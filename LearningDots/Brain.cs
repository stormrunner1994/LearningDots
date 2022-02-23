using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearningDots
{
    public class Brain
    {
        public Vector[] directions; //series of vectors which get the dot to the goal (hopefully)
        public int step = 0;
        private Random rand;

        public Brain(int size, int index, Random rand)
        {
            this.rand = rand; 
            directions = new Vector[size];
            randomize();
        }

        // für loaded Dot
        public Brain(List<Vector> directions)
        {
            this.directions = new Vector[directions.Count];
            for (int a = 0; a < directions.Count; a++)
                this.directions[a] = directions[a];
        }

        public Brain (Brain brain, int size)
        {
            this.rand = brain.rand;
            directions = new Vector[size];
            for (int a = 0; a < size; a++)
                directions[a] = brain.directions[a];
        }

        void randomize()
        {
            for (int i = 0; i < directions.Length; i++)
            {
                int x = rand.Next(-1, 2);
                int y = rand.Next(-1, 2);

                while (x == 0 && y == 0)
                {
                    x = rand.Next(-1, 2);
                    y = rand.Next(-1, 2);
                }

                directions[i] = new Vector(x, y);
            }
        }

        public void mutate()
        {
            for (int i = 0; i < directions.Length; i++)
            {
                int irand = rand.Next(0, 100);
                if (irand < 1)
                {
                    // random direction
                    int x = rand.Next(-1, 2);
                    int y = rand.Next(-1, 2);
                    directions[i] = new Vector(x, y);
                }
            }
        }
    }

}
