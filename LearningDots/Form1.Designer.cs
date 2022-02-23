
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxmaxSchritte = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxZuschauen = new System.Windows.Forms.CheckBox();
            this.buttonZeichneHindernis = new System.Windows.Forms.Button();
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelprogress = new System.Windows.Forms.Label();
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
            this.panel1.Location = new System.Drawing.Point(62, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 449);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBoxmaxSchritte);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.checkBoxZuschauen);
            this.groupBox1.Controls.Add(this.buttonZeichneHindernis);
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
            this.groupBox1.Size = new System.Drawing.Size(830, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(588, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Lade besten";
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
            this.comboBoxmaxSchritte.Location = new System.Drawing.Point(524, 15);
            this.comboBoxmaxSchritte.Name = "comboBoxmaxSchritte";
            this.comboBoxmaxSchritte.Size = new System.Drawing.Size(59, 21);
            this.comboBoxmaxSchritte.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(436, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Max Schrittzahl:";
            // 
            // checkBoxZuschauen
            // 
            this.checkBoxZuschauen.AutoSize = true;
            this.checkBoxZuschauen.Location = new System.Drawing.Point(444, 37);
            this.checkBoxZuschauen.Name = "checkBoxZuschauen";
            this.checkBoxZuschauen.Size = new System.Drawing.Size(80, 17);
            this.checkBoxZuschauen.TabIndex = 19;
            this.checkBoxZuschauen.Text = "Zuschauen";
            this.checkBoxZuschauen.UseVisualStyleBackColor = true;
            // 
            // buttonZeichneHindernis
            // 
            this.buttonZeichneHindernis.Location = new System.Drawing.Point(669, 13);
            this.buttonZeichneHindernis.Name = "buttonZeichneHindernis";
            this.buttonZeichneHindernis.Size = new System.Drawing.Size(110, 23);
            this.buttonZeichneHindernis.TabIndex = 18;
            this.buttonZeichneHindernis.Text = "Zeichne Hindernis";
            this.buttonZeichneHindernis.UseVisualStyleBackColor = true;
            this.buttonZeichneHindernis.Click += new System.EventHandler(this.buttonZeichneHindernis_Click);
            // 
            // comboBoxmaxtrainingszeit
            // 
            this.comboBoxmaxtrainingszeit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxmaxtrainingszeit.Enabled = false;
            this.comboBoxmaxtrainingszeit.FormattingEnabled = true;
            this.comboBoxmaxtrainingszeit.Items.AddRange(new object[] {
            "10sek",
            "30sek",
            "1min",
            "5min",
            "10min"});
            this.comboBoxmaxtrainingszeit.Location = new System.Drawing.Point(370, 36);
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
            this.comboBoxanzahldots.Location = new System.Drawing.Point(370, 13);
            this.comboBoxanzahldots.Name = "comboBoxanzahldots";
            this.comboBoxanzahldots.Size = new System.Drawing.Size(59, 21);
            this.comboBoxanzahldots.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(248, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Maximale Trainingszeit:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Anzahl Dots:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Y:";
            // 
            // textBoxzielY
            // 
            this.textBoxzielY.Location = new System.Drawing.Point(162, 39);
            this.textBoxzielY.Name = "textBoxzielY";
            this.textBoxzielY.Size = new System.Drawing.Size(36, 20);
            this.textBoxzielY.TabIndex = 11;
            this.textBoxzielY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxzielY_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 42);
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
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Zielpunkt:";
            // 
            // textBoxzielX
            // 
            this.textBoxzielX.Location = new System.Drawing.Point(94, 39);
            this.textBoxzielX.Name = "textBoxzielX";
            this.textBoxzielX.Size = new System.Drawing.Size(36, 20);
            this.textBoxzielX.TabIndex = 9;
            this.textBoxzielX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxzielX_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y:";
            // 
            // textBoxstartY
            // 
            this.textBoxstartY.Location = new System.Drawing.Point(162, 13);
            this.textBoxstartY.Name = "textBoxstartY";
            this.textBoxstartY.Size = new System.Drawing.Size(36, 20);
            this.textBoxstartY.TabIndex = 6;
            this.textBoxstartY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxstartY_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 16);
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
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Startpunkt:";
            // 
            // textBoxstartX
            // 
            this.textBoxstartX.Location = new System.Drawing.Point(94, 13);
            this.textBoxstartX.Name = "textBoxstartX";
            this.textBoxstartX.Size = new System.Drawing.Size(36, 20);
            this.textBoxstartX.TabIndex = 3;
            this.textBoxstartX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxstartX_KeyDown);
            // 
            // buttonTrain
            // 
            this.buttonTrain.Location = new System.Drawing.Point(669, 37);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(110, 23);
            this.buttonTrain.TabIndex = 4;
            this.buttonTrain.Text = "Training starten";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Y-Achse";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(550, 562);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "X-Achse";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labelprogress);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(603, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 455);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(230, 403);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 428);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(227, 21);
            this.progressBar1.TabIndex = 1;
            // 
            // labelprogress
            // 
            this.labelprogress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelprogress.AutoSize = true;
            this.labelprogress.Location = new System.Drawing.Point(98, 436);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new System.Drawing.Size(0, 13);
            this.labelprogress.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 584);
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
        private System.Windows.Forms.Button buttonZeichneHindernis;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBoxZuschauen;
        private System.Windows.Forms.ComboBox comboBoxmaxSchritte;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelprogress;
    }
}

