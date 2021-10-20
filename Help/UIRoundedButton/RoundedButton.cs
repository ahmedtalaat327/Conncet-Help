using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Help
{
    class RoundedButton : Label
    {
        private Image loadedImage;
        public string img_name { get; set; } = "";
        public string app_title { get; set; } = "";
        public bool found { get; set; } = false;

        public bool asGroupeItem { get; set; } = false;

        public RoundedButton()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.White;

            this.MouseUp += RoundedButton_MouseUp; ;
            this.MouseDown += RoundedButton_MouseDown;
        }

        private void RoundedButton_MouseUp(object sender, MouseEventArgs e)
        {
            if(!asGroupeItem)
            this.BackColor = Color.White;
            this.Refresh();
        }

        private void RoundedButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (!asGroupeItem)
            {
                this.BackColor = Color.DarkGray;
                this.Refresh();
            }
            else
            {
                foreach (var item in this.Parent.Controls)
                {
                    if (((RoundedButton)item).Name == "groupemenu")
                    {
                        ((RoundedButton)item).BackColor = Color.White;
                    }

                }
                this.BackColor = Color.DarkGray;
            }
        }

     

        GraphicsPath GetRoundPath(RectangleF rectangle, int cornerRadius)
        {
           // fint cornerRadius = 15; // change this value according to your needs
            int diminisher = 1;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(rectangle.X + rectangle.Width - cornerRadius - diminisher, rectangle.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(rectangle.X + rectangle.Width - cornerRadius - diminisher, rectangle.Y + rectangle.Height - cornerRadius - diminisher, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius - diminisher, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);

          

            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            using (GraphicsPath GraphPath = GetRoundPath(Rect, 21))
            {
                this.Region = new Region(GraphPath);
                using (Pen pen = new Pen(Color.FromArgb(255,0,200,240), 2.0f))
                {

                    pen.Alignment = PenAlignment.Inset;
                    SmoothingMode old = e.Graphics.SmoothingMode;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, GraphPath);
                    e.Graphics.SmoothingMode = old;
                }

            
            }

            if (img_name.Length > 0)
            {
                loadedImage = Image.FromFile($"asset/{img_name}");
                Image verfied;
                if (found)
                  verfied = Image.FromFile($"asset/tick.png");
                else verfied = Image.FromFile($"asset/errp.png");

                using (var src = ((Bitmap)loadedImage))
                using (var bmp = new Bitmap(100, 100, PixelFormat.Format32bppPArgb))
                using (var src_ = ((Bitmap)verfied))
                using (var bmp_ = new Bitmap(20, 20, PixelFormat.Format32bppPArgb))
                using (var gr = Graphics.FromImage(bmp))
                {
                    // gr.Clear(Color.Blue);
                    e.Graphics.DrawImage(src, new Rectangle(10, 2, bmp.Width, bmp.Height));
                   
                    var fnt = new Font("Arial", 10, FontStyle.Bold);
                 

                    StringFormat newStringFormat = new StringFormat();
                    newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                    SizeF stringSize = new SizeF();
                    stringSize = e.Graphics.MeasureString(app_title, fnt, 110, newStringFormat);

                    float x = (120 - stringSize.Height) / 2;
                    float y = 100;

                    Brush  br = new SolidBrush(Color.FromArgb(255, 80, 82, 82));

                    e.Graphics.DrawString(app_title, fnt,br, new PointF(x,y));
                    
                    e.Graphics.DrawImage(src_, new Rectangle(this.Size.Width-25, 5, bmp_.Width, bmp_.Height));
                  
                }
            }

        }
    }
}
