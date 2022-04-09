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

        public Trainingsmodus(Panel panel)
        {
            this.panel = panel;
            panel.Paint += panel1_Paint;

            if (!Directory.Exists(safeDirectory))
                Directory.CreateDirectory(safeDirectory);
        }


        public bool Start(int obstacleFrom, int obstacleTo, int maxGenerations,
            int numberTrainings, FormTrainingsmodus formTrainingsmodus,
            int panelHeight, int panelWidth, int speed,
            Point startPoint, Point endPoint, Panel panel,bool showPanel)
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
            formTrainingsmodus.progressBar1.Value = 0;
            thread = new Thread(delegate () { Train(startPoint, endPoint, showPanel); });

            return true;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Hindernis h in obstacles)
            {
                if (h.typ == Hindernis.Typ.Rechteck)
                    e.Graphics.FillRectangle(new SolidBrush(h.color), h.position.X, h.position.Y, h.breite, h.höhe);
            }
        }

        public bool Stop()
        {
            thread.Abort();
            return true;
        }

        private void Train(Point startPoint, Point endPoint, bool showPanel)
        {
            for (int a = 0; a < numberTrainings; a++)
            {
                obstacles = GetRandomObstacles();

                // Draw Obstacles in panel
                if (showPanel)
                Invoker.invokeInvalidate(panel);

                Setting setting = new Setting(endPoint, startPoint, 100, false, 1000, true, obstacles, maxGenerations, speed, Setting.Endbedingung.Generations);
                Training training = new Training(setting, panelHeight, panelWidth);
                training.Starten();

                while (training.läuft)
                {
                    Thread.Sleep(500);
                }

                // did one dot reach the fin?
                if (training.population.SoManyReachedGoal(1))
                    successfulObstacles.Add(obstacles);
                else
                    failedObstacles.Add(obstacles);

                // Update status
                Invoker.invokeTextSet(formTrainingsmodus.labelStatus.Text, a + "/" + numberTrainings);
                Invoker.invokeProgressBarValue(formTrainingsmodus.progressBar1, a);
                setting.SafeObstaclesInFile(safeDirectory + "\\" + a.ToString() + ".csv");
            }
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
                bool horizontal = Convert.ToBoolean(rand.Next(0, 1));

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
