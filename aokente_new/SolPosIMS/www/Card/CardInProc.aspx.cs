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
using System.Data.OleDb;
using System.IO;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Log;
using Ims.Card.Model;
using Ims.Card.BLL;
using Ims.Member.Model;

public partial class Card_CardInProc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
       
         Importdata();   
 
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("请先预览卡片信息是否正确，再进行数据导入");
            
        }
        else
        {
            if (Session["tabledate"] != null)
            {
                int inQuent = 0;
                DataTable ta = (DataTable)Session["tabledate"];
                string cardMessge = IsInOroOut(ta);
                if (cardMessge == "KO")
                {
                    //开始导入
                    tb_Card card = new tb_Card();

                    for (int q = 0; q < ta.Rows.Count; q++)
                    {
                        //判断此卡号在数据库中是否已存在
                        if (CardHelperBLL.HaveThatCard(ta.Rows[q][2].ToString()) > 0)
                        {
                            continue;
                        }
                        else
                        {
                            card.card = ta.Rows[q][2].ToString().Trim();
                            card.physicalno = ta.Rows[q][1].ToString().Trim();
                            card.Balance = Convert.ToDecimal(ta.Rows[q][3].ToString().Trim());
                            card.initvalue = card.Balance;
                            card.tradepassword = WebHelper.Encrypt(MembershipPasswordFormat.Encrypted,"000000", WebHelper.tradepassword_salt);
                            card.pass = card.tradepassword;
                            //card.tradepassword = "000000";
                            //card.pass = card.tradepassword;
                            card.addeddate = ta.Rows[q][6].ToString();
                            card.memo = "个人导入";
                            card.validDate = "2030-12-31 23:59:59";

                            if (Checkbox2.Checked == false)//不直接激活
                            {
                                card.activitystatus = 0;
                                card.Status = 0;
                                card.chflag = true;
                                card.isSysAuto = false;

                                if (CardHelperBLL.InsertObject(card) > 0)
                                {
                                    inQuent++;
                                    continue;
                                }

                            }
                            else
                            {
                                card.activitystatus = 1;//待激活的卡
                                card.Userid = "M" + DateTime.Now.ToString("yMdHmss") + q.ToString();
                                card.Status = 1;
                                card.regionid = siteID1.Value.Trim();


                                tb_Member t = new tb_Member();
                                t.Userid = card.Userid;
                                t.Expenditure = 0;
                                t.RealName = "无名单";
                                t.Regionid = card.regionid;
                                t.UserRank = RanksID1.Value;
                                t.Memo = "系统自动生成的不记名卡用户";
                                t.isSysAuto = true;
                                t.flag = true;
                                t.addeddate = card.addeddate;
                                t.Points = 0;

                                tb_CardActivityByShop s = new tb_CardActivityByShop();
                                s.card = card.card;
                                s.siteid = t.Regionid;
                                s.activitydate = card.addeddate;
                                s.activityway = "在线";
                                s.operatorid = ta.Rows[q][7].ToString().Trim();
                                s.status = 2;
                                s.memo = "系统自动批量生成的不记名卡用户!";
                                s.flag1 = true;

                                tb_CardActive_Histroy h = new tb_CardActive_Histroy();
                                h.Contno = DateTime.Now.ToString("yMdHmss") + q.ToString();
                                h.Card = card.card;
                                h.Activeway = "在线";
                                h.Activeoperator = s.operatorid;
                                h.activetime = card.addeddate;
                                h.Memo = "系统自动批量生成的不记名卡用户";
                                h.flag = true;
                                if (CardHelperBLL.SentCardAndActive(card, t, s, h))
                                {
                                    inQuent++;
                                    continue;
                                }
                            }


                        }
                    }
                    if (inQuent > 0)
                    {
                        WebClientHelper.DoClientMsgBox("成功导入" + inQuent.ToString() + "条数据!");
                    }
                    else
                    {
                        WebClientHelper.DoClientMsgBox("成功导入" + inQuent.ToString() + "条数据!如果没有导入数据，原因是数据库已存在相同卡号的数据!");
                    }
                }
                else
                {
                    WebClientHelper.DoClientMsgBox(cardMessge);
                }
            }
            else
            {
                if (GridView1.Rows.Count <= 0)
                {
                    WebClientHelper.DoClientMsgBox("请先预览卡片信息是否正确，再进行数据导入");
                }
            }
        }
    }
    public  DataTable ExcelToDataTable(string strExcelFileName, string strSheetName)
    {
        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties=Excel 5.0;";
        string strExcel = string.Format("select * from [{0}$]", strSheetName);
        DataSet ds = new DataSet();
        //try
        //{
        using (OleDbConnection conn = new OleDbConnection(strConn))
        {
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
            adapter.Fill(ds, strSheetName);
            conn.Close();
        }
        DataTable ta = ds.Tables[strSheetName];
        DataTable c = new DataTable();//创建临时表 

        c.Columns.Add(new DataColumn("序号", typeof(string)));
        c.Columns.Add(new DataColumn("卡面卡号", typeof(string)));
        c.Columns.Add(new DataColumn("内部卡号", typeof(string)));
        c.Columns.Add(new DataColumn("初始金额", typeof(decimal)));
        c.Columns.Add(new DataColumn("直接激活", typeof(string)));
        c.Columns.Add(new DataColumn("密码", typeof(string)));
        c.Columns.Add(new DataColumn("导入日期", typeof(string)));
        c.Columns.Add(new DataColumn("导入者", typeof(string)));

        decimal money = 0;
       money = Convert.ToDecimal(Money.Value);


        string isActive = "";
        if (Checkbox2.Checked == true)
        {
            isActive = "是";
        }
        else
        {
            isActive = "否";
        }

        for (int i = 0; i < ta.Rows.Count; i++)
        {
            DataRow dr = c.NewRow();
            dr["序号"] = ta.Rows[i][0].ToString();
            dr["卡面卡号"] = ta.Rows[i][1].ToString();
            dr["内部卡号"] = ta.Rows[i][2].ToString();
            dr["初始金额"] = money;
            dr["直接激活"] = isActive;
            dr["密码"] = "000000";
            dr["导入日期"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dr["导入者"] = Ims.Main.ImsInfo.CurrentUserId;
            c.Rows.Add(dr);
        }

        return c;
        //}
        //catch(Exception ex)
        //{
        //    LogHelper.Write(ex.Message);
        //    return null;
        //}
    }
 
    private void Importdata()
    {
        //先上传到某文件夹
        string fileName = FileUpload1.FileName;
        string fileSize = FileUpload1.PostedFile.ContentLength.ToString();
        string fileType = FileUpload1.PostedFile.ContentType;
        string fileType1 = fileName.Substring(fileName.LastIndexOf(".") + 1);

        string upImagePath = Server.MapPath(Request.ApplicationPath + "/CardEXEC") + "\\" + fileName;
        string upFilePath = Server.MapPath(Request.ApplicationPath + "/files") + "\\" + fileName;
        string databasePath = Request.ApplicationPath + "/CardEXEC" + "/" + fileName;

        if (fileType1 != "xls") //文件后缀名
        {
            WebClientHelper.DoClientMsgBox("选择文件的格式不对或未选择文件!");
        }
        else
        {
            try
            {
                FileUpload1.SaveAs(upImagePath);   //上传成功后
                System.Threading.Thread.Sleep(2000);//进程休眠5秒！

                string path2 = Server.MapPath("../CardEXEC/"); //路径
                string delFile = path2 + fileName;

                string sheet = "Sheet1";
                GridView1.DataSource = ExcelToDataTable(delFile, sheet);
                GridView1.DataBind();

                //写入缓存
                Session["tabledate"] = ExcelToDataTable(delFile, sheet);

                //最后删除
                File.Delete(delFile);
            }
            catch (Exception ex)
            {
                string path3 = Server.MapPath("../CardEXEC/"); //获取文件路径
                string delFile3 = path3 + fileName;
                if (path3 == "")
                {
                    //不做任何处理
                }
                else
                {
                    //最后删除
                    File.Delete(delFile3);
                }

                LogHelper.Write(ex.Message);
                WebClientHelper.DoClientMsgBox("文件格式不正确,导入失败,请重试!");
            }

        }
    }
    protected void Button4_ServerClick(object sender, EventArgs e)
    {
        string fileName = "template.xls";//客户端保存的文件名
        string filePath = Server.MapPath("../CardEXEC/EXEC/template.xls");//路径

        System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
        if (fileInfo.Exists == true)
        {
            const long ChunkSize = 102400;//100K 每次读取文件，只读取100K，这样可以缓解服务器的压力
            byte[] buffer = new byte[ChunkSize];

            Response.Clear();
            System.IO.FileStream iStream = System.IO.File.OpenRead(filePath);
            long dataLengthToRead = iStream.Length;//获取下载的文件总大小
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
            while (dataLengthToRead > 0 && Response.IsClientConnected)
            {
                int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
                Response.OutputStream.Write(buffer, 0, lengthRead);
                Response.Flush();
                dataLengthToRead = dataLengthToRead - lengthRead;
            }
            Response.Close();
            WebClientHelper.DoClientMsgBox("下载成功!");
        }
        else
        {
            WebClientHelper.DoClientMsgBox("模版文件不存在!");
        }

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = (DataTable)Session["tabledate"];
            GridView1.DataBind();
            TextBox tb = (TextBox)GridView1.BottomPagerRow.FindControl("inPageNum");
            tb.Text = (GridView1.PageIndex + 1).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "go")
        {
            try
            {
                TextBox tb = (TextBox)GridView1.BottomPagerRow.FindControl("inPageNum");
                int num = Int32.Parse(tb.Text);
                GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                GridView1_PageIndexChanging(null, ea);
            }
            catch (Exception ex)
            {
                LogHelper.Write(ex.Message);
            }
        }
    }

    //判断值是否为空
    public static string IsInOroOut(DataTable ta)
    {
        string messge = "KO";
        if (ta!=null)
        {
            for (int i = 0; i < ta.Rows.Count; i++)
            {
                if (ta.Rows[i][1].ToString() == "")
                {
                    //WebClientHelper.DoClientMsgBox("导入xls中第:" + (r + 2) + "行卡面卡号为空值!请处理好xls再进行导入!");
                    messge = "导入xls中第:" + (i  + 2) + "行卡面卡号为空值!请处理好xls再进行导入!";
                    break;
                }
                else
                {
                    if (ta.Rows[i][2].ToString() == "")
                    {
                        //WebClientHelper.DoClientMsgBox("导入xls中第:" + (r + 2) + "行内部卡号为空值!请处理好xls再进行导入!");
                        messge = "导入xls中第:" + (i  + 2) + "行内部卡号为空值!请处理好xls再进行导入!";
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        return messge;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        Importdata();
    }
 
}
