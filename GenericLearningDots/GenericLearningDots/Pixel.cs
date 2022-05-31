using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDots
{
    public class Pixel
    {
        public Color color;
        public Point location;

        public Pixel(Color color, Point location)
        {
            this.color = color;
            this.location = location;
        }
    }
}
