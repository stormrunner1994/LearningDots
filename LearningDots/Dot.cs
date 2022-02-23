using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Point = System.Drawing.Point;

namespace LearningDots
{
    public class Dot
    {
        public int speed = 1;
        public int größe = 5;
        public Color color = Color.Black;
        public Point position;
        public Point startPosition;
        public Brain brain;
        public bool isDead = false;
        public bool reachedGoal = false;
        public bool isBest = false;
        public double fitness = 0;
        public int index;
        public int rang = -1;

        public Dot(int größe, Color color, Point startPosition, int index)
        {
            this.index = index;
            this.größe = größe;
            this.color = color;
            this.startPosition = this.position = startPosition;
        }

        public Dot(Point startPosition, int index)
        {
            this.index = index;
            brain = new Brain(400, index);
            this.startPosition = this.position = startPosition;
        }


        public void update(int feldbreite, int feldhöhe, int goalX, int goalY)
        {
            if (isDead || reachedGoal) return;

            move();
            if (position.X < 2 || position.Y < 2 || position.X > feldbreite - 2 || position.Y > feldhöhe - 2)
                isDead = true;
            else if (Math.Abs(goalX - position.X) < 5 && Math.Abs(goalY - position.Y) < 5)
                reachedGoal = true;
        }    

       public void move()
        {
            if (brain.step >= brain.directions.Length)
            {
                isDead = true;
                return;
            }

            Vector vec = brain.directions[brain.step];
            position.X += (int)vec.X * speed;
            position.Y += (int)vec.Y * speed;
            brain.step++;
        }

        public void calculateFitness(int goalX, int goalY)
        {
            if (reachedGoal)
            {
                //if the dot reached the goal then the fitness is based on the amount of steps it took to get there
                fitness = 1.0 / 16.0 + 10000.0 / (double)(brain.step * brain.step);
            }
            else
            {
                //if the dot didn't reach the goal then the fitness is based on how close it is to the goal
                double distanceToGoal = Math.Sqrt(Math.Pow(goalX - position.X, 2) + Math.Pow(goalY - position.Y, 2));
                fitness = 1.0 / (distanceToGoal * distanceToGoal);
            }
        }

        public Dot getChild()
        { 
            Dot baby = new Dot(startPosition, index);
            baby.brain = new Brain(brain); // Copy Constructor
            return baby;
        }
    } 
}
