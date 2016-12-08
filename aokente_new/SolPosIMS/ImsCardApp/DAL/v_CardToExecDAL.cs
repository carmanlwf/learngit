using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data;
using System.Data;

namespace Ims.Card.DAL
{
  public   class v_CardToExecDAL
    {
        ///// <summary>
        ///// ������ȫ������
        ///// </summary>
        ///// <param name="cardID"></param>
        ///// <param name="addeddate1"></param>
        ///// <param name="addeddate2"></param>
        ///// <returns>DataTable</returns>
        ///// 
        //public static DataTable CardConetEXEC(string TypeID, string stiteID, string cardstatus, string addeddate1, string addeddate2, string activeaddeddate1, string activeaddeddate2)
        //{
        //    string sqlWhere = "";

        //    if (TypeID != "")
        //    {
        //        sqlWhere = " TypeID ='" + TypeID + "' ";

        //    }
        //    if (stiteID != "")
        //    {
        //        if (sqlWhere != "")
        //        {
        //            sqlWhere += " and   siteid ='" + stiteID + "' ";
        //        }
        //        else
        //        {
        //            sqlWhere = "siteid ='" + stiteID + "' ";
        //        }
        //    }
        //    if (cardstatus != "")
        //    {
        //        if (sqlWhere != "")
        //        {
        //            sqlWhere += " and   cardstatus ='" + cardstatus + "' ";
        //        }
        //        else
        //        {
        //            sqlWhere = "cardstatus ='" + cardstatus + "' ";
        //        }
        //    }
        //    if (addeddate1 != "")
        //    {
        //        if (sqlWhere != "")//ǰ����������
        //        {
        //            sqlWhere += "  and  activeaddate>='" + addeddate1 + "'   ";
        //        }
        //        else
        //        {
        //            sqlWhere = "  activeaddate>='" + addeddate1 + " 00:00:00'   ";
        //        }
        //    }
        //    if (addeddate2 != "")
        //    {
        //        if (sqlWhere != "")//ǰ����������
        //        {
        //            sqlWhere += "  and  activeaddate<='" + addeddate2 + " 23:59:60'   ";
        //        }
        //        else
        //        {
        //            sqlWhere = "  activeaddate<='" + addeddate2 + " 23:59:60'   ";
        //        }
        //    }

        //    if (activeaddeddate1 != "")
        //    {
        //        if (sqlWhere != "")//ǰ����������
        //        {
        //            sqlWhere += "  and  activeaddate>='" + activeaddeddate1 + "'   ";
        //        }
        //        else
        //        {
        //            sqlWhere = "  activeaddate>='" + activeaddeddate1 + " 00:00:00'   ";
        //        }
        //    }
        //    if (activeaddeddate2 != "")
        //    {
        //        if (sqlWhere != "")//ǰ����������
        //        {
        //            sqlWhere += "  and  activeaddate<='" + activeaddeddate2 + " 23:59:60'   ";
        //        }
        //        else
        //        {
        //            sqlWhere = "  activeaddate<='" + activeaddeddate2 + " 23:59:60'   ";
        //        }
        //    }

