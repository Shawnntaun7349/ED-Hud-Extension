namespace ED_Hud_Extension
{
    partial class SettingsForm
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
            closeButton = new Button();
            applyButton = new Button();
            settingsTabControl = new TabControl();
            genTab = new TabPage();
            defGamelPathLabel = new Label();
            gameBrowseButton = new Button();
            gamePathTextbox = new TextBox();
            gpBrowserLabel = new Label();
            defJournalPathLabel = new Label();
            pathBrowseButton = new Button();
            journalPathTextbox = new TextBox();
            pathBrowserLabel = new Label();
            dispTab = new TabPage();
            skipAnimationToggle = new CheckBox();
            displaySettingsLabel = new Label();
            uiElementsLabel = new Label();
            statReadToggle = new CheckBox();
            prefDisplayMenu = new ComboBox();
            prefDisplayLabel = new Label();
            soundTab = new TabPage();
            inaraTab = new TabPage();
            capiTab = new TabPage();
            capiDisconnectButton = new Button();
            capiConnectButton = new Button();
            capiAccountTag = new Label();
            capiAccountLabel = new Label();
            capiStatusTag = new Label();
            capiStatusLabel = new Label();
            helpTab = new TabPage();
            restartButton = new Button();
            checkUpdateButton = new Button();
            uiTab = new TabPage();
            pageTabControl = new TabControl();
            genPageTab = new TabPage();
            homePageTab = new TabPage();
            combatPageTab = new TabPage();
            explorationPagTab = new TabPage();
            missionsPageTab = new TabPage();
            stationsPageTab = new TabPage();
            autoShutdownToggle = new CheckBox();
            autoSwitchToggle = new CheckBox();
            combatSwitchToggle = new CheckBox();
            genPageLabel = new Label();
            homePageLabel = new Label();
            combatPageLabel = new Label();
            explorationPageLabel = new Label();
            missionsPageLabel = new Label();
            stationsPageLabel = new Label();
            pathSettingsLabel = new Label();
            miscLabel = new Label();
            settingsTabControl.SuspendLayout();
            genTab.SuspendLayout();
            dispTab.SuspendLayout();
            capiTab.SuspendLayout();
            uiTab.SuspendLayout();
            pageTabControl.SuspendLayout();
            genPageTab.SuspendLayout();
            homePageTab.SuspendLayout();
            combatPageTab.SuspendLayout();
            explorationPagTab.SuspendLayout();
            missionsPageTab.SuspendLayout();
            stationsPageTab.SuspendLayout();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.Location = new Point(713, 415);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 0;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(12, 415);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(75, 23);
            applyButton.TabIndex = 1;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // settingsTabControl
            // 
            settingsTabControl.Controls.Add(genTab);
            settingsTabControl.Controls.Add(dispTab);
            settingsTabControl.Controls.Add(soundTab);
            settingsTabControl.Controls.Add(uiTab);
            settingsTabControl.Controls.Add(inaraTab);
            settingsTabControl.Controls.Add(capiTab);
            settingsTabControl.Controls.Add(helpTab);
            settingsTabControl.Location = new Point(12, 12);
            settingsTabControl.Name = "settingsTabControl";
            settingsTabControl.SelectedIndex = 0;
            settingsTabControl.Size = new Size(776, 397);
            settingsTabControl.TabIndex = 2;
            // 
            // genTab
            // 
            genTab.BackColor = SystemColors.Control;
            genTab.Controls.Add(miscLabel);
            genTab.Controls.Add(pathSettingsLabel);
            genTab.Controls.Add(autoShutdownToggle);
            genTab.Controls.Add(defGamelPathLabel);
            genTab.Controls.Add(gameBrowseButton);
            genTab.Controls.Add(gamePathTextbox);
            genTab.Controls.Add(gpBrowserLabel);
            genTab.Controls.Add(defJournalPathLabel);
            genTab.Controls.Add(pathBrowseButton);
            genTab.Controls.Add(journalPathTextbox);
            genTab.Controls.Add(pathBrowserLabel);
            genTab.Location = new Point(4, 24);
            genTab.Name = "genTab";
            genTab.Padding = new Padding(3);
            genTab.Size = new Size(768, 369);
            genTab.TabIndex = 0;
            genTab.Text = "General";
            // 
            // defGamelPathLabel
            // 
            defGamelPathLabel.AutoSize = true;
            defGamelPathLabel.Location = new Point(3, 21);
            defGamelPathLabel.Name = "defGamelPathLabel";
            defGamelPathLabel.Size = new Size(694, 30);
            defGamelPathLabel.TabIndex = 20;
            defGamelPathLabel.Text = "The default game path is \r\n\"C:\\Program Files (x86)\\Steam\\steamapps\\common\\Elite Dangerous\\Products\\elite-dangerous-odyssey-64\\EliteDangerous64.exe\"";
            // 
            // gameBrowseButton
            // 
            gameBrowseButton.Location = new Point(552, 53);
            gameBrowseButton.Name = "gameBrowseButton";
            gameBrowseButton.Size = new Size(31, 23);
            gameBrowseButton.TabIndex = 18;
            gameBrowseButton.Text = "...";
            gameBrowseButton.UseVisualStyleBackColor = true;
            // 
            // gamePathTextbox
            // 
            gamePathTextbox.Location = new Point(90, 54);
            gamePathTextbox.Name = "gamePathTextbox";
            gamePathTextbox.Size = new Size(456, 23);
            gamePathTextbox.TabIndex = 17;
            // 
            // gpBrowserLabel
            // 
            gpBrowserLabel.AutoSize = true;
            gpBrowserLabel.Location = new Point(33, 57);
            gpBrowserLabel.Name = "gpBrowserLabel";
            gpBrowserLabel.Size = new Size(51, 15);
            gpBrowserLabel.TabIndex = 16;
            gpBrowserLabel.Text = "Elite EXE";
            // 
            // defJournalPathLabel
            // 
            defJournalPathLabel.AutoSize = true;
            defJournalPathLabel.Location = new Point(3, 95);
            defJournalPathLabel.Name = "defJournalPathLabel";
            defJournalPathLabel.Size = new Size(543, 15);
            defJournalPathLabel.TabIndex = 15;
            defJournalPathLabel.Text = "The default Journal folder location is \"...\\[user]\\Saved Games\\Frontier Developments\\Elite Dangerous\"";
            // 
            // pathBrowseButton
            // 
            pathBrowseButton.Location = new Point(552, 113);
            pathBrowseButton.Name = "pathBrowseButton";
            pathBrowseButton.Size = new Size(31, 23);
            pathBrowseButton.TabIndex = 14;
            pathBrowseButton.Text = "...";
            pathBrowseButton.UseVisualStyleBackColor = true;
            // 
            // journalPathTextbox
            // 
            journalPathTextbox.Location = new Point(90, 113);
            journalPathTextbox.Name = "journalPathTextbox";
            journalPathTextbox.Size = new Size(456, 23);
            journalPathTextbox.TabIndex = 13;
            // 
            // pathBrowserLabel
            // 
            pathBrowserLabel.AutoSize = true;
            pathBrowserLabel.Location = new Point(3, 117);
            pathBrowserLabel.Name = "pathBrowserLabel";
            pathBrowserLabel.Size = new Size(81, 15);
            pathBrowserLabel.TabIndex = 12;
            pathBrowserLabel.Text = "Journal Folder";
            // 
            // dispTab
            // 
            dispTab.BackColor = SystemColors.Control;
            dispTab.Controls.Add(skipAnimationToggle);
            dispTab.Controls.Add(displaySettingsLabel);
            dispTab.Controls.Add(uiElementsLabel);
            dispTab.Controls.Add(statReadToggle);
            dispTab.Controls.Add(prefDisplayMenu);
            dispTab.Controls.Add(prefDisplayLabel);
            dispTab.Location = new Point(4, 24);
            dispTab.Name = "dispTab";
            dispTab.Padding = new Padding(3);
            dispTab.Size = new Size(768, 369);
            dispTab.TabIndex = 1;
            dispTab.Text = "Display";
            // 
            // skipAnimationToggle
            // 
            skipAnimationToggle.AutoSize = true;
            skipAnimationToggle.Location = new Point(3, 119);
            skipAnimationToggle.Name = "skipAnimationToggle";
            skipAnimationToggle.Size = new Size(531, 19);
            skipAnimationToggle.TabIndex = 30;
            skipAnimationToggle.Text = "Skip Initial Animation Loop [EDHE will NOT function correctly without Elite: Dangerous running]\r\n";
            skipAnimationToggle.UseVisualStyleBackColor = true;
            // 
            // displaySettingsLabel
            // 
            displaySettingsLabel.AutoSize = true;
            displaySettingsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            displaySettingsLabel.Location = new Point(7, 3);
            displaySettingsLabel.Name = "displaySettingsLabel";
            displaySettingsLabel.Size = new Size(133, 21);
            displaySettingsLabel.TabIndex = 26;
            displaySettingsLabel.Text = "Display Settings";
            // 
            // uiElementsLabel
            // 
            uiElementsLabel.AutoSize = true;
            uiElementsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiElementsLabel.Location = new Point(7, 71);
            uiElementsLabel.Name = "uiElementsLabel";
            uiElementsLabel.Size = new Size(101, 21);
            uiElementsLabel.TabIndex = 25;
            uiElementsLabel.Text = "UI Elements";
            // 
            // statReadToggle
            // 
            statReadToggle.AutoSize = true;
            statReadToggle.Location = new Point(3, 94);
            statReadToggle.Name = "statReadToggle";
            statReadToggle.Size = new Size(105, 19);
            statReadToggle.TabIndex = 24;
            statReadToggle.Text = "Status Readout";
            statReadToggle.UseVisualStyleBackColor = true;
            // 
            // prefDisplayMenu
            // 
            prefDisplayMenu.FormattingEnabled = true;
            prefDisplayMenu.Location = new Point(114, 31);
            prefDisplayMenu.Name = "prefDisplayMenu";
            prefDisplayMenu.Size = new Size(350, 23);
            prefDisplayMenu.TabIndex = 21;
            // 
            // prefDisplayLabel
            // 
            prefDisplayLabel.AutoSize = true;
            prefDisplayLabel.Location = new Point(15, 34);
            prefDisplayLabel.Name = "prefDisplayLabel";
            prefDisplayLabel.Size = new Size(96, 15);
            prefDisplayLabel.TabIndex = 20;
            prefDisplayLabel.Text = "Preferred Display";
            // 
            // soundTab
            // 
            soundTab.BackColor = SystemColors.Control;
            soundTab.Location = new Point(4, 24);
            soundTab.Name = "soundTab";
            soundTab.Size = new Size(768, 369);
            soundTab.TabIndex = 2;
            soundTab.Text = "Sound";
            // 
            // inaraTab
            // 
            inaraTab.BackColor = SystemColors.Control;
            inaraTab.Location = new Point(4, 24);
            inaraTab.Name = "inaraTab";
            inaraTab.Padding = new Padding(3);
            inaraTab.Size = new Size(768, 369);
            inaraTab.TabIndex = 4;
            inaraTab.Text = "Inara";
            // 
            // capiTab
            // 
            capiTab.BackColor = SystemColors.Control;
            capiTab.Controls.Add(capiDisconnectButton);
            capiTab.Controls.Add(capiConnectButton);
            capiTab.Controls.Add(capiAccountTag);
            capiTab.Controls.Add(capiAccountLabel);
            capiTab.Controls.Add(capiStatusTag);
            capiTab.Controls.Add(capiStatusLabel);
            capiTab.Location = new Point(4, 24);
            capiTab.Name = "capiTab";
            capiTab.Padding = new Padding(3);
            capiTab.Size = new Size(768, 369);
            capiTab.TabIndex = 8;
            capiTab.Text = "cAPI";
            // 
            // capiDisconnectButton
            // 
            capiDisconnectButton.Enabled = false;
            capiDisconnectButton.Location = new Point(6, 65);
            capiDisconnectButton.Name = "capiDisconnectButton";
            capiDisconnectButton.Size = new Size(208, 23);
            capiDisconnectButton.TabIndex = 23;
            capiDisconnectButton.Text = "Disconnect from Frontier Account";
            capiDisconnectButton.UseVisualStyleBackColor = true;
            capiDisconnectButton.Click += capiDisconnectButton_Click;
            // 
            // capiConnectButton
            // 
            capiConnectButton.Location = new Point(6, 36);
            capiConnectButton.Name = "capiConnectButton";
            capiConnectButton.Size = new Size(208, 23);
            capiConnectButton.TabIndex = 22;
            capiConnectButton.Text = "Connect to Frontier Account";
            capiConnectButton.UseVisualStyleBackColor = true;
            capiConnectButton.Click += capiConnectButton_Click;
            // 
            // capiAccountTag
            // 
            capiAccountTag.AutoSize = true;
            capiAccountTag.Location = new Point(154, 18);
            capiAccountTag.Name = "capiAccountTag";
            capiAccountTag.Size = new Size(25, 15);
            capiAccountTag.TabIndex = 21;
            capiAccountTag.Text = "n/a";
            // 
            // capiAccountLabel
            // 
            capiAccountLabel.AutoSize = true;
            capiAccountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            capiAccountLabel.Location = new Point(3, 18);
            capiAccountLabel.Name = "capiAccountLabel";
            capiAccountLabel.Size = new Size(125, 15);
            capiAccountLabel.TabIndex = 20;
            capiAccountLabel.Text = "Connected Account : ";
            // 
            // capiStatusTag
            // 
            capiStatusTag.AutoSize = true;
            capiStatusTag.Location = new Point(154, 3);
            capiStatusTag.Name = "capiStatusTag";
            capiStatusTag.Size = new Size(78, 15);
            capiStatusTag.TabIndex = 18;
            capiStatusTag.Text = "disconnected";
            // 
            // capiStatusLabel
            // 
            capiStatusLabel.AutoSize = true;
            capiStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            capiStatusLabel.Location = new Point(3, 3);
            capiStatusLabel.Name = "capiStatusLabel";
            capiStatusLabel.Size = new Size(145, 15);
            capiStatusLabel.TabIndex = 17;
            capiStatusLabel.Text = "cAPI Connection Status : ";
            // 
            // helpTab
            // 
            helpTab.BackColor = SystemColors.Control;
            helpTab.Location = new Point(4, 24);
            helpTab.Name = "helpTab";
            helpTab.Size = new Size(768, 369);
            helpTab.TabIndex = 3;
            helpTab.Text = "Help";
            // 
            // restartButton
            // 
            restartButton.Location = new Point(93, 415);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(75, 23);
            restartButton.TabIndex = 3;
            restartButton.Text = "Restart";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += restartButton_Click;
            // 
            // checkUpdateButton
            // 
            checkUpdateButton.Location = new Point(174, 415);
            checkUpdateButton.Name = "checkUpdateButton";
            checkUpdateButton.Size = new Size(129, 23);
            checkUpdateButton.TabIndex = 4;
            checkUpdateButton.Text = "Check for Updates";
            checkUpdateButton.UseVisualStyleBackColor = true;
            checkUpdateButton.Click += checkUpdateButton_Click;
            // 
            // uiTab
            // 
            uiTab.BackColor = SystemColors.Control;
            uiTab.Controls.Add(pageTabControl);
            uiTab.Location = new Point(4, 24);
            uiTab.Name = "uiTab";
            uiTab.Size = new Size(768, 369);
            uiTab.TabIndex = 9;
            uiTab.Text = "User Interface";
            // 
            // pageTabControl
            // 
            pageTabControl.Controls.Add(genPageTab);
            pageTabControl.Controls.Add(homePageTab);
            pageTabControl.Controls.Add(combatPageTab);
            pageTabControl.Controls.Add(explorationPagTab);
            pageTabControl.Controls.Add(missionsPageTab);
            pageTabControl.Controls.Add(stationsPageTab);
            pageTabControl.Location = new Point(3, 3);
            pageTabControl.Name = "pageTabControl";
            pageTabControl.SelectedIndex = 0;
            pageTabControl.Size = new Size(768, 369);
            pageTabControl.TabIndex = 0;
            // 
            // genPageTab
            // 
            genPageTab.BackColor = SystemColors.Control;
            genPageTab.Controls.Add(genPageLabel);
            genPageTab.Controls.Add(autoSwitchToggle);
            genPageTab.Location = new Point(4, 24);
            genPageTab.Name = "genPageTab";
            genPageTab.Padding = new Padding(3);
            genPageTab.Size = new Size(760, 341);
            genPageTab.TabIndex = 0;
            genPageTab.Text = "General";
            // 
            // homePageTab
            // 
            homePageTab.BackColor = SystemColors.Control;
            homePageTab.Controls.Add(homePageLabel);
            homePageTab.Location = new Point(4, 24);
            homePageTab.Name = "homePageTab";
            homePageTab.Padding = new Padding(3);
            homePageTab.Size = new Size(760, 341);
            homePageTab.TabIndex = 1;
            homePageTab.Text = "Home";
            // 
            // combatPageTab
            // 
            combatPageTab.BackColor = SystemColors.Control;
            combatPageTab.Controls.Add(combatPageLabel);
            combatPageTab.Controls.Add(combatSwitchToggle);
            combatPageTab.Location = new Point(4, 24);
            combatPageTab.Name = "combatPageTab";
            combatPageTab.Size = new Size(760, 341);
            combatPageTab.TabIndex = 2;
            combatPageTab.Text = "Combat";
            // 
            // explorationPagTab
            // 
            explorationPagTab.BackColor = SystemColors.Control;
            explorationPagTab.Controls.Add(explorationPageLabel);
            explorationPagTab.Location = new Point(4, 24);
            explorationPagTab.Name = "explorationPagTab";
            explorationPagTab.Size = new Size(760, 341);
            explorationPagTab.TabIndex = 3;
            explorationPagTab.Text = "Exploration";
            // 
            // missionsPageTab
            // 
            missionsPageTab.BackColor = SystemColors.Control;
            missionsPageTab.Controls.Add(missionsPageLabel);
            missionsPageTab.Location = new Point(4, 24);
            missionsPageTab.Name = "missionsPageTab";
            missionsPageTab.Size = new Size(760, 341);
            missionsPageTab.TabIndex = 4;
            missionsPageTab.Text = "Missions";
            // 
            // stationsPageTab
            // 
            stationsPageTab.BackColor = SystemColors.Control;
            stationsPageTab.Controls.Add(stationsPageLabel);
            stationsPageTab.Location = new Point(4, 24);
            stationsPageTab.Name = "stationsPageTab";
            stationsPageTab.Size = new Size(760, 341);
            stationsPageTab.TabIndex = 5;
            stationsPageTab.Text = "Stationing";
            // 
            // autoShutdownToggle
            // 
            autoShutdownToggle.AutoSize = true;
            autoShutdownToggle.Location = new Point(6, 184);
            autoShutdownToggle.Name = "autoShutdownToggle";
            autoShutdownToggle.Size = new Size(240, 19);
            autoShutdownToggle.TabIndex = 30;
            autoShutdownToggle.Text = "Close Application when Elite shuts down";
            autoShutdownToggle.UseVisualStyleBackColor = true;
            // 
            // autoSwitchToggle
            // 
            autoSwitchToggle.AutoSize = true;
            autoSwitchToggle.Location = new Point(6, 27);
            autoSwitchToggle.Name = "autoSwitchToggle";
            autoSwitchToggle.Size = new Size(172, 19);
            autoSwitchToggle.TabIndex = 28;
            autoSwitchToggle.Text = "Switch Pages Automatically";
            autoSwitchToggle.UseVisualStyleBackColor = true;
            // 
            // combatSwitchToggle
            // 
            combatSwitchToggle.AutoSize = true;
            combatSwitchToggle.Location = new Point(3, 24);
            combatSwitchToggle.Name = "combatSwitchToggle";
            combatSwitchToggle.Size = new Size(239, 19);
            combatSwitchToggle.TabIndex = 29;
            combatSwitchToggle.Text = "Switch Panels Automatically for Combat";
            combatSwitchToggle.UseVisualStyleBackColor = true;
            // 
            // genPageLabel
            // 
            genPageLabel.AutoSize = true;
            genPageLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            genPageLabel.Location = new Point(3, 0);
            genPageLabel.Name = "genPageLabel";
            genPageLabel.Size = new Size(177, 21);
            genPageLabel.TabIndex = 29;
            genPageLabel.Text = "General Page Settings";
            // 
            // homePageLabel
            // 
            homePageLabel.AutoSize = true;
            homePageLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            homePageLabel.Location = new Point(6, 0);
            homePageLabel.Name = "homePageLabel";
            homePageLabel.Size = new Size(164, 21);
            homePageLabel.TabIndex = 30;
            homePageLabel.Text = "Home Page Settings";
            // 
            // combatPageLabel
            // 
            combatPageLabel.AutoSize = true;
            combatPageLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            combatPageLabel.Location = new Point(3, 0);
            combatPageLabel.Name = "combatPageLabel";
            combatPageLabel.Size = new Size(178, 21);
            combatPageLabel.TabIndex = 30;
            combatPageLabel.Text = "Combat Page Settings";
            // 
            // explorationPageLabel
            // 
            explorationPageLabel.AutoSize = true;
            explorationPageLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            explorationPageLabel.Location = new Point(3, 0);
            explorationPageLabel.Name = "explorationPageLabel";
            explorationPageLabel.Size = new Size(207, 21);
            explorationPageLabel.TabIndex = 30;
            explorationPageLabel.Text = "Exploration Page Settings";
            // 
            // missionsPageLabel
            // 
            missionsPageLabel.AutoSize = true;
            missionsPageLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            missionsPageLabel.Location = new Point(3, 0);
            missionsPageLabel.Name = "missionsPageLabel";
            missionsPageLabel.Size = new Size(184, 21);
            missionsPageLabel.TabIndex = 30;
            missionsPageLabel.Text = "Missions Page Settings";
            // 
            // stationsPageLabel
            // 
            stationsPageLabel.AutoSize = true;
            stationsPageLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stationsPageLabel.Location = new Point(3, 0);
            stationsPageLabel.Name = "stationsPageLabel";
            stationsPageLabel.Size = new Size(198, 21);
            stationsPageLabel.TabIndex = 30;
            stationsPageLabel.Text = "Stationing Page Settings";
            // 
            // pathSettingsLabel
            // 
            pathSettingsLabel.AutoSize = true;
            pathSettingsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pathSettingsLabel.Location = new Point(6, 0);
            pathSettingsLabel.Name = "pathSettingsLabel";
            pathSettingsLabel.Size = new Size(142, 21);
            pathSettingsLabel.TabIndex = 31;
            pathSettingsLabel.Text = "File Path Settings";
            // 
            // miscLabel
            // 
            miscLabel.AutoSize = true;
            miscLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            miscLabel.Location = new Point(6, 160);
            miscLabel.Name = "miscLabel";
            miscLabel.Size = new Size(115, 21);
            miscLabel.TabIndex = 33;
            miscLabel.Text = "Misc. Settings";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkUpdateButton);
            Controls.Add(restartButton);
            Controls.Add(settingsTabControl);
            Controls.Add(applyButton);
            Controls.Add(closeButton);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            settingsTabControl.ResumeLayout(false);
            genTab.ResumeLayout(false);
            genTab.PerformLayout();
            dispTab.ResumeLayout(false);
            dispTab.PerformLayout();
            capiTab.ResumeLayout(false);
            capiTab.PerformLayout();
            uiTab.ResumeLayout(false);
            pageTabControl.ResumeLayout(false);
            genPageTab.ResumeLayout(false);
            genPageTab.PerformLayout();
            homePageTab.ResumeLayout(false);
            homePageTab.PerformLayout();
            combatPageTab.ResumeLayout(false);
            combatPageTab.PerformLayout();
            explorationPagTab.ResumeLayout(false);
            explorationPagTab.PerformLayout();
            missionsPageTab.ResumeLayout(false);
            missionsPageTab.PerformLayout();
            stationsPageTab.ResumeLayout(false);
            stationsPageTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button closeButton;
        private Button applyButton;
        private TabControl settingsTabControl;
        private TabPage genTab;
        private Label defJournalPathLabel;
        private Button pathBrowseButton;
        private TextBox journalPathTextbox;
        private Label pathBrowserLabel;
        private TabPage dispTab;
        private ComboBox prefDisplayMenu;
        private Label prefDisplayLabel;
        private TabPage soundTab;
        private TabPage helpTab;
        private CheckBox statReadToggle;
        private Label displaySettingsLabel;
        private Label uiElementsLabel;
        private Label defGamelPathLabel;
        private Button gameBrowseButton;
        private TextBox gamePathTextbox;
        private Label gpBrowserLabel;
        private TabPage inaraTab;
        private Button restartButton;
        private Button checkUpdateButton;
        private TabPage capiTab;
        private Label capiStatusTag;
        private Label capiStatusLabel;
        private Label capiAccountTag;
        private Label capiAccountLabel;
        private Button capiDisconnectButton;
        private Button capiConnectButton;
        private CheckBox skipAnimationToggle;
        private TabPage uiTab;
        private TabControl pageTabControl;
        private TabPage genPageTab;
        private TabPage homePageTab;
        private TabPage combatPageTab;
        private TabPage explorationPagTab;
        private TabPage missionsPageTab;
        private TabPage stationsPageTab;
        private CheckBox autoShutdownToggle;
        private CheckBox autoSwitchToggle;
        private CheckBox combatSwitchToggle;
        private Label genPageLabel;
        private Label homePageLabel;
        private Label combatPageLabel;
        private Label explorationPageLabel;
        private Label missionsPageLabel;
        private Label stationsPageLabel;
        private Label pathSettingsLabel;
        private Label miscLabel;
    }
}