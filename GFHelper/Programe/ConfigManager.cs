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
        public static Dictionary<string, object> defultValue = new Dictionary<string, object>();
        public static string friendUID = "friendUID,true";



        private InstanceManager im;
        private Dictionary<int, ConfigNode> config;
        private int maxline = 0;

        public ConfigManager(InstanceManager im)
        {
            fileName = (string)Properties.Settings.Default["ConfigFile"];
            this.im = im;
            this.config = new Dictionary<int, ConfigNode>();

            defultValue.Add("friendUID", true);

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
                var configfile = File.ReadAllLines(fileName,Encoding.UTF8);
                string[] newconfigfile = new string[maxline];

                for (int i = 0; i < configfile.Length; ++i)
                    newconfigfile[i] = configfile[i];

                foreach (var line in config)
                {
                    newconfigfile[line.Key] = String.Format("{0}={1}", line.Value.key, line.Value.value);
                }

                File.WriteAllLines(fileName, newconfigfile, System.Text.Encoding.UTF8);
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
            //try
            //{
            //    var i = findConfig(key);
            //    i.value = value.ToString();
            //}
            //catch (KeyNotFoundException)
            //{
                ConfigNode cn = new ConfigNode();
                cn.key = key;
                cn.value = value.ToString();
                this.config.Add(maxline++, cn);
            //}

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
                SetConfig(key, defultValue[key]);
                return defultValue[key].ToString()== "True";
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

                if (this.im.configManager.getConfigString("platform").ToLower() == "ios")
                    ProgrameData.platform = "iOS";
                else
                    ProgrameData.platform = "android";
                ProgrameData.worldid = this.im.configManager.getConfigString("worldId");
                switch (ProgrameData.platform)
                {
                    case "android":
                        {
                            if (ProgrameData.worldid == "0")
                            {
                                ProgrameData.GameAdd = "http://gf-adrgw-cn-zs-game-0001.ppgame.com/index.php/1000/";
                            }
                            else
                            {
                                ProgrameData.GameAdd = "http://s" + ProgrameData.worldid + ".gw.gf.ppgame.com/index.php/100" + ProgrameData.worldid + "/";

                            }
                            break;
                        }
                    case "iOS":
                        {
                            ProgrameData.GameAdd = "http://gf-ios-cn-zs-game-0001.ppgame.com/index.php/3000/";
                            break;
                        }
                    default:
                        break;
                }




                ProgrameData.channelid = this.im.configManager.getConfigString("channelid").ToUpper();

                ProgrameData.accountid = this.im.configManager.getConfigString("accountid");
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                ProgrameData.password = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(this.im.configManager.getConfigString("password"))));
                ProgrameData.password = ProgrameData.password.Replace("-", "");
                ProgrameData.password = ProgrameData.password.ToLower();



                ProgrameData.androidid = this.im.configManager.getConfigString("androidid").ToUpper();
                ProgrameData.mac = this.im.configManager.getConfigString("mac");

                ProgrameData.OperationDelay = this.im.configManager.getConfigInt("OperationDelay");


                ProgrameData.AutoSimulationBattleF = this.im.configManager.getConfigBool("AutoSimulationBattleF");
                ProgrameData.AutoDefenseTrialBattleT = this.im.configManager.getConfigInt("AutoDefenseTrialBattleT");
                ProgrameData.SimulationDataType = this.im.configManager.getConfigInt("SimulationDataType");
                ProgrameData.SimulationTeamEffect = this.im.configManager.getConfigInt("SimulationTeamEffect");
                ProgrameData.SimulationDataDuration = double.Parse(this.im.configManager.getConfigString("SimulationDataDuration"));

                ProgrameData.show_result_error = this.im.configManager.getConfigBool("Result_Error_Show");
                ProgrameData.StopTime_string = this.im.configManager.getConfigString("StopTime");

                ProgrameData.friendUID = this.im.configManager.getConfigBool("friendUID");

                if (ProgrameData.StopTime_string.ToLower() == "null")
                {
                    //ProgrameData.StopTime_datetime = "";
                }
                else
                {
                    IFormatProvider format = new System.Globalization.CultureInfo("zh-CN");
                    ProgrameData.StopTime_datetime = DateTime.ParseExact(ProgrameData.StopTime_string, "yyyyMMddHHmmss", format);
                }

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
