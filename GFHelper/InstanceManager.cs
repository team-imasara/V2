using EyLogin;
using GFHelper.CatchData;
using GFHelper.UserData;
using GFHelper.Programe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GFHelper
{

    class InstanceManager
    {

        public MainWindow mainWindow;
        public UIHelp uihelp;
        public ACTION action;
        public POST post = new POST();
        public ConfigManager configManager;

        //data
        public Programe.TextRes.Asset_Textes asset_textes;//解析后勤 枪 日常任务等代码
        public CatchDataSummery catchdatasummery;
        public UserDataSummery userdatasummery;


        //4个后勤任务
        public Dictionary<int, Operation_Act_Info> Dic_auto_operation_act = new Dictionary<int, Operation_Act_Info>();
        //程序任务队列如后勤练级
        public List<TaskListInfo> TaskList;

        public BackgroundThread backgroundthread;

        public Programe.Auto.Auto_Summery auto_summery;

        public InstanceManager(MainWindow mainWindow)
        {

            this.mainWindow = mainWindow;
            this.backgroundthread = new BackgroundThread(this);
            this.uihelp = new UIHelp(this);
            this.action = new ACTION(this);
            this.configManager = new ConfigManager(this);

            this.asset_textes = new Programe.TextRes.Asset_Textes(this);
            this.catchdatasummery = new CatchDataSummery(this);
            this.userdatasummery = new UserDataSummery(this);


            //4个后勤任务
            for (int x=0; x < 4;x++)
            {
                Operation_Act_Info auto_operation_act = new Operation_Act_Info();
                Dic_auto_operation_act.Add(Dic_auto_operation_act.Count, auto_operation_act);
            }



            this.TaskList = new List<TaskListInfo>();

            this.auto_summery = new Programe.Auto.Auto_Summery(this);
        }
    }
}
