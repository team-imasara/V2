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

                im.logger.Log("GFHelper启动");
                im.dataHelper.StartReadCatchData();
                //int port = im.configManager.getConfigInt("port");
                //if (port <= 0) port = 8888;
                //im.listener.startProxy(port);

            }
            catch (Exception e)
            {
                im.logger.Log(e);
                MessageBox.Show("GFHelper启动失败！错误原因: " + e.ToString());
            }
            //倒计时线程
            

            countdown = new Thread((new ThreadStart(() => im.backgroundthread.countdown())));//倒计时线程
            countdown.SetApartmentState(ApartmentState.STA);
            countdown.IsBackground = true;
            countdown.Start();


            CompleteMisson = new Thread((new ThreadStart(() => im.backgroundthread.CompleteMisson())));//倒计时线程
            CompleteMisson.SetApartmentState(ApartmentState.STA);
            CompleteMisson.IsBackground = true;
            CompleteMisson.Start();

        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            countdown.Abort();
            CompleteMisson.Abort();




            //im.listener.Shutdown();
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
            im.autoOperation.Start(comboBoxOperationTeam.SelectedIndex + 1, comboBoxOperation.SelectedIndex + 1);
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            im.logger.Log(checkBoxAutoOperation.IsChecked);
            im.autoOperation.autoOperation = (bool)checkBoxAutoOperation.IsChecked;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            im.data.tasklistadd(1);



            //if (im.baseAction.AutoLogin() == true)
            //im.uiHelper.setStatusBarText_InThread(String.Format( " 好像登陆成功的样子 sign = {0}", Models.SimpleInfo.sign));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Label1.Content=AuthCode.Decode(textbox1.Text, textbox2.Text);

        }

        private void getuserinfo_Click(object sender, RoutedEventArgs e)
        {
            im.baseAction.GetUserinfo();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Newtonsoft.Json.Linq.JObject obj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(AuthCode.Decode(textbox1.Text, "yundoudou"));//解析JSON串
            textbox2.Text = obj["sign"].ToString();
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

        private void CheckT_Click(object sender, RoutedEventArgs e)
        {

            Models.SimpleInfo.UserMcCode = im.eyLogin.GetMachineCode();
            if (im.mcsystem.checkT() == true)
            {
                this.im.uiHelper.setStatusBarText_InThread(" 初始化好像成功了");
                //控件开放





                //线程开放


            }
            //验证失败代码
            else
            {
                MessageBox.Show("这是一个随时停止维护的脚本，仅限GFH群内成员交流学习使用。禁止传播，请各位且用且珍惜。");
                MessageBox.Show(string.Format("验证失败，请联系作者添加权限:{0}", Models.SimpleInfo.UserMcCode));
            }
        }

        private void AutoOperationB_S1_Click(object sender, RoutedEventArgs e)
        {
            //开始后勤任务1
            im.data.tasklistadd(3);

        }

        private void AutoOperationB_S2_Click(object sender, RoutedEventArgs e)
        {
            //开始后勤任务2
            im.data.tasklistadd(4);
        }

        private void AutoOperationB_S3_Click(object sender, RoutedEventArgs e)
        {
            //开始后勤任务2
            im.data.tasklistadd(5);
        }

        private void AutoOperationB_S4_Click(object sender, RoutedEventArgs e)
        {
            //开始后勤任务2
            im.data.tasklistadd(6);
        }

        private void count1s_Click(object sender, RoutedEventArgs e)
        {
            //    if (im.data.user_operationInfo[0]._LastTime > -1)
            //    {
            //        im.data.user_operationInfo[0]._LastTime = im.data.user_operationInfo[0]._LastTime - 1;
            //    }
            //    im.uiHelper.operationinfocd();
            //}
        }
    }
}
