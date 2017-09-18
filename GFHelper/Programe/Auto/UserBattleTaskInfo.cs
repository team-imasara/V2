﻿using GFHelper.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe.Auto
{
    public class User_Normal_BattleTaskInfo
    {
        public int Key;//字典本事key键
        public int TaskMap;
        public int TaskMianTeam_ID;

        public int TaskSupportTeam1_ID;
        public string TaskSupportTeam2_ID;
        public string TaskSupportTeam3_ID;
        public string TaskSupportTeam4_ID;
        public string TaskSupportTeam5_ID;
        public string TaskSupportTeam6_ID;
        public string TaskSupportTeam7_ID;
        public string TaskSupportTeam8_ID;


        public int mvp;
        public int withdrawNUM //每次都要赋值
        {
            get
            {
                int i = 0;
                if (string.IsNullOrEmpty(withdrawPOS1.ToString()) == false && withdrawPOS1 != 0) i++;
                if (string.IsNullOrEmpty(withdrawPOS2.ToString()) == false && withdrawPOS2 != 0) i++;
                return i;
            }
        }
        public int withdrawPOS1;
        public int withdrawPOS2;
        public int withdrawgunid1
        {
            get
            {
                int id=0;
                foreach (var item in teaminfo)
                {
                    if (item.Value.position == withdrawPOS1)
                    {
                        id = item.Value.id;
                    }
                }
                return id;
            }
        }
        public int withdrawgunid2
        {
            get
            {
                int id = 0;
                foreach (var item in teaminfo)
                {
                    if (item.Value.position == withdrawPOS2)
                    {
                        id = item.Value.id;
                    }
                }
                return id;
            }
        }
        public int withdrawgunid5
        {
            get; set;
        }
        public int withdrawgunid3
        {
            get; set;
        }
        public int withdrawgunid4
        {
            get; set;
        }
        public int TeamEffect;
        public int Effect1=0;
        public int Effect2=0;
        public int Effect3=0;
        public int Effect4=0;
        public int Effect5;


        internal Dictionary<int, Gun_With_User_Info> teaminfo=new Dictionary<int, Gun_With_User_Info>();
        public int user_exp;
        private int _seed = 0;
        public int seed
        {
            get
            {
                _seed = 0;
                foreach (var item in teaminfo)
                {
                    _seed = _seed + item.Value.gun_exp + item.Value.life + item.Value.teamId;
                }
                _seed += user_exp;
                return _seed;
            }
        }




        public int BattleLoopTime = 0;
        public int BattleMaxLoopTime=0;



        public double reStart_WaitTime;//修复时间也是新的一轮所等的时间
        public bool TaskList_ADD = false;




        public bool BattleStart = false;//可以开始新的一轮或者等待修复
        public bool ChangeGunBattleTask;//换枪任务
        public int DismantlementGunCount = 24;//拆枪数量
        public int EquipmentUpdateCount = 24;
        public bool DismantleGunOrEquipment;//这个变量决定枪满装备满是否拆除或者停止脚本
        public int DismantleType;//=0表示拆的是枪，1是装备升级
        public bool NeetToDismantleGunOrEquipment = false;//是否需要拆枪
        public int EquipmentType;//升级装备所选贼装备的类型
        public int EquipmentUpdatePostion;
        public bool Used;//整个挂机任务是否使用
        public string TaskName;//地图名称如5-4E
        public int TaskNumber;
        public bool Team_Serror = false;
        public int Team_SerrorTime = 0;
        public int TaskType = 2;
        public bool ChoiceToFix;//总设定是否修复
        public bool NeedToFix;
        public bool ChoiceToSupply;
        public int FixType = 2;
        public int FixMaxTime;
        public int FixMintime;
        public int FixMaxPercentage = 0;
        public int FixMinPercentage = 0;
        public int RoundInterval;
        public int LoopMaxTime = -1;//循环最大次数达到这个数目则停止循环战斗 -1为无限次
        public bool BattleLoopUnLockWindows;
        public bool ChangeGun;
        public bool SetMap = false;
        public bool BattleSupport_plus = true;//是否拖尸 总开关
        public bool NeedSupport_plus = false;//当前拖尸是否要补给 小开关
        public List<int> BattleGunPostionMove = new List<int>();
        public int BattleSupportRound = 0;//回合数补给间隔
        public bool GunNeedWithDraw = false;//战斗中人形撤退
        public double GunWithDrawTimedelay = 0;//撤退延迟

        public void Build_info(int taskmap, int mtID,int stID,int mvp)
        {
            //地图
            this.TaskMap = taskmap;
            this.TaskMianTeam_ID = mtID;
            this.TaskSupportTeam1_ID = stID;
            this.mvp = mvp;
            
        }
    }

    public class User_Simulation_BattleTaskInfo
    {

        public int Type;// 1 初级 2 中级 3 高级
        public int mission_id1 = 1301;
        public int mission_id2 = 1302;
        public int mission_id3 = 1303;
        public double duration;
        public double L_duration1=0.7f;
        public double L_duration2=1.4f;
        public double L_duration3=2.87f;
        public int skill_cd;
        public int enemy_effect_client1= 2569;
        public int enemy_effect_client2 = 5069;
        public int enemy_effect_client3 = 10069;

        public void  setData(int type,double duration,int skill_cd)
        {
            this.Type = type;
            this.duration = duration;
            this.skill_cd = skill_cd;
        }

    }


}