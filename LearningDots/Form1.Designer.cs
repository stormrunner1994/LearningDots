
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxShowDeathDistribution = new System.Windows.Forms.CheckBox();
            this.buttonresetTraining = new System.Windows.Forms.Button();
            this.comboBoxobstacle = new System.Windows.Forms.ComboBox();
            this.checkBoxdiagonal = new System.Windows.Forms.CheckBox();
            this.buttonShowBestDot = new System.Windows.Forms.Button();
            this.comboBoxmaxSchritte = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxZuschauen = new System.Windows.Forms.CheckBox();
            this.comboBoxmaxtrainingszeit = new System.Windows.Forms.ComboBox();
            this.comboBoxanzahldots = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonprevgen = new System.Windows.Forms.Button();
            this.buttonnextgen = new System.Windows.Forms.Button();
            this.labelprogress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBoxstatus = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showDeathDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obstaclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveActualObstacleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.startEndpointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printRanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(62, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 449);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxShowDeathDistribution);
            this.groupBox1.Controls.Add(this.buttonresetTraining);
            this.groupBox1.Controls.Add(this.comboBoxobstacle);
            this.groupBox1.Controls.Add(this.checkBoxdiagonal);
            this.groupBox1.Controls.Add(this.buttonShowBestDot);
            this.groupBox1.Controls.Add(this.comboBoxmaxSchritte);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.checkBoxZuschauen);
            this.groupBox1.Controls.Add(this.comboBoxmaxtrainingszeit);
            this.groupBox1.Controls.Add(this.comboBoxanzahldots);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.buttonTrain);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 98);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings:";
            // 
            // checkBoxShowDeathDistribution
            // 
            this.checkBoxShowDeathDistribution.AutoSize = true;
            this.checkBoxShowDeathDistribution.Location = new System.Drawing.Point(646, 70);
            this.checkBoxShowDeathDistribution.Name = "checkBoxShowDeathDistribution";
            this.checkBoxShowDeathDistribution.Size = new System.Drawing.Size(140, 17);
            this.checkBoxShowDeathDistribution.TabIndex = 24;
            this.checkBoxShowDeathDistribution.Text = "Show Death Distribution";
            this.checkBoxShowDeathDistribution.UseVisualStyleBackColor = true;
            this.checkBoxShowDeathDistribution.CheckedChanged += new System.EventHandler(this.checkBoxShowDeathDistribution_CheckedChanged);
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
            // buttonShowBestDot
            // 
            this.buttonShowBestDot.Enabled = false;
            this.buttonShowBestDot.Location = new System.Drawing.Point(646, 16);
            this.buttonShowBestDot.Name = "buttonShowBestDot";
            this.buttonShowBestDot.Size = new System.Drawing.Size(95, 23);
            this.buttonShowBestDot.TabIndex = 18;
            this.buttonShowBestDot.Text = "Show best dot";
            this.buttonShowBestDot.UseVisualStyleBackColor = true;
            this.buttonShowBestDot.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxmaxSchritte
            // 
            this.comboBoxmaxSchritte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxmaxSchritte.FormattingEnabled = true;
            this.comboBoxmaxSchritte.Items.AddRange(new object[] {
            "500",
            "1000",
            "2000",
            "5000",
            "10000",
            "20000"});
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
            "1000",
            "2000",
            "5000",
            "10000"});
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
            this.label9.Location = new System.Drawing.Point(9, 131);
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
            this.groupBox2.Controls.Add(this.richTextBoxstatus);
            this.groupBox2.Location = new System.Drawing.Point(603, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 449);
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
            this.buttonnextgen.Location = new System.Drawing.Point(104, 18);
            this.buttonnextgen.Name = "buttonnextgen";
            this.buttonnextgen.Size = new System.Drawing.Size(92, 23);
            this.buttonnextgen.TabIndex = 2;
            this.buttonnextgen.Text = "Next Gen";
            this.buttonnextgen.UseVisualStyleBackColor = true;
            this.buttonnextgen.Click += new System.EventHandler(this.buttonnextgen_Click);
            // 
            // labelprogress
            // 
            this.labelprogress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelprogress.AutoSize = true;
            this.labelprogress.Location = new System.Drawing.Point(98, 430);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new System.Drawing.Size(0, 13);
            this.labelprogress.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 422);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(227, 21);
            this.progressBar1.TabIndex = 1;
            // 
            // richTextBoxstatus
            // 
            this.richTextBoxstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxstatus.Location = new System.Drawing.Point(3, 47);
            this.richTextBoxstatus.Name = "richTextBoxstatus";
            this.richTextBoxstatus.ReadOnly = true;
            this.richTextBoxstatus.Size = new System.Drawing.Size(230, 369);
            this.richTextBoxstatus.TabIndex = 0;
            this.richTextBoxstatus.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.obstaclesToolStripMenuItem,
            this.startEndpointToolStripMenuItem,
            this.trainingToolStripMenuItem,
            this.printRanksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(854, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDeathDistributionToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "View";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // showDeathDistributionToolStripMenuItem
            // 
            this.showDeathDistributionToolStripMenuItem.Name = "showDeathDistributionToolStripMenuItem";
            this.showDeathDistributionToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.showDeathDistributionToolStripMenuItem.Text = "Show Death Distribution";
            // 
            // obstaclesToolStripMenuItem
            // 
            this.obstaclesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveActualObstacleToolStripMenuItem,
            this.toolStripComboBox1});
            this.obstaclesToolStripMenuItem.Name = "obstaclesToolStripMenuItem";
            this.obstaclesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.obstaclesToolStripMenuItem.Text = "Obstacles";
            // 
            // saveActualObstacleToolStripMenuItem
            // 
            this.saveActualObstacleToolStripMenuItem.Name = "saveActualObstacleToolStripMenuItem";
            this.saveActualObstacleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveActualObstacleToolStripMenuItem.Text = "Save current obstacle";
            this.saveActualObstacleToolStripMenuItem.Click += new System.EventHandler(this.saveActualObstacleToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Saved obstacles"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // startEndpointToolStripMenuItem
            // 
            this.startEndpointToolStripMenuItem.Name = "startEndpointToolStripMenuItem";
            this.startEndpointToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.startEndpointToolStripMenuItem.Text = "Start/Endpoint";
            this.startEndpointToolStripMenuItem.Click += new System.EventHandler(this.startEndpointToolStripMenuItem_Click);
            // 
            // trainingToolStripMenuItem
            // 
            this.trainingToolStripMenuItem.Name = "trainingToolStripMenuItem";
            this.trainingToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.trainingToolStripMenuItem.Text = "Trainingsmodus";
            this.trainingToolStripMenuItem.Click += new System.EventHandler(this.trainingToolStripMenuItem_Click);
            // 
            // printRanksToolStripMenuItem
            // 
            this.printRanksToolStripMenuItem.Name = "printRanksToolStripMenuItem";
            this.printRanksToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.printRanksToolStripMenuItem.Text = "Print Ranks";
            this.printRanksToolStripMenuItem.Click += new System.EventHandler(this.printRanksToolStripMenuItem_Click);
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "LearningDots";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button buttonTrain;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox comboBoxanzahldots;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox comboBoxmaxtrainingszeit;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RichTextBox richTextBoxstatus;
        public System.Windows.Forms.CheckBox checkBoxZuschauen;
        public System.Windows.Forms.ComboBox comboBoxmaxSchritte;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Button buttonShowBestDot;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label labelprogress;
        public System.Windows.Forms.CheckBox checkBoxdiagonal;
        public System.Windows.Forms.Button buttonprevgen;
        public System.Windows.Forms.Button buttonnextgen;
        public System.Windows.Forms.ComboBox comboBoxobstacle;
        public System.Windows.Forms.Button buttonresetTraining;
        public System.Windows.Forms.CheckBox checkBoxShowDeathDistribution;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem obstaclesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem startEndpointToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem showDeathDistributionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveActualObstacleToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem printRanksToolStripMenuItem;
    }
}

