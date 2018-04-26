using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GFHelper.Programe.Auto.Map_Sent;
using GFHelper.Programe.ProgramePro;

namespace GFHelper.Programe.Auto
{
    class BattleLoop_Activity
    {

        private InstanceManager im;
        public BattleLoop_Activity(InstanceManager im)
        {
            this.im = im;
        }

        public void Battle_Gun_PZB38(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            Map_Sent.MapGun_PZB38.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[11].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[12].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[13].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[14].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[15].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_PZB38.dic_TeamMove[16].team_id = ubti.Teams[0].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题

            im.action.startMission(Map_Sent.MapGun_PZB38.mission_id, Map_Sent.MapGun_PZB38.Mission_Start_spots);

            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4245, 0, 0, random.Next(5, 7), 4384, 6171, 10017, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.endTurn();
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4245, 0, 0, random.Next(5, 7), 4384, 6171, 10017, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);
            im.action.reinforceTeam(Map_Sent.MapGun_PZB38.spots2);

            string endturn1 = im.action.endTurn();

            if (Function.Normal_PosCheck_type1(endturn1, 4257, 4247) == 1 || Function.Normal_PosCheck_type1(endturn1, 4253, 4247) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(4247, 0, 0, random.Next(5, 7), 4384, 6171, 10017, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            im.action.endEnemyTurn();
            im.action.startTurn();
            //拯救人质
            im.action.saveHostage(Map_Sent.MapGun_PZB38.saveHostageSpots1);
            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);






            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4248, 0, 0, random.Next(5, 7), 4384, 6171, 10017, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);


            if (Function.Normal_PosCheck_type2(endturn1, 4250) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(4250, 0, 0, random.Next(5, 7), 4384, 6171, 10017, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);

            string endTurn5 = im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4259, 0, 0, random.Next(5, 7), 4560, 5064, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);


            if (Function.Normal_PosCheck_type2(endTurn5, 4251) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(4251, 0, 0, random.Next(5, 7), 4384, 6171, 10017, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4255, 0, 0, random.Next(5, 7), 4331, 4100, 10003, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4258, 0, 0, random.Next(5, 7), 4331, 4100, 10003, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            string endturn4 = im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);

            if (Function.Normal_PosCheck_type2(endturn4, 4255) == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(4255, 0, 0, random.Next(5, 7), 4331, 4100, 10003, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }


            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGun_PZB38.dic_TeamMove[stepNum++]);


            //拯救人质
            im.action.saveHostage(Map_Sent.MapGun_PZB38.saveHostageSpots2);
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
            im.action.reinforceTeam(Map_Sent.MapE2_A_0_in_2018_winter.spots2, true);

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


            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);//补给问题
            im.action.SupplyTeam(ubti.Teams[1].TeamID, ubti.needSupply);//补给问题


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

        public void Battle_Gun_M1887_2(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGUN_M1887_2.spots1.team_id = ubti.Teams[0].TeamID;


            Map_Sent.MapGUN_M1887_2.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887_2.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887_2.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887_2.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887_2.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887_2.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_M1887_2.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;





            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.MapGUN_M1887_2.mission_id, Map_Sent.MapGUN_M1887_2.Mission_Start_spots);

            //im.action.SupplyTeam(ubti.Teams[0].TeamID);

            im.action.teamMove(Map_Sent.MapGUN_M1887_2.dic_TeamMove[stepNum++]);

            im.action.allyTeamAi(1, 0);
            im.action.allyTeamAi(2, 0);
            im.action.allyTeamAi(3, 0);

            //
            //
            im.action.allyMySideMove();
            im.action.allyMySideMove();
            im.action.allyMySideMove();
            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();




