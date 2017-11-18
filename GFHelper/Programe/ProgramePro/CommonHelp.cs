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
using System.Diagnostics;
using System.Security.Principal;
using Microsoft.Win32;
using AC;
using LitJson;
using ICSharpCode.SharpZipLib.GZip;

namespace GFHelper.Programe
{
    class CommonHelp
    {

        public static int randomtime(int time)
        {
            Random random = new Random();
            if (time == 0) return 0;
            return random.Next(1, time);
        }

        public static DateTime LocalDateTimeConvertToChina(DateTime dateTime)
        {
            TimeZoneInfo timeZoneSource = TimeZoneInfo.Local;
            TimeZoneInfo timeZoneDestination = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            return TimeZoneInfo.ConvertTime(dateTime, timeZoneSource, timeZoneDestination);
        }
        public static int ConvertDateTime_China_Int(DateTime time, bool ifoffset = false)
        {
            try
            {
                TimeZoneInfo timeZoneSource = TimeZoneInfo.Local;
                TimeZoneInfo timeZoneDestination = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
                time = TimeZoneInfo.ConvertTime(time, timeZoneSource, timeZoneDestination);


                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(LocalDateTimeConvertToChina(new DateTime(1970, 1, 1, 0, 0, 0, 0)));

                long t = (time.Ticks - startTime.Ticks) / 10000000;
                if (ifoffset)
                    return (int)t + ProgrameData.timeoffset;
                else
                    return (int)t;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }

        }





        public static bool CheckCatchDataVersion(string Ncatchdatversion)
        {
            if (Ncatchdatversion == ProgrameData.CatchDataVersion)
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



      

        public static void DeleteFile(string str, bool D=false)
        {
            DirectoryInfo path = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = path.GetFiles("*.*");
            //取得所有文件，然后判断文件名是否以"xxx-"开头
            for (int i = 0; i < files.Count(); i++)
            {
                if (files[i].Name == str + ".json" && D) continue;
                if (files[i].Name.Contains(str))
                    files[i].Delete();
            }
        }
        public static bool CheckCatchData()
        {
            try
            {
                //删除文件夹下的catchdata文件
                //im.mainWindow.CheckT.IsEnabled = false;
                DeleteFile("catchdata");

                //检查catchdata版本

                string catchdataAdd = AC.EncryptTool.GetCryptoFileName(ProgrameData.CatchDataVersion.ToString());

                string url = "http://rescnf.gf.ppgame.com/data/" + catchdataAdd.ToString();

                //下载
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileAsync(new Uri(url), Path.GetFileName("catchdata.dat"));

                    client.DownloadProgressChanged += client_DownloadProgressChanged;
                    client.DownloadFileCompleted += client_DownloadFileCompleted;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            return true;


        }


        static void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ;
            //setLabel0Text_InThread(string.Format("当前接收到{0}字节，文件大小总共{1}字节", e.BytesReceived, e.TotalBytesToReceive));
        }
        static void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("文件下载被取消", "提示");
            }
            if (e.Error == null && e.Cancelled == false)
            {
                UnzipDataAndSave("catchdata.dat", ProgrameData.CatchDataVersion);
                DeleteFile("catchdata",true);
                ProgrameData.catchdataF = true;
            }


        }
        static void UnzipDataAndSave(string dataFilePath, string dataVersion, string saveFile = "catchdata.json")
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



        public static void StopTime()
        {
            if (ProgrameData.StopTime_string.ToLower() == "null") return;
            if (ProgrameData.StopTime_datetime <= LocalDateTimeConvertToChina(DateTime.Now))
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


        public static bool RegisterDll()
        {
            RegistryKey rkTest = Registry.ClassesRoot.OpenSubKey("CLSID\\{3674FE01-AB81-4659-AFA0-1245D0E1531B}\\");
            if (rkTest != null) return true;

                bool result = true;
            try
            {
                string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EyLogin.dll");//获得要注册的dll的物理路径
                if (!File.Exists(dllPath))
                {
                    MessageBox.Show(string.Format("“{0}”目录下无“XXX.dll”文件！", AppDomain.CurrentDomain.BaseDirectory));

                    return false;
                }
                //拼接命令参数
                string startArgs = string.Format("/s \"{0}\"", dllPath);

                Process p = new Process();//创建一个新进程，以执行注册动作
                p.StartInfo.FileName = "regsvr32";
                p.StartInfo.Arguments = startArgs;

                //以管理员权限dll文件
                WindowsIdentity winIdentity = WindowsIdentity.GetCurrent();
                WindowsPrincipal winPrincipal = new WindowsPrincipal(winIdentity);
                if (!winPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    p.StartInfo.Verb = "runas";//管理员权限运行
                }
                p.Start();
                p.WaitForExit();
                p.Close();
                p.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("注册XXX.dll时出错,错误信息：{0}", ex.Message));
                result = false;
            }

            return result;
        }


        public static string DecodeAndMapJson(string wwwText)
        {
            JsonData result=new JsonData();
            try
            {
                if (wwwText.StartsWith("#"))
                {
                    using (MemoryStream memoryStream = new MemoryStream(AuthCode.DecodeWithGzip(wwwText.Substring(1), ProgrameData.sign)))
                    {
                        using (Stream stream = new GZipInputStream(memoryStream))
                        {
                            using (StreamReader streamReader = new StreamReader(stream, Encoding.Default))
                            {
                                result = JsonMapper.ToObject(streamReader);
                                return result.ToJson();
                            }
                        }
                    }
                }
                string text2 = AuthCode.Decode(wwwText, ProgrameData.sign);

                result = JsonMapper.ToObject(text2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return result.ToJson();
        }

        public static string sign(string result)
        {
            JsonData jsonData2 = null;
            GameData.realtimeSinceLogin = Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
            AuthCode.Init(new AuthCode.IntDelegate(GameData.GetCurrentTimeStamp));

            GameData.loginTime = ConvertDateTime_China_Int(DateTime.Now);

            using (MemoryStream stream = new MemoryStream(AuthCode.DecodeWithGzip(result.Substring(1), "yundoudou")))
            {
                using (Stream stream2 = new GZipInputStream(stream))
                {
                    using (StreamReader streamReader = new StreamReader(stream2, Encoding.Default))
                    {
                        jsonData2 = JsonMapper.ToObject(streamReader);
                    }
                }
            }

            ProgrameData.uid = jsonData2["uid"].String;
            ProgrameData.sign = jsonData2["sign"].String;
            return ProgrameData.sign;

        }

        public static int GetTotalFPS_(double time)
        {
            double result = time * 31;
            return (int)Math.Ceiling(result);
        }

    }

}

