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
            combatPanel = new Panel();
            combatStatTag = new Label();
            combatLabel = new Label();
            shipTag = new Label();
            shieldTag = new Label();
            hullTag = new Label();
            targetTag = new Label();
            rankTag = new Label();
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
            simulateButton = new Button();
            combatPanel.SuspendLayout();
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
            // combatPanel
            // 
            combatPanel.Controls.Add(combatStatTag);
            combatPanel.Controls.Add(combatLabel);
            combatPanel.Controls.Add(shipTag);
            combatPanel.Controls.Add(shieldTag);
            combatPanel.Controls.Add(hullTag);
            combatPanel.Controls.Add(targetTag);
            combatPanel.Controls.Add(rankTag);
            combatPanel.Controls.Add(label2);
            combatPanel.Controls.Add(label1);
            combatPanel.Controls.Add(extendBountyTag);
            combatPanel.Controls.Add(extendedBountyLabel);
            combatPanel.Controls.Add(localBountyTag);
            combatPanel.Controls.Add(legalStatusTag);
            combatPanel.Controls.Add(targetShipLabel);
            combatPanel.Controls.Add(legalStatusLabel);
            combatPanel.Controls.Add(targetRankLabel);
            combatPanel.Controls.Add(targetFactionLabel);
            combatPanel.Controls.Add(localBounty);
            combatPanel.Controls.Add(targetHullLabel);
            combatPanel.Controls.Add(targetPowerLabel);
            combatPanel.Controls.Add(targetShieldsLabel);
            combatPanel.Controls.Add(targetNameLabel);
            combatPanel.Location = new Point(73, 12);
            combatPanel.Name = "combatPanel";
            combatPanel.Size = new Size(1835, 1027);
            combatPanel.TabIndex = 22;
            // 
            // combatStatTag
            // 
            combatStatTag.AutoSize = true;
            combatStatTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            combatStatTag.ForeColor = SystemColors.Control;
            combatStatTag.Location = new Point(970, -3);
            combatStatTag.Name = "combatStatTag";
            combatStatTag.Size = new Size(172, 54);
            combatStatTag.TabIndex = 62;
            combatStatTag.Text = "Inactive";
            // 
            // combatLabel
            // 
            combatLabel.AutoSize = true;
            combatLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            combatLabel.ForeColor = Color.FromArgb(255, 128, 0);
            combatLabel.Location = new Point(790, 0);
            combatLabel.Name = "combatLabel";
            combatLabel.Size = new Size(205, 54);
            combatLabel.TabIndex = 61;
            combatLabel.Text = "Combat : ";
            // 
            // shipTag
            // 
            shipTag.AutoSize = true;
            shipTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            shipTag.ForeColor = SystemColors.Control;
            shipTag.Location = new Point(139, 388);
            shipTag.Name = "shipTag";
            shipTag.Size = new Size(101, 54);
            shipTag.TabIndex = 60;
            shipTag.Text = "N/A";
            // 
            // shieldTag
            // 
            shieldTag.AutoSize = true;
            shieldTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            shieldTag.ForeColor = SystemColors.Control;
            shieldTag.Location = new Point(183, 442);
            shieldTag.Name = "shieldTag";
            shieldTag.Size = new Size(101, 54);
            shieldTag.TabIndex = 59;
            shieldTag.Text = "N/A";
            // 
            // hullTag
            // 
            hullTag.AutoSize = true;
            hullTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hullTag.ForeColor = SystemColors.Control;
            hullTag.Location = new Point(139, 496);
            hullTag.Name = "hullTag";
            hullTag.Size = new Size(101, 54);
            hullTag.TabIndex = 58;
            hullTag.Text = "N/A";
            // 
            // targetTag
            // 
            targetTag.AutoSize = true;
            targetTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetTag.ForeColor = SystemColors.Control;
            targetTag.Location = new Point(183, 178);
            targetTag.Name = "targetTag";
            targetTag.Size = new Size(101, 54);
            targetTag.TabIndex = 57;
            targetTag.Text = "N/A";
            // 
            // rankTag
            // 
            rankTag.AutoSize = true;
            rankTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rankTag.ForeColor = SystemColors.Control;
            rankTag.Location = new Point(156, 232);
            rankTag.Name = "rankTag";
            rankTag.Size = new Size(101, 54);
            rankTag.TabIndex = 56;
            rankTag.Text = "N/A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(738, 178);
            label2.Name = "label2";
            label2.Size = new Size(101, 54);
            label2.TabIndex = 55;
            label2.Text = "N/A";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(756, 232);
            label1.Name = "label1";
            label1.Size = new Size(101, 54);
            label1.TabIndex = 54;
            label1.Text = "N/A";
            // 
            // extendBountyTag
            // 
            extendBountyTag.AutoSize = true;
            extendBountyTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            extendBountyTag.ForeColor = SystemColors.Control;
            extendBountyTag.Location = new Point(915, 340);
            extendBountyTag.Name = "extendBountyTag";
            extendBountyTag.Size = new Size(101, 54);
            extendBountyTag.TabIndex = 53;
            extendBountyTag.Text = "N/A";
            // 
            // extendedBountyLabel
            // 
            extendedBountyLabel.AutoSize = true;
            extendedBountyLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            extendedBountyLabel.ForeColor = Color.FromArgb(255, 128, 0);
            extendedBountyLabel.Location = new Point(558, 340);
            extendedBountyLabel.Name = "extendedBountyLabel";
            extendedBountyLabel.Size = new Size(351, 54);
            extendedBountyLabel.TabIndex = 52;
            extendedBountyLabel.Text = "Galactic Bounty : ";
            // 
            // localBountyTag
            // 
            localBountyTag.AutoSize = true;
            localBountyTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            localBountyTag.ForeColor = SystemColors.Control;
            localBountyTag.Location = new Point(863, 286);
            localBountyTag.Name = "localBountyTag";
            localBountyTag.Size = new Size(101, 54);
            localBountyTag.TabIndex = 51;
            localBountyTag.Text = "N/A";
            // 
            // legalStatusTag
            // 
            legalStatusTag.AutoSize = true;
            legalStatusTag.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            legalStatusTag.ForeColor = SystemColors.Control;
            legalStatusTag.Location = new Point(290, 286);
            legalStatusTag.Name = "legalStatusTag";
            legalStatusTag.Size = new Size(101, 54);
            legalStatusTag.TabIndex = 50;
            legalStatusTag.Text = "N/A";
            // 
            // targetShipLabel
            // 
            targetShipLabel.AutoSize = true;
            targetShipLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetShipLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetShipLabel.Location = new Point(0, 394);
            targetShipLabel.Name = "targetShipLabel";
            targetShipLabel.Size = new Size(138, 54);
            targetShipLabel.TabIndex = 49;
            targetShipLabel.Text = "Ship : ";
            // 
            // legalStatusLabel
            // 
            legalStatusLabel.AutoSize = true;
            legalStatusLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            legalStatusLabel.ForeColor = Color.FromArgb(255, 128, 0);
            legalStatusLabel.Location = new Point(0, 286);
            legalStatusLabel.Name = "legalStatusLabel";
            legalStatusLabel.Size = new Size(284, 54);
            legalStatusLabel.TabIndex = 48;
            legalStatusLabel.Text = "Legal Status : ";
            // 
            // targetRankLabel
            // 
            targetRankLabel.AutoSize = true;
            targetRankLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetRankLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetRankLabel.Location = new Point(0, 232);
            targetRankLabel.Name = "targetRankLabel";
            targetRankLabel.Size = new Size(150, 54);
            targetRankLabel.TabIndex = 47;
            targetRankLabel.Text = "Rank : ";
            // 
            // targetFactionLabel
            // 
            targetFactionLabel.AutoSize = true;
            targetFactionLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetFactionLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetFactionLabel.Location = new Point(558, 232);
            targetFactionLabel.Name = "targetFactionLabel";
            targetFactionLabel.Size = new Size(192, 54);
            targetFactionLabel.TabIndex = 46;
            targetFactionLabel.Text = "Faction : ";
            // 
            // localBounty
            // 
            localBounty.AutoSize = true;
            localBounty.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            localBounty.ForeColor = Color.FromArgb(255, 128, 0);
            localBounty.Location = new Point(558, 286);
            localBounty.Name = "localBounty";
            localBounty.Size = new Size(299, 54);
            localBounty.TabIndex = 45;
            localBounty.Text = "Local Bounty : ";
            // 
            // targetHullLabel
            // 
            targetHullLabel.AutoSize = true;
            targetHullLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetHullLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetHullLabel.Location = new Point(0, 502);
            targetHullLabel.Name = "targetHullLabel";
            targetHullLabel.Size = new Size(133, 54);
            targetHullLabel.TabIndex = 44;
            targetHullLabel.Text = "Hull : ";
            // 
            // targetPowerLabel
            // 
            targetPowerLabel.AutoSize = true;
            targetPowerLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetPowerLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetPowerLabel.Location = new Point(558, 178);
            targetPowerLabel.Name = "targetPowerLabel";
            targetPowerLabel.Size = new Size(174, 54);
            targetPowerLabel.TabIndex = 43;
            targetPowerLabel.Text = "Power : ";
            // 
            // targetShieldsLabel
            // 
            targetShieldsLabel.AutoSize = true;
            targetShieldsLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetShieldsLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetShieldsLabel.Location = new Point(0, 448);
            targetShieldsLabel.Name = "targetShieldsLabel";
            targetShieldsLabel.Size = new Size(189, 54);
            targetShieldsLabel.TabIndex = 42;
            targetShieldsLabel.Text = "Shields : ";
            // 
            // targetNameLabel
            // 
            targetNameLabel.AutoSize = true;
            targetNameLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            targetNameLabel.ForeColor = Color.FromArgb(255, 128, 0);
            targetNameLabel.Location = new Point(0, 178);
            targetNameLabel.Name = "targetNameLabel";
            targetNameLabel.Size = new Size(177, 54);
            targetNameLabel.TabIndex = 41;
            targetNameLabel.Text = "Target : ";
            // 
            // simulateButton
            // 
            simulateButton.BackColor = SystemColors.ActiveCaptionText;
            simulateButton.FlatStyle = FlatStyle.Popup;
            simulateButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            simulateButton.ForeColor = Color.FromArgb(255, 128, 0);
            simulateButton.Location = new Point(1674, 1045);
            simulateButton.Name = "simulateButton";
            simulateButton.Size = new Size(114, 23);
            simulateButton.TabIndex = 23;
            simulateButton.Text = "Simulate Combat";
            simulateButton.UseVisualStyleBackColor = false;
            simulateButton.Click += simulateButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1920, 1080);
            Controls.Add(simulateButton);
            Controls.Add(combatPanel);
            Controls.Add(restartSessionButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "E:D Hud Extension";
            combatPanel.ResumeLayout(false);
            combatPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button restartSessionButton;
        private Panel combatPanel;
        private Label shipTag;
        private Label shieldTag;
        private Label hullTag;
        private Label targetTag;
        private Label rankTag;
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
        private Label combatStatTag;
        private Label combatLabel;
        private Button simulateButton;
    }
}
