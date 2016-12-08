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
using Ims.Card.Model;
using Ims.Card.BLL;
using NewSoftDotNetLibrary.Web.BindParameter;
using System.Collections.Generic;
using Ims.Pos.BLL;
using Ims.Log.Model;
using Ims.Log.BLL;

public partial class Card_EndCard2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            //BindCard();
        }
    }
    public void BindCard()
    {
        InitListControlHelper.InitListControls(typeof(tb_Card));
        tb_Card o = new tb_Card();
        //string s = HexStrToAsc(RF_Card.Value);
        string s = Card.Value.Trim();
        string card = s;
        if (!string.IsNullOrEmpty(card))
        {
            o = CardHelperBLL.GetObject(card);
            if (o != null)
            {
                if (o.Status == 3)
                {
                    WebClientHelper.DoClientMsgBox("此卡已注销，不能执行清款操作！卡号：" + card);
                }
                else if ((int)o.Status == 0)
                {
                    WebClientHelper.DoClientMsgBox("卡未激活，不能执行清款操作!卡号：" + card); return;
                }
                else if ((int)o.Status == 2)
                {
                    WebClientHelper.DoClientMsgBox("卡片处于挂失状态，不能执行清款操作!卡号：" + card); return;
                }
                else if ((int)o.Status == 4)
                {
                    WebClientHelper.DoClientMsgBox("卡片处于补卡状态，不能执行清款操作!卡号：" + card); return;
                }
                //ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.BindToParameter);
                RealName.Value = o.RealName;
                CellPhone.Value = o.CellPhone;
                TypeName.Value = o.TypeName;
                activitytime.Value = o.activitytime;
                ValidDate.Value = o.validDate;
                Balance.Value = o.Balance.ToString();
                

                ControlHelper.SetControlsReadonly(true, "ActualCost,ChargeaMount,Memo,PayType,ChargeAmount,chkManual");
                GridView1.DataSourceID = "ObjectDataSource1";
                GridView1.PageIndex = 0;
                GridView1.DataBind();
                if (GridView1.Rows.Count <= 0)
                {
                    //WebClientHelper.DoClientMsgBox("没有满足条件的充值/扣款信息!");
                }

            }
            else
            {
                WebClientHelper.DoClientMsgBox("系统不存在此卡信息!卡号：" + card);
            }
        }
        else
        {
            WebClientHelper.DoClientMsgBox("请输入卡号!");
        }
    }
    /// <summary>
    /// 十六进制字符串转ascii码
    /// </summary>
    /// <param name="HexStr"></param>
    /// <returns></returns>
    public static string HexStrToAsc(string HexStr)
    {
        HexStr = HexStr.Replace(" ", "");
        List<byte> buffer = new List<byte>();
        for (int i = 0; i < HexStr.Length; i += 2)
        {
            string temp = HexStr.Substring(i, 2);
            byte value = Convert.ToByte(temp, 16);
            buffer.Add(value);
        }
        //string str = System.Text.Encoding.ASCII.GetString(buffer.ToArray());
        string str = System.Text.Encoding.GetEncoding("GB2312").GetString(buffer.ToArray());
        return str;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindCard();
    }

    /// <summary>
    /// 注销
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNew_Click(object sender, EventArgs e)
    {
        if (SP_POS_TransactionBLL.IsConsumed(Card.Value.Trim()))
        {
            WebClientHelper.DoClientMsgBox("该卡已开始消费,为了保持账目收支平衡,不能执行销卡操作!");
            return;
        }
        string msg = "";
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();

        if (Card.Value != "")
        {
            tb_Card tbcard = CardHelperBLL.GetObject(Card.Value);
            if (tbcard != null)
            {
                if (tbcard.Status == 3)
                {
                    WebClientHelper.DoClientMsgBox("此卡已注销，不能销卡！");
                }
                else if ((int)tbcard.Status == 0)
                {
                    WebClientHelper.DoClientMsgBox("卡未激活，不能执行注销操作...");
                }
                else if ((int)tbcard.Status == 2)
                {
                    WebClientHelper.DoClientMsgBox("卡片处于挂失状态，不能进行注销...");
                }
                else if ((int)tbcard.Status == 4)
                {
                    WebClientHelper.DoClientMsgBox("卡片处于补卡状态，不能进行注销...");
                }
                else
                {
                    tb_Card t = new tb_Card();
                    t.balance = 0;
                    t.card = Card.Value;
                    CardHelperBLL.UpdateCard(t);
                    msg = "您执行了退卡操作，此卡上余额将清零！";

                    int count = 0;
                    card_chargelist list = new card_chargelist();
                    //遍历GridView行，得到chargetype的值，更新值
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        list.transId = GridView1.Rows[i].Cells[0].Text.ToString();//交易号
                        string type = GridView1.Rows[i].Cells[3].Text.ToString();
                        if (type == "充值")
                        {
                            list.Chargetype = "充值回滚";
                            count += CardHelperBLL.UpdateCard_ChargeList(list);
                        }
                        else if (type == "扣款")
                        {
                            list.Chargetype = "扣款回滚";
                            count += CardHelperBLL.UpdateCard_ChargeList(list);
                        }
                    }
                    //写入日志
                    tb_Log log = new tb_Log();
                    log.logid = DateTime.Now.ToString("yyyyMMddHHmmss");
                    log.operater = Ims.Main.ImsInfo.CurrentUserId;
                    //log.operater = "admin";
                    log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    log.type = "销卡操作";
                    log.logmsg = log.operater + "  对当前注销卡的充值/扣款记录进行回滚操作,成功回滚数据" + count + "条记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条充值/扣款记录!");

                    if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                    {
                        cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                        return;
                    }
                }
            }
        }
        else
        {
            WebClientHelper.DoClientMsgBox("请输入要注销的卡号！");
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        v_card_chargelist_area o = ParameterBindHelper.BindParameterToObject(typeof(v_card_chargelist_area), BindParameterUsage.OpQuery) as v_card_chargelist_area;
        o.Card = Card.Value.Trim();
        o.flag = true;
        e.InputParameters[0] = o;
    }
}
