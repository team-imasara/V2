using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GFHelper.Programe.Auto
{
    class Auto_Summery
    {
        private InstanceManager im;
        public Auto_Summery(InstanceManager im)
        {
            this.im = im;
        }

        public bool LoginSuccessful = false;
        public bool NeedAuto_Loop_Operation_Act = true;
        public bool NeedAuto_Click_Girls_In_Dorm = true;//这些都需要 read userinfo 重置
        public bool Time3AddGetFriendBattery = true;//3点收电池  不需要read userinfo重置
        public bool Time15AddGetFriendBattery = true;
        public bool Time11AddGetMineBattery = true;
        public bool Time17AddGetFriendBattery = true;
        //卡琳娜可点击数

        public void Auto_Loop_Start_Finish_Operation_Act()
        {
            //检查UI上的总开关
            if (this.NeedAuto_Loop_Operation_Act == false) return;
            try
            {
                for(int i = 0; i < im.Dic_auto_operation_act.Count; i++)
                {

                    if(string.IsNullOrEmpty(im.Dic_auto_operation_act[i].id.ToString()) == true)
                    {
                        continue;
                    }
                    if(im.Dic_auto_operation_act[i].remaining_time < 0)
                    {
                        if(im.Dic_auto_operation_act[i].Added==false)//确保任务队列只添加一次
                        {
                            if (this.NeedAuto_Loop_Operation_Act == false)//只接收不循环
                            {
                                switch (i)
                                {
                                    case 0:
                                        {

                                            ProgrameData.TaskList.Add(Programe.TaskList.Finish_Operation_Act1);
                                            break;
                                        }
                                    case 1:
                                        {
                                            ProgrameData.TaskList.Add(Programe.TaskList.Finish_Operation_Act2);
                                            break;
                                        }
                                    case 2:
                                        {
                                            ProgrameData.TaskList.Add(Programe.TaskList.Finish_Operation_Act3);
                                            break;
                                        }
                                    case 3:
                                        {
                                            ProgrameData.TaskList.Add(Programe.TaskList.Finish_Operation_Act4);
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (i)
                                {
                                    case 0:
                                        {

                                            ProgrameData.TaskList.Add(Programe.TaskList.Auto_Loop_Operation_Act1);
                                            break;
                                        }
                                    case 1:
                                        {
                                            ProgrameData.TaskList.Add(Programe.TaskList.Auto_Loop_Operation_Act2);
                                            break;
                                        }
                                    case 2:
                                        {
                                            ProgrameData.TaskList.Add(Programe.TaskList.Auto_Loop_Operation_Act3);
                                            break;
                                        }
                                    case 3:
                                        {
                                            ProgrameData.TaskList.Add(Programe.TaskList.Auto_Loop_Operation_Act4);
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }



                            im.Dic_auto_operation_act[i].Added = true;
                        }

                    }
                    else
                    {
                        im.Dic_auto_operation_act[i].Added = false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("自动后勤出错");
                MessageBox.Show(e.ToString());
                //看总开关有throw和不理两种情况
                throw;
            }



        }

        public void Auto_Click_Kalina()
        {
            if(im.userdatasummery.kalina_with_user_info.click_num < 5)
            {
                ProgrameData.TaskList.Add(Programe.TaskList.Click_Kalina);
                im.userdatasummery.kalina_with_user_info.click_num++;
            }
        }
        public void Auto_Click_Girls_In_Dorm()
        {
            if (NeedAuto_Click_Girls_In_Dorm == false) return;
            foreach (var k in im.userdatasummery.team_info)
            {
                foreach (var x in k.Value)
                {
                    if (x.Value.can_click == 1)
                    {
                        ProgrameData.TaskList.Add(TaskList.Click_Girls_In_Dorm);
                        NeedAuto_Click_Girls_In_Dorm = false;
                        return;
                    }
                }
            }


        }

        public void Auto_Get_Material()
        {
            if (im.userdatasummery.user_info.material_available_num1 > 0)
            {
                //lalala
            }


        }

        //好友电池
        public void Auto_Get_Battary()
        {
            DateTime BeijingTimeNow = CommonHelp.LocalDateTimeConvertToChina(DateTime.Now);
            //如果12点过了则添加Settings.Default.GetFriendBattleryDelayM

            //3点
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 3 + 1) && Time3AddGetFriendBattery == true)
            {
                ProgrameData.TaskList.Add(TaskList.Get_Battary_Friend);
                Time3AddGetFriendBattery = false;
            }
            else
            {
                if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 3 + 1)
                    Time3AddGetFriendBattery = true;
            }

            //11点
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 15 + 1) && Time15AddGetFriendBattery == true)
            {
                ProgrameData.TaskList.Add(TaskList.Get_Battary_Friend);

                Time15AddGetFriendBattery = false;
            }
            else
            {
                if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 15 + 1)
                    Time3AddGetFriendBattery = true;
            }

            if(BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 11 + 1) && Time11AddGetMineBattery == true)
            {
                ProgrameData.TaskList.Add(TaskList.Get_Dorm_Info);
                ProgrameData.TaskList.Add(TaskList.Get_Battary_Mine);
                Time11AddGetMineBattery = false;
            }
            else
            {
                if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 11 + 1)
                    Time11AddGetMineBattery = true;
            }

            //17点
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 17 + 1) && Time17AddGetFriendBattery == true)
            {

                ProgrameData.TaskList.Add(TaskList.Get_Dorm_Info);
                ProgrameData.TaskList.Add(TaskList.Get_Battary_Mine);
                Time17AddGetFriendBattery = false;
            }
            else
            {
                if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 17 + 1)
                    Time17AddGetFriendBattery = true;
            }
        }

        public void Auto_Simulation_Battle()
        {
            if (ProgrameData.AutoSimulationBattleF == false) return;
            //决定哪种模式
            int day = (int)CommonHelp.LocalDateTimeConvertToChina(DateTime.Now).DayOfWeek;
            if (day==1 || day== 3 || day == 4 || day == 6)
            {
                if (im.userdatasummery.user_info.bp >= 5)
                {
                    ProgrameData.TaskList.Add(TaskList.Start_Trial);
                    im.userdatasummery.user_info.bp -= 5;
                }
            }
            if(day == 2 || day == 5 || day == 0)
            {
                switch (im.userdatasummery.usbti.Type)
                {
                    case 1:
                        {
                            if (im.userdatasummery.user_info.bp >= 1)
                            {
                                ProgrameData.TaskList.Add(TaskList.Simulation_DATA);
                                im.userdatasummery.user_info.bp -= 1;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (im.userdatasummery.user_info.bp >= 2)
                            {
                                ProgrameData.TaskList.Add(TaskList.Simulation_DATA);
                                im.userdatasummery.user_info.bp -= 2;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (im.userdatasummery.user_info.bp >= 3)
                            {
                                ProgrameData.TaskList.Add(TaskList.Simulation_DATA);
                                im.userdatasummery.user_info.bp -= 3;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }


        }


        public void BP_Recover()
        {
            if (im.userdatasummery.user_info.bp >= 6)
            {
                return;
            }


            if ((im.userdatasummery.user_info.last_bp_recover_time + 7200+600) < (CommonHelp.ConvertDateTime_China_Int(DateTime.Now)))//600是延迟10分钟
            {
                //如果上次恢复时间到现在当前时间差距大于两个小时 则 发送请求 
                ProgrameData.TaskList.Add(TaskList.GetRecoverBp);
                im.userdatasummery.user_info.last_bp_recover_time = CommonHelp.ConvertDateTime_China_Int(DateTime.Now);
            }

        }

        public void WriteReportFinish()
        {
            if (im.BattleReport.isFinish && im.BattleReport.isUsing)
            {
                ProgrameData.TaskList.Add(TaskList.BattleReport_Finish);
            }
        }

        /// <summary>
        /// 每日零点刷新
        /// </summary>
        public void DailyReFlash()
        {
            if (CommonHelp.ConvertDateTime_China_Int(DateTime.Now) > ProgrameData.tomorrow_zero+600)//600是延迟10分钟
            {
                ProgrameData.tomorrow_zero = 2101948800;
                ProgrameData.TaskList.Add(TaskList.Login);
            }
            return;
        }

        public void BattleTaskLoop()
        {
            for(int i = 0; i <= 5; i++)
            {
                if (im.dic_userbattletaskinfo.ContainsKey(i))
                {
                    if (im.dic_userbattletaskinfo[i].reStart_WaitTime > 0)
                    {
                        im.dic_userbattletaskinfo[i].reStart_WaitTime--;
                    }
                    if(im.dic_userbattletaskinfo[i].reStart_WaitTime<=0 && im.dic_userbattletaskinfo[i].TaskList_ADD == false)
                    {
                        switch (i)
                        {
                            case 0:
                                {
                                    ProgrameData.TaskList.Add(Programe.TaskList.TaskBattle_1);
                                    break;
                                }
                            case 1:
                                {
                                    ProgrameData.TaskList.Add(Programe.TaskList.TaskBattle_2);
                                    break;
                                }
                            case 2:
                                {
                                    ProgrameData.TaskList.Add(Programe.TaskList.TaskBattle_3);
                                    break;
                                }
                            case 3:
                                {
                                    ProgrameData.TaskList.Add(Programe.TaskList.TaskBattle_4);
                                    break;
                                }

                            default:
                                break;
                        }
                        im.dic_userbattletaskinfo[i].TaskList_ADD = true;
                    }
                }
            }
        }

        //总的循环
        public void Auto_Act_Summery()
        {
            if (LoginSuccessful == true)
            {
                //后勤
                Auto_Loop_Start_Finish_Operation_Act();
                //格琳娜
                Auto_Click_Kalina();
                Auto_Click_Girls_In_Dorm();
                //好友电池
                Auto_Get_Battary();
                //模拟作战
                Auto_Simulation_Battle();
                //动能点数恢复
                BP_Recover();
                //每日零点刷新
                DailyReFlash();
                WriteReportFinish();
            }
        }


        



    }
}
