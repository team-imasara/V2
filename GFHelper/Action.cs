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
            //如果当前时间戳大于    "user_record":   "attendance_type1_time": 1487520000,则签到
            if (CommonHelper.ConvertDateTimeInt(time)> im.data.userInfo.attendance_type1_time)
            {
                im.uiHelper.setStatusBarText_InThread(String.Format(" 开始签到"));
                im.apioperation.attendance();
            }

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


            //-----------------加后勤结束判断
            int a = 0;
            foreach (var item in im.data.user_operationInfo)
            {

                if (item.Value._LastTime == -1)
                {
                    a = 1;
                    im.data.tasklistadd(7);
                }
                else
                {

                }
            }
            if (a==1)
            im.data.tasklistadd(2);//getuserinfo
            //----------------如果有后勤结束则发包接收后勤





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

        public string _startOperation()//通用版user_operationInfo里只要有就发送开始后勤post
        {
            foreach (var item in im.data.user_operationInfo)
            {
                if (item.Value._LastTime == -1)
                {
                    string resurt = im.apioperation.StartOperation(item.Value._teamId, item.Value._operationId, item.Value.MissionId);

                    if (resurt == "1")
                    {
                        return "1";
                    }
                    else
                    {
                        resurt = string.Format("出现未知错误 : {0}", resurt);
                        return resurt;
                    }

                }
                else
                {

                }

            }
            return "出现未知错误";
        }

        public string startOperation(int team_id, int operation_id, int mission_id)
        {
            string resurt = im.apioperation.StartOperation(team_id, operation_id, mission_id);

            if (resurt == "1")
            {
                return "1";
            }
            else
            {
                resurt = string.Format("出现未知错误 : {0}", resurt);
                return resurt;
            }
        }
        public string finishOperation()
        {
            foreach (var item in im.data.user_operationInfo)
            {
                if (item.Value._LastTime < 0)
                {
                    //api操作发包接收后勤
                    string result = im.apioperation.FinishOperation(item.Value._operationId);
                    //加后勤成功判断if()
                    im.data.tasklistremove();
                    im.data.tasklistadd(2);


                    return "";
                }
                else
                {

                }
            }


            return "";
        }
    }
}
