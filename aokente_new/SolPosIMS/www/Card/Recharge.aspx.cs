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

public partial class Card_MonthCard : System.Web.UI.Page
{
    public string numM = string.Empty;
    public string SMoney = string.Empty;
    public string Typid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        igCarNumber.Disabled = true;
        if (!Page.IsPostBack)
        {
            DataTable t = tb_CardTypeBLL.GetObjectsCard();
            string HOption = string.Empty;
            int ct = 0;
            if (t != null && t.Rows.Count > 0)
            {
                string money = string.Empty;
                foreach (DataRow r in t.Rows)
                {

                    if (string.IsNullOrEmpty(r["NumCost"].ToString()))
                        money = "0";
                    else
                        money = Convert.ToDecimal(r["NumCost"]).ToString("F2");

                    HOption += "<option value=" + r["TypeID"].ToString() + " numMonths =" + r["NumMonths"].ToString() + "  money=" + money + ">" + r["TypeName"].ToString() + "</option>";

                    if (ct == 0)
                    {
                        ct++;
                        this.SMoney = money;
                        this.Add_Balance.DataBind();
                        this.numM = r["NumMonths"].ToString();
                        this.numMonths.DataBind();
                        this.Typid = r["TypeID"].ToString();
                        this.TypeID.DataBind();
                    }
                }
                
            }

            divCradType.InnerHtml = "<select id='Cardid'  style='width: 150px' class='inputblue'>" + HOption + " </select>￥<label id='Smoney' style='color: Red; height: 18px;'>" + SMoney + "</label>";

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
            if (cd == "0")
                rName = "2";//用户不是会员！
        }
        else
        {
            rName = "3";//对不起用户不存在，请先注册！
        }

        return rName;

    }
    public string code()
    {
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        return DateTime.Now.ToString("yyyyMMdd") + ran.GetHashCode().ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        try
        {
           int tm = Convert.ToInt32(numMonths.Value);

           SqlParameter[] Para = new SqlParameter[]{
               new SqlParameter("@transid", SqlDbType.VarChar,30), 
               new SqlParameter("@card", SqlDbType.VarChar,30),
               new SqlParameter("@cardtype",SqlDbType.VarChar,20),                
               new SqlParameter("@operid",SqlDbType.VarChar,30),
               new SqlParameter("@supportSites",SqlDbType.VarChar,500),
               new SqlParameter("@uptotime",SqlDbType.Int),
               new SqlParameter("@isCard",SqlDbType.Int),
               new SqlParameter("@momeys",SqlDbType.Money),
               new SqlParameter("@ReMessage",SqlDbType.VarChar,50)
            };
           Para[0].Value = code();
           Para[1].Value = igCarNumber1.Value;
           Para[2].Value = TypeID.Value.ToString();
           Para[3].Value = Ims.Main.ImsInfo.CurrentUserId;
           Para[4].Value = SupportSites.Value.ToString().TrimEnd(',');
           Para[5].Value = tm;
           Para[6].Value = tm > 0 ? 1 : 0;
           Para[7].Value = Add_Balance.Value;
           Para[8].Direction = ParameterDirection.ReturnValue;

            CardHelperDAL.pr_Recharge(Para);

         if (!DBNull.Value.Equals(Para[8].Value))
             msg = Para[8].Value.ToString();
        
        }
        catch (Exception ex)
        {
            msg = "失败！";
        }

        if (msg=="1")
            msg = "成功！";
        else
            msg = "失败！";
       
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

        }
    }

}
