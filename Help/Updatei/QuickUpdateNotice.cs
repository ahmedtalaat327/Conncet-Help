using System;

namespace Help.Updatei
{
    class QuickUpdateNotice : MyUpdate
    {

        private string RealivePath { get; set; } = Form1.GetApplicationRoot();

        public QuickUpdateNotice(string appName)
        {

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
