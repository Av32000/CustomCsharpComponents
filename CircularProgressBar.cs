using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace ParsePass.CustomsComponents
{
    internal class CircularProgressBar : UserControl
    {
        float val = 0;
        float max = 100;
        Color progressColor = Color.ForestGreen, backgroundColor = Color.Black;
        bool showPercent;

        [Category("Custom Appearance")]
        public float Value { get { return val; } set { if (value > max) { val = max; } else { val = value; } Invalidate(); } }
        [Category("Custom Appearance")]
        public float Max { get { return max; } set { max = value; Invalidate(); } }
        [Category("Custom Appearance")]
        public bool ShowPercent { get { return showPercent; } set { showPercent = value; Invalidate(); } }
        [Category("Custom Appearance")]
        public Color ProgressColor { get { return progressColor; } set { progressColor = value; Invalidate(); } }
        [Category("Custom Appearance")]
        public Color BackgroundColor { get { return backgroundColor; } set { backgroundColor = value; Invalidate(); } }

        public CircularProgressBar()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int currentVal = (int)((val*100) / max);
            Graphics g = e.Graphics;
            Pen pen = new Pen(progressColor, 6) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            g.FillPie(new SolidBrush(backgroundColor), new Rectangle(8,8,Width-16,Height-16),0,360);
            g.DrawArc(pen, new Rectangle(5, 5, Width - 10, Height - 10),-90,(val/max)*360);

            if (ShowPercent)
            {
                StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment= StringAlignment.Center };
                g.DrawString(currentVal + "%", Font, new SolidBrush(ForeColor), ClientRectangle,sf);
            }
            base.OnPaint(e);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            if (Width <= 40)
            {
                Width = 40;
            }
            Height = Width;
            base.OnSizeChanged(e);
        }
    }
}
