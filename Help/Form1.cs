
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        //apps to check
        List<RoundedButton> apps = new List<RoundedButton>();
        //apps checker flag
        bool first_time = true;

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
            TableLayoutPanel _TablePanel = new TableLayoutPanel();
            setPopUpWindow(_TablePanel, new Size(200, 70));
            CheckAllEXE();

            DrawingControl.SuspendDrawing(panel1);

            DrawingControl.SuspendDrawing(rightBasePanel);

            foreach (Control item in panel1.Controls.OfType<Control>().ToList())
            {
                if (item.Name == "win")
                {
                    panel1.Controls.Remove(item);
                }
                else if (item.Name == "bg")
                {
                    panel1.Controls.Remove(item);
                }

            }


            DrawingControl.ResumeDrawing(panel1);
            DrawingControl.ResumeDrawing(rightBasePanel);
            rightBasePanel.Refresh();

        }
        private  async Task CheckAllEXE()
        {
            List<string> appsNames = new List<string> { "Connect", "DataExtraction", "ScanConnect", "Utility" };
             
                for (int q = 0; q < appsNames.Count(); q++)
                {
                    var path = GetApplicationRoot() + "\\" + appsNames[q] + ".exe";
                    if (File.Exists(path))
                    {
                        apps[q].found = true;
                    }
                }
            first_time = false;


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
            titl1.Margin = new Padding(5, 0, 10, 5);
            titl1.Text = "Check for VC++ in this PC.";
            titl1.Size = new Size(250, 24);

            _tl.Controls.Add(titl1);


            RoundedButton vcsetup = new RoundedButton();

            vcsetup.Size = new Size(400, 35);
            var fnt = new Font("Arial", 10, FontStyle.Bold);
            vcsetup.Font = fnt;
            vcsetup.Text = "Setup 'Connect' environment dependencies";
            vcsetup.MouseClick += Vcsetup_MouseClick;

            vcsetup.Padding = new Padding(10,5,5,5);
            _tl.Controls.Add(vcsetup);


            Info.Controls.Add(_tl);

            p1.Controls.Add(Info);


            _TablePanel.Controls.Add(p1);


            //Second PAne Comps
            TableLayoutPanel upperMenu = new TableLayoutPanel();
            
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
            if (first_time)
            {
                apps.Clear();

                apps.Add(r1);
                apps.Add(r2);
                apps.Add(r3);
                apps.Add(r4);
            }


            int column = 3;
            int row = 2;
            var incPadd = 5;
            upperMenu.Size = new Size(120 * 3 + column * 2 * incPadd, 120 * 2 + row * 2 * incPadd);
            upperMenu.BackColor = Color.Red;
            upperMenu.RowCount = 2;
            upperMenu.ColumnCount = 3;
            upperMenu.BackColor = p1.colorUsed;
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

        private void Vcsetup_MouseClick(object sender, MouseEventArgs e)
        {
            TableLayoutPanel _TablePanel = new TableLayoutPanel();
            _TablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25f));
            _TablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25f));
            _TablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25f));
            _TablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25f));
            _TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0f));

            _TablePanel.RowCount = 3;
            _TablePanel.ColumnCount = 1;

           

            var fnt = new Font("Arial", 10, FontStyle.Bold);
            Label title = new Label()
            {
                Text = "You need to install the following:",
                Font = fnt,
                Size = new Size(500, _TablePanel.Height / 4),
                Margin = new Padding(0, 5, 0, 0)
            };
            _TablePanel.Controls.Add(title);

            RoundedButton vcsetup_32 = new RoundedButton();
            vcsetup_32.Size = new Size(300, 32);
            vcsetup_32.Font = fnt;
            vcsetup_32.Text = "Install VC_redist.x86.exe";
            vcsetup_32.MouseClick += Vcsetup_32_MouseClick;
            vcsetup_32.Padding = new Padding(10, 5, 5, 5);
            _TablePanel.Controls.Add(vcsetup_32);

            RoundedButton vcsetup_64 = new RoundedButton();
            vcsetup_64.Size = new Size(300, 32);
            vcsetup_64.Font = fnt;
            vcsetup_64.Text = "Install VC_redist.x64.exe";
            vcsetup_64.MouseClick += Vcsetup_64_MouseClick;
            vcsetup_64.Padding = new Padding(10, 5, 5, 5);
            _TablePanel.Controls.Add(vcsetup_64);

            RoundedButton close = new RoundedButton();
            close.Size = new Size(65, 32);
            close.Font = fnt;
            close.Text = "Done";
            close.Padding = new Padding(10, 5, 5, 5);
            close.MouseClick += Close_MouseClick;
            _TablePanel.Controls.Add(close);

            setPopUpWindow(_TablePanel, new Size(400, 200));
        }

        private void Vcsetup_64_MouseClick(object sender, MouseEventArgs e)
        {
            var path = GetApplicationRoot() + "\\asset\\" + "VC_redist.x64.exe";
            Process.Start(path);
        }

        private void Vcsetup_32_MouseClick(object sender, MouseEventArgs e)
        {
            var path = GetApplicationRoot() + "\\asset\\" + "VC_redist.x86.exe";
            Process.Start(path);
        }

        private void Close_MouseClick(object sender, MouseEventArgs e)
        {
            DrawingControl.SuspendDrawing(panel1);

            DrawingControl.SuspendDrawing(rightBasePanel);

            foreach (Control item in panel1.Controls.OfType<Control>().ToList())
            {
                if (item.Name == "win")
                {
                    panel1.Controls.Remove(item);               
                }
               else  if (item.Name == "bg")
                {
                    panel1.Controls.Remove(item);
                }
               
            }
         
            
            DrawingControl.ResumeDrawing(panel1);
            DrawingControl.ResumeDrawing(rightBasePanel);
            rightBasePanel.Refresh();
          
        }

        private void setThirdOptionComps()
        {
            ExtendedPanel p1 = new ExtendedPanel(35, PanelType.Normmal, Direction.TopToDown);
            p1.Size = new Size(rightBasePanel.Width, rightBasePanel.Height * 2 / 3);
            // p1.Controls.Add(paneOfBaloon);
            rightBasePanel.Controls.Add(p1);

            var fnt = new Font("Arial", 10, FontStyle.Bold);
            Label title = new Label()
            {
                Text = "Thanks in advance, please explane your problem..",
                Font = fnt,
                Size = new Size(500, 30),
                Margin = new Padding(15, 10, 0, 0),
                BackColor = p1.colorUsed
            };
            p1.Controls.Add(title);

            RoundedTextField test = new RoundedTextField();
            test.Size = new Size(p1.Width-30, 200);
            test.Font = new Font("Arial", 11, FontStyle.Regular);
            test.Margin = new Padding(15,5,10,10);
            test.Name = "Field";
            p1.Controls.Add(test);

            RoundedButton sendfeed = new RoundedButton();

            sendfeed.Size = new Size(140, 30);
             
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


            setPopUpWindow(null,new Size(400, 200));
        }

        private void removeAllChildsForRightBasePane()
        {
            var all = rightBasePanel.Controls;
            foreach(var item in all)
            {
                rightBasePanel.Controls.Remove((Control)item);
            }
        }

        private void setPopUpWindow(Panel contentPane,Size size)
        {
            DrawingControl.SuspendDrawing(panel1);

            ExtendedPanel panDisabling = new ExtendedPanel(35, PanelType.Normmal, Direction.LeftToRight);
            panDisabling.Size = size;
            panDisabling.BackColor = Color.FromArgb(200, this.BackColor);
            panDisabling.Location = new Point(((panel1.Width-panDisabling.Width)/2), ((panel1.Height - panDisabling.Height) / 2));
            panDisabling.Name = "win";
            panel1.Controls.Add(panDisabling);
            if (contentPane != null){
                contentPane.Margin = new Padding(20);
                contentPane.Size = new Size(panDisabling.Width - 40, panDisabling.Height - 40);
                contentPane.BackColor = panDisabling.BackColor;
                panDisabling.Controls.Add(contentPane);
            }
            //Lower appears above (first)
            Panel backGround = new Panel();
            backGround.BackColor = Color.LightGray;
            backGround.Size = new Size(panel1.Size.Width-23, panel1.Size.Height-45);
            backGround.Name = "bg";
          //  backGround.colorUsed = Color.FromArgb(255, 234, 234, 244);
            backGround.BackgroundImage =  Image.FromFile($"asset/emojibg.png");
            panel1.Controls.Add(backGround);

            
            panel1.Controls.SetChildIndex(backGround, 1);
            panel1.Controls.SetChildIndex(panDisabling, 0);
            
            //
            basePanel.BringToFront();
            backGround.BringToFront();
            panDisabling.BringToFront();
            DrawingControl.ResumeDrawing(panel1);
        }

        public static string GetApplicationRoot()
        {
            var workingDirectory = Environment.CurrentDirectory;
            string pathToExe = $"{workingDirectory}";
            return pathToExe;
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
