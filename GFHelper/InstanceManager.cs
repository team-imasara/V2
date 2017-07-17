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

        public EyLoginSoft eyLogin;
        public MainWindow mainWindow;
        public UIHelp uihelp;
        public ACTION action;
        public POST post = new POST();
        public ConfigManager configManager;

        //data
        public CatchDataSummery catchdatasummery;
        public UserDataSummery userdatasummery;

        //程序任务队列如后勤练级
        public List<TaskListInfo> TaskList;

        public BackgroundThread backgroundthread;

        public InstanceManager(MainWindow mainWindow)
        {
            this.eyLogin = new EyLoginSoft();
            this.mainWindow = mainWindow;
            this.backgroundthread = new BackgroundThread(this);
            this.uihelp = new UIHelp(this);
            this.action = new ACTION(this);
            this.configManager = new ConfigManager(this);

            this.catchdatasummery = new CatchDataSummery(this);
            this.userdatasummery = new UserDataSummery(this);





            this.TaskList = new List<TaskListInfo>();

    }
    }
}
