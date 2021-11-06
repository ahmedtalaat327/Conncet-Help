

using System;

namespace Help.Updatei
{
    public abstract class MyUpdate
    {


        /// <summary>
        /// Check for update intially
        /// </summary>
        /// <returns></returns>
        public virtual bool MyUpdate_CheckForMe(string nameofapp, int cversion) {
            return false;
        }
        /// <summary>
        /// Get current update then compare to check if there something to be graped!
        /// </summary>
        public virtual void MyUpdate_GrabNextVersion()
        {

        }



     

    }
}
