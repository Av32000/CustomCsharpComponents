using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Calendar.ToggleSwitchButton
{
    internal class ToggleSwitch : CheckBox
    {
        //Fields
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;
        
        [Category("Toggle Appearance")]
        public Color OnBackColor { get => onBackColor; set { onBackColor = value; this.Invalidate(); } }
        [Category("Toggle Appearance")]
        public Color OnToggleColor { get => onToggleColor; set { onToggleColor = value; this.Invalidate(); } }
        [Category("Toggle Appearance")]
        public Color OffBackColor { get => offBackColor; set { offBackColor = value; this.Invalidate(); } }
        [Category("Toggle Appearance")]
        public Color OffToggleColor { get => offToggleColor; set { offToggleColor = value; this.Invalidate(); } }

        public override string Text
        {
            get => base.Text;
            set
            {
                
            }
        }
        
        [Category("Toggle Appearance")]
        [DefaultValue(true)]
        public bool SolidStyle { get => solidStyle; set { solidStyle = value; this.Invalidate(); } }

        //Constructor
        public ToggleSwitch()
        {
            this.MinimumSize = new Size(45, 22);
        }

        //Methods
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize -2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            this.AutoSize = false;
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if (this.Checked)
            {
                //Draw the control surface
                if (solidStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), this.GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(onBackColor), this.GetFigurePath());
                }
                //Draw the control toggle
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else
            {
                if (solidStyle)
                {
                    //Draw the control surface
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), this.GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(offBackColor), this.GetFigurePath());
                }
                //Draw the control toggle
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
