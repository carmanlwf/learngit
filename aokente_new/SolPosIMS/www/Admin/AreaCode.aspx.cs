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
using Ims.Admin.Model;
using Ims.Admin.BLL;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Main.BLL;
using Ims.Main;
public partial class Admin_AreaCode : System.Web.UI.Page
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (ViewState["area_status"] != null)
        {
            if (ViewState["area_status"].ToString() == "add")
            {
                btnAdd.Attributes.Add("disabled", "disabled");
            }
            else
            {
                btnAdd.Attributes.Remove("disabled");
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!ImsInfo.UserIsInRole("admin_areacode"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        //初始化风格
        GridViewHelper.InitDefaultGridViewEvent(gvArea, ObjectDataSource1);
        if (!Page.IsPostBack)
        {

            //默认排序
            gvArea.Sort("area_code",SortDirection.Ascending);
            //绑定省份下拉框
            InitListControlHelper.BindNormalTableToListControl(ddlProvince, "PLACECODE", "PLACENAME", "v_pub_province", "PLACECODE");
            InitListControlHelper.BindNormalTableToListControl(province, "PLACECODE", "PLACENAME", "v_pub_province", "PLACECODE", null, null);
            ViewState["area_status"] = "add";
        }
    }
    /// <summary>
    /// 新增按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        //清空界面ParameterBindHelper
        AreaCodeInfo AreaCodeInfo = new AreaCodeInfo();
        ParameterBindHelper.BindObjectToParameter(panelAreaInfo, AreaCodeInfo, BindParameterUsage.OpInsert);
        //改变状态为add
        ViewState["area_status"] = "add";
        //只读控制
        ControlHelper.SetControlReadonly(areacode, false);
    }
    /// <summary>
    /// 保存按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        if (ViewState["area_status"] == null)
        {
            return;
        }
        else if (ViewState["area_status"].ToString() == "add")
        {
            //新增
            InsertData();
        }
        else if (ViewState["area_status"].ToString() == "update")
        {
            //修改
            UpdateData();
        }
    }
    /// <summary>
    /// 查询按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_ServerClick(object sender, EventArgs e)
    {
        gvArea.PageIndex = 0;
        gvArea.DataBind();
        if (gvArea.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的记录信息!");
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (!e.ExecutingSelectCount)
        {
            //查询地区信息
            object areaCodeInfo = ParameterBindHelper.BindParameterToObject(panelQuery, typeof(AreaCodeInfo), BindParameterUsage.OpQuery);
            e.InputParameters[0] = areaCodeInfo;
        }
    }
    protected void radBtnSel_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton radioCur = (RadioButton)sender;
        GridViewRow row = (GridViewRow)(radioCur.Parent.Parent);
        gvArea.SelectedIndex = row.RowIndex;
        for (int i = 0; i < gvArea.Rows.Count; i++)
        {
            RadioButton radio = (RadioButton)(gvArea.Rows[i].FindControl("radBtnSel"));
            if (radio != null)
            {
                if (row.RowIndex != i)
                {
                    radio.Checked = false;
                }
            }
        }
        InitAreaInfo();
    }
    #region 私有方法
    /// <summary>
    /// 刷新地区代码详细信息
    /// </summary>
    private void InitAreaInfo()
    {
        if (gvArea.SelectedRow != null)
        {
            string areacodeSel = gvArea.SelectedDataKey.Value.ToString();
            AreaCodeInfo areacodeInfo = new AreaCodeInfo();
            areacodeInfo.area_code = areacodeSel;
            areacodeInfo = AreaCodeBLL.GetObject(areacodeInfo);
            ParameterBindHelper.BindObjectToParameter(panelAreaInfo, areacodeInfo, BindParameterUsage.OpInsert);

            province.Value = areacodeInfo.province_code.Trim();

            //改变状态为update
            ViewState["area_status"] = "update";
            ViewState["area_code"] = areacodeSel;
            //只读控制
            ControlHelper.SetControlReadonly(areacode, true);
        }
    }
    /// <summary>
    /// 新增地区代码信息
    /// </summary>
    private void InsertData()
    {
        AreaCodeInfo areaCodeInfo = new AreaCodeInfo();
        ParameterBindHelper.BindParameterToObject(panelAreaInfo, areaCodeInfo, BindParameterUsage.OpInsert);
        bool ishave = AreaCodeBLL.CheckAreaCodeData(areaCodeInfo);
        if (ishave)
        {
            //提示组号已经存在
            WebClientHelper.DoClientMsgBox("当前地区代码已经存在!");
            return;
        }
        else
        {
            //新增
            AreaCodeBLL.InsertObject(areaCodeInfo);
            //记录操作日志
            FunctionLogBLL.WriteFunLog(FunctionLogBLL.S_AreaCode, "新增地区代码" + areaCodeInfo.area_code + "信息");
            WebClientHelper.DoClientMsgBox("保存成功!");
            //刷新界面
            gvArea.PageIndex = 0;
            gvArea.DataBind();
        }
    }

    /// <summary>
    /// 修改地区代码信息
    /// </summary>
    private void UpdateData()
    {
        AreaCodeInfo areaCodeInfo = new AreaCodeInfo();
        ParameterBindHelper.BindParameterToObject(panelAreaInfo, areaCodeInfo, BindParameterUsage.OpInsert);

        //修改
        AreaCodeBLL.UpdateObject(areaCodeInfo);
        //记录操作日志
        FunctionLogBLL.WriteFunLog(FunctionLogBLL.S_AreaCode, "修改地区代码" + areaCodeInfo.area_code + "信息");
        WebClientHelper.DoClientMsgBox("保存成功!");
        //刷新界面
        gvArea.PageIndex = 0;
        gvArea.DataBind();

    }
    #endregion
}
