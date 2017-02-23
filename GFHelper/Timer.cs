using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GFHelper.Models;
using System.Threading;
using System.Windows;

namespace GFHelper
{


    class Timer
    {

        private List<TimerDelegate> timer;
        private InstanceManager im;
        private bool work;

        public Timer(InstanceManager im)
        {
            this.im = im;
            this.timer = new List<TimerDelegate>();
            this.work = false;
        }

        public void DeleteTimerWithTextBlock(TextBlock tb)
        {
            foreach(var item in timer)
            {
                if (item.textBlock == tb)
                {
                    this.timer.Remove(item);
                    return;
                }
            }
        }
        public void AddTimerText(TextBlock tb, int start, int last)
        {
            TimerDelegate tt = new TimerDelegate();
            tt.textBlock = tb;
            tt.start = start;
            tt.last = last;
            this.AddTimer(tt);
        }


        public void AddTimerDelegate(CommonModels.TimerDelegeFunction function, object a, int start, int last)
        {
            TimerDelegate td = new TimerDelegate();
            td.a = a;
            td.function = function;
            td.start = start;
            td.last = last;
            this.AddTimer(td);
        }

        public void AddTimer(int start, int last, CommonModels.TimerDelegeFunction function = null, object a = null, TextBlock tb = null)
        {
            TimerDelegate td = new TimerDelegate();
            td.a = a;
            td.function = function;
            td.start = start;
            td.last = last;
            td.textBlock = tb;
            this.AddTimer(td);
        }

        public void AddTimer(TimerDelegate td)
        {
            this.timer.Add(td);
        }

        public void Start()
        {
            if (this.work) return;
            this.work = true;
            Task.Run(() =>
            {
                Update();
            });
        }

        public void Stop()
        {
            this.work = false;
        }

        public void Update()
        {

            while (work)
            {
                if (timer.Count != 0)
                    foreach (var item in timer.ToArray())
                    {
                        int duration = (item.start + item.last) - CommonHelper.ConvertDateTimeInt(System.DateTime.Now);

                        if (item.textBlock != null)
                        {
                            im.uiHelper.setTextBlockText(item.textBlock, CommonHelper.formatDuration(duration));
                        }

                        if (duration <= 0)
                        {
                            this.timer.Remove(item);
                            if (item.function != null)
                            {
                                item.function(item.a);
                            }

                            if(item.textBlock != null)
                            {
                                im.uiHelper.setTextBlockText(item.textBlock, CommonHelper.formatDuration(0));
                            }
                            
                        }
                    }
                Thread.Sleep(500);
            }
            
        }

    }

