using EliteJournalReader;
using EliteJournalReader.Events;

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
            combatTag = new Label();
            combatLinkLabel = new Label();
            combatStarDTTag = new Label();
            combatStarDTLabel = new Label();
            combatLocDTTag = new Label();
            combatLocDTLabel = new Label();
            combatLabel = new Label();
            targetShipTag = new Label();
            targetShieldTag = new Label();
            targetHullTag = new Label();
            targetTag = new Label();
            targetRankTag = new Label();
            label2 = new Label();
            label1 = new Label();
            targetExtendBountyTag = new Label();
            targetExtendedBountyLabel = new Label();
            targetLocalBountyTag = new Label();
            targetLegalStatusTag = new Label();
            targetShipLabel = new Label();
            targetLegalStatusLabel = new Label();
            targetRankLabel = new Label();
            targetFactionLabel = new Label();
            targetLocalBounty = new Label();
            targetHullLabel = new Label();
            targetPowerLabel = new Label();
            targetShieldsLabel = new Label();
            targetNameLabel = new Label();
            simulateButton = new Button();
            settingsButton = new Button();
            combatButton = new Button();
            explorationButton = new Button();
            homeButton = new Button();
            initPanel = new Panel();
            enviroDone = new Label();
            uplinkDone = new Label();
            clientDone = new Label();
            diagDone = new Label();
            initDone = new Label();
            waitingClientLabel = new Label();
            waitingConnectLabel = new Label();
            initLabel = new Label();
            diagLabel = new Label();
            enviroLabel = new Label();
            homePanel = new Panel();
            homeARLabel = new Label();
            homeARTag = new Label();
            homeMRLabel = new Label();
            homeMRTag = new Label();
            homeEXRLabel = new Label();
            homeEXRTag = new Label();
            homeERLabel = new Label();
            homeERTag = new Label();
            homeTRLabel = new Label();
            homeLSTag = new Label();
            homeLSLabel = new Label();
            homeLBTag = new Label();
            homeSysTag = new Label();
            homeCRLabel = new Label();
            homeCRTag = new Label();
            creditBalanceLabel = new Label();
            homeSysLabel = new Label();
            homeCredBalanceTag = new Label();
            homeTRTag = new Label();
            homeLBLabel = new Label();
            curShipFuelTag = new Label();
            curShipIDTag = new Label();
            curShipDesTag = new Label();
            curShipTag = new Label();
            shipFuelLabel = new Label();
            shipIDLabel = new Label();
            linkLabel = new Label();
            shipNameLabel = new Label();
            shipLabel = new Label();
            starDTTag = new Label();
            waitingSTTag = new Label();
            starDTLabel = new Label();
            locDTTag = new Label();
            welcomeLabel = new Label();
            locDTLabel = new Label();
            explorePanel = new Panel();
            exploreLinkLabel = new Label();
            exploreStarDTTag = new Label();
            exploreStarDTLabel = new Label();
            exploreLocDTTag = new Label();
            exploreLocDTLabel = new Label();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            label32 = new Label();
            label33 = new Label();
            label34 = new Label();
            label35 = new Label();
            label36 = new Label();
            label37 = new Label();
            label38 = new Label();
            label39 = new Label();
            label40 = new Label();
            label41 = new Label();
            label42 = new Label();
            label43 = new Label();
            label44 = new Label();
            label45 = new Label();
            label46 = new Label();
            dividerPanel = new Panel();
            exitButton = new Button();
            statusPanel = new Panel();
            verLabel = new Label();
            statusLabel = new Label();
            combatPanel.SuspendLayout();
            initPanel.SuspendLayout();
            homePanel.SuspendLayout();
            explorePanel.SuspendLayout();
            statusPanel.SuspendLayout();
            SuspendLayout();
            // 
            // restartSessionButton
            // 
            restartSessionButton.BackColor = SystemColors.ActiveCaptionText;
            restartSessionButton.FlatStyle = FlatStyle.Popup;
            restartSessionButton.Font = new Font("Oxanium ExtraBold", 9F, FontStyle.Bold);
            restartSessionButton.ForeColor = Color.FromArgb(192, 64, 0);
            restartSessionButton.Location = new Point(12, 929);
            restartSessionButton.Name = "restartSessionButton";
            restartSessionButton.Size = new Size(92, 23);
            restartSessionButton.TabIndex = 21;
            restartSessionButton.Text = "Restart Session";
            restartSessionButton.UseVisualStyleBackColor = false;
            restartSessionButton.Click += restartSessionButton_Click;
            // 
            // combatPanel
            // 
            combatPanel.Controls.Add(combatTag);
            combatPanel.Controls.Add(combatLinkLabel);
            combatPanel.Controls.Add(combatStarDTTag);
            combatPanel.Controls.Add(combatStarDTLabel);
            combatPanel.Controls.Add(combatLocDTTag);
            combatPanel.Controls.Add(combatLocDTLabel);
            combatPanel.Controls.Add(combatLabel);
            combatPanel.Controls.Add(targetShipTag);
            combatPanel.Controls.Add(targetShieldTag);
            combatPanel.Controls.Add(targetHullTag);
            combatPanel.Controls.Add(targetTag);
            combatPanel.Controls.Add(targetRankTag);
            combatPanel.Controls.Add(label2);
            combatPanel.Controls.Add(label1);
            combatPanel.Controls.Add(targetExtendBountyTag);
            combatPanel.Controls.Add(targetExtendedBountyLabel);
            combatPanel.Controls.Add(targetLocalBountyTag);
            combatPanel.Controls.Add(targetLegalStatusTag);
            combatPanel.Controls.Add(targetShipLabel);
            combatPanel.Controls.Add(targetLegalStatusLabel);
            combatPanel.Controls.Add(targetRankLabel);
            combatPanel.Controls.Add(targetFactionLabel);
            combatPanel.Controls.Add(targetLocalBounty);
            combatPanel.Controls.Add(targetHullLabel);
            combatPanel.Controls.Add(targetPowerLabel);
            combatPanel.Controls.Add(targetShieldsLabel);
            combatPanel.Controls.Add(targetNameLabel);
            combatPanel.Location = new Point(114, 12);
            combatPanel.Name = "combatPanel";
            combatPanel.Size = new Size(1798, 1031);
            combatPanel.TabIndex = 22;
            // 
            // combatTag
            // 
            combatTag.Anchor = AnchorStyles.Top;
            combatTag.AutoSize = true;
            combatTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            combatTag.ForeColor = SystemColors.Control;
            combatTag.Location = new Point(767, 47);
            combatTag.Name = "combatTag";
            combatTag.Size = new Size(174, 50);
            combatTag.TabIndex = 76;
            combatTag.Text = "Inactive";
            combatTag.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // combatLinkLabel
            // 
            combatLinkLabel.AutoSize = true;
            combatLinkLabel.Font = new Font("Oxanium", 21.75F);
            combatLinkLabel.ForeColor = Color.FromArgb(192, 64, 0);
            combatLinkLabel.Location = new Point(698, 98);
            combatLinkLabel.Name = "combatLinkLabel";
            combatLinkLabel.Size = new Size(307, 36);
            combatLinkLabel.TabIndex = 75;
            combatLinkLabel.Text = "uplink intergrity : high";
            // 
            // combatStarDTTag
            // 
            combatStarDTTag.Font = new Font("Oxanium", 21.75F);
            combatStarDTTag.ForeColor = Color.FromArgb(192, 64, 0);
            combatStarDTTag.Location = new Point(1414, 42);
            combatStarDTTag.Name = "combatStarDTTag";
            combatStarDTTag.Size = new Size(381, 72);
            combatStarDTTag.TabIndex = 74;
            combatStarDTTag.Text = "Tuesday, August 18th 3312\r\n2:45\r\n";
            combatStarDTTag.TextAlign = ContentAlignment.MiddleRight;
            // 
            // combatStarDTLabel
            // 
            combatStarDTLabel.AutoSize = true;
            combatStarDTLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            combatStarDTLabel.ForeColor = SystemColors.Control;
            combatStarDTLabel.Location = new Point(1463, -12);
            combatStarDTLabel.Name = "combatStarDTLabel";
            combatStarDTLabel.Size = new Size(332, 50);
            combatStarDTLabel.TabIndex = 73;
            combatStarDTLabel.Text = "Star Date / Time";
            combatStarDTLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // combatLocDTTag
            // 
            combatLocDTTag.AutoSize = true;
            combatLocDTTag.Font = new Font("Oxanium", 21.75F);
            combatLocDTTag.ForeColor = Color.FromArgb(192, 64, 0);
            combatLocDTTag.Location = new Point(4, 42);
            combatLocDTTag.Name = "combatLocDTTag";
            combatLocDTTag.Size = new Size(189, 72);
            combatLocDTTag.TabIndex = 72;
            combatLocDTTag.Text = "Waiting for\r\nconnection...\r\n";
            // 
            // combatLocDTLabel
            // 
            combatLocDTLabel.AutoSize = true;
            combatLocDTLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            combatLocDTLabel.ForeColor = SystemColors.Control;
            combatLocDTLabel.Location = new Point(4, -12);
            combatLocDTLabel.Name = "combatLocDTLabel";
            combatLocDTLabel.Size = new Size(354, 50);
            combatLocDTLabel.TabIndex = 71;
            combatLocDTLabel.Text = "Local Date / Time";
            // 
            // combatLabel
            // 
            combatLabel.AutoSize = true;
            combatLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            combatLabel.ForeColor = Color.FromArgb(192, 64, 0);
            combatLabel.Location = new Point(756, 0);
            combatLabel.Name = "combatLabel";
            combatLabel.Size = new Size(201, 50);
            combatLabel.TabIndex = 61;
            combatLabel.Text = "Combat : ";
            // 
            // targetShipTag
            // 
            targetShipTag.AutoSize = true;
            targetShipTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetShipTag.ForeColor = SystemColors.Control;
            targetShipTag.Location = new Point(139, 388);
            targetShipTag.Name = "targetShipTag";
            targetShipTag.Size = new Size(94, 50);
            targetShipTag.TabIndex = 60;
            targetShipTag.Text = "N/A";
            // 
            // targetShieldTag
            // 
            targetShieldTag.AutoSize = true;
            targetShieldTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetShieldTag.ForeColor = SystemColors.Control;
            targetShieldTag.Location = new Point(183, 442);
            targetShieldTag.Name = "targetShieldTag";
            targetShieldTag.Size = new Size(94, 50);
            targetShieldTag.TabIndex = 59;
            targetShieldTag.Text = "N/A";
            // 
            // targetHullTag
            // 
            targetHullTag.AutoSize = true;
            targetHullTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetHullTag.ForeColor = SystemColors.Control;
            targetHullTag.Location = new Point(139, 496);
            targetHullTag.Name = "targetHullTag";
            targetHullTag.Size = new Size(94, 50);
            targetHullTag.TabIndex = 58;
            targetHullTag.Text = "N/A";
            // 
            // targetTag
            // 
            targetTag.AutoSize = true;
            targetTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetTag.ForeColor = SystemColors.Control;
            targetTag.Location = new Point(183, 178);
            targetTag.Name = "targetTag";
            targetTag.Size = new Size(94, 50);
            targetTag.TabIndex = 57;
            targetTag.Text = "N/A";
            // 
            // targetRankTag
            // 
            targetRankTag.AutoSize = true;
            targetRankTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetRankTag.ForeColor = SystemColors.Control;
            targetRankTag.Location = new Point(156, 232);
            targetRankTag.Name = "targetRankTag";
            targetRankTag.Size = new Size(94, 50);
            targetRankTag.TabIndex = 56;
            targetRankTag.Text = "N/A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(738, 178);
            label2.Name = "label2";
            label2.Size = new Size(94, 50);
            label2.TabIndex = 55;
            label2.Text = "N/A";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(756, 232);
            label1.Name = "label1";
            label1.Size = new Size(94, 50);
            label1.TabIndex = 54;
            label1.Text = "N/A";
            // 
            // targetExtendBountyTag
            // 
            targetExtendBountyTag.AutoSize = true;
            targetExtendBountyTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetExtendBountyTag.ForeColor = SystemColors.Control;
            targetExtendBountyTag.Location = new Point(915, 340);
            targetExtendBountyTag.Name = "targetExtendBountyTag";
            targetExtendBountyTag.Size = new Size(94, 50);
            targetExtendBountyTag.TabIndex = 53;
            targetExtendBountyTag.Text = "N/A";
            // 
            // targetExtendedBountyLabel
            // 
            targetExtendedBountyLabel.AutoSize = true;
            targetExtendedBountyLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetExtendedBountyLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetExtendedBountyLabel.Location = new Point(558, 340);
            targetExtendedBountyLabel.Name = "targetExtendedBountyLabel";
            targetExtendedBountyLabel.Size = new Size(353, 50);
            targetExtendedBountyLabel.TabIndex = 52;
            targetExtendedBountyLabel.Text = "Galactic Bounty : ";
            // 
            // targetLocalBountyTag
            // 
            targetLocalBountyTag.AutoSize = true;
            targetLocalBountyTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetLocalBountyTag.ForeColor = SystemColors.Control;
            targetLocalBountyTag.Location = new Point(863, 286);
            targetLocalBountyTag.Name = "targetLocalBountyTag";
            targetLocalBountyTag.Size = new Size(94, 50);
            targetLocalBountyTag.TabIndex = 51;
            targetLocalBountyTag.Text = "N/A";
            // 
            // targetLegalStatusTag
            // 
            targetLegalStatusTag.AutoSize = true;
            targetLegalStatusTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetLegalStatusTag.ForeColor = SystemColors.Control;
            targetLegalStatusTag.Location = new Point(290, 286);
            targetLegalStatusTag.Name = "targetLegalStatusTag";
            targetLegalStatusTag.Size = new Size(94, 50);
            targetLegalStatusTag.TabIndex = 50;
            targetLegalStatusTag.Text = "N/A";
            // 
            // targetShipLabel
            // 
            targetShipLabel.AutoSize = true;
            targetShipLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetShipLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetShipLabel.Location = new Point(0, 394);
            targetShipLabel.Name = "targetShipLabel";
            targetShipLabel.Size = new Size(136, 50);
            targetShipLabel.TabIndex = 49;
            targetShipLabel.Text = "Ship : ";
            // 
            // targetLegalStatusLabel
            // 
            targetLegalStatusLabel.AutoSize = true;
            targetLegalStatusLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetLegalStatusLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetLegalStatusLabel.Location = new Point(0, 286);
            targetLegalStatusLabel.Name = "targetLegalStatusLabel";
            targetLegalStatusLabel.Size = new Size(289, 50);
            targetLegalStatusLabel.TabIndex = 48;
            targetLegalStatusLabel.Text = "Legal Status : ";
            // 
            // targetRankLabel
            // 
            targetRankLabel.AutoSize = true;
            targetRankLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetRankLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetRankLabel.Location = new Point(0, 232);
            targetRankLabel.Name = "targetRankLabel";
            targetRankLabel.Size = new Size(148, 50);
            targetRankLabel.TabIndex = 47;
            targetRankLabel.Text = "Rank : ";
            // 
            // targetFactionLabel
            // 
            targetFactionLabel.AutoSize = true;
            targetFactionLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetFactionLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetFactionLabel.Location = new Point(558, 232);
            targetFactionLabel.Name = "targetFactionLabel";
            targetFactionLabel.Size = new Size(194, 50);
            targetFactionLabel.TabIndex = 46;
            targetFactionLabel.Text = "Faction : ";
            // 
            // targetLocalBounty
            // 
            targetLocalBounty.AutoSize = true;
            targetLocalBounty.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetLocalBounty.ForeColor = Color.FromArgb(192, 64, 0);
            targetLocalBounty.Location = new Point(558, 286);
            targetLocalBounty.Name = "targetLocalBounty";
            targetLocalBounty.Size = new Size(301, 50);
            targetLocalBounty.TabIndex = 45;
            targetLocalBounty.Text = "Local Bounty : ";
            // 
            // targetHullLabel
            // 
            targetHullLabel.AutoSize = true;
            targetHullLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetHullLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetHullLabel.Location = new Point(0, 502);
            targetHullLabel.Name = "targetHullLabel";
            targetHullLabel.Size = new Size(129, 50);
            targetHullLabel.TabIndex = 44;
            targetHullLabel.Text = "Hull : ";
            // 
            // targetPowerLabel
            // 
            targetPowerLabel.AutoSize = true;
            targetPowerLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetPowerLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetPowerLabel.Location = new Point(558, 178);
            targetPowerLabel.Name = "targetPowerLabel";
            targetPowerLabel.Size = new Size(175, 50);
            targetPowerLabel.TabIndex = 43;
            targetPowerLabel.Text = "Power : ";
            // 
            // targetShieldsLabel
            // 
            targetShieldsLabel.AutoSize = true;
            targetShieldsLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetShieldsLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetShieldsLabel.Location = new Point(0, 448);
            targetShieldsLabel.Name = "targetShieldsLabel";
            targetShieldsLabel.Size = new Size(191, 50);
            targetShieldsLabel.TabIndex = 42;
            targetShieldsLabel.Text = "Shields : ";
            // 
            // targetNameLabel
            // 
            targetNameLabel.AutoSize = true;
            targetNameLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetNameLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetNameLabel.Location = new Point(0, 178);
            targetNameLabel.Name = "targetNameLabel";
            targetNameLabel.Size = new Size(176, 50);
            targetNameLabel.TabIndex = 41;
            targetNameLabel.Text = "Target : ";
            // 
            // simulateButton
            // 
            simulateButton.BackColor = SystemColors.ActiveCaptionText;
            simulateButton.FlatStyle = FlatStyle.Popup;
            simulateButton.Font = new Font("Oxanium ExtraBold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            simulateButton.ForeColor = Color.FromArgb(192, 64, 0);
            simulateButton.Location = new Point(12, 958);
            simulateButton.Name = "simulateButton";
            simulateButton.Size = new Size(92, 23);
            simulateButton.TabIndex = 23;
            simulateButton.Text = "Simulate Combat";
            simulateButton.UseVisualStyleBackColor = false;
            simulateButton.Click += simulateButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = SystemColors.ActiveCaptionText;
            settingsButton.FlatStyle = FlatStyle.Popup;
            settingsButton.Font = new Font("Oxanium ExtraBold", 9F, FontStyle.Bold);
            settingsButton.ForeColor = Color.FromArgb(192, 64, 0);
            settingsButton.Location = new Point(12, 987);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(92, 23);
            settingsButton.TabIndex = 24;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // combatButton
            // 
            combatButton.BackColor = SystemColors.ActiveCaptionText;
            combatButton.FlatStyle = FlatStyle.Popup;
            combatButton.Font = new Font("Oxanium ExtraBold", 9F, FontStyle.Bold);
            combatButton.ForeColor = Color.FromArgb(192, 64, 0);
            combatButton.Location = new Point(12, 43);
            combatButton.Name = "combatButton";
            combatButton.Size = new Size(92, 23);
            combatButton.TabIndex = 25;
            combatButton.Text = "Combat";
            combatButton.UseVisualStyleBackColor = false;
            combatButton.Click += combatButton_Click;
            // 
            // explorationButton
            // 
            explorationButton.BackColor = SystemColors.ActiveCaptionText;
            explorationButton.FlatStyle = FlatStyle.Popup;
            explorationButton.Font = new Font("Oxanium ExtraBold", 9F, FontStyle.Bold);
            explorationButton.ForeColor = Color.FromArgb(192, 64, 0);
            explorationButton.Location = new Point(12, 72);
            explorationButton.Name = "explorationButton";
            explorationButton.Size = new Size(92, 23);
            explorationButton.TabIndex = 26;
            explorationButton.Text = "Exploration";
            explorationButton.UseVisualStyleBackColor = false;
            explorationButton.Click += explorationButton_Click;
            // 
            // homeButton
            // 
            homeButton.BackColor = SystemColors.ActiveCaptionText;
            homeButton.FlatStyle = FlatStyle.Popup;
            homeButton.Font = new Font("Oxanium ExtraBold", 9F, FontStyle.Bold);
            homeButton.ForeColor = Color.FromArgb(192, 64, 0);
            homeButton.Location = new Point(12, 14);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(92, 23);
            homeButton.TabIndex = 27;
            homeButton.Text = "Home";
            homeButton.UseVisualStyleBackColor = false;
            homeButton.Click += homeButton_Click;
            // 
            // initPanel
            // 
            initPanel.BackColor = SystemColors.ActiveCaptionText;
            initPanel.Controls.Add(enviroDone);
            initPanel.Controls.Add(uplinkDone);
            initPanel.Controls.Add(clientDone);
            initPanel.Controls.Add(diagDone);
            initPanel.Controls.Add(initDone);
            initPanel.Controls.Add(waitingClientLabel);
            initPanel.Controls.Add(waitingConnectLabel);
            initPanel.Controls.Add(initLabel);
            initPanel.Controls.Add(diagLabel);
            initPanel.Controls.Add(enviroLabel);
            initPanel.Location = new Point(110, 0);
            initPanel.Name = "initPanel";
            initPanel.Size = new Size(1802, 1042);
            initPanel.TabIndex = 65;
            // 
            // enviroDone
            // 
            enviroDone.Font = new Font("Oxanium", 21.75F);
            enviroDone.ForeColor = Color.FromArgb(192, 64, 0);
            enviroDone.Location = new Point(1113, 385);
            enviroDone.Name = "enviroDone";
            enviroDone.Size = new Size(84, 36);
            enviroDone.TabIndex = 73;
            enviroDone.Text = "done";
            enviroDone.Visible = false;
            // 
            // uplinkDone
            // 
            uplinkDone.Font = new Font("Oxanium", 21.75F);
            uplinkDone.ForeColor = Color.FromArgb(192, 64, 0);
            uplinkDone.Location = new Point(1113, 421);
            uplinkDone.Name = "uplinkDone";
            uplinkDone.Size = new Size(84, 36);
            uplinkDone.TabIndex = 72;
            uplinkDone.Text = "done";
            uplinkDone.Visible = false;
            // 
            // clientDone
            // 
            clientDone.Font = new Font("Oxanium", 21.75F);
            clientDone.ForeColor = Color.FromArgb(192, 64, 0);
            clientDone.Location = new Point(1113, 460);
            clientDone.Name = "clientDone";
            clientDone.Size = new Size(84, 36);
            clientDone.TabIndex = 74;
            clientDone.Text = "done";
            clientDone.Visible = false;
            // 
            // diagDone
            // 
            diagDone.Font = new Font("Oxanium", 21.75F);
            diagDone.ForeColor = Color.FromArgb(192, 64, 0);
            diagDone.Location = new Point(1113, 349);
            diagDone.Name = "diagDone";
            diagDone.Size = new Size(84, 36);
            diagDone.TabIndex = 71;
            diagDone.Text = "done";
            diagDone.Visible = false;
            // 
            // initDone
            // 
            initDone.Font = new Font("Oxanium", 21.75F);
            initDone.ForeColor = Color.FromArgb(192, 64, 0);
            initDone.Location = new Point(1113, 313);
            initDone.Name = "initDone";
            initDone.Size = new Size(84, 36);
            initDone.TabIndex = 70;
            initDone.Text = "done";
            initDone.Visible = false;
            // 
            // waitingClientLabel
            // 
            waitingClientLabel.Font = new Font("Oxanium", 21.75F);
            waitingClientLabel.ForeColor = Color.FromArgb(192, 64, 0);
            waitingClientLabel.Location = new Point(623, 460);
            waitingClientLabel.Name = "waitingClientLabel";
            waitingClientLabel.Size = new Size(414, 36);
            waitingClientLabel.TabIndex = 69;
            waitingClientLabel.Text = "waiting for client response.";
            waitingClientLabel.Visible = false;
            // 
            // waitingConnectLabel
            // 
            waitingConnectLabel.Font = new Font("Oxanium", 21.75F);
            waitingConnectLabel.ForeColor = Color.FromArgb(192, 64, 0);
            waitingConnectLabel.Location = new Point(623, 421);
            waitingConnectLabel.Name = "waitingConnectLabel";
            waitingConnectLabel.Size = new Size(463, 36);
            waitingConnectLabel.TabIndex = 65;
            waitingConnectLabel.Text = "establishing uplink connection.";
            waitingConnectLabel.Visible = false;
            // 
            // initLabel
            // 
            initLabel.Font = new Font("Oxanium", 21.75F);
            initLabel.ForeColor = Color.FromArgb(192, 64, 0);
            initLabel.Location = new Point(623, 313);
            initLabel.Name = "initLabel";
            initLabel.Size = new Size(442, 36);
            initLabel.TabIndex = 66;
            initLabel.Text = "initiating service...                                ";
            // 
            // diagLabel
            // 
            diagLabel.Font = new Font("Oxanium", 21.75F);
            diagLabel.ForeColor = Color.FromArgb(192, 64, 0);
            diagLabel.Location = new Point(623, 349);
            diagLabel.Name = "diagLabel";
            diagLabel.Size = new Size(477, 36);
            diagLabel.TabIndex = 67;
            diagLabel.Text = "performing diagnostics...                   ";
            diagLabel.Visible = false;
            // 
            // enviroLabel
            // 
            enviroLabel.Font = new Font("Oxanium", 21.75F);
            enviroLabel.ForeColor = Color.FromArgb(192, 64, 0);
            enviroLabel.Location = new Point(623, 385);
            enviroLabel.Name = "enviroLabel";
            enviroLabel.Size = new Size(442, 36);
            enviroLabel.TabIndex = 68;
            enviroLabel.Text = "running environmental check...        ";
            enviroLabel.Visible = false;
            // 
            // homePanel
            // 
            homePanel.BackColor = SystemColors.ActiveCaptionText;
            homePanel.Controls.Add(homeARLabel);
            homePanel.Controls.Add(homeARTag);
            homePanel.Controls.Add(homeMRLabel);
            homePanel.Controls.Add(homeMRTag);
            homePanel.Controls.Add(homeEXRLabel);
            homePanel.Controls.Add(homeEXRTag);
            homePanel.Controls.Add(homeERLabel);
            homePanel.Controls.Add(homeERTag);
            homePanel.Controls.Add(homeTRLabel);
            homePanel.Controls.Add(homeLSTag);
            homePanel.Controls.Add(homeLSLabel);
            homePanel.Controls.Add(homeLBTag);
            homePanel.Controls.Add(homeSysTag);
            homePanel.Controls.Add(homeCRLabel);
            homePanel.Controls.Add(homeCRTag);
            homePanel.Controls.Add(creditBalanceLabel);
            homePanel.Controls.Add(homeSysLabel);
            homePanel.Controls.Add(homeCredBalanceTag);
            homePanel.Controls.Add(homeTRTag);
            homePanel.Controls.Add(homeLBLabel);
            homePanel.Controls.Add(curShipFuelTag);
            homePanel.Controls.Add(curShipIDTag);
            homePanel.Controls.Add(curShipDesTag);
            homePanel.Controls.Add(curShipTag);
            homePanel.Controls.Add(shipFuelLabel);
            homePanel.Controls.Add(shipIDLabel);
            homePanel.Controls.Add(linkLabel);
            homePanel.Controls.Add(shipNameLabel);
            homePanel.Controls.Add(shipLabel);
            homePanel.Controls.Add(starDTTag);
            homePanel.Controls.Add(waitingSTTag);
            homePanel.Controls.Add(starDTLabel);
            homePanel.Controls.Add(locDTTag);
            homePanel.Controls.Add(welcomeLabel);
            homePanel.Controls.Add(locDTLabel);
            homePanel.Location = new Point(114, 12);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(1798, 1031);
            homePanel.TabIndex = 63;
            // 
            // homeARLabel
            // 
            homeARLabel.AutoSize = true;
            homeARLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeARLabel.ForeColor = SystemColors.Control;
            homeARLabel.Location = new Point(4, 628);
            homeARLabel.Name = "homeARLabel";
            homeARLabel.Size = new Size(270, 50);
            homeARLabel.TabIndex = 99;
            homeARLabel.Text = "Arena Rank : ";
            // 
            // homeARTag
            // 
            homeARTag.AutoSize = true;
            homeARTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeARTag.ForeColor = Color.FromArgb(192, 64, 0);
            homeARTag.Location = new Point(388, 628);
            homeARTag.Name = "homeARTag";
            homeARTag.Size = new Size(237, 50);
            homeARTag.TabIndex = 98;
            homeARTag.Text = "arena_rank";
            // 
            // homeMRLabel
            // 
            homeMRLabel.AutoSize = true;
            homeMRLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeMRLabel.ForeColor = SystemColors.Control;
            homeMRLabel.Location = new Point(4, 578);
            homeMRLabel.Name = "homeMRLabel";
            homeMRLabel.Size = new Size(361, 50);
            homeMRLabel.TabIndex = 97;
            homeMRLabel.Text = "Mercenary Rank : ";
            // 
            // homeMRTag
            // 
            homeMRTag.AutoSize = true;
            homeMRTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeMRTag.ForeColor = Color.FromArgb(192, 64, 0);
            homeMRTag.Location = new Point(388, 578);
            homeMRTag.Name = "homeMRTag";
            homeMRTag.Size = new Size(226, 50);
            homeMRTag.TabIndex = 96;
            homeMRTag.Text = "merc_rank";
            // 
            // homeEXRLabel
            // 
            homeEXRLabel.AutoSize = true;
            homeEXRLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeEXRLabel.ForeColor = SystemColors.Control;
            homeEXRLabel.Location = new Point(4, 678);
            homeEXRLabel.Name = "homeEXRLabel";
            homeEXRLabel.Size = new Size(370, 50);
            homeEXRLabel.TabIndex = 95;
            homeEXRLabel.Text = "ExoBiology Rank : ";
            // 
            // homeEXRTag
            // 
            homeEXRTag.AutoSize = true;
            homeEXRTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeEXRTag.ForeColor = Color.FromArgb(192, 64, 0);
            homeEXRTag.Location = new Point(388, 678);
            homeEXRTag.Name = "homeEXRTag";
            homeEXRTag.Size = new Size(258, 50);
            homeEXRTag.TabIndex = 94;
            homeEXRTag.Text = "exobio_rank";
            // 
            // homeERLabel
            // 
            homeERLabel.AutoSize = true;
            homeERLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeERLabel.ForeColor = SystemColors.Control;
            homeERLabel.Location = new Point(4, 778);
            homeERLabel.Name = "homeERLabel";
            homeERLabel.Size = new Size(378, 50);
            homeERLabel.TabIndex = 93;
            homeERLabel.Text = "Exploration Rank : ";
            // 
            // homeERTag
            // 
            homeERTag.AutoSize = true;
            homeERTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeERTag.ForeColor = Color.FromArgb(192, 64, 0);
            homeERTag.Location = new Point(388, 778);
            homeERTag.Name = "homeERTag";
            homeERTag.Size = new Size(288, 50);
            homeERTag.TabIndex = 92;
            homeERTag.Text = "explorer_rank";
            // 
            // homeTRLabel
            // 
            homeTRLabel.AutoSize = true;
            homeTRLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeTRLabel.ForeColor = SystemColors.Control;
            homeTRLabel.Location = new Point(4, 728);
            homeTRLabel.Name = "homeTRLabel";
            homeTRLabel.Size = new Size(266, 50);
            homeTRLabel.TabIndex = 91;
            homeTRLabel.Text = "Trade Rank : ";
            // 
            // homeLSTag
            // 
            homeLSTag.AutoSize = true;
            homeLSTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeLSTag.ForeColor = Color.FromArgb(192, 64, 0);
            homeLSTag.Location = new Point(299, 432);
            homeLSTag.Name = "homeLSTag";
            homeLSTag.Size = new Size(257, 50);
            homeLSTag.TabIndex = 90;
            homeLSTag.Text = "legal_status";
            // 
            // homeLSLabel
            // 
            homeLSLabel.AutoSize = true;
            homeLSLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeLSLabel.ForeColor = SystemColors.Control;
            homeLSLabel.Location = new Point(4, 432);
            homeLSLabel.Name = "homeLSLabel";
            homeLSLabel.Size = new Size(289, 50);
            homeLSLabel.TabIndex = 89;
            homeLSLabel.Text = "Legal Status : ";
            // 
            // homeLBTag
            // 
            homeLBTag.AutoSize = true;
            homeLBTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeLBTag.ForeColor = Color.FromArgb(192, 64, 0);
            homeLBTag.Location = new Point(334, 928);
            homeLBTag.Name = "homeLBTag";
            homeLBTag.Size = new Size(275, 50);
            homeLBTag.TabIndex = 88;
            homeLBTag.Text = "loan_balance";
            // 
            // homeSysTag
            // 
            homeSysTag.AutoSize = true;
            homeSysTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeSysTag.ForeColor = Color.FromArgb(192, 64, 0);
            homeSysTag.Location = new Point(299, 382);
            homeSysTag.Name = "homeSysTag";
            homeSysTag.Size = new Size(288, 50);
            homeSysTag.TabIndex = 86;
            homeSysTag.Text = "system_name";
            // 
            // homeCRLabel
            // 
            homeCRLabel.AutoSize = true;
            homeCRLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeCRLabel.ForeColor = SystemColors.Control;
            homeCRLabel.Location = new Point(4, 532);
            homeCRLabel.Name = "homeCRLabel";
            homeCRLabel.Size = new Size(306, 50);
            homeCRLabel.TabIndex = 85;
            homeCRLabel.Text = "Combat Rank : ";
            // 
            // homeCRTag
            // 
            homeCRTag.AutoSize = true;
            homeCRTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeCRTag.ForeColor = Color.FromArgb(192, 64, 0);
            homeCRTag.Location = new Point(388, 528);
            homeCRTag.Name = "homeCRTag";
            homeCRTag.Size = new Size(274, 50);
            homeCRTag.TabIndex = 84;
            homeCRTag.Text = "combat_rank";
            // 
            // creditBalanceLabel
            // 
            creditBalanceLabel.AutoSize = true;
            creditBalanceLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            creditBalanceLabel.ForeColor = SystemColors.Control;
            creditBalanceLabel.Location = new Point(4, 881);
            creditBalanceLabel.Name = "creditBalanceLabel";
            creditBalanceLabel.Size = new Size(329, 50);
            creditBalanceLabel.TabIndex = 83;
            creditBalanceLabel.Text = "Credit Balance : ";
            // 
            // homeSysLabel
            // 
            homeSysLabel.AutoSize = true;
            homeSysLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeSysLabel.ForeColor = SystemColors.Control;
            homeSysLabel.Location = new Point(4, 382);
            homeSysLabel.Name = "homeSysLabel";
            homeSysLabel.Size = new Size(306, 50);
            homeSysLabel.TabIndex = 81;
            homeSysLabel.Text = "Local System : ";
            // 
            // homeCredBalanceTag
            // 
            homeCredBalanceTag.AutoSize = true;
            homeCredBalanceTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeCredBalanceTag.ForeColor = Color.FromArgb(192, 64, 0);
            homeCredBalanceTag.Location = new Point(334, 878);
            homeCredBalanceTag.Name = "homeCredBalanceTag";
            homeCredBalanceTag.Size = new Size(305, 50);
            homeCredBalanceTag.TabIndex = 80;
            homeCredBalanceTag.Text = "credit_balance";
            // 
            // homeTRTag
            // 
            homeTRTag.AutoSize = true;
            homeTRTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeTRTag.ForeColor = Color.FromArgb(192, 64, 0);
            homeTRTag.Location = new Point(388, 728);
            homeTRTag.Name = "homeTRTag";
            homeTRTag.Size = new Size(232, 50);
            homeTRTag.TabIndex = 78;
            homeTRTag.Text = "trade_rank";
            // 
            // homeLBLabel
            // 
            homeLBLabel.AutoSize = true;
            homeLBLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            homeLBLabel.ForeColor = SystemColors.Control;
            homeLBLabel.Location = new Point(4, 928);
            homeLBLabel.Name = "homeLBLabel";
            homeLBLabel.Size = new Size(305, 50);
            homeLBLabel.TabIndex = 77;
            homeLBLabel.Text = "Loan Balance : ";
            // 
            // curShipFuelTag
            // 
            curShipFuelTag.AutoSize = true;
            curShipFuelTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            curShipFuelTag.ForeColor = Color.FromArgb(192, 64, 0);
            curShipFuelTag.Location = new Point(299, 332);
            curShipFuelTag.Name = "curShipFuelTag";
            curShipFuelTag.Size = new Size(212, 50);
            curShipFuelTag.TabIndex = 76;
            curShipFuelTag.Text = "fuel_level";
            // 
            // curShipIDTag
            // 
            curShipIDTag.AutoSize = true;
            curShipIDTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            curShipIDTag.ForeColor = Color.FromArgb(192, 64, 0);
            curShipIDTag.Location = new Point(299, 282);
            curShipIDTag.Name = "curShipIDTag";
            curShipIDTag.Size = new Size(159, 50);
            curShipIDTag.TabIndex = 75;
            curShipIDTag.Text = "ship_id";
            // 
            // curShipDesTag
            // 
            curShipDesTag.AutoSize = true;
            curShipDesTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            curShipDesTag.ForeColor = Color.FromArgb(192, 64, 0);
            curShipDesTag.Location = new Point(299, 232);
            curShipDesTag.Name = "curShipDesTag";
            curShipDesTag.Size = new Size(229, 50);
            curShipDesTag.TabIndex = 74;
            curShipDesTag.Text = "ship_name";
            curShipDesTag.TextAlign = ContentAlignment.TopRight;
            // 
            // curShipTag
            // 
            curShipTag.AutoSize = true;
            curShipTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            curShipTag.ForeColor = Color.FromArgb(192, 64, 0);
            curShipTag.Location = new Point(299, 178);
            curShipTag.Name = "curShipTag";
            curShipTag.Size = new Size(210, 50);
            curShipTag.TabIndex = 73;
            curShipTag.Text = "ship_type";
            // 
            // shipFuelLabel
            // 
            shipFuelLabel.AutoSize = true;
            shipFuelLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            shipFuelLabel.ForeColor = SystemColors.Control;
            shipFuelLabel.Location = new Point(4, 332);
            shipFuelLabel.Name = "shipFuelLabel";
            shipFuelLabel.Size = new Size(247, 50);
            shipFuelLabel.TabIndex = 72;
            shipFuelLabel.Text = "Fuel Level  :";
            // 
            // shipIDLabel
            // 
            shipIDLabel.AutoSize = true;
            shipIDLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            shipIDLabel.ForeColor = SystemColors.Control;
            shipIDLabel.Location = new Point(4, 282);
            shipIDLabel.Name = "shipIDLabel";
            shipIDLabel.Size = new Size(93, 50);
            shipIDLabel.TabIndex = 71;
            shipIDLabel.Text = "ID  :";
            // 
            // linkLabel
            // 
            linkLabel.AutoSize = true;
            linkLabel.Font = new Font("Oxanium", 21.75F);
            linkLabel.ForeColor = Color.FromArgb(192, 64, 0);
            linkLabel.Location = new Point(698, 98);
            linkLabel.Name = "linkLabel";
            linkLabel.Size = new Size(307, 36);
            linkLabel.TabIndex = 70;
            linkLabel.Text = "uplink intergrity : high";
            // 
            // shipNameLabel
            // 
            shipNameLabel.AutoSize = true;
            shipNameLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            shipNameLabel.ForeColor = SystemColors.Control;
            shipNameLabel.Location = new Point(4, 232);
            shipNameLabel.Name = "shipNameLabel";
            shipNameLabel.Size = new Size(280, 50);
            shipNameLabel.TabIndex = 68;
            shipNameLabel.Text = "Designation  :";
            shipNameLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // shipLabel
            // 
            shipLabel.AutoSize = true;
            shipLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            shipLabel.ForeColor = SystemColors.Control;
            shipLabel.Location = new Point(4, 178);
            shipLabel.Name = "shipLabel";
            shipLabel.Size = new Size(291, 50);
            shipLabel.TabIndex = 67;
            shipLabel.Text = "Current Ship  :";
            // 
            // starDTTag
            // 
            starDTTag.Font = new Font("Oxanium", 21.75F);
            starDTTag.ForeColor = Color.FromArgb(192, 64, 0);
            starDTTag.Location = new Point(1414, 42);
            starDTTag.Name = "starDTTag";
            starDTTag.Size = new Size(381, 72);
            starDTTag.TabIndex = 66;
            starDTTag.Text = "Tuesday, August 18th 3312\r\n2:45\r\n";
            starDTTag.TextAlign = ContentAlignment.MiddleRight;
            starDTTag.Visible = false;
            starDTTag.TextChanged += starDTTag_TextChanged;
            // 
            // waitingSTTag
            // 
            waitingSTTag.AutoSize = true;
            waitingSTTag.Font = new Font("Oxanium", 21.75F);
            waitingSTTag.ForeColor = Color.FromArgb(192, 64, 0);
            waitingSTTag.Location = new Point(1451, 56);
            waitingSTTag.Name = "waitingSTTag";
            waitingSTTag.Size = new Size(343, 36);
            waitingSTTag.TabIndex = 64;
            waitingSTTag.Text = "Waiting for connection...";
            waitingSTTag.TextAlign = ContentAlignment.TopRight;
            // 
            // starDTLabel
            // 
            starDTLabel.AutoSize = true;
            starDTLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            starDTLabel.ForeColor = SystemColors.Control;
            starDTLabel.Location = new Point(1463, -12);
            starDTLabel.Name = "starDTLabel";
            starDTLabel.Size = new Size(332, 50);
            starDTLabel.TabIndex = 63;
            starDTLabel.Text = "Star Date / Time";
            starDTLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // locDTTag
            // 
            locDTTag.AutoSize = true;
            locDTTag.Font = new Font("Oxanium", 21.75F);
            locDTTag.ForeColor = Color.FromArgb(192, 64, 0);
            locDTTag.Location = new Point(4, 42);
            locDTTag.Name = "locDTTag";
            locDTTag.Size = new Size(189, 72);
            locDTTag.TabIndex = 62;
            locDTTag.Text = "Waiting for\r\nconnection...\r\n";
            // 
            // welcomeLabel
            // 
            welcomeLabel.Anchor = AnchorStyles.Top;
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeLabel.ForeColor = Color.White;
            welcomeLabel.Location = new Point(623, 0);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(459, 50);
            welcomeLabel.TabIndex = 61;
            welcomeLabel.Text = "Welcome, Commander ";
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            welcomeLabel.TextChanged += welcomeLabel_TextChanged;
            // 
            // locDTLabel
            // 
            locDTLabel.AutoSize = true;
            locDTLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            locDTLabel.ForeColor = SystemColors.Control;
            locDTLabel.Location = new Point(4, -12);
            locDTLabel.Name = "locDTLabel";
            locDTLabel.Size = new Size(354, 50);
            locDTLabel.TabIndex = 55;
            locDTLabel.Text = "Local Date / Time";
            // 
            // explorePanel
            // 
            explorePanel.Controls.Add(exploreLinkLabel);
            explorePanel.Controls.Add(exploreStarDTTag);
            explorePanel.Controls.Add(exploreStarDTLabel);
            explorePanel.Controls.Add(exploreLocDTTag);
            explorePanel.Controls.Add(exploreLocDTLabel);
            explorePanel.Controls.Add(label27);
            explorePanel.Controls.Add(label28);
            explorePanel.Controls.Add(label29);
            explorePanel.Controls.Add(label30);
            explorePanel.Controls.Add(label31);
            explorePanel.Controls.Add(label32);
            explorePanel.Controls.Add(label33);
            explorePanel.Controls.Add(label34);
            explorePanel.Controls.Add(label35);
            explorePanel.Controls.Add(label36);
            explorePanel.Controls.Add(label37);
            explorePanel.Controls.Add(label38);
            explorePanel.Controls.Add(label39);
            explorePanel.Controls.Add(label40);
            explorePanel.Controls.Add(label41);
            explorePanel.Controls.Add(label42);
            explorePanel.Controls.Add(label43);
            explorePanel.Controls.Add(label44);
            explorePanel.Controls.Add(label45);
            explorePanel.Controls.Add(label46);
            explorePanel.Location = new Point(114, 12);
            explorePanel.Name = "explorePanel";
            explorePanel.Size = new Size(1798, 1031);
            explorePanel.TabIndex = 63;
            // 
            // exploreLinkLabel
            // 
            exploreLinkLabel.AutoSize = true;
            exploreLinkLabel.Font = new Font("Oxanium", 21.75F);
            exploreLinkLabel.ForeColor = Color.FromArgb(192, 64, 0);
            exploreLinkLabel.Location = new Point(698, 98);
            exploreLinkLabel.Name = "exploreLinkLabel";
            exploreLinkLabel.Size = new Size(307, 36);
            exploreLinkLabel.TabIndex = 75;
            exploreLinkLabel.Text = "uplink intergrity : high";
            // 
            // exploreStarDTTag
            // 
            exploreStarDTTag.Font = new Font("Oxanium", 21.75F);
            exploreStarDTTag.ForeColor = Color.FromArgb(192, 64, 0);
            exploreStarDTTag.Location = new Point(1414, 42);
            exploreStarDTTag.Name = "exploreStarDTTag";
            exploreStarDTTag.Size = new Size(381, 72);
            exploreStarDTTag.TabIndex = 74;
            exploreStarDTTag.Text = "Tuesday, August 18th 3312\r\n2:45\r\n";
            exploreStarDTTag.TextAlign = ContentAlignment.MiddleRight;
            // 
            // exploreStarDTLabel
            // 
            exploreStarDTLabel.AutoSize = true;
            exploreStarDTLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            exploreStarDTLabel.ForeColor = SystemColors.Control;
            exploreStarDTLabel.Location = new Point(1463, -12);
            exploreStarDTLabel.Name = "exploreStarDTLabel";
            exploreStarDTLabel.Size = new Size(332, 50);
            exploreStarDTLabel.TabIndex = 73;
            exploreStarDTLabel.Text = "Star Date / Time";
            exploreStarDTLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // exploreLocDTTag
            // 
            exploreLocDTTag.AutoSize = true;
            exploreLocDTTag.Font = new Font("Oxanium", 21.75F);
            exploreLocDTTag.ForeColor = Color.FromArgb(192, 64, 0);
            exploreLocDTTag.Location = new Point(4, 42);
            exploreLocDTTag.Name = "exploreLocDTTag";
            exploreLocDTTag.Size = new Size(189, 72);
            exploreLocDTTag.TabIndex = 72;
            exploreLocDTTag.Text = "Waiting for\r\nconnection...\r\n";
            // 
            // exploreLocDTLabel
            // 
            exploreLocDTLabel.AutoSize = true;
            exploreLocDTLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            exploreLocDTLabel.ForeColor = SystemColors.Control;
            exploreLocDTLabel.Location = new Point(4, -12);
            exploreLocDTLabel.Name = "exploreLocDTLabel";
            exploreLocDTLabel.Size = new Size(354, 50);
            exploreLocDTLabel.TabIndex = 71;
            exploreLocDTLabel.Text = "Local Date / Time";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label27.ForeColor = SystemColors.Control;
            label27.Location = new Point(139, 388);
            label27.Name = "label27";
            label27.Size = new Size(94, 50);
            label27.TabIndex = 60;
            label27.Text = "N/A";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label28.ForeColor = SystemColors.Control;
            label28.Location = new Point(183, 442);
            label28.Name = "label28";
            label28.Size = new Size(94, 50);
            label28.TabIndex = 59;
            label28.Text = "N/A";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label29.ForeColor = SystemColors.Control;
            label29.Location = new Point(139, 496);
            label29.Name = "label29";
            label29.Size = new Size(94, 50);
            label29.TabIndex = 58;
            label29.Text = "N/A";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label30.ForeColor = SystemColors.Control;
            label30.Location = new Point(183, 178);
            label30.Name = "label30";
            label30.Size = new Size(94, 50);
            label30.TabIndex = 57;
            label30.Text = "N/A";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label31.ForeColor = SystemColors.Control;
            label31.Location = new Point(156, 232);
            label31.Name = "label31";
            label31.Size = new Size(94, 50);
            label31.TabIndex = 56;
            label31.Text = "N/A";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label32.ForeColor = SystemColors.Control;
            label32.Location = new Point(738, 178);
            label32.Name = "label32";
            label32.Size = new Size(94, 50);
            label32.TabIndex = 55;
            label32.Text = "N/A";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label33.ForeColor = SystemColors.Control;
            label33.Location = new Point(756, 232);
            label33.Name = "label33";
            label33.Size = new Size(94, 50);
            label33.TabIndex = 54;
            label33.Text = "N/A";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label34.ForeColor = SystemColors.Control;
            label34.Location = new Point(915, 340);
            label34.Name = "label34";
            label34.Size = new Size(94, 50);
            label34.TabIndex = 53;
            label34.Text = "N/A";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label35.ForeColor = Color.FromArgb(192, 64, 0);
            label35.Location = new Point(558, 340);
            label35.Name = "label35";
            label35.Size = new Size(353, 50);
            label35.TabIndex = 52;
            label35.Text = "Galactic Bounty : ";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label36.ForeColor = SystemColors.Control;
            label36.Location = new Point(863, 286);
            label36.Name = "label36";
            label36.Size = new Size(94, 50);
            label36.TabIndex = 51;
            label36.Text = "N/A";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label37.ForeColor = SystemColors.Control;
            label37.Location = new Point(290, 286);
            label37.Name = "label37";
            label37.Size = new Size(94, 50);
            label37.TabIndex = 50;
            label37.Text = "N/A";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label38.ForeColor = Color.FromArgb(192, 64, 0);
            label38.Location = new Point(0, 394);
            label38.Name = "label38";
            label38.Size = new Size(136, 50);
            label38.TabIndex = 49;
            label38.Text = "Ship : ";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label39.ForeColor = Color.FromArgb(192, 64, 0);
            label39.Location = new Point(0, 286);
            label39.Name = "label39";
            label39.Size = new Size(289, 50);
            label39.TabIndex = 48;
            label39.Text = "Legal Status : ";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label40.ForeColor = Color.FromArgb(192, 64, 0);
            label40.Location = new Point(0, 232);
            label40.Name = "label40";
            label40.Size = new Size(148, 50);
            label40.TabIndex = 47;
            label40.Text = "Rank : ";
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label41.ForeColor = Color.FromArgb(192, 64, 0);
            label41.Location = new Point(558, 232);
            label41.Name = "label41";
            label41.Size = new Size(194, 50);
            label41.TabIndex = 46;
            label41.Text = "Faction : ";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label42.ForeColor = Color.FromArgb(192, 64, 0);
            label42.Location = new Point(558, 286);
            label42.Name = "label42";
            label42.Size = new Size(301, 50);
            label42.TabIndex = 45;
            label42.Text = "Local Bounty : ";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label43.ForeColor = Color.FromArgb(192, 64, 0);
            label43.Location = new Point(0, 502);
            label43.Name = "label43";
            label43.Size = new Size(129, 50);
            label43.TabIndex = 44;
            label43.Text = "Hull : ";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label44.ForeColor = Color.FromArgb(192, 64, 0);
            label44.Location = new Point(558, 178);
            label44.Name = "label44";
            label44.Size = new Size(175, 50);
            label44.TabIndex = 43;
            label44.Text = "Power : ";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label45.ForeColor = Color.FromArgb(192, 64, 0);
            label45.Location = new Point(0, 448);
            label45.Name = "label45";
            label45.Size = new Size(191, 50);
            label45.TabIndex = 42;
            label45.Text = "Shields : ";
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            label46.ForeColor = Color.FromArgb(192, 64, 0);
            label46.Location = new Point(0, 178);
            label46.Name = "label46";
            label46.Size = new Size(176, 50);
            label46.TabIndex = 41;
            label46.Text = "Target : ";
            // 
            // dividerPanel
            // 
            dividerPanel.BackColor = Color.FromArgb(192, 64, 0);
            dividerPanel.Location = new Point(110, 0);
            dividerPanel.Name = "dividerPanel";
            dividerPanel.Size = new Size(2, 1076);
            dividerPanel.TabIndex = 66;
            // 
            // exitButton
            // 
            exitButton.BackColor = SystemColors.ActiveCaptionText;
            exitButton.FlatStyle = FlatStyle.Popup;
            exitButton.Font = new Font("Oxanium ExtraBold", 9F, FontStyle.Bold);
            exitButton.ForeColor = Color.FromArgb(192, 64, 0);
            exitButton.Location = new Point(12, 1045);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(92, 23);
            exitButton.TabIndex = 67;
            exitButton.Text = "Terminate";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // statusPanel
            // 
            statusPanel.BackColor = SystemColors.ControlText;
            statusPanel.Controls.Add(verLabel);
            statusPanel.Controls.Add(statusLabel);
            statusPanel.Location = new Point(118, 1045);
            statusPanel.Name = "statusPanel";
            statusPanel.Size = new Size(1794, 32);
            statusPanel.TabIndex = 69;
            // 
            // verLabel
            // 
            verLabel.AutoSize = true;
            verLabel.BackColor = Color.Black;
            verLabel.Font = new Font("Oxanium", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            verLabel.ForeColor = Color.FromArgb(192, 64, 0);
            verLabel.Location = new Point(1710, 16);
            verLabel.Name = "verLabel";
            verLabel.Size = new Size(77, 15);
            verLabel.TabIndex = 1;
            verLabel.Text = "version 0.1.6";
            verLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.BackColor = Color.Black;
            statusLabel.Dock = DockStyle.Right;
            statusLabel.Font = new Font("Oxanium", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusLabel.ForeColor = Color.FromArgb(192, 64, 0);
            statusLabel.Location = new Point(1744, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(50, 15);
            statusLabel.TabIndex = 0;
            statusLabel.Text = "Status :";
            statusLabel.TextAlign = ContentAlignment.MiddleRight;
            statusLabel.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1920, 1080);
            Controls.Add(initPanel);
            Controls.Add(explorePanel);
            Controls.Add(combatPanel);
            Controls.Add(statusPanel);
            Controls.Add(homePanel);
            Controls.Add(exitButton);
            Controls.Add(dividerPanel);
            Controls.Add(settingsButton);
            Controls.Add(restartSessionButton);
            Controls.Add(homeButton);
            Controls.Add(explorationButton);
            Controls.Add(combatButton);
            Controls.Add(simulateButton);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.Manual;
            Text = "E:D Hud Extension";
            Load += MainForm_Load;
            combatPanel.ResumeLayout(false);
            combatPanel.PerformLayout();
            initPanel.ResumeLayout(false);
            homePanel.ResumeLayout(false);
            homePanel.PerformLayout();
            explorePanel.ResumeLayout(false);
            explorePanel.PerformLayout();
            statusPanel.ResumeLayout(false);
            statusPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button restartSessionButton;
        private Panel combatPanel;
        private Label targetShipTag;
        private Label targetShieldTag;
        private Label targetHullTag;
        private Label targetTag;
        private Label targetRankTag;
        private Label label2;
        private Label label1;
        private Label targetExtendBountyTag;
        private Label targetExtendedBountyLabel;
        private Label targetLocalBountyTag;
        private Label targetLegalStatusTag;
        private Label targetShipLabel;
        private Label targetLegalStatusLabel;
        private Label targetRankLabel;
        private Label targetFactionLabel;
        private Label targetLocalBounty;
        private Label targetHullLabel;
        private Label targetPowerLabel;
        private Label targetShieldsLabel;
        private Label targetNameLabel;
        private Label combatLabel;
        private Button simulateButton;
        private Button settingsButton;
        private Button combatButton;
        private Button explorationButton;
        private Button homeButton;
        private Panel initPanel;
        private Panel homePanel;
        private Label welcomeLabel;
        private Label locDTLabel;
        private Panel explorePanel;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label waitingSTTag;
        private Label starDTLabel;
        private Label locDTTag;
        public Label waitingConnectLabel;
        private Panel dividerPanel;
        private Button exitButton;
        private Label starDTTag;
        private EliteJournalReader.JournalWatcher journalWatcher;
        private Label shipNameLabel;
        private Label shipLabel;
        public Label initLabel;
        public Label diagLabel;
        public Label enviroLabel;
        private Label linkLabel;
        private Panel statusPanel;
        private Label statusLabel;
        public Label waitingClientLabel;
        private Label shipFuelLabel;
        private Label shipIDLabel;
        private Label curShipFuelTag;
        private Label curShipIDTag;
        private Label curShipDesTag;
        private Label curShipTag;
        private Label verLabel;
        private Label combatLinkLabel;
        private Label combatTag;
        private Label combatStarDTTag;
        private Label combatStarDTLabel;
        private Label combatLocDTTag;
        private Label combatLocDTLabel;
        private Label homeLSTag;
        private Label homeLSLabel;
        private Label homeLBTag;
        private Label homeSysTag;
        private Label homeCRLabel;
        private Label homeCRTag;
        private Label creditBalanceLabel;
        private Label homeSysLabel;
        private Label homeCredBalanceTag;
        private Label homeTRTag;
        private Label homeLBLabel;
        public Label clientDone;
        public Label enviroDone;
        public Label uplinkDone;
        public Label diagDone;
        public Label initDone;
        private Label homeTRLabel;
        private Label homeARLabel;
        private Label homeARTag;
        private Label homeMRLabel;
        private Label homeMRTag;
        private Label homeEXRLabel;
        private Label homeEXRTag;
        private Label homeERLabel;
        private Label homeERTag;
        private Label exploreLinkLabel;
        private Label exploreStarDTTag;
        private Label exploreStarDTLabel;
        private Label exploreLocDTTag;
        private Label exploreLocDTLabel;
    }
}
