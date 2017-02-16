using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GFHelper.Models;
using System.Threading;

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

    class CountDown
    {
        private InstanceManager im;
        public CountDown(InstanceManager im)
        {

            this.im = im;
        }
        public void countdown()//倒计时
        {
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

                if (im.data.user_operationInfo[0]._LastTime > -1)
                {
                    im.data.user_operationInfo[0]._LastTime = im.data.user_operationInfo[0]._LastTime - c;

                    if (Convert.ToInt32(im.data.user_operationInfo[0]._LastTime) == 0)
                    {

                    }
                }

                //if (variables.RT2 > -1)
                //{
                //    variables.RT2 = variables.RT2 - c;



                //    if (Convert.ToInt32(variables.RT2) == 0)
                //    {
                //        taskadd(ReceiveLogistics);
                //        taskadd(StartLogisticsTask2);
                //    }
                //}

                //if (variables.RT3 > -1)
                //{
                //    variables.RT3 = variables.RT3 - c;

                //    if (Convert.ToInt32(variables.RT3) == 0)
                //    {
                //        taskadd(ReceiveLogistics);
                //        taskadd(StartLogisticsTask3);
                //    }
                //}

                //if (variables.RT4 > -1)
                //{

                //    variables.RT4 = variables.RT4 - c;

                //    if (Convert.ToInt32(variables.RT4) == 0)
                //    {
                //        taskadd(ReceiveLogistics);
                //        taskadd(StartLogisticsTask4);
                //    }

                //}

                //if (ShowerTime[0] > -1)
                //{
                //    ShowerTime[0] -= c;
                //}
                //if (ShowerTime[1] > -1)
                //{
                //    ShowerTime[1] -= c;
                //}
                //if (ShowerTime[2] > -1)
                //{
                //    ShowerTime[2] -= c;
                //}
                //if (ShowerTime[3] > -1)
                //{
                //    ShowerTime[3] -= c;
                //}
                //if (ShowerTime[4] > -1)
                //{
                //    ShowerTime[4] -= c;
                //}
                //if (ShowerTime[5] > -1)
                //{
                //    ShowerTime[5] -= c;
                //}
                //if (variables.BFIXT1 > -1)
                //{
                //    variables.BFIXT1 = variables.BFIXT1 - c;
                //    if (Convert.ToInt32(variables.BFIXT1) == 0)
                //    {
                //        taskadd(Battle1);
                //    }
                //}

                //if (variables.BFIXT2 > -1)
                //{
                //    variables.BFIXT2 -= c;
                //    if (Convert.ToInt32(variables.BFIXT2) == 0)
                //    {
                //        taskadd(Battle2);
                //    }
                //}

                //if (variables.BFIXT3 > -1)
                //{
                //    variables.BFIXT3 -= c;
                //    if (Convert.ToInt32(variables.BFIXT3) == 0)
                //    {
                //        taskadd(Battle3);
                //    }
                //}

                //if (variables.BFIXT4 > -1)
                //{
                //    variables.BFIXT4 -= c;
                //    if (Convert.ToInt32(variables.BFIXT4) == 0)
                //    {
                //        taskadd(Battle4);
                //    }
                //}
                //if (variables.AutoBattleTime > -1)
                //{
                //    variables.AutoBattleTime -= c;
                //    if (Convert.ToInt32(variables.AutoBattleTime) == 0)
                //    {
                //        taskadd(AutoBattle);
                //    }
                //}

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

                Thread.Sleep(1000);
                //}
                //catch (Exception ex)
                //{
                //    WriteLog.WriteError("计时器发生错误 : " + ex.Message);
                //}

                //finally
                //{
                //}

                //sw.Reset();

            }
        }
    }




}
