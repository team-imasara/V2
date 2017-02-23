﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFHelper.Models;
using Codeplex.Data;
using System.IO;

namespace GFHelper
{
    class DataHelper
    {
        public Dictionary<int, GunInfo> gunInfoDict;

        private InstanceManager im;
        public DataHelper(InstanceManager im)
        {
            this.gunInfoDict = new Dictionary<int, GunInfo>();
            this.im = im;

        }


        public void StartReadCatchData()
        {
            Task.Run(() =>
            {
                if (im.dataHelper.ReadCatchData())
                {
                    im.autoOperation.SetOperationInfo();
                    //im.autoOperation.StartRefresh();
                }
                else
                {
                    im.uiHelper.setStatusBarText_InThread("catchdata读取失败！请检查相关文件！");
                }


                im.logger.Log("配置文件加载成功");
            });
        }


        public void ClearData()
        {
            im.autoOperation.operationList.Clear();

            im.data.userInfo.dictionaryDailyStatistics.Clear();
            im.data.userInfo.dictionaryWeeklyStatistics.Clear();
            im.data.userInfo.listGunCollect.Clear();
            im.data.userInfo.gunWithUserID.Clear();
            im.data.userInfo.teamInfo.Clear();
            im.data.userInfo.item.Clear();

        }

        public GunWithUserInfo SimpleGetTeamGun(int team, int location)
        {
            try
            {
                return im.data.userInfo.teamInfo[team][location];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ReadCatchData()
        {

            string catchdatafile = "catchdata";
            string jsondata;
            try
            {
                jsondata = File.ReadAllText(catchdatafile);

                var jsonobj = DynamicJson.Parse(jsondata); //讲道理，我真不想写了

                //gun_info

                foreach (var gun in jsonobj.gun_info)
                {
                    GunInfo g = new GunInfo();
                    g.id = Convert.ToInt32(gun.id);
                    g.name = gun.name;
                    g.Introduce = gun.introduce;
                    g.code = gun.code;
                    g.type = (GunType)Convert.ToInt32(gun.type);
                    g.rank = Convert.ToInt32(gun.rank);
                    g.maxEquip = Convert.ToInt32(gun.max_equip);
                    g.ratioLife = Convert.ToInt32(gun.ratio_life);
                    g.baseAmmo = Convert.ToInt32(gun.baseammo);
                    g.baseMre = Convert.ToInt32(gun.basemre);
                    g.ammoAddWithnumber = Convert.ToInt32(gun.ammo_add_withnumber);
                    g.mreAddWithNumber = Convert.ToInt32(gun.mre_add_withnumber);
                    g.ratioPow = Convert.ToInt32(gun.ratio_pow);
                    g.ratioHit = Convert.ToInt32(gun.ratio_hit);
                    g.ratioRange = Convert.ToInt32(gun.ratio_range);
                    g.ratioSpeed = Convert.ToInt32(gun.ratio_speed);
                    g.ratioRate = Convert.ToInt32(gun.ratio_rate);
                    g.ratioCrit = Convert.ToInt32(gun.crit);
                    g.retireMp = Convert.ToInt32(gun.retiremp);
                    g.retireAmmo = Convert.ToInt32(gun.retireammo);
                    g.retireMre = Convert.ToInt32(gun.retiremre);
                    g.retirePart = Convert.ToInt32(gun.retirepart);
                    g.eatRatio = Convert.ToInt32(gun.eat_ratio);
                    g.developDuration = Convert.ToInt32(gun.develop_duration);
                    g.dialogue = gun.dialogue;
                    g.effectGridGunType = (GunType)Convert.ToInt32(gun.effect_guntype);
                    {
                        foreach (var item in gun.effect_grid_pos.Split(','))
                        {
                            if (String.IsNullOrEmpty(item)) continue;
                            g.listEffectGrid.Add(Convert.ToInt32(item));
                        }

                        foreach (var item in gun.effect_grid_effect.Split(';'))
                        {
                            if (String.IsNullOrEmpty(item)) continue;
                            var s = item.Split(',');
                            g.dictEffect.Add((EffectType)Convert.ToInt32(s[0]), Convert.ToInt32(s[1]));
                        }
                    }

                    g.skill1 = Convert.ToInt32(gun.skill1);
                    g.skill2 = Convert.ToInt32(gun.skill2);
                    g.special = Convert.ToInt32(gun.special);
                    g.extra = gun.extra;

                    Data.gunInfo.Add(g.id, g);
                }

                //operation_info

                foreach(var item in jsonobj.operation_info)
                {
                    OperationInfo o = new OperationInfo();
                    o.id = Convert.ToInt32(item.id);
                    o.campaign = Convert.ToInt32(item.campaign);
                    o.name = item.name;
                    o.description = item.description;
                    o.duration = Convert.ToInt32(item.duration);
                    o.mp = Convert.ToInt32(item.mp);
                    o.ammo = Convert.ToInt32(item.ammo);
                    o.mre = Convert.ToInt32(item.mre);
                    o.part = Convert.ToInt32(item.part);

                    {
                        foreach(var i in item.item_pool.Split(','))
                        {
                            if (String.IsNullOrEmpty(i)) continue;
                            o.itemPool.Add(Convert.ToInt32(i));
                        }
                    }

                    o.teamLeaderMinLevel = Convert.ToInt32(item.team_leader_min_level);
                    o.gunMin = Convert.ToInt32(item.gun_min);

                    {
                        o.gunTypeMin[0] = Convert.ToInt32(item.guntype1_min);
                        o.gunTypeMin[1] = Convert.ToInt32(item.guntype2_min);
                        o.gunTypeMin[2] = Convert.ToInt32(item.guntype3_min);
                        o.gunTypeMin[3] = Convert.ToInt32(item.guntype4_min);
                        o.gunTypeMin[4] = Convert.ToInt32(item.guntype5_min);
                        o.gunTypeMin[5] = Convert.ToInt32(item.guntype6_min);
                        o.gunTypeMin[6] = Convert.ToInt32(item.guntype7_min);
                    }

                    Data.operationInfo.Add(o.id, o);

                }

                //equip_info
                foreach(var item in jsonobj.equip_info)
                {
                    EquipInfo ei = new EquipInfo();
                    ei.id = Convert.ToInt32(item.id);
                    ei.name = item.name;
                    ei.description = item.description;
                    ei.rank = Convert.ToInt32(item.rank);
                    ei.category = Convert.ToInt32(item.category);
                    ei.type = Convert.ToInt32(item.type);
                    ei.pow = item.pow;
                    ei.hit = item.hit;
                    ei.dodge = item.dodge;
                    ei.speed = item.speed;
                    ei.rate = item.rate;
                    ei.criticalHarmRate = item.critical_harm_rate;
                    ei.criticalPercent = item.critical_percent;
                    ei.armorPiercing = item.armor_piercing;
                    ei.armor = item.armor;
                    ei.shield = item.shield;
                    ei.damageAmplify = item.damage_amplify;
                    ei.damageReduction = item.damage_reduction;
                    ei.nightViewPercent = item.night_view_percent;
                    ei.bulletNumberUp = item.bullet_number_up;
                    ei.slowDownPercent = item.slow_down_percent;
                    ei.slowDownRate = Convert.ToInt32(item.slow_down_rate);
                    ei.slowDownTime = Convert.ToInt32(item.slow_down_time);
                    ei.dotPercent = item.dot_percent;
                    ei.dotDamage = Convert.ToInt32(item.dot_damage);
                    ei.dotTime = Convert.ToInt32(item.dot_time);
                    ei.retireMp = Convert.ToInt32(item.retire_mp);
                    ei.retireAmmo = Convert.ToInt32(item.retire_ammo);
                    ei.retireMre = Convert.ToInt32(item.retire_mre);
                    ei.retirePart = Convert.ToInt32(item.retire_part);
                    ei.code = item.code;
                    ei.developDuration = Convert.ToInt32(item.develop_duration);
                    ei.company = item.company;
                    ei.skillLevelUp = Convert.ToInt32(item.skill_level_up);
                    ei.fitGuns = item.fit_guns;
                    ei.equipIntroduction = item.equip_introduction;

                    Data.equipInfo.Add(ei.id, ei);
                }

            }
            catch (IOException e)
            {
                im.logger.Log(e);
                return false;
            }
            catch (Exception e)
            {
                im.logger.Log(e);
                throw;
            }
            return true;
        }



        public bool ReadUserInfo(string jsondata)
        {
            try
            {
                ClearData();

                dynamic jsonobj = DynamicJson.Parse(jsondata);
                dynamic userdata = jsonobj.user_info;
                dynamic userrecord = jsonobj.user_record;
                //UserInfo userInfo = Data.userInfo;

                //user_info
                im.data.userInfo.userId = userdata.user_id;
                im.data.userInfo.name = userdata.name;
                im.data.userInfo.pauseTurnChance = Convert.ToInt32(userdata.pause_turn_chance);
                im.data.userInfo.gem = Convert.ToInt32(userdata.gem);
                im.data.userInfo.Exp = Convert.ToInt32(userdata.experience);
                im.data.userInfo.maxTeam = Convert.ToInt32(userdata.maxteam);
                im.data.userInfo.mp = Convert.ToInt32(userdata.mp);
                im.data.userInfo.ammo = Convert.ToInt32(userdata.ammo);
                im.data.userInfo.mre = Convert.ToInt32(userdata.mre);
                im.data.userInfo.part = Convert.ToInt32(userdata.part);
                im.data.userInfo.core = Convert.ToInt32(userdata.core);
                im.data.userInfo.maxGun = Convert.ToInt32(userdata.maxgun);
                im.data.userInfo.maxEquip = Convert.ToInt32(userdata.maxequip);
                im.data.userInfo.maxDevelopSlot = Convert.ToInt32(userdata.max_build_slot) / 2;
                im.data.userInfo.maxFixSlot = Convert.ToInt32(userdata.max_fix_slot);
                im.data.userInfo.maxUpgradeSlot = Convert.ToInt32(userdata.max_upgrade_slot);
                im.data.userInfo.coin1 = Convert.ToInt32(userdata.coin1);
                im.data.userInfo.coin2 = Convert.ToInt32(userdata.coin2);
                im.data.userInfo.coin3 = Convert.ToInt32(userdata.coin3);
                im.data.userInfo.bp = Convert.ToInt32(userdata.bp);
                im.data.userInfo.lastBpRecoverTime = Convert.ToInt32(userdata.last_bp_recover_time);
                im.data.userInfo.monthlyCardExpirationGem = Convert.ToInt32(userdata.monthlycard1_end_time);
                im.data.userInfo.monthlyCardExpirationRes = Convert.ToInt32(userdata.monthlycard2_end_time);




                //              "user_record": 

                im.data.userInfo.mission_campaign = Convert.ToInt32(userrecord.mission_campaign);
                im.data.userInfo.special_mission_campaign = userrecord.special_mission_campaign;
                im.data.userInfo.attendance_type1_day = Convert.ToInt32(userrecord.attendance_type1_day);
                im.data.userInfo.attendance_type1_time = Convert.ToInt32(userrecord.attendance_type1_time);
                im.data.userInfo.attendance_type2_day = Convert.ToInt32(userrecord.attendance_type2_day);
                im.data.userInfo.attendance_type2_time = Convert.ToInt32(userrecord.attendance_type2_time);
                im.data.userInfo.develop_lowrank_count = Convert.ToInt32(userrecord.develop_lowrank_count);
                im.data.userInfo.special_develop_lowrank_count = Convert.ToInt32(userrecord.special_develop_lowrank_count);
                im.data.userInfo.get_gift_ids = Convert.ToInt32(userrecord.get_gift_ids);
                im.data.userInfo.spend_point =userrecord.spend_point;
                im.data.userInfo.gem_mall_ids = userrecord.gem_mall_ids;
                im.data.userInfo.seven_attendance_days = Convert.ToInt32(userrecord.seven_attendance_days);
                im.data.userInfo.last_bp_buy_time = Convert.ToInt32(userrecord.last_bp_buy_time);
                im.data.userInfo.bp_buy_count = Convert.ToInt32(userrecord.bp_buy_count);
                im.data.userInfo.new_developgun_count = Convert.ToInt32(userrecord.new_developgun_count);
                im.data.userInfo.buyitem1_developgun_count = userrecord.buyitem1_developgun_count;
                im.data.userInfo.buyitem1_specialdevelopgun_count = userrecord.buyitem1_specialdevelopgun_count;
                im.data.userInfo.buyitem1_num = Convert.ToInt32(userrecord.buyitem1_num);
                im.data.userInfo.last_developgun_time = Convert.ToInt32(userrecord.last_developgun_time);
                im.data.userInfo.last_specialdevelopgun_time = Convert.ToInt32(userrecord.last_specialdevelopgun_time);
                im.data.userInfo.furniture_classes = Convert.ToInt32(userrecord.furniture_classes);
                im.data.userInfo.adjutant = userrecord.adjutant;




                //gun_collect
                string guncollect = userdata.gun_collect;
                if (guncollect[0] != ',')
                {
                    foreach (string id in guncollect.Split(','))
                    {
                        im.data.userInfo.listGunCollect.Add(Convert.ToInt32(id));
                    }

                }

                //gun_with_user_info
                foreach(var gun in jsonobj.gun_with_user_info)
                {
                    GunWithUserInfo g = new GunWithUserInfo();
                    g.Ammo = Convert.ToInt32(gun.ammo);
                    g.Dodge = Convert.ToInt32(gun.dodge);
                    g.FixEndTime = Convert.ToInt32(gun.fix_end_time);
                    g.GunExp = Convert.ToInt32(gun.gun_exp);
                    g.GunID = Convert.ToInt32(gun.gun_id);
                    g.GunLevel = Convert.ToInt32(gun.gun_level);
                    g.Hit = Convert.ToInt32(gun.hit);
                    g.ID = Convert.ToInt32(gun.id);
                    g.IfModification = Convert.ToBoolean(Convert.ToInt32(gun.if_modification));
                    g.IsLocked = Convert.ToBoolean(Convert.ToInt32(gun.is_locked));
                    g.Life = Convert.ToInt32(gun.life);
                    g.Location = Convert.ToInt32(gun.location);
                    g.Mre = Convert.ToInt32(gun.mre);
                    g.Number = Convert.ToInt32(gun.number);
                    g.Position = Convert.ToInt32(gun.position);
                    g.Pow = Convert.ToInt32(gun.pow);
                    g.Rate = Convert.ToInt32(gun.rate);
                    g.Skill1 = Convert.ToInt32(gun.skill1);
                    g.Skill2 = Convert.ToInt32(gun.skill2);
                    g.TeamID = Convert.ToInt32(gun.team_id);
                    g.UserID = Convert.ToInt32(gun.user_id);

                    g.UpdateData();

                    im.data.userInfo.gunWithUserID.Add(g);
                    if(g.TeamID != 0)
                    {
                        if (!im.data.userInfo.teamInfo.ContainsKey(g.TeamID))
                        {
                            im.data.userInfo.teamInfo.Add(g.TeamID, new Dictionary<int, GunWithUserInfo>());
                        }

                        im.data.userInfo.teamInfo[g.TeamID].Add(g.Location, g);
                    }

                }

                
                //item_with_user_info
                foreach(var item in jsonobj.item_with_user_info)
                {
                    int id = Convert.ToInt32(item.item_id);
                    int num = Convert.ToInt32(item.number);

                    im.data.userInfo.item.Add(id, num);
                }

                //develop_act_info
                foreach(var item in jsonobj.develop_act_info)
                {
                    im.uiHelper.setDevelopingTimer(im.timer, Convert.ToInt32(item.build_slot), Convert.ToInt32(item.gun_id), Convert.ToInt32(item.start_time) - SimpleInfo.timeoffset);
                }

                //operation_act_info
                int count = 0;
                im.data.user_operationInfo.Clear();
                foreach (var item in jsonobj.operation_act_info)
                {
                    try
                    {
                        foreach (var UIitem in im.data.UIauto_operationInfo)
                        {
                            if (UIitem.Value._operationId == item.operation_id)
                            {
                                UIitem.Value._LastTime = item.start_time + Data.operationInfo[item.operation_id].duration - DateTime.Now;
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }


                    im.mainWindow.Dispatcher.Invoke(() =>
                    {
                        if (count == 0)
                        {
                            AutoOperationInfo ao = new AutoOperationInfo(im);
                            ao.ReadAutoOperationInfo(Convert.ToInt32(item.team_id), Convert.ToInt32(item.operation_id), Convert.ToInt32(item.user_id), Convert.ToInt32(item.id), Convert.ToInt32(item.start_time));




                            im.data.user_operationInfo.Add(0, ao);
                        }
                        if (count == 1)
                        {
                            AutoOperationInfo ao = new AutoOperationInfo(im);
                            ao.ReadAutoOperationInfo(Convert.ToInt32(item.team_id), Convert.ToInt32(item.operation_id), Convert.ToInt32(item.user_id), Convert.ToInt32(item.id), Convert.ToInt32(item.start_time));

                            im.data.user_operationInfo.Add(1, ao);
                        }

                        if (count == 2)
                        {
                            AutoOperationInfo ao = new AutoOperationInfo(im);
                            ao.ReadAutoOperationInfo(Convert.ToInt32(item.team_id), Convert.ToInt32(item.operation_id), Convert.ToInt32(item.user_id), Convert.ToInt32(item.id), Convert.ToInt32(item.start_time));

                            im.data.user_operationInfo.Add(2, ao);
                        }

                        if (count == 3)
                        {

                            AutoOperationInfo ao = new AutoOperationInfo(im);
                            ao.ReadAutoOperationInfo(Convert.ToInt32(item.team_id), Convert.ToInt32(item.operation_id), Convert.ToInt32(item.user_id), Convert.ToInt32(item.id), Convert.ToInt32(item.start_time));

                            im.data.user_operationInfo.Add(3, ao);
                        }
                    }
                    );

                    count++;



                }

                //develop_equip_act_info
                
                foreach(KeyValuePair<string, dynamic> i in jsonobj.develop_equip_act_info)
                {
                    var item = i.Value;
                    im.uiHelper.setDevelopingTimer(im.timer, Convert.ToInt32(item.build_slot), Convert.ToInt32(item.equip_id), Convert.ToInt32(item.start_time) - SimpleInfo.timeoffset, true);
                }
            }
            catch(Exception e)
            {
                im.logger.Log(e);
                return false;
            }
            return true;

        }
    }
}
