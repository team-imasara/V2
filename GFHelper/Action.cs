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
            im.uiHelper.setStatusBarText_InThread(String.Format(" 正在获取本机IP"));
            Models.SimpleInfo.client_ip = this.im.serverHelper.GetLocalAddress();

            im.uiHelper.setStatusBarText_InThread(String.Format(" 数字天空登陆中"));
            im.apioperation.LoginFirstUrl();

            DateTime time = DateTime.Now;
            im.uiHelper.setStatusBarText_InThread(String.Format(" 获取版本号"));
            im.apioperation.Index_version(time);

            im.uiHelper.setStatusBarText_InThread(String.Format(" 游戏登陆中"));
            im.apioperation.GetDigitalUid();

            //获取UserInfo
            im.uiHelper.setStatusBarText_InThread(String.Format(" 获取userinfo"));
            im.dataHelper.ReadUserInfo(im.apioperation.GetUserInfo());
            im.uiHelper.setUserInfo();
            im.autoOperation.SetTeamInfo();
            //加零点签到判断
            //加邮件判断
            //加后勤结束判断
            im.uiHelper.setStatusBarText_InThread(String.Format(" 查询是否有新邮件"));
            im.apioperation.ifNewMail();
            im.uiHelper.setStatusBarText_InThread(String.Format(" 获取左下角小广告"));
            im.apioperation.GetBannerEvent();
            im.uiHelper.setStatusBarText_InThread(String.Format(" 获取商店信息"));
            im.apioperation.GetMallStaticTables();
            im.uiHelper.setStatusBarText_InThread(String.Format(" 获取邮箱列表"));
            im.apioperation.GetMailList();
            im.uiHelper.setStatusBarText_InThread(String.Format(" 回复资源"));
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

        public string startOperation(int team_id, int operation_id, int mission_id)
        {
            string resurt = im.apioperation.StartOperation(team_id,operation_id, mission_id);

            if(resurt == "1")
            {
                return "执行后勤任务成功";
            }
            else
            {
                resurt = string.Format("出现未知错误 : {0}", resurt);
                return resurt;
            }



        }



    }
}
