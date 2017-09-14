using Codeplex.Data;
using GFHelper.Programe.ProgramePro;
using GFHelper.UserData;
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
            parameters.Add("app_id", "00020000100021001");
            parameters.Add("channelid", ProgrameData.channelid);
            parameters.Add("idfa", "");
            parameters.Add("androidid", ProgrameData.androidid);
            parameters.Add("mac", ProgrameData.mac);
            parameters.Add("req_id", ProgrameData.req_id++.ToString());

            string data =Programe.POST.StringBuilder_(parameters);
            string result = "";
            result = im.post.GetDigitalUid(data);
            if (ResultPro.GetDigitalUid_Pro(ref result)==false)
            {
                MessageBox.Show(result);
                return false;
            }
            return true;


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
        //        if (CommonHelper.ConvertDateTime_China_Int(now) > (item.Value.startTime + item.Value._durationTime))
        //        {
        //            string resurt = im.apioperation.StartOperation(item.Value._teamId, item.Value._operationId);

        //            if (resurt == "1")
        //            {
        //                lock (im.user_operationInfoLocker)//锁
        //                {
        //                    item.Value.reSet();
        //                    //int temp = CommonHelper.ConvertDateTime_China_Int(time);
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
                Programe.ProgramePro.WriteLog.Log(String.Format(" 10电池好友UID =  {0}", item.Value.f_userid.ToString()));
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
                }
            }
        }

        public void Auto_Start_Simulation_Data()
        {
            if (ProgrameData.AutoSimulationBattleF == false) return;
            im.uihelp.setStatusBarText_InThread(String.Format(" 开始资料采样"));
            im.battle_loop.Simulation_DATA(im.userdatasummery.usbti);
        }

        public void Auto_Start_Trial()
        {
            //开始模拟作战无线防御
            //uid 
            //outdatacode = {"team_ids":"7","battle_team":7}
            //req_id
            //url = Mission/startTrial
            if (ProgrameData.AutoSimulationBattleF == false) return;
            string gunid = im.userdatasummery.team_info[ProgrameData.AutoDefenseTrialBattleT][1].id.ToString();

            im.uihelp.setStatusBarText_InThread(String.Format(" BP点数 高于5 开始无限防御模式"));

            if (im.post.StartTrial(ProgrameData.AutoDefenseTrialBattleT.ToString()) == false)
            {
                //发送失败的处理

            }

            im.uihelp.setStatusBarText_InThread(String.Format(" 结束防御模式"));
            System.Threading.Thread.Sleep(5000);

            //序列化
            Random random = new Random();
            string outdatacode = "{\"if_win\":0,\"battle_guns\":{\"" + /*人形ID 预定P7*/ gunid + "\":{\"life\":32,\"dps\":0}},\"skill_cd\":" + /*146上下浮动*/random.Next(145, 150).ToString() + ",\"battle_damage\":{\"enemy_effect_client\":22644}}";

            if (im.post.EndTrial(outdatacode) == false)
            {
                //发送失败的处理
            }
        }

        public void GetRecoverBP()
        {
            im.uihelp.setStatusBarText_InThread(String.Format(" 动能点数恢复"));
            string result = im.post.GetRecoverBP();

            if(result != "")
            {
                var jsonobj = DynamicJson.Parse(result);
                im.userdatasummery.Read_BP_Info(jsonobj);
            }


        }

        public void Get_Build_Coin()
        {
            try
            {
                if (im.userdatasummery.dorm_with_user_info.current_build_coin <= 0) return;
                //开始获得
                im.userdatasummery.dorm_with_user_info.current_build_coin = 0;
                if (im.post.Get_Build_Coin(im.userdatasummery.dorm_with_user_info.info.user_id, im.userdatasummery.dorm_with_user_info.info.dorm_id))
                {
                    //成功的处理把开关guanbi
                }
                else
                {
                    //错误的处理
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        public void Get_Dorm_Info()
        {
            try
            {
                string result = im.post.GetFriend_DormInfo();
                if(result != "")
                {
                    var jsonobj = DynamicJson.Parse(result);
                    im.userdatasummery.ReadDormData(jsonobj);
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        public void Eat_Equip()
        {
            //SELECT+1
            //选取需要升级的枪 done
            //选取狗粮 优先2级 done
            //发送请求         done
            //删除装备         done
            //经验++           done
            im.userdatasummery.Read_Equipment_Upgrade();

            string[] equipFood = new string[11];
            equipFood = im.userdatasummery.Get_Equipment_Food();


            //判断是否为空
            if (string.IsNullOrEmpty(equipFood.ToString()) == true) return;
            var obj = new
            {

                equip_with_user_id = im.userdatasummery.equip_with_user_info_Upgrade[0].id.ToString(),

                food = equipFood
            };


            var jsonStringFromObj = DynamicJson.Serialize(obj);

            //发送请求
            string result = im.post.Eat_Equip(jsonStringFromObj.ToString());

            //数据处理
            if(ProgramePro.ResultPro.Eat_Equip_ResultPro(ref result) == true)
            {
                //加经验 检测是否 超过等级
                im.userdatasummery.Check_Equipment_Update(im.userdatasummery.equip_with_user_info_Upgrade[0].id, Convert.ToInt32(result),im.userdatasummery.equip_with_user_info[0].equip_level);
                //删除装备
                im.userdatasummery.Del_Equip_IN_Dict(equipFood);
            }


        }

        //战斗相关
        public bool startMission(int mission_id,Programe.Auto.Spots[] spots)
        {
            // 一个 int mission_id 一个数组
            //{"mission_id":90018,"spots":[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]}

            // Create New JsonObject
            dynamic newjson = new DynamicJson();
            newjson.mission_id /*这是节点*/ = mission_id;/* 这是值*/
            newjson.spots = spots ;

            var jsonstring = newjson.ToString();


            //发送请求
            string result = im.post.startMission(jsonstring);

            //数据处理
            if (ProgramePro.ResultPro.Start_Mission_ResultPro(result) == true)
            {
                return true;
            }
            return false;
        }

        public bool teamMove(Programe.Auto.TeamMove teammove)
        {
            //{"team_id":6,"from_spot_id":3033,"to_spot_id":3038,"move_type":1}
            dynamic newjson = new DynamicJson();
            newjson.team_id /*这是节点*/ = teammove.team_id;/* 这是值*/
            newjson.from_spot_id /*这是节点*/ = teammove.from_spot_id;/* 这是值*/
            newjson.to_spot_id /*这是节点*/ = teammove.to_spot_id;/* 这是值*/
            newjson.move_type /*这是节点*/ = teammove.move_type;/* 这是值*/
            var jsonstring = newjson.ToString();

            //发送请求
            string result = im.post.teamMove(jsonstring);
            if (ProgramePro.ResultPro.Team_Move_ResultPro(result) == true)
            {
                return true;
            }
            return false;
        }

        public bool Normal_battleFinish(string data,ref string result)
        {

            ProgramePro.WriteLog.Log(data);
            //发送请求
            result = im.post.battleFinish(data);
            if (ProgramePro.ResultPro.Battle_Finish_ResultPro(ref result) == true)
            {
                return true;
            }
            return false;
        }

        public bool Simulation_battleFinish(string data, ref string result)
        {
            result = im.post.simulation_DATA(data);
            if (ProgramePro.ResultPro.Simulation_DATA(ref result) == true)
            {
                return true;
            }
            return false;


        }


        public bool withdrawTeam(int spot_id)
        {
            //{"spot_id":3033}
            var obj = new
            {
                spot_id = spot_id,
            };
            var jsonStringFromObj = DynamicJson.Serialize(obj);
            //发送请求
            string result = im.post.withdrawTeam(jsonStringFromObj.ToString());
            if (ProgramePro.ResultPro.WithDraw_Team_ResultPro(result) == true)
            {
                return true;
            }
            return false;
        }


        public bool abortMission()
        {
            //caa6f92d234e04c034f88c9eb445fd45(sign)

            string result = im.post.abortMission();
            if (ProgramePro.ResultPro.Abort_Mission_ResultPro(result) == true)
            {
                return true;
            }
            return false;
        }

        public bool GUN_OUT_Team(int mvp_id,Dictionary<int,Gun_With_User_Info> teaminfo)
        {
            //{"team_id":6,"gun_with_user_id":0,"location":4}
            foreach (var item in teaminfo)
            {
                if(item.Value.id != mvp_id)
                {
                    dynamic newjson = new DynamicJson();
                    newjson.team_id /*这是节点*/ = item.Value.team_id;/* 这是值*/
                    newjson.gun_with_user_id /*这是节点*/ = 0;/* 这是值*/
                    newjson.location /*这是节点*/ = item.Value.location;/* 这是值*/
                    var jsonstring = newjson.ToString();
                    string result = im.post.GUN_OUTandIN_Team(jsonstring);
                    if (ProgramePro.ResultPro.GUN_OUTandIN_Team(result) == true)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool GUN_IN_Team(int mvp_id, Dictionary<int, Gun_With_User_Info> teaminfo)
        {
            //{"team_id":6,"gun_with_user_id":0,"location":4}
            foreach (var item in teaminfo)
            {
                if (item.Value.id != mvp_id)
                {
                    dynamic newjson = new DynamicJson();
                    newjson.team_id /*这是节点*/ = item.Value.team_id;/* 这是值*/
                    newjson.gun_with_user_id /*这是节点*/ = item.Value.id;/* 这是值*/
                    newjson.location /*这是节点*/ = item.Value.location;/* 这是值*/
                    var jsonstring = newjson.ToString();
                    string result = im.post.GUN_OUTandIN_Team(jsonstring);
                    if (ProgramePro.ResultPro.GUN_OUTandIN_Team(result) == true)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool SupplyTeam(int team_id)
        {
            dynamic newjson = new DynamicJson();
            newjson.team_id /*这是节点*/ = team_id;/* 这是值*/
            var jsonstring = newjson.ToString();
            string result = im.post.SupplyTeam(jsonstring);
            if (ProgramePro.ResultPro.GUN_OUTandIN_Team(result) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
