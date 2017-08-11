using GFHelper.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GFHelper.Programe
{
    /// <summary>
    /// UIHelp之和刷新UI有关
    /// </summary>
    class UIHelp
    {
        public InstanceManager im;
        public UIHelp(InstanceManager im)
        {
            this.im = im;
        }

        public static int ShowTeamID = 1;

        public  void MainWindowTitle()
        {
            if (im.TaskList.Any())
            {
                im.mainWindow.Title = string.Format(" 少女前线-暗 当前任务 " + im.TaskList[0].TaskName.ToString());
            }
            else
            {
                im.mainWindow.Title = string.Format(" 少女前线-暗 当前任务 空闲");
            }

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

        public void setUserInfo()//ui更新
        {
            try
            {

                //User_Info userInfo = new User_Info();
                //Dictionary<int, Item_With_User_Info> item_with_user_info = new Dictionary<int, Item_With_User_Info>();

                //userInfo = im.userdatasummery.user_info;
                //item_with_user_info = im.userdatasummery.item_with_user_info;

                im.mainWindow.Dispatcher.BeginInvoke(new Action(() =>
                {
                    //GridUserInfo
                    im.mainWindow.UserName.Text = im.userdatasummery.user_info.name;
                    im.mainWindow.UserLevel.Text = "Lv." + im.userdatasummery.user_info.lv.ToString();

                    //GridResources
                    im.mainWindow.textammo.Text = im.userdatasummery.user_info.ammo.ToString();
                    im.mainWindow.textmre.Text = im.userdatasummery.user_info.mre.ToString();
                    im.mainWindow.textmp.Text = im.userdatasummery.user_info.mp.ToString();
                    im.mainWindow.textpart.Text = im.userdatasummery.user_info.part.ToString();
                    //items
                    //讲道理，难看
                    try
                    {
                        int findKey = -1;
                        foreach (var item in im.userdatasummery.item_with_user_info)
                        {
                            if (item.Value.item_id == 1)
                            {
                                findKey = item.Key;
                                break;
                            }
                        }
                        im.mainWindow.textitem1.Text = Convert.ToString(im.userdatasummery.item_with_user_info[findKey].number);//人形制造契约:item_with_user_info
                    }
                    catch (Exception) { im.mainWindow.textitem1.Text = "0"; }

                    try
                    {
                        int findKey = -1;
                        foreach (var item in im.userdatasummery.item_with_user_info)
                        {
                            if (item.Value.item_id == 3)
                            {
                                findKey = item.Key;
                                break;
                            }
                        }
                        im.mainWindow.textitem3.Text = Convert.ToString(im.userdatasummery.item_with_user_info[findKey].number);//快速制造契约: 
                    }
                    catch (Exception) { im.mainWindow.textitem3.Text = "0"; }

                    try
                    {
                        int findKey = -1;
                        foreach (var item in im.userdatasummery.item_with_user_info)
                        {
                            if (item.Value.item_id == 4)
                            {
                                findKey = item.Key;
                                break;
                            }
                        }
                        im.mainWindow.textitem4.Text = Convert.ToString(im.userdatasummery.item_with_user_info[findKey].number);
                    }
                    catch (Exception) { im.mainWindow.textitem4.Text = "0"; }
                    try
                    {
                        int findKey = -1;
                        foreach (var item in im.userdatasummery.item_with_user_info)
                        {
                            if (item.Value.item_id == 8)
                            {
                                findKey = item.Key;
                                break;
                            }
                        }
                        im.mainWindow.textitem8.Text = Convert.ToString(im.userdatasummery.item_with_user_info[findKey].number);
                    }
                    catch (Exception) { im.mainWindow.textitem8.Text = "0"; }
                    try
                    {
                        int findKey = -1;
                        foreach (var item in im.userdatasummery.item_with_user_info)
                        {
                            if (item.Value.item_id == 2)
                            {
                                findKey = item.Key;
                                break;
                            }
                        }
                        im.mainWindow.textEquipBuiltNum.Text = Convert.ToString(im.userdatasummery.item_with_user_info[findKey].number);
                    }
                    catch (Exception) { im.mainWindow.textitem8.Text = "0"; }



                    im.mainWindow.textDevelopSlot.Text = im.userdatasummery.user_info.max_build_slot.ToString();//建造槽
                    im.mainWindow.textFixSlot.Text = im.userdatasummery.user_info.max_fix_slot.ToString();
                    im.mainWindow.textUpgradeSlot.Text = im.userdatasummery.user_info.max_upgrade_slot.ToString();

                    im.mainWindow.textGunNum.Text = String.Format("{0}/{1}", im.userdatasummery.user_info.gun_collect.Count, im.userdatasummery.user_info.maxgun);
                    im.mainWindow.textTeamNum.Text = im.userdatasummery.user_info.maxteam.ToString();
                    im.mainWindow.textUnlockRatio.Text = ((int)((double)im.userdatasummery.user_info.gun_collect.Count / (double)im.catchdatasummery.gun_info.Count * 100)).ToString() + "%";




                    //
                    //im.userdatasummery.kalina_with_user_info
                    im.mainWindow.textDevelopSlot1.Text = im.userdatasummery.kalina_with_user_info.level.ToString();//建造槽
                    im.mainWindow.textFixSlot1.Text = im.userdatasummery.kalina_with_user_info.favor.ToString();

                    //item_with_user_info
                    im.mainWindow.textEquipNum.Text = String.Format("{0}/{1}", im.userdatasummery.equip_with_user_info.Count, im.userdatasummery.user_info.maxequip);
                    im.mainWindow.textEquipRank5Num1.Text = im.userdatasummery.Rank5EquipmentN.ToString();

                    //friend_with_user_info
                    im.mainWindow.textFriendNum.Text = String.Format("{0}/50", im.userdatasummery.friend_with_user_info.Count);
                    im.mainWindow.textFriendLv.Text = im.userdatasummery.GetFriendLv().ToString();

                    //研究点数 初级中级高级
                    im.mainWindow.textCoin1Num.Text = im.userdatasummery.user_info.coin1.ToString();
                    im.mainWindow.textCoin2Num.Text = im.userdatasummery.user_info.coin2.ToString();
                    im.mainWindow.textCoin3Num.Text = im.userdatasummery.user_info.coin3.ToString();

                    //钻石电池
                    im.mainWindow.textGemNum.Text = im.userdatasummery.user_info.gem.ToString();
                    im.mainWindow.textBatteryNum.Text = im.userdatasummery.GetBatteryNum().ToString();

                    //基础动能超导动能
                    im.mainWindow.textBPnum.Text = im.userdatasummery.user_info.bp.ToString();
                    im.mainWindow.textBP_PayNUM.Text = im.userdatasummery.user_info.bp_pay.ToString();

                    //采购币 兑换卷
                    im.mainWindow.textFurniture_CoinNum.Text = im.userdatasummery.GetFurniture_CoinNum().ToString();
                    im.mainWindow.textExchange_CoinNum.Text = im.userdatasummery.GetExchange_CoinNum().ToString();

                }));
            }
            catch (Exception e)
            {
                MessageBox.Show("UI更新userinfo出错");
                MessageBox.Show(e.ToString());
            }
        }

        public void SetTeamInfo_In_Operation()//设置队伍信息
        {
            im.mainWindow.Dispatcher.Invoke(() =>
            {
                im.mainWindow.comboBoxOperationTeam1.Items.Clear();
                im.mainWindow.comboBoxOperationTeam2.Items.Clear();
                im.mainWindow.comboBoxOperationTeam3.Items.Clear();
                im.mainWindow.comboBoxOperationTeam4.Items.Clear();
            });
            try
            {
                im.mainWindow.Dispatcher.Invoke(() =>
                {
                    //public Dictionary<int, Dictionary<int, Gun_With_User_Info>> team_info = new Dictionary<int, Dictionary<int, Gun_With_User_Info>>();//没读一次user_info都需要刷新
                    //需要表示当前梯队的队长的核心id
                    foreach (var i in im.userdatasummery.team_info)
                    {
                        var item = i.Value;//i.Value ==  Dictionary<int, Gun_With_User_Info>
                        if (item.Values.Count == 0) { continue; }
                        string itemtext;
                        //找队长
                        int TeamLeaderID=1;
                        foreach (var x in item.Values)
                        {
                            if(x.location == 1) { TeamLeaderID = x.gun_id; }
                        }
                        //在catchdata里找对应的枪
                        string NameInCatchData = "";
                        foreach (var k in im.catchdatasummery.gun_info)
                        {
                            if (TeamLeaderID == k.Value.id) NameInCatchData = k.Value.en_name;
                        }


                        itemtext = String.Format("梯队{0}({1})", i.Key, NameInCatchData);
                        im.uihelp.addComboBoxText(im.mainWindow.comboBoxOperationTeam1, itemtext);
                        im.uihelp.addComboBoxText(im.mainWindow.comboBoxOperationTeam2, itemtext);
                        im.uihelp.addComboBoxText(im.mainWindow.comboBoxOperationTeam3, itemtext);
                        im.uihelp.addComboBoxText(im.mainWindow.comboBoxOperationTeam4, itemtext);
                    }
                });


            }
            catch (Exception e )
            {
                MessageBox.Show("后勤梯队UI更新出错");
                MessageBox.Show(e.ToString());

            }




        }

        /// <summary>
        /// 设置后勤信息
        /// </summary>
        /// 
        public void SetOperationInfo()//设置后勤信息
        {
            im.mainWindow.Dispatcher.Invoke(() =>
            {
                im.mainWindow.comboBoxOperation1.Items.Clear();
                im.mainWindow.comboBoxOperation2.Items.Clear();
                im.mainWindow.comboBoxOperation3.Items.Clear();
                im.mainWindow.comboBoxOperation4.Items.Clear();
            });

            im.mainWindow.Dispatcher.Invoke(() =>
            {
                for (int i = 0; i < im.catchdatasummery.operation_info.Count; ++i)
                {
                    var item = im.catchdatasummery.operation_info[i];
                    string itemtext;
                    itemtext = String.Format("{0}({1}-{2})",item.name, (int)((item.id - 1) / 4), (int)((item.id - 1) % 4) + 1);

                    im.uihelp.addComboBoxText(im.mainWindow.comboBoxOperation1, itemtext);
                    im.uihelp.addComboBoxText(im.mainWindow.comboBoxOperation2, itemtext);
                    im.uihelp.addComboBoxText(im.mainWindow.comboBoxOperation3, itemtext);
                    im.uihelp.addComboBoxText(im.mainWindow.comboBoxOperation4, itemtext);
            }
            });


        }

        //设置BP回复点数的时间
        public void SetBPTime_Recover()
        {
            if ((CommonHelp.ConvertDateTime_China_Int(DateTime.Now) - im.userdatasummery.user_info.last_bp_recover_time) > 7200) return;

            im.mainWindow.BP_RecoverTime.Content = CommonHelp.formatDuration((CommonHelp.ConvertDateTime_China_Int(DateTime.Now) - im.userdatasummery.user_info.last_bp_recover_time)).ToString();


        }

        /// <summary>
        /// 后勤控件处理 梯队 任务 框 和按钮
        /// </summary>
        public void setUI_User_info()//每一秒刷新一次
        {
            im.mainWindow.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(
    () =>
    {
        //基础动能超导动能
        im.mainWindow.textBPnum.Text = im.userdatasummery.user_info.bp.ToString();
        im.mainWindow.textBP_PayNUM.Text = im.userdatasummery.user_info.bp_pay.ToString();
        //动能点数倒数时间
        SetBPTime_Recover();
        for(int k = 0; k < 4; k++)
        {
            switch (k)
            {
                case 0:
                    {
                        im.mainWindow.comboBoxOperationTeam1.SelectedIndex = im.Dic_auto_operation_act[k].team_id - 1;
                        im.mainWindow.comboBoxOperation1.SelectedIndex = im.Dic_auto_operation_act[k].operation_id - 1;
                        if (im.Dic_auto_operation_act[k].remaining_time <= 0)
                        {
                            im.mainWindow.operation_time1.Text = "   完成";
                            im.mainWindow.AutoOperationB_S1.Content = "任务开始";
                            im.mainWindow.comboBoxOperationTeam1.IsEnabled = true;
                            im.mainWindow.comboBoxOperation1.IsEnabled = true;

                        }
                        else
                        {
                            im.mainWindow.operation_time1.Text = CommonHelp.formatDuration(Convert.ToInt32(im.Dic_auto_operation_act[k].remaining_time));

                            im.mainWindow.comboBoxOperationTeam1.IsEnabled = false;
                            im.mainWindow.comboBoxOperation1.IsEnabled = false;
                            im.mainWindow.AutoOperationB_S1.Content = "任务终止";
                        }


                        break;
                    }
                case 1:
                    {
                        im.mainWindow.comboBoxOperationTeam2.SelectedIndex = im.Dic_auto_operation_act[k].team_id - 1;
                        im.mainWindow.comboBoxOperation2.SelectedIndex = im.Dic_auto_operation_act[k].operation_id - 1;
                        if (im.Dic_auto_operation_act[k].remaining_time <= 0)
                        {
                            im.mainWindow.operation_time2.Text = "   完成";
                            im.mainWindow.AutoOperationB_S2.Content = "任务开始";
                            im.mainWindow.comboBoxOperationTeam2.IsEnabled = true;
                            im.mainWindow.comboBoxOperation2.IsEnabled = true;
                        }
                        else
                        {
                            im.mainWindow.operation_time2.Text = CommonHelp.formatDuration(Convert.ToInt32(im.Dic_auto_operation_act[k].remaining_time));
                            im.mainWindow.AutoOperationB_S2.Content = "任务终止";
                            im.mainWindow.comboBoxOperationTeam2.IsEnabled = false;
                            im.mainWindow.comboBoxOperation2.IsEnabled = false;
                        }

                        break;
                    }
                case 2:
                    {
                        im.mainWindow.comboBoxOperationTeam3.SelectedIndex = im.Dic_auto_operation_act[k].team_id - 1;
                        im.mainWindow.comboBoxOperation3.SelectedIndex = im.Dic_auto_operation_act[k].operation_id - 1;
                        if (im.Dic_auto_operation_act[k].remaining_time <= 0)
                        {
                            im.mainWindow.operation_time3.Text = "   完成";
                            im.mainWindow.AutoOperationB_S3.Content = "任务开始";
                            im.mainWindow.comboBoxOperationTeam3.IsEnabled = true;
                            im.mainWindow.comboBoxOperation3.IsEnabled = true;
                        }
                        else
                        {
                            im.mainWindow.AutoOperationB_S3.Content = "任务终止";
                            im.mainWindow.comboBoxOperationTeam3.IsEnabled = false;
                            im.mainWindow.comboBoxOperation3.IsEnabled = false;
                            im.mainWindow.operation_time3.Text = CommonHelp.formatDuration(Convert.ToInt32(im.Dic_auto_operation_act[k].remaining_time));
                        }

                        break;
                    }
                case 3:
                    {
                        im.mainWindow.comboBoxOperationTeam4.SelectedIndex = im.Dic_auto_operation_act[k].team_id - 1;
                        im.mainWindow.comboBoxOperation4.SelectedIndex = im.Dic_auto_operation_act[k].operation_id - 1;

                        if (im.Dic_auto_operation_act[k].remaining_time <= 0)
                        {
                            im.mainWindow.operation_time4.Text = "   完成";
                            im.mainWindow.AutoOperationB_S4.Content = "任务开始";
                            im.mainWindow.comboBoxOperationTeam4.IsEnabled = true;
                            im.mainWindow.comboBoxOperation4.IsEnabled = true;
                        }
                        else
                        {
                            im.mainWindow.operation_time4.Text = CommonHelp.formatDuration(Convert.ToInt32(im.Dic_auto_operation_act[k].remaining_time));
                            im.mainWindow.AutoOperationB_S4.Content = "任务终止";
                            im.mainWindow.comboBoxOperationTeam4.IsEnabled = false;
                            im.mainWindow.comboBoxOperation4.IsEnabled = false;
                        }

                        break;
                    }
                default:
                    break;
            }

        }

        if (im.mainWindow.AutoOperation_CheckBox.IsChecked == false)
        {
            im.mainWindow.AutoOperationB_S1.IsEnabled = true;
            im.mainWindow.AutoOperationB_S2.IsEnabled = true;
            im.mainWindow.AutoOperationB_S3.IsEnabled = true;
            im.mainWindow.AutoOperationB_S4.IsEnabled = true;
        }
        else
        {
            im.mainWindow.AutoOperationB_S1.IsEnabled = false;
            im.mainWindow.AutoOperationB_S2.IsEnabled = false;
            im.mainWindow.AutoOperationB_S3.IsEnabled = false;
            im.mainWindow.AutoOperationB_S4.IsEnabled = false;
        }
        im.uihelp.MainWindowTitle();
    }
)
);
        }



        public void setTeamInfo_In_Formation()
        {
            //传入一个梯队
            //不需要进入刷新线程
            setTeamName_In_Formation();
            setTeamInOperation_In_Formation();
            Dictionary<int, Gun_With_User_Info> team_info = new Dictionary<int, Gun_With_User_Info>();
            //如果是空则退出
            if(im.userdatasummery.team_info[ShowTeamID].Count == 0)
            {
                im.mainWindow.Gun1Name.Content = "人形";
                im.mainWindow.Gun1Lv.Content = "N/A";
                im.mainWindow.Gun1Exp.Content = "N/A";
                im.mainWindow.Gun1Hp.Content = "N/A";

                im.mainWindow.Gun2Name.Content = "人形";
                im.mainWindow.Gun2Lv.Content = "N/A";
                im.mainWindow.Gun2Exp.Content = "N/A";
                im.mainWindow.Gun2Hp.Content = "N/A";

                im.mainWindow.Gun3Name.Content = "人形";
                im.mainWindow.Gun3Lv.Content = "N/A";
                im.mainWindow.Gun3Exp.Content = "N/A";
                im.mainWindow.Gun3Hp.Content = "N/A";

                im.mainWindow.Gun4Name.Content = "人形";
                im.mainWindow.Gun4Lv.Content = "N/A";
                im.mainWindow.Gun4Exp.Content = "N/A";
                im.mainWindow.Gun4Hp.Content = "N/A";

                im.mainWindow.Gun5Name.Content = "人形";
                im.mainWindow.Gun5Lv.Content = "N/A";
                im.mainWindow.Gun5Exp.Content = "N/A";
                im.mainWindow.Gun5Hp.Content = "N/A";

            }
            team_info = im.userdatasummery.team_info[ShowTeamID];
            im.mainWindow.Dispatcher.Invoke(() =>
            {
                //public Dictionary<int, Dictionary<int, Gun_With_User_Info>> team_info = new Dictionary<int, Dictionary<int, Gun_With_User_Info>>();//没读一次user_info都需要刷新
                //需要表示当前梯队的队长的核心id
                //Dictionary<int,Gun_With_User_Info> team_info 是一个梯队 int 0 是队长
                foreach (var item in team_info)
                {
                    switch (item.Value.location)
                    {
                        case 1:
                            {
                                //队长
                                im.mainWindow.Gun1Name.Content = im.userdatasummery.FindGunName_GunId(item.Value.gun_id);
                                im.mainWindow.Gun1Lv.Content = item.Value.gun_level;
                                im.mainWindow.Gun1Exp.Content = item.Value.gun_exp;
                                im.mainWindow.Gun1Hp.Content = item.Value.life;
                                break;
                            }
                        case 2:
                            {
                                //队长
                                im.mainWindow.Gun2Name.Content = im.userdatasummery.FindGunName_GunId(item.Value.gun_id);
                                im.mainWindow.Gun2Lv.Content = item.Value.gun_level;
                                im.mainWindow.Gun2Exp.Content = item.Value.gun_exp;
                                im.mainWindow.Gun2Hp.Content = item.Value.life;
                                break;
                            }
                        case 3:
                            {
                                //队长
                                im.mainWindow.Gun3Name.Content = im.userdatasummery.FindGunName_GunId(item.Value.gun_id);
                                im.mainWindow.Gun3Lv.Content = item.Value.gun_level;
                                im.mainWindow.Gun3Exp.Content = item.Value.gun_exp;
                                im.mainWindow.Gun3Hp.Content = item.Value.life;
                                break;
                            }
                        case 4:
                            {
                                //队长
                                im.mainWindow.Gun4Name.Content = im.userdatasummery.FindGunName_GunId(item.Value.gun_id);
                                im.mainWindow.Gun4Lv.Content = item.Value.gun_level;
                                im.mainWindow.Gun4Exp.Content = item.Value.gun_exp;
                                im.mainWindow.Gun4Hp.Content = item.Value.life;
                                break;
                            }
                        case 5:
                            {
                                //队长
                                im.mainWindow.Gun5Name.Content = im.userdatasummery.FindGunName_GunId(item.Value.gun_id);
                                im.mainWindow.Gun5Lv.Content = item.Value.gun_level;
                                im.mainWindow.Gun5Exp.Content = item.Value.gun_exp;
                                im.mainWindow.Gun5Hp.Content = item.Value.life;
                                break;
                            }
                        default:
                            break;
                    }
                }
            });



        }

        public void setTeamName_In_Formation()
        {
            
            switch (UIHelp.ShowTeamID)
            {
                case 1:
                    {
                        im.mainWindow.TeamName_In_Formation.Content = "第一梯队";
                        break;
                    }
                case 2:
                    {
                        im.mainWindow.TeamName_In_Formation.Content = "第二梯队";
                        break;
                    }
                case 3:
                    {
                        im.mainWindow.TeamName_In_Formation.Content = "第三梯队";
                        break;
                    }
                case 4:
                    {
                        im.mainWindow.TeamName_In_Formation.Content = "第四梯队";
                        break;
                    }
                case 5:
                    {
                        im.mainWindow.TeamName_In_Formation.Content = "第五梯队";
                        break;
                    }
                case 6:
                    {
                        im.mainWindow.TeamName_In_Formation.Content = "第六梯队";
                        break;
                    }
                case 7:
                    {
                        im.mainWindow.TeamName_In_Formation.Content = "第七梯队";
                        break;
                    }
                case 8:
                    {
                        im.mainWindow.TeamName_In_Formation.Content = "第八梯队";
                        break;
                    }
                case 9:
                    {
                        im.mainWindow.TeamName_In_Formation.Content = "第九梯队";
                        break;
                    }
                case 10:
                    {
                        im.mainWindow.TeamName_In_Formation.Content = "第十梯队";
                        break;
                    }
                default:
                    break;
            }


        }

        public void setTeamInOperation_In_Formation()
        {
            foreach (var item in im.Dic_auto_operation_act)
            {
                if(ShowTeamID == item.Value.team_id)
                {
                    im.mainWindow.TeamInOperation_Formation.Visibility = Visibility.Visible;
                    return;
                }
            }
            im.mainWindow.TeamInOperation_Formation.Visibility = Visibility.Hidden;

        }
    }
}