    class BackgroundThread
    {
        private InstanceManager im;
        public BackgroundThread(InstanceManager im)
        {

            this.im = im;
        }
        public void countdown()//倒计时
        {
            int a = 0;
            DateTime Now = DateTime.Now;
            double c;
            Thread.Sleep(1000);
            //Stopwatch sw = new Stopwatch();
            while (true)
            {
                c = (DateTime.Now - Now).TotalSeconds;
                Now = DateTime.Now;

                //sw.Start();

                //消除第一空余第二任务的BUG
                //if (Task.ElementAt(0).TaskNumber == 0)
                //{
                //    if (Task.ElementAt(1).TaskNumber != 0)
                //    {
                //        Task.RemoveAt(1);
                //    }
                //}



                lock (im.user_operationInfoLocker)//锁
                {
                    foreach (var item in im.data.user_operationInfo)
                    {
                        if (CommonHelper.ConvertDateTimeInt(Now) > (item.Value.startTime + item.Value._durationTime + Models.SimpleInfo.autoStartOperationRandomDelay))//+5s
                        {
                            if (item.Value._durationTime == 0)//除去重复添加928BUG
                            {
                                ;
                            }
                            else
                            {
                                a = 1;
                                item.Value._durationTime = 0;
                                im.data.tasklistadd(9);

                                im.data.tasklistadd(8);

                            }
                        }
                        if (item.Value._LastTime >= 0)
                        {
                            item.Value.SetLastTime();//获取剩余时间
                        }
                    }
                }


                if (a == 1)
                {
                    //im.data.tasklistadd(2);//getuserinfo
                    Models.SimpleInfo.LoginStartOperation = true;
                    a = 0;
                }





                //this.SetText("label99", variables.AppState);

                //SetText("comboBox1", variables.LogisticsTeam1);
                //SetText("comboBox2", variables.LogisticsTeam2);
                //SetText("comboBox3", variables.LogisticsTeam3);
                //SetText("comboBox4", variables.LogisticsTeam4);
                //SetText("comboBox5", variables.LogisticsTask1);
                //SetText("comboBox6", variables.LogisticsTask2);
                //SetText("comboBox7", variables.LogisticsTask3);
                //SetText("comboBox8", variables.LogisticsTask4);
                //SetText("textBox1", Convert.ToInt32(variables.RT1).ToString());
                //SetText("textBox2", Convert.ToInt32(variables.RT2).ToString());
                //SetText("textBox3", Convert.ToInt32(variables.RT3).ToString());
                //SetText("textBox4", Convert.ToInt32(variables.RT4).ToString());

                //SetText("label3", Task.ElementAt(0).TaskName);//显示队列任务
                //SetText("label4", Task.ElementAt(1).TaskName);
                //SetText("label5", Task.ElementAt(2).TaskName);
                //SetText("label6", Task.ElementAt(3).TaskName);
                //SetText("label7", Task.ElementAt(4).TaskName);

                //SetText("textBox12", Convert.ToInt32(variables.BFIXT1).ToString());// 战斗任务倒数时间
                //SetText("textBox14", Convert.ToInt32(variables.BFIXT2).ToString());
                //SetText("textBox15", Convert.ToInt32(variables.BFIXT3).ToString());
                //SetText("textBox17", Convert.ToInt32(variables.BFIXT4).ToString());
                //SetText("textBox19", Convert.ToInt32(variables.AutoBattleTime).ToString());

                //SetText("textBox6", Convert.ToInt32(ShowerTime[0]).ToString());//澡堂
                //SetText("textBox7", Convert.ToInt32(ShowerTime[1]).ToString());
                //SetText("textBox8", Convert.ToInt32(ShowerTime[2]).ToString());
                //SetText("textBox9", Convert.ToInt32(ShowerTime[3]).ToString());
                //SetText("textBox10", Convert.ToInt32(ShowerTime[4]).ToString());
                //SetText("textBox11", Convert.ToInt32(ShowerTime[5]).ToString());


                //sw.Stop();


                //try
                //{

                im.uiHelper.setUserOperationinfo();
                Thread.Sleep(1000);
            }
        }

