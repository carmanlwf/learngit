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
using Ims.Member.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.BLL;
using Ims.Member.BLL;
using Ims.Card.Model;

public partial class Member_MemberOperation : FormNormalEditPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            InitListControlHelper.InitListControls(typeof(tb_MemberRanks));
            //InitListControlHelper.BindNormalTableToListControl(regionid, "id", "sitename", "tb_site");
            //InitListControlHelper.BindNormalTableToListControl(TypeId, "id", "Name", "tb_MemberRanks");
            InitListControlHelper.BindNormalTableToListControl(GroupID, "GroupID", "GroupName", "tb_Group", "", "DeleStatus =0", "");
            //GetDefaultValue(null);
        }
        OnPageLoad();
        if (Request.QueryString["statu"] == "readonly")
        {
            ControlHelper.SetControlsReadonly(true);
            chflag.Attributes.Add("disabled", "disabled");
            cbIsSms.Attributes.Add("disabled", "disabled");
            btnUpdate.Visible = false;
            btnInsert.Visible = false;
        }
        else
        {
            ////权限设置
            //if (!PmRolesCheck.InPMRoles(PmRolesCheck.PmInfo_All))
            //{
            //    return;
            //}
        }
        if (Request.QueryString["getcode"] != null)
        {
            //skilllevel.Disabled = true;
            //pname.Disabled = true;
            //sex.Disabled = true;
            Userid.Value = Request.QueryString["getcode"].ToString();
            CardID.Value = CardHelperBLL.GetCardIDByUserID(Userid.Value);
            ControlHelper.SetControlReadonly(Userid, true);
        }
        else
        {
            Userid.Value = "M-" + DateTime.Now.ToString("yyyyMMddhhmmss");
        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        if (MemberHelperBLL.CheckUserPhone(this.CellPhone.Value.Trim()) > 0)
        {
            WebClientHelper.DoClientMsgBox("此号码已在使用中!");
            return;
        }
        Insert();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Update();

        tb_Member m = new tb_Member();
        m.Userid = Userid.Value;
        m.RealName = RealName.Value;
        m.Gender = int.Parse(gender.Value);
        m.CellPhone = CellPhone.Value;
        m.TelPhone = Telphone.Value.Trim();
        m.Zipcode = Zipcode.Value;
        m.QQ = QQ.Value;
        m.email = email.Value;
        m.IdType = IdType.Value;
        m.IdNo = IdNo.Value;
        m.BirthDate = birthdate.Value;
        m.Address = Address.Value;
        m.Memo = memo.Value;
        m.IsSms = cbIsSms.Checked;
        tb_Card c = new tb_Card();
        c.card = CardID.Value;
        c.GroupID = GroupID.Value;
        c.SaleMemID = Request.Form.Get("SaleMemID");

        if (CardHelperBLL.UpdateCardAndMember(c, m))
        {
            string msg = "";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            msg = "会员信息更新成功!";
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                return;
            }
        }
    }
    protected override void OnChangeModeToInsert()
    {
        btnUpdate.Visible = false;
        btnInsert.Visible = true;
        chflag.Disabled = true;
        chflag.Checked = false;
    }

    protected override void OnChangeModeToUpdate()
    {

        btnUpdate.Visible = true;
        btnInsert.Visible = false;
        chflag.Disabled = false;
    }

    protected override bool OnInserted(object o, int result, Exception ex, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        okToDo = WebClientHelper.ToDo.FormViewModeInsert;
        errorToDo = WebClientHelper.ToDo.FormViewModeInsert;
        tb_MemberRanks newo = new tb_MemberRanks();
        newo.addeddate = DateTime.Now.ToString();
        newo.Point = 0;
        //newo.UserRank = "1";
        //GetDefaultValue(newo);
        ParameterBindHelper.BindObjectToParameter(newo, BindParameterUsage.OpQuery);
        string msg = "添加数据成功！";
        ChangeModeToInsert();
        WebClientHelper.DoResultClientProcess(ex == null, msg, okToDo, errorToDo);
        return true;
    }

    protected override bool OnUpdated(object o, int result, Exception ex, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        okToDo = WebClientHelper.ToDo.CloseSelfWindow;
        errorToDo = WebClientHelper.ToDo.FormViewModeEdit;
        return base.OnUpdated(o, result, ex, okToDo, errorToDo);
    }
}

