﻿
namespace LearningDots
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonLoadObstacle = new System.Windows.Forms.Button();
            this.buttonSaveObstacle = new System.Windows.Forms.Button();
            this.comboBoxobstacle = new System.Windows.Forms.ComboBox();
            this.checkBoxdiagonal = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxmaxSchritte = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxZuschauen = new System.Windows.Forms.CheckBox();
            this.comboBoxmaxtrainingszeit = new System.Windows.Forms.ComboBox();
            this.comboBoxanzahldots = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxzielY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxzielX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxstartY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxstartX = new System.Windows.Forms.TextBox();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonprevgen = new System.Windows.Forms.Button();
            this.buttonnextgen = new System.Windows.Forms.Button();
            this.labelprogress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonresetTraining = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(62, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 464);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonresetTraining);
            this.groupBox1.Controls.Add(this.buttonLoadObstacle);
            this.groupBox1.Controls.Add(this.buttonSaveObstacle);
            this.groupBox1.Controls.Add(this.comboBoxobstacle);
            this.groupBox1.Controls.Add(this.checkBoxdiagonal);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBoxmaxSchritte);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.checkBoxZuschauen);
            this.groupBox1.Controls.Add(this.comboBoxmaxtrainingszeit);
            this.groupBox1.Controls.Add(this.comboBoxanzahldots);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxzielY);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxzielX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxstartY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxstartX);
            this.groupBox1.Controls.Add(this.buttonTrain);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 98);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings:";
            // 
            // buttonLoadObstacle
            // 
            this.buttonLoadObstacle.Location = new System.Drawing.Point(582, 16);
            this.buttonLoadObstacle.Name = "buttonLoadObstacle";
            this.buttonLoadObstacle.Size = new System.Drawing.Size(46, 23);
            this.buttonLoadObstacle.TabIndex = 22;
            this.buttonLoadObstacle.Text = "Load";
            this.buttonLoadObstacle.UseVisualStyleBackColor = true;
            this.buttonLoadObstacle.Click += new System.EventHandler(this.buttonLoadObstacle_Click);
            // 
            // buttonSaveObstacle
            // 
            this.buttonSaveObstacle.Location = new System.Drawing.Point(530, 16);
            this.buttonSaveObstacle.Name = "buttonSaveObstacle";
            this.buttonSaveObstacle.Size = new System.Drawing.Size(46, 23);
            this.buttonSaveObstacle.TabIndex = 18;
            this.buttonSaveObstacle.Text = "Save";
            this.buttonSaveObstacle.UseVisualStyleBackColor = true;
            this.buttonSaveObstacle.Click += new System.EventHandler(this.buttonSaveObstacle_Click);
            // 
            // comboBoxobstacle
            // 
            this.comboBoxobstacle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxobstacle.FormattingEnabled = true;
            this.comboBoxobstacle.Items.AddRange(new object[] {
            "no obstacle",
            "easy obstacle",
            "hard obstacle",
            "Draw by yourself"});
            this.comboBoxobstacle.Location = new System.Drawing.Point(414, 18);
            this.comboBoxobstacle.Name = "comboBoxobstacle";
            this.comboBoxobstacle.Size = new System.Drawing.Size(110, 21);
            this.comboBoxobstacle.TabIndex = 18;
            this.comboBoxobstacle.SelectedIndexChanged += new System.EventHandler(this.comboBoxobstacle_SelectedIndexChanged);
            // 
            // checkBoxdiagonal
            // 
            this.checkBoxdiagonal.AutoSize = true;
            this.checkBoxdiagonal.Location = new System.Drawing.Point(204, 67);
            this.checkBoxdiagonal.Name = "checkBoxdiagonal";
            this.checkBoxdiagonal.Size = new System.Drawing.Size(127, 17);
            this.checkBoxdiagonal.TabIndex = 18;
            this.checkBoxdiagonal.Text = "allow diagonal moves";
            this.checkBoxdiagonal.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(646, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Show best dot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxmaxSchritte
            // 
            this.comboBoxmaxSchritte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxmaxSchritte.FormattingEnabled = true;
            this.comboBoxmaxSchritte.Items.AddRange(new object[] {
            "500",
            "1000",
            "2000",
            "5000"});
            this.comboBoxmaxSchritte.Location = new System.Drawing.Point(312, 40);
            this.comboBoxmaxSchritte.Name = "comboBoxmaxSchritte";
            this.comboBoxmaxSchritte.Size = new System.Drawing.Size(59, 21);
            this.comboBoxmaxSchritte.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(201, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Max number of steps";
            // 
            // checkBoxZuschauen
            // 
            this.checkBoxZuschauen.AutoSize = true;
            this.checkBoxZuschauen.Location = new System.Drawing.Point(415, 47);
            this.checkBoxZuschauen.Name = "checkBoxZuschauen";
            this.checkBoxZuschauen.Size = new System.Drawing.Size(69, 17);
            this.checkBoxZuschauen.TabIndex = 19;
            this.checkBoxZuschauen.Text = "Spectate";
            this.checkBoxZuschauen.UseVisualStyleBackColor = true;
            this.checkBoxZuschauen.CheckedChanged += new System.EventHandler(this.checkBoxZuschauen_CheckedChanged);
            // 
            // comboBoxmaxtrainingszeit
            // 
            this.comboBoxmaxtrainingszeit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxmaxtrainingszeit.FormattingEnabled = true;
            this.comboBoxmaxtrainingszeit.Items.AddRange(new object[] {
            "5sec",
            "10sec",
            "30sec",
            "1min",
            "5min",
            "10min"});
            this.comboBoxmaxtrainingszeit.Location = new System.Drawing.Point(101, 68);
            this.comboBoxmaxtrainingszeit.Name = "comboBoxmaxtrainingszeit";
            this.comboBoxmaxtrainingszeit.Size = new System.Drawing.Size(59, 21);
            this.comboBoxmaxtrainingszeit.TabIndex = 16;
            // 
            // comboBoxanzahldots
            // 
            this.comboBoxanzahldots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxanzahldots.FormattingEnabled = true;
            this.comboBoxanzahldots.Items.AddRange(new object[] {
            "5",
            "10",
            "50",
            "100",
            "500",
            "1000"});
            this.comboBoxanzahldots.Location = new System.Drawing.Point(312, 13);
            this.comboBoxanzahldots.Name = "comboBoxanzahldots";
            this.comboBoxanzahldots.Size = new System.Drawing.Size(59, 21);
            this.comboBoxanzahldots.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Max training time:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Number of dots:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Y:";
            // 
            // textBoxzielY
            // 
            this.textBoxzielY.Location = new System.Drawing.Point(155, 39);
            this.textBoxzielY.Name = "textBoxzielY";
            this.textBoxzielY.Size = new System.Drawing.Size(36, 20);
            this.textBoxzielY.TabIndex = 11;
            this.textBoxzielY.TextChanged += new System.EventHandler(this.textBoxzielY_TextChanged);
            this.textBoxzielY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxzielY_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Endpoint:";
            // 
            // textBoxzielX
            // 
            this.textBoxzielX.Location = new System.Drawing.Point(90, 39);
            this.textBoxzielX.Name = "textBoxzielX";
            this.textBoxzielX.Size = new System.Drawing.Size(36, 20);
            this.textBoxzielX.TabIndex = 9;
            this.textBoxzielX.TextChanged += new System.EventHandler(this.textBoxzielX_TextChanged);
            this.textBoxzielX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxzielX_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y:";
            // 
            // textBoxstartY
            // 
            this.textBoxstartY.Location = new System.Drawing.Point(155, 11);
            this.textBoxstartY.Name = "textBoxstartY";
            this.textBoxstartY.Size = new System.Drawing.Size(36, 20);
            this.textBoxstartY.TabIndex = 6;
            this.textBoxstartY.TextChanged += new System.EventHandler(this.textBoxstartY_TextChanged);
            this.textBoxstartY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxstartY_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Startpoint:";
            // 
            // textBoxstartX
            // 
            this.textBoxstartX.Location = new System.Drawing.Point(90, 11);
            this.textBoxstartX.Name = "textBoxstartX";
            this.textBoxstartX.Size = new System.Drawing.Size(36, 20);
            this.textBoxstartX.TabIndex = 3;
            this.textBoxstartX.TextChanged += new System.EventHandler(this.textBoxstartX_TextChanged);
            this.textBoxstartX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxstartX_KeyDown);
            // 
            // buttonTrain
            // 
            this.buttonTrain.Location = new System.Drawing.Point(530, 43);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(110, 23);
            this.buttonTrain.TabIndex = 4;
            this.buttonTrain.Text = "Start training";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Y-Achse";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(550, 583);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "X-Achse";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonprevgen);
            this.groupBox2.Controls.Add(this.buttonnextgen);
            this.groupBox2.Controls.Add(this.labelprogress);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(603, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 464);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "History:";
            // 
            // buttonprevgen
            // 
            this.buttonprevgen.Enabled = false;
            this.buttonprevgen.Location = new System.Drawing.Point(6, 18);
            this.buttonprevgen.Name = "buttonprevgen";
            this.buttonprevgen.Size = new System.Drawing.Size(92, 23);
            this.buttonprevgen.TabIndex = 3;
            this.buttonprevgen.Text = "Previous Gen";
            this.buttonprevgen.UseVisualStyleBackColor = true;
            // 
            // buttonnextgen
            // 
            this.buttonnextgen.Enabled = false;
            this.buttonnextgen.Location = new System.Drawing.Point(104, 18);
            this.buttonnextgen.Name = "buttonnextgen";
            this.buttonnextgen.Size = new System.Drawing.Size(92, 23);
            this.buttonnextgen.TabIndex = 2;
            this.buttonnextgen.Text = "Next Gen";
            this.buttonnextgen.UseVisualStyleBackColor = true;
            // 
            // labelprogress
            // 
            this.labelprogress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelprogress.AutoSize = true;
            this.labelprogress.Location = new System.Drawing.Point(98, 445);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new System.Drawing.Size(0, 13);
            this.labelprogress.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 437);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(227, 21);
            this.progressBar1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 47);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(230, 384);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // buttonresetTraining
            // 
            this.buttonresetTraining.Location = new System.Drawing.Point(646, 43);
            this.buttonresetTraining.Name = "buttonresetTraining";
            this.buttonresetTraining.Size = new System.Drawing.Size(110, 23);
            this.buttonresetTraining.TabIndex = 23;
            this.buttonresetTraining.Text = "Reset training";
            this.buttonresetTraining.UseVisualStyleBackColor = true;
            this.buttonresetTraining.Click += new System.EventHandler(this.buttonresetTraining_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 605);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "LearningDots";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxstartX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxstartY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxzielY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxzielX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxanzahldots;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxmaxtrainingszeit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBoxZuschauen;
        private System.Windows.Forms.ComboBox comboBoxmaxSchritte;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelprogress;
        private System.Windows.Forms.CheckBox checkBoxdiagonal;
        private System.Windows.Forms.Button buttonprevgen;
        private System.Windows.Forms.Button buttonnextgen;
        private System.Windows.Forms.ComboBox comboBoxobstacle;
        private System.Windows.Forms.Button buttonSaveObstacle;
        private System.Windows.Forms.Button buttonLoadObstacle;
        private System.Windows.Forms.Button buttonresetTraining;
    }
}

