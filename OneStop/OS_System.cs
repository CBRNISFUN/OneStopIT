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

using System;
using System.ComponentModel;
using System.IO;
using System.Management;
using System.Security.Principal;
using System.Windows.Forms;

namespace OneStop
{
    class OsSystem
    {
        //The purpose of this class is to store all actions that involve the system, such as 
        //getting and storing WMI data or other non-registry changes.
        


        public static string GetStartupMode()
        {
            //reads systeminformation.bootmode to get current settings in plain english.
            string strCurrentModeDesc = "";
            string strBootMode = SystemInformation.BootMode.ToString();

            if(strBootMode=="FailSafe")
            {
                strCurrentModeDesc = "Safe (No Networking)";
            }
            else if (strBootMode == "FailSafeWithNetwork")
            {
                strCurrentModeDesc = "Safe (With Networking)";
            }
            else if (strBootMode == "Normal")
            {
                strCurrentModeDesc = "Normal";
            }
            else
            {
                strCurrentModeDesc = "Unknown";
            }

            return strCurrentModeDesc;
        }

        public static bool GetElevatedStatus()
        {
            bool isElevated;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            return isElevated;
        }
        public static string ComputerName()
        {
            return Environment.MachineName;
        }
        public static string AntivirusInstalled()
        {

            string strStatus = String.Empty;
            try
            {
                string wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
                ManagementObjectCollection instances = searcher.Get();
                strStatus = instances.Count.ToString();
            }

            catch (Exception e)
            {
                strStatus = "No Data";
            }
            
            try
            {
                string wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter2";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
                ManagementObjectCollection instances = searcher.Get();
                strStatus = instances.Count.ToString();
            }

            catch (Exception e)
            {
                strStatus = "No Data";
            }

            return strStatus;
        }
        public void CreateRestorePoint(string description)
        {

            try
            {
                ManagementClass classInstance =
                    new ManagementClass("root\\DEFAULT",
                    "SystemRestore", null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams =
                    classInstance.GetMethodParameters("CreateRestorePoint");

                // Add the input parameters.
                inParams["Description"] = description;
                inParams["EventType"] = 100; // 100 -BeginSystemChange value
                inParams["RestorePointType"] = 0; // 0 - Application install restore point type

                // Execute the method and obtain the return values.
                ManagementBaseObject outParams =
                    classInstance.InvokeMethod("CreateRestorePoint", inParams, null);

                // Custom code to throw the Win32 exception for information related to the error code
                int success = Convert.ToInt32(outParams["ReturnValue"]);
                if (success != 0)
                {
                    throw new Win32Exception(success);
                }
                // List outParams
                Console.WriteLine("Out parameters:");
                Console.WriteLine("ReturnValue: " + outParams["ReturnValue"]);
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }

        }
        public static string GetCDriveSpace()
        {
            string result = "err.";
            DriveInfo driveInfo = new DriveInfo(@"C:");
            long freeSpaceB = driveInfo.AvailableFreeSpace;
            long freeSpaceKb = freeSpaceB / 1024;
            long freeSpaceMb = freeSpaceKb / 1024;
            long freeSpaceGb = freeSpaceMb / 1024;
            result = Convert.ToString(freeSpaceGb) + " GB (" + Convert.ToString(freeSpaceMb) + " MB)";
            return result;
        }

        public static string GetAnyDriveSpace(string driveToCheck)
        {
            //expects @"DRIVELETTER:"
            string result = "err.";
            DriveInfo driveInfo = new DriveInfo(driveToCheck);
            long freeSpaceB = driveInfo.AvailableFreeSpace;
            long freeSpaceKb = freeSpaceB / 1024;
            long freeSpaceMb = freeSpaceKb / 1024;
            long freeSpaceGb = freeSpaceMb / 1024;
            result = Convert.ToString(freeSpaceGb) + " GB (" + Convert.ToString(freeSpaceMb) + " MB)";
            return result;
        }

        public static string GetOsFriendlyName()
        {
            string result = string.Empty;
            string query = "SELECT Caption FROM Win32_OperatingSystem";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }

        public static string GetInstalledMemory()
        {
            string result = string.Empty;
            string query = "SELECT MaxCapacity FROM Win32_PhysicalMemoryArray";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject wniPart in searcher.Get())
            {
                UInt32 sizeinKb = Convert.ToUInt32(wniPart.Properties["MaxCapacity"].Value);
                UInt32 sizeinMb = sizeinKb / 1024;
                UInt32 sizeinGb = sizeinMb / 1024;
                result = sizeinGb + " GB (" + sizeinMb + " MB)";
                //OSConsole.WriteLine("Size in KB: {0}, Size in MB: {1}, Size in GB: {2}", SizeinKB, SizeinMB, SizeinGB);
            }
            return result;

        }

        public static string GetMachineName()
        {
            string result = Environment.MachineName;
            return result;
        }
        
        public static string GetArch()
        {
            string result = " (Unknown Arch.)";
            if (Convert.ToString(IntPtr.Size) == "4") { result = " (32Bit)"; }
            if (Convert.ToString(IntPtr.Size) == "8") { result = " (64Bit)"; }
            return result;
        }


    }
}
