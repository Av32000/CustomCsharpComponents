using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Calendar.CustomButtons
{
    internal class ModernButton : Button
    {
        private Color _borderColor = Color.FromArgb(200,200,200);
        private Color _backgroundColor = Color.FromArgb(66, 226, 184);

        [Category("Modern Appearance")]
        public Color BorderColor { get => _borderColor; set { _borderColor = value; this.Invalidate(); } }
        [Category("Modern Appearance")]
        public Color BackgroundColor { get => _backgroundColor; set { _backgroundColor = value; this.Invalidate(); } }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            pevent.Graphics.FillRectangle(new SolidBrush(_backgroundColor), this.ClientRectangle);
            pevent.Graphics.DrawRectangle(new Pen(this._borderColor), new Rectangle(0, 0, this.Width - 1, this.Height - 1));

            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, flags);
        }

        public ModernButton()
        {
            this.ForeColor = Color.White;
            this.Cursor = Cursors.Hand;
        }
    }

    
}
