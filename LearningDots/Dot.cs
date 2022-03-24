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
        public int speed = 5;
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
        public Dictionary<string, int> besuchtePositionen = new Dictionary<string, int>(); // X;Y

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

        public Dot(Point startPosition, int index, int maxSteps, Random rand, bool erlaubeDiagonaleZüge, List<Hindernis> hindernisse,
            int speed)
        {
            this.speed = speed;
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

            Move();
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
            // TODO hindernis greift nicht immer
            foreach (Hindernis h in hindernisse)
            {
                // Hängt davon ab, wie Viereck gedreht ist
                // Liegt im Hindernis?
                if (position.X >= h.position.X && position.X <= h.position.X + h.länge
                    && position.Y >= h.position.Y && position.Y <= h.position.Y + h.höhe)
                    return true;
            }

            return false;
        }

        public void Move()
        {
            if (brain.step >= brain.directions.Length)
            {
                isDead = true;
                return;
            }

            Vector vec = brain.directions[brain.step];
            position.X += (int)vec.X * speed;
            position.Y += (int)vec.Y * speed;

            string pos = position.X + ";" + position.Y;
            if (besuchtePositionen.ContainsKey(pos))
                besuchtePositionen[pos]++;
            else
                besuchtePositionen.Add(pos, 1);

            brain.step++;
        }

        public void CalculateFitness(int goalX, int goalY)
        {
            double besuchtAnteil = (0.0 + AnzahlMehrfachBesuchtePunkte()) / 100;
            double direkteUmkehr = (0.0 + AnzahlDirekteUmkehr()) / 10;
            
            if (reachedGoal)
            {
                fitness = 1.0 + 1.0 / (brain.step + besuchtAnteil + direkteUmkehr);
            }
            else
            {
                // bleibe hier <= 1
                // belohne, wer viele Schritte getan hat
                int nichtGenutzeSchritte = maxSteps - brain.step;

                // Hindernisse vorhanden, bei obstacle ist distanz zum ziel egal
                if (hindernisse.Count > 0)
                    fitness = 1.0 / (nichtGenutzeSchritte + besuchtAnteil + direkteUmkehr);
                else
                {
                    double distanceToGoal = Math.Sqrt(Math.Pow(goalX - position.X, 2) + Math.Pow(goalY - position.Y, 2));
                    fitness = 1.0 / (distanceToGoal + nichtGenutzeSchritte + besuchtAnteil + direkteUmkehr);
                }
            }
        }

        private int AnzahlDirekteUmkehr()
        {
            // Abzug für jede direkte Umkehr
            int anzahl = 0;
            Vector letzte = brain.directions[0];

            for (int a = 1; a < brain.directions.Length; a++)
            {
                Vector vec = brain.directions[a];

                // gleicht sich aus
                if (letzte.X + vec.X == 0 && letzte.Y + vec.X == 0)
                    anzahl++;

                letzte = vec;
            }

            return anzahl;
        }

        private int AnzahlMehrfachBesuchtePunkte()
        {
            // Abzug für jeden mehrfach besuchten Ort
            int anzahl = 0;
            foreach (KeyValuePair<string, int> s in besuchtePositionen.OrderByDescending(i => i.Value))
            {
                if (s.Value == 1) break;
                anzahl += s.Value - 1;
            }
            return anzahl;
        }

        public Dot getChild(int maxSteps)
        {
            Dot baby = new Dot(startPosition, index, maxSteps, rand, brain.erlaubeDiagonaleZüge, hindernisse, speed);
            baby.brain = new Brain(brain, maxSteps); // Copy Constructor
            return baby;
        }
    }
}
