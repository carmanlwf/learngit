using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace VipposRegDLL
{
    public class RegKey
    {
        public static string mySn = "6FDC84F9131DD58736EE532FCD44346F";//服务编号6FDC84F9131DD58736EE532FCD44346F

        public int[] intNumber = new int[25];//用于存机器码的Ascii值
        public char[] Charcode = new char[25];//存储机器码字


        public int[] intCode = new int[127];//用于存密钥
        public string CreateCode()
        {
            RegDLL rd = new RegDLL();
            string temp = rd.DiskID;//获得硬盘序列号
            return GetMd5(temp);
        }
        public string GetMd5(object text)
        {
            string path = text.ToString();

            MD5CryptoServiceProvider MD5Pro = new MD5CryptoServiceProvider();
            Byte[] buffer = Encoding.GetEncoding("utf-8").GetBytes(text.ToString());
            Byte[] byteResult = MD5Pro.ComputeHash(buffer);

            string md5result = BitConverter.ToString(byteResult).Replace("-", "");
            return md5result;
        }

        public void setIntCode()//给数组赋值个小于的随机数
        {
            //Random ra = new Random();
            //for (int i = 1; i < intCode.Length;i++ )
            //{
            //    intCode[i] = ra.Next(0, 9);
            //}
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i + 3 > 9 ? 0 : i + 3;
            }
        }
        //生成注册码
        public string GetCode(string code)
        {
            if (code != "")
            {
                return GetMd5(code);
            }
            else
            {
                return "";
            }
        }
 
    }
}
