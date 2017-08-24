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
using System.Net;
using System.IO.Compression;

namespace GFHelper.Programe
{
    class CommonHelp
    {
        public static EyLoginSoft eyLogin = new EyLoginSoft();
        public static DownLoadP dlp = new DownLoadP();
        public static DateTime PSTConvertToGMT(DateTime dateTime)
        {
            TimeZoneInfo timeZoneSource = TimeZoneInfo.Local;
            TimeZoneInfo timeZoneDestination = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            return TimeZoneInfo.ConvertTime(dateTime, timeZoneSource, timeZoneDestination);
        }
        public static int ConvertDateTime_China_Int(DateTime time, bool ifoffset = false)
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

        

        public bool checkT()
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();//获取主版本号     

            eyLogin.SetAppKey("D5FA256E997E4E728DCEC4FB5111ACDF"); // 设置程序秘钥~一定要设置,否则无法正常使用控件
            ProgrameData.UserMcCode = eyLogin.GetMachineCode();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            ProgrameData.UserMcCode = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ProgrameData.UserMcCode)), 4, 8);
            ProgrameData.UserMcCode = ProgrameData.UserMcCode.Replace("-", "");
            ProgrameData.UserMcCode = ProgrameData.UserMcCode.ToLower();
            ProgrameData.UserMcCode = ProgrameData.UserMcCode.Remove(0, 1);
            ProgrameData.UserMcCode = ProgrameData.UserMcCode.Insert(0, "a");
            int ret0 = eyLogin.UserLogin(ProgrameData.UserMcCode, "a123456789", "v1.0.0", eyLogin.GetMachineCode());
            if (ret0 == 1)//登陆成功
            {
                eyLogin.OpenUserCheck();
                return true;
            }
            else
            {
                MessageBox.Show("验证网络连接失败!");
                MessageBox.Show("机器码 : " + ProgrameData.UserMcCode);
                MessageBox.Show(UnicodeToString(eyLogin.GetLastMessages()));
                return false;
            }

        }

        public static void DeleteFile(string str)
        {
            DirectoryInfo path = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = path.GetFiles("*.*");
            //取得所有文件，然后判断文件名是否以"xxx-"开头
            for (int i = 0; i < files.Count(); i++)
            {
                if (files[i].Name == str + ".json") continue;
                if (files[i].Name.Substring(0, 9) == str)
                    files[i].Delete();
            }
        }
        public void CheckCatchData()
        {
            //删除文件夹下的catchdata文件
            //im.mainWindow.CheckT.IsEnabled = false;
            DeleteFile("catchdata");

            //检查catchdata版本

            string catchdataAdd = AC.EncryptTool.GetCryptoFileName(ProgrameData.CatchDataVersion.ToString());
            string url = "http://rescnf.gf.ppgame.com/data/" + catchdataAdd;

            //下载
            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(new Uri(url), Path.GetFileName("catchdata.dat"));
                dlp.Show();
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
            }


        }
        private static void DownLoadNewCatchData(object sender, EventArgs e)
        {
            string abc = AC.EncryptTool.GetCryptoFileName("1098");
            string url = "http://rescnf.gf.ppgame.com/data/" + abc;


            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(new Uri(url), Path.GetFileName("catchdata.dat"));
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
            }
        }
        static void client_DownloadProgressChanged( object sender, DownloadProgressChangedEventArgs e)
        {
            setLabel0Text_InThread(string.Format("当前接收到{0}字节，文件大小总共{1}字节", e.BytesReceived, e.TotalBytesToReceive));
        }
        static void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("文件下载被取消", "提示");
            }
            MessageBox.Show("catchdata文件下载成功", "提示");
            UnzipDataAndSave("catchdata.dat", ProgrameData.CatchDataVersion);

            DeleteFile("catchdata");


        }
        static void UnzipDataAndSave(string dataFilePath, int dataVersion, string saveFile = "catchdata.json")
        {
            byte[] buffer = new byte[0x400];
            StringBuilder builder = new StringBuilder();
            using (Stream stream = new FileStream(dataFilePath, FileMode.Open))
            {
                CryptoStream baseInputStream = new CryptoStream(stream, AC.EncryptTool.GetDecryptorServiceProvider(dataVersion), CryptoStreamMode.Read);
                using (Stream stream3 = new GZipStream(baseInputStream, CompressionMode.Decompress))
                {
                    //StreamReader reader = new StreamReader(stream3, Encoding.UTF8);
                    FileStream fs = new FileStream(saveFile, FileMode.OpenOrCreate);
                    stream3.CopyTo(fs);
                    fs.Close();
                    stream3.Close();
                }
                stream.Close();
            }
        }
        public static void setLabel0Text(string text)
        {
            dlp.label0.Content = string.Format(text);
        }

        public static void setLabel0Text_InThread(string text)
        {
            dlp.Dispatcher.BeginInvoke(new Action(() =>
            {
                setLabel0Text(text);
            }));
        }

        public static void StopTime()
        {
            if (ProgrameData.StopTime_string.ToLower() == "null") return;
            if(ProgrameData.StopTime_datetime <= PSTConvertToGMT(DateTime.Now))
            {
                Environment.Exit(0);
            }

        }


        /// <summary>    
        /// Unicode字符串转为正常字符串    
        /// </summary>    
        /// <param name="srcText"></param>    
        /// <returns></returns>    
        public static string UnicodeToString(string srcText)
        {
            if (srcText.Contains("\\") == false) return srcText;
            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;
            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }






    }


}
