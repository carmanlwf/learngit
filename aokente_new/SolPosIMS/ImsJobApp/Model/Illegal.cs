using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Job.Model
{
    public class Illegal
    {
        private string _igID;
        public string IgID
        {
            get { return _igID; }
            set { _igID = value; }
        }
        private string _igCarNumber;
        public string IgCarNumber
        {
            get { return _igCarNumber; }
            set { _igCarNumber = value; }
        }
        private string _igCreateTime;
        public string IgCreateTime
        {
            get { return _igCreateTime; }
            set { _igCreateTime = value; }
        }
        private string _igTerminalCard;
        public string IgTerminalCard
        {
            get { return _igTerminalCard; }
            set { _igTerminalCard = value; }
        }
        private string _igPoliceName;
        public string IgPoliceName
        {
            get { return _igPoliceName; }
            set { _igPoliceName = value; }
        }
        
        private string _igUploadTime;
        public string IgUploadTime
        {
            get { return _igUploadTime; }
            set { _igUploadTime = value; }
        }
        private string _igPoliceIP;
        public string IgPoliceIP
        {
            get { return _igPoliceIP; }
            set { _igPoliceIP = value; }
        }
        private string _igArea;
        public string IgArea
        {
            get
            {
                return _igArea;
            }
            set { _igArea = value; }
        }
        private string _igImgDescription;
        public string IgImgDescription
        {
                get
                {    
                return _igImgDescription;
            }
            set { _igImgDescription = value; }
        }
        private string _igOverviewImg;
        public string IgOverviewImg
        {
            get { return _igOverviewImg; }
            set { _igOverviewImg = value; }
        }
        private string _igBodyworkImg;
        public string IgBodyworkImg
        {
            get { return _igBodyworkImg; }
            set { _igBodyworkImg = value; }
        }
        private string _igPlateImg;
        public string IgPlateImg
        {
            get { return _igPlateImg; }
            set { _igPlateImg = value; }
        }
        private bool _flag;
        public bool Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
    }
}
