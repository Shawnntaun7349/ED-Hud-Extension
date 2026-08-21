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
            label4 = new Label();
            label3 = new Label();
            statReadButton = new CheckBox();
            fullscreenMenu = new ComboBox();
            label2 = new Label();
            prefDisplayMenu = new ComboBox();
            prefDisplayLabel = new Label();
            soundTab = new TabPage();
            helpTab = new TabPage();
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
            dispTab.Controls.Add(label4);
            dispTab.Controls.Add(label3);
            dispTab.Controls.Add(statReadButton);
            dispTab.Controls.Add(fullscreenMenu);
            dispTab.Controls.Add(label2);
            dispTab.Controls.Add(prefDisplayMenu);
            dispTab.Controls.Add(prefDisplayLabel);
            dispTab.Location = new Point(4, 24);
            dispTab.Name = "dispTab";
            dispTab.Padding = new Padding(3);
            dispTab.Size = new Size(768, 369);
            dispTab.TabIndex = 1;
            dispTab.Text = "Display";
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
            label3.Location = new Point(7, 98);
            label3.Name = "label3";
            label3.Size = new Size(101, 21);
            label3.TabIndex = 25;
            label3.Text = "UI Elements";
            // 
            // statReadButton
            // 
            statReadButton.AutoSize = true;
            statReadButton.Location = new Point(3, 121);
            statReadButton.Name = "statReadButton";
            statReadButton.Size = new Size(105, 19);
            statReadButton.TabIndex = 24;
            statReadButton.Text = "Status Readout";
            statReadButton.UseVisualStyleBackColor = true;
            // 
            // fullscreenMenu
            // 
            fullscreenMenu.FormattingEnabled = true;
            fullscreenMenu.Items.AddRange(new object[] { "Fullscreen", "Borderless Windowed" });
            fullscreenMenu.Location = new Point(114, 55);
            fullscreenMenu.Name = "fullscreenMenu";
            fullscreenMenu.Size = new Size(161, 23);
            fullscreenMenu.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 58);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 22;
            label2.Text = "Fullscreen";
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
            prefDisplayLabel.Location = new Point(12, 34);
            prefDisplayLabel.Name = "prefDisplayLabel";
            prefDisplayLabel.Size = new Size(96, 15);
            prefDisplayLabel.TabIndex = 20;
            prefDisplayLabel.Text = "Preferred Display";
            // 
            // soundTab
            // 
            soundTab.Location = new Point(4, 24);
            soundTab.Name = "soundTab";
            soundTab.Size = new Size(768, 369);
            soundTab.TabIndex = 2;
            soundTab.Text = "Sound";
            soundTab.UseVisualStyleBackColor = true;
            // 
            // helpTab
            // 
            helpTab.Location = new Point(4, 24);
            helpTab.Name = "helpTab";
            helpTab.Size = new Size(768, 369);
            helpTab.TabIndex = 3;
            helpTab.Text = "Help";
            helpTab.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
        private ComboBox fullscreenMenu;
        private Label label2;
        private ComboBox prefDisplayMenu;
        private Label prefDisplayLabel;
        private TabPage soundTab;
        private TabPage helpTab;
        private CheckBox statReadButton;
        private Label label4;
        private Label label3;
        private Label label7;
        private Button gameBrowseButton;
        private TextBox gamePathTextbox;
        private Label label6;
    }
}