        //    string sql1 = "select card as ����,RealName as ��Ա,TypeName as ������ , balance as ���,Points as ����,sitename as �ֵ�,cardstatus as ��״̬,activeaddate as  ����ʱ��,addeddate as ����ʱ��   from v_CardToExec  ";
        //    string sqlEXC = "";
        //    if (sqlWhere != "")
        //    {
        //        sqlEXC = sql1 + " where  " + sqlWhere + "   order by activeaddate desc";
        //    }
        //    else
        //    {
        //        sqlEXC = sql1 + "  order by activeaddate desc";
        //    }
        //    return DataExecSqlHelper.ExecuteQuerySql(sqlEXC);
        //}
      /// <summary>
      /// ͳ�ƽ��(�����ۺ�ͳ��)
      /// </summary>
      /// <param name="TypeID"></param>
      /// <param name="stiteID"></param>
      /// <param name="cardstatus"></param>
      /// <param name="addeddate1"></param>
      /// <param name="addeddate2"></param>
      /// <param name="activeaddeddate1"></param>
      /// <param name="activeaddeddate2"></param>
        /// /// <param name="dataType"></param>
      /// <returns></returns>
      public static DataTable CardConetEXEC(string TypeID, string stiteID, string cardstatus, string addeddate1, string addeddate2, string activeaddeddate1, string activeaddeddate2,string initvalue, string point1, string point2)
      {
          string strSql ="";
          strSql = "select card as ����,RealName as ��Ա,TypeName as ������ , balance as ���,Points as ����,sitename as �ֵ�,cardstatus as ��״̬,activeaddate as  ����ʱ��,addeddate as ����ʱ�� FROM v_CardToExec WHERE 1 = 1";
          if (!string.IsNullOrEmpty(TypeID))
              strSql += " And TypeID = '" + TypeID + "'";
          if (!string.IsNullOrEmpty(stiteID))
              strSql += " And stiteid = '" + stiteID + "'";
          if (!string.IsNullOrEmpty(cardstatus))
              strSql += " And cardstatus = '" + cardstatus + "'";
          if (!string.IsNullOrEmpty(addeddate1)&&!string.IsNullOrEmpty(addeddate2))
              strSql += " And addeddate >= '" + addeddate1 + "' And addeddate <='" + addeddate2+"'";
          if (!string.IsNullOrEmpty(activeaddeddate1) && !string.IsNullOrEmpty(activeaddeddate2))
              strSql += " And activeaddate >= '" + activeaddeddate1 + "' And activeaddate <='" + activeaddeddate2+"'";
          if (!string.IsNullOrEmpty(point1) && !string.IsNullOrEmpty(point2))
              strSql += " And points >= '" + point1 + "' And points <=" + point2;
          return DataExecSqlHelper.ExecuteQuerySql(strSql);
      }
      public static DataTable CardCount(string TypeID, string siteid, string cardstatus, string addeddate1, string addeddate2, string activeaddeddate1, string activeaddeddate2, string initvalue, string point1, string point2)
      {
          string strSql = "";
          strSql = @"SELECT SUM(CASE cardstatus WHEN 'δ����' THEN ISNULL(balance,0) WHEN '��ʹ��' THEN 0 END) as �����ܶ�_δ����,
		SUM(CASE cardstatus WHEN '��ʹ��' THEN ISNULL(balance,0) WHEN 'δ����' THEN 0 END) as �����ܶ�_��ʹ��,
		SUM(CASE cardstatus WHEN 'δ����' THEN ISNULL(initvalue,0) WHEN '��ʹ��' THEN 0 END) as ��ʼ�ܶ�_δ����,
		SUM(CASE cardstatus WHEN '��ʹ��' THEN ISNULL(initvalue,0) WHEN 'δ����' THEN 0 END) as ��ʼ�ܶ�_��ʹ��,
		SUM(balance) as �����ܶ�_����,
		SUM(initvalue)as ��ʼ�ܶ�_����,
		SUM(CASE cardstatus WHEN 'δ����' THEN 1 WHEN '��ʹ��' THEN 0 END) as ��������_δ����,
		SUM(CASE cardstatus WHEN '��ʹ��' THEN 1 WHEN 'δ����' THEN 0 END) as ��������_��ʹ��,
		COUNT(1) as ��������_����

FROM v_CardToExec WHERE 1 = 1 ";

          if (!string.IsNullOrEmpty(TypeID))
              strSql += " And TypeID = '" + TypeID + "'";
          if (!string.IsNullOrEmpty(siteid))
              strSql += " And siteid = '" + siteid + "'";
          if (!string.IsNullOrEmpty(cardstatus))
              strSql += " And cardstatus = '" + cardstatus + "'";
          if (!string.IsNullOrEmpty(addeddate1) && !string.IsNullOrEmpty(addeddate2))
              strSql += " And addeddate >= '" + addeddate1 + "' And addeddate <='" + addeddate2+"'";
          if (!string.IsNullOrEmpty(activeaddeddate1) && !string.IsNullOrEmpty(activeaddeddate2))
              strSql += " And activeaddate >= '" + activeaddeddate1 + "' And activeaddate <='" + activeaddeddate2+"'";
          if (!string.IsNullOrEmpty(point1) && !string.IsNullOrEmpty(point2))
              strSql += " And points >= '" + point1 + "' And points <=" + point2;
          return DataExecSqlHelper.ExecuteQuerySql(strSql);

      }
        /// <summary>
        /// ������ͳ��
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="addeddate1"></param>
        /// <param name="addeddate2"></param>
        /// <returns>DataTable</returns>
        /// 
        //public static DataTable CardCount(string TypeID, string stiteID, string cardstatus, string addeddate1, string addeddate2, string activeaddeddate1, string activeaddeddate2)
        //{
        //    string sqlWhere = "";

