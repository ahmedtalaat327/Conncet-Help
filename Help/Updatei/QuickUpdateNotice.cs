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
            for (int x = 0; x < appNames.Length + 2; x++)
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
                var panecol = CreateUpdateBlock(icon);
                panecol.Size = _TablePanel.Size;
                _TablePanel.Controls.Add(panecol);

            }

            RoundedButton done = new RoundedButton();

            done.Size = new Size(80, 35);
            var fnt = new Font("Arial", 10, FontStyle.Bold);
            done.Font = fnt;
            done.Text = "Done";
            // vcsetup.MouseClick += Vcsetup_MouseClick;
            done.Margin = new Padding(10, 0, 0, 0);
            done.Padding = new Padding(15, 8, 5, 5);

            _TablePanel.Controls.Add(done);

            Form1.setPopUpWindow(_TablePanel, _TablePanel.Size);
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
            paneOfBaloon.Size = new Size(_TablePanel.Size.Height, _TablePanel.Size.Height);
            paneOfBaloon.BackColor = Color.FromArgb(255, 254, 255, 255);
            //create lbl
            Label titl1 = new Label();
            titl1.Font = new Font("Arial", 11, FontStyle.Bold);
            titl1.Padding = new Padding(4);
            titl1.Text = text+".";
            titl1.Size = new Size(_TablePanel.Size.Width, _TablePanel.Size.Height);
            titl1.BackColor = Color.Red;
            //create another lbl

            //create rbutton



            _TablePanel.Controls.Add(paneOfBaloon);
            _TablePanel.Controls.Add(titl1);
            return _TablePanel;
        }
      
    }
}
