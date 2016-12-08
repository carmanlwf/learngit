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
using Ims.Card.BLL;
using Ims.Member.Model;
using Ims.Member.BLL;
using ZsdDotNetLibrary.Web;
using Ims.Card.Model;
using Ims.Log.Model;
using Ims.Main;
using Ims.Card.Model;
using Ims.Card.BLL;

public partial class Card_CardAllActive : System.Web.UI.Page
{
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,seller") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            InitListControlHelper.BindNormalTableToListControl(UserRank, "id", "Name", "tb_MemberRanks");              
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        tb_Card o = new tb_Card();
        string cardid = "00005";
        str = Request.QueryString["num"];
        if (str =="")
        {              
            return;
        }
        string[] str1 = str.Split(',');
        for (int i = 0; i < str1.Length; i++)
        {
            o.regionid = cardid;
            o.card = str1[i].ToString();
            o.Status = 1;
            CardHelperBLL.UpdateObject(o);
        }

        WebClientHelper.DoResultClientProcess(true, "卡已激活！",WebClientHelper.ToDo.RefreshParentWindow,WebClientHelper.ToDo.CloseSelfWindow);        
    }

}
