using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GFHelper.Programe.ProgramePro
{
    public class ResultPro
    {
        public static bool GetDigitalUid_Pro(ref string result)
        {
            if (result.Contains("Err_Msg") || result.Contains("Err_No")) return false;
            try
            {
                var jsonobj = DynamicJson.Parse(AuthCode.Decode(result, "yundoudou")); //讲道理，我真不想写了
                ProgrameData.sign = jsonobj.sign.ToString();
                ProgrameData.uid = jsonobj.uid.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("解析sign出现错误");
                MessageBox.Show(string.Format("result = {0}", result));
                MessageBox.Show(e.ToString());
                return false;
            }
            return true;

        }


        public static bool Simulation_DATA(ref string result)
        {
            //如果是网络错误 如连接超时 另外考虑
            //{"coin_num":"97","coin_type":"2"}
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                MessageBox.Show("解析结果错误");
                MessageBox.Show(e.ToString());
            }
            //字符串检查
            if (result.Contains("coin_num") && result.Contains("coin_type"))
            {
                return true;
            }
            return false;


        }




        //GUN_OUT_Team
        public static bool GUN_OUTandIN_Team(string result)
        {
            //如果是网络错误 如连接超时 另外考虑

            //字符串检查
            if (result =="1")
            {
                return true;
            }
            return false;
        }

        public static bool Abort_Mission_ResultPro(string result)
        {
            //如果是网络错误 如连接超时 另外考虑
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                MessageBox.Show("解析结果错误");
                MessageBox.Show(e.ToString());
            }
            //字符串检查
            if (result.Contains("mission_lose_result") && result.Contains("turn") && result.Contains("enemydie_num") )
            {
                return true;
            }
            return false;
        }


        public static bool WithDraw_Team_ResultPro(string result)
        {
            //如果是网络错误 如连接超时 另外考虑
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                MessageBox.Show("解析结果错误");
                MessageBox.Show(e.ToString());
            }
            //字符串检查
            if (result.Contains("spot_id") && result.Contains("boss_hp"))
            {
                return true;
            }
            return false;
        }



        public static bool Battle_Finish_ResultPro(ref string result)
        {
            //如果是网络错误 如连接超时 另外考虑
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                MessageBox.Show("解析结果错误");
                MessageBox.Show(e.ToString());
                return false;
            }
            //字符串检查
            if (result.Contains("user_exp") && result.Contains("fairy_exp") && result.Contains("battle_rank") && result.Contains("free_exp"))
            {
                return true;
            }
            return false;
        }


        public static bool Team_Move_ResultPro(string result)
        {

            //如果是网络错误 如连接超时 另外考虑
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                MessageBox.Show("解析结果错误");
                MessageBox.Show(e.ToString());
            }
            //字符串检查
            if (result.Contains("spot_id") && result.Contains("fairy_skill_return"))
            {
                return true;
            }
            return false;
        }


        public static bool Start_Mission_ResultPro(string result)
        {
            //如果是网络错误 如连接超时 另外考虑
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                MessageBox.Show("解析结果错误");
                MessageBox.Show(e.ToString());
            }
            //字符串检查
            if (result.Contains("spot_id") && result.Contains("boss_hp"))
            {
                return true;
            }
            return false;
        }



        public static bool Eat_Equip_ResultPro(ref string result)
        {
            //如果是网络错误 如连接超时 另外考虑
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                MessageBox.Show("解析结果错误");
                MessageBox.Show(e.ToString());
            }

            //字符串检查
            if (result.Contains("equip_add_exp"))
            {
                var jsonobj = DynamicJson.Parse(result);

                 result = jsonobj.equip_add_exp.ToString();
                return true;
            }



            return false;
        }

        public static bool Finish_Operation_ResultPro(string result)
        {
            //如果是网络错误 如连接超时 另外考虑
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception)
            {
                return false;
            }

            //字符串检查
            if (result.Contains("big_success")) return true;
            if (result.Contains("item_id")) return true;
            return false;
        }

        public static bool StartTrial_ResultPro(string result, bool NeedDecode = true)
        {
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                return false;
            }
            //序列化

            //字符串检查
            if (result.Contains("trial_id")) return true;
            return false;
        }

        public static bool EndTrial_ResultPro(string result, bool NeedDecode = true)
        {
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                return false;
            }
            //序列化

            //字符串检查
            if (result.Contains("reward_voucher")) return true;
            return false;
        }

        public static string GetFriend_DormInfo(string result)
        {
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            //序列化

            //字符串检查
            if (result.Contains("current_build_coin")) return result;
            if (result.Contains("build_coin_flag")) return result;
            return "";
        }
        public static bool Get_Friend_Build_Coin(string result, bool NeedDecode = true)
        {
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                return false;
            }
            //序列化

            //字符串检查
            if (result.Contains("build_coin")) return true;
            return false;
        }

        public static string Get_RecoverBP(string result)
        {
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                return "";
            }
            //序列化

            //字符串检查
            if (result.Contains("recover_bp")) return result;
            if (result.Contains("last_bp_recover_time")) return result;
            return "";
        }

        public static string Get_Mail_Content(string result)
        {
            try
            {
                result = AuthCode.Decode(result, ProgrameData.sign);
            }
            catch (Exception e)
            {
                return "";
            }
            //序列化

            //字符串检查
            if (result.Contains("title"))
            {
                var jsonobj = DynamicJson.Parse(result);

                string title = Programe.TextRes.Asset_Textes.ChangeCodeFromeCSV(CommonHelp.UnicodeToString(jsonobj.title.ToString()));
                string content = Programe.TextRes.Asset_Textes.ChangeCodeFromeCSV(CommonHelp.UnicodeToString(jsonobj.content.ToString()));

                result ="标题 : " + title+" 内容 :" +content;

                return result;
            }
            return "";
        }
    }
}
