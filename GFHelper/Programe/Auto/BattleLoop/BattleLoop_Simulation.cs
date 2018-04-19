using GFHelper.Programe.Auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFHelper.Programe.Auto.Map_Sent;
using GFHelper.Programe.ProgramePro;
using System.Threading;

namespace GFHelper.Programe
{
    class BattleLoop_Simulation
    {
        private InstanceManager im;
        public BattleLoop_Simulation(InstanceManager im)
        {
            this.im = im;
        }


        //Corridor
        public void BattleCorridor()
        {
            BattleTask_team_info bti = new BattleTask_team_info();
            bti.TeamEffect = 25810;
            bti.isMainTeam = true;
            bti.TeamID = ProgrameData.AutoDefenseTrialBattleT;
            bti.teaminfo = im.userdatasummery.team_info[ProgrameData.AutoDefenseTrialBattleT];
            bti.MVP = im.userdatasummery.team_info[ProgrameData.AutoDefenseTrialBattleT][1].id;
            im.BattleLoop_S_Teams.Add(bti);//另外弄个





            new_User_Normal_MissionInfo ubti = new new_User_Normal_MissionInfo(im.BattleLoop_S_Teams, "", im.userdatasummery.user_info.experience);

            Random random = new Random();
            int stepNum = 0; string result = "";
            Corridor.spots1.team_id = ubti.Teams[0].TeamID;//机霰

            Corridor.dic_TeamMove[0].team_id = ubti.Teams[0].TeamID;
            Corridor.dic_TeamMove[1].team_id = ubti.Teams[0].TeamID;
            Corridor.dic_TeamMove[2].team_id = ubti.Teams[0].TeamID;
            Corridor.dic_TeamMove[3].team_id = ubti.Teams[0].TeamID;
            Corridor.dic_TeamMove[4].team_id = ubti.Teams[0].TeamID;
            im.battle_loop.Check_Equip_Gun_FULL();
            im.action.startMission(Corridor.mission_id, Corridor.Mission_Start_spots);
            im.action.teamMove(Corridor.dic_TeamMove[stepNum++]);
            im.action.teamMove_Random(Corridor.dic_TeamMove[stepNum++]);
            im.action.teamMove_Random(Corridor.dic_TeamMove[stepNum++]);
            im.action.teamMove_Random(Corridor.dic_TeamMove[stepNum++]);
            im.action.teamMove_Random(Corridor.dic_TeamMove[stepNum++]);

            ubti.Teams[0].TeamEffect = 25810;
            newBattleData.Teams = ubti.Teams;
            newBattleData.setData(5520, 0, 0, random.Next(8, 10), 26483, 28819, 10009, im.userdatasummery.user_info.experience);
            if (im.action.Normal_battleFinish(newBattleData.stringBuilder.ToString(), ref result))
            {
                im.battle_loop.Battle_Result_PRO(ref ubti, 0, ref result);
            }
            im.BattleLoop_S_Teams.Clear();
        }

        public bool Auto_Start_Trial()
        {

            if (ProgrameData.AutoSimulationBattleF == false) return true;
            im.uihelp.setStatusBarText_InThread(String.Format(" BP点数 高于5 开始无限防御模式"));

            int count = 0;
            while (true)
            {
                string result = im.post.StartTrial(ProgrameData.AutoDefenseTrialBattleT.ToString());

                switch (ResultPro.Result_Pro(ref result, "StartTrial_Pro", true))
                {
                    case 1:
                        {
                            goto a;
                        }
                    case 0:
                        {
                            ACTION.result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            if (count >= ProgrameData.BL_Error_num) { return false; }
                            ACTION.result_error_PRO(result, count++); continue;
                        }
                    default:
                        break;
                }

            }

            a: im.uihelp.setStatusBarText_InThread(String.Format(" 结束防御模式"));
            Thread.Sleep(5000);

            //序列化
            Random random = new Random();



            TrialExercise_Battle_Sent tbs = new TrialExercise_Battle_Sent(im.userdatasummery.team_info[ProgrameData.AutoDefenseTrialBattleT]);

            string outdatacode = tbs.BattleResult;




            count = 0;
            while (true)
            {
                string result = im.post.EndTrial(outdatacode);

                switch (ResultPro.Result_Pro(ref result, "EndTrial_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            ACTION.result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            if (count >= ProgrameData.BL_Error_num) { return false; }
                            ACTION.result_error_PRO(result, count++); continue;
                        }
                    default:
                        break;
                }
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
                        sbs.set_Data(usbt.mission_id1, usbt.duration, usbt.skill_cd, usbt.enemy_effect_client1, usbt.enemy_life1);
                        if (usbt.duration < usbt.L_duration1)
                        {
                            return;
                        }
                        break;
                    }
                case 2:
                    {
                        sbs.set_Data(usbt.mission_id2, usbt.duration, usbt.skill_cd, usbt.enemy_effect_client2, usbt.enemy_life2);
                        if (usbt.duration < usbt.L_duration2)
                        {
                            return;
                        }
                        break;
                    }
                case 3:
                    {
                        sbs.set_Data(usbt.mission_id3, usbt.duration, usbt.skill_cd, usbt.enemy_effect_client3, usbt.enemy_life3);
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
