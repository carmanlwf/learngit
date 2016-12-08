using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;
using System.Data.SqlClient;
using Ims.Pos.DAL;
namespace Ims.Card.DAL
{
    public class CardViewSitesDAL
    {
        public static DataTable getSites(string carnum)
        {
            SqlParameter[] Para = new SqlParameter[]{                 
               new SqlParameter("@carnum", SqlDbType.VarChar,50),                  
               new SqlParameter("Rstr",SqlDbType.Int)
               };

            Para[0].Value = carnum;    
            Para[1].Direction = ParameterDirection.ReturnValue;

            DataSet ds = SQLHelper.QueryStored("SP_ViewSites", CommandType.StoredProcedure, Para);
            DataTable dt = ds.Tables[0];
            return dt;
        }
    }
}
