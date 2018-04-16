using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Threading;
using Codeplex.Data;
using GFHelper.Programe;
using System.Runtime.InteropServices;
using GFHelper.UserData;
using AC;
using GFHelper.Programe.Auto;

namespace GFHelper
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private InstanceManager im;

        Thread countdown, CompleteMisson;

        public MainWindow()
        {
            CommonHelp.RegisterDll();
            InitializeComponent();
            try
            {
                im = new InstanceManager(this);
                //加载配置文件
                //检查catchdata
                AppUpdate();
                im.configManager.setConfig();
                im.userdatasummery.usbti.setData(Programe.ProgrameData.SimulationDataType, Programe.ProgrameData.SimulationDataDuration, Programe.ProgrameData.SimulationTeamEffect);
                //im.logger.Log("GFHelper启动");

                //初始化练级地图信息




            }
            catch (Exception e)
            {

                MessageBox.Show("GFHelper启动失败！错误原因: " + e.ToString());
            }
            //倒计时线程

        }

        public void AppUpdate()
        {

            var updater = FSLib.App.SimpleUpdater.Updater.Instance;

            //当检查发生错误时,这个事件会触发
            updater.Error += new EventHandler(updater_Error);

            //找到更新的事件.但在此实例中,找到更新会自动进行处理,所以这里并不需要操作
            //updater.UpdatesFound += new EventHandler(updater_UpdatesFound);

            //开始检查更新-这是最简单的模式.请现在 assemblyInfo.cs 中配置更新地址,参见对应的文件.
            FSLib.App.SimpleUpdater.Updater.CheckUpdateSimple();



        }
        static void updater_Error(object sender, EventArgs e)
        {
            var updater = sender as FSLib.App.SimpleUpdater.Updater;
            MessageBox.Show("错误,请告诉作者他的服务器宕机了");
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                countdown.Abort();
                CompleteMisson.Abort();
            }
            catch (Exception)
            { 
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }




        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            //im.logger.Log(checkBoxAutoOperation.IsChecked);
            //im.autoOperation.autoOperation = (bool)checkBoxAutoOperation.IsChecked;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//登陆按钮
        {

            im.mainWindow.Login.IsEnabled = false;
            ProgrameData.AutoRelogin = true;
            ProgrameData.TaskList.Add(TaskList.Login);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void getuserinfo_Click(object sender, RoutedEventArgs e)
        {
            //im.baseAction.GetUserinfo();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {


        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //im.apioperation.StartOperation();
        }

        private void listViewOperation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBoxOperation1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                im.Dic_auto_operation_act[0].operation_id = im.catchdatasummery.operation_info[im.mainWindow.comboBoxOperation1.SelectedIndex].id;
            }
            catch (Exception)
            {

            }

        }

        private void CheckT_Click(object sender, RoutedEventArgs e)//初始化按钮
        {
            im.mainWindow.CheckT.IsEnabled = false;

            var getIndex_version = new Task<string>(im.post.Index_version);

            var CheckT = new Task<bool>(im.userlogin.checkT);
            var CCD = new Task<bool>(CommonHelp.CheckCatchData);
            getIndex_version.ContinueWith(p =>
            {
                im.uihelp.setStatusBarText_InThread(String.Format(" 获取时间信息完成"));
                CCD.Start();
            });
            CheckT.ContinueWith(p =>
            {
                im.uihelp.setStatusBarText_InThread(String.Format(" 验证授权完成"));
                testcheck(CheckT.Result);
                //testcheck(true);
            });

            CCD.ContinueWith(p =>
            {
                im.uihelp.setStatusBarText_InThread(String.Format(" 下载catchdata完成"));
                im.catchdatasummery.ReadCatchData();
                MessageBox.Show("catchdata文件下载成功", "提示");
            });

            im.uihelp.setStatusBarText_InThread(String.Format(" 开始初始化"));
            getIndex_version.Start();
            CheckT.Start();
            im.mainWindow.Login.IsEnabled = true;
        }

        public void testcheck(bool result)
        {

            if (result)
            {
                this.im.uihelp.setStatusBarText_InThread(" 验证通过允许使用");


                var CountDown = new Task(im.backgroundthread.CountDown);//倒计时线程
                CountDown.Start();
                var CompleteMisson = new Task(im.backgroundthread.CompleteMisson);//CompleteMisson
                CompleteMisson.Start();

            }
            //验证失败代码
            else
            {
                Environment.Exit(0);
            }
        }

        private void AutoOperationB_S1_Click(object sender, RoutedEventArgs e)
        {
            im.action.UI_Button_Start_Finish_Operation_Act(im.mainWindow.AutoOperationB_S1, 0);

        }

        private void AutoOperationB_S2_Click(object sender, RoutedEventArgs e)
        {
            im.action.UI_Button_Start_Finish_Operation_Act(im.mainWindow.AutoOperationB_S2, 1);

        }

        private void AutoOperationB_S3_Click(object sender, RoutedEventArgs e)
        {
            im.action.UI_Button_Start_Finish_Operation_Act(im.mainWindow.AutoOperationB_S3, 2);

        }



        private void AutoOperation_CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (im.mainWindow.AutoOperation_CheckBox.IsChecked == true)
            {
                im.auto_summery.NeedAuto_Loop_Operation_Act = true;

            }
            else
            {
                im.auto_summery.NeedAuto_Loop_Operation_Act = false;
            }
        }

        private void comboBoxOperationTeam1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                im.Dic_auto_operation_act[0].team_id = im.userdatasummery.team_info[im.mainWindow.comboBoxOperationTeam1.SelectedIndex + 1][1].team_id;
            }
            catch (Exception)
            {

            }

        }

        private void comboBoxOperationTeam2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                im.Dic_auto_operation_act[1].team_id = im.userdatasummery.team_info[im.mainWindow.comboBoxOperationTeam2.SelectedIndex + 1][1].team_id;
            }
            catch (Exception)
            {

            }

        }

        private void comboBoxOperationTeam3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                im.Dic_auto_operation_act[2].team_id = im.userdatasummery.team_info[im.mainWindow.comboBoxOperationTeam3.SelectedIndex + 1][1].team_id;
            }
            catch (Exception)
            {

            }

        }

        private void comboBoxOperationTeam4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                im.Dic_auto_operation_act[3].team_id = im.userdatasummery.team_info[im.mainWindow.comboBoxOperationTeam4.SelectedIndex + 1][1].team_id;
            }
            catch (Exception)
            {

            }

        }

        private void comboBoxOperation2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                im.Dic_auto_operation_act[1].operation_id = im.catchdatasummery.operation_info[im.mainWindow.comboBoxOperation2.SelectedIndex].id;
            }
            catch (Exception)
            {

            }


        }

        private void comboBoxOperation3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                im.Dic_auto_operation_act[2].operation_id = im.catchdatasummery.operation_info[im.mainWindow.comboBoxOperation3.SelectedIndex].id;
            }
            catch (Exception)
            {

            }

        }

        private void comboBoxOperation4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                im.Dic_auto_operation_act[3].operation_id = im.catchdatasummery.operation_info[im.mainWindow.comboBoxOperation4.SelectedIndex].id;
            }
            catch (Exception)
            {


            }

        }



        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (UIHelp.ShowTeamID < im.userdatasummery.team_info.Count)
                {
                    UIHelp.ShowTeamID++;
                    im.uihelp.setTeamInfo_In_Formation();
                }
            }
            catch (Exception e0)
            {
                MessageBox.Show("UI更新梯队信息出错");
                MessageBox.Show(e0.ToString());
            }
        }

        private void Label_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (UIHelp.ShowTeamID >= 2)
                {
                    UIHelp.ShowTeamID--;
                    im.uihelp.setTeamInfo_In_Formation();
                }
            }
            catch (Exception e0)
            {
                MessageBox.Show("UI更新梯队信息出错");
                MessageBox.Show(e0.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProgrameData.TaskList.Add(TaskList.Get_Battary_Friend);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            UserDataSummery.dicGun_PowerUP.Clear();
            int i = 0;
            foreach (var item in im.userdatasummery.gun_with_user_info)
            {
                if (item.Value.maxAddDodge != item.Value.additionDodge && item.Value.maxAddHit != item.Value.additionHit && item.Value.maxAddPow != item.Value.additionPow&& item.Value.maxAddRate != item.Value.additionRate)
                {
                    UserDataSummery.dicGun_PowerUP.Add(i++, item.Value);
                    MessageBox.Show(string.Format("Gun_name = {0} ", Programe.TextRes.Asset_Textes.ChangeCodeFromeCSV(im.userdatasummery.FindGunName_GunId(item.Value.gun_id))));
                }

            }
            MessageBox.Show((string.Format("当前共有 i={0}", i)));

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {


            ProgrameData.TaskList.Add(TaskList.Get_Battary_Friend);
        }
        private void Button_Click_61(object sender, RoutedEventArgs e)
        {


            ProgrameData.TaskList.Add(TaskList.Friend_Praise);
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("请确保已勾选MVP,战斗效能和正确的梯队 重要的人形上锁");
            MessageBox.Show("请确保已勾选MVP,战斗效能和正确的梯队 重要的人形上锁");
            MessageBox.Show("请确保已勾选MVP,战斗效能和正确的梯队 重要的人形上锁");


            List<string> t = TaskO.Text.ToLower().Split(' ').ToList();
            

            var Comboxtaskmap = this.Task1Map.SelectedItem as ComboBoxItem;
            string TaskMap = Comboxtaskmap.Content.ToString();
            foreach (var item in t)
            {
                if (item.Contains("-map"))
                {
                    TaskMap = item.Remove(0,4);
                }
                if (item.Contains("-loginnum"))
                {
                    Int32.TryParse(item.Remove(0, 9), out ProgrameData.BL_ReLogin_num);
                }


            }

            new_User_Normal_MissionInfo nunm = new new_User_Normal_MissionInfo(im.Teams, TaskMap, im.userdatasummery.user_info.experience);
            if (t.Contains("-ns")) nunm.needSupply = false;
            int.TryParse(BattleMaxLoopTime.Text, out nunm.MaxLoopTime);
            im.dic_userbattletaskinfo[0]= nunm;
            
            ProgrameData.TaskList.Add(TaskList.TaskBattle_1);
        }

        private void Task1MT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            im.uihelp.setTeamInfo_In_Formation();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string sign = CommonHelp.sign(textbox3.Text);

            label_sign.Content = ProgrameData.sign;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            result_decoded.Text = CommonHelp.DecodeAndMapJson(result_decoded.Text);
        }

        private void POST_Click(object sender, RoutedEventArgs e)
        {



        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            im.action.EatGunHandle();
        }

        private void Get_User_info_Click(object sender, RoutedEventArgs e)
        {
            ProgrameData.TaskList.Add(TaskList.GetuserInfo);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            BattleTask_team_info bti = new BattleTask_team_info();
            bti.TeamEffect =Convert.ToInt32(Task1TeamE.Text);
            bti.isMainTeam = true;
            bti.TeamID = Task1MT.SelectedIndex + 1;
            bti.teaminfo = im.userdatasummery.team_info[Task1MT.SelectedIndex+1];
            if (GUN1_MVP.IsChecked == true) bti.MVP = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][1].id;
            if (GUN2_MVP.IsChecked == true) bti.MVP = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][2].id;
            if (GUN3_MVP.IsChecked == true) bti.MVP = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][3].id;
            if (GUN4_MVP.IsChecked == true) bti.MVP = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][4].id;
            if (GUN5_MVP.IsChecked == true) bti.MVP = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][5].id;
            im.Teams.Add(bti);
            BattleTeamsLabel.Content += string.Format("第 {0} 梯队(主力)\r\n", bti.TeamID);
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            im.Teams.Clear();
            BattleTeamsLabel.Content = "";
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            BattleTask_team_info bti = new BattleTask_team_info();
            bti.isMainTeam = false;
            bti.TeamID = Task1MT.SelectedIndex + 1;
            bti.teaminfo = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1];
            im.Teams.Add(bti);
            BattleTeamsLabel.Content += string.Format("第 {0} 梯队(辅助)\r\n", bti.TeamID);
        }

        private void button_encrypt_Click(object sender, RoutedEventArgs e)
        {

            result_encrypt.Text = AuthCode.Encode(result_encrypt.Text, ProgrameData.sign);
        }

        private void AutoOperationB_S4_Click(object sender, RoutedEventArgs e)
        {
            im.action.UI_Button_Start_Finish_Operation_Act(im.mainWindow.AutoOperationB_S4, 3);
        }


    }
}
