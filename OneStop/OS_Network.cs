//OneStopIT - The Open Source All-In-One tool for technicians.
//Copyright (C) 2016 CollectiveIT.org

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

//Developers: staticextasy, CBRN_IS_FUN (Garren King) - Find us on http://www.reddit.com/r/OneStopIT

//OMG THANK YOU JETBRAINS FOR SAVING MY STUPID ASS - CBRN_IS_FUN

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
