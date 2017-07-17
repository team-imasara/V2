using System;
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
    }
}
