﻿using System;
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
            training = new Training(panel1, zielPos, startPos, 100, richTextBox1, 1000,progressBar1, labelprogress);
        }

        private Color defaultforecolor;
        enum Richtung { Höhe, Breite };

        Training training;


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxmaxSchritte.SelectedIndex = 1;
            comboBoxanzahldots.SelectedIndex = 2;
            comboBoxmaxtrainingszeit.SelectedIndex = 3;
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
            if (buttonTrain.Text == "Training starten")
            {
                Point zielPos = new Point(Convert.ToInt32(textBoxzielX.Text), Convert.ToInt32(textBoxzielY.Text));
                Point startPos = new Point(Convert.ToInt32(textBoxstartX.Text), Convert.ToInt32(textBoxstartY.Text));
                int populationsGröße = Convert.ToInt32(comboBoxanzahldots.Text);
                int maxSteps = Convert.ToInt32(comboBoxmaxSchritte.Text);
                training.SetSettings(zielPos, startPos, populationsGröße, checkBoxZuschauen.Checked, maxSteps,
                    checkBoxdiagonal.Checked);
                training.Starten();
                buttonTrain.Text = "Training stoppen";
            }
            else
            {
                // Sichere besten
                training.SafeBest();
                training.Stoppen();
                buttonTrain.Text = "Training starten";
            }
        }

        private bool TextBoxValide(string text, Richtung richtung)
        {
            int iout;
            if (!Int32.TryParse(text, out iout))
            {
                MessageBox.Show("Wert muss eine Ganzzahl sein.");
                return false;
            }

            int wert = Convert.ToInt32(text);
            if (wert < 0)
            {
                MessageBox.Show("Wert darf nicht kleiner 0 sein.");
                return false;
            }
            if (richtung == Richtung.Breite && wert > panel1.Width)
            {

                MessageBox.Show("Wert darf nicht größer als Feldbreite [" + panel1.Width + " sein.");
                return false;
            }
            else if (richtung == Richtung.Höhe && wert > panel1.Height)
            {
                MessageBox.Show("Wert darf nicht größer als FEldhöhe [" + panel1.Height + " sein.");
                return false;
            }
            return true;
        }

        private void textBoxstartX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) return;

            TextBox tb = sender as TextBox;
            if (!TextBoxValide(tb.Text, Richtung.Breite))
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
            if (!TextBoxValide(tb.Text, Richtung.Breite))
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
            if (!TextBoxValide(tb.Text, Richtung.Breite))
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
            if (!TextBoxValide(tb.Text, Richtung.Breite))
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Lade besten")
            {
                button1.Text = "Halte an";
                training.LoadBest();
                training.LasseBestenAblaufen();
            }
            else
            {
                button1.Text = "Lade besten";
                training.HalteBestenAn();
            }
        }
    }
}
