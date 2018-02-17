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

        public void BattleLOOP_normal(new_User_Normal_MissionInfo ubti)
        {
            if (im.userdatasummery.CheckResources()) { return; }

            switch (ubti.TaskMap)
            {
                case 0:
                    {

                        break;
                    }
                case 1:
                    {
                        //im.battleloop_n.Battle5_2N(ubti);

                        break;
                    }
                case 2:
                    {
                        im.battleloop_n.Battle10_4E(ubti);

                        break;
                    }
                case 3:
                    {
                        im.battleloop_a.Battle_Equip_UMP(ubti);
                        break;
                    }

                case 4:
                    {
                        im.battleloop_a.Battle_Gun_Light(ubti);
                        break;
                    }

                case 5:
                    {
                        im.battleloop_a.Battle_Gun_PM7(ubti);
                        break;
                    }
                case 6:
                    {
                        im.battleloop_a.Battle_Equip_HK416(ubti);
                        break;
                    }

                case 7:
                    {
                        im.battleloop_a.Box_in_2018_winter(ubti);
                        break;
                    }
                case 8:
                    {
                        im.battleloop_a.Battle_Gun_DSR_50(ubti);
                        break;
                    }
                case 9:
                    {
                        im.battleloop_a.Battle_Gun_M1887(ubti);
                        break;
                    }
                case 10:
                    {
                        im.battleloop_a.Battle_Gun_57(ubti);
                        break;
                    }
                case 11:
                    {
                        im.battleloop_a.Battle_Gun_ART556(ubti);
                        break;
                    }
                default:
                    break;
            }
        }

        public int Check_Activity_Battle_Loop_Need(int key)
        {
            im.action.eventDraw();


            return 0;




        }


        public void End_At_Battle(new_User_Normal_MissionInfo ubti)
        {
            //                    if(this.BattleLoopTime % this.BattleSupportRound == 0)
            ubti.LoopTime++;

            //检查是否需要扩编
            im.action.CombineGun();
            //检查是否需要拆解核心
            Gun_Retire_Core();

            //检查是否需要修复
            im.userdatasummery.Check_Gun_need_FIX(ubti.Teams, 0.2);
            //检查是否需要重新登陆
            if (ubti.LoopTime % ProgrameData.BL_ReLogin_num == 0)
            {
                ProgrameData.TaskList.Add(TaskList.GetuserInfo);
            }

            if (ubti.Loop == false)
            {
                return;
            }
            if (ubti.LoopTime < ubti.MaxLoopTime || ubti.MaxLoopTime == 0)
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
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            if (im.userdatasummery.Check_Equip_GUN_FULL())
            {
                if (im.userdatasummery.gun_with_user_info.Count + 2 >= im.userdatasummery.user_info.maxgun)
                {
                    if (ProgrameData.AutoStrengthen)
                    {
                        if (im.action.EatGunHandle()) return;
                    }
                    if (!ProgrameData.AutoStrengthen)
                    {
                        im.action.Gun_retire(2);
                        im.action.Gun_retire(3);
                    }


                }
                if (im.userdatasummery.equip_with_user_info.Count + 2 >= im.userdatasummery.user_info.maxequip)
                {





                    im.action.Eat_Equip();//升级
                }


                //装备满了 需要升级或者拆解
            }
        }

        public void CheckGun_AMMO_MRC_NEED_SUPORT(new_User_Normal_MissionInfo ubti, int teamLoc, int num)
        {
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
            Map_Sent.Map3_6.spots1.team_id = ubti.Teams[teamLoc].TeamID;
            Map_Sent.Map3_6.spots2.team_id = ubti.getSupportTeamID;


            Check_Equip_Gun_FULL();

            if (im.userdatasummery.CheckGun_AMMO_MRC_NEED_SUPORT(ubti.Teams[teamLoc].MVP, num))
            {
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (移出队伍)"));
                im.action.GUN_OUT_Team(ubti.Teams[teamLoc].MVP, ubti.Teams[teamLoc].teaminfo);

                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (开始作战)"));
                im.action.startMission(Map_Sent.Map3_6.mission_id, Map_Sent.Map3_6.Mission_Start_spots);

                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (单独补给)"));
                im.action.SupplyTeam(ubti.Teams[teamLoc].TeamID);
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (梯队撤离)"));
                im.action.withdrawTeam(Map_Sent.Map3_6.withdrawSpot);
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (作战终止)"));
                im.action.abortMission();
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (移入队伍)"));
                im.action.GUN_IN_Team(ubti.Teams[teamLoc].MVP, ubti.Teams[teamLoc].teaminfo);
                im.userdatasummery.Gun_mre_ammo_REFILL(ubti.Teams[teamLoc].MVP);
            }
        }

        public void Battle_Result_PRO(ref new_User_Normal_MissionInfo ubti,int teamLoc,ref string result,int activityMissionKey=0)
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

            //效能更新 升级后 hp的差额加入效能 是否重新入字典

            im.userdatasummery.BattleFinish_ammo_mrc(ubti.Teams[teamLoc].TeamID);
        }



        public void ContinueLoopBattle(new_User_Normal_MissionInfo ubti)
        {
            ProgrameData.TaskList.Add(TaskList.TaskBattle_1);
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
