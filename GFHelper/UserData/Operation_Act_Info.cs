using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GFHelper.UserData
{
    public class Operation_Act_Info
    {
        public int key;//表示当前字段在字典里的键位

        public int id;
        public int operation_id;
        public int user_id;
        public int team_id;
        public int start_time;

        public int remaining_time;
        public bool Added = false;//true 已经添加到任务队列
        public void Time_Operate(int operation_time)
        {
            //剩下时间 = 开始时间+任务时间 - 当前时间
            try
            {
                if (string.IsNullOrEmpty(id.ToString())==false)
                {
                    remaining_time = start_time + operation_time - Programe.CommonHelp.ConvertDateTime_China_Int(DateTime.Now);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("计算后勤剩余时间出错");
                MessageBox.Show(e.ToString());
            }
        }
    }



}
