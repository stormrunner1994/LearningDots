using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningDots
{
    public class Training
    {
        private bool erlaubeDiagonaleZüge = false;
        private static bool STATUSBEHALTEN = true;
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
        private Dot loadedDot;
        private enum TimerAktion { trainieren, besteDot };
        private TimerAktion timeraktion = TimerAktion.trainieren;
        private ProgressBar progressbar;
        Label labelprogressbar;

        public Training(Panel panel, Point zielPos, Point startPos, int populationsGröße, RichTextBox rtbStatus
            , int maxSteps, ProgressBar progressbar, Label labelprogressbar, List<Hindernis> hindernisse)
        {
            this.progressbar = progressbar;
            this.labelprogressbar = labelprogressbar;
            this.rtbStatus = rtbStatus;
            this.populationsGröße = populationsGröße;
            status = new Status(populationsGröße);
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, startPos, -1);
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, zielPos, -1);
            population = new Population(populationsGröße, panel.Height, panel.Width, ziel.position, start.position, maxSteps, erlaubeDiagonaleZüge, hindernisse);
            this.panel = panel;
            panel.Paint += new PaintEventHandler(panel_Paint);
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        public void SetSettings(Point zielPos, Point startPos, int populationsGröße, bool zuschauen, int maxSteps,
            bool erlaubeDiagonaleZüge, List<Hindernis> hindernisse)
        {
            this.populationsGröße = populationsGröße;
            this.zuschauen = zuschauen;
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, startPos, -1);
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, zielPos, -1);
            population = new Population(populationsGröße, panel.Height, panel.Width, ziel.position, start.position, maxSteps,
                erlaubeDiagonaleZüge, hindernisse);
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
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, startPos, -1);
            ZeichneFeld();
        }

        public void SetZielpunkt(Point zielPos)
        {
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, zielPos, -1);
            ZeichneFeld();
        }

        public void SetPopulationsGröße(int populationsGröße)
        {
            population = new Population(populationsGröße, panel.Height, panel.Width, ziel.position, start.position, population.maxSteps,
                erlaubeDiagonaleZüge,population.hindernisse);
            ZeichneFeld();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // draw dots again
            if (timeraktion == TimerAktion.trainieren)
            {
                if (population.allDotsFinished())
                {
                    // generic algorithm
                    population.calculateFitnessForAllDots();

                    if (STATUSBEHALTEN)
                    {
                        double[] bestWorstAvgFitness = population.GetBestWorstAvgFitness();
                        int[] deadReachedGoal = population.GetDeadReachedGoal();
                        status.AddGenInfo(bestWorstAvgFitness[2], bestWorstAvgFitness[1], bestWorstAvgFitness[0],
                        deadReachedGoal[0], deadReachedGoal[1]);
                        population.naturalSelection(status.GetLastGenInfo());
                    }
                    else
                        population.naturalSelection(null);

                    population.mutateBabies();

                    if (STATUSBEHALTEN)
                        UpdateStatusRichTextBox(false);

                    progressbar.Value = 0;
                    progressbar.Maximum = population.maxSteps;
                }
                else
                {
                    population.update();

                    if (progressbar.Value + 1 <= progressbar.Maximum)
                        progressbar.Value++;
                    labelprogressbar.Text = progressbar.Value + "/" + progressbar.Maximum;
                }
            }
            else
            {
                if (loadedDot.isDead || loadedDot.reachedGoal)
                {
                    loadedDot.position = loadedDot.startPosition;
                    loadedDot.brain.step = 0;
                    loadedDot.isDead = loadedDot.reachedGoal = false;
                }
                loadedDot.move();
            }
            panel.Invalidate();
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

        public void LasseBestenAblaufen()
        {
            timeraktion = TimerAktion.besteDot;
            timer.Start();
        }

        public void HalteBestenAn()
        {
            timer.Stop();
            timeraktion = TimerAktion.trainieren;
        }

        private void ThreadTrainieren()
        {
            while (true)
            {
                if (population.allDotsFinished())
                {
                    // generic algorithm
                    population.calculateFitnessForAllDots();
                    if (STATUSBEHALTEN)
                    {
                        double[] bestWorstAvgFitness = population.GetBestWorstAvgFitness();
                        int[] deadReachedGoal = population.GetDeadReachedGoal();
                        status.AddGenInfo(bestWorstAvgFitness[2], bestWorstAvgFitness[1], bestWorstAvgFitness[0],
                        deadReachedGoal[0], deadReachedGoal[1]);

                        if (population.SoManyReachedGoal(80))
                            break;

                        var reihenfolge = population.GetReihenfolge();

                        population.naturalSelection(status.GetLastGenInfo());
                    }
                    else
                    {
                        if (population.SoManyReachedGoal(80))
                            break;
                        population.naturalSelection(null);
                    }
                    population.mutateBabies();
                    if (STATUSBEHALTEN)
                    {
                        var ratio = population.durchschnittlicheÄnderungen();
                        GenInfo last = status.GetLastGenInfo();
                    }
                }
                else
                {
                    population.update();
                }

            }

            Invoker_.Invoker.invokeInvalidate(panel);
            UpdateStatusRichTextBox(true);
        }

        public void SafeBest()
        {
            StreamWriter sw = new StreamWriter("best.csv");
            Dot best = population.getBestDot();
            foreach (var v in best.brain.directions)
                sw.WriteLine(v.X + ";" + v.Y);
            sw.Close();
        }

        public void LoadBest()
        {
            var loadedDirections = new List<System.Windows.Vector>();
            StreamReader sr = new StreamReader("best.csv");

            while (!sr.EndOfStream)
            {
                string zeile = sr.ReadLine();
                string[] split = zeile.Split(';');
                double x = Convert.ToDouble(split[0].ToString());
                double y = Convert.ToDouble(split[1].ToString());
                loadedDirections.Add(new System.Windows.Vector(x, y));
            }
            sr.Close();

            Brain brain = new Brain(loadedDirections);
            loadedDot = new Dot(start.position, brain);
        }

        public void Starten()
        {
            status = new Status(populationsGröße);
            if (zuschauen)
            {
                progressbar.Minimum = 0;
                progressbar.Maximum = population.maxSteps;
                progressbar.Value = 0;
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
                Invoker_.Invoker.invokeInvalidate(panel);
                UpdateStatusRichTextBox(true);
                thread.Abort();
            }
        }


        private void panel_Paint(object sender, PaintEventArgs e)
        {
            if (timeraktion == TimerAktion.trainieren)
            {
                foreach (Dot d in population.dots)
                {
                    if (d.isBest)
                        e.Graphics.FillEllipse(new SolidBrush(Color.DarkRed), d.position.X, d.position.Y, d.größe + 3, d.größe + 3);
                    else
                        e.Graphics.FillEllipse(new SolidBrush(d.color), d.position.X, d.position.Y, d.größe, d.größe);
                }
            }
            else
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.DarkRed), loadedDot.position.X, loadedDot.position.Y, loadedDot.größe + 3, loadedDot.größe + 3);
            }

            // Zeichne Goal
            e.Graphics.FillEllipse(new SolidBrush(ziel.color), ziel.position.X, ziel.position.Y, ziel.größe, ziel.größe);
            // Zeichne Start
            e.Graphics.FillEllipse(new SolidBrush(start.color), start.position.X, start.position.Y, start.größe, start.größe);


        }

        // https://social.msdn.microsoft.com/Forums/en-US/061f3678-f31f-4ad8-926b-f364e7367ad3/draw-circle-and-move-on-a-form-in-c?forum=csharplanguage
    }
}
