using GFHelper;
using GFHelper.Programe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace GFHelper
{
    class BackgroundThread
    {
        public InstanceManager im;

        public BackgroundThread(InstanceManager im)
        {
            this.im = im;
        }



        public void CountDown()//倒计时
        {
            DateTime Now = DateTime.Now;


            Thread.Sleep(200);

            while (true)
            {
                //到点自动退出程序
                Programe.CommonHelp.StopTime();

                //需要改 在auto那里新建auto_summery 里写入此方法
                foreach (var item in im.Dic_auto_operation_act)
                {
                    if (item.Value.id == 0) continue;
                    item.Value.Time_Operate(im.catchdatasummery.operation_info[item.Value.operation_id - 1].duration);
                }

                //一些自动循环任务 后勤
                im.auto_summery.Auto_Act_Summery();

                im.uihelp.setUI_User_info();
                Thread.Sleep(1000);

            }
        }

        public void CompleteMisson()
        {
            Thread.Sleep(1000);
                while (true)
                {
                    Thread.Sleep(500);
                    DateTime Now = DateTime.Now;
                    if (ProgrameData.TaskList.Any())
                    {
                        switch (ProgrameData.TaskList.ElementAt(0).TaskNumber)
                        {
                            case 1:
                                {
                                    //登陆
                                    bool temp = im.action.AutoLogin();
                                    if (temp == true)
                                        im.uihelp.setStatusBarText_InThread(String.Format(" 好像登陆成功的样子 sign = {0}", Programe.ProgrameData.sign));

                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;

                                }

                            case 2://任务开始
                                {
                                    //Get_user_info 读取用户信息刷新数据
                                    im.action.Get_Set_UserInfo();
                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }

                            case 7:
                                {
                                    im.action.Start_Operation_Act(im.Dic_auto_operation_act[0]);
                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }

                            case 8:
                                {
                                    im.action.Start_Operation_Act(im.Dic_auto_operation_act[1]);
                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }

                            case 9:
                                {
                                    im.action.Start_Operation_Act(im.Dic_auto_operation_act[2]);
                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }

                            case 10:
                                {
                                    im.action.Start_Operation_Act(im.Dic_auto_operation_act[3]);
                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }
                            case 11:
                                {
                                    im.uihelp.setStatusBarText_InThread(String.Format(" 等待预定时间 "));
                                    Thread.Sleep(Programe.CommonHelp.randomtime(Programe.ProgrameData.OperationDelay));
                                    im.action.Start_Loop_Operation_Act(im.Dic_auto_operation_act[0]);

                                    ProgrameData.TaskList.RemoveAt(0);
                                    //ProgrameData.TaskList.Add(Programe.TaskList.GetuserInfo);
                                    break;
                                }
                            case 12:
                                {
                                    im.uihelp.setStatusBarText_InThread(String.Format(" 等待预定时间 "));
                                    Thread.Sleep(Programe.CommonHelp.randomtime(Programe.ProgrameData.OperationDelay));
                                    im.action.Start_Loop_Operation_Act(im.Dic_auto_operation_act[1]);
                                    ProgrameData.TaskList.RemoveAt(0);
                                    //ProgrameData.TaskList.Add(Programe.TaskList.GetuserInfo);
                                    break;
                                }
                            case 13:
                                {
                                    im.uihelp.setStatusBarText_InThread(String.Format(" 等待预定时间 "));
                                    Thread.Sleep(Programe.CommonHelp.randomtime(Programe.ProgrameData.OperationDelay));
                                    im.action.Start_Loop_Operation_Act(im.Dic_auto_operation_act[2]);
                                    ProgrameData.TaskList.RemoveAt(0);
                                    //ProgrameData.TaskList.Add(Programe.TaskList.GetuserInfo);
                                    break;
                                }
                            case 14:
                                {
                                    im.uihelp.setStatusBarText_InThread(String.Format(" 等待预定时间 "));
                                    Thread.Sleep(Programe.CommonHelp.randomtime(Programe.ProgrameData.OperationDelay));
                                    im.action.Start_Loop_Operation_Act(im.Dic_auto_operation_act[3]);

                                    ProgrameData.TaskList.RemoveAt(0);
                                    //ProgrameData.TaskList.Add(Programe.TaskList.GetuserInfo);
                                    break;
                                }
                            case 15:
                                {
                                    im.action.Abort_Operation_Act(im.Dic_auto_operation_act[0]);

                                    ProgrameData.TaskList.RemoveAt(0);
                                    //ProgrameData.TaskList.Add(Programe.TaskList.GetuserInfo);
                                    break;
                                }

                            case 16:
                                {
                                    im.action.Abort_Operation_Act(im.Dic_auto_operation_act[1]);

                                    ProgrameData.TaskList.RemoveAt(0);
                                    //ProgrameData.TaskList.Add(Programe.TaskList.GetuserInfo);
                                    break;
                                }

                            case 17:
                                {
                                    im.action.Abort_Operation_Act(im.Dic_auto_operation_act[2]);

                                    ProgrameData.TaskList.RemoveAt(0);
                                    //ProgrameData.TaskList.Add(Programe.TaskList.GetuserInfo);
                                    break;
                                }

                            case 18:
                                {
                                    im.action.Abort_Operation_Act(im.Dic_auto_operation_act[3]);

                                    ProgrameData.TaskList.RemoveAt(0);
                                    //ProgrameData.TaskList.Add(Programe.TaskList.GetuserInfo);
                                    break;
                                }

                            case 21:
                                {
                                    im.action.Click_Kalina();
                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }

                            case 22:
                                {
                                    im.action.Receive_Favor_Girls_In_Dorm();
                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }

                            case 23:
                                {
                                    im.action.Visit_Friend_Dorm_Info();
                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }
                            case 24:
                                {
                                    im.action.Get_Build_Coin();
                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }
                            case 25:
                                {
                                    im.action.Get_Dorm_Info();
                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }
                            case 26:
                                {
                                    im.friend.Friend_Praise();
                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }
                            case 31:
                                {
                                    im.action.Auto_Start_Trial();
                                    ProgrameData.TaskList.RemoveAt(0);
                                    //处理结尾 BP的回复时间
                                    //getuserinfo 不能用太卡了只能手动处理
                                    break;
                                }
                            case 32:
                                {
                                    im.action.GetRecoverBP();
                                    ProgrameData.TaskList.RemoveAt(0);
                                    //处理结尾 BP的回复时间
                                    //getuserinfo 不能用太卡了只能手动处理
                                    break;
                                }
                            case 33:
                                {
                                    im.action.Auto_Start_Simulation_Data();
                                    ProgrameData.TaskList.RemoveAt(0);
                                    //处理结尾 BP的回复时间
                                    //getuserinfo 不能用太卡了只能手动处理
                                    break;
                                }
                            case 41:
                                {
                                    //练级任务1
                                    im.battle_loop.BattleLOOP_normal(im.dic_userbattletaskinfo[0]);
                                    ProgrameData.TaskList.RemoveAt(0);
                                    im.battle_loop.End_At_Battle(im.dic_userbattletaskinfo[0]);
                                    break;
                                }
                            case 42:
                                {
                                    //练级任务1
                                    im.battle_loop.BattleLOOP_normal(im.dic_userbattletaskinfo[1]);

                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }
                            case 43:
                                {
                                    //练级任务1
                                    im.battle_loop.BattleLOOP_normal(im.dic_userbattletaskinfo[2]);

                                    ProgrameData.TaskList.RemoveAt(0);
                                    break;
                                }
                            case 44:
                                {
                                    //练级任务1
                                    im.battle_loop.BattleLOOP_normal(im.dic_userbattletaskinfo[3]);

                                ProgrameData.TaskList.RemoveAt(0);
                                break;
                            }

                        case 51:
                            {
                                im.userdatasummery.WriteReport();
                                ProgrameData.TaskList.RemoveAt(0);
                                break;
                            }
                        case 52:
                            {
                                im.action.Establish_Build_Finish();
                                ProgrameData.TaskList.RemoveAt(0);
                                break;
                            }
                            //case 2://readUserinfo
                            //    {
                            ////im.baseAction.GetUserinfo();
                            //im.uiHelper.setStatusBarText_InThread(String.Format(" 获取userinfo"));
                            //im.dataHelper.ReadUserInfo(im.apioperation.GetUserInfo());

                            //im.uiHelper.setUserInfo();//ui

                            ////im.uiHelper.setUserOperation();
                            ////im.uiHelper.setUserOperationteam();


                            ////im.autoOperation.SetTeamInfo();
                            ////im.autoOperation.SetOperationInfo();
                            //ProgrameData.TaskList.taskremove();
                            //im.uiHelper.setStatusBarText_InThread(String.Format(" 获取userinfo成功"));
                            //break;

                    }


                        //case 3://后勤任务1开始
                        {
                            //int team_id, operation_id;
                            //im.mainWindow.comboBoxOperationTeam1.Dispatcher.Invoke(new Action(delegate
                            //{
                            //    im.mainWindow.comboBoxOperation1.Dispatcher.Invoke(new Action(delegate
                            //    {
                            //        team_id = im.mainWindow.comboBoxOperationTeam1.SelectedIndex + 1;
                            //        operation_id = im.mainWindow.comboBoxOperation1.SelectedIndex + 1;
                            //        string temp = im.baseAction.startOperation(team_id, operation_id);
                            //        im.uiHelper.setStatusBarText_InThread(String.Format(" {0}", temp));

                            //        ProgrameData.TaskList.taskadd(Models.TaskListInfo.GetuserInfo);
                            //        ProgrameData.TaskList.taskremove();
                            //        //这里写代码      
                            //    }));//这里写代码      
                            //}));



                            //break;
                        }

                        //case "4":
                        //    {
                        //        if (im.gameData.GetOperationTime_60s())
                        //        {
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    //im.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    //im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    //im.gameData.User_operationInfo[i].Added = true;

                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Add(BaseData.TaskListInfo.WaitForLogistics);
                        //                    //返回时间
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }

                        //            }
                        //        }

                        //        else
                        //        {
                        //            im.time.StartLogisticsTask2(dmae, im.mouse);
                        //            ProgrameData.TaskList.taskremove();
                        //        }
                        //        //战斗结束 判断是否需要加接收后勤任务到最前
                        //        //foreach (var item in im.gameData.User_operationInfo)
                        //        //{
                        //        //    if (item.Value.NeedToRecieve)
                        //        //    {
                        //        //        im.gametasklist.Insert(0, BaseData.TaskListInfo.ReceiveLogistics);
                        //        //        item.Value.NeedToRecieve = false;
                        //        //    }
                        //        //}
                        //        im.mouse.BindWindowS(dmae, 0);

                        //        break;
                        //    }

                        //case "5":
                        //    {
                        //        if (im.gameData.GetOperationTime_60s())
                        //        {
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    //im.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    //im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    //im.gameData.User_operationInfo[i].Added = true;
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;

                        //                    CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Add(BaseData.TaskListInfo.WaitForLogistics);
                        //                    //返回时间
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }

                        //            }
                        //        }
                        //        else
                        //        {
                        //            im.time.StartLogisticsTask3(dmae, im.mouse);
                        //            ProgrameData.TaskList.taskremove();
                        //        }
                        //        //战斗结束 判断是否需要加接收后勤任务到最前
                        //        //foreach (var item in im.gameData.User_operationInfo)
                        //        //{
                        //        //    if (item.Value.NeedToRecieve)
                        //        //    {
                        //        //        im.gametasklist.Insert(0, BaseData.TaskListInfo.ReceiveLogistics);
                        //        //        item.Value.NeedToRecieve = false;
                        //        //    }
                        //        //}
                        //        im.mouse.BindWindowS(dmae, 0);

                        //        break;
                        //    }



                        //case "6":
                        //    {

                        //        if (im.gameData.GetOperationTime_60s())
                        //        {
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    //im.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    //im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    //im.gameData.User_operationInfo[i].Added = true;

                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;

                        //                    CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Add(BaseData.TaskListInfo.WaitForLogistics);
                        //                    //返回时间
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }

                        //            }
                        //        }
                        //        else
                        //        {
                        //            im.time.StartLogisticsTask4(dmae, im.mouse);
                        //            ProgrameData.TaskList.taskremove();
                        //        }
                        //        //战斗结束 判断是否需要加接收后勤任务到最前
                        //        //foreach (var item in im.gameData.User_operationInfo)
                        //        //{
                        //        //    if (item.Value.NeedToRecieve)
                        //        //    {
                        //        //        im.gametasklist.Insert(0, BaseData.TaskListInfo.ReceiveLogistics);
                        //        //        item.Value.NeedToRecieve = false;
                        //        //    }
                        //        //}
                        //        im.mouse.BindWindowS(dmae, 0);
                        //        break;
                        //    }
                        //case "7":
                        //    {
                        //        int temp = 0;

                        //        while (true)
                        //        {
                        //            while (BaseData.SystemInfo.StayAtRecieveOperationPage)
                        //            {
                        //                //全部相同才确定
                        //                BaseData.SystemInfo.AppState = "接收后勤任务";
                        //                im.mouse.delayTime(1, 1);
                        //                im.mouse.LeftClick(dmae, 484, 258, 681, 459);
                        //                temp = 1;
                        //            }
                        //            if (temp == 1 && BaseData.SystemInfo.StayAtHomePage)
                        //            {
                        //                BaseData.SystemInfo.AppState = "回到主页";
                        //                ProgrameData.TaskList.taskremove();
                        //                break;
                        //            }
                        //            im.mouse.delayTime(1, 1);
                        //        }
                        //        break;




                        //    }
                        //case "12"://0
                        //    {
                        //        if (im.gameData.GetOperationTime_60s()|| im.gameData.GetAutoBattleTime_60s())
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            im.gameData.User_battleInfo[0].reSetBattleInfo();
                        //            UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                        //            tempUserBattleInfo = im.gameData.User_battleInfo[0];

                        //            im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);

                        //            im.gameData.User_battleInfo[0] = tempUserBattleInfo;

                        //            ProgrameData.TaskList.taskremove();

                        //            im.gameData.User_battleInfo[0].EndAtBattle(dmae);
                        //        }



                        //        break;
                        //    }

                        //case "13":
                        //    {

                        //        if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {

                        //            im.gameData.User_battleInfo[1].reSetBattleInfo();
                        //            UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                        //            tempUserBattleInfo = im.gameData.User_battleInfo[1];

                        //            im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);
                        //            im.gameData.User_battleInfo[1] = tempUserBattleInfo;

                        //            ProgrameData.TaskList.taskremove();



                        //            im.gameData.User_battleInfo[1].EndAtBattle(dmae);

                        //        }

                        //        //判断最大循环最大次数，若相等则停止
                        //        break;
                        //    }
                        //case "14":
                        //    {
                        //        if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {

                        //            im.gameData.User_battleInfo[2].reSetBattleInfo();
                        //            UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                        //            tempUserBattleInfo = im.gameData.User_battleInfo[2];

                        //            im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);
                        //            im.gameData.User_battleInfo[2] = tempUserBattleInfo;

                        //            ProgrameData.TaskList.taskremove();

                        //            im.gameData.User_battleInfo[2].EndAtBattle(dmae);

                        //        }
                        //        break;
                        //    }
                        //case "15":
                        //    {
                        //        if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            im.gameData.User_battleInfo[3].reSetBattleInfo();
                        //            UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                        //            tempUserBattleInfo = im.gameData.User_battleInfo[3];

                        //            im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);
                        //            im.gameData.User_battleInfo[3] = tempUserBattleInfo;
                        //            ProgrameData.TaskList.taskremove();


                        //            im.gameData.User_battleInfo[3].EndAtBattle(dmae);

                        //        }

                        //        break;
                        //    }

                        //case "16":
                        //    {
                        //        if (im.gameData.GetOperationTime_60s()/* || im.gameData.GetAutoBattleTime_60s()*/)
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            UserAutoBattleInfo temp = new UserAutoBattleInfo();

                        //            im.gameData.User_AutobattleInfo[0].AutoBattleUse = true;
                        //            temp = im.gameData.User_AutobattleInfo[0];
                        //            im.gameData.User_AutobattleInfo[0].AutoBattleLastTime = im.time.AutoBattle(dmae, im.mouse, ref temp);
                        //            im.gameData.User_AutobattleInfo[0].AutoBattleLoopTime++;
                        //            ProgrameData.TaskList.taskremove();


                        //        }
                        //        im.mouse.BindWindowS(dmae, 0);
                        //        break;
                        //    }


                        //case "17":
                        //    {
                        //        if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            im.time.BuildEquipment(dmae, im.mouse);
                        //            ProgrameData.TaskList.taskremove();

                        //        }
                        //        im.mouse.BindWindowS(dmae, 0);
                        //        break;

                        //    }
                        //case "19":
                        //    {
                        //        im.mouse.BindWindowS(dmae, 1);
                        //        im.dormitory.VoteDormitoryLoop(dmae);
                        //        ProgrameData.TaskList.taskremove();
                        //        im.mouse.BindWindowS(dmae, 0);
                        //        break;
                        //    }

                        //case "20"://装备强化
                        //    {
                        //        if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            //代码
                        //            im.equipment.EquipmentUpdate(dmae,im.gameData.User_battleInfo[CommonHelp.BattleEquipmentOrGunNumber-1].EquipmentType, im.gameData.User_battleInfo[CommonHelp.BattleEquipmentOrGunNumber-1].EquipmentUpdatePostion, im.gameData.User_battleInfo[CommonHelp.BattleEquipmentOrGunNumber-1].EquipmentUpdateCount);
                        //            ProgrameData.TaskList.taskremove();

                        //        }


                        //        im.mouse.BindWindowS(dmae, 0);



                        //        break;
                        //    }


                        //case "22"://读取和保存好友宿舍的名单
                        //    {
                        //        im.mouse.BindWindowS(dmae, 1);
                        //        im.dormitory.ReadAndSaveFriendsDormitoryList(dmae);
                        //        ProgrameData.TaskList.taskremove();



                        //        im.mouse.BindWindowS(dmae, 0);
                        //        break;
                        //    }
                        //case "23"://读取和保存好友宿舍的名单
                        //    {
                        //        im.mouse.BindWindowS(dmae, 1);

                        //        im.dormitory.GetFriendBattery(dmae,im.Form1.checkBox2.Checked,im.Form1.checkBox3.Checked);
                        //        ProgrameData.TaskList.taskremove();

                        //        im.mouse.BindWindowS(dmae, 0);
                        //        break;
                        //    }


                        //case "24"://更换编队1
                        //    {
                        //        if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            //根据当前battle的KEY传过去

                        //            UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                        //            tempUserBattleInfo = im.gameData.User_battleInfo[CommonHelp.BattleFixNumber-1];
                        //            switch (CommonHelp.BattleFixNumber)
                        //            {
                        //                case 1: { im.formation.TeamFormationChange1(dmae,im.mouse,ref tempUserBattleInfo); break; }
                        //                case 2: { im.formation.TeamFormationChange1(dmae, im.mouse, ref tempUserBattleInfo); break; }
                        //                case 3: { im.formation.TeamFormationChange1(dmae, im.mouse, ref tempUserBattleInfo); break; }
                        //                case 4: { im.formation.TeamFormationChange1(dmae, im.mouse, ref tempUserBattleInfo); break; }

                        //                default:
                        //                    break;
                        //            }




                        //            ProgrameData.TaskList.taskremove();


                        //        }



                        //        break;
                        //    }

                        //case "25"://单独补给
                        //    {
                        //        if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            //根据当前battle的KEY传过去
                        //            im.gameData.User_battleInfo[CommonHelp.BattleFixNumber - 1].NeetToDismantleGunOrEquipment = false;
                        //            UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                        //            tempUserBattleInfo = im.gameData.User_battleInfo[CommonHelp.BattleFixNumber - 1];
                        //            switch (CommonHelp.BattleFixNumber)
                        //            {
                        //                case 1: { im.formation.TeamFormationFighterSupport(dmae, im.mouse, ref tempUserBattleInfo); break; }
                        //                case 2: { im.formation.TeamFormationFighterSupport(dmae, im.mouse, ref tempUserBattleInfo); break; }
                        //                case 3: { im.formation.TeamFormationFighterSupport(dmae, im.mouse, ref tempUserBattleInfo); break; }
                        //                case 4: { im.formation.TeamFormationFighterSupport(dmae, im.mouse, ref tempUserBattleInfo); break; }

                        //                default:
                        //                    break;
                        //            }
                        //            im.gameData.User_battleInfo[CommonHelp.BattleFixNumber - 1] = tempUserBattleInfo;



                        //            ProgrameData.TaskList.taskremove();

                        //            if(im.gameData.User_battleInfo[CommonHelp.BattleFixNumber - 1].NeetToDismantleGunOrEquipment)
                        //            {
                        //                CommonHelp.gametasklist.Insert(1, BaseData.TaskListInfo.BattleSupport_plus);
                        //            }


                        //        }



                        //        break;
                        //    }


                        //case "26"://更换编队2
                        //    {
                        //        if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            //根据当前battle的KEY传过去

                        //            UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                        //            tempUserBattleInfo = im.gameData.User_battleInfo[CommonHelp.BattleFixNumber - 1];
                        //            switch (CommonHelp.BattleFixNumber)
                        //            {
                        //                case 1: { im.formation.TeamFormationChange2(dmae, im.mouse, ref tempUserBattleInfo); break; }
                        //                case 2: { im.formation.TeamFormationChange2(dmae, im.mouse, ref tempUserBattleInfo); break; }
                        //                case 3: { im.formation.TeamFormationChange2(dmae, im.mouse, ref tempUserBattleInfo); break; }
                        //                case 4: { im.formation.TeamFormationChange2(dmae, im.mouse, ref tempUserBattleInfo); break; }

                        //                default:
                        //                    break;
                        //            }




                        //            ProgrameData.TaskList.taskremove();


                        //        }



                        //        break;
                        //    }



                        //case "94"://回到游戏
                        //    {
                        //        break;
                        //    }

                        //case "96"://拆除
                        //    {
                        //        if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {

                        //            //拆枪代码
                        //            switch (CommonHelp.BattleEquipmentOrGunNumber)
                        //            {
                        //                case 1: { im.time.DismantlementGun(dmae, im.mouse, im.gameData.User_battleInfo[0].DismantlementGunCount);  break; }
                        //                case 2: { im.time.DismantlementGun(dmae, im.mouse, im.gameData.User_battleInfo[1].DismantlementGunCount); break; }
                        //                case 3: { im.time.DismantlementGun(dmae, im.mouse, im.gameData.User_battleInfo[2].DismantlementGunCount); break; }
                        //                case 4: { im.time.DismantlementGun(dmae, im.mouse, im.gameData.User_battleInfo[3].DismantlementGunCount); break; }

                        //                default:
                        //                    break;
                        //            }
                        //            ProgrameData.TaskList.taskremove();

                        //        }


                        //        im.mouse.BindWindowS(dmae, 0);



                        //        break;
                        //    }

                        //case "97":
                        //    {
                        //        if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                        //        {
                        //            //后勤
                        //            Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                        //            for (int i = 0; i < 4; i++)
                        //            {
                        //                if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                        //                {
                        //                    LogistandAutolist temp = new LogistandAutolist();
                        //                    temp.key = i;
                        //                    temp.type = 0;
                        //                    temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                        //                    TimeDic.Add(i, temp);

                        //                    im.gameData.User_operationInfo[i].Lfinish = true;
                        //                    CommonHelp.gametasklist.Insert(0, BaseData.TaskListInfo.WaitForLogistics);//等加接收一起完成
                        //                    im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                        //                    im.gameData.User_operationInfo[i].Added = true;
                        //                }
                        //            }
                        //            //自律

                        //            if (im.gameData.GetAutoBattleTime_60s())
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.type = 1;
                        //                temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                        //                TimeDic.Add(TimeDic.Count, temp);
                        //            }

                        //            var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                        //            foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                        //            {
                        //                LogistandAutolist temp = new LogistandAutolist();
                        //                temp.key = kvp.Key;
                        //                temp.type = 0;
                        //                CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            switch (CommonHelp.BattleFixNumber)
                        //            {
                        //                case 1: { im.gameData.User_battleInfo[0].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[0]); break; }
                        //                case 2: { im.gameData.User_battleInfo[1].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[1]); break; }
                        //                case 3: { im.gameData.User_battleInfo[2].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[2]); break; }
                        //                case 4: { im.gameData.User_battleInfo[3].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[3]); break; }

                        //                default:
                        //                    break;
                        //            }


                        //            ProgrameData.TaskList.taskremove();

                        //            //修复结束 判断是否需要加接收后勤任务到最前
                        //            //foreach (var item in im.gameData.User_operationInfo)
                        //            //{
                        //            //    if (item.Value.ReceiveRightNow)
                        //            //    {
                        //            //        im.gametasklist.Insert(0, BaseData.TaskListInfo.ReceiveLogistics);
                        //            //        item.Value.ReceiveRightNow = false;
                        //            //        item.Value.NeedToRecieve = false;
                        //            //        item.Value.OperationNeedTowait = false;
                        //            //    }
                        //            //}
                        //        }
                        //        im.mouse.BindWindowS(dmae, 0);
                        //        break;
                        //    }


                        //case "98":
                        //    {
                        //        switch (CommonHelp.User_LogistandAutoNumberNow[0].type)
                        //        {
                        //            case 0:
                        //                {
                        //                    while (true)
                        //                    {
                        //                        if (SystemInfo.StayAtRecieveOperationPage)
                        //                        {
                        //                            SystemInfo.AppState = "接收后勤任务";
                        //                            im.mouse.delayTime(1, 1);
                        //                            Random ran = new Random();

                        //                            if (WindowsFormsApplication1.BaseData.SystemInfo.LogisticFinishWaittingTime != 0)
                        //                            {
                        //                                im.mouse.delayTime(Convert.ToDouble(ran.Next(1, WindowsFormsApplication1.BaseData.SystemInfo.LogisticFinishWaittingTime * 10)) / 10 * 60, 1);//等待时间
                        //                            }

                        //                            im.mouse.LeftClick(dmae, 484, 258, 681, 459);
                        //                        }
                        //                        while (im.pagecheck.CheckLsystemAgain(dmae.dm))
                        //                        {

                        //                            im.mouse.LeftClick(dmae, 677, 475, 808, 514);
                        //                            im.mouse.delayTime(1, 1);
                        //                            while (im.pagecheck.CheckLsystemAgain(dmae.dm) == false)
                        //                            {
                        //                                goto end;
                        //                            }
                        //                        }
                        //                        if (SystemInfo.StayAtHomePage)
                        //                        {
                        //                            SystemInfo.AppState = "主页";
                        //                        }
                        //                        im.mouse.delayTime(1, 1);
                        //                    }
                        //                    end: ProgrameData.TaskList.taskremove();
                        //                    try
                        //                    {
                        //                        im.gameData.User_operationInfo[CommonHelp.User_LogistandAutoNumberNow[0].key].Lfinish = false;
                        //                        CommonHelp.User_LogistandAutoNumberNow.RemoveAt(0);//出列
                        //                    }
                        //                    catch (Exception)
                        //                    {
                        //                    }
                        //                    break;
                        //                }
                        //            case 1:
                        //                {
                        //                    while (true)
                        //                    {
                        //                        if (SystemInfo.AutoBattleFinishPage)
                        //                        {
                        //                            SystemInfo.AppState = "自律任务完成";
                        //                            im.mouse.delayTime(1, 1);
                        //                            Random ran = new Random();

                        //                            if (WindowsFormsApplication1.BaseData.SystemInfo.LogisticFinishWaittingTime != 0)
                        //                            {
                        //                                im.mouse.delayTime(Convert.ToDouble(ran.Next(1, WindowsFormsApplication1.BaseData.SystemInfo.LogisticFinishWaittingTime * 10)) / 10 * 60, 1);//等待时间
                        //                            }

                        //                            im.mouse.LeftClick(dmae, 484, 258, 681, 459);
                        //                        }
                        //                        while (true)
                        //                        {

                        //                            while (im.pagecheck.CheckWhiteM(dmae.dm))
                        //                            {
                        //                                im.mouse.delayTime(1, 1);
                        //                                continue;
                        //                            }
                        //                            if (im.pagecheck.CheckNewGunEquipmentPage(dmae.dm))
                        //                            {
                        //                                SystemInfo.AppState = "获取新人形";
                        //                                im.mouse.LeftClick(dmae, 1107, 633, 1242, 691);
                        //                            }
                        //                            im.mouse.delayTime(1, 1);

                        //                            if (SystemInfo.AutoBattleFinishPage)
                        //                            {
                        //                                while (SystemInfo.StayAtHomePage == false)
                        //                                {
                        //                                    im.mouse.LeftClick(dmae, 1107, 633, 1242, 691);
                        //                                }
                        //                                goto end;
                        //                            }


                        //                        }
                        //                    }
                        //                    end: ProgrameData.TaskList.taskremove();
                        //                    try
                        //                    {
                        //                        im.gameData.User_operationInfo[CommonHelp.User_LogistandAutoNumberNow[0].key].Lfinish = false;
                        //                        CommonHelp.User_LogistandAutoNumberNow.RemoveAt(0);//出列
                        //                    }
                        //                    catch (Exception)
                        //                    {
                        //                    }

                        //                    break;

                        //                }
                        //            default:
                        //                break;
                        //        }


                        //        break;
                        //    }
                        //case "99"://接收自律
                        //    {
                        //        break;
                        //    }



                    }
                    else
                    {

                    }
                }

        }
    }

    //    public void ThreadT()//处理线程;
    //    {

    //        while (true)
    //        {
    //            //Thread.Sleep(1000);
    //            //switch (BaseData.SystemInfo.ThreadTCase)
    //            //{
    //            //    case 0: { break; }
    //            //    //重启处理任务的线程;
    //            //    case 1:
    //            //        {

    //            //            im.gameData.User_battleInfo[0].Used = false;
    //            //            im.gameData.User_battleInfo[1].Used = false;
    //            //            im.gameData.User_battleInfo[2].Used = false;
    //            //            im.gameData.User_battleInfo[3].Used = false;

    //            //            im.CompleteMisson.Abort();
    //            //            CommonHelp.gametasklist.Clear();

    //            //            im.CompleteMisson = new Thread(CompleteMisson);
    //            //            im.CompleteMisson.IsBackground = true;
    //            //            im.CompleteMisson.Start();

    //            //            BaseData.SystemInfo.ThreadTCase = 0;
    //            //            im.mouse.BindWindowS(dmae, 0);//0不锁死鼠标
    //            //            break;
    //            //        }
    //            //    case 2:
    //            //        {
    //            //            im.CompleteMisson.Abort();
    //            //            //ProgrameData.TaskList.taskremove();
    //            //            im.CompleteMisson = new Thread(CompleteMisson);
    //            //            im.CompleteMisson.IsBackground = true;
    //            //            im.CompleteMisson.Start();
    //            //            BaseData.SystemInfo.ThreadTCase = 0;
    //            //            im.mouse.BindWindowS(dmae, 0);//0不锁死鼠标
    //            //            break;
    //            //        }

    //            //    default:
    //            //        break;
    //        //    //}
    //        //}



    //    }

    //}
}
