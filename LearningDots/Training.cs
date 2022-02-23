using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningDots
{
    public class Training
    {
        public static int SPEZIALPUNKTEGRÖSSE = 10;
        private Dot ziel;
        private Dot start;
        private Panel panel;
        private Population population;
        private Timer timer = new Timer();
        private RichTextBox rtbStatus;
        public Status status;

        public Training(Panel panel, Point zielPos, Point startPos, int populationsGröße,
            RichTextBox rtbStatus)
        {
            status = new Status(populationsGröße);
            this.rtbStatus = rtbStatus;
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, startPos,-1);
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, zielPos,-1);
            population = new Population(populationsGröße, panel.Height, panel.Width, ziel.position, start.position);
            this.panel = panel;
            panel.Paint += new PaintEventHandler(panel_Paint);
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        public void SetSettings(Point zielPos, Point startPos, int populationsGröße)
        {
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, startPos,-1);
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, zielPos,-1);
            population = new Population(populationsGröße, panel.Height, panel.Width, ziel.position, start.position);           
        }

        public void ZeichneFeld()
        {
            panel.Invalidate();
        }

        public Point GetStartpunkt()
        {
            return start.position;
        }
        public Point GetZielpunkt()
        {
            return ziel.position;
        }

        public int GetPopulationsGröße()
        {
            return population.dots.Length;
        }

        public void SetStartpunkt(Point startPos)
        {
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, startPos,-1);
            ZeichneFeld();
        }

        public void SetZielpunkt(Point zielPos)
        {
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, zielPos, -1);
            ZeichneFeld();
        }

        public void SetPopulationsGröße(int populationsGröße)
        {
            population = new Population(populationsGröße, panel.Height, panel.Width, ziel.position, start.position);
            ZeichneFeld();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // draw dots again
            panel.Invalidate();

            if (population.allDotsFinished())
            {
                // generic algorithm
                population.calculateFitnessForAllDots();
                double[] bestWorstAvgFitness = population.GetBestWorstAvgFitness();
                status.AddGenInfo(bestWorstAvgFitness[2], bestWorstAvgFitness[1], bestWorstAvgFitness[0]);

                population.naturalSelection(status.GetLastGenInfo());
                population.mutateBabies();
            }
            else
            {
                population.update();
            }
            rtbStatus.Text = "Gen: " + population.gen + "\nFinished: " + population.FinishedQuote();
        }

        public void Starten()
        {
            timer.Start();
        }

        public void Stoppen()
        {
            timer.Stop();
        }


        private void panel_Paint(object sender, PaintEventArgs e)
        {
            foreach (Dot d in population.dots)
            {
                if (d.isBest)
                    e.Graphics.FillEllipse(new SolidBrush(Color.Pink), d.position.X, d.position.Y, d.größe, d.größe);
                else
                    e.Graphics.FillEllipse(new SolidBrush(d.color), d.position.X, d.position.Y, d.größe, d.größe);
            }

            // Zeichne Goal
            e.Graphics.FillEllipse(new SolidBrush(ziel.color), ziel.position.X, ziel.position.Y, ziel.größe, ziel.größe);
            // Zeichne Start
            e.Graphics.FillEllipse(new SolidBrush(start.color), start.position.X, start.position.Y, start.größe, start.größe);
        }

        // https://social.msdn.microsoft.com/Forums/en-US/061f3678-f31f-4ad8-926b-f364e7367ad3/draw-circle-and-move-on-a-form-in-c?forum=csharplanguage
    }
}
