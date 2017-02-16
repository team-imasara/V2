using EyLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper
{

    class InstanceManager
    {
        public Models.mcSystem mcsystem;
        public APIoperation apioperation;
        public ConfigManager configManager;
        public Listener listener;
        public UIHelper uiHelper;
        public ServerHelper serverHelper;

        public Timer timer;
        public CountDown countdown;

        public Data data;
        public DataHelper dataHelper;
        public MainWindow mainWindow;
        public AutoOperation autoOperation;
        public Models.AutoOperationInfo autoOperationInfo;
        public Logger logger;
        public UpdateManager updateManager;
        public DoPost.Login login;
        public EyLoginSoft eyLogin;
        public BaseAction baseAction;

        public InstanceManager(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            this.eyLogin = new EyLoginSoft();
            this.mcsystem = new Models.mcSystem(this);
            this.apioperation = new APIoperation(this);
            this.logger = new Logger(this);
            this.configManager = new ConfigManager(this);

            this.timer = new Timer(this);
            this.countdown = new CountDown(this);

            this.uiHelper = new UIHelper(this);
            this.serverHelper = new ServerHelper(this);

            this.data = new Data(this);
            this.dataHelper = new DataHelper(this);

            this.listener = new Listener(this);

            this.autoOperation = new AutoOperation(this);
            this.autoOperationInfo = new Models.AutoOperationInfo(this);

            this.updateManager = new UpdateManager(this);
            this.login = new DoPost.Login(this);
            this.baseAction = new BaseAction(this);
        }
    }
}
