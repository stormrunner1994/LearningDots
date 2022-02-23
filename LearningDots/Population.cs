﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDots
{
    class Population
    {
        const bool SETZERANG = true;
        public Dot[] dots;
        double fitnessSum;
        public int gen = 1;
        int bestDotIndex = 0; //the index of the best dot in the dots[]
        int maxSteps = 1000;
        int feldhöhe;
        int feldbreite;
        Point zielPosition;
        Point startPosition;
        List<double> bestfitnesses = new List<double>();


        public Population(int anzahl, int feldhöhe, int feldbreite, Point zielPosition, Point startPosition)
        {
            this.zielPosition = zielPosition;
            this.feldhöhe = feldhöhe;
            this.feldbreite = feldbreite;
            this.startPosition = startPosition;
            dots = new Dot[anzahl];
            for (int i = 0; i < anzahl; i++)
                dots[i] = new Dot(startPosition, i);
        }

        public void update()
        {
            for (int i = 0; i < dots.Length; i++)
            {
                if (dots[i].brain.step > maxSteps)
                    dots[i].isDead = true;
                else
                    dots[i].update(feldbreite, feldhöhe, zielPosition.X, zielPosition.Y);
            }
        }

        public void calculateFitnessForAllDots()
        {
            for (int i = 0; i < dots.Length; i++)
                dots[i].calculateFitness(zielPosition.X, zielPosition.Y);
        }

        public bool allDotsFinished()
        {
            for (int i = 0; i < dots.Length; i++)
            {
                // Reached goal????
                if (!dots[i].isDead && !dots[i].reachedGoal)
                    return false;
            }

            return true;
        }

        public string FinishedQuote()
        {
            int iFinished = 0;
            for (int i = 0; i < dots.Length; i++)
            {
                if (dots[i].isDead || dots[i].reachedGoal)
                    iFinished++;
            }

            return iFinished + "/" + dots.Length;
        }

        public double[] GetBestWorstAvgFitness()
        {
            double[] bestWorst = new double[3];

            if (dots.Length < 1) return bestWorst;

            double best = dots.First().fitness;
            double worst = dots.First().fitness;
            double avg = 0;

            foreach (Dot d in dots)
            {
                avg += d.fitness;
                if (d.fitness < worst) worst = d.fitness;
                else if (d.fitness > best) best = d.fitness;
            }

            bestWorst[0] = best;
            bestWorst[1] = worst;
            bestWorst[2] = avg / dots.Length;
            return bestWorst;
        }

        // next generation of dots
        public void naturalSelection(GenInfo genInfo)
        {
            Dot[] newDots = new Dot[dots.Length]; //next gen
            bestDotIndex = getBestDotIndex();
            calculateFitnessSum();

            //the champion lives on 
            bestfitnesses.Add(dots[bestDotIndex].fitness);
            newDots[0] = dots[bestDotIndex].getChild();
            newDots[0].isBest = true;
            for (int i = 1; i < newDots.Length; i++)
            {
                //select parent based on fitness
                Dot parent = selectParent(i);

                // For Status
                genInfo.RankChosen(i);

                //get baby from them
                newDots[i] = parent.getChild();
            }

            // overwrite dots with new generation
            for (int i = 0; i < newDots.Length; i++)
                dots[i] = newDots[i];
            gen++;
        }

        public void calculateFitnessSum()
        {
            fitnessSum = 0;
            for (int i = 0; i < dots.Length; i++)
                fitnessSum += dots[i].fitness;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        //chooses dot from the population to return randomly(considering fitness)

        //this function works by randomly choosing a value between 0 and the sum of all the fitnesses
        //then go through all the dots and add their fitness to a running sum and if that sum is greater than the random value generated that dot is chosen
        //since dots with a higher fitness function add more to the running sum then they have a higher chance of being chosen
        Dot selectParent(int index)
        {
            double faktor = 1 / fitnessSum;
            double rand = new Random(index).NextDouble() / faktor;
            double runningSum = 0;

            for (int i = 0; i < dots.Length; i++)
            {
                runningSum += dots[i].fitness;
                if (runningSum > rand)
                {
                    return dots[i];
                }
            }

            return dots.Last();
        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //mutates all the brains of the babies
        public void mutateBabies()
        {
            for (int i = 1; i < dots.Length; i++)
            {
                dots[i].brain.mutate(i);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //finds the dot with the highest fitness and sets it as the best dot
        public int getBestDotIndex()
        {
            double max = 0;
            int maxIndex = 0;
            for (int i = 0; i < dots.Length; i++)
            {
                if (dots[i].fitness > max)
                {
                    max = dots[i].fitness;
                    maxIndex = i;
                }
            }

            // setze Rang anhand von Fitness
            if (SETZERANG)
            {
                double größte = 0;
                double kleinste = 1;
                foreach (Dot d in dots)
                {
                    int rang = 100;

                    if (d.fitness > größte) größte = d.fitness;
                    if (d.fitness < kleinste) kleinste = d.fitness;

                    foreach (Dot dd in dots)
                    {
                        if (d == dd) continue;
                        if (d.fitness > dd.fitness)
                            rang--;

                    }
                    d.rang = rang;
                }
            }

            //if this dot reached the goal then reset the minimum number of steps it takes to get to the goal
            if (dots[maxIndex].reachedGoal)
            {
                maxSteps = dots[maxIndex].brain.step;
            }

            return maxIndex;
        }
    }
}
