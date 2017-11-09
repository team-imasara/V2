using Codeplex.Data;
using GFHelper.CatchData;
using GFHelper.CatchData.CatchDataFunc;
using GFHelper.Programe;
using GFHelper.Programe.ProgramePro;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using UnityEngine;

namespace GFHelper.UserData
{
    class UserDataSummery
    {
        public InstanceManager im;

        public UserDataSummery(InstanceManager im)
        {
            this.im = im;
        }
        public User_Info user_info = new User_Info();
        public Dictionary<int, Operation_Act_Info> operation_act_info = new Dictionary<int, Operation_Act_Info>();
        public Kalina_With_User_Info kalina_with_user_info = new Kalina_With_User_Info();
        public Dictionary<int, Gun_With_User_Info> gun_with_user_info = new Dictionary<int, Gun_With_User_Info>();//所有的枪
        public Dictionary<int, Friend_With_User_Info> friend_with_user_info = new Dictionary<int, Friend_With_User_Info>();
        public Dictionary<int, Equip_With_User_Info> equip_with_user_info = new Dictionary<int, Equip_With_User_Info>();

        public Dictionary<int, Equip_With_User_Info> equip_with_user_info_Rank5 = new Dictionary<int, Equip_With_User_Info>();
        public Dictionary<int, Equip_With_User_Info> equip_with_user_info_Rank4 = new Dictionary<int, Equip_With_User_Info>();
        public Dictionary<int, Equip_With_User_Info> equip_with_user_info_Rank3 = new Dictionary<int, Equip_With_User_Info>();
        public Dictionary<int, Equip_With_User_Info> equip_with_user_info_Rank2 = new Dictionary<int, Equip_With_User_Info>();
        public Dictionary<int, Equip_With_User_Info> equip_with_user_info_Upgrade = new Dictionary<int, Equip_With_User_Info>();

        public Dictionary<int, Item_With_User_Info> item_with_user_info = new Dictionary<int, Item_With_User_Info>();
        public User_Record user_record = new User_Record();
        public Dictionary<int, MailList> maillist = new Dictionary<int, MailList>();
        public Dorm_With_User_Info dorm_with_user_info = new Dorm_With_User_Info();
        public int Dorm_Rest_Friend_Build_Coin_Count;

        public Programe.Auto.User_Simulation_BattleTaskInfo usbti = new Programe.Auto.User_Simulation_BattleTaskInfo();

        // Token: 0x040016FF RID: 5887
        public Dictionary<int, CatchData.Fairy> dictTeamFairy = new Dictionary<int, CatchData.Fairy>();
        /// <summary>
        /// team_info,int key 就是一个梯队
        /// </summary>
        public Dictionary<int, Dictionary<int,Gun_With_User_Info>> team_info = new Dictionary<int, Dictionary<int,Gun_With_User_Info>>();//没读一次user_info都需要刷新
        public static List<int> Gun_Retire_Rank2 = new List<int>();
        public static List<int> Gun_Retire_Rank3 = new List<int>();
        public static Dictionary<int, Gun_With_User_Info> dicGun_PowerUP = new Dictionary<int,Gun_With_User_Info>();
        public static Dictionary<int, Gun_With_User_Info> dicGun_Combine = new Dictionary<int, Gun_With_User_Info>();
        public static Auto_Mission_Act_Info amai = new Auto_Mission_Act_Info();
        public static Dictionary<int, upgrade_act_info> upgrade_act_info = new Dictionary<int, upgrade_act_info>();

        public int FriendLv;
        public bool Mission_S;

        public void ClearUserData()
        {
            user_info = new User_Info();
            this.operation_act_info.Clear();
            this.kalina_with_user_info = new Kalina_With_User_Info();
            this.gun_with_user_info.Clear();
            this.friend_with_user_info.Clear();

            //equip
            this.equip_with_user_info.Clear();
            this.equip_with_user_info_Rank2.Clear();
            this.equip_with_user_info_Rank3.Clear();
            this.equip_with_user_info_Rank4.Clear();
            this.equip_with_user_info_Rank5.Clear();

            this.user_record = new User_Record();
            this.maillist.Clear();
            EmptyOperation_Act_Info();

        }

        public bool ReadUserData_user_info(dynamic jsonobj)
        {
            try
            {
                user_info.id = Convert.ToInt32(jsonobj.user_info.id);
                user_info.user_id = Convert.ToInt32(jsonobj.user_info.user_id);
                user_info.open_id = jsonobj.user_info.open_id.ToString();
                user_info.channel_id = jsonobj.user_info.channel_id.ToString();
                user_info.sign = jsonobj.user_info.sign.ToString();
                user_info.name = jsonobj.user_info.name.ToString();
                user_info.gem = Convert.ToInt32(jsonobj.user_info.gem);
                user_info.pause_turn_chance = Convert.ToInt32(jsonobj.user_info.pause_turn_chance);
                user_info.lv = Convert.ToInt32(jsonobj.user_info.lv);
                user_info.maxequip = Convert.ToInt32(jsonobj.user_info.maxequip);
                user_info.experience = Convert.ToInt32(jsonobj.user_info.experience);


                user_info.maxgun = Convert.ToInt32(jsonobj.user_info.maxgun);
                user_info.maxteam = Convert.ToInt32(jsonobj.user_info.maxteam);
                user_info.max_build_slot = Convert.ToInt32(jsonobj.user_info.max_build_slot);
                user_info.max_equip_build_slot = Convert.ToInt32(jsonobj.user_info.max_equip_build_slot);
                user_info.max_fix_slot = Convert.ToInt32(jsonobj.user_info.max_fix_slot);
                user_info.max_upgrade_slot = Convert.ToInt32(jsonobj.user_info.max_upgrade_slot);
                user_info.max_gun_preset = Convert.ToInt32(jsonobj.user_info.max_gun_preset);
                user_info.max_fairy = Convert.ToInt32(jsonobj.user_info.max_fairy);
                user_info.maxdorm = Convert.ToInt32(jsonobj.user_info.maxdorm);
                user_info.bp = Convert.ToInt32(jsonobj.user_info.bp);

                user_info.bp_pay = Convert.ToInt32(jsonobj.user_info.bp_pay);
                user_info.mp = Convert.ToInt32(jsonobj.user_info.mp);
                user_info.ammo = Convert.ToInt32(jsonobj.user_info.ammo);
                user_info.mre = Convert.ToInt32(jsonobj.user_info.mre);
                user_info.part = Convert.ToInt32(jsonobj.user_info.part);
                user_info.core = Convert.ToInt32(jsonobj.user_info.core);
                user_info.coin1 = Convert.ToInt32(jsonobj.user_info.coin1);
                user_info.coin2 = Convert.ToInt32(jsonobj.user_info.coin2);
                user_info.coin3 = Convert.ToInt32(jsonobj.user_info.coin3);
                try
                {
                    Int32.TryParse(jsonobj.monthlycard1_end_time, out user_info.monthlycard1_end_time);
                    Int32.TryParse(jsonobj.monthlycard2_end_time, out user_info.monthlycard2_end_time);
                }
                catch (Exception)
                {
                }


                user_info.growthfond = Convert.ToInt32(jsonobj.user_info.growthfond);
                user_info.last_recover_time = Convert.ToInt32(jsonobj.user_info.last_recover_time);
                user_info.last_bp_recover_time = Convert.ToInt32(jsonobj.user_info.last_bp_recover_time);
                user_info.last_favor_recover_time = Convert.ToInt32(jsonobj.user_info.last_favor_recover_time);

                try
                {
                    Int32.TryParse(jsonobj.last_monthlycard1_recover_time, out user_info.last_monthlycard1_recover_time);
                    Int32.TryParse(jsonobj.last_monthlycard2_recover_time, out user_info.last_monthlycard2_recover_time);
                }
                catch (Exception)
                {
                }


                user_info.last_login_time = Convert.ToInt32(jsonobj.user_info.last_login_time);
                user_info.reg_time = Convert.ToInt32(jsonobj.user_info.reg_time);


                foreach (var item in jsonobj.user_info.gun_collect.Split(','))
                {
                    if (String.IsNullOrEmpty(item)) continue;
                    user_info.gun_collect.Add(Convert.ToInt32(item));
                }
                user_info.last_dorm_material_change_time1 = Convert.ToInt32(jsonobj.user_info.last_dorm_material_change_time1);
                user_info.last_dorm_material_change_time2 = Convert.ToInt32(jsonobj.user_info.last_dorm_material_change_time2);
                user_info.material_available_num1 = Convert.ToInt32(jsonobj.user_info.material_available_num1);
                user_info.material_available_num2 = Convert.ToInt32(jsonobj.user_info.material_available_num2);
                user_info.dorm_max_score = Convert.ToInt32(jsonobj.user_info.dorm_max_score);

            }
            catch (Exception e)
            {

                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取UserData_user_info遇到错误");
                    MessageBox.Show(e.ToString());
                });


