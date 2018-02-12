﻿using System;
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




        //public void Battle5_2N(new_User_Normal_MissionInfo ubti)
        //{
        //    //u代表用户 整个的
        //    //先在im更新数据然后 this.ubti更新
        //    int stepNum = 0;
        //    string result = "";
        //    Random random = new Random();
        //    Map_Sent.Map5_2N.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map5_2N.spots2.team_id = ubti.TaskSupportTeam1_ID;
        //    Map_Sent.Map5_2N.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map5_2N.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map5_2N.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map5_2N.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;

        //    //撤退位置
        //    List<int> list = new List<int>();
        //    list.Add(14);
        //    im.battle_loop.Set_Withdraw_INFO(ubti, list);


        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查装备仓库是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();


        //    //是否需要单独补给
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
        //    im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 1);

        //    //阵型确定
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查阵型"));
        //    im.userdatasummery.Update_GUN_Pos(ubti.TaskMianTeam_ID, ubti.mvp);

        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map5_2N.mission_id, Map_Sent.Map5_2N.Mission_Start_spots);


        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

        //    //战斗结算 经验，装备，指挥官经验
        //    //建立

        //    Normal_Battle_Sent bs1 = new Normal_Battle_Sent();

        //    im.battle_loop.BattleSent_Data_Built(ref bs1, ubti, 3038, 0, random.Next(4, 5), 11830, 2430);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

        //    if (im.action.Normal_battleFinish(bs1.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

        //    Normal_Battle_Sent bs2 = new Normal_Battle_Sent();

        //    im.battle_loop.BattleSent_Data_Built(ref bs2, ubti, 3047, 0, random.Next(4, 5), 14196, 2916);
        //    //战斗结算 经验装备
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs2.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }


        //    //左移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);


        //    //左移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_2N.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map5_2N.dic_TeamMove[stepNum++]);

        //    //撤离
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
        //    im.action.withdrawTeam(Map_Sent.Map5_2N.withdrawSpot);

        //    //战役结束
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
        //    im.action.abortMission();
        //    //结算
        //}

        //public void Battle0_2(new_User_Normal_MissionInfo ubti)
        //{
        //    Random random = new Random();
        //    int stepNum = 0; string result = "";
        //    Normal_Battle_Sent bs = new Normal_Battle_Sent();
        //    Map_Sent.Map0_2.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map0_2.spots2.team_id = ubti.TaskSupportTeam1_ID;
        //    Map_Sent.Map0_2.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map0_2.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map0_2.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map0_2.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map0_2.dic_TeamMove[4].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map0_2.dic_TeamMove[5].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map0_2.dic_TeamMove[6].team_id = ubti.TaskMianTeam_ID;

        //    List<int> list = new List<int>();
        //    list.Add(18);
        //    im.battle_loop.Set_Withdraw_INFO(ubti, list);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();

        //    //是否需要单独补给
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
        //    im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 5);//补给问题

        //    //阵型确定
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查阵型"));
        //    im.userdatasummery.Update_GUN_Pos(ubti.TaskMianTeam_ID, ubti.mvp);//霰弹的位置

        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map0_2.mission_id, Map_Sent.Map0_2.Mission_Start_spots);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (单独补给)"));
        //    im.action.SupplyTeam(ubti.TaskSupportTeam1_ID);

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

        //    //战斗结算 经验，装备，指挥官经验
        //    //建立
        //    //需要扣血
        //    //im.userdatasummery.GUN_Life_reduce(100, random.Next(50, 80));
        //    bs.spot_id = 17;
        //    bs.mvp = ubti.mvp;
        //    bs.user_rec.seed = ubti.seed;
        //    //bs.battle_info.enemy_effect_client = 9544;

        //    //bs.battle_info.true_time = 23.7;
        //    bs.set_data(ubti);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

        //    //战斗结算 经验，装备，指挥官经验
        //    //建立
        //    //需要扣血
        //    //im.userdatasummery.GUN_Life_reduce(100, random.Next(30, 60));
        //    bs.spot_id = 18;
        //    bs.mvp = ubti.mvp;
        //    bs.user_rec.seed = ubti.seed;
        //    //bs.battle_info.enemy_effect_client = 8449;
        //    //bs.battle_info.true_time = 23.7;
        //    bs.set_data(ubti);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);


        //    //战斗结算 经验，装备，指挥官经验
        //    //建立
        //    //需要扣血
        //    //im.userdatasummery.GUN_Life_reduce(100, random.Next(60, 100));
        //    bs.spot_id = 16;
        //    bs.mvp = ubti.mvp;
        //    bs.user_rec.seed = ubti.seed;
        //    //bs.battle_info.enemy_effect_client = 4753;
        //    //bs.battle_info.true_time = 9.8;
        //    bs.set_data(ubti);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }



        //    im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
        //    im.action.endTurn();
        //    im.uihelp.setStatusBarText_InThread(String.Format("回合开始"));
        //    im.action.startTurn();
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

        //    //im.userdatasummery.GUN_Life_reduce(100, random.Next(10, 30));
        //    bs.spot_id = 23;
        //    bs.mvp = ubti.mvp;
        //    bs.user_rec.seed = ubti.seed;
        //    //bs.battle_info.enemy_effect_client = 6270;

        //    //bs.battle_info.true_time = 19.3;
        //    bs.set_data(ubti);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map0_2.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map0_2.dic_TeamMove[stepNum++]);

        //    //im.userdatasummery.GUN_Life_reduce(100, random.Next(20, 40));
        //    bs.spot_id = 25;
        //    bs.mvp = ubti.mvp;
        //    bs.user_rec.seed = ubti.seed;
        //    //bs.battle_info.enemy_effect_client = 6540;

        //    //bs.battle_info.true_time = 17.7;
        //    bs.set_data(ubti);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
        //    im.action.endTurn();



        //}
        //public void Battle7_6(new_User_Normal_MissionInfo ubti)
        //{
        //    Random random = new Random();
        //    int stepNum = 0; string result = "";
        //    Normal_Battle_Sent bs = new Normal_Battle_Sent();
        //    Map_Sent.Map7_6.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6.spots2.team_id = ubti.TaskSupportTeam1_ID;
        //    Map_Sent.Map7_6.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;


        //    List<int> list = new List<int>();
        //    list.Add(13); list.Add(14);
        //    im.battle_loop.Set_Withdraw_INFO(ubti, list);


        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();

        //    //是否需要单独补给
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
        //    im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 5);//补给问题

        //    //阵型确定
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查阵型"));
        //    im.userdatasummery.Update_GUN_Pos(ubti.TaskMianTeam_ID, ubti.mvp);

        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map7_6.mission_id, Map_Sent.Map7_6.Mission_Start_spots);

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1947, 0, random.Next(6, 8), 6752, 5688);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);

        //    //战斗结算 经验，装备，指挥官经验
        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1949, 0, random.Next(6, 8), 5475, 8890);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }




        //    im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
        //    im.action.endTurn();

        //    //战斗结算 经验，装备，指挥官经验
        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1949, 0, random.Next(6, 8), 6752, 5688);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.uihelp.setStatusBarText_InThread(String.Format("回合开始"));
        //    im.action.startTurn();




        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);


        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1947, 0, random.Next(6, 8), 6752, 5688);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }





        //    //Mission / reinforceTeam
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 部署梯队"));
        //    im.action.reinforceTeam(Map_Sent.Map7_6.spots2);


        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6.dic_TeamMove[stepNum++]);








        //    //撤离
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 撤离"));
        //    im.action.withdrawTeam(Map_Sent.Map7_6.withdrawSpot);

        //    //战役结束
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 终止作战"));
        //    im.action.abortMission();




        //}

        //public void Battle7_6BOSS(new_User_Normal_MissionInfo ubti)
        //{
        //    Random random = new Random();
        //    int stepNum = 0; string result = "";
        //    Normal_Battle_Sent bs = new Normal_Battle_Sent();
        //    Map_Sent.Map7_6BOSS.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6BOSS.spots2.team_id = ubti.TaskSupportTeam1_ID;
        //    Map_Sent.Map7_6BOSS.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6BOSS.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6BOSS.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6BOSS.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6BOSS.dic_TeamMove[4].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6BOSS.dic_TeamMove[5].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6BOSS.dic_TeamMove[6].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6BOSS.dic_TeamMove[7].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6BOSS.dic_TeamMove[8].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6BOSS.dic_TeamMove[9].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map7_6BOSS.dic_TeamMove[10].team_id = ubti.TaskMianTeam_ID;

        //    List<int> list = new List<int>();
        //    list.Add(18); list.Add(14);//
        //    im.battle_loop.Set_Withdraw_INFO(ubti, list);


        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();

        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map7_6BOSS.mission_id, Map_Sent.Map7_6BOSS.Mission_Start_spots);

        //    //补给梯队
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (单独补给)"));
        //    im.action.SupplyTeam(ubti.TaskMianTeam_ID);


        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1947, 0, random.Next(4, 6), 6756, 11380);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1949, 0, random.Next(4, 6), 5475, 8890);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.action.endTurn();

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1949, 0, random.Next(4, 6), 6752, 5688);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.action.endEnemyTurn();
        //    im.action.startTurn();

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1947, 0, random.Next(4, 6), 6752, 5688);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 部署梯队"));
        //    im.action.reinforceTeam(Map_Sent.Map7_6BOSS.spots2);

        //    im.uihelp.setStatusBarText_InThread(String.Format("回合结束"));
        //    im.action.endTurn();


        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1947, 0, random.Next(8, 9), 10875, 16022);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }
        //    im.action.endEnemyTurn();
        //    im.action.startTurn();



        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

        //    //补给梯队
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (单独补给)"));
        //    im.action.SupplyTeam(ubti.TaskMianTeam_ID);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1949, 0, random.Next(7, 8), 10415, 23979);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1946, 0, random.Next(7, 8), 10415, 23979);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }


        //    im.action.endTurn();
        //    im.action.endEnemyTurn();
        //    im.action.startTurn();

        //    //补给梯队
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 正在单独补给 (单独补给)"));
        //    im.action.SupplyTeam(ubti.TaskMianTeam_ID);


        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1941, 0, random.Next(7, 8), 12904, 17068);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map7_6BOSS.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1942, 0, random.Next(18, 20), 24604, 48992);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //        result_log(result, "7");
        //    }


        //    im.action.endTurn();

        //}

        //public void Battle3_4N(new_User_Normal_MissionInfo ubti)
        //{

        //    Random random = new Random();
        //    int stepNum = 0; string result = "";
        //    Normal_Battle_Sent bs = new Normal_Battle_Sent();
        //    Map_Sent.Map3_4N.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[4].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[5].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[6].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[7].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[8].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[9].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[10].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[11].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[12].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_4N.dic_TeamMove[13].team_id = ubti.TaskMianTeam_ID;

        //    List<int> list = new List<int>();
        //    list.Add(18); list.Add(14);//
        //    im.battle_loop.Set_Withdraw_INFO(ubti, list);


        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();

        //    //是否需要单独补给
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
        //    im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti, 5);//补给问题

        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map3_4N.mission_id, Map_Sent.Map3_4N.Mission_Start_spots);




        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1347, 0, random.Next(7, 8), 6020, 10112);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    string endTurn1 = im.action.endTurn();//能否靠这个猜测第二个光头 如果记得被占则终止作战
        //    im.action.endEnemyTurn();
        //    im.action.startTurn();

        //    var regex = new Regex("1485");
        //    var matches = regex.Matches(endTurn1);
        //    if (matches.Count == 2)
        //    {
        //        im.action.abortMission();
        //        return;
        //    }

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1503, 0, random.Next(6, 7), 6044, 5056);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);

        //    //第二个光头在还不在?

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1504, 0, random.Next(7, 8), 7775, 6505);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result, true))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }
        //    //else
        //    //{
        //    //    im.action.abortMission();
        //    //    return;
        //    //}

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[stepNum++]);


        //    string endTurn2 = im.action.endTurn();//分支开始推测强无敌位置  站在机场 回合结束
        //    int Bosscase = Map_Sent.Map3_4N.BossPos(endTurn2);
        //    int rCase = Map_Sent.Map3_4N.rPos(endTurn2);

        //    switch (rCase)
        //    {
        //        case 1:
        //            {
        //                im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1505, 0, random.Next(6, 7), 7775, 6505);
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //                if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //                {
        //                    im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //                }
        //                break;
        //            }
        //        default:
        //            break;
        //    }


        //    switch (Bosscase)
        //    {
        //        case 0:
        //            {
        //                im.action.endEnemyTurn();
        //                im.action.startTurn();
        //                //机场上方
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

        //                im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1489, 0, random.Next(10, 11), 9685, 21662);
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //                if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //                {
        //                    im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //                }
        //                break;
        //            }
        //        case 1:
        //            {
        //                im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1505, 0, random.Next(10, 11), 9685, 21662);
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //                if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //                {
        //                    im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //                }
        //                im.action.endEnemyTurn();
        //                im.action.startTurn();
        //                break;

        //            }
        //        case 2:
        //            {
        //                im.action.endEnemyTurn();
        //                im.action.startTurn();
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[7]);

        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[8]);

        //                im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1506, 0, random.Next(10, 11), 9685, 21662);
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //                if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //                {
        //                    im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //                }
        //                break;

        //            }

        //        case 3:
        //            {
        //                im.action.endEnemyTurn();
        //                im.action.startTurn();
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[7]);

        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[9]);

        //                im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1507, 0, random.Next(10, 11), 9685, 21662);
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //                if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //                {
        //                    im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //                }
        //                break;

        //            }

        //        case 4:
        //            {
        //                im.action.endEnemyTurn();
        //                im.action.startTurn();
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[7]);

        //                im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1509, 0, random.Next(10, 11), 9685, 21662);
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //                if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //                {
        //                    im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //                }

        //                break;

        //            }

        //        case 5:
        //            {
        //                im.action.endEnemyTurn();
        //                im.action.startTurn();
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[10]);

        //                im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1506, 0, random.Next(10, 11), 9685, 21662);
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //                if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //                {
        //                    im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //                }

        //                break;
        //            }

        //        case 6:
        //            {
        //                im.action.endEnemyTurn();
        //                im.action.startTurn();
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[11]);

        //                im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1490, 0, random.Next(10, 11), 9685, 21662);
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //                if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //                {
        //                    im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //                }

        //                break;
        //            }

        //        case 7:
        //            {
        //                im.action.endEnemyTurn();
        //                im.action.startTurn();
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[12]);

        //                im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1501, 0, random.Next(10, 11), 9685, 21662);
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //                if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //                {
        //                    im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //                }

        //                break;
        //            }

        //        case 8:
        //            {
        //                im.action.endEnemyTurn();
        //                im.action.startTurn();
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[4]);

        //                im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_4N.dic_TeamMove[stepNum]));
        //                im.action.teamMove(Map_Sent.Map3_4N.dic_TeamMove[13]);

        //                im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1476, 0, random.Next(10, 11), 9685, 21662);
        //                im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //                if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //                {
        //                    im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //                }
        //                break;
        //            }

        //        default:
        //            break;
        //    }








        //    im.action.abortMission();

        //}



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

        //public void Battle1_6(new_User_Normal_MissionInfo ubti)
        //{
        //    Random random = new Random();
        //    int stepNum = 0; string result = "";
        //    Normal_Battle_Sent bs = new Normal_Battle_Sent();
        //    Map_Sent.Map1_6.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map1_6.spots2.team_id = ubti.TaskSupportTeam1_ID;
        //    Map_Sent.Map1_6.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map1_6.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map1_6.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map1_6.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map1_6.dic_TeamMove[4].team_id = ubti.TaskMianTeam_ID;


        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();


        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map1_6.mission_id, Map_Sent.Map1_6.Mission_Start_spots);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
        //    im.action.SupplyTeam(ubti.TaskMianTeam_ID);


        //    //妖精
        //    im.action.FairyMissionSkill(ubti.TaskMianTeam_ID, 133, 136);

        //    //reinforceTeam
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 部署梯队"));
        //    im.action.reinforceTeam(Map_Sent.Map1_6.spots2);

            
        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map1_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);


        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 144, 0, random.Next(3, 4), 435, 519);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    im.action.endTurn();
        //    im.action.endEnemyTurn();
        //    im.action.startTurn();

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map1_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

        //    //战斗结算 经验，装备，指挥官经验
        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 148,0, random.Next(2, 3), 480, 415);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map1_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map1_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

        //    //战斗结算 经验，装备，指挥官经验
        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 146, 0, random.Next(5, 6), 519, 762);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //        result_log(result, "1");
        //    }

        //    im.action.endTurn();
        //    im.action.endEnemyTurn();
        //    im.action.startTurn();



        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map1_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map1_6.dic_TeamMove[stepNum++]);

        //    im.action.endTurn();




        //}

        //public void Battle2_6(new_User_Normal_MissionInfo ubti)
        //{
        //    Random random = new Random();
        //    int stepNum = 0; string result = "";
        //    Normal_Battle_Sent bs = new Normal_Battle_Sent();
        //    Map_Sent.Map2_6.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map2_6.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;


        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();


        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map2_6.mission_id, Map_Sent.Map2_6.Mission_Start_spots);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
        //    im.action.SupplyTeam(ubti.TaskMianTeam_ID);


        //    //妖精
        //    im.action.FairyMissionSkill(ubti.TaskMianTeam_ID, 260, 267);


        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map2_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map2_6.dic_TeamMove[stepNum++]);


        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 271, 0, random.Next(5, 6), 2804, 6356);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //        result_log(result, "2");
        //    }

        //    im.action.endTurn();
        //}

        //public void Battle3_6(new_User_Normal_MissionInfo ubti)
        //{
        //    Random random = new Random();
        //    int stepNum = 0; string result = "";
        //    Normal_Battle_Sent bs = new Normal_Battle_Sent();
        //    Map_Sent.Map3_6.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_6.spots2.team_id = ubti.TaskSupportTeam1_ID;
        //    Map_Sent.Map3_6.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_6.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_6.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map3_6.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;



        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();


        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map3_6.mission_id, Map_Sent.Map3_6.Mission_Start_spots);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
        //    im.action.SupplyTeam(ubti.TaskMianTeam_ID);

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove_Random(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);


        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 419, 0, random.Next(4, 5), 1644, 5880);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map3_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map3_6.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 425, 0, random.Next(6, 7), 6626, 13700);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //        result_log(result, "3");
        //    }

        //    im.action.endTurn();




        //}

        //public void Battle4_6(new_User_Normal_MissionInfo ubti)
        //{
        //    Random random = new Random();
        //    int stepNum = 0; string result = "";
        //    Normal_Battle_Sent bs = new Normal_Battle_Sent();
        //    Map_Sent.Map4_6.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map4_6.spots2.team_id = ubti.TaskSupportTeam1_ID;
        //    Map_Sent.Map4_6.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map4_6.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map4_6.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map4_6.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;



        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();


        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map4_6.mission_id, Map_Sent.Map4_6.Mission_Start_spots);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
        //    im.action.SupplyTeam(ubti.TaskMianTeam_ID);


        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map4_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 588, 0, random.Next(3, 4), 1790, 4415);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map4_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 594, 0, random.Next(6, 7), 2336, 6732);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }


        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map4_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 598, 0, random.Next(5, 6), 2403, 5742);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }


        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map4_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map4_6.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 604, 0, random.Next(7, 8), 8876, 16656);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //        result_log(result, "4");
        //    }

        //    im.action.endTurn();




        //}

        //public void Battle5_6(new_User_Normal_MissionInfo ubti)
        //{
        //    Random random = new Random();
        //    int stepNum = 0; string result = "";
        //    Normal_Battle_Sent bs = new Normal_Battle_Sent();
        //    Map_Sent.Map5_6.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map5_6.spots2.team_id = ubti.TaskSupportTeam1_ID;
        //    Map_Sent.Map5_6.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map5_6.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map5_6.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map5_6.dic_TeamMove[3].team_id = ubti.TaskMianTeam_ID;



        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();


        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map5_6.mission_id, Map_Sent.Map5_6.Mission_Start_spots);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
        //    im.action.SupplyTeam(ubti.TaskMianTeam_ID);


        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 808, 0, random.Next(6, 7), 3960, 11922);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);


        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);



        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map5_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map5_6.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 826, 0, random.Next(8, 9), 11633, 19416);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //        result_log(result, "5");
        //    }

        //    im.action.endTurn();




        //}

        //public void Battle6_6(new_User_Normal_MissionInfo ubti)
        //{
        //    Random random = new Random();
        //    int stepNum = 0; string result = "";
        //    Normal_Battle_Sent bs = new Normal_Battle_Sent();
        //    Map_Sent.Map6_6.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map6_6.spots2.team_id = ubti.TaskSupportTeam1_ID;
        //    Map_Sent.Map6_6.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map6_6.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map6_6.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;


        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();


        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map6_6.mission_id, Map_Sent.Map6_6.Mission_Start_spots);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
        //    im.action.SupplyTeam(ubti.TaskMianTeam_ID);


        //    //妖精
        //    im.action.FairyMissionSkill(ubti.TaskMianTeam_ID, 1616, 1630);


        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map6_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);


        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1628, 0, random.Next(7, 8), 9908, 8168);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }


        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map6_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);


        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1632, 0, random.Next(8, 9), 8578, 17114);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //    }




        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map6_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map6_6.dic_TeamMove[stepNum++]);


        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 1633, 0, random.Next(10, 12), 18986, 37505);
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //        result_log(result, "6");
        //    }


        //    im.action.endTurn();
        //}

        //public void Battle8_6(new_User_Normal_MissionInfo ubti)
        //{
        //    Random random = new Random();
        //    int stepNum = 0; string result = "";
        //    Normal_Battle_Sent bs = new Normal_Battle_Sent();
        //    Map_Sent.Map8_6.spots1.team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map8_6.dic_TeamMove[0].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map8_6.dic_TeamMove[1].team_id = ubti.TaskMianTeam_ID;
        //    Map_Sent.Map8_6.dic_TeamMove[2].team_id = ubti.TaskMianTeam_ID;


        //    im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
        //    im.battle_loop.Check_Equip_Gun_FULL();


        //    //部署梯队
        //    //回合开始
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
        //    im.action.startMission(Map_Sent.Map8_6.mission_id, Map_Sent.Map8_6.Mission_Start_spots);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 梯队补给"));
        //    im.action.SupplyTeam(ubti.TaskMianTeam_ID);


        //    //妖精
        //    im.action.FairyMissionSkill(ubti.TaskMianTeam_ID, 3788, 3678);

        //    im.action.endTurn();
        //    im.action.endEnemyTurn();
        //    im.action.startTurn();



        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map8_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map8_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);

        //    //右移一步
        //    im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map8_6.dic_TeamMove[stepNum]));
        //    im.action.teamMove(Map_Sent.Map8_6.dic_TeamMove[stepNum++]);

        //    im.battle_loop.BattleSent_Data_Built(ref bs, ubti, 3668, 0, random.Next(16, 18), 27549, 38000);

        //    im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));
        //    if (im.action.Normal_battleFinish(bs.BattleResult, ref result))
        //    {
        //        im.battle_loop.Battle_Result_PRO(ref ubti, ref result);
        //        result_log(result, "8");
        //    }

        //}

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


            List<int> list = new List<int>();
            list.Add(13); list.Add(14);
            //im.battle_loop.Set_Withdraw_INFO(ubti, list);


            im.uihelp.setStatusBarText_InThread(String.Format(" 检查床位是否满额"));
            im.battle_loop.Check_Equip_Gun_FULL();

            //是否需要单独补给
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查是否需要单独补给"));
            im.battle_loop.CheckGun_AMMO_MRC_NEED_SUPORT(ubti,0, 2);//补给问题

            //阵型确定
            im.uihelp.setStatusBarText_InThread(String.Format(" 检查阵型"));
            im.userdatasummery.Update_GUN_Pos(ubti.Teams[0].TeamID, ubti.Teams[0].MVP);

            //部署梯队
            //回合开始
            im.uihelp.setStatusBarText_InThread(String.Format(" 回合开始"));
            im.action.startMission(Map_Sent.Map10_4E.mission_id, Map_Sent.Map10_4E.Mission_Start_spots);

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map10_4E.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);

            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5495, 0, 0, random.Next(10, 12), 26702, 43140, 10003,im.userdatasummery.user_info.experience);
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

            newBattleData.setData(5492, 0, 0, random.Next(10, 12), 39015, 63520, 10003, im.userdatasummery.user_info.experience);
            im.uihelp.setStatusBarText_InThread(String.Format(" 战斗结算"));

            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti,0, ref result);
            }

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map10_4E.dic_TeamMove[stepNum]));
            im.action.teamMove(Map_Sent.Map10_4E.dic_TeamMove[stepNum++]);

            //右移一步
            im.uihelp.setStatusBarText_InThread(String.Format(" 移动 spot = {0}", Map_Sent.Map10_4E.dic_TeamMove[stepNum]));
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