            im.action.teamMove(Map_Sent.MapGUN_M1887_2.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_M1887_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5598, 0, 0, random.Next(8, 9), 5376, 6837, 10017, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_M1887_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5611, 0, 0, random.Next(8, 9), 5480, 15654, 10012, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapGUN_M1887_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5610, 0, 0, random.Next(18, 20), 55964, 72700, 900051, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapGUN_M1887_2.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_M1887_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5613, 0, 0, random.Next(18, 20), 11336, 20145, 900088, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
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

            //im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

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

        public void Battle_Gun_DSR_2(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGUN_DSR_50_2.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_DSR_50_2.spots2.team_id = ubti.Teams[1].TeamID;

            Map_Sent.MapGUN_DSR_50_2.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_DSR_50_2.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_DSR_50_2.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_DSR_50_2.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_DSR_50_2.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_DSR_50_2.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;

            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.MapGUN_DSR_50_2.mission_id, Map_Sent.MapGUN_DSR_50_2.Mission_Start_spots);

            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);

            im.action.teamMove(Map_Sent.MapGUN_DSR_50_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5694, 0, 0, random.Next(8, 9), 5376, 6837, 10017, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_DSR_50_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5682, 0, 0, random.Next(8, 9), 5480, 15654, 10012, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }



            im.action.teamMove(Map_Sent.MapGUN_DSR_50_2.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5690, 0, 0, random.Next(18, 20), 55964, 72700, 900051, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapGUN_DSR_50_2.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_DSR_50_2.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5693, 0, 0, random.Next(18, 20), 11336, 20145, 900088, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }







        }



