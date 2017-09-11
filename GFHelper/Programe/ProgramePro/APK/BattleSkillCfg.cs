//using LitJson;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GFHelper.Programe.ProgramePro.APK
//{
//    class BattleSkillCfg
//    {
//        public BattleSkillCfg(JsonData jsonData)
//        {
//            this.id = jsonData["id"].Int;
//            this.name = jsonData["name"].String;
//            this.skillGroupId = jsonData["skill_group_id"].Int;
//            this.type = jsonData["type"].Int;
//            this.skillPriority = jsonData["skill_priority"].Int;
//            this.description = jsonData["description"].String;
//            this.code = jsonData["code"].String;
//            this.trainCoinType = jsonData["train_coin_type"].Int;
//            this.trainCoinNumber = jsonData["train_coin_number"].Int;
//            this.isRare = jsonData["is_rare"].Bool;
//            this.weight = jsonData["weight"].Int;
//            this.trainTime = jsonData["skill_up_time"].Int;
//            this.daynightOnly = jsonData["daynight_only"].Int;
//            this.interruptType = jsonData["interrupt_type"].Int;
//            this.interruptDamageLimit = jsonData["interrupt_damage_limit"].Int;
//            this.cdType = jsonData["cd_type"].Int;
//            this.cdTime = jsonData["cd_time"].Int;
//            this.startCdTime = jsonData["start_cd_time"].Int;
//            this.targetSelectAi = jsonData["target_select_ai"].Int;
//            this.targetLost = jsonData["target_lost"].Int;
//            this.triggerType = jsonData["trigger_type"].Int;
//            this.triggerTargetType = jsonData["trigger_target"].Int;
//            this.triggerParameter = jsonData["trigger_parameter"].Int;
//            this.triggerBuffId = jsonData["trigger_buff_id"].Int;
//            this.actionId = jsonData["action_id"].Int;
//            this.isFormAction = jsonData["is_form_action"].Bool;
//            this.isSwitch = jsonData["is_switch"].Bool;
//            this.prefixNameId = jsonData["passive_name"].String;
//            this.fairyConsumption = jsonData["consumption"].Int;
//            this.buffDelay = jsonData["buff_delay"].Int;
//            string @string = jsonData["buff_id_target"].String;
//            string[] array = @string.Split(new char[]
//            {
//            ','
//            });
//            this.buffTarget = new List<int>();
//            this.buffTargetNum = new List<int>();
//            for (int i = 0; i < array.Length; i++)
//            {
//                string[] array2 = array[i].Split(new char[]
//                {
//                ':'
//                });
//                int num = 0;
//                int num2 = 0;
//                if (array2.Length > 1 && int.TryParse(array2[0], ref num))
//                {
//                    this.buffTarget.Add(num);
//                    this.buffTargetNum.Add((!int.TryParse(array2[1], ref num2)) ? 0 : num2);
//                }
//            }
//            @string = jsonData["buff_id_self"].String;
//            array = @string.Split(new char[]
//            {
//            ','
//            });
//            this.buffSelf = new List<int>();
//            this.buffSelfNum = new List<int>();
//            for (int j = 0; j < array.Length; j++)
//            {
//                string[] array3 = array[j].Split(new char[]
//                {
//                ':'
//                });
//                int num3 = 0;
//                int num4 = 0;
//                if (array3.Length > 1 && int.TryParse(array3[0], ref num3))
//                {
//                    this.buffSelf.Add(num3);
//                    this.buffSelfNum.Add((!int.TryParse(array3[1], ref num4)) ? 0 : num4);
//                }
//            }
//            this._duration = SkillUtils.ConvertToPoolSign(jsonData["skill_duration"].String);
//            string string2 = jsonData["data_pool_1"].String;
//            if (string2.get_Length() > 0)
//            {
//                string[] array4 = string2.Split(new char[]
//                {
//                ','
//                });
//                this.dataPool1 = new float[array4.Length];
//                float num5 = 0f;
//                for (int k = 0; k < array4.Length; k++)
//                {
//                    if (float.TryParse(array4[k], ref num5))
//                    {
//                        this.dataPool1[k] = num5;
//                    }
//                    else
//                    {
//                        this.dataPool1[k] = 0f;
//                        NDebug.LogWaring("技能数值池1中错误的数值:" + k);
//                    }
//                }
//            }
//            string2 = jsonData["data_pool_2"].String;
//            if (string2.get_Length() > 0)
//            {
//                string[] array5 = string2.Split(new char[]
//                {
//                ','
//                });
//                this.dataPool2 = new float[array5.Length];
//                float num6 = 0f;
//                for (int l = 0; l < array5.Length; l++)
//                {
//                    if (float.TryParse(array5[l], ref num6))
//                    {
//                        this.dataPool2[l] = num6;
//                    }
//                    else
//                    {
//                        this.dataPool2[l] = 0f;
//                        NDebug.LogWaring("技能数值池2中错误的数值:" + l);
//                    }
//                }
//            }
//            string2 = jsonData["night_data_pool_1"].String;
//            if (string2.get_Length() > 0)
//            {
//                string[] array6 = string2.Split(new char[]
//                {
//                ','
//                });
//                this.dataPoolNight1 = new float[array6.Length];
//                float num7 = 0f;
//                for (int m = 0; m < array6.Length; m++)
//                {
//                    if (float.TryParse(array6[m], ref num7))
//                    {
//                        this.dataPoolNight1[m] = num7;
//                    }
//                    else
//                    {
//                        this.dataPoolNight1[m] = 0f;
//                        NDebug.LogWaring("技能夜战数值池1中错误的数值:" + m);
//                    }
//                }
//            }
//            string2 = jsonData["night_data_pool_2"].String;
//            if (string2.get_Length() > 0)
//            {
//                string[] array7 = string2.Split(new char[]
//                {
//                ','
//                });
//                this.dataPoolNight2 = new float[array7.Length];
//                float num8 = 0f;
//                for (int n = 0; n < array7.Length; n++)
//                {
//                    if (float.TryParse(array7[n], ref num8))
//                    {
//                        this.dataPoolNight2[n] = num8;
//                    }
//                    else
//                    {
//                        this.dataPoolNight2[n] = 0f;

