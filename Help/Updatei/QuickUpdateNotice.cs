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
              
            }
            _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.0f));

            _TablePanel.RowCount = appNames.Length+1;
            _TablePanel.ColumnCount = 1;
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
                _TablePanel.Controls.Add(CreateUpdateBlock(icon));

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
            TableLayoutPanel _TablePanel = new TableLayoutPanel();
            _TablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0f));
            _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0f));
            _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.0f));
            _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0f));
            _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            _TablePanel.RowCount =  1;
            _TablePanel.ColumnCount = 4;

            //cretae icon
            Image loadedImage = Image.FromFile($"asset/balooon.png");
            Panel paneOfBaloon = new Panel();
            paneOfBaloon.BackgroundImage = (loadedImage);
            paneOfBaloon.Size = new Size(85, 100);
            paneOfBaloon.BackColor = Color.FromArgb(255, 254, 255, 255);
            //create lbl
            Label titl1 = new Label();
            titl1.Font = new Font("Arial", 11, FontStyle.Bold);
            // titl1.Margin = new Padding(1);
            titl1.Text = "xxxxxxxxxxxx.";
            titl1.Size = new Size(_width, 20);
          
            //create another lbl

            //create rbutton



            _TablePanel.Controls.Add(paneOfBaloon);
            _TablePanel.Controls.Add(titl1);
            return _TablePanel;
        }
      
    }
}
