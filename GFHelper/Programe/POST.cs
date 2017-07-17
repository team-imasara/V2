﻿using Codeplex.Data;
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





































































        //public string attendance()//api = index/index
        //{
        //    DateTime time = DateTime.Now;
        //    string outdatacode = AuthCode.Encode(Models.SimpleInfo.sign, Models.SimpleInfo.sign);
        //    string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode), ++Models.SimpleInfo.reqid);
        //    im.logger.Log(requeststring);
        //    string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.GetUserInfo, requeststring);//不需要解密 返回的是签到当月信息奖励
        //    return result;
        //}

        //public void ifNewMail()
        //{
        //    string outdatacode = AuthCode.Encode(Models.SimpleInfo.sign, Models.SimpleInfo.sign);//用自身作为密匙把自身加密
        //    string requeststring = String.Format("uid={0}&signcode={1}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode));
        //    im.logger.Log(requeststring);

        //    string result = "";
        //    //var jsonobj = DynamicJson.Parse(result);
        //    while (string.IsNullOrEmpty(result) == true)
        //    {
        //        result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.CheckNewMail, requeststring);
        //        var jsonobj = DynamicJson.Parse(AuthCode.Decode(result, Models.SimpleInfo.sign));
        //    }



        //}

        //public void GetBannerEvent()//获取左下角小广告
        //{
        //    IDictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("c", "game");
        //    parameters.Add("a", "bannerEvent");
        //    string data = StringBuilder_(parameters);
        //    string result = im.serverHelper.DoPost("http://adr.transit.gf.ppgame.com/index.php", data.ToString());
        //    //Newtonsoft.Json.Linq.JObject obj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(AuthCode.Decode(result, Models.SimpleInfo.sign));
        //}

        //public void GetMallStaticTables()
        //{
        //    string outdatacode = AuthCode.Encode(Models.SimpleInfo.sign, Models.SimpleInfo.sign);//用自身作为密匙把自身加密
        //    string requeststring = String.Format("uid={0}&signcode={1}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode));
        //    im.logger.Log(requeststring);

        //    //Newtonsoft.Json.Linq.JObject obj = null;

        //    string result = "";
        //    //var jsonobj = DynamicJson.Parse(result);

        //    while (string.IsNullOrEmpty(result) == true)
        //    {
        //        result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.MallStaticTables, requeststring);
        //        var jsonobj = DynamicJson.Parse(AuthCode.Decode(result, Models.SimpleInfo.sign));

        //    }



        //}

        //public void GetMailList()
        //{
        //    var obj = new
        //    {
        //        startid = 0,
        //        ignore_time = 1,
        //    };

        //    string data = Codeplex.Data.DynamicJson.Serialize(obj);


        //    string outdatacode = AuthCode.Encode(data, Models.SimpleInfo.sign);//用自身作为密匙把自身加密
        //    string requeststring = String.Format("uid={0}&outdatacode={1}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode));
        //    im.logger.Log(requeststring);
        //    string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.GetMailList, requeststring);
        //    result = AuthCode.Decode(result, Models.SimpleInfo.sign);//解析JSON串
        //}

        //public string RecoverResource()//恢复资源
        //{
        //    string outdatacode = AuthCode.Encode(Models.SimpleInfo.sign, Models.SimpleInfo.sign);//用自身作为密匙把自身加密
        //    string requeststring = String.Format("uid={0}&signcode={1}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode));
        //    im.logger.Log(requeststring);
        //    string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.RecoverResource, requeststring);
        //    return result;
        //}

        //public string StartOperation(int team_id, int operation_id)
        //{
        //    string outdatacode = AuthCode.Encode(String.Format("{{\"team_id\":{0},\"operation_id\":{1}}}", team_id, operation_id), Models.SimpleInfo.sign);
        //    string requeststring = String.Format("uid={0}&outdatacode={1}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode));
        //    im.logger.Log(requeststring);

        //    string result = "";

        //    while (result != "1")
        //    {
        //        result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.StartOperation, requeststring);
        //    }

        //    return result;



        //}

        //public string FinishOperation(int operationid)
        //{
        //    string outdatacode = AuthCode.Encode(String.Format("{{\"operation_id\":{0}}}", operationid), Models.SimpleInfo.sign);
        //    string requeststring = String.Format("uid={0}&outdatacode={1}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode));
        //    im.logger.Log(requeststring);

        //    string result = "";

        //    while (string.IsNullOrEmpty(result) == true)
        //    {
        //        result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.FinishOperation, requeststring);//不需要解密
        //    }

        //    //result = AuthCode.Decode(result, Models.SimpleInfo.sign);//解析解密
        //    return result;



        //}





































    }
}