        //    if (TypeID != "")
        //    {
        //        sqlWhere = " TypeID ='" + TypeID + "' ";

        //    }
        //    if (stiteID != "")
        //    {
        //        if (sqlWhere != "")
        //        {
        //            sqlWhere += " and   siteid ='" + stiteID + "' ";
        //        }
        //        else
        //        {
        //            sqlWhere = "siteid ='" + stiteID + "' ";
        //        }
        //    }
        //    if (cardstatus != "")
        //    {
        //        if (sqlWhere != "")
        //        {
        //            sqlWhere += " and   cardstatus ='" + cardstatus + "' ";
        //        }
        //        else
        //        {
        //            sqlWhere = "cardstatus ='" + cardstatus + "' ";
        //        }
        //    }
        //    if (addeddate1 != "")
        //    {
        //        if (sqlWhere != "")//ǰ����������
        //        {
        //            sqlWhere += "  and  activeaddate>='" + addeddate1 + "'   ";
        //        }
        //        else
        //        {
        //            sqlWhere = "  activeaddate>='" + addeddate1 + " 00:00:00'   ";
        //        }
        //    }
        //    if (addeddate2 != "")
        //    {
        //        if (sqlWhere != "")//ǰ����������
        //        {
        //            sqlWhere += "  and  activeaddate<='" + addeddate2 + " 23:59:60'   ";
        //        }
        //        else
        //        {
        //            sqlWhere = "  activeaddate<='" + addeddate2 + " 23:59:60'   ";
        //        }
        //    }

        //    if (activeaddeddate1 != "")
        //    {
        //        if (sqlWhere != "")//ǰ����������
        //        {
        //            sqlWhere += "  and  activeaddate>='" + activeaddeddate1 + "'   ";
        //        }
        //        else
        //        {
        //            sqlWhere = "  activeaddate>='" + activeaddeddate1 + " 00:00:00'   ";
        //        }
        //    }
        //    if (activeaddeddate2 != "")
        //    {
        //        if (sqlWhere != "")//ǰ����������
        //        {
        //            sqlWhere += "  and  activeaddate<='" + activeaddeddate2 + " 23:59:60'   ";
        //        }
        //        else
        //        {
        //            sqlWhere = "  activeaddate<='" + activeaddeddate2 + " 23:59:60'   ";
        //        }
        //    }

        //    string sql1 = "select COUNT(1) from v_CardToExec   ";
        //    string sql2 = "select COUNT(1) from v_CardToExec where cardstatus='δ����'";
        //    string sql3 = " select SUM(balance) from v_CardToExec ";
        //    string sql4 = " select SUM(balance) from v_CardToExec  where  cardstatus = 'δ����'";

        //    //string havewhere = " where ";
        //    string sqlUNION = "  UNION ALL ";

        //    string Sqldate = "";
        //    if (sqlWhere == "")
        //    {
        //        //Sqldate = sql1 + sqlUNION + sql2 + " where cardstatus ='δ����' " + sqlUNION + sql3 + "  where cardstatus ='δ����' " + sqlUNION + sql4;
        //        Sqldate = sql1 + sqlUNION + sql2 + sqlUNION + sql3 + sqlUNION + sql4;
        //    }
        //    else
        //    {
        //        Sqldate = sql1 + sqlUNION + sql2 + sqlUNION + sql3 + " where " + sqlWhere + sqlUNION + sql4;
        //    }
        //    return DataExecSqlHelper.ExecuteQuerySql(Sqldate);
        //}

    }
}
