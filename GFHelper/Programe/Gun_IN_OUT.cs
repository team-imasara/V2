using Codeplex.Data;
using GFHelper.Programe.ProgramePro;
using GFHelper.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe
{
    class Gun_IN_OUT
    {

        public static void Get_Gun_Location(int mvp_id, ref Dictionary<int,int> list, Dictionary<int, Gun_With_User_Info> teaminfo)
        {
            //mvp检查
            //如果MVP是队长 则 LIST 只有 4位 MVP不需要动
            bool mvp_location_1 = false;
            foreach (var item in teaminfo)
            {
                if(item.Value.id==mvp_id && item.Value.location == 1)
                {
                    mvp_location_1 = true;
                }
            }
            if (mvp_location_1)
            {
                //MVP是队长
                foreach (var item in teaminfo)
                {
                    if (item.Value.id == mvp_id) continue;
                    list[item.Value.location] = item.Value.id;
                }
            }
            else
            {
                foreach (var item in teaminfo)
                {
                    list[item.Value.location] = item.Value.id;
                }
            }

        }


        public static void Get_TankNormal_id(int mvp_id,ref Dictionary<int,int> list, Dictionary<int, Gun_With_User_Info> teaminfo)
        {
            int maxlife1=0, maxlife2=0;

            //tank1_id
            foreach (var item in teaminfo)
            {
                if (item.Value.id == mvp_id) continue;
                if(item.Value.maxLife >= maxlife1)
                {
                    maxlife1 = item.Value.maxLife;
                    list[1]=item.Value.id;
                }
            }

            //tank2_id
            foreach (var item in teaminfo)
            {
                if (item.Value.id == mvp_id) continue;
                if (item.Value.maxLife >= maxlife2 && item.Value.maxLife !=maxlife1)
                {
                    maxlife2 = item.Value.maxLife;
                    list[2] = item.Value.id;
                }
            }


            //normal_id
            foreach (var item in teaminfo)
            {
                if (item.Value.id == mvp_id) continue;
                if (list.ContainsValue(item.Value.id)) continue;
                list.Add(list.Count,item.Value.id);
            }



        }

        public static void Gun_IN_post(int team_id,int gun_with_user_id,int location)
        {
            dynamic newjson = new DynamicJson();
            newjson.team_id /*这是节点*/ = team_id;/* 这是值*/
            newjson.gun_with_user_id /*这是节点*/ = gun_with_user_id;/* 这是值*/
            newjson.location /*这是节点*/ = location;/* 这是值*/

            int count = 0;
            while (true)
            {
                string result = POST.GUN_OUTandIN_Team(newjson.ToString());

                switch (ResultPro.Result_Pro(ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            return;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            count++;
                            if (count == 2)
                            {
                                return;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

        }

        public static void Gun_OUT_post(int team_id,int location)
        {
            dynamic newjson = new DynamicJson();
            newjson.team_id /*这是节点*/ = team_id;/* 这是值*/
            newjson.gun_with_user_id /*这是节点*/ = 0;/* 这是值*/
            newjson.location /*这是节点*/ = location;/* 这是值*/

            int count = 0;
            while (true)
            {
                string result = POST.GUN_OUTandIN_Team(newjson.ToString());

                switch (ResultPro.Result_Pro(ref result, "GUN_OUTandIN_Team_PRO", false))
                {
                    case 1:
                        {
                            return;
                        }
                    case 0:
                        {
                            continue;
                        }
                    case -1:
                        {
                            count++;
                            if (count == 2)
                            {
                                return;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

        }


    }
}
