using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe.Auto.Map_Sent
{
    static class Map5_2N
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 90018;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(3033);//主力
        public static Spots spots2 = new Spots(3057);//辅助

        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(3033, 3038, 1);
        public static TeamMove teammove2 = new TeamMove(3038, 3047, 1);
        public static TeamMove teammove3 = new TeamMove(3047, 3038, 1);
        public static TeamMove teammove4 = new TeamMove(3038, 3033, 1);

        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    TeamMove teammove1 = new TeamMove(3033, 3038, 1);
                    TeamMove teammove2 = new TeamMove(3038, 3047, 1);
                    TeamMove teammove3 = new TeamMove(3047, 3038, 1);
                    TeamMove teammove4 = new TeamMove(3038, 3033, 1);

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



        public static int withdrawSpot = 3033;//撤离
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
        public static TeamMove teammove5 = new TeamMove(19, 16, 1);
        public static TeamMove teammove6 = new TeamMove(16, 23, 1);
        public static TeamMove teammove7 = new TeamMove(23, 25, 1);
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

        public static TeamMove teammove1 = new TeamMove(136, 144, 1);
        public static TeamMove teammove2 = new TeamMove(144, 148, 1);
        public static TeamMove teammove3 = new TeamMove(148, 149, 1);
        public static TeamMove teammove4 = new TeamMove(149, 146, 1);
        public static TeamMove teammove5 = new TeamMove(146, 147, 1);
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

        public static TeamMove teammove1 = new TeamMove(267, 271, 1);
        public static Dictionary<int, TeamMove> _dic_TeamMove = new Dictionary<int, TeamMove>();
        public static Dictionary<int, TeamMove> dic_TeamMove
        {
            get
            {
                if (_dic_TeamMove.Count == 0)
                {
                    _dic_TeamMove[0] = teammove1;
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
        public static TeamMove teammove2 = new TeamMove(422, 418, 1);
        public static TeamMove teammove3 = new TeamMove(418, 419, 1);
        public static TeamMove teammove4 = new TeamMove(419, 425, 1);
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

        public static TeamMove teammove1 = new TeamMove(1630, 1628, 1);
        public static TeamMove teammove2 = new TeamMove(1628, 1632, 1);
        public static TeamMove teammove3 = new TeamMove(1632, 1633, 1);
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

    static class Map8_6
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 80;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(3788);//主力

        public static Spots[] Mission_Start_spots = { spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(3678, 3671, 1);
        public static TeamMove teammove2 = new TeamMove(3671, 3677, 1);
        public static TeamMove teammove3 = new TeamMove(3677, 3668, 1);
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
        public static TeamMove teammove2 = new TeamMove(1947, 1949, 1);
        public static TeamMove teammove3 = new TeamMove(1949, 1947, 1);
        public static TeamMove teammove4 = new TeamMove(1947, 1948, 2);//
        public static TeamMove teammove5 = new TeamMove(1948, 1947, 2);//
        public static TeamMove teammove6 = new TeamMove(1947, 1949, 1);
        public static TeamMove teammove7 = new TeamMove(1949, 1947, 1);
        public static TeamMove teammove8 = new TeamMove(1947, 1946, 1);
        public static TeamMove teammove9 = new TeamMove(1946, 2152, 1);
        public static TeamMove teammove10 = new TeamMove(2152, 1941, 1);
        public static TeamMove teammove11 = new TeamMove(1941, 1942, 1);

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

        public static Spots[] Mission_Start_spots = { spots2,spots1 };//部署梯队的信息

        public static TeamMove teammove1 = new TeamMove(5494, 5495, 1);
        public static TeamMove teammove2 = new TeamMove(5495, 5492, 1);
        public static TeamMove teammove3 = new TeamMove(5492, 5495, 1);
        public static TeamMove teammove4 = new TeamMove(5495, 5494, 1);

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
        public static int withdrawSpot = 5494;//撤离
    }


    static class MapE1_1
    {
        //要给spots1 2 赋值 梯队ID
        //要给teammove 赋值 梯队ID
        public static int mission_id = 10043;
        //[{"spot_id":3033,"team_id":6},{"spot_id":3057,"team_id":7}]
        public static Spots spots1 = new Spots(4971);//主力
        public static Spots spots2 = new Spots(4971);//主力
        public static Spots[] Mission_Start_spots = { spots1};//部署梯队的信息

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

}

