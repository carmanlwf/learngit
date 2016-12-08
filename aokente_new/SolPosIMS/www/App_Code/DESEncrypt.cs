using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace NJDesEncrypt
{
    /// <summary>
    /// 类名:DESEncrypt 用于DES加解密。
    /// 
    /// </summary>
    public class DESEncrypt
    {

        /**
         * 功能:
         *   用于DES加密字符串。
         * 参数:
         *   strSrc 需要加密的字符串。
         *   strKey 密钥。
         *   strCharEncodingName 字符的编码。
         * 返回值:
         *   解密后的字符串。
         **/
        public static string Encrypt(string strSrc, string strKey)
        {
            return Encrypt(strSrc, strKey, "utf-8");
        }

        /**
         * 功能:
         *   用于DES加密字符串。
         * 参数:
         *   strSrc 需要加密的字符串。
         *   strKey 密钥。
         *   strCharEncodingName 字符的编码。
         * 返回值:
         *   解密后的字符串。
         **/
        public static string Encrypt(string strSrc, string strKey, string strCharEncodingName)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Mode = CipherMode.ECB;
                provider.Padding = PaddingMode.PKCS7;
                provider.Key = Encoding.GetEncoding(strCharEncodingName).GetBytes(strKey);

                MemoryStream stream = new MemoryStream();
                CryptoStream cryptStream = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);

                byte[] bytes = Encoding.GetEncoding(strCharEncodingName).GetBytes(strSrc);
                cryptStream.Write(bytes, 0, bytes.Length);
                cryptStream.FlushFinalBlock();

                byte[] btDes = stream.ToArray();

                string strRet = Convert.ToBase64String(btDes);

                return strRet;
            }
            catch (Exception e)
            {
            }

            return "";

        } // DESEncrypt


        /**
         * 功能:
         *   用于DES解密(默认GB2312)。
         * 参数:
         *   strSrc 需要解密的字符串。
         *   strKey 密钥。
         * 返回值:
         *   解密后的字符串。
         **/
        public static string DeEncrypt(string strSrc, string strKey)
        {
            return DeEncrypt(strSrc, strKey, "utf-8");
        }

        /**
         * 功能:
         *   用于DES解密。
         * 参数:
         *   strSrc 需要解密的字符串。
         *   strKey 密钥。
         *   strCharEncodingName 字符的编码。
         * 返回值:
         *   解密后的字符串。
         **/
        public static string DeEncrypt(string strSrc, string strKey, string strCharEncodingName)
        {

            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Mode = CipherMode.ECB;
                provider.Padding = PaddingMode.PKCS7;
                provider.Key = Encoding.GetEncoding(strCharEncodingName).GetBytes(strKey);

                MemoryStream stream = new MemoryStream();
                CryptoStream cryptStream = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);

                byte[] bytes = Convert.FromBase64String(strSrc);
                //byte[] bytes = Encoding.UTF8.GetBytes(strSrc);
                cryptStream.Write(bytes, 0, bytes.Length);
                cryptStream.FlushFinalBlock();

                byte[] btDes = stream.ToArray();

                string strRet = Encoding.GetEncoding(strCharEncodingName).GetString(btDes);


                return strRet;
            }
            catch (Exception e)
            {
            }

            return "";
        }


    }// class DESEncrypt

}
