using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GFHelper.CatchData
{
    class Fairy
    {
        // Token: 0x04001245 RID: 4677
        public long id;

        // Token: 0x04001246 RID: 4678
        public int fairyInfoId;

        // Token: 0x04001247 RID: 4679
        public int teamId;

        // Token: 0x04001248 RID: 4680
        public int level;

        // Token: 0x04001249 RID: 4681
        private int _exp;

        // Token: 0x0400124A RID: 4682
        public int mainSkillLevel = 1;

        // Token: 0x0400124B RID: 4683
        public List<string> listSkillCollect = new List<string>();

        // Token: 0x0400124C RID: 4684
        public int qualityExp;

        // Token: 0x0400124D RID: 4685
        public Fairy_Info _info;

        // Token: 0x0400124E RID: 4686
        public bool isLocked;

        // Token: 0x0400124F RID: 4687
        public int equipId;

        // Token: 0x04001250 RID: 4688
        //public MissionSkill mainSkill;

        // Token: 0x04001251 RID: 4689
        public long minorSkillId;

        // Token: 0x04001252 RID: 4690
        public bool autoSkill;

        // Token: 0x04001253 RID: 4691
        public bool waitForConsume;

        // Token: 0x04001254 RID: 4692
        public bool isFriendly = true;

        // Token: 0x17000540 RID: 1344
        // (get) Token: 0x06001626 RID: 5670 RVA: 0x00070080 File Offset: 0x0006E280
        public float pow
        {
            get
            {
                return (float)this.powWithLevel * this._info.dictProportion[this.qualityLevel];
            }
        }



        // Token: 0x1700053B RID: 1339
        // (get) Token: 0x06001621 RID: 5665 RVA: 0x0006FE78 File Offset: 0x0006E078
        public int powWithLevel
        {
            get
            {
                float[] fairyGrowRatio = this.GetFairyGrowRatio("fairy_pow_grow");
                return Mathf.CeilToInt(fairyGrowRatio[0] * (float)this._info.basePow / fairyGrowRatio[2]) + Mathf.CeilToInt((float)(this.level - 1) * fairyGrowRatio[1] * (float)this._info.basePow / fairyGrowRatio[2] * (float)this._info.growthValue / fairyGrowRatio[3]);
            }
        }

        public int qualityLevel=1;//智障云母
        //{
        //    get
        //    {
        //        int num = 1;
        //        while (this.info.dictQualityExp.ContainsKey(num) && this.qualityExp >= this.info.dictQualityExp.get_Item(num))
        //        {
        //            num++;
        //        }
        //        num = Mathf.Clamp(num - 1, 1, num);
        //        int num2 = 1;
        //        while (GameData.dictFairyQualityLevelLimit.ContainsKey(num2) && this.level >= GameData.dictFairyQualityLevelLimit.get_Item(num2))
        //        {
        //            num2++;
        //        }
        //        num2 = Mathf.Clamp(num2 - 1, 1, num2);
        //        return Mathf.Min(num, num2);
        //    }
        //}
        // Token: 0x06001620 RID: 5664 RVA: 0x0006FDFC File Offset: 0x0006DFFC
        private float[] GetFairyGrowRatio(string configKey)
        {
            float[] array = new float[4];
            string @string = CatchDataFunc.Game_Config_Info_Func.GetString(configKey);
            if (string.IsNullOrEmpty(@string))
            {
                array[0] = 100f;
                array[1] = 1.01f;
                array[2] = 100f;
                array[3] = 100f;
            }
            else
            {
                string[] array2 = @string.Split(new char[]
                {
                ','
                });
                for (int i = 0; i < 4; i++)
                {
                    array[i] = Convert.ToSingle(array2[i]);
                }
            }
            return array;
        }

        // Token: 0x1700053C RID: 1340
        // (get) Token: 0x06001622 RID: 5666 RVA: 0x0006FEE0 File Offset: 0x0006E0E0
        public int hitWithLevel
        {
            get
            {
                float[] fairyGrowRatio = this.GetFairyGrowRatio("fairy_hit_grow");
                return Mathf.CeilToInt(fairyGrowRatio[0] * (float)this._info.baseHit / fairyGrowRatio[2]) + Mathf.CeilToInt((float)(this.level - 1) * fairyGrowRatio[1] * (float)this._info.baseHit / fairyGrowRatio[2] * (float)this._info.growthValue / fairyGrowRatio[3]);
            }
        }
        public int dodgeWithLevel
        {
            get
            {
                float[] fairyGrowRatio = this.GetFairyGrowRatio("fairy_dodge_grow");
                return Mathf.CeilToInt(fairyGrowRatio[0] * (float)this._info.baseDodge / fairyGrowRatio[2]) + Mathf.CeilToInt((float)(this.level - 1) * fairyGrowRatio[1] * (float)this._info.baseDodge / fairyGrowRatio[2] * (float)this._info.growthValue / fairyGrowRatio[3]);
            }
        }  
        // Token: 0x1700053F RID: 1343
            // (get) Token: 0x06001625 RID: 5669 RVA: 0x00070018 File Offset: 0x0006E218
        public int critDamageWithLevel
        {
            get
            {
                float[] fairyGrowRatio = this.GetFairyGrowRatio("fairy_critical_harm_rate_grow");
                return Mathf.CeilToInt(fairyGrowRatio[0] * (float)this._info.baseCritDamage / fairyGrowRatio[2]) + Mathf.CeilToInt((float)(this.level - 1) * fairyGrowRatio[1] * (float)this._info.baseCritDamage / fairyGrowRatio[2] * (float)this._info.growthValue / fairyGrowRatio[3]);
            }
        }
        public float hit
        {
            get
            {
                return (float)this.hitWithLevel * this._info.dictProportion[this.qualityLevel];
            }
        }
        public float dodge
        {
            get
            {
                return (float)this.dodgeWithLevel * this._info.dictProportion[this.qualityLevel];
            }
        }   // Token: 0x17000544 RID: 1348
            // (get) Token: 0x0600162A RID: 5674 RVA: 0x00070130 File Offset: 0x0006E330
        public float critDamage
        {
            get
            {
                return (float)this.critDamageWithLevel * this._info.dictProportion[this.qualityLevel];
            }
        }

        // Token: 0x17000543 RID: 1347
        // (get) Token: 0x06001629 RID: 5673 RVA: 0x00070104 File Offset: 0x0006E304
        public float armor
        {
            get
            {
                return (float)this.armorWithLevel * this._info.dictProportion[this.qualityLevel];
            }
        }

        // Token: 0x1700053E RID: 1342
        // (get) Token: 0x06001624 RID: 5668 RVA: 0x0006FFB0 File Offset: 0x0006E1B0
        public int armorWithLevel
        {
            get
            {
                float[] fairyGrowRatio = this.GetFairyGrowRatio("fairy_armor_grow");
                return Mathf.CeilToInt(fairyGrowRatio[0] * (float)this._info.baseArmor / fairyGrowRatio[2]) + Mathf.CeilToInt((float)(this.level - 1) * fairyGrowRatio[1] * (float)this._info.baseArmor / fairyGrowRatio[2] * (float)this._info.growthValue / fairyGrowRatio[3]);
            }
        }
    }
}
