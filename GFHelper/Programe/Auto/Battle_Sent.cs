using GFHelper.UserData;
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

            //this.mvp = ubti.mvp;
            //this.gun = ubti.gun;
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
            writer.WritePropertyName("11");
            writer.Write(skill_cd-life_reduce);
            writer.WritePropertyName("12");
            writer.Write(skill_cd);
            writer.WritePropertyName("13");
            writer.Write(skill_cd);
            writer.WritePropertyName("15");
            writer.Write(battle_info.enemy_effect_client);
            writer.WritePropertyName("17");
            writer.Write(battle_info.true_time);//要 4场战斗 不同的时间 总帧数
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
