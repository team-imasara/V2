﻿using GFHelper.UserData;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe.Auto
{
    public class Normal_Battle_Sent
    {

        public void set_data(User_Normal_BattleTaskInfo ubti)
        {
            Random random = new Random();


            switch (ubti.teamId_used)
            {
                case 0:
                    {
                        teaminfo = ubti.teaminfo0;
                        ubti.TeamEffect = ubti.TeamEffect0;
                        break;
                    }
                case 1:
                    {
                        teaminfo = ubti.teaminfo1;
                        ubti.TeamEffect = ubti.TeamEffect1;
                        break;
                    }
                default:
                    break;
            }


            foreach (var item in ubti.List_lifeReduce)
            {
                life_reduce += item;
            }

            switch (ubti.TaskMap)
            {
                case 0://5-2N
                    {
                        int r1 = random.Next(50, 60);
                        record tempRecod = new record(r1, ubti.List_withdrawGUN_ID[0], 1, 0, false);
                        this.user_rec.listRecord.Add(tempRecod);



                        break;
                    }
                case 1://7-6
                    {
                        int r1 = random.Next(150, 180);
                        record tempRecod1 = new record(r1, ubti.List_withdrawGUN_ID[0], 1, 0, false);
                        record tempRecod2 = new record(r1 + random.Next(20,50), ubti.List_withdrawGUN_ID[1], 1, 0, false);
                        this.user_rec.listRecord.Add(tempRecod1);
                        this.user_rec.listRecord.Add(tempRecod2);
                        break;
                    }
                default:
                    break;
            }
            this.skill_cd = ubti.TeamEffect;

        }

        internal Dictionary<int, Gun_With_User_Info> teaminfo = new Dictionary<int, Gun_With_User_Info>();
        public int spot_id;
        public bool if_enemy_die = true;
        public int boss_hp = 0;
        public int mvp;
        public string last_battle_info = "";
        //public Battle_Gun_Info[] gun = new Battle_Gun_Info[5];
        public user_rec user_rec = new user_rec();
        //"{\"seed\":11464086,\"record\":[\"81,41020270,1,0,False\",\"106,2547569,1,0,False\"]}"
        public int skill_cd;
        public battle_info battle_info = new battle_info();

        public int life_reduce;
        public int teamID_used = 0;

        public string BattleResult
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                JsonWriter jsonWriter = new JsonWriter(stringBuilder);

                jsonWriter.WriteObjectStart();

                jsonWriter.WritePropertyName("spot_id");
                jsonWriter.Write(spot_id);

                jsonWriter.WritePropertyName("if_enemy_die");
                jsonWriter.Write(if_enemy_die);

                jsonWriter.WritePropertyName("current_time");
                jsonWriter.Write(GameData.GetCurrentTimeStamp());

                jsonWriter.WritePropertyName("boss_hp");
                jsonWriter.Write(boss_hp);

                jsonWriter.WritePropertyName("mvp");
                jsonWriter.Write(mvp);

                jsonWriter.WritePropertyName("last_battle_info");
                jsonWriter.Write("");

                jsonWriter.WritePropertyName("guns");
                jsonWriter.WriteArrayStart();


                foreach (var item in teaminfo)
                {
                    jsonWriter.WriteObjectStart();
                    jsonWriter.WritePropertyName("id");
                    jsonWriter.Write(item.Value.id);
                    jsonWriter.WritePropertyName("life");
                    jsonWriter.Write(item.Value.life);
                    jsonWriter.WriteObjectEnd();
                }
                jsonWriter.WriteArrayEnd();

                jsonWriter.WritePropertyName("user_rec");
                StringBuilder stringBuilder1 = new StringBuilder();
                JsonWriter jsonWriter1 = new JsonWriter(stringBuilder1);
                jsonWriter1.WriteObjectStart();
                jsonWriter1.WritePropertyName("seed");
                jsonWriter1.Write(user_rec.seed);
                jsonWriter1.WritePropertyName("record");
                jsonWriter1.WriteArrayStart();
                foreach (var current in this.user_rec.listRecord)
                {
                    jsonWriter1.Write(current.ToString());
                }
                jsonWriter1.WriteArrayEnd();
                jsonWriter1.WriteObjectEnd();
                jsonWriter.Write(stringBuilder1.ToString());


                WriteDamageData(jsonWriter);



                jsonWriter.WritePropertyName("battle_damage");
                jsonWriter.WriteObjectStart();
                jsonWriter.WriteObjectEnd();
                jsonWriter.WriteObjectEnd();

                return stringBuilder.ToString();
            }
        }



        public void WriteDamageData(JsonWriter writer)
        {
            Random random = new Random();
            writer.WritePropertyName("1000");
            writer.WriteObjectStart();
            writer.WritePropertyName("10");
            writer.Write(skill_cd);
            writer.WritePropertyName("11");
            writer.Write(skill_cd-life_reduce);
            writer.WritePropertyName("12");
            writer.Write(skill_cd);
            writer.WritePropertyName("13");
            writer.Write(skill_cd);
            writer.WritePropertyName("15");
            writer.Write(battle_info.enemy_effect_client);

            writer.WritePropertyName("16");
            writer.Write(0);

            writer.WritePropertyName("17");
            writer.Write(battle_info.true_time);//要 4场战斗 不同的时间 总帧数

            writer.WritePropertyName("33");
            writer.Write(0);//改

            writer.WritePropertyName("40");
            writer.Write(128);//我也不知道是什么

            writer.WritePropertyName("18");
            writer.Write(life_reduce);
            writer.WritePropertyName("19");

            if (battle_info.damage_team_no_miss == 0)
            {
                writer.Write((int)(life_reduce * (double)random.Next(10, 20) / 10));
            }
            else
            {
                writer.Write(battle_info.damage_team_no_miss);
            }

            writer.WritePropertyName("20");
            writer.Write(0);
            writer.WritePropertyName("21");
            writer.Write(0);
            writer.WritePropertyName("22");
            writer.Write(0);
            writer.WritePropertyName("23");
            writer.Write(0);
            writer.WritePropertyName("24");
            writer.Write(battle_info.life_enemy);//要 damage_enemy 4场战斗不同的数据
            writer.WritePropertyName("25");
            writer.Write(0);
            writer.WritePropertyName("26");
            writer.Write(battle_info.life_enemy);//要 life_enemy 4场战斗不同的数据
            writer.WritePropertyName("27");
            writer.Write(battle_info.client_time);// 要 实际时间 4场战斗不同的数据

            writer.WritePropertyName("34");//  min_damage_armor = "34";
            writer.Write(0);
            writer.WritePropertyName("35");//  min_damage_no_armor = "35";
            writer.Write(0);
            writer.WritePropertyName("41"); //max_damage;
            writer.Write(0);
            writer.WritePropertyName("42");
            writer.Write(0);
            writer.WritePropertyName("43");
            writer.Write(0);
            writer.WritePropertyName("44");
            writer.Write(0);
            writer.WriteObjectEnd();

            writer.WritePropertyName("1001");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WritePropertyName("1002");
            writer.WriteObjectStart();
            
            writer.WriteObjectEnd();
            writer.WritePropertyName("1003");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
        }
    }

    public static class newBattleData
    {
        public static int spot_id;
        public static bool if_enemy_die=true;
        public static int current_time;
        public static int boss_hp=0;
        public static int mvp;
        public static string last_battle_info;
        public static List<BattleTask_team_info> Teams = new List<BattleTask_team_info>();
        public static int teamLoc;
        public static string user_rec;
        public static int truetime;
        public static int life_reduce;
        public static int enemy_effect_client;
        public static int enemy_character_type_id;
        public static int life_enemy;
        public static int user_exp;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spotid"></param>
        /// <param name="teamLoc"></param>
        /// <param name="lrd">life_reduce</param>
        /// <param name="tt">truetime</param>
        /// <param name="eec">enemy_effect_client</param>
        /// <param name="le">life_enemy</param>
        /// <param name="userexp"></param>
        /// <param name="ecti">enemy_character_type_id</param>
        public static void setData(int spotid, int teamLoc, int lrd, int tt, int eec, int le,int ecti, int userexp, bool if_enemy_die =true)
        {
            newBattleData.if_enemy_die = if_enemy_die;
            spot_id = spotid;
            newBattleData.teamLoc = teamLoc;
            mvp = Teams[newBattleData.teamLoc].MVP;
            enemy_effect_client = eec;
            life_enemy = le;
            truetime = tt;
            life_reduce = lrd;
            user_exp = userexp;
            enemy_character_type_id = ecti;
            WriteData();
        }
        public static StringBuilder stringBuilder;
        public static JsonWriter writer;



        public static void WriteData()
        {
            stringBuilder = new StringBuilder();
            writer = new JsonWriter(stringBuilder);
            writer.WriteObjectStart();

            writer.WritePropertyName("spot_id");
            writer.Write(spot_id);
            writer.WritePropertyName("if_enemy_die");
            writer.Write(if_enemy_die);
            writer.WritePropertyName("current_time");
            writer.Write(GameData.GetCurrentTimeStamp());
            writer.WritePropertyName("boss_hp");
            writer.Write(boss_hp);
            writer.WritePropertyName("mvp");
            writer.Write(mvp);
            writer.WritePropertyName("last_battle_info");
            writer.Write("");

            writer.WritePropertyName("guns");
            writer.WriteArrayStart();
            foreach (var item in Teams[teamLoc].teaminfo)
            {
                writer.WriteObjectStart();
                writer.WritePropertyName("id");
                writer.Write(item.Value.id);
                writer.WritePropertyName("life");
                writer.Write(item.Value.life);
                writer.WriteObjectEnd();
            }
            writer.WriteArrayEnd();

            writer.WritePropertyName("user_rec");
            StringBuilder stringBuilder1 = new StringBuilder();
            JsonWriter jsonWriter1 = new JsonWriter(stringBuilder1);
            jsonWriter1.WriteObjectStart();
            jsonWriter1.WritePropertyName("seed");
            jsonWriter1.Write(Teams[teamLoc].getSeed(user_exp));
            jsonWriter1.WritePropertyName("record");
            jsonWriter1.WriteArrayStart();
            //foreach (var current in user_rec.listRecord)
            //{
            //    jsonWriter1.Write(current.ToString());
            //}
            jsonWriter1.WriteArrayEnd();
            jsonWriter1.WriteObjectEnd();
            writer.Write(stringBuilder1.ToString());


            Random random = new Random();
            writer.WritePropertyName("1000");
            writer.WriteObjectStart();
            writer.WritePropertyName("10");
            writer.Write(Teams[teamLoc].TeamEffect);
            writer.WritePropertyName("11");
            writer.Write(Teams[teamLoc].TeamEffect - life_reduce);
            writer.WritePropertyName("12");
            writer.Write(Teams[teamLoc].TeamEffect);
            writer.WritePropertyName("13");
            writer.Write(Teams[teamLoc].TeamEffect);
            writer.WritePropertyName("15");
            writer.Write(enemy_effect_client);

            writer.WritePropertyName("16");
            writer.Write(0);

            writer.WritePropertyName("17");
            writer.Write(truetime*29.7);//要 4场战斗 不同的时间 总帧数

            writer.WritePropertyName("33");
            writer.Write(enemy_character_type_id);//改

            writer.WritePropertyName("40");
            writer.Write(128);//我也不知道是什么

            writer.WritePropertyName("18");
            writer.Write(life_reduce);
            writer.WritePropertyName("19");
            writer.Write((int)(life_reduce * (double)random.Next(10, 20) / 10));


            writer.WritePropertyName("20");
            writer.Write(0);
            writer.WritePropertyName("21");
            writer.Write(0);
            writer.WritePropertyName("22");
            writer.Write(0);
            writer.WritePropertyName("23");
            writer.Write(0);
            writer.WritePropertyName("24");
            writer.Write(life_enemy);//要 damage_enemy 4场战斗不同的数据
            writer.WritePropertyName("25");
            writer.Write(0);
            writer.WritePropertyName("26");
            writer.Write(life_enemy);//要 life_enemy 4场战斗不同的数据
            writer.WritePropertyName("27");
            writer.Write(truetime);// 要 实际时间 4场战斗不同的数据

            writer.WritePropertyName("34");//  min_damage_armor = "34";
            writer.Write(0);
            writer.WritePropertyName("35");//  min_damage_no_armor = "35";
            writer.Write(0);
            writer.WritePropertyName("41"); //max_damage;
            writer.Write(0);
            writer.WritePropertyName("42");
            writer.Write(0);
            writer.WritePropertyName("43");
            writer.Write(0);
            writer.WritePropertyName("44");
            writer.Write(0);
            writer.WriteObjectEnd();

            writer.WritePropertyName("1001");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WritePropertyName("1002");
            writer.WriteObjectStart();

            foreach (var item in Teams[teamLoc].teaminfo)
            {
                writer.WritePropertyName(item.Value.id.ToString());
                writer.WriteObjectStart();
                writer.WritePropertyName("47");
                writer.Write(2);
                writer.WriteObjectEnd();
            }
            writer.WriteObjectEnd();
            writer.WritePropertyName("1003");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();

            writer.WritePropertyName("battle_damage");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WriteObjectEnd();
        }

        //internal const string team_effect = "10";


        //internal const string afterbattle_team_effect = "11";

        //internal const string team_effect_60 = "12";

        //internal const string team_effect_30 = "13";

        //internal const string enemy_effect = "14";//NO

        //internal const string enemy_effect_client = "15";

        //internal const string true_damage = "16";

        //internal const string true_time = "17";

        //// Token: 0x04001608 RID: 5640
        //internal const string damage_team = "18";

        //// Token: 0x04001609 RID: 5641
        //internal const string damage_team_no_miss = "19";

        //// Token: 0x0400160A RID: 5642
        //internal const string damage_drone = "20";

        //// Token: 0x0400160B RID: 5643
        //internal const string damage_shield = "21";

        //// Token: 0x0400160C RID: 5644
        //internal const string max_shield = "22";

        //// Token: 0x0400160D RID: 5645
        //internal const string total_shield = "23";

        //// Token: 0x0400160E RID: 5646
        //internal const string damage_enemy = "24";

        //// Token: 0x0400160F RID: 5647
        //internal const string damage_enemy_own = "25";

        //// Token: 0x04001610 RID: 5648
        //internal const string life_enemy = "26";

        //// Token: 0x04001611 RID: 5649
        //internal const string client_time = "27";

        //// Token: 0x04001612 RID: 5650
        //internal const string enemy_character_type_id = "33";

        //// Token: 0x04001613 RID: 5651
        //internal const string min_damage_armor = "34";

        //// Token: 0x04001614 RID: 5652
        //internal const string min_damage_no_armor = "35";

        //// Token: 0x04001615 RID: 5653
        //internal const string max_damage = "41";

        //// Token: 0x04001616 RID: 5654
        //internal const string max_skill_damage = "42";

        //// Token: 0x04001617 RID: 5655
        //internal const string damage = "43";

        //// Token: 0x04001618 RID: 5656
        //internal const string damage_no_skill = "44";

        //// Token: 0x04001619 RID: 5657
        //internal const string cd_time_client = "45";

        //// Token: 0x0400161A RID: 5658
        //internal const string start_cd_time_client = "46";

        //// Token: 0x0400161B RID: 5659
        //internal const string skill_num = "47";

        //// Token: 0x0400161C RID: 5660
        //internal const string fairy_id = "67";

        //// Token: 0x0400161D RID: 5661
        //internal const string use_fairy_skill = "68";

        //// Token: 0x0400161E RID: 5662
        //internal const string use_fairy_passive_skill = "9";














    }







    public class Simulation_Battle_Sent
    {
        public int mission_id;
        public int boss_hp = 0;
        public double duration;
        public int skill_cd;
        public int life_enemy;
        public battle_time battle_time = new battle_time();

        public void set_Data(int mission_id, double duration, int skill_cd, int enemy_effect_client,int life_enemy)
        {
            //根据不同关卡选不同的血量
            this.mission_id = mission_id;
            this.duration = duration;
            this.skill_cd = skill_cd;
            this.battle_time.enemy_effect_client = enemy_effect_client;

            this.life_enemy = life_enemy;

            this.battle_time.true_time = duration;
        }
        public string BattleResult
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                JsonWriter jsonWriter = new JsonWriter(sb);
                jsonWriter.WriteObjectStart();
                jsonWriter.WritePropertyName("mission_id");
                jsonWriter.Write(mission_id);
                jsonWriter.WritePropertyName("boss_hp");
                jsonWriter.Write(0);
                jsonWriter.WritePropertyName("duration");
                jsonWriter.Write(battle_time.true_time);

                WriteDamageData(jsonWriter);

                jsonWriter.WritePropertyName("battle_time");
                jsonWriter.WriteObjectStart();
                jsonWriter.WriteObjectEnd();
                jsonWriter.WriteObjectEnd();


                return sb.ToString();
            }
        }






        public void WriteDamageData(JsonWriter writer)
        {
            writer.WritePropertyName("1000");
            writer.WriteObjectStart();
            writer.WritePropertyName("11");
            writer.Write(skill_cd);
            writer.WritePropertyName("12");
            writer.Write(skill_cd);
            writer.WritePropertyName("13");
            writer.Write(skill_cd);
            writer.WritePropertyName("15");
            writer.Write(battle_time.enemy_effect_client);
            writer.WritePropertyName("17");
            writer.Write(CommonHelp.GetTotalFPS_(battle_time.true_time));//总帧数
            writer.WritePropertyName("18");
            writer.Write(0);
            writer.WritePropertyName("19");
            writer.Write(0);
            writer.WritePropertyName("20");
            writer.Write(0);
            writer.WritePropertyName("21");
            writer.Write(0);
            writer.WritePropertyName("22");
            writer.Write(0);
            writer.WritePropertyName("23");
            writer.Write(0);
            writer.WritePropertyName("24");
            writer.Write(life_enemy);//血量
            writer.WritePropertyName("25");
            writer.Write(0);
            writer.WritePropertyName("26");
            writer.Write(life_enemy);
            writer.WritePropertyName("27");
            writer.Write((int)Math.Ceiling(battle_time.true_time));//总时间
            writer.WriteObjectEnd();
            writer.WritePropertyName("1001");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WritePropertyName("1002");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WritePropertyName("1003");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
        }













    }

    class TrialExercise_Battle_Sent
    {

        public int if_win = 0;
        internal Dictionary<int, Gun_With_User_Info> teaminfo = new Dictionary<int, Gun_With_User_Info>();

        public TrialExercise_Battle_Sent(Dictionary<int, Gun_With_User_Info> teaminfo)
        {
            this.teaminfo = teaminfo;
        }




        public string BattleResult
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                JsonWriter jsonWriter = new JsonWriter(stringBuilder);
                jsonWriter.WriteObjectStart();

                jsonWriter.WritePropertyName("if_win");
                jsonWriter.Write(0);

                jsonWriter.WritePropertyName("battle_guns");
                jsonWriter.WriteObjectStart();
                foreach (var item in teaminfo)
                {
                    jsonWriter.WritePropertyName(item.Value.id.ToString());
                    jsonWriter.WriteObjectStart();

                    jsonWriter.WritePropertyName("life");
                    jsonWriter.Write(item.Value.life);

                    jsonWriter.WritePropertyName("dps");
                    jsonWriter.Write(0);
                    jsonWriter.WriteObjectEnd();


                }
                jsonWriter.WriteObjectEnd();
                WriteDamageData(jsonWriter);
                jsonWriter.WritePropertyName("battle_damage");
                jsonWriter.WriteObjectStart();
                jsonWriter.WriteObjectEnd();
                jsonWriter.WriteObjectEnd();




                return stringBuilder.ToString();
            }
        }


        public void WriteDamageData(JsonWriter writer)
        {
            writer.WritePropertyName("1000");
            writer.WriteObjectStart();
            writer.WritePropertyName("11");
            writer.Write(149);
            writer.WritePropertyName("12");
            writer.Write(0);
            writer.WritePropertyName("13");
            writer.Write(0);
            writer.WritePropertyName("15");
            writer.Write(22644);
            writer.WritePropertyName("17");
            writer.Write(0);
            writer.WritePropertyName("18");
            writer.Write(0);
            writer.WritePropertyName("19");
            writer.Write(0);
            writer.WritePropertyName("20");
            writer.Write(0);
            writer.WritePropertyName("21");
            writer.Write(0);
            writer.WritePropertyName("22");
            writer.Write(0);
            writer.WritePropertyName("23");
            writer.Write(0);
            writer.WritePropertyName("24");
            writer.Write(0);
            writer.WritePropertyName("25");
            writer.Write(0);
            writer.WritePropertyName("26");
            writer.Write(24520);
            writer.WritePropertyName("27");
            writer.Write(3);
            writer.WriteObjectEnd();
            writer.WritePropertyName("1001");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WritePropertyName("1002");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
            writer.WritePropertyName("1003");
            writer.WriteObjectStart();
            writer.WriteObjectEnd();
        }




    }



}
