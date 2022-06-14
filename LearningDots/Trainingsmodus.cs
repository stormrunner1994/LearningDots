using System;
using System.Collections.Generic;
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
    class Trainingsmodus
    {
        private string safeDirectory = "trainingmode";
        private Random rand = new Random();
        int obstacleFrom, obstacleTo, maxGenerations, speed, numberTrainings, panelHeight, panelWidth;
        Thread thread;
        List<List<Hindernis>> failedObstacles = new List<List<Hindernis>>();
        List<List<Hindernis>> successfulObstacles = new List<List<Hindernis>>();
        private FormTrainingsmodus formTrainingsmodus;
        private Panel panel;
        private List<Hindernis> obstacles = new List<Hindernis>();
        //private Training training;
        private enum Status { Skip, Continue, Pause, Stop, Running, Nothing, IsPausing }
        private Status status = Status.Nothing;

        public Trainingsmodus(Panel panel)
        {
            this.panel = panel;
            panel.Paint += panel1_Paint;

            if (!Directory.Exists(safeDirectory))
                Directory.CreateDirectory(safeDirectory);
        }

        public void Skip()
        {
            status = Status.Skip;
        }

        public void Continue()
        {
            status = Status.Continue;
        }

        public void Pause()
        {
            status = Status.IsPausing;
        }

        public bool Start(int obstacleFrom, int obstacleTo, int maxGenerations,
            int numberTrainings, FormTrainingsmodus formTrainingsmodus,
            int panelHeight, int panelWidth, int speed,
            Point startPoint, Point endPoint, Panel panel, bool showPanel)
        {
            this.obstacleFrom = obstacleFrom;
            this.obstacleTo = obstacleTo;
            this.maxGenerations = maxGenerations;
            this.numberTrainings = numberTrainings;
            this.formTrainingsmodus = formTrainingsmodus;
            this.panelHeight = panelHeight;
            this.panelWidth = panelWidth;
            this.speed = speed;

            failedObstacles = new List<List<Hindernis>>();
            successfulObstacles = new List<List<Hindernis>>();
            formTrainingsmodus.progressBar1.Maximum = numberTrainings;
            formTrainingsmodus.progressBar2.Maximum = maxGenerations;
            formTrainingsmodus.progressBar1.Value = 0;
            formTrainingsmodus.progressBar2.Value = 0;
            thread = new Thread(delegate () { Train(startPoint, endPoint, showPanel); });
            thread.Start();

            return true;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Hindernis h in obstacles)
            {
                if (h.typ == Hindernis.Typ.Rechteck)
                    e.Graphics.FillRectangle(new SolidBrush(h.color), h.location.X, h.location.Y, h.breite, h.höhe);
            }

            foreach (Pixel p in Helper.deathRegionDots)
            {
                e.Graphics.FillRegion(new SolidBrush(p.color), new Region(new Rectangle(p.location.X, p.location.Y, 5, 5)));
            }
        }

        public bool Stop()
        {
            thread.Abort();
            return true;
        }

        private void Train(Point startPoint, Point endPoint, bool showPanel)
        {
            for (int a = 1; a <= numberTrainings; a++)
            {
                Helper.deathRegionDots.Clear();
                obstacles = GetRandomObstacles();

                // Draw Obstacles in panel
                if (showPanel)
                    Invoker.invokeInvalidate(panel);

                Dictionary<Setting.AbbruchBedingung, int> abbruchBedingungen = new Dictionary<Setting.AbbruchBedingung, int>();
                abbruchBedingungen.Add(Setting.AbbruchBedingung.Generations, maxGenerations);
                abbruchBedingungen.Add(Setting.AbbruchBedingung.FoundGoal, -1);
                Setting setting = new Setting(endPoint, startPoint, 100, false, 1000, true, obstacles, speed, abbruchBedingungen);
                Training training = new Training(setting, panelHeight, panelWidth);
                training.Starten();

                while (training.status != Training.Status.Stopped)
                {
                    if (status == Status.Stop) break;
                    else if (status == Status.IsPausing)
                    {
                        training.Pause();
                        training.thread.Join();
                        Helper.GenerateDeathRegions(training);
                        panel.Invalidate();
                        status = Status.Pause;
                    }
                    else if (status == Status.Continue)
                    {
                        training.Continue();
                        status = Status.Running;
                    }
                    else if (status == Status.Skip)
                    {
                        status = Status.Running;
                        break;
                    }

                    Thread.Sleep(500);
                    Invoker.invokeProgressBarValue(formTrainingsmodus.progressBar2, training.population.gen);
                    Invoker.invokeTextSet(formTrainingsmodus.labelStatusGenerations, "Generations (" +  training.population.gen + "/" + maxGenerations + "):");

                }

                if (status == Status.Stop) break;

                // did one dot reach the fin?
                if (training.population.SoManyReachedGoal(1))
                    successfulObstacles.Add(obstacles);
                else
                    failedObstacles.Add(obstacles);

                // Update status
                Invoker.invokeTextSet(formTrainingsmodus.labelStatusTrainings, "Trainings (" + a + "/" + numberTrainings + "):");
                Invoker.invokeProgressBarValue(formTrainingsmodus.progressBar1, a);
                setting.SafeObstaclesInFile(safeDirectory + "\\" + a.ToString() + ".csv");
            }

            Invoker.invokeTextSet(formTrainingsmodus.richTextBox1, "Successful: " +
                successfulObstacles.Count + "\nFailed: " + failedObstacles.Count);
        }

        private List<Hindernis> GetRandomObstacles()
        {
            List<Hindernis> hindernisse = new List<Hindernis>();

            int numberObstacles = rand.Next(obstacleFrom, obstacleTo);

            for (int a = 0; a < numberObstacles; a++)
            {
                int posX = rand.Next(0, panelWidth);
                int posY = rand.Next(0, panelHeight);

                // horizontal or vertical?
                bool horizontal = Convert.ToBoolean(rand.Next(0, 2));

                int height = 0, width = 0;
                if (horizontal)
                {
                    height = speed + 1;
                    width = rand.Next(1, panelWidth);
                }
                else
                {
                    width = speed + 1;
                    height = rand.Next(1, panelHeight);
                }

                Hindernis h = new Hindernis(new Point(posX, posY), width, height, Hindernis.Typ.Rechteck);
                hindernisse.Add(h);
            }

            return hindernisse;
        }
    }
}
