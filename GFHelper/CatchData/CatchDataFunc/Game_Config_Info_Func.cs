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




            //float result = 0;
            //foreach (var item in CatchDataSummery.game_config_info)
            //{
            //    if(item.Value.parameter_name == "min_attribute")
            //    {
            //        foreach (var x in item.Value.parameter_value.Values)
            //        {
            //            if (x[0] == attri)
            //            {
            //                float.TryParse(x[1], out result);

            //            }
            //        }
            //    }
            //}
            //return result;
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
    }
}
