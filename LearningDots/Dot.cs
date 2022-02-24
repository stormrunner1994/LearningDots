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
        public const int SPEED = 5;
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
        public int maxSteps = 0;
        private Random rand;
        private List<Hindernis> hindernisse;

        // Spezial Dots
        public Dot(int größe, Color color, Point startPosition, int index)
        {
            this.index = index;
            this.größe = größe;
            this.color = color;
            this.startPosition = this.position = startPosition;
        }

        // Für loaded Dot
        public Dot(Point startPosition, Brain brain)
        {
            this.startPosition = startPosition;
            this.position = startPosition;
            this.brain = brain;
        }

        public Dot(Point startPosition, int index, int maxSteps, Random rand, bool erlaubeDiagonaleZüge, List<Hindernis> hindernisse)
        {
            this.rand = rand;
            this.maxSteps = maxSteps;
            this.index = index;
            brain = new Brain(maxSteps, index, rand, erlaubeDiagonaleZüge);
            this.startPosition = this.position = startPosition;
            this.hindernisse = hindernisse;
        }


        public void update(int feldbreite, int feldhöhe, int goalX, int goalY)
        {
            if (isDead || reachedGoal) return;

            move();
            // Rand
            if (position.X < 2 || position.Y < 2 || position.X > feldbreite - 2 || position.Y > feldhöhe - 2)
                isDead = true;
            // Ziel erreicht
            else if (Math.Abs(goalX - position.X) < 5 && Math.Abs(goalY - position.Y) < 5)
                reachedGoal = true;
            // An Hindernis gestoßen
            else if (AnHindernisGestoßen())
                isDead = true;
            
        }

        private bool AnHindernisGestoßen()
        {
            foreach (Hindernis h in hindernisse)
            {
                // Liegt im Hindernis?
                if (position.X >= h.position.X && position.X <= h.position.X + h.länge
                    && position.Y >= h.position.Y && position.Y <= h.position.Y + h.höhe)
                    return true;
            }

            return false;
        }

        public void move()
        {
            if (brain.step >= brain.directions.Length)
            {
                isDead = true;
                return;
            }

            Vector vec = brain.directions[brain.step];
            position.X += (int)vec.X * SPEED;
            position.Y += (int)vec.Y * SPEED;
            brain.step++;
        }

        public void calculateFitness(int goalX, int goalY)
        {
            double distanceToGoal = Math.Sqrt(Math.Pow(goalX - position.X, 2) + Math.Pow(goalY - position.Y, 2));

            if (distanceToGoal == 0) distanceToGoal = 1;

            if (reachedGoal)
            {
                fitness = 1.0 + 1.0 / (distanceToGoal * distanceToGoal) + 1.0 / brain.step;
            }
            else
            {
                fitness = 1.0 / (distanceToGoal * distanceToGoal);

            }
        }

        public Dot getChild(int maxSteps)
        {
            Dot baby = new Dot(startPosition, index, maxSteps, rand, brain.erlaubeDiagonaleZüge, hindernisse);
            baby.brain = new Brain(brain, maxSteps); // Copy Constructor
            return baby;
        }
    }
}
