using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            labelprogress.BackColor = Color.Transparent;
            
            formStartEndpoint = new FormStartEndpoint(panel1);
            Setting setting = new Setting(formStartEndpoint.zielPos,
                formStartEndpoint.startPos, 100, true, 1000, true,
                new List<Hindernis>(), speed, new Dictionary<Setting.AbbruchBedingung,int>());
            training = new Training(panel1, setting, this);
            panel1.MouseDown += Panel1_MouseDown;
            panel1.MouseUp += Panel1_MouseUp;
        }

        private FormStartEndpoint formStartEndpoint;
        FormTrainingsmodus ftm;
        private int speed = 5;
        //private Setting setting;

        private List<Hindernis> hindernisse = new List<Hindernis>();
        Training training;
        Point linienStart = new Point();
        Point linienZiel = new Point();

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            linienZiel = new Point(e.X, e.Y);

            if (!linienStart.IsEmpty && !linienZiel.IsEmpty && comboBoxobstacle.Text == "Draw by yourself")
            {
                int länge = Convert.ToInt32(Math.Abs(linienZiel.X - linienStart.X));
                int höhe = Convert.ToInt32(Math.Abs(linienZiel.Y - linienStart.Y));

                if (länge > höhe) höhe = speed + 1;
                else if (höhe > länge) länge = speed + 1;

                hindernisse.Add(new Hindernis(linienStart, länge, höhe, Hindernis.Typ.Rechteck, Color.Blue));
                panel1.Invalidate();
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            linienStart = new Point(e.X, e.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonLoadObstacle.Enabled = File.Exists("obstacle.csv");
            buttonresetTraining.Enabled = false;
            comboBoxobstacle.SelectedIndex = 2;
            comboBoxmaxSchritte.SelectedIndex = 0;
            comboBoxanzahldots.SelectedIndex = 8;
            comboBoxmaxtrainingszeit.SelectedIndex = 0;
            checkBoxZuschauen.Checked = false;
            checkBoxdiagonal.Checked = true;
            //buttonTrain_Click(sender, e);
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {            
            if (buttonTrain.Text == "Start training")
            {
                buttonresetTraining.Enabled = false;
                training.SetSettings(GetActualSetting(Setting.AbbruchBedingung.Time));
                training.Starten();
                buttonTrain.Text = "Stop training";
            }
            else if (buttonTrain.Text == "Continue training")
            {
                buttonresetTraining.Enabled = false;
                training.SetZuschauen(checkBoxZuschauen.Checked);
                training.SetAbbruchBedingung(Setting.AbbruchBedingung.Time, Setting.GetTimeInSecs(comboBoxmaxtrainingszeit.Text));
                training.Continue();
                buttonTrain.Text = "Stop training";
            }
            else
            {
                // Sichere besten
                training.SafeBest();
                training.Stoppen();
                buttonTrain.Text = "Continue training";
                buttonresetTraining.Enabled = true;
            }
        }
             
          

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonShowBestDot.Text == "Show best dot")
            {
                buttonShowBestDot.Text = "Stop best dot";
                training.LoadBest();
                richTextBoxstatus.Text =  training.GetLoadedDotStats();
                training.LasseBestenAblaufen();
            }
            else
            {
                buttonShowBestDot.Text = "Show best dot";
                training.HalteBestenAn();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Hindernis h in hindernisse)
            {
                if (h.typ == Hindernis.Typ.Rechteck)
                    e.Graphics.FillRectangle(new SolidBrush(h.color), h.position.X, h.position.Y, h.breite, h.höhe);
            }

            foreach (Pixel p in Helper.deathRegionDots)
            {
                e.Graphics.FillRegion(new SolidBrush(p.color), new Region(new Rectangle(p.location.X, p.location.Y, 5, 5)));
            }
        }
                                    

        private void checkBoxZuschauen_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxmaxtrainingszeit.Enabled = !checkBoxZuschauen.Checked;
        }

        private void comboBoxobstacle_SelectedIndexChanged(object sender, EventArgs e)
        {
            hindernisse.Clear();
            if (comboBoxobstacle.SelectedIndex == 0)
            {
                panel1.Refresh();
            }
            else if (comboBoxobstacle.SelectedIndex == 1)
            {
                hindernisse.Add(new Hindernis(new Point(200, 200), 800, 10, Hindernis.Typ.Rechteck, Color.Blue));
                panel1.Invalidate();
            }
            else if (comboBoxobstacle.SelectedIndex == 2)
            {
                hindernisse.Add(new Hindernis(new Point(10, 200), 800, 10, Hindernis.Typ.Rechteck, Color.Blue));
                panel1.Invalidate();
            }
        }

        private void buttonSaveObstacle_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("obstacle.csv");
            foreach (Hindernis h in hindernisse)
                sw.WriteLine(h.GetHindernis());
            sw.Close();
            buttonLoadObstacle.Enabled = File.Exists("obstacle.csv");
        }

        private void buttonLoadObstacle_Click(object sender, EventArgs e)
        {
            hindernisse.Clear();
            StreamReader sr = new StreamReader("obstacle.csv");
            while (!sr.EndOfStream)
            {
                string zeile = sr.ReadLine();
                Hindernis h = new Hindernis(zeile);
                hindernisse.Add(h);
            }
            sr.Close();

            if (hindernisse.Count > 0)
            panel1.Invalidate();
        }

        private Setting GetActualSetting(Setting.AbbruchBedingung abbruchBedingung)
        {
            Point zielPos = formStartEndpoint.zielPos;
            Point startPos = formStartEndpoint.startPos;
            int populationsGröße = Convert.ToInt32(comboBoxanzahldots.Text);
            int maxSteps = Convert.ToInt32(comboBoxmaxSchritte.Text);
            Dictionary<Setting.AbbruchBedingung, int> abbruchBedingungen = new Dictionary<Setting.AbbruchBedingung, int>();
            abbruchBedingungen.Add(abbruchBedingung, Setting.GetTimeInSecs(comboBoxmaxtrainingszeit.Text));
            Setting setting = new Setting(zielPos, startPos, populationsGröße, checkBoxZuschauen.Checked,
                maxSteps, checkBoxdiagonal.Checked,hindernisse,  speed, abbruchBedingungen);
            return setting;
        }

        private void buttonresetTraining_Click(object sender, EventArgs e)
        {
            // Sichere besten
            training.SafeBest();          
            training.Reset(GetActualSetting(Setting.AbbruchBedingung.Time));
            buttonTrain.Text = "Start training";
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void checkBoxShowDeathDistribution_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowDeathDistribution.Checked)
            {
                Helper.GenerateDeathRegions(training);
            }
            else
            {
                Helper.deathRegionDots.Clear();
            }

            panel1.Invalidate();
        }



        private void buttonnextgen_Click(object sender, EventArgs e)
        {
            buttonresetTraining.Enabled = false;
            buttonnextgen.Enabled = false;
            training.Reset(GetActualSetting(Setting.AbbruchBedingung.NextGen));
            training.Continue();
            buttonTrain.Text = "Stop training";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormView fv = new FormView();
            fv.ShowDialog();
        }

        private void startEndpointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formStartEndpoint.ShowDialog();
            training.SetStartpunkt(formStartEndpoint.startPos);
            training.SetZielpunkt(formStartEndpoint.zielPos);
        }

        private void trainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ftm = new FormTrainingsmodus(panel1, formStartEndpoint.startPos,
                formStartEndpoint.zielPos,speed);
            ftm.ShowDialog();
        }
    }
}
