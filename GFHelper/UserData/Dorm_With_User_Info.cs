using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.UserData
{
    /// <summary>
    /// 主要用途: 获取电池 
    /// </summary>
    public class Dorm_With_User_Info
    {
        public info info = new info();
        public int current_build_coin;
        public int build_coin_flag;

    }

    public class info
    {
        public string praise_num;
        public string visit_num;
        public string user_id;//记录这个
        public string dorm_id;//记录这个
    }
}
