using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Calendar.CustomButtons
{
    internal class ModernRoundButton : Button
    {
        private Color _borderColor = Color.FromArgb(200, 200, 200);
        private Color _backgroundColor = Color.FromArgb(66, 226, 184);
        private int _borderWidth = 2;

        [Category("Modern Appearance")]
        public Color BorderColor { get => _borderColor; set { _borderColor = value; this.Invalidate(); } }
        [Category("Modern Appearance")]
        public Color BackgroundColor { get => _backgroundColor; set { _backgroundColor = value; this.Invalidate(); } }
        
        [Category("Modern Appearance")]
        public int BorderWidth { get => _borderWidth; set { _borderWidth = value; this.Invalidate(); } }

        public ModernRoundButton()
        {
            this.ForeColor = Color.White;
            this.Size = new Size(75, 75);
            this.Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //Draw the round background
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
            
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(path);
            pevent.Graphics.FillPath(new SolidBrush(this.BackgroundColor), path);

            //Draw the border
            pevent.Graphics.DrawEllipse(new Pen(this._borderColor,BorderWidth), new Rectangle(0, 0, this.Width - 1, this.Height - 1));

            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, flags);
        }
    }
}
