using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFHelper.CatchData;
namespace GFHelper.CatchData
{
    public class Gun_Info
    {
        public int id;
        public string name;
        public string introduce;
        public string en_introduce;
        public string code;
        public int type;
        public int rank;
        public int max_equip;
        public int ratio_life;
        public int ratio_armor;
        public int baseammo;
        public int basemre;
        public int ammo_add_withnumber;
        public int mre_add_withnumber;
        public int ratio_pow;
        public int ratio_hit;
        public int ratio_dodge;
        public int ratio_range;
        public int ratio_speed;
        public int ratio_rate;
        public int armor_piercing;
        public int crit;
        public int retiremp;
        public int retireammo;
        public int retiremre;
        public int retirepart;
        public int eat_ratio;
        public int develop_duration;
        public string dialogue;
        public int effect_grid_center;
        public int effect_guntype;

        public List<int> effect_grid_pos = new List<int>();
        public Dictionary<int, List<int>> effect_grid_effect = new Dictionary<int, List<int>>();//

        public int skill1;
        public int skill2;
        public int repel_probability;
        public double repel_distance;
        public int special;
        public string extra;

        public Dictionary<int, List<int>> type_equip1 = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> type_equip2 = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> type_equip3 = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> type_equip4 = new Dictionary<int, List<int>>();

        public int ai;
        public int normal_attack;
        public string passive_skill;
        public int is_additional;
        public int launch_time;



        //public int Compare(GunInfo x, GunInfo y)
        //{
        //    return (x.id - y.id);
        //}

    }
}
