using Codeplex.Data;
using GFHelper.Programe.Auto;
using GFHelper.Programe.ProgramePro;
using GFHelper.UserData;
using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
            ProgrameData.client_ip = im.post.GetLocalAddress();//done

            im.uihelp.setStatusBarText_InThread(String.Format(" 数字天空登陆中"));
            im.post.LoginFirstUrl();


            im.uihelp.setStatusBarText_InThread(String.Format(" 获取版本号"));
            im.post.Index_version();

            im.uihelp.setStatusBarText_InThread(String.Format(" 游戏登陆中"));
            GetDigitalUid();

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
            //            ProgrameData.TaskList.taskadd(Models.TaskListInfo.ReceiveLogistics);//
            //        }
            //    }
            //    if (a == 1)
            //    {
            //        ProgrameData.TaskList.taskadd(Models.TaskListInfo.StartLogisticsTask1);//getuserinfo
            //    }
            //    Models.SimpleInfo.LoginStartOperation = true;
            //}
            ////----------------如果有后勤结束则发包接收后勤

            //im.autoOperation.SetTeamInfo();

            //加零点签到判断
            //如果当前时间戳大于    "user_record":   "attendance_type1_time": 1487520000,则签到
            if (CommonHelp.ConvertDateTime_China_Int(DateTime.Now) > im.userdatasummery.user_record.attendance_type1_time)
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
            string result;
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
                    result = im.post.GetOneMail_Type1(mailwith_user_id);
                    result = ProgramePro.ResultPro.Get_Mail_Content(result);
                    ProgramePro.WriteLog.Log(string.Format("邮件记录 : {0}", result));
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

        public bool GetDigitalUid()
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("openid", ProgrameData.openid);
            parameters.Add("access_token", ProgrameData.access_token);
            parameters.Add("app_id", "0002000100021001");
            parameters.Add("channelid", ProgrameData.channelid);
            parameters.Add("idfa", "");
            parameters.Add("androidid", ProgrameData.androidid);
            parameters.Add("mac", ProgrameData.mac);
            parameters.Add("req_id", ProgrameData.req_id++.ToString());

            string data =Programe.POST.StringBuilder_(parameters);

            string result = "";
            while (true)
            {
                result = im.post.GetDigitalUid(data);

                switch (ResultPro.Result_Pro(ref result, "GetDigitalUid_Pro", false))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            return false;
                        }
                    default:
                        break;
                }
            }
        }

        public void Get_Set_UserInfo()
        {
            string result = im.post.GetUserInfo();
            var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了
            im.userdatasummery.ReadUserData(jsonobj);
            im.uihelp.setUserInfo();
        }

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

            if (im.post.FinishOperation(operation_act_info.operation_id) == false)
            {
                //错误处理

            }

            im.uihelp.setStatusBarText_InThread(String.Format(" 第 {0} 梯队后勤任务开始 ", operation_act_info.team_id));

            if(im.post.StartOperation(operation_act_info.team_id, operation_act_info.operation_id) == false)
            {
                //错误返回处理
            }
            else
            {
                //正确返回处理 更改时间
                im.Dic_auto_operation_act[operation_act_info.key].start_time = CommonHelp.ConvertDateTime_China_Int(DateTime.Now);
            }

        }

        public void Finish_Operation_Act(Operation_Act_Info operation_act_info)
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
                            ProgrameData.TaskList.Add(TaskList.Start_Operation_Act1);
                            ProgrameData.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 1:
                        {
                            ProgrameData.TaskList.Add(TaskList.Start_Operation_Act2);
                            ProgrameData.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 2:
                        {
                            ProgrameData.TaskList.Add(TaskList.Start_Operation_Act3);
                            ProgrameData.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 3:
                        {
                            ProgrameData.TaskList.Add(TaskList.Start_Operation_Act4);
                            ProgrameData.TaskList.Add(TaskList.GetuserInfo);
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
                            ProgrameData.TaskList.Add(TaskList.Abort_Operation_Act1);
                            ProgrameData.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 1:
                        {
                            ProgrameData.TaskList.Add(TaskList.Abort_Operation_Act2);
                            ProgrameData.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 2:
                        {
                            ProgrameData.TaskList.Add(TaskList.Abort_Operation_Act3);
                            ProgrameData.TaskList.Add(TaskList.GetuserInfo);
                            break;
                        }
                    case 3:
                        {
                            ProgrameData.TaskList.Add(TaskList.Abort_Operation_Act4);
                            ProgrameData.TaskList.Add(TaskList.GetuserInfo);
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
                        if (string.IsNullOrEmpty(im.userdatasummery.team_info[x][y].location.ToString())) continue;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (im.userdatasummery.team_info[x][y].can_click == 1)
                    {
                        im.uihelp.setStatusBarText_InThread(String.Format(" 第 {0} 宿舍 少女 {1} 好感度提升 ",x, im.userdatasummery.team_info[x][y].gun_id));
                        int result = Convert.ToInt32(im.post.Receive_Favor_Girls_IN_Dorm(x, im.userdatasummery.team_info[x][y].id));
                        if (result > 0)
                        {
                            im.uihelp.setStatusBarText_InThread(String.Format(" 第 {0} 宿舍 少女 {1} 好感度提升 result = {2}", x, im.userdatasummery.team_info[x][y].gun_id.ToString(), result.ToString()));
                            im.userdatasummery.team_info[x][y].can_click++;
                        }
                    }
                }
            }

        }

        public void LogFriend_Dorm_info()
        {
            if (ProgrameData.friendUID == false) return;
            foreach (var item in im.userdatasummery.friend_with_user_info)
            {
                im.uihelp.setStatusBarText_InThread(String.Format(" 正在查询好友 {0} 宿舍电池数目", item.Value.name.ToString()));

                int Friend_BattaryNum = im.post.Get_Friend_BattaryNum(item.Value.f_userid);
                if(Friend_BattaryNum==10)
                WriteLog.Log(String.Format(" 10电池好友UID =  {0}", item.Value.f_userid.ToString()));
            }
        }

        public void Visit_Friend_Dorm_Info()
        {
            int BattaryNum = 10;

            LogFriend_Dorm_info();
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
                    if (item.Key == im.userdatasummery.friend_with_user_info.Last().Key) return;

                }
            }
        }

        public void Auto_Start_Simulation_Data()
        {
            if (ProgrameData.AutoSimulationBattleF == false) return;
            im.uihelp.setStatusBarText_InThread(String.Format(" 开始资料采样"));
            im.battle_loop.Simulation_DATA(im.userdatasummery.usbti);
        }

        public bool Auto_Start_Trial()
        {
            //开始模拟作战无线防御
            //uid 
            //outdatacode = {"team_ids":"7","battle_team":7}
            //req_id
            //url = Mission/startTrial
            if (ProgrameData.AutoSimulationBattleF == false) return true;


            im.uihelp.setStatusBarText_InThread(String.Format(" BP点数 高于5 开始无限防御模式"));

            int count = 0;
            while (true)
            {
                string result = im.post.StartTrial(ProgrameData.AutoDefenseTrialBattleT.ToString());

                switch (ResultPro.Result_Pro(ref result, "StartTrial_Pro", true))
                {
                    case 1:
                        {
                            goto a;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }

            }

            a: im.uihelp.setStatusBarText_InThread(String.Format(" 结束防御模式"));
            Thread.Sleep(5000);

            //序列化
            Random random = new Random();



            TrialExercise_Battle_Sent tbs = new TrialExercise_Battle_Sent(im.userdatasummery.team_info[ProgrameData.AutoDefenseTrialBattleT]);

            string outdatacode = tbs.BattleResult;




            count = 0;
            while (true)
            {
                string result = im.post.EndTrial(outdatacode);

                switch (ResultPro.Result_Pro(ref result, "EndTrial_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }
            }
        }

        public bool GetRecoverBP()
        {
            im.uihelp.setStatusBarText_InThread(String.Format(" 动能点数恢复"));
            int count = 0;
            while (true)
            {
                string result = im.post.GetRecoverBP();

                switch (ResultPro.Result_Pro(ref result, "Get_RecoverBP_Pro", true))
                {
                    case 1:
                        {
                            var jsonobj = DynamicJson.Parse(result);
                            im.userdatasummery.Read_BP_Info(jsonobj);
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }

            }
        }

        public bool Get_Build_Coin()
        {
            try
            {
                if (im.userdatasummery.dorm_with_user_info.current_build_coin <= 0) return true;
                //开始获得
                im.userdatasummery.dorm_with_user_info.current_build_coin = 0;
                int count = 0;
                while (true)
                {
                    string result = im.post.Get_Build_Coin(im.userdatasummery.dorm_with_user_info.info.user_id, im.userdatasummery.dorm_with_user_info.info.dorm_id);

                    switch (ResultPro.Result_Pro(ref result, "Get_Friend_Build_Coin_Pro", true))
                    {
                        case 1:
                            {

                                return true;
                            }
                        case 0:
                            {
                                result_error_PRO(result, count++); continue;
                            }
                        case -1:
                            {
                                result_error_PRO(result, count++); break;
                            }
                        default:
                            break;
                    }

                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Get_Dorm_Info()
        {
            try
            {
                int count = 0;
                while (true)
                {
                    string result = im.post.GetFriend_DormInfo();

                    switch (ResultPro.Result_Pro(ref result, "GetFriend_DormInfo_Pro", true))
                    {
                        case 1:
                            {
                                var jsonobj = DynamicJson.Parse(result);
                                im.userdatasummery.ReadDormData(jsonobj);
                                return true;
                            }
                        case 0:
                            {
                                result_error_PRO(result, count++); continue;
                            }
                        case -1:
                            {
                                result_error_PRO(result, count++); break;
                            }
                        default:
                            break;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取要扩编的人形字典
        /// </summary>
        public void Get_dicGun_Combine()
        {
            UserDataSummery.dicGun_Combine.Clear();

            foreach (var item in im.userdatasummery.gun_with_user_info)
            {
                //2扩
                if(item.Value.level>=10 && item.Value.level < 30)
                {
                    if (item.Value.number < 2) UserDataSummery.dicGun_Combine.Add(UserDataSummery.dicGun_Combine.Count, item.Value);
                }
                //3扩
                if (item.Value.level >= 30 && item.Value.level < 70)
                {
                    if (item.Value.number < 3) UserDataSummery.dicGun_Combine.Add(UserDataSummery.dicGun_Combine.Count, item.Value);
                }
                //4扩
                if (item.Value.level >= 70 && item.Value.level < 90)
                {
                    if (item.Value.number < 4) UserDataSummery.dicGun_Combine.Add(UserDataSummery.dicGun_Combine.Count, item.Value);
                }
                //5扩
                if (item.Value.level >= 90 && item.Value.level <= 100)
                {
                    if (item.Value.number < 5) UserDataSummery.dicGun_Combine.Add(UserDataSummery.dicGun_Combine.Count, item.Value);
                }
            }
        }


        /// <summary>
        /// 进行扩编
        /// </summary>
        public void CombineGun()
        {
            im.uihelp.setStatusBarText_InThread(String.Format(" 准备扩编"));
            int count = 0;
            Get_dicGun_Combine();
            if (UserDataSummery.dicGun_Combine.Count == 0) return;

            if (im.userdatasummery.user_info.core < UserDataSummery.dicGun_Combine[0].Core_COMbineNeed) return;
            Thread.Sleep(2000);
            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("gun_with_user_id");
            jsonWriter.Write(UserDataSummery.dicGun_Combine[0].id);
            jsonWriter.WritePropertyName("combine");
            jsonWriter.WriteArrayStart();
            jsonWriter.WriteArrayEnd();
            jsonWriter.WriteObjectEnd();



            while (true)
            {
                string result = im.post.combineGun(sb.ToString());


                switch (ResultPro.Result_Pro(ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            im.userdatasummery.user_info.core -= UserDataSummery.dicGun_Combine[0].Core_COMbineNeed;
                            UserDataSummery.dicGun_Combine[0].number++;
                            return;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }

            }




        }



        /// <summary>
        /// 获取当前需要强化的人形
        /// </summary>
        /// <returns></returns>
        public void Get_dicGun_PowerUP()
        {
            UserDataSummery.dicGun_PowerUP.Clear();
            int i = 0;
            foreach (var item in im.userdatasummery.gun_with_user_info)
            {
                if (item.Value.maxAddDodge > item.Value.additionDodge && item.Value.maxAddHit > item.Value.additionHit && item.Value.maxAddPow > item.Value.additionPow && item.Value.maxAddRate > item.Value.additionRate)
                {
                    UserDataSummery.dicGun_PowerUP.Add(i++, item.Value);
                    //MessageBox.Show(string.Format("Gun_name = {0}", Programe.TextRes.Asset_Textes.ChangeCodeFromeCSV(im.userdatasummery.FindGunName_GunId(item.Value.gun_id))));
                }
            }
        }

        public bool Gun_PowerUP(int id,ref string result)
        {

            Thread.Sleep(2000);
            if (im.userdatasummery.Get_Gun_Retire()==false) MessageBox.Show("没有2级枪");
            //Gun_Retire
            int count = 0;

            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("gun_with_user_id");
            jsonWriter.Write(id);
            jsonWriter.WritePropertyName("item9_num");
            jsonWriter.Write(0);
            jsonWriter.WritePropertyName("food");
            jsonWriter.WriteArrayStart();

            foreach (var item in UserDataSummery.Gun_Retire_Rank2)
            {
                jsonWriter.Write(item);
            }
            jsonWriter.WriteArrayEnd();
            jsonWriter.WriteObjectEnd();

            while (true)
            {
                result = im.post.EatGun(sb.ToString());


                switch (ResultPro.Result_Pro(ref result, "EatGun", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }

            }
        }

        public bool EatGunHandle()
        {
            Thread.Sleep(2000);
            im.uihelp.setStatusBarText_InThread(String.Format(" 准备人形强化"));
            string result = "";
            Get_dicGun_PowerUP();
            im.userdatasummery.Get_Gun_Retire();

            if (UserDataSummery.dicGun_PowerUP.Count == 0) return false;

            for (int i = 0; i <= UserDataSummery.dicGun_PowerUP.Last().Key; i++)
            {
                if (UserDataSummery.dicGun_PowerUP.ContainsKey(i) == false) continue;
                if (Gun_PowerUP(UserDataSummery.dicGun_PowerUP[i].id, ref result))
                {
                    im.userdatasummery.Del_Gun_IN_Dict(2);
                }

                JsonData jsonData = new JsonData();
                try
                {
                    jsonData = JsonMapper.ToObject(result);
                }
                catch (Exception e)
                {
                    MessageBox.Show("EatGunHandle_error");
                    MessageBox.Show(string.Format("result = {0}", result));
                    MessageBox.Show(e.ToString());
                }

                int additionPow = Convert.ToInt32((int)jsonData["pow"]);
                int additionHit = Convert.ToInt32((int)jsonData["hit"]);
                int additionDodge = Convert.ToInt32((int)jsonData["dodge"]);
                int additionRate = Convert.ToInt32((int)jsonData["rate"]);

                UserDataSummery.dicGun_PowerUP[i].additionPow = additionPow;
                UserDataSummery.dicGun_PowerUP[i].additionHit = additionHit;
                UserDataSummery.dicGun_PowerUP[i].additionDodge = additionDodge;
                UserDataSummery.dicGun_PowerUP[i].additionRate = additionRate;
                UserDataSummery.dicGun_PowerUP[i].UpdateData();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 枪支拆解 参数type是拆解的星
        /// </summary>
        /// <param name="type"> 传入2是只拆2星，传入3是只拆3星</param>
        /// <returns></returns>
        public bool Gun_retire(int type)
        {

            //if (im.userdatasummery.Check_Equip_GUN_FULL()==false) return false;
            //if (im.userdatasummery.Get_Gun_Retire() == false) return false;

            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);
            jsonWriter.WriteArrayStart();
            switch (type)
            {
                case 2:
                    {
                        im.uihelp.setStatusBarText_InThread(String.Format(" 拆解2星人形"));
                        foreach (var item in UserDataSummery.Gun_Retire_Rank2)
                        {
                            jsonWriter.Write(item);
                        }
                        break;
                    }
                case 3:
                    {
                        im.uihelp.setStatusBarText_InThread(String.Format(" 拆解3星人形"));
                        foreach (var item in UserDataSummery.Gun_Retire_Rank3)
                        {
                            jsonWriter.Write(item);
                        }
                        break;
                    }
                default:
                    break;
            }

            jsonWriter.WriteArrayEnd();
            Thread.Sleep(2000);
            int count = 0;
            while (true)
            {
                string result =  im.post.Retire_Gun(sb.ToString());

                switch (ResultPro.Result_Pro(ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            im.userdatasummery.Del_Gun_IN_Dict(type); return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }
            }
        }

        public bool Eat_Equip()
        {
            //SELECT+1
            //选取需要升级的枪 done
            //选取狗粮 优先2级 done
            //发送请求         done
            //删除装备         done
            //经验++           done
            Thread.Sleep(2000);
            im.uihelp.setStatusBarText_InThread(String.Format(" 准备装备升级"));
            if (im.userdatasummery.equip_with_user_info.Count < im.userdatasummery.user_info.maxequip)
            {
                return true;
            }

            im.userdatasummery.Read_Equipment_Upgrade();

            string[] equipFood = new string[11];
            equipFood = im.userdatasummery.Get_Equipment_Food();


            //判断是否为空
            if (string.IsNullOrEmpty(equipFood.ToString())) return false;
            var obj = new
            {
                equip_with_user_id = im.userdatasummery.equip_with_user_info_Upgrade[0].id.ToString(),
                food = equipFood
            };

            var jsonStringFromObj = DynamicJson.Serialize(obj);

            //发送请求
            //数据处理
            int count = 0;
            while (true)
            {
                string result = im.post.Eat_Equip(jsonStringFromObj.ToString());


                switch (ResultPro.Result_Pro(ref result, "Eat_Equip_Pro", true))
                {
                    case 1:
                        {
                            var jsonobj = DynamicJson.Parse(result);
                            result = jsonobj.equip_add_exp.ToString();
                            //加经验 检测是否 超过等级
                            im.userdatasummery.Check_Equipment_Update(im.userdatasummery.equip_with_user_info_Upgrade[0].id, Convert.ToInt32(result));
                            //删除装备
                            im.userdatasummery.Del_Equip_IN_Dict(equipFood);
                            im.userdatasummery.Read_Equipment_Rank();
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }

            }
        }

        //战斗相关
        public bool startMission(int mission_id,Auto.Spots[] spots)
        {
            Thread.Sleep(8000);
            int count = 0;
            dynamic newjson = new DynamicJson();
            newjson.mission_id /*这是节点*/ = mission_id;/* 这是值*/
            newjson.spots = spots ;

            while (true)
            {
                string result = im.post.startMission(newjson.ToString());

                switch (ResultPro.Result_Pro(ref result, "Start_Mission_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    default:
                        break;
                }
            }
        }

        public bool reinforceTeam(Auto.Spots spots)
        {
            //{"spot_id":1948,"team_id":7}
            Thread.Sleep(2000);
            int count = 0;
            dynamic newjson = new DynamicJson();
            newjson.spot_id /*这是节点*/ = spots.spot_id;/* 这是值*/
            newjson.team_id = spots.team_id;

            while (true)
            {
                string result = im.post.reinforceTeam(newjson.ToString());


                switch (ResultPro.Result_Pro(ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }
            }
        }

        public bool teamMove(Auto.TeamMove teammove)
        {
            //{"team_id":6,"from_spot_id":3033,"to_spot_id":3038,"move_type":1}
            Thread.Sleep(2000);
            dynamic newjson = new DynamicJson();
            newjson.team_id /*这是节点*/ = teammove.team_id;/* 这是值*/
            newjson.from_spot_id /*这是节点*/ = teammove.from_spot_id;/* 这是值*/
            newjson.to_spot_id /*这是节点*/ = teammove.to_spot_id;/* 这是值*/
            newjson.move_type /*这是节点*/ = teammove.move_type;/* 这是值*/

            int count = 0;
            //发送请求
            while (true)
            {
                string result = im.post.teamMove(newjson.ToString());

                switch (ResultPro.Result_Pro(ref result, "Team_Move_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }

            }
        }

        public bool Normal_battleFinish(string data,ref string result)
        {
            //WriteLog.Log(String.Format("data = {0}", data));
            Thread.Sleep(5000);
            int count = 0;
            while (true)
            {
                result = im.post.battleFinish(data);

                switch (ResultPro.Result_Pro(ref result, "Battle_Finish_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            if (count == 3) { return false; }
                            result_error_PRO(result, count++); break;

                        }
                    default:
                        break;
                }


            }
        }
        public bool withdrawTeam(int spot_id)
        {
            Thread.Sleep(2000);
            //{"spot_id":3033}
            var obj = new
            {
                spot_id = spot_id,
            };
            int count = 0;
            var jsonStringFromObj = DynamicJson.Serialize(obj);
            while (true)
            {
                string result = im.post.withdrawTeam(jsonStringFromObj.ToString());

                switch (ResultPro.Result_Pro(ref result, "WithDraw_Team_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }

            }
        }

        public bool endTurn()
        {
            Thread.Sleep(2000);
            int count = 0;

            while (true)
            {
                string result = im.post.endTurn();

                switch (ResultPro.Result_Pro(ref result, "endTurn", true))
                {
                    case 1:
                        {
                            if (result.Contains("gun_with_user_id"))
                            {
                                var jsonobj = DynamicJson.Parse(result);
                                Gun_With_User_Info gwui = new Gun_With_User_Info(im);
                                gwui.id = Convert.ToInt32(jsonobj.mission_win_result.reward_gun.gun_with_user_id);
                                gwui.gun_id = Convert.ToInt32(jsonobj.mission_win_result.reward_gun.gun_id);
                                int i = 0;
                                while (true)
                                {
                                    if (!im.userdatasummery.gun_with_user_info.ContainsKey(i))
                                    {
                                        im.userdatasummery.gun_with_user_info.Add(i, gwui);
                                        break;
                                    }
                                    i++;
                                }
                            }
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }
            }
        }
        public bool startTurn()
        {
            Thread.Sleep(2000);
            int count = 0;

            while (true)
            {
                string result = im.post.startTurn();

                switch (ResultPro.Result_Pro(ref result, "startTurn", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }


            }
        }


        public bool Simulation_battleFinish(string data, ref string result)
        {
            Thread.Sleep(2000);
            int count = 0;
            while (true)
            {
                result = im.post.simulation_DATA(data);

                switch (ResultPro.Result_Pro(ref result, "Simulation_DATA_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }

            }
        }


        public bool SupplyTeam(int team_id)
        {
            dynamic newjson = new DynamicJson();
            newjson.team_id /*这是节点*/ = team_id;/* 这是值*/
            int count = 0;
            while (true)
            {
                string result = im.post.SupplyTeam(newjson.ToString());
                Thread.Sleep(2000);

                switch (ResultPro.Result_Pro(ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }

            }
        }


        public bool abortMission()
        {
            //caa6f92d234e04c034f88c9eb445fd45(sign)
            int count = 0;
            while (true)
            {
                string result = im.post.abortMission();
                Thread.Sleep(2000);

                switch (ResultPro.Result_Pro(ref result, "Abort_Mission_Pro", true))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); break;
                        }
                    default:
                        break;
                }
            }
        }

        public static void result_error_PRO(string result,int count)
        {
            //第二次post 返回error:2可能是服务器已经接受但是没有返回成功 可以尝试继续
            WriteLog.Log(result);
            if (ProgrameData.show_result_error)
            {
                MessageBox.Show(result);
            }
            //if (ProgrameData.Error_Num_Stop == count)
            //{
            //    MessageBox.Show("错误次数达到上限");
            //    //错误次数达到上线
            //}
        }


        public bool GUN_OUT_Team(int mvp_id,Dictionary<int,Gun_With_User_Info> teaminfo)
        {
            //{"team_id":6,"gun_with_user_id":0,"location":4}
            GUN_OUT_Team: int count = 0;
            int Gun_count = 0;
            foreach (var item in teaminfo)
            {
                if(item.Value.id != mvp_id)
                {
                    dynamic newjson = new DynamicJson();
                    newjson.team_id /*这是节点*/ = item.Value.team_id;/* 这是值*/
                    newjson.gun_with_user_id /*这是节点*/ = 0;/* 这是值*/
                    newjson.location /*这是节点*/ = item.Value.location;/* 这是值*/

                    bool loop = true;
                    while (loop)
                    {
                        string result = im.post.GUN_OUTandIN_Team(newjson.ToString());

                        switch (ResultPro.Result_Pro(ref result, "GUN_OUTandIN_Team_PRO", false))
                        {
                            case 1:
                                {
                                    Gun_count++; loop=false;break;
                                }
                            case 0:
                                {
                                    result_error_PRO(result, count++); continue;
                                }
                            case -1:
                                {
                                    result_error_PRO(result, count++); break;
                                }
                            default:
                                break;
                        }



                    }
                }
            }
            //队长位置判定 MVP不是队长的话移到队长位置
            foreach (var item in teaminfo)
            {
                if (item.Value.id == mvp_id && item.Value.location != 1)
                {
                    dynamic newjson = new DynamicJson();
                    newjson.team_id /*这是节点*/ = item.Value.team_id;/* 这是值*/
                    newjson.gun_with_user_id /*这是节点*/ = item.Value.id;/* 这是值*/
                    newjson.location /*这是节点*/ = 1;/* 这是值*/

                    bool loop = true;
                    while (loop)
                    {
                        string result = im.post.GUN_OUTandIN_Team(newjson.ToString());

                        switch (ResultPro.Result_Pro(ref result, "GUN_OUTandIN_Team_PRO", false))
                        {
                            case 1:
                                {
                                    Gun_count++; loop = false; break;
                                }
                            case 0:
                                {
                                    result_error_PRO(result, count++); continue;
                                }
                            case -1:
                                {
                                    result_error_PRO(result, count++); break;
                                }
                            default:
                                break;
                        }

                    }
                }
            }


            if (Gun_count == 4|| Gun_count == 5)
            {
                return true;
            }
            else
            {
                goto GUN_OUT_Team;
            }
        }

        public bool GUN_IN_Team(int mvp_id, Dictionary<int, Gun_With_User_Info> teaminfo)
        {
            //{"team_id":6,"gun_with_user_id":0,"location":4}
            GUN_IN_Team: int count = 0;
            int Gun_count = 0;
            foreach(var item in teaminfo)
            {
                if (item.Value.id != mvp_id)
                {
                    dynamic newjson = new DynamicJson();
                    newjson.team_id /*这是节点*/ = item.Value.team_id;/* 这是值*/
                    newjson.gun_with_user_id /*这是节点*/ = item.Value.id;/* 这是值*/
                    newjson.location /*这是节点*/ = item.Value.location;/* 这是值*/

                    bool loop = true;
                    while (loop)
                    {
                        string result = im.post.GUN_OUTandIN_Team(newjson.ToString());

                        switch (ResultPro.Result_Pro(ref result, "GUN_OUTandIN_Team_PRO", false))
                        {
                            case 1:
                                {
                                    Gun_count++; loop = false; break;
                                }
                            case 0:
                                {
                                    result_error_PRO(result, count++); continue;
                                }
                            case -1:
                                {
                                    result_error_PRO(result, count++); break;
                                }
                            default:
                                break;
                        }



                    }
                }
            }

            //mvp位置判定 如果不是
            foreach (var item in teaminfo)
            {
                if (item.Value.id == mvp_id && item.Value.location !=1)
                {
                    dynamic newjson = new DynamicJson();
                    newjson.team_id /*这是节点*/ = item.Value.team_id;/* 这是值*/
                    newjson.gun_with_user_id /*这是节点*/ = item.Value.id;/* 这是值*/
                    newjson.location /*这是节点*/ = item.Value.location;/* 这是值*/

                    bool loop = true;
                    while (loop)
                    {
                        string result = im.post.GUN_OUTandIN_Team(newjson.ToString());
                        switch (ResultPro.Result_Pro(ref result, "GUN_OUTandIN_Team_PRO", false))
                        {
                            case 1:
                                {
                                    Gun_count++; loop = false; break;
                                }
                            case 0:
                                {
                                    result_error_PRO(result, count++); continue;
                                }
                            case -1:
                                {
                                    result_error_PRO(result, count++); break;
                                }
                            default:
                                break;
                        }
                    }
                }
            }


            if (Gun_count == 4 || Gun_count == 5)
            {
                return true;
            }
            else
            {
                goto GUN_IN_Team;
            }
        }


        public bool Fix_Gun(int gun_id,bool quick_fix)
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter jsonWriter = new JsonWriter(sb);
            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName("if_quick");
            if(quick_fix)jsonWriter.Write(1);
            if (!quick_fix) jsonWriter.Write(0);

            jsonWriter.WritePropertyName("fix_guns");

            jsonWriter.WriteObjectStart();
            jsonWriter.WritePropertyName(gun_id.ToString());
            jsonWriter.Write(1);
            jsonWriter.WriteObjectEnd();

            jsonWriter.WriteObjectEnd();

            int count = 0;
            while (true)
            {
                string result = im.post.Girl_Fix(sb.ToString());

                switch (ResultPro.Result_Pro(ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            return true;
                        }
                    case 0:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    case -1:
                        {
                            result_error_PRO(result, count++); continue;
                        }
                    default:
                        break;
                }


            }
        }

    }

}
