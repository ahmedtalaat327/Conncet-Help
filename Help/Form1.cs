
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Help
{
    public partial class Form1 : Form
    {
        //Panel1 _ GridPnel 2 columns and 1 row
        public static TableLayoutPanel basePanel = new TableLayoutPanel();


        //Left base panel
        public static ExtendedPanel leftBasePanel = new ExtendedPanel(35, PanelType.Normmal, Direction.TopToDown);


        //right base panel
        public static Panel rightBasePanel = new Panel();


       

        private static List<RoundedButton> menuItems = new List<RoundedButton>();
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;



            //BasePanel Panel1 companion!
            basePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0f));
            basePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0f));
            basePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.0f));
            basePanel.RowCount = 1;
            basePanel.ColumnCount = 2;
            basePanel.Location = new Point(0, 0);
            basePanel.Size = panel1.Size;
            panel1.Controls.Add(basePanel);
            //Left BasePanel 

            leftBasePanel.Size = new Size((panel1.Width / 2) - 10, panel1.Height - 55);
            leftBasePanel.Margin = new Padding(5, 5, 2, 5);
            basePanel.Controls.Add(leftBasePanel);
            panel1.Controls.SetChildIndex(basePanel, 2);

            //buttons of leftBasePanel
            RoundedButton overView_option = new RoundedButton();
            overView_option.asGroupeItem = true;
            overView_option.Size = new Size(leftBasePanel.Size.Width - 25, 34);
            overView_option.Padding = new Padding(20, 8, 5, 6);
            overView_option.Margin = new Padding(14, 5, 10, 5);
            var fnt = new Font("Arial", 10, FontStyle.Bold);
            overView_option.Font = fnt;
            overView_option.Text = "Overview";
            overView_option.BackColor = Color.DarkGray;
            overView_option.Name = "groupemenu";
            overView_option.MouseClick += OverView_option_MouseClick;

            RoundedButton documentation_option = new RoundedButton();
            documentation_option.asGroupeItem = true;
            documentation_option.Size = new Size(leftBasePanel.Size.Width - 25, 34);
            documentation_option.Padding = new Padding(20, 8, 5, 6);
            documentation_option.Margin = new Padding(14, 5, 10, 5);
            documentation_option.Font = fnt;
            documentation_option.Text = "Documentation";
            documentation_option.Name = "groupemenu";
            documentation_option.MouseClick += Documentation_option_MouseClick;

            RoundedButton help_option = new RoundedButton();
            help_option.asGroupeItem = true;
            help_option.Size = new Size(leftBasePanel.Size.Width - 25, 34);
            help_option.Padding = new Padding(20, 8, 5, 6);
            help_option.Margin = new Padding(14, 5, 10, 5);
            help_option.Font = fnt;
            help_option.Text = "Feedback";
            help_option.Name = "groupemenu";
            help_option.MouseClick += Help_option_MouseClick;

            menuItems.Add(overView_option);
            menuItems.Add(documentation_option);
            menuItems.Add(help_option);

            foreach (var item in menuItems) {
                leftBasePanel.Controls.Add(item);
            }


            //Right BasePanel
            rightBasePanel.Size = new Size((panel1.Width * 2 / 3) - 30, panel1.Height - 55);
            rightBasePanel.Margin = new Padding(3, 5, 5, 10);
            basePanel.Controls.Add(rightBasePanel);


            DrawingControl.SuspendDrawing(rightBasePanel);
            setFirstOptionComps();
            DrawingControl.ResumeDrawing(rightBasePanel);



            //Console.WriteLine(Form1.GetApplicationRoot());

            panel1.Controls.SetChildIndex(basePanel, 1);
           
           
        }

        private void Help_option_MouseClick(object sender, MouseEventArgs e)
        {
            removeAllChildsForRightBasePane();
            DrawingControl.SuspendDrawing(rightBasePanel);
            setThirdOptionComps();
            DrawingControl.ResumeDrawing(rightBasePanel);

        }

        private void Documentation_option_MouseClick(object sender, MouseEventArgs e)
        {
            removeAllChildsForRightBasePane();
        }

        private void OverView_option_MouseClick(object sender, MouseEventArgs e)
        {

            removeAllChildsForRightBasePane();
            DrawingControl.SuspendDrawing(rightBasePanel);
            setFirstOptionComps();
            DrawingControl.ResumeDrawing(rightBasePanel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void setFirstOptionComps()
        {


            TableLayoutPanel _TablePanel = new TableLayoutPanel();
            _TablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.3f));
            _TablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.7f));
            _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0f));
         
            _TablePanel.RowCount = 2;
            _TablePanel.ColumnCount = 1;
            _TablePanel.Location = new Point(0, 0);
            _TablePanel.Size = rightBasePanel.Size;
            rightBasePanel.Controls.Add(_TablePanel);

            //First Pane Comps
            Image loadedImage = Image.FromFile($"asset/balooon.png");
            Panel paneOfBaloon = new Panel();
            paneOfBaloon.BackgroundImage = (loadedImage);
            paneOfBaloon.Size = new Size(85, 100);
            paneOfBaloon.BackColor = Color.FromArgb(255, 254, 255, 255);
            ExtendedPanel p1 = new ExtendedPanel(35, PanelType.Normmal, Direction.LeftToRight);
            p1.Size = new Size(rightBasePanel.Width, rightBasePanel.Height*1/3);
            p1.Controls.Add(paneOfBaloon);
            TableLayoutPanel Info = new TableLayoutPanel();
            //Info.BackColor = Color.Gray;
            Info.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));
            Info.RowStyles.Add(new ColumnStyle(SizeType.Percent, 1.0f));
            Info.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0f));
            Info.RowCount = 2;
            Info.ColumnCount = 1;
            Info.Margin = new Padding(5,15,5,15);
            Info.Size = new Size(p1.Width-85, p1.Height);
            Info.BackColor = Color.FromArgb(255, 254, 255, 255);


            Label title = new Label();
            title.Font = new Font("Arial", 12, FontStyle.Bold);
            title.Margin = new Padding(5, 5, 5, 1);
            title.Text = "Welcome to Help Connect App.";
            title.Size = new Size(300, 20);

            Info.Controls.Add(title);

           

            TableLayoutPanel _tl = new TableLayoutPanel();
            _tl.RowStyles.Add(new RowStyle(SizeType.Percent, 0.4f));
            _tl.RowStyles.Add(new RowStyle(SizeType.Percent, 0.6f));
            _tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0f));

            _tl.RowCount = 2;
            _tl.ColumnCount = 1;

            _tl.Size = new Size(342, 50);

            Label titl1 = new Label();
            titl1.Font = new Font("Arial", 9, FontStyle.Bold);
            titl1.Margin = new Padding(5, 0, 5, 5);
            titl1.Text = "Check for VC++ in this PC.";
            titl1.Size = new Size(250, 24);

            _tl.Controls.Add(titl1);


            RoundedButton vcsetup = new RoundedButton();

            vcsetup.Size = new Size(400, 50);
            var fnt = new Font("Arial", 10, FontStyle.Bold);
            vcsetup.Font = fnt;
            vcsetup.Text = "Setup 'Connect' environment dependencies";

            vcsetup.Padding = new Padding(10,5,5,5);
            _tl.Controls.Add(vcsetup);


            Info.Controls.Add(_tl);

            p1.Controls.Add(Info);


            _TablePanel.Controls.Add(p1);


            //Second PAne Comps
            TableLayoutPanel upperMenu = new TableLayoutPanel();
            List<RoundedButton> apps = new List<RoundedButton>();
            RoundedButton r1 = new RoundedButton();
            r1.img_name = "connect-app256.png";
            r1.app_title = "Connect App.";
            RoundedButton r2 = new RoundedButton();
            r2.img_name = "connect-service256.png";
            r2.app_title = "ScanConnect.";
            RoundedButton r3 = new RoundedButton();
            r3.img_name = "utility_logo_256.png";
            r3.app_title = "Utility.";
            RoundedButton r4 = new RoundedButton();
            r4.img_name = "da-ext256.png";
            r4.app_title = "DataExtraction.";

             
            apps.Add(r1);
            apps.Add(r2);
            apps.Add(r3);
            apps.Add(r4);



            int column = 3;
            int row = 2;
            var incPadd = 5;
            upperMenu.Size = new Size(120 * 3 + column * 2 * incPadd, 120 * 2 + row * 2 * incPadd);
            upperMenu.BackColor = Color.Red;
            upperMenu.RowCount = 2;
            upperMenu.ColumnCount = 3;
            upperMenu.BackColor = Color.Transparent;
            upperMenu.Margin = new Padding(45, 20, 5, 5);
            foreach (var item in apps)
            {


                item.Size = new Size(120, 120);
                item.Margin = new Padding(5);
                upperMenu.Controls.Add(item);


            }

            ExtendedPanel p2 = new ExtendedPanel(35, PanelType.Normmal, Direction.LeftToRight);
             
            p2.Size = new Size(rightBasePanel.Width, rightBasePanel.Height*2/3);
            p2.Controls.Add(upperMenu);
            _TablePanel.Controls.Add(p2);

 
         
        }

        private void setThirdOptionComps()
        {
            ExtendedPanel p1 = new ExtendedPanel(35, PanelType.Normmal, Direction.TopToDown);
            p1.Size = new Size(rightBasePanel.Width, rightBasePanel.Height * 2 / 3);
            // p1.Controls.Add(paneOfBaloon);
            rightBasePanel.Controls.Add(p1);
            RoundedTextField test = new RoundedTextField();
            test.Size = new Size(p1.Width-30, 230);
            test.Font = new Font("Arial", 11, FontStyle.Regular);
            test.Margin = new Padding(15);
            test.Name = "Field";
            p1.Controls.Add(test);

            RoundedButton sendfeed = new RoundedButton();

            sendfeed.Size = new Size(140, 30);
            var fnt = new Font("Arial", 10, FontStyle.Bold);
            sendfeed.Font = fnt;
            sendfeed.Text = "Send Feedback";
            sendfeed.Margin = new Padding(15,0,5,5);
            sendfeed.Padding = new Padding(10, 5, 5, 5);
            sendfeed.MouseClick += Sendfeed_MouseClick;
            p1.Controls.Add(sendfeed);

        }

        private void Sendfeed_MouseClick(object sender, MouseEventArgs e)
        {
            var parent = ((RoundedButton)(sender)).Parent;
            foreach(Control item in parent.Controls)
            {
                if (item.Name == "Field")
                {
                    ((RoundedTextField)item).Enabled = false;
                }
            }


            setDisableWindow(null,new Size(400, 200));
        }

        private void removeAllChildsForRightBasePane()
        {
            var all = rightBasePanel.Controls;
            foreach(var item in all)
            {
                rightBasePanel.Controls.Remove((Control)item);
            }
        }

        private void setDisableWindow(Panel contentPane,Size size)
        {
            ExtendedPanel panDisabling = new ExtendedPanel(35, PanelType.Normmal, Direction.LeftToRight);
            panDisabling.Size = size;
            panDisabling.BackColor = Color.FromArgb(200, this.BackColor);
            panDisabling.Location = new Point(((panel1.Width-panDisabling.Width)/2), ((panel1.Height - panDisabling.Height) / 2));
            panel1.Controls.Add(panDisabling);
            if (contentPane != null){
                contentPane.Size = panDisabling.Size;
                panDisabling.Controls.Add(contentPane);
            }
            //Lower appears above (first)
            ExtendedPanel backGround = new ExtendedPanel(1,PanelType.Normmal,Direction.LeftToRight);
            backGround.BackColor = Color.LightGray;
            backGround.Size = panel1.Size;
            panel1.Controls.Add(backGround);

            panel1.Controls.SetChildIndex(backGround, 1);
            panel1.Controls.SetChildIndex(panDisabling, 0);
            
            //
            basePanel.BringToFront();
            backGround.BringToFront();
            panDisabling.BringToFront();
        }

        public static string GetApplicationRoot()
        {
            var exePath = new Uri(System.Reflection.
            Assembly.GetExecutingAssembly().CodeBase).LocalPath;

            return new FileInfo(exePath).DirectoryName;

        }

    }

    class DrawingControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
    }
}
