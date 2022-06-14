using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningDots
{
    public class Hindernis
    {
        public enum Typ { Rechteck };
        public Typ typ;
        public Point location;
        public int breite;
        public int höhe;
        public Color color = Color.Blue;
        public PictureBox pictureBox = null;
        // public int drehung


        public Hindernis(string zeile)
        {
            string[] splits = zeile.Split(';');
            location = new Point(Convert.ToInt32(splits[0].Split(',')[0]), Convert.ToInt32(splits[0].Split(',')[1]));
            breite = Convert.ToInt32(splits[1]);
            höhe = Convert.ToInt32(splits[2]);
            // Enum.Parse(Typ, splits[3]);
            typ = Typ.Rechteck;
            color = Color.FromArgb(Convert.ToInt32(splits[4]));
        }


        public Hindernis(Point location, int breite, int höhe, Typ typ, Color color)
        {
            this.location = location;
            this.breite = breite;
            this.höhe = höhe;
            this.typ = typ;
            this.color = color;
        }

        public Hindernis(Point location, int breite, int höhe, Typ typ)
        {
            this.location = location;
            this.breite = breite;
            this.höhe = höhe;
            this.typ = typ;
        }

        public string GetHindernis()
        {
            return location.X + "," + location.Y + ";" + breite + ";" + höhe + ";" + typ.ToString() + ";"
               + color.ToArgb().ToString();
        }
    }
}
