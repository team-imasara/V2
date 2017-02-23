//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.DoPost
{
    //2017.2.10 GK
    //一些发包的动作 登陆等
    class Login
    {
        private InstanceManager im;

        public Login(InstanceManager im)
        {
            this.im = im;
        }

        public bool Account_Login()
        {
            HttpWebResponse response;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            //---------LoginFirstUrl = LoginFirstUrl = "http://gf.ppgame.com/interfaces"; (获取access_token 和 openid） end------------------


            //---------Index_version = "Index/version";//获取当前时间戳，获取换日时间戳，数据版本 客户端版本 星期几 start------------------
            parameters.Clear();
            DateTime time = System.DateTime.Now;
            Models.SimpleInfo.reqid = CommonHelper.ConvertDateTimeInt(time);
            parameters.Add("req_id", Models.SimpleInfo.reqid.ToString());//注意这是第一个时间戳，以后+1
            try
            {
                response = ServerHelper.CreatePostHttpResponse(Models.SimpleInfo.GameAdd + RequestUrls.Index_version, parameters, encoding);
            }
            catch (Exception)
            {

                return false;
            }

            StreamReader sr = new StreamReader(response.GetResponseStream());//创建一个stream读取流 //获取响应的字符串流   
            string html = sr.ReadToEnd();


            //---------Index_version = "Index/version";//获取当前时间戳，获取换日时间戳，数据版本 客户端版本 星期几 end------------------

            System.Threading.Thread.Sleep(5000);
            //---------GetDigitalUid 获取 sign 和 uid start------------------
            Models.SimpleInfo.reqid++;
            parameters.Clear();
            parameters.Add("openid", Models.SimpleInfo.openid);
            parameters.Add("access_token", Models.SimpleInfo.access_token);
            parameters.Add("app_id", "00020000100021001");
            parameters.Add("channelid",Models.SimpleInfo.channelid);
            parameters.Add("idfa", "");
            parameters.Add("androidid", Models.SimpleInfo.androidid);
            parameters.Add("mac", Models.SimpleInfo.mac);
            parameters.Add("req_id", Models.SimpleInfo.reqid.ToString());//
            try
            {
                response = ServerHelper.CreatePostHttpResponse(Models.SimpleInfo.GameAdd + RequestUrls.GetDigitalUid, parameters, encoding);
            }
            catch (Exception)
            {

                return false;
            }

            sr = new StreamReader(response.GetResponseStream());//创建一个stream读取流 //获取响应的字符串流   
            html = sr.ReadToEnd();   //从头读到尾，放到字符串html  

            //obj = (JObject)JsonConvert.DeserializeObject(AuthCode.Decode(html, "yundoudou"));//解析JSON串

            var jsonobj = Codeplex.Data.DynamicJson.Parse(html); //讲道理，我真不想写了


            Models.SimpleInfo.sign = jsonobj.sign.ToString();
            Models.SimpleInfo.uid = jsonobj.uid.ToString();
            //---------GetDigitalUid end------------------

            ////------------------获取user_info start------------------
            //parameters.Clear();
            //time = System.DateTime.Now;
            //Models.SimpleInfo.reqid++;
            //parameters.Add("outdatacode",AuthCode.Encode("{\"time\":" + CommonHelper.ConvertDateTimeInt(time).ToString() + "}",Models.SimpleInfo.sign));
            //parameters.Add("req_id",Models.SimpleInfo.reqid.ToString());
            //parameters.Add("uid", Models.SimpleInfo.uid);
            //try
            //{
            //    response = ServerHelper.CreatePostHttpResponse(Models.SimpleInfo.GameAdd + RequestUrls.GetUserInfo, parameters, encoding);
            //}
            //catch (Exception)
            //{

            //    return false;
            //}
            //sr = new StreamReader(response.GetResponseStream());//创建一个stream读取流 //获取响应的字符串流   
            //html = sr.ReadToEnd();   //从头读到尾，放到字符串html  
            ////------------------获取user_info end------------------



            //im.dataHelper.ReadUserInfo(html);
            //im.uiHelper.setUserInfo();
            //im.autoOperation.SetTeamInfo();



            return true;
        }


    }
}
