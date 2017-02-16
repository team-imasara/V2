using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Models
{
    class SimpleInfo
    {
        public static string UserMcCode;//本机MD5机器码



        public static Platform platform;
        public static string GameAdd;//游戏服务器地址...N个服
        public static string worldid;
        public static string accountid;
        public static string password;
        public static string channelid;
        public static string androidid;
        public static string mac;
        public static string client_ip;
        public static string host;

        public static string access_token;
        public static string openid;

        public static string uid;
        public static string sign;
        public static bool isServerLoaded = false;
        public static int reqid = 0;
        public static int timeoffset = 0;
    }
}