                return false;
            }


            return true;
        }

        public bool ReadUserData_operation_act_info(dynamic jsonobj)
        {

            try
            {
                foreach (var item in jsonobj.operation_act_info)
                {
                    Operation_Act_Info oai = new Operation_Act_Info();

                    oai.key = operation_act_info.Count;
                    oai.id = Convert.ToInt32(item.id);
                    oai.operation_id = Convert.ToInt32(item.operation_id);
                    oai.user_id = Convert.ToInt32(item.user_id);
                    oai.team_id = Convert.ToInt32(item.team_id);
                    oai.start_time = Convert.ToInt32(item.start_time);

                    operation_act_info.Add(operation_act_info.Count, oai);

                }
            }
            catch (Exception e)
            {
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取UserData_operation_act_info遇到错误");
                    MessageBox.Show(e.ToString());
                });

                return false;
            }
            return true;
        }
        public void ReadUserData_upgrade_act_info(dynamic jsonobj)
        {
            upgrade_act_info.Clear();
            try
            {
                foreach (var item in jsonobj.upgrade_act_info)
                {
                    upgrade_act_info uai = new upgrade_act_info();

                    uai.user_id = Convert.ToInt32(item.user_id);
                    uai.gun_with_user_id = Convert.ToInt32(item.gun_with_user_id);
                    uai.skill = Convert.ToInt32(item.skill);
                    uai.upgrade_slot = Convert.ToInt32(item.upgrade_slot);
                    uai.fairy_with_user_id = Convert.ToInt32(item.fairy_with_user_id);
                    uai.end_time = Convert.ToInt32(item.end_time);

                    upgrade_act_info.Add(upgrade_act_info.Count, uai);

                }
            }
            catch (Exception e)
            {
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取UserData_upgrade_act_info遇到错误");
                    MessageBox.Show(e.ToString());
                });

                return;
            }
            return ;
        }

        public bool ReadUserData_kalina_with_user_info(dynamic jsonobj)
        {
            try
            {
                kalina_with_user_info.user_id =Convert.ToInt32(jsonobj.kalina_with_user_info.user_id);
                kalina_with_user_info.click_num = Convert.ToInt32(jsonobj.kalina_with_user_info.click_num);
                kalina_with_user_info.click_time = Convert.ToInt32(jsonobj.kalina_with_user_info.click_time);
                kalina_with_user_info.level = Convert.ToInt32(jsonobj.kalina_with_user_info.level);
                kalina_with_user_info.favor = Convert.ToInt32(jsonobj.kalina_with_user_info.favor);
                kalina_with_user_info.last_favor = Convert.ToInt32(jsonobj.kalina_with_user_info.last_favor);
                kalina_with_user_info.skin = Convert.ToInt32(jsonobj.kalina_with_user_info.skin);
                kalina_with_user_info.send_mail_time = Convert.ToInt32(jsonobj.kalina_with_user_info.send_mail_time);
            }
            catch (Exception e)
            {
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取UserData_kalina_with_user_info遇到错误");
                    MessageBox.Show(e.ToString());
                });

                return false;
            }


            return true;
        }

        public bool ReadUserData_gun_with_user_info(dynamic jsonobj)
        {
            gun_with_user_info.Clear();
            try
            {
                foreach (var item in jsonobj.gun_with_user_info)
                {
                    Gun_With_User_Info gwui = new Gun_With_User_Info(im);

                    gwui.id = Convert.ToInt32(item.id);
                    gwui.user_id = Convert.ToInt32(item.user_id);
                    gwui.gun_id = Convert.ToInt32(item.gun_id);
                    gwui._gun_exp = Convert.ToInt32(item.gun_exp);
                    gwui.gun_level = Convert.ToInt32(item.gun_level);
                    gwui._level = gwui.gun_level;
                    gwui.level = gwui.gun_level;
                    gwui.team_id = Convert.ToInt32(item.team_id);
                    gwui.teamId = gwui.team_id;
                    gwui.if_modification = Convert.ToInt32(item.if_modification);
                    gwui.location = Convert.ToInt32(item.location);
                    gwui.position = Convert.ToInt32(item.position);
                    gwui.life = Convert.ToInt32(item.life);
                    gwui.ammo = Convert.ToInt32(item.ammo);
                    gwui.mre = Convert.ToInt32(item.mre);

                    gwui.pow = Convert.ToInt32(item.pow);
                    gwui.hit = Convert.ToInt32(item.hit);
                    gwui.additionHit = gwui.hit;
                    gwui.dodge = Convert.ToInt32(item.dodge);
                    gwui.additionDodge = gwui.dodge;
                    gwui.rate = Convert.ToInt32(item.rate);
                    gwui.info.maxAddRate = gwui.rate;
                    gwui.skill1 = Convert.ToInt32(item.skill1);
                    gwui.skill2 = Convert.ToInt32(item.skill2);
                    gwui.fix_end_time = Convert.ToInt32(item.fix_end_time);
                    gwui.is_locked = Convert.ToInt32(item.is_locked);
                    gwui.number = Convert.ToInt32(item.number);
                    gwui.equip1 = Convert.ToInt32(item.equip1);
                    gwui.equip2 = Convert.ToInt32(item.equip2);
                    gwui.equip3 = Convert.ToInt32(item.equip3);
                    gwui.equip4 = Convert.ToInt32(item.equip4);
                    gwui.favor = Convert.ToInt32(item.favor);
                    gwui.max_favor = Convert.ToInt32(item.max_favor);
                    gwui.favor_toplimit = Convert.ToInt32(item.favor_toplimit);
                    gwui.soul_bond = Convert.ToInt32(item.soul_bond);
                    gwui.skin = Convert.ToInt32(item.skin);
                    gwui.can_click = Convert.ToInt32(item.can_click);
                    //gwui.UpdateMaxLife();
                    gwui.UpdateData();
                    //gwui.crit = Convert.ToInt32(item.crit);
                    //gwui.piercing = Convert.ToInt32(item.piercing);
                    //gwui.maxLife = Convert.ToInt32(item.maxLife);
                    //gwui.bulletNumber = Convert.ToInt32(item.bulletNumber);
                    //float.TryParse(item.nightResistance, out gwui.nightResistance);
                    //gwui.fairyPow = Convert.ToInt32(item.fairyPow);
                    //gwui.fairyHit = Convert.ToInt32(item.fairyHit);
                    //gwui.fairyDodge = Convert.ToInt32(item.fairyDodge);
                    //gwui.fairyArmor = Convert.ToInt32(item.fairyArmor);
                    //gwui.criHarmRate = Convert.ToInt32(item.criHarmRate);
                    int i = 0;
                    while (true)
                    {
                        if (!gun_with_user_info.ContainsKey(i))
                        {
                            gun_with_user_info.Add(i, gwui);
                            break;
                        }
                        i++;
                    }

                }
            }
            catch (Exception e)
            {
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取UserData_gun_with_user_info遇到错误");
                    MessageBox.Show(e.ToString());
                });

                return false;
            }




            return true;
        }

        public bool ReadUserData_friend_with_user_info(dynamic jsonobj)
        {
            friend_with_user_info.Clear();
            try
            {
                foreach (var item in jsonobj.friend_with_user_info)
                {
                    Friend_With_User_Info fwui = new Friend_With_User_Info();

                    fwui.type = Convert.ToInt32(item.type);
                    fwui.f_userid = Convert.ToInt32(item.f_userid);
                    fwui.name = item.name.ToString();
                    fwui.lv = Convert.ToInt32(item.lv);
                    fwui.headpic_id = Convert.ToInt32(item.headpic_id);
                    fwui.homepage_time = Convert.ToInt32(item.homepage_time);

                    friend_with_user_info.Add(friend_with_user_info.Count, fwui);
                }
            }
            catch (Exception e)
            {
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取UserData_friend_with_user_info遇到错误");
                    MessageBox.Show(e.ToString());
                });

                return false;
            }


            return true;
        }

        public bool ReadUserData_equip_with_user_info(dynamic jsonobj)
        {
            equip_with_user_info.Clear();
            //string abc = jsonobj.equip_with_user_info.ToString();
            try
            {
                foreach (var item in jsonobj.equip_with_user_info)
                {
                    Equip_With_User_Info ewui = new Equip_With_User_Info();


                    ewui.id = Convert.ToInt32(item.Value.id);
                    ewui.user_id = Convert.ToInt32(item.Value.user_id);
                    ewui.gun_with_user_id = Convert.ToInt32(item.Value.gun_with_user_id);
                    ewui.equip_id = Convert.ToInt32(item.Value.equip_id);
                    ewui.equip_exp = Convert.ToInt32(item.Value.equip_exp);
                    ewui.equip_level = Convert.ToInt32(item.Value.equip_level);
                    ewui.pow = Convert.ToInt32(item.Value.pow);
                    ewui.hit = Convert.ToInt32(item.Value.hit);
                    ewui.dodge = Convert.ToInt32(item.Value.dodge);
                    ewui.speed = Convert.ToInt32(item.Value.speed);
                    ewui.rate = Convert.ToInt32(item.Value.rate);
                    ewui.critical_harm_rate = Convert.ToInt32(item.Value.critical_harm_rate);
                    ewui.critical_percent = Convert.ToInt32(item.Value.critical_percent);
                    ewui.armor_piercing = Convert.ToInt32(item.Value.armor_piercing);
                    ewui.armor = Convert.ToInt32(item.Value.armor);
                    ewui.shield = Convert.ToInt32(item.Value.shield);
                    ewui.damage_amplify = Convert.ToInt32(item.Value.damage_amplify);
                    ewui.damage_reduction = Convert.ToInt32(item.Value.damage_reduction);
                    ewui.night_view_percent = Convert.ToInt32(item.Value.night_view_percent);

                    ewui.bullet_number_up = Convert.ToInt32(item.Value.bullet_number_up);
                    ewui.adjust_count = Convert.ToInt32(item.Value.adjust_count);
                    ewui.is_locked = Convert.ToInt32(item.Value.is_locked);
                    ewui.last_adjust = item.Value.last_adjust.ToString();
                    foreach (var x in CatchDataSummery.equip_info)
                    {
                        if (x.Value.id == Convert.ToInt32(item.Value.equip_id)) ewui.info = x.Value;
                    }
                    equip_with_user_info.Add(equip_with_user_info.Count, ewui);
                }
            }
            catch (Exception e)
            {
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取UserData_equip_with_user_info遇到错误");
                    MessageBox.Show(e.ToString());
                });

                return false;
            }
            return true;
        }

        public bool ReadUserData_item_with_user_info(dynamic jsonobj)
        {
            item_with_user_info.Clear();
            try
            {
                foreach (var item in jsonobj.item_with_user_info)
                {
                    Item_With_User_Info iwui = new Item_With_User_Info();
                    iwui.item_id = Convert.ToInt32(item.item_id);
                    iwui.number = Convert.ToInt32(item.number);
                    item_with_user_info.Add(item_with_user_info.Count, iwui);
                }
            }
            catch (Exception e)
            {
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取UserData_item_with_user_info遇到错误");
                    MessageBox.Show(e.ToString());
                });

                return false;
            }
            return true;
        }

        public bool ReadUserData_user_record(dynamic jsonobj)
        {
            try
            {
                user_record.user_id = Convert.ToInt32(jsonobj.user_record.user_id);
                user_record.mission_campaign = Convert.ToInt32(jsonobj.user_record.mission_campaign);
                user_record.special_mission_campaign = jsonobj.user_record.special_mission_campaign.ToString();
                user_record.attendance_type1_day = Convert.ToInt32(jsonobj.user_record.attendance_type1_day);
                user_record.attendance_type1_time = Convert.ToInt32(jsonobj.user_record.attendance_type1_time);
                user_record.attendance_type2_day = Convert.ToInt32(jsonobj.user_record.attendance_type2_day);
                user_record.attendance_type2_time = Convert.ToInt32(jsonobj.user_record.attendance_type2_time);
                user_record.develop_lowrank_count = Convert.ToInt32(jsonobj.user_record.develop_lowrank_count);
                user_record.special_develop_lowrank_count = Convert.ToInt32(jsonobj.user_record.special_develop_lowrank_count);
                user_record.get_gift_ids = jsonobj.user_record.get_gift_ids.ToString();
                user_record.spend_point = Convert.ToDouble(jsonobj.user_record.spend_point);
                user_record.gem_mall_ids = jsonobj.user_record.gem_mall_ids.ToString();
                user_record.product_type21_ids = jsonobj.user_record.product_type21_ids.ToString();
                user_record.seven_attendance_days = jsonobj.user_record.seven_attendance_days.ToString();
                user_record.last_bp_buy_time = Convert.ToInt32(jsonobj.user_record.last_bp_buy_time);
                user_record.bp_buy_count = Convert.ToInt32(jsonobj.user_record.bp_buy_count);
                user_record.new_developgun_count = Convert.ToInt32(jsonobj.user_record.new_developgun_count);
                user_record.buyitem1_developgun_count = Convert.ToDouble(jsonobj.user_record.buyitem1_developgun_count);
                user_record.buyitem1_specialdevelopgun_count = Convert.ToDouble(jsonobj.user_record.buyitem1_specialdevelopgun_count);
                user_record.buyitem1_num = Convert.ToInt32(jsonobj.user_record.buyitem1_num);
                user_record.last_developgun_time = Convert.ToInt32(jsonobj.user_record.last_developgun_time);
                user_record.last_specialdevelopgun_time = Convert.ToInt32(jsonobj.user_record.last_specialdevelopgun_time);
                user_record.furniture_classes = jsonobj.user_record.furniture_classes.ToString();
                user_record.adjutant = jsonobj.user_record.adjutant.ToString();
            }
            catch (Exception e)
            {

                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取UserData_user_record遇到错误");
                    MessageBox.Show(e.ToString());
                });

                return false;
            }
            return true;

        }

        public void ReadAuto_Mission_Act_Info(dynamic jsonobj)
        {
            //amai
            try
            {

                if (jsonobj.auto_mission_act_info==null) return;
                amai.auto_mission_id = Convert.ToInt32(jsonobj.auto_mission_act_info.auto_mission_id);
                amai.user_id = Convert.ToInt32(jsonobj.auto_mission_act_info.user_id);

                amai.team_ids.Clear();

                foreach (var item in jsonobj.auto_mission_act_info.team_ids.Split(','))
                {
                    if (String.IsNullOrEmpty(item)) continue;
                    amai.team_ids.Add(Convert.ToInt32(item));
                }

                amai.end_time = Convert.ToInt32(jsonobj.auto_mission_act_info.end_time);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public bool ReadUserData_maillist(dynamic jsonobj)
        {
            maillist.Clear();
            try
            {
                foreach (var item in jsonobj)
                {
                    MailList ml = new MailList();

                    ml.id = Convert.ToInt32(item.id);
                    ml.user_id = Convert.ToInt32(item.user_id);
                    ml.type = Convert.ToInt32(item.type);
                    ml.sub_id = Convert.ToInt32(item.sub_id);
                    ml.user_exp = Convert.ToInt32(item.user_exp);
                    ml.mp = Convert.ToInt32(item.mp);
                    ml.ammo = Convert.ToInt32(item.ammo);
                    ml.mre = Convert.ToInt32(item.mre);
                    ml.part = Convert.ToInt32(item.part);
                    ml.core = Convert.ToInt32(item.core);
                    ml.gem = Convert.ToInt32(item.gem);
                    ml.gun_id = Convert.ToInt32(item.gun_id);
                    ml.item_ids = item.item_ids.ToString();
                    ml.equip_ids = item.equip_ids.ToString();
                    ml.furniture = item.furniture.ToString();
                    ml.gift = item.gift.ToString();
                    ml.coins = item.coins.ToString();
                    ml.skin = item.skin.ToString();
                    ml.title = item.title.ToString();
                    ml.content = item.content.ToString();
                    ml.code = item.code.ToString();
                    ml.start_time = Convert.ToInt32(item.start_time);
                    ml.end_time = Convert.ToInt32(item.end_time);
                    ml.if_read = Convert.ToInt32(item.if_read);

                    maillist.Add(maillist.Count, ml);
                }
            }
            catch (Exception e)
            {
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取UserData_maillist遇到错误");
                    MessageBox.Show(e.ToString());
                });


                return false;
            }
            return true;
        }

        public void ReadUserData_mission_act_info(dynamic jsonobj)
        {
            Mission_S = false;
            try
            {
                string data = jsonobj.mission_act_info.ToString();
                if (data.Length > 10)
                {
                    Mission_S = true;
                }
            }
            catch (Exception)
            {
                return;
            }



        }

        /// <summary>
        /// ReadDormData 不在 getuserinfo API接口上。 
        /// 需要单独 api接口 Friend/dormInfo
        /// </summary>
        /// <param name="jsonobj"></param>
        /// <returns></returns>
        public bool ReadDormData(dynamic jsonobj)
        {
            dorm_with_user_info = null;
            dorm_with_user_info = new Dorm_With_User_Info();
            try
            {
                dorm_with_user_info.info.dorm_id = jsonobj.info.dorm_id.ToString();
                dorm_with_user_info.info.praise_num = jsonobj.info.praise_num.ToString();
                dorm_with_user_info.info.user_id = jsonobj.info.user_id.ToString();
                dorm_with_user_info.info.visit_num = jsonobj.info.visit_num.ToString();
                dorm_with_user_info.current_build_coin = Convert.ToInt32(jsonobj.current_build_coin);
                dorm_with_user_info.build_coin_flag = Convert.ToInt32(jsonobj.build_coin_flag);
            }
            catch (Exception e)
            {

                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取DormData遇到错误");
                    MessageBox.Show(e.ToString());
                });

                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取BP信息
        /// </summary>
        /// <param name="jsonobj"></param>
        /// <returns></returns>
        public bool Read_BP_Info(dynamic jsonobj)
        {
            
            try
            {
                user_info.bp += Convert.ToInt32(jsonobj.recover_bp);
                user_info.last_bp_recover_time = Convert.ToInt32(jsonobj.last_bp_recover_time);
            }
            catch (Exception e)
            {

                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("读取BP_Info遇到错误");
                    MessageBox.Show(e.ToString());
                });

                return false;
            }
            return true;
        }

        public bool UpdateGun_Exp(dynamic jsonobj, ref int numE)
        {
            try
            {
                int x = 0;
                foreach (var item in jsonobj.gun_exp)
                {
                    //gun_with_user_id":"2547569"
                    int exp = Convert.ToInt32(item.exp);
                    int id = Convert.ToInt32(item.gun_with_user_id);

                    for(int i = 0; i <= gun_with_user_info.Last().Key + 1; i++)
                    {
                        if (gun_with_user_info.ContainsKey(i) == false) continue;

                        if (gun_with_user_info[i].level != 100 && gun_with_user_info[i].id== id)
                        {
                            if(Update_GUN_exp_level(exp, gun_with_user_info[i].gun_exp, gun_with_user_info[i].gun_level) > 0)
                            {
                                int maxlife0 = gun_with_user_info[i].maxLife;
                                gun_with_user_info[i].gun_exp += exp;
                                int maxlife1 = gun_with_user_info[i].maxLife;
                                numE += maxlife1 - maxlife0;
                            }
                            else
                            {
                                gun_with_user_info[i].gun_exp += exp;
                            }
                        }

                    }
                }

                //更新数据 能否升级
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(" 更新少女经验出错");
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        public bool Add_Get_Gun_Equip_Battle(dynamic jsonobj)
        {
            //battle_get_equip
            if (jsonobj.ToString().Contains("battle_get_equip") == true)
            {
                try
                {
                    Equip_With_User_Info ewui = new Equip_With_User_Info();
                    ewui.id = Convert.ToInt32(jsonobj.battle_get_equip.id);
                    ewui.user_id = Convert.ToInt32(jsonobj.battle_get_equip.user_id);
                    ewui.gun_with_user_id = Convert.ToInt32(jsonobj.battle_get_equip.gun_with_user_id);
                    ewui.equip_id = Convert.ToInt32(jsonobj.battle_get_equip.equip_id);
                    ewui.equip_exp = Convert.ToInt32(jsonobj.battle_get_equip.equip_exp);
                    ewui.equip_level = Convert.ToInt32(jsonobj.battle_get_equip.equip_level);
                    ewui.pow = Convert.ToInt32(jsonobj.battle_get_equip.pow);
                    ewui.hit = Convert.ToInt32(jsonobj.battle_get_equip.hit);
                    ewui.dodge = Convert.ToInt32(jsonobj.battle_get_equip.dodge);
                    ewui.speed = Convert.ToInt32(jsonobj.battle_get_equip.speed);
                    ewui.rate = Convert.ToInt32(jsonobj.battle_get_equip.rate);
                    ewui.critical_harm_rate = Convert.ToInt32(jsonobj.battle_get_equip.critical_harm_rate);
                    ewui.critical_percent = Convert.ToInt32(jsonobj.battle_get_equip.critical_percent);
                    ewui.armor_piercing = Convert.ToInt32(jsonobj.battle_get_equip.armor_piercing);
                    ewui.armor = Convert.ToInt32(jsonobj.battle_get_equip.armor);
                    ewui.shield = Convert.ToInt32(jsonobj.battle_get_equip.shield);
                    ewui.damage_amplify = Convert.ToInt32(jsonobj.battle_get_equip.damage_amplify);
                    ewui.damage_reduction = Convert.ToInt32(jsonobj.battle_get_equip.damage_reduction);
                    ewui.night_view_percent = Convert.ToInt32(jsonobj.battle_get_equip.night_view_percent);

                    ewui.bullet_number_up = Convert.ToInt32(jsonobj.battle_get_equip.bullet_number_up);
                    ewui.adjust_count = Convert.ToInt32(jsonobj.battle_get_equip.adjust_count);
                    ewui.is_locked = Convert.ToInt32(jsonobj.battle_get_equip.is_locked);
                    ewui.last_adjust = jsonobj.battle_get_equip.last_adjust.ToString();
                    int i = 0;
                    while (true)
                    {
                        if (!equip_with_user_info.ContainsKey(i))
                        {
                            equip_with_user_info.Add(i, ewui);
                            break;
                        }
                        i++;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(" 添加掉落装备遇到错误");
                    MessageBox.Show(e.ToString());
                    return false;
                }
            }
            
            if(jsonobj.ToString().Contains("battle_get_gun") == true)
            {
                try
                {
                    Gun_With_User_Info gwui = new Gun_With_User_Info(im);

                    gwui.id = Convert.ToInt32(jsonobj.battle_get_gun.gun_with_user_id);
                    gwui.gun_id = Convert.ToInt32(jsonobj.battle_get_gun.gun_id);
                    Check_NewGun(gwui.gun_id);
                    gwui.UpdateData();
                    int i = 0;
                    while (true)
                    {
                        if (!gun_with_user_info.ContainsKey(i))
                        {
                            gun_with_user_info[i] = gwui;
                            //gun_with_user_info.Add(i, gwui);
                            return true;
                        }
                        i++;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(" 添加人形掉落遇到错误");
                    MessageBox.Show(e.ToString());
                    return false;
                }
            }
            return true;
        }

        public void Check_NewGun(int gun_id)
        {
            if (!user_info.gun_collect.Contains(gun_id))
            {
                WriteLog.Log(string.Format("获取新人形 : {0} ,意不意外 惊不惊喜", Programe.TextRes.Asset_Textes.ChangeCodeFromeCSV(im.userdatasummery.FindGunName_GunId(gun_id))),"log");
                List<int> listLockid = new List<int>();
                listLockid.Add(gun_id);
                List<int> listUnLockid = new List<int>();

                im.uihelp.setStatusBarText_InThread(String.Format(" LOCK"));
                Thread.Sleep(2000);
                im.action.changeLock(listLockid, listUnLockid);



            }
            else
            {
                WriteLog.Log(string.Format("获取人形 : {0}", Programe.TextRes.Asset_Textes.ChangeCodeFromeCSV(im.userdatasummery.FindGunName_GunId(gun_id))),"log");
            }


        }

        public bool ReadUserData(dynamic jsonobj)
        {
            ClearUserData();
            Dorm_Rest_Friend_Build_Coin_Count = -1;
            try
            {
                ReadUserData_user_info(jsonobj);
                ReadUserData_operation_act_info(jsonobj);
                ReadUserData_kalina_with_user_info(jsonobj);
                ReadUserData_gun_with_user_info(jsonobj);
                ReadUserData_friend_with_user_info(jsonobj);
                ReadUserData_equip_with_user_info(jsonobj);
                ReadUserData_item_with_user_info(jsonobj);
                ReadUserData_user_record(jsonobj);
                Dorm_Rest_Friend_Build_Coin_Count = Convert.ToInt32(jsonobj.dorm_rest_friend_build_coin_count);

                ReadUserData_mission_act_info(jsonobj);

                ReadAuto_Mission_Act_Info(jsonobj);
                ReadUserData_upgrade_act_info(jsonobj);


                //如果operation_act_info不为空 则需要更新 自动后勤
                UpdateOperation_Act_Info();
                SetTeamInfo();

                //设置一些开关
                im.auto_summery.NeedAuto_Click_Girls_In_Dorm = true;

                //ui更新
                im.uihelp.SetTeamInfo_In_Operation();

                Read_Equipment_Rank();
                FriendLv = GetFriendLv();
            }
            catch (Exception e)
            {
                MessageBox.Show("ReadUserData 出错");
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }



        public void SetTeamInfo()
        {
            team_info.Clear();
            try
            {
                for(int i = 1; i <= user_info.maxteam; i++)
                {
                    //一个小队一个小队寻找
                    Dictionary<int,Gun_With_User_Info> Dic_gwui = new Dictionary<int,Gun_With_User_Info>();
                    foreach (var item in gun_with_user_info)
                    {

                        if (item.Value.team_id == i)
                        {
                            //Dictionary<int, List<Gun_With_User_Info>>
                            //应该是一个小队5只手枪入列
                            //Gun_With_User_Info gwui = new Gun_With_User_Info(im);
                            //gwui = item.Value;
                            Dic_gwui.Add(item.Value.location, item.Value);
                        }
                    }
                    team_info.Add(i, Dic_gwui);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("建立梯队列表出现错误");
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// 检查是否满仓
        /// </summary>
        /// <returns></returns>
        public bool Check_Equip_GUN_FULL()
        {
            if (im.userdatasummery.gun_with_user_info.Count+10 >= im.userdatasummery.user_info.maxgun)
            {
                return true;
            }
            if (im.userdatasummery.equip_with_user_info.Count+10 >= im.userdatasummery.user_info.maxequip)
            {
                return true;
            }
            return false;

        }

        public void Read_Equipment_Rank()
        {
            this.equip_with_user_info_Rank2.Clear();
            this.equip_with_user_info_Rank3.Clear();
            this.equip_with_user_info_Rank4.Clear();
            this.equip_with_user_info_Rank5.Clear();
            try
            {
                foreach (var item in equip_with_user_info)
                {
                    //item.Value.equip_id用id 索引 catchdata的id 得到 5级
                    if (CatchDataSummery.equip_info[item.Value.equip_id - 1].rank == 5)
                    {
                        Equip_With_User_Info ewui_rank5 = new Equip_With_User_Info();
                        ewui_rank5 = item.Value;
                        equip_with_user_info_Rank5.Add(equip_with_user_info_Rank5.Count,ewui_rank5);
                    }

                    //item.Value.equip_id用id 索引 catchdata的id 得到 4级
                    if (CatchDataSummery.equip_info[item.Value.equip_id - 1].rank == 4)
                    {
                        Equip_With_User_Info ewui_rank4 = new Equip_With_User_Info();
                        ewui_rank4 = item.Value;
                        equip_with_user_info_Rank4.Add(equip_with_user_info_Rank4.Count, ewui_rank4);
                    }

                    //item.Value.equip_id用id 索引 catchdata的id 得到 3级
                    if (CatchDataSummery.equip_info[item.Value.equip_id - 1].rank == 3)
                    {
                        Equip_With_User_Info ewui_rank3 = new Equip_With_User_Info();
                        ewui_rank3 = item.Value;
                        equip_with_user_info_Rank3.Add(equip_with_user_info_Rank3.Count, ewui_rank3);
                    }

                    //item.Value.equip_id用id 索引 catchdata的id 得到 2级
                    if (CatchDataSummery.equip_info[item.Value.equip_id - 1].rank == 2)
                    {
                        Equip_With_User_Info ewui_rank2 = new Equip_With_User_Info();
                        ewui_rank2 = item.Value;
                        equip_with_user_info_Rank2.Add(equip_with_user_info_Rank2.Count, ewui_rank2);
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 返回false 表示没有2级枪了
        /// </summary>
        /// <returns></returns>
        public bool Get_Gun_Retire()
        {
            Gun_Retire_Rank2.Clear();
            Gun_Retire_Rank3.Clear();
            foreach (var item in gun_with_user_info)
            {
                if (item.Value.info.rank == 2 && item.Value.is_locked == 0 && item.Value.teamId==0)
                {
                    Gun_Retire_Rank2.Add(item.Value.id);
                    if (Gun_Retire_Rank2.Count == ProgrameData.Eat_Gun_rank2_num) break;
                }
            }
            foreach (var item in gun_with_user_info)
            {
                if (item.Value.info.rank == 3 && item.Value.is_locked == 0)
                {
                    Gun_Retire_Rank3.Add(item.Value.id);
                    if (Gun_Retire_Rank3.Count == 24) break;
                }
            }


            if (Gun_Retire_Rank2.Count > 0 || Gun_Retire_Rank3.Count > 0) return true;
            return false;
        }

        public string[] Get_Equipment_Food()
        {
            string[] strFood =new string[12];
            int count = 0;
            foreach (var item in equip_with_user_info_Rank2)
            {
                if (count == 12) return strFood;
                if(item.Value.gun_with_user_id == 0)
                {
                    strFood[count] = item.Value.id.ToString();
                    count++;
                }
            }

            foreach (var item in equip_with_user_info_Rank3)
            {
                if (count == 12) return strFood;
                if (item.Value.gun_with_user_id == 0)
                {
                    strFood[count] = item.Value.id.ToString();
                    count++;
                }
            }

            foreach (var item in equip_with_user_info_Rank4)
            {
                if (count == 12) return strFood;
                if (item.Value.gun_with_user_id == 0)
                {
                    strFood[count] = item.Value.id.ToString();
                    count++;
                }
            }
            return strFood;

        }

        /// <summary>
        /// 获取需要升级的装备
        /// </summary>
        public void Read_Equipment_Upgrade()
        {
            equip_with_user_info_Upgrade.Clear();
            int type=0;
            im.mainWindow.UpgradeEquipType.Dispatcher.Invoke(new Action(() => { type = im.mainWindow.UpgradeEquipType.SelectedIndex + 1; }));


            foreach (var item in equip_with_user_info_Rank5)
            {
                //5级装备等级小于10 没有被人形装备
                if(item.Value.equip_level<10 && CatchDataSummery.equip_info[item.Value.equip_id-1].type == type && item.Value.gun_with_user_id == 0)
                {
                    Equip_With_User_Info ewui_upgrade = new Equip_With_User_Info();
                    ewui_upgrade = item.Value;
                    equip_with_user_info_Upgrade.Add(equip_with_user_info_Upgrade.Count, ewui_upgrade);
                }
            }

        }








        /// <summary>
        /// 更新装备的经验值 loc 是 装备总表的位置 exp是升级的经验
        /// 不允许传入10级装备
        /// </summary>
        /// <param name="loc">123</param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public void Check_Equipment_Update(int id,int exp)
        {

            int key=-1;

            //当前装备的经验值
            foreach (var item in im.userdatasummery.equip_with_user_info)
            {
                if(item.Value.id == id)
                {
                    key = item.Key;
                    break;
                }
            }

            //开始比较 分别是需要升级或者不需要升级
            this.im.userdatasummery.equip_with_user_info[key].equip_level += this.im.userdatasummery.equip_with_user_info[key].GetLevelToBeAdded(exp);
            this.im.userdatasummery.equip_with_user_info[key].equip_exp += exp;

            //10级处理
            if(im.userdatasummery.equip_with_user_info[key].equip_level == 10)
            {
                //10级处理
            }


        }

        /// <summary>
        /// 删除退休人形gun_with_user_info
        /// </summary>
        public void Del_Gun_IN_Dict(int type)
        {
            for (int i = 0; i <= gun_with_user_info.Last().Key; i++)
            {
                if (gun_with_user_info.ContainsKey(i))
                {
                    switch (type)
                    {
                        case 2:
                            {
                                foreach (var x in Gun_Retire_Rank2)
                                {
                                    if (gun_with_user_info[i].id == x)
                                    {
                                        gun_with_user_info.Remove(i);
                                        break;
                                    }
                                }

                                break;
                            }

                        case 3:
                            {
                                foreach (var y in Gun_Retire_Rank3)
                                {
                                    if (gun_with_user_info[i].id == y)
                                    {
                                        gun_with_user_info.Remove(i);
                                        break;
                                    }
                                }

                                break;
                            }
                        default:
                            break;
                    }
                }
            }
            switch (type)
            {
                case 2:
                    {
                        Gun_Retire_Rank2.Clear();
                        break;
                    }
                case 3:
                    {
                        Gun_Retire_Rank3.Clear();
                        break;
                    }
                default:
                    break;
            }


        }

        /// <summary>
        /// 升级装备后删除对应的表
        /// </summary>
        /// <param name="res"></param>
        public void Del_Equip_IN_Dict(string[] res)
        {
            foreach (var item0 in res)
            {
                
                for(int i = 0; i < equip_with_user_info.Last().Key; i++)
                {
                    if (equip_with_user_info.ContainsKey(i))
                    {
                        if (Convert.ToInt32(item0) == equip_with_user_info[i].id)
                        {
                            equip_with_user_info.Remove(i);
                        }
                    }
                }

                for (int i = 0; i < equip_with_user_info_Rank2.Last().Key; i++)
                {
                    if (equip_with_user_info_Rank2.ContainsKey(i))
                    {
                        if (Convert.ToInt32(item0) == equip_with_user_info_Rank2[i].id)
                        {
                            equip_with_user_info_Rank2.Remove(i);
                        }
                    }


                }
                for (int i = 0; i < equip_with_user_info_Rank3.Last().Key; i++)
                {
                    if (equip_with_user_info_Rank3.ContainsKey(i))
                    {
                        if (Convert.ToInt32(item0) == equip_with_user_info_Rank3[i].id)
                        {
                            equip_with_user_info_Rank3.Remove(i);
                        }
                    }
                }
                for (int i = 0; i < equip_with_user_info_Rank4.Last().Key; i++)
                {
                    if (equip_with_user_info_Rank4.ContainsKey(i))
                    { 
                        if (Convert.ToInt32(item0) == equip_with_user_info_Rank4[i].id)
                        {
                            equip_with_user_info_Rank4.Remove(i);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 计算好友平均等级
        /// </summary>
        /// <returns></returns>
        public int GetFriendLv()
        {
            int count = 0, lv = 0;
            if (friend_with_user_info.Count == 0) return lv;
            try
            {

                foreach (var item in friend_with_user_info)
                {
                    count = count + item.Value.lv;
                }
                lv = ((int)((double)count / (double)friend_with_user_info.Count));
                return lv;
            }
            catch (Exception e)
            {
                MessageBox.Show("计算好友平均等级出错");
                MessageBox.Show(e.ToString());
                return 0;
            }
            

        }

        public int GetBatteryNum()
        {
            try
            {
                foreach (var item in item_with_user_info)
                {
                    if (item.Value.item_id == 506) return item.Value.number;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("解析电池数量出错");
                MessageBox.Show(e.ToString());

            }
            return 0;
        }
        public int GetFurniture_CoinNum()
        {
            try
            {
                foreach (var item in item_with_user_info)
                {
                    if (item.Value.item_id == 41) return item.Value.number;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("解析采购币数量出错");
                MessageBox.Show(e.ToString());

            }
            return 0;
        }
        public int GetExchange_CoinNum()
        {
            try
            {
                foreach (var item in item_with_user_info)
                {
                    if (item.Value.item_id == 42) return item.Value.number;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("解析兑换卷数量出错");
                MessageBox.Show(e.ToString());

            }
            return 0;
        }



        public void ReadMailList(string result)
        {
            var jsonobj = DynamicJson.Parse(result);
            im.userdatasummery.ReadUserData_maillist(jsonobj);
        }

        public int NeedDailyAttendance()
        {
            foreach (var item in im.userdatasummery.maillist)
            {
                if (Convert.ToInt32(item.Value.type) == 5)
                {
                    return item.Key;
                }
            }
            return -1;
        }


        public int NeedDailyGift_Kalina()
        {
            foreach (var item in im.userdatasummery.maillist)
            {
                if (Convert.ToInt32(item.Value.type) == 1)
                {
                    return item.Value.id;
                }
            }
            return -1;
        }

        //更新自动后勤信息
        public void UpdateOperation_Act_Info()
        {
            //没有后勤任务信息，不需要更新
            if (operation_act_info.Count == 0) return;
            int count = 0;
            foreach (var item in operation_act_info)
            {
                im.Dic_auto_operation_act[count++] =item.Value;
            }
        }

        public void EmptyOperation_Act_Info()
        {
            im.Dic_auto_operation_act.Clear();
            //4个后勤任务
            for (int x = 0; x < 4; x++)
            {
                Operation_Act_Info auto_operation_act = new Operation_Act_Info();
                im.Dic_auto_operation_act.Add(im.Dic_auto_operation_act.Count, auto_operation_act);
            }

        }


        public string FindGunName_GunId(int gun_id)
        {

            //在catchdata里找对应的枪
            try
            {
                foreach (var k in im.catchdatasummery.gun_info)
                {
                    if (gun_id == k.Value.id)
                    {
                        return k.Value.name;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("寻找人形名字出错");
                MessageBox.Show(e.ToString());
            }

            return "";
        }

        /// <summary>
        /// 返回将会升级的数目
        /// </summary>
        /// <param name="addexp"></param>
        /// <param name="current_exp"></param>
        /// <param name="current_level"></param>
        /// <returns></returns>
        public static int Update_GUN_exp_level(int addexp,int current_exp, int current_level)
        {
            int num = 0;//将会升级的数目
            if (current_level == 100)
            {
                return 0;
            }
            else
            {
                if(ExpToLevel(addexp + current_exp)== current_level)
                {
                    ;
                }
                else
                {
                    return ExpToLevel(addexp + current_exp)- current_level;
                }
            }

            return num;//返回升了多少次级和ref addexp 所剩下的
        }
        /// <summary>
        /// 返回的是所有经验对应的等级
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="isUser"></param>
        /// <returns></returns>
        public static int ExpToLevel(int exp, bool isUser = false)
        {
            int num = 0;
            while ((exp -= CurrentLeveMaxExp(++num, isUser)) >= 0)
            {
            }
            return num;
        }

        /// <summary>
        /// 获取等级的最大经验
        /// </summary>
        /// <param name="level"></param>
        /// <param name="isUser"></param>
        /// <returns></returns>
        public static int CurrentLeveMaxExp(int level, bool isUser = false)
        {
            if (isUser)
            {
                if (level <= 25)
                {
                    return level * 100;
                }
                if (level <= 99)
                {
                    return 100 * Mathf.FloorToInt(Mathf.Pow((float)level * 0.2f, 2f));
                }
                if (level <= 199)
                {
                    return 100 * Mathf.FloorToInt(Mathf.Pow((float)level * 0.11f, 2.5f));
                }
                return 100 * Mathf.FloorToInt(Mathf.Pow((float)level * 0.0118f, 9f));
            }
            else
            {
                if (level <= 25)
                {
                    return level * 100;
                }
                if (level <= 29)
                {
                    return 100 * Mathf.FloorToInt(Mathf.Pow((float)level * 0.15f, 2.4f));
                }
                if (level <= 69)
                {
                    return 100 * Mathf.FloorToInt(Mathf.Pow((float)level * 0.15f, 2.5f));
                }
                if (level <= 89)
                {
                    return 100 * Mathf.FloorToInt(Mathf.Pow((float)level * 0.15f, 2.6f));
                }
                return 100 * Mathf.FloorToInt(Mathf.Pow((float)level * 0.15f, 2.7f));
            }
        }
        /// <summary>
        /// mvp位置是8 其他 7 9 13 14
        /// </summary>
        /// <param name="teamid"></param>
        /// <param name="mvp"></param>
        public bool Update_GUN_Pos(int teamid,int mvpid)
        {
            //mvp位置是8
            //其他 7 9 13 14
            bool mvpPOSeEdited=false;
            List<int> listkey = new List<int>();

            StringBuilder stringBuilder = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(stringBuilder);
            jsonWriter.WriteObjectStart();

            int mvpkey = 0;
            for(int i = 1; i <= 5; i++)
            {
                if(im.userdatasummery.team_info[teamid][i].position!=8 && im.userdatasummery.team_info[teamid][i].id == mvpid)
                {
                    //还要修改gun_with_user_info 内的值
                    im.userdatasummery.team_info[teamid][i].position = 8;
                    mvpkey = i;
                    mvpPOSeEdited = true;
                    continue;
                }
                if (im.userdatasummery.team_info[teamid][i].position == 8 && im.userdatasummery.team_info[teamid][i].id == mvpid)
                {
                    continue;
                }
                listkey.Add(i);
            }
            int x = 0;
            foreach (var i in listkey)
            {
                switch (x++)
                {
                    case 0:
                        {
                            if (im.userdatasummery.team_info[teamid][i].position == 7) continue;
                            im.userdatasummery.team_info[teamid][i].position = 7;
                            int id = im.userdatasummery.team_info[teamid][i].id;
                            jsonWriter.WritePropertyName(id.ToString());
                            jsonWriter.Write(7);

                            break;
                        }
                    case 1:
                        {

                            if (mvpPOSeEdited)
                            {
                                int a = im.userdatasummery.team_info[teamid][mvpkey].id;
                                jsonWriter.WritePropertyName(a.ToString());
                                jsonWriter.Write(8);
                            }
                            if (im.userdatasummery.team_info[teamid][i].position == 9) continue;
                            im.userdatasummery.team_info[teamid][i].position = 9;
                            int id = im.userdatasummery.team_info[teamid][i].id;
                            jsonWriter.WritePropertyName(id.ToString());
                            jsonWriter.Write(9);
                            break;
                        }
                    case 2:
                        {
                            if (im.userdatasummery.team_info[teamid][i].position == 13) continue;
                            im.userdatasummery.team_info[teamid][i].position = 13;

                            int id = im.userdatasummery.team_info[teamid][i].id;
                            jsonWriter.WritePropertyName(id.ToString());
                            jsonWriter.Write(13);
                            break;
                        }
                    case 3:
                        {
                            if (im.userdatasummery.team_info[teamid][i].position == 14) continue;
                            im.userdatasummery.team_info[teamid][i].position = 14;

                            int id = im.userdatasummery.team_info[teamid][i].id;
                            jsonWriter.WritePropertyName(id.ToString());
                            jsonWriter.Write(14);
                            break;
                        }
                    default:
                        break;
                }
            }
            jsonWriter.WriteObjectEnd();
            string jsonstring = stringBuilder.ToString();

            if (jsonstring.Contains(":") == false) return true;
            int count = 0;
            while (true)
            {
                string result = im.post.setPosition(jsonstring);
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    Programe.ACTION.result_error_PRO(result, count++);
                }
            }

        }

        /// <summary>
        /// num是最小的口粮弹药数 如5-2N 必须大于1
        /// 返回TRUE是需要补给
        /// </summary>
        /// <param name="gunid"></param>
        /// <param name="num">num是最小的口粮弹药数 如5-2N 必须大于1</param>
        /// <returns></returns>
        public bool CheckGun_AMMO_MRC_NEED_SUPORT(int gunid,int num)
        {
            foreach (var item in gun_with_user_info)
            {
                if (item.Value.id == gunid)
                {
                    if(item.Value.ammo<=num || item.Value.mre<=num)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;

        }

        public void BattleFinish_ammo_mrc(int teamid)
        {
            for(int i = 1; i <= 5; i++)
            {
                if (team_info[teamid].ContainsKey(i))
                {
                    //存在这个队员
                    if (team_info[teamid][i].ammo > 0)
                    {
                        team_info[teamid][i].ammo--;
                    }
                    if (team_info[teamid][i].mre > 0)
                    {
                        team_info[teamid][i].mre--;
                    }
                }
            }
        }

        public void Gun_mre_ammo_REFILL(int gunid)
        {
            for(int i = 0; i <= gun_with_user_info.Last().Key + 1; i++)
            {
                if (gun_with_user_info.ContainsKey(i))
                {
                    if (gun_with_user_info[i].id == gunid)
                    {
                        gun_with_user_info[i].mre = 10;
                        gun_with_user_info[i].ammo = 5;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 战斗结束后的扣血
        /// </summary>
        /// <param name="teamID">队伍ID</param>
        /// <param name="pos">要扣血的位置</param>
        /// <param name="life_reduce">要扣血的血量 和 pos 一一对应</param>
        public void GUN_Life_reduce(int teamID,List<int> pos,List<int> life_reduce)
        {
            int count = 0;

            foreach (var item in pos)
            {
                for (int i = 1; i <= team_info[teamID].Count; i++)
                {
                    if(item == team_info[teamID][i].position)
                    {
                        if (count + 1 > life_reduce.Count) return;

                        team_info[teamID][i].life -= life_reduce[count];
                        count++;
                        if (team_info[teamID][i].life < 0)
                        {
                            team_info[teamID][i].life = 0;
                        }



                    }


                }
            }
        }

        public void Check_Gun_need_FIX(int teamID, double num)
        {
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查人形是否需要修复"));
            System.Threading.Thread.Sleep(1000);
            for (int i = 1; i <= team_info[teamID].Count; i++)
            {
                double k =(double)team_info[teamID][i].life / team_info[teamID][i].maxLife;
                if (k <= num)
                {
                    System.Threading.Thread.Sleep(2000);
                    if (im.action.Fix_Gun(team_info[teamID][i].id, true))
                    {
                        team_info[teamID][i].life = team_info[teamID][i].maxLife;
                    }
                }
            }

        }

        public bool CheckGunStatus(Gun_With_User_Info gwui)
        {
            //是否在后勤 自律 训练
            foreach (var x in im.userdatasummery.operation_act_info)
            {
                if (x.Value.team_id == gwui.team_id)
                {
                    return true;
                }
            }
            if (UserDataSummery.amai.team_ids.Contains(gwui.team_id)) return true;
            foreach (var y in UserDataSummery.upgrade_act_info)
            {
                if (y.Value.gun_with_user_id == gwui.id) return true;
            }
            return false;


        }



    }







}
