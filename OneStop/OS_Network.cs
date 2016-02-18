// Decompiled with JetBrains decompiler
// Type: OneStop.OS_Network
// Assembly: OneStop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5BE87A31-83AB-43B7-BB01-CFC02D4F018E
// Assembly location: C:\Users\Garren\Documents\Visual Studio 2013\Projects\OneStop\OneStop\bin\Debug\OneStop.exe

//OMG THANK YOU JETBRAINS FOR SAVING MY STUPID ASS.

using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace OneStop
{
    public class OsNetwork
    {
        public static List<string> GetAdaptersByDescription()
        {
            List<string> list = new List<string>();
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                string name = networkInterface.Name;
                list.Add(networkInterface.Description);
            }
            return list;
        }

        public static List<string> GetAdaptersByName()
        {
            List<string> list = new List<string>();
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
                list.Add(networkInterface.Name);
            return list;
        }

        public static string GetInternalIp()
        {
            string str = string.Empty;
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    foreach (IPAddress ipAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                    {
                        if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                            str = ipAddress.ToString();
                    }
                }
                catch
                {
                    str = "Not Found";
                }
            }
            if (!NetworkInterface.GetIsNetworkAvailable())
                str = "Not Found";
            return str;
        }

        public static string GetExternalIp()
        {
            string str1 = string.Empty;
            string str2;
            try
            {
                str2 = new WebClient().DownloadString("http://icanhazip.com");
            }
            catch
            {
                str2 = "Not Found";
            }
            if (str2 == "")
            {
                try
                {
                    str2 = new WebClient().DownloadString("http://bot.whatismyipaddress.com");
                }
                catch
                {
                    str2 = "Not Found";
                }
            }
            else if (str2.Length > 15)
            {
                try
                {
                    str2 = new WebClient().DownloadString("http://bot.whatismyipaddress.com");
                }
                catch
                {
                    str2 = "Not Found";
                }
            }
            return str2;
        }

        public static string GetCurrentDns()
        {
            string str = string.Empty;
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                IPAddressCollection dnsAddresses = networkInterface.GetIPProperties().DnsAddresses;
                if (dnsAddresses.Count > 0)
                {
                    foreach (IPAddress ipAddress in dnsAddresses)
                        str = str + "," + ipAddress;
                }
            }
            return str;
        }
    }
}
