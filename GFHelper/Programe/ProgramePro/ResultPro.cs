using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe.ProgramePro
{
    public class ResultPro
    {
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
    }
}
