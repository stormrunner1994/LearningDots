using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningDots
{
    public partial class FormStartEndpoint : Form
    {
        enum Richtung { Höhe, Breite };
        private Color defaultforecolor;
        private Panel panel;
        public Point zielPos;
        public Point startPos;


        public FormStartEndpoint(Panel panel)
        {
            InitializeComponent();
            this.panel = panel;
            defaultforecolor = textBoxstartX.ForeColor; 
            Point zielPos = new Point(panel.Width / 2, 0);
            Point startPos = new Point(panel.Width / 2, panel.Height - Training.SPEZIALPUNKTEGRÖSSE);
            this.zielPos = zielPos;
            this.startPos = startPos;
            textBoxstartX.Text = startPos.X.ToString();
            textBoxstartY.Text = startPos.Y.ToString();
            textBoxzielX.Text = zielPos.X.ToString();
            textBoxzielY.Text = zielPos.Y.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxzielY_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite, true))
            {
                tb.ForeColor = Color.Red;
                return;
            }

            tb.ForeColor = defaultforecolor;
        }       

        private bool TextBoxValide(string text, Richtung richtung, bool bMessagebox)
        {
            int iout;
            if (!Int32.TryParse(text, out iout))
            {
                if (bMessagebox)
                    MessageBox.Show("Wert muss eine Ganzzahl sein.");
                return false;
            }

            int wert = Convert.ToInt32(text);
            if (wert < 0)
            {
                if (bMessagebox)
                    MessageBox.Show("Wert darf nicht kleiner 0 sein.");
                return false;
            }
            if (richtung == Richtung.Breite && wert > panel.Width)
            {
                if (bMessagebox)
                    MessageBox.Show("Wert darf nicht größer als Feldbreite [" + panel.Width + " sein.");
                return false;
            }
            else if (richtung == Richtung.Höhe && wert > panel.Height)
            {
                if (bMessagebox)
                    MessageBox.Show("Wert darf nicht größer als Feldhöhe [" + panel.Height + " sein.");
                return false;
            }
            return true;
        }

        private void textBoxstartX_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite, false))
            {
                tb.ForeColor = Color.Red;
                return;
            }

            tb.ForeColor = defaultforecolor;
        }

        private void textBoxstartY_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite, false))
            {
                tb.ForeColor = Color.Red;
                return;
            }

            tb.ForeColor = defaultforecolor;
        }

        private void textBoxzielX_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
