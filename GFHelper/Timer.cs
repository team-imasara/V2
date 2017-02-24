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
        public void UIupdate()//倒计时
        {
            //Stopwatch sw = new Stopwatch();
            while (true)
            {

                //sw.Start();

                //消除第一空余第二任务的BUG
                //if (Task.ElementAt(0).TaskNumber == 0)
                //{
                //    if (Task.ElementAt(1).TaskNumber != 0)
                //    {
                //        Task.RemoveAt(1);
                //    }
                //}
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

            bool Readuserinfo = true;
            int a = 0;
            im.data.tasklist.Add(0);
            while (true)
            {

                Thread.Sleep(100);

                if(im.data.tasklist[0] == 0)
                {
                    //check
                    lock (im.user_operationInfoLocker)//锁
                    {
                        foreach (var item in im.data.user_operationInfo)
                        {
                            if (CommonHelper.ConvertDateTimeInt(DateTime.Now) > (item.Value.startTime + item.Value._durationTime + SimpleInfo.autoStartOperationRandomDelay))//+5s
                            {
                                if (item.Value.needStartOperation == true)
                                {
                                    a = 1;
                                    item.Value._durationTime = 0;
                                    im.data.tasklistadd(9);
                                    im.data.tasklistadd(8);
                                    im.data.tasklistadd(2);
                                    //小于1分钟就不读取getuserinfo
                                    foreach (var item1 in im.data.user_operationInfo)
                                    {
                                        if (item1.Value._operationId != item.Value._operationId)//检查非自己本身其他的后勤任务如果剩余时间剩下30秒自定义则取消readuserinfo
                                        {
                                            if (item1.Value._LastTime > 30)//自定义
                                            {
                                                ;
                                            }
                                            else
                                            {
                                                Readuserinfo = false;
                                                break;
                                            }
                                        }

                                    }
                                    if (Readuserinfo == true)
                                    {
                                        im.data.tasklistadd(2);
                                    }
                                }
                            }
                            if (item.Value._LastTime >= 0)
                            {
                                item.Value.SetLastTime();//获取剩余时间
                            }
                        }
                        if (a == 1)
                        {
                            //im.data.tasklistadd(2);//getuserinfo
                            SimpleInfo.LoginStartOperation = true;
                            a = 0;
                        }
                    }
                }
                else
                {
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
                                int team_id, operation_id;
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

                    }
                }
                
                



            }





    }
    }




}
