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

        public void BattleLOOP(Programe.Auto.User_Normal_BattleTaskInfo ubti)
        {
            switch (ubti.TaskMap)
            {
                case 0:
                    {
                        Battle5_2N(ubti);
                        break;
                    }
                case 1:
                    {
                        Battle7_6(ubti);
                        break;
                    }
                default:
                    break;
            }
        }

        public void Battle5_2N(User_Normal_BattleTaskInfo ubti)
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
            Check_Equip_Gun_FULL();


            //是否需要单独补给
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
            CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 1);

            //阵型确定
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查阵型"));
            im.userdatasummery.Update_GUN_Pos(ubti.TaskMianTeam_ID, ubti.mvp);

            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.Map5_2N.mission_id, Map_Sent.Map5_2N.Mission_Start_spots);


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

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

            if (im.action.Normal_battleFinish(bs1.BattleResult,ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            Normal_Battle_Sent bs2 = new Normal_Battle_Sent();

            bs2.spot_id = 3047;
            bs2.mvp = ubti.mvp;
            bs2.user_rec.seed = ubti.seed;

            bs2.battle_damage.enemy_effect_client = 14196;
            bs2.battle_damage.team_effect_30 = ubti.TeamEffect;
            bs2.battle_damage.team_effect_60 = ubti.TeamEffect;
            bs2.battle_damage.true_time = 5.1;
            bs2.set_data(ubti);

            //战斗结算 经验装备
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs2.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }


            //左移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);


            //左移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            //撤离
            im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
            im.action.withdrawTeam(Map_Sent.Map5_2N.withdrawSpot);

            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            im.action.abortMission();
            //结算
        }

        public void Battle0_2(User_Normal_BattleTaskInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0;string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.Map0_2.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map0_2.spots2.team_id = ubti.TaskSupportTeam1_ID;
            Map_Sent.Map0_2.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map0_2.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map0_2.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map0_2.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map0_2.dic_TeamMove[4].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map0_2.dic_TeamMove[5].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map0_2.dic_TeamMove[6].team_id = ubti.TaskMianTeam_ID;
            ubti.withdrawPOS1 = 18;

            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            Check_Equip_Gun_FULL();

            //是否需要单独补给
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
            CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 5);//补给问题

            //阵型确定
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查阵型"));
            im.userdatasummery.Update_GUN_Pos(ubti.TaskMianTeam_ID, ubti.mvp);//霰弹的位置

            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.Map0_2.mission_id, Map_Sent.Map0_2.Mission_Start_spots);

            im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (单独补给)"));
            im.action.SupplyTeam(ubti.TaskSupportTeam1_ID);

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验
            //建立
            //需要扣血
            im.userdatasummery.GUN_HP_reduce(100, random.Next(50, 80));
            bs.spot_id = 17;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            bs.battle_damage.enemy_effect_client = 9544;
            bs.battle_damage.team_effect_60 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.team_effect_30 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.true_time = 23.7;
            bs.set_data(ubti);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验
            //建立
            //需要扣血
            im.userdatasummery.GUN_HP_reduce(100, random.Next(30, 60));
            bs.spot_id = 18;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            bs.battle_damage.enemy_effect_client = 8449;
            bs.battle_damage.team_effect_60 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.team_effect_30 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.true_time = 23.7;
            bs.set_data(ubti);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);


            //战斗结算 经验，装备，指挥官经验
            //建立
            //需要扣血
            im.userdatasummery.GUN_HP_reduce(100, random.Next(60, 100));
            bs.spot_id = 16;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            bs.battle_damage.enemy_effect_client = 4753;
            bs.battle_damage.team_effect_60 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.team_effect_30 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.true_time = 9.8;
            bs.set_data(ubti);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }



            im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
            im.action.endTurn();
            im.uihelp.setStatusBarText_InThread(String.Format("回合开始"));
            im.action.startTurn();
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            im.userdatasummery.GUN_HP_reduce(100, random.Next(10, 30));
            bs.spot_id = 23;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            bs.battle_damage.enemy_effect_client = 6270;
            bs.battle_damage.team_effect_60 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.team_effect_30 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.true_time = 19.3;
            bs.set_data(ubti);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            im.userdatasummery.GUN_HP_reduce(100, random.Next(20, 40));
            bs.spot_id = 25;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            bs.battle_damage.enemy_effect_client = 6540;
            bs.battle_damage.team_effect_60 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.team_effect_30 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.true_time = 17.7;
            bs.set_data(ubti);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
            im.action.endTurn();



        }
        public void Battle7_6(User_Normal_BattleTaskInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.Map7_6.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map7_6.spots2.team_id = ubti.TaskSupportTeam1_ID;
            Map_Sent.Map7_6.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map7_6.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map7_6.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map7_6.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;

            ubti.withdrawPOS1 = 14;
            ubti.withdrawPOS2 = 13;
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            Check_Equip_Gun_FULL();

            //是否需要单独补给
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
            CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 5);//补给问题

            //阵型确定
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查阵型"));
            im.userdatasummery.Update_GUN_Pos(ubti.TaskMianTeam_ID, ubti.mvp);

            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.Map7_6.mission_id, Map_Sent.Map7_6.Mission_Start_spots);

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验
            bs.spot_id = 1947;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            bs.battle_damage.enemy_effect_client = 6756;
            bs.battle_damage.team_effect_60 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.team_effect_30 = ubti.TeamEffect - random.Next(200, 300);//需要重新想
            bs.battle_damage.true_time = (double)random.Next(90, 110) / 10;
            bs.set_data(ubti);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验
            bs.spot_id = 1949;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            bs.battle_damage.enemy_effect_client = 5475;
            bs.battle_damage.team_effect_60 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.team_effect_30 = ubti.TeamEffect - random.Next(200, 300);//需要重新想
            bs.battle_damage.true_time = (double)random.Next(80, 90) / 10;
            bs.set_data(ubti);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }




            im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
            im.action.endTurn();

            //战斗结算 经验，装备，指挥官经验
            bs.spot_id = 1949;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            bs.battle_damage.enemy_effect_client = 6752;
            bs.battle_damage.team_effect_60 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.team_effect_30 = ubti.TeamEffect - random.Next(200, 300);//需要重新想
            bs.battle_damage.true_time = (double)random.Next(70, 85) / 10;
            bs.set_data(ubti);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            im.uihelp.setStatusBarText_InThread(String.Format("回合开始"));
            im.action.startTurn();




            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验
            bs.spot_id = 1947;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            bs.battle_damage.enemy_effect_client = 6752;
            bs.battle_damage.team_effect_60 = ubti.TeamEffect;//需要重新想
            bs.battle_damage.team_effect_30 = ubti.TeamEffect - random.Next(200, 300);//需要重新想
            bs.battle_damage.true_time =(double)random.Next(70, 85) / 10;
            bs.set_data(ubti);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }





            //Mission / reinforceTeam
            im.uihelp.setStatusBarText_InThread(String.Format(" 部署梯队"));
            im.action.reinforceTeam(Map_Sent.Map7_6.spots2);


            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);








            //撤离
            im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
            im.action.withdrawTeam(Map_Sent.Map7_6.withdrawSpot);

            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            im.action.abortMission();




        }

        public void End_At_Battle(User_Normal_BattleTaskInfo ubti)
        {
            //                    if(this.BattleLoopTime % this.BattleSupportRound == 0)
            ubti.BattleLoopTime++;

            //检查是否需要扩编
            im.action.CombineGun();
            //检查是否需要拆解核心
            Gun_Retire_Core();



            if (ubti.BattleLoopTime <= ubti.BattleMaxLoopTime || ubti.BattleMaxLoopTime == 0)
            {
                //继续循环
                ContinueLoopBattle(ubti);
            }

        }


        public void Gun_Retire_Core()
        {
            im.userdatasummery.Get_Gun_Retire();
            if (UserDataSummery.Gun_Retire_Rank3.Count >= 24)
            {
                im.action.Gun_retire(3);
                im.userdatasummery.user_info.core += 24;
            }

        }

        public void Check_Equip_Gun_FULL()
        {
            if (im.userdatasummery.Check_Equip_GUN_FULL())
            {
                im.action.Eat_Equip();//升级
                im.action.EatGunHandle();
                im.action.Gun_retire(2);
                //装备满了 需要升级或者拆解
            }
        }

        public void CheckGun_AMMO_MRC_NEED_SUPORT(User_Normal_BattleTaskInfo ubti,int num)
        {
            Map_Sent.Map5_2N.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map5_2N.spots2.team_id = ubti.TaskSupportTeam1_ID;
            if (im.userdatasummery.CheckGun_AMMO_MRC_NEED_SUPORT(ubti.mvp, num))
            {
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (移出队伍)"));
                im.action.GUN_OUT_Team(ubti.mvp, ubti.teaminfo);
                im.action.startMission(Map_Sent.Map5_2N.mission_id, Map_Sent.Map5_2N.Mission_Start_spots);
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (单独补给)"));
                im.action.SupplyTeam(ubti.TaskMianTeam_ID);
                im.action.withdrawTeam(Map_Sent.Map5_2N.withdrawSpot);
                im.action.abortMission();
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (移入队伍)"));
                im.action.GUN_IN_Team(ubti.mvp, ubti.teaminfo);
                im.userdatasummery.Gun_mre_ammo_REFILL(ubti.mvp);
            }
        }

        public void Battle_Result_PRO(ref User_Normal_BattleTaskInfo ubti,ref string result)
        {
            var jsonobj = Codeplex.Data.DynamicJson.Parse(result);
            im.userdatasummery.user_info.experience += Convert.ToInt16(jsonobj.user_exp);
            //装备
            im.userdatasummery.Add_Get_Gun_Equip_Battle(jsonobj);
            //人形经验
            int numE = 0;
            im.userdatasummery.UpdateGun_Exp(jsonobj, ref numE);
            ubti.TeamEffect += numE;
            //效能更新 升级后 hp的差额加入效能 是否重新入字典
            ubti.teaminfo = im.userdatasummery.im.userdatasummery.team_info[ubti.TaskMianTeam_ID];//需要
            im.userdatasummery.BattleFinish_ammo_mrc(ubti.TaskMianTeam_ID);
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
