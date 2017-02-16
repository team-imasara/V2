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
        public UserInfo userInfo = new UserInfo();
        public static Dictionary<int, GunInfo> gunInfo = new Dictionary<int, GunInfo>();
        public static Dictionary<int, OperationInfo> operationInfo = new Dictionary<int, OperationInfo>();
        public Dictionary<int, AutoOperationInfo> user_operationInfo = new Dictionary<int, AutoOperationInfo>();
        public static Dictionary<int, EquipInfo> equipInfo = new Dictionary<int, EquipInfo>();

        
    }
}
