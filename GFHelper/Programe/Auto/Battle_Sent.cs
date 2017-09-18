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
            int r1 = random.Next(50, 60);

            this.mvp = ubti.mvp;
            //this.gun = ubti.gun;
            teaminfo = ubti.teaminfo;

            if (ubti.withdrawNUM == 1)
            {
                record tempRecod = new record(r1, ubti.withdrawgunid1, 1, 0, false);
                this.user_rec.listRecord.Add(tempRecod);

            }
            if(ubti.withdrawNUM == 2)
            {
                //"{\"seed\":11464086,\"record\":[\"81,41020270,1,0,False\",\"106,2547569,1,0,False\"]}"
                record tempRecod1 = new record(r1, ubti.withdrawgunid1, 1, 0, false);
                record tempRecod2 = new record(r1 + random.Next(13, 20), ubti.withdrawgunid2, 1, 0, false);
                this.user_rec.listRecord.Add(tempRecod1);
                this.user_rec.listRecord.Add(tempRecod2);
            }

            this.skill_cd = ubti.TeamEffect;

        }

        internal Dictionary<int, Gun_With_User_Info> teaminfo = new Dictionary<int, Gun_With_User_Info>();
        public int spot_id;
        public bool if_enemy_die=true;
        public int boss_hp=0;
        public int mvp;
        public string last_battle_info="";
        //public Battle_Gun_Info[] gun = new Battle_Gun_Info[5];
        public user_rec user_rec = new user_rec();
        //"{\"seed\":11464086,\"record\":[\"81,41020270,1,0,False\",\"106,2547569,1,0,False\"]}"
        public int skill_cd;
        public battle_damage battle_damage = new battle_damage();

        public string BattleResult
        {
            get
            {
                dynamic newjson = new Codeplex.Data.DynamicJson();

                StringBuilder stringBuilder = new StringBuilder();
                JsonWriter jsonWriter = new JsonWriter(stringBuilder);
                jsonWriter.WriteObjectStart();
                jsonWriter.WritePropertyName("spot_id");
                jsonWriter.Write(spot_id);
                jsonWriter.WritePropertyName("if_enemy_die");
                jsonWriter.Write(if_enemy_die);
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
                //newjson.spot_id /*这是节点*/ = spot_id;/* 这是值*/
                //newjson.if_enemy_die /*这是节点*/ = if_enemy_die;/* 这是值*/
                //newjson.boss_hp = boss_hp;
                //newjson.mvp = mvp;
                //newjson.last_battle_info = last_battle_info;
                //newjson.guns = gun;

                //newjson.user_rec = new{ user_rec.data.ToString()};

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

                jsonWriter.WritePropertyName("skill_cd");
                jsonWriter.Write(skill_cd);
                jsonWriter.WritePropertyName("battle_damage");

                StringBuilder stringBuilder2 = new StringBuilder();
                JsonWriter jsonWriter2 = new JsonWriter(stringBuilder2);
                jsonWriter2.WriteObjectStart();
                jsonWriter2.WritePropertyName("enemy_effect_client");
                jsonWriter2.Write(battle_damage.enemy_effect_client);
                jsonWriter2.WritePropertyName("team_effect_60");
                jsonWriter2.Write(battle_damage.team_effect_60);
                jsonWriter2.WritePropertyName("team_effect_30");
                jsonWriter2.Write(battle_damage.team_effect_30);
                jsonWriter2.WritePropertyName("true_time");
                jsonWriter2.Write(battle_damage.true_time);
                jsonWriter2.WriteObjectEnd();

                jsonWriter.Write(stringBuilder2.ToString());

                //newjson.skill_cd = skill_cd;
                //newjson.battle_damage = battle_damage;


                jsonWriter.WriteObjectEnd();
                return stringBuilder.ToString();
            }
        }

    }
    public class Simulation_Battle_Sent
    {
        public int mission_id;
        public int boss_hp = 0;
        public double duration;
        public int skill_cd;
        public battle_time battle_time = new battle_time();

        public void set_Data(int mission_id,double duration,int skill_cd,int enemy_effect_client)
        {
            this.mission_id = mission_id;
            this.duration = duration;
            this.skill_cd = skill_cd;
            this.battle_time.enemy_effect_client = enemy_effect_client;
            this.battle_time.team_effect_30 = skill_cd;
            this.battle_time.team_effect_60 = skill_cd;
            this.battle_time.true_time = duration;
        }
        public string BattleResult
        {
            get
            {
                dynamic newjson = new Codeplex.Data.DynamicJson();
                newjson.mission_id /*这是节点*/ = mission_id;/* 这是值*/
                newjson.boss_hp /*这是节点*/ = boss_hp;/* 这是值*/
                newjson.duration = duration;
                newjson.skill_cd = skill_cd;
                newjson.battle_time = battle_time;

                return newjson.ToString();
            }
        }
    }



}
