using EyLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GFHelper.Models
{
    class mcSystem
    {
        private InstanceManager im;

        public mcSystem(InstanceManager im)
        {
            this.im = im;
        }


        public bool checkT()
        {

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();//获取主版本号     

            im.eyLogin.SetAppKey("D5FA256E997E4E728DCEC4FB5111ACDF"); // 设置程序秘钥~一定要设置,否则无法正常使用控件

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            SimpleInfo.UserMcCode = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(Models.SimpleInfo.UserMcCode)), 4, 8);
            SimpleInfo.UserMcCode = SimpleInfo.UserMcCode.Replace("-", "");
            SimpleInfo.UserMcCode = SimpleInfo.UserMcCode.ToLower();
            SimpleInfo.UserMcCode = SimpleInfo.UserMcCode.Remove(0, 1);
            SimpleInfo.UserMcCode = SimpleInfo.UserMcCode.Insert(0, "a");


            im.uiHelper.setStatusBarText_InThread("开始验证");
            int ret0 = im.eyLogin.UserLogin(SimpleInfo.UserMcCode, "a123456789", version, im.eyLogin.GetMachineCode());

            if (ret0 == 0)
            {
                this.im.uiHelper.setStatusBarText_InThread("验证失败") ;
                if (im.eyLogin.GetLastError() == -203)
                {
                    MessageBox.Show("发现新版本，请在GFH群获取新版本。", "少女前线");
                    im.logger.Log("发现新版本，请在GFH群获取新版本。");
                    Environment.Exit(0);

                }
                //MessageBox.Show(eyLogin.GetLastError().ToString(), "少女前线");
                return false;
            }
            else
            {

                string ret1 = im.eyLogin.GetLatestVersion();
                if (ret1 != version)
                {
                    MessageBox.Show("发现新版本，请在GFH群获取新版本。", "少女前线");
                    Environment.Exit(0);
                    return false;
                }
                this.im.uiHelper.setStatusBarText_InThread("验证成功");
                im.logger.Log("验证成功");

                int ret2 = im.eyLogin.OpenUserCheck();

                if (ret2 == 0)

                {

                    MessageBox.Show("开启自动校验用户状态失败.");
                }

                return true;
            }

        }





    }
}
