using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

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
            Get_Set_UserInfo();

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

            im.auto_summery.LoginSuccessful = true;//开始自动任务循环
            return true;
        }

        /// <summary>
        /// Mail只处理签到信息
        /// 可能会处理友情点 资源
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
                int x = 0;
                while (im.userdatasummery.maillist.Count > 0)
                {

                    int mailwith_user_id = im.userdatasummery.maillist[x].id;
                    im.uihelp.setStatusBarText_InThread(String.Format(" 开始接收邮件 邮件ID: {0} ,邮件剩余数量 : {1} 线程延迟2.5秒",im.userdatasummery.maillist[x].id,im.userdatasummery.maillist.Count));
                    im.post.GetOneMail_Type1(mailwith_user_id);
                    im.uihelp.setStatusBarText_InThread(String.Format(" 邮件ID: {0} 接收成功 ,邮件剩余数量 : {1} 线程延迟2.5秒", im.userdatasummery.maillist[x].id, im.userdatasummery.maillist.Count));
                    if (im.post.GetMailResource_Type1(mailwith_user_id) != "")
                    {

                        im.userdatasummery.maillist.Remove(x);
                        x++;
                    }


                }



                //while(im.userdatasummery.NeedDailyAttendance() != -1)//不等于-1表示需要签到并且返回mailwith_user_id type = 5是 签到
                //{
                //    int mailwith_user_id = im.userdatasummery.maillist[im.userdatasummery.NeedDailyAttendance()].id;
                //    im.post.GetOneMail_Type1(mailwith_user_id);
                //    if (im.post.GetMailResource_Type1(mailwith_user_id) == "[null]")
                //    {
                //        im.userdatasummery.maillist.Remove(im.userdatasummery.NeedDailyAttendance());
                //    }
                //}

                //if (im.userdatasummery.NeedDailyGift_Kalina() != -1)//不等于-1表示需要签到并且返回mailwith_user_id type =1 是格琳娜
                //{
                //    im.post.GetOneMail_Type2(im.userdatasummery.NeedDailyGift_Kalina());
                //    im.post.GetMailResource_Type2(im.userdatasummery.NeedDailyGift_Kalina());
                //}

            }


        }

        public void Get_Set_UserInfo()
        {
            string result = im.post.GetUserInfo();
            var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了
            im.userdatasummery.ReadUserData(jsonobj);
            im.uihelp.setUserInfo();
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


        public void Start_Loop_Operation_Act(UserData.Operation_Act_Info operation_act_info)
        {
            //检测后勤条件
            int team_leader_min_level, gun_min;
            team_leader_min_level=im.catchdatasummery.operation_info[operation_act_info.operation_id - 1].team_leader_min_level;
            gun_min=im.catchdatasummery.operation_info[operation_act_info.operation_id - 1].gun_min;

            bool Out = false;


            if (team_leader_min_level > im.userdatasummery.team_info[operation_act_info.team_id][1].gun_level)
            {
                Out = true;
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("梯队队长等级不符合后勤任务要求");
                });
            };

            if(gun_min> im.userdatasummery.team_info[operation_act_info.team_id].Count)
            {
                Out = true;
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("梯队人形总数不符合后勤任务要求");
                });
            }



            if (Out == true) return;
            //im.Dic_auto_operation_act[0]
            im.uihelp.setStatusBarText_InThread(String.Format(" 第 {0} 梯队后勤任务结束 ", operation_act_info.team_id));
            im.post.FinishOperation(operation_act_info.operation_id);
            im.uihelp.setStatusBarText_InThread(String.Format(" 第 {0} 梯队后勤任务开始 ", operation_act_info.team_id));
            im.post.StartOperation(operation_act_info.team_id, operation_act_info.operation_id);

        }

        public void Finish_Operation_Act(UserData.Operation_Act_Info operation_act_info)
        {
            im.uihelp.setStatusBarText_InThread(String.Format(" 第 {0} 梯队后勤任务结束 ", operation_act_info.team_id));
            im.post.FinishOperation(operation_act_info.operation_id);
        }

        public void Abort_Operation_Act(UserData.Operation_Act_Info operation_act_info)
        {
            im.uihelp.setStatusBarText_InThread(String.Format(" 第 {0} 梯队后勤任务终止 ", operation_act_info.team_id));
            im.post.AbortOperation(operation_act_info.operation_id);
        }

        public void Start_Operation_Act(UserData.Operation_Act_Info operation_act_info)
        {
            //检测后勤条件
            int team_leader_min_level, gun_min;
            team_leader_min_level = im.catchdatasummery.operation_info[operation_act_info.operation_id - 1].team_leader_min_level;
            gun_min = im.catchdatasummery.operation_info[operation_act_info.operation_id - 1].gun_min;

            bool Out = false;


            if (team_leader_min_level > im.userdatasummery.team_info[operation_act_info.team_id][1].gun_level)
            {
                Out = true;
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("梯队队长等级不符合后勤任务要求");
                });
            };

            if (gun_min > im.userdatasummery.team_info[operation_act_info.team_id].Count)
            {
                Out = true;
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("梯队人形总数不符合后勤任务要求");
                });
            }



            if (Out == true) return;
            //im.Dic_auto_operation_act[0]
            im.uihelp.setStatusBarText_InThread(String.Format(" 第 {0} 梯队后勤任务开始 ", operation_act_info.team_id));
            im.post.StartOperation(operation_act_info.team_id, operation_act_info.operation_id);
        }

        public void Click_Kalina()
        {

            //发送操作
            im.uihelp.setStatusBarText_InThread(String.Format(" 讨好氪金官 "));
            string result = im.post.Click_kalinaFavor();
            int k;
            Int32.TryParse(result, out k);
            if (k == 1)
            {
                im.uihelp.setStatusBarText_InThread(String.Format(" 氪金官好感度 + 1 "));

            }

        }

        public void Click_Get_material()
        {
            im.uihelp.setStatusBarText_InThread(String.Format(" 准备获取宿舍电池 "));




        }

        public void UI_Button_Start_Finish_Operation_Act(Button button, int x)
        {
            //combobox变动需要更新im.Dic_auto_operation_act
            //public static TaskListInfo Start_Operation_Act1 = new TaskListInfo("后勤任务 1 开始", 7);
            //public static TaskListInfo Start_Operation_Act2 = new TaskListInfo("后勤任务 2 开始", 8);
            //public static TaskListInfo Start_Operation_Act3 = new TaskListInfo("后勤任务 3 开始", 9);
            //public static TaskListInfo Start_Operation_Act4 = new TaskListInfo("后勤任务 4 开始", 10);

            if (button.Content.ToString() == "任务开始" || button.Content.ToString() == "后勤任务")
            {
                switch (x)
                {
                    case 0:
                        {
                            im.TaskList.Add(TaskList.Start_Operation_Act1);
                            im.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 1:
                        {
                            im.TaskList.Add(TaskList.Start_Operation_Act2);
                            im.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 2:
                        {
                            im.TaskList.Add(TaskList.Start_Operation_Act3);
                            im.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 3:
                        {
                            im.TaskList.Add(TaskList.Start_Operation_Act4);
                            im.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                }
            }



            if (button.Content.ToString() == "任务终止")
            {
                switch (x)
                {
                    case 0:
                        {
                            im.TaskList.Add(TaskList.Abort_Operation_Act1);
                            im.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 1:
                        {
                            im.TaskList.Add(TaskList.Abort_Operation_Act2);
                            im.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 2:
                        {
                            im.TaskList.Add(TaskList.Abort_Operation_Act3);
                            im.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 3:
                        {
                            im.TaskList.Add(TaskList.Abort_Operation_Act4);
                            im.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                }
            }


        }

        public void Receive_Favor_Girls_In_Dorm()
        {
            //编列梯队列表
            //梯队内人形can_click ==1 则发送post
            //根据result can_click +1;

            for(int x = 1; x <= im.userdatasummery.team_info.Count; x++)
            {
                if (im.userdatasummery.team_info[x].Count == 0) continue;
                for(int y = 1; y <= im.userdatasummery.team_info[x].Count; y++)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(im.userdatasummery.team_info[x][y].location.ToString())) ;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (im.userdatasummery.team_info[x][y].can_click == 1)
                    {
                        im.uihelp.setStatusBarText_InThread(String.Format(" 第 {0} 宿舍 少女 {1} 好感度提升 ",x+1, im.userdatasummery.team_info[x][y].gun_id));
                        int result = Convert.ToInt32(im.post.Receive_Favor_Girls_IN_Dorm(x, im.userdatasummery.team_info[x][y].id));
                        if (result > 0)
                        {
                            im.uihelp.setStatusBarText_InThread(String.Format(" 第 {0} 宿舍 少女 {1} 好感度提升 result = {2}", x + 1, im.userdatasummery.team_info[x][y].gun_id.ToString(), result.ToString()));
                            im.userdatasummery.team_info[x][y].can_click++;
                        }
                    }
                }
            }

        }

        public void Visit_Friend_Dorm_Info()
        {
            int BattaryNum = 10;


            while (im.userdatasummery.Dorm_Rest_Friend_Build_Coin_Count != 0)
            {
                int LoopTime = 1;
                foreach (var item in im.userdatasummery.friend_with_user_info)
                {
                    //循环遍历 获取每一个好友宿舍的电池,从十开始
                    //成功的话-1
                    //im.uihelp.setStatusBarText_InThread(String.Format(" 正在拜访好友 {0} 宿舍  当前可获取电池次数 {1}", item.Value.name.ToString(), im.userdatasummery.Dorm_Rest_Friend_Build_Coin_Count));
                    if (im.userdatasummery.Dorm_Rest_Friend_Build_Coin_Count == 0) continue;
                    int Friend_BattaryNum = im.post.Get_Friend_BattaryNum(item.Value.f_userid);
                    im.uihelp.setStatusBarText_InThread(String.Format(" 好友 {0} 宿舍  拥有电池数 {1} 意不意外 惊不惊喜", item.Value.name.ToString(), Friend_BattaryNum));

                    if (Friend_BattaryNum == BattaryNum)
                    {
                        im.post.Get_Friend_Battary(item.Value.f_userid, 0, Friend_BattaryNum);
                        im.userdatasummery.Dorm_Rest_Friend_Build_Coin_Count--;
                        Programe.ProgramePro.WriteLog.Log(String.Format(" 获取好友 {0} 宿舍的电池 数目: {1} ", item.Value.name.ToString(), Friend_BattaryNum));
                    }

                    if (LoopTime == im.userdatasummery.friend_with_user_info.Count) BattaryNum--;
                }
            }
        }

        public void Get_Friend_Dorm_Info(int v_user_id,int dorm_id)
        {



        }

        public void DeleteFile(string str)
        {
            DirectoryInfo path = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = path.GetFiles("*.*");
            //取得所有文件，然后判断文件名是否以"xxx-"开头
            for (int i = 0; i < files.Count(); i++)
            {
                if (files[i].Name == str+".json") continue;
                if (files[i].Name.Substring(0, 9) == str)
                    files[i].Delete();
            }
        }
        public void CheckCatchData()
        {
            //删除文件夹下的catchdata文件
            im.mainWindow.CheckT.IsEnabled = false;
            DeleteFile("catchdata");

            //检查catchdata版本
            ProgrameData.CatchDataVersion = im.post.Index_version();
            string catchdataAdd = AC.EncryptTool.GetCryptoFileName(ProgrameData.CatchDataVersion.ToString());
            string url = "http://rescnf.gf.ppgame.com/data/" + catchdataAdd;

            //下载
            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(new Uri(url), Path.GetFileName("catchdata.dat"));
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
            }


        }
        private void DownLoadNewCatchData(object sender, EventArgs e)
        {
            string abc = AC.EncryptTool.GetCryptoFileName("1098");
            string url = "http://rescnf.gf.ppgame.com/data/" + abc;


            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(new Uri(url), Path.GetFileName("catchdata.dat"));
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
            }
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            im.uihelp.setStatusBarText_InThread(string.Format("当前接收到{0}字节，文件大小总共{1}字节", e.BytesReceived, e.TotalBytesToReceive));
        }
        void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("文件下载被取消", "提示");
            }
            MessageBox.Show("catchdata文件下载成功", "提示");
            UnzipDataAndSave("catchdata.dat",ProgrameData.CatchDataVersion);

            DeleteFile("catchdata");
            im.catchdatasummery.ReadCatchData();
            im.mainWindow.Login.IsEnabled = true;

        }
        static void UnzipDataAndSave(string dataFilePath, int dataVersion, string saveFile = "catchdata.json")
        {
            byte[] buffer = new byte[0x400];
            StringBuilder builder = new StringBuilder();
            using (Stream stream = new FileStream(dataFilePath, FileMode.Open))
            {
                CryptoStream baseInputStream = new CryptoStream(stream, AC.EncryptTool.GetDecryptorServiceProvider(dataVersion), CryptoStreamMode.Read);
                using (Stream stream3 = new GZipStream(baseInputStream, CompressionMode.Decompress))
                {
                    //StreamReader reader = new StreamReader(stream3, Encoding.UTF8);
                    FileStream fs = new FileStream(saveFile, FileMode.OpenOrCreate);
                    stream3.CopyTo(fs);
                    fs.Close();
                    stream3.Close();
                }
                stream.Close();
            }
        }


    }
}
