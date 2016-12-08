using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZsdDotNetLibrary.Data;
using Ims.Pos.BLL;
using Ims.Pos.Model.AccessInfo;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text;

public class ArrearsInfo
{
    private string _sitename;
    public string sitename
    {
        get { return _sitename; }
        set { _sitename = value; }
    }

    private string _starttime;
    public string starttime
    {
        get { return _starttime; }
        set { _starttime = value; }
    }

    private string _endtime;
    public string endtime
    {
        get { return _endtime; }
        set { _endtime = value; }
    }

    private string _arrears;
    public string arrears
    {
        get { return _arrears; }
        set { _arrears = value; }
    }

    private string _sumMins;
    public string sumMins
    {
        get { return _sumMins; }
        set { _sumMins = value; }
    }
}

public partial class InterFace_ClearBill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!CheckClientInfo())
        //    Response.Redirect("../Unauthorized.aspx");
        if(!Page.IsPostBack)
            GetMasterDataSource1();
    }
    public void GetMasterDataSource()
    {
        string carNum = "";
        if (!string.IsNullOrEmpty(Request.QueryString["CardSnr"]))
            carNum = Request.QueryString["CardSnr"].ToString();
        string strSql = "SELECT CredenceSnr,sitename,UserID,sumMins,money FROM tb_POS_Transaction SELECT businessid,tradecomment FROM pay_paydetail"; //注意发布前要取消到这个100
        DataSet ds = SQLHelper.Query(strSql);
        ds.Tables[0].TableName = "tb_POS_Transaction";
        ds.Tables[1].TableName = "pay_paydetail";

        //找到两个表中相关联的列 
        DataColumn father = ds.Tables["tb_POS_Transaction"].Columns["CredenceSnr"];
        DataColumn son = ds.Tables["pay_paydetail"].Columns["businessid"];

        //给两个列，建立名为tablerelation的关系 
        DataRelation r = new DataRelation("billlist", father, son, false);
        //将表关系添加到数据集中 
        ds.Relations.Add(r);
        //DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
        gv_bill.DataSource = ds;
        gv_bill.DataBind();
    }

    public void GetMasterDataSource1()
    {
        string carNum = "";
        if (!string.IsNullOrEmpty(Request.QueryString["CardSnr"]))
            carNum = Request.QueryString["CardSnr"].ToString();

        SqlParameter[] Para = new SqlParameter[]{                 
               new SqlParameter("@carnum",SqlDbType.VarChar,30)
            };
        Para[0].Value = carNum;
        DataSet ds = SQLHelper.QueryStored("SP_GetArrearsByCarNum", CommandType.StoredProcedure, Para);
        gv_bill.DataSource = ds;
        gv_bill.DataBind();
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        string carNum = "", posnum = "", userid = "", AndroidID = "";
        List<ArrearsInfo> arrearList = new List<ArrearsInfo>();
        if (!string.IsNullOrEmpty(Request.QueryString["CardSnr"]))
            carNum = Request.QueryString["CardSnr"].ToString();
        if (!string.IsNullOrEmpty(Request.QueryString["PosSnr"]))
            posnum = Request.QueryString["PosSnr"].ToString();
        if (!string.IsNullOrEmpty(Request.QueryString["UserID"]))
            userid = Request.QueryString["UserID"].ToString();
        if (!string.IsNullOrEmpty(Request.QueryString["AndroidID"]))
            AndroidID = Request.QueryString["AndroidID"].ToString();
        double pay = 0;
        if (this.gv_bill.Rows.Count > 0)
        {
            string id = "";          
            for (int i = 0; i < gv_bill.Rows.Count; i++)
            {
                CheckBox ck = gv_bill.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                
                if (ck.Checked )
                {
                    //this.gv_bill
                    ArrearsInfo arreasinfo = new ArrearsInfo();
                    id += "'" + (this.gv_bill.Rows[i].Cells[0].FindControl("Label1") as Label).Text + "'";//卡号
                    id += ",";
                    //Common.ShowDialogWin(this.Page, this, "操作完成!");
                    //string temp = this.gv_bill.Rows[1].Cells[0].;
                    double arrears = Convert.ToDouble((this.gv_bill.Rows[i].Cells[0].FindControl("Label2") as Label).Text);
                    //double arrears = Convert.ToDouble(this.gv_bill.Rows[i].Cells[5].Text);
                    pay += arrears;
                    //string sql = "update tb_card set balance = balance + " + arrears + " where card = (select top 1 CardSnr from tb_pos_transaction where CredenceSnr = " + businessid + ")";
                    //DataExecSqlHelper.ExecuteNonQuerySql(sql);
                    arreasinfo.arrears = arrears.ToString();
                    arreasinfo.sitename = (this.gv_bill.Rows[i].Cells[0].FindControl("Label3") as Label).Text;
                    arreasinfo.starttime = (this.gv_bill.Rows[i].Cells[0].FindControl("Label4") as Label).Text;
                    arreasinfo.endtime = (this.gv_bill.Rows[i].Cells[0].FindControl("Label5") as Label).Text;
                    arreasinfo.sumMins = (this.gv_bill.Rows[i].Cells[0].FindControl("Label6") as Label).Text;
                    arrearList.Add(arreasinfo);

                    SqlParameter[] Para = new SqlParameter[]{                 
                        new SqlParameter("@PosSnr",SqlDbType.VarChar,20),
                        new SqlParameter("@UserID",SqlDbType.VarChar,20),
                        new SqlParameter("@CardSnr",SqlDbType.VarChar,20),
                        new SqlParameter("@Amount",SqlDbType.Decimal),
                        new SqlParameter("@AndroidID",SqlDbType.VarChar,50),
                        new SqlParameter("@ReMessage",SqlDbType.Int)
                    };
                    Para[0].Value = posnum;//pos机号
                    Para[1].Value = userid;//pos操作员
                    Para[2].Value = carNum;//车牌号
                    Para[3].Value = arrears;//欠费金额
                    Para[4].Value = AndroidID;//欠费金额
                    Para[5].Direction = ParameterDirection.ReturnValue;
                    StringBuilder log = new StringBuilder();
                    
                    try
                    {
                        DataSet ds = SQLHelper.QueryStored("SP_POS_Charge1", CommandType.StoredProcedure, Para);
                    }
                    catch (Exception ex)
                    {
                        log.Append(ex.Message);
                    }
                    if (0 != Convert.ToInt32(Para[5].Value.ToString()))
                        log.Append("追缴失败，失败代码是" + Para[5].Value.ToString());
                    else
                        log.Append(userid + "使用终端机号：" + posnum + "追缴了" + arrears + "元");
                    posnum = string.IsNullOrEmpty(posnum) ? "default" : posnum;
                    WebHelper.WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + log + "\r\n", posnum, 1, "charge");
                }
                else
                {
                }
            }
            id = id.TrimEnd(',');
            if (!string.IsNullOrEmpty(id))
            {
                string sql = "update tb_pos_transaction set isPay = 1 where CredenceSnr in (" + id + ")";
                DataExecSqlHelper.ExecuteNonQuerySql(sql);
            }
           
            string sql1 = "select balance from tb_card where card = '" + carNum + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql1);
            string balance = "";
            if (dt != null && dt.Rows.Count > 0)
                balance = dt.Rows[0][0].ToString();
            string info = JavaScriptConvert.SerializeObject(arrearList);
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>if (window.javaCallback) window.javaCallback.javaCallback(" + Convert.ToString(pay) + "," + balance + ",'" + info + "');alert('操作完成');</script>");
                //cs.RegisterStartupScript(cstype, "ReturnWin", "<script>if (window.javaCallback) window.javaCallback.javaCallback(" + Convert.ToString(pay) + "," + balance + ",'nihao');alert('操作完成');</script>");
                //cs.RegisterStartupScript(cstype, "ReturnWin", "<script>if (window.javaCallback) window.javaCallback.javaCallback(" + Convert.ToString(pay) + "," + info + "," + balance + ");alert('操作完成');</script>");
                GetMasterDataSource1();
            }
        }
    }
    public bool CheckClientInfo()
    {
        string strReq = "";
        string reqText = "";
        AccessObject oAO = new AccessObject();
        if(!string.IsNullOrEmpty(Request.QueryString["data"]))
        {
            strReq = Request.QueryString["data"].ToString();
            reqText = WebHelper.DES64_Algorithm(strReq, 0);//  解密
            oAO = JavaScriptConvert.DeserializeObject<AccessObject>(reqText);
        }
        return SP_POS_SignINBLL.CheckUserLogin(oAO.UserID, oAO.Password);
    }
}
