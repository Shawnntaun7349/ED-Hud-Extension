namespace ED_Hud_Extension
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            restartSessionButton = new Button();
            tabControl = new TabControl();
            combatPage = new TabPage();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            extendBountyTag = new Label();
            extendedBountyLabel = new Label();
            localBountyTag = new Label();
            legalStatusTag = new Label();
            targetShipLabel = new Label();
            legalStatusLabel = new Label();
            targetRankLabel = new Label();
            targetFactionLabel = new Label();
            localBounty = new Label();
            targetHullLabel = new Label();
            targetPowerLabel = new Label();
            targetShieldsLabel = new Label();
            targetNameLabel = new Label();
            tradePage = new TabPage();
            tabPage1 = new TabPage();
            tabControl.SuspendLayout();
            combatPage.SuspendLayout();
            SuspendLayout();
            // 
            // restartSessionButton
            // 
            restartSessionButton.BackColor = SystemColors.ActiveCaptionText;
            restartSessionButton.FlatStyle = FlatStyle.Popup;
            restartSessionButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            restartSessionButton.ForeColor = Color.FromArgb(255, 128, 0);
            restartSessionButton.Location = new Point(1794, 1045);
            restartSessionButton.Name = "restartSessionButton";
            restartSessionButton.Size = new Size(114, 23);
            restartSessionButton.TabIndex = 21;
            restartSessionButton.Text = "Restart Session";
            restartSessionButton.UseVisualStyleBackColor = false;
            restartSessionButton.Click += restartSessionButton_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(combatPage);
            tabControl.Controls.Add(tradePage);
            tabControl.Controls.Add(tabPage1);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(1, 1);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1896, 1027);
            tabControl.TabIndex = 22;
            // 
            // combatPage
            // 
            combatPage.BackColor = Color.DimGray;
            combatPage.Controls.Add(label8);
            combatPage.Controls.Add(label7);
            combatPage.Controls.Add(label6);
            combatPage.Controls.Add(label5);
            combatPage.Controls.Add(label4);
            combatPage.Controls.Add(label3);
            combatPage.Controls.Add(label2);
            combatPage.Controls.Add(label1);
            combatPage.Controls.Add(extendBountyTag);
            combatPage.Controls.Add(extendedBountyLabel);
            combatPage.Controls.Add(localBountyTag);
            combatPage.Controls.Add(legalStatusTag);
            combatPage.Controls.Add(targetShipLabel);
            combatPage.Controls.Add(legalStatusLabel);
            combatPage.Controls.Add(targetRankLabel);
            combatPage.Controls.Add(targetFactionLabel);
            combatPage.Controls.Add(localBounty);
            combatPage.Controls.Add(targetHullLabel);
            combatPage.Controls.Add(targetPowerLabel);
            combatPage.Controls.Add(targetShieldsLabel);
            combatPage.Controls.Add(targetNameLabel);
            combatPage.Location = new Point(4, 22);
            combatPage.Name = "combatPage";
            combatPage.Padding = new Padding(3);
            combatPage.Size = new Size(1888, 1001);
            combatPage.TabIndex = 0;
            combatPage.Text = "Combat";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(475, 693);
            label8.Name = "label8";
            label8.Size = new Size(19, 19);
            label8.TabIndex = 41;
            label8.Text = "A";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.Control;
            label7.Location = new Point(145, 213);
            label7.Name = "label7";
            label7.Size = new Size(101, 54);
            label7.TabIndex = 40;
            label7.Text = "N/A";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(189, 267);
            label6.Name = "label6";
            label6.Size = new Size(101, 54);
            label6.TabIndex = 39;
            label6.Text = "N/A";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(145, 321);
            label5.Name = "label5";
            label5.Size = new Size(101, 54);
            label5.TabIndex = 38;
            label5.Text = "N/A";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(189, 3);
            label4.Name = "label4";
            label4.Size = new Size(101, 54);
            label4.TabIndex = 37;
            label4.Text = "N/A";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(162, 57);
            label3.Name = "label3";
            label3.Size = new Size(101, 54);
            label3.TabIndex = 36;
            label3.Text = "N/A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(744, 3);
            label2.Name = "label2";
            label2.Size = new Size(101, 54);
            label2.TabIndex = 35;
            label2.Text = "N/A";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(762, 57);
            label1.Name = "label1";
            label1.Size = new Size(101, 54);
            label1.TabIndex = 34;
            label1.Text = "N/A";
            // 
            // extendBountyTag
            // 
            extendBountyTag.AutoSize = true;
            extendBountyTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            extendBountyTag.ForeColor = SystemColors.Control;
            extendBountyTag.Location = new Point(921, 165);
            extendBountyTag.Name = "extendBountyTag";
            extendBountyTag.Size = new Size(101, 54);
            extendBountyTag.TabIndex = 33;
            extendBountyTag.Text = "N/A";
            // 
            // extendedBountyLabel
            // 
            extendedBountyLabel.AutoSize = true;
            extendedBountyLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            extendedBountyLabel.ForeColor = Color.FromArgb(255, 128, 0);
            extendedBountyLabel.Location = new Point(564, 165);
            extendedBountyLabel.Name = "extendedBountyLabel";
            extendedBountyLabel.Size = new Size(351, 54);
            extendedBountyLabel.TabIndex = 32;
            extendedBountyLabel.Text = "Galactic Bounty : ";
            // 
            // localBountyTag
            // 
            localBountyTag.AutoSize = true;
            localBountyTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            localBountyTag.ForeColor = SystemColors.Control;
            localBountyTag.Location = new Point(869, 111);
            localBountyTag.Name = "localBountyTag";
            localBountyTag.Size = new Size(101, 54);
            localBountyTag.TabIndex = 31;
            localBountyTag.Text = "N/A";
            // 
            // legalStatusTag
            // 
            legalStatusTag.AutoSize = true;
            legalStatusTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            legalStatusTag.ForeColor = SystemColors.Control;
            legalStatusTag.Location = new Point(296, 111);
            legalStatusTag.Name = "legalStatusTag";
            legalStatusTag.Size = new Size(101, 54);
            legalStatusTag.TabIndex = 30;
            legalStatusTag.Text = "N/A";
            // 
            // targetShipLabel
            // 
            targetShipLabel.AutoSize = true;
            targetShipLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetShipLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetShipLabel.Location = new Point(6, 219);
            targetShipLabel.Name = "targetShipLabel";
            targetShipLabel.Size = new Size(138, 54);
            targetShipLabel.TabIndex = 29;
            targetShipLabel.Text = "Ship : ";
            // 
            // legalStatusLabel
            // 
            legalStatusLabel.AutoSize = true;
            legalStatusLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            legalStatusLabel.ForeColor = Color.FromArgb(255, 128, 0);
            legalStatusLabel.Location = new Point(6, 111);
            legalStatusLabel.Name = "legalStatusLabel";
            legalStatusLabel.Size = new Size(284, 54);
            legalStatusLabel.TabIndex = 28;
            legalStatusLabel.Text = "Legal Status : ";
            // 
            // targetRankLabel
            // 
            targetRankLabel.AutoSize = true;
            targetRankLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetRankLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetRankLabel.Location = new Point(6, 57);
            targetRankLabel.Name = "targetRankLabel";
            targetRankLabel.Size = new Size(150, 54);
            targetRankLabel.TabIndex = 27;
            targetRankLabel.Text = "Rank : ";
            // 
            // targetFactionLabel
            // 
            targetFactionLabel.AutoSize = true;
            targetFactionLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetFactionLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetFactionLabel.Location = new Point(564, 57);
            targetFactionLabel.Name = "targetFactionLabel";
            targetFactionLabel.Size = new Size(192, 54);
            targetFactionLabel.TabIndex = 26;
            targetFactionLabel.Text = "Faction : ";
            // 
            // localBounty
            // 
            localBounty.AutoSize = true;
            localBounty.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            localBounty.ForeColor = Color.FromArgb(255, 128, 0);
            localBounty.Location = new Point(564, 111);
            localBounty.Name = "localBounty";
            localBounty.Size = new Size(299, 54);
            localBounty.TabIndex = 25;
            localBounty.Text = "Local Bounty : ";
            // 
            // targetHullLabel
            // 
            targetHullLabel.AutoSize = true;
            targetHullLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetHullLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetHullLabel.Location = new Point(6, 327);
            targetHullLabel.Name = "targetHullLabel";
            targetHullLabel.Size = new Size(133, 54);
            targetHullLabel.TabIndex = 24;
            targetHullLabel.Text = "Hull : ";
            // 
            // targetPowerLabel
            // 
            targetPowerLabel.AutoSize = true;
            targetPowerLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetPowerLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetPowerLabel.Location = new Point(564, 3);
            targetPowerLabel.Name = "targetPowerLabel";
            targetPowerLabel.Size = new Size(174, 54);
            targetPowerLabel.TabIndex = 23;
            targetPowerLabel.Text = "Power : ";
            // 
            // targetShieldsLabel
            // 
            targetShieldsLabel.AutoSize = true;
            targetShieldsLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetShieldsLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetShieldsLabel.Location = new Point(6, 273);
            targetShieldsLabel.Name = "targetShieldsLabel";
            targetShieldsLabel.Size = new Size(189, 54);
            targetShieldsLabel.TabIndex = 22;
            targetShieldsLabel.Text = "Shields : ";
            // 
            // targetNameLabel
            // 
            targetNameLabel.AutoSize = true;
            targetNameLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetNameLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetNameLabel.Location = new Point(6, 3);
            targetNameLabel.Name = "targetNameLabel";
            targetNameLabel.Size = new Size(177, 54);
            targetNameLabel.TabIndex = 21;
            targetNameLabel.Text = "Target : ";
            // 
            // tradePage
            // 
            tradePage.BackColor = Color.DimGray;
            tradePage.BackgroundImageLayout = ImageLayout.None;
            tradePage.Location = new Point(4, 22);
            tradePage.Name = "tradePage";
            tradePage.Padding = new Padding(3);
            tradePage.Size = new Size(1888, 1001);
            tradePage.TabIndex = 1;
            tradePage.Text = "Trade";
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 22);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1888, 1001);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1920, 1080);
            Controls.Add(tabControl);
            Controls.Add(restartSessionButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "E:D Hud Extension";
            Shown += MainForm_Shown;
            tabControl.ResumeLayout(false);
            combatPage.ResumeLayout(false);
            combatPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button restartSessionButton;
        private TabControl tabControl;
        private TabPage combatPage;
        private TabPage tradePage;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label extendBountyTag;
        private Label extendedBountyLabel;
        private Label localBountyTag;
        private Label legalStatusTag;
        private Label targetShipLabel;
        private Label legalStatusLabel;
        private Label targetRankLabel;
        private Label targetFactionLabel;
        private Label localBounty;
        private Label targetHullLabel;
        private Label targetPowerLabel;
        private Label targetShieldsLabel;
        private Label targetNameLabel;
        private TabPage tabPage1;
    }
}
