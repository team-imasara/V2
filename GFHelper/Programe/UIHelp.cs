using GFHelper.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
                        int findKey=-1;
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



                    im.mainWindow.textDevelopSlot.Text = im.userdatasummery.user_info.max_build_slot.ToString();//建造槽
                    im.mainWindow.textFixSlot.Text = im.userdatasummery.user_info.max_fix_slot.ToString();
                    im.mainWindow.textUpgradeSlot.Text = im.userdatasummery.user_info.max_upgrade_slot.ToString();

                    im.mainWindow.textGunNum.Text = String.Format("{0}/{1}", im.userdatasummery.user_info.gun_collect.Count, im.userdatasummery.user_info.maxgun);
                    im.mainWindow.textTeamNum.Text = im.userdatasummery.user_info.maxteam.ToString();
                    im.mainWindow.textUnlockRatio.Text = ((int)((double)im.userdatasummery.user_info.gun_collect.Count / (double)im.catchdatasummery.gun_info.Count* 100)).ToString() + "%";




                    //
                    //im.userdatasummery.kalina_with_user_info
                    im.mainWindow.textDevelopSlot1.Text = im.userdatasummery.kalina_with_user_info.level.ToString();//建造槽
                    im.mainWindow.textFixSlot1.Text = im.userdatasummery.kalina_with_user_info.favor.ToString();

                    //item_with_user_info
                    im.mainWindow.textEquipNum.Text = String.Format("{0}/{1}", im.userdatasummery.equip_with_user_info.Count,im.userdatasummery.user_info.maxequip);
                    im.mainWindow.textEquipRank5Num1.Text = im.userdatasummery.Rank5EquipmentN.ToString();

                    //friend_with_user_info
                    im.mainWindow.textFriendNum.Text = String.Format("{0}/50", im.userdatasummery.friend_with_user_info.Count);
                    im.mainWindow.textFriendLv.Text = im.userdatasummery.FriendLv.ToString();

                }));
            }
            catch (Exception e)
            {
                throw;
            }
        }



    }
}
