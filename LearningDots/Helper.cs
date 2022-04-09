using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDots
{
    class Helper
    {
        public static List<Pixel> deathRegionDots = new List<Pixel>();

        public static void GenerateDeathRegions(Training training)
        {
            deathRegionDots.Clear();

            /*                	
                    linen #FAF0E6 250,240,230
                    LightSalmon #FFA07A 255,160,122
                    coral #FF7F50 255,127,80
                    OrangeRed3 #CD3700 205,55,0
                    firebrick #B22222 178,34,34
                    red4 #8B0000 139,0,0     
                */

            if (training.GetDeathLocations().Count == 0)
            {
                return;
            }

            List<Color> colors = new List<Color>();
            colors.Add(Color.FromArgb(250, 240, 230));
            colors.Add(Color.FromArgb(255, 160, 122));
            colors.Add(Color.FromArgb(255, 127, 80));
            colors.Add(Color.FromArgb(205, 55, 0));
            colors.Add(Color.FromArgb(178, 34, 34));
            colors.Add(Color.FromArgb(139, 0, 0));
            int highestVisit = training.GetDeathLocations().OrderByDescending(i => i.Value).First().Value;
            int max = 0;

            Dictionary<int, int> verteilung = new Dictionary<int, int>();
            for (int a = 0; a < colors.Count; a++)
                verteilung.Add(a, 0);

            foreach (KeyValuePair<string, int> pair in training.GetDeathLocations())
            {
                string[] splits = pair.Key.Split(';');

                double compare = (0.0 + pair.Value) / ((0.0 + highestVisit) / colors.Count);

                int index = GetIndex(colors.Count, compare);

                if (index > colors.Count - 1) index--;

                if (index == colors.Count - 1)
                    max++;

                verteilung[index]++;

                Color c = colors[index];
                Point p = new Point(Convert.ToInt32(splits[0].ToString()),
                    Convert.ToInt32(splits[1].ToString()));
                deathRegionDots.Add(new Pixel(c, p));
            }
        }

        private static int GetIndex(int count, double compare)
        {
            for (int a = count; a > 1; a--)
            {
                double log = Math.Log(a) / 1.5;
                if (compare > log)
                    return a - 1;
            }

            return 0;
        }
    }
}
