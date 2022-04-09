
namespace LearningDots
{
    partial class FormStartEndpoint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Y:";
            // 
            // textBoxzielY
            // 
            this.textBoxzielY.Location = new System.Drawing.Point(161, 40);
            this.textBoxzielY.Name = "textBoxzielY";
            this.textBoxzielY.Size = new System.Drawing.Size(36, 20);
            this.textBoxzielY.TabIndex = 21;
            this.textBoxzielY.TextChanged += new System.EventHandler(this.textBoxzielY_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Endpoint:";
            // 
            // textBoxzielX
            // 
            this.textBoxzielX.Location = new System.Drawing.Point(96, 40);
            this.textBoxzielX.Name = "textBoxzielX";
            this.textBoxzielX.Size = new System.Drawing.Size(36, 20);
            this.textBoxzielX.TabIndex = 19;
            this.textBoxzielX.TextChanged += new System.EventHandler(this.textBoxzielX_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Y:";
            // 
            // textBoxstartY
            // 
            this.textBoxstartY.Location = new System.Drawing.Point(161, 12);
            this.textBoxstartY.Name = "textBoxstartY";
            this.textBoxstartY.Size = new System.Drawing.Size(36, 20);
            this.textBoxstartY.TabIndex = 16;
            this.textBoxstartY.TextChanged += new System.EventHandler(this.textBoxstartY_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "X:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Startpoint:";
            // 
            // textBoxstartX
            // 
            this.textBoxstartX.Location = new System.Drawing.Point(96, 12);
            this.textBoxstartX.Name = "textBoxstartX";
            this.textBoxstartX.Size = new System.Drawing.Size(36, 20);
            this.textBoxstartX.TabIndex = 14;
            this.textBoxstartX.TextChanged += new System.EventHandler(this.textBoxstartX_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Abort";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormStartEndpoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 106);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxzielY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxzielX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxstartY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxstartX);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(228, 145);
            this.MinimumSize = new System.Drawing.Size(228, 145);
            this.Name = "FormStartEndpoint";
            this.ShowIcon = false;
            this.Text = "FormStartEndpoint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxzielY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxzielX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxstartY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxstartX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}