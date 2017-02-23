using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GFHelper.Models
{
    class  AutoOperationInfo
    {
        private InstanceManager im;
        //public AutoOperationInfo(int teamid, int operationid, int id=0, int userid=0 , int starttime=0, InstanceManager im)
        //{
        //    this._textLastTime = new TextBlock();
        //    this._id = id;
        //    this._operationId = operationid;
        //    this._userId = userid;
        //    this._teamId = teamid;
        //    this._startTime = starttime;

        //    this.im = im;
        //    SetDefaultLastTime();
        //}
        public AutoOperationInfo(InstanceManager im)
        {
            this.im = im;

        }

        public void ReadAutoOperationInfo(int teamid, int operationid, int id , int userid , int starttime )
        {

            this._textLastTime = new TextBlock();
            this._id = id;
            this._operationId = operationid;
            this._userId = userid;
            this._teamId = teamid;
            this._startTime = starttime;
            Set_durationTime();
            //SetDefaultLastTime();
            SetLastTime();

        }
        public void reSet()
        {
            DateTime time = System.DateTime.Now;
            this._startTime = CommonHelper.ConvertDateTimeInt(DateTime.Now);
            //this.startTime = CommonHelper.ConvertDateTimeInt(DateTime.Now);
            this._LastTime = Data.operationInfo[this._operationId].duration;
            this.SetLastTime();
            this.Set_durationTime();

        }

        public void SetDefaultLastTime()
        {
            this.startTime = Data.operationInfo[_operationId].duration;
        }

        public void Set_durationTime()//设置剩余的时间
        {
            this._durationTime = Data.operationInfo[_operationId].duration;


        }
        public void SetLastTime()//设置剩余的时间
        {
            DateTime time = System.DateTime.Now;
            int temp = CommonHelper.ConvertDateTimeInt(time);
            this._LastTime = _startTime + Data.operationInfo[_operationId].duration - temp;
            if(this._LastTime < 0)
            {
                this._LastTime = -1;
            }


        }
        public TextBlock getTextBlock()
        {
            return this._textLastTime;
        }

        public string Id
        {
            get
            {
                return Data.operationInfo[this._id].name;
            }
        }



        public string OperationName//关卡名字
        {
            get
            {
                return Data.operationInfo[this._operationId].name;
            }
        }

        public string UserId//关卡名字
        {
            get
            {
                return Data.operationInfo[this._userId].name;
            }
        }
        public string TeamName
        {
            get
            {
                return String.Format("梯队{0}({1})", this._teamId, Data.gunInfo[im.data.userInfo.teamInfo[this._teamId][1].GunID].name);
            }
        }


        public string TextLastTime
        {
            get
            {
                return this._textLastTime.Text;
            }
        }

        public int startTime
        {
            get
            {
                return this._startTime;
            }
            set
            {
                this._startTime = value;
                //this._textLastTime.Text = CommonHelper.formatDuration(value);
            }
        }

        public int MissionId
        {
            get
            {
                return Data.operationInfo[this._operationId].campaign;
            }
        }



        public int _id;

        public int _operationId;

        public int _userId;

        public int _teamId;

        private TextBlock _textLastTime;

        private int _startTime;

        public double _LastTime;

        public int _durationTime;

        public int _endTime;



    }
}
