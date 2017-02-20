using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper
{
    class APIoperation
    {
        private InstanceManager im;
        public APIoperation(InstanceManager im)
        {
          this.im = im;
        }
        
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
        public bool LoginFirstUrl()
        {
            //---------LoginFirstUrl = LoginFirstUrl = "http://gf.ppgame.com/interfaces"; (获取access_token 和 openid） start------------------
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("method", "findByEn");
            parameters.Add("ifs_en", "account_login");
            parameters.Add("login_identify", Models.SimpleInfo.accountid);
            parameters.Add("login_pwd", Models.SimpleInfo.password);
            parameters.Add("app_id", "00020000100021001");
            parameters.Add("encrypt_mode", "md5");
            parameters.Add("sign", "");
            parameters.Add("client_ip", Models.SimpleInfo.client_ip);

            string data =  StringBuilder_(parameters);

            string result = im.serverHelper.DoPost(RequestUrls.LoginFirstUrl, data.ToString());
            //response = ServerHelper.dop(Request,Urls.LoginFirstUrl, parameters, encoding);
            Newtonsoft.Json.Linq.JObject obj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(result);//解析JSON串
            Models.SimpleInfo.access_token = obj["access_token"].ToString();
            Models.SimpleInfo.openid = obj["openid"].ToString();
            return true;
        }

        public bool Index_version(DateTime time)//这个API发的是当前时间戳？
        {

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            //DateTime time = System.DateTime.Now;


            if(Models.SimpleInfo.reqid == 0)
            {
                Models.SimpleInfo.reqid = CommonHelper.ConvertDateTimeInt(time);
                parameters.Add("req_id", Models.SimpleInfo.reqid.ToString());//注意这是第一个时间戳，以后+1
            }
            //Models.SimpleInfo.reqid = CommonHelper.ConvertDateTimeInt(time);
            else
            {
                parameters.Add("req_id", (++Models.SimpleInfo.reqid).ToString());//注意这是第一个时间戳，以后+1
            }


            string data = StringBuilder_(parameters);

            string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.Index_version, data.ToString());//明码不需要解密
            //response = ServerHelper.dop(Request,Urls.LoginFirstUrl, parameters, encoding);

            //Newtonsoft.Json.Linq.JObject obj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(AuthCode.Decode(result, "yundoudou"));//
            return true;
        }

        public bool GetDigitalUid()
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            Models.SimpleInfo.reqid++;
            parameters.Clear();
            parameters.Add("openid", Models.SimpleInfo.openid);
            parameters.Add("access_token", Models.SimpleInfo.access_token);
            parameters.Add("app_id", "00020000100021001");
            parameters.Add("channelid", Models.SimpleInfo.channelid);
            parameters.Add("idfa", "");
            parameters.Add("androidid", Models.SimpleInfo.androidid);
            parameters.Add("mac", Models.SimpleInfo.mac);
            parameters.Add("req_id", Models.SimpleInfo.reqid.ToString());//

            string data = StringBuilder_(parameters);

            string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.GetDigitalUid, data.ToString());

            Newtonsoft.Json.Linq.JObject obj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(AuthCode.Decode(result, "yundoudou"));//解析JSON串
            Models.SimpleInfo.sign = obj["sign"].ToString();
            Models.SimpleInfo.uid = obj["uid"].ToString();
            return true;
        }

        public string GetUserInfo()//api = index/index
        {
            DateTime time = DateTime.Now;
            string outdatacode = AuthCode.Encode("{\"time\":" + CommonHelper.ConvertDateTimeInt(time).ToString() + "}", Models.SimpleInfo.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode), ++Models.SimpleInfo.reqid);
            im.logger.Log(requeststring);
            string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.GetUserInfo, requeststring);
            return result;
        }

        public string attendance()//api = index/index
        {
            DateTime time = DateTime.Now;
            string outdatacode = AuthCode.Encode(Models.SimpleInfo.sign, Models.SimpleInfo.sign);
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode), ++Models.SimpleInfo.reqid);
            im.logger.Log(requeststring);
            string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.GetUserInfo, requeststring);//不需要解密 返回的是签到当月信息奖励
            return result;
        }

        public void ifNewMail()
        {
            string outdatacode = AuthCode.Encode(Models.SimpleInfo.sign, Models.SimpleInfo.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode), ++Models.SimpleInfo.reqid);
            im.logger.Log(requeststring);
            string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.CheckNewMail, requeststring);
            Newtonsoft.Json.Linq.JObject obj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(AuthCode.Decode(result, Models.SimpleInfo.sign));
        }

        public void GetBannerEvent()//获取左下角小广告
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("c", "game");
            parameters.Add("a", "bannerEvent");
            string data = StringBuilder_(parameters);
            string result = im.serverHelper.DoPost("http://adr.transit.gf.ppgame.com/index.php", data.ToString());
            //Newtonsoft.Json.Linq.JObject obj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(AuthCode.Decode(result, Models.SimpleInfo.sign));
        }

        public void GetMallStaticTables()
        {
            string outdatacode = AuthCode.Encode(Models.SimpleInfo.sign, Models.SimpleInfo.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode), ++Models.SimpleInfo.reqid);
            im.logger.Log(requeststring);
            string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.MallStaticTables, requeststring);
            Newtonsoft.Json.Linq.JObject obj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(AuthCode.Decode(result, Models.SimpleInfo.sign));
        }

        public void GetMailList()
        {
            var obj = new
            {
                startid = 0,
                ignore_time = 1,
            };
            // {"Name":"Foo","Age":30,"Address":{"Country":"Japan","City":"Tokyo"},"Like":["Microsoft","Xbox"]}
            string data = Codeplex.Data.DynamicJson.Serialize(obj);


            string outdatacode = AuthCode.Encode(data, Models.SimpleInfo.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode), ++Models.SimpleInfo.reqid);
            im.logger.Log(requeststring);
            string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.GetMailList, requeststring);
            result= AuthCode.Decode(result,Models.SimpleInfo.sign);//解析JSON串
        }

        public string RecoverResource()//恢复资源
        {
            string outdatacode = AuthCode.Encode(Models.SimpleInfo.sign, Models.SimpleInfo.sign);//用自身作为密匙把自身加密
            string requeststring = String.Format("uid={0}&signcode={1}&req_id={2}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode), ++Models.SimpleInfo.reqid);
            im.logger.Log(requeststring);
            string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.RecoverResource, requeststring);
            Newtonsoft.Json.Linq.JObject obj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(AuthCode.Decode(result, Models.SimpleInfo.sign));
            return result;
        }

        public string StartOperation(int team_id,int operation_id,int mission_id)
        {
            string outdatacode = AuthCode.Encode(String.Format("{{\"team_id\":{0},\"operation_id\":{1},\"mission_id\":{2}}}", team_id, operation_id, mission_id), Models.SimpleInfo.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode), ++Models.SimpleInfo.reqid);
            im.logger.Log(requeststring);
            string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.StartOperation, requeststring);//不需要解密
            return result;
        }

        public string FinishOperation(int operationid)
        {
            string outdatacode = AuthCode.Encode(String.Format("{{\"operation_id\":{0}}}", operationid), Models.SimpleInfo.sign);
            string requeststring = String.Format("uid={0}&outdatacode={1}&req_id={2}", Models.SimpleInfo.uid, System.Web.HttpUtility.UrlEncode(outdatacode), ++Models.SimpleInfo.reqid);
            im.logger.Log(requeststring);
            string result = im.serverHelper.DoPost(Models.SimpleInfo.GameAdd + RequestUrls.FinishOperation, requeststring);//不需要解密
            //result = AuthCode.Decode(result, Models.SimpleInfo.sign);//解析解密
            return result;



        }



















    }
}
