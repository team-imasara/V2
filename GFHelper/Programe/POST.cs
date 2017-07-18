using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe
{
    class POST
    {

        private static String StringBuilder_(IDictionary<string, string> parameters)
        {
            StringBuilder buffer = new StringBuilder();
            if (!(parameters == null || parameters.Count == 0))
            {
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
            }
            return buffer.ToString();
        }


        public string DoPost(string url, string data)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                wc.Encoding = Encoding.UTF8;
                byte[] postData = wc.Encoding.GetBytes(data);
                string result = Encoding.UTF8.GetString(wc.UploadData(url, "POST", postData));
                return result;
            }
            catch (WebException e)
            {
                return "false " + e.ToString();
            }
        }

        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns></returns>
        public string GetLocalAddress()
        {
            string result = DoPost("http://1212.ip138.com/ic.asp", "");
            int start = result.IndexOf("[") + 1;
            int end = result.IndexOf("]", start);
            result = result.Substring(start, end - start);
            return result;
        }

        public bool LoginFirstUrl()
        {
            //---------LoginFirstUrl = LoginFirstUrl = "http://gf.ppgame.com/interfaces"; (获取access_token 和 openid） start------------------
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("method", "findByEn");
            parameters.Add("ifs_en", "account_login");
            parameters.Add("login_identify", ProgrameData.accountid);
            parameters.Add("login_pwd", ProgrameData.password);
            parameters.Add("app_id", "00020000100021001");
            parameters.Add("encrypt_mode", "md5");
            parameters.Add("sign", "");
            parameters.Add("client_ip", ProgrameData.client_ip);

            string data = StringBuilder_(parameters);

            string result = "";

            while (string.IsNullOrEmpty(result) == true)
            {

                result = DoPost(RequestUrls.LoginFirstUrl, data.ToString());
                var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了

                ProgrameData.access_token = jsonobj.access_token.ToString();
                ProgrameData.openid = jsonobj.openid.ToString();
            }

            return true;
        }

        public int Index_version()//这个API发的是当前时间戳？
        {

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("", "");
            string data = StringBuilder_(parameters);
            string result = "";
            int catchdataversion=0;

            while (string.IsNullOrEmpty(result) == true)
            {

                result = DoPost(ProgrameData.GameAdd + RequestUrls.Index_version, data.ToString());//明码不需要解密
                //result = CommonHelp.StringD(result);
                var jsonobj = DynamicJson.Parse(result); //讲道理，我真不想写了

                catchdataversion = Convert.ToInt32(jsonobj.data_version);
            }
            return catchdataversion;
        }

        public bool GetDigitalUid()
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("openid", ProgrameData.openid);
            parameters.Add("access_token", ProgrameData.access_token);
            parameters.Add("app_id", "00020000100021001");
            parameters.Add("channelid", ProgrameData.channelid);
            parameters.Add("idfa", "");
            parameters.Add("androidid", ProgrameData.androidid);
            parameters.Add("mac", ProgrameData.mac);

            string data = StringBuilder_(parameters);

            string result = "";

            while (string.IsNullOrEmpty(result) == true)
            {
                result = DoPost(ProgrameData.GameAdd + RequestUrls.GetDigitalUid, data.ToString());
                var jsonobj = DynamicJson.Parse(AuthCode.Decode(result, "yundoudou")); //讲道理，我真不想写了
                ProgrameData.sign = jsonobj.sign.ToString();
                ProgrameData.uid = jsonobj.uid.ToString();
            }

            return true;
        }

        public string GetUserInfo()//api = index/index
        {

            string outdatacode = AuthCode.Encode("{\"time\":" +  CommonHelp.ConvertDateTimeInt(DateTime.Now).ToString() + "}", ProgrameData.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}", ProgrameData.uid, System.Web.HttpUtility.UrlEncode(outdatacode));
            string result = "";

            while (string.IsNullOrEmpty(result) == true)
            {
                result = DoPost(ProgrameData.GameAdd + RequestUrls.GetUserInfo, requeststring);
            }
            return result;
        }





































































        public string attendance()//api = index/index
        {

            string outdatacode = AuthCode.Encode(ProgrameData.sign, ProgrameData.sign);
            string requeststring = String.Format("uid={0}&signcode={1}", ProgrameData.uid, System.Web.HttpUtility.UrlEncode(outdatacode));
            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result = DoPost(ProgrameData.GameAdd + RequestUrls.GetAttendance, requeststring);//不需要解密 返回的是签到当月信息奖励
                //var jsonobj = DynamicJson.Parse(AuthCode.Decode(result, ProgrameData.sign));
            }
            return result;
        }

        public string ifNewMail()
        {
            string outdatacode = AuthCode.Encode(ProgrameData.sign, ProgrameData.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&signcode={1}", ProgrameData.uid, System.Web.HttpUtility.UrlEncode(outdatacode));
            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result = DoPost(ProgrameData.GameAdd + RequestUrls.CheckNewMail, requeststring);
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            return result;
        }

        public void GetBannerEvent()//获取左下角小广告
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("c", "game");
            parameters.Add("a", "bannerEvent");
            string data = StringBuilder_(parameters);
            string result = DoPost("http://adr.transit.gf.ppgame.com/index.php", data.ToString());
                   }

        public void GetMallStaticTables()
        {
            string outdatacode = AuthCode.Encode(ProgrameData.sign, ProgrameData.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&signcode={1}", ProgrameData.uid, System.Web.HttpUtility.UrlEncode(outdatacode));

            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result = DoPost(ProgrameData.GameAdd + RequestUrls.MallStaticTables, requeststring);
                var jsonobj = DynamicJson.Parse(AuthCode.Decode(result, ProgrameData.sign));
            }
        }

        public string GetMailList()
        {
            var obj = new
            {
                startid = 0,
                ignore_time = 1,
            };

            string outdatacode = DynamicJson.Serialize(obj);


            outdatacode = AuthCode.Encode(outdatacode, ProgrameData.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&outdatacode={1}", ProgrameData.uid, System.Web.HttpUtility.UrlEncode(outdatacode));

            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result = DoPost(ProgrameData.GameAdd + RequestUrls.GetMailList, requeststring);
                result = AuthCode.Decode(result, ProgrameData.sign);
            }

            return result;//未json化
        }

        public string GetOneMail(int mailwith_user_id)
        {

            string outdatacode = "{\"mail_with_user_id\":" + mailwith_user_id.ToString() +"}";
            outdatacode = AuthCode.Encode(outdatacode, ProgrameData.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&outdatacode={1}", ProgrameData.uid, System.Web.HttpUtility.UrlEncode(outdatacode));

            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result = DoPost(ProgrameData.GameAdd + RequestUrls.GetOneMail, requeststring);

            }
            result = AuthCode.Decode(result, ProgrameData.sign);
            return result;
        }
        public string GetMailResource(int mailwith_user_id)
        {

            string outdatacode = "{\"mail_with_user_id\":" + mailwith_user_id.ToString() + "}";
            outdatacode = AuthCode.Encode(outdatacode, ProgrameData.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&outdatacode={1}", ProgrameData.uid, System.Web.HttpUtility.UrlEncode(outdatacode));

            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result = DoPost(ProgrameData.GameAdd + RequestUrls.GetMailResource, requeststring);

            }
            result = AuthCode.Decode(result, ProgrameData.sign);
            return result;
        }





















        public string RecoverResource()//恢复资源
        {
            string outdatacode = AuthCode.Encode(ProgrameData.sign, ProgrameData.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&signcode={1}", ProgrameData.uid, System.Web.HttpUtility.UrlEncode(outdatacode));

            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result = DoPost(ProgrameData.GameAdd + RequestUrls.RecoverResource, requeststring);
                var jsonobj = DynamicJson.Parse(AuthCode.Decode(result, ProgrameData.sign));
            }
            return result;
        }

        public string StartOperation(int teamid, int operation_id)
        {
            string outdatacode = AuthCode.Encode(String.Format("{{\"teamid\":{0},\"operation_id\":{1}}}", teamid, operation_id), ProgrameData.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}", ProgrameData.uid, System.Web.HttpUtility.UrlEncode(outdatacode));

            string result = "";
            int count = 0;
            while (result != "1")
            {
                result = DoPost(ProgrameData.GameAdd + RequestUrls.StartOperation, requeststring);
                if(count++ == 10)
                {
                    break;
                }
            }
            return result;

        }

        public string FinishOperation(int operationid)
        {
            string outdatacode = AuthCode.Encode(String.Format("{{\"operationid\":{0}}}", operationid), ProgrameData.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}", ProgrameData.uid, System.Web.HttpUtility.UrlEncode(outdatacode));


            string result = "";
            while (string.IsNullOrEmpty(result) == true)
            {
                result = DoPost(ProgrameData.GameAdd + RequestUrls.FinishOperation, requeststring);//不需要解密
                result = AuthCode.Decode(result, ProgrameData.sign);//解析解密
            }
            return result;



        }





































    }
}
