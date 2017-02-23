﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Codeplex.Data;
using System.Windows.Controls;
using GFHelper.Models;
using System.Windows.Threading;

namespace GFHelper
{
    class UIHelper
    {
        private InstanceManager im;

        public UIHelper(InstanceManager im)
        {
            this.im = im;
        }

        public void addComboBoxText(ComboBox cb, string text)
        {
            im.mainWindow.Dispatcher.BeginInvoke(new Action(() =>
            {
                cb.Items.Add(text);
            }));

        }

        public void setStatusBarText(string text)
        {
            TextBlock tb = new TextBlock();
            tb.Text = ' ' + text;

            im.mainWindow.statusBar.Items.Clear();
            im.mainWindow.statusBar.Items.Add(tb);
        }

        public void setStatusBarText_InThread(string text)
        {
            im.mainWindow.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.setStatusBarText(text);
            }));

        }

        public void setTextBlockText(TextBlock tb, string text)
        {
            im.mainWindow.Dispatcher.BeginInvoke(new Action(() =>
            {
                tb.Text = text;

            }));
        }

        public void refreshListOperation()
        {
            im.mainWindow.Dispatcher.BeginInvoke(new Action(() =>
            {
                im.mainWindow.listViewOperation.Items.Refresh();
            }));
        }

        public void SetDevelopingTextBlock(int slot, out TextBlock textname, out TextBlock texttime, bool isEquip = false)
        {
            if (!isEquip)
            {
                switch (slot)
                {
                    case 1:
                        textname = im.mainWindow.textFactoryGunName1;
                        texttime = im.mainWindow.textFactoryGunTime1;
                        break;
                    case 2:
                        textname = im.mainWindow.textFactoryGunName2;
                        texttime = im.mainWindow.textFactoryGunTime2;
                        break;
                    case 3:
                        textname = im.mainWindow.textFactoryGunName3;
                        texttime = im.mainWindow.textFactoryGunTime3;
                        break;
                    case 4:
                        textname = im.mainWindow.textFactoryGunName4;
                        texttime = im.mainWindow.textFactoryGunTime4;
                        break;
                    case 5:
                        textname = im.mainWindow.textFactoryGunName5;
                        texttime = im.mainWindow.textFactoryGunTime5;
                        break;
                    case 6:
                        textname = im.mainWindow.textFactoryGunName6;
                        texttime = im.mainWindow.textFactoryGunTime6;
                        break;
                    case 7:
                        textname = im.mainWindow.textFactoryGunName7;
                        texttime = im.mainWindow.textFactoryGunTime7;
                        break;
                    case 8:
                        textname = im.mainWindow.textFactoryGunName8;
                        texttime = im.mainWindow.textFactoryGunTime8;
                        break;

                    default:
                        textname = im.mainWindow.textFactoryGunName1;
                        texttime = im.mainWindow.textFactoryGunTime1;
                        break;
                }
            }
            else
            {
                switch (slot)
                {
                    case 1:
                        textname = im.mainWindow.textFactoryEquipName1;
                        texttime = im.mainWindow.textFactoryEquipTime1;
                        break;
                    case 2:
                        textname = im.mainWindow.textFactoryEquipName2;
                        texttime = im.mainWindow.textFactoryEquipTime2;
                        break;
                    case 3:
                        textname = im.mainWindow.textFactoryEquipName3;
                        texttime = im.mainWindow.textFactoryEquipTime3;
                        break;
                    case 4:
                        textname = im.mainWindow.textFactoryEquipName4;
                        texttime = im.mainWindow.textFactoryEquipTime4;
                        break;
                    case 5:
                        textname = im.mainWindow.textFactoryEquipName5;
                        texttime = im.mainWindow.textFactoryEquipTime5;
                        break;
                    case 6:
                        textname = im.mainWindow.textFactoryEquipName6;
                        texttime = im.mainWindow.textFactoryEquipTime6;
                        break;
                    case 7:
                        textname = im.mainWindow.textFactoryEquipName7;
                        texttime = im.mainWindow.textFactoryEquipTime7;
                        break;
                    case 8:
                        textname = im.mainWindow.textFactoryEquipName8;
                        texttime = im.mainWindow.textFactoryEquipTime8;
                        break;

                    default:
                        textname = im.mainWindow.textFactoryEquipName1;
                        texttime = im.mainWindow.textFactoryEquipTime1;
                        break;
                }
            }
        }

        public void setDevelopingTimer(Timer timer, int slot, int id, int starttime, bool isEquip = false)
        {
            TextBlock texttime;
            TextBlock textname;

            slot = (slot + 1) / 2;
            this.SetDevelopingTextBlock(slot, out textname, out texttime, isEquip);

            string name;
            int duration;
            if (!isEquip)
            {
                name = Data.gunInfo[id].name;
                duration = Data.gunInfo[id].developDuration;
            }
            else
            {
                name = Data.equipInfo[id].name;
                duration = Data.equipInfo[id].developDuration;
            }
            this.setTextBlockText(textname, name);

            timer.AddTimerText(texttime, starttime, duration);
            timer.Start();
        }

        public void setFactoryTimerDefault(int slot, bool isEquip = false)
        {
            TextBlock textname, texttime;
            slot = (slot + 1) / 2;

            SetDevelopingTextBlock(slot, out textname, out texttime, isEquip);

            this.setTextBlockText(textname, "未使用");
            im.logger.Log(im.timer.GetType());
            im.timer.DeleteTimerWithTextBlock(texttime);
            this.setTextBlockText(texttime, CommonHelper.formatDuration(0));
        }

        public void setUserInfo()//ui更新
        {
            try
            {
                UserInfo userInfo = im.data.userInfo;
                im.mainWindow.Dispatcher.BeginInvoke(new Action(() =>
                {
                    //GridUserInfo
                    im.mainWindow.UserName.Text = userInfo.name;
                    im.mainWindow.UserLevel.Text = "Lv." + userInfo.level;

                    //GridResources
                    im.mainWindow.textammo.Text = userInfo.ammo.ToString();
                    im.mainWindow.textmre.Text = userInfo.mre.ToString();
                    im.mainWindow.textmp.Text = userInfo.mp.ToString();
                    im.mainWindow.textpart.Text = userInfo.part.ToString();
                    //items
                    //讲道理，难看
                    try
                    {
                        im.mainWindow.textitem1.Text = Convert.ToString(userInfo.item[1]);
                    }
                    catch (Exception) { im.mainWindow.textitem1.Text = "0"; }

                    try
                    {
                        im.mainWindow.textitem3.Text = Convert.ToString(userInfo.item[3]);
                    }
                    catch (Exception) { im.mainWindow.textitem3.Text = "0"; }

                    try
                    {
                        im.mainWindow.textitem4.Text = Convert.ToString(userInfo.item[4]);
                    }
                    catch (Exception) { im.mainWindow.textitem4.Text = "0"; }
                    try
                    {
                        im.mainWindow.textitem8.Text = Convert.ToString(userInfo.item[8]);
                    }
                    catch (Exception) { im.mainWindow.textitem8.Text = "0"; }



                    im.mainWindow.textDevelopSlot.Text = userInfo.maxDevelopSlot.ToString();
                    im.mainWindow.textFixSlot.Text = userInfo.maxFixSlot.ToString();
                    im.mainWindow.textUpgradeSlot.Text = userInfo.maxUpgradeSlot.ToString();

                    im.mainWindow.textGunNum.Text = String.Format("{0}/{1}", userInfo.gunWithUserID.Count, userInfo.maxGun);
                    im.mainWindow.textTeamNum.Text = userInfo.maxTeam.ToString();
                    im.mainWindow.textUnlockRatio.Text = ((int)((double)userInfo.listGunCollect.Count / (double)Data.gunInfo.Count * 100)).ToString() + "%";

                }));
            }
            catch (Exception e)
            {
                im.logger.Log(e);
                throw;
            }
        }

