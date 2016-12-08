using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.Model.Charge;
using Ims.Pos.Model;
using System.Data;
using Ims.Pos.DAL;
using Newtonsoft.Json;

namespace Ims.Pos.BLL
{
    public class SP_POS_ChargeBLL
    {
        public static string ChargeByCardSnr(input_charge oInput)
        {
            string CardSnr = oInput.CardSnr;
            string ret_str = "";
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
            oOutput.chargeTime = now;
            
            try
            {
                
                oOutput.FLAG = SP_POS_ChargeDAL.SP_POS_ChargeByCardSnr(oInput, now);//充值结果
                DataTable dt = SP_POS_ChargeDAL.GetAccountInfoByCardSnr(CardSnr);
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
                    oOutput.MESSAGE = "";
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
