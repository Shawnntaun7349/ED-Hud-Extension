using static Globals;

namespace ED_Hud_Extension
{
    /* a class made to handle all the fun math that comes with resizing the form and ensuring that the ui still works. 
    *  var formSize is a Size object stored in the Globals class that determines the size of the MainForm based on the 
    *  user's set display preference. everything else, math-wise, is based on those values.
    */ 
    internal class DisplayHandler
    {
        public static void centerPanel(Panel panel)
        {
            if (panel.Name == "innerInitPanel")
            {
                int panelX = panel.Size.Width;
                int panelY = panel.Size.Height;
                panel.Location = new Point(
                      (formSize.Width - panelX) / 2,
                      ((formSize.Height - panelY) / 2) - 50
                );
            }
        }

        public static void resizePanels(Panel panel)
        {
            if (panel.Name == "initPanel")
            {
                panel.Size = new Size(formSize.Width, formSize.Height - 60);
            }

            if (panel.Name == "dividerPanel")
            {
                panel.Size = new Size(panel.Size.Width, formSize.Height);
            }
        }

        public static void resizeControlsPanel(TableLayoutPanel panel)
        {
            if (panel.Name == "ControlsPanel")
            {
                panel.RowStyles[5].Height = formSize.Height - 196; //196 is the combined height of all the other buttons of the control panel, so this line
                                                                   //keeps the Settings and Terminate buttons on the bottom when the size is changed from screen to screen
            }
            if (panel.Name == "constDisplayPanel")
            {
                panel.Size = new Size(formSize.Width - 108, panel.Height); //108 is the left side offset of the controls panel, with the menu buttons
            }
        }

        public static void setWorkingArea(Panel panel) 
        {
            panel.Location = new Point(110, 137); //110 & 137 provide a good offset from the top and left panels, while allowing for their divider panels for aesthic cohesion
            panel.Size = new Size(formSize.Width - 108, formSize.Height - 137);
            foreach (Panel subPanel in panel.Controls.OfType<Panel>())
            {
                if (subPanel.Tag == "workingAreaPanel")
                {
                    subPanel.Size = panel.Size;
                    subPanel.Location = new Point(0, 0);
                }
            }
        }

        public static void arrangeExplorePanel(Panel panel)
        {
            foreach (Control c in panel.Controls)
            {
                if (c.Name == "exploreDivider")
                {
                    c.Size = new Size(c.Width, panel.Height);
                    c.Location = new Point(((panel.Width * 2) / 3), 0);
                }

                if (c.Name == "bodiesDivPanel")
                {
                    c.Size = new Size(panel.Width - (panel.Width / 3), c.Height);
                    c.Location = new Point(0, c.Location.Y);
                }

                if (c.Tag == "planetDetailList")
                {
                    c.Location = new Point(((panel.Width * 2) / 3) + 5, 0);
                    c.Size = new Size(panel.Width - c.Location.X, panel.Height - 20);
                }

                if (c.Name == "bodyListPanel")
                {
                    c.Size = new Size(c.Width, panel.Height - c.Location.X);
                }
            }
        }

        public static void arrangeCombatPanel(Panel mainPanel, Panel ofPanel)
        {
            ofPanel.Size = mainPanel.Size;
            ofPanel.Location = mainPanel.Location;

            foreach (Control c in mainPanel.Controls)
            {
                if (c.Name == "combatPanelDivider")
                {
                    c.Size = new Size(mainPanel.Width, c.Height);
                    c.Location = new Point(0, c.Location.Y);
                }
            }

            foreach (Control c in ofPanel.Controls)
            {
                if (c.Name == "ofDivPanel")
                {
                    c.Size = new Size(ofPanel.Width, c.Height);
                    c.Location = new Point(0, c.Location.Y);
                }
            }
        }
    }
}
