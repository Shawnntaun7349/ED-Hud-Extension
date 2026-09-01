using System;
using System.Collections.Generic;
using System.Text;

namespace ED_Hud_Extension
{
    internal class Designs
    {
        public class CustomProgressBar : ProgressBar
        {
            public CustomProgressBar()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
                if (ProgressBarRenderer.IsSupported)
                {
                    ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

                    double scaleFactor = ((double)Value - (double)Minimum) / ((double)Maximum - (double)Minimum);
                    rec.Width = (int)((rec.Width * scaleFactor) - 4);
                    rec.Height -= 4;

                    using (var brush = new SolidBrush(this.ForeColor))
                    {
                        e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
                    }
                }
            }
        }
    }
}
