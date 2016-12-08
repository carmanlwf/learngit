using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Job.Model
{
    [DbObject("RoadDate", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery |     BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class RoadDate
    {
        private string _rdID;
        public string RdID
       {
           get { return _rdID; }
           set { _rdID = value; }
       }
       private string _rdStopCName;
       public string RdStopCName
       {
           get { return _rdStopCName; }
           set { _rdStopCName = value; }
       }

       private string _rdParkServerIP;
       public string RdParkServerIP
       {
           get { return _rdParkServerIP; }
           set { _rdParkServerIP = value; }
       }
       private string _rdLongitude;
       public string RdLongitude
       {
           get { return _rdLongitude; }
           set { _rdLongitude = value; }
       }
       private string _rdlatitude;
       public string Rdlatitude
       {
           get { return _rdlatitude; }
           set { _rdlatitude = value; }
       }
       private string _rdFier;
       public string RdFier
       {
           get { return _rdFier; }
           set { _rdFier = value; }
       }
       private string _rdDescription;
       public string RdDescription
       {
           get { return _rdDescription; }
           set { _rdDescription = value; }
       }

       private string _rdCreateTime;
       public string RdCreateTime
       {
           get { return _rdCreateTime; }
           set { _rdCreateTime = value; }
       }
       private string _rdUpdateTime;
       public string RdUpdateTime
       {
           get { return _rdUpdateTime; }
           set { _rdUpdateTime = value; }
       }
       private bool _flag;
       public bool Flag
       {
           get { return _flag; }
           set { _flag = value; }
       }

    }
}
