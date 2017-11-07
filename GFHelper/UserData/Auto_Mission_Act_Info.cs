using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.UserData
{
    class Auto_Mission_Act_Info
    {
        public int auto_mission_id;
        public int user_id;
        public List<int> team_ids = new List<int>();
        public long end_time;
    }
}
