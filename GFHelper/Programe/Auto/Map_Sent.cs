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


}

