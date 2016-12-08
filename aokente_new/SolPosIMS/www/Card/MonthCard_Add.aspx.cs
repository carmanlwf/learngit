using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ims.Card.BLL;
using Ims.Card.Model;
using System.Data;
using ZsdDotNetLibrary.Web;
using Ims.Card.DAL;
using System.Data.SqlClient;

public partial class MonthCard_Add : System.Web.UI.Page
{
   public static string numM =string.Empty;
   public static string SMoney = string.Empty;
   public static string Typid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        igCarNumber.Disabled = true;
        if (!Page.IsPostBack)
        {
            DataTable t = tb_CardTypeBLL.GetObjectsCard();
            string HOption = string.Empty;
            if (t != null && t.Rows.Count > 0)
            {
                string money = string.Empty;
                int ct = 0;
                foreach (DataRow r in t.Rows)
                {
                     if (string.IsNullOrEmpty(r["NumCost"].ToString()))
                            money = "0";
                        else
                            money = Convert.ToDecimal(r["NumCost"]).ToString("F2");

                 if (Convert.ToDecimal(money) > 0)
                   {
                        HOption += "<option value=" + r["TypeID"].ToString() + " numMonths =" + r["NumMonths"].ToString() + "  money=" + money + ">" + r["TypeName"].ToString() + "</option>";
 #region
                        if (ct==0)
                     {
                         ct++;
                         SMoney = money;
                        this.Add_Balance.DataBind();
                        numM = r["NumMonths"].ToString();
                        this.numMonths.DataBind();
                        Typid = r["TypeID"].ToString();
                        this.TypeID.DataBind();
                     }
 #endregion
                   }}
            }

            divCradType.InnerHtml = "<select id='Cardid'  style='width: 150px' class='inputblue'>" + HOption + " </select>";//￥<label id='Smoney' style='color: Red; height: 18px;'>" + SMoney + "</label>

            InitListControlHelper.BindNormalTableToListControl(select1, "id", "sitename", "tb_site", "", "", "");
          
        }

    }
    //检验用户是否存在
    [System.Web.Services.WebMethod]
    public static string GetCarNumber(string val)
    {
        string rName = string.Empty;
        tb_Card member = CardHelperBLL.GetObject(val);
        if (member != null)
        {
            string cd = Card_RecordDAL.GetCard(val).Rows[0]["cunt"].ToString();
                rName = "1";
            if (cd == "1")
                rName = "2";//用户已经是会员！
        }
        else
        {
            rName = "3";//对不起用户不存在，请先注册！
        }
       

        return rName;

    }
    public static string code()
    {
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        return DateTime.Now.ToString("yyyyMMdd") + ran.GetHashCode().ToString();
    }
    ////是否会员
    //[System.Web.Services.WebMethod]
    //public static string GetCrad(string crad)
    //{
    //    return 
    //}

    [System.Web.Services.WebMethod]
    public static string btnUpdate_Click(string igCarNum, string TypeName, string pay, string Month, string Support, string Balance, string time)
    {
        
        string msg = string.Empty;
        try{
              tb_Card member = CardHelperBLL.GetObject(igCarNum);
              if (pay=="0" && member != null)
               {
                   if (Convert.ToInt32(member.balance) < Convert.ToInt32(Balance))
                   {
                       return "余额不足！";
                   }
              }

              int tm = Convert.ToInt32(Month);

            if (string.IsNullOrEmpty(time))
                time = DateTime.Now.ToString("yyyy-MM-dd");

            SqlParameter[] Para = new SqlParameter[]{
                   new SqlParameter("@transid", SqlDbType.VarChar,30), 
                   new SqlParameter("@card", SqlDbType.VarChar,30),
                   new SqlParameter("@cardtype",SqlDbType.VarChar,20),                
                   new SqlParameter("@operid",SqlDbType.VarChar,30),
                   new SqlParameter("@supportSites",SqlDbType.VarChar,500),
                   new SqlParameter("@uptotime",SqlDbType.VarChar,30),
                   new SqlParameter("@isPay",SqlDbType.Int),
                   new SqlParameter("@momeys",SqlDbType.Money),
                   new SqlParameter("@ReMessage",SqlDbType.VarChar,50)
                };
            Para[0].Value = code();
            Para[1].Value = igCarNum;
            Para[2].Value = TypeName.ToString();
            Para[3].Value = Ims.Main.ImsInfo.CurrentUserId;
            Para[4].Value = Support.ToString().TrimEnd(',');
            Para[5].Value = Convert.ToDateTime(time).AddMonths(tm).ToString("yyyy-MM-dd");
            Para[6].Value = Convert.ToInt32(pay);
            Para[7].Value = Balance;
            Para[8].Direction = ParameterDirection.ReturnValue;

            CardHelperDAL.pr_InCard(Para);

            if (!DBNull.Value.Equals(Para[8].Value))
                msg = Para[8].Value.ToString(); 
        }
        catch(Exception ex)
        {
            msg = "失败！";
        }
        if (msg == "1")
            msg =  "成功！";
        else
            msg = "失败！";

        return msg;
    }

}
