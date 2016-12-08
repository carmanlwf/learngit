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
using System.Text;
using Ims.Card.Model;
using Ims.Card.BLL;
using Ims.Log.BLL;
using System.Threading;
using Ims.Log.Model;
using Ims.Member.Model;

public partial class Card_SentCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ///权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {

            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");

            InitListControlHelper.BindNormalTableToListControl(TypeID, "TypeID", "TypeName", "tb_CardType", "", "DeleStatus =0", "");
        }
    }
    protected void bt_Batch_ServerClick(object sender, EventArgs e)
    {
        if (CheckCardNoValid())
        {
            string card_head = CardPre.Value;
            int card_num = int.Parse(Num.Value.Trim());
            double init_balance = string.IsNullOrEmpty(InitBalance.Value.Trim()) ? 0.00 : double.Parse(InitBalance.Value);
            string operter = Ims.Main.ImsInfo.CurrentUserId;//操作者
            int succes_num = 0;
            string code = "";
            string pass = "";

            StringBuilder sb_cardno = new StringBuilder();
            StringBuilder sb_pass = new StringBuilder();
            StringBuilder sb_initvalue = new StringBuilder();
            StringBuilder sb_loginpass = new StringBuilder();
            for (int i = 0; i < card_num; i++)
            {
                string card_customer = card_head + FormatCardStr(StartNum.Value.Trim(), i);
                //启用过滤后4结尾的卡号自动跳过
                if (cbIn4.Checked)
                {
                    if (card_customer.LastIndexOf("4") > 0)
                        continue;
                }
                //启用过滤后7结尾的卡号自动跳过
                if (cbIn7.Checked)
                {
                    if (card_customer.LastIndexOf("7") > 0)
                        continue;
                }
                if (Checkbox2.Checked == true)
                {
                    tb_Card c = new tb_Card();
                    c.card = card_head + FormatCardStr(StartNum.Value.Trim(), i);

                    if (Checkbox4.Checked == true)//统一密码
                    {
                        code = password.Value.Trim();
                        pass = password.Value.Trim();
                    }
                    else
                    {
                        code = c.card.Substring(c.card.Length - 6);//交易密码 （卡号后6位）
                        pass = c.card.Substring(c.card.Length - 6);//交易密码 （卡号后6位）
                    }
                    //str.Substring(str.Length - i); 
                    //c.Balance = double.Parse(InitBalance.Value); //账户余额
                    c.Balance = Convert.ToDecimal(InitBalance.Value); //账户余额
                    c.initvalue = Convert.ToDecimal(InitBalance.Value);//初始金额
                    c.tradepassword = WebHelper.Encrypt(MembershipPasswordFormat.Encrypted, code, WebHelper.tradepassword_salt);
                    c.pass = WebHelper.Encrypt(MembershipPasswordFormat.Encrypted, pass, WebHelper.tradepassword_salt);
                    c.addeddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    c.memo = "系统自动生成的不记名卡";
                    c.activitystatus = 1;//待激活的卡
                    c.physicalno = c.card;
                    c.isSysAuto = true;
                    c.Status = 1;//待激活状态
                    c.chflag = true;//启用
                    c.Userid = "M" + DateTime.Now.ToString("yMdHHmmss") + i.ToString();
                    c.validDate = validDate.Value + " 23:59:59";
                    c.Status = 1;
                    c.regionid = Request.Form.Get("Site_Code");
                    c.TypeID = TypeID.Value;

                    tb_Member t = new tb_Member();
                    t.Userid = c.Userid;
                    t.Expenditure = 0;
                    t.RealName = "无名单";
                    t.Regionid = c.regionid;
                    //t.UserRank = UserRank.Value;
                    t.Memo = "系统自动生成的不记名卡用户";
                    t.isSysAuto = true;
                    t.flag = true;
                    t.addeddate = c.addeddate;
                    t.Points = 0;


                    tb_CardActivityByShop s = new tb_CardActivityByShop();
                    s.card = c.card;
                    s.siteid = t.Regionid;
                    s.activitydate = c.addeddate;
                    s.activityway = "在线";
                    s.operatorid = operter;
                    s.status = 2;
                    s.memo = "系统自动批量生成的不记名卡用户!";
                    s.flag1 = true;

                    tb_CardActive_Histroy h = new tb_CardActive_Histroy();
                    h.Contno = DateTime.Now.ToString("yMdHHmmss") + i.ToString();
                    h.Card = c.card;
                    h.Activeway = "在线";
                    h.Activeoperator = operter;
                    h.activetime = c.addeddate;
                    h.Memo = "系统自动批量生成的不记名卡用户";
                    h.flag = true;


                    if (CardHelperBLL.GetObject_objec(c.card.Trim()) == null)//系统是否已有此卡号
                    {
                        if (CardHelperBLL.SentCardAndActive(c, t, s, h))
                        {
                            succes_num++;
                            sb_cardno.Append(c.card);//卡号
                            sb_cardno.Append("#");
                            sb_pass.Append(code);    //交易密码
                            sb_pass.Append("#");
                            sb_initvalue.Append(c.initvalue);//初始金额
                            sb_initvalue.Append("#");
                            sb_loginpass.Append(pass);  //登陆密码
                            sb_loginpass.Append("#");
                            Thread.Sleep(20);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
                //不直接激活
                else
                {
                    tb_Card c = new tb_Card();
                    c.card = card_head + FormatCardStr(StartNum.Value.Trim(), i);
                    if (Checkbox4.Checked == true)//统一密码
                    {
                        code = password.Value.Trim();
                        pass = password.Value.Trim();
                    }
                    else
                    {
                        code = c.card.Substring(c.card.Length - 6);//交易密码 （卡号后6位）
                        pass = c.card.Substring(c.card.Length - 6);//交易密码 （卡号后6位）
                    }
                    //code = c.card.Substring(3);//交易密码 （卡号后6位）
                    //pass = c.card.Substring(3);//登陆密码明文 （卡号后6位）
                    c.Balance = Convert.ToDecimal(InitBalance.Value); //账户余额
                    c.initvalue = Convert.ToDecimal(InitBalance.Value); ;//初始金额

                    c.tradepassword = WebHelper.Encrypt(MembershipPasswordFormat.Encrypted, code, WebHelper.tradepassword_salt);
                    c.pass = WebHelper.Encrypt(MembershipPasswordFormat.Encrypted, pass, WebHelper.tradepassword_salt);

                    c.addeddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    c.memo = "系统自动生成的不记名卡";
                    c.activitystatus = 0;//待激活的卡
                    c.physicalno = c.card;
                    //c.Userid = t.Userid;
                    c.isSysAuto = true;
                    c.Status = 0;//待激活状态
                    c.chflag = true;//启用
                    c.TypeID = TypeID.Value;//卡所属类型
                    //c.GroupID = GroupID1.Value;
                    //c.SaleMemID = Request.Form.Get("Member1");


                    if (CardHelperBLL.GetObject_objec(c.card.Trim()) == null)
                    {
                        if (CardHelperBLL.InsertObject(c) > 0)
                        {
                            succes_num++;
                            sb_cardno.Append(c.card);//卡号
                            sb_cardno.Append("#");
                            sb_pass.Append(code);    //交易密码
                            sb_pass.Append("#");
                            sb_initvalue.Append(c.initvalue);//初始金额
                            sb_initvalue.Append("#");
                            sb_loginpass.Append(pass);  //登陆密码
                            sb_loginpass.Append("#");
                            Thread.Sleep(20);
                        }
                        else
                        {
                            continue;
                        }

                    }
                    else
                    {
                        continue;
                    }
                }
            }
            if (succes_num > 0)
            {
                tb_Log log = new tb_Log();
                log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.type = "批量发卡";
                log.logmsg = "批量发卡操作.卡号前缀：" + CardPre.Value + ",起始序号：" + StartNum.Value + ",张数：" + Num.Value + ",初始金额：" + InitBalance.Value + ",生成方式：" + RadFileFormat.SelectedItem.Text + ",共有" + succes_num + "张成功.";
                log.flag = true;
                LogHelperBLL.InsertObject(log);
            }
            CardPre.Value = "";
            StartNum.Value = "";
            Num.Value = "";
            password.Value = "";
            WebClientHelper.DoClientMsgBox("批量发卡结束!共有" + succes_num + "张成功.");
            //textid.Text = "批量发卡结束!共有" + succes_num + "张成功.";
            string[] str1 = sb_cardno.ToString().Split('#');
            string[] str2 = sb_pass.ToString().Split('#');
            string[] str3 = sb_initvalue.ToString().Split('#');
            string[] str4 = sb_loginpass.ToString().Split('#');
            string filename = "Txt" + DateTime.Now.ToString("yyyyMMddhhmmss");
            if (succes_num > 0)
            {
                switch (RadFileFormat.SelectedIndex)
                {
                    case 0:
                        if (WebHelper.RecordToTxt_CardBatchResgistion(filename, str1, str2, str4, str3))
                        {
                            lbDown.Text = "<a href ='../CardTxt/" + filename + ".txt" + "' target = '_blank' style='color:Green'>点击右键'目标另存为(A)...'下载该批次号码</a>";
                        }
                        break;
                    case 1:
                        lbDown.ForeColor = System.Drawing.Color.Red;
                        lbDown.Text = "生成的Excel文件不会保存在服务器上,请下载到本地保存!";

                        WebHelper.RecordToExcel_BatchRegistion(filename, str1, str2, str4, str3);
                        //WebClientHelper.DoClientMsgBox("发卡成功!");
                        break;
                    default:
                        lbDown.Text = "系统异常,请联系开发商!";
                        break;
                }
            }
            else
            {
                lbDown.ForeColor = System.Drawing.Color.Red;
                lbDown.Text = "无任何卡号生成！";
            }


        }

        else
        {
            WebClientHelper.DoClientMsgBox("卡号生成将溢出,请重新指定起始序号和张数!");
        }
    }
    /// <summary>
    /// 判断卡号是否溢出
    /// </summary>
    /// <returns></returns>
    public bool CheckCardNoValid()
    {
        Int64 c1 = Int64.Parse(StartNum.Value.Trim());
        Int64 c2 = Int64.Parse(Num.Value.Trim());
        Int64 c = c1 + c2;
        if (c > 9999999999)//9999999999
        { return false; }
        else
        { return true; }
    }
    /// <summary>
    /// 格式化卡号后半部分
    /// </summary>
    /// <param name="baseNum"></param>
    /// <param name="i_sqno"></param>
    /// <returns></returns>
    public string FormatCardStr(string baseNum, int i_sqno)
    {
        int cardrihgtlenth = 0;
        if (StartNum.Value.Trim() != "")
        {
            cardrihgtlenth = StartNum.Value.Trim().Length;
        }
        else
        {
            cardrihgtlenth = 3;
        }
        Int64 baseNo = Int64.Parse(baseNum) + Convert.ToInt64(i_sqno);
        string str_temp = baseNo.ToString();
        while (str_temp.Length < cardrihgtlenth) //10,8,6
        {
            str_temp = "0" + str_temp;
        }
        return str_temp;
    }

}
