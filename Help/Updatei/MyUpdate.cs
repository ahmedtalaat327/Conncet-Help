using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Updatei
{
    public abstract class MyUpdate
    {

        /// <summary>
        /// Check for update intially
        /// </summary>
        /// <returns></returns>
        public virtual bool MyUpdate_CheckForMe(string nameofapp,int cversion) {
            return false;
        }

        public virtual void MyUpdate_GrapNextVersion()
        {

        }



    }
}
