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
        public Population population;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public Verlauf verlauf;
        private bool zuschauen = false;
        public Thread thread;
        private Dot loadedDot;
        private enum TimerAktion { trainieren, besteDot };
        private TimerAktion timeraktion = TimerAktion.trainieren;
        private Setting setting;
        private Form1 form;
        public enum Status {Running, IsStopping, Stopped, Nothing, Paused, IsPausing }
        public Status status = Status.Nothing;

        public Training(Panel panel, Setting setting, Form1 form)
        {
            this.form = form;
            this.setting = setting;
            verlauf = new Verlauf(setting.populationsGröße);
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, setting.startPos, -1);
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, setting.zielPos, -1);
            population = new Population(setting.populationsGröße, panel.Height, panel.Width, ziel.position, start.position, setting.maxSteps, setting.erlaubeDiagonaleZüge, setting.hindernisse, setting.speed);
            panel.Paint += new PaintEventHandler(panel_Paint);
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        public Training(Setting setting, int panelHeight, int panelWidth)
        {
            this.setting = setting;
            verlauf = new Verlauf(setting.populationsGröße);
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, setting.startPos, -1);
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, setting.zielPos, -1);
            population = new Population(setting.populationsGröße, panelHeight, panelWidth, ziel.position, start.position, setting.maxSteps, setting.erlaubeDiagonaleZüge, setting.hindernisse, setting.speed);
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        public Dictionary<string, int> GetDeathLocations()
        {
            return population.dictDeathLocations;
        }

        public string GetLoadedDotStats()
        {
            if (loadedDot == null) return "No dot loaded";

            return loadedDot.brain.directions.Length + " steps";
        }

        public void SetSettings(Setting setting)
        {
            this.setting = setting;
            zuschauen = setting.zuschauen;
            start = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Green, setting.startPos, -1);
            ziel = new Dot(SPEZIALPUNKTEGRÖSSE, Color.Red, setting.zielPos, -1);
            population = new Population(setting.populationsGröße, form.panel1.Height, form.panel1.Width, ziel.position, start.position, setting.maxSteps,
                setting.erlaubeDiagonaleZüge, setting.hindernisse, setting.speed);
        }


        public bool SetAbbruchBedingung(Setting.AbbruchBedingung abbruchBedingungen, int value = -1)
        {
            setting.abbruchBedingungen.Clear();
            setting.abbruchBedingungen.Add(abbruchBedingungen, value);

            if (abbruchBedingungen == Setting.AbbruchBedingung.NextGen)
                setting.abbruchBedingungen[abbruchBedingungen] = population.gen + 1;
            return true;
        }

        public bool SetAbbruchBedingungen(List<Setting.AbbruchBedingung> abbruchBedingungen, List<int> values)
        {
            if (abbruchBedingungen.Count != values.Count) return false;

            setting.abbruchBedingungen.Clear();
            for (int a = 0; a < abbruchBedingungen.Count; a++)
            {
                setting.abbruchBedingungen.Add(abbruchBedingungen[a], values[a]);
                if (abbruchBedingungen[a] == Setting.AbbruchBedingung.NextGen)
                    setting.abbruchBedingungen[abbruchBedingungen[a]] = population.gen + 1;
            }
            return true;
        }

        public void SetZuschauen(bool zuschauen)
        {
            this.zuschauen = setting.zuschauen = zuschauen;
        }

        public void ZeichneFeld()
        {
            form.panel1.Invalidate();
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
            population = new Population(populationsGröße, form.panel1.Height, form.panel1.Width, ziel.position, start.position, population.maxSteps,
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
                    // safe places where dots have died
                    population.SavePlacesWhereDotsDied();

                    // generic algorithm
                    population.CalculateFitnessForAllDots();

                    double[] bestWorstAvgFitness = population.GetBestWorstAvgFitness();
                    int[] deadReachedGoal = population.GetDeadReachedGoal();
                    verlauf.AddGenInfo(bestWorstAvgFitness[2], bestWorstAvgFitness[1], bestWorstAvgFitness[0],
                    deadReachedGoal[0], deadReachedGoal[1], population.maxSteps);
                    population.NaturalSelection(verlauf.GetLastGenInfo());

                    population.MutateBabies();
                    UpdateStatusRichTextBox(false);

                    form.progressBar1.Value = 0;
                    form.progressBar1.Maximum = population.maxSteps;
                }
                else
                {
                    population.Update();

                    if (form.progressBar1.Value + 1 <= form.progressBar1.Maximum)
                        form.progressBar1.Value++;
                    form.labelprogress.Text = form.progressBar1.Value + "/" + form.progressBar1.Maximum;
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
                loadedDot.Move();
            }
            status = Status.Stopped;
            form.panel1.Invalidate();
        }


        private void UpdateStatusRichTextBox(bool nurLetzte)
        {
            if (!nurLetzte)
            {
                Invoker.invokeTextSet(form.richTextBoxstatus, "");
                var genInfos = verlauf.GetGenInfos();

                // zeige nur die letzen 20
                int count = 0;
                for (int a = genInfos.Count - 1; a > -1; a--)
                {
                    if (count == 20) break;

                    GenInfo gi = genInfos[a];
                    if (Invoker.invokeTextGet(form.richTextBoxstatus) != "") Invoker.invokeAppendText(form.richTextBoxstatus, "\n\n" + gi.GetInfo());
                    else Invoker.invokeAppendText(form.richTextBoxstatus, gi.GetInfo());
                    count++;
                }
            }
            else
            {
                if (verlauf.GetLastGenInfo() != null)
                    Invoker.invokeTextSet(form.richTextBoxstatus, verlauf.GetLastGenInfo().GetInfo());
                else
                    Invoker.invokeTextSet(form.richTextBoxstatus, "no Generation yet");
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
            if (setting.abbruchBedingungen.ContainsKey(Setting.AbbruchBedingung.Time) && form != null)
                Invoker.invokeProgressBar(form.progressBar1, 0, 0, setting.abbruchBedingungen[Setting.AbbruchBedingung.Time]);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int secs = 0;
            while (true)
            {
                if (setting.abbruchBedingungen.ContainsKey(Setting.AbbruchBedingung.Time)
                    && (sw.ElapsedMilliseconds / 1000) > secs)
                {
                    secs = (int)(sw.ElapsedMilliseconds / 1000);

                    if (form != null)
                    {
                        if (secs <= Invoker.invokeProgressBarGetMax(form.progressBar1))
                            Invoker.invokeProgressBarValue(form.progressBar1, secs);
                        Invoker.invokeTextSet(form.labelprogress, GetRestTime(secs, Invoker.invokeProgressBarGetMax(form.progressBar1)));
                    }
                }

                if (population.allDotsFinished())
                {
                    // Beende Loop
                    if (setting.abbruchBedingungen.ContainsKey(Setting.AbbruchBedingung.Time) && sw.ElapsedMilliseconds >= setting.abbruchBedingungen[Setting.AbbruchBedingung.Time] * 1000
                        || setting.abbruchBedingungen.ContainsKey(Setting.AbbruchBedingung.NextGen) && population.gen > setting.abbruchBedingungen[Setting.AbbruchBedingung.NextGen]
                        || setting.abbruchBedingungen.ContainsKey(Setting.AbbruchBedingung.FoundGoal) && population.SoManyReachedGoal(1)
                        || setting.abbruchBedingungen.ContainsKey(Setting.AbbruchBedingung.Generations) && population.gen >= setting.abbruchBedingungen[Setting.AbbruchBedingung.Generations])
                        break;

                    // safe places where dots have died
                    population.SavePlacesWhereDotsDied();

                    // generic algorithm
                    population.CalculateFitnessForAllDots();
                    double[] bestWorstAvgFitness = population.GetBestWorstAvgFitness();
                    int[] deadReachedGoal = population.GetDeadReachedGoal();
                    verlauf.AddGenInfo(bestWorstAvgFitness[2], bestWorstAvgFitness[1], bestWorstAvgFitness[0],
                    deadReachedGoal[0], deadReachedGoal[1], population.maxSteps);

                    //  var reihenfolge = population.GetReihenfolge();

                    population.NaturalSelection(verlauf.GetLastGenInfo());
                    population.MutateBabies();
                    //var ratio = population.DurchschnittlicheÄnderungen();
                    //GenInfo last = verlauf.GetLastGenInfo();


                    // safe point to kill thread
                    if (status == Status.IsStopping || status == Status.IsPausing)
                        break;
                }
                else
                    population.Update();
            }

            sw.Stop();
            SafeBest();
            if (form != null)
            {
                Invoker.invokeInvalidate(form.panel1);
                Invoker.invokeProgressBarValue(form.progressBar1, Invoker.invokeProgressBarGetMax(form.progressBar1));
                Invoker.invokeTextSet(form.labelprogress.Text, secs + "/" + Invoker.invokeProgressBarGetMax(form.progressBar1));
                UpdateStatusRichTextBox(true);
                Invoker.invokeTextSet(form.buttonTrain, "Continue training");
                Invoker.invokeEnable(form.buttonresetTraining, true);
                Invoker.invokeEnable(form.buttonShowBestDot, true);
                Invoker.invokeEnable(form.buttonnextgen, true);
            }
            if (status == Status.IsPausing)
                status = Status.Paused;
            else if (status == Status.IsStopping || status == Status.Running)
                status = Status.Stopped;
        }

        public void PrintRanks(string pfad)
        {
            StreamWriter sw = new StreamWriter(pfad);
            foreach (string s in population.ranks)
                sw.WriteLine(s);
            sw.Close();
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
            if (form != null)
                form.buttonShowBestDot.Enabled = false;
            if (zuschauen)
            {
                if (form != null)
                {
                    form.progressBar1.Minimum = 0;
                    form.progressBar1.Maximum = population.maxSteps;
                    form.progressBar1.Value = 0;
                }
                timer.Start();
            }
            else
            {
                thread = new Thread(delegate () { ThreadTrainieren(); });
                thread.Start();
            }
            status = Status.Running;
        }

        public void Starten()
        {
            verlauf = new Verlauf(setting.populationsGröße);
            Continue();
        }

        public void Reset(Setting setting)
        {
            SetSettings(setting);
            verlauf = new Verlauf(setting.populationsGröße);
        }

        public void Pause()
        {
            if (zuschauen)
            {
                timer.Stop();
            }
            else
            {
                if (form != null)
                {
                    Invoker.invokeInvalidate(form.panel1);
                    UpdateStatusRichTextBox(true);
                }
            }
            if (form != null)
                form.buttonShowBestDot.Enabled = true;
            status = Status.IsPausing;
        }

        public void Stoppen()
        {
            Pause();
            status = Status.Stopped;
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
