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
        public int maxSteps = -1;
        int feldhöhe;
        int feldbreite;
        Point zielPosition;
        Point startPosition;
        private Random rand = new Random();


        public Population(int anzahl, int feldhöhe, int feldbreite, Point zielPosition, Point startPosition, int maxSteps)
        {
            this.maxSteps = maxSteps;
            this.zielPosition = zielPosition;
            this.feldhöhe = feldhöhe;
            this.feldbreite = feldbreite;
            this.startPosition = startPosition;
            dots = new Dot[anzahl];
            for (int i = 0; i < anzahl; i++)
                dots[i] = new Dot(startPosition, i, maxSteps, rand);
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


        public bool SoManyReachedGoal(int prozent)
        {
            int zielwert = dots.Length * prozent / 100;
            int count = 0;

            foreach (Dot d in dots)
            {
                if (d.reachedGoal)
                    count++;
            }

            return count >= zielwert;
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

        public int[] GetDeadReachedGoal()
        {
            int[] res = new int[2];

            if (dots.Length < 1) return res;

            int dead = 0;
            int reachedGoal = 0;

            foreach (Dot d in dots)
            {
                if (d.isDead) dead++;
                if (d.reachedGoal) reachedGoal++;
            }

            res[0] = dead;
            res[1] = reachedGoal;

            return res;
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


        public List<Dot> GetReihenfolge()
        {
            List<Dot> sorted = new List<Dot>();
            foreach (var d in dots.OrderByDescending(i => i.fitness))
                sorted.Add(d);

            return sorted;
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
            newDots[0] = dots[bestDotIndex].getChild(maxSteps);
            newDots[0].isBest = true;
            for (int i = 1; i < newDots.Length; i++)
            {
                //select parent based on fitness
                Dot parent = selectParent(i);

                // For Status
                if (genInfo != null)
                genInfo.RankChosen(parent.rang);

                //get baby from them
                newDots[i] = parent.getChild(maxSteps);
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
          
            double rand = this.rand.NextDouble() / faktor;
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

        public double durchschnittlicheÄnderungen()
        {
            double ratio = 0;

            for (int a = 1; a < dots.Length; a++)
            {
                for (int b = 0; b < dots[a].brain.directions.Length; b++)
                {
                    if (dots[a].brain.directions[b] != dots[0].brain.directions[b])
                        ratio++;
                }
            }

            return ratio/ (dots.Length-1);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //mutates all the brains of the babies
        public void mutateBabies()
        {
            for (int i = 1; i < dots.Length; i++)
            {
                dots[i].brain.mutate();
            }
        }

        public Dot getBestDot()
        {
            return dots[getBestDotIndex()];
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

            double größte = 0;
            double kleinste = 1;
            foreach (Dot d in dots)
            {
                int rang = dots.Length;

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

            //if this dot reached the goal then reset the minimum number of steps it takes to get to the goal
            if (dots[maxIndex].reachedGoal)
            {
                maxSteps = dots[maxIndex].brain.step;
            }

            return maxIndex;
        }
    }
}