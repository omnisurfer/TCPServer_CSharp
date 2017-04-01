namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.gpsTextBox = new System.Windows.Forms.TextBox();
            this.compassTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.odbTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdSendTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gpsTextBox
            // 
            this.gpsTextBox.Location = new System.Drawing.Point(12, 25);
            this.gpsTextBox.Multiline = true;
            this.gpsTextBox.Name = "gpsTextBox";
            this.gpsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gpsTextBox.Size = new System.Drawing.Size(419, 188);
            this.gpsTextBox.TabIndex = 0;
            // 
            // compassTextBox
            // 
            this.compassTextBox.Location = new System.Drawing.Point(453, 25);
            this.compassTextBox.Multiline = true;
            this.compassTextBox.Name = "compassTextBox";
            this.compassTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.compassTextBox.Size = new System.Drawing.Size(181, 188);
            this.compassTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "GPS_NMEA Stream";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "COMPASS Stream";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(702, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ODB Stream";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // odbTextBox
            // 
            this.odbTextBox.Location = new System.Drawing.Point(707, 25);
            this.odbTextBox.Multiline = true;
            this.odbTextBox.Name = "odbTextBox";
            this.odbTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.odbTextBox.Size = new System.Drawing.Size(181, 188);
            this.odbTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "CMD Stream";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmdTextBox
            // 
            this.cmdTextBox.Location = new System.Drawing.Point(12, 244);
            this.cmdTextBox.Multiline = true;
            this.cmdTextBox.Name = "cmdTextBox";
            this.cmdTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cmdTextBox.Size = new System.Drawing.Size(622, 159);
            this.cmdTextBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(559, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdSendTextBox
            // 
            this.cmdSendTextBox.Location = new System.Drawing.Point(12, 411);
            this.cmdSendTextBox.Name = "cmdSendTextBox";
            this.cmdSendTextBox.Size = new System.Drawing.Size(533, 20);
            this.cmdSendTextBox.TabIndex = 9;
            this.cmdSendTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(900, 447);
            this.Controls.Add(this.cmdSendTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.odbTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compassTextBox);
            this.Controls.Add(this.gpsTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gpsTextBox;
        private System.Windows.Forms.TextBox compassTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox odbTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cmdTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox cmdSendTextBox;
    }
}

