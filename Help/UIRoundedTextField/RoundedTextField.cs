using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Help
{
    class RoundedTextField : Control
    {
        private string text;

        public string Text

        {

            get { return textBox.Text; }

            set { textBox.Text = value; }

        }



        TextBox textBox = new TextBox();

        public RoundedTextField()

        {

       
            this.Resize += new EventHandler(UserControl1_Resize);

            textBox.Multiline = true;

            textBox.BorderStyle = BorderStyle.None;

          
           //textBox.Margin = new Padding(3,3,3,3);

            textBox.BackColor = Color.FromArgb(255, 240, 240, 240);
            this.BackColor = Color.FromArgb(255, 240, 240, 240);

            textBox.GotFocus += TextBox_GotFocus;
            textBox.LostFocus += TextBox_LostFocus;
            

            this.Controls.Add(textBox);

        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            textBox.BackColor = Color.FromArgb(255, 230, 230, 230);
            this.BackColor = Color.FromArgb(255, 230, 230, 230);
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            textBox.BackColor = Color.FromArgb(255, 240, 240, 240);
            this.BackColor = Color.FromArgb(255, 240, 240, 240);
        }

        private void UserControl1_Resize(object sender, EventArgs e)

        {

            textBox.Size = new Size(this.Width - 12, this.Height - 12);

            textBox.Location = new Point(6, 6);


            

        }

       
        /*
        private void UserControl1_Paint(object sender, PaintEventArgs e)

        {

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
             


        }
        */

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);



            RectangleF Rect = this.ClientRectangle;
            using (GraphicsPath GraphPath = GetRoundPath(Rect, 25))
            {
                this.Region = new Region(GraphPath);
                using (Pen pen = new Pen(Color.FromArgb(255, 0, 200, 240), 2.0f))
                {

                    pen.Alignment = PenAlignment.Inset;
                    SmoothingMode old = e.Graphics.SmoothingMode;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, GraphPath);
                    e.Graphics.SmoothingMode = old;
                }


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

    }
}
