using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ims.Pos.DAL;
using Ims.Pos.Model;
using Newtonsoft.Json;

namespace Ims.Pos.BLL
{
    public class CheckIsArrearageHelperBLL
    {
        public static string GetAccountInfoByCardSnr(input_CheckIsArrearage oInput)
        {
            string CardSnr = oInput.CardSnr;
            string ret_str = "";
            output_CheckIsArrearage oOutput = new output_CheckIsArrearage();
            //oOutput.CardSnr = CardSnr;
            oOutput.Balance = 0;
            oOutput.CardType = "";
            oOutput.CellPhone = "";
            oOutput.FLAG = "-1";
            oOutput.MESSAGE = "server error";
            oOutput.Points = 0;
            oOutput.TotalExpenditure = 0;
            oOutput.validDate = "";
            oOutput.LastSaleTime = "";
            try
            {
                DataTable dt = CheckIsArrearageHelperDAL.GetAccountInfoByCardSnr(CardSnr);
                if (dt != null && dt.Rows.Count > 0)
                {
                    decimal mybalance = 0;
                    decimal myExpenditure = 0;
                    int mypoint = 0;
                    if (dt.Rows[0]["balance"] != null)
                    {
                        decimal.TryParse(dt.Rows[0]["balance"].ToString(), out mybalance);
                        oOutput.Balance = mybalance;
                    }
                    if (dt.Rows[0]["TypeName"] != null)
                    {
                        oOutput.CardType = dt.Rows[0]["TypeName"].ToString();
                    }
                    if (dt.Rows[0]["CellPhone"] != null)
                    {
                        oOutput.CellPhone = dt.Rows[0]["CellPhone"].ToString();
                    }
                    if (dt.Rows[0]["Expenditure"] != null)
                    {
                        decimal.TryParse(dt.Rows[0]["Expenditure"].ToString(), out myExpenditure);
                        oOutput.TotalExpenditure = myExpenditure;
                    }
                    if (dt.Rows[0]["Points"] != null)
                    {
                        int.TryParse(dt.Rows[0]["Points"].ToString(), out mypoint);
                        oOutput.Points = mypoint;
                    }
                    if (dt.Rows[0]["validDate"] != null)
                    {
                        oOutput.validDate = dt.Rows[0]["validDate"].ToString();
                    }
                    if (dt.Rows[0]["LastSaleTime1"] != null)
                    {
                        oOutput.LastSaleTime = dt.Rows[0]["LastSaleTime1"].ToString();
                    }
                    if (dt.Rows[0]["supportSites"] != null)
                    {
                        oOutput.supportSites = dt.Rows[0]["supportSites"].ToString();
                    }
                    if (dt.Rows[0]["uptotime"] != null)
                    {
                        oOutput.uptotime = dt.Rows[0]["uptotime"].ToString();
                    }
                    if (dt.Rows[0]["IsByTime"] != null)
                    {
                        oOutput.IsByTime = int.Parse(dt.Rows[0]["IsByTime"].ToString());
                    }
                    oOutput.FLAG = "0";//请求成功
                    oOutput.MESSAGE = "";
                }
                else
                {
                    CheckIsArrearageHelperDAL.SP_POS_ActiveCard(oInput);//没有账户,则根据车牌号创建账户
                    oOutput.FLAG = "0";//请求成功,但无数据返回
                    oOutput.MESSAGE = "new account";
                }
            }
            catch
            {
                oOutput.FLAG = "-1";
                oOutput.MESSAGE = "expection occurs";
            }
            ret_str = JavaScriptConvert.SerializeObject(oOutput);
            return ret_str;
        }
    }
}
