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

                im.configManager.setConfig();
                im.catchdatasummery.ReadCatchData();
                //im.logger.Log("GFHelper启动");


            }
            catch (Exception e)
            {
                //im.logger.Log(e);
                //MessageBox.Show("GFHelper启动失败！错误原因: " + e.ToString());
            }
            //倒计时线程

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



        private void button_Click_1(object sender, RoutedEventArgs e)
        { 
            if(comboBoxOperationTeam.SelectedIndex == -1 || comboBoxOperation.SelectedIndex == -1)
            {
                MessageBox.Show("添加失败！请检查你的选择！");
                //return;
            }
            //im.autoOperation.Start(comboBoxOperationTeam.SelectedIndex + 1, comboBoxOperation.SelectedIndex + 1);
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            //im.logger.Log(checkBoxAutoOperation.IsChecked);
            //im.autoOperation.autoOperation = (bool)checkBoxAutoOperation.IsChecked;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//登陆按钮
        {

            im.mainWindow.Login.IsEnabled = false;
            //im.TaskList.Add(TaskList.Login);
            im.action.AutoLogin();
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

        }

        private void CheckT_Click(object sender, RoutedEventArgs e)//初始化按钮
        {
            im.mainWindow.CheckT.IsEnabled = false;

            //检查本地CatchData是否最新
            //if (CommonHelp.CheckCatchDataVersion(im.post.Index_version()) == false)
            //{
            //    //清空catchdata
            //    //下载最新的catchdata
            //    //读取
            //}


            if (CommonHelp.checkT(im.eyLogin))
            {
                this.im.uihelp.setStatusBarText_InThread(" 验证通过允许使用");
                //控件开放
                im.mainWindow.Login.IsEnabled = true;



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

            }
        }

        private void AutoOperationB_S1_Click(object sender, RoutedEventArgs e)
        {
            im.mainWindow.AutoOperationB_S1.IsEnabled = false;
            ////开始后勤任务1
            //im.taskList.tasklistadd(3);
            //lock (im.user_operationInfoLocker)//锁
            //{
            //    if (im.data.UIauto_operationInfo.Count < 4)
            //    {
            //        im.data.UIauto_operationInfo.Add(0, null);
            //        im.data.UIauto_operationInfo.Add(1, null);
            //        im.data.UIauto_operationInfo.Add(2, null);
            //        im.data.UIauto_operationInfo.Add(3, null);
            //    }
            //    im.data.UIauto_operationInfo[0].UIreadautoOperationinfo(im.mainWindow.comboBoxOperationTeam1.SelectedIndex + 1, im.mainWindow.comboBoxOperation1.SelectedIndex + 1);
            //}

        }

        private void AutoOperationB_S2_Click(object sender, RoutedEventArgs e)
        {
            im.mainWindow.AutoOperationB_S2.IsEnabled = false;
            //im.data.tasklistadd(4);
            //lock (im.user_operationInfoLocker)//锁
            //{
            //    if (im.data.UIauto_operationInfo.Count < 4)
            //    {
            //        im.data.UIauto_operationInfo.Add(0, null);
            //        im.data.UIauto_operationInfo.Add(1, null);
            //        im.data.UIauto_operationInfo.Add(2, null);
            //        im.data.UIauto_operationInfo.Add(3, null);
            //    }
            //    //开始后勤任务2
            //    im.data.UIauto_operationInfo[1].UIreadautoOperationinfo(im.mainWindow.comboBoxOperationTeam2.SelectedIndex + 1, im.mainWindow.comboBoxOperation2.SelectedIndex + 1);
            //}

        }

        private void AutoOperationB_S3_Click(object sender, RoutedEventArgs e)
        {
            im.mainWindow.AutoOperationB_S3.IsEnabled = false;
            //im.data.tasklistadd(5);
            //lock (im.user_operationInfoLocker)//锁
            //{
            //    if (im.data.UIauto_operationInfo.Count < 4)
            //    {
            //        im.data.UIauto_operationInfo.Add(0, null);
            //        im.data.UIauto_operationInfo.Add(1, null);
            //        im.data.UIauto_operationInfo.Add(2, null);
            //        im.data.UIauto_operationInfo.Add(3, null);
            //    }
            //    //开始后勤任务3
            //    im.data.UIauto_operationInfo[2].UIreadautoOperationinfo(im.mainWindow.comboBoxOperationTeam3.SelectedIndex + 1, im.mainWindow.comboBoxOperation3.SelectedIndex + 1);

            //}

        }

        private void AutoOperationB_S4_Click(object sender, RoutedEventArgs e)
        {
            im.mainWindow.AutoOperationB_S4.IsEnabled = false;
            //im.data.tasklistadd(6);
            //lock (im.user_operationInfoLocker)//锁
            //{
            //    if (im.data.UIauto_operationInfo.Count < 4)
            //    {
            //        im.data.UIauto_operationInfo.Add(0, null);
            //        im.data.UIauto_operationInfo.Add(1, null);
            //        im.data.UIauto_operationInfo.Add(2, null);
            //        im.data.UIauto_operationInfo.Add(3, null);
            //    }
            //    //开始后勤任务4
            //    im.data.UIauto_operationInfo[3].UIreadautoOperationinfo(im.mainWindow.comboBoxOperationTeam4.SelectedIndex + 1, im.mainWindow.comboBoxOperation4.SelectedIndex + 1);
            //}

            //im.data.tasklistadd(6);
        }


    }
}
