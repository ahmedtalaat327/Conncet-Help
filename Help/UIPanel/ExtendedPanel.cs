


using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Help
{
    public class ExtendedPanel : Panel
    {
        private Flow layoutEngine;
        private const int WS_EX_TRANSPARENT = 0x20;
        private int opacity = 50;
        public  int radius = 0;
        public PanelType Type = PanelType.Normmal;
        private Direction directionOfFlowLayout;

        public ExtendedPanel(int r,PanelType t,Direction dir)
        {
            this.radius = r;this.Type = t;
            this.DoubleBuffered = true;
            this.directionOfFlowLayout = dir;

            if (Type == PanelType.TransparentPanel)
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                SetStyle(ControlStyles.Opaque, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.UserPaint, true);
            }
        }
        public override LayoutEngine LayoutEngine
        {
            get
            {
                if(layoutEngine==null)
                layoutEngine = new Flow(directionOfFlowLayout);

                return layoutEngine;
            }
        }
        protected override CreateParams CreateParams
        {


            get
            {

                if (Type == PanelType.Normmal)
                {
                    CreateParams cp = base.CreateParams;
                    return cp;
                }
                else
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                    return cp;
                }
            }
        }

        GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                             Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
            GraphPath.CloseFigure();
            return GraphPath;
        }


        public int Opacity
        {
            get
            {
                return this.opacity;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("value must be between 0 and 100");
                this.opacity = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Type == PanelType.Normmal)
            {
                base.OnPaint(e);
                RectangleF Rect = new RectangleF(1, 1, this.Width, this.Height);
                if (radius > 0)
                    using (GraphicsPath GraphPath = GetRoundPath(Rect, this.radius))
                    {
                        this.Region = new Region(GraphPath);
                        using (Pen pen = new Pen(Color.FromArgb(40, 5, 5, 5), 0.1f))
                        {
                            Brush br = new SolidBrush(Color.FromArgb(255, 254, 255, 255));
                            pen.Alignment = PenAlignment.Inset;
                            SmoothingMode old = e.Graphics.SmoothingMode;
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.DrawPath(pen, GraphPath);
                            e.Graphics.FillPath(br, GraphPath);
                            e.Graphics.SmoothingMode = old;
                        }
                    }
            }
            else
            {
                using (var brush = new SolidBrush(Color.FromArgb(this.opacity * 255 / 100, this.BackColor)))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
                base.OnPaint(e);
            }
        }


    }
}
