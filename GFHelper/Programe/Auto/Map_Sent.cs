using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe.Auto.Map_Sent
{

    static class Function
    {
        public static int Normal_PosCheck_type1(string result,int fromSpot,int toSpot)
        {
            if (result.Contains("error")) return 0;//error 代码
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["enemy_move"];
            foreach (JsonData item in jsonData)
            {
                if (item["from_spot_id"].Int == fromSpot && item["to_spot_id"].Int == toSpot)
                    return 1;//需要打
            }
            return 2;//不需要打
        }

        /// <summary>
        /// 0 error代码 1需要打 2不需要打
        /// </summary>
        /// <param name="result"></param>
        /// <param name="toSpot"></param>
        /// <returns> 0 error代码 1需要打 2不需要打</returns>
        public static int Normal_PosCheck_type2(string result, int toSpot)
        {
            if (result.Contains("error")) return 0;//error 代码
            try
            {
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["enemy_move"];
                foreach (JsonData item in jsonData)
                {
                    if (item["to_spot_id"].Int == toSpot)
                        return 1;//需要打
                }
                return 2;//不需要打
            }
            catch (Exception)
            {
                return 1;
            }

        }

        public static int Night_PosCheck_type1(string result,int toSpot)
        {
            if (result.Contains("error")) return 0;//error 代码
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["night_enemy"];
            foreach (JsonData item in jsonData)
            {
                if (item["to_spot_id"].Int == toSpot)
                {
                    return 1;//需要打
                }
            }
            return 2;//不需要打
        }



    }
    //
    static class Corridor
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 1503;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5523);//主力


        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5523, 5521, 1);
        public static TeamMove teammove2 = new TeamMove(5521, 5522, 1);
        public static TeamMove teammove3 = new TeamMove(5522, 5519, 1);
        public static TeamMove teammove4 = new TeamMove(5519, 5524, 1);
        public static TeamMove teammove5 = new TeamMove(5524, 5520, 1);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }




    static class Map2_4N
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 90008;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(1330);//主力


        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(1330, 1332, 1);
        public static TeamMove teammove2 = new TeamMove(1332, 1453, 1);
        public static TeamMove teammove3 = new TeamMove(1453, 1454, 1);
        public static TeamMove teammove4 = new TeamMove(1454, 1457, 1);
        public static TeamMove teammove5 = new TeamMove(1457, 1461, 1);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;


                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序


        public static int PosCheck1(string result)
        {
            if (result.Contains("error")) return 0;//不需要打
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["night_enemy"];
            foreach (JsonData item in jsonData)
            {
                if (item["to_spot_id"].Int == 1453)
                    return 1;//需要打

            }
            return 0;//不需要打
        }
    }






    static class Map3_4N
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 90012;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(1485);//主力


        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(1485, 1347, 1);
        public static TeamMove teammove2 = new TeamMove(1347, 1503, 1);
        public static TeamMove teammove3 = new TeamMove(1503, 1504, 1);
        public static TeamMove teammove4 = new TeamMove(1504, 1505, 1);//分支开始
        public static TeamMove teammove5 = new TeamMove(1505, 1489, 1);//分支1向上
        public static TeamMove teammove6 = new TeamMove(1947, 1949, 1);//分支2向左1
        public static TeamMove teammove7 = new TeamMove(1949, 1947, 1);//分支2向左2
        public static TeamMove teammove8 = new TeamMove(1505, 1509, 1);//分支3
        public static TeamMove teammove9 = new TeamMove(1509, 1506, 1);//分支3
        public static TeamMove teammove10 = new TeamMove(1509, 1507, 1);//分支3
        public static TeamMove teammove11 = new TeamMove(1489, 1506, 1);
        public static TeamMove teammove12 = new TeamMove(1489, 1490, 1);
        public static TeamMove teammove13 = new TeamMove(1489, 1501, 1);
        public static TeamMove teammove14 = new TeamMove(1489, 1476, 1);
        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;
                    _dic_TeamMove[11] = teammove12;
                    _dic_TeamMove[12] = teammove13;
                    _dic_TeamMove[13] = teammove14;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 3033;//撤离

        public static int BossPos(string result)
        {
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["night_enemy"];
            foreach (JsonData item in jsonData)
            {
                if(item["enemy_team_id"].Int == 609)
                {

                    if (item["to_spot_id"].Int == 1489) return 0;//机场上方
                    
                    if (item["to_spot_id"].Int == 1505) return 1;//机场左测 到 机场

                    if (item["from_spot_id"].Int ==1509 &&  item["to_spot_id"].Int == 1506) return 2;//机场左测 到 上一格 

                    if (item["from_spot_id"].Int == 1509 && item["to_spot_id"].Int == 1507) return 3;//机场左测 到 机场左左侧

                    if (item["to_spot_id"].Int == 1509) return 4;//机场左左侧

                    if (item["from_spot_id"].Int == 1489 && item["to_spot_id"].Int == 1506) return 5;//机场上 到 左上机场

                    if (item["from_spot_id"].Int == 1489 && item["to_spot_id"].Int == 1490) return 6;//机场上 到 左上机场

                    if (item["from_spot_id"].Int == 1489 && item["to_spot_id"].Int == 1501) return 7;//机场上 到 左上机场

                    if (item["from_spot_id"].Int == 1489 && item["to_spot_id"].Int == 1476) return 8;//机场上 到 左上机场
                }
            }
            return -1;//need abaort
        }
        public static int rPos(string result)
        {
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["night_enemy"];
            foreach (JsonData item in jsonData)
            {
                if(item.Contains("to_spot_id=1505") )return 1;//机场
                if (item["enemy_team_id"].Int == 606)
                {
                    switch (item["to_spot_id"].Int)
                    {
                        case 1505:
                            {
                                return 1;//机场
                            }
                        default:
                            break;
                    }
                }
            }
            return 0;//need abaort
        }



    }

    static class Map5_2N
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 90018;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(3033);//主力
        public static Spots spots2 = new Spots(3057);//辅助

        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(3033, 3037, 1);
        public static TeamMove teammove2 = new TeamMove(3037, 3038, 1);
        public static TeamMove teammove3 = new TeamMove(3038, 3047, 1);
        public static TeamMove teammove4 = new TeamMove(3047, 3052, 1);
        public static TeamMove teammove5 = new TeamMove(3052, 3051, 1);
        public static TeamMove teammove6 = new TeamMove(3051, 3056, 1);
        public static TeamMove teammove7 = new TeamMove(3056, 3057, 2);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 3057;//撤离
    }

    static class Map6_4N
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 90024;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(4066);//主力
        public static Spots spots2 = new Spots(4070);//主力

        public static Spots[] Mission_Start_spots = { spots1,spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(4066, 4067, 1);
        public static TeamMove teammove2 = new TeamMove(4067, 4077, 1);
        public static TeamMove teammove3 = new TeamMove(4077, 4078, 1);
        public static TeamMove teammove4 = new TeamMove(4078, 4082, 1);//分支开始
        public static TeamMove teammove5 = new TeamMove(4082, 4079, 1);//分支1向上
        public static TeamMove teammove6 = new TeamMove(4079, 4068, 1);//分支2向左1
        public static TeamMove teammove7 = new TeamMove(4068, 4079, 1);//分支2向左2
        public static TeamMove teammove8 = new TeamMove(4079, 4082, 1);//分支3

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 4082;//撤离
    }




    static class Map0_2
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 2;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(9);//主力
        public static Spots spots2 = new Spots(12);//辅助

        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(9, 17, 1);
        public static TeamMove teammove2 = new TeamMove(17, 18, 1);
        public static TeamMove teammove3 = new TeamMove(18, 19, 1);
        public static TeamMove teammove4 = new TeamMove(19, 16, 1);
        public static TeamMove teammove5 = new TeamMove(16, 23, 1);
        public static TeamMove teammove6 = new TeamMove(23, 25, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 3033;//撤离
    }


    static class Map1_2
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 6;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(92);//主力


        public static Spots[] Mission_Start_spots = { spots1};//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(92, 93, 1);
        public static TeamMove teammove2 = new TeamMove(93, 94, 1);
        public static TeamMove teammove3 = new TeamMove(94, 95, 1);
        public static TeamMove teammove4 = new TeamMove(95, 96, 1);
        public static TeamMove teammove5 = new TeamMove(96, 98, 1);
        public static TeamMove teammove6 = new TeamMove(98, 96, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 3033;//撤离
    }




    static class Map7_6
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 70;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(1948);//主力
        public static Spots spots2 = new Spots(1948);//辅助

        public static Spots[] Mission_Start_spots = { spots1};//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(1948, 1947, 1);
        public static TeamMove teammove2 = new TeamMove(1947, 1949, 1);
        public static TeamMove teammove3 = new TeamMove(1949, 1947, 1);
        public static TeamMove teammove4 = new TeamMove(1947, 1948, 2);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 1948;//撤离
    }

    static class Map1_6
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(133);//主力
        public static Spots spots2 = new Spots(133);//辅助

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(133, 134, 1);
        public static TeamMove teammove2 = new TeamMove(134, 135, 1);
        public static TeamMove teammove3 = new TeamMove(135, 139, 1);
        public static TeamMove teammove4 = new TeamMove(139, 136, 1);
        public static TeamMove teammove5 = new TeamMove(136, 144, 1);
        public static TeamMove teammove6 = new TeamMove(144, 148, 1);
        public static TeamMove teammove7 = new TeamMove(148, 149, 1);
        public static TeamMove teammove8 = new TeamMove(149, 146, 1);
        public static TeamMove teammove9 = new TeamMove(146, 147, 1);
        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                    _dic_TeamMove[8] = teammove9;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序

        public static int BossPos(string result)
        {
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["enemy_move"];
            foreach (JsonData item in jsonData)
            {
                if (item["from_spot_id"].Int == 145 && item["to_spot_id"].Int == 146)
                    return 1;//需要打还带草在打boss

            }
            return 0;//直接打boss再占领
        }

        public static int HomePos1(string result)
        {
            try
            {
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["enemy_move"];
                foreach (JsonData item in jsonData)
                {
                    if (item["from_spot_id"].Int == 135 && item["to_spot_id"].Int == 134)
                        return 1;//需要打

                }
                return 0;//不需要打
            }
            catch (Exception)
            {
                return 0;//不需要打
            }

        }
        public static int HomePos2(string result)
        {
            try
            {
                JsonData jsonData = JsonMapper.ToObject(result);
                jsonData = jsonData["enemy_move"];
                foreach (JsonData item in jsonData)
                {
                    if (item["from_spot_id"].Int == 145 && item["to_spot_id"].Int == 146)
                        return 1;//需要打

                }
                return 0;//不需要打
            }
            catch (Exception)
            {
                return 0;//不需要打
            } 

        }
        public static int withdrawSpot = 1948;//撤离
    }


    static class Map2_6
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 20;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(260);//主力


        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(260, 261, 1);
        public static TeamMove teammove2 = new TeamMove(261, 263, 1);
        public static TeamMove teammove3 = new TeamMove(263, 267, 1);
        public static TeamMove teammove4 = new TeamMove(267, 271, 1);
        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序

    }

    static class Map3_6
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 30;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(427);//主力
        public static Spots spots2 = new Spots(431);//辅助

        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(427, 422, 1);
        public static TeamMove teammove2 = new TeamMove(422, 423, 1);
        public static TeamMove teammove3 = new TeamMove(423, 424, 1);
        public static TeamMove teammove4 = new TeamMove(424, 425, 1);
        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 427;//撤离
    }

    static class Map4_6
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 40;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(582);//主力
        public static Spots spots2 = new Spots(587);//辅助

        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(582, 588, 1);
        public static TeamMove teammove2 = new TeamMove(588, 594, 1);
        public static TeamMove teammove3 = new TeamMove(594, 598, 1);
        public static TeamMove teammove4 = new TeamMove(598, 604, 1);
        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序

    }

    static class Map5_6
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 50;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(803);//主力
        public static Spots spots2 = new Spots(807);//辅助

        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(803, 808, 1);
        public static TeamMove teammove2 = new TeamMove(808, 813, 1);
        public static TeamMove teammove3 = new TeamMove(813, 820, 1);
        public static TeamMove teammove4 = new TeamMove(820, 826, 1);
        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序

    }

    static class Map6_6
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 60;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(1616);//主力
        public static Spots spots2 = new Spots(1618);//辅助

        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(1616, 1634, 1);
        public static TeamMove teammove2 = new TeamMove(1634, 1635, 1);
        public static TeamMove teammove3 = new TeamMove(1635, 1620, 1);
        public static TeamMove teammove4 = new TeamMove(1620, 1621, 1);
        public static TeamMove teammove5 = new TeamMove(1621, 1636, 1);
        public static TeamMove teammove6 = new TeamMove(1636, 1632, 1);
        public static TeamMove teammove7 = new TeamMove(1632, 1633, 1);
        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序

    }

    static class Map8_6
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 80;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(3788);//主力
        public static Spots spots2 = new Spots(3788);//主力
        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(3788, 3658, 1);
        public static TeamMove teammove2 = new TeamMove(3658, 3789, 1);
        public static TeamMove teammove3 = new TeamMove(3789, 3662, 1);

        public static TeamMove teammove4 = new TeamMove(3662, 3679, 1);
        public static TeamMove teammove5 = new TeamMove(3679, 3681, 1);
        public static TeamMove teammove6 = new TeamMove(3681, 3682, 1);

        public static TeamMove teammove7 = new TeamMove(3682, 3667, 1);
        public static TeamMove teammove8 = new TeamMove(3667, 3673, 1);
        public static TeamMove teammove9 = new TeamMove(3673, 3664, 1);

        public static TeamMove teammove10 = new TeamMove(3664, 3670, 1);
        public static TeamMove teammove11 = new TeamMove(3670, 3669, 1);

        public static TeamMove teammove12 = new TeamMove(3669, 3678, 1);
        public static TeamMove teammove13 = new TeamMove(3678, 3671, 1);
        public static TeamMove teammove14 = new TeamMove(3671, 3677, 1);
        public static TeamMove teammove15 = new TeamMove(3677, 3668, 1);











        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;

                    _dic_TeamMove[11] = teammove12;
                    _dic_TeamMove[12] = teammove13;
                    _dic_TeamMove[13] = teammove14;
                    _dic_TeamMove[14] = teammove15;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序

        public static int HomePos1(string result)
        {
            if(result.Contains("error")) return 0;//不需要打
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["enemy_move"];
            foreach (JsonData item in jsonData)
            {
                if (item["from_spot_id"].Int == 3657 && item["to_spot_id"].Int == 3788)
                    return 1;//需要打

            }
            return 0;//不需要打
        }
        public static int HomePos2(string result)
        {
            if (result.Contains("error")) return 0;//不需要打
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["enemy_move"];
            foreach (JsonData item in jsonData)
            {
                if (item["from_spot_id"].Int == 3681 && item["to_spot_id"].Int == 3679)
                    return 1;//需要打
                if (item["from_spot_id"].Int == 3681 && item["to_spot_id"].Int == 3682)
                    return 2;//需要打
            }
            return 0;//不需要打
        }
        public static int HomePos3(string result)
        {
            if (result.Contains("error")) return 0;//不需要打
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["enemy_move"];
            foreach (JsonData item in jsonData)
            {
                if (item["from_spot_id"].Int == 3683 && item["to_spot_id"].Int == 3679)
                    return 1;//需要打
            }
            return 0;//不需要打
        }
        public static int PosCheck1(string result)
        {
            if (result.Contains("error")) return 0;//不需要打
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["enemy_move"];
            foreach (JsonData item in jsonData)
            {
                if (item["to_spot_id"].Int == 3682)
                    return 1;//需要打
            }
            return 0;//不需要打
        }
        public static int PosCheck2(string result)
        {
            if (result.Contains("error")) return 0;//不需要打
            JsonData jsonData = JsonMapper.ToObject(result);
            jsonData = jsonData["enemy_move"];
            foreach (JsonData item in jsonData)
            {
                if (item["to_spot_id"].Int == 3679)
                    return 1;//需要打
            }
            return 0;//不需要打
        }
    }

    static class Map10_6
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 100;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5363);//主力
        public static Spots spots2 = new Spots(5363);//主力
        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5363, 5360, 1);
        public static TeamMove teammove2 = new TeamMove(5360, 5357, 1);
        public static TeamMove teammove3 = new TeamMove(5357, 5346, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;


                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序

     
    }


    static class Map7_6BOSS
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 70;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(1948);//主力
        public static Spots spots2 = new Spots(1948);//辅助

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(1948, 1947, 1);
        public static TeamMove teammove2 = new TeamMove(1947, 1948, 2);
        public static TeamMove teammove3 = new TeamMove(1948, 1947, 2);

        public static TeamMove teammove4 = new TeamMove(1947, 1946, 1);
        public static TeamMove teammove5 = new TeamMove(1946, 2152, 1);
        public static TeamMove teammove6 = new TeamMove(2152, 1941, 1);
        public static TeamMove teammove7 = new TeamMove(1941, 1942, 1);
        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 1948;//撤离
    }

    static class Map10_4E
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 104;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5494);//主力
        public static Spots spots2 = new Spots(5480);//辅助

        public static Spots[] Mission_Start_spots = { spots2, spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5494, 5495, 1);
        public static TeamMove teammove2 = new TeamMove(5495, 5492, 1);
        public static TeamMove teammove3 = new TeamMove(5492, 5495, 1);
        public static TeamMove teammove4 = new TeamMove(5495, 5494, 1);
        public static TeamMove teammove5 = new TeamMove(5494, 5497, 1);
        public static TeamMove teammove6 = new TeamMove(5497, 5494, 1);
        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 5494;//撤离
    }
    static class Map4_1
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 35;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(513);//主力
        public static Spots spots2 = new Spots(516);//辅助

        public static Spots[] Mission_Start_spots = { spots2, spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(513, 512, 1);
        public static TeamMove teammove2 = new TeamMove(512, 511, 1);
        public static TeamMove teammove3 = new TeamMove(511, 509, 1);
        public static TeamMove teammove4 = new TeamMove(509, 508, 1);
        public static TeamMove teammove5 = new TeamMove(508, 509, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 5494;//撤离
    }



    static class MapGun_PZB38
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10033;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(4243);//主力
        public static Spots spots2 = new Spots(4245);//辅助

        public static string saveHostageSpots1 = "4247";
        public static string saveHostageSpots2= "4245";
        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(4243, 4244, 1);
        public static TeamMove teammove2 = new TeamMove(4244, 4245, 1);
        public static TeamMove teammove3 = new TeamMove(4245, 4246, 1);
        public static TeamMove teammove4 = new TeamMove(4246, 4247, 1);
        public static TeamMove teammove5 = new TeamMove(4247, 4253, 1);

        public static TeamMove teammove6 = new TeamMove(4253, 4248, 1);
        public static TeamMove teammove7 = new TeamMove(4248, 4249, 1);
        public static TeamMove teammove8 = new TeamMove(4249, 4250, 1);

        public static TeamMove teammove9 = new TeamMove(4250, 4261, 1);
        public static TeamMove teammove10 = new TeamMove(4261, 4259, 1);
        public static TeamMove teammove11 = new TeamMove(4259, 4251, 1);

        public static TeamMove teammove12 = new TeamMove(4251, 4255, 1);
        public static TeamMove teammove13 = new TeamMove(4255, 4258, 1);//
        public static TeamMove teammove14 = new TeamMove(4258, 4255, 1);

        public static TeamMove teammove15 = new TeamMove(4255, 4252, 1);
        public static TeamMove teammove16 = new TeamMove(4252, 4246, 1);
        public static TeamMove teammove17 = new TeamMove(4246, 4245, 2);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;

                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;
                    _dic_TeamMove[11] = teammove12;
                    _dic_TeamMove[12] = teammove13;
                    _dic_TeamMove[13] = teammove14;
                    _dic_TeamMove[14] = teammove15;
                    _dic_TeamMove[15] = teammove16;
                    _dic_TeamMove[16] = teammove17;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 5577;//撤离
    }




    static class MapGun_Light
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10054;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5561);//主力
        public static Spots spots2 = new Spots(5561);//辅助

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5561, 5570, 1);
        public static TeamMove teammove2 = new TeamMove(5570, 5573, 1);
        public static TeamMove teammove3 = new TeamMove(5573, 5576, 1);
        public static TeamMove teammove4 = new TeamMove(5576, 5578, 1);
        public static TeamMove teammove5 = new TeamMove(5578, 5575, 1);

        public static TeamMove teammove6 = new TeamMove(5575, 5577, 1);
        public static TeamMove teammove7 = new TeamMove(5577, 5575, 1);
        public static TeamMove teammove8 = new TeamMove(5575, 5577, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 5577;//撤离
    }

    static class MapGun_PM7
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10064;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5774);//主力
        public static Spots spots2 = new Spots(5774);
        public static Spots spots3 = new Spots(5774);

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5774, 5776, 1);
        public static TeamMove teammove2 = new TeamMove(5774, 5775, 1);
        public static TeamMove teammove3 = new TeamMove(5774, 5775, 2);
        public static TeamMove teammove4 = new TeamMove(5775, 5774, 1);
        public static TeamMove teammove5 = new TeamMove(5776, 5774, 2);



        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 5774;//撤离
    }

    static class MapGun_M4A1
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10089;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6392);//主力
        public static Spots spots2 = new Spots(6392);

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6392, 6391, 1);
        public static TeamMove teammove2 = new TeamMove(6391, 6373, 1);
        public static TeamMove teammove3 = new TeamMove(6373, 6372, 1);

        public static TeamMove teammove4 = new TeamMove(6372, 6371, 1);
        public static TeamMove teammove5 = new TeamMove(6371, 6398, 1);
        public static TeamMove teammove6 = new TeamMove(6398, 6402, 1);

        public static TeamMove teammove7 = new TeamMove(6402, 6401, 1);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 5774;//撤离
    }


    static class MapEquip_UMP
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10040;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(4574);//主力
        public static Spots spots2 = new Spots(4559);//辅助
        public static Spots spots3 = new Spots(4567);//辅助

        public static Spots[] Mission_Start_spots = { spots1 , spots2 , spots3};//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(4574, 4572, 1);
        public static TeamMove teammove2 = new TeamMove(4572, 4582, 1);
        public static TeamMove teammove3 = new TeamMove(4582, 4573, 1);
        public static TeamMove teammove4 = new TeamMove(4573, 4583, 1);
        public static TeamMove teammove5 = new TeamMove(4583, 4555, 1);

        public static TeamMove teammove6 = new TeamMove(4555, 4568, 1);
        public static TeamMove teammove7 = new TeamMove(4568, 4603, 1);
        public static TeamMove teammove8 = new TeamMove(4603, 4568, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot1 = 4559;//撤离
        public static int withdrawSpot2 = 4568;//撤离
    }

    static class MapGUN_DSR_50
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10086;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6284);//主力 机霰队 8
        public static Spots spots2 = new Spots(6284);//主力 李白队 1
        public static Spots spots3 = new Spots(6284);//辅助 雷电   6
        public static Spots spots4 = new Spots(6284);//辅助 M4     7

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6284, 6303, 1);//机霰队 8
        public static TeamMove teammove2 = new TeamMove(6303, 6284, 2);//机霰队 8
        public static TeamMove teammove3 = new TeamMove(6284, 6304, 1);//机霰队 8
        public static TeamMove teammove4 = new TeamMove(6304, 6305, 1);//机霰队 8
        public static TeamMove teammove5 = new TeamMove(6284, 6304, 1);//M4     7
        public static TeamMove teammove6 = new TeamMove(6284, 6304, 2);//李白队 1
        public static TeamMove teammove7 = new TeamMove(6304, 6305, 2);//李白队 1
        public static TeamMove teammove8 = new TeamMove(6304, 6284, 2);//机霰队 8
        public static TeamMove teammove0 = new TeamMove(6284, 6303, 2);//机霰队 8
        public static TeamMove teammove9 = new TeamMove(6305, 6293, 1);//李白队 1
        public static TeamMove teammove10 = new TeamMove(6293, 6299, 2);//李白队 1
        public static TeamMove teammove11 = new TeamMove(6304, 6305, 1);//辅助 M4     7
        public static TeamMove teammove12 = new TeamMove(6305, 6293, 2);//辅助 M4     7
        public static TeamMove teammove13 = new TeamMove(6293, 6305, 2);//辅助 M4     7
        public static TeamMove teammove14 = new TeamMove(6299, 6293, 2);//李白队 1
        public static TeamMove teammove15 = new TeamMove(6293, 6306, 1);//李白队 1
        public static TeamMove teammove16 = new TeamMove(6306, 6295, 1);//李白队 1
        public static TeamMove teammove17 = new TeamMove(6305, 6293, 1);//辅助 M4     7
        public static TeamMove teammove18 = new TeamMove(6293, 6306, 1);//辅助 M4     7
        public static TeamMove teammove19 = new TeamMove(6295, 6301, 1);//李白队 1
        public static TeamMove teammove20 = new TeamMove(6301, 6302, 1);//李白队 1
        public static TeamMove teammove21 = new TeamMove(6302, 6308, 1);//李白队 1

        public static TeamMove teammove22 = new TeamMove(6308, 6290, 1);//李白队 1
        public static TeamMove teammove23 = new TeamMove(6290, 6297, 1);//李白队 1
        public static TeamMove teammove24 = new TeamMove(6297, 6310, 1);//李白队 1
        public static TeamMove teammove25 = new TeamMove(6310, 6298, 1);//李白队 1

        









        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;
                    _dic_TeamMove[11] = teammove12;
                    _dic_TeamMove[12] = teammove13;
                    _dic_TeamMove[13] = teammove14;
                    _dic_TeamMove[14] = teammove15;
                    _dic_TeamMove[15] = teammove16;
                    _dic_TeamMove[16] = teammove17;
                    _dic_TeamMove[17] = teammove18;
                    _dic_TeamMove[18] = teammove19;
                    _dic_TeamMove[19] = teammove20;
                    _dic_TeamMove[20] = teammove21;
                    _dic_TeamMove[21] = teammove22;
                    _dic_TeamMove[22] = teammove23;
                    _dic_TeamMove[23] = teammove24;
                    _dic_TeamMove[24] = teammove25;
                    _dic_TeamMove[25] = teammove0;

    }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot1 = 4559;//撤离
        public static int withdrawSpot2 = 4568;//撤离
    }

    static class MapGUN_DSR_50_2
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10060;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5701);//主力
        public static Spots spots2 = new Spots(5699);//辅助


        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5701, 5694, 1);
        public static TeamMove teammove2 = new TeamMove(5694, 5682, 1);
        public static TeamMove teammove3 = new TeamMove(5682, 5690, 1);
        public static TeamMove teammove4 = new TeamMove(5690, 5683, 1);
        public static TeamMove teammove5 = new TeamMove(5683, 5693, 1);


        public static TeamMove teammove6 = new TeamMove(5743, 5732, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6192;//撤离
    }


    static class MapGUN_M1887
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10083;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6192);//主力
        public static Spots spots2 = new Spots(6187);//辅助
        public static Spots spots3 = new Spots(6188);//辅助
        public static Spots spots4 = new Spots(6189);//辅助
        public static Spots spots5 = new Spots(6190);//辅助

        public static Spots[] Mission_Start_spots = { spots1, spots2, spots3, spots4, spots5 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6192, 6198, 1);
        public static TeamMove teammove2 = new TeamMove(6198, 6203, 1);
        public static TeamMove teammove3 = new TeamMove(6203, 6208, 1);
        public static TeamMove teammove4 = new TeamMove(6208, 6214, 1);
        public static TeamMove teammove5 = new TeamMove(6214, 6213, 1);


        public static TeamMove teammove6 = new TeamMove(6213, 6212, 1);
        public static TeamMove teammove7 = new TeamMove(6212, 6213, 1);
        public static TeamMove teammove8 = new TeamMove(6213, 6208, 1);

        public static TeamMove teammove9 = new TeamMove(6208, 6203, 1);
        public static TeamMove teammove10 = new TeamMove(6203, 6198, 1);
        public static TeamMove teammove11 = new TeamMove(6198, 6192, 1);





        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6192;//撤离

    }

    static class MapGUN_M1887_2
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10056;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5596);//主力


        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5596, 5597, 1);
        public static TeamMove teammove2 = new TeamMove(5597, 5605, 1);
        public static TeamMove teammove3 = new TeamMove(5605, 5598, 1);
        public static TeamMove teammove4 = new TeamMove(5598, 5611, 1);

        public static TeamMove teammove5 = new TeamMove(5611, 5610, 1);
        public static TeamMove teammove6 = new TeamMove(5610, 5603, 1);
        public static TeamMove teammove7 = new TeamMove(5603, 5613, 1);






        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;

 
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6192;//撤离

    }


    static class MapGUN_57
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10062;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5731);//主力
        public static Spots spots2 = new Spots(5731);//辅助


        public static Spots[] Mission_Start_spots = { spots1};//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5731, 5733, 1);
        public static TeamMove teammove2 = new TeamMove(5733, 5738, 1);
        public static TeamMove teammove3 = new TeamMove(5738, 5740, 1);
        public static TeamMove teammove4 = new TeamMove(5740, 5744, 1);
        public static TeamMove teammove5 = new TeamMove(5744, 5743, 1);
        public static TeamMove teammove6 = new TeamMove(5743, 5732, 1);
        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6192;//撤离

    }



    static class MapGUN_ART556
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10063;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5747);//主力
        public static Spots spots2 = new Spots(5747);//主力
        public static Spots spots3 = new Spots(5746);//辅助
        public static Spots spots4 = new Spots(5747);//辅助

        public static Spots[] Mission_Start_spots = { spots1, spots3 };//部署梯队的信息




        public static TeamMove teammove1 = new TeamMove(5747, 5748, 1);
        public static TeamMove teammove2 = new TeamMove(5748, 5751, 1);
        public static TeamMove teammove3 = new TeamMove(5751, 5758, 1);
        public static TeamMove teammove4 = new TeamMove(5758, 5759, 1);

        public static TeamMove teammove5 = new TeamMove(5759, 5761, 1);
        public static TeamMove teammove6 = new TeamMove(5747, 5748, 1);

        public static TeamMove teammove7 = new TeamMove(5748, 5751, 1);
        public static TeamMove teammove8 = new TeamMove(5751, 5758, 2);
        public static TeamMove teammove9 = new TeamMove(5758, 5764, 1);
        public static TeamMove teammove10 = new TeamMove(5764, 5767, 2);
        public static TeamMove teammove11 = new TeamMove(5767, 5769, 1);
        public static TeamMove teammove12 = new TeamMove(5747, 5748, 1);

        public static TeamMove teammove13 = new TeamMove(5769, 5772, 1);
        public static TeamMove teammove14 = new TeamMove(5761, 5769, 1);
        public static TeamMove teammove15 = new TeamMove(5769, 5770, 1);

        public static TeamMove teammove16 = new TeamMove(5770, 5773, 1);



        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;
                    _dic_TeamMove[11] = teammove12;
                    _dic_TeamMove[12] = teammove13;
                    _dic_TeamMove[13] = teammove14;
                    _dic_TeamMove[14] = teammove15;
                    _dic_TeamMove[15] = teammove16;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6216;//撤离

    }

    static class MapGUN_JS
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10055;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5581);//主力
        public static Spots spots2 = new Spots(5581);//主力
        public static Spots spots3 = new Spots(5581);//辅助


        public static Spots[] Mission_Start_spots = { spots1};//部署梯队的信息




        public static TeamMove teammove1 = new TeamMove(5581, 5592, 1);
        public static TeamMove teammove2 = new TeamMove(5592, 5584, 1);
        public static TeamMove teammove3 = new TeamMove(5584, 5595, 1);
        public static TeamMove teammove4 = new TeamMove(5595, 5582, 1);
        public static TeamMove teammove5 = new TeamMove(5582, 5588, 1);

        public static TeamMove teammove6 = new TeamMove(5581, 5592, 1);//2队
        public static TeamMove teammove7 = new TeamMove(5592, 5581, 2);//2队


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot1 = 5581;//撤离
        public static int withdrawSpot2 = 5588;//撤离
    }

    static class MapGUN_SPP_1
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10069;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5877);//主力 3
        public static Spots spots2 = new Spots(5876);//主力 5
        public static Spots spots3 = new Spots(5876);//辅助


        public static Spots[] Mission_Start_spots = { spots1 , spots2};//部署梯队的信息




        public static TeamMove teammove1 = new TeamMove(5877, 5891, 1); //0
        public static TeamMove teammove2 = new TeamMove(5891, 5890, 1); //0
        public static TeamMove teammove3 = new TeamMove(5876, 5871, 1); //1
        public static TeamMove teammove4 = new TeamMove(5871, 5878, 1); //1
        public static TeamMove teammove5 = new TeamMove(5878, 5871, 1); //1

        public static TeamMove teammove6 = new TeamMove(5871, 5876, 2); //1



        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot1 = 5890;//撤离
        public static int withdrawSpot2 = 5876;//撤离
    }


    /// <summary>
    /// 底层升变4
    /// </summary>
    static class MapEquip_HK416
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10077;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6049);//主力
        public static Spots spots2 = new Spots(6067);//辅助


        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6049, 6048, 1);
        public static TeamMove teammove2 = new TeamMove(6048, 6047, 1);
        public static TeamMove teammove3 = new TeamMove(6047, 6042, 1);

        public static TeamMove teammove4 = new TeamMove(6042, 6047, 1);

        public static TeamMove teammove5 = new TeamMove(6047, 6046, 1);

        public static TeamMove teammove6 = new TeamMove(6046, 6045, 1);

        public static TeamMove teammove7 = new TeamMove(6045, 6044, 1);
        public static TeamMove teammove8 = new TeamMove(6044, 6045, 1);

        public static TeamMove teammove9 = new TeamMove(6045, 6053, 1);
        public static TeamMove teammove10 = new TeamMove(6053, 6054, 1);
        public static TeamMove teammove11 = new TeamMove(6054, 6055, 1);

        public static TeamMove teammove12 = new TeamMove(6055, 6033, 1);
        public static TeamMove teammove13 = new TeamMove(6033, 6055, 1);
        public static TeamMove teammove14 = new TeamMove(6055, 6063, 1);

        public static TeamMove teammove15 = new TeamMove(6063, 6067, 2);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;

                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;
                    _dic_TeamMove[11] = teammove12;
                    _dic_TeamMove[12] = teammove13;
                    _dic_TeamMove[13] = teammove14;
                    _dic_TeamMove[14] = teammove15;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6067;//撤离

    }

    /// <summary>
    /// 2018冬活 第二轮月亮 分歧点
    /// </summary>
    static class MapE2_A_0_in_2018_winter
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10065;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5818);//主力
        public static Spots spots2 = new Spots(5818);//辅助


        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5818, 5811, 1);
        public static TeamMove teammove2 = new TeamMove(5811, 5816, 1);
        public static TeamMove teammove3 = new TeamMove(5816, 5817, 1);

        public static TeamMove teammove4 = new TeamMove(5817, 5822, 1);

        public static TeamMove teammove5 = new TeamMove(5822, 5814, 1);

        

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6067;//撤离

    }

    static class MapE2_A_1_in_2018_winter
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10066;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5825);//主力

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5825, 5829, 1);
        public static TeamMove teammove2 = new TeamMove(5829, 5835, 1);
        public static TeamMove teammove3 = new TeamMove(5835, 5834, 1);

        public static TeamMove teammove4 = new TeamMove(5834, 5836, 1);

        public static TeamMove teammove5 = new TeamMove(5836, 5840, 1);

        public static TeamMove teammove6 = new TeamMove(5840,5828, 1);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6067;//撤离

    }

    static class MapE2_A_2_in_2018_winter
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10067;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5845);//主力

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5845, 5847, 1);
        public static TeamMove teammove2 = new TeamMove(5847, 5850, 1);
        public static TeamMove teammove3 = new TeamMove(5850, 5852, 1);

        public static TeamMove teammove4 = new TeamMove(5852, 5856, 1);




        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6067;//撤离

    }

    static class MapE2_A_3_in_2018_winter
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10068;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5864);//主力

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5864, 5861, 1);
        public static TeamMove teammove2 = new TeamMove(5861, 5862, 1);
        public static TeamMove teammove3 = new TeamMove(5862, 5863, 1);

        public static TeamMove teammove4 = new TeamMove(5863, 5858, 1);




        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6067;//撤离

    }

    static class MapE2_A_4_in_2018_winter
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10069;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5877);//主力
        public static Spots spots2 = new Spots(5876);//主力

        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5877, 5891, 1);
        public static TeamMove teammove2 = new TeamMove(5891, 5890, 1);

        public static TeamMove teammove3 = new TeamMove(5876, 5871, 1);
        public static TeamMove teammove4 = new TeamMove(5871, 5878, 1);

        public static TeamMove teammove5 = new TeamMove(5890, 5874, 1);
        public static TeamMove teammove6 = new TeamMove(5874, 5875, 1);
        public static TeamMove teammove7 = new TeamMove(5875, 5872, 1);

        public static TeamMove teammove8 = new TeamMove(5878, 5871, 1);
        public static TeamMove teammove9 = new TeamMove(5871, 5876, 1);



        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                    _dic_TeamMove[8] = teammove9;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6067;//撤离

    }



    static class MapE1_1
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10043;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(4971);//主力
        public static Spots spots2 = new Spots(4971);//主力
        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(4971, 4978, 1);
        public static TeamMove teammove2 = new TeamMove(4978, 4971, 2);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 4971;//撤离
    }

    static class MapE1_2
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10044;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(4984);//主力
        public static Spots spots2 = new Spots(4984);//主力
        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(4984, 4993, 1);
        public static TeamMove teammove2 = new TeamMove(4993, 4984, 2);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 4984;//撤离
    }

    static class MapE1_3
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10045;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5003);//辅助
        public static Spots spots2 = new Spots(5004);//主力
        public static Spots[] Mission_Start_spots = { spots1 ,spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5004, 5008, 1);
        public static TeamMove teammove2 = new TeamMove(5008, 5009, 1);
        public static TeamMove teammove3 = new TeamMove(5009, 5005, 1);
        public static TeamMove teammove4 = new TeamMove(5005, 5002, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 5002;//撤离
    }

    static class MapE1_3_TYPE2
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10045;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5002);//主力
        public static Spots spots2 = new Spots(5003);//辅助
        public static Spots spots3 = new Spots(5004);//辅助
        public static Spots spots4 = new Spots(5002);//辅助

        public static Spots[] Mission_Start_spots = { spots1, spots2, spots3 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5002, 5005, 1);
        public static TeamMove teammove2 = new TeamMove(5005, 5002, 2);
        public static TeamMove teammove3 = new TeamMove(5002, 5003, 2);
        public static TeamMove teammove4 = new TeamMove(5003, 5004, 2);
        public static TeamMove teammove5 = new TeamMove(5004, 5008, 1);
        public static TeamMove teammove6 = new TeamMove(5008, 5009, 1);
        public static TeamMove teammove7 = new TeamMove(5009, 5011, 1);
        //第一回合结束
        public static TeamMove teammove8 = new TeamMove(5011, 5009, 1);
        public static TeamMove teammove9 = new TeamMove(5009, 5010, 1);
        public static TeamMove teammove10 = new TeamMove(5010, 5012, 1);

        public static TeamMove teammove11 = new TeamMove(5012, 5014, 1);
        public static TeamMove teammove12 = new TeamMove(5014, 5015, 1);
        public static TeamMove teammove13 = new TeamMove(5015, 5017, 1);
        public static TeamMove teammove14 = new TeamMove(5017, 5019, 1);
        //第二回合结束

        public static TeamMove teammove15 = new TeamMove(5019, 5020, 1);
        public static TeamMove teammove16 = new TeamMove(5020, 5019, 1);
        public static TeamMove teammove17 = new TeamMove(5019, 5021, 1);
        //第三回合结束

        public static TeamMove teammove18 = new TeamMove(5021, 5019, 1);
        public static TeamMove teammove19 = new TeamMove(5019, 5020, 1);
        public static TeamMove teammove20 = new TeamMove(5020, 5022, 1);

        public static TeamMove teammove21 = new TeamMove(5022, 5024, 1);
        public static TeamMove teammove22 = new TeamMove(5024, 5025, 1);
        public static TeamMove teammove23 = new TeamMove(5025, 5027, 1);
        public static TeamMove teammove24 = new TeamMove(5027, 5007, 1);








        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;
                    _dic_TeamMove[11] = teammove12;
                    _dic_TeamMove[12] = teammove13;
                    _dic_TeamMove[13] = teammove14;
                    _dic_TeamMove[14] = teammove15;
                    _dic_TeamMove[15] = teammove16;
                    _dic_TeamMove[16] = teammove17;
                    _dic_TeamMove[17] = teammove18;
                    _dic_TeamMove[18] = teammove19;
                    _dic_TeamMove[19] = teammove20;
                    _dic_TeamMove[20] = teammove21;
                    _dic_TeamMove[21] = teammove22;
                    _dic_TeamMove[22] = teammove23;
                    _dic_TeamMove[23] = teammove24;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 5002;//撤离
    }



    static class MapE1_4
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10046;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5054);//辅助
        public static Spots spots2 = new Spots(5054);//主力
        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5054, 5050, 1);
        public static TeamMove teammove2 = new TeamMove(5050, 5036, 1);
        public static TeamMove teammove3 = new TeamMove(5036, 5044, 1);
        public static TeamMove teammove4 = new TeamMove(5044, 5032, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 5032;//撤离
    }

    static class MapE1_4BOSS
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10046;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5054);

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5031, 5055, 1);
        public static TeamMove teammove2 = new TeamMove(5055, 5041, 1);
        public static TeamMove teammove3 = new TeamMove(5041, 5038, 1);
        public static TeamMove teammove4 = new TeamMove(5038, 5053, 1);

        public static TeamMove teammove5 = new TeamMove(5053, 5030, 1);
        public static TeamMove teammove6 = new TeamMove(5030, 5052, 1);
        public static TeamMove teammove7 = new TeamMove(5052, 5037, 1);
        public static TeamMove teammove8 = new TeamMove(5037, 5042, 1);



        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 5032;//撤离
    }
    static class MapE2_1
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10047;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5064);//主力
        public static Spots spots2 = new Spots(5064);//
        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5064, 5061, 1);
        public static TeamMove teammove2 = new TeamMove(5061, 5060, 1);
        public static TeamMove teammove3 = new TeamMove(5060, 5066, 1);
        public static TeamMove teammove4 = new TeamMove(5066, 5069, 1);
        public static TeamMove teammove5 = new TeamMove(5069, 5074, 1);
        public static TeamMove teammove6 = new TeamMove(5074, 5078, 1);

        public static TeamMove teammove7 = new TeamMove(5078, 5062, 1);
        public static TeamMove teammove8 = new TeamMove(5062, 5084, 1);
        public static TeamMove teammove9 = new TeamMove(5084, 5062, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;
                    _dic_TeamMove[8] = teammove9;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 5062;//撤离
    }



    static class MapE2_2
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10048;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5085);//辅助
        public static Spots spots2 = new Spots(5085);//主力
        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5085, 5086, 1);
        public static TeamMove teammove2 = new TeamMove(5086, 5087, 1);
        public static TeamMove teammove3 = new TeamMove(5087, 5089, 1);
        public static TeamMove teammove4 = new TeamMove(5089, 5087, 1);
        public static TeamMove teammove5 = new TeamMove(5087, 5086, 1);
        public static TeamMove teammove6 = new TeamMove(5086, 5085, 2);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 5085;//撤离
    }

    static class MapE2_3
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10049;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5110);//辅助
        public static Spots spots2 = new Spots(5110);//主力
        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5110, 5139, 1);
        public static TeamMove teammove2 = new TeamMove(5139, 5110, 2);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 5110;//撤离
    }

    static class MapE2_4
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10050;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(5152);//辅助
        public static Spots spots2 = new Spots(5155);//主力
        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5152, 5154, 1);
        public static TeamMove teammove2 = new TeamMove(5154, 5157, 1);
        public static TeamMove teammove3 = new TeamMove(5157, 5159, 1);
        public static TeamMove teammove4 = new TeamMove(5159, 5148, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序



        public static int withdrawSpot = 5110;//撤离
    }

    static class MapE1_1_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10093;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6714);//主力
        public static Spots spots2 = new Spots(6714);//主力


        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6714, 6712, 1);
        public static TeamMove teammove2 = new TeamMove(6712, 6726, 1);
        public static TeamMove teammove3 = new TeamMove(6726, 6725, 1);
        public static TeamMove teammove4 = new TeamMove(6725, 6713, 1);



        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE1_2_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10094;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6734);//主力
        public static Spots spots2 = new Spots(6734);//主力


        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6734, 6744, 1);
        public static TeamMove teammove2 = new TeamMove(6744, 6735, 1);
        public static TeamMove teammove3 = new TeamMove(6735, 6748, 1);
        public static TeamMove teammove4 = new TeamMove(6748, 6733, 1);

        public static TeamMove teammove5 = new TeamMove(6733, 6732, 1);
        public static TeamMove teammove6 = new TeamMove(6732, 6736, 1);
        public static TeamMove teammove7 = new TeamMove(6736, 6737, 1);
        public static TeamMove teammove8 = new TeamMove(6737, 6731, 1);

        public static TeamMove teammove9 = new TeamMove(6731, 6730, 1);
        public static TeamMove teammove10 = new TeamMove(6730, 6747, 1);
        public static TeamMove teammove11 = new TeamMove(6747, 6728, 1);
        public static TeamMove teammove12 = new TeamMove(6734, 6744, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;

                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;
                    _dic_TeamMove[11] = teammove12;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE1_3_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10095;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6759);//主力
        public static Spots spots2 = new Spots(6759);//主力


        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6759, 6762, 1);
        public static TeamMove teammove2 = new TeamMove(6762, 6763, 1);
        public static TeamMove teammove3 = new TeamMove(6763, 6761, 1);
        public static TeamMove teammove4 = new TeamMove(6761, 6760, 1);

        public static TeamMove teammove5 = new TeamMove(6760, 6755, 1);
        public static TeamMove teammove6 = new TeamMove(6755, 6756, 1);
        public static TeamMove teammove7 = new TeamMove(6756, 6833, 1);
        public static TeamMove teammove8 = new TeamMove(6833, 6758, 1);
        

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;


                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE2_1_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10096;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6764);//主力
        public static Spots spots2 = new Spots(6764);//主力
        public static Spots spots3 = new Spots(6764);//主力


        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6764, 6781, 1);//
        public static TeamMove teammove2 = new TeamMove(6781, 6772, 1);//
        public static TeamMove teammove3 = new TeamMove(6764, 6781, 1);//
        public static TeamMove teammove4 = new TeamMove(6772, 6778, 1);//

        public static TeamMove teammove5 = new TeamMove(6778, 6779, 1);//



        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                    _dic_TeamMove[4] = teammove5;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE2_1_Light_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10096;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6764);//主力
        public static Spots spots2 = new Spots(6764);//主力

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6764, 6771, 1);
        public static TeamMove teammove2 = new TeamMove(6771, 6764, 1);
        public static TeamMove teammove3 = new TeamMove(6764, 6766, 1);
        public static TeamMove teammove4 = new TeamMove(6766, 6764, 2);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6764;//撤离
    }








    static class MapE2_2_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10097;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6801);//主力
        public static Spots spots2 = new Spots(6799);//主力
        public static Spots spots3 = new Spots(6801);//主力



        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6801, 6820, 1);
        public static TeamMove teammove2 = new TeamMove(6820, 6806, 1);
        public static TeamMove teammove3 = new TeamMove(6806, 6824, 1);
        public static TeamMove teammove4 = new TeamMove(6824, 6825, 1);

        public static TeamMove teammove5 = new TeamMove(6825, 6827, 1);
        public static TeamMove teammove6 = new TeamMove(6827, 6829, 1);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE2_3_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10098;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6862);//主力
        public static Spots spots2 = new Spots(6862);//主力
        public static Spots spots3 = new Spots(6862);//主力



        public static Spots[] Mission_Start_spots = { spots1};//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6862, 6864, 1);
        public static TeamMove teammove2 = new TeamMove(6864, 6863, 1);
        public static TeamMove teammove3 = new TeamMove(6862, 6864, 1);
        public static TeamMove teammove4 = new TeamMove(6863, 6865, 1);

        public static TeamMove teammove5 = new TeamMove(6865, 6860, 1);
        public static TeamMove teammove6 = new TeamMove(6864, 6863, 1);
        public static TeamMove teammove7 = new TeamMove(6863, 6865, 1);
        public static TeamMove teammove8 = new TeamMove(6860, 6859, 1);

        public static TeamMove teammove9 = new TeamMove(6859, 6858, 1);
        public static TeamMove teammove10 = new TeamMove(6858, 6845, 1);
        public static TeamMove teammove11 = new TeamMove(6845, 6842, 1);
        public static TeamMove teammove12 = new TeamMove(6842, 6834, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;

                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;
                    _dic_TeamMove[11] = teammove12;


                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE3_1_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10099;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6870);//主力




        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6870, 6869, 1);
        public static TeamMove teammove2 = new TeamMove(6869, 6883, 1);
        public static TeamMove teammove3 = new TeamMove(6883, 6882, 1);
        public static TeamMove teammove4 = new TeamMove(6882, 6879, 1);



        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE3_2_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10100;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6890);//主力
        public static Spots spots2 = new Spots(6890);//主力




        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6890, 6895, 1);
        public static TeamMove teammove2 = new TeamMove(6895, 6891, 1);
        public static TeamMove teammove3 = new TeamMove(6891, 6898, 1);
        public static TeamMove teammove4 = new TeamMove(6898, 6897, 1);

        public static TeamMove teammove5 = new TeamMove(6897, 6889, 1);
        public static TeamMove teammove6 = new TeamMove(6889, 6892, 1);
        public static TeamMove teammove7 = new TeamMove(6892, 6893, 1);
        public static TeamMove teammove8 = new TeamMove(6893, 6888, 1);

        public static TeamMove teammove9 = new TeamMove(6888, 6887, 1);
        public static TeamMove teammove10 = new TeamMove(6887, 6896, 1);
        public static TeamMove teammove11 = new TeamMove(6896, 6885, 1);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;

                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;



                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE3_3_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10101;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6914);//主力
        public static Spots spots2 = new Spots(6914);//主力
        public static Spots spots3 = new Spots(6914);//主力



        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6914, 6917, 1);
        public static TeamMove teammove2 = new TeamMove(6917, 6918, 1);
        public static TeamMove teammove3 = new TeamMove(6914, 6917, 1);
        public static TeamMove teammove4 = new TeamMove(6918, 6916, 1);

        public static TeamMove teammove5 = new TeamMove(6916, 6915, 1);
        public static TeamMove teammove6 = new TeamMove(6917, 6918, 1);
        public static TeamMove teammove7 = new TeamMove(6918, 6916, 1);//
        public static TeamMove teammove8 = new TeamMove(6915, 6910, 1);

        public static TeamMove teammove9 = new TeamMove(6910, 6911, 1);
        public static TeamMove teammove10 = new TeamMove(6911, 6987, 1);
        public static TeamMove teammove11 = new TeamMove(6987, 6913, 1);


        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;

                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;



                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE4_1_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10102;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6919);//主力
        public static Spots spots2 = new Spots(6919);//主力
        public static Spots spots3 = new Spots(6919);//主力



        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6919, 6934, 1);
        public static TeamMove teammove2 = new TeamMove(6934, 6925, 1);
        public static TeamMove teammove3 = new TeamMove(6919, 6934, 1);
        public static TeamMove teammove4 = new TeamMove(6925, 6931, 1);

        public static TeamMove teammove5 = new TeamMove(6934, 6923, 1);
        public static TeamMove teammove6 = new TeamMove(6923, 6934, 1);
        public static TeamMove teammove7 = new TeamMove(6934, 6923, 1);

        public static TeamMove teammove8 = new TeamMove(6923, 6934, 1);//
        public static TeamMove teammove9 = new TeamMove(6934, 6923, 1);
        public static TeamMove teammove10 = new TeamMove(6923, 6934, 1);

        public static TeamMove teammove11 = new TeamMove(6934, 6923, 1);
        public static TeamMove teammove12 = new TeamMove(6923, 6934, 1);

        public static TeamMove teammove13 = new TeamMove(6934, 6923, 1);
        public static TeamMove teammove14 = new TeamMove(6923, 6934, 1);

        public static TeamMove teammove15 = new TeamMove(6934, 6923, 1);
        public static TeamMove teammove16 = new TeamMove(6923, 6934, 1);

        public static TeamMove teammove20 = new TeamMove(6931, 6932, 1);

    public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;
                    _dic_TeamMove[7] = teammove8;

                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;

                    _dic_TeamMove[11] = teammove12;
                    _dic_TeamMove[12] = teammove13;

                    _dic_TeamMove[13] = teammove14;
                    _dic_TeamMove[14] = teammove15;

                    _dic_TeamMove[15] = teammove16;
                    _dic_TeamMove[16] = teammove20;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE4_2_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10103;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(6956);//主力
        public static Spots spots2 = new Spots(6954);//主力
        public static Spots spots3 = new Spots(6956);//主力



        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(6956, 6974, 1);
        public static TeamMove teammove2 = new TeamMove(6974, 6961, 1);
        public static TeamMove teammove3 = new TeamMove(6961, 6978, 1);
        public static TeamMove teammove4 = new TeamMove(6978, 6979, 1);

        public static TeamMove teammove5 = new TeamMove(6979, 6982, 1);
        public static TeamMove teammove6 = new TeamMove(6982, 6983, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE4_3_2018_spring
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10104;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(7016);//主力
        public static Spots spots2 = new Spots(7016);//主力
        public static Spots spots3 = new Spots(7014);//主力



        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(7016, 7018, 1);
        public static TeamMove teammove2 = new TeamMove(7018, 7017, 1);
        public static TeamMove teammove3 = new TeamMove(7017, 7019, 1);
        public static TeamMove teammove4 = new TeamMove(7019, 7014, 1);

        public static TeamMove teammove5 = new TeamMove(7014, 7013, 1);
        public static TeamMove teammove6 = new TeamMove(7013, 7012, 1);
        public static TeamMove teammove7 = new TeamMove(7014, 7013, 1);//

        public static TeamMove teammove8 = new TeamMove(7013, 7012, 2);
        public static TeamMove teammove9 = new TeamMove(7012, 6999, 1);
        public static TeamMove teammove10 = new TeamMove(6999, 6996, 1);
        public static TeamMove teammove11 = new TeamMove(6996, 6988, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;

                    _dic_TeamMove[4] = teammove5;
                    _dic_TeamMove[5] = teammove6;
                    _dic_TeamMove[6] = teammove7;

                    _dic_TeamMove[7] = teammove8;
                    _dic_TeamMove[8] = teammove9;
                    _dic_TeamMove[9] = teammove10;
                    _dic_TeamMove[10] = teammove11;


                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
    }

    static class MapE1_2_sass_2017_winter
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10006;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(2036);//主力
        public static Spots spots2 = new Spots(2036);//主力

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(2036, 2205, 1);
        public static TeamMove teammove2 = new TeamMove(2205, 2204, 1);
        public static TeamMove teammove3 = new TeamMove(2204, 2040, 1);
        public static TeamMove teammove4 = new TeamMove(2040, 2041, 1);
        public static TeamMove teammove5 = new TeamMove(2041, 2209, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6764;//撤离
    }




    static class MapE1_3_sass_2017_winter
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10007;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(2045);//主力
        public static Spots spots2 = new Spots(2045);//主力

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(2045, 2215, 1);
        public static TeamMove teammove2 = new TeamMove(2215, 2050, 1);
        public static TeamMove teammove3 = new TeamMove(2050, 2234, 1);
        public static TeamMove teammove4 = new TeamMove(2234, 2235, 1);
        public static TeamMove teammove5 = new TeamMove(2235, 2053, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
                    _dic_TeamMove[1] = teammove2;
                    _dic_TeamMove[2] = teammove3;
                    _dic_TeamMove[3] = teammove4;
                    _dic_TeamMove[4] = teammove5;

                }

                return _dic_TeamMove;
            }
            set
            {
                _dic_TeamMove = value;
            }
        }//梯队移动的顺序
        public static int withdrawSpot = 6764;//撤离
    }




}

