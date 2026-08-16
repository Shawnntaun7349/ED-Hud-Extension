namespace ED_Hud_Extension
{
    partial class InitForm
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
            initLabel = new Label();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // initLabel
            // 
            initLabel.AutoSize = true;
            initLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            initLabel.ForeColor = Color.FromArgb(255, 128, 0);
            initLabel.Location = new Point(811, 478);
            initLabel.Name = "initLabel";
            initLabel.Size = new Size(299, 54);
            initLabel.TabIndex = 3;
            initLabel.Text = "< Initializing >";
            initLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = SystemColors.ControlDarkDark;
            progressBar1.ForeColor = Color.FromArgb(255, 128, 0);
            progressBar1.Location = new Point(811, 557);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(299, 23);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 2;
            // 
            // InitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 255);
            ClientSize = new Size(1920, 1080);
            Controls.Add(initLabel);
            Controls.Add(progressBar1);
            Name = "InitForm";
            Text = "Elite: Dangerous Hud Extension";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label initLabel;
        private ProgressBar progressBar1;
    }
}