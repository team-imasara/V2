using Codeplex.Data;
using GFHelper.Programe.ProgramePro;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GFHelper.Programe.Auto
{
    class Friend
    {
        private InstanceManager im;
        public Friend(InstanceManager im)
        {
            this.im = im;
        }

        public void Friend_Praise()
        {

            int f_userid;

            for (int i = 0; i < 50; i++)
            {
                while (true)
                {
                    int count = 0;
                    StringBuilder sb = new StringBuilder();
                    JsonWriter jsonWriter = new JsonWriter(sb);
                    jsonWriter.WriteObjectStart();
                    jsonWriter.WritePropertyName("f_userid");
                    jsonWriter.Write(0);
                    jsonWriter.WriteObjectEnd();
                    Thread.Sleep(1500);

                    string result = im.post.Friend_visit(sb.ToString());
                    if (ResultPro.Result_Pro(ref result, "Friend_visit", true) == 1)
                    {
                        var jsonobj = DynamicJson.Parse(result);
                        f_userid = Convert.ToInt32(jsonobj.info.f_userid);
                        im.uihelp.setStatusBarText_InThread(String.Format(" 访问 f_userid = {0} 当前次数 {1}", f_userid, i+1));
                        break;
                    }
                    if (ResultPro.Result_Pro(ref result, "Friend_visit", true) == 0) { ACTION.result_error_PRO(result, count++); continue; }
                    if (ResultPro.Result_Pro(ref result, "Friend_visit", true) == -1) { ACTION.result_error_PRO(result, count++); continue; /*特殊处理我还没想好*/; }
                }

                while (true)
                {
                    int count = 0;
                    StringBuilder sb = new StringBuilder();
                    JsonWriter jsonWriter = new JsonWriter(sb);
                    jsonWriter.WriteObjectStart();
                    jsonWriter.WritePropertyName("f_userid");
                    jsonWriter.Write(f_userid);
                    jsonWriter.WriteObjectEnd();
                    Thread.Sleep(1500);
                    im.uihelp.setStatusBarText_InThread(String.Format(" 点赞 f_userid = {0},当前次数 {1}", f_userid, i+1));
                    string result = im.post.Friend_praise(sb.ToString());
                    if (ResultPro.Result_Pro(ref result, "Friend_praise", true) == 1)
                    {
                        break;
                    }
                    if (ResultPro.Result_Pro(ref result, "Friend_praise", true) == 0) { ACTION.result_error_PRO(result, count++); continue; }
                    if (ResultPro.Result_Pro(ref result, "Friend_praise", true) == -1) { ACTION.result_error_PRO(result, count++); break; /*特殊处理我还没想好*/; }
                }
            }




        }




    }
}
