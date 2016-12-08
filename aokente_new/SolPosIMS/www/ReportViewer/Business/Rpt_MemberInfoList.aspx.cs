using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using NewSoftDotNetLibrary.Web;
using ZsdDotNetLibrary.Report;
using System.Collections.Generic;
using Ims.Member.Model;

public partial class ReportViewer_Business_Rpt_MemberInfoList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //InitListControlHelper.BindNormalTableToListControl(RankId, "RankName", "RankName", "MB_MemberRanks");
            //RankId.Items.Insert(0, new ListItem("全部", ""));
        }
    }
    public void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        tb_Member o = new tb_Member();
        o.addeddate1 = begindate.Value;
        o.addeddate2 = begindate.Value;

        List<tb_Member> m_list = RptMemberInfoBLL.GetPagedObjects(0, "", o);
        //string [] paras = {"userid","realname","sex","points","cellphone","addeddate"};

        DataTable dt = RptHelper.ToDataTable(m_list, typeof(RptMemberInfo));
        //ParameterBindHelper.
        //RptMemberInfo rpt = new RptMemberInfo();
        //rpt.sex = "男";
        //DataTable dt = RptMemberInfoBLL.GetMemberInfoList(rpt);
        ExcelHelper.ExportExcel(dt, typeof(RptMemberInfo), "会员信息清单");
        DivCover.Style.Add("display", "none");
        Waiting.Style.Add("display", "none");


    }
}

