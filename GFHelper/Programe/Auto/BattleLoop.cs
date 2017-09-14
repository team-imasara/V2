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

        public void BattleLOOP(Programe.Auto.User_Normal_BattleTaskInfo ubti)
        {
            switch (ubti.TaskMap)
            {
                case 0:
                    {
                        Battle5_2N(ubti);
                        break;
                    }
                default:
                    break;
            }
        }

        public void Battle5_2N(Programe.Auto.User_Normal_BattleTaskInfo ubti)
        {
            //u代表用户 整个的
            //先在im更新数据然后 this.ubti更新
            int stepNum = 0;
            string result = "";
            Map_Sent.Map5_2N.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map5_2N.spots2.team_id = ubti.TaskSupportTeam1_ID;
            Map_Sent.Map5_2N.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map5_2N.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map5_2N.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map5_2N.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;
            ubti.withdrawPOS1 = 14;

            im.uihelp.setStatusBarText_InThread(String.Format(" 检查装备仓库是否满额"));

            if (im.userdatasummery.Check_Equip_FULL())
            {
                im.action.Eat_Equip();//升级
                //装备满了 需要升级或者拆解
            }

            //是否需要单独补给
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
            if (im.userdatasummery.CheckGun_AMMO_MRC_NEED_SUPORT(ubti.mvp,1))
            {
                im.action.GUN_OUT_Team(ubti.mvp, ubti.teaminfo);
                Thread.Sleep(12000);
                im.action.startMission(Map_Sent.Map5_2N.mission_id, Map_Sent.Map5_2N.Mission_Start_spots);
                Thread.Sleep(2000);
                if (im.action.SupplyTeam(ubti.TaskMianTeam_ID) == false) MessageBox.Show("补给梯队错误");
                Thread.Sleep(1500);
                im.action.withdrawTeam(Map_Sent.Map5_2N.withdrawSpot);
                Thread.Sleep(1500);
                im.action.abortMission();
                Thread.Sleep(3000);
                im.action.GUN_IN_Team(ubti.mvp, ubti.teaminfo);
                im.userdatasummery.Gun_mre_ammo_REFILL(ubti.mvp);
                return;
            }

            //阵型确定
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查阵型"));
            im.userdatasummery.Update_GUN_Pos(ubti.TaskMianTeam_ID, ubti.mvp);

            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            Thread.Sleep(12000);
            if (im.action.startMission(Map_Sent.Map5_2N.mission_id,Map_Sent.Map5_2N.Mission_Start_spots))
            {

                Thread.Sleep(2000);
            }
            //补给
            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
            if (im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]))
            {
                Thread.Sleep(8000);
            }
            //战斗结算 经验，装备，指挥官经验
            //建立

            Normal_Battle_Sent bs1 = new Normal_Battle_Sent();

            bs1.spot_id = 3038;
            bs1.mvp = ubti.mvp;
            bs1.user_rec.seed = ubti.seed;

            bs1.battle_damage.enemy_effect_client = 11830;
            bs1.battle_damage.team_effect_30 = ubti.TeamEffect;
            bs1.battle_damage.team_effect_60 = ubti.TeamEffect;
            bs1.battle_damage.true_time = 3.7;
            bs1.set_data(ubti);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs1.BattleResult,ref result) == true)
            {
                var jsonobj = Codeplex.Data.DynamicJson.Parse(result);


                im.userdatasummery.user_info.experience += Convert.ToInt16(jsonobj.user_exp);
                //装备
                im.userdatasummery.Add_Get_Equip_Battle(jsonobj);
                //人形经验
                int numE = 0;
                im.userdatasummery.UpdateGun_Exp(jsonobj, ref numE);
                ubti.TeamEffect += numE;
                //效能更新 升级后 hp的差额加入效能 是否重新入字典
                ubti.teaminfo = im.userdatasummery.im.userdatasummery.team_info[ubti.TaskMianTeam_ID];//需要
                im.userdatasummery.BattleFinish_ammo_mrc(ubti.TaskMianTeam_ID);
                Thread.Sleep(3000);

            }
            else
            {
                MessageBox.Show(string.Format("错误 result = {0}", result));
            }
            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
            if (im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]))
            {
                Thread.Sleep(10000);
            }
            Normal_Battle_Sent bs2 = new Normal_Battle_Sent();

            bs1.spot_id = 3047;
            bs1.mvp = ubti.mvp;
            bs1.user_rec.seed = ubti.seed;

            bs1.battle_damage.enemy_effect_client = 14196;
            bs1.battle_damage.team_effect_30 = ubti.TeamEffect;
            bs1.battle_damage.team_effect_60 = ubti.TeamEffect;
            bs1.battle_damage.true_time = 5.1;
            bs1.set_data(ubti);

            //战斗结算 经验装备
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs1.BattleResult, ref result) == true)
            {
                var jsonobj = Codeplex.Data.DynamicJson.Parse(result);
                int user_exp = Convert.ToInt16(jsonobj.user_exp);
                //装备
                im.userdatasummery.Add_Get_Equip_Battle(jsonobj);
                //人形经验
                int numE = 0;
                im.userdatasummery.UpdateGun_Exp(jsonobj, ref numE);
                ubti.TeamEffect += numE;
                ubti.teaminfo = im.userdatasummery.im.userdatasummery.team_info[ubti.TaskMianTeam_ID];//需要
                im.userdatasummery.BattleFinish_ammo_mrc(ubti.TaskMianTeam_ID);
                Thread.Sleep(4000);
            }
            else
            {
                MessageBox.Show(string.Format("错误 result = {0}", result));
            }
            //左移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
            if (im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]))
            {
                Thread.Sleep(2000);
            }
            //左移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
            if (im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]))
            {
                Thread.Sleep(2000);
            }
            //撤离
            im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
            if (im.action.withdrawTeam(Map_Sent.Map5_2N.withdrawSpot))
            {
                Thread.Sleep(2000);
            }
            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            if (im.action.abortMission())
            {
                Thread.Sleep(2000);
            }
            //结算
        }




        public void End_At_Battle(User_Normal_BattleTaskInfo ubti)
        {
            //                    if(this.BattleLoopTime % this.BattleSupportRound == 0)
            ubti.BattleLoopTime++;


            if (im.userdatasummery.Check_Equip_FULL())
            {
                //装备满了
                return;
            }


            if (ubti.BattleLoopTime<=ubti.BattleMaxLoopTime || ubti.BattleMaxLoopTime==0)
            {
                //继续循环
                ContinueLoopBattle(ubti);
            }

        }

        public void ContinueLoopBattle(User_Normal_BattleTaskInfo ubti)
        {
            switch (ubti.Key)
            {
                case 0:
                    {
                        im.TaskList.Add(Programe.TaskList.TaskBattle_1);
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
                        sbs.set_Data(usbt.mission_id1, usbt.duration, usbt.skill_cd, usbt.enemy_effect_client1);
                        if (usbt.duration < usbt.L_duration1)
                        {
                            return;
                        }
                        break;
                    }
                case 2:
                    {
                        sbs.set_Data(usbt.mission_id2, usbt.duration, usbt.skill_cd, usbt.enemy_effect_client2);
                        if (usbt.duration < usbt.L_duration2)
                        {
                            return;
                        }
                        break;
                    }
                case 3:
                    {
                        sbs.set_Data(usbt.mission_id3, usbt.duration, usbt.skill_cd, usbt.enemy_effect_client3);
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

    }
}
