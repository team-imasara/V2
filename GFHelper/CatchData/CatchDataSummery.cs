using System;
using System.Collections.Generic;
using GFHelper.Programe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Codeplex.Data;
using System.Windows;

namespace GFHelper.CatchData
{
    class CatchDataSummery
    {
        public InstanceManager im;

        public CatchDataSummery(InstanceManager im)
        {
            this.im = im;
        }

        public Dictionary<int, Auto_Mission_Info> auto_mission_info = new Dictionary<int, Auto_Mission_Info>();
        public Dictionary<int, Equip_Exp_Info> equip_exp_info = new Dictionary<int, Equip_Exp_Info>();
        public Dictionary<int, Equip_Info> equip_info = new Dictionary<int, Equip_Info>();
        public Dictionary<int, Gun_Info> gun_info = new Dictionary<int, Gun_Info>();
        public Dictionary<int, Gun_Type_Info> gun_type_info = new Dictionary<int, Gun_Type_Info>();
        public Dictionary<int, Kalina_Favor_Info> kalina_favor_info = new Dictionary<int, Kalina_Favor_Info>();
        public Dictionary<int, Operation_Info> operation_info = new Dictionary<int, Operation_Info>();


        public void ClearCatchData()
        {
            this.auto_mission_info.Clear();
            this.equip_exp_info.Clear();
            this.equip_info.Clear();
            this.gun_info.Clear();
            this.gun_type_info.Clear();
            this.kalina_favor_info.Clear();
            this.operation_info.Clear();
        }

