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
                case 2:
                    {
                        Battle7_6BOSS(ubti);
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
            Random random = new Random();
            Map_Sent.Map5_2N.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map5_2N.spots2.team_id = ubti.TaskSupportTeam1_ID;
            Map_Sent.Map5_2N.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map5_2N.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map5_2N.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map5_2N.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;

            //撤退位置
            List<int> list = new List<int>();
            list.Add(14);
            Set_Withdraw_INFO(ubti, list);


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

            BattleSent_Data_Built(ref bs1, ubti, 3038, 0, random.Next(4, 5), 11830, 2430);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs1.BattleResult,ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            Normal_Battle_Sent bs2 = new Normal_Battle_Sent();

            BattleSent_Data_Built(ref bs2, ubti, 3047, 0, random.Next(4, 5), 14196, 2916);
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

            List<int> list = new List<int>();
            list.Add(18); 
            Set_Withdraw_INFO(ubti, list);

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
            //im.userdatasummery.GUN_Life_reduce(100, random.Next(50, 80));
            bs.spot_id = 17;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            //bs.battle_info.enemy_effect_client = 9544;

            //bs.battle_info.true_time = 23.7;
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
            //im.userdatasummery.GUN_Life_reduce(100, random.Next(30, 60));
            bs.spot_id = 18;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            //bs.battle_info.enemy_effect_client = 8449;
            //bs.battle_info.true_time = 23.7;
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
            //im.userdatasummery.GUN_Life_reduce(100, random.Next(60, 100));
            bs.spot_id = 16;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            //bs.battle_info.enemy_effect_client = 4753;
            //bs.battle_info.true_time = 9.8;
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

            //im.userdatasummery.GUN_Life_reduce(100, random.Next(10, 30));
            bs.spot_id = 23;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            //bs.battle_info.enemy_effect_client = 6270;

            //bs.battle_info.true_time = 19.3;
            bs.set_data(ubti);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            //im.userdatasummery.GUN_Life_reduce(100, random.Next(20, 40));
            bs.spot_id = 25;
            bs.mvp = ubti.mvp;
            bs.user_rec.seed = ubti.seed;
            //bs.battle_info.enemy_effect_client = 6540;

            //bs.battle_info.true_time = 17.7;
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


            List<int> list = new List<int>();
            list.Add(13);list.Add(14);
            Set_Withdraw_INFO(ubti,list);


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

            BattleSent_Data_Built(ref bs, ubti, 1947, random.Next(10, 20), random.Next(6, 8), 6752, 5688);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验
            BattleSent_Data_Built(ref bs, ubti, 1949, random.Next(10, 20), random.Next(6, 8), 5475, 8890);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }




            im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
            im.action.endTurn();

            //战斗结算 经验，装备，指挥官经验
            BattleSent_Data_Built(ref bs, ubti, 1949, random.Next(10, 20), random.Next(6, 8), 6752, 5688);
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


            BattleSent_Data_Built(ref bs, ubti, 1947, random.Next(10, 20), random.Next(6, 8), 6752, 5688);
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
        public void Battle7_6BOSS(User_Normal_BattleTaskInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.Map7_6BOSS.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map7_6BOSS.spots2.team_id = ubti.TaskSupportTeam1_ID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[4].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[5].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[6].team_id = ubti.TaskMianTeam_ID;



            List<int> list = new List<int>();
            list.Add(18); list.Add(14);//
            Set_Withdraw_INFO(ubti, list);


            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            Check_Equip_Gun_FULL();


            //阵型确定
            //im.uihelp.setStatusBarText_InThread(String.Format(" 检查阵型"));
            //im.userdatasummery.Update_GUN_Pos(ubti.TaskMianTeam_ID, ubti.mvp);/////////////////////////需要改

            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.Map7_6BOSS.mission_id, Map_Sent.Map7_6BOSS.Mission_Start_spots);

            //补给梯队
            im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (单独补给)"));
            im.action.SupplyTeam(ubti.TaskMianTeam_ID);


            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

            BattleSent_Data_Built(ref bs, ubti, 1947, 0, random.Next(4, 6), 6756, 11380);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }


            im.uihelp.setStatusBarText_InThread(String.Format(" 部署梯队"));
            im.action.reinforceTeam(Map_Sent.Map7_6BOSS.spots2);


            im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (单独补给)"));
            im.action.SupplyTeam(ubti.TaskSupportTeam1_ID);

            im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
            im.action.endTurn();


            BattleSent_Data_Built(ref bs, ubti, 1947, 0, random.Next(4, 5), 6752, 5688);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            BattleSent_Data_Built(ref bs, ubti, 1948, 0, random.Next(4, 5), 5475, 8890,1);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            //回合结束
            im.uihelp.setStatusBarText_InThread(String.Format("回合开始"));
            im.action.endEnemyTurn();
            im.action.startTurn();


            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

            im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (单独补给)"));
            im.action.SupplyTeam(ubti.TaskMianTeam_ID);

            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);////0000000

            BattleSent_Data_Built(ref bs, ubti, 1946, 0, random.Next(7, 8), 10875, 16022,0);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }


            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

            BattleSent_Data_Built(ref bs, ubti, 2152, 0, random.Next(7, 8), 10415, 23979);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

            BattleSent_Data_Built(ref bs, ubti, 1941, 0, random.Next(7, 8), 12904, 17068);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
            im.action.endTurn();


            BattleSent_Data_Built(ref bs, ubti, 1941, random.Next(0,1)*221, random.Next(18, 22), 24604, 48992, 4060);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                Battle_Result_PRO(ref ubti, ref result);
            }

            //回合结束
            im.uihelp.setStatusBarText_InThread(String.Format("回合开始"));
            im.action.endEnemyTurn();
            im.action.startTurn();

            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

            im.action.endTurn();


        }


        public void End_At_Battle(User_Normal_BattleTaskInfo ubti)
        {
            //                    if(this.BattleLoopTime % this.BattleSupportRound == 0)
            ubti.BattleLoopTime++;

            //检查是否需要扩编
            im.action.CombineGun();
            //检查是否需要拆解核心
            Gun_Retire_Core();

            //检查是否需要修复
            im.userdatasummery.Check_Gun_need_FIX(ubti.TaskMianTeam_ID, 0.2);
            //检查是否需要重新登陆
            if (ubti.BattleLoopTime % ProgrameData.BL_ReLogin_num == 0)
            {
                ProgrameData.TaskList.Add(TaskList.Login);
            }


            if (ubti.BattleLoopTime <= ubti.BattleMaxLoopTime || ubti.BattleMaxLoopTime == 0)
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
                //im.action.Gun_retire(2);
                if (im.action.EatGunHandle())
                {
                    return;
                }
                else
                {
                    im.action.Gun_retire(2);
                }

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

        public void Battle_Result_PRO(ref User_Normal_BattleTaskInfo ubti,ref string result)
        {
            if (ProgrameData.debugmode)
            {
                WriteLog.Log(string.Format(" battle_result = {0} ", result), "debug");
            }
            var jsonobj = Codeplex.Data.DynamicJson.Parse(result);
            im.userdatasummery.user_info.experience += Convert.ToInt16(jsonobj.user_exp);
            ubti.user_exp = im.userdatasummery.user_info.experience;
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





    }
}
