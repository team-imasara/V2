using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe
{
    class GameData
    {
        public static int GetCurrentTimeStamp()
        {
            return Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds - (double)GameData.realtimeSinceLogin + (double)GameData.loginTime);
        }

        public static int realtimeSinceLogin = 0;
        public static int loginTime = 0;
    }
}
