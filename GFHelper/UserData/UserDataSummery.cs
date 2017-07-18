﻿using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public Dictionary<int, Gun_With_User_Info> gun_with_user_info = new Dictionary<int, Gun_With_User_Info>();
        public Dictionary<int, Friend_With_User_Info> friend_with_user_info = new Dictionary<int, Friend_With_User_Info>();
        public Dictionary<int, Equip_With_User_Info> equip_with_user_info = new Dictionary<int, Equip_With_User_Info>();
        public Dictionary<int, Item_With_User_Info> item_with_user_info = new Dictionary<int, Item_With_User_Info>();
        public User_Record user_record = new User_Record();
        public Dictionary<int, MailList> maillist = new Dictionary<int, MailList>();


        public int FriendLv;
        public int Rank5EquipmentN;

        public void ClearUserData()
        {
            user_info = new User_Info();
            this.operation_act_info.Clear();
            this.kalina_with_user_info = new Kalina_With_User_Info();
            this.gun_with_user_info.Clear();
            this.friend_with_user_info.Clear();
            this.equip_with_user_info.Clear();
            this.user_record = new User_Record();
            this.maillist.Clear();
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
                MessageBox.Show("读取UserData_user_info遇到错误");
                MessageBox.Show(e.ToString());
                return false;
            }


            return true;
        }

        public bool ReadUserData_operation_act_info(dynamic jsonobj)
        {
            operation_act_info.Clear();
            try
            {
                foreach (var item in jsonobj.operation_act_info)
                {
                    Operation_Act_Info oai = new Operation_Act_Info();

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
                MessageBox.Show("读取UserData_operation_act_info遇到错误");
                MessageBox.Show(e.ToString());
                return false;
            }




            return true;
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
                MessageBox.Show("读取UserData_kalina_with_user_info遇到错误");
                MessageBox.Show(e.ToString());
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
                    Gun_With_User_Info gwui = new Gun_With_User_Info();

                    gwui.id = Convert.ToInt32(item.id);
                    gwui.user_id = Convert.ToInt32(item.user_id);
                    gwui.gun_id = Convert.ToInt32(item.gun_id);
                    gwui.gun_exp = Convert.ToInt32(item.gun_exp);
                    gwui.gun_level = Convert.ToInt32(item.gun_level);
                    gwui.team_id = Convert.ToInt32(item.team_id);
                    gwui.if_modification = Convert.ToInt32(item.if_modification);
                    gwui.location = Convert.ToInt32(item.location);
                    gwui.position = Convert.ToInt32(item.position);
                    gwui.life = Convert.ToInt32(item.life);
                    gwui.ammo = Convert.ToInt32(item.ammo);
                    gwui.mre = Convert.ToInt32(item.mre);
                    gwui.pow = Convert.ToInt32(item.pow);
                    gwui.hit = Convert.ToInt32(item.hit);
                    gwui.dodge = Convert.ToInt32(item.dodge);
                    gwui.rate = Convert.ToInt32(item.rate);
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

                    gun_with_user_info.Add(gun_with_user_info.Count, gwui);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("读取UserData_gun_with_user_info遇到错误");
                MessageBox.Show(e.ToString());
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
                MessageBox.Show("读取UserData_friend_with_user_info遇到错误");
                MessageBox.Show(e.ToString());
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

                    equip_with_user_info.Add(equip_with_user_info.Count, ewui);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("读取UserData_equip_with_user_info遇到错误");
                MessageBox.Show(e.ToString());
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
                MessageBox.Show("读取UserData_item_with_user_info遇到错误");
                MessageBox.Show(e.ToString());
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
                user_record.furniture_classes = Convert.ToInt32(jsonobj.user_record.furniture_classes);
                user_record.adjutant = jsonobj.user_record.adjutant.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("读取UserData_user_record遇到错误");
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;

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
                MessageBox.Show("读取UserData_maillist遇到错误");
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }

        public bool ReadUserData(dynamic jsonobj)
        {
            ClearUserData();
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

                Rank5EquipmentN = GetRank5Equipment();
                FriendLv = GetFriendLv();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


        public int GetRank5Equipment()
        {
            int count = 0;
            try
            {
                foreach (var item in equip_with_user_info)
                {
                    //item.Value.equip_id用id 索引 catchdata的id 得到 5级
                    if (im.catchdatasummery.equip_info[item.Value.equip_id - 1].rank == 5)
                        count++;
                }
                return count;

            }
            catch (Exception)
            {

                return 0;
            }
        }



        /// <summary>
        /// 计算好友平均等级
        /// </summary>
        /// <returns></returns>
        public int GetFriendLv()
        {
            int count = 0, lv = 0;
            try
            {
                foreach (var item in friend_with_user_info)
                {
                    count = count + item.Value.lv;
                }
                lv = ((int)((double)count / (double)friend_with_user_info.Count));
                return lv;
            }
            catch (Exception)
            {
                return 0;
            }
            

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
                    return item.Value.id;
                }
            }
            return -1;
        }

    }







}
