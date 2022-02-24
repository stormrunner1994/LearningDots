using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDots
{
    public class Hindernis
    {
        public enum Typ { Rechteck};
        public Typ typ;
        public Point position;
        public int länge;
        public int höhe;
        public Color color;


        public Hindernis(Point position, int länge, int höhe, Typ typ, Color color)
        {
            this.position = position;
            this.länge = länge;
            this.höhe = höhe;
            this.typ = typ;
            this.color = color;
        }
    }
}
