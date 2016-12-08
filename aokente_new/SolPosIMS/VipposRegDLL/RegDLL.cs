using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Management;

namespace VipposRegDLL
{
    public class RegDLL
    {
     public string CpuID; //CPU序列号   
     public string MacAddress; //网卡地址   
     public string DiskID; //硬盘序列号   
     public string MotherBoardID; //主板序列号   
     public string IpAddress; //IP地址   
     public string LoginUserName; //系统登录名   
     public string ComputerName; //计算机名称   
     public string SystemType; //操作系统   
     public string TotalPhysicalMemory;//内存大小，单位：M    
     private static RegDLL _instance;
     public static RegDLL Instance()  
    {  
        if (_instance == null)
            _instance = new RegDLL();  
        return _instance;  
    }  
    /// <summary>   
    /// 构造函数   
    /// </summary>   
     public RegDLL()  
    {  
        CpuID = GetCpuID();  
        MacAddress = GetMacAddress();  
        DiskID = GetDiskID();  
        MotherBoardID = GetMotherBoardSerialNumber();  
        IpAddress = GetIPAddress();  
        LoginUserName = GetUserName();  
        SystemType = GetSystemType();  
        TotalPhysicalMemory = GetTotalPhysicalMemory();  
        ComputerName = GetComputerName();  
    }  
    /// <summary>   
    /// 获取cpu序列号   
    /// </summary>   
    /// <returns></returns>   
    private string GetCpuID()  
    {  
        try  
        {  
            //获取CPU序列号代码    
            string cpuInfo = "";//cpu序列号    
            ManagementClass mc = new ManagementClass("Win32_Processor");  
            ManagementObjectCollection moc = mc.GetInstances();  
            foreach (ManagementObject mo in moc)  
            {  
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();  
            }  
            moc = null;  
            mc = null;  
            return cpuInfo;  
        }  
        catch  
        {  
            return "unknow";  
        }  
    }  
    /// <summary>   
    /// 获取网卡硬件地址    
    /// </summary>   
    /// <returns></returns>   
    private string GetMacAddress()  
    {  
        try  
        {  
           //获取网卡硬件地址    
            string mac = "";  
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");  
            ManagementObjectCollection moc = mc.GetInstances();  
            foreach (ManagementObject mo in moc)  
            {  
                if ((bool)mo["IPEnabled"] == true)  
                {  
                    mac = mo["MacAddress"].ToString();  
                    break;  
                }  
            }  
            moc = null;  
            mc = null;  
            return mac;  
        }  
        catch  
        {  
            return "unknow";  
        }  
    }  
    /// <summary>   
    /// 获取IP地址   
    /// </summary>   
    /// <returns></returns>   
    private string GetIPAddress()  
    {  
        try  
        {  
            //获取IP地址    
            string st = "";  
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");  
            ManagementObjectCollection moc = mc.GetInstances();  
           foreach (ManagementObject mo in moc)  
            {  
                if ((bool)mo["IPEnabled"] == true)  
                {  
                    //st=mo["IpAddress"].ToString();    
                    System.Array ar;  
                    ar = (System.Array)(mo.Properties["IpAddress"].Value);  
                    st = ar.GetValue(0).ToString();  
                    break;  
                }  
            }  
            moc = null;  
            mc = null;  
            return st;  
        }  
        catch  
        {  
            return "unknow";  
        }  
    }  
  
    /// <summary>   
    /// 获取主板序号   
    /// </summary>   
    /// <returns></returns>   
    private string GetMotherBoardSerialNumber()  
    {  
        try  
        {  
            //获取主板序号代码    
            string motherbordInfo = "";//主板序列号    
            ManagementClass mc = new ManagementClass("WIN32_BaseBoard");  
            ManagementObjectCollection moc = mc.GetInstances();  
            foreach (ManagementObject mo in moc)  
            {  
                motherbordInfo = mo.Properties["SerialNumber"].Value.ToString();  
            }  
            moc = null;  
            mc = null;  
            return motherbordInfo;  
        }  
        catch  
        {  
            return "unknow";  
        }  
    }  
  
    /// <summary>   
    /// 获取硬盘ID    
    /// </summary>   
    /// <returns></returns>   
    private string GetDiskID()  
    {  
        try  
        {  
            //获取硬盘ID    
            String HDid = "";  
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");  
            ManagementObjectCollection moc = mc.GetInstances();  
            foreach (ManagementObject mo in moc)  
            {  
                HDid = (string)mo.Properties["Model"].Value;  
            }  
            moc = null;  
            mc = null;  
            return HDid;  
        }  
        catch  
        {  
            return "unknow";  
        }  
   }  
  
    /// <summary>    
    /// 操作系统的登录用户名    
    /// </summary>    
    /// <returns></returns>    
    private string GetUserName()  
    {  
        try  
        {  
            string st = "";  
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");  
            ManagementObjectCollection moc = mc.GetInstances();  
            foreach (ManagementObject mo in moc)  
            {  
                st = mo["UserName"].ToString();  
            }  
            moc = null;  
            mc = null;  
            return st;  
        }  
        catch  
        {  
           return "unknow";  
        }  
    }  
  
  
    /// <summary>    
    /// PC类型    
    /// </summary>    
    /// <returns></returns>    
    private string GetSystemType()  
    {  
        try  
        {  
            string st = "";  
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");  
            ManagementObjectCollection moc = mc.GetInstances();  
            foreach (ManagementObject mo in moc)  
            {  
                st = mo["SystemType"].ToString();  
            }  
            moc = null;  
            mc = null;  
            return st;  
        }  
        catch  
        {  
            return "unknow";  
        }  
    }  
  
    /// <summary>    
    /// 物理内存    
    /// </summary>    
    /// <returns></returns>    
    private string GetTotalPhysicalMemory()  
    {  
        try  
        {  
            string st = "";  
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");  
            ManagementObjectCollection moc = mc.GetInstances();  
            foreach (ManagementObject mo in moc)  
            {  
               st = mo["TotalPhysicalMemory"].ToString();  
            }  
            moc = null;  
            mc = null;  
            return st;  
        }  
        catch  
        {  
            return "unknow";  
        }  
    }  
    /// <summary>    
    /// 电脑名称   
    /// </summary>    
    /// <returns></returns>    
    private string GetComputerName()  
    {  
        try  
        {  
            return System.Environment.GetEnvironmentVariable("ComputerName");  
        }  
        catch  
        {  
            return "unknow";  
        }  
    }  
    }
}