using GFHelper.CatchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GFHelper.UserData
{
    public class Equip_With_User_Info
    {
        public int id;
        public int user_id;
        public int gun_with_user_id;
        public int equip_id;
        public int equip_exp;
        public int equip_level;
        public int pow;
        public int hit;
        public int dodge;
        public int speed;
        public int rate;
        public int critical_harm_rate;
        public int critical_percent;
        public int armor_piercing;
        public int armor;
        public int shield;
        public int damage_amplify;
        public int damage_reduction;

        public int bullet_number_up;
        public int adjust_count;
        public int is_locked;
        public string last_adjust;
        // Token: 0x0400161A RID: 5658
        private int _nightResistance;
        // Token: 0x04001607 RID: 5639
        public Equip_Info info;
        // Token: 0x170005CC RID: 1484
        // (get) Token: 0x060017B2 RID: 6066 RVA: 0x0007B6B0 File Offset: 0x000798B0
        // (set) Token: 0x060017B1 RID: 6065 RVA: 0x0007B6A4 File Offset: 0x000798A4
        public int nightResistance
        {
            get
            {
                return this.GetBounsProperty("night_view_percent", this._nightResistance);
            }
            set
            {
                this._nightResistance = value;
            }
        }
        // Token: 0x060017BA RID: 6074 RVA: 0x0007B71C File Offset: 0x0007991C
        private int GetBounsProperty(string type, int value)
        {
            if (this.equip_level == 0)
            {
                return value;
            }
            string[] array = this.info.strBounsType.Split(new char[]
            {
            ','
            });
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string text = array2[i];
                string[] array3 = text.Split(new char[]
                {
                ':'
                });
                if (array3[0].Equals(type))
                {
                    float num = (float)int.Parse(array3[1]) / 100f;
                    float num2 = 1f + (float)this.equip_level * num;
                    return Mathf.FloorToInt((float)value * num2);
                }
            }
            return value;
        }
        public int night_view_percent;
    }
}
