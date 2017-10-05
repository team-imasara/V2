using GFHelper.CatchData;
using GFHelper.CatchData.CatchDataFunc;
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
        public Equip_Info info=new Equip_Info();
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




        /// <summary>
        /// 传入一个exp,返回升了多少级
        /// </summary>
        /// <param name="expAdded"></param>
        /// <returns></returns>
        public int GetLevelToBeAdded(int expAdded)
        {
            int i = expAdded + GetCurrentLevelExp();
            int num = equip_level + 1;
            int num2 = 0;
            while (i >= 0)
            {
                i -= CalculateExpToNextLevel(num);
                num++;
                if (i >= 0)
                {
                    num2++;
                }
            }
            return num2;
        }
        public int GetCurrentLevelExp()
        {
            return this.equip_exp - this.GetTotalExpToLevel(this.equip_level);
        }

        public int CalculateExpToNextLevel(int nextLevel)
        {
            int num;
            if (nextLevel > 1)
            {
                if (nextLevel - 1 < CatchDataSummery.equip_exp_info.Count)
                {
                    num = CatchDataSummery.equip_exp_info[nextLevel] - CatchDataSummery.equip_exp_info[nextLevel - 1];
                }
                else
                {
                    num = 99999;
                }
            }
            else if (nextLevel == 1)
            {
                num = CatchDataSummery.equip_exp_info[nextLevel];
            }
            else
            {
                num = 0;
            }
            float equipLevelUpRate = Game_Config_Info_Func.GetEquipLevelUpRate((int)this.info.rank);
            float exclusiveRate = this.info.exclusive_rate;
            return Mathf.CeilToInt((float)num * equipLevelUpRate * exclusiveRate);
        }

        // Token: 0x060017C1 RID: 6081 RVA: 0x0007BC30 File Offset: 0x00079E30
        public int GetTotalExpToLevel(int level)
        {
            int num;
            if (level >= 1)
            {
                num = CatchDataSummery.equip_exp_info[level];
            }
            else
            {
                num = 0;
            }
            float equipLevelUpRate = Game_Config_Info_Func.GetEquipLevelUpRate(this.info.rank);
            return Mathf.CeilToInt((float)num * equipLevelUpRate * this.info.exclusive_rate);
        }


    }
}
