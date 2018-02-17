using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public void Battle_Gun_Light(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGun_Light.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_Light.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGun_Light.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_Light.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_Light.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_Light.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_Light.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_Light.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_Light.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_Light.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;

            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);


            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            im.battle_loop.Check_Equip_Gun_FULL();

            //是否需要单独补给
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题

            //阵型确定
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查阵型"));
            im.userdatasummery.Update_GUN_Pos(ubti.Teams[0].TeamID, ubti.Teams[0].MVP);

            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.MapGun_Light.mission_id, Map_Sent.MapGun_Light.Mission_Start_spots);

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapGun_Light.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapGun_Light.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5570, 0, 0, random.Next(5, 7), 888, 642, 10003, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.uihelp.setStatusBarText_InThread(String.Format(" 部署梯队"));
            im.action.reinforceTeam(Map_Sent.MapGun_Light.spots2);

            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();


            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapGun_Light.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapGun_Light.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5573, 0, 0, random.Next(5, 7), 3125, 5013, 10009, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapGun_Light.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapGun_Light.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5576, 0, 0, random.Next(5, 7), 3148, 2702, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapGun_Light.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapGun_Light.dic_TeamMove[stepNum++]);
            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapGun_Light.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapGun_Light.dic_TeamMove[stepNum++]);
            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapGun_Light.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapGun_Light.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5577, 0, 0, random.Next(5, 7), 3448, 5399, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapGun_Light.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapGun_Light.dic_TeamMove[stepNum++]);


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5575, 0, 0, random.Next(5, 7), 3148, 2702, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }





            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.MapGun_Light.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.MapGun_Light.dic_TeamMove[stepNum++]);



            //撤离
            im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
            im.action.withdrawTeam(Map_Sent.MapGun_Light.withdrawSpot);

            //战役结束
            im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
            im.action.abortMission();
        }

        public void Battle_Equip_UMP(new_User_Normal_MissionInfo ubti)
        {
            //4559 zhongjian
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapEquip_UMP.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMP.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapEquip_UMP.spots3.team_id = ubti.Teams[2].TeamID;
            Map_Sent.MapEquip_UMP.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMP.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMP.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMP.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMP.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMP.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMP.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMP.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;

            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);



            im.battle_loop.Check_Equip_Gun_FULL();//检查床位是否满额

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//检查是否需要单独补给

            im.userdatasummery.Update_GUN_Pos(ubti.Teams[0].TeamID, ubti.Teams[0].MVP);//检查阵型

            im.action.startMission(Map_Sent.MapEquip_UMP.mission_id, Map_Sent.MapEquip_UMP.Mission_Start_spots);//回合开始

            im.action.teamMove(Map_Sent.MapEquip_UMP.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapEquip_UMP.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapEquip_UMP.dic_TeamMove[stepNum++]);//右移一步

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4573, 0, 0, random.Next(5, 7), 14993, 21581, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapEquip_UMP.dic_TeamMove[stepNum++]);//右移一步

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4583, 0, 0, random.Next(5, 7), 14993, 21581, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapEquip_UMP.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapEquip_UMP.dic_TeamMove[stepNum++]);//右移一步
            im.action.withdrawTeam(Map_Sent.MapEquip_UMP.withdrawSpot1);//撤离
            string EndTurnresult = im.action.endTurn();

            im.action.endEnemyTurn();

            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapEquip_UMP.dic_TeamMove[stepNum++]);//右移一步

            //战斗结算 经验，装备，指挥官经验
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4603, 0, 0, random.Next(5, 7), 14993, 21581, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapEquip_UMP.dic_TeamMove[stepNum++]);//右移一步

            im.action.withdrawTeam(Map_Sent.MapEquip_UMP.withdrawSpot2);//撤离

            im.action.abortMission();//终止作战
        }

        /// <summary>
        /// 底层升变4
        /// </summary>
        /// <param name="ubti"></param>
        public void Battle_Equip_HK416(new_User_Normal_MissionInfo ubti)
        {
            //4559 zhongjian
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapEquip_HK416.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[11].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[12].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[13].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_HK416.dic_TeamMove[14].team_id = ubti.Teams[0].TeamID;



            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);



            im.battle_loop.Check_Equip_Gun_FULL();//检查床位是否满额

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//检查是否需要单独补给

            im.action.startMission(Map_Sent.MapEquip_HK416.mission_id, Map_Sent.MapEquip_HK416.Mission_Start_spots);//回合开始

            im.action.teamMove(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            bool isBattle = im.action.teamMove_Random(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            if (isBattle)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6042, 0, 0, random.Next(7, 9), 12190, 37920, 10012, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            im.action.teamMove(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步

            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            isBattle = im.action.teamMove_Random(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            if (isBattle)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6045, 0, 0, random.Next(7, 9), 11223, 10008, 10012, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            isBattle = im.action.teamMove_Random(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            if (isBattle)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6044, 0, 0, random.Next(7, 9), 12190, 37920, 10012, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            im.action.teamMove(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步

            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();

            isBattle = im.action.teamMove_Random(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            if (isBattle)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6055, 0, 0, random.Next(7, 9), 11223, 12249, 10008, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            isBattle = im.action.teamMove_Random(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            if (isBattle)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6033, 0, 0, random.Next(7, 9), 12190, 37920, 10012, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            im.action.teamMove(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapEquip_HK416.dic_TeamMove[stepNum++]);//右移一步


            im.action.withdrawTeam(Map_Sent.MapEquip_HK416.withdrawSpot);//撤离

            im.action.abortMission();//终止作战

        }

        public void Box_in_2018_winter(new_User_Normal_MissionInfo ubti)
        {
            ubti.Loop = false;
            im.action.missionGroupReset();
            Battle_E2_A_0_in_2018_winter(ubti);
            Battle_E2_A_1_in_2018_winter(ubti);
            Battle_E2_A_2_in_2018_winter(ubti);
            Battle_E2_A_3_in_2018_winter(ubti);
            Battle_E2_A_4_in_2018_winter(ubti);

        }

        public void Battle_E2_A_0_in_2018_winter(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapE2_A_0_in_2018_winter.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_0_in_2018_winter.spots2.team_id = ubti.Teams[2].TeamID;
            Map_Sent.MapE2_A_0_in_2018_winter.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_0_in_2018_winter.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_0_in_2018_winter.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_0_in_2018_winter.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_0_in_2018_winter.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;

            im.battle_loop.Check_Equip_Gun_FULL();//检查床位是否满额

            im.action.startMission(Map_Sent.MapE2_A_0_in_2018_winter.mission_id, Map_Sent.MapE2_A_0_in_2018_winter.Mission_Start_spots);//回合开始
            im.action.SupplyTeam(ubti.Teams[0].TeamID);//梯队补给
            im.action.teamMove(Map_Sent.MapE2_A_0_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.reinforceTeam(Map_Sent.MapE2_A_0_in_2018_winter.spots2,true);

            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5811, 0, 0, random.Next(7, 9), 6471, 11481, 10026, im.userdatasummery.user_info.experience);
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapE2_A_0_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5816, 0, 0, random.Next(7, 9), 6471, 11481, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapE2_A_0_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapE2_A_0_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5822, 0, 0, random.Next(7, 9), 2640, 4920, 10025, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapE2_A_0_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.endTurn();






        }

        public void Battle_E2_A_1_in_2018_winter(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapE2_A_1_in_2018_winter.spots1.team_id = ubti.Teams[0].TeamID;

            Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;

            im.battle_loop.Check_Equip_Gun_FULL();//检查床位是否满额

            im.action.startMission(Map_Sent.MapE2_A_1_in_2018_winter.mission_id, Map_Sent.MapE2_A_1_in_2018_winter.Mission_Start_spots);//回合开始

            im.action.SupplyTeam(ubti.Teams[0].TeamID);//梯队补给

            im.action.teamMove(Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5835, 0, 0, random.Next(7, 9), 3960, 7380, 10025, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }





            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5840, 0, 0, random.Next(7, 9), 6735, 4215, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5840, 0, 0, random.Next(7, 9), 5420, 22654, 10030, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.endOtherSideTurn();
            im.action.startTurn();
            im.action.teamMove(Map_Sent.MapE2_A_1_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.endTurn();

        }

        public void Battle_E2_A_2_in_2018_winter(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapE2_A_2_in_2018_winter.spots1.team_id = ubti.Teams[0].TeamID;

            Map_Sent.MapE2_A_2_in_2018_winter.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_2_in_2018_winter.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_2_in_2018_winter.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_2_in_2018_winter.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();//检查床位是否满额

            im.action.startMission(Map_Sent.MapE2_A_2_in_2018_winter.mission_id, Map_Sent.MapE2_A_2_in_2018_winter.Mission_Start_spots);//回合开始

            im.action.SupplyTeam(ubti.Teams[0].TeamID);//梯队补给

            im.action.teamMove(Map_Sent.MapE2_A_2_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5847, 0, 0, random.Next(7, 9), 7232, 20196, 10028, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapE2_A_2_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5850, 0, 0, random.Next(7, 9), 6856, 12066, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapE2_A_2_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapE2_A_2_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5856, 0, 0, random.Next(7, 9), 3216, 1911, 10033, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.endTurn();
        }

        public void Battle_E2_A_3_in_2018_winter(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapE2_A_3_in_2018_winter.spots1.team_id = ubti.Teams[0].TeamID;

            Map_Sent.MapE2_A_3_in_2018_winter.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_3_in_2018_winter.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_3_in_2018_winter.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_3_in_2018_winter.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();//检查床位是否满额

            im.action.startMission(Map_Sent.MapE2_A_3_in_2018_winter.mission_id, Map_Sent.MapE2_A_3_in_2018_winter.Mission_Start_spots);//回合开始

            im.action.SupplyTeam(ubti.Teams[0].TeamID);//梯队补给

            im.action.teamMove(Map_Sent.MapE2_A_3_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5861, 0, 0, random.Next(7, 9), 8439, 13791, 10016, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.allyMySideMove();
            im.action.endTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5861, 0, 0, random.Next(7, 9), 8463, 1645, 10018, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapE2_A_3_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5862, 0, 0, random.Next(7, 9), 8463, 1645, 10018, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapE2_A_3_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5863, 0, 0, random.Next(7, 9), 8316, 8617, 10014, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapE2_A_3_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5858, 0, 0, random.Next(7, 9), 9207, 21714, 900026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

        }

        public void Battle_E2_A_4_in_2018_winter(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapE2_A_4_in_2018_winter.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_4_in_2018_winter.spots2.team_id = ubti.Teams[1].TeamID;

            Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;

            Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[2].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[3].team_id = ubti.Teams[1].TeamID;

            Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
      
            Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[7].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[8].team_id = ubti.Teams[1].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();//检查床位是否满额

            im.action.startMission(Map_Sent.MapE2_A_4_in_2018_winter.mission_id, Map_Sent.MapE2_A_4_in_2018_winter.Mission_Start_spots);//回合开始

            im.action.SupplyTeam(ubti.Teams[0].TeamID);//梯队补给
            im.action.SupplyTeam(ubti.Teams[1].TeamID);//梯队补给

            im.action.teamMove(Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5891, 0, 0, random.Next(7, 9), 10242, 18003, 10016, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5890, 0, 0, random.Next(7, 9), 10242, 18003, 10016, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5878, 1, 0, random.Next(7, 9), 10242, 18003, 10016, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5872, 0, 0, random.Next(7, 9), 9140, 17960, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapE2_A_4_in_2018_winter.dic_TeamMove[stepNum++]);//右移一步


            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5872, 0, 0, random.Next(7, 9), 9140, 17960, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5876, 1, 0, random.Next(7, 9), 9140, 17960, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.endOtherSideTurn();
            im.action.startTurn();



            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5876, 1, 0, random.Next(7, 9), 9140, 17960, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.endOtherSideTurn();
            im.action.startTurn();



            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

        }




        public void Battle_Gun_PM7(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGun_PM7.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PM7.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGun_PM7.spots3.team_id = ubti.Teams[2].TeamID;
            Map_Sent.MapGun_PM7.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PM7.dic_TeamMove[1].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGun_PM7.dic_TeamMove[2].team_id = ubti.Teams[2].TeamID;
            Map_Sent.MapGun_PM7.dic_TeamMove[3].team_id = ubti.Teams[2].TeamID;
            Map_Sent.MapGun_PM7.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;


            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();


            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题
            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 1, 5);//补给问题


            im.action.startMission(Map_Sent.MapGun_PM7.mission_id, Map_Sent.MapGun_PM7.Mission_Start_spots);

            im.action.teamMove(Map_Sent.MapGun_PM7.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5776, 0, 0, random.Next(4, 6), 7147, 8594, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.reinforceTeam(Map_Sent.MapGun_PM7.spots2);

            im.action.endTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5774, 1, 0, random.Next(4, 6), 7147, 8594, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5776, 0, 0, random.Next(4, 6), 7147, 8594, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.MapGun_PM7.dic_TeamMove[stepNum++]);

            //战斗结算 经验，装备，指挥官经验
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5775, 1, 0, random.Next(5, 7), 3125, 5013, 10009, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.reinforceTeam(Map_Sent.MapGun_PM7.spots3);


            im.action.teamMove(Map_Sent.MapGun_PM7.dic_TeamMove[stepNum++]);
            im.action.withdrawTeam(Map_Sent.MapGun_PM7.withdrawSpot);
            im.action.teamMove(Map_Sent.MapGun_PM7.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGun_PM7.dic_TeamMove[stepNum++]);
            im.action.withdrawTeam(Map_Sent.MapGun_PM7.withdrawSpot);
            im.action.abortMission();
            
        }


        public void Battle_Gun_DSR_50(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGUN_DSR_50.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            Map_Sent.MapGUN_DSR_50.spots2.team_id = ubti.Teams[1].TeamID;//李白
            Map_Sent.MapGUN_DSR_50.spots3.team_id = ubti.Teams[2].TeamID;
            Map_Sent.MapGUN_DSR_50.spots4.team_id = ubti.Teams[3].TeamID;

            Map_Sent.MapGUN_DSR_50.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[4].team_id = ubti.Teams[3].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[5].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[6].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[8].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[9].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[10].team_id = ubti.Teams[3].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[11].team_id = ubti.Teams[3].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[12].team_id = ubti.Teams[3].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[13].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[14].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[15].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[16].team_id = ubti.Teams[3].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[17].team_id = ubti.Teams[3].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[18].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[19].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[20].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[21].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[22].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[23].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[24].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_DSR_50.dic_TeamMove[25].team_id = ubti.Teams[0].TeamID;

            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.MapGUN_DSR_50.mission_id, Map_Sent.MapGUN_DSR_50.Mission_Start_spots);

            im.action.SupplyTeam(ubti.Teams[0].TeamID);//{ "team_id":8}


            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);


            im.action.reinforceTeam(Map_Sent.MapGUN_DSR_50.spots3);

            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6303, 0, 0, random.Next(8, 9), 15519, 27717, 10033, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6304, 0, 0, random.Next(8, 9), 15519, 27717, 10033, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.reinforceTeam(Map_Sent.MapGUN_DSR_50.spots4);

            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);

            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6305, 0, 0, random.Next(8, 9), 15519, 27717, 10033, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.endOtherSideTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.reinforceTeam(Map_Sent.MapGUN_DSR_50.spots2);


            im.action.SupplyTeam(ubti.Teams[1].TeamID);

            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[25]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);



            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6293, 1, 0, random.Next(8, 9), 15798, 13935, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);



            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6303, 0, 0, random.Next(8, 9), 15519, 27717, 10033, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.endOtherSideTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6306, 1, 0, random.Next(8, 9), 15798, 13935, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6295, 1, 0, random.Next(8, 9), 15798, 13935, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);




            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6295, 1, 0, random.Next(8, 9), 15798, 13935, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.endOtherSideTurn();
            im.action.startTurn();



            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6308, 1, 0, random.Next(8, 9), 29562, 52575, 10027, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6290, 1, 0, random.Next(8, 9), 29562, 52575, 10027, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6297, 1, 0, random.Next(8, 9), 29562, 52575, 10027, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }





            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6310, 1, 0, random.Next(8, 9), 29562, 52575, 10027, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }







            im.action.teamMove(Map_Sent.MapGUN_DSR_50.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6298, 1, 0, random.Next(8, 9), 29562, 52575, 10027, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.allyMySideMove();
            im.action.endTurn();



        }

        public void Battle_Gun_M1887(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGUN_M1887.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_M1887.spots3.team_id = ubti.Teams[2].TeamID;
            Map_Sent.MapGUN_M1887.spots4.team_id = ubti.Teams[3].TeamID;
            Map_Sent.MapGUN_M1887.spots5.team_id = ubti.Teams[4].TeamID;

            Map_Sent.MapGUN_M1887.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;



            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.MapGUN_M1887.mission_id, Map_Sent.MapGUN_M1887.Mission_Start_spots);

            im.action.SupplyTeam(ubti.Teams[0].TeamID);

            im.action.teamMove(Map_Sent.MapGUN_M1887.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_M1887.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_M1887.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_M1887.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6214, 0, 0, random.Next(8, 9), 42085, 69426, 10027, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_M1887.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6213, 0, 0, random.Next(8, 9), 42085, 69426, 10027, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_M1887.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6212, 0, 0, random.Next(8, 9), 42085, 69426, 10027, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_M1887.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_M1887.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_M1887.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_M1887.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_M1887.dic_TeamMove[stepNum++]);

            im.action.withdrawTeam(Map_Sent.MapGUN_M1887.withdrawSpot);
            im.action.abortMission();

        }

        public void Battle_Gun_57(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGUN_57.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_57.spots2.team_id = ubti.Teams[1].TeamID;

            Map_Sent.MapGUN_57.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_57.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_57.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_57.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_57.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_57.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;

            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.MapGUN_57.mission_id, Map_Sent.MapGUN_57.Mission_Start_spots);

            im.action.SupplyTeam(ubti.Teams[0].TeamID);

            im.action.teamMove(Map_Sent.MapGUN_57.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5733, 0, 0, random.Next(8, 9), 5016, 8574, 10004, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.reinforceTeam(Map_Sent.MapGUN_57.spots2);

            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGUN_57.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5738, 0, 0, random.Next(8, 9), 5173, 14632, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapGUN_57.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5740, 0, 0, random.Next(8, 9), 6179, 6670, 10009, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapGUN_57.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5744, 0, 0, random.Next(8, 9), 5173, 14632, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.MapGUN_57.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5743, 0, 0, random.Next(8, 9), 27588, 20666, 10021, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_57.dic_TeamMove[stepNum++]);


            im.action.endTurn();
        }

        public void Battle_Gun_ART556(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGUN_ART556.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;


            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.MapGUN_ART556.mission_id, Map_Sent.MapGUN_ART556.Mission_Start_spots);
            im.action.SupplyTeam(ubti.Teams[0].TeamID);

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6225, 0, 0, random.Next(4, 6), 20000, 29751, 10016, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6225, 0, 0, random.Next(8, 10), 21886, 50530, 900026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);


            im.action.endTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6220, 0, 0, random.Next(8, 10), 20000, 29751, 10016, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6221, 0, 0, random.Next(8, 10), 20000, 29751, 10016, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.endTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6222, 0, 0, random.Next(8, 10), 21886, 50530, 900026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.reinforceTeam(Map_Sent.MapGUN_ART556.spots2);

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.withdrawTeam(Map_Sent.MapGUN_ART556.withdrawSpot);
            im.action.abortMission();

        }

    }
}
