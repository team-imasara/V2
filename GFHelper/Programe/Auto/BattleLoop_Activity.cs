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

        public void Battle_Equip_UMPUX(new_User_Normal_MissionInfo ubti)
        {
            //4559 zhongjian
            Random random = new Random();
            int stepNum = 0; string result = "";

            Map_Sent.MapEquip_UMPUX.spots1.team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMPUX.spots2.team_id = ubti.Teams[1].TeamID;
            Map_Sent.MapEquip_UMPUX.spots3.team_id = ubti.Teams[2].TeamID;
            Map_Sent.MapEquip_UMPUX.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMPUX.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMPUX.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMPUX.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMPUX.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMPUX.dic_TeamMove[5].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMPUX.dic_TeamMove[6].team_id = ubti.Teams[0].TeamID;
            Map_Sent.MapEquip_UMPUX.dic_TeamMove[7].team_id = ubti.Teams[0].TeamID;

            //List<int> list = new List<int>();
            //list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);



            im.battle_loop.Check_Equip_Gun_FULL();//检查床位是否满额

            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 0, 5);//检查是否需要单独补给

            im.userdatasummery.Update_GUN_Pos(ubti.Teams[0].TeamID, ubti.Teams[0].MVP);//检查阵型

            im.action.startMission(Map_Sent.MapEquip_UMPUX.mission_id, Map_Sent.MapEquip_UMPUX.Mission_Start_spots);//回合开始

            im.action.teamMove(Map_Sent.MapEquip_UMPUX.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapEquip_UMPUX.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapEquip_UMPUX.dic_TeamMove[stepNum++]);//右移一步

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4573, 0, 0, random.Next(5, 7), 14993, 21581, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapEquip_UMPUX.dic_TeamMove[stepNum++]);//右移一步

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4583, 0, 0, random.Next(5, 7), 14993, 21581, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }


            im.action.teamMove(Map_Sent.MapEquip_UMPUX.dic_TeamMove[stepNum++]);//右移一步
            im.action.teamMove(Map_Sent.MapEquip_UMPUX.dic_TeamMove[stepNum++]);//右移一步
            im.action.withdrawTeam(Map_Sent.MapEquip_UMPUX.withdrawSpot1);//撤离
            string EndTurnresult = im.action.endTurn();

            im.action.endEnemyTurn();

            im.action.startTurn();

            im.action.teamMove(Map_Sent.MapEquip_UMPUX.dic_TeamMove[stepNum++]);//右移一步

            //战斗结算 经验，装备，指挥官经验
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(4603, 0, 0, random.Next(5, 7), 14993, 21581, 10008, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }

            im.action.teamMove(Map_Sent.MapEquip_UMPUX.dic_TeamMove[stepNum++]);//右移一步

            im.action.withdrawTeam(Map_Sent.MapEquip_UMPUX.withdrawSpot2);//撤离

            im.action.abortMission();//终止作战
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




    }
}
