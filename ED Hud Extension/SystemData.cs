using System.Text.Json;
using System.Text.Json.Serialization;

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
            public Discovery? discovery { get;set; } //discoverer: commander, DoD: DateTime
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
            public float? orbitalPeriod { get;set; } 
            public float? rotationalPeriod { get;set; }
            public List<Belt>? belts { get;set; }
            public List<Ring>? rings { get; set; }
            public bool? isLandable { get;set; } //for planets only
            public float? gravity { get;set; } //for planets only
            public float? radius { get;set; } //for planets only
            public float? surfacePressure { get;set; } //for planets only
            public string? volcanismType { get;set; } //for planets only
            public string? atmosphereType { get;set; } //for planets only
            public Atmosphere? atmosphereComposition { get;set; } //element : % of composition
            public Composition? solidComposition { get;set; }//material : % of composition
        }

        public class Atmosphere
        {
            public double ammonia { get; set; }
            public double argon { get; set; }

            [JsonPropertyName("Carbon dioxide")]
            public double carbonDioxide { get; set; }
            public double helium { get; set; }
            public double hydrogen { get; set; }
            public double iron { get; set; }
            public double methane { get; set; }
            public double neon { get; set; }
            public double nitrogen { get; set; }
            public double oxygen { get; set; }
            public double silicates { get; set; }

            [JsonPropertyName("Sulphur dioxide")]
            public double sulphurDioxide { get; set; }
            public double water { get; set; }
        }

        public class Composition
        {
            public double rock { get; set; }
            public double metal { get; set; }
            public double ice { get; set; }
        }

        public class Ring
        {
            public string name { get; set; }
            public string type { get; set; }
            public long mass { get; set; }
            public int innerRadius { get; set; }
            public int outerRadius { get; set; }
        }

        public class Belt
        {
            public string name { get; set; }
            public string type { get; set; }
            public long mass { get; set; }
            public int innerRadius { get; set; }
            public int outerRadius { get; set; }
        }

        public class Discovery
        {
            public string? commander { get;set; }
            public string? date {  get;set; }
        }

        public class Parent
        {
            public List<object>? parentList { get;set; }
        }

        public static Bodies bodies;
        public static SolarSystem system;
        public static Belt belts;
        public static Ring rings;
        public static Parent parents;
        public static Discovery discovery;
        public static Composition composition;
        public static Atmosphere atmosphere;

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
            discovery = JsonSerializer.Deserialize<Discovery>(jsonText, options);
            bodies = JsonSerializer.Deserialize<Bodies>(jsonText, options);
            parents = JsonSerializer.Deserialize<Parent>(jsonText, options);
            composition = JsonSerializer.Deserialize<Composition>(jsonText, options);

            belts = JsonSerializer.Deserialize<Belt>(jsonText, options);
            rings = JsonSerializer.Deserialize<Ring>(jsonText, options);
            atmosphere = JsonSerializer.Deserialize<Atmosphere>(jsonText, options);

            int starCount = 0;

            if (system.bodies is null)
            {
                foreach(Label lbl in panel.Controls)
                {
                    if (lbl.Tag == "systemDataErrorLabel")
                    {
                        lbl.Invoke(new Action(() => lbl.Visible = true));
                    }
                }
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
                
                //panel.Size = new Size(panel.Width, (DisplayHandler.requiredSize(panel, "Height")));

                panel.ResumeLayout(true);
                panel.Refresh();
            }

        }
        
        public void generateBodyList(Panel targetPanel, string labelText, SolarSystem system)
        {
            if (targetPanel.IsHandleCreated)
            {
                targetPanel.SuspendLayout();

                Label dynamicLabel = new Label();
                dynamicLabel.Text = labelText;
                dynamicLabel.Tag = "listItem";
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
                dynamicLabel.Anchor = AnchorStyles.Top;
                targetPanel.Controls.Add(dynamicLabel);
                dynamicLabel.CreateControl();
            }

            targetPanel.ResumeLayout(true);

            targetPanel.PerformLayout();
        }

        public static void planetListMouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = ColorTranslator.FromHtml("#FFCC99");
            lbl.Cursor = Cursors.Hand; //this is just to emulate the LabelButton control used elsewhere, cos this is a shitload easier than using actual LabelButtons for readability issues
            
        }

        public static void planetListMouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = ColorTranslator.FromHtml("#C04000");
            lbl.Cursor = Cursors.Default;
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
            
            //lock the color in, unsubscribe it from events
            lbl.MouseEnter -= planetListMouseEnter;
            lbl.MouseLeave -= planetListMouseLeave;
            lbl.ForeColor = ColorTranslator.FromHtml("#FFCC99");

            //once all that's done, identify what body the user selected

            var form = ((Control)sender).FindForm();
            form.BeginInvoke(new Action(() => ((MainForm)form).detailHiderPanel.SendToBack()));
            form.BeginInvoke(new Action(() => ((MainForm)form).loadDetails(lbl.Text, bodies))); //good lord have I learned to hate C# because of this line
        }

    }
}