//                    }
//                }
//            }
//            this.lvupDescription = jsonData["lvup_description"].String;
//            this.isReTarget = jsonData["is_re_target"].Bool;
//            this.spTriggerType = jsonData["sppool_trigger_type"].Int;
//            this.spTriggerTargetType = jsonData["sppool_trigger_target"].Int;
//            this.spTriggerParameter = jsonData["sppool_trigger_parameter"].Int;
//            this.spTriggerBuffId = jsonData["sppool_trigger_buff_id"].Int;
//            string2 = jsonData["sp_data_pool_1"].String;
//            if (string2.get_Length() > 0)
//            {
//                string[] array8 = string2.Split(new char[]
//                {
//                ','
//                });
//                this.spDataPool1 = new float[array8.Length];
//                float num9 = 0f;
//                for (int num10 = 0; num10 < array8.Length; num10++)
//                {
//                    if (float.TryParse(array8[num10], ref num9))
//                    {
//                        this.spDataPool1[num10] = num9;
//                    }
//                    else
//                    {
//                        this.spDataPool1[num10] = 0f;
//                        NDebug.LogWaring("技能条件数值池1中错误的数值:" + num10);
//                    }
//                }
//            }
//            string2 = jsonData["sp_data_pool_2"].String;
//            if (string2.get_Length() > 0)
//            {
//                string[] array9 = string2.Split(new char[]
//                {
//                ','
//                });
//                this.spDataPool2 = new float[array9.Length];
//                float num11 = 0f;
//                for (int num12 = 0; num12 < array9.Length; num12++)
//                {
//                    if (float.TryParse(array9[num12], ref num11))
//                    {
//                        this.spDataPool2[num12] = num11;
//                    }
//                    else
//                    {
//                        this.spDataPool2[num12] = 0f;
//                        NDebug.LogWaring("技能条件数值池2中错误的数值:" + num12);
//                    }
//                }
//            }
//            string string3 = jsonData["skin_action"].String;
//            if (string3.get_Length() > 0)
//            {
//                string[] array10 = string3.Split(new char[]
//                {
//                ','
//                });
//                if (array10.Length > 0)
//                {
//                    this.dicSkinAction = new Dictionary<int, int>();
//                    for (int num13 = 0; num13 < array10.Length; num13++)
//                    {
//                        string[] array11 = array10[num13].Split(new char[]
//                        {
//                        ':'
//                        });
//                        int num14 = 0;
//                        int num15 = 0;
//                        if (array11.Length > 1 && int.TryParse(array11[0], ref num14) && int.TryParse(array11[1], ref num15))
//                        {
//                            this.dicSkinAction.Add(num14, num15);
//                        }
//                    }
//                }
//            }
//        }

