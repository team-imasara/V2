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

        public static string GameAdd;//游戏服务器地址...N个服
        public static string platform;
        public static string worldid;
        public static string channelid;
        public static string androidid;
        public static string mac;
        public static string host;



        public static int CatchDataVersion;
        public static bool isServerLoaded = false;






        public static string access_token;
        public static string openid;

        public static string uid;
        public static string sign;


        public static int timeoffset;

        //UI设置

    }
}
