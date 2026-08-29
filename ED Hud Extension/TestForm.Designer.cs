namespace ED_Hud_Extension
{
    partial class TestForm
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
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            planetOne = new Label();
            planetTwo = new Label();
            planetThree = new Label();
            dataTag = new Label();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 5;
            timer1.Tick += timer1_Tick;
            // 
            // planetOne
            // 
            planetOne.AutoSize = true;
            planetOne.Font = new Font("Segoe UI", 26F);
            planetOne.Location = new Point(122, 122);
            planetOne.Name = "planetOne";
            planetOne.Size = new Size(146, 47);
            planetOne.TabIndex = 0;
            planetOne.Text = "planet 1";
            planetOne.MouseEnter += planetOne_MouseEnter;
            // 
            // planetTwo
            // 
            planetTwo.AutoSize = true;
            planetTwo.Font = new Font("Segoe UI", 26F);
            planetTwo.Location = new Point(122, 169);
            planetTwo.Name = "planetTwo";
            planetTwo.Size = new Size(146, 47);
            planetTwo.TabIndex = 1;
            planetTwo.Text = "planet 2";
            planetTwo.MouseEnter += planetTwo_MouseEnter;
            // 
            // planetThree
            // 
            planetThree.AutoSize = true;
            planetThree.Font = new Font("Segoe UI", 26F);
            planetThree.Location = new Point(122, 216);
            planetThree.Name = "planetThree";
            planetThree.Size = new Size(146, 47);
            planetThree.TabIndex = 2;
            planetThree.Text = "planet 3";
            planetThree.MouseEnter += planetTwo_MouseEnter;
            // 
            // dataTag
            // 
            dataTag.AutoSize = true;
            dataTag.Location = new Point(488, 95);
            dataTag.Name = "dataTag";
            dataTag.Size = new Size(12, 15);
            dataTag.TabIndex = 5;
            dataTag.Text = "\\";
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 625);
            Controls.Add(dataTag);
            Controls.Add(planetThree);
            Controls.Add(planetTwo);
            Controls.Add(planetOne);
            Name = "TestForm";
            Text = "TestForm";
            Load += TestForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label planetOne;
        private Label planetTwo;
        private Label planetThree;
        private Label dataTag;
    }
}