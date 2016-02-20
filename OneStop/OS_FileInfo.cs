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

//Code in this fileinfo taken from StackOverflow user Eric J. http://stackoverflow.com/questions/1304/how-to-check-for-file-lock

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OneStop
{
    public partial class OS_FileInfo : Form
    {

        [StructLayout(LayoutKind.Sequential)]
        struct RM_UNIQUE_PROCESS
        {
            public int dwProcessId;
            public System.Runtime.InteropServices.ComTypes.FILETIME ProcessStartTime;
        }

        const int RmRebootReasonNone = 0;
        const int CCH_RM_MAX_APP_NAME = 255;
        const int CCH_RM_MAX_SVC_NAME = 63;

        enum RM_APP_TYPE
        {
            RmUnknownApp = 0,
            RmMainWindow = 1,
            RmOtherWindow = 2,
            RmService = 3,
            RmExplorer = 4,
            RmConsole = 5,
            RmCritical = 1000
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        struct RM_PROCESS_INFO
        {
            public RM_UNIQUE_PROCESS Process;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_APP_NAME + 1)]
            public string strAppName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_SVC_NAME + 1)]
            public string strServiceShortName;

            public RM_APP_TYPE ApplicationType;
            public uint AppStatus;
            public uint TSSessionId;
            [MarshalAs(UnmanagedType.Bool)]
            public bool bRestartable;
        }

        [DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
        static extern int RmRegisterResources(uint pSessionHandle,
                                              UInt32 nFiles,
                                              string[] rgsFilenames,
                                              UInt32 nApplications,
                                              [In] RM_UNIQUE_PROCESS[] rgApplications,
                                              UInt32 nServices,
                                              string[] rgsServiceNames);

        [DllImport("rstrtmgr.dll", CharSet = CharSet.Auto)]
        static extern int RmStartSession(out uint pSessionHandle, int dwSessionFlags, string strSessionKey);

        [DllImport("rstrtmgr.dll")]
        static extern int RmEndSession(uint pSessionHandle);

        [DllImport("rstrtmgr.dll")]
        static extern int RmGetList(uint dwSessionHandle,
                                    out uint pnProcInfoNeeded,
                                    ref uint pnProcInfo,
                                    [In, Out] RM_PROCESS_INFO[] rgAffectedApps,
                                    ref uint lpdwRebootReasons);


        public OS_FileInfo()
        {
            InitializeComponent();
        }

        private void OS_FileInfo_DragDrop(object sender, DragEventArgs e)
        {
            WasDropped(e);
        }



        private void OS_FileInfo_DragOver(object sender, DragEventArgs e)
        {
            WasDragged(e);
        }


        private void txtDataOutput_DragDrop(object sender, DragEventArgs e)
        {
            WasDropped(e);
        }

        private void txtDataOutput_DragOver(object sender, DragEventArgs e)
        {
            WasDragged(e);
        }

        public void Console(string input, int mode)
        {
            //mode = 0 or null -> OSConsole, 1 -> OSConsole plus log, 2-> Log Only
            string logfile = Directory.GetCurrentDirectory() + "\\Logs\\onestoplog.txt";
            string logfiledir = Directory.GetCurrentDirectory() + "\\Logs\\";

            var directoryInfo = new FileInfo(logfiledir).Directory;
            if (directoryInfo != null) directoryInfo.Create();

            if (input == "OS_GPL")
            {
                if (mode == 1 || mode == 0)
                {
                    txtDataOutput.AppendText(@"OneStopIT - The Open Source All-In-One tool for technicians." +
                                            Environment.NewLine +
                                            "Copyright (C)2016 CollectiveIT.org" +
                                            Environment.NewLine +
                                            Environment.NewLine +
                                            "This program is free software: you can redistribute it and/or modify" +
                                            Environment.NewLine +
                                            "it under the terms of the GNU General Public License as published by" +
                                            Environment.NewLine +
                                            "the Free Software Foundation, either version 3 of the License, or" +
                                            Environment.NewLine +
                                            "(at your option) any later version." +
                                            Environment.NewLine +
                                            Environment.NewLine +
                                            "This program is distributed in the hope that it will be useful," +
                                            Environment.NewLine +
                                            "but WITHOUT ANY WARRANTY; without even the implied warranty of" +
                                            Environment.NewLine +
                                            "MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the" +
                                            "GNU General Public License for more details." +
                                            Environment.NewLine +
                                            Environment.NewLine +
                                            "You should have received a copy of the GNU General Public License" +
                                            Environment.NewLine +
                                            "along with this program.  If not, see <http://www.gnu.org/licenses/>." +
                                            Environment.NewLine +
                                            "Developers: staticextasy, CBRN_IS_FUN (Garren King) - Find us on reddit.com/r/OneStopIT" +
                                            Environment.NewLine);
                }
            }

            if (input == "OS_HR" && (mode == 0 || mode == 1))
            {
                txtDataOutput.AppendText(Environment.NewLine + @"===========================================");
            }
            if (input == "OS_BR" && (mode == 0 || mode == 1))
            {
                txtDataOutput.AppendText(Environment.NewLine + Environment.NewLine);
            }
            if ((mode == 0 || mode == 1) &&
                (input.Contains("OS_BR") || input.Contains("OS_GPL") || input.Contains("OS_HR")))
            {
            }
            else
            {
                if (mode == 0 || mode == 1)
                {
                    txtDataOutput.AppendText(Environment.NewLine + input);
                }
            }

            if (input == "OS_GPL")
            {
                if (mode == 1 || mode == 0)
                {

                    try
                    {
                        File.AppendAllText(logfile, @"OneStopIT - The Open Source All-In-One tool for technicians." +
                                                    Environment.NewLine +
                                                    "Copyright (C)2016 CollectiveIT.org" +
                                                    Environment.NewLine +
                                                    Environment.NewLine +
                                                    "This program is free software: you can redistribute it and/or modify" +
                                                    Environment.NewLine +
                                                    "it under the terms of the GNU General Public License as published by" +
                                                    Environment.NewLine +
                                                    "the Free Software Foundation, either version 3 of the License, or" +
                                                    Environment.NewLine +
                                                    "(at your option) any later version." +
                                                    Environment.NewLine +
                                                    Environment.NewLine +
                                                    "This program is distributed in the hope that it will be useful," +
                                                    Environment.NewLine +
                                                    "but WITHOUT ANY WARRANTY; without even the implied warranty of" +
                                                    Environment.NewLine +
                                                    "MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the" +
                                                    "GNU General Public License for more details." +
                                                    Environment.NewLine +
                                                    Environment.NewLine +
                                                    "You should have received a copy of the GNU General Public License" +
                                                    Environment.NewLine +
                                                    "along with this program.  If not, see <http://www.gnu.org/licenses/>." +
                                                    Environment.NewLine +
                                                    "Developers: staticextasy, CBRN_IS_FUN (Garren King) - Find us on reddit.com/r/OneStopIT" +
                                                    Environment.NewLine);

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(@"Problem writing log file" + Environment.NewLine + Environment.NewLine + e);
                    }
                }

            }
            if (input == "OS_HR" && mode == 1 || mode == 2)
            {
                try
                {
                    File.AppendAllText(logfile, Environment.NewLine + @"===========================================");
                }
                catch (Exception e)
                {
                    MessageBox.Show(@"Problem writing log file" + Environment.NewLine + Environment.NewLine + e);
                }
            }
            if (input == "OS_BR" && mode == 1 || mode == 2)
            {
                try
                {
                    File.AppendAllText(logfile, Environment.NewLine + Environment.NewLine);
                }
                catch (Exception e)
                {
                    MessageBox.Show(@"Problem writing log file" + Environment.NewLine + Environment.NewLine + e);
                }
            }
            if (mode == 1 || mode == 2)
            {
                if (input.Contains("OS_BR") || input.Contains("OS_GPL") || input.Contains("OS_HR"))
                {

                }
                else
                {
                    try
                    {
                        File.AppendAllText(logfile, Environment.NewLine + input);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(@"Problem writing log file" + Environment.NewLine + Environment.NewLine + e);
                    }
                }
            }
        }
        private void WasDragged(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void WasDropped(DragEventArgs e)
        {
            Console("OS_BR",2);
            Console("OS_HR", 2);
            Console("User initated action - Dragged Files into OneStop File Info at: " + DateTime.Now.ToString(),2);
            
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            int c = files.Length;
            Console("OS_HR", 1);
            Console("Getting info on " + Convert.ToString(c) + " files", 1);
            Console("OS_HR", 1);
            foreach (string file in files)
            {
                try
                {
                    var fi = new System.IO.FileInfo(file);

                    txtTargetFile.Items.Add(fi.FullName);


                    string readonlystatus = "";
                    readonlystatus = fi.IsReadOnly ? "File is read only" : "File is not read only";

                    Console(fi.Name, 1);
                    Console("Attributes: " + fi.Attributes, 1);
                    Console("Creation Time: " + fi.CreationTime + " (" + fi.CreationTimeUtc + " UTC)", 1);
                    //OSConsole("UTC Creation Time: " +fi.CreationTimeUtc);
                    Console("Directory: " + fi.DirectoryName, 1);
                    Console("Last Access: " + fi.LastAccessTime + " (" + fi.LastAccessTimeUtc + " UTC)", 1);
                    Console("Last Write: " + fi.LastWriteTime + " (" + fi.LastWriteTimeUtc + " UTC)", 1);
                    Console("Read Only: " + readonlystatus, 1);
                    Console("Size in Bytes: " + fi.Length, 1);
                    Console("OS_BR", 1);
                    Console("Attempting to Determine if File is Locked...", 1);
                    
                    StringBuilder builder = new StringBuilder();
                    foreach (var process in WhoIsLocking(fi.FullName))
                    {
                        builder.Append(process).Append(", ");
                    }
                    string lockedresult = builder.ToString();
                    Console(string.IsNullOrEmpty(lockedresult) ? "No Locks could be found by this program" : "Locked by: " + lockedresult, 1);
                    Console("OS_BR", 1);
                    string os_md5hash = MD5Hash(fi.FullName);
                    if (!String.IsNullOrEmpty(os_md5hash))
                    {
                        Console("MD5 Hash: " + MD5Hash(fi.FullName), 1);
                    }

                    Console("OS_BR", 1);
                    Console("Attempting to get FileVersionInfo - Only shows non-null values", 1);
                    Console("OS_BR", 1);
                    FileVersionInfo.GetVersionInfo(fi.FullName);
                    FileVersionInfo currentFileVersionInfo = FileVersionInfo.GetVersionInfo(fi.FullName);
                    if (!string.IsNullOrEmpty(currentFileVersionInfo.CompanyName))
                    {
                        Console("Company Name: " + currentFileVersionInfo.CompanyName, 1);
                    }
                  
                    if (!string.IsNullOrEmpty(currentFileVersionInfo.Comments)) 
                    {
                        Console("Comments: " + currentFileVersionInfo.Comments, 1);
                    }

                    if (!string.IsNullOrEmpty(currentFileVersionInfo.FileBuildPart.ToString()) &&
                        currentFileVersionInfo.FileBuildPart != 0)
                    {
                        Console("Build Number: " + Convert.ToString(currentFileVersionInfo.FileBuildPart), 1);
                    }

                    if (!string.IsNullOrEmpty(currentFileVersionInfo.FileDescription))
                    {
                        Console("Description: " + currentFileVersionInfo.FileDescription, 1);
                    }

                    if (!string.IsNullOrEmpty(currentFileVersionInfo.FileVersion))
                    {
                        Console("Version: " + currentFileVersionInfo.FileVersion, 1);
                    }

                    if (!string.IsNullOrEmpty(currentFileVersionInfo.InternalName))
                    {
                        Console("Internal Name: " + currentFileVersionInfo.InternalName, 1);
                    }

                    if (!string.IsNullOrEmpty(currentFileVersionInfo.IsDebug.ToString()) &&
                        currentFileVersionInfo.IsDebug)
                    {
                        Console("Contains Debugging: " + Convert.ToString(currentFileVersionInfo.IsDebug), 1);
                    }
                    if (!string.IsNullOrEmpty(currentFileVersionInfo.IsPatched.ToString()) &&
                        currentFileVersionInfo.IsPatched)
                    {
                        Console("Marked as Patched: " + Convert.ToString(currentFileVersionInfo.IsPatched), 1);
                    }

                    if (!string.IsNullOrEmpty(currentFileVersionInfo.IsPreRelease.ToString()) &&
                        currentFileVersionInfo.IsPreRelease)
                    {
                        Console("Marked as Pre-Release: " + Convert.ToString(currentFileVersionInfo.IsPreRelease), 1);
                    }

                    if (!string.IsNullOrEmpty(currentFileVersionInfo.IsPrivateBuild.ToString()) &&
                        currentFileVersionInfo.IsPrivateBuild)
                    {
                        Console("Marked as Private Build: " + Convert.ToString(currentFileVersionInfo.IsPreRelease), 1);
                    }

                    if (!string.IsNullOrEmpty(currentFileVersionInfo.IsSpecialBuild.ToString()) &&
                        currentFileVersionInfo.IsSpecialBuild)
                    {
                        Console("Marked as Special Build: " + Convert.ToString(currentFileVersionInfo.IsSpecialBuild), 1);
                    }
                    if (!string.IsNullOrEmpty(currentFileVersionInfo.Language))
                    {
                        Console("Lanugage: " + currentFileVersionInfo.Language, 1);
                    }
                    if (!string.IsNullOrEmpty(currentFileVersionInfo.LegalCopyright))
                    {
                        Console("Copywrite Notice: " + currentFileVersionInfo.LegalCopyright, 1);
                    }
                    if (!string.IsNullOrEmpty(currentFileVersionInfo.ProductName))
                    {
                        Console("Product Distributed With: " + currentFileVersionInfo.ProductName, 1);
                    }
                    if (!string.IsNullOrEmpty(currentFileVersionInfo.ProductBuildPart.ToString()) &&
                        currentFileVersionInfo.ProductBuildPart != 0)
                    {
                        Console("Product Distributed With Build Number: " + Convert.ToString(currentFileVersionInfo.ProductBuildPart), 1);
                    }
                    if (!string.IsNullOrEmpty(currentFileVersionInfo.SpecialBuild))
                    {
                        Console("Special Build Info: " + currentFileVersionInfo.SpecialBuild, 1);
                    }
                    if (!string.IsNullOrEmpty(currentFileVersionInfo.ProductName))
                    {
                        Console("Private Build Info: " + currentFileVersionInfo.PrivateBuild, 1);
                    }

                    Console(alreadySigned(fi.FullName), 1);


                }
                catch (System.IO.FileNotFoundException fileNotFoundException)
                {
                    Console("File Not found or Error: " + fileNotFoundException, 1);
                }
                Console("OS_HR", 1);

            }
        }
        
        
        
        
        
        
        
        private string alreadySigned(string file)
        {
            //Stackoverflow user ksun - http://stackoverflow.com/questions/15939073/determining-if-a-file-has-a-digital-signature-in-c-sharp-without-actually-verify
            string result = "";
            string output = "";

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.FileName = "signTool.exe";
                startInfo.Arguments = "verify /v " + file;
                startInfo.UseShellExecute = false;

                Process process = new Process();
                process.StartInfo = startInfo;
                process.EnableRaisingEvents = true;
                
                process.Start();
                process.WaitForExit();
                output = process.StandardOutput.ReadToEnd();
            }
            catch (Exception e)
            {
                result = "Error when checking signed status: " + e;
            }
           

            result = output.Contains("Signing Certificate Chain:") ? "File is signed" : "File is not signed";
            return result;
        }

        public string MD5Hash(string fileName)
        {
            //Stackoverflow user Shankar Damodaran - http://stackoverflow.com/questions/16318087/calculate-the-hash-of-the-contents-of-a-file-in-c
            StringBuilder sb = new StringBuilder();

            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                
            }
            catch (UnauthorizedAccessException ex)
            {
                Console("MD5 Exception: Unable to Access (In Use, Read-only, etc.)", 1);
                return null;
            }
            catch (FileNotFoundException ex)
            {
                Console("MD5 Exception: File not found or was moved", 1);
                return null;
            }
            catch (IOException ex)
            {
                Console("MD5 Exception: Misc I/O", 1);
                return null;
            }
            catch (Exception e)
            {
                Console("MD5 Exception: Misc", 1);
                return null;
            }
            return sb.ToString();
        }

        /// <summary>
        /// Find out what process(es) have a lock on the specified file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <returns>Processes locking the file</returns>
        /// <remarks>See also:
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa373661(v=vs.85).aspx
        /// http://wyupdate.googlecode.com/svn-history/r401/trunk/frmFilesInUse.cs (no copyright in code at time of viewing)
        /// 
        /// </remarks>
        public List<Process> WhoIsLocking(string path)
        {
            uint handle;
            string key = Guid.NewGuid().ToString();
            List<Process> processes = new List<Process>();

            int res = RmStartSession(out handle, 0, key);

            if (res != 0) { 
                throw new Exception("Could not begin restart session.  Unable to determine file locker.");
            }
            try
            {
                const int ERROR_MORE_DATA = 234;
                uint pnProcInfoNeeded = 0,
                     pnProcInfo = 0,
                     lpdwRebootReasons = RmRebootReasonNone;

                string[] resources = new string[] { path }; // Just checking on one resource.

                res = RmRegisterResources(handle, (uint)resources.Length, resources, 0, null, 0, null);

                if (res != 0)
                    throw new Exception("Could not register resource.");

                //Note: there's a race condition here -- the first call to RmGetList() returns
                //      the total number of process. However, when we call RmGetList() again to get
                //      the actual processes this number may have increased.
                res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, null, ref lpdwRebootReasons);

                if (res == ERROR_MORE_DATA)
                {
                    // Create an array to store the process results
                    RM_PROCESS_INFO[] processInfo = new RM_PROCESS_INFO[pnProcInfoNeeded];
                    pnProcInfo = pnProcInfoNeeded;

                    // Get the list
                    res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, processInfo, ref lpdwRebootReasons);

                    if (res == 0)
                    {
                        processes = new List<Process>((int)pnProcInfo);

                        // Enumerate all of the results and add them to the 
                        // list to be returned
                        for (int i = 0; i < pnProcInfo; i++)
                        {
                            try
                            {
                                processes.Add(Process.GetProcessById(processInfo[i].Process.dwProcessId));
                            }
                            // catch the error -- in case the process is no longer running
                            catch (ArgumentException) { }
                        }
                    }
                    else
                        throw new Exception("Could not list processes locking resource.");
                }
                else if (res != 0)
                    throw new Exception("Could not list processes locking resource. Failed to get size of result.");
            }
            finally
            {
                RmEndSession(handle);
            }

            return processes;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
