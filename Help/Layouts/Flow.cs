

using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Help 
{
   public class Flow : LayoutEngine
    {
        private Direction direction;
        public Flow(Direction dir)
        {
            this.direction = dir;
        }
        public override bool Layout(
            object container,
            LayoutEventArgs layoutEventArgs)
        {
            Control parent = container as Control;

            // Use DisplayRectangle so that parent.Padding is honored.
            Rectangle parentDisplayRectangle = parent.DisplayRectangle;
            Point nextControlLocation = parentDisplayRectangle.Location;

            int index = 0;

            foreach (Control c in parent.Controls)
            {
                if (index == 0)
                    nextControlLocation.Y = 5;
                   // nextControlLocation.X = 5;

                // Only apply layout to visible controls.
                if (!c.Visible)
                {
                    continue;
                }

                // Respect the margin of the control:
                // shift over the left and the top.
                nextControlLocation.Offset(c.Margin.Left, c.Margin.Top);

                // Set the location of the control.
                c.Location = nextControlLocation;

                // Set the autosized controls to their 
                // autosized heights.
                if (c.AutoSize)
                {
                    c.Size = c.GetPreferredSize(parentDisplayRectangle.Size);
                }


                //Which Direction verticlly or horizanly
                if (direction == Direction.LeftToRight)
                {
                    
                  

                    // Move X back to the display rectangle origin.
                    nextControlLocation.Y = parentDisplayRectangle.Y;

                    // Increment Y by the height of the control 
                    // and the bottom margin.
                    nextControlLocation.X += c.Width + c.Margin.Right;
                }
                else
                {


                    // Move X back to the display rectangle origin.
                    nextControlLocation.X = parentDisplayRectangle.X;

                    // Increment Y by the height of the control 
                    // and the bottom margin.
                    nextControlLocation.Y += c.Height + c.Margin.Bottom;
                }
                index++;
              
            }

            // Optional: Return whether or not the container's 
            // parent should perform layout as a result of this 
            // layout. Some layout engines return the value of 
            // the container's AutoSize property.

            return false;
        }
    }
}