//        public void setUserOperation()
//        {
//            im.mainWindow.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(
//    () =>
//    {
//        int a = 0;
//        foreach (var item in im.data.user_operationInfo)
//        {
//            switch (a)
//            {
//                case 0: { im.mainWindow.comboBoxOperation1.SelectedIndex = item.Value._operationId - 1; break; }
//                case 1: { im.mainWindow.comboBoxOperation2.SelectedIndex = item.Value._operationId - 1; break; }
//                case 2: { im.mainWindow.comboBoxOperation3.SelectedIndex = item.Value._operationId - 1; break; }
//                case 3: { im.mainWindow.comboBoxOperation4.SelectedIndex = item.Value._operationId - 1; break; }
//                default:
//                    break;
//            }
//            a++;

//        }

//    }
//)
//);
//        }


        public void setUserOperationinfo()//每一秒刷新一次
        {
            im.mainWindow.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(
    () =>
    {
        int a = 0;
        foreach (var item in im.data.user_operationInfo)
        {
            switch (a)
            {
                case 0:
                    {
                        im.mainWindow.comboBoxOperationTeam1.SelectedIndex = item.Value._teamId - 1;
                        im.mainWindow.comboBoxOperation1.SelectedIndex = item.Value._operationId - 1;
                        if(item.Value._LastTime == -1)
                        {
                            im.mainWindow.operation_time1.Text = "   完成";
                        }
                        else
                        im.mainWindow.operation_time1.Text = CommonHelper.formatDuration(Convert.ToInt32(item.Value._LastTime));

                        break;
                    }
                case 1:
                    {
                        im.mainWindow.comboBoxOperationTeam2.SelectedIndex = item.Value._teamId - 1;
                        im.mainWindow.comboBoxOperation2.SelectedIndex = item.Value._operationId - 1;
                        if (item.Value._LastTime == -1)
                        {
                            im.mainWindow.operation_time2.Text = "   完成";
                        }
                        else
                            im.mainWindow.operation_time2.Text = CommonHelper.formatDuration(Convert.ToInt32(item.Value._LastTime));
                        break;
                    }
                case 2:
                    {
                        im.mainWindow.comboBoxOperationTeam3.SelectedIndex = item.Value._teamId - 1;
                        im.mainWindow.comboBoxOperation3.SelectedIndex = item.Value._operationId - 1;
                        if (item.Value._LastTime == -1)
                        {
                            im.mainWindow.operation_time3.Text = "   完成";
                        }
                        else
                            im.mainWindow.operation_time3.Text = CommonHelper.formatDuration(Convert.ToInt32(item.Value._LastTime));
                        break;
                    }
                case 3:
                    {
                        im.mainWindow.comboBoxOperationTeam4.SelectedIndex = item.Value._teamId - 1;
                        im.mainWindow.comboBoxOperation4.SelectedIndex = item.Value._operationId - 1;
                        if (item.Value._LastTime == -1)
                        {
                            im.mainWindow.operation_time4.Text = "   完成";
                        }
                        else
                            im.mainWindow.operation_time4.Text = CommonHelper.formatDuration(Convert.ToInt32(item.Value._LastTime));
                        break;
                    }
                default:
                    break;
            }
            a++;

        }

    }
)
);
        }


