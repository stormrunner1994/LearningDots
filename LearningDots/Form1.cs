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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            defaultforecolor = textBoxstartX.ForeColor;
            labelprogress.BackColor = Color.Transparent;
            Point zielPos = new Point(panel1.Width / 2, 0);
            Point startPos = new Point(panel1.Width / 2, panel1.Height - Training.SPEZIALPUNKTEGRÖSSE);

            setting = new Setting(zielPos, startPos, 100, true, 1000, true, new List<Hindernis>(),1);
            training = new Training(panel1, setting, richTextBox1, progressBar1, labelprogress, buttonTrain);
        }


        private Setting setting;
        private Color defaultforecolor;
        enum Richtung { Höhe, Breite };

        private List<Hindernis> hindernisse = new List<Hindernis>();
        Training training;


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxmaxSchritte.SelectedIndex = 1;
            comboBoxanzahldots.SelectedIndex = 2;
            comboBoxmaxtrainingszeit.SelectedIndex = 0;
            textBoxstartX.Text = training.GetStartpunkt().X.ToString();
            textBoxstartY.Text = training.GetStartpunkt().Y.ToString();
            textBoxzielX.Text = training.GetZielpunkt().X.ToString();
            textBoxzielY.Text = training.GetZielpunkt().Y.ToString();
            checkBoxZuschauen.Checked = true;
            checkBoxdiagonal.Checked = true;
            //buttonTrain_Click(sender, e);
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            if (buttonTrain.Text == "Start training")
            {
                Point zielPos = new Point(Convert.ToInt32(textBoxzielX.Text), Convert.ToInt32(textBoxzielY.Text));
                Point startPos = new Point(Convert.ToInt32(textBoxstartX.Text), Convert.ToInt32(textBoxstartY.Text));
                int populationsGröße = Convert.ToInt32(comboBoxanzahldots.Text);
                int maxSteps = Convert.ToInt32(comboBoxmaxSchritte.Text);
                setting = new Setting(zielPos, startPos, populationsGröße, checkBoxZuschauen.Checked, maxSteps, checkBoxdiagonal.Checked,
                    hindernisse, Setting.GetTimeInSecs(comboBoxmaxtrainingszeit.Text));
                training.SetSettings(setting);
                training.Starten();
                buttonTrain.Text = "Stop training";
                textBoxstartX.Enabled = textBoxstartY.Enabled = textBoxzielX.Enabled = textBoxzielY.Enabled = false;
            }
            else
            {
                // Sichere besten
                training.SafeBest();
                training.Stoppen();
                buttonTrain.Text = "Start training";
                textBoxstartX.Enabled = textBoxstartY.Enabled = textBoxzielX.Enabled = textBoxzielY.Enabled = true;
            }
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
            if (richtung == Richtung.Breite && wert > panel1.Width)
            {
                if (bMessagebox)
                    MessageBox.Show("Wert darf nicht größer als Feldbreite [" + panel1.Width + " sein.");
                return false;
            }
            else if (richtung == Richtung.Höhe && wert > panel1.Height)
            {
                if (bMessagebox)
                    MessageBox.Show("Wert darf nicht größer als Feldhöhe [" + panel1.Height + " sein.");
                return false;
            }
            return true;
        }

        private void textBoxstartX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) return;

            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite, true))
            {
                buttonTrain.Enabled = false;
                tb.ForeColor = Color.Red;
                return;
            }

            buttonTrain.Enabled = true;
            tb.ForeColor = defaultforecolor;
            training.SetStartpunkt(new Point(Convert.ToInt32(tb.Text), training.GetStartpunkt().Y));
        }

        private void textBoxzielX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) return;

            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite, true))
            {
                buttonTrain.Enabled = false;
                tb.ForeColor = Color.Red;
                return;
            }

            buttonTrain.Enabled = true;
            tb.ForeColor = defaultforecolor;
            training.SetZielpunkt(new Point(Convert.ToInt32(tb.Text), training.GetZielpunkt().Y));

        }

        private void textBoxstartY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) return;

            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite, true))
            {
                buttonTrain.Enabled = false;
                tb.ForeColor = Color.Red;
                return;
            }

            buttonTrain.Enabled = true;
            tb.ForeColor = defaultforecolor;
            training.SetStartpunkt(new Point(training.GetStartpunkt().X, Convert.ToInt32(tb.Text)));
        }

        private void textBoxzielY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) return;

            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite, true))
            {
                buttonTrain.Enabled = false;
                tb.ForeColor = Color.Red;
                return;
            }

            buttonTrain.Enabled = true;
            tb.ForeColor = defaultforecolor;
            training.SetZielpunkt(new Point(training.GetZielpunkt().X, Convert.ToInt32(tb.Text)));
        }

        private void buttonZeichneHindernis_Click(object sender, EventArgs e)
        {
            if (buttonZeichneHindernis.Text == "Draw obstacle")
            {
                // schweres Hindernis
                hindernisse.Add(new Hindernis(new Point(10, 200), 800, 10, Hindernis.Typ.Rechteck, Color.Blue));
                // einfaches Hindernis
                //hindernisse.Add(new Hindernis(new Point(200, 200), 800, 10, Hindernis.Typ.Rechteck, Color.Blue));

                buttonZeichneHindernis.Text = "Hide obstacle";
                panel1.Invalidate();
            }
            else
            {
                buttonZeichneHindernis.Text = "Draw obstacle";
                hindernisse.Clear();
                panel1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Load best dot")
            {
                button1.Text = "Stop best dot";
                training.LoadBest();
                training.LasseBestenAblaufen();
            }
            else
            {
                button1.Text = "Load best dot";
                training.HalteBestenAn();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Hindernis h in hindernisse)
            {
                if (h.typ == Hindernis.Typ.Rechteck)
                    e.Graphics.FillRectangle(new SolidBrush(h.color), h.position.X, h.position.Y, h.länge, h.höhe);
            }
        }

        private void textBoxstartX_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite, false))
            {
                buttonTrain.Enabled = false;
                tb.ForeColor = Color.Red;
                return;
            }

            buttonTrain.Enabled = true;
            tb.ForeColor = defaultforecolor;
            training.SetStartpunkt(new Point(Convert.ToInt32(tb.Text), training.GetStartpunkt().Y));
        }

        private void textBoxstartY_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite, false))
            {
                buttonTrain.Enabled = false;
                tb.ForeColor = Color.Red;
                return;
            }

            buttonTrain.Enabled = true;
            tb.ForeColor = defaultforecolor;
            training.SetStartpunkt(new Point(training.GetStartpunkt().X, Convert.ToInt32(tb.Text)));
        }

        private void textBoxzielX_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite, false))
            {
                buttonTrain.Enabled = false;
                tb.ForeColor = Color.Red;
                return;
            }

            buttonTrain.Enabled = true;
            tb.ForeColor = defaultforecolor;
            training.SetZielpunkt(new Point(Convert.ToInt32(tb.Text), training.GetZielpunkt().Y));
        }

        private void textBoxzielY_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite, false))
            {
                buttonTrain.Enabled = false;
                tb.ForeColor = Color.Red;
                return;
            }

            buttonTrain.Enabled = true;
            tb.ForeColor = defaultforecolor;
            training.SetZielpunkt(new Point(training.GetZielpunkt().X, Convert.ToInt32(tb.Text)));
        }

        private void checkBoxZuschauen_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxmaxtrainingszeit.Enabled = !checkBoxZuschauen.Checked;
        }
    }
}
