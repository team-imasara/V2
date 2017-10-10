using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.CatchData
{
    using System;
    //using GF.Battle;
    using UnityEngine;
    using GFHelper.CatchData.CatchDataFunc;

    // Token: 0x020002F6 RID: 758
    public class Skill
    {
        // Token: 0x0600199E RID: 6558 RVA: 0x00090F34 File Offset: 0x0008F134
        public Skill(int skillid, int level)
        {
            this._skillid = skillid;
            this._level = level;
            this._UpdateSkill();
        }

        // Token: 0x0600199F RID: 6559 RVA: 0x00090F50 File Offset: 0x0008F150
        //private int _GetCD()
        //{
        //    //switch (this.info.cdType)
        //    //{
        //    //    case 1:
        //    //    case 3:
        //    //        return this.cdFrame;
        //    //    case 2:
        //    //        return (this.cdTurn <= 0) ? this.cdFrame : this.cdTurn;
        //    //    default:
        //    //        return 0;
        //    //}
        //}

        // Token: 0x060019A0 RID: 6560 RVA: 0x00090FA8 File Offset: 0x0008F1A8
        //public void UpdateCD(BattleCharacterController self)
        //{
        //    if (this.info == null)
        //    {
        //        return;
        //    }
        //    if (this.cdTurn == 0)
        //    {
        //        if (this.info.IsCommonSkill() && (self.status == CharacterStatus.advancing || self.status == CharacterStatus.switching))
        //        {
        //            if (this.cdFrame < self.coldDownTime)
        //            {
        //                this.cdFrame++;
        //            }
        //            return;
        //        }
        //        if (this.cdFrame > 0)
        //        {
        //            this.cdFrame--;
        //        }
        //        else
        //        {
        //            this.cdFrame = 0;
        //        }
        //    }
        //}

        // Token: 0x060019A1 RID: 6561 RVA: 0x0009103C File Offset: 0x0008F23C



        //public void ResetCD(Gun gun)
        //{
        //    if (this.info == null)
        //    {
        //        return;
        //    }
        //    if (this.info.cdType == 2)
        //    {
        //        int skillCDTurn = SkillUtils.GetSkillCDTurn(gun.id, this.info.id);
        //        if (GameData.missionAction == null || GameData.missionAction.turn >= skillCDTurn)
        //        {
        //            this.cdTurn = 0;
        //            SkillUtils.RemoveSkillCD(gun.id, this.info.id);
        //        }
        //        else
        //        {
        //            this.cdTurn = skillCDTurn - GameData.missionAction.turn;
        //        }
        //    }
        //    else
        //    {
        //        this.cdTurn = 0;
        //    }
        //    this.cdFrame = this.GetSkillCDByEffectGrid(gun, this.info.startCdTime);
        //}

        // Token: 0x060019A2 RID: 6562 RVA: 0x000910F0 File Offset: 0x0008F2F0
        //public bool IsTrigger(SkillImpl self)
        //{
        //    if (this.info == null)
        //    {
        //        return false;
        //    }
        //    if (this.info.daynightOnly == 3 && !BattleController.Instance.isNight)
        //    {
        //        return false;
        //    }
        //    if (this.info.daynightOnly == 4 && BattleController.Instance.isNight)
        //    {
        //        return false;
        //    }
        //    if (this._GetCD() > 0)
        //    {
        //        return false;
        //    }
        //    bool flag = SkillUtils.IsTrigger(this.info, self, false);
        //    if (!flag && this.info.triggerType == 12)
        //    {
        //        this.UseSkill(self.GetCharacter());
        //    }
        //    return flag;
        //}

        // Token: 0x060019A3 RID: 6563 RVA: 0x00091190 File Offset: 0x0008F390
        //private int GetSkillCDByEffectGrid(Gun gun, int cdFrame)
        //{
        //    //if (cdFrame == 0)
        //    //{
        //    //    return cdFrame;
        //    //}
        //    //float num = gun.GetEffectGridValue(EffectGridType.skill, (GameData.currentSelectedMissionInfo == null || GameData.currentSelectedMissionInfo.duplicateType != 3) ? SubGunType.None : SubGunType.Simultor);
        //    //num = Mathf.Min(num, (float)(Game_Config_Info_Func.GetInt("cd_reduction_limit") + 100) / 100f);
        //    //if (num == 1f)
        //    //{
        //    //    return cdFrame;
        //    //}
        //    //return Mathf.CeilToInt((float)cdFrame * Mathf.Max(0f, 2f - num));
        //}

        // Token: 0x060019A4 RID: 6564 RVA: 0x00091210 File Offset: 0x0008F410
        //public void UseSkill(BattleCharacterController self)
        //{
        //    if (self == null)
        //    {
        //        return;
        //    }
        //    enumSkillCDType cdType = (enumSkillCDType)this.info.cdType;
        //    if (cdType != enumSkillCDType.eBattleTurn)
        //    {
        //        if (cdType != enumSkillCDType.eSpeed)
        //        {
        //            this.cdFrame = this.GetSkillCDByEffectGrid(self.gun, this.info.cdTime);
        //        }
        //        else
        //        {
        //            this.cdFrame = self.coldDownTime;
        //        }
        //    }
        //    else
        //    {
        //        this.cdTurn = this.info.cdTime + 1;
        //        this.cdFrame = 0;
        //        //SkillUtils.AddSkillCD(self.gun.id, this.info.id, (GameData.missionAction == null) ? (this.cdTurn + 1) : (GameData.missionAction.turn + this.cdTurn));
        //    }
        //}

        // Token: 0x17000645 RID: 1605
        // (get) Token: 0x060019A5 RID: 6565 RVA: 0x000912E0 File Offset: 0x0008F4E0
        //public string description
        //{
        //    //get
        //    //{
        //    //    //return this.info.description;
        //    //}
        //}

        // Token: 0x17000646 RID: 1606
        // (get) Token: 0x060019A6 RID: 6566 RVA: 0x000912F0 File Offset: 0x0008F4F0
        //public string cdDesc
        //{
        //    //get
        //    //{
        //    //    if (this.info == null)
        //    //    {
        //    //        return string.Empty;
        //    //    }
        //    //    enumSkillCDType cdType = (enumSkillCDType)this.info.cdType;
        //    //    if (cdType == enumSkillCDType.eNormal)
        //    //    {
        //    //        return Data.GetLang(LanguageConfig.ELANS_TYPE_BATTLE.冷却时间_80) + (this.info.cdTime / 30).ToString("f0") + Data.GetLang(LanguageConfig.ELANS_TYPE_COMMON.秒_200);
        //    //    }
        //    //    if (cdType != enumSkillCDType.eBattleTurn)
        //    //    {
        //    //        return string.Empty;
        //    //    }
        //    //    return Data.GetLang(LanguageConfig.ELANS_TYPE_BATTLE.冷却时间_80) + this.info.cdTime + Data.GetLang(LanguageConfig.ELANS_TYPE_MISSIONSELECTION.回合_31);
        //    //}
        //}

        // Token: 0x060019A7 RID: 6567 RVA: 0x000913A8 File Offset: 0x0008F5A8
        private void _UpdateSkill()
        {
            //if (this._skillid == 0)
            //{
            //    this.info = null;
            //    return;
            //}
            //this.info = ((this._level == 0) ? GameData.listBTSkillCfg.GetDataById((long)this._skillid) : GameData.listBTSkillCfg.GetDataById(SkillUtils.GetSkillID(this._skillid, this._level)));
            //this.cdFrame = 0;
            //this.cdTurn = 0;
        }

        // Token: 0x17000647 RID: 1607
        // (get) Token: 0x060019A8 RID: 6568 RVA: 0x00091418 File Offset: 0x0008F618
        // (set) Token: 0x060019A9 RID: 6569 RVA: 0x00091420 File Offset: 0x0008F620
        public int id
        {
            get
            {
                return this._skillid;
            }
            set
            {
                if (this._skillid != value)
                {
                    this._skillid = value;
                    this._UpdateSkill();
                }
            }
        }

        // Token: 0x17000648 RID: 1608
        // (get) Token: 0x060019AA RID: 6570 RVA: 0x0009143C File Offset: 0x0008F63C
        // (set) Token: 0x060019AB RID: 6571 RVA: 0x00091444 File Offset: 0x0008F644
        public int level
        {
            get
            {
                return this._level;
            }
            set
            {
                if (this._level != value)
                {
                    this._level = value;
                    this._UpdateSkill();
                }
            }
        }

        // Token: 0x17000649 RID: 1609
        // (get) Token: 0x060019AC RID: 6572 RVA: 0x00091460 File Offset: 0x0008F660
        //public int skillid
        //{
        //    //get
        //    //{
        //    //    return (this.info == null) ? 0 : this.info.id;
        //    //}
        //}

        // Token: 0x1700064A RID: 1610
        // (get) Token: 0x060019AD RID: 6573 RVA: 0x00091480 File Offset: 0x0008F680
        public float effect1
        {
            get
            {
                return this.GetRealEffect(1, false);
            }
        }

        // Token: 0x1700064B RID: 1611
        // (get) Token: 0x060019AE RID: 6574 RVA: 0x0009148C File Offset: 0x0008F68C
        public float effect2
        {
            get
            {
                return this.GetRealEffect(2, false);
            }
        }

        // Token: 0x1700064C RID: 1612
        // (get) Token: 0x060019AF RID: 6575 RVA: 0x00091498 File Offset: 0x0008F698
        public float effect3
        {
            get
            {
                return this.GetRealEffect(3, false);
            }
        }

        // Token: 0x1700064D RID: 1613
        // (get) Token: 0x060019B0 RID: 6576 RVA: 0x000914A4 File Offset: 0x0008F6A4
        public float effect4
        {
            get
            {
                return this.GetRealEffect(4, false);
            }
        }

        // Token: 0x060019B1 RID: 6577 RVA: 0x000914B0 File Offset: 0x0008F6B0
        public float GetRealEffect(int index, bool getNextLevel = false)
        {
            return 0f;
        }

        // Token: 0x04002373 RID: 9075
        //public BattleSkillCfg info;

        // Token: 0x04002374 RID: 9076
        private int _skillid;

        // Token: 0x04002375 RID: 9077
        private int _level;

        // Token: 0x04002376 RID: 9078
        public int cdFrame;

        // Token: 0x04002377 RID: 9079
        public int cdTurn;
    }

}
