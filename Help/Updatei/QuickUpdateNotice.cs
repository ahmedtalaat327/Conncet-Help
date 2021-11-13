using System.Drawing;
using System.Windows.Forms;

namespace Help.Updatei
{
    class QuickUpdateNotice : MyUpdate
    {

        private string RealivePath { get; set; } = Form1.GetApplicationRoot();

        private int  _width = 450;
        private int  _height = 300;

        public QuickUpdateNotice(Form mainForm, string [] appNames)
        {
            TableLayoutPanel _TablePanel = new TableLayoutPanel();
            for (int x = 0; x < appNames.Length + 1; x++)
            {
                _TablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0f));
                if (x != 0)
                {
                    _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0f));
                    _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.0f));
                    _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0f));
                    _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0f));
                }
                else
                {
                    _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.0f));
                }
            }

      
            _TablePanel.RowCount = appNames.Length+1;
            _TablePanel.ColumnCount = 4;
            _TablePanel.Size = new Size(_width-20, _height-20);

            Label titl1 = new Label();
            titl1.Font = new Font("Arial", 11, FontStyle.Bold);
           // titl1.Margin = new Padding(1);
            titl1.Text = "Update Centre.";
            titl1.Size = new Size(_width, _height/(appNames.Length + 1));
            _TablePanel.Controls.Add(titl1);

            foreach(var icon in appNames)
            {
                //each block create here
                //|---icon---|-------name------|---button---|--state--|

            }

            Form1.setPopUpWindow(_TablePanel, new Size(_width, _height));
        }

        public override bool MyUpdate_CheckForMe(string nameofapp, int cversion)
        {
            return false;
        }

        public override void MyUpdate_GrabNextVersion()
        {
            
        }
        private Panel CreateUpdateBlock(string text)
        {
            return null;
        }
      
    }
}
