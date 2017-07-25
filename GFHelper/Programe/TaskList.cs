﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHelper.Programe
{
    public class TaskListInfo
    {
        public TaskListInfo(string tasknme, int tasknumber)
        {
            TaskName = tasknme;
            TaskNumber = tasknumber;
        }

        public int TaskNumber;
        public string TaskName;
    }

    public class TaskList
    {
        public static TaskListInfo taskfree = new TaskListInfo("空闲", 0);
        public static TaskListInfo Login = new TaskListInfo("登陆", 1);
        public static TaskListInfo GetuserInfo = new TaskListInfo("读取用户信息", 2);
        public static TaskListInfo Finish_Operation_Act1 = new TaskListInfo("后勤任务 1 结束", 3);
        public static TaskListInfo Finish_Operation_Act2 = new TaskListInfo("后勤任务 2 结束", 4);
        public static TaskListInfo Finish_Operation_Act3 = new TaskListInfo("后勤任务 3 结束", 5);
        public static TaskListInfo Finish_Operation_Act4 = new TaskListInfo("后勤任务 4 结束", 6);
        public static TaskListInfo Start_Operation_Act1 = new TaskListInfo("后勤任务 1 开始", 7);
        public static TaskListInfo Start_Operation_Act2 = new TaskListInfo("后勤任务 2 开始", 8);
        public static TaskListInfo Start_Operation_Act3 = new TaskListInfo("后勤任务 3 开始", 9);
        public static TaskListInfo Start_Operation_Act4 = new TaskListInfo("后勤任务 4 开始", 10);

        public static TaskListInfo Auto_Loop_Operation_Act1 = new TaskListInfo("循环后勤任务1", 11);
        public static TaskListInfo Auto_Loop_Operation_Act2 = new TaskListInfo("循环后勤任务2", 12);
        public static TaskListInfo Auto_Loop_Operation_Act3 = new TaskListInfo("循环后勤任务3", 13);
        public static TaskListInfo Auto_Loop_Operation_Act4 = new TaskListInfo("循环后勤任务4", 14);

        public static TaskListInfo Abort_Operation_Act1 = new TaskListInfo("后勤任务 1 终止", 15);
        public static TaskListInfo Abort_Operation_Act2 = new TaskListInfo("后勤任务 2 终止", 16);
        public static TaskListInfo Abort_Operation_Act3 = new TaskListInfo("后勤任务 3 终止", 17);
        public static TaskListInfo Abort_Operation_Act4 = new TaskListInfo("后勤任务 4 终止", 18);

        public static TaskListInfo Click_Kalina = new TaskListInfo("格琳娜好感上升", 21);
        public static TaskListInfo Click_Girls_In_Dorm = new TaskListInfo("宿舍少女好感上升", 22);
        public static TaskListInfo Get_Battary_Friend = new TaskListInfo("获取好友电池", 23);

    }
}
