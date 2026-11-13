namespace ED_Hud_Extension
{
    partial class StatisticsSettingsForm
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
            confirmButton = new Button();
            cancelButton = new Button();
            statisticsSettingsLabel = new Label();
            defaultResetButton = new Button();
            combatStatsTabControl = new TabControl();
            currentSessionTab = new TabPage();
            onFootScavsKilledCheckBox = new CheckBox();
            onFootSkimmersKilledCheckBox = new CheckBox();
            settlementsConqueredCheckBox = new CheckBox();
            settlementsDefenderCheckBox = new CheckBox();
            conflictZonesWinsTotalCheckBox = new CheckBox();
            conflictZonesHighWinsCheckBox = new CheckBox();
            conflictZonesMediumWinsCheckBox = new CheckBox();
            conflictZonesLowWinsCheckBox = new CheckBox();
            conflictZonesTotalCheckBox = new CheckBox();
            conflictZonesHighCheckBox = new CheckBox();
            conflictZonesMediumCheckBox = new CheckBox();
            conflictZonesLowCheckBox = new CheckBox();
            onFootVehiclesDestroyedCheckBox = new CheckBox();
            onFootCombatBondProfitsCheckBox = new CheckBox();
            onFootCombatBondsCheckBox = new CheckBox();
            skimmersKilledCheckBox = new CheckBox();
            highestSingleRewardCheckBox = new CheckBox();
            assassinationsProfitsCheckBox = new CheckBox();
            assassinationsCheckBox = new CheckBox();
            combatBondProfitsCheckBox = new CheckBox();
            combatBondsCheckBox = new CheckBox();
            bountyProfitsCheckBox = new CheckBox();
            bountiesClaimedCheckBox = new CheckBox();
            careerTab = new TabPage();
            resetSessionButton = new Button();
            explanationLabel = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox8 = new CheckBox();
            checkBox9 = new CheckBox();
            checkBox10 = new CheckBox();
            checkBox11 = new CheckBox();
            checkBox12 = new CheckBox();
            checkBox13 = new CheckBox();
            checkBox14 = new CheckBox();
            checkBox15 = new CheckBox();
            checkBox16 = new CheckBox();
            checkBox17 = new CheckBox();
            checkBox18 = new CheckBox();
            checkBox19 = new CheckBox();
            checkBox20 = new CheckBox();
            checkBox21 = new CheckBox();
            checkBox22 = new CheckBox();
            checkBox23 = new CheckBox();
            checkBox24 = new CheckBox();
            checkBox25 = new CheckBox();
            checkBox26 = new CheckBox();
            combatStatsTabControl.SuspendLayout();
            currentSessionTab.SuspendLayout();
            careerTab.SuspendLayout();
            SuspendLayout();
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(52, 863);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(75, 23);
            confirmButton.TabIndex = 0;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(133, 863);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // statisticsSettingsLabel
            // 
            statisticsSettingsLabel.AutoSize = true;
            statisticsSettingsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            statisticsSettingsLabel.Location = new Point(12, 9);
            statisticsSettingsLabel.Name = "statisticsSettingsLabel";
            statisticsSettingsLabel.Size = new Size(269, 21);
            statisticsSettingsLabel.TabIndex = 32;
            statisticsSettingsLabel.Text = "Combat Statistics Display Settings";
            // 
            // defaultResetButton
            // 
            defaultResetButton.Location = new Point(761, 401);
            defaultResetButton.Name = "defaultResetButton";
            defaultResetButton.Size = new Size(100, 23);
            defaultResetButton.TabIndex = 33;
            defaultResetButton.Text = "Reset to Default";
            defaultResetButton.UseVisualStyleBackColor = true;
            // 
            // combatStatsTabControl
            // 
            combatStatsTabControl.Controls.Add(currentSessionTab);
            combatStatsTabControl.Controls.Add(careerTab);
            combatStatsTabControl.Location = new Point(12, 48);
            combatStatsTabControl.Name = "combatStatsTabControl";
            combatStatsTabControl.SelectedIndex = 0;
            combatStatsTabControl.Size = new Size(875, 721);
            combatStatsTabControl.TabIndex = 34;
            // 
            // currentSessionTab
            // 
            currentSessionTab.BackColor = SystemColors.Control;
            currentSessionTab.Controls.Add(onFootScavsKilledCheckBox);
            currentSessionTab.Controls.Add(onFootSkimmersKilledCheckBox);
            currentSessionTab.Controls.Add(defaultResetButton);
            currentSessionTab.Controls.Add(settlementsConqueredCheckBox);
            currentSessionTab.Controls.Add(settlementsDefenderCheckBox);
            currentSessionTab.Controls.Add(conflictZonesWinsTotalCheckBox);
            currentSessionTab.Controls.Add(conflictZonesHighWinsCheckBox);
            currentSessionTab.Controls.Add(conflictZonesMediumWinsCheckBox);
            currentSessionTab.Controls.Add(conflictZonesLowWinsCheckBox);
            currentSessionTab.Controls.Add(conflictZonesTotalCheckBox);
            currentSessionTab.Controls.Add(conflictZonesHighCheckBox);
            currentSessionTab.Controls.Add(conflictZonesMediumCheckBox);
            currentSessionTab.Controls.Add(conflictZonesLowCheckBox);
            currentSessionTab.Controls.Add(onFootVehiclesDestroyedCheckBox);
            currentSessionTab.Controls.Add(onFootCombatBondProfitsCheckBox);
            currentSessionTab.Controls.Add(onFootCombatBondsCheckBox);
            currentSessionTab.Controls.Add(skimmersKilledCheckBox);
            currentSessionTab.Controls.Add(highestSingleRewardCheckBox);
            currentSessionTab.Controls.Add(assassinationsProfitsCheckBox);
            currentSessionTab.Controls.Add(assassinationsCheckBox);
            currentSessionTab.Controls.Add(combatBondProfitsCheckBox);
            currentSessionTab.Controls.Add(combatBondsCheckBox);
            currentSessionTab.Controls.Add(bountyProfitsCheckBox);
            currentSessionTab.Controls.Add(bountiesClaimedCheckBox);
            currentSessionTab.Location = new Point(4, 24);
            currentSessionTab.Name = "currentSessionTab";
            currentSessionTab.Padding = new Padding(3);
            currentSessionTab.Size = new Size(867, 429);
            currentSessionTab.TabIndex = 0;
            currentSessionTab.Text = "Current Session";
            // 
            // onFootScavsKilledCheckBox
            // 
            onFootScavsKilledCheckBox.AutoSize = true;
            onFootScavsKilledCheckBox.Location = new Point(177, 131);
            onFootScavsKilledCheckBox.Name = "onFootScavsKilledCheckBox";
            onFootScavsKilledCheckBox.Size = new Size(163, 19);
            onFootScavsKilledCheckBox.TabIndex = 25;
            onFootScavsKilledCheckBox.Text = "On Foot Scavengers Killed";
            onFootScavsKilledCheckBox.UseVisualStyleBackColor = true;
            // 
            // onFootSkimmersKilledCheckBox
            // 
            onFootSkimmersKilledCheckBox.AutoSize = true;
            onFootSkimmersKilledCheckBox.Location = new Point(177, 106);
            onFootSkimmersKilledCheckBox.Name = "onFootSkimmersKilledCheckBox";
            onFootSkimmersKilledCheckBox.Size = new Size(156, 19);
            onFootSkimmersKilledCheckBox.TabIndex = 24;
            onFootSkimmersKilledCheckBox.Text = "On Foot Skimmers Killed";
            onFootSkimmersKilledCheckBox.UseVisualStyleBackColor = true;
            // 
            // settlementsConqueredCheckBox
            // 
            settlementsConqueredCheckBox.AutoSize = true;
            settlementsConqueredCheckBox.Location = new Point(177, 81);
            settlementsConqueredCheckBox.Name = "settlementsConqueredCheckBox";
            settlementsConqueredCheckBox.Size = new Size(150, 19);
            settlementsConqueredCheckBox.TabIndex = 23;
            settlementsConqueredCheckBox.Text = "Settlements Conquered";
            settlementsConqueredCheckBox.UseVisualStyleBackColor = true;
            // 
            // settlementsDefenderCheckBox
            // 
            settlementsDefenderCheckBox.AutoSize = true;
            settlementsDefenderCheckBox.Location = new Point(177, 56);
            settlementsDefenderCheckBox.Name = "settlementsDefenderCheckBox";
            settlementsDefenderCheckBox.Size = new Size(142, 19);
            settlementsDefenderCheckBox.TabIndex = 22;
            settlementsDefenderCheckBox.Text = "Settlements Defended";
            settlementsDefenderCheckBox.UseVisualStyleBackColor = true;
            // 
            // conflictZonesWinsTotalCheckBox
            // 
            conflictZonesWinsTotalCheckBox.AutoSize = true;
            conflictZonesWinsTotalCheckBox.Location = new Point(177, 31);
            conflictZonesWinsTotalCheckBox.Name = "conflictZonesWinsTotalCheckBox";
            conflictZonesWinsTotalCheckBox.Size = new Size(164, 19);
            conflictZonesWinsTotalCheckBox.TabIndex = 21;
            conflictZonesWinsTotalCheckBox.Text = "Conflict Zone Wins [Total]";
            conflictZonesWinsTotalCheckBox.UseVisualStyleBackColor = true;
            // 
            // conflictZonesHighWinsCheckBox
            // 
            conflictZonesHighWinsCheckBox.AutoSize = true;
            conflictZonesHighWinsCheckBox.Location = new Point(6, 406);
            conflictZonesHighWinsCheckBox.Name = "conflictZonesHighWinsCheckBox";
            conflictZonesHighWinsCheckBox.Size = new Size(164, 19);
            conflictZonesHighWinsCheckBox.TabIndex = 20;
            conflictZonesHighWinsCheckBox.Text = "Conflict Zone Wins [High]";
            conflictZonesHighWinsCheckBox.UseVisualStyleBackColor = true;
            // 
            // conflictZonesMediumWinsCheckBox
            // 
            conflictZonesMediumWinsCheckBox.AutoSize = true;
            conflictZonesMediumWinsCheckBox.Location = new Point(6, 356);
            conflictZonesMediumWinsCheckBox.Name = "conflictZonesMediumWinsCheckBox";
            conflictZonesMediumWinsCheckBox.Size = new Size(183, 19);
            conflictZonesMediumWinsCheckBox.TabIndex = 16;
            conflictZonesMediumWinsCheckBox.Text = "Conflict Zone Wins [Medium]";
            conflictZonesMediumWinsCheckBox.UseVisualStyleBackColor = true;
            // 
            // conflictZonesLowWinsCheckBox
            // 
            conflictZonesLowWinsCheckBox.AutoSize = true;
            conflictZonesLowWinsCheckBox.Location = new Point(6, 306);
            conflictZonesLowWinsCheckBox.Name = "conflictZonesLowWinsCheckBox";
            conflictZonesLowWinsCheckBox.Size = new Size(160, 19);
            conflictZonesLowWinsCheckBox.TabIndex = 15;
            conflictZonesLowWinsCheckBox.Text = "Conflict Zone Wins [Low]";
            conflictZonesLowWinsCheckBox.UseVisualStyleBackColor = true;
            // 
            // conflictZonesTotalCheckBox
            // 
            conflictZonesTotalCheckBox.AutoSize = true;
            conflictZonesTotalCheckBox.Location = new Point(177, 6);
            conflictZonesTotalCheckBox.Name = "conflictZonesTotalCheckBox";
            conflictZonesTotalCheckBox.Size = new Size(132, 19);
            conflictZonesTotalCheckBox.TabIndex = 14;
            conflictZonesTotalCheckBox.Text = "Conflict Zones Total";
            conflictZonesTotalCheckBox.UseVisualStyleBackColor = true;
            // 
            // conflictZonesHighCheckBox
            // 
            conflictZonesHighCheckBox.AutoSize = true;
            conflictZonesHighCheckBox.Location = new Point(6, 381);
            conflictZonesHighCheckBox.Name = "conflictZonesHighCheckBox";
            conflictZonesHighCheckBox.Size = new Size(140, 19);
            conflictZonesHighCheckBox.TabIndex = 13;
            conflictZonesHighCheckBox.Text = "Conflict Zones [High]";
            conflictZonesHighCheckBox.UseVisualStyleBackColor = true;
            // 
            // conflictZonesMediumCheckBox
            // 
            conflictZonesMediumCheckBox.AutoSize = true;
            conflictZonesMediumCheckBox.Location = new Point(6, 331);
            conflictZonesMediumCheckBox.Name = "conflictZonesMediumCheckBox";
            conflictZonesMediumCheckBox.Size = new Size(159, 19);
            conflictZonesMediumCheckBox.TabIndex = 12;
            conflictZonesMediumCheckBox.Text = "Conflict Zones ]Medium]";
            conflictZonesMediumCheckBox.UseVisualStyleBackColor = true;
            // 
            // conflictZonesLowCheckBox
            // 
            conflictZonesLowCheckBox.AutoSize = true;
            conflictZonesLowCheckBox.Location = new Point(6, 281);
            conflictZonesLowCheckBox.Name = "conflictZonesLowCheckBox";
            conflictZonesLowCheckBox.Size = new Size(136, 19);
            conflictZonesLowCheckBox.TabIndex = 11;
            conflictZonesLowCheckBox.Text = "Conflict Zones [Low]";
            conflictZonesLowCheckBox.UseVisualStyleBackColor = true;
            // 
            // onFootVehiclesDestroyedCheckBox
            // 
            onFootVehiclesDestroyedCheckBox.AutoSize = true;
            onFootVehiclesDestroyedCheckBox.Location = new Point(6, 256);
            onFootVehiclesDestroyedCheckBox.Name = "onFootVehiclesDestroyedCheckBox";
            onFootVehiclesDestroyedCheckBox.Size = new Size(170, 19);
            onFootVehiclesDestroyedCheckBox.TabIndex = 10;
            onFootVehiclesDestroyedCheckBox.Text = "On Foot Vehicles Destroyed";
            onFootVehiclesDestroyedCheckBox.UseVisualStyleBackColor = true;
            // 
            // onFootCombatBondProfitsCheckBox
            // 
            onFootCombatBondProfitsCheckBox.AutoSize = true;
            onFootCombatBondProfitsCheckBox.Location = new Point(6, 231);
            onFootCombatBondProfitsCheckBox.Name = "onFootCombatBondProfitsCheckBox";
            onFootCombatBondProfitsCheckBox.Size = new Size(183, 19);
            onFootCombatBondProfitsCheckBox.TabIndex = 9;
            onFootCombatBondProfitsCheckBox.Text = "On Foot Combat Bond Profits";
            onFootCombatBondProfitsCheckBox.UseVisualStyleBackColor = true;
            // 
            // onFootCombatBondsCheckBox
            // 
            onFootCombatBondsCheckBox.AutoSize = true;
            onFootCombatBondsCheckBox.Location = new Point(6, 206);
            onFootCombatBondsCheckBox.Name = "onFootCombatBondsCheckBox";
            onFootCombatBondsCheckBox.Size = new Size(151, 19);
            onFootCombatBondsCheckBox.TabIndex = 8;
            onFootCombatBondsCheckBox.Text = "On Foot Combat Bonds";
            onFootCombatBondsCheckBox.UseVisualStyleBackColor = true;
            // 
            // skimmersKilledCheckBox
            // 
            skimmersKilledCheckBox.AutoSize = true;
            skimmersKilledCheckBox.Location = new Point(6, 181);
            skimmersKilledCheckBox.Name = "skimmersKilledCheckBox";
            skimmersKilledCheckBox.Size = new Size(110, 19);
            skimmersKilledCheckBox.TabIndex = 7;
            skimmersKilledCheckBox.Text = "Skimmers Killed";
            skimmersKilledCheckBox.UseVisualStyleBackColor = true;
            // 
            // highestSingleRewardCheckBox
            // 
            highestSingleRewardCheckBox.AutoSize = true;
            highestSingleRewardCheckBox.Location = new Point(6, 156);
            highestSingleRewardCheckBox.Name = "highestSingleRewardCheckBox";
            highestSingleRewardCheckBox.Size = new Size(144, 19);
            highestSingleRewardCheckBox.TabIndex = 6;
            highestSingleRewardCheckBox.Text = "Highest Single Reward";
            highestSingleRewardCheckBox.UseVisualStyleBackColor = true;
            // 
            // assassinationsProfitsCheckBox
            // 
            assassinationsProfitsCheckBox.AutoSize = true;
            assassinationsProfitsCheckBox.Location = new Point(6, 131);
            assassinationsProfitsCheckBox.Name = "assassinationsProfitsCheckBox";
            assassinationsProfitsCheckBox.Size = new Size(134, 19);
            assassinationsProfitsCheckBox.TabIndex = 5;
            assassinationsProfitsCheckBox.Text = "Assassination Profits";
            assassinationsProfitsCheckBox.UseVisualStyleBackColor = true;
            // 
            // assassinationsCheckBox
            // 
            assassinationsCheckBox.AutoSize = true;
            assassinationsCheckBox.Location = new Point(6, 106);
            assassinationsCheckBox.Name = "assassinationsCheckBox";
            assassinationsCheckBox.Size = new Size(102, 19);
            assassinationsCheckBox.TabIndex = 4;
            assassinationsCheckBox.Text = "Assassinations";
            assassinationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // combatBondProfitsCheckBox
            // 
            combatBondProfitsCheckBox.AutoSize = true;
            combatBondProfitsCheckBox.Location = new Point(6, 81);
            combatBondProfitsCheckBox.Name = "combatBondProfitsCheckBox";
            combatBondProfitsCheckBox.Size = new Size(137, 19);
            combatBondProfitsCheckBox.TabIndex = 3;
            combatBondProfitsCheckBox.Text = "Combat Bond Profits";
            combatBondProfitsCheckBox.UseVisualStyleBackColor = true;
            // 
            // combatBondsCheckBox
            // 
            combatBondsCheckBox.AutoSize = true;
            combatBondsCheckBox.Location = new Point(6, 56);
            combatBondsCheckBox.Name = "combatBondsCheckBox";
            combatBondsCheckBox.Size = new Size(105, 19);
            combatBondsCheckBox.TabIndex = 2;
            combatBondsCheckBox.Text = "Combat Bonds";
            combatBondsCheckBox.UseVisualStyleBackColor = true;
            // 
            // bountyProfitsCheckBox
            // 
            bountyProfitsCheckBox.AutoSize = true;
            bountyProfitsCheckBox.Location = new Point(6, 31);
            bountyProfitsCheckBox.Name = "bountyProfitsCheckBox";
            bountyProfitsCheckBox.Size = new Size(148, 19);
            bountyProfitsCheckBox.TabIndex = 1;
            bountyProfitsCheckBox.Text = "Bounty Hunting Profits";
            bountyProfitsCheckBox.UseVisualStyleBackColor = true;
            // 
            // bountiesClaimedCheckBox
            // 
            bountiesClaimedCheckBox.AutoSize = true;
            bountiesClaimedCheckBox.Location = new Point(6, 6);
            bountiesClaimedCheckBox.Name = "bountiesClaimedCheckBox";
            bountiesClaimedCheckBox.Size = new Size(119, 19);
            bountiesClaimedCheckBox.TabIndex = 0;
            bountiesClaimedCheckBox.Text = "Bounties Claimed";
            bountiesClaimedCheckBox.UseVisualStyleBackColor = true;
            // 
            // careerTab
            // 
            careerTab.BackColor = SystemColors.Control;
            careerTab.Controls.Add(checkBox1);
            careerTab.Controls.Add(checkBox2);
            careerTab.Controls.Add(checkBox3);
            careerTab.Controls.Add(checkBox4);
            careerTab.Controls.Add(checkBox5);
            careerTab.Controls.Add(checkBox6);
            careerTab.Controls.Add(checkBox7);
            careerTab.Controls.Add(checkBox8);
            careerTab.Controls.Add(checkBox9);
            careerTab.Controls.Add(checkBox10);
            careerTab.Controls.Add(checkBox11);
            careerTab.Controls.Add(checkBox12);
            careerTab.Controls.Add(checkBox13);
            careerTab.Controls.Add(checkBox14);
            careerTab.Controls.Add(checkBox15);
            careerTab.Controls.Add(checkBox16);
            careerTab.Controls.Add(checkBox17);
            careerTab.Controls.Add(checkBox18);
            careerTab.Controls.Add(checkBox19);
            careerTab.Controls.Add(checkBox20);
            careerTab.Controls.Add(checkBox21);
            careerTab.Controls.Add(checkBox22);
            careerTab.Controls.Add(checkBox23);
            careerTab.Controls.Add(checkBox24);
            careerTab.Controls.Add(checkBox25);
            careerTab.Controls.Add(checkBox26);
            careerTab.Location = new Point(4, 24);
            careerTab.Name = "careerTab";
            careerTab.Padding = new Padding(3);
            careerTab.Size = new Size(867, 693);
            careerTab.TabIndex = 1;
            careerTab.Text = "Career Statistics";
            // 
            // resetSessionButton
            // 
            resetSessionButton.Location = new Point(214, 863);
            resetSessionButton.Name = "resetSessionButton";
            resetSessionButton.Size = new Size(95, 23);
            resetSessionButton.TabIndex = 26;
            resetSessionButton.Text = "Reset Session";
            resetSessionButton.UseVisualStyleBackColor = true;
            // 
            // explanationLabel
            // 
            explanationLabel.AutoSize = true;
            explanationLabel.Location = new Point(12, 30);
            explanationLabel.Name = "explanationLabel";
            explanationLabel.Size = new Size(811, 15);
            explanationLabel.TabIndex = 35;
            explanationLabel.Text = "Toggle each Statistic to determine what the given statistic panel does / does not show you. Settings are per panel. Default setting is all values toggled On.\r\n";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(653, 200);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(134, 19);
            checkBox1.TabIndex = 108;
            checkBox1.Text = "Dropships Cancelled";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(653, 175);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(122, 19);
            checkBox2.TabIndex = 107;
            checkBox2.Text = "Dropships Booked";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(653, 150);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(113, 19);
            checkBox3.TabIndex = 106;
            checkBox3.Text = "Dropships Taken";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(653, 125);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(163, 19);
            checkBox4.TabIndex = 105;
            checkBox4.Text = "On Foot Scavengers Killed";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(653, 100);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(156, 19);
            checkBox5.TabIndex = 104;
            checkBox5.Text = "On Foot Skimmers Killed";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(653, 75);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(150, 19);
            checkBox6.TabIndex = 103;
            checkBox6.Text = "Settlements Conquered";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(653, 50);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(142, 19);
            checkBox7.TabIndex = 102;
            checkBox7.Text = "Settlements Defended";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Location = new Point(457, 200);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(164, 19);
            checkBox8.TabIndex = 101;
            checkBox8.Text = "Conflict Zone Wins [Total]";
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Location = new Point(457, 150);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(164, 19);
            checkBox9.TabIndex = 100;
            checkBox9.Text = "Conflict Zone Wins [High]";
            checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            checkBox10.AutoSize = true;
            checkBox10.Location = new Point(457, 100);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(183, 19);
            checkBox10.TabIndex = 99;
            checkBox10.Text = "Conflict Zone Wins [Medium]";
            checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            checkBox11.AutoSize = true;
            checkBox11.Location = new Point(457, 50);
            checkBox11.Name = "checkBox11";
            checkBox11.Size = new Size(160, 19);
            checkBox11.TabIndex = 98;
            checkBox11.Text = "Conflict Zone Wins [Low]";
            checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            checkBox12.AutoSize = true;
            checkBox12.Location = new Point(457, 175);
            checkBox12.Name = "checkBox12";
            checkBox12.Size = new Size(132, 19);
            checkBox12.TabIndex = 97;
            checkBox12.Text = "Conflict Zones Total";
            checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            checkBox13.AutoSize = true;
            checkBox13.Location = new Point(457, 125);
            checkBox13.Name = "checkBox13";
            checkBox13.Size = new Size(140, 19);
            checkBox13.TabIndex = 96;
            checkBox13.Text = "Conflict Zones [High]";
            checkBox13.UseVisualStyleBackColor = true;
            // 
            // checkBox14
            // 
            checkBox14.AutoSize = true;
            checkBox14.Location = new Point(457, 75);
            checkBox14.Name = "checkBox14";
            checkBox14.Size = new Size(159, 19);
            checkBox14.TabIndex = 95;
            checkBox14.Text = "Conflict Zones ]Medium]";
            checkBox14.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            checkBox15.AutoSize = true;
            checkBox15.Location = new Point(457, 25);
            checkBox15.Name = "checkBox15";
            checkBox15.Size = new Size(136, 19);
            checkBox15.TabIndex = 94;
            checkBox15.Text = "Conflict Zones [Low]";
            checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            checkBox16.AutoSize = true;
            checkBox16.Location = new Point(457, 225);
            checkBox16.Name = "checkBox16";
            checkBox16.Size = new Size(170, 19);
            checkBox16.TabIndex = 93;
            checkBox16.Text = "On Foot Vehicles Destroyed";
            checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox17
            // 
            checkBox17.AutoSize = true;
            checkBox17.Location = new Point(258, 225);
            checkBox17.Name = "checkBox17";
            checkBox17.Size = new Size(183, 19);
            checkBox17.TabIndex = 92;
            checkBox17.Text = "On Foot Combat Bond Profits";
            checkBox17.UseVisualStyleBackColor = true;
            // 
            // checkBox18
            // 
            checkBox18.AutoSize = true;
            checkBox18.Location = new Point(258, 200);
            checkBox18.Name = "checkBox18";
            checkBox18.Size = new Size(151, 19);
            checkBox18.TabIndex = 91;
            checkBox18.Text = "On Foot Combat Bonds";
            checkBox18.UseVisualStyleBackColor = true;
            // 
            // checkBox19
            // 
            checkBox19.AutoSize = true;
            checkBox19.Location = new Point(656, 25);
            checkBox19.Name = "checkBox19";
            checkBox19.Size = new Size(110, 19);
            checkBox19.TabIndex = 90;
            checkBox19.Text = "Skimmers Killed";
            checkBox19.UseVisualStyleBackColor = true;
            // 
            // checkBox20
            // 
            checkBox20.AutoSize = true;
            checkBox20.Location = new Point(258, 175);
            checkBox20.Name = "checkBox20";
            checkBox20.Size = new Size(144, 19);
            checkBox20.TabIndex = 89;
            checkBox20.Text = "Highest Single Reward";
            checkBox20.UseVisualStyleBackColor = true;
            // 
            // checkBox21
            // 
            checkBox21.AutoSize = true;
            checkBox21.Location = new Point(258, 150);
            checkBox21.Name = "checkBox21";
            checkBox21.Size = new Size(134, 19);
            checkBox21.TabIndex = 88;
            checkBox21.Text = "Assassination Profits";
            checkBox21.UseVisualStyleBackColor = true;
            // 
            // checkBox22
            // 
            checkBox22.AutoSize = true;
            checkBox22.Location = new Point(258, 125);
            checkBox22.Name = "checkBox22";
            checkBox22.Size = new Size(102, 19);
            checkBox22.TabIndex = 87;
            checkBox22.Text = "Assassinations";
            checkBox22.UseVisualStyleBackColor = true;
            // 
            // checkBox23
            // 
            checkBox23.AutoSize = true;
            checkBox23.Location = new Point(258, 100);
            checkBox23.Name = "checkBox23";
            checkBox23.Size = new Size(137, 19);
            checkBox23.TabIndex = 86;
            checkBox23.Text = "Combat Bond Profits";
            checkBox23.UseVisualStyleBackColor = true;
            // 
            // checkBox24
            // 
            checkBox24.AutoSize = true;
            checkBox24.Location = new Point(258, 75);
            checkBox24.Name = "checkBox24";
            checkBox24.Size = new Size(105, 19);
            checkBox24.TabIndex = 85;
            checkBox24.Text = "Combat Bonds";
            checkBox24.UseVisualStyleBackColor = true;
            // 
            // checkBox25
            // 
            checkBox25.AutoSize = true;
            checkBox25.Location = new Point(258, 50);
            checkBox25.Name = "checkBox25";
            checkBox25.Size = new Size(148, 19);
            checkBox25.TabIndex = 84;
            checkBox25.Text = "Bounty Hunting Profits";
            checkBox25.UseVisualStyleBackColor = true;
            // 
            // checkBox26
            // 
            checkBox26.AutoSize = true;
            checkBox26.Location = new Point(258, 25);
            checkBox26.Name = "checkBox26";
            checkBox26.Size = new Size(119, 19);
            checkBox26.TabIndex = 83;
            checkBox26.Text = "Bounties Claimed";
            checkBox26.UseVisualStyleBackColor = true;
            // 
            // StatisticsSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 1001);
            Controls.Add(explanationLabel);
            Controls.Add(combatStatsTabControl);
            Controls.Add(statisticsSettingsLabel);
            Controls.Add(confirmButton);
            Controls.Add(cancelButton);
            Controls.Add(resetSessionButton);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StatisticsSettingsForm";
            ShowInTaskbar = false;
            Text = "Combat Statistics Settings";
            combatStatsTabControl.ResumeLayout(false);
            currentSessionTab.ResumeLayout(false);
            currentSessionTab.PerformLayout();
            careerTab.ResumeLayout(false);
            careerTab.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button confirmButton;
        private Button cancelButton;
        private Label statisticsSettingsLabel;
        private Button defaultResetButton;
        private TabControl combatStatsTabControl;
        private TabPage currentSessionTab;
        private TabPage careerTab;
        private CheckBox onFootScavsKilledCheckBox;
        private CheckBox checkBox26;
        private CheckBox settlementsConqueredCheckBox;
        private CheckBox settlementsDefenderCheckBox;
        private CheckBox conflictZonesWinsTotalCheckBox;
        private CheckBox conflictZonesHighWinsCheckBox;
        private CheckBox conflictZonesMediumWinsCheckBox;
        private CheckBox conflictZonesLowWinsCheckBox;
        private CheckBox conflictZonesTotalCheckBox;
        private CheckBox conflictZonesHighCheckBox;
        private CheckBox conflictZonesMediumCheckBox;
        private CheckBox conflictZonesLowCheckBox;
        private CheckBox onFootVehiclesDestroyedCheckBox;
        private CheckBox onFootCombatBondProfitsCheckBox;
        private CheckBox onFootCombatBondsCheckBox;
        private CheckBox skimmersKilledCheckBox;
        private CheckBox highestSingleRewardCheckBox;
        private CheckBox assassinationsProfitsCheckBox;
        private CheckBox assassinationsCheckBox;
        private CheckBox combatBondProfitsCheckBox;
        private CheckBox combatBondsCheckBox;
        private CheckBox bountyProfitsCheckBox;
        private CheckBox bountiesClaimedCheckBox;
        private CheckBox onFootSkimmersKilledCheckBox;
        private Button resetSessionButton;
        private Label explanationLabel;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private CheckBox checkBox10;
        private CheckBox checkBox11;
        private CheckBox checkBox12;
        private CheckBox checkBox13;
        private CheckBox checkBox14;
        private CheckBox checkBox15;
        private CheckBox checkBox16;
        private CheckBox checkBox17;
        private CheckBox checkBox18;
        private CheckBox checkBox19;
        private CheckBox checkBox20;
        private CheckBox checkBox21;
        private CheckBox checkBox22;
        private CheckBox checkBox23;
        private CheckBox checkBox24;
        private CheckBox checkBox25;
    }
}