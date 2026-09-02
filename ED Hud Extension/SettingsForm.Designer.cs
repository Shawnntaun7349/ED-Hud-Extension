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
            label7 = new Label();
            gameBrowseButton = new Button();
            gamePathTextbox = new TextBox();
            label6 = new Label();
            label1 = new Label();
            pathBrowseButton = new Button();
            journalPathTextbox = new TextBox();
            pathLabel = new Label();
            dispTab = new TabPage();
            autoShutdownToggle = new CheckBox();
            combatSwitchToggle = new CheckBox();
            autoSwitchToggle = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            statReadToggle = new CheckBox();
            prefDisplayMenu = new ComboBox();
            prefDisplayLabel = new Label();
            soundTab = new TabPage();
            inaraTab = new TabPage();
            edsmTab = new TabPage();
            spanshTab = new TabPage();
            edmcTab = new TabPage();
            helpTab = new TabPage();
            restartButton = new Button();
            checkUpdateButton = new Button();
            settingsTabControl.SuspendLayout();
            genTab.SuspendLayout();
            dispTab.SuspendLayout();
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
            settingsTabControl.Controls.Add(inaraTab);
            settingsTabControl.Controls.Add(edsmTab);
            settingsTabControl.Controls.Add(spanshTab);
            settingsTabControl.Controls.Add(edmcTab);
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
            genTab.Controls.Add(label7);
            genTab.Controls.Add(gameBrowseButton);
            genTab.Controls.Add(gamePathTextbox);
            genTab.Controls.Add(label6);
            genTab.Controls.Add(label1);
            genTab.Controls.Add(pathBrowseButton);
            genTab.Controls.Add(journalPathTextbox);
            genTab.Controls.Add(pathLabel);
            genTab.Location = new Point(4, 24);
            genTab.Name = "genTab";
            genTab.Padding = new Padding(3);
            genTab.Size = new Size(768, 369);
            genTab.TabIndex = 0;
            genTab.Text = "General";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 3);
            label7.Name = "label7";
            label7.Size = new Size(694, 30);
            label7.TabIndex = 20;
            label7.Text = "The default game path is \r\n\"C:\\Program Files (x86)\\Steam\\steamapps\\common\\Elite Dangerous\\Products\\elite-dangerous-odyssey-64\\EliteDangerous64.exe\"";
            // 
            // gameBrowseButton
            // 
            gameBrowseButton.Location = new Point(555, 35);
            gameBrowseButton.Name = "gameBrowseButton";
            gameBrowseButton.Size = new Size(31, 23);
            gameBrowseButton.TabIndex = 18;
            gameBrowseButton.Text = "...";
            gameBrowseButton.UseVisualStyleBackColor = true;
            // 
            // gamePathTextbox
            // 
            gamePathTextbox.Location = new Point(93, 36);
            gamePathTextbox.Name = "gamePathTextbox";
            gamePathTextbox.Size = new Size(456, 23);
            gamePathTextbox.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 39);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 16;
            label6.Text = "Elite EXE";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 77);
            label1.Name = "label1";
            label1.Size = new Size(543, 15);
            label1.TabIndex = 15;
            label1.Text = "The default Journal folder location is \"...\\[user]\\Saved Games\\Frontier Developments\\Elite Dangerous\"";
            // 
            // pathBrowseButton
            // 
            pathBrowseButton.Location = new Point(555, 95);
            pathBrowseButton.Name = "pathBrowseButton";
            pathBrowseButton.Size = new Size(31, 23);
            pathBrowseButton.TabIndex = 14;
            pathBrowseButton.Text = "...";
            pathBrowseButton.UseVisualStyleBackColor = true;
            // 
            // journalPathTextbox
            // 
            journalPathTextbox.Location = new Point(93, 95);
            journalPathTextbox.Name = "journalPathTextbox";
            journalPathTextbox.Size = new Size(456, 23);
            journalPathTextbox.TabIndex = 13;
            // 
            // pathLabel
            // 
            pathLabel.AutoSize = true;
            pathLabel.Location = new Point(6, 99);
            pathLabel.Name = "pathLabel";
            pathLabel.Size = new Size(81, 15);
            pathLabel.TabIndex = 12;
            pathLabel.Text = "Journal Folder";
            // 
            // dispTab
            // 
            dispTab.BackColor = SystemColors.Control;
            dispTab.Controls.Add(autoShutdownToggle);
            dispTab.Controls.Add(combatSwitchToggle);
            dispTab.Controls.Add(autoSwitchToggle);
            dispTab.Controls.Add(label4);
            dispTab.Controls.Add(label3);
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
            // autoShutdownToggle
            // 
            autoShutdownToggle.AutoSize = true;
            autoShutdownToggle.Location = new Point(3, 235);
            autoShutdownToggle.Name = "autoShutdownToggle";
            autoShutdownToggle.Size = new Size(240, 19);
            autoShutdownToggle.TabIndex = 29;
            autoShutdownToggle.Text = "Close Application when Elite shuts down";
            autoShutdownToggle.UseVisualStyleBackColor = true;
            // 
            // combatSwitchToggle
            // 
            combatSwitchToggle.AutoSize = true;
            combatSwitchToggle.Location = new Point(3, 210);
            combatSwitchToggle.Name = "combatSwitchToggle";
            combatSwitchToggle.Size = new Size(239, 19);
            combatSwitchToggle.TabIndex = 28;
            combatSwitchToggle.Text = "Switch Panels Automatically for Combat";
            combatSwitchToggle.UseVisualStyleBackColor = true;
            // 
            // autoSwitchToggle
            // 
            autoSwitchToggle.AutoSize = true;
            autoSwitchToggle.Location = new Point(3, 185);
            autoSwitchToggle.Name = "autoSwitchToggle";
            autoSwitchToggle.Size = new Size(175, 19);
            autoSwitchToggle.TabIndex = 27;
            autoSwitchToggle.Text = "Switch Panels Automatically";
            autoSwitchToggle.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(7, 3);
            label4.Name = "label4";
            label4.Size = new Size(133, 21);
            label4.TabIndex = 26;
            label4.Text = "Display Settings";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(7, 137);
            label3.Name = "label3";
            label3.Size = new Size(101, 21);
            label3.TabIndex = 25;
            label3.Text = "UI Elements";
            // 
            // statReadToggle
            // 
            statReadToggle.AutoSize = true;
            statReadToggle.Location = new Point(3, 160);
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
            prefDisplayMenu.Size = new Size(456, 23);
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
            // edsmTab
            // 
            edsmTab.BackColor = SystemColors.Control;
            edsmTab.Location = new Point(4, 24);
            edsmTab.Name = "edsmTab";
            edsmTab.Size = new Size(768, 369);
            edsmTab.TabIndex = 5;
            edsmTab.Text = "EDSM";
            // 
            // spanshTab
            // 
            spanshTab.BackColor = SystemColors.Control;
            spanshTab.Location = new Point(4, 24);
            spanshTab.Name = "spanshTab";
            spanshTab.Size = new Size(768, 369);
            spanshTab.TabIndex = 6;
            spanshTab.Text = "Spansh";
            // 
            // edmcTab
            // 
            edmcTab.BackColor = SystemColors.Control;
            edmcTab.Location = new Point(4, 24);
            edmcTab.Name = "edmcTab";
            edmcTab.Size = new Size(768, 369);
            edmcTab.TabIndex = 7;
            edmcTab.Text = "EDMC";
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
            ResumeLayout(false);
        }

        #endregion

        private Button closeButton;
        private Button applyButton;
        private TabControl settingsTabControl;
        private TabPage genTab;
        private Label label1;
        private Button pathBrowseButton;
        private TextBox journalPathTextbox;
        private Label pathLabel;
        private TabPage dispTab;
        private ComboBox prefDisplayMenu;
        private Label prefDisplayLabel;
        private TabPage soundTab;
        private TabPage helpTab;
        private CheckBox statReadToggle;
        private Label label4;
        private Label label3;
        private Label label7;
        private Button gameBrowseButton;
        private TextBox gamePathTextbox;
        private Label label6;
        private CheckBox combatSwitchToggle;
        private CheckBox autoSwitchToggle;
        private CheckBox autoShutdownToggle;
        private TabPage inaraTab;
        private TabPage edsmTab;
        private TabPage spanshTab;
        private TabPage edmcTab;
        private Button restartButton;
        private Button checkUpdateButton;
    }
}