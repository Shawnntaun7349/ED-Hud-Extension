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
            pathLabel = new Label();
            pathTextbox = new TextBox();
            browseButton = new Button();
            label1 = new Label();
            settingsLabel = new Label();
            prefDisplayLabel = new Label();
            prefDisplayMenu = new ComboBox();
            label2 = new Label();
            fullscreenMenu = new ComboBox();
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
            // pathLabel
            // 
            pathLabel.AutoSize = true;
            pathLabel.Location = new Point(27, 112);
            pathLabel.Name = "pathLabel";
            pathLabel.Size = new Size(81, 15);
            pathLabel.TabIndex = 2;
            pathLabel.Text = "Journal Folder";
            // 
            // pathTextbox
            // 
            pathTextbox.Location = new Point(114, 109);
            pathTextbox.Name = "pathTextbox";
            pathTextbox.Size = new Size(456, 23);
            pathTextbox.TabIndex = 3;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(576, 108);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(31, 23);
            browseButton.TabIndex = 4;
            browseButton.Text = "...";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 91);
            label1.Name = "label1";
            label1.Size = new Size(543, 15);
            label1.TabIndex = 5;
            label1.Text = "The default Journal folder location is \"...\\[user]\\Saved Games\\Frontier Developments\\Elite Dangerous\"";
            // 
            // settingsLabel
            // 
            settingsLabel.Anchor = AnchorStyles.Top;
            settingsLabel.AutoSize = true;
            settingsLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            settingsLabel.ForeColor = Color.Black;
            settingsLabel.Location = new Point(260, 9);
            settingsLabel.Name = "settingsLabel";
            settingsLabel.Size = new Size(273, 54);
            settingsLabel.TabIndex = 6;
            settingsLabel.Text = "User Settings";
            settingsLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // prefDisplayLabel
            // 
            prefDisplayLabel.AutoSize = true;
            prefDisplayLabel.Location = new Point(12, 141);
            prefDisplayLabel.Name = "prefDisplayLabel";
            prefDisplayLabel.Size = new Size(96, 15);
            prefDisplayLabel.TabIndex = 7;
            prefDisplayLabel.Text = "Preferred Display";
            // 
            // prefDisplayMenu
            // 
            prefDisplayMenu.FormattingEnabled = true;
            prefDisplayMenu.Location = new Point(114, 138);
            prefDisplayMenu.Name = "prefDisplayMenu";
            prefDisplayMenu.Size = new Size(456, 23);
            prefDisplayMenu.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 170);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 10;
            label2.Text = "Fullscreen";
            // 
            // fullscreenMenu
            // 
            fullscreenMenu.FormattingEnabled = true;
            fullscreenMenu.Items.AddRange(new object[] { "Fullscreen", "Borderless Windowed" });
            fullscreenMenu.Location = new Point(114, 167);
            fullscreenMenu.Name = "fullscreenMenu";
            fullscreenMenu.Size = new Size(161, 23);
            fullscreenMenu.TabIndex = 11;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(fullscreenMenu);
            Controls.Add(label2);
            Controls.Add(prefDisplayMenu);
            Controls.Add(prefDisplayLabel);
            Controls.Add(settingsLabel);
            Controls.Add(label1);
            Controls.Add(browseButton);
            Controls.Add(pathTextbox);
            Controls.Add(pathLabel);
            Controls.Add(applyButton);
            Controls.Add(closeButton);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button closeButton;
        private Button applyButton;
        private Label pathLabel;
        private TextBox pathTextbox;
        private Button browseButton;
        private Label label1;
        private Label settingsLabel;
        private Label prefDisplayLabel;
        private ComboBox prefDisplayMenu;
        private Label label2;
        private ComboBox fullscreenMenu;
    }
}