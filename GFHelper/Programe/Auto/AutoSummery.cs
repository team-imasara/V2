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

                                            im.TaskList.Add(Programe.TaskList.Finish_Operation_Act1);
                                            break;
                                        }
                                    case 1:
                                        {
                                            im.TaskList.Add(Programe.TaskList.Finish_Operation_Act2);
                                            break;
                                        }
                                    case 2:
                                        {
                                            im.TaskList.Add(Programe.TaskList.Finish_Operation_Act3);
                                            break;
                                        }
                                    case 3:
                                        {
                                            im.TaskList.Add(Programe.TaskList.Finish_Operation_Act4);
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

                                            im.TaskList.Add(Programe.TaskList.Auto_Loop_Operation_Act1);
                                            break;
                                        }
                                    case 1:
                                        {
                                            im.TaskList.Add(Programe.TaskList.Auto_Loop_Operation_Act2);
                                            break;
                                        }
                                    case 2:
                                        {
                                            im.TaskList.Add(Programe.TaskList.Auto_Loop_Operation_Act3);
                                            break;
                                        }
                                    case 3:
                                        {
                                            im.TaskList.Add(Programe.TaskList.Auto_Loop_Operation_Act4);
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
                im.TaskList.Add(Programe.TaskList.Click_Kalina);
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
                        im.TaskList.Add(TaskList.Click_Girls_In_Dorm);
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
        public void Auto_Get_Battary_Friend()
        {
            DateTime BeijingTimeNow = CommonHelp.PSTConvertToGMT(DateTime.Now);
            //如果12点过了则添加Settings.Default.GetFriendBattleryDelayM

            //3点
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 3 + 1) && Time3AddGetFriendBattery == true)
            {
                im.TaskList.Add(TaskList.Get_Battary_Friend);
                Time3AddGetFriendBattery = false;
            }
            else
            {
                if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 3 + 1)
                    Time3AddGetFriendBattery = true;
            }

            //15点
            if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 15 + 1) && Time15AddGetFriendBattery == true)
            {
                im.TaskList.Add(TaskList.Get_Battary_Friend);

                Time15AddGetFriendBattery = false;
            }
            else
            {
                if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 15 + 1)
                    Time3AddGetFriendBattery = true;
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
                Auto_Get_Battary_Friend();
            }


        }
        



    }
}
