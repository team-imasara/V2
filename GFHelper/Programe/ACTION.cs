﻿using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe
{
    class ACTION
    {
        private InstanceManager im;
        public ACTION(InstanceManager im)
        {
            this.im = im;
        }

        public bool AutoLogin()
        {
            im.uihelp.setStatusBarText_InThread(String.Format(" 正在获取本机IP"));
            ProgrameData.client_ip = im.post.GetLocalAddress();

            im.uihelp.setStatusBarText_InThread(String.Format(" 数字天空登陆中"));
            im.post.LoginFirstUrl();


            im.uihelp.setStatusBarText_InThread(String.Format(" 获取版本号"));
            im.post.Index_version();

            im.uihelp.setStatusBarText_InThread(String.Format(" 游戏登陆中"));
            im.post.GetDigitalUid();

            im.uihelp.setStatusBarText_InThread(String.Format(" 获取userinfo"));
            string result = im.post.GetUserInfo();
            var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了
            im.userdatasummery.ReadUserData(jsonobj);


            im.uihelp.setUserInfo();

            //int a = 0;
            //lock (im.user_operationInfoLocker)//锁
            //{
            //    im.dataHelper.ReadUserInfo(im.apioperation.GetUserInfo());
            //    //-----------------加后勤结束判断
            //    foreach (var item in im.data.user_operationInfo)
            //    {
            //        if (item.Value._LastTime == -1)
            //        {
            //            im.taskList.taskadd(Models.TaskListInfo.ReceiveLogistics);//
            //        }
            //    }
            //    if (a == 1)
            //    {
            //        im.taskList.taskadd(Models.TaskListInfo.StartLogisticsTask1);//getuserinfo
            //    }
            //    Models.SimpleInfo.LoginStartOperation = true;
            //}
            ////----------------如果有后勤结束则发包接收后勤

            //im.autoOperation.SetTeamInfo();

            //加零点签到判断
            //如果当前时间戳大于    "user_record":   "attendance_type1_time": 1487520000,则签到
            if (CommonHelp.ConvertDateTimeInt(DateTime.Now) > im.userdatasummery.user_record.attendance_type1_time)
            {
                im.uihelp.setStatusBarText_InThread(String.Format(" 开始签到"));
                im.post.attendance();
            }
            ////加零点签到判断
            ////加邮件判断
            ////加后勤结束判断

            im.uihelp.setStatusBarText_InThread(String.Format(" 获取左下角小广告"));
            im.post.GetBannerEvent();


            im.uihelp.setStatusBarText_InThread(String.Format(" 获取商店信息"));
            im.post.GetMallStaticTables();


            im.uihelp.setStatusBarText_InThread(String.Format(" 查询是否有新邮件"));
            Mail();




            im.uihelp.setStatusBarText_InThread(String.Format(" 回复资源"));
            im.post.RecoverResource();

            return true;
        }

        /// <summary>
        /// Mail只处理签到信息
        /// </summary>
        public void Mail()
        {
            im.uihelp.setStatusBarText_InThread(String.Format(" 查询是否有新邮件"));
            var jsonobj = DynamicJson.Parse(im.post.ifNewMail());

            if (jsonobj.if_new_mail == true)
            {
                //如果有 就发送
                im.userdatasummery.ReadMailList(im.post.GetMailList());
                //根据是否有邮件签到
                //type 5 可能是签到
                if(im.userdatasummery.NeedDailyAttendance() != -1)//不等于-1表示需要签到并且返回mailwith_user_id
                {
                    im.post.GetOneMail(im.userdatasummery.NeedDailyAttendance());
                    im.post.GetMailResource(im.userdatasummery.NeedDailyAttendance());
                }



            }


        }



        //public bool GetUserinfo()
        //{
        //    im.dataHelper.ReadUserInfo(im.apioperation.GetUserInfo());
        //    im.uiHelper.setUserInfo();
        //    im.autoOperation.SetTeamInfo();
        //    im.autoOperation.SetOperationInfo();
        //    return true;
        //}

        //public string autostartOperation()//通用版user_operationInfo里只要有就发送开始后勤post
        //{
        //    DateTime now = new DateTime();
        //    foreach (var item in im.data.user_operationInfo)
        //    {
        //        now = DateTime.Now;
        //        if (CommonHelper.ConvertDateTimeInt(now) > (item.Value.startTime + item.Value._durationTime))
        //        {
        //            string resurt = im.apioperation.StartOperation(item.Value._teamId, item.Value._operationId);

        //            if (resurt == "1")
        //            {
        //                lock (im.user_operationInfoLocker)//锁
        //                {
        //                    item.Value.reSet();
        //                    //int temp = CommonHelper.ConvertDateTimeInt(time);
        //                }


        //                return "1";
        //            }
        //            else
        //            {
        //                resurt = string.Format("出现未知错误 : {0}", resurt);
        //                return resurt;
        //            }

        //        }
        //        else
        //        {

        //        }

        //    }
        //    return "出现未知错误";
        //}

        //public string startOperation(int team_id, int operation_id)
        //{
        //    string resurt = im.apioperation.StartOperation(team_id, operation_id);

        //    if (resurt == "1")
        //    {
        //        return "1";
        //    }
        //    else
        //    {
        //        resurt = string.Format("出现未知错误 : {0}", resurt);
        //        return resurt;
        //    }
        //}

        //public string LoginfinishOperation()
        //{
        //    foreach (var item in im.data.user_operationInfo)
        //    {
        //        if (item.Value._LastTime < 0)
        //        {
        //            im.uiHelper.setStatusBarText_InThread(String.Format(" 开始接收后勤任务"));
        //            //api操作发包接收后勤
        //            string result = im.apioperation.FinishOperation(item.Value._operationId);
        //            //加后勤成功判断if()
        //            return "";
        //        }
        //        else
        //        {

        //        }
        //    }


        //    return "";
        //}

        //public string autofinishOperation()
        //{

        //    foreach (var item in im.data.user_operationInfo)
        //    {
        //        if (item.Value._LastTime == -1)
        //        {
        //            im.uiHelper.setStatusBarText_InThread(String.Format(" 开始接收后勤任务"));
        //            //api操作发包接收后勤
        //            //string result = im.apioperation.FinishOperation(item.Value._operationId);
        //            while (im.apioperation.FinishOperation(item.Value._operationId) == "")
        //            {

        //            }
        //            //加后勤成功判断if()
        //            return "";
        //        }

        //    }


        //    return "";
        //}
    }
}
