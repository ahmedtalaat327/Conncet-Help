using System.Drawing;
using System.Windows.Forms;

namespace Help.Updatei
{
    class QuickUpdateNotice : MyUpdate
    {

        private string RealivePath { get; set; } = Form1.GetApplicationRoot();

        public QuickUpdateNotice(Form mainForm, string appName)
        {
            TableLayoutPanel _TablePanel = new TableLayoutPanel();
            Form1.setPopUpWindow(_TablePanel, new Size(400, 200));
        }

        public override bool MyUpdate_CheckForMe(string nameofapp, int cversion)
        {
            return false;
        }

        public override void MyUpdate_GrabNextVersion()
        {
            
        }

      
    }
}