        public void CompleteMisson()
        {
            //if (variables.PprogramErrorBackToHome == true)
            //{
            //    //点游戏图标重进游戏
            //    taskadd(BackToGame);
            //    variables.PprogramErrorBackToHome = false;
            //}


            im.data.tasklist.Add(0);
            while (true)
            {

                Thread.Sleep(100);
                switch (im.data.tasklist[0])
                {
                    case 1://登陆
                        {
                            bool temp = im.baseAction.AutoLogin();
                            if (temp == true)
                                im.uiHelper.setStatusBarText_InThread(String.Format(" 好像登陆成功的样子 sign = {0}", Models.SimpleInfo.sign));





                            im.data.tasklistremove();
                            break;

                        }

                    case 2://readUserinfo
                        {
                            //im.baseAction.GetUserinfo();
                            im.uiHelper.setStatusBarText_InThread(String.Format(" 获取userinfo"));
                            im.dataHelper.ReadUserInfo(im.apioperation.GetUserInfo());

                            im.uiHelper.setUserInfo();//ui

                            //im.uiHelper.setUserOperation();
                            //im.uiHelper.setUserOperationteam();


                            //im.autoOperation.SetTeamInfo();
                            //im.autoOperation.SetOperationInfo();
                            im.data.tasklistremove();
                            im.uiHelper.setStatusBarText_InThread(String.Format(" 获取userinfo成功"));
                            break;

                        }


                    case 3://后勤任务1开始
                        { 
                        int team_id,  operation_id;
                            im.mainWindow.comboBoxOperationTeam1.Dispatcher.Invoke(new Action(delegate {
                                im.mainWindow.comboBoxOperation1.Dispatcher.Invoke(new Action(delegate {
                                    team_id = im.mainWindow.comboBoxOperationTeam1.SelectedIndex + 1;
                                    operation_id = im.mainWindow.comboBoxOperation1.SelectedIndex + 1;
                                    string temp = im.baseAction.startOperation(team_id, operation_id, Data.operationInfo[operation_id].campaign);
                                    im.uiHelper.setStatusBarText_InThread(String.Format(" {0}", temp));

                                    im.data.tasklistadd(2);
                                    im.data.tasklistremove();
                                    //这里写代码      
                                }));//这里写代码      
                            }));



                            break;
                        }

                    case 4://后勤任务2开始
                        {
                            int team_id, operation_id;

                            im.mainWindow.comboBoxOperationTeam2.Dispatcher.Invoke(new Action(delegate {
                                im.mainWindow.comboBoxOperation2.Dispatcher.Invoke(new Action(delegate {
                                    team_id = im.mainWindow.comboBoxOperationTeam2.SelectedIndex + 1;
                                    operation_id = im.mainWindow.comboBoxOperation2.SelectedIndex + 1;
                                    string temp = im.baseAction.startOperation(team_id, operation_id, Data.operationInfo[operation_id].campaign);
                                    im.uiHelper.setStatusBarText_InThread(String.Format(" {0}", temp));

                                    im.data.tasklistadd(2);
                                    im.data.tasklistremove();
                                    //这里写代码      
                                }));//这里写代码      
                            }));


                            break;
                        }

                    case 5:
                        {
                            int team_id, operation_id;
                            im.mainWindow.comboBoxOperationTeam3.Dispatcher.Invoke(new Action(delegate {
                                im.mainWindow.comboBoxOperation3.Dispatcher.Invoke(new Action(delegate {
                                    team_id = im.mainWindow.comboBoxOperationTeam3.SelectedIndex + 1;
                                    operation_id = im.mainWindow.comboBoxOperation3.SelectedIndex + 1;
                                    string temp = im.baseAction.startOperation(team_id, operation_id, Data.operationInfo[operation_id].campaign);
                                    im.uiHelper.setStatusBarText_InThread(String.Format(" {0}", temp));

                                    im.data.tasklistadd(2);
                                    im.data.tasklistremove();
                                    //这里写代码      
                                }));//这里写代码      
                            }));



                            break;
                        }



                    case 6:
                        {
                            int team_id, operation_id;
                            im.mainWindow.comboBoxOperationTeam4.Dispatcher.Invoke(new Action(delegate {
                                im.mainWindow.comboBoxOperation4.Dispatcher.Invoke(new Action(delegate {
                                    team_id = im.mainWindow.comboBoxOperationTeam4.SelectedIndex + 1;
                                    operation_id = im.mainWindow.comboBoxOperation4.SelectedIndex + 1;
                                    string temp = im.baseAction.startOperation(team_id, operation_id, Data.operationInfo[operation_id].campaign);
                                    im.uiHelper.setStatusBarText_InThread(String.Format(" {0}", temp));

                                    im.data.tasklistadd(2);
                                    im.data.tasklistremove();
                                    //这里写代码      
                                }));//这里写代码      
                            }));



                            break;
                        }


                    case 7://接收任务
                        {
                            string temp = im.baseAction.LoginfinishOperation();
                            if (temp == "1")
                                im.uiHelper.setStatusBarText_InThread(String.Format(" 接收后勤任务成功"));

                            else
                                MessageBox.Show("接收后勤任务失败");

                            im.data.tasklistremove();
                            break;
                        }

                    case 8://开始任务通用
                        {
                            im.uiHelper.setStatusBarText_InThread(String.Format(" 开始执行后勤任务"));
                            string temp = im.baseAction.autostartOperation();
                            if (temp == "1")
                                im.uiHelper.setStatusBarText_InThread(String.Format(" 执行后勤任务成功"));


                            im.data.tasklistremove();


                            break;
                        }

                    case 9://接收任务
                        {
                            string temp = im.baseAction.autofinishOperation();

                                im.uiHelper.setStatusBarText_InThread(String.Format(" 接收后勤任务成功"));
                            im.data.tasklistremove();

                            break;
                        }
                        //    case "12":
                        //        {

                        //            if ((variables.RT1 > 0 && variables.RT1 < 10) || (variables.RT2 > 0 && variables.RT2 < 10) || (variables.RT3 > 0 && variables.RT3 < 10) || (variables.RT4 > 0 && variables.RT4 < 10))
                        //            {
                        //                taskadd(WaitForLogistics);
                        //                taskremove();
                        //                taskadd(Battle1);//泛型练级1
                        //            }
                        //            else
                        //            {
                        //                if (variables.Battletask1.Used == false)
                        //                {
                        //                    SetText("label23", "战斗任务1");
                        //                    taskremove();
                        //                }
                        //                else
                        //                {

                        //                    Temptextbox = textBox12;
                        //                    variables.temptaskNo = 1;

                        //                    if (variables.Battletask1.TaskName == "魔方行动E4")
                        //                    {
                        //                        SetText("label23", variables.Battletask1.TaskName);
                        //                    }
                        //                    else
                        //                    {

                        //                        SetText("label23", variables.Battletask1.TaskName + "练级");
                        //                    }


                        //                    time.ChoseThebattle(dmae, mouse, variables.Battletask1.TaskName, variables.Battletask1.TaskMianTeam, variables.Battletask1.TaskSupportTeam, variables.Battletask1.ChoinceToFix, variables.Battletask1.ChoinceToSupply, variables.Battletask1.FixMaxTime, variables.Battletask1.FixMintime, variables.Battletask1.FixMaxPercentage, variables.Battletask1.FixMinPercentage, variables.Battletask1.TaskType, variables.Battletask1.SetMap);
                        //                    taskremove();

                        //                    if (variables.Battletask1.ChangeGun == true) { variables.ChangeGunBattleTask = 1; taskadd(variables.ChangeGun); }


                        //                    if (variables.NeedToFix == true) { Task.Insert(0, Fix); }
                        //                    else//-----循环间隔
                        //                    {
                        //                        Random ran = new Random();
                        //                        int temp0 = ran.Next(0, Battletask1.RoundInterval);
                        //                        variables.BFIXT1 = temp0 + 1;
                        //                        ran = null;
                        //                    }



                        //                    SetText("textBox5", (Int32.Parse(textBox5.Text) + 1).ToString());



                        //                }

                        //            }
                        //            if (Battletask1.Used == false) { mouse.BindWindowS(dmae, 0); }
                        //            if (Battletask1.BattleLoopUnLockWindows == false) { mouse.BindWindowS(dmae, 0); }
                        //            break;
                        //        }

                        //    case "13":
                        //        {

                        //            if ((variables.RT1 > 0 && variables.RT1 < 10) || (variables.RT2 > 0 && variables.RT2 < 10) || (variables.RT3 > 0 && variables.RT3 < 10) || (variables.RT4 > 0 && variables.RT4 < 10))
                        //            {
                        //                taskadd(WaitForLogistics);
                        //                taskremove();
                        //                taskadd(Battle2);//泛型练级2
                        //            }
                        //            else
                        //            {
                        //                if (variables.Battletask2.Used == false)
                        //                {
                        //                    SetText("label24", "战斗任务2");
                        //                    taskremove();
                        //                }
                        //                else
                        //                {


                        //                    Temptextbox = textBox14;
                        //                    variables.temptaskNo = 2;

                        //                    if (variables.Battletask2.TaskName == "魔方行动E4")
                        //                    {
                        //                        SetText("label24", variables.Battletask2.TaskName);
                        //                    }
                        //                    else
                        //                    {

                        //                        SetText("label24", variables.Battletask2.TaskName + "练级");
                        //                    }


                        //                    SetText("label24", variables.Battletask2.TaskName + "练级");

                        //                    time.ChoseThebattle(dmae, mouse, variables.Battletask2.TaskName, variables.Battletask2.TaskMianTeam, variables.Battletask2.TaskSupportTeam, variables.Battletask2.ChoinceToFix, variables.Battletask2.ChoinceToSupply, variables.Battletask2.FixMaxTime, variables.Battletask2.FixMintime, variables.Battletask2.FixMaxPercentage, variables.Battletask2.FixMinPercentage, variables.Battletask2.TaskType, Battletask2.SetMap);
                        //                    SetText("textBox13", (Int32.Parse(textBox13.Text) + 1).ToString());
                        //                    taskremove();

                        //                    if (variables.Battletask2.ChangeGun == true) { variables.ChangeGunBattleTask = 2; taskadd(variables.ChangeGun); }

                        //                    if (variables.NeedToFix == true) { Task.Insert(0, Fix); }
                        //                    else
                        //                    {
                        //                        Random ran = new Random();
                        //                        int temp0 = ran.Next(0, Battletask2.RoundInterval);
                        //                        variables.BFIXT2 = temp0 + 1;
                        //                        ran = null;
                        //                    }

                        //                }

                        //            }
                        //            if (Battletask2.Used == false) { mouse.BindWindowS(dmae, 0); }
                        //            if (Battletask2.BattleLoopUnLockWindows == false) { mouse.BindWindowS(dmae, 0); }
                        //            break;
                        //        }
                        //    case "14":
                        //        {

                        //            if ((variables.RT1 > 0 && variables.RT1 < 10) || (variables.RT2 > 0 && variables.RT2 < 10) || (variables.RT3 > 0 && variables.RT3 < 10) || (variables.RT4 > 0 && variables.RT4 < 10))
                        //            {
                        //                taskadd(WaitForLogistics);
                        //                taskremove();
                        //                taskadd(Battle3);//泛型练级3
                        //            }
                        //            else
                        //            {
                        //                if (variables.Battletask3.Used == false)
                        //                {
                        //                    SetText("label25", "战斗任务3");
                        //                    taskremove();
                        //                }
                        //                else
                        //                {


                        //                    Temptextbox = textBox15;
                        //                    variables.temptaskNo = 3;


                        //                    if (variables.Battletask3.TaskName == "魔方行动E4")
                        //                    {
                        //                        SetText("label25", variables.Battletask3.TaskName);
                        //                    }
                        //                    else
                        //                    {

                        //                        SetText("label25", variables.Battletask3.TaskName + "练级");
                        //                    }




                        //                    time.ChoseThebattle(dmae, mouse, variables.Battletask3.TaskName, variables.Battletask3.TaskMianTeam, variables.Battletask3.TaskSupportTeam, variables.Battletask3.ChoinceToFix, variables.Battletask3.ChoinceToSupply, variables.Battletask3.FixMaxTime, variables.Battletask3.FixMintime, variables.Battletask3.FixMaxPercentage, variables.Battletask3.FixMinPercentage, variables.Battletask3.TaskType, Battletask3.SetMap);
                        //                    SetText("textBox16", (Int32.Parse(textBox16.Text) + 1).ToString());
                        //                    taskremove();

                        //                    if (variables.Battletask3.ChangeGun == true) { variables.ChangeGunBattleTask = 3; taskadd(variables.ChangeGun); }

                        //                    if (variables.NeedToFix == true) { Task.Insert(0, Fix); }
                        //                    else
                        //                    {
                        //                        Random ran = new Random();
                        //                        int temp0 = ran.Next(0, Battletask3.RoundInterval);
                        //                        variables.BFIXT3 = temp0 + 1;
                        //                        ran = null;
                        //                    }

                        //                }

                        //            }
                        //            if (Battletask3.Used == false) { mouse.BindWindowS(dmae, 0); }
                        //            if (Battletask3.BattleLoopUnLockWindows == false) { mouse.BindWindowS(dmae, 0); }
                        //            break;
                        //        }
                        //    case "15":
                        //        {

                        //            if ((variables.RT1 > 0 && variables.RT1 < 10) || (variables.RT2 > 0 && variables.RT2 < 10) || (variables.RT3 > 0 && variables.RT3 < 10) || (variables.RT4 > 0 && variables.RT4 < 10))
                        //            {
                        //                taskadd(WaitForLogistics);
                        //                taskremove();
                        //                taskadd(Battle4);//泛型练级4
                        //            }
                        //            else
                        //            {
                        //                if (variables.Battletask4.Used == false)
                        //                {
                        //                    SetText("label26", "战斗任务4");
                        //                    taskremove();
                        //                }
                        //                else
                        //                {

                        //                    Temptextbox = textBox17;
                        //                    variables.temptaskNo = 4;

                        //                    if (variables.Battletask4.TaskName == "魔方行动E4")
                        //                    {
                        //                        SetText("label26", variables.Battletask4.TaskName);
                        //                    }
                        //                    else
                        //                    {

                        //                        SetText("label26", variables.Battletask4.TaskName + "练级");
                        //                    }



                        //                    time.ChoseThebattle(dmae, mouse, variables.Battletask4.TaskName, variables.Battletask4.TaskMianTeam, variables.Battletask4.TaskSupportTeam, variables.Battletask4.ChoinceToFix, variables.Battletask4.ChoinceToSupply, variables.Battletask4.FixMaxTime, variables.Battletask4.FixMintime, variables.Battletask4.FixMaxPercentage, variables.Battletask4.FixMinPercentage, variables.Battletask4.TaskType, Battletask4.SetMap);
                        //                    SetText("textBox18", (Int32.Parse(textBox18.Text) + 1).ToString());
                        //                    taskremove();

                        //                    if (variables.Battletask4.ChangeGun == true) { variables.ChangeGunBattleTask = 4; taskadd(variables.ChangeGun); }

                        //                    if (variables.NeedToFix == true) { Task.Insert(0, Fix); }
                        //                    else
                        //                    {
                        //                        Random ran = new Random();
                        //                        int temp0 = ran.Next(0, Battletask4.RoundInterval);
                        //                        variables.BFIXT4 = temp0 + 1;
                        //                        ran = null;
                        //                    }

                        //                }

                        //            }
                        //            if (Battletask4.Used == false) { mouse.BindWindowS(dmae, 0); }
                        //            if (Battletask4.BattleLoopUnLockWindows == false) { mouse.BindWindowS(dmae, 0); }
                        //            break;
                        //        }

                        //    case "16":
                        //        {

                        //            if ((variables.RT1 > 0 && variables.RT1 < 10) || (variables.RT2 > 0 && variables.RT2 < 10) || (variables.RT3 > 0 && variables.RT3 < 10) || (variables.RT4 > 0 && variables.RT4 < 10))
                        //            {
                        //                taskadd(WaitForLogistics);
                        //                taskremove();
                        //                taskadd(AutoBattle);//自律作战
                        //            }
                        //            else
                        //            {

                        //                Temptextbox = textBox19;
                        //                variables.temptaskNo = 5;
                        //                variables.AutoBattleTime = time.AutoBattle(dmae, mouse, Settings.Default.AutoMap, Settings.Default.AutoTeam1, Settings.Default.AutoTeam2, Settings.Default.AutoTeam3, Settings.Default.AutoTeam4);
                        //                SetText("textBox20", (Int32.Parse(textBox20.Text) + 1).ToString());
                        //                taskremove();

                        //            }
                        //            mouse.BindWindowS(dmae, 0);
                        //            break;
                        //        }
                        //    case "94"://回到游戏
                        //        {

                        //            break;
                        //        }
                        //    case "95"://1-2换枪
                        //        {

                        //            if ((variables.RT1 > 0 && variables.RT1 < 10) || (variables.RT2 > 0 && variables.RT2 < 10) || (variables.RT3 > 0 && variables.RT3 < 10) || (variables.RT4 > 0 && variables.RT4 < 10))
                        //            {
                        //                taskadd(WaitForLogistics);
                        //                taskremove();
                        //                taskadd(ChangeGun);//1-2换枪
                        //            }
                        //            else
                        //            {

                        //                //1-2换枪代码
                        //                switch (variables.ChangeGunBattleTask)
                        //                {
                        //                    case 1: { time.ChangeGun(dmae, mouse, Battletask1.TaskMianTeam, 1, 2, 3, 4, 5); break; }
                        //                    case 2: { time.ChangeGun(dmae, mouse, Battletask2.TaskMianTeam, 1, 2, 3, 4, 5); break; }
                        //                    case 3: { time.ChangeGun(dmae, mouse, Battletask3.TaskMianTeam, 1, 2, 3, 4, 5); break; }
                        //                    case 4: { time.ChangeGun(dmae, mouse, Battletask4.TaskMianTeam, 1, 2, 3, 4, 5); break; }

                        //                    default:
                        //                        break;
                        //                }

                        //                taskremove();

                        //            }
                        //            mouse.BindWindowS(dmae, 0);
                        //            break;
                        //        }

                        //    case "96"://拆除
                        //        {

                        //            if ((variables.RT1 > 0 && variables.RT1 < 10) || (variables.RT2 > 0 && variables.RT2 < 10) || (variables.RT3 > 0 && variables.RT3 < 10) || (variables.RT4 > 0 && variables.RT4 < 10))
                        //            {
                        //                taskadd(WaitForLogistics);
                        //                taskremove();
                        //                taskadd(variables.Dismantlement);//拆枪
                        //            }
                        //            else
                        //            {

                        //                //拆枪代码
                        //                time.DismantlementGun(dmae, mouse, DismantlementGunCount);
                        //                taskremove();

                        //            }
                        //            mouse.BindWindowS(dmae, 0);
                        //            break;
                        //        }

                        //    case "97":
                        //        {

                        //            if ((variables.RT1 > 0 && variables.RT1 < 10) || (variables.RT2 > 0 && variables.RT2 < 10) || (variables.RT3 > 0 && variables.RT3 < 10) || (variables.RT4 > 0 && variables.RT4 < 10))
                        //            {
                        //                taskadd(WaitForLogistics);
                        //                taskremove();
                        //                taskadd(Fix);
                        //            }
                        //            else
                        //            {
                        //                switch (variables.temptaskNo)
                        //                {
                        //                    case 1: { variables.BFIXT1 = time.Fix(dmae, mouse, ref ShowerTime, variables.Battletask1.FixType, variables.Battletask1.FixMaxTime, variables.Battletask1.FixMintime, Battletask1.FixMinPercentage, Battletask1.FixMaxPercentage, ref Temptextbox, Battletask1.RoundInterval); break; }
                        //                    case 2: { variables.BFIXT2 = time.Fix(dmae, mouse, ref ShowerTime, variables.Battletask2.FixType, variables.Battletask2.FixMaxTime, variables.Battletask2.FixMintime, Battletask2.FixMinPercentage, Battletask2.FixMaxPercentage, ref Temptextbox, Battletask2.RoundInterval); break; }
                        //                    case 3: { variables.BFIXT3 = time.Fix(dmae, mouse, ref ShowerTime, variables.Battletask3.FixType, variables.Battletask3.FixMaxTime, variables.Battletask3.FixMintime, Battletask3.FixMinPercentage, Battletask3.FixMaxPercentage, ref Temptextbox, Battletask3.RoundInterval); break; }
                        //                    case 4: { variables.BFIXT4 = time.Fix(dmae, mouse, ref ShowerTime, variables.Battletask4.FixType, variables.Battletask4.FixMaxTime, variables.Battletask4.FixMintime, Battletask4.FixMinPercentage, Battletask4.FixMaxPercentage, ref Temptextbox, Battletask4.RoundInterval); break; }

                        //                    default:
                        //                        break;
                        //                }


                        //                taskremove();

                        //            }
                        //            mouse.BindWindowS(dmae, 0);
                        //            break;
                        //        }


                        //    case "98":
                        //        {
                        //            Thread.Sleep(10000);
                        //            taskremove();
                        //            break;
                        //        }
                        //}
                }
        }





    }
    }




}
