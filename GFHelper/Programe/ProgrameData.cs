using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GFHelper.Programe
{
    public class ProgrameData
    {
        InstanceManager im;
        ProgrameData(InstanceManager im)
        {
            this.im = im;
        }

        public static string UserMcCode;
        public static string client_ip;
        public static string accountid;
        public static string password;

        public static int req_id;
        public static bool catchdataF = false;
        public static string GameAdd;//游戏服务器地址...N个服
        public static string platform;
        public static string worldid;
        public static string channelid;
        public static string androidid;
        public static string mac;
        public static string host;

        public static int OperationDelay;

        public static string CatchDataVersion;
        public static int tomorrow_zero;//用于零时刷新 北京时间0点
        public static int weekday;//会用于模拟战


        public static bool AutoSimulationBattleF;
        public static int AutoDefenseTrialBattleT;

        public static int SimulationDataType;
        public static int SimulationTeamEffect;
        public static double SimulationDataDuration;

        public static string StopTime_string;
        public static DateTime StopTime_datetime;



        public static string access_token;
        public static string openid;

        public static string uid;
        public static string sign;


        public static int timeoffset;

        public static bool friendUID;
        //UI设置

        public static bool show_result_error = true;

        public static bool debugmode = false;

        public static int Eat_Gun_rank2_num = 24;

        public static int Error_Num_Stop = 10;

        public static int BL_ReLogin_num = 20;

        public static bool AutoStrengthen;
        public static bool AutoDummyLink;
        //post返回error 如果累计大于3则 返回false
        public static int BL_Error_num = 3;

        public static Dictionary<int, string> dic_Error_Result = new Dictionary<int, string>();
        public static List<TaskListInfo> TaskList = new List<TaskListInfo>();


        public static void Add_dic_Error(string result)
        {
            if (dic_Error_Result.Count >= 100) dic_Error_Result.Clear();
            dic_Error_Result.Add(dic_Error_Result.Count, result);


            int count = 0;


            foreach (var item in dic_Error_Result)
            {
                if (item.Value.Contains("error"))
                {
                    count++;


                    if (count >= 3)
                    {
                        if (ProgrameData.TaskList.Contains(Programe.TaskList.Login))
                        {
                            return;
                        }

                        Programe.ProgramePro.WriteLog.Log(String.Format(" error错误达到3个 "),"debug");
                        dic_Error_Result.Clear();
                        TaskList.Add(Programe.TaskList.Login);
                        return;
                    }

                    continue;
                }
                else
                {
                    count = 0;
                }

            }




        }

    }
}
