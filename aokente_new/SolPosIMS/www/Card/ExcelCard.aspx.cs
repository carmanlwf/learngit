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
using Ims.Card.Model;
using ZsdDotNetLibrary.Web;
using Ims.Site.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.BLL;
using Ims.Log.Model;
using Ims.Log.BLL;
using System.Text;
using System.Threading;
using Ims.Member.Model;

public partial class Card_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            InitListControlHelper.BindNormalTableToListControl(TypeID, "TypeID", "TypeName", "tb_CardType", "", "DeleStatus =0", "");
        }
    }

    //上传Excel
    protected string fill()
    {
        string Road = "";
        try
        {
            string ExcelFile = this.FileCell.PostedFile.FileName;//FileUpload为asp:FileUpload控件
            string FileName = ExcelFile.Substring(ExcelFile.LastIndexOf(".") + 1);
            if (FileName != "xls")
            {
                Response.Write("<script>alert('您上传的不是Excel文件！')</script>");
            }

            string datetime = DateTime.Now.Date.ToString("yyyyMMdd");
            string time = DateTime.Now.ToShortTimeString().Replace(":", "");
            string NewFileName = "Excel" + datetime + time + DateTime.Now.Millisecond.ToString() + ".xls";//生成新文件名
            Road = Server.MapPath("~\\card\\excel") + "\\" + NewFileName;
            //ViewState["xpath"] = pathX;
            this.FileCell.PostedFile.SaveAs(Road);

        }
        catch
        {
            Response.Write("<script>alert('数据上传失败，请重新导入')</script>");
        }
        return Road;
    }
    //导入表制卡
    protected void Button1_Click(object sender, EventArgs e)
    {
        string path = fill();
        string operter = Ims.Main.ImsInfo.CurrentUserId;//操作者
        int num = 0;
        int znum = 0;
        string memo = "";
        string a = "";
        if (path.Length > 5)
        {
            int stat = path.Length - 4;
            a = path.Substring(stat, 4);
        }
  
        if (a != "" && a == ".xls")
        {
            string Bname = "";
            if (name.Value == "")
            {
                Bname = "Sheet1";
            }
            else
            {
                Bname = name.Value;
            }
            DataTable dt = WebHelper.XlsToDataTable(Bname, path);
            string Card0 = "";
            string Card1 = "";
            string Card2 = "";
            //获取Excel列名
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName == "卡号")
                {
                    Card0 = dc.ColumnName;
                }
                if (dc.ColumnName == "卡号1")
                {
                    Card1 = dc.ColumnName;
                }
                if (dc.ColumnName == "卡号2")
                {
                    Card2 = dc.ColumnName;
                }

            }
            tb_Card tc = new tb_Card();

            tb_Member t = new tb_Member();
            tb_CardActivityByShop ts = new tb_CardActivityByShop();
            tb_CardActive_Histroy h = new tb_CardActive_Histroy();
            if (Checkbox1.Checked == true)
            {
                tc.activitystatus = 0;
                tc.Status = 0;

             
            }
            else {
                tc.activitystatus = 1;
                tc.Status = 1;
                tc.regionid = Request.Form.Get("Site_Code");
            
            }


            tc.addeddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            tc.memo = "系统导入Excel生成的不记名卡";
            tc.isSysAuto = true;
            //tc.regionid = "S-20120719021227";
            tc.TypeID = TypeID.Value;
            tc.validDate = validDate.Value + " 23:59:59";
            tc.Points = 0;
            string txtpass = "";
            StringBuilder sb_cardno = new StringBuilder();
            StringBuilder sb_pass = new StringBuilder();
            StringBuilder sb_initvalue = new StringBuilder();
            StringBuilder sb_loginpass = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {

                    if (Card0 != "" && dt.Rows[i]["卡号"].ToString() != "")
                    {
                        tc.card = dt.Rows[i]["卡号"].ToString();
                        tc.physicalno = dt.Rows[i]["卡号"].ToString();
                        string money = dt.Rows[i]["面值"].ToString();
                        if (money == "")
                        {
                            money = "0";
                        }
                        tc.initvalue = decimal.Parse(money);
                        tc.balance = decimal.Parse(money);
                        //密码选择
                        if (SJ.Checked == true)
                        {
                            string newpass = "";
                            string[] s = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                            Random rd = new Random();
                            for (int j = 0; j < 6; j++)
                            {
                                newpass += s[rd.Next(10)].ToString();
                            }
                            txtpass = newpass;
                            string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newpass, "MD5");
                            tc.pass = pass;
                            tc.tradepassword = pass;
                        }
                        else
                        {
                            txtpass = dt.Rows[i]["密码"].ToString();
                            string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(dt.Rows[i]["密码"].ToString(), "MD5");
                            tc.pass = pass;
                            tc.tradepassword = pass;
                        }
                        tb_Card count = new tb_Card();
                        count.card = dt.Rows[i]["卡号"].ToString();
                        if (CardHelperBLL.GetObjectsCount_card(count) > 0)
                        {
                            num++;
                            memo += count.card + "，";
                        }
                        else
                        {
                            znum++;
                         
                            //激活选择
                            if (Checkbox2.Checked == true)
                            {
                                tc.Userid = "M" + DateTime.Now.ToString("yMdHHmmss") + i.ToString()+"1";
                                //会员表
                                t.Userid = tc.Userid;
                                t.Expenditure = 0;
                                t.RealName = "无名单";
                                t.Regionid = tc.regionid;
                                //t.UserRank = UserRank.Value;
                                t.Memo = "系统自动生成的不记名卡用户";
                                t.isSysAuto = true;
                                t.flag = true;
                                t.addeddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                t.Points = 0;
                                //激活表
                                ts.card = tc.card;
                                ts.siteid = t.Regionid;
                                ts.activitydate = tc.addeddate;
                                ts.activityway = "在线";
                                ts.operatorid = operter;
                                ts.status = 2;
                                ts.memo = "系统自动批量生成的不记名卡用户!";
                                ts.flag1 = true;

                                //记录表
                                h.Contno = DateTime.Now.ToString("yMdHHmmss") + i.ToString();
                                h.Card = tc.card;
                                h.Activeway = "在线";
                                h.Activeoperator = operter;
                                h.activetime = tc.addeddate;
                                h.Memo = "系统自动批量生成的不记名卡用户";
                                h.flag = true;
                                if (CardHelperBLL.SentCardAndActive(tc, t, ts, h) == false)
                                {
                                    WebClientHelper.DoClientMsgBox("未知错误，请重试！");
                                }
                            }
                            else
                            {
                                CardHelperBLL.InsertObject(tc);
                                
                            }

                            sb_cardno.Append(tc.card);//卡号
                            sb_cardno.Append("#");
                            sb_pass.Append(txtpass);    //交易密码
                            sb_pass.Append("#");
                            sb_initvalue.Append(tc.initvalue);//初始金额
                            sb_initvalue.Append("#");
                            sb_loginpass.Append(txtpass);  //登陆密码
                            sb_loginpass.Append("#");
                            Thread.Sleep(20);
                        }


                    }

                    if (Card1 != "" && dt.Rows[i]["卡号1"].ToString() != "")
                    {
                        tc.card = dt.Rows[i]["卡号1"].ToString();
                        tc.physicalno = dt.Rows[i]["卡号1"].ToString();
                        string money = dt.Rows[i]["面值1"].ToString();
                        if (money == "")
                        {
                            money = "0";
                        }
                        tc.initvalue = decimal.Parse(money);
                        tc.balance = decimal.Parse(money);
                        //密码选择
                        if (SJ.Checked == true)
                        {
                            string newpass = "";
                            string[] s = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                            Random rd = new Random();
                            for (int j = 0; j < 6; j++)
                            {
                                newpass += s[rd.Next(10)].ToString();
                            }
                            txtpass = newpass;
                            string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newpass, "MD5");
                            tc.pass = pass;
                            tc.tradepassword = pass;
                        }
                        else
                        {
                            txtpass = dt.Rows[i]["密码1"].ToString();
                            string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(dt.Rows[i]["密码1"].ToString(), "MD5");
                            tc.pass = pass;
                            tc.tradepassword = pass;
                        }

                        tb_Card count = new tb_Card();
                        count.card = dt.Rows[i]["卡号1"].ToString();
                        if (CardHelperBLL.GetObjectsCount_card(count) > 0)
                        {
                            num++;
                            memo += count.card + "，";
                        }
                        else
                        {
                            znum++;
                            //激活选择
                            if (Checkbox2.Checked == true)
                            {
                                tc.Userid = "M" + DateTime.Now.ToString("yMdHHmmss") + i.ToString() + "2";
                                //会员表
                                t.Userid = tc.Userid;
                                t.Expenditure = 0;
                                t.RealName = "无名单";
                                t.Regionid = tc.regionid;
                                //t.UserRank = UserRank.Value;
                                t.Memo = "系统自动生成的不记名卡用户";
                                t.isSysAuto = true;
                                t.flag = true;
                                t.addeddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                t.Points = 0;
                                //激活表
                                ts.card = tc.card;
                                ts.siteid = t.Regionid;
                                ts.activitydate = tc.addeddate;
                                ts.activityway = "在线";
                                ts.operatorid = operter;
                                ts.status = 2;
                                ts.memo = "系统自动批量生成的不记名卡用户!";
                                ts.flag1 = true;
                                
                                //记录表
                                h.Contno = DateTime.Now.ToString("yMdHHmmss") + i.ToString();
                                h.Card = tc.card;
                                h.Activeway = "在线";
                                h.Activeoperator = operter;
                                h.activetime = tc.addeddate;
                                h.Memo = "系统自动批量生成的不记名卡用户";
                                h.flag = true;
                                if (CardHelperBLL.SentCardAndActive(tc, t, ts, h) == false)
                                {
                                    WebClientHelper.DoClientMsgBox("未知错误，请重试！");
                                }
                            }
                            else
                            {
                                CardHelperBLL.InsertObject(tc);

                            }

                            sb_cardno.Append(tc.card);//卡号
                            sb_cardno.Append("#");
                            sb_pass.Append(txtpass);    //交易密码
                            sb_pass.Append("#");
                            sb_initvalue.Append(tc.initvalue);//初始金额
                            sb_initvalue.Append("#");
                            sb_loginpass.Append(txtpass);  //登陆密码
                            sb_loginpass.Append("#");
                            Thread.Sleep(20);
                        }
                    }

                    if (Card2 != "" && dt.Rows[i]["卡号2"].ToString() != "")
                    {
                        tc.card = dt.Rows[i]["卡号2"].ToString();
                        tc.physicalno = dt.Rows[i]["卡号2"].ToString();
                        string money = dt.Rows[i]["面值2"].ToString();
                        if (money == "")
                        {
                            money = "0";
                        }
                        tc.initvalue = decimal.Parse(money);
                        tc.balance = decimal.Parse(money);
                        //密码选择
                        if (SJ.Checked == true)
                        {
                            string newpass = "";
                            string[] s = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                            Random rd = new Random();
                            for (int j = 0; j < 6; j++)
                            {
                                newpass += s[rd.Next(10)].ToString();
                            }
                            txtpass = newpass;
                            string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newpass, "MD5");
                            tc.pass = pass;
                            tc.tradepassword = pass;
                        }
                        else
                        {
                            txtpass = dt.Rows[i]["密码2"].ToString();
                            string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(dt.Rows[i]["密码2"].ToString(), "MD5");
                            tc.pass = pass;
                            tc.tradepassword = pass;
                        }
                        tb_Card count = new tb_Card();
                        count.card = dt.Rows[i]["卡号2"].ToString();
                        if (CardHelperBLL.GetObjectsCount_card(count) > 0)
                        {
                            num++;
                            memo += count.card + "，";
                        }
                        else
                        {
                            znum++;
                            if (Checkbox2.Checked == true)
                            {
                                tc.Userid = "M" + DateTime.Now.ToString("yMdHHmmss") + i.ToString() + "3";
                                //会员表
                                t.Userid = tc.Userid;
                                t.Expenditure = 0;
                                t.RealName = "无名单";
                                t.Regionid = tc.regionid;
                                //t.UserRank = UserRank.Value;
                                t.Memo = "系统自动生成的不记名卡用户";
                                t.isSysAuto = true;
                                t.flag = true;
                                t.addeddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                t.Points = 0;
                                //激活表
                                ts.card = tc.card;
                                ts.siteid = t.Regionid;
                                ts.activitydate = tc.addeddate;
                                ts.activityway = "在线";
                                ts.operatorid = operter;
                                ts.status = 2;
                                ts.memo = "系统自动批量生成的不记名卡用户!";
                                ts.flag1 = true;

                                //激活历史表
                                h.Contno = DateTime.Now.ToString("yMdHHmmss") + i.ToString();
                                h.Card = tc.card;
                                h.Activeway = "在线";
                                h.Activeoperator = operter;
                                h.activetime = tc.addeddate;
                                h.Memo = "系统自动批量生成的不记名卡用户";
                                h.flag = true;
                                if (CardHelperBLL.SentCardAndActive(tc, t, ts, h) == false)
                                {
                                    WebClientHelper.DoClientMsgBox("未知错误，请重试！");
                                }
                            }
                            else
                            {
                                CardHelperBLL.InsertObject(tc);

                            }
                            sb_cardno.Append(tc.card);//卡号
                            sb_cardno.Append("#");
                            sb_pass.Append(txtpass);    //交易密码
                            sb_pass.Append("#");
                            sb_initvalue.Append(tc.initvalue);//初始金额
                            sb_initvalue.Append("#");
                            sb_loginpass.Append(txtpass);  //登陆密码
                            sb_loginpass.Append("#");
                            Thread.Sleep(20);
                        }
                    }

                }
                catch (Exception)
                {

                    WebClientHelper.DoClientMsgBox("请选择正确的Excel文件，错误原因无卡号，或者Excel列名错误！");
                }

            }
            if (num > 0)
            {
                string[] str1 = sb_cardno.ToString().Split('#');
                string[] str2 = sb_pass.ToString().Split('#');
                string[] str3 = sb_initvalue.ToString().Split('#');
                string[] str4 = sb_loginpass.ToString().Split('#');
                string filename = "Txt" + DateTime.Now.ToString("yyyyMMddhhmmss");
                if (WebHelper.RecordToTxt_CardBatchResgistion(filename, str1, str2, str4, str3))
                {
                    lbDown.Text = "<a href ='../CardTxt/" + filename + ".txt" + "' target = '_blank' style='color:Green'>点击右键'目标另存为(A)...'下载该批次号码</a>";
                }
            }
            //写入日志
            tb_Log log = new tb_Log();
            log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            log.operater = Ims.Main.ImsInfo.CurrentUserId;
            log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.type = "导入制卡";
            if (num > 10)
            {
                log.logmsg = log.operater + "成功导入卡" + znum + "张!未能导入卡" + num + "张! 原因是该卡号系统已存在!";
                LogHelperBLL.InsertObject(log);
                WebClientHelper.DoClientMsgBox("成功导入卡" + znum + "张! 未能导入卡 " + num + "张! 原因是该卡号系统已存在!");
            }
            else
            {
                log.logmsg = log.operater + "成功导入卡" + znum + "张!未能导入卡" + num + "张!其卡号为:" + memo + " 原因是该卡号系统已存在!";
                LogHelperBLL.InsertObject(log);
                WebClientHelper.DoClientMsgBox("成功导入卡" + znum + "张!未能导入卡 " + num + "张! 其卡号为:" + memo + " 原因是该卡号系统已存在!");
            }

        }
        else
        {
            WebClientHelper.DoClientMsgBox("请选择正确的格式文件！");
        }
    }
}
