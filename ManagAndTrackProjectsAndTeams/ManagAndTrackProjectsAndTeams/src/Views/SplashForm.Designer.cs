namespace ManagAndTrackProjectsAndTeams.src.Views
{
    partial class SplashForm
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
            this.components = new System.ComponentModel.Container();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.guna2HtmlLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.guna2ProgressBar1);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(600, 400);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2ProgressBar1
            // 
            this.guna2ProgressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.guna2ProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(181)))));
            this.guna2ProgressBar1.Location = new System.Drawing.Point(168, 334);
            this.guna2ProgressBar1.Name = "guna2ProgressBar1";
            this.guna2ProgressBar1.Size = new System.Drawing.Size(300, 10);
            this.guna2ProgressBar1.TabIndex = 2;
            this.guna2ProgressBar1.Text = "guna2ProgressBar1";
            this.guna2ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // guna2HtmlLabel
            // 
            this.guna2HtmlLabel.AutoSize = false;
            this.guna2HtmlLabel.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel.ForeColor = System.Drawing.Color.Navy;
            this.guna2HtmlLabel.Location = new System.Drawing.Point(200, 259);
            this.guna2HtmlLabel.Name = "guna2HtmlLabel";
            this.guna2HtmlLabel.Size = new System.Drawing.Size(200, 40);
            this.guna2HtmlLabel.TabIndex = 1;
            this.guna2HtmlLabel.Text = "...التحميل جاري";
            this.guna2HtmlLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2PictureBox
            // 
            this.guna2PictureBox.BorderRadius = 75;
            this.guna2PictureBox.Image = global::ManagAndTrackProjectsAndTeams.Properties.Resources.OIP;
            this.guna2PictureBox.ImageRotate = 0F;
            this.guna2PictureBox.Location = new System.Drawing.Point(215, 41);
            this.guna2PictureBox.Name = "guna2PictureBox";
            this.guna2PictureBox.Size = new System.Drawing.Size(185, 187);
            this.guna2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox.TabIndex = 0;
            this.guna2PictureBox.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SplashForm";
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;
        private System.Windows.Forms.Timer timer;
    }
}