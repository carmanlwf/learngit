using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Drawing;
using Ims.Card.Model;
using Ims.Card.BLL;

public partial class InterFace_PictureBox : System.Web.UI.Page
{
    public class imageByte
    {
        public static string strImage = "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 hlwFynXL+//4c/vly+Lz3POGH6N9fhvVSjdGpTWruj7Tfvm59efLa/vllZLu h9b9tvJ+HtOdwkIZKDVYWp4hZ0pLgssxJWOsdlkNlJp7XmPv+h9j7N+/fduN 4/enZ0qMem+DyWwWr6NUgeKfsSM3eZG2Vp1yL/FAmVxAKaXsvvWX3XTFcZjj UExZvaiYnEdOczgcMcZcJ7ZKynQ631FXP9HA01qRZYnW/a1tlzrdt/bLa/et f3PdOCim1BbKo8PK2KBMKKAs2/b//vvXjbnkSkxJZaPqRSXG4uV0NouXyOl0 NppMRuMJLYgv++vHh9Z0Ouv2B4Rm4+qqVqvGWKZJP6zMGEod/A6ZyRgXQqT0 R+NJ6/729F81Gk/670MKf8u23bi6ql5UAhVI6a/m0a5DRrTT7VEmvlJ22Aj6 7rrsUr7FXddpXtfL8VV/dlPBj5pUeYXy7qa5Ul5u1GvbzOS2LTxfUP4x+nJH 0p4yOa84zk2jbpftyPhNP2btl1daVGxc/b0u4LqO6zp3t83xmGyq/CrlF1eX l/sF6MFwOPpjOvv1X48p2OCjqYjNfadkDj9GkXVZToD2SSkOcsSBUv3Be60W T2xHnK18sXZZvbioDAbD/uC9PxiSUYzQpPnw15ToD3bXofavIrmO89x+8eZe CmuYR1ORJ0s5/BiRadl/CW65bPTbt8f9w83BYBgo1bi6SvSOTM6b1/XmdX34 Meq+9X///rSC5pc6tLafjuPO3lIml+Ws6P1jtLycuL+osiOl3HOw555HWfBB OdPc8/586X55eYFS4/HEdZzlX05GkdDsv78fFBlv3Mi3o5qhf64TD5Sp3edx teWDzEOg1J8vXcsS9UPqnRQhzD1v7nm7/5yUkqrlZdtu1GsXF5UovDt0gZGc gM6b3M4CyhTUee3NPe/xoXVcKkAbe3fPkN++PY7GkygaubioNOq1IxwrhSUH rWClD2U27jvN1Htlo1Dsar+8Dj9GN9eNI/IAWq7c5wctSzTqtUa9JqXff38f DkfDj5HrOlcHWsrRZGJZIs0w8Qg2jlhszNkm2dpl9eqoGs3KmuQWr/06Gk9q l9XjtkR43uLQH7EscXfTvLtpDj9G7x+jg1Z0AqWGw1Fc9QGtlDP3XbKsJGoZ lKPMPa92Wd1RLd+dJXwZTe6ebLXL6tzz+oNh57W3D5Tp1Afy6r7ThHLueUf8 1I59QLTho/vWNzn/8nVyKf3pdPPC49zzRuPJyl4Q2h28/266sm1vnBIqUCsv Hknp9wfvtcuq5i+EFB9Kk/PRePKlI96WfKy/UCal//3pR6CU6zqtu9vdA1y7 rPYH70/PbZPzFcotS0jpm5w3/7kkSAEfOeWVFcWDXDy9p/uPbKzbY4zd3er+ cllmUKYmCvWOePeem/zmurHuWy1LuK6z45CClW/+9vjzjo2VtcsN+yceWvd7 7sXc/adXTHjZthtXx7xV47pOo147dPUhZRmn27nZbIajKKHNeBmGc/hOQo4H B+mmGKCEmYTiZQOWEiqipYQgQAkBSgjKHZRHH4QAFV7HsQFLCcFSQrCUsJQQ LCUEaWApASUEKCFACUG5iyk5B9lQnGzAfUOIKSFA+ZVELH/YMIzMd1Uun321 3oBjuWHH+tsFSWhbixDLEitntmwUdRot23Z+j0AnMLKBkkKHzHt823aJc/7n yyu9xLMylq5Tlr7fee39dH+bzhuArlMeTSb9wdDk/KfPFiSBUtPZrPPac13n p519STrdt+l0NhpPXKec0y5PRycbPK45kfkjKNt29aJCr0T1B+8r75fRC2J2 2a5eVNI5UsJ1HWpaSn+UTgOsXlTubpq//uuRGj3teAmu4jjsswXvWfnu2KDU KgGnE/kPOr0yZZmc31w35p634yKb1/Vvjw/pnG5aTEupFZR0HvO6sdRKFxcV xtj7x8du22/mudyWvfvWJwe3LHFz3dDfWDLGjj6hoMBZTpxQamUsKfvW3Fh+ qbnn7dnpTE8zmX0bPB0S8GU71Khfdd/6g8Fwn5LKdDrrvw/nnmdZlpTSdZxD j/E9Aji26dzATrc39xaMMW/uBUrtcyghNQz1vAU3uQqUZYnGVS3zhP0UIyV0 uIiEjGV/8E49oHbjRYeX3t00o2bivbfB96cfd7fN5MqZ4/GUMbZ+rGF0LC81 D/3y9ww/Rp3X3sVFJTrWevgxenpuZ95R7xQeeIwXodXSDhlL9lVL4dF4QkQu H5jWvK7XatXOay+hmK8/GNJs2QF91Ah6t7ltv7y6rrN8/BWlUPsAnWhAqYWl pOvQx4NHxpJO5t1mLDvdHp2ru1aRafQHw3bn9fRmjMtN4gMVjMYTtr216EHq dN/YWj8rb+5lnkKdaKFEvJeiFZRRZNl9628895FWJje29KLmXNPpTEr/xODS 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";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
            GetCarPicDetail();
    }
    /// <summary>
    /// 获取指定停车记录的车辆照片
    /// </summary>
    public void GetCarPicDetail()
    {
        string transid = "";
        byte[] bpath = Convert.FromBase64String(imageByte.strImage);
        if (!string.IsNullOrEmpty(Request.QueryString["getcode"]))
        {
            transid = Request.QueryString["getcode"].ToString();
            DataTable  dt = POS_TransactionBLL.GetCardInfoByTransId(transid);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["carpicture"] != null)
            {
                string strPic = "";
                strPic = dt.Rows[0]["carpicture"].ToString();
                if (!string.IsNullOrEmpty(strPic))
                {
                    try
                    {
                        string newPicText = HttpContext.Current.Server.UrlDecode(strPic);
                        bpath = Convert.FromBase64String(newPicText);
                    }
                    catch
                    {
                        bpath = Convert.FromBase64String(imageByte.strImage);
                    }
                }
                else
                {
                    bpath = Convert.FromBase64String(imageByte.strImage);
                }
            }
        }
        //BytesToImage(bpath);
        Response.ContentType = "image/jpeg";
        Response.BinaryWrite(bpath);
    }
    /// <summary>
    /// Convert Byte[] to Image
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public Image BytesToImage(byte[] buffer)
    {
        MemoryStream ms = new MemoryStream(buffer);
        Image image = Image.FromStream(ms);
        return image;
    }
}
