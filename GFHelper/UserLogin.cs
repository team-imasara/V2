using GFHelper.Programe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GFHelper
{
    class UserLogin
    {
        private InstanceManager im;
        public UserLogin(InstanceManager im)
        {
            this.im = im;
        }
        public bool checkT()
        {
            try
            {
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();//获取主版本号     

                im.eyLogin.SetAppKey("D5FA256E997E4E728DCEC4FB5111ACDF"); // 设置程序秘钥~一定要设置,否则无法正常使用控件
                ProgrameData.UserMcCode = im.eyLogin.GetMachineCode();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                ProgrameData.UserMcCode = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ProgrameData.UserMcCode)), 4, 8);
                ProgrameData.UserMcCode = ProgrameData.UserMcCode.Replace("-", "");
                ProgrameData.UserMcCode = ProgrameData.UserMcCode.ToLower();
                ProgrameData.UserMcCode = ProgrameData.UserMcCode.Remove(0, 1);
                ProgrameData.UserMcCode = ProgrameData.UserMcCode.Insert(0, "a");
                int ret0 = im.eyLogin.UserLogin(ProgrameData.UserMcCode, "a123456789", "v1.0.0", im.eyLogin.GetMachineCode());
                if (ret0 == 1)//登陆成功
                {
                    if (ProgrameData.UserClient == true)
                    {
                        im.eyLogin.OpenUserCheck();
                    }

                    return true;
                }
                else
                {
                    MessageBox.Show("验证网络连接失败!");
                    MessageBox.Show("机器码 : " + ProgrameData.UserMcCode);
                    MessageBox.Show(CommonHelp.UnicodeToString(im.eyLogin.GetLastMessages()));
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }

        }
    }
}
