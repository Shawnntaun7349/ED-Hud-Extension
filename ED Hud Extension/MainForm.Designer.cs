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
        public void InitializeComponent()
        {
            restartSessionButton = new Button();
            combatPanel = new Panel();
            targetSSHTag = new Label();
            targetSSHealthLabel = new Label();
            targetSSTag = new Label();
            targetSubSystemLabel = new Label();
            combatPanelDivider = new Panel();
            targetDataLabel = new Label();
            scanStageTag = new Label();
            scanStageLabel = new Label();
            targetShipTag = new Label();
            targetShieldTag = new Label();
            targetHullTag = new Label();
            targetTag = new Label();
            targetRankTag = new Label();
            targetPowerTag = new Label();
            targetFactionTag = new Label();
            targetBountyTag = new Label();
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
            expNextSystemTag = new Label();
            expNextSystemLabel = new Label();
            expDestinationTag = new Label();
            expDestinationLabel = new Label();
            bodiesLabel = new Label();
            starsLabel = new Label();
            detailViewPanel = new Panel();
            label9 = new Label();
            bodiesDivPanel = new Panel();
            label10 = new Label();
            bodyListPanel = new Panel();
            bodyList = new ListView();
            label11 = new Label();
            label12 = new Label();
            fsdTag = new Label();
            fsdLabel = new Label();
            expCurrentSystemTag = new Label();
            expCurrentSystemLabel = new Label();
            dividerPanel = new Panel();
            exitButton = new Button();
            statusPanel = new Panel();
            verLabel = new Label();
            statusLabel = new Label();
            stationButton = new Button();
            combatPanel.SuspendLayout();
            initPanel.SuspendLayout();
            homePanel.SuspendLayout();
            explorePanel.SuspendLayout();
            bodyListPanel.SuspendLayout();
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
            combatPanel.Controls.Add(targetSSHTag);
            combatPanel.Controls.Add(targetSSHealthLabel);
            combatPanel.Controls.Add(targetSSTag);
            combatPanel.Controls.Add(targetSubSystemLabel);
            combatPanel.Controls.Add(combatPanelDivider);
            combatPanel.Controls.Add(targetDataLabel);
            combatPanel.Controls.Add(scanStageTag);
            combatPanel.Controls.Add(scanStageLabel);
            combatPanel.Controls.Add(targetShipTag);
            combatPanel.Controls.Add(targetShieldTag);
            combatPanel.Controls.Add(targetHullTag);
            combatPanel.Controls.Add(targetTag);
            combatPanel.Controls.Add(targetRankTag);
            combatPanel.Controls.Add(targetPowerTag);
            combatPanel.Controls.Add(targetFactionTag);
            combatPanel.Controls.Add(targetBountyTag);
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
            combatPanel.Location = new Point(110, 149);
            combatPanel.Name = "combatPanel";
            combatPanel.Size = new Size(1802, 894);
            combatPanel.TabIndex = 22;
            // 
            // targetSSHTag
            // 
            targetSSHTag.AutoSize = true;
            targetSSHTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetSSHTag.ForeColor = SystemColors.Control;
            targetSSHTag.Location = new Point(290, 676);
            targetSSHTag.Name = "targetSSHTag";
            targetSSHTag.Size = new Size(312, 50);
            targetSSHTag.TabIndex = 84;
            targetSSHTag.Tag = "combatTag";
            targetSSHTag.Text = "[awaiting scan]";
            // 
            // targetSSHealthLabel
            // 
            targetSSHealthLabel.AutoSize = true;
            targetSSHealthLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetSSHealthLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetSSHealthLabel.Location = new Point(0, 678);
            targetSSHealthLabel.Name = "targetSSHealthLabel";
            targetSSHealthLabel.Size = new Size(218, 50);
            targetSSHealthLabel.TabIndex = 83;
            targetSSHealthLabel.Text = "Integrity : ";
            // 
            // targetSSTag
            // 
            targetSSTag.AutoSize = true;
            targetSSTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetSSTag.ForeColor = SystemColors.Control;
            targetSSTag.Location = new Point(290, 626);
            targetSSTag.Name = "targetSSTag";
            targetSSTag.Size = new Size(312, 50);
            targetSSTag.TabIndex = 82;
            targetSSTag.Tag = "combatTag";
            targetSSTag.Text = "[awaiting scan]";
            // 
            // targetSubSystemLabel
            // 
            targetSubSystemLabel.AutoSize = true;
            targetSubSystemLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetSubSystemLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetSubSystemLabel.Location = new Point(0, 628);
            targetSubSystemLabel.Name = "targetSubSystemLabel";
            targetSubSystemLabel.Size = new Size(262, 50);
            targetSubSystemLabel.TabIndex = 81;
            targetSubSystemLabel.Text = "Sub-System:";
            // 
            // combatPanelDivider
            // 
            combatPanelDivider.BackColor = Color.FromArgb(192, 64, 0);
            combatPanelDivider.Location = new Point(-4, 241);
            combatPanelDivider.Margin = new Padding(0);
            combatPanelDivider.Name = "combatPanelDivider";
            combatPanelDivider.Size = new Size(1801, 2);
            combatPanelDivider.TabIndex = 80;
            // 
            // targetDataLabel
            // 
            targetDataLabel.AutoSize = true;
            targetDataLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetDataLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetDataLabel.Location = new Point(0, 179);
            targetDataLabel.Name = "targetDataLabel";
            targetDataLabel.Size = new Size(460, 50);
            targetDataLabel.TabIndex = 79;
            targetDataLabel.Text = "Target Data [Current] : ";
            // 
            // scanStageTag
            // 
            scanStageTag.AutoSize = true;
            scanStageTag.Font = new Font("Oxanium", 21.75F);
            scanStageTag.ForeColor = SystemColors.Control;
            scanStageTag.Location = new Point(887, -5);
            scanStageTag.Name = "scanStageTag";
            scanStageTag.Size = new Size(139, 36);
            scanStageTag.TabIndex = 78;
            scanStageTag.Text = "no target";
            // 
            // scanStageLabel
            // 
            scanStageLabel.AutoSize = true;
            scanStageLabel.Font = new Font("Oxanium", 21.75F);
            scanStageLabel.ForeColor = Color.FromArgb(192, 64, 0);
            scanStageLabel.Location = new Point(676, -5);
            scanStageLabel.Name = "scanStageLabel";
            scanStageLabel.Size = new Size(183, 36);
            scanStageLabel.TabIndex = 77;
            scanStageLabel.Text = "scan stage : ";
            // 
            // targetShipTag
            // 
            targetShipTag.AutoSize = true;
            targetShipTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetShipTag.ForeColor = SystemColors.Control;
            targetShipTag.Location = new Point(290, 464);
            targetShipTag.Name = "targetShipTag";
            targetShipTag.Size = new Size(312, 50);
            targetShipTag.TabIndex = 60;
            targetShipTag.Tag = "combatTag";
            targetShipTag.Text = "[awaiting scan]";
            // 
            // targetShieldTag
            // 
            targetShieldTag.AutoSize = true;
            targetShieldTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetShieldTag.ForeColor = SystemColors.Control;
            targetShieldTag.Location = new Point(290, 524);
            targetShieldTag.Name = "targetShieldTag";
            targetShieldTag.Size = new Size(312, 50);
            targetShieldTag.TabIndex = 59;
            targetShieldTag.Tag = "combatTag";
            targetShieldTag.Text = "[awaiting scan]";
            // 
            // targetHullTag
            // 
            targetHullTag.AutoSize = true;
            targetHullTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetHullTag.ForeColor = SystemColors.Control;
            targetHullTag.Location = new Point(290, 578);
            targetHullTag.Name = "targetHullTag";
            targetHullTag.Size = new Size(312, 50);
            targetHullTag.TabIndex = 58;
            targetHullTag.Tag = "combatTag";
            targetHullTag.Text = "[awaiting scan]";
            // 
            // targetTag
            // 
            targetTag.AutoSize = true;
            targetTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetTag.ForeColor = SystemColors.Control;
            targetTag.Location = new Point(290, 254);
            targetTag.Name = "targetTag";
            targetTag.Size = new Size(312, 50);
            targetTag.TabIndex = 57;
            targetTag.Tag = "combatTag";
            targetTag.Text = "[awaiting scan]";
            // 
            // targetRankTag
            // 
            targetRankTag.AutoSize = true;
            targetRankTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetRankTag.ForeColor = SystemColors.Control;
            targetRankTag.Location = new Point(290, 308);
            targetRankTag.Name = "targetRankTag";
            targetRankTag.Size = new Size(312, 50);
            targetRankTag.TabIndex = 56;
            targetRankTag.Tag = "combatTag";
            targetRankTag.Text = "[awaiting scan]";
            // 
            // targetPowerTag
            // 
            targetPowerTag.AutoSize = true;
            targetPowerTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetPowerTag.ForeColor = SystemColors.Control;
            targetPowerTag.Location = new Point(1017, 254);
            targetPowerTag.Name = "targetPowerTag";
            targetPowerTag.Size = new Size(312, 50);
            targetPowerTag.TabIndex = 55;
            targetPowerTag.Tag = "combatTag";
            targetPowerTag.Text = "[awaiting scan]";
            // 
            // targetFactionTag
            // 
            targetFactionTag.AutoSize = true;
            targetFactionTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetFactionTag.ForeColor = SystemColors.Control;
            targetFactionTag.Location = new Point(1017, 308);
            targetFactionTag.Name = "targetFactionTag";
            targetFactionTag.Size = new Size(312, 50);
            targetFactionTag.TabIndex = 54;
            targetFactionTag.Tag = "combatTag";
            targetFactionTag.Text = "[awaiting scan]";
            // 
            // targetBountyTag
            // 
            targetBountyTag.AutoSize = true;
            targetBountyTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetBountyTag.ForeColor = SystemColors.Control;
            targetBountyTag.Location = new Point(1017, 362);
            targetBountyTag.Name = "targetBountyTag";
            targetBountyTag.Size = new Size(123, 50);
            targetBountyTag.TabIndex = 51;
            targetBountyTag.Tag = "combatTag";
            targetBountyTag.Text = "None";
            // 
            // targetLegalStatusTag
            // 
            targetLegalStatusTag.AutoSize = true;
            targetLegalStatusTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetLegalStatusTag.ForeColor = SystemColors.Control;
            targetLegalStatusTag.Location = new Point(290, 364);
            targetLegalStatusTag.Name = "targetLegalStatusTag";
            targetLegalStatusTag.Size = new Size(312, 50);
            targetLegalStatusTag.TabIndex = 50;
            targetLegalStatusTag.Tag = "combatTag";
            targetLegalStatusTag.Text = "[awaiting scan]";
            // 
            // targetShipLabel
            // 
            targetShipLabel.AutoSize = true;
            targetShipLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetShipLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetShipLabel.Location = new Point(0, 472);
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
            targetLegalStatusLabel.Location = new Point(0, 364);
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
            targetRankLabel.Location = new Point(0, 310);
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
            targetFactionLabel.Location = new Point(812, 310);
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
            targetLocalBounty.Location = new Point(812, 364);
            targetLocalBounty.Name = "targetLocalBounty";
            targetLocalBounty.Size = new Size(190, 50);
            targetLocalBounty.TabIndex = 45;
            targetLocalBounty.Text = "Bounty : ";
            // 
            // targetHullLabel
            // 
            targetHullLabel.AutoSize = true;
            targetHullLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            targetHullLabel.ForeColor = Color.FromArgb(192, 64, 0);
            targetHullLabel.Location = new Point(0, 580);
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
            targetPowerLabel.Location = new Point(812, 256);
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
            targetShieldsLabel.Location = new Point(0, 526);
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
            targetNameLabel.Location = new Point(0, 256);
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
            homePanel.Location = new Point(110, 12);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(1802, 1031);
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
            linkLabel.Size = new Size(296, 36);
            linkLabel.TabIndex = 70;
            linkLabel.Tag = "uplinkLabel";
            linkLabel.Text = "uplink integrity : high";
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
            locDTTag.Location = new Point(0, 42);
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
            welcomeLabel.Location = new Point(625, 0);
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
            locDTLabel.Location = new Point(0, -12);
            locDTLabel.Name = "locDTLabel";
            locDTLabel.Size = new Size(354, 50);
            locDTLabel.TabIndex = 55;
            locDTLabel.Text = "Local Date / Time";
            // 
            // explorePanel
            // 
            explorePanel.Controls.Add(expNextSystemTag);
            explorePanel.Controls.Add(expNextSystemLabel);
            explorePanel.Controls.Add(expDestinationTag);
            explorePanel.Controls.Add(expDestinationLabel);
            explorePanel.Controls.Add(bodiesLabel);
            explorePanel.Controls.Add(starsLabel);
            explorePanel.Controls.Add(detailViewPanel);
            explorePanel.Controls.Add(label9);
            explorePanel.Controls.Add(bodiesDivPanel);
            explorePanel.Controls.Add(label10);
            explorePanel.Controls.Add(bodyListPanel);
            explorePanel.Controls.Add(label11);
            explorePanel.Controls.Add(label12);
            explorePanel.Controls.Add(fsdTag);
            explorePanel.Controls.Add(fsdLabel);
            explorePanel.Controls.Add(expCurrentSystemTag);
            explorePanel.Controls.Add(expCurrentSystemLabel);
            explorePanel.Location = new Point(110, 149);
            explorePanel.Name = "explorePanel";
            explorePanel.Size = new Size(1802, 894);
            explorePanel.TabIndex = 63;
            // 
            // expNextSystemTag
            // 
            expNextSystemTag.AutoSize = true;
            expNextSystemTag.Font = new Font("Oxanium", 21.75F);
            expNextSystemTag.ForeColor = SystemColors.Control;
            expNextSystemTag.Location = new Point(812, 67);
            expNextSystemTag.Name = "expNextSystemTag";
            expNextSystemTag.Size = new Size(91, 36);
            expNextSystemTag.TabIndex = 94;
            expNextSystemTag.Text = "ready";
            // 
            // expNextSystemLabel
            // 
            expNextSystemLabel.AutoSize = true;
            expNextSystemLabel.Font = new Font("Oxanium", 21.75F);
            expNextSystemLabel.ForeColor = Color.FromArgb(192, 64, 0);
            expNextSystemLabel.Location = new Point(750, 31);
            expNextSystemLabel.Name = "expNextSystemLabel";
            expNextSystemLabel.Size = new Size(203, 36);
            expNextSystemLabel.TabIndex = 93;
            expNextSystemLabel.Text = "next system : ";
            // 
            // expDestinationTag
            // 
            expDestinationTag.AutoSize = true;
            expDestinationTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            expDestinationTag.ForeColor = SystemColors.Control;
            expDestinationTag.Location = new Point(0, 50);
            expDestinationTag.Name = "expDestinationTag";
            expDestinationTag.Size = new Size(312, 50);
            expDestinationTag.TabIndex = 92;
            expDestinationTag.Text = "[awaiting scan]";
            // 
            // expDestinationLabel
            // 
            expDestinationLabel.AutoSize = true;
            expDestinationLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            expDestinationLabel.ForeColor = Color.FromArgb(192, 64, 0);
            expDestinationLabel.Location = new Point(0, 0);
            expDestinationLabel.Name = "expDestinationLabel";
            expDestinationLabel.Size = new Size(426, 50);
            expDestinationLabel.TabIndex = 91;
            expDestinationLabel.Text = "Destination System : ";
            // 
            // bodiesLabel
            // 
            bodiesLabel.AutoSize = true;
            bodiesLabel.Font = new Font("Oxanium", 21.75F);
            bodiesLabel.ForeColor = Color.FromArgb(192, 64, 0);
            bodiesLabel.Location = new Point(0, 257);
            bodiesLabel.Name = "bodiesLabel";
            bodiesLabel.Size = new Size(129, 36);
            bodiesLabel.TabIndex = 85;
            bodiesLabel.Text = "Bodies : ";
            // 
            // starsLabel
            // 
            starsLabel.AutoSize = true;
            starsLabel.Font = new Font("Oxanium", 21.75F);
            starsLabel.ForeColor = Color.FromArgb(192, 64, 0);
            starsLabel.Location = new Point(0, 221);
            starsLabel.Name = "starsLabel";
            starsLabel.Size = new Size(127, 36);
            starsLabel.TabIndex = 83;
            starsLabel.Text = "Star[s] : ";
            // 
            // detailViewPanel
            // 
            detailViewPanel.BackColor = Color.FromArgb(64, 64, 64);
            detailViewPanel.ForeColor = SystemColors.Desktop;
            detailViewPanel.Location = new Point(1150, 148);
            detailViewPanel.Name = "detailViewPanel";
            detailViewPanel.Size = new Size(652, 735);
            detailViewPanel.TabIndex = 90;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Oxanium", 21.75F);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(196, 293);
            label9.Name = "label9";
            label9.Size = new Size(91, 36);
            label9.TabIndex = 88;
            label9.Text = "ready";
            // 
            // bodiesDivPanel
            // 
            bodiesDivPanel.BackColor = Color.FromArgb(192, 64, 0);
            bodiesDivPanel.Location = new Point(0, 216);
            bodiesDivPanel.Name = "bodiesDivPanel";
            bodiesDivPanel.Size = new Size(652, 2);
            bodiesDivPanel.TabIndex = 82;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Oxanium", 21.75F);
            label10.ForeColor = SystemColors.Control;
            label10.Location = new Point(196, 221);
            label10.Name = "label10";
            label10.Size = new Size(91, 36);
            label10.TabIndex = 84;
            label10.Text = "ready";
            // 
            // bodyListPanel
            // 
            bodyListPanel.BackColor = Color.FromArgb(64, 64, 64);
            bodyListPanel.Controls.Add(bodyList);
            bodyListPanel.ForeColor = SystemColors.Desktop;
            bodyListPanel.Location = new Point(2, 472);
            bodyListPanel.Name = "bodyListPanel";
            bodyListPanel.Size = new Size(652, 411);
            bodyListPanel.TabIndex = 89;
            // 
            // bodyList
            // 
            bodyList.Location = new Point(95, 45);
            bodyList.Name = "bodyList";
            bodyList.Size = new Size(431, 324);
            bodyList.TabIndex = 0;
            bodyList.UseCompatibleStateImageBehavior = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Oxanium", 21.75F);
            label11.ForeColor = Color.FromArgb(192, 64, 0);
            label11.Location = new Point(0, 293);
            label11.Name = "label11";
            label11.Size = new Size(172, 36);
            label11.TabIndex = 87;
            label11.Text = "fsd status : ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Oxanium", 21.75F);
            label12.ForeColor = SystemColors.Control;
            label12.Location = new Point(196, 257);
            label12.Name = "label12";
            label12.Size = new Size(91, 36);
            label12.TabIndex = 86;
            label12.Text = "ready";
            // 
            // fsdTag
            // 
            fsdTag.AutoSize = true;
            fsdTag.Font = new Font("Oxanium", 21.75F);
            fsdTag.ForeColor = SystemColors.Control;
            fsdTag.Location = new Point(895, -5);
            fsdTag.Name = "fsdTag";
            fsdTag.Size = new Size(91, 36);
            fsdTag.TabIndex = 80;
            fsdTag.Text = "ready";
            // 
            // fsdLabel
            // 
            fsdLabel.AutoSize = true;
            fsdLabel.Font = new Font("Oxanium", 21.75F);
            fsdLabel.ForeColor = Color.FromArgb(192, 64, 0);
            fsdLabel.Location = new Point(699, -5);
            fsdLabel.Name = "fsdLabel";
            fsdLabel.Size = new Size(172, 36);
            fsdLabel.TabIndex = 79;
            fsdLabel.Text = "fsd status : ";
            // 
            // expCurrentSystemTag
            // 
            expCurrentSystemTag.AutoSize = true;
            expCurrentSystemTag.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            expCurrentSystemTag.ForeColor = SystemColors.Control;
            expCurrentSystemTag.Location = new Point(0, 158);
            expCurrentSystemTag.Name = "expCurrentSystemTag";
            expCurrentSystemTag.Size = new Size(312, 50);
            expCurrentSystemTag.TabIndex = 53;
            expCurrentSystemTag.Text = "[awaiting scan]";
            // 
            // expCurrentSystemLabel
            // 
            expCurrentSystemLabel.AutoSize = true;
            expCurrentSystemLabel.Font = new Font("Oxanium", 30F, FontStyle.Bold);
            expCurrentSystemLabel.ForeColor = Color.FromArgb(192, 64, 0);
            expCurrentSystemLabel.Location = new Point(0, 108);
            expCurrentSystemLabel.Name = "expCurrentSystemLabel";
            expCurrentSystemLabel.Size = new Size(350, 50);
            expCurrentSystemLabel.TabIndex = 52;
            expCurrentSystemLabel.Text = "Current System : ";
            // 
            // dividerPanel
            // 
            dividerPanel.BackColor = Color.FromArgb(192, 64, 0);
            dividerPanel.Location = new Point(110, 0);
            dividerPanel.Margin = new Padding(0);
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
            verLabel.Text = "version 0.1.8";
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
            // stationButton
            // 
            stationButton.BackColor = SystemColors.ActiveCaptionText;
            stationButton.FlatStyle = FlatStyle.Popup;
            stationButton.Font = new Font("Oxanium ExtraBold", 9F, FontStyle.Bold);
            stationButton.ForeColor = Color.FromArgb(192, 64, 0);
            stationButton.Location = new Point(12, 101);
            stationButton.Name = "stationButton";
            stationButton.Size = new Size(92, 23);
            stationButton.TabIndex = 70;
            stationButton.Text = "Stationing";
            stationButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1920, 1080);
            Controls.Add(stationButton);
            Controls.Add(dividerPanel);
            Controls.Add(explorePanel);
            Controls.Add(combatPanel);
            Controls.Add(homePanel);
            Controls.Add(initPanel);
            Controls.Add(statusPanel);
            Controls.Add(exitButton);
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
            bodyListPanel.ResumeLayout(false);
            statusPanel.ResumeLayout(false);
            statusPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public Button restartSessionButton;
        public Panel combatPanel;
        public Label targetShipTag;
        public Label targetShieldTag;
        public Label targetHullTag;
        public Label targetTag;
        public Label targetRankTag;
        public Label targetPowerTag;
        public Label targetFactionTag;
        public Label targetBountyTag;
        public Label targetLegalStatusTag;
        public Label targetShipLabel;
        public Label targetLegalStatusLabel;
        public Label targetRankLabel;
        public Label targetFactionLabel;
        public Label targetLocalBounty;
        public Label targetHullLabel;
        public Label targetPowerLabel;
        public Label targetShieldsLabel;
        public Label targetNameLabel;
        public Button simulateButton;
        public Button settingsButton;
        public Button combatButton;
        public Button explorationButton;
        public Button homeButton;
        public Panel initPanel;
        public Panel homePanel;
        public Label welcomeLabel;
        public Label locDTLabel;
        public Panel explorePanel;
        public Label expCurrentSystemTag;
        public Label expCurrentSystemLabel;
        public Label waitingSTTag;
        public Label starDTLabel;
        public Label locDTTag;
        public Label waitingConnectLabel;
        public Panel dividerPanel;
        public Button exitButton;
        public Label starDTTag;
        public EliteJournalReader.JournalWatcher journalWatcher;
        public Label shipNameLabel;
        public Label shipLabel;
        public Label initLabel;
        public Label diagLabel;
        public Label enviroLabel;
        public Label linkLabel;
        public Panel statusPanel;
        public Label statusLabel;
        public Label waitingClientLabel;
        public Label shipFuelLabel;
        public Label shipIDLabel;
        public Label curShipFuelTag;
        public Label curShipIDTag;
        public Label curShipDesTag;
        public Label curShipTag;
        public Label verLabel;
        public Label homeLSTag;
        public Label homeLSLabel;
        public Label homeLBTag;
        public Label homeSysTag;
        public Label homeCRLabel;
        public Label homeCRTag;
        public Label creditBalanceLabel;
        public Label homeSysLabel;
        public Label homeCredBalanceTag;
        public Label homeTRTag;
        public Label homeLBLabel;
        public Label clientDone;
        public Label enviroDone;
        public Label uplinkDone;
        public Label diagDone;
        public Label initDone;
        public Label homeTRLabel;
        public Label homeARLabel;
        public Label homeARTag;
        public Label homeMRLabel;
        public Label homeMRTag;
        public Label homeEXRLabel;
        public Label homeEXRTag;
        public Label homeERLabel;
        public Label homeERTag;
        public Label scanStageLabel;
        public Label scanStageTag;
        public Panel combatPanelDivider;
        public Label targetDataLabel;
        public Label targetSSHTag;
        public Label targetSSHealthLabel;
        public Label targetSSTag;
        public Label targetSubSystemLabel;
        public Button stationButton;
        public Label fsdTag;
        public Label fsdLabel;
        public Panel bodiesDivPanel;
        public Panel bodyListPanel;
        public Panel detailViewPanel;
        public Label bodiesLabel;
        public Label starsLabel;
        public Label label9;
        public Label label10;
        public Label label11;
        public Label label12;
        public ListView bodyList;
        public Label expDestinationTag;
        public Label expDestinationLabel;
        public Label expNextSystemTag;
        public Label expNextSystemLabel;
    }
}
