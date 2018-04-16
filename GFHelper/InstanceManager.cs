using EyLogin;
using GFHelper.CatchData;
using GFHelper.UserData;
using GFHelper.Programe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFHelper.Programe.Auto;
using GFHelper.Programe.Auto.BattleLoop_Normal;

namespace GFHelper
{

    class InstanceManager
    {

        public MainWindow mainWindow;
        public UIHelp uihelp;
        public ACTION action;
        public POST post = new POST();
        public ConfigManager configManager;



        public EyLoginSoft eyLogin = new EyLoginSoft();
        public UserLogin userlogin;
        //data
        public Programe.TextRes.Asset_Textes asset_textes;//解析后勤 枪 日常任务等代码
        public CatchDataSummery catchdatasummery;
        public UserDataSummery userdatasummery;
        public Friend friend;

        //4个后勤任务
        public Dictionary<int, Operation_Act_Info> Dic_auto_operation_act = new Dictionary<int, Operation_Act_Info>();
        //程序任务队列如后勤练级
        public BattleReport BattleReport = new BattleReport();
        public List<EquipBuilt> list_equipBuilt=new List<EquipBuilt>(); 
        //练级任务
        public Dictionary<int, new_User_Normal_MissionInfo> dic_userbattletaskinfo = new Dictionary<int, new_User_Normal_MissionInfo>();


        public BackgroundThread backgroundthread;

        public Auto_Summery auto_summery;
        public BattleLoop battle_loop;

        public BattleLoop_Normal battleloop_n;
        public BattleLoop_Activity battleloop_a;
        public List<BattleTask_team_info> Teams = new List<BattleTask_team_info>();
        public InstanceManager(MainWindow mainWindow)
        {
            this.userlogin = new UserLogin(this);
            this.mainWindow = mainWindow;
            this.backgroundthread = new BackgroundThread(this);
            this.uihelp = new UIHelp(this);
            this.action = new ACTION(this);
            this.configManager = new ConfigManager(this);

            this.asset_textes = new Programe.TextRes.Asset_Textes(this);
            this.catchdatasummery = new CatchDataSummery(this);
            this.userdatasummery = new UserDataSummery(this);
            this.friend = new Friend(this);

            this.battleloop_n = new BattleLoop_Normal(this);
            this.battleloop_a = new BattleLoop_Activity(this);
            //4个后勤任务
            for (int x=0; x < 4;x++)
            {
                Operation_Act_Info auto_operation_act = new Operation_Act_Info();
                Dic_auto_operation_act.Add(Dic_auto_operation_act.Count, auto_operation_act);
            }
            //练级任务
            new_User_Normal_MissionInfo nunm = new new_User_Normal_MissionInfo(Teams, "", 0);
            dic_userbattletaskinfo.Add(dic_userbattletaskinfo.Count, nunm);

            for (int x = 0; x < 2; x++)
            {
                EquipBuilt eb = new EquipBuilt();
                this.list_equipBuilt.Add(eb);
            }

            this.auto_summery = new Auto_Summery(this);
            this.battle_loop = new BattleLoop(this);


        }
    }
}