//        public void setUserOperationteam()
//        {
//            im.mainWindow.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(
//    () =>
//    {
//        int a = 0;
//        foreach (var item in im.data.user_operationInfo)
//        {
//            switch (a)
//            {
//                case 0: { im.mainWindow.comboBoxOperationTeam1.SelectedIndex = item.Value._teamId - 1; break; }
//                case 1: { im.mainWindow.comboBoxOperationTeam2.SelectedIndex = item.Value._teamId - 1; break; }
//                case 2: { im.mainWindow.comboBoxOperationTeam3.SelectedIndex = item.Value._teamId - 1; break; }
//                case 3: { im.mainWindow.comboBoxOperationTeam4.SelectedIndex = item.Value._teamId - 1; break; }
//                default:
//                    break;
//            }
//            a++;

//        }

//    }
//)
//);
//        }
        //public void operationinfocd()//委托修改UI控件
        //{
            
        //    im.mainWindow.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(
        //        () =>
        //    {
        //        int a = 0;
        //        foreach (var item in im.data.user_operationInfo)
        //        {
        //            switch (a)
        //            {
        //                case 0: { im.mainWindow.operation_time1.Text = CommonHelper.formatDuration(Convert.ToInt32(item.Value._LastTime));break; }
        //                case 1: { im.mainWindow.operation_time2.Text = CommonHelper.formatDuration(Convert.ToInt32(item.Value._LastTime)); break; }
        //                case 2: { im.mainWindow.operation_time3.Text = CommonHelper.formatDuration(Convert.ToInt32(item.Value._LastTime)); break; }
        //                case 3: { im.mainWindow.operation_time4.Text = CommonHelper.formatDuration(Convert.ToInt32(item.Value._LastTime)); break; }
        //                default:
        //                    break;
        //            }
        //            a++;
        //            //item.Value._LastTime = item.Value._LastTime - c;
        //        }

        //        //im.mainWindow.operation_time1.Text = CommonHelper.formatDuration(Convert.ToInt32(im.data.user_operationInfo[0]._LastTime));
        //        //im.mainWindow.operation_time2.Text = CommonHelper.formatDuration(Convert.ToInt32(im.data.user_operationInfo[1]._LastTime));
        //        //im.mainWindow.operation_time3.Text = CommonHelper.formatDuration(Convert.ToInt32(im.data.user_operationInfo[2]._LastTime));
        //        //im.mainWindow.operation_time4.Text = CommonHelper.formatDuration(Convert.ToInt32(im.data.user_operationInfo[3]._LastTime));

        //    }
        //    )
        //    );


        //}


    }
}