        public void Battle_Gun_ART556(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGUN_ART556.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_ART556.spots3.team_id = ubti.Teams[2].TeamID;
            Map_Sent.MapGUN_ART556.spots4.team_id = ubti.Teams[3].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;

            Map_Sent.MapGUN_ART556.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[5].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[6].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[7].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[8].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[9].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[10].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[11].team_id = ubti.Teams[3].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[12].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[13].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[14].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_ART556.dic_TeamMove[15].team_id = ubti.Teams[0].TeamID;


            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.MapGUN_ART556.mission_id, Map_Sent.MapGUN_ART556.Mission_Start_spots);
            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);


            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5748, 0, 0, random.Next(4, 6), 4673, 8182, 10024, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5759, 0, 0, random.Next(4, 6), 6060, 10915, 10026, im.userdatasummery.user_info.experience);
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

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5761, 0, 0, random.Next(4, 6), 6060, 10915, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.reinforceTeam(Map_Sent.MapGUN_ART556.spots2);
            im.action.SupplyTeam(ubti.Teams[1].TeamID);

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.reinforceTeam(Map_Sent.MapGUN_ART556.spots4);

            im.action.allyMySideMove();
            im.action.endTurn();
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5748, 1, 0, random.Next(4, 6), 4673, 8182, 10024, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();




            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5764, 1, 0, random.Next(4, 6), 6060, 10915, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5769, 1, 0, random.Next(4, 6), 11172, 17709, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);


            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5772, 1, 0, random.Next(4, 6), 11172, 17709, 10026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);


            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();


            im.action.teamMove(Map_Sent.MapGUN_ART556.dic_TeamMove[stepNum++]);

            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();
        }

        public void Battle_Gun_JS(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGUN_JS.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_JS.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_JS.spots3.team_id = ubti.Teams[2].TeamID;

            Map_Sent.MapGUN_JS.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_JS.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_JS.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_JS.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_JS.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;

            Map_Sent.MapGUN_JS.dic_TeamMove[5].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_JS.dic_TeamMove[6].team_id = ubti.Teams[1].TeamID;



            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.MapGUN_JS.mission_id, Map_Sent.MapGUN_JS.Mission_Start_spots);
            //im.action.SupplyTeam(ubti.Teams[0].TeamID);


            im.action.teamMove(Map_Sent.MapGUN_JS.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5592, 0, 0, random.Next(9, 10), 26061, 23814, 900051, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.reinforceTeam(Map_Sent.MapGUN_JS.spots2);
            //im.action.SupplyTeam(ubti.Teams[1].TeamID);



            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGUN_JS.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5584, 0, 0, random.Next(4, 6), 4203, 13119, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_JS.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5595, 0, 0, random.Next(4, 6), 4593, 13119, 10006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_JS.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5582, 0, 0, random.Next(4, 6), 4593, 13119, 10006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_JS.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5588, 0, 0, random.Next(4, 6), 26061, 23814, 900051, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5581, 1, 0, random.Next(4, 6), 4203, 13119, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5588, 0, 0, random.Next(4, 6), 4593, 13119, 10006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGUN_JS.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5592, 1, 0, random.Next(4, 6), 4593, 13119, 10006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.reinforceTeam(Map_Sent.MapGUN_JS.spots3);

            im.action.teamMove(Map_Sent.MapGUN_JS.dic_TeamMove[stepNum++]);

            im.action.withdrawTeam(Map_Sent.MapGUN_JS.withdrawSpot1);
            im.action.withdrawTeam(Map_Sent.MapGUN_JS.withdrawSpot2);
            im.action.abortMission();
        }

        public void Battle_Gun_SPP_1(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGUN_SPP_1.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_SPP_1.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_SPP_1.spots3.team_id = ubti.Teams[2].TeamID;

            Map_Sent.MapGUN_SPP_1.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_SPP_1.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGUN_SPP_1.dic_TeamMove[2].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_SPP_1.dic_TeamMove[3].team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapGUN_SPP_1.dic_TeamMove[4].team_id = ubti.Teams[1].TeamID;

            Map_Sent.MapGUN_SPP_1.dic_TeamMove[5].team_id = ubti.Teams[1].TeamID;




            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();

            im.action.startMission(Map_Sent.MapGUN_SPP_1.mission_id, Map_Sent.MapGUN_SPP_1.Mission_Start_spots);
            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);
            im.action.SupplyTeam(ubti.Teams[1].TeamID, ubti.needSupply);

            im.action.teamMove(Map_Sent.MapGUN_SPP_1.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5891, 0, 0, random.Next(9, 10), 10242, 18003, 10016, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapGUN_SPP_1.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5890, 0, 0, random.Next(9, 10), 10242, 18003, 10016, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapGUN_SPP_1.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_SPP_1.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5878, 1, 0, random.Next(9, 10), 10242, 18003, 10016, im.userdatasummery.user_info.experience);
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

            im.action.reinforceTeam(Map_Sent.MapGUN_SPP_1.spots3, true);

            im.action.teamMove(Map_Sent.MapGUN_SPP_1.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGUN_SPP_1.dic_TeamMove[stepNum++]);



            im.action.withdrawTeam(Map_Sent.MapGUN_SPP_1.withdrawSpot1);
            im.action.withdrawTeam(Map_Sent.MapGUN_SPP_1.withdrawSpot2);

            im.action.abortMission();


        }

        public void Battle_Gun_M4A1(new_User_Normal_MissionInfo ubti)
        {

            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapGun_M4A1.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_M4A1.spots2.team_id = ubti.Teams[1].TeamID;

            Map_Sent.MapGun_M4A1.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_M4A1.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_M4A1.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_M4A1.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_M4A1.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_M4A1.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapGun_M4A1.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;

            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);

            im.battle_loop.Check_Equip_Gun_FULL();


            im.action.SupplyTeam(ubti.Teams[0].TeamID, ubti.needSupply);//补给问题



            im.action.startMission(Map_Sent.MapGun_M4A1.mission_id, Map_Sent.MapGun_M4A1.Mission_Start_spots);

            im.action.teamMove(Map_Sent.MapGun_M4A1.dic_TeamMove[stepNum++]);

            im.action.reinforceTeam(Map_Sent.MapGun_M4A1.spots2, true);


            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGun_M4A1.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGun_M4A1.dic_TeamMove[stepNum++]);
            im.action.teamMove(Map_Sent.MapGun_M4A1.dic_TeamMove[stepNum++]);


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6371, 0, 0, random.Next(10, 20), 16392, 24774, 10009, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.allyMySideMove();
            string endTurn_Result = im.action.endTurn();


            var regex = new Regex("6370");
            var matches = regex.Matches(endTurn_Result);
            if (matches.Count == 2)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6371, 0, 0, random.Next(10, 20), 16392, 24774, 10009, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            else
            {
                //龙骑
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6371, 0, 0, random.Next(10, 20), 9472, 12388, 10008, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            //这里分歧龙骑还是跑车
            //跑车




            im.action.endEnemyTurn();
            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapGun_M4A1.dic_TeamMove[stepNum++]);
            if (matches.Count == 2)
            {
                //龙骑
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6371, 0, 0, random.Next(10, 20), 9472, 12388, 10008, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            im.action.teamMove(Map_Sent.MapGun_M4A1.dic_TeamMove[stepNum++]);


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6402, 0, 0, random.Next(10, 20), 19485, 26727, 10002, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapGun_M4A1.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6401, 0, 0, random.Next(10, 20), 25390, 58500, 900026, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.abortMission();





        }

        public void Battle_E1_1_2018_spring(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            MapE1_1_2018_spring.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            MapE1_1_2018_spring.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            MapE1_1_2018_spring.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            MapE1_1_2018_spring.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            MapE1_1_2018_spring.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            MapE1_1_2018_spring.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题


            im.action.startMission(MapE1_1_2018_spring.mission_id, MapE1_1_2018_spring.Mission_Start_spots);

            im.action.teamMove(MapE1_1_2018_spring.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6712, 0, 0, random.Next(3, 4), 744, 1080, 10001, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.reinforceTeam(MapE1_1_2018_spring.spots2);

            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startTurn();


            im.action.teamMove(MapE1_1_2018_spring.dic_TeamMove[stepNum++]);


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6726, 0, 0, random.Next(3, 4), 978, 846, 10006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(MapE1_1_2018_spring.dic_TeamMove[stepNum++]);


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6725, 0, 0, random.Next(8, 10), 978, 846, 10006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(MapE1_1_2018_spring.dic_TeamMove[stepNum++]);


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6713, 0, 0, random.Next(3, 4), 1533, 2112, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            string endTurn = im.action.endTurn();

            if (endTurn.Contains("rank"))
            {
                WriteLog.Log("Spring E1_1 成功", "log");
            }
            else
            {
                im.action.abortMission();
                Battle_E1_3_2018_spring(ubti);
            }
        }

        public void Battle_E1_2_2018_spring(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            MapE1_2_2018_spring.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            MapE1_2_2018_spring.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            MapE1_2_2018_spring.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            MapE1_2_2018_spring.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            MapE1_2_2018_spring.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            MapE1_2_2018_spring.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;

            MapE1_2_2018_spring.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            MapE1_2_2018_spring.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            MapE1_2_2018_spring.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            MapE1_2_2018_spring.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;

            MapE1_2_2018_spring.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            MapE1_2_2018_spring.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            MapE1_2_2018_spring.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;
            MapE1_2_2018_spring.dic_TeamMove[11].team_id = ubti.Teams[1].TeamID;

            im.battle_loop.Check_Equip_Gun_FULL();

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题


            im.action.startMission(MapE1_2_2018_spring.mission_id, MapE1_2_2018_spring.Mission_Start_spots);

            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);
            im.action.reinforceTeam(MapE1_2_2018_spring.spots2);

            im.action.allyMySideMove();
            im.action.endTurn();


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6744, 0, 0, random.Next(3, 4), 928, 810, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);
            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6748, 0, 0, random.Next(3, 4), 1364, 1944, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);

            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();


            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);
            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);
            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6737, 0, 0, random.Next(3, 4), 1364, 1944, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);


            im.action.allyMySideMove();
            im.action.endTurn();

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6731, 0, 0, random.Next(3, 4), 1364, 1944, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);
            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);
            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6728, 0, 0, random.Next(3, 4), 576, 477, 10003, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.teamMove(MapE1_2_2018_spring.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6744, 1, 0, random.Next(3, 4), 576, 477, 10003, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }








            im.action.allyMySideMove();
            string endTurn = im.action.endTurn();

            if (endTurn.Contains("rank"))
            {
                WriteLog.Log("Spring E1_2 成功", "log");
            }
            else
            {
                im.action.abortMission();
                Battle_E1_3_2018_spring(ubti);
            }




        }

        public void Battle_E1_3_2018_spring(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            MapE1_3_2018_spring.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            MapE1_3_2018_spring.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            MapE1_3_2018_spring.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            MapE1_3_2018_spring.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            MapE1_3_2018_spring.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            MapE1_3_2018_spring.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;

            MapE1_3_2018_spring.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            MapE1_3_2018_spring.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            MapE1_3_2018_spring.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            MapE1_3_2018_spring.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;

            im.battle_loop.Check_Equip_Gun_FULL();

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题


            im.action.startMission(MapE1_3_2018_spring.mission_id, MapE1_3_2018_spring.Mission_Start_spots);

            im.action.teamMove(MapE1_3_2018_spring.dic_TeamMove[stepNum++]);
            im.action.reinforceTeam(MapE1_3_2018_spring.spots2);

            im.action.allyMySideMove();
            string endTurn0 = im.action.endTurn();

            int home = Function.Normal_PosCheck_type2(endTurn0, 6759);
            int posCheck0 = Function.Normal_PosCheck_type2(endTurn0, 6762);
            int posCheck3 = Function.Normal_PosCheck_type1(endTurn0, 6760, 6761);
            if (home == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6759, 1, 0, random.Next(3, 4), 1466, 2315, 10004, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (posCheck0 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6762, 0, 0, random.Next(3, 4), 2070, 2768, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(MapE1_3_2018_spring.dic_TeamMove[stepNum++]);
            if (posCheck3 == 1 && posCheck0 == 2)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6763, 0, 0, random.Next(3, 4), 2070, 2768, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }





            im.action.teamMove(MapE1_3_2018_spring.dic_TeamMove[stepNum++]);
            if (posCheck0 == 2)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6761, 0, 0, random.Next(3, 4), 2070, 2768, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            im.action.teamMove(MapE1_3_2018_spring.dic_TeamMove[stepNum++]);
            //6760
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6760, 0, 0, random.Next(3, 4), 2070, 2768, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.allyMySideMove();
            string endTurn1 = im.action.endTurn();
            home = Function.Normal_PosCheck_type2(endTurn1, 6759);
            int posCheck1 = Function.Normal_PosCheck_type2(endTurn1, 6760);
            if (home == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6759, 1, 0, random.Next(3, 4), 1466, 2315, 10004, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (posCheck1 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6760, 0, 0, random.Next(3, 4), 1262, 1857, 10003, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(MapE1_3_2018_spring.dic_TeamMove[stepNum++]);
            bool teamMove1 = im.action.teamMove(MapE1_3_2018_spring.dic_TeamMove[stepNum++]);
            if(teamMove1 == false)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6756, 0, 0, random.Next(3, 4), 1466, 2315, 10004, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
                --stepNum;
                im.action.teamMove(MapE1_3_2018_spring.dic_TeamMove[stepNum++]);
            }



            teamMove1 = im.action.teamMove(MapE1_3_2018_spring.dic_TeamMove[stepNum++]);
            if (teamMove1 == false)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6756, 0, 0, random.Next(3, 4), 1466, 2315, 10004, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
                --stepNum;
                im.action.teamMove(MapE1_3_2018_spring.dic_TeamMove[stepNum++]);
            }







            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6833, 0, 0, random.Next(3, 4), 1466, 2315, 10004, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.allyMySideMove();
            string endTurn2 = im.action.endTurn();
            home = Function.Normal_PosCheck_type2(endTurn2, 6759);
            int posCheck2 = Function.Normal_PosCheck_type2(endTurn2, 6833);
            if (home == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6759, 1, 0, random.Next(3, 4), 1466, 2315, 10004, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (posCheck2 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6833, 0, 0, random.Next(3, 4), 2311, 5566, 10006, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }


            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();
            im.action.teamMove(MapE1_3_2018_spring.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6758, 0, 0, random.Next(3, 4), 2070, 2768, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.allyMySideMove();
            string endTurn3 = im.action.endTurn();
            if (endTurn3.Contains("rank"))
            {
                WriteLog.Log("Spring E1_3 成功", "log");
            }
            else
            {
                im.action.abortMission();
                Battle_E1_3_2018_spring(ubti);
            }















        }

        public void Battle_E2_1_2018_spring(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            MapE2_1_2018_spring.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            MapE2_1_2018_spring.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            MapE2_1_2018_spring.spots3.team_id = ubti.Teams[2].TeamID;//机霰
            MapE2_1_2018_spring.spots4.team_id = ubti.Teams[3].TeamID;//机霰

            MapE2_1_2018_spring.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            MapE2_1_2018_spring.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            MapE2_1_2018_spring.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            MapE2_1_2018_spring.dic_TeamMove[3].team_id = ubti.Teams[2].TeamID;

            MapE2_1_2018_spring.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;


            im.battle_loop.Check_Equip_Gun_FULL();

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题


            im.action.startMission(MapE2_1_2018_spring.mission_id, MapE2_1_2018_spring.Mission_Start_spots);

            im.action.teamMove(MapE2_1_2018_spring.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6771, 0, 0, random.Next(3, 4), 2844, 9096, 10029, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.reinforceTeam(MapE2_1_2018_spring.spots2);

            im.action.allyMySideMove();

            string endTurn0 = im.action.endTurn();
            int home = Function.Normal_PosCheck_type2(endTurn0, 6764);
            int airportCheck1 = Function.Normal_PosCheck_type2(endTurn0, 6771);

            if (home == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6764, 1, 0, random.Next(6, 7), 1930, 1340, 10003, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (airportCheck1 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6771, 0, 0, random.Next(6, 7), 3549, 11018, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();


            im.action.teamMove(MapE2_1_2018_spring.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6770, 0, 0, random.Next(6, 7), 3549, 11018, 10029, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.teamMove(MapE2_1_2018_spring.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6778, 0, 0, random.Next(6, 7), 5096, 4922, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.reinforceTeam(MapE2_1_2018_spring.spots3);


            im.action.allyMySideMove();

            string endTurn1 = im.action.endTurn();
            home = Function.Normal_PosCheck_type2(endTurn1, 6764);
            airportCheck1 = Function.Normal_PosCheck_type2(endTurn1, 6771);
            if (home == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6764, 1, 0, random.Next(6, 7), 2844, 14096, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (airportCheck1 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6771, 2, 0, random.Next(6, 7), 3549, 11018, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(MapE2_1_2018_spring.dic_TeamMove[stepNum++]);


            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6770, 2, 0, random.Next(6, 7), 5460, 16630, 10029, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.reinforceTeam(MapE2_1_2018_spring.spots4);
            im.action.teamMove(MapE2_1_2018_spring.dic_TeamMove[stepNum++]);

            string endTurn2 = im.action.endTurn();
            home = Function.Normal_PosCheck_type2(endTurn2, 6764);
            airportCheck1 = Function.Normal_PosCheck_type2(endTurn2, 6771);
            int posCheck = Function.Normal_PosCheck_type2(endTurn2, 6770);
            if (home == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6764, 1, 0, random.Next(6, 7), 2844, 14096, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (airportCheck1 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6771, 3, 0, random.Next(6, 7), 3549, 11018, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (posCheck == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6770, 2, 0, random.Next(6, 7), 3549, 11018, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();








            string endTurn3 = im.action.endTurn();
            home = Function.Normal_PosCheck_type2(endTurn3, 6764);
            airportCheck1 = Function.Normal_PosCheck_type2(endTurn3, 6771);
            posCheck = Function.Normal_PosCheck_type2(endTurn2, 6770);
            if (home == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6764, 1, 0, random.Next(6, 7), 2844, 14096, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (airportCheck1 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6771, 3, 0, random.Next(6, 7), 3549, 11018, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (posCheck == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6770, 2, 0, random.Next(6, 7), 3549, 11018, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();








            string endTurn4 = im.action.endTurn();
            home = Function.Normal_PosCheck_type2(endTurn4, 6764);
            airportCheck1 = Function.Normal_PosCheck_type2(endTurn4, 6771);
            posCheck = Function.Normal_PosCheck_type2(endTurn4, 6770);
            if (home == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6764, 1, 0, random.Next(6, 7), 2844, 14096, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (airportCheck1 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6771, 3, 0, random.Next(6, 7), 3549, 11018, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (posCheck == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6770, 2, 0, random.Next(6, 7), 3549, 11018, 10029, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            bool startTurn = im.action.startTurn();
            if (startTurn == true)
            {
                WriteLog.Log("Spring E2_1 成功", "log");
            }
            else
            {
                im.action.abortMission();
                Battle_E2_1_2018_spring(ubti);
            }














        }

        public void Battle_E2_2_2018_spring(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            MapE2_2_2018_spring.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            MapE2_2_2018_spring.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            MapE2_2_2018_spring.spots3.team_id = ubti.Teams[2].TeamID;//机霰


            MapE2_2_2018_spring.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            MapE2_2_2018_spring.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            MapE2_2_2018_spring.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            MapE2_2_2018_spring.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            MapE2_2_2018_spring.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            MapE2_2_2018_spring.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;

            im.battle_loop.Check_Equip_Gun_FULL();

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题


            im.action.startMission(MapE2_2_2018_spring.mission_id, MapE2_2_2018_spring.Mission_Start_spots);

            im.action.teamMove(MapE2_2_2018_spring.dic_TeamMove[stepNum++]);
            im.action.teamMove(MapE2_2_2018_spring.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6806, 0, 0, random.Next(3, 4), 2089, 2443, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(MapE2_2_2018_spring.dic_TeamMove[stepNum++]);
            im.action.reinforceTeam(MapE2_2_2018_spring.spots3);




            im.action.allyMySideMove();
            string endTurn0 = im.action.endTurn();
            int home = Function.Normal_PosCheck_type2(endTurn0, 6801);
            int airportCheck1 = Function.Normal_PosCheck_type2(endTurn0, 6799);
            int posCheck1 = Function.Normal_PosCheck_type2(endTurn0, 6824);
            int posCheck2 = Function.Normal_PosCheck_type2(endTurn0, 6825);


            if (airportCheck1 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6799, 1, 0, random.Next(6, 7), 1232, 819, 10003, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (home == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6801, 2, 0, random.Next(6, 7), 2595, 2856, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (posCheck1 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6824, 0, 0, random.Next(6, 7), 3100, 5241, 10004, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();


            im.action.teamMove(MapE2_2_2018_spring.dic_TeamMove[stepNum++]);

            if (posCheck2 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6825, 0, 0, random.Next(6, 7), 3239, 3332, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            im.action.teamMove(MapE2_2_2018_spring.dic_TeamMove[stepNum++]);
            if (posCheck2 == 2)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6827, 0, 0, random.Next(6, 7), 3239, 3332, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            im.action.teamMove(MapE2_2_2018_spring.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6829, 0, 0, random.Next(6, 7), 3036, 6874, 10006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }








            im.action.allyMySideMove();
            string endTurn = im.action.endTurn();

            if (endTurn.Contains("rank"))
            {
                WriteLog.Log("Spring E2_2 成功", "log");
            }
            else
            {
                im.action.abortMission();
                Battle_E1_3_2018_spring(ubti);
            }

        }

        public void Battle_E2_3_2018_spring(new_User_Normal_MissionInfo ubti)
        {
            Random random = new Random();
            int stepNum = 0; string result = "";
            MapE2_3_2018_spring.spots1.team_id = ubti.Teams[0].TeamID;//机霰
            MapE2_3_2018_spring.spots2.team_id = ubti.Teams[1].TeamID;//机霰
            MapE2_3_2018_spring.spots3.team_id = ubti.Teams[2].TeamID;//机霰


            MapE2_3_2018_spring.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            MapE2_3_2018_spring.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            MapE2_3_2018_spring.dic_TeamMove[2].team_id = ubti.Teams[1].TeamID;
            MapE2_3_2018_spring.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;


            MapE2_3_2018_spring.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            MapE2_3_2018_spring.dic_TeamMove[5].team_id = ubti.Teams[1].TeamID;
            MapE2_3_2018_spring.dic_TeamMove[6].team_id = ubti.Teams[1].TeamID;
            MapE2_3_2018_spring.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;


            MapE2_3_2018_spring.dic_TeamMove[8].team_id = ubti.Teams[0].TeamID;
            MapE2_3_2018_spring.dic_TeamMove[9].team_id = ubti.Teams[0].TeamID;
            MapE2_3_2018_spring.dic_TeamMove[10].team_id = ubti.Teams[0].TeamID;
            MapE2_3_2018_spring.dic_TeamMove[11].team_id = ubti.Teams[0].TeamID;

            im.battle_loop.Check_Equip_Gun_FULL();

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//补给问题


            im.action.startMission(MapE2_3_2018_spring.mission_id, MapE2_3_2018_spring.Mission_Start_spots);

            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);
            im.action.reinforceTeam(MapE2_3_2018_spring.spots2);

            im.action.allyMySideMove();
            string endTurn0 = im.action.endTurn();
            int home = Function.Normal_PosCheck_type2(endTurn0, 6862);
            int posCheck1 = Function.Normal_PosCheck_type2(endTurn0, 6864);
            if (home == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6862, 1, 0, random.Next(6, 7), 2206, 3330, 10001, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            if (posCheck1 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6864, 0, 0, random.Next(6, 7), 2630, 5314, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }

            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6863, 0, 0, random.Next(3, 4), 2135, 10941, 10007, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);
            im.action.reinforceTeam(MapE2_3_2018_spring.spots3);


            im.action.allyMySideMove();
            im.action.endTurn();
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();

            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6865, 0, 0, random.Next(6, 9), 5525, 6016, 10006, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);
            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);
            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);


            im.action.allyMySideMove();
            string endTurn1 = im.action.endTurn();
            posCheck1 = Function.Normal_PosCheck_type2(endTurn1, 6860);
            if (posCheck1 == 1)
            {
                newBattleData.Teams = ubti.Teams;
                newBattleData.setData(6860, 0, 0, random.Next(6, 7), 4504, 5469, 10005, im.userdatasummery.user_info.experience);
                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
                if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
                {
                    im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
                }
            }
            im.action.endEnemyTurn();
            im.action.startOtherSideTurn();
            im.action.endOtherSideTurn();
            im.action.startTurn();


            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);
            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6858, 0, 0, random.Next(6, 7), 4504, 5469, 10005, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6845, 0, 0, random.Next(6, 7), 1930, 1340, 10003, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6842, 0, 0, random.Next(6, 7), 2206, 3330, 10001, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(MapE2_3_2018_spring.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(6834, 0, 0, random.Next(15, 20), 13746, 42328, 900103, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            if (result.Contains("rank"))
            {
                WriteLog.Log("Spring E2_3 成功", "log");
            }
            else
            {
                im.action.abortMission();
                Battle_E2_3_2018_spring(ubti);
            }

        }



    }
}