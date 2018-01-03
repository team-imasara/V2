using GFHelper.Programe.ProgramePro.APK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.CatchData.CatchDataFunc
{
    class Game_Config_Info_Func
    {
        private CatchData.CatchDataSummery cds;
        public Game_Config_Info_Func(CatchDataSummery catchdatasummery)
        {
            this.cds = catchdatasummery;
        }

        public static float GetMinAttribute(string attri)
        {
            CatchDataSummery.Attri attri_0 =(CatchDataSummery.Attri) Enum.Parse(typeof(CatchDataSummery.Attri), attri);


            if (!CatchDataSummery.dictMinAttribute.ContainsKey(attri_0))
            {
                CatchDataSummery.dictMinAttribute.Add(attri_0, (float)Convert.ToDouble(GetString("min_attribute").Split(new char[]
                {
                ','
                })[(int)attri_0].Split(new char[]
                {
                ':'
                })[1]));
            }
            return CatchDataSummery.dictMinAttribute[attri_0];


        }

        public double GetDouble(string str)
        {
            double result = 0;
            foreach (var item in CatchDataSummery.game_config_info)
            {
                if(item.Value.parameter_name == str)
                {
                    string[] a = item.Value.parameter_value[0];
                    Double.TryParse(a[0], out result);
                    return result;
                }
            }
            return result;
        }

        public static int GetInt(string key)
        {
            int result = 0;
            foreach (var item in CatchDataSummery.game_config_info)
            {
                if (item.Value.parameter_name == key)
                {
                    string[] a = item.Value.parameter_value[0];
                    int.TryParse(a[0], out result);
                    return result;
                }
            }
            return result;
        }


        public static float GetFloatFromStringArray(string key, int id, char splitChar = ',')
        {
            float result = 0;
            foreach (var item in CatchDataSummery.game_config_info)
            {
                if (item.Value.parameter_name == key)
                {
                    result = float.Parse(item.Value.parameter_value[id][0]);
                    return result;
                }
            }
            return result;

        }

        public static float GetGunBasicAttribute(GunType type, string key)
        {

            if (!CatchDataSummery.dictGunBaseAttri.ContainsKey(type))
            {
                CatchDataSummery.dictGunBaseAttri.Add(type, new Dictionary<string, float>());
            }
            if (!CatchDataSummery.dictGunBaseAttri[type].ContainsKey(key))
            {
                float result =CatchDataSummery.gun_type_info[type].data[key];
                CatchDataSummery.dictGunBaseAttri[type].Add(key, result);
            }
            return CatchDataSummery.dictGunBaseAttri[type][key];
        }

        public static string GetString(string key)
        {
            string result = "";
            foreach (var item in CatchDataSummery.game_config_info)
            {
                if (item.Value.parameter_name == key)
                {
                    result = item.Value.parameter_value_String;
                    break;
                }
            }
            return result;
        }   
        // Token: 0x06001851 RID: 6225 RVA: 0x000843F4 File Offset: 0x000825F4
        public static float GetEquipLevelUpRate(int rarity)
        {
            if (rarity < 1)
            {
                return 0f;
            }
            if (CatchDataSummery.equip_exp_Rate_info.Count == 0)
            {
                string[] array = GetString("equip_exp_rate").Split(new char[]
                {
                ','
                });
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string text = array2[i];
                    string text2 = text.Split(new char[]
                    {
                    ':'
                    })[0];
                    string text3 = text.Split(new char[]
                    {
                    ':'
                    })[1];
                    CatchDataSummery.equip_exp_Rate_info.Add(int.Parse(text2), float.Parse(text3));
                }
            }
            if (CatchDataSummery.equip_exp_Rate_info.ContainsKey(rarity))
            {
                return CatchDataSummery.equip_exp_Rate_info[rarity];
            }
            return 0f;
        }
    }
}
