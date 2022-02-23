using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private int populationsGröße = -1;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private RichTextBox rtbStatus;
        public Status status;
        private bool zuschauen = false;
        private Thread thread;

        public Training(Panel panel, Point zielPos, Point startPos, int populationsGröße, RichTextBox rtbStatus)
        {
            this.rtbStatus = rtbStatus;
            this.populationsGröße = populationsGröße;
            status = new Status(populationsGröße);
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, startPos,-1);
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, zielPos,-1);
            population = new Population(populationsGröße, panel.Height, panel.Width, ziel.position, start.position);
            this.panel = panel;
            panel.Paint += new PaintEventHandler(panel_Paint);
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        public void SetSettings(Point zielPos, Point startPos, int populationsGröße, bool zuschauen)
        {
            this.zuschauen = zuschauen;
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
                int[] deadReachedGoal = population.GetDeadReachedGoal();
                status.AddGenInfo(bestWorstAvgFitness[2], bestWorstAvgFitness[1], bestWorstAvgFitness[0],
                deadReachedGoal[0], deadReachedGoal[1]);

                population.naturalSelection(status.GetLastGenInfo());
                population.mutateBabies();
                UpdateStatusRichTextBox(false);
            }
            else
            {
                population.update();
            }
        }

        private void UpdateStatusRichTextBox(bool nurLetzte)
        {
            if (!nurLetzte)
            {
                Invoker_.Invoker.invokeText(rtbStatus, "");
                var genInfos = status.GetGenInfos();

                for (int a = genInfos.Count - 1; a > -1; a--)
                {
                    GenInfo gi = genInfos[a];
                    if (Invoker_.Invoker.invokeGetText(rtbStatus) != "") Invoker_.Invoker.invokeAppendText(rtbStatus, "\n\n" + gi.GetInfo());
                    else Invoker_.Invoker.invokeAppendText(rtbStatus, gi.GetInfo());
                }
            }
            else
                Invoker_.Invoker.invokeText(rtbStatus, status.GetLastGenInfo().GetInfo());
        }

        private void ThreadTrainieren()
        {
            for (int a = 0; a < 2000 * population.maxSteps; a++)
            {
                if (population.allDotsFinished())
                {
                    // generic algorithm
                    population.calculateFitnessForAllDots();
                    double[] bestWorstAvgFitness = population.GetBestWorstAvgFitness();
                    int[] deadReachedGoal = population.GetDeadReachedGoal();
                    status.AddGenInfo(bestWorstAvgFitness[2], bestWorstAvgFitness[1], bestWorstAvgFitness[0],
                    deadReachedGoal[0], deadReachedGoal[1]);

                    population.naturalSelection(status.GetLastGenInfo());
                    population.mutateBabies();
                    //UpdateStatusRichTextBox();
                   // panel.Invalidate();

                }
                else
                {
                    population.update();
                }

            }
            panel.Invalidate();
            UpdateStatusRichTextBox(true);
        }

        public void Starten()
        {
            status = new Status(populationsGröße);
            if (zuschauen)
            {
                timer.Start();
            }
            else
            {
                thread = new Thread(delegate () { ThreadTrainieren(); });
                thread.Start();
            }
        }

        public void Stoppen()
        {
            if (zuschauen)
            {
                timer.Stop();
            }
            else
            {
                thread.Abort();
            }
        }


        private void panel_Paint(object sender, PaintEventArgs e)
        {
            foreach (Dot d in population.dots)
            {
                if (d.isBest)
                    e.Graphics.FillEllipse(new SolidBrush(Color.DarkRed), d.position.X, d.position.Y, d.größe+3, d.größe+3);
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
