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




    static class Map3_6
    {
        public static int mission_id = 30;
        public static Spots spots1 = new Spots(427);//主力
        public static Spots spots2 = new Spots(431);//辅助
        public static Spots[] Mission_Start_spots = { spots1, spots2 };//部署梯队的信息
        public static int withdrawSpot = 427;//撤离
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
        public static TeamMove teammove4 = new TeamMove(1947, 1946, 1);//
        public static TeamMove teammove5 = new TeamMove(1946, 2152, 1);//
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

