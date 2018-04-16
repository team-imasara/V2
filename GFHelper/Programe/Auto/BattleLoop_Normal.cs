using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFHelper.Programe.Auto;
using GFHelper.Programe.ProgramePro;
using System.Text.RegularExpressions;

namespace GFHelper.Programe.Auto.BattleLoop_Normal
{
    class BattleLoop_Normal
    {

        private InstanceManager im;
        public BattleLoop_Normal(InstanceManager im)
        {
            this.im = im;
        }




        public void Battle5_2N(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.Map5_2N.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map5_2N.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_2N.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti,0 , 5);//补给问题

            im.action.startMission(Map_Sent.Map5_2N.mission_id, Map_Sent.Map5_2N.Mission_Start_spots);

            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3037, 0, 0, random.Next(8, 10), 13376, 19401, 10016, im.userdatasummery.user_info.experience);
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3038, 0, 0, random.Next(8, 10), 11830, 2430, 10018, im.userdatasummery.user_info.experience);
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3047, 0, 0, random.Next(8, 10), 14196, 2916, 10018, im.userdatasummery.user_info.experience);
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3052, 0, 0, random.Next(8, 10), 11370, 17811, 10016, im.userdatasummery.user_info.experience);
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3056, 0, 0, random.Next(8, 10), 13376, 19401, 10016, im.userdatasummery.user_info.experience);
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);
            im.action.withdrawTeam(Map_Sent.Map5_2N.withdrawSpot);
            im.action.abortMission();









        }

        public void Battle0_2(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.Map0_2.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map0_2.spots2.team_id = ubti.Teams[1].TeamID;//李白
            Map_Sent.Map0_2.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_2.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_2.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_2.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_2.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map0_2.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;





            im.battle_loop.Check_Equip_Gun_FULL();

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题


            im.action.startMission(Map_Sent.Map0_2.mission_id, Map_Sent.Map0_2.Mission_Start_spots);

            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(17, 0, 0, random.Next(8, 10), 9544, 28800, 20005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(18, 0, 0, random.Next(8, 10), 8449, 23684, 20008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(16, 0, 0, random.Next(8, 10), 4795, 11079, 20009, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();



            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(23, 0, 0, random.Next(8, 10), 6270, 18000, 20004, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(25, 0, 0, random.Next(8, 10), 6540, 18184, 20008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }




            im.action.endTurn();
        }

        public void Battle1_2(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.Map1_2.spots1.team_id = ubti.Teams[0].TeamID;//机霰

            Map_Sent.Map1_2.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_2.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_2.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_2.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_2.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_2.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;





            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.Map1_2.mission_id, Map_Sent.Map1_2.Mission_Start_spots);

            im.action.teamMove(Map_Sent.Map1_2.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map1_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(94, 0, 0, random.Next(8, 10), 132, 189, 20001, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.Map1_2.dic_TeamMove[stepNum++]);


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(95, 0, 0, random.Next(8, 10), 176, 252, 20001, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.Map1_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(96, 0, 0, random.Next(8, 10), 264, 388, 20001, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove_Random(Map_Sent.Map1_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(98, 0, 0, random.Next(8, 10), 180, 276, 20001, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();
            im.action.teamMove(Map_Sent.Map1_2.dic_TeamMove[stepNum++]);
            im.action.endTurn();

        }


        public void Battle7_6(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.Map7_6.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map7_6.spots2.team_id = ubti.Teams[1].TeamID;//李白
            Map_Sent.Map7_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;



            im.battle_loop.Check_Equip_Gun_FULL();

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题


            im.action.startMission(Map_Sent.Map7_6.mission_id, Map_Sent.Map7_6.Mission_Start_spots);

            im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1947, 0, 0, random.Next(4, 6), 6756, 11380, 10004, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1949, 0, 0, random.Next(8, 10), 5475, 8890, 10001, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.endTurn();


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1949, 0, 0, random.Next(8, 10), 5475, 8890, 10001, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.uihelp.setStatusBarText_InThread(String.Format("回合开始"));
            im.action.startTurn();


            im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1947, 0, 0, random.Next(8, 10), 6752, 5688, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.reinforceTeam(Map_Sent.Map7_6.spots2);

            im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);

            im.action.withdrawTeam(Map_Sent.Map7_6.withdrawSpot);

            im.action.abortMission();




        }



        public void Battle2_4N(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.Map2_4N.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map2_4N.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_4N.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_4N.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_4N.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_4N.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();
            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题
            im.action.startMission(Map_Sent.Map2_4N.mission_id, Map_Sent.Map2_4N.Mission_Start_spots);

            im.action.teamMove(Map_Sent.Map2_4N.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map2_4N.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1453, 0, 0, random.Next(8, 10), 7012, 5568, 10005, im.userdatasummery.user_info.experience);
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            string endTurn1 = im.action.endTurn();//能否靠这个猜测第二个光头 如果记得被占则终止作战
            if (Map_Sent.Map2_4N.PosCheck1(endTurn1) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(1453, 0, 0, random.Next(8, 10), 6707, 10016, 10016, im.userdatasummery.user_info.experience);
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }


            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.Map2_4N.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map2_4N.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map2_4N.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1461, 0, 0, random.Next(8, 10), 5988, 7624, 10008, im.userdatasummery.user_info.experience);
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.abortMission();

        }


        public void Battle3_4N(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.Map3_4N.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[11].team_id =  ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[12].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_4N.dic_TeamMove[13].team_id = ubti.Teams[0].TeamID;



            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            im.battle_loop.Check_Equip_Gun_FULL();

            //是否需要单独补给
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题

            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.Map3_4N.mission_id, Map_Sent.Map3_4N.Mission_Start_spots);




            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1347, 0, 0, random.Next(8, 10), 6020, 10112, 20008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }






            string endTurn1 = im.action.endTurn();//能否靠这个猜测第二个光头 如果记得被占则终止作战
            im.action.endEnemyTurn();
            im.action.startTurn();

            var regex = new Regex("1485");
            var matches = regex.Matches(endTurn1);
            if (matches.Count == 2)
            {
                im.action.abortMission();
                return;
            }

            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1503, 0, 0, random.Next(8, 10), 6044, 5056, 20008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);

            //第二个光头在还不在?

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1504, 0, 0, random.Next(8, 10), 7775, 6505, 20008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            //else
            //{
            //    im.action.abortMission();
            //    return;
            //}

            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);


            string endTurn2 = im.action.endTurn();//分支开始推测强无敌位置  站在机场 回合结束
            int Bosscase = Map_Sent.Map3_4N.BossPos(endTurn2);
            int rCase = Map_Sent.Map3_4N.rPos(endTurn2);

            switch (rCase)
            {
                case 1:
                    {
                        newBattleData.Teams = ubti.Teams;
                        newBattleData.setData(1505, 0, 0, random.Next(8, 10), 7775, 6505, 20008, im.userdatasummery.user_info.experience);
                        im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                        if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                        {
                            im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                        }
                        break;
                    }
                default:
                    break;
            }


            switch (Bosscase)
            {
                case 0:
                    {
                        im.action.endEnemyTurn();
                        im.action.startTurn();
                        //机场上方
                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

                        newBattleData.Teams = ubti.Teams;
                        newBattleData.setData(1489, 0, 0, random.Next(8, 10), 9685, 21662, 20008, im.userdatasummery.user_info.experience);
                        im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                        if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                        {
                            im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                        }



                        break;
                    }
                case 1:
                    {
                        newBattleData.Teams = ubti.Teams;
                        newBattleData.setData(1505, 0, 0, random.Next(8, 10), 9685, 21662, 20008, im.userdatasummery.user_info.experience);
                        im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                        if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                        {
                            im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                        }

                        im.action.endEnemyTurn();
                        im.action.startTurn();
                        break;

                    }
                case 2:
                    {
                        im.action.endEnemyTurn();
                        im.action.startTurn();
                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[7]);

                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[8]);

                        newBattleData.Teams = ubti.Teams;
                        newBattleData.setData(1506, 0, 0, random.Next(8, 10), 9685, 21662, 20008, im.userdatasummery.user_info.experience);
                        im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                        if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                        {
                            im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                        }


                        break;

                    }

                case 3:
                    {
                        im.action.endEnemyTurn();
                        im.action.startTurn();
                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[7]);

                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[9]);

                        newBattleData.Teams = ubti.Teams;
                        newBattleData.setData(1507, 0, 0, random.Next(8, 10), 9685, 21662, 20008, im.userdatasummery.user_info.experience);
                        im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                        if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                        {
                            im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                        }



                        break;

                    }

                case 4:
                    {
                        im.action.endEnemyTurn();
                        im.action.startTurn();
                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[7]);

                        newBattleData.Teams = ubti.Teams;
                        newBattleData.setData(1509, 0, 0, random.Next(8, 10), 9685, 21662, 20008, im.userdatasummery.user_info.experience);
                        im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                        if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                        {
                            im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                        }
                        break;

                    }

                case 5:
                    {
                        im.action.endEnemyTurn();
                        im.action.startTurn();
                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[10]);

                        newBattleData.Teams = ubti.Teams;
                        newBattleData.setData(1506, 0, 0, random.Next(8, 10), 9685, 21662, 20008, im.userdatasummery.user_info.experience);
                        im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                        if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                        {
                            im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                        }
                        break;
                    }

                case 6:
                    {
                        im.action.endEnemyTurn();
                        im.action.startTurn();
                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[11]);


                        newBattleData.Teams = ubti.Teams;
                        newBattleData.setData(1490, 0, 0, random.Next(8, 10), 9685, 21662, 20008, im.userdatasummery.user_info.experience);
                        im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                        if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                        {
                            im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                        }



                        break;
                    }

                case 7:
                    {
                        im.action.endEnemyTurn();
                        im.action.startTurn();
                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[12]);

                        newBattleData.Teams = ubti.Teams;
                        newBattleData.setData(1501, 0, 0, random.Next(8, 10), 9685, 21662, 20008, im.userdatasummery.user_info.experience);
                        im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                        if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                        {
                            im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                        }
                        break;
                    }

                case 8:
                    {
                        im.action.endEnemyTurn();
                        im.action.startTurn();
                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

                        im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
                        im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[13]);

                        newBattleData.Teams = ubti.Teams;
                        newBattleData.setData(1476, 0, 0, random.Next(8, 10), 9685, 21662, 20008, im.userdatasummery.user_info.experience);
                        im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                        if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                        {
                            im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                        }



                        break;
                    }

                default:
                    break;
            }








            im.action.abortMission();

        }



        //public void text(new_User_Normal_MissionInfo ubti)
        //{
        //    //Battle1_6(ubti);
        //    Battle2_6(ubti);
        //    Battle3_6(ubti);
        //    Battle4_6(ubti);
        //    Battle5_6(ubti);
        //    Battle6_6(ubti);
        //    Battle7_6BOSS(ubti);
        //    Battle8_6(ubti);
        //}

        public void Battle1_6(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.Map1_6.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map1_6.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            Map_Sent.Map1_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map1_6.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.Map1_6.mission_id, Map_Sent.Map1_6.Mission_Start_spots);

            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);


            im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(135, 0, 0, random.Next(8, 10), 279, 512, 20004, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove_Random(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(136, 0, 0, random.Next(8, 10), 435, 519, 20002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(144, 0, 0, random.Next(8, 10), 480, 415, 20002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);
            im.action.teamMove_Random(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(149, 0, 0, random.Next(8, 10), 519, 764, 90002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            result = im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);
            if (Map_Sent.Map1_6.HomePos2(result) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(146, 0, 0, random.Next(8, 10), 380, 800, 20004, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }



            im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

            string endTrun = im.action.endTurn();
            if (endTrun.Contains("rank"))
            {
                WriteLog.Log("1_6BOSS 成功", "log");
            }
            else
            {
                im.action.abortMission();
                Battle1_6(ubti);
            }
        }

        public void Battle2_6(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.Map2_6.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.Map2_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map2_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.Map2_6.mission_id, Map_Sent.Map2_6.Mission_Start_spots);

            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            im.action.teamMove(Map_Sent.Map2_6.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map2_6.dic_TeamMove[stepNum++]);



            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(263, 0, 0, random.Next(8, 10), 736, 1820, 20005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(263, 0, 0, random.Next(8, 10), 1008, 7860, 20005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endEnemyTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.Map2_6.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map2_6.dic_TeamMove[stepNum++]);



            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(271, 0, 0, random.Next(8, 10), 2804, 6356, 90004, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endTurn();
            WriteLog.Log("2_6BOSS 成功", "log");
        }

        public void Battle3_6(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.Map3_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map3_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map3_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.Map3_6.mission_id, Map_Sent.Map3_6.Mission_Start_spots);

            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            im.action.teamMove(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);

            im.action.teamMove_Random(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(423, 0, 0, random.Next(8, 10), 1534, 4461, 20005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(424, 0, 0, random.Next(8, 10), 1866, 5070, 20006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(425, 0, 0, random.Next(8, 10), 6626, 13700, 90002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endTurn();
            WriteLog.Log("3_6BOSS 成功", "log");
        }

        public void Battle4_6(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.Map4_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map4_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map4_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.Map4_6.mission_id, Map_Sent.Map4_6.Mission_Start_spots);

            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            im.action.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(588, 0, 0, random.Next(8, 10), 1790, 4415, 90002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map4_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(594, 0, 0, random.Next(8, 10), 2336, 6732, 90002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map4_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(598, 0, 0, random.Next(8, 10), 2403, 5742, 90002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map4_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(604, 0, 0, random.Next(8, 10), 8876, 16656, 90002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.endTurn();
            WriteLog.Log("4_6BOSS 成功", "log");



        }

        public void Battle5_6(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.Map5_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map5_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map5_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.Map5_6.mission_id, Map_Sent.Map5_6.Mission_Start_spots);

            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(808, 0, 0, random.Next(8, 10), 3960, 11922, 90002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);



            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_6.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(826, 0, 0, random.Next(8, 10), 11633, 19416, 90002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endTurn();
            WriteLog.Log("5_6BOSS 成功", "log");



        }

        public void Battle6_6(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.Map6_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map6_6.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.Map6_6.mission_id, Map_Sent.Map6_6.Mission_Start_spots);
            
            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            im.action.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1634, 0, 0, random.Next(8, 10), 5980, 15210, 10004, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1620, 0, 0, random.Next(8, 10), 7988, 19644, 10006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            im.action.endTurn();
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1621, 0, 0, random.Next(8, 10), 7988, 19644, 10006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1632, 0, 0, random.Next(8, 10), 8578, 17114, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1633, 0, 0, random.Next(8, 10), 18986, 42505, 900033, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            
            im.action.endTurn();
            WriteLog.Log("6_6BOSS 成功", "log");
        }
        public void Battle7_6BOSS(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map7_6BOSS.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map7_6BOSS.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.Map7_6BOSS.mission_id, Map_Sent.Map7_6BOSS.Mission_Start_spots);

            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1947, 0, 0, random.Next(8, 10), 6756, 11380, 10004, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.reinforceTeam(Map_Sent.Map7_6BOSS.spots2);
            im.action.SupplyTeam(ubti.Teams[1].TeamID, ubti.needSupply);

            im.action.endTurn();
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1947, 0, 0, random.Next(8, 10), 6752, 5688, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1948, 1, 0, random.Next(8, 10), 5475, 8890, 10001, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            im.action.SupplyTeam(ubti.Teams[1].TeamID, ubti.needSupply);

            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1946, 0, 0, random.Next(8, 10), 10875, 16022, 10002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(2152, 0, 0, random.Next(8, 10), 10415, 23979, 10006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1941, 0, 0, random.Next(8, 10), 12904, 17068, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            im.action.endTurn();
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(1941, 0, 0, random.Next(8, 10), 24604, 53992, 900039, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.endEnemyTurn();
            im.action.startTurn();
            im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);
            im.action.endTurn();
            WriteLog.Log("7_6BOSS 成功", "log");
        }
        public void Battle8_6(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Normal_Battle_Sent bs = new Normal_Battle_Sent();
            Map_Sent.Map8_6.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map8_6.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.Map8_6.mission_id, Map_Sent.Map8_6.Mission_Start_spots);

            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);
            im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            im.action.reinforceTeam(Map_Sent.Map8_6.spots2);
            im.action.SupplyTeam(ubti.Teams[1].TeamID, ubti.needSupply);

            string homepos3 = im.action.endTurn();

            im.action.endEnemyTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3789, 0, 0, random.Next(8, 10), 14216, 16880, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3662, 0, 0, random.Next(8, 10), 14216, 16880, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);

            if (Map_Sent.Map8_6.HomePos3(homepos3) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(3679, 1, 0, random.Next(8, 10), 14216, 15880, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }



            string HomePos = im.action.endTurn();
            if (Map_Sent.Map8_6.HomePos1(HomePos) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(3788, 1, 0, random.Next(8, 10), 14184, 17816, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (Map_Sent.Map8_6.HomePos2(HomePos) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(3679, 0, 0, random.Next(8, 10), 14216, 16880, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }



            im.action.endEnemyTurn();
            im.action.startTurn();
            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);

            if (Map_Sent.Map8_6.PosCheck2(HomePos) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(3679, 0, 0, random.Next(8, 10), 14216, 16880, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }




            im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            if (Map_Sent.Map8_6.PosCheck1(HomePos) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(3682, 0, 0, random.Next(8, 10), 14216, 16880, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }


            im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3667, 0, 0, random.Next(8, 10), 13305, 44774, 10012, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3673, 0, 0, random.Next(8, 10), 13305, 44774, 10012, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            HomePos = im.action.endTurn();
            if (Map_Sent.Map8_6.HomePos1(HomePos) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(3788, 1, 0, random.Next(8, 10), 14184, 17816, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            im.action.endEnemyTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3664, 0, 0, random.Next(8, 10), 18023, 31636, 10004, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3670, 0, 0, random.Next(8, 10), 18023, 31636, 10004, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(3669, 0, 0, random.Next(8, 10), 23382, 38970, 900070, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            if (result.Contains("rank"))
            {
                im.action.abortMission();
                WriteLog.Log("8_6BOSS 成功", "log");
            }
            else
            {
                im.action.abortMission();
                Battle8_6(ubti);
            }
        }

        public void Battle10_4E(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.Map10_4E.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.Map10_4E.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;

            List<int> list = new List<int>();
            list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti,0, 2);//补给问题
            im.action.startMission(Map_Sent.Map10_4E.mission_id, Map_Sent.Map10_4E.Mission_Start_spots);

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map10_4E.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5495, 0, 0, random.Next(10, 12), 26702, 43140, 10027, im.userdatasummery.user_info.experience);
            WriteLog.Log(newBattleData.stringBuilder.ToString(), "debug");
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0,ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map10_4E.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验

            newBattleData.setData(5492, 0, 0, random.Next(10, 12), 39015, 63520, 10027, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti,0, ref result);
            }

            im.action.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);

            newBattleData.setData(5497, 0, 0, random.Next(10, 12), 26702, 43140, 10027, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            im.action.allyMySideMove();
                im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();

            newBattleData.setData(5497, 0, 0, random.Next(10, 12), 39015, 63520, 10027, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endOtherSideTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);


            //撤离
            im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
            im.action.withdrawTeam(Map_Sent.Map10_4E.withdrawSpot);

            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            im.action.abortMission();
        }


        private void result_log(string result,string str)
        {
            if (result.Contains("prize"))
            {
                WriteLog.Log(string.Format("第 {0} 获得prize", str),"log");
            }
            else
            {
                WriteLog.Log(string.Format("第 {0} 没有获得prize", str),"log");
            }
        }

    }
}
