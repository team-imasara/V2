using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using GFHelper.Programe;
namespace GFHelper
{
    class ConfigManager
    {
        struct ConfigNode
        {
            public string key;
            public string value;

            public ConfigNode(string key, string value)
            {
                this.key = key;
                this.value = value;
            }

            public override string ToString()
            {
                return this.value;
            }
        }

        public static string fileName;

        private InstanceManager im;
        private Dictionary<int, ConfigNode> config;
        private int maxline = 0;

        public ConfigManager(InstanceManager im)
        {
            fileName = (string)Properties.Settings.Default["ConfigFile"];
            this.im = im;
            this.config = new Dictionary<int, ConfigNode>();
        }

        public bool Load()
        {
            if (String.IsNullOrEmpty(fileName) || !File.Exists(fileName)) return false;

            string[] con = File.ReadAllLines(fileName);

            try
            {
                int linenum = -1;
                foreach (string line in con)
                {
                    ++linenum;
                    if (String.IsNullOrEmpty(line) || line[0] == '#') continue;//注释
                    string[] c = line.Split('=');
                    config.Add(linenum, new ConfigNode(c[0].Trim(), c[1].Trim().ToLower()));
                }

                maxline = con.Length;
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }

        public void Save()
        {
            try
            {
                var configfile = File.ReadAllLines(fileName);
                string[] newconfigfile = new string[maxline];

                for (int i = 0; i < configfile.Length; ++i)
                    newconfigfile[i] = configfile[i];

                foreach (var line in config)
                {
                    newconfigfile[line.Key] = String.Format("{0}={1}", line.Value.key, line.Value.value);
                }

                File.WriteAllLines(fileName, newconfigfile);
            }
            catch (Exception e)
            {

            }
        }

        private ConfigNode findConfig(string key)
        {
            foreach (var i in config)
                if (i.Value.key == key) return i.Value;

            throw new KeyNotFoundException();
        }

        public void SetConfig(string key, object value)
        {
            try
            {
                var i = findConfig(key);
                i.value = value.ToString();
            }
            catch (KeyNotFoundException)
            {
                ConfigNode cn = new ConfigNode();
                cn.key = key;
                cn.value = value.ToString();
                this.config.Add(maxline++, cn);
            }

            this.Save();
        }

        public string getConfigString(string key)
        {
            try
            {
                return findConfig(key).ToString();
            }
            catch (KeyNotFoundException)
            {
                return String.Empty;
            }
        }

        public bool getConfigBool(string key)
        {
            try
            {
                return findConfig(key).ToString() == "true";
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public int getConfigInt(string key)
        {
            try
            {
                return Convert.ToInt32(findConfig(key).ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool setConfig()
        {
            try
            {
                if (!this.im.configManager.Load())
                {
                    System.Windows.MessageBox.Show("配置文件加载失败！");
                    Environment.Exit(0);
                }

                if (this.im.configManager.getConfigString("platform") == "ios")
                    ProgrameData.platform = "iOS";
                else
                    ProgrameData.platform = "android";

                ProgrameData.channelid = this.im.configManager.getConfigString("channelid").ToUpper();
                ProgrameData.worldid = this.im.configManager.getConfigString("worldId");
                ProgrameData.accountid = this.im.configManager.getConfigString("accountid");
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                ProgrameData.password = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(this.im.configManager.getConfigString("password"))));
                ProgrameData.password = ProgrameData.password.Replace("-", "");
                ProgrameData.password = ProgrameData.password.ToLower();

                ProgrameData.androidid = this.im.configManager.getConfigString("androidid").ToUpper();
                ProgrameData.mac = this.im.configManager.getConfigString("mac");

                ProgrameData.AutoDefenseTrialBattleF = this.im.configManager.getConfigBool("AutoDefenseTrialBattleF");
                ProgrameData.AutoDefenseTrialBattleT = this.im.configManager.getConfigInt("AutoDefenseTrialBattleT");
                ProgrameData.StopTime_string = this.im.configManager.getConfigString("StopTime");
                if(ProgrameData.StopTime_string.ToLower() == "null")
                {
                    //ProgrameData.StopTime_datetime = "";
                }
                else
                {
                    IFormatProvider format = new System.Globalization.CultureInfo("zh-CN");
                    ProgrameData.StopTime_datetime = DateTime.ParseExact(ProgrameData.StopTime_string,"yyyyMMddHHmmss", format);
                }


                ProgrameData.GameAdd = "http://s" + ProgrameData.worldid + ".gw.gf.ppgame.com/index.php/100" + ProgrameData.worldid + "/";

            }
            catch (Exception e)
            {

                System.Windows.MessageBox.Show("配置读取失败！错误原因: " + e.ToString());
                return false;
            }


            return true;
        }


    }
}
