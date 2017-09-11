using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe.Auto
{
    public class Spots
    {
        public Spots(int spot_id)
        {
            this.spot_id = spot_id;
        }
        public int spot_id
        {
            set;
            get;
        }
        public int team_id
        {
            set;
            get;
        }
        //public string jsonstring
        //{
        //    get
        //    {
        //        return string.Format("spot_id:{0},team_id:{1}", spot_id, team_id);
        //    }
        //}
    }
    public class Battle_Gun_Info
    {
        public int id{set; get;}
        public int life { set; get; }
    }
    public class user_rec
    {
        public int seed;
        public List<record> listRecord = new List<record>();
        //public user_rec(int seed, string[] record)
        //{
        //    this.seed = seed;
        //    foreach (var item in record)
        //    {
        //        this.record = item;
        //    }
        //}
        //"{\"seed\":11464086,\"record\":[\"81,41020270,1,0,False\",\"106,2547569,1,0,False\"]}"

    }
    public class record
    {
        public int fixedFrameId { set; get; }
        public int gunId { set; get; }
        public int type { set; get; }
        public int targetPosId { set; get; }
        public bool autoSkillSwitch { set; get; }
        public record(int fixedFrameId,int gunId,int type,int targetPosId,bool autoSkillSwitch)
        {
            this.fixedFrameId = fixedFrameId;
            this.gunId = gunId;
            this.type = type;
            this.targetPosId = targetPosId;
            this.autoSkillSwitch = autoSkillSwitch;

        }
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}", new object[]
            {
            this.fixedFrameId,
            this.gunId,
            (int)this.type,
            this.targetPosId,
            this.autoSkillSwitch
            });
        }
    }
    public class battle_damage
    {
        public int enemy_effect_client { set; get; }
        public int team_effect_60 { set; get; }
        public int team_effect_30 { set; get; }
        public double true_time { set; get;}
    }

    public class battle_time
    {
        public int enemy_effect_client { set; get; }
        public int team_effect_60 { set; get; }
        public int team_effect_30 { set; get; }
        public double true_time { set; get; }
    }


    public class TeamMove
    {
        public TeamMove(int from_spot_id,int to_spot_id,int move_type)
        {
            this.from_spot_id = from_spot_id;
            this.to_spot_id = to_spot_id;
            this.move_type = move_type;
        }
        //{"team_id":6,"from_spot_id":3033,"to_spot_id":3038,"move_type":1}
        public int team_id { set; get; }
        public int from_spot_id { set; get; }
        public int to_spot_id { set; get; }
        public int move_type { set; get; }
    }
    public class BattleMap
    {
        //public int mission_id;
        ////[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        //public Spots[] Mission_Start_spots = new Spots[9];//部署梯队的信息
        //public Dictionary<int, TeamMove> dic_TeamMove = new Dictionary<int, TeamMove>();//梯队移动的顺序
        //public int withdrawSpot;//撤离

        //public TeamMove teammove=new TeamMove();
        //public void setTeamMove(int from_spot_id,int to_spot_id,int move_type)
        //{
        //    this.teammove.from_spot_id = from_spot_id;
        //    this.teammove.to_spot_id = to_spot_id;
        //    this.teammove.move_type = move_type;
        //    this.dic_TeamMove.Add(dic_TeamMove.Count, teammove);
        //}
    }
    
    public class Battle_TASK_INFO
    {
        //public BattleMap Battle5_2N = new BattleMap();
        //public Battle_Result_Sent Ressult_5_2N_1 = new Battle_Result_Sent();
        //public Battle_Result_Sent Ressult_5_2N_2 = new Battle_Result_Sent();
        //public void setBattle_5_2N_1(User_Normal_BattleTaskInfo ubti)
        //{
        //    Random random = new Random();
        //    //Battle_Result_Sent brs0 = new Battle_Result_Sent();
        //    brs0.spot_id = Battle5_2N.dic_TeamMove[0].to_spot_id;
        //    brs0.if_enemy_die = true;
        //    brs0.boss_hp = 0;
        //    brs0.mvp = ubti.mvp;
        //    brs0.last_battle_info = "";

        //    brs0.gun = ubti.gun;
        //    brs0.user_rec.seed = ubti.seed;

        //    int r1 = random.Next(50, 60);
        //    brs0.user_rec.record[0] = string.Format("{0},{1},{2},{3},{4},{5}", r1, ubti.withdrawgunid1, 1, 0, false.ToString());
        //    brs0.user_rec.record[1] = string.Format("{0},{1},{2},{3},{4},{5}", r1 + random.Next(13, 20), ubti.withdrawgunid2, 1, 0, false.ToString());

        //    brs0.battle_damage.enemy_effect_client = 11830;
        //    brs0.battle_damage.team_effect_30 = ubti.team_effect_60;
        //    brs0.battle_damage.team_effect_60 = ubti.team_effect_60;
        //    brs0.battle_damage.true_time = ((float)(random.Next(35, 40) / 10)).ToString();
        //    brs0.build_sent_data();
        //}






    }

}
