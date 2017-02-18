using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Models
{

    public class UserInfo
    {
        public int bp;
        public int ammo;
        public int autoBattle;
        public int coin1;
        public int coin2;
        public int coin3;
        public int contract;
        public int contract16;
        public int core;
        public Dictionary<string, int> dictionaryDailyStatistics = new Dictionary<string, int>();
        public Dictionary<string, int> dictionaryWeeklyStatistics = new Dictionary<string, int>();
        private int exp;
        public int gem;
        public int lastBpRecoverTime;
        public int level;
        public List<int> listGunCollect = new List<int>();
        public int maxDevelopSlot;
        public int maxEquip;
        public int maxFixSlot;
        public int maxGun;
        public int maxResearchSlot = 2;
        public int maxTeam;
        public int monthlyCardExpirationGem;
        public int monthlyCardExpirationRes;
        public int mp;
        public int mre;
        public string name;
        public int part;
        public int pauseTurnChance;
        public int quickDevelop;
        public int quickReinforce;
        public int quickSkillTraining;
        public int ring;
        public string userId;
        public int maxUpgradeSlot;

        //user_record
        public int mission_campaign;
        public string special_mission_campaign;
        public int attendance_type1_day;
        public int attendance_type1_time;
        public int attendance_type2_day;
        public int attendance_type2_time;
        public int develop_lowrank_count;
        public int special_develop_lowrank_count;
        public int get_gift_ids;
        public string spend_point;
        public string gem_mall_ids;
        public int seven_attendance_days;
        public int last_bp_buy_time;
        public int bp_buy_count;
        public int new_developgun_count;
        public string buyitem1_developgun_count;
        public string buyitem1_specialdevelopgun_count;
        public int buyitem1_num;
        public int last_developgun_time;
        public int last_specialdevelopgun_time;
        public int furniture_classes;
        public string adjutant;

        public List<GunWithUserInfo> gunWithUserID = new List<GunWithUserInfo>();
        public Dictionary<int, int> item = new Dictionary<int, int>();
        public SortedDictionary<int, Dictionary<int, GunWithUserInfo>> teamInfo = new SortedDictionary<int, Dictionary<int, GunWithUserInfo>>();

        public int Exp
        {
            get
            {
                return this.exp;
            }
            set
            {
                this.exp = value;
                int level = this.level;
                this.level = CommonHelper.ExpToLevel(this.exp, true);
            }
        }
    }

}
