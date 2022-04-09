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
    public partial class FormTrainingsmodus : Form
    {
        private Trainingsmodus modus;
        private int panelHeight, panelWidth, speed;
        private Point startPoint, endPoint;

        public FormTrainingsmodus(Panel panel,Point startPoint, Point endPoint, int speed)
        {
            InitializeComponent();
            panelHeight = panel.Height;
            panelWidth =  panel.Width;
            this.speed = speed;
            this.startPoint = startPoint;
            this.endPoint = endPoint;

            modus = new Trainingsmodus(panel1);
        }

        private void FormTrainingsmodus_Load(object sender, EventArgs e)
        {
            textBox1.Text = "5";
            textBox2.Text = "20";
            comboBox1.SelectedIndex = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                button1.Text = "Stop";

                modus.Start(Convert.ToInt32(textBox1.Text),
                    Convert.ToInt32(textBox2.Text), Convert.ToInt32(comboBox1.Text),
                    Convert.ToInt32(comboBox2.Text), this, panelHeight, panelWidth, speed,
                    startPoint, endPoint, panel1, checkBox1.Checked);
            }
            else
            {
                button1.Text = "Start";
                modus.Stop();
            }
        }
    }
}
