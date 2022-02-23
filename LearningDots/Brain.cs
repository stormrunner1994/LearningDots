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
        public int index = 0;

        public Brain(int size, int index)
        {
            this.index = index;
            directions = new Vector[size];
            randomize();
        }

        public Brain (Brain brain)
        {
            directions = new Vector[brain.directions.Length];
            for (int a = 0; a < directions.Length; a++)
                directions[a] = new Vector(brain.directions[a].X, brain.directions[a].Y);
        }

        void randomize()
        {
            Random rand = new Random(index);
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

        public void mutate(int index)
        {
            Random rand = new Random(index);
            for (int i = 0; i < directions.Length; i++)
            {
                int irand = rand.Next(0, 100);
                if (irand < 10)
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
