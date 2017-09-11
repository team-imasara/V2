using GFHelper.CatchData;
using GFHelper.CatchData.CatchDataFunc;
using GFHelper.Programe.ProgramePro.APK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GFHelper.UserData
{
    class Gun_With_User_Info
    {
        private InstanceManager im;

        public Gun_With_User_Info(InstanceManager im)
        {
            this.im = im;
        }

        public int id;
        public int user_id;
        public int gun_id;
        public int gun_exp
        {
            get { return gun_exp; }
            set
            {
                gun_exp += value;
                if (level == 100) return;
                if (UserData.UserDataSummery.ExpToLevel(gun_exp) == level) return;
                level += UserDataSummery.Update_GUN_exp_level(value, gun_exp - value, level);
                if (life == maxLife)
                {
                    UpdateMaxLife();
                    life = maxLife;
                }
                else
                {
                    UpdateMaxLife();
                }
            }

        }
        public int gun_level;
        public int team_id;
        public int teamId;
        public int if_modification;
        public int location;
        public int position;
        public int life;
        public int ammo;
        public int mre;
        public int pow;
        public int hit;
        public int dodge;
        public int rate;
        public int skill1;
        public int skill2;
        public int fix_end_time;
        public int is_locked;
        public int number;
        public int equip1;
        public int equip2;
        public int equip3;
        public int equip4;
        public int favor;
        public int max_favor;
        public int favor_toplimit;
        public int soul_bond;
        public int skin;
        public int can_click;

        public int crit;
        public int piercing;
        public int maxLife;
        public int bulletNumber;
        public int armor;
        public float nightResistance;

        public int fairyPow;
        public int fairyHit;
        public int fairyDodge;
        public int fairyArmor;

        public int criHarmRate;

        public CatchData.Gun_Info info = new Gun_Info();

        public int gunEffect=0;

        public float powbuffTemp = 1f;

        // Token: 0x040017BE RID: 6078
        public float hitbuffTemp = 1f;

        // Token: 0x040017BF RID: 6079
        public float dodgebuffTemp = 1f;

        // Token: 0x040017C0 RID: 6080
        public float armorbuffTemp = 1f;

        // Token: 0x040017C1 RID: 6081
        public float critbuffTemp = 1f;

        // Token: 0x040017C2 RID: 6082
        public float harmratebuffTemp = 1f;

        public int _level;
        public int basePow;
        // Token: 0x04001788 RID: 6024
        public int maxAddPow;
        // Token: 0x0400178B RID: 6027
        public int favorPow;
        public int additionPow;
        public int current_Maxlife;
        // Token: 0x04001782 RID: 6018
        public List<Equip_With_User_Info> equipList = new List<Equip_With_User_Info>();
        // Token: 0x170005F2 RID: 1522
        // (get) Token: 0x06001880 RID: 6272 RVA: 0x0008551C File Offset: 0x0008371C
        Fairy fairy
        {
            get
            {
                if (this.teamId != 0 && im.userdatasummery.dictTeamFairy !=null && im.userdatasummery.dictTeamFairy.ContainsKey(this.teamId))
                {
                    return im.userdatasummery.dictTeamFairy[this.teamId];
                }
                return null;
            }
        }
        public int baseRate;
        public int maxAddRate;
        public int additionRate;
        public int baseHit;
        // Token: 0x0400178F RID: 6031
        public int maxAddHit;
        // Token: 0x04001797 RID: 6039
        public int baseDodge;
        public int maxAddDodge;
        // Token: 0x04001798 RID: 6040
        public int favorDodge;
        public int favorHit;
        // Token: 0x0400179D RID: 6045
        public int fairyCriHarmRate;
        public int speed;
        public int additionHit;
        public int additionDodge;
        public int equipAp;
        public int[] arrEffectGridBuff = new int[8];


















        public virtual int GetPoint(bool fullLife = false, bool basePoint = false, bool isNight = false, SubGunType subGunType = SubGunType.None)
        {
            return this.GetAtkPoint(isNight, fullLife, basePoint, subGunType) + this.GetSurPoint(fullLife, basePoint, subGunType) + this.GetSkill1Point(fullLife, basePoint, subGunType);
        }

        public int GetAtkPoint(bool isNight, bool isFullLife, bool basePoint, SubGunType subGunType = SubGunType.None, bool countFairy = true)
        {
            int num = this.pow;
            int num2 = this.rate;
            int num3 = this.hit;
            int num4 = this.dodge;
            int num5 = this.crit;
            int num6 = this.armor;
            int num7 = this.piercing;//穿甲
            if (!countFairy)//妖精
            {
                num -= this.fairyPow;
                num3 -= this.fairyHit;
                num4 -= this.fairyDodge;
                num6 -= this.fairyArmor;
            }
            if (!basePoint)
            {
                num = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("pow"), (float)num * this.GetEffectGridValue(EffectGridType.pow, subGunType) * this.powbuffTemp));
                num2 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("rate"), (float)num2 * this.GetEffectGridValue(EffectGridType.rate, subGunType)));
                num3 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("hit"), (float)num3 * this.GetEffectGridValue(EffectGridType.hit, subGunType) * this.hitbuffTemp));
                num4 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("dodge"), (float)num4 * this.GetEffectGridValue(EffectGridType.dodge, subGunType) * this.dodgebuffTemp));
                num5 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("critical_percent"), (float)num5 * this.GetEffectGridValue(EffectGridType.crit, subGunType) * this.critbuffTemp));
                num6 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("armor"), (float)num6 * this.GetEffectGridValue(EffectGridType.armor, subGunType) * this.armorbuffTemp));
                num7 = Mathf.CeilToInt(Mathf.Max(Game_Config_Info_Func.GetMinAttribute("armor_piercing"), (float)num7 * this.GetEffectGridValue(EffectGridType.ap, subGunType)));
                float effectGridValue = this.GetEffectGridValue(EffectGridType.skill, subGunType);
            }
            int num8 = this.life;
            if (isFullLife)
            {
                num8 = this.maxLife;
            }
            int num9 = this.info.special + this.bulletNumber;
            int num10 = num3;
            if (isNight)
            {
                num10 = Mathf.CeilToInt((float)num3 * (1f + (float)im.catchdatasummery.Game_Config_info_Func.GetDouble("night_hit_debuff") * (1f - this.nightResistance)));
            }
            GunType type = this.info.type;
            int result;
            if (type != GunType.machinegun)
            {
                if (type != GunType.shotgun)
                {
                    float floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 0, ',');
                    float floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 1, ',');
                    float floatFromStringArray3 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 2, ',');
                    float floatFromStringArray4 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 3, ',');
                    float floatFromStringArray5 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 4, ',');
                    float floatFromStringArray6 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_normal", 5, ',');
                    result = Mathf.CeilToInt(floatFromStringArray * Mathf.Ceil((float)num8 / (float)this.maxLife * (float)this.number) * (((float)num + (float)num7 / floatFromStringArray6) * ((float)this.criHarmRate / 100f * (float)num5 / 100f + 1f) * (float)num2 / floatFromStringArray5 * (float)num10 / ((float)num10 + floatFromStringArray3) + floatFromStringArray4));
                }
                else
                {
                    float floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 0, ',');
                    float floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 1, ',');
                    float floatFromStringArray3 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 2, ',');
                    float floatFromStringArray4 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 3, ',');
                    float floatFromStringArray5 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 4, ',');
                    float floatFromStringArray6 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 5, ',');
                    float floatFromStringArray7 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 6, ',');
                    float floatFromStringArray8 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 7, ',');
                    float floatFromStringArray9 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_sg", 8, ',');
                    result = Mathf.CeilToInt(floatFromStringArray * Mathf.Ceil((float)num8 / (float)this.maxLife * (float)this.number) * (floatFromStringArray7 * (float)num9 * ((float)num + (float)num7 / floatFromStringArray6) * ((float)this.criHarmRate / 100f * (float)num5 / 100f + 1f) / ((float)num9 * floatFromStringArray5 / (float)num2 + floatFromStringArray8 + floatFromStringArray9 * (float)num9) * (float)num10 / ((float)num10 + floatFromStringArray3) + floatFromStringArray4));
                }
            }
            else
            {
                float floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 0, ',');
                float floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 1, ',');
                float floatFromStringArray3 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 2, ',');
                float floatFromStringArray4 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 3, ',');
                float floatFromStringArray5 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 4, ',');
                float floatFromStringArray6 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 5, ',');
                float floatFromStringArray7 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("attack_effect_mg", 6, ',');
                result = Mathf.CeilToInt(floatFromStringArray * Mathf.Ceil((float)num8 / (float)this.maxLife * (float)this.number) * ((float)num9 * ((float)num + (float)num7 / floatFromStringArray7) * ((float)this.criHarmRate / 100f * (float)num5 / 100f + 1f) / ((float)num9 / 3f + floatFromStringArray3 + floatFromStringArray4 / (float)num2) * (float)num10 / ((float)num10 + floatFromStringArray5) + floatFromStringArray6));
            }
            return result;
        }




        // Token: 0x06001638 RID: 5688 RVA: 0x00072A9C File Offset: 0x00070C9C
        public int GetSurPoint(bool isFullLife, bool basePoint, SubGunType subGunType = SubGunType.None)
        {
            int num4;
            int num6;
            if (basePoint)
            {
                int num = this.pow;
                int num2 = this.rate;
                int num3 = this.hit;
                num4 = this.dodge;
                int num5 = this.crit;
                num6 = this.armor;
                int num7 = this.piercing;
            }
            else
            {
                int num = Mathf.CeilToInt((float)this.pow * this.GetEffectGridValue(EffectGridType.pow, subGunType));
                int num2 = Mathf.CeilToInt((float)this.rate * this.GetEffectGridValue(EffectGridType.rate, subGunType));
                int num3 = Mathf.CeilToInt((float)this.hit * this.GetEffectGridValue(EffectGridType.hit, subGunType));
                num4 = Mathf.CeilToInt((float)this.dodge * this.GetEffectGridValue(EffectGridType.dodge, subGunType));
                int num5 = Mathf.CeilToInt((float)this.crit * this.GetEffectGridValue(EffectGridType.crit, subGunType));
                num6 = Mathf.CeilToInt((float)this.armor * this.GetEffectGridValue(EffectGridType.armor, subGunType));
                int num7 = Mathf.CeilToInt((float)this.piercing * this.GetEffectGridValue(EffectGridType.ap, subGunType));
                float effectGridValue = this.GetEffectGridValue(EffectGridType.skill, subGunType);
            }
            int num8 = this.life;
            if (isFullLife)
            {
                num8 = this.maxLife;
            }
            //deffence_effect = 1,35,2.6,75,1.6,1

            float floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 0, ',');
            float floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 1, ',');
            float floatFromStringArray3 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 2, ',');
            float floatFromStringArray4 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 3, ',');
            float floatFromStringArray5 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 4, ',');
            float floatFromStringArray6 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("deffence_effect", 5, ',');
            return (int)(floatFromStringArray * (float)Mathf.CeilToInt((float)num8 * ((floatFromStringArray2 + (float)num4) / floatFromStringArray2) * (floatFromStringArray3 * floatFromStringArray4 / Mathf.Max(floatFromStringArray4 - (float)num6 / floatFromStringArray6, 1f) - floatFromStringArray5)));
        }

        public int GetSkill1Point(bool isFullLife, bool basePoint, SubGunType subGunType = SubGunType.None)
        {
            float num;
            if (basePoint)
            {
                num = 1f;
            }
            else
            {
                num = this.GetEffectGridValue(EffectGridType.skill, subGunType);
            }
            int num2 = this.life;
            if (isFullLife)
            {
                num2 = this.maxLife;
            }
            //skill_effect = 35,5
            float floatFromStringArray = 35f;
            float floatFromStringArray2 = 5f;
            //float floatFromStringArray = Data.GetFloatFromStringArray("skill_effect", 0, ',');
            //float floatFromStringArray2 = Data.GetFloatFromStringArray("skill_effect", 1, ',');
            //int level = this.GetSkill(enumSkill.eSkill1).level;
            return Mathf.CeilToInt(Mathf.Ceil((float)num2 / (float)this.maxLife * (float)this.number) * (0.8f + (float)this.info.rank / 10f) * (floatFromStringArray + floatFromStringArray2 * (float)(level - 1)) * (float)Mathf.CeilToInt((float)level / 10f) * num);
        }

        public float GetEffectGridValue(EffectGridType type, SubGunType subGunType = SubGunType.None)
        {
            if (subGunType != SubGunType.None)
            {
                //猜测是特典枪
                //if (subGunType == SubGunType.Simultor)
                //{
                //    return 1f + (float)((ExGun)this).GetArrEffcetGridBuff(subGunType)[type - EffectGridType.pow] / 100f;
                //}
            }
            return 1f + (float)this.arrEffectGridBuff[type - EffectGridType.pow] / 100f;
        }

        //public Skill GetSkill(enumSkill e)
        //{
        //    return (this.mVecSkill.Count <= (int)e) ? this.mVecSkill[0] : this.mVecSkill[(int)e];
        //}



        public void UpdateData()
        {
            foreach (var item in im.catchdatasummery.gun_info)
            {
                if(gun_id == item.Value.id)
                {
                    info = item.Value;
                    break;
                }
            }



            float floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("life_basic", 0, ',');
            float floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("life_basic", 1, ',');
            float floatFromStringArray3 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("life_basic", 2, ',');

            if (this.maxLife != 0)
            {
                this.current_Maxlife = this.maxLife;
                this.maxLife = Mathf.CeilToInt((floatFromStringArray + ((float)this.level - 1f) * floatFromStringArray2) * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_life") * this.info.ratioLife / floatFromStringArray3) * this.number;
                this.gunEffect += maxLife - current_Maxlife;
                
            }
            else
            {
                this.maxLife = Mathf.CeilToInt((floatFromStringArray + ((float)this.level - 1f) * floatFromStringArray2) * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_life") * this.info.ratioLife / floatFromStringArray3) * this.number;
            }


            floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("power_basic", 0, ',');
            floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("power_basic", 1, ',');
            this.basePow = Mathf.CeilToInt(floatFromStringArray * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_pow") * (float)this.info.ratioPow / floatFromStringArray2);
            floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("power_grow", 0, ',');
            floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("power_grow", 1, ',');
            floatFromStringArray3 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("power_grow", 2, ',');
            this.maxAddPow = Mathf.CeilToInt((float)(this.level - 1) * floatFromStringArray * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_pow") * (float)this.info.ratioPow * this.info.eatRatio / floatFromStringArray2 / floatFromStringArray3);
            this.pow = this.basePow + this.additionPow;
            this.favorPow = Math.Sign(this.favorRatio) * Mathf.CeilToInt(Mathf.Abs((float)this.pow * this.favorRatio));
            this.pow += this.favorPow;

            using (List<Equip_With_User_Info>.Enumerator enumerator = this.equipList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Equip_With_User_Info current = enumerator.Current;//没有get_Current这个函数
                    this.pow += current.pow;
                }
            }
            if (this.fairy == null)
            {
                this.fairyPow = 0;
            }
            else
            {
                this.fairyPow = Mathf.CeilToInt((float)this.pow * this.fairy.pow / 100f);
            }
            this.pow += this.fairyPow;
            floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("rate_basic", 0, ',');
            floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("rate_basic", 1, ',');
            this.baseRate = Mathf.CeilToInt(floatFromStringArray * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_rate") * (float)this.info.ratioRate / floatFromStringArray2);
            floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("rate_grow", 0, ',');
            floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("rate_grow", 1, ',');
            floatFromStringArray3 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("rate_grow", 2, ',');
            this.maxAddRate = Mathf.CeilToInt((float)(this.level - 1) * floatFromStringArray * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_rate") * (float)this.info.ratioRate * this.info.eatRatio / floatFromStringArray2 / floatFromStringArray3);
            this.rate = this.baseRate + this.additionRate;
            using (List<Equip_With_User_Info>.Enumerator enumerator2 = this.equipList.GetEnumerator())
            {
                while (enumerator2.MoveNext())
                {
                    Equip_With_User_Info current2 = enumerator2.Current;
                    this.rate += current2.rate;
                }
            }
            floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("hit_basic", 0, ',');
            floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("hit_basic", 1, ',');
            this.baseHit = Mathf.CeilToInt(floatFromStringArray * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_hit") * (float)this.info.ratioHit / floatFromStringArray2);
            floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("hit_grow", 0, ',');
            floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("hit_grow", 1, ',');
            floatFromStringArray3 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("hit_grow", 2, ',');
            this.maxAddHit = Mathf.CeilToInt((float)(this.level - 1) * floatFromStringArray * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_hit") * (float)this.info.ratioHit * this.info.eatRatio / floatFromStringArray2 / floatFromStringArray3);
            this.hit = this.baseHit + this.additionHit;
            this.favorHit = Math.Sign(this.favorRatio) * Mathf.CeilToInt(Mathf.Abs((float)this.hit * this.favorRatio));
            this.hit += this.favorHit;
            using (List<Equip_With_User_Info>.Enumerator enumerator3 = this.equipList.GetEnumerator())
            {
                while (enumerator3.MoveNext())
                {
                    Equip_With_User_Info current3 = enumerator3.Current;
                    this.hit += current3.hit;
                }
            }
            if (this.fairy == null)
            {
                this.fairyHit = 0;
            }
            else
            {
                this.fairyHit = Mathf.CeilToInt((float)this.hit * this.fairy.hit / 100f);
            }
            this.hit += this.fairyHit;
            floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("dodge_basic", 0, ',');
            floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("dodge_basic", 1, ',');
            this.baseDodge = Mathf.CeilToInt(floatFromStringArray * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_dodge") * (float)this.info.ratioDodge / floatFromStringArray2);
            floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("dodge_grow", 0, ',');
            floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("dodge_grow", 1, ',');
            floatFromStringArray3 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("dodge_grow", 2, ',');
            this.maxAddDodge = Mathf.CeilToInt((float)(this.level - 1) * floatFromStringArray * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_dodge") * (float)this.info.ratioDodge * this.info.eatRatio / floatFromStringArray2 / floatFromStringArray3);
            this.dodge = this.baseDodge + this.additionDodge;
            this.favorDodge = Math.Sign(this.favorRatio) * Mathf.CeilToInt(Mathf.Abs((float)this.dodge * this.favorRatio));
            this.dodge += this.favorDodge;
            using (List<Equip_With_User_Info>.Enumerator enumerator4 = this.equipList.GetEnumerator())
            {
                while (enumerator4.MoveNext())
                {
                    Equip_With_User_Info current4 = enumerator4.Current;
                    this.dodge += current4.dodge;
                }
            }
            if (this.fairy == null)
            {
                this.fairyDodge = 0;
            }
            else
            {
                this.fairyDodge = Mathf.CeilToInt((float)this.dodge * this.fairy.dodge / 100f);
            }
            this.dodge += this.fairyDodge;
            this.piercing = this.info.armorPiercing;
            this.equipAp = 0;
            using (List<Equip_With_User_Info>.Enumerator enumerator5 = this.equipList.GetEnumerator())
            {
                while (enumerator5.MoveNext())
                {
                    Equip_With_User_Info current5 = enumerator5.Current;
                    this.equipAp += current5.armor_piercing;
                }
            }
            this.piercing += this.equipAp;
            floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("armor_basic", 0, ',');
            floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("armor_basic", 1, ',');
            floatFromStringArray3 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("armor_basic", 2, ',');
            this.armor = Mathf.CeilToInt((floatFromStringArray + (float)(this.level - 1) * floatFromStringArray2) * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_armor") * (float)this.info.ratioArmor / floatFromStringArray3);
            using (List<Equip_With_User_Info>.Enumerator enumerator6 = this.equipList.GetEnumerator())
            {
                while (enumerator6.MoveNext())
                {
                    Equip_With_User_Info current6 = enumerator6.Current;
                    this.armor += current6.armor;
                }
            }
            if (this.fairy == null)
            {
                this.fairyArmor = 0;
            }
            else
            {
                this.fairyArmor = Mathf.CeilToInt((float)this.armor * this.fairy.armor / 100f);
            }
            this.armor += this.fairyArmor;
            this.crit = this.info.ratioCrit;
            using (List<Equip_With_User_Info>.Enumerator enumerator7 = this.equipList.GetEnumerator())
            {
                while (enumerator7.MoveNext())
                {
                    Equip_With_User_Info current7 = enumerator7.Current;
                    this.crit += current7.critical_percent;
                }
            }
            this.criHarmRate = 50;
            using (List<Equip_With_User_Info>.Enumerator enumerator8 = this.equipList.GetEnumerator())
            {
                while (enumerator8.MoveNext())
                {
                    Equip_With_User_Info current8 = enumerator8.Current;
                    this.criHarmRate += current8.critical_harm_rate;
                }
            }
            if (this.fairy == null)
            {
                this.fairyCriHarmRate = 0;
            }
            else
            {
                this.fairyCriHarmRate = Mathf.CeilToInt((float)this.criHarmRate * this.fairy.critDamage / 100f);
            }
            this.criHarmRate += this.fairyCriHarmRate;
            this.nightResistance = 0f;
            using (List<Equip_With_User_Info>.Enumerator enumerator9 = this.equipList.GetEnumerator())
            {
                while (enumerator9.MoveNext())
                {
                    Equip_With_User_Info current9 = enumerator9.Current;
                    this.nightResistance += (float)current9.nightResistance;
                }
            }
            this.nightResistance /= 100f;
            floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("speed_basic", 0, ',');
            floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("speed_basic", 1, ',');
            this.speed = Mathf.CeilToInt(floatFromStringArray * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_speed") * (float)this.info.ratioSpeed / floatFromStringArray2);
            using (List<Equip_With_User_Info>.Enumerator enumerator10 = this.equipList.GetEnumerator())
            {
                while (enumerator10.MoveNext())
                {
                    Equip_With_User_Info current10 = enumerator10.Current;
                    this.speed += current10.speed;
                }
            }
            this.bulletNumber = 0;
            using (List<Equip_With_User_Info>.Enumerator enumerator11 = this.equipList.GetEnumerator())
            {
                while (enumerator11.MoveNext())
                {
                    Equip_With_User_Info current11 = enumerator11.Current;
                    this.bulletNumber += current11.bullet_number_up;
                }
            }
            //guiling
            //using (List<Equip_With_User_Info>.Enumerator enumerator12 = this.equipList.GetEnumerator())
            //{
            //    while (enumerator12.MoveNext())
            //    {
            //        Equip_With_User_Info current12 = enumerator12.Current;
            //        if (current12.info.skill != 0)
            //        {
            //            this.GetSkill(enumSkill.eNormal).id = current12.info.skill;
            //            break;
            //        }
            //        this.InitSkills();
            //    }
            //}
            //if (this.equipList.Count() == 0 && this.mVecSkill.get_Count() != 0)
            //{
            //    this.InitSkills();
            //}
        }
        //public void InitSkills()
        //{
        //    this.mHasDodgeSkill = false;
        //    this.mHasHurtSkill = false;
        //    for (int i = 0; i < this.info.skills.Count(); i++)
        //    {
        //        if (this.mVecSkill.get_Count() <= i)
        //        {
        //            this.mVecSkill.Add(new Skill(this.info.skills.get_Item(i), 1));
        //        }
        //        else
        //        {
        //            this.mVecSkill.get_Item(i).id = this.info.skills.get_Item(i);
        //        }
        //        if (this.mVecSkill.get_Item(i).info != null && this.mVecSkill.get_Item(i).info.triggerType == 11)
        //        {
        //            this.mHasDodgeSkill = true;
        //        }
        //        if (this.mVecSkill.get_Item(i).info != null && this.mVecSkill.get_Item(i).info.triggerType == 10)
        //        {
        //            this.mHasHurtSkill = true;
        //        }
        //    }
        //}
        /// <summary>
        /// 如果更新了的话 level=99 会自动更新this.life
        /// </summary>
        /// 
        public void UpdateMaxLife()
        {
            float floatFromStringArray = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("life_basic", 0, ',');
            float floatFromStringArray2 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("life_basic", 1, ',');
            float floatFromStringArray3 = CatchData.CatchDataFunc.Game_Config_Info_Func.GetFloatFromStringArray("life_basic", 2, ',');
            this.maxLife = Mathf.CeilToInt((floatFromStringArray + ((float)this.level - 1f) * floatFromStringArray2) * CatchData.CatchDataFunc.Game_Config_Info_Func.GetGunBasicAttribute(this.info.type, "basic_attribute_life") * this.info.ratioLife / floatFromStringArray3) * this.number;

        }

        public int level;
        //{
        //    get
        //    {

        //        return this._level;
        //    }
        //    set
        //    {
        //        int level = this._level;
        //        int num = this.maxLife;
        //        this._level = Mathf.Min(value, 100);
        //        this.UpdateData();
        //        if (level != 0 && this._level > level)
        //        {
        //            this.life = this.maxLife * Mathf.FloorToInt((float)this.life / (float)num) + this.life % num;
        //        }
        //    }
        //}
        public float favorRatio
        {
            get
            {
                if (this.favor < 100000)
                {
                    return -0.05f;
                }
                if (this.favor < 900000)
                {
                    return 0f;
                }
                if (this.favor < 1400000)
                {
                    return 0.05f;
                }
                return 0.1f;
            }
        }
    }
}
