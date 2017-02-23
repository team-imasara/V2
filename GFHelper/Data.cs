using GFHelper.Models;
using System.Collections.Generic;

namespace GFHelper
{
    class Data
    {
        private InstanceManager im;
        public Data(InstanceManager im)
        {

            this.im = im;
        }

        public List<int> tasklist = new List<int>();
        public UserInfo userInfo = new UserInfo();
        public static Dictionary<int, GunInfo> gunInfo = new Dictionary<int, GunInfo>();
        public static Dictionary<int, OperationInfo> operationInfo = new Dictionary<int, OperationInfo>();
        public Dictionary<int, AutoOperationInfo> user_operationInfo = new Dictionary<int, AutoOperationInfo>();
        public Dictionary<int, AutoOperationInfo> UIauto_operationInfo = new Dictionary<int, AutoOperationInfo>();
        public static Dictionary<int, EquipInfo> equipInfo = new Dictionary<int, EquipInfo>();




        public bool tasklistadd(int temp)
        {
            if (im.data.tasklist[0] == 0)
            {
                im.data.tasklist.Add(temp);
                im.data.tasklist.Remove(0);
            }
            else
                im.data.tasklist.Add(temp);

            return true;
        }

        public bool tasklistremove()
        {
            if(im.data.tasklist.Count == 1)
            {
                im.data.tasklist.Add(0);
                im.data.tasklist.RemoveAt(0);
            }
            else
            {
                im.data.tasklist.RemoveAt(0);
            }
            return true;
        }




    }
}
