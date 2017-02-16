using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper
{
    class BaseAction
    {
        private InstanceManager im;
        public BaseAction(InstanceManager im)
        {
            this.im = im;
        }

        public bool AutoLogin()
        {

            Models.SimpleInfo.client_ip = this.im.serverHelper.GetLocalAddress();
            im.apioperation.LoginFirstUrl();

            DateTime time = DateTime.Now;
            im.apioperation.Index_version(time);

            im.apioperation.GetDigitalUid();

            //获取UserInfo
            im.dataHelper.ReadUserInfo(im.apioperation.GetUserInfo());
            im.uiHelper.setUserInfo();
            im.autoOperation.SetTeamInfo();
            //加零点签到判断
            //加邮件判断
            //加后勤结束判断
            im.apioperation.ifNewMail();
            im.apioperation.GetBannerEvent();
            im.apioperation.GetMallStaticTables();
            im.apioperation.GetMailList();
            im.apioperation.RecoverResource();
            //加后勤结束判断
            //如果有后勤结束则发包接收后勤
            foreach (var item in Data.operationInfo)
            {
                //im.mainWindow.Dispatcher.Invoke(() =>
                //{
                //    AutoOperationInfo ao = new AutoOperationInfo(Convert.ToInt32(item.team_id), Convert.ToInt32(item.operation_id));
                //    ao.LastTime = Convert.ToInt32(item.start_time) + ao.LastTime - CommonHelper.ConvertDateTimeInt(DateTime.Now, true);
                //    im.autoOperation.AddTimerStartOperation(ao);
                //});
                //Models.AutoOperationInfo ao = new Models.AutoOperationInfo(Convert.ToInt32(item.team_id), Convert.ToInt32(item.operation_id));



            }




            return true;
        }

        public bool GetUserinfo()
        {
            im.dataHelper.ReadUserInfo(im.apioperation.GetUserInfo());
            im.uiHelper.setUserInfo();
            im.autoOperation.SetTeamInfo();
            im.autoOperation.SetOperationInfo();
            return true;
        }

    }
}
