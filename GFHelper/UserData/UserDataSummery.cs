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

        public void ClearUserData()
        {
            user_info = new User_Info();
            this.operation_act_info.Clear();
            kalina_with_user_info= new Kalina_With_User_Info();
            this.gun_with_user_info.Clear();
            this.friend_with_user_info.Clear();
            this.equip_with_user_info.Clear();
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

            return true;
        }

        public bool ReadUserData_kalina_with_user_info(dynamic jsonobj)
        {

            return true;
        }

        public bool ReadUserData_gun_with_user_info(dynamic jsonobj)
        {

            return true;
        }

        public bool ReadUserData_friend_with_user_info(dynamic jsonobj)
        {

            return true;
        }

        public bool ReadUserData_equip_with_user_info(dynamic jsonobj)
        {

            return true;
        }

        public bool ReadUserData_item_with_user_info(dynamic jsonobj)
        {
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

        public bool ReadCatchData(dynamic jsonobj)
        {
            try
            {
                ReadUserData_user_info(jsonobj);
                ReadUserData_operation_act_info(jsonobj);
                ReadUserData_kalina_with_user_info(jsonobj);
                ReadUserData_gun_with_user_info(jsonobj);
                ReadUserData_friend_with_user_info(jsonobj);
                ReadUserData_equip_with_user_info(jsonobj);
            }
            catch (Exception)
            {

                return false;
            }


            return true;
        }


    }







}
