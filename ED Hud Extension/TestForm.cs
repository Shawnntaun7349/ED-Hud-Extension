using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ED_Hud_Extension
{
    public partial class TestForm : Form
    {
        private static float sweepAngle = 90;
        private static string currentColor = "blue";

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            ResizeRedraw = true;

            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, 50, 50);
            float startAngle = 0;

            startAngle += 5;

            if (currentColor == "blue") //draw it in green
            {
                using (Pen pen = new Pen(Color.Green, 4))
                {
                    e.Graphics.DrawArc(pen, rect, startAngle, sweepAngle);
                }
            }
            else //draw it in blue
            {
                using (Pen pen = new Pen(Color.Blue, 4))
                {
                    e.Graphics.DrawArc(pen, rect, startAngle, sweepAngle);
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sweepAngle += 5;
            if (sweepAngle >= 360)
            {
                sweepAngle = 0;
                if (currentColor == "blue")
                {
                    currentColor = "green";
                }
                else
                {
                    currentColor = "blue";
                }
            }

            Invalidate();
        }
    }
}