//        // Token: 0x17000588 RID: 1416
//        // (get) Token: 0x06001703 RID: 5891 RVA: 0x00077CE4 File Offset: 0x00075EE4
//        // (set) Token: 0x06001704 RID: 5892 RVA: 0x00077CF8 File Offset: 0x00075EF8
//        public string name
//        {
//            get
//            {
//                return PLTable.Instance.GetTableLang(this.nameId);
//            }
//            set
//            {
//                this.nameId = value;
//            }
//        }

//        // Token: 0x17000589 RID: 1417
//        // (get) Token: 0x06001705 RID: 5893 RVA: 0x00077D04 File Offset: 0x00075F04
//        // (set) Token: 0x06001706 RID: 5894 RVA: 0x00077D18 File Offset: 0x00075F18
//        public string description
//        {
//            get
//            {
//                return PLTable.Instance.GetTableLang(this.descriptionId);
//            }
//            set
//            {
//                this.descriptionId = value;
//            }
//        }

//        // Token: 0x1700058A RID: 1418
//        // (get) Token: 0x06001707 RID: 5895 RVA: 0x00077D24 File Offset: 0x00075F24
//        public string prefixName
//        {
//            get
//            {
//                return PLTable.Instance.GetTableLang(this.prefixNameId);
//            }
//        }

//        // Token: 0x1700058B RID: 1419
//        // (get) Token: 0x06001708 RID: 5896 RVA: 0x00077D38 File Offset: 0x00075F38
//        public string prefixNameColored
//        {
//            get
//            {
//                return (!this.isRare) ? PLTable.Instance.GetTableLang(this.prefixNameId) : ("<color=#FFB400FF>" + PLTable.Instance.GetTableLang(this.prefixNameId) + "</color>");
//            }
//        }

//        // Token: 0x1700058C RID: 1420
//        // (get) Token: 0x06001709 RID: 5897 RVA: 0x00077D84 File Offset: 0x00075F84
//        // (set) Token: 0x0600170A RID: 5898 RVA: 0x00077D98 File Offset: 0x00075F98
//        public string lvupDescription
//        {
//            get
//            {
//                return PLTable.Instance.GetTableLang(this.lvupDescriptionId);
//            }
//            set
//            {
//                this.lvupDescriptionId = value;
//            }
//        }

//        // Token: 0x1700058D RID: 1421
//        // (get) Token: 0x0600170B RID: 5899 RVA: 0x00077DA4 File Offset: 0x00075FA4
//        public string skillCd
//        {
//            get
//            {
//                return Data.GetLang(LanguageConfig.ELANS_TYPE_BATTLE.冷却时间_80) + this.cdTime + Data.GetLang(LanguageConfig.ELANS_TYPE_MISSIONSELECTION.回合_31);
//            }
//        }

//        // Token: 0x0600170C RID: 5900 RVA: 0x00077DE0 File Offset: 0x00075FE0
//        public long GetID()
//        {
//            return (long)this.id;
//        }

//        // Token: 0x0600170D RID: 5901 RVA: 0x00077DEC File Offset: 0x00075FEC
//        public bool IsActiveSkill()
//        {
//            return this.type == 1;
//        }

//        // Token: 0x0600170E RID: 5902 RVA: 0x00077DF8 File Offset: 0x00075FF8
//        public bool IsCommonSkill()
//        {
//            return this.type == 3;
//        }

