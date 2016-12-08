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
using Ims.Card.Model;
using Ims.Card.BLL;
using ZsdDotNetLibrary.Web;

public partial class Card_CardTurnType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString["getcode"]!=null)
            {
                tb_Card c = new tb_Card();
                c = CardHelperBLL.GetObject(Request.QueryString["getcode"].ToString());
                Card.Value = Request.QueryString["getcode"].ToString();
                RealName.Value = c.RealName;
                TypeName.Value = c.TypeName;
                TypeID2.Value = c.TypeID;
                ConDiscount1.Text = c.ConDiscount.ToString();
                Proportion1.Text = c.Proportion.ToString();
                Recharge1.Text = c.Recharge.ToString();
            }
            InitListControlHelper.BindNormalTableToListControl(TypeID1, "TypeID", "TypeName", "tb_CardType", "", "DeleStatus =0", "");
          
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        tb_Card o= new tb_Card();
        o.card = Card.Value;
        o.TypeID = TypeID1.Value;
        if (CardHelperBLL.UpdateObject(o)>0)
        {
            tb_TurnTypeRecord r = new tb_TurnTypeRecord();
            r.TID = DateTime.Now.ToString("yyMMddHHmmss");
            r.CardID = Card.Value;

            r.OTypeID = TypeID2.Value;
            r.NTypeID = TypeID1.Value;
            r.TMan = "admin";
            r.AddDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            r.Flag = true;
            if (tb_TurnTypeRecordBLL.InsertObject(r)>0)
            {
                string msg = "";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                msg = "转换成功!";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                }
            }
        }
    }
}
