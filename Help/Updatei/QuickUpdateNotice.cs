using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Updatei
{
    class QuickUpdateNotice : MyUpdate
    {
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
