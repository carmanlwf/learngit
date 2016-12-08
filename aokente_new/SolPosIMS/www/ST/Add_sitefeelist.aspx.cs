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
using System.Web.Script.Serialization;
using System.Text;
using System.IO;


public partial class ST_Add_sitefeelist : FormNormalEditPage
{
    static string sid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {//权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            InitListControlHelper.InitListControls(typeof(price_temp_feetype));

            areacode.Items.Insert(0, new ListItem("请选择", ""));
            InitListControlHelper.BindNormalTableToListControl(areacode, "areacode", "areaname", "tb_area");

            sitename.Items.Insert(0, new ListItem("请选择", ""));
        }

        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {

            btnUpdate.Visible = true;
            btnInsert.Visible = false;
            sid = spid.Value = Request.QueryString["id"].ToString();
            ControlHelper.SetControlReadonly(spid, true);
        }
        else
        {
            btnUpdate.Visible = false;
            btnInsert.Visible = true;
            spid.Value = "p-" + code();

        }

    }

    private static string laodData(string siteid, string sid)
    {

        DataTable tablep = null;
        price_temp_feetype site = new price_temp_feetype();

        DataTable table = InPriceBLL.GetPagedObjects("");

        string str = string.Empty;

        foreach (DataRow r in table.Rows)
        {
            if (!string.IsNullOrEmpty(siteid))
                tablep = price_temp_sitefeelistBLL.GetPagedObjects(r["pid"].ToString(), siteid);

            if (tablep != null && tablep.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(sid))
                {
                    str += "<span style='float:left; text-align:left; height:15px; width:160px;overflow:hidden; margin-left:1px;'><input type='checkbox' checked='checked' style='float:left;' value='' id='" + r["pid"] + "'>" + r["pname"] + "</span>";
                }
            }
            else
            {
                str += "<span style='float:left; text-align:left; height:15px; width:160px;overflow:hidden; margin-left:1px;'><input type='checkbox'style='float:left;' value='' id='" + r["pid"] + "'>" + r["pname"] + "</span>";
            }

        }
        return str;
    }
    public string code()
    {
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        return ran.GetHashCode().ToString();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(istrue.Value))
        { return; }
        price_temp_sitefeelist newo = new price_temp_sitefeelist();
        newo.Sitename = null;
        newo.StartWorkTime = startW.Value;
        newo.EndWorkTime = endW.Value;
        string sitename = Request.Form["sitename"];
        if (!string.IsNullOrEmpty(sitename))
        {
            newo.Siteid = sitename;
            newo.Sitename = Request.Form["snainput"];
        }
        newo.Flag = true;
        string[] arry = pids.Value.TrimEnd(',').Split(',');
        int num = 0;
        for (int i = 0; i < arry.Length; i++)
        {
            if (!string.IsNullOrEmpty(arry[i]))
            {
                newo.Pid = arry[i];
                DataTable table = InPriceBLL.GetPagedObjects(newo.Pid);
                if (table != null && table.Rows.Count > 0)
                {
                    long tick = DateTime.Now.Ticks;
                    Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
                    newo.Spid = "p-" + ran.GetHashCode();
                    newo.Pname = table.Rows[0]["pname"].ToString();
                    newo.Description = table.Rows[0]["memo"].ToString();
                }
                num += price_temp_sitefeelistBLL.InsertObject(newo);
            }
        }
        string msg = string.Empty;
        if (num > 0)
        {
            msg = num + "条添加数据成功！";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

            }
        }

    }

    [System.Web.Services.WebMethod]
    public static string refleshList(string site)
    {
        return laodData(site, sid);
    }

    [System.Web.Services.WebMethod]
    public static string Aareacode(string areacode)
    {
        tb_site t = new tb_site();
        t.areacode = areacode;

        List<tb_site> lt = SiteHelperBLL.GetPagedObjects_id(t);

        List<string[]> alSchedule = new List<string[]>();//声明一个存放元素的 集合
        string josn = "[";
        for (int i = 0; i < lt.Count; i++)
        {
            josn += "{\"id\":\"" + lt[i].id.ToString() + "\",\"sitename\":\"" + lt[i].sitename + "\"},";

        }

        return josn.TrimEnd(',') + "]"; //Obj2Json(lt);//

    }
    public static string Obj2Json<T>(T data)
    {
        try
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, data);
                return Encoding.UTF8.GetString(ms.ToArray());

            }
        }
        catch
        {
            return null;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(istrue.Value))
        { return; }
        price_temp_sitefeelist newo = new price_temp_sitefeelist();

        string sitename = Request.Form["sitename"];
        if (!string.IsNullOrEmpty(sitename))
        {
            newo.Siteid = sitename;
            newo.Sitename = Request.Form["snainput"];
        }
        newo.StartWorkTime = startW.Value;
        newo.EndWorkTime = endW.Value;
        newo.Flag = true;
        string[] arry = pids.Value.TrimEnd(',').Split(',');
        price_temp_sitefeelist deleteid = new price_temp_sitefeelist();
        deleteid.Siteid = newo.Siteid;
        price_temp_sitefeelistBLL.DeleteObject_siteid(deleteid);
        int num = 0;
        for (int i = 0; i < arry.Length; i++)
        {
            if (!string.IsNullOrEmpty(arry[i]))
            {
                newo.Pid = arry[i];
                DataTable table = InPriceBLL.GetPagedObjects(newo.Pid);
                if (table != null && table.Rows.Count > 0)
                {
                    long tick = DateTime.Now.Ticks;
                    Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
                    newo.Spid = "p-" + ran.GetHashCode();
                    newo.Pname = table.Rows[0]["pname"].ToString();
                    newo.Description = table.Rows[0]["memo"].ToString();
                }
                num += price_temp_sitefeelistBLL.InsertObject(newo);
            }
        }

        string msg = string.Empty;
        if (num > 0)
        {
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
