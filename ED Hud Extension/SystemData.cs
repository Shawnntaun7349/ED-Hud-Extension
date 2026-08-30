using OpenTK.Compute.OpenCL;
using System.Diagnostics;
using System.Security.Policy;
using System.Text.Json;

namespace ED_Hud_Extension
{
    public class SystemData //a class for handling planet & system data pulled from EDSM (thank you EDSM)
    {
        public static Label currentItem; //currently selected bodyList item
        public static int currentX; //current x coordinate for appending list items
        public static int currentY; //curent y coordinate for appending list items

        //a whole dickload of class objects for parsing the system data dump from EDSM
        
        public class SolarSystem
        {
            public double? id { get;set; }
            public double? id64 { get;set; }
            public string? name { get;set; }
            public string? url { get;set; }
            public double? bodyCount { get;set; }
            public List<Bodies>? bodies { get;set; }
        }

        public class Bodies
        {
            public double? id { get;set; }
            public double? id64 { get;set; }
            public double? bodyId { get;set; }
            public string? name { get;set; }
            public List<Discovery>? discoveryInfo { get;set; } //discoverer: commander, DoD: DateTime
            public string? type { get;set; }
            public string? subType { get;set; }
            public List<Parent>? parents { get;set; } 
            public float? distanceFromStar { get;set; }
            public bool? isMainStar { get;set; } //for stars only
            public bool? isScoopable { get;set; } //for stars only
            public double? age { get;set; }
            public string? spectralClass { get;set; } //for stars only
            public string? luminosity { get;set; } //for stars only
            public float? absoluteMagnitude { get;set; } //for stars only
            public float? solarMasses { get;set; } //for stars only
            public float? solarRadius { get;set; } //for stars only
            public float? earthMasses { get;set; } //for planets only
            public double? surfaceTemperature { get;set; } 
            public double? orbitalPeriod { get;set; }
            public double? rotationalPeriod { get;set; }
            public List<Belt>? belts { get;set; }
            public bool? isLandable { get;set; } //for planets only
            public float? gravity { get;set; } //for planets only
            public float? radius { get;set; } //for planets only
            public float? surfacePressure { get;set; } //for planets only
            public string? volcanismType { get;set; } //for planets only
            public string? atmosphereType { get;set; } //for planets only
            public Dictionary<string, float>? atmosphereComposition { get;set; } //element : % of composition
            public Dictionary<string, float>? solidComposition { get;set; }//material : % of composition
        }

        public class Belt
        {
            public List<object>? beltList { get;set; }
            public Dictionary<string, float>? beltData {  get;set; }
        }

        public class Discovery
        {
            public string? cmdrName { get;set; }
            public string? dod {  get;set; }
        }

        public class Parent
        {
            public List<object>? parentList { get;set; }
            public Dictionary<string, int>? parentInfo {  get;set; }
        }

        /* Font = Oxanium, Style = Bold, Size = 22.75pt, Initial Location = (0,0), Y offset per item = 36, X offset for subitems is 10, 
         * default color is #C04000, selected color is #FFCC99
         * 
         * 
        */
        public static System.Threading.Timer waitTimer;
        public static Bodies bodies;
        public static SolarSystem system;
        public static Belt belts;
        public static Parent parents;
        public static Discovery discovery;

        public void loadSystemData(Panel panel, string targetSystem)
        {
            panel.SuspendLayout();

            while (panel.Controls.Count > 0)
            {
                foreach (Control control in panel.Controls)
                {
                    control.Dispose();
                }
            }

            currentY = 0;

            string jsonText = File.ReadAllText("C:\\EDHE\\res\\systemdata.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            system = JsonSerializer.Deserialize<SolarSystem>(jsonText, options);
            bodies = JsonSerializer.Deserialize<Bodies>(jsonText, options);
            belts = JsonSerializer.Deserialize<Belt>(jsonText, options);
            parents = JsonSerializer.Deserialize<Parent>(jsonText, options);
            discovery = JsonSerializer.Deserialize<Discovery>(jsonText, options);

            int starCount = 0;

            if (system.bodies is null)
            {

            }
            else
            {
                foreach (var body in system.bodies)
                {
                    if (body.type == "Star") { starCount++; }
                    generateBodyList(panel, $"{body.name}", system);
                }
                var form = ((Control)panel).FindForm();
                form.BeginInvoke(new Action(() => ((MainForm)form).bodyCountTag.Text = system.bodyCount.ToString()));
                form.BeginInvoke(new Action(() => ((MainForm)form).starCountTag.Text = starCount.ToString()));

                panel.ResumeLayout(true);
                panel.Refresh();
            }

        }
        
        public void generateBodyList(Panel targetPanel, string labelText, SolarSystem system)
        {
            if (targetPanel.IsHandleCreated)
            {
                Label dynamicLabel = new Label();
                dynamicLabel.Text = labelText;
                dynamicLabel.AutoSize = true;
                dynamicLabel.ForeColor = ColorTranslator.FromHtml("#C04000");
                dynamicLabel.Font = new Font(Globals.oxaniumFont.Families[0], 23, FontStyle.Bold);
                dynamicLabel.MouseEnter += planetListMouseEnter;
                dynamicLabel.MouseLeave += planetListMouseLeave;
                dynamicLabel.MouseClick += planetListItemSelected;
                int offsetX = 25;

                foreach (var body in system.bodies)
                {
                    if (body.name == labelText)
                    {
                        if (body.parents == null)
                        {
                            dynamicLabel.Location = new Point(currentX, currentY);
                        }
                        else
                        {
                            int i = 0;
                            while (i < body.parents.Count)
                            {
                                offsetX += 25;
                                i++;
                            }
                            dynamicLabel.Location = new Point(offsetX, currentY);
                        }
                    }
                }
                currentY += 40;

                targetPanel.Controls.Add(dynamicLabel);
                targetPanel.Refresh();
            }
        }

        public static void planetListMouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = ColorTranslator.FromHtml("#FFCC99");
        }

        public static void planetListMouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = ColorTranslator.FromHtml("#C04000");
        }

        public void planetListItemSelected(object sender, EventArgs e)
        {
            if (currentItem != null) //set the last item's color back to normal, resubcribe it to the mouse events
            { 
                currentItem.ForeColor = ColorTranslator.FromHtml("#C04000");
                currentItem.MouseEnter += planetListMouseEnter;
                currentItem.MouseLeave += planetListMouseLeave;
            }

            Label lbl = (Label)sender;
            currentItem = lbl; //make this the new current item

            lbl.ForeColor = ColorTranslator.FromHtml("#FFCC99"); //lock the color in, unsubscribe it from events
            lbl.MouseEnter -= planetListMouseEnter;
            lbl.MouseLeave -= planetListMouseLeave;

            //once all that's done, identify what body the user selected

            var form = ((Control)sender).FindForm();
            form.BeginInvoke(new Action(() => ((MainForm)form).detailHiderPanel.Visible = false));
            form.BeginInvoke(new Action(() => ((MainForm)form).loadDetails(lbl.Text, bodies))); //good lord have I learned to hate C# because of this line
        }

    }
}
