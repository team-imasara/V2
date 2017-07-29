using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe.ProgramePro
{
    class WriteLog
    {
        private InstanceManager im;
        public WriteLog(InstanceManager im)
        {
            this.im = im;
        }
        private static StreamWriter streamWriter; //写文件  

        public static void Log(string message)
        {
            try
            {
                //DateTime dt = new DateTime();
                string directPath = Directory.GetCurrentDirectory() + "\\Log";    //获得文件夹路径
                if (!Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
                {
                    Directory.CreateDirectory(directPath);
                }
                directPath += string.Format(@"\{0}月{1}日.log", DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"));
                if (streamWriter == null)
                {
                    streamWriter = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
                }

                if (message != null)
                {
                    streamWriter.WriteLine("【" + DateTime.Now.ToString("HH:mm:ss") + "】" + "      " +  /*"异常信息：\r\n"*/ message);
                }
            }

            catch (Exception ex)
            {

                Log("记录输出异常：" + ex.Message);
            }

            finally
            {
                if (streamWriter != null)
                {
                    try
                    {
                        streamWriter.Flush();
                        streamWriter.Dispose();
                        streamWriter = null;
                    }
                    catch (Exception ex)
                    {

                        Log("记录输出异常：" + ex.Message);
                    }

                }
            }
        }





















    }

}
