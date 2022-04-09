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
        public enum Typ { Rechteck };
        public Typ typ;
        public Point position;
        public int breite;
        public int höhe;
        public Color color = Color.Blue;
        // public int drehung


        public Hindernis(string zeile)
        {
            string[] splits = zeile.Split(';');
            position = new Point(Convert.ToInt32(splits[0].Split(',')[0]), Convert.ToInt32(splits[0].Split(',')[1]));
            breite = Convert.ToInt32(splits[1]);
            höhe = Convert.ToInt32(splits[2]);
            // Enum.Parse(Typ, splits[3]);
            typ = Typ.Rechteck;
            color = Color.FromArgb(Convert.ToInt32(splits[4]));
        }


        public Hindernis(Point position, int breite, int höhe, Typ typ, Color color)
        {
            this.position = position;
            this.breite = breite;
            this.höhe = höhe;
            this.typ = typ;
            this.color = color;
        }

        public Hindernis(Point position, int breite, int höhe, Typ typ)
        {
            this.position = position;
            this.breite = breite;
            this.höhe = höhe;
            this.typ = typ;
        }

        public string GetHindernis()
        {
            return position.X + "," + position.Y + ";" + breite + ";" + höhe + ";" + typ.ToString() + ";"
               + color.ToArgb().ToString();
        }
    }
}
