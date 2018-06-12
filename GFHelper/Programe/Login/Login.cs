using System;
using System.Text;
using LitJson;
using System.Collections;
using System.Collections.Generic;

namespace GFHelper.Programe.Login
{
    public class Login
    {
        public static string normalLogin(String login_identify, String login_pwd)
        {

            JsonWriter data = new JsonWriter();
            data.WriteObjectStart();
            data.WritePropertyName("login_pwd");
            data.Write(login_pwd);
            data.WritePropertyName("app_id");
            data.Write("0002000100021001");
            data.WritePropertyName("encrypt_mode");
            data.Write("md5");
            data.WritePropertyName("login_identify");
            data.Write(login_identify);
            data.WriteObjectEnd();
            return createUserCenterHttpRequest(data.ToString());

        }

        public static string createUserCenterHttpRequest(string data)
        {
            byte[] strEncrypt = XXTea.Encrypt(data);
            byte[] body = packageRequestData(strEncrypt);
            return POST.DoPost("http://gf.ucenter.ppgame.com/normal_login", body);
        }
        public static byte[] packageRequestData(byte[] data)
        {
            JsonWriter head = new JsonWriter();

            head.WriteObjectStart();
            head.WritePropertyName("app_id");
            head.Write("0002000100021001");
            head.WritePropertyName("version");
            head.Write("1.0");
            head.WriteObjectEnd();



            List<Byte> listbyte = new List<Byte>();  // 复制目的

            // 迭代 bytes 数组中的内容后添加到 lbyte 中

            foreach (byte b in Encoding.Default.GetBytes(head.ToString()))
            {
                listbyte.Add(b);
            }
            listbyte.Add(0x0);
            foreach (var b in data)
            {
                listbyte.Add(b);
            }

            return listbyte.ToArray();
        }
    }




}

