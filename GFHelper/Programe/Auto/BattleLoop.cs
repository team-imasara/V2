using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe.Auto
{
    class BattleLoop
    {
        private InstanceManager im;
        public BattleLoop(InstanceManager im)
        {
            this.im = im;
        }

        public void BattleLOOP(Programe.Auto.UserBattleTaskInfo ubti)
        {
            switch (ubti.TaskMap)
            {
                case 0:
                    {
                        Battle5_2N(ubti);
                        break;
                    }
                default:
                    break;
            }
        }

        public void Battle5_2N(Programe.Auto.UserBattleTaskInfo ubti)
        {
            //u代表用户 整个的
            
            int stepNum = 0;
            Battle_TASK_INFO bti = new Battle_TASK_INFO();
            bti.setMapInfo();
            bti.setBattle_5_2N_1(ubti);
            bti.setBattle_5_2N_2(ubti);

            if (im.userdatasummery.Check_Equip_FULL())
            {
                im.action.Eat_Equip();//升级
                //装备满了 需要升级或者拆解
            }

            //部署梯队
            //回合开始
            if (im.action.startMission(bti.Battle5_2N.mission_id, bti.Battle5_2N.Mission_Start_spots))
            {
                ;
            }
            //补给
            //右移一步
            if (im.action.teamMove(bti.Battle5_2N.dic_TeamMove[stepNum++]))
            {
                ;
            }
            //战斗结算 经验装备
            //建立

            
            if (im.action.battleFinish(bti.Ressult_5_2N_1.obj) == true)
            {
                ;
            }
            //右移一步
            if (im.action.teamMove(bti.Battle5_2N.dic_TeamMove[stepNum++]))
            {
                ;
            }
            //战斗结算 经验装备
            if (im.action.battleFinish(bti.Ressult_5_2N_2.obj) == true)
            {
                ;
            }
            //左移一步
            if (im.action.teamMove(bti.Battle5_2N.dic_TeamMove[stepNum++]))
            {
                ;
            }
            //左移一步
            if (im.action.teamMove(bti.Battle5_2N.dic_TeamMove[stepNum++]))
            {

            }
            //撤离
            if (im.action.withdrawTeam(bti.Battle5_2N.withdrawSpot))
            {

            }
            //战役结束
            if (im.action.abortMission())
            {

            }
            //结算
        }
    }
}
