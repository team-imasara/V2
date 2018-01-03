using Codeplex.Data;
using ICSharpCode.SharpZipLib.GZip;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AC;
using LitJson;
using UnityEngine;

namespace GFHelper.Programe.ProgramePro
{
    public class ResultPro
    {
        /// <summary>
        /// 结果处理 主要判断此次post是否成功
        /// </summary>
        /// <param name="result">需要处理的post result</param>
        /// <param name="type">需要处理的类型 战斗结果或者 梯队移动</param>
        /// <param name="need">是否需要使用sign解密</param>
        /// <param name=""></param>
        /// <returns>1成功 0不成功,需要重发 -1不成功,不需要重发</returns>
        public static int Result_Pro(ref string result,string type,bool need_decode)
        {
            ProgrameData.Add_dic_Error(result);
            if (result == "first") { return 0; }//第一次发送
            if (result=="") { return 0; }//
            if (result.Contains("error")) { return -1; }//我也不知道return 什么好
            if (result.Contains("Err_Msg") || result.Contains("Err_No")) return -1;
            if (need_decode)
            {
                try
                {
                    //AuthCode.Decode(result, ProgrameData.sign);
                    result = CommonHelp.DecodeAndMapJson(result); 
                }
                catch (Exception e)
                {
                    MessageBox.Show("解析结果错误");
                    MessageBox.Show(e.ToString());
                    return -1;
                }
            }


            switch (type)
            {
                case "GetDigitalUid_Pro":
                    {
                        try
                        {
                            JsonData jsonData2 = null;
                            GameData.realtimeSinceLogin = Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
                            AuthCode.Init(new AuthCode.IntDelegate(GameData.GetCurrentTimeStamp));

                            using (MemoryStream stream = new MemoryStream(AuthCode.DecodeWithGzip(result.Substring(1), "yundoudou")))
                            {
                                using (Stream stream2 = new GZipInputStream(stream))
                                {
                                    using (StreamReader streamReader = new StreamReader(stream2, Encoding.Default))
                                    {
                                            jsonData2 = JsonMapper.ToObject(streamReader);
                                    }
                                }
                            }

                            ProgrameData.uid = jsonData2["uid"].String;
                            ProgrameData.sign = jsonData2["sign"].String;


                            //var jsonobj = DynamicJson.Parse(AuthCode.Decode(result, "yundoudou")); //讲道理，我真不想写了
                            //ProgrameData.sign = jsonobj.sign.ToString();
                            //ProgrameData.uid = jsonobj.uid.ToString();
                            return 1;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("解析sign出现错误");
                            MessageBox.Show(string.Format("result = {0}", result));
                            MessageBox.Show(e.ToString());
                            return 0;
                        }
                    }
                case "Simulation_DATA_Pro":
                    {
                        return result.Contains("coin_num") && result.Contains("coin_type") ? 1 : 0;
                    }
                case "GUN_OUTandIN_Team_PRO":
                    {
                        return result == "1" ? 1 : 0;
                    }
                case "Abort_Mission_Pro":
                    {
                        return result.Contains("mission_lose_result") && result.Contains("turn") && result.Contains("enemydie_num") ? 1 : 0;
                    }
                case "WithDraw_Team_Pro":
                    {
                        return result.Contains("spot_id") || result.Contains("[]") ? 1 : 0;
                    }
                case "Battle_Finish_Pro":
                    {
                        return result.Contains("user_exp") &&result.Contains("battle_rank") && result.Contains("free_exp") ? 1 : 0;
                    }
                case "Team_Move_Pro":
                    {
                        return result.Contains("fairy_skill_perform") && result.Contains("fairy_skill_return") ? 1 : 0;
                    }
                case "Start_Mission_Pro":
                    {
                        return result.Contains("spot_id") ? 1 : 0;
                    }
                case "Eat_Equip_Pro":
                    {
                        return result.Contains("equip_add_exp")? 1 : 0;
                    }
                case "Finish_Operation_Pro":
                    {
                        return result.Contains("big_success") && result.Contains("item_id") ? 1 : 0;
                    }
                case "StartTrial_Pro":
                    {
                        return result.Contains("trial_id") ? 1 : 0;
                    }
                case "EndTrial_Pro":
                    {
                        return result.Contains("reward_voucher") ? 1 : 0;
                    }
                case "GetFriend_DormInfo_Pro":
                    {
                        return result.Contains("current_build_coin") && result.Contains("build_coin_flag") ? 1 : 0;
                    }
                case "Get_Friend_Build_Coin_Pro":
                    {
                        return result.Contains("build_coin") ? 1 : 0;
                    }
                case "Get_RecoverBP_Pro":
                    {
                        return result.Contains("recover_bp") && result.Contains("last_bp_recover_time") ? 1 : 0;
                    }
                case "endTurn":
                    {
                        return result.Contains("mission_win_result") || result.Contains("fairy_skill_on_enemy") ? 1 : 0;
                    }
                case "startTurn":
                    {
                        return result.Contains("mission_lose_result") && result.Contains("mission_win_result") && result.Contains("fairy_skill_return") ? 1 : 0;
                    }

                case "EatGun":
                    {
                        return result.Contains("pow") && result.Contains("dodge") && result.Contains("rate") ? 1 : 0;
                    }
                case "Friend_visit":
                    {
                        return result.Contains("info") && result.Contains("user_id") && result.Contains("f_userid") ? 1 : 0;
                    }
                case "Friend_praise":
                    {
                        return result.Contains("package") && result.Contains("id") && result.Contains("user_exp") ? 1 : 0;
                    }
                //LoginFirstUrl
                case "LoginFirstUrl":
                    {
                        return result.Contains("access_token") && result.Contains("openid") && result.Contains("result") ? 1 : 0;
                    }
                //Index_version
                case "Index_version":
                    {
                        return result.Contains("now") && result.Contains("tomorrow_zero") && result.Contains("data_version") ? 1 : 0;
                    }
                //GetUserInfo
                case "GetUserInfo":
                    {
                        return result.Contains("id") && result.Contains("gun") && result.Contains("user") ? 1 : 0;
                    }

                case "endEnemyTurn_PRO":
                    {
                        return result.Contains("ally_instance_betray") && result.Contains("mission_lose_result") && result.Contains("ally_instance_transform") ? 1 : 0;
                    }
                case "eventDraw":
                    {
                        return result.Contains("mission_campaign") && result.Contains("draw_event_id") && result.Contains("start_time") ? 1 : 0;
                    }
                case "night_reinforceTeam":
                    {
                        return result.Contains("night_spots") && result.Contains("spot_id") && result.Contains("belong") ? 1 : 0;
                    }
                case "FairyMissionSkill":
                    {
                        return result.Contains("fairy_team_id") && result.Contains("fairy_skill_perform") && result.Contains("next_skill_cd_turn") ? 1 : 0;
                    }
                case "Team_MoveRandom_Pro":
                    {
                        return result.Contains("enemy_team_id") && result.Contains("enemy_instance_id") ? 1 : 0;
                    }
                case "Establish_Build":
                    {
                        return result.Contains("build_tmp_data") && result.Contains("build_coin") ? 1 : 0;
                    }
                case "Establish_Build_Finish":
                    {
                        return result.Contains("gift") ? 1 : 0;
                    }
                default:
                    break;
            }

            return 1;
        }

        public static string Get_Mail_Content(string result)
        {
            try
            {
                //result = AuthCode.Decode(result, ProgrameData.sign);
                result = CommonHelp.DecodeAndMapJson(result);
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
