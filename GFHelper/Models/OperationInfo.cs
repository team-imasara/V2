using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Models
{
    class OperationInfo
    {
        public int id;
        public int campaign;
        public string name;
        public string description;
        public int duration;
        public int mp;
        public int ammo;
        public int mre;
        public int part;
        public List<int> itemPool = new List<int>();
        public int teamLeaderMinLevel;
        public int gunMin;
        public int[] gunTypeMin = new int[7]; 
    }

    class simple_OperationInfo//用于自动后期
    {
        public int id;
        public int operation_id;
        public int user_id;
        public int team_id;
        public int start_time;

    }

}
