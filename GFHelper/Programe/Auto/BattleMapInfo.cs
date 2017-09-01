using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe.Auto
{
    public class Spots
    {
        public int spot_id;
        public int team_id;
    }
    public class Battle_Gun_Info
    {
        public int id;
        public int life;
    }
    public class user_rec
    {
        public int seed;
        public string[] record;
    }
    public class record
    {
        public int fixedFrameId;
        public int gunId;
        public int type;
        public int targetPosId;
        public bool autoSkillSwitch;
    }
    public class battle_damage
    {
        public int enemy_effect_client;
        public int team_effect_60;
        public int team_effect_30;
        public string true_time;
    }
    public class TeamMove
    {
        //{"team_id":6,"from_spot_id":3033,"to_spot_id":3038,"move_type":1}
        public int team_id;
        public int from_spot_id;
        public int to_spot_id;
        public int move_type;
    }
    public class BattleMap
    {
        public int mission_id;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public Spots[] Mission_Start_spots = new Spots[9];//部署梯队的信息
        public Dictionary<int, TeamMove> dic_TeamMove = new Dictionary<int, TeamMove>();//梯队移动的顺序
        public int withdrawSpot;//撤离

        public TeamMove teammove=new TeamMove();
        public void setTeamMove(int from_spot_id,int to_spot_id,int move_type)
        {
            this.teammove.from_spot_id = from_spot_id;
            this.teammove.to_spot_id = to_spot_id;
            this.teammove.move_type = move_type;
            this.dic_TeamMove.Add(dic_TeamMove.Count, teammove);
        }
    }
    public class Battle_Result_Sent //在地图里弄
    {
        public void set_data (Battle_Result_Sent brs)
        {
            this.spot_id = brs.spot_id;
            this.if_enemy_die = brs.if_enemy_die;
            this.boss_hp = brs.boss_hp;
            this.mvp = brs.mvp;
            this.last_battle_info = brs.last_battle_info;
            this.gun = brs.gun;
            this.user_rec = brs.user_rec;
            this.skill_cd = brs.skill_cd;
            this.battle_damage = brs.battle_damage;
            build_sent_data();
        }
        public int spot_id;
        public bool if_enemy_die;
        public int boss_hp;
        public int mvp;
        public string last_battle_info;
        public Battle_Gun_Info[] gun = new Battle_Gun_Info[5];
        public user_rec user_rec = new user_rec();
        public int skill_cd;
        public battle_damage battle_damage = new battle_damage();
        public object obj = new object();
        public void build_sent_data()
        {
            this.obj = new
            {
                spot_id = spot_id,
                if_enemy_die= if_enemy_die,
                boss_hp= boss_hp,
                mvp = mvp,
                last_battle_info= last_battle_info,
                guns =gun,
                user_rec= user_rec,
                skill_cd = skill_cd,
                battle_damage= battle_damage
            };
        }
    }
    public class Battle_TASK_INFO
    {
        public BattleMap Battle5_2N = new BattleMap();
        public Battle_Result_Sent Ressult_5_2N_1 = new Battle_Result_Sent();
        public Battle_Result_Sent Ressult_5_2N_2 = new Battle_Result_Sent();
        public void setBattle_5_2N_1(UserBattleTaskInfo ubti)
        {
            Random random = new Random();
            Battle_Result_Sent brs0 = new Battle_Result_Sent();
            brs0.spot_id = Battle5_2N.dic_TeamMove[0].to_spot_id;
            brs0.if_enemy_die = true;
            brs0.boss_hp = 0;
            brs0.mvp = ubti.mvp;
            brs0.last_battle_info = "";

            brs0.gun = ubti.gun;
            brs0.user_rec.seed = ubti.seed;

            int r1 = random.Next(50, 60);
            brs0.user_rec.record[0] = string.Format("{0},{1},{2},{3},{4},{5}", r1, ubti.withdrawgunid1, 1, 0, false.ToString());
            brs0.user_rec.record[1] = string.Format("{0},{1},{2},{3},{4},{5}", r1 + random.Next(13, 20), ubti.withdrawgunid2, 1, 0, false.ToString());

            brs0.battle_damage.enemy_effect_client = 11830;
            brs0.battle_damage.team_effect_30 = ubti.team_effect_60;
            brs0.battle_damage.team_effect_60 = ubti.team_effect_60;
            brs0.battle_damage.true_time = ((float)(random.Next(35, 40) / 10)).ToString();
            brs0.build_sent_data();
        }

        public void setBattle_5_2N_2(UserBattleTaskInfo ubti)
        {
            Random random = new Random();
            Battle_Result_Sent brs0 = new Battle_Result_Sent();
            brs0.spot_id = Battle5_2N.dic_TeamMove[1].to_spot_id;
            brs0.if_enemy_die = true;
            brs0.boss_hp = 0;
            brs0.mvp = ubti.mvp;
            brs0.last_battle_info = "";

            brs0.gun = ubti.gun;
            brs0.user_rec.seed = ubti.seed;

            int r1 = random.Next(80, 90);
            brs0.user_rec.record[0] = string.Format("{0},{1},{2},{3},{4},{5}", r1, ubti.withdrawgunid1, 1, 0, false.ToString());
            brs0.user_rec.record[1] = string.Format("{0},{1},{2},{3},{4},{5}", r1 + random.Next(13, 20), ubti.withdrawgunid2, 1, 0, false.ToString());

            brs0.battle_damage.enemy_effect_client = 14196;
            brs0.battle_damage.team_effect_30 = ubti.team_effect_60;
            brs0.battle_damage.team_effect_60 = ubti.team_effect_60;
            brs0.battle_damage.true_time = ((float)(random.Next(48, 53) / 10)).ToString();
            brs0.build_sent_data();

        }



        public void setMapInfo()
        {
            Battle5_2N.mission_id = 90018;
            Battle5_2N.Mission_Start_spots[0].spot_id = 3033;//主力
            Battle5_2N.Mission_Start_spots[1].spot_id = 3057;//辅助
            Battle5_2N.setTeamMove(3033, 3038, 1);
            Battle5_2N.setTeamMove(3038, 3047, 1);
            Battle5_2N.setTeamMove(3047, 3038, 1);
            Battle5_2N.setTeamMove(3038, 3033, 1);
            Battle5_2N.withdrawSpot = 3033;
        }


    }

}
