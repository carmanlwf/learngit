using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

/// <summary>
/// UpLoadAndSaveImage 的摘要说明
/// </summary>
public class UpLoadAndSaveImage
{
    public UpLoadAndSaveImage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data">文件数据</param>
    /// <param name="virPath">图片文件夹</param>
    /// <param name="fext">扩展名</param>
    /// <param name="physicPath">物理路径</param>
    /// <returns></returns>
    public string UpLoadAndSave(byte[] data, ref string virPath, string fext, string physicPath, int targetSizeW, int targetSizeH, string comeFile, string whereFile, string filethree,string filefour, int threeW, int threeH,int fourW,int fourH)
    {
        // 返回文件物理地址，修改虚拟地址 
        if (data == null || virPath == null || fext == null || physicPath == "")
        {
            throw new Exception(" 非法参数");
        }
        string rtnValue = SaveToServer(data, fext, physicPath, data.Length);
        virPath = rtnValue;
        physicPath += rtnValue;
        string pathcopy = physicPath.Replace(comeFile, whereFile);//一次更换文件
        string paththree = physicPath.Replace(comeFile, filethree);//二次更换文件
        string pathfour = physicPath.Replace(comeFile, filefour);//3次更换文件
        byte[] newdata = SmallImageFile(data, targetSizeW, targetSizeH);//缩小图
        byte[] threedata = SmallImageFile(data, threeW, threeH);
        byte[] fourdata = SmallImageFile(data, fourW, fourH);
        SaveToWhere(newdata, fext, pathcopy, newdata.Length);//一次缩小
        SaveToWhere(threedata, fext, paththree, threedata.Length);//二次缩小
        SaveToWhere(fourdata, fext, pathfour, fourdata.Length);//3次缩小
        return physicPath;
    }
    //文件名+后缀
    private string CreateFilePath(string fext)
    {
        string filePath = "";
        Random rd = new Random();
        filePath += DateTime.Now.Year.ToString("0000");
        filePath += DateTime.Now.Month.ToString("00");
        filePath += DateTime.Now.Date.ToString("00");
        filePath += DateTime.Now.Hour.ToString("00");
        filePath += DateTime.Now.Minute.ToString("00");
        filePath += DateTime.Now.Second.ToString("00");
        filePath += DateTime.Now.Millisecond.ToString("00");
        filePath += rd.Next(99).ToString("00");
        filePath += fext;
        return filePath;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="fext">扩展名</param>
    /// <param name="physicPath">物理路径</param>
    /// <param name="fileLen">文件大小</param>
    /// <returns></returns>
    private string SaveToServer(byte[] data, string fext, string physicPath, int fileLen)
    {
        string filePath = CreateFilePath(fext);
        string rtnValue = filePath;
        filePath = filePath.Insert(0, @physicPath);
        if (File.Exists(filePath))
        {
            filePath = CreateFilePath(fext);
            rtnValue = filePath;
        }
        FileStream fs = new FileStream(filePath, FileMode.CreateNew);
        fs.Write(data, 0, fileLen);
        fs.Close();
        return rtnValue;
    }
    private string SaveToWhere(byte[] data, string fext, string physicPath, int fileLen)
    {
        string rtnValue = physicPath;
        if (File.Exists(physicPath))
        {
            physicPath = CreateFilePath(fext);
        }
        FileStream fs = new FileStream(physicPath, FileMode.CreateNew);
        fs.Write(data, 0, fileLen);
        fs.Close();
        return rtnValue;
    }
    /// <summary>
    /// 缩小目标图片大小
    /// </summary>
    /// <param name="data">数据</param>
    /// <param name="targetSizeW">宽</param>
    /// <param name="targetSizeH">高</param>
    /// <returns></returns>
    public static byte[] SmallImageFile(byte[] data, int targetSizeW, int targetSizeH)
    {
        System.Drawing.Image original = System.Drawing.Image.FromStream(new MemoryStream(data));
        int targetH, targetW;
        targetW = targetSizeW;
        targetH = (int)(original.Height * ((float)targetSizeW / (float)original.Width));
        if (targetH > targetSizeH)
        {
            targetH = targetSizeH;
            targetW = (int)(original.Width * ((float)targetSizeH / (float)original.Height));
        }
        if (targetSizeW < (int)original.Width || targetSizeH < (int)original.Height)
        {
            System.Drawing.Image imgPhoto = System.Drawing.Image.FromStream(new MemoryStream(data));
            // 创建一个新的空白画布。缩放后的图像将被画在这画布。     
            Bitmap bmPhoto = new Bitmap(targetW, targetH, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(72, 72);//设置分辨率
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;//消除锯齿
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, targetW, targetH), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel);
            // 保存到内存,然后到一个文件。我们处理所有对象,确保文件不被锁。
            MemoryStream mm = new MemoryStream();
            bmPhoto.Save(mm, System.Drawing.Imaging.ImageFormat.Jpeg);
            original.Dispose();
            imgPhoto.Dispose();
            bmPhoto.Dispose();
            grPhoto.Dispose();
            return mm.GetBuffer();
        }
        else { return data; }
    }
}
