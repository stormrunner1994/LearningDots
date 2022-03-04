using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoker_;

namespace LearningDots
{
    public class Training
    {
        private bool erlaubeDiagonaleZüge = false;
        public static int SPEZIALPUNKTEGRÖSSE = 10;
        private Dot ziel;
        private Dot start;
        private Panel panel;
        private Population population;
        private int populationsGröße = -1;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private RichTextBox rtbStatus;
        public Verlauf verlauf;
        private bool zuschauen = false;
        private Thread thread;
        private Dot loadedDot;
        private enum TimerAktion { trainieren, besteDot };
        private TimerAktion timeraktion = TimerAktion.trainieren;
        private ProgressBar progressbar;
        Label labelprogressbar;
        private Setting setting;
        private Button buttonStart;
        private Button buttonReset;

        public Training(Panel panel, Setting setting, RichTextBox rtbStatus, ProgressBar progressbar, Label labelprogressbar,
            Button buttonStart, Button buttonReset)
        {
            this.buttonReset = buttonReset;
            this.buttonStart = buttonStart;
            this.setting = setting;
            this.progressbar = progressbar;
            this.labelprogressbar = labelprogressbar;
            this.rtbStatus = rtbStatus;
            this.populationsGröße = setting.populationsGröße;
            verlauf = new Verlauf(populationsGröße);
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, setting.startPos, -1);
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, setting.zielPos, -1);
            population = new Population(populationsGröße, panel.Height, panel.Width, ziel.position, start.position, setting.maxSteps, setting.erlaubeDiagonaleZüge, setting.hindernisse, setting.speed);
            this.panel = panel;
            panel.Paint += new PaintEventHandler(panel_Paint);
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        public string GetLoadedDotStats()
        {
            if (loadedDot == null) return "No dot loaded";

            return loadedDot.brain.directions.Length + " steps";
        }

        public void SetSettings(Setting setting)
        {
            this.setting = setting;
            populationsGröße = setting.populationsGröße;
            zuschauen = setting.zuschauen;
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, setting.startPos, -1);
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, setting.zielPos, -1);
            population = new Population(populationsGröße, panel.Height, panel.Width, ziel.position, start.position, setting.maxSteps,
                setting.erlaubeDiagonaleZüge, setting.hindernisse,setting.speed);
        }

        public void SetMaxTrainingTime(int time)
        {
            setting.maxTrainingTime = time;
        }

        public void SetZuschauen(bool zuschauen)
        {
            this.zuschauen = setting.zuschauen = zuschauen;
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
            setting.populationsGröße = populationsGröße;
            population = new Population(populationsGröße, panel.Height, panel.Width, ziel.position, start.position, population.maxSteps,
                erlaubeDiagonaleZüge, population.hindernisse, setting.speed);
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

                    double[] bestWorstAvgFitness = population.GetBestWorstAvgFitness();
                    int[] deadReachedGoal = population.GetDeadReachedGoal();
                    verlauf.AddGenInfo(bestWorstAvgFitness[2], bestWorstAvgFitness[1], bestWorstAvgFitness[0],
                    deadReachedGoal[0], deadReachedGoal[1], population.maxSteps);
                    population.naturalSelection(verlauf.GetLastGenInfo());

                    population.mutateBabies();
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
                Invoker.invokeTextSet(rtbStatus, "");
                var genInfos = verlauf.GetGenInfos();

                // zeige nur die letzen 20
                int count = 0;
                for (int a = genInfos.Count - 1; a > -1; a--)
                {
                    if (count == 20) break;

                    GenInfo gi = genInfos[a];
                    if (Invoker.invokeTextGet(rtbStatus) != "") Invoker.invokeAppendText(rtbStatus, "\n\n" + gi.GetInfo());
                    else Invoker.invokeAppendText(rtbStatus, gi.GetInfo());
                    count++;
                }
            }
            else
            {
                if (verlauf.GetLastGenInfo() != null)
                    Invoker.invokeTextSet(rtbStatus, verlauf.GetLastGenInfo().GetInfo());
                else
                    Invoker.invokeTextSet(rtbStatus, "no Generation yet");
            }
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

        private string GetRestTime(int secs, int max)
        {
            int diff = max - secs;

            int h = diff / 3600;
            diff -= h * 3600;
            int min = diff / 60;
            diff -= min * 60;
            int sec = diff;

            string strH = h.ToString();
            if (h < 10) strH = "0" + strH;
            string strMin = min.ToString();
            if (min < 10) strMin = "0" + strMin;
            string strSec = sec.ToString();
            if (sec < 10) strSec = "0" + strSec;

            string output = "";
            if (h > 0) output = strH + ":" + strMin + ":" + strSec + "h";
            else if (min > 0) output = strMin + ":" + strSec + "min";
            else if (sec > 0) output = strSec + "sec";

            return output;
        }

        private void ThreadTrainieren()
        {
            Invoker.invokeProgressBar(progressbar, 0, 0, setting.maxTrainingTime);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int secs = 0;
            while (true)
            {
                if ((sw.ElapsedMilliseconds / 1000) > secs)
                {
                    secs = (int)(sw.ElapsedMilliseconds / 1000);
                    Invoker.invokeProgressBarValue(progressbar, secs);
                    Invoker.invokeTextSet(labelprogressbar, GetRestTime(secs, Invoker.invokeProgressBarGetMax(progressbar)));
                }

                if (population.allDotsFinished())
                {
                    // generic algorithm
                    population.calculateFitnessForAllDots();
                    double[] bestWorstAvgFitness = population.GetBestWorstAvgFitness();
                    int[] deadReachedGoal = population.GetDeadReachedGoal();
                    verlauf.AddGenInfo(bestWorstAvgFitness[2], bestWorstAvgFitness[1], bestWorstAvgFitness[0],
                    deadReachedGoal[0], deadReachedGoal[1], population.maxSteps);

                    // Beende Loop
                    if (population.SoManyReachedGoal(100) || sw.ElapsedMilliseconds >= setting.maxTrainingTime * 1000)
                        break;

                    var reihenfolge = population.GetReihenfolge();

                    population.naturalSelection(verlauf.GetLastGenInfo());
                    population.mutateBabies();
                    var ratio = population.durchschnittlicheÄnderungen();
                    GenInfo last = verlauf.GetLastGenInfo();
                }
                else
                    population.update();
            }

            sw.Stop();
            SafeBest();
            Invoker.invokeInvalidate(panel);
            Invoker.invokeProgressBarValue(progressbar, Invoker.invokeProgressBarGetMax(progressbar));
            Invoker.invokeTextSet(labelprogressbar.Text, secs + "/" + Invoker.invokeProgressBarGetMax(progressbar));
            UpdateStatusRichTextBox(true);
            Invoker.invokeTextSet(buttonStart, "Continue training");
            Invoker.invokeEnable(buttonReset, true);
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

        public void Continue()
        {
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

        public void Starten()
        {
            verlauf = new Verlauf(populationsGröße);
            Continue();
        }

        public void Stoppen()
        {
            if (zuschauen)
            {
                timer.Stop();
            }
            else
            {
                Invoker.invokeInvalidate(panel);
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
