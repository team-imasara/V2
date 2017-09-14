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
            InitializeComponent();
            try
            {
                this.im = new InstanceManager(this);
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
                //im.logger.Log(e);
                //MessageBox.Show("GFHelper启动失败！错误原因: " + e.ToString());
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
            im.TaskList.Add(TaskList.Login);
            //im.action.AutoLogin();
            //if (im.baseAction.AutoLogin() == true)

            //if (im.baseAction.AutoLogin() == true)
            //im.uiHelper.setStatusBarText_InThread(String.Format( " 好像登陆成功的样子 sign = {0}", Models.SimpleInfo.sign));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Label1.Content=AuthCode.Decode(textbox1.Text, textbox2.Text);

        }

        private void getuserinfo_Click(object sender, RoutedEventArgs e)
        {
            //im.baseAction.GetUserinfo();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            var jsonobj = DynamicJson.Parse(AuthCode.Decode(textbox1.Text, "yundoudou")); //讲道理，我真不想写了


            textbox2.Text = jsonobj.sign.ToString();
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

            var getIndex_version = new Task<int>(im.post.Index_version);
            var CheckT = new Task<bool>(CommonHelp.checkT);
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
                //线程开放
                countdown = new Thread((new ThreadStart(() => im.backgroundthread.CountDown())));//倒计时线程
                countdown.SetApartmentState(ApartmentState.STA);
                countdown.IsBackground = true;
                countdown.Start();
                CompleteMisson = new Thread((new ThreadStart(() => im.backgroundthread.CompleteMisson())));//倒计时线程
                CompleteMisson.SetApartmentState(ApartmentState.STA);
                CompleteMisson.IsBackground = true;
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
            im.TaskList.Add(TaskList.Get_Battary_Friend);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            im.userdatasummery.Update_GUN_Pos(6, 256315);
            //int i = 0;

            //for (; i < im.userdatasummery.gun_with_user_info.Count; i++)
            //{
            //    if (im.userdatasummery.gun_with_user_info[i].teamId == 7)
            //    {
            //        im.userdatasummery.gun_with_user_info[i].UpdateData();
            //        im.userdatasummery.gun_with_user_info[i].GetPoint(true);
            //    }
            //}
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {


            im.TaskList.Add(TaskList.Get_Battary_Friend);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            int mvp=0;//mvp不用理

            Programe.Auto.User_Normal_BattleTaskInfo ubti = new Programe.Auto.User_Normal_BattleTaskInfo();
            if (GUN1_MVP.IsChecked == true) mvp = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][1].id;
            if (GUN2_MVP.IsChecked == true) mvp = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][2].id;
            if (GUN3_MVP.IsChecked == true) mvp = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][3].id;
            if (GUN4_MVP.IsChecked == true) mvp = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][4].id;
            if (GUN5_MVP.IsChecked == true) mvp = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][5].id;


            ubti.TeamEffect = Convert.ToInt32(Task1TeamE.Text);
            //ubti.Effect1 = Convert.ToInt32(GUN_1E.Text);
            //ubti.Effect2 = Convert.ToInt32(GUN_2E.Text);
            //ubti.Effect3 = Convert.ToInt32(GUN_3E.Text);
            //ubti.Effect4 = Convert.ToInt32(GUN_4E.Text);
            //ubti.Effect5 = Convert.ToInt32(GUN_5E.Text);

            ubti.teaminfo = im.userdatasummery.im.userdatasummery.team_info[Task1MT.SelectedIndex + 1];//需要




            Programe.Auto.Battle_Gun_Info[] gun = new Programe.Auto.Battle_Gun_Info[5];
            //枪的效能 总效能

            for (int i = 1; i <= 5; i++)
            {
                if(im.userdatasummery.team_info[Task1MT.SelectedIndex + 1].ContainsKey(i) == true)
                {
                    Programe.Auto.Battle_Gun_Info temp = new Programe.Auto.Battle_Gun_Info();
                    temp.id = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][i].id;
                    temp.life = im.userdatasummery.team_info[Task1MT.SelectedIndex + 1][i].life;
                    gun[i-1] = temp;
                }
            }
            ubti.gun = gun.OrderBy(p => p.id).ToArray();


            ubti.user_exp = im.userdatasummery.user_info.experience;//需要


            ubti.Build_info(Task1Map.SelectedIndex,Task1MT.SelectedIndex+1,Task1ST1.SelectedIndex+1, gun, mvp);
            ubti.Key = 0;
            im.dic_userbattletaskinfo[0]=ubti;
            im.TaskList.Add(Programe.TaskList.TaskBattle_1);
        }

        private void Task1MT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            im.uihelp.setTeamInfo_In_Formation();
        }

        private void AutoOperationB_S4_Click(object sender, RoutedEventArgs e)
        {
            im.action.UI_Button_Start_Finish_Operation_Act(im.mainWindow.AutoOperationB_S4, 3);
        }


    }
}
