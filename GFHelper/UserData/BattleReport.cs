using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GFHelper.UserData
{
    class BattleReport
    {
        private bool Using = false;
        public bool isUsing
        {
            get
            {
                return Using;
            }
            set
            {
                Using = value;
            }
        }
        public int StartTime;//utx
        public int continuedTime;
        public int remaining_time
        {
            get
            {
                DateTime t = new DateTime(1970, 1, 1);
                double second = (DateTime.UtcNow - t).TotalSeconds;
                return StartTime + continuedTime - (int)second;
            }
        }
        public bool isFinish
        {
            get
            {
                if (remaining_time < 0) return true;
                return false;
            }
        }



    }
}
