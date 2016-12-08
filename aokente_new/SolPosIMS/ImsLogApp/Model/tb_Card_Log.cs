using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Log.Model
{
    /// <summary>
    /// ��������־�ļ�
    /// </summary>
    [DbObject("tb_Card_Log", ObjType = DbObjectAttribute.ObjectType.Table)]
    //[DbObject("v_web_consult_log", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
   public   class tb_Card_Log
    {
        //����
        string _cardid;

        public string Cardid
        {
            get { return _cardid; }
            set { _cardid = value; }
        }
        //������
        string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        //��¼����
       string _operate_date;
       public string operate_date
       {
           get { return _operate_date; }
           set { _operate_date = value; }
       }
        //��¼��־
       string _logmsg;

       public string Logmsg
       {
           get { return _logmsg; }
           set { _logmsg = value; }
       }
       //���ڲ�ѯ-----------------------
        string _operate_date_begin;
        /// <summary>
        /// ������ʼʱ��
        /// </summary>
       [SqlField(QueryOperator = ">=", FieldFormatString = "operate_date")]
        [BindControlParameter("operate_date_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operate_date_begin
        {
            get { return _operate_date_begin; }
            set { _operate_date_begin = value; }
        }

        string _operate_date_end;
        /// <summary>
        /// ������ֹʱ��
        /// </summary>
       [SqlField(QueryOperator = "<=", FieldFormatString = "operate_date")]
        [BindControlParameter("operate_date_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operate_date_end
        {
            get { return _operate_date_end; }
            set { _operate_date_end = value; }
        }
    }
}
