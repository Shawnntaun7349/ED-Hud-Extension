using System;
using System.Collections.Generic;
using System.Text;
using ED_Hud_Extension;
using static Globals;
using static ED_Hud_Extension.MainForm;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ED_Hud_Extension
{
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
                int panelY = formSize.Height - 60;
                int panelX = formSize.Width;
                panel.Size = new Size(panelX, panelY);
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
                int panelY = formSize.Height - 196;
                panel.RowStyles[5].Height = panelY;
            }
            if (panel.Name == "constDisplayPanel")
            {
                int sizeX = formSize.Width - 108;
                panel.Size = new Size(formSize.Width - 108, panel.Height);
            }
        }

        public static void setWorkingArea(Panel panel) 
        {
            panel.Width = formSize.Width - 108;
            panel.Height = formSize.Height - (134 + 34);
            panel.Location = new Point(110, 137);
            foreach (Panel subPanel in panel.Controls.OfType<Panel>())
            {
                if (subPanel.Tag == "workingAreaPanel")
                {
                    subPanel.Width = panel.Width;
                    subPanel.Height = panel.Height;
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
                    c.Size = new Size(c.Size.Width, panel.Height);
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
                    c.Size = new Size(panel.Size.Width - c.Location.X, panel.Height);
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
                    c.Size = new Size(mainPanel.Size.Width, c.Height);
                    c.Location = new Point(0, c.Location.Y);
                }
            }

            foreach (Control c in ofPanel.Controls)
            {
                if (c.Name == "ofDivPanel")
                {
                    c.Size = new Size(ofPanel.Size.Width, c.Height);
                    c.Location = new Point(0, c.Location.Y);
                }
            }
        }
    }
}
