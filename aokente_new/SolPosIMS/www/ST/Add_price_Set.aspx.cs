using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZsdDotNetLibrary.Web;
using Ims.Site.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Site.BLL;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ims.Log.BLL;
using Ims.Log.Model;

public partial class ST_Add_price_Set : FormNormalEditPage
{
    protected void Page_Load(object sender, EventArgs e)
    {//权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            this.Cartype.Items.Insert(0, new ListItem("请选择", ""));
            this.Cartype.Items.Insert(1, new ListItem("小车", "1"));
            this.Cartype.Items.Insert(2, new ListItem("大车", "2"));

            InitListControlHelper.InitListControls(typeof(price_temp_feetype));

        }
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            btnUpdate.Visible = true;
            btnInsert.Visible = false;
            Pid.Value = Request.QueryString["id"].ToString();
            ControlHelper.SetControlReadonly(Pid, true);

            price_temp_feetype newo = new price_temp_feetype();
            newo.Pid = Request.QueryString["id"];
            newo = InPriceBLL.GetPagedObjects(0, 1, "", newo)[0];
            Pid.Value = newo.Pid;
            Pname.Value = newo.Pname;
            Cartype.Value = newo.Cartype.ToString();
            maxPayment.Value = newo.MaxPayment.ToString();
            minPayment.Value = newo.MinPayment.ToString();
            normalChargingPrice.Value = newo.NormalChargingPrice.ToString();
            Memo.Value = newo.Memo;
            FreeTimeSeg.Value = newo.FreeTimeSeg.ToString();
            ChargeByTimes.Checked = Convert.ToBoolean(newo.ChargeByTimes);
            FirstChargingTimeSeg.Value = newo.FirstChargingTimeSeg.ToString();
            NormalChargingTimeSeg.Value = newo.NormalChargingTimeSeg.ToString();
        }
        else
        {
            btnUpdate.Visible = false;
            btnInsert.Visible = true;

            Pid.Value = "p-" + code();

        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        price_temp_feetype newo = new price_temp_feetype();
        msg = Pid.Value == "" ? "编号不能为空！," : ""; ;
        msg += Request.Form["Pname"].ToString() == "" ? "名称不能为空！," : "";
        msg += Request.Form["Cartype"] == "" ? "请选择车型！," : "";
        msg += ismsg("最高收费", Request.Form["maxPayment"]) + ",";
        msg += ismsg("起步价", Request.Form["minPayment"]) + ",";
        msg += ismsg("超出缴费", Request.Form["normalChargingPrice"]) + ",";
        msg += ismsg("超出时间", Request.Form["NormalChargingTimeSeg"]) + ",";
        msg += ismsg("超出时间", Request.Form["NormalChargingTimeSeg"]) + ",";
        msg += ismsg("休息时间", FreeTimeSeg.Value);
        if (!returnCheck(msg.Split(',')))
        {
            newo.Pid = Pid.Value;
            newo.Pname = Pname.Value;
            string cartpe = Cartype.Items[Cartype.SelectedIndex].Text;
            if (cartpe != "请选择")
            {
                newo.Pname += "(" + cartpe + ")";
            }
            newo.Cartype = Convert.ToInt32(Cartype.Value);
            newo.Flag = true;
            newo.MaxPayment = Convert.ToDecimal(maxPayment.Value);
            newo.MinPayment = Convert.ToDecimal(minPayment.Value);
            newo.NormalChargingPrice = Convert.ToDecimal(normalChargingPrice.Value);
            newo.Memo = Memo.Value;
            newo.Addeddate = DateTime.Now.ToString("yyyy-MM-dd H:m:s");
            newo.FreeTimeSeg = Convert.ToInt32(FreeTimeSeg.Value);
            newo.ChargeByTimes = ChargeByTimes.Checked;
            newo.FirstChargingTimeSeg = Convert.ToInt32(FirstChargingTimeSeg.Value);
            newo.NormalChargingTimeSeg = Convert.ToInt32(NormalChargingTimeSeg.Value);
            int num = InPriceBLL.InsertObject(newo);

            if (num > 0)
            {
                tb_Log tbl = new tb_Log();
                tbl.logid = "log" + code();
                tbl.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                tbl.operater = Ims.Main.ImsInfo.CurrentUser.Id;
                tbl.type = "新增收费";
                tbl.flag = true;
                tbl.logmsg = Ims.Main.ImsInfo.CurrentUser.Id + "新增：" + Pid.Value;

                LogHelperBLL.InsertObject(tbl);

                msg = num + "条新增成功！";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                }
            }
        }
    }

    //验证输入
    public string ismsg(string text, string value)
    {
        Regex m_regex = new System.Text.RegularExpressions.Regex("^(-?[0-9]*[.]*[0-9]{0,3})$");
        if (string.IsNullOrEmpty(value))
            return text + "不能为空!";
        else if (!m_regex.IsMatch(value))
            return text + "必须为数字!";

        return null;
    }

    public bool returnCheck(string[] value)
    {

        for (int i = 0; i < value.Length; i++)
        {
            if (!string.IsNullOrEmpty(value[i]))
            {
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>Check('" + value[i] + "');</script>");

                    return true;
                }
            }
        }
        return false;

    }
    public string code()
    {
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        return ran.GetHashCode().ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        price_temp_feetype newo = new price_temp_feetype();
        newo.Pid = Pid.Value;
        msg = Request.Form["Pname"].ToString() == "" ? "名称不能为空！," : "";
        msg += Request.Form["Cartype"] == "" ? "请选择车型！," : "";
        msg += ismsg("最高收费", Request.Form["maxPayment"]) + ",";
        msg += ismsg("起步价", Request.Form["minPayment"]) + ",";
        msg += ismsg("超出缴费", Request.Form["normalChargingPrice"]) + ",";
        msg += ismsg("超出时间", Request.Form["NormalChargingTimeSeg"]) + ",";
        msg += ismsg("休息时间", FreeTimeSeg.Value);
        if (!returnCheck(msg.Split(',')))
        {
            newo.Pname = Request.Form["Pname"].ToString();

            string cartpe = Cartype.Items[Cartype.SelectedIndex].Text;

            if (cartpe != "请选择")
            {
                int count = newo.Pname.Split('(').Length;
                if (count > 1)
                {
                    newo.Pname = newo.Pname.Split('(')[0] + "(" + cartpe + ")";
                }
                else
                {
                    newo.Pname += "(" + cartpe + ")";
                }

            }
            newo.Cartype = Convert.ToInt32(Request.Form["Cartype"]);
            newo.Flag = true;
            newo.MaxPayment = Convert.ToDecimal(Request.Form["maxPayment"]);
            newo.MinPayment = Convert.ToDecimal(Request.Form["minPayment"]);
            newo.NormalChargingPrice = Convert.ToDecimal(Request.Form["normalChargingPrice"]);
            newo.Memo = Request.Form["Memo"].ToString();
            newo.Addeddate = DateTime.Now.ToString("yyyy-MM-dd H:m:s");
            newo.FreeTimeSeg = Convert.ToInt32(Request.Form["FreeTimeSeg"]);
            newo.ChargeByTimes = Convert.ToBoolean(Request.Form["clickCharge"]);
            newo.FirstChargingTimeSeg = Convert.ToInt32(Request.Form["FirstChargingTimeSeg"]);
            newo.NormalChargingTimeSeg = Convert.ToInt32(Request.Form["NormalChargingTimeSeg"]);

            int num = InPriceBLL.UpdateObject(newo);

            if (num > 0)
            {
                tb_Log tbl = new tb_Log();
                tbl.logid = "log" + code();
                tbl.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                tbl.operater = Ims.Main.ImsInfo.CurrentUser.Id;
                tbl.type = "更新收费";
                tbl.flag = true;
                tbl.logmsg = Ims.Main.ImsInfo.CurrentUser.Id + "更新：" + Pid.Value;

                LogHelperBLL.InsertObject(tbl);

                msg = num + "条更新成功！";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                }
            }

        }

    }

    protected override bool OnSelecting(ref object objKey, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        errorToDo |= WebClientHelper.ToDo.CloseSelfWindow;
        return base.OnSelecting(ref objKey, okToDo, errorToDo);
    }




}
