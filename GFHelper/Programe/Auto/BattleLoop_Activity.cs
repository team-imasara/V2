using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe.Auto
{
    class BattleLoop_Activity
    {

        private InstanceManager im;
        public BattleLoop_Activity(InstanceManager im)
        {
            this.im = im;
        }

        public void E1_1(User_Normal_BattleTaskInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.MapE1_1.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE1_1.spots2.team_id = ubti.TaskSupportTeam1_ID;

            Map_Sent.MapE1_1.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE1_1.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;




            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            im.battle_loop.Check_Equip_Gun_FULL();



            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.MapE1_1.mission_id, Map_Sent.MapE1_1.Mission_Start_spots);

            im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
            im.action.SupplyTeam(ubti.TaskMianTeam_ID);


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_1.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_1.dic_TeamMove[stepNum++]);

            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 4978, 0, random.Next(1, 2), 1170, 2112);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 62);
            }


            //Mission / reinforceTeam
            im.uihelp.setStatusBarText_InThread(String.Format(" 部署梯队"));
            im.action.reinforceTeam(Map_Sent.MapE1_1.spots2);

            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_1.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_1.dic_TeamMove[stepNum++]);


            im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
            im.action.endTurn();


            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 4971, 0, random.Next(1, 2), 1170, 2112);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 62);
            }


            //回合结束
            im.uihelp.setStatusBarText_InThread(String.Format("回合开始"));
            im.action.endEnemyTurn();
            im.action.startTurn();

            //撤离
            im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
            im.action.withdrawTeam(Map_Sent.MapE1_1.withdrawSpot);

            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            im.action.abortMission();

            im.action.eventDraw();
        }


        public void E1_2(User_Normal_BattleTaskInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.MapE1_2.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE1_2.spots2.team_id = ubti.TaskSupportTeam1_ID;

            Map_Sent.MapE1_2.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE1_2.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;


            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            im.battle_loop.Check_Equip_Gun_FULL();



            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.MapE1_2.mission_id, Map_Sent.MapE1_2.Mission_Start_spots);

            im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
            im.action.SupplyTeam(ubti.TaskMianTeam_ID);


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_2.dic_TeamMove[stepNum++]);

            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 4993, 0, random.Next(2, 3), 2778, 5388);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 63);
            }


            //Mission / reinforceTeam
            im.uihelp.setStatusBarText_InThread(String.Format(" 部署梯队"));
            im.action.reinforceTeam(Map_Sent.MapE1_2.spots2);

            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_2.dic_TeamMove[stepNum++]);


            //撤离
            im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
            im.action.withdrawTeam(Map_Sent.MapE1_2.withdrawSpot);

            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            im.action.abortMission();

            im.action.eventDraw();
        }

        public void E1_3(User_Normal_BattleTaskInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.MapE1_3.spots1.team_id = ubti.TaskSupportTeam1_ID;
            Map_Sent.MapE1_3.spots2.team_id = ubti.TaskMianTeam_ID;

            Map_Sent.MapE1_3.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE1_3.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE1_3.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE1_3.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;

            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            im.battle_loop.Check_Equip_Gun_FULL();



            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.MapE1_3.mission_id, Map_Sent.MapE1_3.Mission_Start_spots);

            im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
            im.action.SupplyTeam(ubti.TaskMianTeam_ID);


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_3.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_3.dic_TeamMove[stepNum++]);

            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 5008, 0, random.Next(3, 5), 3997, 7343);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 64);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_3.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_3.dic_TeamMove[stepNum++]);

            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 5009, 0, random.Next(3, 5), 3997, 7343);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 64);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_3.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_3.dic_TeamMove[stepNum++]);

            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 5005, 0, random.Next(3, 5), 3997, 7343);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 64);
            }


            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_3.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_3.dic_TeamMove[stepNum++]);


            //撤离
            im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
            im.action.withdrawTeam(Map_Sent.MapE1_3.withdrawSpot);

            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            im.action.abortMission();

            im.action.eventDraw();
        }

        public void E1_4(User_Normal_BattleTaskInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.MapE1_4.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE1_4.spots2.team_id = ubti.TaskSupportTeam1_ID;

            Map_Sent.MapE1_4.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE1_4.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE1_4.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE1_4.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;

            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            im.battle_loop.Check_Equip_Gun_FULL();



            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.MapE1_4.mission_id, Map_Sent.MapE1_4.Mission_Start_spots);

            im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
            im.action.SupplyTeam(ubti.TaskMianTeam_ID);


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_4.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_4.dic_TeamMove[stepNum++]);

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_4.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_4.dic_TeamMove[stepNum++]);

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_4.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_4.dic_TeamMove[stepNum++]);

            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 5044, 0, random.Next(4,6), 5363, 11953);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 65);
            }

            im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
            im.action.endTurn();


            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 5044, 0, random.Next(4,6), 5363, 11953);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 65);
            }


            //回合结束
            im.uihelp.setStatusBarText_InThread(String.Format("回合开始"));
            im.action.endEnemyTurn();
            im.action.startTurn();



            //Mission / reinforceTeam
            im.uihelp.setStatusBarText_InThread(String.Format(" 部署梯队"));
            im.action.reinforceTeam(Map_Sent.MapE1_4.spots2);

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE1_4.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE1_4.dic_TeamMove[stepNum++]);

            //撤离
            im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
            im.action.withdrawTeam(Map_Sent.MapE1_4.withdrawSpot);

            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            im.action.abortMission();


            im.action.eventDraw();
        }


        public void E2_2(User_Normal_BattleTaskInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.MapE2_2.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_2.spots2.team_id = ubti.TaskSupportTeam1_ID;

            Map_Sent.MapE2_2.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_2.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_2.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_2.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_2.dic_TeamMove[4].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_2.dic_TeamMove[5].team_id = ubti.TaskMianTeam_ID;

            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            im.battle_loop.Check_Equip_Gun_FULL();



            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.MapE2_2.mission_id, Map_Sent.MapE2_2.Mission_Start_spots);

            im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
            im.action.SupplyTeam(ubti.TaskMianTeam_ID);


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_2.dic_TeamMove[stepNum++]);


            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 5086, 0, random.Next(10, 12), 11862, 33456);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 67);
            }

            //Mission / reinforceTeam
            im.uihelp.setStatusBarText_InThread(String.Format(" 部署梯队"));
            im.action.reinforceTeam(Map_Sent.MapE2_2.spots2,true);



            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_2.dic_TeamMove[stepNum++]);


            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 5087, 0, random.Next(10, 12), 11862, 33456);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 67);
            }



            im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
            im.action.endTurn();
            //回合结束
            im.uihelp.setStatusBarText_InThread(String.Format("回合开始"));
            im.action.endEnemyTurn();
            im.action.startTurn();

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_2.dic_TeamMove[stepNum++]);


            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 5089, 0, random.Next(10, 12), 11862, 33456);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 67);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_2.dic_TeamMove[stepNum++]);
            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_2.dic_TeamMove[stepNum++]);
            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_2.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_2.dic_TeamMove[stepNum++]);


            //撤离
            im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
            im.action.withdrawTeam(Map_Sent.MapE2_2.withdrawSpot);

            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            im.action.abortMission();


            im.action.eventDraw();
        }

        public void E2_3(User_Normal_BattleTaskInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.MapE2_3.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_3.spots2.team_id = ubti.TaskSupportTeam1_ID;

            Map_Sent.MapE2_3.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_3.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;


            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            im.battle_loop.Check_Equip_Gun_FULL();



            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.MapE2_3.mission_id, Map_Sent.MapE2_3.Mission_Start_spots);

            im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
            im.action.SupplyTeam(ubti.TaskMianTeam_ID);


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_3.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_3.dic_TeamMove[stepNum++]);


            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 5139, 0, random.Next(12, 14), 14207, 41426);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 68);
            }

            //Mission / reinforceTeam
            im.uihelp.setStatusBarText_InThread(String.Format(" 部署梯队"));
            im.action.reinforceTeam(Map_Sent.MapE2_3.spots2, true);



            im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
            im.action.endTurn();
            //回合结束
            im.uihelp.setStatusBarText_InThread(String.Format("回合开始"));
            im.action.endEnemyTurn();
            im.action.startTurn();



            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_3.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_3.dic_TeamMove[stepNum++]);

            //撤离
            im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
            im.action.withdrawTeam(Map_Sent.MapE1_4.withdrawSpot);

            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            im.action.abortMission();


            im.action.eventDraw();
        }

        public void E2_4(User_Normal_BattleTaskInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.MapE2_4.spots1.team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_4.spots2.team_id = ubti.TaskSupportTeam1_ID;

            Map_Sent.MapE2_4.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_4.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_4.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
            Map_Sent.MapE2_4.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;

            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            im.battle_loop.Check_Equip_Gun_FULL();



            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.MapE2_4.mission_id, Map_Sent.MapE2_4.Mission_Start_spots);

            im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
            im.action.SupplyTeam(ubti.TaskMianTeam_ID);


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_4.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_4.dic_TeamMove[stepNum++]);
            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_4.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_4.dic_TeamMove[stepNum++]);

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_4.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_4.dic_TeamMove[stepNum++]);

            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 5159, 0, random.Next(10, 14), 17268, 40356);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 69);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapE2_4.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapE2_4.dic_TeamMove[stepNum++]);

            im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 5148, 0, random.Next(10, 14), 17268, 40356);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, ref result, 69);
            }

            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            im.action.abortMission();


            im.action.eventDraw();
        }


    }
}