        public bool ReadCatchData_auto_mission_info(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.auto_mission_info)
                {
                    Auto_Mission_Info ami = new Auto_Mission_Info();
                    ami.mission_id = Convert.ToInt32(item.mission_id);
                    ami.team_effect = Convert.ToInt32(item.team_effect);
                    ami.team_count = Convert.ToInt32(item.team_count);
                    ami.mp = Convert.ToInt32(item.mp);
                    ami.ammo = Convert.ToInt32(item.ammo);
                    ami.mre = Convert.ToInt32(item.mre);
                    ami.part = Convert.ToInt32(item.part);
                    ami.duration = Convert.ToInt32(item.duration);
                    ami.experience = Convert.ToInt32(item.experience);
                    ami.expect_gun_level = Convert.ToInt32(item.expect_gun_level);
                    ami.get_gun_num = Convert.ToInt32(item.get_gun_num);

                    foreach (var x in item.gun_n_pool.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        ami.gun_n_pool.Add(Convert.ToInt32(x));
                    }
                    foreach (var x in item.gun_1_pool.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        ami.gun_1_pool.Add(Convert.ToInt32(x));
                    }

                    //public List<int> gun_n_pool = new List<int>();
                    //public List<int> gun_1_pool = new List<int>();
                    int.TryParse(item.limit_guns, out ami.limit_guns);
                    ami.get_equip_num = Convert.ToInt32(item.get_equip_num);

                    foreach (var x in item.equip_n_pool.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        ami.equip_n_pool.Add(Convert.ToInt32(x));
                    }
                    foreach (var x in item.equip_1_pool.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        ami.equip_1_pool.Add(Convert.ToInt32(x));
                    }

                    ami.draw_event_id = Convert.ToInt32(item.draw_event_id);
                    int.TryParse(item.limit_equips, out ami.limit_equips);
                    auto_mission_info.Add(ami.mission_id, ami);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("读取CatchDdat遇到错误");
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }
        public bool ReadCatchData_equip_exp_info(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.equip_exp_info)
                {
                    Equip_Exp_Info eei = new Equip_Exp_Info();
                    eei.level = Convert.ToInt32(item.level);
                    eei.exp = Convert.ToInt32(item.exp);
                    equip_exp_info.Add(eei.level-1, eei);
                }
            }
            catch (Exception e )
            {
                MessageBox.Show("读取CatchData_equip_exp_info遇到错误");
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }
        public bool ReadCatchData_equip_info(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.equip_info)
                {
                    Equip_Info ei = new Equip_Info();
                    ei.id = Convert.ToInt32(item.id);
                    ei.name = item.name.ToString();
                    ei.description = item.description.ToString();
                    ei.rank =Convert.ToInt32(item.rank);
                    ei.category = Convert.ToInt32(item.category);//具体类型
                    ei.type = Convert.ToInt32(item.type);//3大类
                    ei.pow =item.pow.ToString();
                    ei.hit = item.hit.ToString();
                    ei.dodge = item.dodge.ToString();
                    ei.speed = item.speed.ToString();
                    ei.rate = item.rate.ToString();
                    ei.critical_harm_rate = item.critical_harm_rate.ToString();

                    foreach (var x in item.critical_percent.Split(','))
                    {
                        
                        if (String.IsNullOrEmpty(x)) continue;
                        ei.critical_percent.Add(Convert.ToInt32(x));
                    }

                    ei.armor_piercing = item.armor_piercing.ToString();
                    ei.armor = item.armor.ToString();
                    ei.shield = item.shield.ToString();
                    ei.damage_amplify = item.damage_amplify.ToString();
                    ei.damage_reduction = item.damage_reduction.ToString();
                    ei.night_view_percent = item.night_view_percent.ToString();
                    ei.bullet_number_up = item.bullet_number_up.ToString();
                    ei.slow_down_percent = item.slow_down_percent.ToString();
                    int.TryParse(item.slow_down_rate, out ei.slow_down_rate);
                    int.TryParse(item.slow_down_time, out ei.slow_down_time);
                    ei.dot_percent = item.dot_percent.ToString();
                    int.TryParse(item.dot_damage, out ei.dot_damage);
                    int.TryParse(item.dot_time, out ei.dot_time);
                    int.TryParse(item.retire_mp, out ei.retire_mp);
                    int.TryParse(item.retire_ammo, out ei.retire_ammo);
                    int.TryParse(item.retire_mre, out ei.retire_mre);
                    int.TryParse(item.retire_part, out ei.retire_part);
                    ei.code = item.code.ToString();
                    int.TryParse(item.develop_duration, out ei.develop_duration);
                    ei.company = item.company.ToString();
                    int.TryParse(item.skill_level_up, out ei.skill_level_up);
                    ei.fit_guns = item.fit_guns.ToString();
                    ei.equip_introduction = item.equip_introduction.ToString();

                    double.TryParse(item.powerup_mp, out ei.powerup_mp);
                    double.TryParse(item.powerup_ammo, out ei.powerup_ammo);
                    double.TryParse(item.powerup_mre, out ei.powerup_mre);
                    double.TryParse(item.powerup_part, out ei.powerup_part);
                    double.TryParse(item.exclusive_rate, out ei.exclusive_rate);
                    
                    foreach (var x in item.bonus_type.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        //x -> hit:5
                        string[] sArray = x.Split(':');
                        ei.bonus_type.Add(sArray[0].ToString(), Convert.ToInt32(sArray[1]));
                    }

                    int.TryParse(item.skill, out ei.skill);
                    int.TryParse(item.max_level, out ei.max_level);



                    equip_info.Add(ei.id - 1, ei);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("读取CatchData_equip_info遇到错误");
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }
        public bool ReadCatchData_gun_info(dynamic jsonobj)
        {
            int count = 0;
            try
            {
                foreach (var item in jsonobj.gun_info)
                {
                    Gun_Info gi = new Gun_Info();

                    int.TryParse(item.id, out gi.id);

                    gi.name = item.name.ToString();
                    gi.introduce = item.introduce.ToString();
                    gi.en_introduce = item.en_introduce.ToString();
                    gi.code = item.code.ToString();


                    int.TryParse(item.type, out gi.type);
                    int.TryParse(item.rank, out gi.rank);
                    int.TryParse(item.max_equip, out gi.max_equip);
                    int.TryParse(item.ratio_life, out gi.ratio_life);
                    int.TryParse(item.ratio_armor, out gi.ratio_armor);
                    int.TryParse(item.baseammo, out gi.baseammo);
                    int.TryParse(item.basemre, out gi.basemre);
                    int.TryParse(item.ammo_add_withnumber, out gi.ammo_add_withnumber);
                    int.TryParse(item.mre_add_withnumber, out gi.mre_add_withnumber);
                    int.TryParse(item.ratio_pow, out gi.ratio_pow);
                    int.TryParse(item.ratio_hit, out gi.ratio_hit);
                    int.TryParse(item.ratio_dodge, out gi.ratio_dodge);
                    int.TryParse(item.ratio_range, out gi.ratio_range);
                    int.TryParse(item.ratio_speed, out gi.ratio_speed);
                    int.TryParse(item.ratio_rate, out gi.ratio_rate);
                    int.TryParse(item.armor_piercing, out gi.armor_piercing);
                    int.TryParse(item.crit, out gi.crit);
                    int.TryParse(item.retiremp, out gi.retiremp);
                    int.TryParse(item.retireammo, out gi.retireammo);
                    int.TryParse(item.retiremre, out gi.retiremre);
                    int.TryParse(item.retirepart, out gi.retirepart);
                    int.TryParse(item.eat_ratio, out gi.eat_ratio);
                    int.TryParse(item.develop_duration, out gi.develop_duration);
                    gi.dialogue = item.dialogue.ToString();
                    int.TryParse(item.effect_grid_center, out gi.effect_grid_center);
                    int.TryParse(item.effect_guntype, out gi.effect_guntype);

                    foreach (var x in item.effect_grid_pos.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        gi.effect_grid_pos.Add(Convert.ToInt32(x));
                    }
                    foreach (var x in item.effect_grid_effect.Split(';'))
                    {
                        //1,10; 4,12
                        //x->1,10
                        if (String.IsNullOrEmpty(x)) continue;
                        string[] sArray = x.Split(',');
                        List<int> list = new List<int>();
                        foreach (var y in sArray)
                        {
                            list.Add(Convert.ToInt32(y));
                        }
                        gi.effect_grid_effect.Add(gi.effect_grid_effect.Count, list);
                    }

                    int.TryParse(item.skill1, out gi.skill1);
                    int.TryParse(item.skill2, out gi.skill2);
                    int.TryParse(item.repel_probability, out gi.repel_probability);
                    double.TryParse(item.repel_distance, out gi.repel_distance);
                    int.TryParse(item.special, out gi.special);
                    gi.extra = item.extra.ToString();

                    {
                        List<string> type_equip1 = new List<string>(item.type_equip1.Split(';'));
                        if (!string.IsNullOrEmpty(type_equip1[0]))
                        {
                            int.TryParse(type_equip1[0], out int type_equip1key);
                            List<int> list = new List<int>();

                            foreach (var y in type_equip1[1].Split(','))
                            {
                                int.TryParse(y, out int k);
                                list.Add(k);
                            }
                            gi.type_equip1.Add(type_equip1key, list);
                        }
                    }

                    {
                        List<string> type_equip2 = new List<string>(item.type_equip2.Split(';'));
                        if (!string.IsNullOrEmpty(type_equip2[0]))
                        {
                            int.TryParse(type_equip2[0], out int type_equip2key);
                            List<int> list = new List<int>();

                            foreach (var y in type_equip2[1].Split(','))
                            {
                                int.TryParse(y, out int k);
                                list.Add(k);
                            }
                            gi.type_equip2.Add(type_equip2key, list);
                        }
                    }

                    {
                        List<string> type_equip3 = new List<string>(item.type_equip3.Split(';'));
                        if (!string.IsNullOrEmpty(type_equip3[0]))
                        {
                            int.TryParse(type_equip3[0], out int type_equip3key);
                            List<int> list = new List<int>();

                            foreach (var y in type_equip3[1].Split(','))
                            {
                                int.TryParse(y, out int k);
                                list.Add(k);
                            }
                            gi.type_equip3.Add(type_equip3key, list);
                        }
                    }

                    {
                        List<string> type_equip4 = new List<string>(item.type_equip4.Split(';'));
                        if (!string.IsNullOrEmpty(type_equip4[0]))
                        {
                            int.TryParse(type_equip4[0], out int type_equip4key);
                            List<int> list = new List<int>();

                            foreach (var y in type_equip4[1].Split(','))
                            {
                                int.TryParse(y, out int k);
                                list.Add(k);
                            }
                            gi.type_equip4.Add(type_equip4key, list);
                        }
                    }

                    int.TryParse(item.ai, out gi.ai);
                    int.TryParse(item.normal_attack, out gi.normal_attack);
                    gi.passive_skill = item.passive_skill.ToString();
                    int.TryParse(item.is_additional, out gi.is_additional);
                    int.TryParse(item.launch_time, out gi.launch_time);


                    gun_info.Add(gun_info.Count, gi);
                    count++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("读取CatchData_gun_info遇到错误");
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }
        public bool ReadCatchData_gun_type_info(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.gun_type_info)
                {
                    Gun_Type_Info gti = new Gun_Type_Info();
                    
                    gti.id = Convert.ToInt32(item.id);
                    gti.name = item.name.ToString();
                    gti.basic_attribute_life =Convert.ToDouble(item.basic_attribute_life);
                    gti.basic_attribute_pow = Convert.ToDouble(item.basic_attribute_pow);
                    gti.basic_attribute_rate = Convert.ToDouble(item.basic_attribute_rate);
                    gti.basic_attribute_speed = Convert.ToDouble(item.basic_attribute_speed);
                    gti.basic_attribute_hit = Convert.ToDouble(item.basic_attribute_hit);
                    gti.basic_attribute_dodge = Convert.ToDouble(item.basic_attribute_dodge);
                    gti.basic_attribute_armor = Convert.ToDouble(item.basic_attribute_armor);
                    gti.mp_fix_ratio = Convert.ToDouble(item.mp_fix_ratio);
                    gti.part_fix_ratio = Convert.ToDouble(item.part_fix_ratio);
                    gti.fix_time_ratio = Convert.ToDouble(item.fix_time_ratio);

                    gun_type_info.Add(gti.id - 1, gti);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("读取CatchData_gun_type_info遇到错误");
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }
        public bool ReadCatchData_kalina_favor_info(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.kalina_favor_info)
                {
                    Kalina_Favor_Info kfi = new Kalina_Favor_Info();
                    kfi.level = Convert.ToInt32(item.level);
                    kfi.min_favor = Convert.ToInt32(item.min_favor);
                    kfi.skin_id = Convert.ToInt32(item.skin_id);

                    kalina_favor_info.Add(kfi.level - 1, kfi);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("读取CatchData_gun_type_info遇到错误");
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }
        public bool ReadCatchData_operation_info(dynamic jsonobj)
        {
            try
            {
                foreach (var item in jsonobj.operation_info)
                {
                    Operation_Info oi = new Operation_Info();

                    oi.id = Convert.ToInt32(item.id);
                    oi.campaign = Convert.ToInt32(item.campaign);
                    oi.name = item.name.ToString();
                    oi.description = item.description.ToString();
                    oi.duration = Convert.ToInt32(item.duration);
                    oi.mp = Convert.ToInt32(item.mp);
                    oi.ammo = Convert.ToInt32(item.ammo);
                    oi.mre = Convert.ToInt32(item.mre);
                    oi.part = Convert.ToInt32(item.part);

                    foreach (var x in item.item_pool.Split(','))
                    {
                        if (String.IsNullOrEmpty(x)) continue;
                        oi.item_pool.Add(Convert.ToInt32(x));
                    }
                    //public List<int> itemPool = new List<int>();
                    oi.team_leader_min_level = Convert.ToInt32(item.team_leader_min_level);
                    oi.gun_min = Convert.ToInt32(item.gun_min);
                    oi.guntype1_min = Convert.ToInt32(item.guntype1_min);
                    oi.guntype2_min = Convert.ToInt32(item.guntype2_min);
                    oi.guntype3_min = Convert.ToInt32(item.guntype3_min);
                    oi.guntype4_min = Convert.ToInt32(item.guntype4_min);
                    oi.guntype5_min = Convert.ToInt32(item.guntype5_min);
                    oi.guntype6_min = Convert.ToInt32(item.guntype6_min);
                    oi.guntype7_min = Convert.ToInt32(item.guntype7_min);

                    operation_info.Add(oi.id - 1, oi);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("读取CatchData_operation_info遇到错误");
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;
        }


        public bool ReadCatchData()
        {
            string catchdatafile = "catchdata" + "_" + "1097"; /*ProgrameData.CatchDataVersion;//catchdata_版本号*/
            string jsondata;

            if (File.Exists(catchdatafile) == false)
            {
                MessageBox.Show("文件 " + catchdatafile + " 不存在");
                return false;
            }

            try
            {
                jsondata = File.ReadAllText(catchdatafile);

                var jsonobj = DynamicJson.Parse(jsondata); //讲道理，我真不想写了

                ReadCatchData_auto_mission_info(jsonobj);
                ReadCatchData_equip_exp_info(jsonobj);
                ReadCatchData_equip_info(jsonobj);
                ReadCatchData_gun_info(jsonobj);
                ReadCatchData_gun_type_info(jsonobj);
                ReadCatchData_kalina_favor_info(jsonobj);
                ReadCatchData_operation_info(jsonobj);

            }
            catch (IOException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }





}

