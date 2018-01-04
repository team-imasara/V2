using GFHelper.Programe.ProgramePro;
using GFHelper.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GFHelper.Programe.Auto
{
    class BattleLoop
    {
        private InstanceManager im;
        public BattleLoop(InstanceManager im)
        {
            this.im = im;
        }

        public void BattleLOOP_normal(User_Normal_BattleTaskInfo ubti)
        {
            if (im.userdatasummery.CheckResources()) { ubti.Used = false; return; }

            switch (ubti.TaskMap)
            {
                case 0:
                    {
                        im.battleloop_n.Battle5_2N(ubti);
                        break;
                    }
                case 1:
                    {
                        im.battleloop_n.Battle7_6(ubti);
                        break;
                    }
                case 2:
                    {
                        im.battleloop_n.Battle7_6BOSS(ubti);
                        break;
                    }
                case 3:
                    {
                        switch (Check_Activity_Battle_Loop_Need(1))
                        {
                            case 1:
                                {
                                    im.battleloop_a.E1_1(ubti);
                                    break;
                                }
                            case 2:
                                {
                                    im.battleloop_a.E1_2(ubti);
                                    break;
                                }
                            case 3:
                                {
                                    im.battleloop_a.E1_3(ubti);
                                    break;
                                }
                            case 4:
                                {
                                    im.battleloop_a.E1_4(ubti);
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }

                case 4:
                    {
                        switch (Check_Activity_Battle_Loop_Need(2))
                        {
                            case 5:
                                {
                                    im.battleloop_a.E2_1(ubti);
                                    break;
                                }
                            case 6:
                                {
                                    im.battleloop_a.E2_2(ubti);
                                    break;
                                }
                            case 7:
                                {
                                    im.battleloop_a.E2_3(ubti);
                                    break;
                                }
                            case 8:
                                {
                                    im.battleloop_a.E2_4(ubti);
                                    break;
                                }

                            default:
                                break;
                        }
                        break;
                    }

                case 5:
                    {
                        im.battleloop_a.E2_3(ubti);
                        break;
                    }
                case 6:
                    {
                        im.battleloop_a.E1_4BOSS(ubti);
                        break;
                    }

                case 7:
                    {
                        im.battleloop_a.E1_3_TYPE2(ubti);
                        break;
                    }
                case 8:
                    {
                        im.battleloop_n.text(ubti);
                        break;
                    }
                case 9:
                    {
                        im.battleloop_n.Battle10_4E(ubti);
                        break;
                    }
                default:
                    break;
            }
        }

        public int Check_Activity_Battle_Loop_Need(int key)
        {
            im.action.eventDraw();

            if (key == 1)
            {
                foreach (var item in UserDataSummery.battle_get_prize_NUM)
                {
                    switch (item.Key)
                    {
                        case 62:
                            {
                                if (item.Value <= 8)
                                    return 1;
                                else
                                {
                                    break;
                                }
                            }
                        case 63:
                            {
                                if (item.Value <= 8)
                                    return 2;
                                else
                                {
                                    break;
                                }
                            }
                        case 64:
                            {
                                if (item.Value <= 8)
                                    return 3;
                                else
                                {
                                    break;
                                }
                            }
                        case 65:
                            {
                                if (item.Value <= 8)
                                    return 4;
                                else
                                {
                                    break;
                                }
                            }

                        default:
                            break;
                    }
                }
            }

            if(key == 2)
            {
                foreach (var item in UserDataSummery.battle_get_prize_NUM)
                {
                    switch (item.Key)
                    {
                        case 66:
                            {
                                if (item.Value <= 6)
                                    return 5;
                                else
                                {
                                    break;
                                }
                            }
                        case 67:
                            {
                                if (item.Value <= 6)
                                    return 6;
                                else
                                {
                                    break;
                                }
                            }
                        case 68:
                            {
                                if (item.Value <= 6)
                                    return 7;
                                else
                                {
                                    break;
                                }
                            }
                        case 69:
                            {
                                if (item.Value <= 6)
                                    return 8;
                                else
                                {
                                    break;
                                }
                            }

                        default:
                            break;
                    }
                }

            }
            return 0;




        }


        public void End_At_Battle(User_Normal_BattleTaskInfo ubti)
        {
            //                    if(this.BattleLoopTime % this.BattleSupportRound == 0)
            ubti.BattleLoopTime++;

            //检查是否需要扩编
            im.action.CombineGun();
            //检查是否需要拆解核心
            Gun_Retire_Core();
            im.userdatasummery.WriteReport();


            //检查是否需要修复
            im.userdatasummery.Check_Gun_need_FIX(ubti.TaskMianTeam_ID, 0.2);
            //检查是否需要重新登陆
            if (ubti.BattleLoopTime % ProgrameData.BL_ReLogin_num == 0)
            {
                ProgrameData.TaskList.Add(TaskList.GetuserInfo);
            }


            if (ubti.TaskMap == 3)
            {
                if (Check_Activity_Battle_Loop_Need(1) == 0) return;
            }
            if (ubti.TaskMap == 4)
            {
                if (Check_Activity_Battle_Loop_Need(2) == 0) return;
            }

            if (ubti.Used == false) return;

            if (ubti.BattleLoopTime < ubti.BattleMaxLoopTime || ubti.BattleMaxLoopTime == 0)
            {

                //继续循环
                ContinueLoopBattle(ubti);
            }

        }

        public void Set_Withdraw_INFO(User_Normal_BattleTaskInfo ubti, List<int> withdrawinfo)
        {
            ubti.List_withdrawGUN_ID.Clear();
            ubti.List_withdrawPOS.Clear();
            foreach (var item in withdrawinfo)
            {
                ubti.List_withdrawPOS.Add(item);
            }
            
            for(int i = 1; i <= im.userdatasummery.team_info[ubti.TaskMianTeam_ID].Count; i++)
            {
                foreach (var item in withdrawinfo)
                {
                    if (im.userdatasummery.team_info[ubti.TaskMianTeam_ID][i].position == item)
                    {
                        ubti.List_withdrawGUN_ID.Add(im.userdatasummery.team_info[ubti.TaskMianTeam_ID][i].id);
                    }
                }
            }
        }

        public void Gun_Retire_Core()
        {
            im.userdatasummery.Get_Gun_Retire();
            if (UserDataSummery.Gun_Retire_Rank3.Count >= 24)
            {
                Thread.Sleep(2000);
                im.action.Gun_retire(3);
                im.userdatasummery.user_info.core += 24;
            }

        }

        public void Check_Equip_Gun_FULL()
        {
            if (im.userdatasummery.Check_Equip_GUN_FULL())
            {
                im.action.Eat_Equip();//升级
                if (ProgrameData.AutoStrengthen)
                {
                    if (im.action.EatGunHandle()) return;
                }

                if (!im.action.Gun_retire(2)) im.action.Gun_retire(3);


                //装备满了 需要升级或者拆解
            }
        }

        public void CheckGun_AMMO_MRC_NEED_SUPORT(User_Normal_BattleTaskInfo ubti,int num)
        {
            Map_Sent.Map3_6.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map3_6.spots2.team_id = ubti.TaskSupportTeam1_ID;


            Check_Equip_Gun_FULL();

            if (im.userdatasummery.CheckGun_AMMO_MRC_NEED_SUPORT(ubti.mvp, num))
            {
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (移出队伍)"));
                im.action.GUN_OUT_Team(ubti.mvp, ubti.teaminfo0);

                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (开始作战)"));
                im.action.startMission(Map_Sent.Map3_6.mission_id, Map_Sent.Map3_6.Mission_Start_spots);

                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (单独补给)"));
                im.action.SupplyTeam(ubti.TaskMianTeam_ID);
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (梯队撤离)"));
                im.action.withdrawTeam(Map_Sent.Map3_6.withdrawSpot);
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (作战终止)"));
                im.action.abortMission();
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (移入队伍)"));
                im.action.GUN_IN_Team(ubti.mvp, ubti.teaminfo0);
                im.userdatasummery.Gun_mre_ammo_REFILL(ubti.mvp);
            }
        }

        public void Battle_Result_PRO(ref User_Normal_BattleTaskInfo ubti,ref string result,int activityMissionKey=0)
        {
            if (ProgrameData.debugmode)
            {
                WriteLog.Log(string.Format(" battle_result = {0} ", result), "debug");
            }
            var jsonobj = Codeplex.Data.DynamicJson.Parse(result);
            im.userdatasummery.user_info.experience += Convert.ToInt16(jsonobj.user_exp);
            ubti.user_exp = im.userdatasummery.user_info.experience;
            UserDataSummery.globalFreeExp += Convert.ToInt16(jsonobj.free_exp);
            //奖励
            im.userdatasummery.Add_Get_battle_get_prize(jsonobj, activityMissionKey);

            //装备
            im.userdatasummery.Add_Get_Gun_Equip_Battle(jsonobj);
            //人形经验
            int numE = 0;
            im.userdatasummery.UpdateGun_Exp(jsonobj, ref numE);
            ubti.TeamEffect += numE;
            //效能更新 升级后 hp的差额加入效能 是否重新入字典
            switch (ubti.teamId_used)
            {
                case 0:
                    {
                        ubti.teaminfo0 = im.userdatasummery.im.userdatasummery.team_info[ubti.TaskMianTeam_ID];//需要
                        break;
                    }
                case 1:
                    {
                        ubti.teaminfo1 = im.userdatasummery.im.userdatasummery.team_info[ubti.TaskSupportTeam1_ID];//需要
                        break;
                    }
                default:
                    break;
            }
            im.userdatasummery.BattleFinish_ammo_mrc(ubti.TaskMianTeam_ID);
        }


        public void BattleSent_Data_Built(ref Normal_Battle_Sent bs, User_Normal_BattleTaskInfo ubti,int spot_id,int life_reduce,int time, int enemy_effect_client,int life_enemy,int teamID_used=0,int damage_team_no_miss
=0)
        {
            Random random = new Random();

            //战斗结算 经验，装备，指挥官经验
            bs.spot_id = spot_id;

            switch (teamID_used)
            {
                case 0:
                    {
                        ubti.teamId_used = teamID_used;
                        bs.teamID_used = teamID_used;
                        bs.mvp = ubti.mvp;
                        break;
                    }
                case 1:
                    {
                        ubti.teamId_used = teamID_used;
                        bs.teamID_used = teamID_used;
                        bs.mvp = ubti.teaminfo1[1].id;
                        break;
                    }
                default:
                    break;
            }
            //bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;



            //血量计算
            ubti.Set_LifeReduce(life_reduce);
            im.userdatasummery.GUN_Life_reduce(ubti.TaskMianTeam_ID, ubti.List_withdrawPOS, ubti.List_lifeReduce);

            bs.set_data(ubti);

            bs.battle_info.data_set(enemy_effect_client,/*浮动*/CommonHelp.GetTotalFPS_((double)time), life_enemy,/*浮动*/time, damage_team_no_miss);
        }

        public void ContinueLoopBattle(User_Normal_BattleTaskInfo ubti)
        {
            switch (ubti.Key)
            {
                case 0:
                    {
                        ProgrameData.TaskList.Add(Programe.TaskList.TaskBattle_1);
                        break;
                    }
                default:
                    break;
            }


        }


        public void Simulation_DATA(User_Simulation_BattleTaskInfo usbt)
        {
            string result = "";
            Simulation_Battle_Sent sbs = new Simulation_Battle_Sent();
            switch (usbt.Type)
            {
                case 1:
                    {
                        sbs.set_Data(usbt.mission_id1, usbt.duration, usbt.skill_cd, usbt.enemy_effect_client1,usbt.enemy_life1);
                        if (usbt.duration < usbt.L_duration1)
                        {
                            return;
                        }
                        break;
                    }
                case 2:
                    {
                        sbs.set_Data(usbt.mission_id2, usbt.duration, usbt.skill_cd, usbt.enemy_effect_client2,usbt.enemy_life2);
                        if (usbt.duration < usbt.L_duration2)
                        {
                            return;
                        }
                        break;
                    }
                case 3:
                    {
                        sbs.set_Data(usbt.mission_id3, usbt.duration, usbt.skill_cd, usbt.enemy_effect_client3,usbt.enemy_life3);
                        if (usbt.duration < usbt.L_duration3) { return; }
                        break;
                    }
                default:
                    return;
            }

            if (im.action.Simulation_battleFinish(sbs.BattleResult, ref result) == true)
            {
                var jsonobj = Codeplex.Data.DynamicJson.Parse(result);

                int coin_num = Convert.ToInt32(jsonobj.coin_num);
                switch (usbt.Type)
                {
                    case 1:
                        {
                            im.userdatasummery.user_info.coin1 += coin_num;
                            break;
                        }
                    case 2:
                        {
                            im.userdatasummery.user_info.coin2 += coin_num;
                            break;
                        }
                    case 3:
                        {
                            im.userdatasummery.user_info.coin3 += coin_num;
                            break;
                        }
                    default:
                        break;
                }
            }




            }

        public static int E1_3_type2_pro(string result)
        {
            if (result.Contains("5009")) return 1;
            else
            {
                return 2; ;
            }
            return 0;
        }



    }
}