//        // Token: 0x0600170F RID: 5903 RVA: 0x00077E04 File Offset: 0x00076004
//        public int GetDuration(BattleCharacterController self)
//        {
//            int skillValue = SkillUtils.GetSkillValue(this._duration);
//            if (skillValue == this._duration)
//            {
//                return skillValue;
//            }
//            if (skillValue == 0 && self != null)
//            {
//                return SkillUtils.GetDuration(self);
//            }
//            return skillValue;
//        }

//        // Token: 0x04001500 RID: 5376
//        public int id;

//        // Token: 0x04001501 RID: 5377
//        private string nameId;

//        // Token: 0x04001502 RID: 5378
//        public int skillGroupId;

//        // Token: 0x04001503 RID: 5379
//        public int type;

//        // Token: 0x04001504 RID: 5380
//        public int skillPriority;

//        // Token: 0x04001505 RID: 5381
//        private string descriptionId;

//        // Token: 0x04001506 RID: 5382
//        public string code;

//        // Token: 0x04001507 RID: 5383
//        public int trainCoinType;

//        // Token: 0x04001508 RID: 5384
//        public int trainCoinNumber;

//        // Token: 0x04001509 RID: 5385
//        public int trainTime;

//        // Token: 0x0400150A RID: 5386
//        public int daynightOnly;

//        // Token: 0x0400150B RID: 5387
//        public int interruptType;

//        // Token: 0x0400150C RID: 5388
//        public int interruptDamageLimit;

//        // Token: 0x0400150D RID: 5389
//        public int cdType;

//        // Token: 0x0400150E RID: 5390
//        public int weight;

//        // Token: 0x0400150F RID: 5391
//        public int cdTime;

//        // Token: 0x04001510 RID: 5392
//        public int startCdTime;

//        // Token: 0x04001511 RID: 5393
//        public int targetSelectAi;

//        // Token: 0x04001512 RID: 5394
//        public int targetLost;

//        // Token: 0x04001513 RID: 5395
//        public int triggerType;

//        // Token: 0x04001514 RID: 5396
//        public int triggerTargetType;

//        // Token: 0x04001515 RID: 5397
//        public int triggerParameter;

//        // Token: 0x04001516 RID: 5398
//        public int triggerBuffId;

//        // Token: 0x04001517 RID: 5399
//        public int actionId;

//        // Token: 0x04001518 RID: 5400
//        private int _duration;

//        // Token: 0x04001519 RID: 5401
//        public int buffDelay;

//        // Token: 0x0400151A RID: 5402
//        public List<int> buffTarget;

//        // Token: 0x0400151B RID: 5403
//        public List<int> buffTargetNum;

//        // Token: 0x0400151C RID: 5404
//        public List<int> buffSelf;

//        // Token: 0x0400151D RID: 5405
//        public List<int> buffSelfNum;

//        // Token: 0x0400151E RID: 5406
//        public bool isFormAction;

//        // Token: 0x0400151F RID: 5407
//        public bool isSwitch;

//        // Token: 0x04001520 RID: 5408
//        public float[] dataPool1;

//        // Token: 0x04001521 RID: 5409
//        public float[] dataPool2;

//        // Token: 0x04001522 RID: 5410
//        public float[] dataPoolNight1;

//        // Token: 0x04001523 RID: 5411
//        public float[] dataPoolNight2;

//        // Token: 0x04001524 RID: 5412
//        public bool isReTarget;

//        // Token: 0x04001525 RID: 5413
//        public int spTriggerType;

//        // Token: 0x04001526 RID: 5414
//        public int spTriggerTargetType;

//        // Token: 0x04001527 RID: 5415
//        public int spTriggerParameter;

//        // Token: 0x04001528 RID: 5416
//        public int spTriggerBuffId;

//        // Token: 0x04001529 RID: 5417
//        public float[] spDataPool1;

//        // Token: 0x0400152A RID: 5418
//        public float[] spDataPool2;

//        // Token: 0x0400152B RID: 5419
//        public bool isRare;

//        // Token: 0x0400152C RID: 5420
//        public Dictionary<int, int> dicSkinAction;

//        // Token: 0x0400152D RID: 5421
//        public string prefixNameId = string.Empty;

//        // Token: 0x0400152E RID: 5422
//        public int fairyConsumption;

//        // Token: 0x0400152F RID: 5423
//        private string lvupDescriptionId;
//    }

//}
