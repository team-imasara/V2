using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EyLogin;
using System.IO;

namespace GFHelper.Programe
{
    class CommonHelp
    {
        public static DateTime PSTConvertToGMT(DateTime dateTime)
        {
            TimeZoneInfo timeZoneSource = TimeZoneInfo.Local;
            TimeZoneInfo timeZoneDestination = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            return TimeZoneInfo.ConvertTime(dateTime, timeZoneSource, timeZoneDestination);
        }
        public static int ConvertDateTimeInt(DateTime time, bool ifoffset = false)
        {
            TimeZoneInfo timeZoneSource = TimeZoneInfo.Local;
            TimeZoneInfo timeZoneDestination = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            time = TimeZoneInfo.ConvertTime(time, timeZoneSource, timeZoneDestination);


            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(PSTConvertToGMT(new DateTime(1970, 1, 1, 0, 0, 0, 0)));

            long t = (time.Ticks - startTime.Ticks) / 10000000;
            if (ifoffset)
                return (int)t + ProgrameData.timeoffset;
            else
                return (int)t;
        }
        public static bool CheckCatchDataVersion(int Ncatchdatversion)
        {
            if(Ncatchdatversion == ProgrameData.CatchDataVersion)
            {
                return true;
            }

            return false;
        }
        public static string formatDuration(int duration)
        {
            int h, m, s;
            h = duration / 3600;
            m = duration / 60 % 60;
            s = duration % 60;
            string result = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
            return result;
        }
        public static bool checkT(EyLoginSoft eyLogin)
        {

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();//获取主版本号     

            eyLogin.SetAppKey("D5FA256E997E4E728DCEC4FB5111ACDF"); // 设置程序秘钥~一定要设置,否则无法正常使用控件
            ProgrameData.UserMcCode = eyLogin.GetMachineCode();
            if (ProgrameData.UserMcCode == "37797B15343158143F7C7B15CA627BDE")
            {
                return true;
            }
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            ProgrameData.UserMcCode = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ProgrameData.UserMcCode)), 4, 8);
            ProgrameData.UserMcCode = ProgrameData.UserMcCode.Replace("-", "");
            ProgrameData.UserMcCode = ProgrameData.UserMcCode.ToLower();
            ProgrameData.UserMcCode = ProgrameData.UserMcCode.Remove(0, 1);
            ProgrameData.UserMcCode = ProgrameData.UserMcCode.Insert(0, "a");



            int ret0 = eyLogin.UserLogin(ProgrameData.UserMcCode, "a123456789", "v1.0.0", eyLogin.GetMachineCode());

            if (ret0 == 1)//登陆成功
            {
                return true;
            }
            else
            {
                MessageBox.Show("验证网络连接失败!");
                MessageBox.Show(eyLogin.GetLastMessages());
                return false;
            }
        }

    }


}
