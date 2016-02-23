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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using OneStop.Properties;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace OneStop
{
    public class OsMain : Form
    {
        public bool BoolLocalDir;
        public bool BoolPrevDir;
        public bool BoolRootDir;
        public bool BoolSearchedDir;

        public string GString = "GodMode.{ED7BA470-8E54-465E-825C-99712043E01C}";
        public bool BoolAdminStatus;
        public int intCMDCommandMode = 3;
        public int intGPLMode = 3;
        public int intProgramOpendMode = 3;
        public int intRegistyMode = 3;
        public int intStartupMode = 3;
        public int intSysinfoMode = 3;
        public int intVerboseErrorMode = 3;
        public int intWebsiteMode = 3;



        public string StrTronPath = "";
        public TextBox tb_Console;
        private ToolStripMenuItem oneStopToolGetFileInfoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem testBrowserToolStripMenuItem;
        private ToolStripMenuItem oneStopInternalToolStripMenuItem;
        private ToolStripMenuItem launchPortableBrowsersetInConfigToolStripMenuItem;
        private ToolStripMenuItem forceLogoffToolStripMenuItem;
        private ToolStripMenuItem connectivityToDefaultGatewayToolStripMenuItem;
        private Button button6;
        private Button button5;
        private LinkLabel linkLabel2;
        private TabControl tabControl1;
        private TabPage tpSystemReport;
        private TabPage tpNetwork;
        private TextBox netBox;
        private Button clearSslBTN;
        private Button setGoogleDnsBTN;
        private Button winsockRepBTN;
        private Button clearStaticBTN;
        private Button dnsFlushBTN;
        private Button releaseRenewBTN;
        private ComboBox netCombo;
        private Button button7;
        private Label label10;
        private GroupBox groupBox3;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label11;
        private TextBox hostNameTextB;
        private Label label12;
        private TextBox textBox8;
        private Label label13;
        private TextBox textBox9;
        private Label label14;
        private TextBox textBox10;
        private Label label15;
        private TextBox textBox11;
        private Label label16;
        private TextBox textBox12;
        private Label label17;
        private TextBox textBox13;
        private Label label18;
        private TextBox pubIPTextB;
        private TabPage tpServers;
        private GroupBox groupBox1;
        private GroupBox mailGroupBox;
        private Button button2;
        private Button button4;
        private Button button1;
        private ComboBox comboBox2;
        private Button button3;
        private ComboBox comboBox1;
        private TextBox textBox7;
        private TextBox textBox6;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox textBox5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private TextBox textBox1;
        private Button button10;
        private Button button11;
        private Button button9;
        private Button button8;
        private PictureBox pictureBox1;
        private TabPage tpIntegration;
        private TabPage tpLogging;
        private GroupBox groupBox9;
        private CheckBox cbSysInfoLog;
        private CheckBox cbSysinfoConsole;
        private GroupBox groupBox10;
        private CheckBox cbOpenedLog;
        private CheckBox cbOpenedConsole;
        private GroupBox groupBox6;
        private CheckBox cbWebsitesLog;
        private CheckBox cbWebsitesConsole;
        private GroupBox groupBox5;
        private CheckBox cbRegistryLog;
        private CheckBox cbRegistryConsole;
        private GroupBox groupBox7;
        private CheckBox cbGPLNoticeLog;
        private CheckBox cbGPLConsole;
        private GroupBox groupBox8;
        private CheckBox cbOSStartLog;
        private CheckBox cbOSStartConsole;
        private GroupBox groupBox4;
        private CheckBox cbVerboseErrorLog;
        private CheckBox cbVerboseErrorConsole;
        private GroupBox groupBox2;
        private CheckBox cbCMDLog;
        private CheckBox cbCMDConsole;
        private Button btnSaveLoggingStatus;
        private GroupBox groupBox11;
        private CheckBox checkBox2;
        private Button button12;
        private CheckBox checkBox1;
        private Label label22;
        private TextBox textBox17;
        private Label label23;
        private TextBox textBox18;
        private GroupBox groupBox13;
        private GroupBox groupBox12;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private Label label19;
        private Button button14;
        private TextBox textBox14;
        private Button button13;
        private GroupBox groupBox14;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private ToolStripLabel lblBootStatus;
        private ToolStripLabel lblTronStatus;
        public string StrTronStatus = "";

        private void OS_Main_Load(object sender, EventArgs e)
        {
            #region Startup

            InitLoggingSettings();
            BoolLocalDir = false;
            BoolRootDir = false;
            BoolPrevDir = false;
            BoolSearchedDir = false;

            OSConsole("OS_HR", intStartupMode);
            OSConsole("Begin  ONESTOP STARTUP", intStartupMode);
            OSConsole("OS_HR", intStartupMode);
            OSConsole("OS_BR", intStartupMode);
            OSConsole("OS_GPL",intStartupMode);

            OSConsole("Onestop begain initial startup at: " + DateTime.Now.ToString(), intStartupMode);


            OSConsole("OS_HR", intStartupMode);
            OSConsole("Loading Settings...", intStartupMode);
            OSConsole("OS_BR", intStartupMode);
            // Load Settings
            Settings.Default.Reload();

            //Tron not found by default
            TronDisable("Not Initialized - ");

            OSConsole("Searching for Tron.bat", intStartupMode);
            //Determine if Tron is located on load.
            var strFileName = "Tron.bat";
            var strCurDir = Directory.GetCurrentDirectory();
            var strFilePaths = Directory.GetFiles(strCurDir);

            if (File.Exists(strCurDir + "\\Tron\\" + strFileName))
            {
                //Tron Was Found in Current Directory, enable all of the disabled functions (ConfigDump Button, 
                TronEnable("Tron Found (OneStop\\Tron) - ", strCurDir + "\\" + strFileName);
                BoolLocalDir = false;
                BoolRootDir = true;
                BoolPrevDir = false;
                BoolSearchedDir = false;

                OSConsole("Tron.bat Found in Local Directory", intStartupMode);

            }
            else if (File.Exists(strCurDir + "\\" + strFileName))
            {
                //Tron Was Found in Current Directory, enable all of the disabled functions (ConfigDump Button, 
                TronEnable("Tron Found (Current) - ", strCurDir + "\\" + strFileName);
                BoolLocalDir = true;
                BoolRootDir = false;
                BoolPrevDir = false;
                BoolSearchedDir = false;
                OSConsole("Tron.bat Found in Local Directory Root", intStartupMode);
            }
            else if (Settings.Default.str_LastTronDirectory != null)
            {
                //We didn't find Tron in the Current directory, but we can look in the stored location of where it was last time
                if (File.Exists(Settings.Default.str_LastTronDirectory + "\\" + strFileName))
                {
                    //We've Found Tron in Previous Directory, enable all the disabled functions
                    TronEnable("Tron Found (Previous) - ", Settings.Default.str_LastTronDirectory + "\\" + strFileName);
                    BoolLocalDir = false;
                    BoolRootDir = false;
                    BoolPrevDir = true;
                    BoolSearchedDir = false;
                    OSConsole("Tron.bat Found in previously used location", intStartupMode);
                }
                else
                {
                    //We didn't find Tron anywhere. 
                    TronDisable("Tron Not Found - ");
                    BoolLocalDir = false;
                    BoolRootDir = false;
                    BoolPrevDir = false;
                    BoolSearchedDir = false;
                    OSConsole("Tron.bat not found", intStartupMode);

                }
            }
            else
            {
                //We didn't find Tron Anywhere.
                TronDisable("Tron Not Found - ");
                BoolLocalDir = false;
                BoolRootDir = false;
                BoolPrevDir = false;
                BoolSearchedDir = false;
                OSConsole("Tron.bat not found", intStartupMode);
            }

            //Determine if We are Administrators.
            var strAdminStatus = "";
            
            try
            {
                var isElevated = OsSystem.GetElevatedStatus();

                if (isElevated)
                {
                    BoolAdminStatus = true;
                    OSConsole("OneStop is running as Administrator", intStartupMode);
                }
                if (!isElevated)
                {
                    
                    BoolAdminStatus = false;
                    OSConsole("OS_BR", 0);
                    OSConsole("ONE STOP IS NOT RUNNING AS ADMINISTRATOR - SOME FUNCTIONALITY, INCLUDING TRON CANNOT RUN", intStartupMode);
                }
            }
            catch (Exception exception)
            {
                OSConsole("Exeption while checking administrator status" + exception, intVerboseErrorMode);
            }


            //Set all labels with current info
            lblAdminStatus.Text = StrTronStatus + strAdminStatus;
            _lblInfoFreeC.Text = OsSystem.GetCDriveSpace();
            _lblInfoOs.Text = OsSystem.GetOsFriendlyName() + OsSystem.GetArch();
            _lblInfoRam.Text = OsSystem.GetInstalledMemory();
            _lblInfoComputerName.Text = OsSystem.GetMachineName();
            _lblInfoExternalIp.Text = "";
            _lnkInfoInternalIp.Text = "";
            _lnkInfoGateway.Text = "";
            _lnkInfoPrimDns.Text = "";
            _lblInfoAdapterDesc.Text = "";
            OSConsole("Getting Current Stystem Status", intSysinfoMode);
            OSConsole("C Drive Space: " + OsSystem.GetCDriveSpace(), intSysinfoMode);
            OSConsole("OS Friendly Name / Arch: "  + OsSystem.GetOsFriendlyName() + OsSystem.GetArch(), intSysinfoMode);
            OSConsole("Installed Memory: " + OsSystem.GetInstalledMemory(), intSysinfoMode);
            OSConsole("Machine Name: " + OsSystem.GetMachineName(), intSysinfoMode);
            OSConsole("OS_HR", 0);
            
            //Network Adapters
            OSConsole("Getting Network Adapters", intSysinfoMode);
            var adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var adapter in adapters)
            {
                _ddlInfoNetworkAdapters.Items.Add(adapter.Name);
                OSConsole("Adapter Found" + adapter.Name + " - " + adapter.Description, intSysinfoMode);
            }

            //Load Quick Launch Menu

            OSConsole("Loading Quick Launch Menu Settings", intStartupMode);
            LoadMenuatStart();

            string strCurrentDirectory = Directory.GetCurrentDirectory();
            string strScriptsDirectory = strCurrentDirectory + "\\Scripts";
            string strDocsDirectory = strCurrentDirectory + "\\Documents";

            //enumerate scripts Quick Launch
            EnumerateScripts(strScriptsDirectory);

            //Enumerate Docs Quick Launch
            EnumerateDocs(strDocsDirectory);

            OSConsole("Loading Customization Settings", intStartupMode);
            //Load Settings Panel
            LoadShopSettings();

            //Load Tron Flags
            OSConsole("Loading Previous Configuration Settings", intStartupMode);
            PopulateTronCBs();
            OSConsole("OS_HR", intStartupMode);
            OSConsole("END ONESTOP STARTUP", intStartupMode);
            OSConsole("OS_HR", intStartupMode);

            OSConsole("Onestop completed initial startup at: " + DateTime.Now.ToString(), intStartupMode);
            #endregion
            
            //Load status with current results
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            string bootstatusout = "";
            string tronstatusout = "";
            string adminerrorstatusout = "";

            lblAdminStatus.ForeColor = System.Drawing.Color.Green;
            lblBootStatus.ForeColor = System.Drawing.Color.Green;
            lblTronStatus.ForeColor = System.Drawing.Color.Green;

            bool boolBootErrorStatus = false;
            bool boolTronErrorStatus = false;
            bool boolAdminErrorStatus = false;


            if (BoolAdminStatus)
            {
                adminerrorstatusout = "[Admin: True] ";
            }
            else
            {
                adminerrorstatusout = "[Admin: False] ";
                boolAdminErrorStatus = true;
            }


            if (BoolLocalDir)
            {
                tronstatusout = "[Tron: Local] ";
            }
            else if (BoolPrevDir)
            {
                tronstatusout =  "[Tron: Previous] ";
            }
            else if (BoolRootDir)
            {
                tronstatusout = "[Tron: Root] ";
            }
            else if (BoolSearchedDir)
            {
                tronstatusout = "[Tron: Searched] ";
            }
            else if (!BoolLocalDir && !BoolPrevDir && !BoolRootDir && !BoolSearchedDir)
            {
                tronstatusout = "[Tron: Not Found] ";
                boolTronErrorStatus = true;
            }
            else
            {
                tronstatusout = "[Tron: Not Found] ";
                boolTronErrorStatus = true;
            }


            if (System.Windows.Forms.SystemInformation.BootMode == BootMode.FailSafe)
            {
                bootstatusout = "[Boot: Safe]";
            }
            else if (System.Windows.Forms.SystemInformation.BootMode == BootMode.FailSafeWithNetwork)
            {
                bootstatusout = "[Boot: Safe+Net]";
            }
            else if (System.Windows.Forms.SystemInformation.BootMode == BootMode.Normal)
            {
                bootstatusout = "[Boot: Normal]";
                boolBootErrorStatus = true;
            }

            if (boolAdminErrorStatus)
            {
                lblAdminStatus.ForeColor = System.Drawing.Color.Red;
            }
            if (boolBootErrorStatus)
            {
                lblBootStatus.ForeColor = System.Drawing.Color.Red;
            }
            if (boolTronErrorStatus)
            {
                lblTronStatus.ForeColor = System.Drawing.Color.Red;
            }
            lblAdminStatus.Text = adminerrorstatusout;
            lblBootStatus.Text = bootstatusout;
            lblTronStatus.Text = tronstatusout;
        }

        private void InitLoggingSettings()
        {
            intCMDCommandMode = OS_Settings.GetCMDConsoleMode();
            intGPLMode = OS_Settings.GetGPLMode();
            intProgramOpendMode = OS_Settings.GetProgramOpenMode();
            intRegistyMode = OS_Settings.GetRegistryMode();
            intStartupMode = OS_Settings.GetStartupMode();
            intSysinfoMode = OS_Settings.GetSysinfoMode();
            intVerboseErrorMode = OS_Settings.GetVerboseErrorMode();
            intWebsiteMode = OS_Settings.GetWebsiteMode();

            //Load Checkboxes for Settings config
            cbCMDLog.Checked = Settings.Default.boolCMDLog;
            cbCMDConsole.Checked = Settings.Default.boolCMDConsole;
            cbGPLConsole.Checked = Settings.Default.boolGPLNoticeConsole;
            cbGPLNoticeLog.Checked = Settings.Default.boolGPLNoticeLog;
            cbOSStartConsole.Checked = Settings.Default.boolStartupConsole;
            cbOSStartLog.Checked = Settings.Default.boolStartupLog;
            cbOpenedConsole.Checked = Settings.Default.boolProgramOpenedConsole;
            cbOpenedLog.Checked = Settings.Default.boolProgramOpenedLog;
            cbRegistryConsole.Checked = Settings.Default.boolRegistryConsole;
            cbRegistryLog.Checked = Settings.Default.boolRegistryLog;
            cbSysInfoLog.Checked = Settings.Default.boolSysInfoLog;
            cbSysinfoConsole.Checked = Settings.Default.boolSysInfoConsole;
            cbWebsitesLog.Checked = Settings.Default.boolWebsiteLog;
            cbWebsitesConsole.Checked = Settings.Default.boolWebsiteConsole;
            cbVerboseErrorLog.Checked = Settings.Default.boolVerboseErrorLog;
            cbVerboseErrorConsole.Checked = Settings.Default.boolVerboseErrorConsole;
        }

        public void OSConsole(string input, int mode)
        {
            //mode = 0 or null -> OSConsole, 1 -> OSConsole plus log, 2-> Log Only, 3->Go nowhere
            string logfile = Directory.GetCurrentDirectory() + "\\Logs\\onestoplog.txt";
            string logfiledir = Directory.GetCurrentDirectory() + "\\Logs\\";
            
            var directoryInfo = new FileInfo(logfiledir).Directory;
            if (directoryInfo != null) directoryInfo.Create();

            if (input == "OS_GPL")
            {
                if(mode == 1 || mode ==0)
                { 
                tb_Console.AppendText(@"OneStopIT - The Open Source All-In-One tool for technicians." +
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
            tb_Console.AppendText(Environment.NewLine + @"===========================================");
            }
            if (input == "OS_BR" && (mode == 0 || mode == 1))
            {
            tb_Console.AppendText(Environment.NewLine + Environment.NewLine);
            }
            if ((mode == 0 || mode == 1) &&
                (input.Contains("OS_BR") || input.Contains("OS_GPL") || input.Contains("OS_HR")))
            {
            }
            else
            {
                if (mode == 0 || mode == 1)
                {
                    tb_Console.AppendText(Environment.NewLine + input);
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
                    File.AppendAllText(logfile,Environment.NewLine + @"===========================================");
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
                    File.AppendAllText(logfile,Environment.NewLine + Environment.NewLine);
                }
                catch (Exception e)
                {
                    MessageBox.Show(@"Problem writing log file" + Environment.NewLine + Environment.NewLine + e);
                }
            }
            if (mode == 1 || mode == 2)
            {
                if(input.Contains("OS_BR") || input.Contains("OS_GPL") || input.Contains("OS_HR"))
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


        private void ddl_info_NetworkAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedAdapter = _ddlInfoNetworkAdapters.SelectedText;

                var adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (var adapter in adapters)
                {
                    if (adapter.Name == _ddlInfoNetworkAdapters.Text)
                    {
                        _lblInfoAdapterDesc.Text = adapter.Description;

                        var adapterProperties = adapter.GetIPProperties();

                        //DNS Server
                        var dnsServers = adapterProperties.DnsAddresses;
                        var strDnsOut = "";
                        if (dnsServers.Count > 0)
                        {
                            foreach (var dns in dnsServers)
                            {
                                if (dns.ToString() == "fec0:0:0:ffff::1%1")
                                {
                                }
                                else if (dns.ToString() == "fec0:0:0:ffff::2%1")
                                {
                                }
                                else if (dns.ToString() == "fec0:0:0:ffff::3%1")
                                {
                                }
                                else
                                {
                                    strDnsOut = strDnsOut + dns + " ";
                                }
                            }
                            _lnkInfoPrimDns.Text = strDnsOut;
                        }


                        //Gateway
                        if (adapter.OperationalStatus == OperationalStatus.Up)
                        {
                            var strOutput = "";
                            foreach (var g in adapter.GetIPProperties().GatewayAddresses)
                            {
                                strOutput = strOutput + g.Address + " ";
                                _lnkInfoGateway.Text = strOutput;
                            }
                        }
                        else
                        {
                            _lnkInfoGateway.Text = "Status is Down";
                        }

                        //Internal IP
                        var strIpOut = "";
                        foreach (var ip in adapter.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                strIpOut = strIpOut + ip.Address + " ";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OSConsole("Exeption Thrown - Network Adapter Selection: " + ex , intVerboseErrorMode);
                throw;
            }
        }

        public void cb_tron_dev_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronDev.Checked)
            {
                TronSave("dev");
            }
            else
            {
                TronDel("dev");
            }
        }

        public void cb_tron_e_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronE.Checked)
            {
                TronSave("e");
            }
            else
            {
                TronDel("e");
            }
        }

        public void cb_tron_er_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronEr.Checked)
            {
                TronSave("er");
            }
            else
            {
                TronDel("er");
            }
        }

        public void cb_tron_m_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronM.Checked)
            {
                TronSave("m");
            }
            else
            {
                TronDel("m");
            }
        }

        public void cb_tron_o_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronO.Checked)
            {
                TronSave("o");
            }
            else
            {
                TronDel("o");
            }
        }

        public void cb_tron_p_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronP.Checked)
            {
                TronSave("p");
            }
            else
            {
                TronDel("p");
            }
        }

        public void cb_tron_r_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronR.Checked)
            {
                TronSave("r");
            }
            else
            {
                TronDel("r");
            }
        }

        public void cb_tron_sa_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSa.Checked)
            {
                TronSave("sa");
            }
            else
            {
                TronDel("sa");
            }
        }

        public void cb_tron_sb_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSb.Checked)
            {
                TronSave("sb");
            }
            else
            {
                TronDel("sb");
            }
        }

        public void cb_tron_sd_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSd.Checked)
            {
                TronSave("sd");
            }
            else
            {
                TronDel("sd");
            }
        }

        public void cb_tron_sdc_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSdc.Checked)
            {
                TronSave("sdc");
            }
            else
            {
                TronDel("sdc");
            }
        }

        public void cb_tron_se_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSe.Checked)
            {
                TronSave("se");
            }
            else
            {
                TronDel("se");
            }
        }

        public void cb_tron_sfr_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSfr.Checked)
            {
                TronSave("sfr");
            }
            else
            {
                TronDel("sfr");
            }
        }

        public void cb_tron_sk_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSk.Checked)
            {
                TronSave("sk");
            }
            else
            {
                TronDel("sk");
            }
        }

        public void cb_tron_sm_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSm.Checked)
            {
                TronSave("sm");
            }
            else
            {
                TronDel("sm");
            }
        }

        public void cb_tron_sp_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSp.Checked)
            {
                TronSave("sp");
            }
            else
            {
                TronDel("sp");
            }
        }

        public void cb_tron_spr_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSpr.Checked)
            {
                TronSave("spr");
            }
            else
            {
                TronDel("spr");
            }
        }

        public void cb_tron_srr_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSrr.Checked)
            {
                TronSave("srr");
            }
            else
            {
                TronDel("srr");
            }
        }

        public void cb_tron_ss_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSs.Checked)
            {
                TronSave("ss");
            }
            else
            {
                TronDel("ss");
            }
        }

        public void cb_tron_str_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronStr.Checked)
            {
                TronSave("str");
            }
            else
            {
                TronDel("str");
            }
        }

        public void cb_tron_sw_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronSw.Checked)
            {
                TronSave("sw");
            }
            else
            {
                TronDel("sw");
            }
        }

        public void cb_tron_v_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronV.Checked)
            {
                TronSave("v");
            }
            else
            {
                TronDel("v");
            }
        }

        public void cb_tron_x_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTronX.Checked)
            {
                TronSave("x");
            }
            else
            {
                TronDel("x");
            }
        }

        private void btn_ShopSet_Save_Click(object sender, EventArgs e)
        {
            Settings.Default.str_Shop_Addr1 = _tbShopSetAddr1.Text;
            Settings.Default.str_Shop_Addr2 = _tbShopSetAddr2.Text;
            Settings.Default.str_Shop_City = _tbShopSetCity.Text;
            Settings.Default.str_Shop_Email = _tbShopSetEmail.Text;
            Settings.Default.str_Shop_Name = _tbShopSetName.Text;
            Settings.Default.str_Shop_Phone = _tbShopSetPhone.Text;
            Settings.Default.str_Shop_State = _tbShopSetState.Text;
            Settings.Default.Save();
            LoadTitleBar();
        }


        private void MenuClicked(object sender, EventArgs e)
        {
            var currentSetting = Settings.Default.str_StoredApps;
            var rawPairs = currentSetting.Split('|');
            foreach (var values in rawPairs)
            {
                if (values.Contains(((ToolStripMenuItem) sender).Text))
                {
                    var path = values.Split(',').Last();

                    try
                    {
                        Process.Start(path);
                    }
                    catch
                    {
                        MessageBox.Show("Error launching app");
                    }
                }
            }
        }

        private void MenuClickedScripts(object sender, EventArgs e)
        {
            var strCurrentDirectory = Directory.GetCurrentDirectory();
            var path = Convert.ToString(sender);
            var fullpath = strCurrentDirectory + "\\Scripts\\" + path;
            try
            {
                Process.Start(fullpath);
            }
            catch
            {
                MessageBox.Show("Error launching Script");
            }
        }

        private void MenuClickedDocuments(object sender, EventArgs e)
        {
            var strCurrentDirectory = Directory.GetCurrentDirectory();
            var path = Convert.ToString(sender);
            var fullpath = strCurrentDirectory + "\\Documents\\" + path;
            try
            {
                Process.Start(fullpath);
            }
            catch
            {
                MessageBox.Show("Error launching Document");
            }
        }


        private void btn_QL_CreateNew_Click(object sender, EventArgs e)
        {
            var strObjectName = _txtQlAppName.Text;
            var strCleaned = strObjectName.Trim(',', '|');
            CreateMenuItem(strCleaned);
            _txtQlAppName.Text = "";
        }

        private void btn_QL_DeleteSelected_Click(object sender, EventArgs e)
        {
            var strCurrent = Settings.Default.str_StoredApps;
            var strOutput = "";

            foreach (var selecteditem in _lbCurrentPrograms.SelectedItems)
            {
                var strItem = selecteditem as string;

                var rawPairs = strCurrent.Split('|');
                foreach (var values in rawPairs)
                {
                    if (!values.Contains(strItem))
                    {
                        strOutput = strOutput + values;
                    }
                    else
                    {
                        var name = values.Split(',').First();
                        _qlToolStripMenuItem.DropDownItems.Remove(_qlToolStripMenuItem.DropDownItems[name]);
                    }
                }
            }
            Settings.Default.str_StoredApps = strOutput;
            Settings.Default.Save();

            _lbCurrentPrograms.Items.Clear();
            //LoadMenuatStart();
        }

        private void btn_LocateTron_Click(object sender, EventArgs e)
        {
            var result = _ofdTron.ShowDialog();
            if (result == DialogResult.OK)
            {
                var strFileName = _ofdTron.FileName;


                if (strFileName.Contains("Tron.bat"))
                {
                    EnableLocalTron();
                }
                else if (strFileName.Contains("tron.bat"))
                {
                    EnableLocalTron();
                }
                else
                {
                    TronDisable("Tron.bat Not Located!");
                }
            }
        }

        private void EnableLocalTron()
        {
            var tronFile = _ofdTron.FileName;
            var str_TronPath = Path.GetDirectoryName(tronFile);
            TronEnable("Tron Located", str_TronPath + "\\" + tronFile);
            Settings.Default.str_LastTronDirectory = str_TronPath + "\\";
            Settings.Default.Save();
            BoolLocalDir = false;
            BoolPrevDir = false;
        }


        private void SaveCurrentCBs()
        {
            Settings.Default.bool_tron_a = false;
            Settings.Default.bool_tron_c = false;
            Settings.Default.bool_tron_d = false;
            Settings.Default.bool_tron_dev = false;
            Settings.Default.bool_tron_e = false;
            Settings.Default.bool_tron_er = false;
            Settings.Default.bool_tron_m = false;
            Settings.Default.bool_tron_o = false;
            Settings.Default.bool_tron_p = false;
            Settings.Default.bool_tron_r = false;
            Settings.Default.bool_tron_sa = false;
            Settings.Default.bool_tron_sb = false;
            Settings.Default.bool_tron_sd = false;
            Settings.Default.bool_tron_sdc = false;
            Settings.Default.bool_tron_se = false;
            Settings.Default.bool_tron_sfr = false;
            Settings.Default.bool_tron_sk = false;
            Settings.Default.bool_tron_sm = false;
            Settings.Default.bool_tron_sp = false;
            Settings.Default.bool_tron_spr = false;
            Settings.Default.bool_tron_srr = false;
            Settings.Default.bool_tron_ss = false;
            Settings.Default.bool_tron_str = false;
            Settings.Default.bool_tron_sw = false;
            Settings.Default.bool_tron_v = false;
            Settings.Default.bool_tron_x = false;
            Settings.Default.Save();

            if (_cbTronDev.Checked)
            {
                Settings.Default.bool_tron_dev = true;
                Settings.Default.Save();
            }
            if (_cbTronE.Checked)
            {
                Settings.Default.bool_tron_e = true;
                Settings.Default.Save();
            }
            if (_cbTronEr.Checked)
            {
                Settings.Default.bool_tron_er = true;
                Settings.Default.Save();
            }
            if (_cbTronM.Checked)
            {
                Settings.Default.bool_tron_m = true;
                Settings.Default.Save();
            }
            if (_cbTronO.Checked)
            {
                Settings.Default.bool_tron_o = true;
                Settings.Default.Save();
            }
            if (_cbTronP.Checked)
            {
                Settings.Default.bool_tron_p = true;
                Settings.Default.Save();
            }
            if (_cbTronR.Checked)
            {
                Settings.Default.bool_tron_r = true;
                Settings.Default.Save();
            }
            if (_cbTronSa.Checked)
            {
                Settings.Default.bool_tron_sa = true;
                Settings.Default.Save();
            }
            if (_cbTronSb.Checked)
            {
                Settings.Default.bool_tron_sb = true;
                Settings.Default.Save();
            }
            if (_cbTronSd.Checked)
            {
                Settings.Default.bool_tron_sd = true;
                Settings.Default.Save();
            }
            if (_cbTronSdc.Checked)
            {
                Settings.Default.bool_tron_sdc = true;
                Settings.Default.Save();
            }
            if (_cbTronSe.Checked)
            {
                Settings.Default.bool_tron_se = true;
                Settings.Default.Save();
            }
            if (_cbTronSfr.Checked)
            {
                Settings.Default.bool_tron_sfr = true;
                Settings.Default.Save();
            }
            if (_cbTronSk.Checked)
            {
                Settings.Default.bool_tron_sk = true;
                Settings.Default.Save();
            }
            if (_cbTronSm.Checked)
            {
                Settings.Default.bool_tron_sm = true;
                Settings.Default.Save();
            }
            if (_cbTronSp.Checked)
            {
                Settings.Default.bool_tron_sp = true;
                Settings.Default.Save();
            }
            if (_cbTronSpr.Checked)
            {
                Settings.Default.bool_tron_spr = true;
                Settings.Default.Save();
            }
            if (_cbTronSrr.Checked)
            {
                Settings.Default.bool_tron_srr = true;
                Settings.Default.Save();
            }
            if (_cbTronSs.Checked)
            {
                Settings.Default.bool_tron_ss = true;
                Settings.Default.Save();
            }
            if (_cbTronStr.Checked)
            {
                Settings.Default.bool_tron_str = true;
                Settings.Default.Save();
            }
            if (_cbTronSw.Checked)
            {
                Settings.Default.bool_tron_sw = true;
                Settings.Default.Save();
            }
            if (_cbTronV.Checked)
            {
                Settings.Default.bool_tron_v = true;
                Settings.Default.Save();
            }
            if (_cbTronX.Checked)
            {
                Settings.Default.bool_tron_x = true;
                Settings.Default.Save();
            }
        }

        private void btn_Tron_SaveFlags_Click(object sender, EventArgs e)
        {
            SaveCurrentCBs();
        }

        private void btn_ConfigDump_Click(object sender, EventArgs e)
        {
            SaveCurrentCBs();
            var strArguments = GetTronArgs();
            LaunchTron(" -c -e");
        }

        private void LaunchTron(string strExtraArg)
        {
            if (BoolLocalDir)
            {
                var strCurrentDir = Directory.GetCurrentDirectory();
                var tronLaunchString = " /C \"" + strCurrentDir + "\\Tron.bat\"" + strExtraArg + GetTronArgs();
                Process.Start("cmd.exe", tronLaunchString);
            }
            else if (BoolPrevDir)
            {
                var strCurrentDir = Settings.Default.str_LastTronDirectory;
                var tronLaunchString = " /C \"" + strCurrentDir + "Tron.bat\"" + strExtraArg + GetTronArgs();
                Process.Start("cmd.exe", tronLaunchString);
            }
            else
            {
                var tronFile = _ofdTron.FileName;
                var tronLaunchString = " /C \"" + tronFile + "\"" + strExtraArg + GetTronArgs();

                Process.Start("cmd.exe", tronLaunchString);
            }
        }

        private void btn_DryRun_Click(object sender, EventArgs e)
        {
            SaveCurrentCBs();
            LaunchTron(" -d -e");
        }

        private void btn_RunTron_Click(object sender, EventArgs e)
        {
            SaveCurrentCBs();
            LaunchTron("-e");
        }


        public string GetTronArgs()
        {
            var tronFileArgs = " -a";
            if (Settings.Default.bool_tron_a)
            {
                tronFileArgs = tronFileArgs + " -a";
            }
            if (Settings.Default.bool_tron_c)
            {
                tronFileArgs = tronFileArgs + " -c";
            }
            if (Settings.Default.bool_tron_d)
            {
                tronFileArgs = tronFileArgs + " -d";
            }
            if (Settings.Default.bool_tron_dev)
            {
                tronFileArgs = tronFileArgs + " -dev";
            }
            if (Settings.Default.bool_tron_e)
            {
                tronFileArgs = tronFileArgs + " -e";
            }
            if (Settings.Default.bool_tron_er)
            {
                tronFileArgs = tronFileArgs + " -er";
            }
            if (Settings.Default.bool_tron_m)
            {
                tronFileArgs = tronFileArgs + " -m";
            }
            if (Settings.Default.bool_tron_o)
            {
                tronFileArgs = tronFileArgs + " -o";
            }
            if (Settings.Default.bool_tron_p)
            {
                tronFileArgs = tronFileArgs + " -p";
            }
            if (Settings.Default.bool_tron_r)
            {
                tronFileArgs = tronFileArgs + " -r";
            }
            if (Settings.Default.bool_tron_sa)
            {
                tronFileArgs = tronFileArgs + " -sa";
            }
            if (Settings.Default.bool_tron_sb)
            {
                tronFileArgs = tronFileArgs + " -sb";
            }
            if (Settings.Default.bool_tron_sd)
            {
                tronFileArgs = tronFileArgs + " -sd";
            }
            if (Settings.Default.bool_tron_sdc)
            {
                tronFileArgs = tronFileArgs + " -sdc";
            }
            if (Settings.Default.bool_tron_se)
            {
                tronFileArgs = tronFileArgs + " -se";
            }
            if (Settings.Default.bool_tron_sfr)
            {
                tronFileArgs = tronFileArgs + " -sfr";
            }
            if (Settings.Default.bool_tron_sk)
            {
                tronFileArgs = tronFileArgs + " -sk";
            }
            if (Settings.Default.bool_tron_sm)
            {
                tronFileArgs = tronFileArgs + " -sm";
            }
            if (Settings.Default.bool_tron_sp)
            {
                tronFileArgs = tronFileArgs + " -sp";
            }
            if (Settings.Default.bool_tron_spr)
            {
                tronFileArgs = tronFileArgs + " -spr";
            }
            if (Settings.Default.bool_tron_srr)
            {
                tronFileArgs = tronFileArgs + " -srr";
            }
            if (Settings.Default.bool_tron_ss)
            {
                tronFileArgs = tronFileArgs + " -ss";
            }
            if (Settings.Default.bool_tron_str)
            {
                tronFileArgs = tronFileArgs + " -str";
            }
            if (Settings.Default.bool_tron_sw)
            {
                tronFileArgs = tronFileArgs + " -sw";
            }
            if (Settings.Default.bool_tron_v)
            {
                tronFileArgs = tronFileArgs + " -v";
            }
            if (Settings.Default.bool_tron_x)
            {
                tronFileArgs = tronFileArgs + " -x";
            }
            return tronFileArgs;
        }

        #region Components

        private ToolStrip _tsBottomToolbar;
        private ToolStripProgressBar _pbCurrentProgress;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripLabel _lblCurrentActionStatus;
        private ToolStripLabel lblAdminStatus;
        private MenuStrip _menuPrimary;
        private ToolStripMenuItem _oneStopToolStripMenuItem;
        private ToolStripMenuItem _runPromptToolStripMenuItem;
        private ToolStripMenuItem _networkToolStripMenuItem;
        private ToolStripMenuItem _systemToolStripMenuItem;
        private ToolStripMenuItem _techResourcesToolStripMenuItem;
        private ToolStripMenuItem _powerToolStripMenuItem;
        private ToolStripMenuItem _helpToolStripMenuItem;
        private TabControl _tcPrimaryTabs;
        private TabPage _tpTronCli;
        private ToolStripMenuItem _startAtRunToolStripMenuItem;
        private ToolStripMenuItem _restartAsAdminToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator2;
        private ToolStripMenuItem _oneStopSettingsToolStripMenuItem;
        private ToolStripMenuItem _tRonToolStripMenuItem;
        private ToolStripMenuItem _foldersToolStripMenuItem;
        private ToolStripMenuItem _prepToolStripMenuItem;
        private ToolStripMenuItem _tempcleanToolStripMenuItem;
        private ToolStripMenuItem _dToolStripMenuItem;
        private ToolStripMenuItem _disinfectToolStripMenuItem;
        private ToolStripMenuItem _repairToolStripMenuItem;
        private ToolStripMenuItem _patchToolStripMenuItem;
        private ToolStripMenuItem _optimizeToolStripMenuItem;
        private ToolStripMenuItem _wrapUpToolStripMenuItem;
        private ToolStripMenuItem _manualToolsToolStripMenuItem;
        private ToolStripMenuItem _setConfigurationOptionsToolStripMenuItem;
        private ToolStripMenuItem _deployTronToNewLocationToolStripMenuItem;
        private ToolStripMenuItem _windowsRunCommandToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator3;
        private ToolStripMenuItem _openPowershellToolStripMenuItem;
        private ToolStripMenuItem _openElevatedCommandPromptToolStripMenuItem;
        private ToolStripMenuItem _openElevatedCommandPromptToPathToolStripMenuItem;
        private ToolStripMenuItem _openRouterInterfaceToolStripMenuItem;
        private ToolStripMenuItem _openAtDefaultGatewayToolStripMenuItem;
        private ToolStripMenuItem _openHttprouterpasswordscomToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator5;
        private ToolStripMenuItem _openSavedInterface1XxxxxxxxxxxxToolStripMenuItem;
        private ToolStripMenuItem _openSavedInterface2XxxxxxxxxxxxToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator4;
        private ToolStripMenuItem _toolStripMenuItem2;
        private ToolStripMenuItem _toolStripMenuItem3;
        private ToolStripMenuItem _toolStripMenuItem4;
        private ToolStripMenuItem _toolStripMenuItem5;
        private ToolStripMenuItem _toolStripMenuItem6;
        private ToolStripMenuItem _toolStripMenuItem7;
        private ToolStripMenuItem _toolStripMenuItem8;
        private ToolStripMenuItem _toolStripMenuItem9;
        private ToolStripMenuItem _toolStripMenuItem10;
        private ToolStripMenuItem _toolStripMenuItem11;
        private ToolStripMenuItem _toolStripMenuItem12;
        private ToolStripMenuItem _dNsSettingsToolStripMenuItem;
        private ToolStripMenuItem _resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator6;
        private ToolStripMenuItem _firewallToolStripMenuItem;
        private ToolStripMenuItem _windowsFirewallAndAdvancedSecurityToolStripMenuItem;
        private ToolStripMenuItem _resetFirewallToDefaultnetshFirewallResetToolStripMenuItem;
        private ToolStripMenuItem _enableFirewallToolStripMenuItem;
        private ToolStripMenuItem _disableFirewallToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator7;
        private ToolStripMenuItem _importFirewallSettingsToolStripMenuItem;
        private ToolStripMenuItem _exportFirewallSettingsToolStripMenuItem;
        private ToolStripMenuItem _enableRemoteManagementToolStripMenuItem;
        private ToolStripMenuItem _enableRemoteDesktopToolStripMenuItem;
        private ToolStripMenuItem _enableProgramInFirewallToolStripMenuItem;
        private ToolStripMenuItem _enablePortToolStripMenuItem;
        private ToolStripMenuItem _groupPolicyToolStripMenuItem;
        private ToolStripMenuItem _getGroupPolicyReportToolStripMenuItem;
        private ToolStripMenuItem _forceRefreshToolStripMenuItem;
        private ToolStripMenuItem _openGroupPolicyEditorToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator8;
        private ToolStripMenuItem _connectivityToHttpwwwgooglecomToolStripMenuItem;
        private ToolStripMenuItem _pingIp4ToolStripMenuItem;
        private ToolStripMenuItem _pringIp6ToolStripMenuItem;
        private ToolStripMenuItem _traceRouteToolStripMenuItem;
        private ToolStripMenuItem _pingPathIp4ToolStripMenuItem;
        private ToolStripMenuItem _pingPathIp6ToolStripMenuItem;
        private ToolStripMenuItem _ipconfigalltoolstripmenuitem;
        private ToolStripMenuItem _releaseDhcpToolStripMenuItem;
        private ToolStripMenuItem _renewDhcpToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator9;
        private ToolStripMenuItem _resetTcpipToolStripMenuItem;
        private ToolStripMenuItem _flushDnsCacheToolStripMenuItem;
        private ToolStripMenuItem _flushArpCacheToolStripMenuItem;
        private ToolStripMenuItem _flushNetbiosCacheToolStripMenuItem;
        private ToolStripMenuItem _restIpv4ToolStripMenuItem;
        private ToolStripMenuItem _resteIpv6ToolStripMenuItem;
        private ToolStripMenuItem _resetWinsockToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator10;
        private ToolStripMenuItem _netstatToolStripMenuItem;
        private ToolStripMenuItem _pingToolStripMenuItem;
        private ToolStripMenuItem _ownIpip4ToolStripMenuItem;
        private ToolStripMenuItem _loopbackIp4ToolStripMenuItem;
        private ToolStripMenuItem _gatewayIp4ToolStripMenuItem;
        private ToolStripMenuItem _otherIp4ToolStripMenuItem;
        private ToolStripMenuItem _openNetworkConnectionsToolStripMenuItem;
        private ToolStripMenuItem _storedCredentialsToolStripMenuItem;
        private ToolStripMenuItem _systemFoldersToolStripMenuItem;
        private ToolStripMenuItem _desktopToolStripMenuItem;
        private ToolStripMenuItem _userProfilesToolStripMenuItem;
        private ToolStripMenuItem _programFilesToolStripMenuItem;
        private ToolStripMenuItem _programFilesx86ToolStripMenuItem;
        private ToolStripMenuItem _windowsToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator12;
        private ToolStripMenuItem _controlPanelObjectsToolStripMenuItem;
        private ToolStripMenuItem _mainToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator13;
        private ToolStripMenuItem _accessibilityToolStripMenuItem;
        private ToolStripMenuItem _addNewHardwareToolStripMenuItem;
        private ToolStripMenuItem _addRemoveProgramsToolStripMenuItem;
        private ToolStripMenuItem _dateTimeToolStripMenuItem;
        private ToolStripMenuItem _displayToolStripMenuItem;
        private ToolStripMenuItem _findFastToolStripMenuItem;
        private ToolStripMenuItem _fontsToolStripMenuItem;
        private ToolStripMenuItem _internetPropertiesToolStripMenuItem;
        private ToolStripMenuItem _joystickToolStripMenuItem;
        private ToolStripMenuItem _keyboardToolStripMenuItem;
        private ToolStripMenuItem _exchangeToolStripMenuItem;
        private ToolStripMenuItem _microsoftMailPostOfficeToolStripMenuItem;
        private ToolStripMenuItem _modemToolStripMenuItem;
        private ToolStripMenuItem _mouseToolStripMenuItem;
        private ToolStripMenuItem _multimediaToolStripMenuItem;
        private ToolStripMenuItem _networkToolStripMenuItem1;
        private ToolStripMenuItem _passwordToolStripMenuItem;
        private ToolStripMenuItem _pCCardToolStripMenuItem;
        private ToolStripMenuItem _powerManagementToolStripMenuItem;
        private ToolStripMenuItem _printersToolStripMenuItem;
        private ToolStripMenuItem _regionalSettingsToolStripMenuItem;
        private ToolStripMenuItem _scannersAndCamerasToolStripMenuItem;
        private ToolStripMenuItem _soundToolStripMenuItem;
        private ToolStripMenuItem _systemToolStripMenuItem1;
        private ToolStripMenuItem _desktopGodmodeFolderToolStripMenuItem;
        private ToolStripMenuItem _createLeaveAfterQuitToolStripMenuItem;
        private ToolStripMenuItem _createDestroyOnQuitToolStripMenuItem;
        private ToolStripMenuItem _diskManagementToolsToolStripMenuItem;
        private ToolStripMenuItem _checkDiskToolStripMenuItem;
        private ToolStripMenuItem _defragSystemToolStripMenuItem;
        private ToolStripMenuItem _defragDefragglerToolStripMenuItem;
        private ToolStripMenuItem _diskManagmentToolStripMenuItem;
        private ToolStripMenuItem _driveCleanupUtilityToolStripMenuItem;
        private ToolStripMenuItem _partitionsToolStripMenuItem;
        private ToolStripMenuItem _mSconfigToolStripMenuItem;
        private ToolStripMenuItem _systemRestoreToolStripMenuItem;
        private ToolStripMenuItem _createRestorePointToolStripMenuItem;
        private ToolStripMenuItem _openRestorePointToolStripMenuItem;
        private ToolStripMenuItem _usersToolStripMenuItem;
        private ToolStripMenuItem _accountsToolStripMenuItem;
        private ToolStripMenuItem _advancedAccountsToolStripMenuItem;
        private ToolStripMenuItem _autoLogonOptionsToolStripMenuItem;
        private ToolStripMenuItem _uAcSettingsToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator11;
        private ToolStripMenuItem _computerManagementToolStripMenuItem;
        private ToolStripMenuItem _componantServicesToolStripMenuItem;
        private ToolStripMenuItem _dataSourcesOdbcToolStripMenuItem;
        private ToolStripMenuItem _deviceManagerToolStripMenuItem;
        private ToolStripMenuItem _directXDiagnosticsToolStripMenuItem;
        private ToolStripMenuItem _driverVerifierToolStripMenuItem;
        private ToolStripMenuItem _eventViewerToolStripMenuItem;
        private ToolStripMenuItem _groupPolicyEditorToolStripMenuItem;
        private ToolStripMenuItem _localSecurityPolicyToolStripMenuItem;
        private ToolStripMenuItem _performanceMonitorToolStripMenuItem;
        private ToolStripMenuItem _printManagementToolStripMenuItem;
        private ToolStripMenuItem _registryEditorToolStripMenuItem;
        private ToolStripMenuItem _servicesToolStripMenuItem;
        private ToolStripMenuItem _sharedFoldersToolStripMenuItem;
        private ToolStripMenuItem _taskSchedulerToolStripMenuItem;
        private ToolStripMenuItem _windowsMemoryDiagnosticToolStripMenuItem;
        private ToolStripMenuItem _wMiTesterToolStripMenuItem;
        private ToolStripMenuItem _windowsUpdatesToolStripMenuItem;
        private ToolStripMenuItem _windowsVersionToolStripMenuItem;
        private ToolStripMenuItem _windowsSecurityCenterToolStripMenuItem;
        private ToolStripMenuItem _rOneStopItToolStripMenuItem;
        private ToolStripMenuItem _rTronScriptToolStripMenuItem;
        private ToolStripMenuItem _ninitecomToolStripMenuItem;
        private ToolStripMenuItem _techWebsitesToolStripMenuItem;
        private ToolStripMenuItem _bleepingComputerToolStripMenuItem;
        private ToolStripMenuItem _geGeekToolStripMenuItem;
        private ToolStripMenuItem _browserTestingToolStripMenuItem;
        private ToolStripMenuItem _dSlReportscomSpeedTestToolStripMenuItem;
        private ToolStripMenuItem _speedtestnetToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator14;
        private ToolStripMenuItem _browserscopeToolStripMenuItem;
        private ToolStripMenuItem _qualysBrowsercheckToolStripMenuItem;
        private ToolStripMenuItem _firefoxOfficialPluginTestToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator15;
        private ToolStripMenuItem _silverlightbubblemarkcomToolStripMenuItem;
        private ToolStripMenuItem _flashbubblemarkcomToolStripMenuItem;
        private ToolStripMenuItem _javajavatesterorgToolStripMenuItem;
        private ToolStripMenuItem _shockwaveadobecomToolStripMenuItem;
        private ToolStripMenuItem _sSLssllabscomToolStripMenuItem;
        private ToolStripMenuItem _shieldsUpToolStripMenuItem;
        private ToolStripMenuItem _virusScannerRemovalToolsToolStripMenuItem;
        private ToolStripMenuItem _eSetMasterListToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator16;
        private ToolStripMenuItem _avastToolStripMenuItem;
        private ToolStripMenuItem _aVgToolStripMenuItem;
        private ToolStripMenuItem _aviraToolStripMenuItem;
        private ToolStripMenuItem _comodoToolStripMenuItem;
        private ToolStripMenuItem _fSecureToolStripMenuItem;
        private ToolStripMenuItem _kasperskyToolStripMenuItem;
        private ToolStripMenuItem _mcAffeToolStripMenuItem;
        private ToolStripMenuItem _nOd32ToolStripMenuItem;
        private ToolStripMenuItem _nortonToolStripMenuItem;
        private ToolStripMenuItem _nortonSecurityScanToolStripMenuItem;
        private ToolStripMenuItem _pandaToolStripMenuItem;
        private ToolStripMenuItem _sophosToolStripMenuItem;
        private ToolStripMenuItem _windowsSecurityEssentialsToolStripMenuItem;
        private ToolStripMenuItem _forceShutdownToolStripMenuItem;
        private ToolStripMenuItem _forceRestartToolStripMenuItem;
        private ToolStripMenuItem _forceLogoffToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator17;
        private ToolStripMenuItem _enableF8ToolStripMenuItem;
        private ToolStripMenuItem _disableF8ToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator22;
        private ToolStripMenuItem _quitToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator18;
        private ToolStripMenuItem _setSafemodeSwitchOnToolStripMenuItem;
        private ToolStripMenuItem _setSafemodeSwitchOnNetworkingToolStripMenuItem;
        private ToolStripMenuItem _setSafemodeSwitchOnMinimalToolStripMenuItem;
        private ToolStripMenuItem _setSafemodeSwitchOnAltShellToolStripMenuItem;
        private ToolStripMenuItem _setSafemodeSwtichOffNormalBootToolStripMenuItem;
        private ToolStripMenuItem _enumerateCurrentModeToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator19;
        private ToolStripMenuItem _hibernateToolStripMenuItem;
        private ToolStripMenuItem _hybridShutdownFastStartUpToolStripMenuItem;
        private ToolStripMenuItem _shutdownWithOptionsToolStripMenuItem;
        private ToolStripMenuItem _aboutToolStripMenuItem;
        private ToolStripMenuItem _disclaimerToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator20;
        private ToolStripMenuItem _viewOnlineDocumentationToolStripMenuItem;
        private ToolStripMenuItem _donateToolStripMenuItem;
        private ToolStripMenuItem _bitCoinToolStripMenuItem;
        private ToolStripMenuItem _paypalToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator21;
        private ToolStripMenuItem _staticToolStripMenuItem;
        private ToolStripMenuItem _cBrnisfunToolStripMenuItem;
        private TabPage _tpSystemInfo;
        private TabPage _tpUninstaller;
        private TabPage _tpWmiExplorer;
        private TabPage _tpConfigurator;
        private TabPage _tpTime;
        private TabControl _tpTronSettings;
        private TabPage _tpLaunchTron;
        private Button _btnLocateTron;
        private Button _btnDeploytofolder;
        private Button _btnConfigDump;
        private Button _btnDryRun;
        private Button _btnRunTron;
        private CheckBox _cbTronStr;
        private CheckBox _cbTronSs;
        private CheckBox _cbTronSrr;
        private CheckBox _cbTronSfr;
        private CheckBox _cbTronSm;
        private CheckBox _cbTronSdc;
        private CheckBox _cbTronSk;
        private CheckBox _cbTronSpr;
        private CheckBox _cbTronSw;
        private CheckBox _cbTronSe;
        private CheckBox _cbTronP;
        private Button _btnClear;
        private CheckBox _cbTronEr;
        private CheckBox _cbTronSb;
        private CheckBox _cbTronM;
        private CheckBox _cbTronX;
        private CheckBox _cbTronO;
        private CheckBox _cbTronV;
        private CheckBox _cbTronR;
        private CheckBox _cbTronSp;
        private CheckBox _cbTronSa;
        private CheckBox _cbTronSd;
        private TabPage _tpEmailSettings;
        private TabPage _tpSetFlags;
        private TabControl _tcConfigurator;
        private TabPage _tpInternetSettings;
        private TabPage _tpSecurity;
        private TabPage _tpPerformance;
        private TabPage _tpWelcomeScreen;
        private TabPage _tpWindows10;
        private TabPage _tpExplorer;
        private TabPage _tpAppearance;
        private LinkLabel _lnkInfoInternalIp;
        private Label _lblInfoExternalIp;
        private LinkLabel _lnkInfoGateway;
        private LinkLabel _lnkInfoPrimDns;
        private Label _lblDns;
        private Label _lblGateway;
        private Label _lblExternalIp;
        private Label _lblInternalIp;
        private Label _lblFreeC;
        private Label _lblInfoFreeC;
        private Label _lblRam;
        private Label _lblInfoRam;
        private Label _lblOs;
        private Label _lblComputerName;
        private Label _lblInfoOs;
        private Label _lblInfoComputerName;
        private ToolStripMenuItem _qlToolStripMenuItem;
        private ToolStripMenuItem _scriptsToolStripMenuItem;
        private ToolStripMenuItem _documentsToolStripMenuItem;
        private ToolStripSeparator _toolStripSeparator23;
        private OpenFileDialog _ofdMenuItem;
        private TabPage _tpSetup;
        private TabControl _tabControl2;
        private TabPage tpQuickLaunch;
        private Label _lblQlMenuItemName;
        private Button _btnQlCreateNew;
        private TextBox _txtQlAppName;
        private Label _lblQlFolders;
        private ContextMenuStrip _cmsDeleteQl;
        private IContainer components;
        private ListBox _lbCurrentPrograms;
        private Button _btnQlDeleteSelected;
        private TabPage _tpWelcome;
        private TabPage _tpOneStopMain;
        private Label _lblOsmExecuteOrder;
        private Label _lblOsmProgramSelect;
        private Label _lblOsmCategories;
        private Button _button2;
        private Button _button1;
        private ListBox _listBox3;
        private ListBox _listBox2;
        private ListBox _lbOsmCategories;
        private ComboBox _ddlInfoNetworkAdapters;
        private Label _label1;
        private Label _lblInfoAdapterDesc;
        private TabPage tpShopSettings;
        private Button _btnShopSetSave;
        private Label _lblShopSetState;
        private TextBox _tbShopSetState;
        private Label _lblShopSetCity;
        private TextBox _tbShopSetCity;
        private Label _lblShopSetEmail;
        private TextBox _tbShopSetEmail;
        private Label _lblShopSetPhone;
        private TextBox _tbShopSetPhone;
        private TextBox _tbShopSetAddr2;
        private Label _lblShopSetAddr;
        private TextBox _tbShopSetAddr1;
        private Label _lblShopSetShopname;
        private TextBox _tbShopSetName;
        private CheckBox _cbTronE;
        private CheckBox _cbTronDev;
        private OpenFileDialog _ofdTron;
        private Button _btnTronSaveFlags;
        private TabPage _tpOem;

        public OsMain()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._tsBottomToolbar = new System.Windows.Forms.ToolStrip();
            this._pbCurrentProgress = new System.Windows.Forms.ToolStripProgressBar();
            this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._lblCurrentActionStatus = new System.Windows.Forms.ToolStripLabel();
            this.lblAdminStatus = new System.Windows.Forms.ToolStripLabel();
            this._menuPrimary = new System.Windows.Forms.MenuStrip();
            this._qlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._documentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this._oneStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._startAtRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._restartAsAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._oneStopSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._tRonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._foldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._prepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._tempcleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._disinfectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._repairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._patchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._optimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._wrapUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._manualToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._setConfigurationOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._deployTronToNewLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.oneStopToolGetFileInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._runPromptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._windowsRunCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._openPowershellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openElevatedCommandPromptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openElevatedCommandPromptToPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openRouterInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openAtDefaultGatewayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openHttprouterpasswordscomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this._openSavedInterface1XxxxxxxxxxxxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openSavedInterface2XxxxxxxxxxxxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this._dNsSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this._firewallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._windowsFirewallAndAdvancedSecurityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._resetFirewallToDefaultnetshFirewallResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._enableFirewallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._disableFirewallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this._importFirewallSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._exportFirewallSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._enableRemoteManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._enableRemoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._enableProgramInFirewallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._enablePortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._groupPolicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._getGroupPolicyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._forceRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openGroupPolicyEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this._connectivityToHttpwwwgooglecomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pingIp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pringIp6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._traceRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pingPathIp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pingPathIp6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ipconfigalltoolstripmenuitem = new System.Windows.Forms.ToolStripMenuItem();
            this._releaseDhcpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._renewDhcpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this._resetTcpipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._flushDnsCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._flushArpCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._flushNetbiosCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._restIpv4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._resteIpv6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._resetWinsockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this._netstatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ownIpip4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._loopbackIp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._gatewayIp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._otherIp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openNetworkConnectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._storedCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._systemFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._desktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._userProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._programFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._programFilesx86ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this._controlPanelObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this._accessibilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._addNewHardwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._addRemoveProgramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._dateTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._findFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._fontsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._internetPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._joystickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._keyboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._exchangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._microsoftMailPostOfficeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._modemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._multimediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._networkToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._passwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pCCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._powerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._printersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._regionalSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._scannersAndCamerasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._systemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._desktopGodmodeFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._createLeaveAfterQuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._createDestroyOnQuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._diskManagementToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._checkDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._defragSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._defragDefragglerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._diskManagmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._driveCleanupUtilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._partitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mSconfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._systemRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._createRestorePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openRestorePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._advancedAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._autoLogonOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._uAcSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this._computerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._componantServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._dataSourcesOdbcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._deviceManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._directXDiagnosticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._driverVerifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._eventViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._groupPolicyEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._localSecurityPolicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._performanceMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._printManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._registryEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._sharedFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._taskSchedulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._windowsMemoryDiagnosticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._wMiTesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._windowsUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._windowsVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._windowsSecurityCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._techResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._rOneStopItToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._rTronScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ninitecomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._techWebsitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._bleepingComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._geGeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._browserTestingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._dSlReportscomSpeedTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._speedtestnetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this._browserscopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._qualysBrowsercheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._firefoxOfficialPluginTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this._silverlightbubblemarkcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._flashbubblemarkcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._javajavatesterorgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._shockwaveadobecomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._sSLssllabscomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._shieldsUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._virusScannerRemovalToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._eSetMasterListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this._avastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aVgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aviraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._comodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._fSecureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._kasperskyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mcAffeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nOd32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nortonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nortonSecurityScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pandaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._sophosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._windowsSecurityEssentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._powerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._forceShutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._forceRestartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._forceLogoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this._enableF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._disableF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this._setSafemodeSwitchOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._setSafemodeSwitchOnNetworkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._setSafemodeSwitchOnMinimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._setSafemodeSwitchOnAltShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._setSafemodeSwtichOffNormalBootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._enumerateCurrentModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this._hibernateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._hybridShutdownFastStartUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._shutdownWithOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._disclaimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this._viewOnlineDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._bitCoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._paypalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this._staticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._cBrnisfunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._tcPrimaryTabs = new System.Windows.Forms.TabControl();
            this._tpWelcome = new System.Windows.Forms.TabPage();
            this.tb_Console = new System.Windows.Forms.TextBox();
            this._tpOneStopMain = new System.Windows.Forms.TabPage();
            this._lblOsmExecuteOrder = new System.Windows.Forms.Label();
            this._lblOsmProgramSelect = new System.Windows.Forms.Label();
            this._lblOsmCategories = new System.Windows.Forms.Label();
            this._button2 = new System.Windows.Forms.Button();
            this._button1 = new System.Windows.Forms.Button();
            this._listBox3 = new System.Windows.Forms.ListBox();
            this._listBox2 = new System.Windows.Forms.ListBox();
            this._lbOsmCategories = new System.Windows.Forms.ListBox();
            this._tpTronCli = new System.Windows.Forms.TabPage();
            this._tpTronSettings = new System.Windows.Forms.TabControl();
            this._tpLaunchTron = new System.Windows.Forms.TabPage();
            this._btnTronSaveFlags = new System.Windows.Forms.Button();
            this._cbTronE = new System.Windows.Forms.CheckBox();
            this._cbTronDev = new System.Windows.Forms.CheckBox();
            this._btnLocateTron = new System.Windows.Forms.Button();
            this._btnDeploytofolder = new System.Windows.Forms.Button();
            this._btnConfigDump = new System.Windows.Forms.Button();
            this._btnDryRun = new System.Windows.Forms.Button();
            this._btnRunTron = new System.Windows.Forms.Button();
            this._cbTronStr = new System.Windows.Forms.CheckBox();
            this._cbTronSs = new System.Windows.Forms.CheckBox();
            this._cbTronSrr = new System.Windows.Forms.CheckBox();
            this._cbTronSfr = new System.Windows.Forms.CheckBox();
            this._cbTronSm = new System.Windows.Forms.CheckBox();
            this._cbTronSdc = new System.Windows.Forms.CheckBox();
            this._cbTronSk = new System.Windows.Forms.CheckBox();
            this._cbTronSpr = new System.Windows.Forms.CheckBox();
            this._cbTronSw = new System.Windows.Forms.CheckBox();
            this._cbTronSe = new System.Windows.Forms.CheckBox();
            this._cbTronP = new System.Windows.Forms.CheckBox();
            this._btnClear = new System.Windows.Forms.Button();
            this._cbTronEr = new System.Windows.Forms.CheckBox();
            this._cbTronSb = new System.Windows.Forms.CheckBox();
            this._cbTronM = new System.Windows.Forms.CheckBox();
            this._cbTronX = new System.Windows.Forms.CheckBox();
            this._cbTronO = new System.Windows.Forms.CheckBox();
            this._cbTronV = new System.Windows.Forms.CheckBox();
            this._cbTronR = new System.Windows.Forms.CheckBox();
            this._cbTronSp = new System.Windows.Forms.CheckBox();
            this._cbTronSa = new System.Windows.Forms.CheckBox();
            this._cbTronSd = new System.Windows.Forms.CheckBox();
            this._tpEmailSettings = new System.Windows.Forms.TabPage();
            this._tpSetFlags = new System.Windows.Forms.TabPage();
            this._tpTime = new System.Windows.Forms.TabPage();
            this._tpSystemInfo = new System.Windows.Forms.TabPage();
            this._tpUninstaller = new System.Windows.Forms.TabPage();
            this._tpWmiExplorer = new System.Windows.Forms.TabPage();
            this._tpConfigurator = new System.Windows.Forms.TabPage();
            this._tcConfigurator = new System.Windows.Forms.TabControl();
            this._tpInternetSettings = new System.Windows.Forms.TabPage();
            this._tpSecurity = new System.Windows.Forms.TabPage();
            this._tpPerformance = new System.Windows.Forms.TabPage();
            this._tpWelcomeScreen = new System.Windows.Forms.TabPage();
            this._tpWindows10 = new System.Windows.Forms.TabPage();
            this._tpExplorer = new System.Windows.Forms.TabPage();
            this._tpAppearance = new System.Windows.Forms.TabPage();
            this._tpOem = new System.Windows.Forms.TabPage();
            this._tpSetup = new System.Windows.Forms.TabPage();
            this._tabControl2 = new System.Windows.Forms.TabControl();
            this.tpQuickLaunch = new System.Windows.Forms.TabPage();
            this._btnQlDeleteSelected = new System.Windows.Forms.Button();
            this._lbCurrentPrograms = new System.Windows.Forms.ListBox();
            this._lblQlMenuItemName = new System.Windows.Forms.Label();
            this._btnQlCreateNew = new System.Windows.Forms.Button();
            this._txtQlAppName = new System.Windows.Forms.TextBox();
            this._lblQlFolders = new System.Windows.Forms.Label();
            this.tpShopSettings = new System.Windows.Forms.TabPage();
            this._btnShopSetSave = new System.Windows.Forms.Button();
            this._lblShopSetState = new System.Windows.Forms.Label();
            this._tbShopSetState = new System.Windows.Forms.TextBox();
            this._lblShopSetCity = new System.Windows.Forms.Label();
            this._tbShopSetCity = new System.Windows.Forms.TextBox();
            this._lblShopSetEmail = new System.Windows.Forms.Label();
            this._tbShopSetEmail = new System.Windows.Forms.TextBox();
            this._lblShopSetPhone = new System.Windows.Forms.Label();
            this._tbShopSetPhone = new System.Windows.Forms.TextBox();
            this._tbShopSetAddr2 = new System.Windows.Forms.TextBox();
            this._lblShopSetAddr = new System.Windows.Forms.Label();
            this._tbShopSetAddr1 = new System.Windows.Forms.TextBox();
            this._lblShopSetShopname = new System.Windows.Forms.Label();
            this._tbShopSetName = new System.Windows.Forms.TextBox();
            this._lnkInfoInternalIp = new System.Windows.Forms.LinkLabel();
            this._lblInfoExternalIp = new System.Windows.Forms.Label();
            this._lnkInfoGateway = new System.Windows.Forms.LinkLabel();
            this._lnkInfoPrimDns = new System.Windows.Forms.LinkLabel();
            this._lblDns = new System.Windows.Forms.Label();
            this._lblGateway = new System.Windows.Forms.Label();
            this._lblExternalIp = new System.Windows.Forms.Label();
            this._lblInternalIp = new System.Windows.Forms.Label();
            this._lblFreeC = new System.Windows.Forms.Label();
            this._lblInfoFreeC = new System.Windows.Forms.Label();
            this._lblRam = new System.Windows.Forms.Label();
            this._lblInfoRam = new System.Windows.Forms.Label();
            this._lblOs = new System.Windows.Forms.Label();
            this._lblComputerName = new System.Windows.Forms.Label();
            this._lblInfoOs = new System.Windows.Forms.Label();
            this._lblInfoComputerName = new System.Windows.Forms.Label();
            this._ofdMenuItem = new System.Windows.Forms.OpenFileDialog();
            this._cmsDeleteQl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._ddlInfoNetworkAdapters = new System.Windows.Forms.ComboBox();
            this._label1 = new System.Windows.Forms.Label();
            this._lblInfoAdapterDesc = new System.Windows.Forms.Label();
            this._ofdTron = new System.Windows.Forms.OpenFileDialog();
            this.testBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneStopInternalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchPortableBrowsersetInConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceLogoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectivityToDefaultGatewayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpServers = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mailGroupBox = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpNetwork = new System.Windows.Forms.TabPage();
            this.tpSystemReport = new System.Windows.Forms.TabPage();
            this.netBox = new System.Windows.Forms.TextBox();
            this.clearSslBTN = new System.Windows.Forms.Button();
            this.setGoogleDnsBTN = new System.Windows.Forms.Button();
            this.winsockRepBTN = new System.Windows.Forms.Button();
            this.clearStaticBTN = new System.Windows.Forms.Button();
            this.dnsFlushBTN = new System.Windows.Forms.Button();
            this.releaseRenewBTN = new System.Windows.Forms.Button();
            this.netCombo = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.hostNameTextB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.pubIPTextB = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.tpIntegration = new System.Windows.Forms.TabPage();
            this.tpLogging = new System.Windows.Forms.TabPage();
            this.cbCMDLog = new System.Windows.Forms.CheckBox();
            this.cbCMDConsole = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbRegistryLog = new System.Windows.Forms.CheckBox();
            this.cbRegistryConsole = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbWebsitesLog = new System.Windows.Forms.CheckBox();
            this.cbWebsitesConsole = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbGPLNoticeLog = new System.Windows.Forms.CheckBox();
            this.cbGPLConsole = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cbOSStartLog = new System.Windows.Forms.CheckBox();
            this.cbOSStartConsole = new System.Windows.Forms.CheckBox();
            this.cbVerboseErrorConsole = new System.Windows.Forms.CheckBox();
            this.cbVerboseErrorLog = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cbSysInfoLog = new System.Windows.Forms.CheckBox();
            this.cbSysinfoConsole = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cbOpenedLog = new System.Windows.Forms.CheckBox();
            this.cbOpenedConsole = new System.Windows.Forms.CheckBox();
            this.btnSaveLoggingStatus = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button12 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.lblBootStatus = new System.Windows.Forms.ToolStripLabel();
            this.lblTronStatus = new System.Windows.Forms.ToolStripLabel();
            this._tsBottomToolbar.SuspendLayout();
            this._menuPrimary.SuspendLayout();
            this._tcPrimaryTabs.SuspendLayout();
            this._tpWelcome.SuspendLayout();
            this._tpOneStopMain.SuspendLayout();
            this._tpTronCli.SuspendLayout();
            this._tpTronSettings.SuspendLayout();
            this._tpLaunchTron.SuspendLayout();
            this._tpSystemInfo.SuspendLayout();
            this._tpConfigurator.SuspendLayout();
            this._tcConfigurator.SuspendLayout();
            this._tpSetup.SuspendLayout();
            this._tabControl2.SuspendLayout();
            this.tpQuickLaunch.SuspendLayout();
            this.tpShopSettings.SuspendLayout();
            this.tpServers.SuspendLayout();
            this.mailGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpNetwork.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tpIntegration.SuspendLayout();
            this.tpLogging.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tsBottomToolbar
            // 
            this._tsBottomToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._tsBottomToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._pbCurrentProgress,
            this._toolStripSeparator1,
            this._lblCurrentActionStatus,
            this.lblAdminStatus,
            this.lblBootStatus,
            this.lblTronStatus});
            this._tsBottomToolbar.Location = new System.Drawing.Point(0, 506);
            this._tsBottomToolbar.Name = "_tsBottomToolbar";
            this._tsBottomToolbar.Size = new System.Drawing.Size(754, 25);
            this._tsBottomToolbar.TabIndex = 0;
            this._tsBottomToolbar.Text = "ts_BottomToolbar";
            // 
            // _pbCurrentProgress
            // 
            this._pbCurrentProgress.Name = "_pbCurrentProgress";
            this._pbCurrentProgress.Size = new System.Drawing.Size(100, 22);
            // 
            // _toolStripSeparator1
            // 
            this._toolStripSeparator1.Name = "_toolStripSeparator1";
            this._toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _lblCurrentActionStatus
            // 
            this._lblCurrentActionStatus.Name = "_lblCurrentActionStatus";
            this._lblCurrentActionStatus.Size = new System.Drawing.Size(0, 22);
            // 
            // lblAdminStatus
            // 
            this.lblAdminStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblAdminStatus.Name = "lblAdminStatus";
            this.lblAdminStatus.Size = new System.Drawing.Size(88, 22);
            this.lblAdminStatus.Text = "lblAdminStatus";
            // 
            // _menuPrimary
            // 
            this._menuPrimary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._qlToolStripMenuItem,
            this._oneStopToolStripMenuItem,
            this._runPromptToolStripMenuItem,
            this._networkToolStripMenuItem,
            this._systemToolStripMenuItem,
            this._techResourcesToolStripMenuItem,
            this._powerToolStripMenuItem,
            this._helpToolStripMenuItem});
            this._menuPrimary.Location = new System.Drawing.Point(0, 0);
            this._menuPrimary.Name = "_menuPrimary";
            this._menuPrimary.Size = new System.Drawing.Size(754, 24);
            this._menuPrimary.TabIndex = 1;
            // 
            // _qlToolStripMenuItem
            // 
            this._qlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._scriptsToolStripMenuItem,
            this._documentsToolStripMenuItem,
            this._toolStripSeparator23});
            this._qlToolStripMenuItem.Name = "_qlToolStripMenuItem";
            this._qlToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this._qlToolStripMenuItem.Text = "QL";
            // 
            // _scriptsToolStripMenuItem
            // 
            this._scriptsToolStripMenuItem.Name = "_scriptsToolStripMenuItem";
            this._scriptsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this._scriptsToolStripMenuItem.Text = "Scripts";
            // 
            // _documentsToolStripMenuItem
            // 
            this._documentsToolStripMenuItem.Name = "_documentsToolStripMenuItem";
            this._documentsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this._documentsToolStripMenuItem.Text = "Documents";
            // 
            // _toolStripSeparator23
            // 
            this._toolStripSeparator23.Name = "_toolStripSeparator23";
            this._toolStripSeparator23.Size = new System.Drawing.Size(149, 6);
            // 
            // _oneStopToolStripMenuItem
            // 
            this._oneStopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._startAtRunToolStripMenuItem,
            this._restartAsAdminToolStripMenuItem,
            this._toolStripSeparator2,
            this._oneStopSettingsToolStripMenuItem,
            this._tRonToolStripMenuItem,
            this._toolStripSeparator22,
            this.oneStopToolGetFileInfoToolStripMenuItem,
            this.toolStripSeparator1,
            this._quitToolStripMenuItem});
            this._oneStopToolStripMenuItem.Name = "_oneStopToolStripMenuItem";
            this._oneStopToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this._oneStopToolStripMenuItem.Text = "OneStop";
            // 
            // _startAtRunToolStripMenuItem
            // 
            this._startAtRunToolStripMenuItem.Name = "_startAtRunToolStripMenuItem";
            this._startAtRunToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this._startAtRunToolStripMenuItem.Text = "Start at Run";
            // 
            // _restartAsAdminToolStripMenuItem
            // 
            this._restartAsAdminToolStripMenuItem.Name = "_restartAsAdminToolStripMenuItem";
            this._restartAsAdminToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this._restartAsAdminToolStripMenuItem.Text = "Restart as Admin";
            // 
            // _toolStripSeparator2
            // 
            this._toolStripSeparator2.Name = "_toolStripSeparator2";
            this._toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // _oneStopSettingsToolStripMenuItem
            // 
            this._oneStopSettingsToolStripMenuItem.Name = "_oneStopSettingsToolStripMenuItem";
            this._oneStopSettingsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this._oneStopSettingsToolStripMenuItem.Text = "OneStop Settings";
            // 
            // _tRonToolStripMenuItem
            // 
            this._tRonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._foldersToolStripMenuItem,
            this._setConfigurationOptionsToolStripMenuItem,
            this._deployTronToNewLocationToolStripMenuItem});
            this._tRonToolStripMenuItem.Name = "_tRonToolStripMenuItem";
            this._tRonToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this._tRonToolStripMenuItem.Text = "TRON Settings";
            // 
            // _foldersToolStripMenuItem
            // 
            this._foldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._prepToolStripMenuItem,
            this._tempcleanToolStripMenuItem,
            this._dToolStripMenuItem,
            this._disinfectToolStripMenuItem,
            this._repairToolStripMenuItem,
            this._patchToolStripMenuItem,
            this._optimizeToolStripMenuItem,
            this._wrapUpToolStripMenuItem,
            this._manualToolsToolStripMenuItem});
            this._foldersToolStripMenuItem.Name = "_foldersToolStripMenuItem";
            this._foldersToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this._foldersToolStripMenuItem.Text = "Folders";
            // 
            // _prepToolStripMenuItem
            // 
            this._prepToolStripMenuItem.Name = "_prepToolStripMenuItem";
            this._prepToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._prepToolStripMenuItem.Text = "0 - Prep";
            this._prepToolStripMenuItem.Click += new System.EventHandler(this._prepToolStripMenuItem_Click);
            // 
            // _tempcleanToolStripMenuItem
            // 
            this._tempcleanToolStripMenuItem.Name = "_tempcleanToolStripMenuItem";
            this._tempcleanToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._tempcleanToolStripMenuItem.Text = "1 - Tempclean";
            this._tempcleanToolStripMenuItem.Click += new System.EventHandler(this._tempcleanToolStripMenuItem_Click);
            // 
            // _dToolStripMenuItem
            // 
            this._dToolStripMenuItem.Name = "_dToolStripMenuItem";
            this._dToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._dToolStripMenuItem.Text = "2 - Debloat";
            this._dToolStripMenuItem.Click += new System.EventHandler(this._dToolStripMenuItem_Click);
            // 
            // _disinfectToolStripMenuItem
            // 
            this._disinfectToolStripMenuItem.Name = "_disinfectToolStripMenuItem";
            this._disinfectToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._disinfectToolStripMenuItem.Text = "3 - Disinfect";
            this._disinfectToolStripMenuItem.Click += new System.EventHandler(this._disinfectToolStripMenuItem_Click);
            // 
            // _repairToolStripMenuItem
            // 
            this._repairToolStripMenuItem.Name = "_repairToolStripMenuItem";
            this._repairToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._repairToolStripMenuItem.Text = "4 - Repair";
            this._repairToolStripMenuItem.Click += new System.EventHandler(this._repairToolStripMenuItem_Click);
            // 
            // _patchToolStripMenuItem
            // 
            this._patchToolStripMenuItem.Name = "_patchToolStripMenuItem";
            this._patchToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._patchToolStripMenuItem.Text = "5 - Patch";
            this._patchToolStripMenuItem.Click += new System.EventHandler(this._patchToolStripMenuItem_Click);
            // 
            // _optimizeToolStripMenuItem
            // 
            this._optimizeToolStripMenuItem.Name = "_optimizeToolStripMenuItem";
            this._optimizeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._optimizeToolStripMenuItem.Text = "6 - Optimize";
            this._optimizeToolStripMenuItem.Click += new System.EventHandler(this._optimizeToolStripMenuItem_Click);
            // 
            // _wrapUpToolStripMenuItem
            // 
            this._wrapUpToolStripMenuItem.Name = "_wrapUpToolStripMenuItem";
            this._wrapUpToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._wrapUpToolStripMenuItem.Text = "7 - Wrap-Up";
            this._wrapUpToolStripMenuItem.Click += new System.EventHandler(this._wrapUpToolStripMenuItem_Click);
            // 
            // _manualToolsToolStripMenuItem
            // 
            this._manualToolsToolStripMenuItem.Name = "_manualToolsToolStripMenuItem";
            this._manualToolsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._manualToolsToolStripMenuItem.Text = "8 - Manual Tools";
            this._manualToolsToolStripMenuItem.Click += new System.EventHandler(this._manualToolsToolStripMenuItem_Click);
            // 
            // _setConfigurationOptionsToolStripMenuItem
            // 
            this._setConfigurationOptionsToolStripMenuItem.Name = "_setConfigurationOptionsToolStripMenuItem";
            this._setConfigurationOptionsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this._setConfigurationOptionsToolStripMenuItem.Text = "Set Configuration Options";
            // 
            // _deployTronToNewLocationToolStripMenuItem
            // 
            this._deployTronToNewLocationToolStripMenuItem.Name = "_deployTronToNewLocationToolStripMenuItem";
            this._deployTronToNewLocationToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this._deployTronToNewLocationToolStripMenuItem.Text = "Deploy TRON to new Location";
            // 
            // _toolStripSeparator22
            // 
            this._toolStripSeparator22.Name = "_toolStripSeparator22";
            this._toolStripSeparator22.Size = new System.Drawing.Size(212, 6);
            // 
            // oneStopToolGetFileInfoToolStripMenuItem
            // 
            this.oneStopToolGetFileInfoToolStripMenuItem.Name = "oneStopToolGetFileInfoToolStripMenuItem";
            this.oneStopToolGetFileInfoToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.oneStopToolGetFileInfoToolStripMenuItem.Text = "OneStop Tool: Get File Info";
            this.oneStopToolGetFileInfoToolStripMenuItem.Click += new System.EventHandler(this.oneStopToolGetFileInfoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // _quitToolStripMenuItem
            // 
            this._quitToolStripMenuItem.Name = "_quitToolStripMenuItem";
            this._quitToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this._quitToolStripMenuItem.Text = "Quit";
            // 
            // _runPromptToolStripMenuItem
            // 
            this._runPromptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._windowsRunCommandToolStripMenuItem,
            this._toolStripSeparator3,
            this._openPowershellToolStripMenuItem,
            this._openElevatedCommandPromptToolStripMenuItem,
            this._openElevatedCommandPromptToPathToolStripMenuItem});
            this._runPromptToolStripMenuItem.Name = "_runPromptToolStripMenuItem";
            this._runPromptToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this._runPromptToolStripMenuItem.Text = "Run/Prompt";
            // 
            // _windowsRunCommandToolStripMenuItem
            // 
            this._windowsRunCommandToolStripMenuItem.Name = "_windowsRunCommandToolStripMenuItem";
            this._windowsRunCommandToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._windowsRunCommandToolStripMenuItem.Text = "Windows Run Command";
            // 
            // _toolStripSeparator3
            // 
            this._toolStripSeparator3.Name = "_toolStripSeparator3";
            this._toolStripSeparator3.Size = new System.Drawing.Size(291, 6);
            // 
            // _openPowershellToolStripMenuItem
            // 
            this._openPowershellToolStripMenuItem.Name = "_openPowershellToolStripMenuItem";
            this._openPowershellToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._openPowershellToolStripMenuItem.Text = "Open Powershell";
            // 
            // _openElevatedCommandPromptToolStripMenuItem
            // 
            this._openElevatedCommandPromptToolStripMenuItem.Name = "_openElevatedCommandPromptToolStripMenuItem";
            this._openElevatedCommandPromptToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._openElevatedCommandPromptToolStripMenuItem.Text = "Open Elevated Command Prompt";
            // 
            // _openElevatedCommandPromptToPathToolStripMenuItem
            // 
            this._openElevatedCommandPromptToPathToolStripMenuItem.Name = "_openElevatedCommandPromptToPathToolStripMenuItem";
            this._openElevatedCommandPromptToPathToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._openElevatedCommandPromptToPathToolStripMenuItem.Text = "Open Elevated Command Prompt to Path";
            // 
            // _networkToolStripMenuItem
            // 
            this._networkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testBrowserToolStripMenuItem,
            this._openRouterInterfaceToolStripMenuItem,
            this._dNsSettingsToolStripMenuItem,
            this._resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem,
            this._toolStripSeparator6,
            this._firewallToolStripMenuItem,
            this._groupPolicyToolStripMenuItem,
            this._toolStripSeparator8,
            this._connectivityToHttpwwwgooglecomToolStripMenuItem,
            this.connectivityToDefaultGatewayToolStripMenuItem,
            this._ipconfigalltoolstripmenuitem,
            this._releaseDhcpToolStripMenuItem,
            this._renewDhcpToolStripMenuItem,
            this._toolStripSeparator9,
            this._resetTcpipToolStripMenuItem,
            this._flushDnsCacheToolStripMenuItem,
            this._flushArpCacheToolStripMenuItem,
            this._flushNetbiosCacheToolStripMenuItem,
            this._restIpv4ToolStripMenuItem,
            this._resteIpv6ToolStripMenuItem,
            this._resetWinsockToolStripMenuItem,
            this._toolStripSeparator10,
            this._netstatToolStripMenuItem,
            this._pingToolStripMenuItem,
            this._openNetworkConnectionsToolStripMenuItem,
            this._storedCredentialsToolStripMenuItem});
            this._networkToolStripMenuItem.Name = "_networkToolStripMenuItem";
            this._networkToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this._networkToolStripMenuItem.Text = "Network";
            // 
            // _openRouterInterfaceToolStripMenuItem
            // 
            this._openRouterInterfaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openAtDefaultGatewayToolStripMenuItem,
            this._openHttprouterpasswordscomToolStripMenuItem,
            this._toolStripSeparator5,
            this._openSavedInterface1XxxxxxxxxxxxToolStripMenuItem,
            this._openSavedInterface2XxxxxxxxxxxxToolStripMenuItem,
            this._toolStripSeparator4,
            this._toolStripMenuItem2,
            this._toolStripMenuItem3,
            this._toolStripMenuItem4,
            this._toolStripMenuItem5,
            this._toolStripMenuItem6,
            this._toolStripMenuItem7,
            this._toolStripMenuItem8,
            this._toolStripMenuItem9,
            this._toolStripMenuItem10,
            this._toolStripMenuItem11,
            this._toolStripMenuItem12});
            this._openRouterInterfaceToolStripMenuItem.Name = "_openRouterInterfaceToolStripMenuItem";
            this._openRouterInterfaceToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._openRouterInterfaceToolStripMenuItem.Text = "Open Router Interface";
            // 
            // _openAtDefaultGatewayToolStripMenuItem
            // 
            this._openAtDefaultGatewayToolStripMenuItem.Name = "_openAtDefaultGatewayToolStripMenuItem";
            this._openAtDefaultGatewayToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this._openAtDefaultGatewayToolStripMenuItem.Text = "Open at Default Gateway";
            // 
            // _openHttprouterpasswordscomToolStripMenuItem
            // 
            this._openHttprouterpasswordscomToolStripMenuItem.Name = "_openHttprouterpasswordscomToolStripMenuItem";
            this._openHttprouterpasswordscomToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this._openHttprouterpasswordscomToolStripMenuItem.Text = "Open http://routerpasswords.com";
            // 
            // _toolStripSeparator5
            // 
            this._toolStripSeparator5.Name = "_toolStripSeparator5";
            this._toolStripSeparator5.Size = new System.Drawing.Size(296, 6);
            // 
            // _openSavedInterface1XxxxxxxxxxxxToolStripMenuItem
            // 
            this._openSavedInterface1XxxxxxxxxxxxToolStripMenuItem.Name = "_openSavedInterface1XxxxxxxxxxxxToolStripMenuItem";
            this._openSavedInterface1XxxxxxxxxxxxToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this._openSavedInterface1XxxxxxxxxxxxToolStripMenuItem.Text = "Open Saved Interface 1 (XXX.XXX.XXX.XXX)";
            // 
            // _openSavedInterface2XxxxxxxxxxxxToolStripMenuItem
            // 
            this._openSavedInterface2XxxxxxxxxxxxToolStripMenuItem.Name = "_openSavedInterface2XxxxxxxxxxxxToolStripMenuItem";
            this._openSavedInterface2XxxxxxxxxxxxToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this._openSavedInterface2XxxxxxxxxxxxToolStripMenuItem.Text = "Open Saved Interface 2 (XXX.XXX.XXX.XXX)";
            // 
            // _toolStripSeparator4
            // 
            this._toolStripSeparator4.Name = "_toolStripSeparator4";
            this._toolStripSeparator4.Size = new System.Drawing.Size(296, 6);
            // 
            // _toolStripMenuItem2
            // 
            this._toolStripMenuItem2.Name = "_toolStripMenuItem2";
            this._toolStripMenuItem2.Size = new System.Drawing.Size(299, 22);
            this._toolStripMenuItem2.Text = "192.168.1.1";
            // 
            // _toolStripMenuItem3
            // 
            this._toolStripMenuItem3.Name = "_toolStripMenuItem3";
            this._toolStripMenuItem3.Size = new System.Drawing.Size(299, 22);
            this._toolStripMenuItem3.Text = "192.168.0.1";
            // 
            // _toolStripMenuItem4
            // 
            this._toolStripMenuItem4.Name = "_toolStripMenuItem4";
            this._toolStripMenuItem4.Size = new System.Drawing.Size(299, 22);
            this._toolStripMenuItem4.Text = "192.168.1.254";
            // 
            // _toolStripMenuItem5
            // 
            this._toolStripMenuItem5.Name = "_toolStripMenuItem5";
            this._toolStripMenuItem5.Size = new System.Drawing.Size(299, 22);
            this._toolStripMenuItem5.Text = "192.168.2.1";
            // 
            // _toolStripMenuItem6
            // 
            this._toolStripMenuItem6.Name = "_toolStripMenuItem6";
            this._toolStripMenuItem6.Size = new System.Drawing.Size(299, 22);
            this._toolStripMenuItem6.Text = "10.0.0.138";
            // 
            // _toolStripMenuItem7
            // 
            this._toolStripMenuItem7.Name = "_toolStripMenuItem7";
            this._toolStripMenuItem7.Size = new System.Drawing.Size(299, 22);
            this._toolStripMenuItem7.Text = "10.0.0.2";
            // 
            // _toolStripMenuItem8
            // 
            this._toolStripMenuItem8.Name = "_toolStripMenuItem8";
            this._toolStripMenuItem8.Size = new System.Drawing.Size(299, 22);
            this._toolStripMenuItem8.Text = "192.168.10.1";
            // 
            // _toolStripMenuItem9
            // 
            this._toolStripMenuItem9.Name = "_toolStripMenuItem9";
            this._toolStripMenuItem9.Size = new System.Drawing.Size(299, 22);
            this._toolStripMenuItem9.Text = "10.0.0.1";
            // 
            // _toolStripMenuItem10
            // 
            this._toolStripMenuItem10.Name = "_toolStripMenuItem10";
            this._toolStripMenuItem10.Size = new System.Drawing.Size(299, 22);
            this._toolStripMenuItem10.Text = "192.168.15.1";
            // 
            // _toolStripMenuItem11
            // 
            this._toolStripMenuItem11.Name = "_toolStripMenuItem11";
            this._toolStripMenuItem11.Size = new System.Drawing.Size(299, 22);
            this._toolStripMenuItem11.Text = "192.168.0.30";
            // 
            // _toolStripMenuItem12
            // 
            this._toolStripMenuItem12.Name = "_toolStripMenuItem12";
            this._toolStripMenuItem12.Size = new System.Drawing.Size(299, 22);
            this._toolStripMenuItem12.Text = "192.168.100.1";
            // 
            // _dNsSettingsToolStripMenuItem
            // 
            this._dNsSettingsToolStripMenuItem.Name = "_dNsSettingsToolStripMenuItem";
            this._dNsSettingsToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._dNsSettingsToolStripMenuItem.Text = "DNS Settings";
            // 
            // _resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem
            // 
            this._resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem.Name = "_resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem";
            this._resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem.Text = "Reset Network Settings to Defaults and Clear All Caches";
            // 
            // _toolStripSeparator6
            // 
            this._toolStripSeparator6.Name = "_toolStripSeparator6";
            this._toolStripSeparator6.Size = new System.Drawing.Size(363, 6);
            // 
            // _firewallToolStripMenuItem
            // 
            this._firewallToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._windowsFirewallAndAdvancedSecurityToolStripMenuItem,
            this._resetFirewallToDefaultnetshFirewallResetToolStripMenuItem,
            this._enableFirewallToolStripMenuItem,
            this._disableFirewallToolStripMenuItem,
            this._toolStripSeparator7,
            this._importFirewallSettingsToolStripMenuItem,
            this._exportFirewallSettingsToolStripMenuItem,
            this._enableRemoteManagementToolStripMenuItem,
            this._enableRemoteDesktopToolStripMenuItem,
            this._enableProgramInFirewallToolStripMenuItem,
            this._enablePortToolStripMenuItem});
            this._firewallToolStripMenuItem.Name = "_firewallToolStripMenuItem";
            this._firewallToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._firewallToolStripMenuItem.Text = "Firewall";
            // 
            // _windowsFirewallAndAdvancedSecurityToolStripMenuItem
            // 
            this._windowsFirewallAndAdvancedSecurityToolStripMenuItem.Name = "_windowsFirewallAndAdvancedSecurityToolStripMenuItem";
            this._windowsFirewallAndAdvancedSecurityToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this._windowsFirewallAndAdvancedSecurityToolStripMenuItem.Text = "Windows Firewall and Advanced Security";
            // 
            // _resetFirewallToDefaultnetshFirewallResetToolStripMenuItem
            // 
            this._resetFirewallToDefaultnetshFirewallResetToolStripMenuItem.Name = "_resetFirewallToDefaultnetshFirewallResetToolStripMenuItem";
            this._resetFirewallToDefaultnetshFirewallResetToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this._resetFirewallToDefaultnetshFirewallResetToolStripMenuItem.Text = "Reset Firewall to Default";
            // 
            // _enableFirewallToolStripMenuItem
            // 
            this._enableFirewallToolStripMenuItem.Name = "_enableFirewallToolStripMenuItem";
            this._enableFirewallToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this._enableFirewallToolStripMenuItem.Text = "Enable Firewall";
            // 
            // _disableFirewallToolStripMenuItem
            // 
            this._disableFirewallToolStripMenuItem.Name = "_disableFirewallToolStripMenuItem";
            this._disableFirewallToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this._disableFirewallToolStripMenuItem.Text = "Disable Firewall";
            // 
            // _toolStripSeparator7
            // 
            this._toolStripSeparator7.Name = "_toolStripSeparator7";
            this._toolStripSeparator7.Size = new System.Drawing.Size(287, 6);
            // 
            // _importFirewallSettingsToolStripMenuItem
            // 
            this._importFirewallSettingsToolStripMenuItem.Name = "_importFirewallSettingsToolStripMenuItem";
            this._importFirewallSettingsToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this._importFirewallSettingsToolStripMenuItem.Text = "Import Firewall Settings";
            // 
            // _exportFirewallSettingsToolStripMenuItem
            // 
            this._exportFirewallSettingsToolStripMenuItem.Name = "_exportFirewallSettingsToolStripMenuItem";
            this._exportFirewallSettingsToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this._exportFirewallSettingsToolStripMenuItem.Text = "Export Firewall Settings";
            // 
            // _enableRemoteManagementToolStripMenuItem
            // 
            this._enableRemoteManagementToolStripMenuItem.Name = "_enableRemoteManagementToolStripMenuItem";
            this._enableRemoteManagementToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this._enableRemoteManagementToolStripMenuItem.Text = "Enable Remote Management";
            // 
            // _enableRemoteDesktopToolStripMenuItem
            // 
            this._enableRemoteDesktopToolStripMenuItem.Name = "_enableRemoteDesktopToolStripMenuItem";
            this._enableRemoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this._enableRemoteDesktopToolStripMenuItem.Text = "Enable Remote Desktop";
            // 
            // _enableProgramInFirewallToolStripMenuItem
            // 
            this._enableProgramInFirewallToolStripMenuItem.Name = "_enableProgramInFirewallToolStripMenuItem";
            this._enableProgramInFirewallToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this._enableProgramInFirewallToolStripMenuItem.Text = "Enable a Program";
            // 
            // _enablePortToolStripMenuItem
            // 
            this._enablePortToolStripMenuItem.Name = "_enablePortToolStripMenuItem";
            this._enablePortToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this._enablePortToolStripMenuItem.Text = "Enable a Port";
            // 
            // _groupPolicyToolStripMenuItem
            // 
            this._groupPolicyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._getGroupPolicyReportToolStripMenuItem,
            this._forceRefreshToolStripMenuItem,
            this._openGroupPolicyEditorToolStripMenuItem});
            this._groupPolicyToolStripMenuItem.Name = "_groupPolicyToolStripMenuItem";
            this._groupPolicyToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._groupPolicyToolStripMenuItem.Text = "Group Policy";
            // 
            // _getGroupPolicyReportToolStripMenuItem
            // 
            this._getGroupPolicyReportToolStripMenuItem.Name = "_getGroupPolicyReportToolStripMenuItem";
            this._getGroupPolicyReportToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._getGroupPolicyReportToolStripMenuItem.Text = "Get Group Policy Report";
            // 
            // _forceRefreshToolStripMenuItem
            // 
            this._forceRefreshToolStripMenuItem.Name = "_forceRefreshToolStripMenuItem";
            this._forceRefreshToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._forceRefreshToolStripMenuItem.Text = "Force Refresh";
            // 
            // _openGroupPolicyEditorToolStripMenuItem
            // 
            this._openGroupPolicyEditorToolStripMenuItem.Name = "_openGroupPolicyEditorToolStripMenuItem";
            this._openGroupPolicyEditorToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this._openGroupPolicyEditorToolStripMenuItem.Text = "Open Group Policy Editor";
            // 
            // _toolStripSeparator8
            // 
            this._toolStripSeparator8.Name = "_toolStripSeparator8";
            this._toolStripSeparator8.Size = new System.Drawing.Size(363, 6);
            // 
            // _connectivityToHttpwwwgooglecomToolStripMenuItem
            // 
            this._connectivityToHttpwwwgooglecomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._pingIp4ToolStripMenuItem,
            this._pringIp6ToolStripMenuItem,
            this._traceRouteToolStripMenuItem,
            this._pingPathIp4ToolStripMenuItem,
            this._pingPathIp6ToolStripMenuItem});
            this._connectivityToHttpwwwgooglecomToolStripMenuItem.Name = "_connectivityToHttpwwwgooglecomToolStripMenuItem";
            this._connectivityToHttpwwwgooglecomToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._connectivityToHttpwwwgooglecomToolStripMenuItem.Text = "Connectivity to http://www.google.com";
            // 
            // _pingIp4ToolStripMenuItem
            // 
            this._pingIp4ToolStripMenuItem.Name = "_pingIp4ToolStripMenuItem";
            this._pingIp4ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this._pingIp4ToolStripMenuItem.Text = "Ping (IP4)";
            // 
            // _pringIp6ToolStripMenuItem
            // 
            this._pringIp6ToolStripMenuItem.Name = "_pringIp6ToolStripMenuItem";
            this._pringIp6ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this._pringIp6ToolStripMenuItem.Text = "Pring (IP6)";
            // 
            // _traceRouteToolStripMenuItem
            // 
            this._traceRouteToolStripMenuItem.Name = "_traceRouteToolStripMenuItem";
            this._traceRouteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this._traceRouteToolStripMenuItem.Text = "Trace Route";
            // 
            // _pingPathIp4ToolStripMenuItem
            // 
            this._pingPathIp4ToolStripMenuItem.Name = "_pingPathIp4ToolStripMenuItem";
            this._pingPathIp4ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this._pingPathIp4ToolStripMenuItem.Text = "Ping Path (IP4)";
            // 
            // _pingPathIp6ToolStripMenuItem
            // 
            this._pingPathIp6ToolStripMenuItem.Name = "_pingPathIp6ToolStripMenuItem";
            this._pingPathIp6ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this._pingPathIp6ToolStripMenuItem.Text = "Ping Path (IP 6)";
            // 
            // _ipconfigalltoolstripmenuitem
            // 
            this._ipconfigalltoolstripmenuitem.Name = "_ipconfigalltoolstripmenuitem";
            this._ipconfigalltoolstripmenuitem.Size = new System.Drawing.Size(366, 22);
            this._ipconfigalltoolstripmenuitem.Text = "Show all IP Info";
            this._ipconfigalltoolstripmenuitem.Click += new System.EventHandler(this._ipconfigalltoolstripmenuitem_Click);
            // 
            // _releaseDhcpToolStripMenuItem
            // 
            this._releaseDhcpToolStripMenuItem.Name = "_releaseDhcpToolStripMenuItem";
            this._releaseDhcpToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._releaseDhcpToolStripMenuItem.Text = "Release DHCP";
            // 
            // _renewDhcpToolStripMenuItem
            // 
            this._renewDhcpToolStripMenuItem.Name = "_renewDhcpToolStripMenuItem";
            this._renewDhcpToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._renewDhcpToolStripMenuItem.Text = "Renew DHCP";
            // 
            // _toolStripSeparator9
            // 
            this._toolStripSeparator9.Name = "_toolStripSeparator9";
            this._toolStripSeparator9.Size = new System.Drawing.Size(363, 6);
            // 
            // _resetTcpipToolStripMenuItem
            // 
            this._resetTcpipToolStripMenuItem.Name = "_resetTcpipToolStripMenuItem";
            this._resetTcpipToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._resetTcpipToolStripMenuItem.Text = "Reset TCP/IP";
            // 
            // _flushDnsCacheToolStripMenuItem
            // 
            this._flushDnsCacheToolStripMenuItem.Name = "_flushDnsCacheToolStripMenuItem";
            this._flushDnsCacheToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._flushDnsCacheToolStripMenuItem.Text = "Flush DNS Cache";
            // 
            // _flushArpCacheToolStripMenuItem
            // 
            this._flushArpCacheToolStripMenuItem.Name = "_flushArpCacheToolStripMenuItem";
            this._flushArpCacheToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._flushArpCacheToolStripMenuItem.Text = "Flush ARP Cache";
            // 
            // _flushNetbiosCacheToolStripMenuItem
            // 
            this._flushNetbiosCacheToolStripMenuItem.Name = "_flushNetbiosCacheToolStripMenuItem";
            this._flushNetbiosCacheToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._flushNetbiosCacheToolStripMenuItem.Text = "Flush NetBIOS Cache";
            // 
            // _restIpv4ToolStripMenuItem
            // 
            this._restIpv4ToolStripMenuItem.Name = "_restIpv4ToolStripMenuItem";
            this._restIpv4ToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._restIpv4ToolStripMenuItem.Text = "Reset IPV4";
            // 
            // _resteIpv6ToolStripMenuItem
            // 
            this._resteIpv6ToolStripMenuItem.Name = "_resteIpv6ToolStripMenuItem";
            this._resteIpv6ToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._resteIpv6ToolStripMenuItem.Text = "Reset IPV6";
            // 
            // _resetWinsockToolStripMenuItem
            // 
            this._resetWinsockToolStripMenuItem.Name = "_resetWinsockToolStripMenuItem";
            this._resetWinsockToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._resetWinsockToolStripMenuItem.Text = "Reset Winsock";
            // 
            // _toolStripSeparator10
            // 
            this._toolStripSeparator10.Name = "_toolStripSeparator10";
            this._toolStripSeparator10.Size = new System.Drawing.Size(363, 6);
            // 
            // _netstatToolStripMenuItem
            // 
            this._netstatToolStripMenuItem.Name = "_netstatToolStripMenuItem";
            this._netstatToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._netstatToolStripMenuItem.Text = "Netstat";
            // 
            // _pingToolStripMenuItem
            // 
            this._pingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ownIpip4ToolStripMenuItem,
            this._loopbackIp4ToolStripMenuItem,
            this._gatewayIp4ToolStripMenuItem,
            this._otherIp4ToolStripMenuItem});
            this._pingToolStripMenuItem.Name = "_pingToolStripMenuItem";
            this._pingToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._pingToolStripMenuItem.Text = "Ping";
            // 
            // _ownIpip4ToolStripMenuItem
            // 
            this._ownIpip4ToolStripMenuItem.Name = "_ownIpip4ToolStripMenuItem";
            this._ownIpip4ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this._ownIpip4ToolStripMenuItem.Text = "Own IP (IP4)";
            // 
            // _loopbackIp4ToolStripMenuItem
            // 
            this._loopbackIp4ToolStripMenuItem.Name = "_loopbackIp4ToolStripMenuItem";
            this._loopbackIp4ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this._loopbackIp4ToolStripMenuItem.Text = "Loopback (IP4)";
            // 
            // _gatewayIp4ToolStripMenuItem
            // 
            this._gatewayIp4ToolStripMenuItem.Name = "_gatewayIp4ToolStripMenuItem";
            this._gatewayIp4ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this._gatewayIp4ToolStripMenuItem.Text = "Gateway (IP4)";
            // 
            // _otherIp4ToolStripMenuItem
            // 
            this._otherIp4ToolStripMenuItem.Name = "_otherIp4ToolStripMenuItem";
            this._otherIp4ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this._otherIp4ToolStripMenuItem.Text = "Other (IP4)";
            // 
            // _openNetworkConnectionsToolStripMenuItem
            // 
            this._openNetworkConnectionsToolStripMenuItem.Name = "_openNetworkConnectionsToolStripMenuItem";
            this._openNetworkConnectionsToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._openNetworkConnectionsToolStripMenuItem.Text = "Open Network Connections";
            // 
            // _storedCredentialsToolStripMenuItem
            // 
            this._storedCredentialsToolStripMenuItem.Name = "_storedCredentialsToolStripMenuItem";
            this._storedCredentialsToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._storedCredentialsToolStripMenuItem.Text = "Stored Credentials";
            // 
            // _systemToolStripMenuItem
            // 
            this._systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._systemFoldersToolStripMenuItem,
            this._toolStripSeparator12,
            this._controlPanelObjectsToolStripMenuItem,
            this._desktopGodmodeFolderToolStripMenuItem,
            this._diskManagementToolsToolStripMenuItem,
            this._mSconfigToolStripMenuItem,
            this._systemRestoreToolStripMenuItem,
            this._usersToolStripMenuItem,
            this._toolStripSeparator11,
            this._computerManagementToolStripMenuItem,
            this._componantServicesToolStripMenuItem,
            this._dataSourcesOdbcToolStripMenuItem,
            this._deviceManagerToolStripMenuItem,
            this._directXDiagnosticsToolStripMenuItem,
            this._driverVerifierToolStripMenuItem,
            this._eventViewerToolStripMenuItem,
            this._groupPolicyEditorToolStripMenuItem,
            this._localSecurityPolicyToolStripMenuItem,
            this._performanceMonitorToolStripMenuItem,
            this._printManagementToolStripMenuItem,
            this._registryEditorToolStripMenuItem,
            this._servicesToolStripMenuItem,
            this._sharedFoldersToolStripMenuItem,
            this._taskSchedulerToolStripMenuItem,
            this._windowsMemoryDiagnosticToolStripMenuItem,
            this._wMiTesterToolStripMenuItem,
            this._windowsUpdatesToolStripMenuItem,
            this._windowsVersionToolStripMenuItem,
            this._windowsSecurityCenterToolStripMenuItem});
            this._systemToolStripMenuItem.Name = "_systemToolStripMenuItem";
            this._systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this._systemToolStripMenuItem.Text = "System";
            // 
            // _systemFoldersToolStripMenuItem
            // 
            this._systemFoldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._desktopToolStripMenuItem,
            this._userProfilesToolStripMenuItem,
            this._programFilesToolStripMenuItem,
            this._programFilesx86ToolStripMenuItem,
            this._windowsToolStripMenuItem});
            this._systemFoldersToolStripMenuItem.Name = "_systemFoldersToolStripMenuItem";
            this._systemFoldersToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._systemFoldersToolStripMenuItem.Text = "System Folders";
            // 
            // _desktopToolStripMenuItem
            // 
            this._desktopToolStripMenuItem.Name = "_desktopToolStripMenuItem";
            this._desktopToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this._desktopToolStripMenuItem.Text = "Desktop";
            // 
            // _userProfilesToolStripMenuItem
            // 
            this._userProfilesToolStripMenuItem.Name = "_userProfilesToolStripMenuItem";
            this._userProfilesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this._userProfilesToolStripMenuItem.Text = "User Profiles";
            // 
            // _programFilesToolStripMenuItem
            // 
            this._programFilesToolStripMenuItem.Name = "_programFilesToolStripMenuItem";
            this._programFilesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this._programFilesToolStripMenuItem.Text = "Program Files";
            // 
            // _programFilesx86ToolStripMenuItem
            // 
            this._programFilesx86ToolStripMenuItem.Name = "_programFilesx86ToolStripMenuItem";
            this._programFilesx86ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this._programFilesx86ToolStripMenuItem.Text = "Program Files (x86)";
            // 
            // _windowsToolStripMenuItem
            // 
            this._windowsToolStripMenuItem.Name = "_windowsToolStripMenuItem";
            this._windowsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this._windowsToolStripMenuItem.Text = "Windows";
            // 
            // _toolStripSeparator12
            // 
            this._toolStripSeparator12.Name = "_toolStripSeparator12";
            this._toolStripSeparator12.Size = new System.Drawing.Size(227, 6);
            // 
            // _controlPanelObjectsToolStripMenuItem
            // 
            this._controlPanelObjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mainToolStripMenuItem,
            this._toolStripSeparator13,
            this._accessibilityToolStripMenuItem,
            this._addNewHardwareToolStripMenuItem,
            this._addRemoveProgramsToolStripMenuItem,
            this._dateTimeToolStripMenuItem,
            this._displayToolStripMenuItem,
            this._findFastToolStripMenuItem,
            this._fontsToolStripMenuItem,
            this._internetPropertiesToolStripMenuItem,
            this._joystickToolStripMenuItem,
            this._keyboardToolStripMenuItem,
            this._exchangeToolStripMenuItem,
            this._microsoftMailPostOfficeToolStripMenuItem,
            this._modemToolStripMenuItem,
            this._mouseToolStripMenuItem,
            this._multimediaToolStripMenuItem,
            this._networkToolStripMenuItem1,
            this._passwordToolStripMenuItem,
            this._pCCardToolStripMenuItem,
            this._powerManagementToolStripMenuItem,
            this._printersToolStripMenuItem,
            this._regionalSettingsToolStripMenuItem,
            this._scannersAndCamerasToolStripMenuItem,
            this._soundToolStripMenuItem,
            this._systemToolStripMenuItem1});
            this._controlPanelObjectsToolStripMenuItem.Name = "_controlPanelObjectsToolStripMenuItem";
            this._controlPanelObjectsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._controlPanelObjectsToolStripMenuItem.Text = "Control Panel Objects";
            // 
            // _mainToolStripMenuItem
            // 
            this._mainToolStripMenuItem.Name = "_mainToolStripMenuItem";
            this._mainToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._mainToolStripMenuItem.Text = "Main";
            // 
            // _toolStripSeparator13
            // 
            this._toolStripSeparator13.Name = "_toolStripSeparator13";
            this._toolStripSeparator13.Size = new System.Drawing.Size(209, 6);
            // 
            // _accessibilityToolStripMenuItem
            // 
            this._accessibilityToolStripMenuItem.Name = "_accessibilityToolStripMenuItem";
            this._accessibilityToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._accessibilityToolStripMenuItem.Text = "Accessibility";
            // 
            // _addNewHardwareToolStripMenuItem
            // 
            this._addNewHardwareToolStripMenuItem.Name = "_addNewHardwareToolStripMenuItem";
            this._addNewHardwareToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._addNewHardwareToolStripMenuItem.Text = "Add New Hardware";
            // 
            // _addRemoveProgramsToolStripMenuItem
            // 
            this._addRemoveProgramsToolStripMenuItem.Name = "_addRemoveProgramsToolStripMenuItem";
            this._addRemoveProgramsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._addRemoveProgramsToolStripMenuItem.Text = "Add/Remove Programs";
            // 
            // _dateTimeToolStripMenuItem
            // 
            this._dateTimeToolStripMenuItem.Name = "_dateTimeToolStripMenuItem";
            this._dateTimeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._dateTimeToolStripMenuItem.Text = "Date/Time";
            // 
            // _displayToolStripMenuItem
            // 
            this._displayToolStripMenuItem.Name = "_displayToolStripMenuItem";
            this._displayToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._displayToolStripMenuItem.Text = "Display";
            // 
            // _findFastToolStripMenuItem
            // 
            this._findFastToolStripMenuItem.Name = "_findFastToolStripMenuItem";
            this._findFastToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._findFastToolStripMenuItem.Text = "FindFast";
            // 
            // _fontsToolStripMenuItem
            // 
            this._fontsToolStripMenuItem.Name = "_fontsToolStripMenuItem";
            this._fontsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._fontsToolStripMenuItem.Text = "Fonts";
            // 
            // _internetPropertiesToolStripMenuItem
            // 
            this._internetPropertiesToolStripMenuItem.Name = "_internetPropertiesToolStripMenuItem";
            this._internetPropertiesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._internetPropertiesToolStripMenuItem.Text = "Internet Properties";
            // 
            // _joystickToolStripMenuItem
            // 
            this._joystickToolStripMenuItem.Name = "_joystickToolStripMenuItem";
            this._joystickToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._joystickToolStripMenuItem.Text = "Joystick";
            // 
            // _keyboardToolStripMenuItem
            // 
            this._keyboardToolStripMenuItem.Name = "_keyboardToolStripMenuItem";
            this._keyboardToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._keyboardToolStripMenuItem.Text = "Keyboard";
            // 
            // _exchangeToolStripMenuItem
            // 
            this._exchangeToolStripMenuItem.Name = "_exchangeToolStripMenuItem";
            this._exchangeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._exchangeToolStripMenuItem.Text = "Exchange";
            // 
            // _microsoftMailPostOfficeToolStripMenuItem
            // 
            this._microsoftMailPostOfficeToolStripMenuItem.Name = "_microsoftMailPostOfficeToolStripMenuItem";
            this._microsoftMailPostOfficeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._microsoftMailPostOfficeToolStripMenuItem.Text = "Microsoft Mail Post Office";
            // 
            // _modemToolStripMenuItem
            // 
            this._modemToolStripMenuItem.Name = "_modemToolStripMenuItem";
            this._modemToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._modemToolStripMenuItem.Text = "Modem";
            // 
            // _mouseToolStripMenuItem
            // 
            this._mouseToolStripMenuItem.Name = "_mouseToolStripMenuItem";
            this._mouseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._mouseToolStripMenuItem.Text = "Mouse";
            // 
            // _multimediaToolStripMenuItem
            // 
            this._multimediaToolStripMenuItem.Name = "_multimediaToolStripMenuItem";
            this._multimediaToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._multimediaToolStripMenuItem.Text = "Multimedia";
            // 
            // _networkToolStripMenuItem1
            // 
            this._networkToolStripMenuItem1.Name = "_networkToolStripMenuItem1";
            this._networkToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this._networkToolStripMenuItem1.Text = "Network";
            // 
            // _passwordToolStripMenuItem
            // 
            this._passwordToolStripMenuItem.Name = "_passwordToolStripMenuItem";
            this._passwordToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._passwordToolStripMenuItem.Text = "Password";
            // 
            // _pCCardToolStripMenuItem
            // 
            this._pCCardToolStripMenuItem.Name = "_pCCardToolStripMenuItem";
            this._pCCardToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._pCCardToolStripMenuItem.Text = "PC Card";
            // 
            // _powerManagementToolStripMenuItem
            // 
            this._powerManagementToolStripMenuItem.Name = "_powerManagementToolStripMenuItem";
            this._powerManagementToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._powerManagementToolStripMenuItem.Text = "Power Management";
            // 
            // _printersToolStripMenuItem
            // 
            this._printersToolStripMenuItem.Name = "_printersToolStripMenuItem";
            this._printersToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._printersToolStripMenuItem.Text = "Printers";
            // 
            // _regionalSettingsToolStripMenuItem
            // 
            this._regionalSettingsToolStripMenuItem.Name = "_regionalSettingsToolStripMenuItem";
            this._regionalSettingsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._regionalSettingsToolStripMenuItem.Text = "Regional Settings";
            // 
            // _scannersAndCamerasToolStripMenuItem
            // 
            this._scannersAndCamerasToolStripMenuItem.Name = "_scannersAndCamerasToolStripMenuItem";
            this._scannersAndCamerasToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._scannersAndCamerasToolStripMenuItem.Text = "Scanners and Cameras";
            // 
            // _soundToolStripMenuItem
            // 
            this._soundToolStripMenuItem.Name = "_soundToolStripMenuItem";
            this._soundToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._soundToolStripMenuItem.Text = "Sound";
            // 
            // _systemToolStripMenuItem1
            // 
            this._systemToolStripMenuItem1.Name = "_systemToolStripMenuItem1";
            this._systemToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this._systemToolStripMenuItem1.Text = "System";
            // 
            // _desktopGodmodeFolderToolStripMenuItem
            // 
            this._desktopGodmodeFolderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._createLeaveAfterQuitToolStripMenuItem,
            this._createDestroyOnQuitToolStripMenuItem});
            this._desktopGodmodeFolderToolStripMenuItem.Name = "_desktopGodmodeFolderToolStripMenuItem";
            this._desktopGodmodeFolderToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._desktopGodmodeFolderToolStripMenuItem.Text = "Desktop \"Godmode\" Folder";
            // 
            // _createLeaveAfterQuitToolStripMenuItem
            // 
            this._createLeaveAfterQuitToolStripMenuItem.Name = "_createLeaveAfterQuitToolStripMenuItem";
            this._createLeaveAfterQuitToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this._createLeaveAfterQuitToolStripMenuItem.Text = "Create/Open (Leave on Quit)";
            // 
            // _createDestroyOnQuitToolStripMenuItem
            // 
            this._createDestroyOnQuitToolStripMenuItem.Name = "_createDestroyOnQuitToolStripMenuItem";
            this._createDestroyOnQuitToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this._createDestroyOnQuitToolStripMenuItem.Text = "Create/Open (Destroy on Quit)";
            // 
            // _diskManagementToolsToolStripMenuItem
            // 
            this._diskManagementToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._checkDiskToolStripMenuItem,
            this._defragSystemToolStripMenuItem,
            this._defragDefragglerToolStripMenuItem,
            this._diskManagmentToolStripMenuItem,
            this._driveCleanupUtilityToolStripMenuItem,
            this._partitionsToolStripMenuItem});
            this._diskManagementToolsToolStripMenuItem.Name = "_diskManagementToolsToolStripMenuItem";
            this._diskManagementToolsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._diskManagementToolsToolStripMenuItem.Text = "Disk Management Tools";
            // 
            // _checkDiskToolStripMenuItem
            // 
            this._checkDiskToolStripMenuItem.Name = "_checkDiskToolStripMenuItem";
            this._checkDiskToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this._checkDiskToolStripMenuItem.Text = "Check Disk";
            // 
            // _defragSystemToolStripMenuItem
            // 
            this._defragSystemToolStripMenuItem.Name = "_defragSystemToolStripMenuItem";
            this._defragSystemToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this._defragSystemToolStripMenuItem.Text = "Defrag (System)";
            // 
            // _defragDefragglerToolStripMenuItem
            // 
            this._defragDefragglerToolStripMenuItem.Name = "_defragDefragglerToolStripMenuItem";
            this._defragDefragglerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this._defragDefragglerToolStripMenuItem.Text = "Defrag (Defraggler)";
            // 
            // _diskManagmentToolStripMenuItem
            // 
            this._diskManagmentToolStripMenuItem.Name = "_diskManagmentToolStripMenuItem";
            this._diskManagmentToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this._diskManagmentToolStripMenuItem.Text = "Disk Managment";
            // 
            // _driveCleanupUtilityToolStripMenuItem
            // 
            this._driveCleanupUtilityToolStripMenuItem.Name = "_driveCleanupUtilityToolStripMenuItem";
            this._driveCleanupUtilityToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this._driveCleanupUtilityToolStripMenuItem.Text = "Drive Cleanup Utility";
            // 
            // _partitionsToolStripMenuItem
            // 
            this._partitionsToolStripMenuItem.Name = "_partitionsToolStripMenuItem";
            this._partitionsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this._partitionsToolStripMenuItem.Text = "Partitions";
            // 
            // _mSconfigToolStripMenuItem
            // 
            this._mSconfigToolStripMenuItem.Name = "_mSconfigToolStripMenuItem";
            this._mSconfigToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._mSconfigToolStripMenuItem.Text = "MSCONFIG";
            // 
            // _systemRestoreToolStripMenuItem
            // 
            this._systemRestoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._createRestorePointToolStripMenuItem,
            this._openRestorePointToolStripMenuItem});
            this._systemRestoreToolStripMenuItem.Name = "_systemRestoreToolStripMenuItem";
            this._systemRestoreToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._systemRestoreToolStripMenuItem.Text = "System Restore";
            // 
            // _createRestorePointToolStripMenuItem
            // 
            this._createRestorePointToolStripMenuItem.Name = "_createRestorePointToolStripMenuItem";
            this._createRestorePointToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this._createRestorePointToolStripMenuItem.Text = "Create Restore Point";
            // 
            // _openRestorePointToolStripMenuItem
            // 
            this._openRestorePointToolStripMenuItem.Name = "_openRestorePointToolStripMenuItem";
            this._openRestorePointToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this._openRestorePointToolStripMenuItem.Text = "Open Restore Point";
            // 
            // _usersToolStripMenuItem
            // 
            this._usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._accountsToolStripMenuItem,
            this._advancedAccountsToolStripMenuItem,
            this._autoLogonOptionsToolStripMenuItem,
            this._uAcSettingsToolStripMenuItem});
            this._usersToolStripMenuItem.Name = "_usersToolStripMenuItem";
            this._usersToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._usersToolStripMenuItem.Text = "Users";
            // 
            // _accountsToolStripMenuItem
            // 
            this._accountsToolStripMenuItem.Name = "_accountsToolStripMenuItem";
            this._accountsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this._accountsToolStripMenuItem.Text = "Accounts";
            // 
            // _advancedAccountsToolStripMenuItem
            // 
            this._advancedAccountsToolStripMenuItem.Name = "_advancedAccountsToolStripMenuItem";
            this._advancedAccountsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this._advancedAccountsToolStripMenuItem.Text = "Advanced Accounts";
            // 
            // _autoLogonOptionsToolStripMenuItem
            // 
            this._autoLogonOptionsToolStripMenuItem.Name = "_autoLogonOptionsToolStripMenuItem";
            this._autoLogonOptionsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this._autoLogonOptionsToolStripMenuItem.Text = "Auto Logon Options";
            // 
            // _uAcSettingsToolStripMenuItem
            // 
            this._uAcSettingsToolStripMenuItem.Name = "_uAcSettingsToolStripMenuItem";
            this._uAcSettingsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this._uAcSettingsToolStripMenuItem.Text = "UAC Settings";
            // 
            // _toolStripSeparator11
            // 
            this._toolStripSeparator11.Name = "_toolStripSeparator11";
            this._toolStripSeparator11.Size = new System.Drawing.Size(227, 6);
            // 
            // _computerManagementToolStripMenuItem
            // 
            this._computerManagementToolStripMenuItem.Name = "_computerManagementToolStripMenuItem";
            this._computerManagementToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._computerManagementToolStripMenuItem.Text = "Computer Management";
            // 
            // _componantServicesToolStripMenuItem
            // 
            this._componantServicesToolStripMenuItem.Name = "_componantServicesToolStripMenuItem";
            this._componantServicesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._componantServicesToolStripMenuItem.Text = "Componant Services";
            // 
            // _dataSourcesOdbcToolStripMenuItem
            // 
            this._dataSourcesOdbcToolStripMenuItem.Name = "_dataSourcesOdbcToolStripMenuItem";
            this._dataSourcesOdbcToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._dataSourcesOdbcToolStripMenuItem.Text = "Data Sources (ODBC)";
            // 
            // _deviceManagerToolStripMenuItem
            // 
            this._deviceManagerToolStripMenuItem.Name = "_deviceManagerToolStripMenuItem";
            this._deviceManagerToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._deviceManagerToolStripMenuItem.Text = "Device Manager";
            // 
            // _directXDiagnosticsToolStripMenuItem
            // 
            this._directXDiagnosticsToolStripMenuItem.Name = "_directXDiagnosticsToolStripMenuItem";
            this._directXDiagnosticsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._directXDiagnosticsToolStripMenuItem.Text = "Direct X Diagnostics";
            // 
            // _driverVerifierToolStripMenuItem
            // 
            this._driverVerifierToolStripMenuItem.Name = "_driverVerifierToolStripMenuItem";
            this._driverVerifierToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._driverVerifierToolStripMenuItem.Text = "Driver Verifier";
            // 
            // _eventViewerToolStripMenuItem
            // 
            this._eventViewerToolStripMenuItem.Name = "_eventViewerToolStripMenuItem";
            this._eventViewerToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._eventViewerToolStripMenuItem.Text = "Event Viewer";
            // 
            // _groupPolicyEditorToolStripMenuItem
            // 
            this._groupPolicyEditorToolStripMenuItem.Name = "_groupPolicyEditorToolStripMenuItem";
            this._groupPolicyEditorToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._groupPolicyEditorToolStripMenuItem.Text = "Group Policy Editor";
            // 
            // _localSecurityPolicyToolStripMenuItem
            // 
            this._localSecurityPolicyToolStripMenuItem.Name = "_localSecurityPolicyToolStripMenuItem";
            this._localSecurityPolicyToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._localSecurityPolicyToolStripMenuItem.Text = "Local Security Policy";
            // 
            // _performanceMonitorToolStripMenuItem
            // 
            this._performanceMonitorToolStripMenuItem.Name = "_performanceMonitorToolStripMenuItem";
            this._performanceMonitorToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._performanceMonitorToolStripMenuItem.Text = "Performance Monitor";
            // 
            // _printManagementToolStripMenuItem
            // 
            this._printManagementToolStripMenuItem.Name = "_printManagementToolStripMenuItem";
            this._printManagementToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._printManagementToolStripMenuItem.Text = "Print Management";
            // 
            // _registryEditorToolStripMenuItem
            // 
            this._registryEditorToolStripMenuItem.Name = "_registryEditorToolStripMenuItem";
            this._registryEditorToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._registryEditorToolStripMenuItem.Text = "Registry Editor";
            // 
            // _servicesToolStripMenuItem
            // 
            this._servicesToolStripMenuItem.Name = "_servicesToolStripMenuItem";
            this._servicesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._servicesToolStripMenuItem.Text = "Services";
            // 
            // _sharedFoldersToolStripMenuItem
            // 
            this._sharedFoldersToolStripMenuItem.Name = "_sharedFoldersToolStripMenuItem";
            this._sharedFoldersToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._sharedFoldersToolStripMenuItem.Text = "Shared Folders";
            // 
            // _taskSchedulerToolStripMenuItem
            // 
            this._taskSchedulerToolStripMenuItem.Name = "_taskSchedulerToolStripMenuItem";
            this._taskSchedulerToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._taskSchedulerToolStripMenuItem.Text = "Task Scheduler";
            // 
            // _windowsMemoryDiagnosticToolStripMenuItem
            // 
            this._windowsMemoryDiagnosticToolStripMenuItem.Name = "_windowsMemoryDiagnosticToolStripMenuItem";
            this._windowsMemoryDiagnosticToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._windowsMemoryDiagnosticToolStripMenuItem.Text = "Windows Memory Diagnostic";
            // 
            // _wMiTesterToolStripMenuItem
            // 
            this._wMiTesterToolStripMenuItem.Name = "_wMiTesterToolStripMenuItem";
            this._wMiTesterToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._wMiTesterToolStripMenuItem.Text = "WMI Tester";
            // 
            // _windowsUpdatesToolStripMenuItem
            // 
            this._windowsUpdatesToolStripMenuItem.Name = "_windowsUpdatesToolStripMenuItem";
            this._windowsUpdatesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._windowsUpdatesToolStripMenuItem.Text = "Windows Updates";
            // 
            // _windowsVersionToolStripMenuItem
            // 
            this._windowsVersionToolStripMenuItem.Name = "_windowsVersionToolStripMenuItem";
            this._windowsVersionToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._windowsVersionToolStripMenuItem.Text = "Windows Version";
            // 
            // _windowsSecurityCenterToolStripMenuItem
            // 
            this._windowsSecurityCenterToolStripMenuItem.Name = "_windowsSecurityCenterToolStripMenuItem";
            this._windowsSecurityCenterToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._windowsSecurityCenterToolStripMenuItem.Text = "Windows Security Center";
            // 
            // _techResourcesToolStripMenuItem
            // 
            this._techResourcesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._rOneStopItToolStripMenuItem,
            this._rTronScriptToolStripMenuItem,
            this._ninitecomToolStripMenuItem,
            this._techWebsitesToolStripMenuItem,
            this._browserTestingToolStripMenuItem,
            this._virusScannerRemovalToolsToolStripMenuItem});
            this._techResourcesToolStripMenuItem.Name = "_techResourcesToolStripMenuItem";
            this._techResourcesToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this._techResourcesToolStripMenuItem.Text = "Tech Resources";
            // 
            // _rOneStopItToolStripMenuItem
            // 
            this._rOneStopItToolStripMenuItem.Name = "_rOneStopItToolStripMenuItem";
            this._rOneStopItToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this._rOneStopItToolStripMenuItem.Text = "/r/OneStopIT";
            this._rOneStopItToolStripMenuItem.Click += new System.EventHandler(this._rOneStopItToolStripMenuItem_Click);
            // 
            // _rTronScriptToolStripMenuItem
            // 
            this._rTronScriptToolStripMenuItem.Name = "_rTronScriptToolStripMenuItem";
            this._rTronScriptToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this._rTronScriptToolStripMenuItem.Text = "/r/TronScript";
            this._rTronScriptToolStripMenuItem.Click += new System.EventHandler(this._rTronScriptToolStripMenuItem_Click);
            // 
            // _ninitecomToolStripMenuItem
            // 
            this._ninitecomToolStripMenuItem.Name = "_ninitecomToolStripMenuItem";
            this._ninitecomToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this._ninitecomToolStripMenuItem.Text = "Ninite.com";
            this._ninitecomToolStripMenuItem.Click += new System.EventHandler(this._ninitecomToolStripMenuItem_Click);
            // 
            // _techWebsitesToolStripMenuItem
            // 
            this._techWebsitesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._bleepingComputerToolStripMenuItem,
            this._geGeekToolStripMenuItem});
            this._techWebsitesToolStripMenuItem.Name = "_techWebsitesToolStripMenuItem";
            this._techWebsitesToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this._techWebsitesToolStripMenuItem.Text = "Tech Websites";
            // 
            // _bleepingComputerToolStripMenuItem
            // 
            this._bleepingComputerToolStripMenuItem.Name = "_bleepingComputerToolStripMenuItem";
            this._bleepingComputerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this._bleepingComputerToolStripMenuItem.Text = "Bleeping Computer";
            this._bleepingComputerToolStripMenuItem.Click += new System.EventHandler(this._bleepingComputerToolStripMenuItem_Click);
            // 
            // _geGeekToolStripMenuItem
            // 
            this._geGeekToolStripMenuItem.Name = "_geGeekToolStripMenuItem";
            this._geGeekToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this._geGeekToolStripMenuItem.Text = "GeGeek";
            this._geGeekToolStripMenuItem.Click += new System.EventHandler(this._geGeekToolStripMenuItem_Click);
            // 
            // _browserTestingToolStripMenuItem
            // 
            this._browserTestingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._dSlReportscomSpeedTestToolStripMenuItem,
            this._speedtestnetToolStripMenuItem,
            this._toolStripSeparator14,
            this._browserscopeToolStripMenuItem,
            this._qualysBrowsercheckToolStripMenuItem,
            this._firefoxOfficialPluginTestToolStripMenuItem,
            this._toolStripSeparator15,
            this._silverlightbubblemarkcomToolStripMenuItem,
            this._flashbubblemarkcomToolStripMenuItem,
            this._javajavatesterorgToolStripMenuItem,
            this._shockwaveadobecomToolStripMenuItem,
            this._sSLssllabscomToolStripMenuItem,
            this._shieldsUpToolStripMenuItem});
            this._browserTestingToolStripMenuItem.Name = "_browserTestingToolStripMenuItem";
            this._browserTestingToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this._browserTestingToolStripMenuItem.Text = "Browser Testing";
            // 
            // _dSlReportscomSpeedTestToolStripMenuItem
            // 
            this._dSlReportscomSpeedTestToolStripMenuItem.Name = "_dSlReportscomSpeedTestToolStripMenuItem";
            this._dSlReportscomSpeedTestToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._dSlReportscomSpeedTestToolStripMenuItem.Text = "DSLReports.com Speed Test";
            this._dSlReportscomSpeedTestToolStripMenuItem.Click += new System.EventHandler(this._dSlReportscomSpeedTestToolStripMenuItem_Click);
            // 
            // _speedtestnetToolStripMenuItem
            // 
            this._speedtestnetToolStripMenuItem.Name = "_speedtestnetToolStripMenuItem";
            this._speedtestnetToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._speedtestnetToolStripMenuItem.Text = "Speedtest.net";
            this._speedtestnetToolStripMenuItem.Click += new System.EventHandler(this._speedtestnetToolStripMenuItem_Click);
            // 
            // _toolStripSeparator14
            // 
            this._toolStripSeparator14.Name = "_toolStripSeparator14";
            this._toolStripSeparator14.Size = new System.Drawing.Size(225, 6);
            // 
            // _browserscopeToolStripMenuItem
            // 
            this._browserscopeToolStripMenuItem.Name = "_browserscopeToolStripMenuItem";
            this._browserscopeToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._browserscopeToolStripMenuItem.Text = "Browserscope";
            this._browserscopeToolStripMenuItem.Click += new System.EventHandler(this._browserscopeToolStripMenuItem_Click);
            // 
            // _qualysBrowsercheckToolStripMenuItem
            // 
            this._qualysBrowsercheckToolStripMenuItem.Name = "_qualysBrowsercheckToolStripMenuItem";
            this._qualysBrowsercheckToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._qualysBrowsercheckToolStripMenuItem.Text = "Qualys Browsercheck";
            this._qualysBrowsercheckToolStripMenuItem.Click += new System.EventHandler(this._qualysBrowsercheckToolStripMenuItem_Click);
            // 
            // _firefoxOfficialPluginTestToolStripMenuItem
            // 
            this._firefoxOfficialPluginTestToolStripMenuItem.Name = "_firefoxOfficialPluginTestToolStripMenuItem";
            this._firefoxOfficialPluginTestToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._firefoxOfficialPluginTestToolStripMenuItem.Text = "Firefox Official Plugin Test";
            this._firefoxOfficialPluginTestToolStripMenuItem.Click += new System.EventHandler(this._firefoxOfficialPluginTestToolStripMenuItem_Click);
            // 
            // _toolStripSeparator15
            // 
            this._toolStripSeparator15.Name = "_toolStripSeparator15";
            this._toolStripSeparator15.Size = new System.Drawing.Size(225, 6);
            // 
            // _silverlightbubblemarkcomToolStripMenuItem
            // 
            this._silverlightbubblemarkcomToolStripMenuItem.Name = "_silverlightbubblemarkcomToolStripMenuItem";
            this._silverlightbubblemarkcomToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._silverlightbubblemarkcomToolStripMenuItem.Text = "Silverlight (bubblemark.com)";
            this._silverlightbubblemarkcomToolStripMenuItem.Click += new System.EventHandler(this._silverlightbubblemarkcomToolStripMenuItem_Click);
            // 
            // _flashbubblemarkcomToolStripMenuItem
            // 
            this._flashbubblemarkcomToolStripMenuItem.Name = "_flashbubblemarkcomToolStripMenuItem";
            this._flashbubblemarkcomToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._flashbubblemarkcomToolStripMenuItem.Text = "Flash (bubblemark.com)";
            this._flashbubblemarkcomToolStripMenuItem.Click += new System.EventHandler(this._flashbubblemarkcomToolStripMenuItem_Click);
            // 
            // _javajavatesterorgToolStripMenuItem
            // 
            this._javajavatesterorgToolStripMenuItem.Name = "_javajavatesterorgToolStripMenuItem";
            this._javajavatesterorgToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._javajavatesterorgToolStripMenuItem.Text = "Java (javatester.org)";
            this._javajavatesterorgToolStripMenuItem.Click += new System.EventHandler(this._javajavatesterorgToolStripMenuItem_Click);
            // 
            // _shockwaveadobecomToolStripMenuItem
            // 
            this._shockwaveadobecomToolStripMenuItem.Name = "_shockwaveadobecomToolStripMenuItem";
            this._shockwaveadobecomToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._shockwaveadobecomToolStripMenuItem.Text = "Shockwave (adobe.com)";
            this._shockwaveadobecomToolStripMenuItem.Click += new System.EventHandler(this._shockwaveadobecomToolStripMenuItem_Click);
            // 
            // _sSLssllabscomToolStripMenuItem
            // 
            this._sSLssllabscomToolStripMenuItem.Name = "_sSLssllabscomToolStripMenuItem";
            this._sSLssllabscomToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._sSLssllabscomToolStripMenuItem.Text = "SSL (ssllabs.com)";
            this._sSLssllabscomToolStripMenuItem.Click += new System.EventHandler(this._sSLssllabscomToolStripMenuItem_Click);
            // 
            // _shieldsUpToolStripMenuItem
            // 
            this._shieldsUpToolStripMenuItem.Name = "_shieldsUpToolStripMenuItem";
            this._shieldsUpToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._shieldsUpToolStripMenuItem.Text = "ShieldsUP!";
            this._shieldsUpToolStripMenuItem.Click += new System.EventHandler(this._shieldsUpToolStripMenuItem_Click);
            // 
            // _virusScannerRemovalToolsToolStripMenuItem
            // 
            this._virusScannerRemovalToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._eSetMasterListToolStripMenuItem,
            this._toolStripSeparator16,
            this._avastToolStripMenuItem,
            this._aVgToolStripMenuItem,
            this._aviraToolStripMenuItem,
            this._comodoToolStripMenuItem,
            this._fSecureToolStripMenuItem,
            this._kasperskyToolStripMenuItem,
            this._mcAffeToolStripMenuItem,
            this._nOd32ToolStripMenuItem,
            this._nortonToolStripMenuItem,
            this._nortonSecurityScanToolStripMenuItem,
            this._pandaToolStripMenuItem,
            this._sophosToolStripMenuItem,
            this._windowsSecurityEssentialsToolStripMenuItem});
            this._virusScannerRemovalToolsToolStripMenuItem.Name = "_virusScannerRemovalToolsToolStripMenuItem";
            this._virusScannerRemovalToolsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this._virusScannerRemovalToolsToolStripMenuItem.Text = "Virus Scanner Removal Tools";
            // 
            // _eSetMasterListToolStripMenuItem
            // 
            this._eSetMasterListToolStripMenuItem.Name = "_eSetMasterListToolStripMenuItem";
            this._eSetMasterListToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._eSetMasterListToolStripMenuItem.Text = "ESET Master List";
            this._eSetMasterListToolStripMenuItem.Click += new System.EventHandler(this._eSetMasterListToolStripMenuItem_Click);
            // 
            // _toolStripSeparator16
            // 
            this._toolStripSeparator16.Name = "_toolStripSeparator16";
            this._toolStripSeparator16.Size = new System.Drawing.Size(218, 6);
            // 
            // _avastToolStripMenuItem
            // 
            this._avastToolStripMenuItem.Name = "_avastToolStripMenuItem";
            this._avastToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._avastToolStripMenuItem.Text = "Avast";
            this._avastToolStripMenuItem.Click += new System.EventHandler(this._avastToolStripMenuItem_Click);
            // 
            // _aVgToolStripMenuItem
            // 
            this._aVgToolStripMenuItem.Name = "_aVgToolStripMenuItem";
            this._aVgToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._aVgToolStripMenuItem.Text = "AVG";
            this._aVgToolStripMenuItem.Click += new System.EventHandler(this._aVgToolStripMenuItem_Click);
            // 
            // _aviraToolStripMenuItem
            // 
            this._aviraToolStripMenuItem.Name = "_aviraToolStripMenuItem";
            this._aviraToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._aviraToolStripMenuItem.Text = "Avira";
            this._aviraToolStripMenuItem.Click += new System.EventHandler(this._aviraToolStripMenuItem_Click);
            // 
            // _comodoToolStripMenuItem
            // 
            this._comodoToolStripMenuItem.Name = "_comodoToolStripMenuItem";
            this._comodoToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._comodoToolStripMenuItem.Text = "Comodo";
            this._comodoToolStripMenuItem.Click += new System.EventHandler(this._comodoToolStripMenuItem_Click);
            // 
            // _fSecureToolStripMenuItem
            // 
            this._fSecureToolStripMenuItem.Name = "_fSecureToolStripMenuItem";
            this._fSecureToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._fSecureToolStripMenuItem.Text = "F-Secure";
            this._fSecureToolStripMenuItem.Click += new System.EventHandler(this._fSecureToolStripMenuItem_Click);
            // 
            // _kasperskyToolStripMenuItem
            // 
            this._kasperskyToolStripMenuItem.Name = "_kasperskyToolStripMenuItem";
            this._kasperskyToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._kasperskyToolStripMenuItem.Text = "Kaspersky";
            this._kasperskyToolStripMenuItem.Click += new System.EventHandler(this._kasperskyToolStripMenuItem_Click);
            // 
            // _mcAffeToolStripMenuItem
            // 
            this._mcAffeToolStripMenuItem.Name = "_mcAffeToolStripMenuItem";
            this._mcAffeToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._mcAffeToolStripMenuItem.Text = "McAffe";
            this._mcAffeToolStripMenuItem.Click += new System.EventHandler(this._mcAffeToolStripMenuItem_Click);
            // 
            // _nOd32ToolStripMenuItem
            // 
            this._nOd32ToolStripMenuItem.Name = "_nOd32ToolStripMenuItem";
            this._nOd32ToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._nOd32ToolStripMenuItem.Text = "NOD32";
            this._nOd32ToolStripMenuItem.Click += new System.EventHandler(this._nOd32ToolStripMenuItem_Click);
            // 
            // _nortonToolStripMenuItem
            // 
            this._nortonToolStripMenuItem.Name = "_nortonToolStripMenuItem";
            this._nortonToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._nortonToolStripMenuItem.Text = "Norton";
            this._nortonToolStripMenuItem.Click += new System.EventHandler(this._nortonToolStripMenuItem_Click);
            // 
            // _nortonSecurityScanToolStripMenuItem
            // 
            this._nortonSecurityScanToolStripMenuItem.Name = "_nortonSecurityScanToolStripMenuItem";
            this._nortonSecurityScanToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._nortonSecurityScanToolStripMenuItem.Text = "Norton Security Scan";
            this._nortonSecurityScanToolStripMenuItem.Click += new System.EventHandler(this._nortonSecurityScanToolStripMenuItem_Click);
            // 
            // _pandaToolStripMenuItem
            // 
            this._pandaToolStripMenuItem.Name = "_pandaToolStripMenuItem";
            this._pandaToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._pandaToolStripMenuItem.Text = "Panda";
            this._pandaToolStripMenuItem.Click += new System.EventHandler(this._pandaToolStripMenuItem_Click);
            // 
            // _sophosToolStripMenuItem
            // 
            this._sophosToolStripMenuItem.Name = "_sophosToolStripMenuItem";
            this._sophosToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._sophosToolStripMenuItem.Text = "Sophos";
            this._sophosToolStripMenuItem.Click += new System.EventHandler(this._sophosToolStripMenuItem_Click);
            // 
            // _windowsSecurityEssentialsToolStripMenuItem
            // 
            this._windowsSecurityEssentialsToolStripMenuItem.Name = "_windowsSecurityEssentialsToolStripMenuItem";
            this._windowsSecurityEssentialsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._windowsSecurityEssentialsToolStripMenuItem.Text = "Windows Security Essentials";
            this._windowsSecurityEssentialsToolStripMenuItem.Click += new System.EventHandler(this._windowsSecurityEssentialsToolStripMenuItem_Click);
            // 
            // _powerToolStripMenuItem
            // 
            this._powerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._forceShutdownToolStripMenuItem,
            this._forceRestartToolStripMenuItem,
            this._forceLogoffToolStripMenuItem,
            this.forceLogoffToolStripMenuItem,
            this._toolStripSeparator17,
            this._enableF8ToolStripMenuItem,
            this._disableF8ToolStripMenuItem,
            this._toolStripSeparator18,
            this._setSafemodeSwitchOnToolStripMenuItem,
            this._setSafemodeSwitchOnNetworkingToolStripMenuItem,
            this._setSafemodeSwitchOnMinimalToolStripMenuItem,
            this._setSafemodeSwitchOnAltShellToolStripMenuItem,
            this._setSafemodeSwtichOffNormalBootToolStripMenuItem,
            this._enumerateCurrentModeToolStripMenuItem,
            this._toolStripSeparator19,
            this._hibernateToolStripMenuItem,
            this._hybridShutdownFastStartUpToolStripMenuItem,
            this._shutdownWithOptionsToolStripMenuItem});
            this._powerToolStripMenuItem.Name = "_powerToolStripMenuItem";
            this._powerToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this._powerToolStripMenuItem.Text = "Power";
            // 
            // _forceShutdownToolStripMenuItem
            // 
            this._forceShutdownToolStripMenuItem.Name = "_forceShutdownToolStripMenuItem";
            this._forceShutdownToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._forceShutdownToolStripMenuItem.Text = "Force Shutdown";
            this._forceShutdownToolStripMenuItem.Click += new System.EventHandler(this._forceShutdownToolStripMenuItem_Click);
            // 
            // _forceRestartToolStripMenuItem
            // 
            this._forceRestartToolStripMenuItem.Name = "_forceRestartToolStripMenuItem";
            this._forceRestartToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._forceRestartToolStripMenuItem.Text = "Force Restart";
            this._forceRestartToolStripMenuItem.Click += new System.EventHandler(this._forceRestartToolStripMenuItem_Click);
            // 
            // _forceLogoffToolStripMenuItem
            // 
            this._forceLogoffToolStripMenuItem.Name = "_forceLogoffToolStripMenuItem";
            this._forceLogoffToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._forceLogoffToolStripMenuItem.Text = "Force Logoff";
            // 
            // _toolStripSeparator17
            // 
            this._toolStripSeparator17.Name = "_toolStripSeparator17";
            this._toolStripSeparator17.Size = new System.Drawing.Size(291, 6);
            // 
            // _enableF8ToolStripMenuItem
            // 
            this._enableF8ToolStripMenuItem.Name = "_enableF8ToolStripMenuItem";
            this._enableF8ToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._enableF8ToolStripMenuItem.Text = "Enable F8 Menu";
            this._enableF8ToolStripMenuItem.Click += new System.EventHandler(this._enableF8ToolStripMenuItem_Click);
            // 
            // _disableF8ToolStripMenuItem
            // 
            this._disableF8ToolStripMenuItem.Name = "_disableF8ToolStripMenuItem";
            this._disableF8ToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._disableF8ToolStripMenuItem.Text = "Disable F8 Menu";
            this._disableF8ToolStripMenuItem.Click += new System.EventHandler(this._disableF8ToolStripMenuItem_Click);
            // 
            // _toolStripSeparator18
            // 
            this._toolStripSeparator18.Name = "_toolStripSeparator18";
            this._toolStripSeparator18.Size = new System.Drawing.Size(291, 6);
            // 
            // _setSafemodeSwitchOnToolStripMenuItem
            // 
            this._setSafemodeSwitchOnToolStripMenuItem.Name = "_setSafemodeSwitchOnToolStripMenuItem";
            this._setSafemodeSwitchOnToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._setSafemodeSwitchOnToolStripMenuItem.Text = "Set Safemode Switch = On";
            this._setSafemodeSwitchOnToolStripMenuItem.Click += new System.EventHandler(this._setSafemodeSwitchOnToolStripMenuItem_Click);
            // 
            // _setSafemodeSwitchOnNetworkingToolStripMenuItem
            // 
            this._setSafemodeSwitchOnNetworkingToolStripMenuItem.Name = "_setSafemodeSwitchOnNetworkingToolStripMenuItem";
            this._setSafemodeSwitchOnNetworkingToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._setSafemodeSwitchOnNetworkingToolStripMenuItem.Text = "Set Safemode Switch = On + Networking";
            this._setSafemodeSwitchOnNetworkingToolStripMenuItem.Click += new System.EventHandler(this._setSafemodeSwitchOnNetworkingToolStripMenuItem_Click);
            // 
            // _setSafemodeSwitchOnMinimalToolStripMenuItem
            // 
            this._setSafemodeSwitchOnMinimalToolStripMenuItem.Name = "_setSafemodeSwitchOnMinimalToolStripMenuItem";
            this._setSafemodeSwitchOnMinimalToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._setSafemodeSwitchOnMinimalToolStripMenuItem.Text = "Set Safemode Switch = On (Minimal)";
            this._setSafemodeSwitchOnMinimalToolStripMenuItem.Click += new System.EventHandler(this._setSafemodeSwitchOnMinimalToolStripMenuItem_Click);
            // 
            // _setSafemodeSwitchOnAltShellToolStripMenuItem
            // 
            this._setSafemodeSwitchOnAltShellToolStripMenuItem.Name = "_setSafemodeSwitchOnAltShellToolStripMenuItem";
            this._setSafemodeSwitchOnAltShellToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._setSafemodeSwitchOnAltShellToolStripMenuItem.Text = "Set Safemode Switch = On (Alt. Shell)";
            this._setSafemodeSwitchOnAltShellToolStripMenuItem.Click += new System.EventHandler(this._setSafemodeSwitchOnAltShellToolStripMenuItem_Click);
            // 
            // _setSafemodeSwtichOffNormalBootToolStripMenuItem
            // 
            this._setSafemodeSwtichOffNormalBootToolStripMenuItem.Name = "_setSafemodeSwtichOffNormalBootToolStripMenuItem";
            this._setSafemodeSwtichOffNormalBootToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._setSafemodeSwtichOffNormalBootToolStripMenuItem.Text = "Set Safemode Swtich = Off (Normal Boot)";
            this._setSafemodeSwtichOffNormalBootToolStripMenuItem.Click += new System.EventHandler(this._setSafemodeSwtichOffNormalBootToolStripMenuItem_Click);
            // 
            // _enumerateCurrentModeToolStripMenuItem
            // 
            this._enumerateCurrentModeToolStripMenuItem.Name = "_enumerateCurrentModeToolStripMenuItem";
            this._enumerateCurrentModeToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._enumerateCurrentModeToolStripMenuItem.Text = "Enumerate Current Mode";
            this._enumerateCurrentModeToolStripMenuItem.Click += new System.EventHandler(this._enumerateCurrentModeToolStripMenuItem_Click);
            // 
            // _toolStripSeparator19
            // 
            this._toolStripSeparator19.Name = "_toolStripSeparator19";
            this._toolStripSeparator19.Size = new System.Drawing.Size(291, 6);
            // 
            // _hibernateToolStripMenuItem
            // 
            this._hibernateToolStripMenuItem.Name = "_hibernateToolStripMenuItem";
            this._hibernateToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._hibernateToolStripMenuItem.Text = "Hibernate";
            this._hibernateToolStripMenuItem.Click += new System.EventHandler(this._hibernateToolStripMenuItem_Click);
            // 
            // _hybridShutdownFastStartUpToolStripMenuItem
            // 
            this._hybridShutdownFastStartUpToolStripMenuItem.Name = "_hybridShutdownFastStartUpToolStripMenuItem";
            this._hybridShutdownFastStartUpToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._hybridShutdownFastStartUpToolStripMenuItem.Text = "Hybrid (Shutdown + Fast Start Up)";
            this._hybridShutdownFastStartUpToolStripMenuItem.Click += new System.EventHandler(this._hybridShutdownFastStartUpToolStripMenuItem_Click);
            // 
            // _shutdownWithOptionsToolStripMenuItem
            // 
            this._shutdownWithOptionsToolStripMenuItem.Name = "_shutdownWithOptionsToolStripMenuItem";
            this._shutdownWithOptionsToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._shutdownWithOptionsToolStripMenuItem.Text = "Shutdown With Options";
            this._shutdownWithOptionsToolStripMenuItem.Click += new System.EventHandler(this._shutdownWithOptionsToolStripMenuItem_Click);
            // 
            // _helpToolStripMenuItem
            // 
            this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem,
            this._disclaimerToolStripMenuItem,
            this._toolStripSeparator20,
            this._viewOnlineDocumentationToolStripMenuItem,
            this._donateToolStripMenuItem,
            this._toolStripSeparator21,
            this._staticToolStripMenuItem,
            this._cBrnisfunToolStripMenuItem});
            this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
            this._helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this._helpToolStripMenuItem.Text = "Help";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this._aboutToolStripMenuItem.Text = "About OneStop";
            // 
            // _disclaimerToolStripMenuItem
            // 
            this._disclaimerToolStripMenuItem.Name = "_disclaimerToolStripMenuItem";
            this._disclaimerToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this._disclaimerToolStripMenuItem.Text = "Disclaimer";
            // 
            // _toolStripSeparator20
            // 
            this._toolStripSeparator20.Name = "_toolStripSeparator20";
            this._toolStripSeparator20.Size = new System.Drawing.Size(220, 6);
            // 
            // _viewOnlineDocumentationToolStripMenuItem
            // 
            this._viewOnlineDocumentationToolStripMenuItem.Name = "_viewOnlineDocumentationToolStripMenuItem";
            this._viewOnlineDocumentationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this._viewOnlineDocumentationToolStripMenuItem.Text = "View Online Documentation";
            // 
            // _donateToolStripMenuItem
            // 
            this._donateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._bitCoinToolStripMenuItem,
            this._paypalToolStripMenuItem});
            this._donateToolStripMenuItem.Name = "_donateToolStripMenuItem";
            this._donateToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this._donateToolStripMenuItem.Text = "Donate";
            // 
            // _bitCoinToolStripMenuItem
            // 
            this._bitCoinToolStripMenuItem.Name = "_bitCoinToolStripMenuItem";
            this._bitCoinToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this._bitCoinToolStripMenuItem.Text = "BitCoin";
            // 
            // _paypalToolStripMenuItem
            // 
            this._paypalToolStripMenuItem.Name = "_paypalToolStripMenuItem";
            this._paypalToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this._paypalToolStripMenuItem.Text = "Paypal";
            // 
            // _toolStripSeparator21
            // 
            this._toolStripSeparator21.Name = "_toolStripSeparator21";
            this._toolStripSeparator21.Size = new System.Drawing.Size(220, 6);
            // 
            // _staticToolStripMenuItem
            // 
            this._staticToolStripMenuItem.Name = "_staticToolStripMenuItem";
            this._staticToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this._staticToolStripMenuItem.Text = "StaticExtasy";
            // 
            // _cBrnisfunToolStripMenuItem
            // 
            this._cBrnisfunToolStripMenuItem.Name = "_cBrnisfunToolStripMenuItem";
            this._cBrnisfunToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this._cBrnisfunToolStripMenuItem.Text = "CBRN_IS_FUN";
            // 
            // _tcPrimaryTabs
            // 
            this._tcPrimaryTabs.Controls.Add(this._tpWelcome);
            this._tcPrimaryTabs.Controls.Add(this._tpOneStopMain);
            this._tcPrimaryTabs.Controls.Add(this._tpTronCli);
            this._tcPrimaryTabs.Controls.Add(this._tpTime);
            this._tcPrimaryTabs.Controls.Add(this._tpSystemInfo);
            this._tcPrimaryTabs.Controls.Add(this._tpUninstaller);
            this._tcPrimaryTabs.Controls.Add(this._tpWmiExplorer);
            this._tcPrimaryTabs.Controls.Add(this._tpConfigurator);
            this._tcPrimaryTabs.Controls.Add(this._tpSetup);
            this._tcPrimaryTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tcPrimaryTabs.HotTrack = true;
            this._tcPrimaryTabs.ItemSize = new System.Drawing.Size(70, 18);
            this._tcPrimaryTabs.Location = new System.Drawing.Point(0, 89);
            this._tcPrimaryTabs.Margin = new System.Windows.Forms.Padding(0);
            this._tcPrimaryTabs.Multiline = true;
            this._tcPrimaryTabs.Name = "_tcPrimaryTabs";
            this._tcPrimaryTabs.Padding = new System.Drawing.Point(0, 0);
            this._tcPrimaryTabs.SelectedIndex = 0;
            this._tcPrimaryTabs.Size = new System.Drawing.Size(754, 417);
            this._tcPrimaryTabs.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this._tcPrimaryTabs.TabIndex = 3;
            // 
            // _tpWelcome
            // 
            this._tpWelcome.Controls.Add(this.button6);
            this._tpWelcome.Controls.Add(this.tb_Console);
            this._tpWelcome.Location = new System.Drawing.Point(4, 22);
            this._tpWelcome.Name = "_tpWelcome";
            this._tpWelcome.Padding = new System.Windows.Forms.Padding(3);
            this._tpWelcome.Size = new System.Drawing.Size(746, 391);
            this._tpWelcome.TabIndex = 10;
            this._tpWelcome.Text = "Welcome";
            this._tpWelcome.UseVisualStyleBackColor = true;
            // 
            // tb_Console
            // 
            this.tb_Console.Location = new System.Drawing.Point(353, 6);
            this.tb_Console.Multiline = true;
            this.tb_Console.Name = "tb_Console";
            this.tb_Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Console.Size = new System.Drawing.Size(385, 379);
            this.tb_Console.TabIndex = 0;
            // 
            // _tpOneStopMain
            // 
            this._tpOneStopMain.Controls.Add(this._lblOsmExecuteOrder);
            this._tpOneStopMain.Controls.Add(this._lblOsmProgramSelect);
            this._tpOneStopMain.Controls.Add(this._lblOsmCategories);
            this._tpOneStopMain.Controls.Add(this._button2);
            this._tpOneStopMain.Controls.Add(this._button1);
            this._tpOneStopMain.Controls.Add(this._listBox3);
            this._tpOneStopMain.Controls.Add(this._listBox2);
            this._tpOneStopMain.Controls.Add(this._lbOsmCategories);
            this._tpOneStopMain.Location = new System.Drawing.Point(4, 22);
            this._tpOneStopMain.Name = "_tpOneStopMain";
            this._tpOneStopMain.Size = new System.Drawing.Size(746, 391);
            this._tpOneStopMain.TabIndex = 11;
            this._tpOneStopMain.Text = "OneStop Main";
            this._tpOneStopMain.UseVisualStyleBackColor = true;
            // 
            // _lblOsmExecuteOrder
            // 
            this._lblOsmExecuteOrder.AutoSize = true;
            this._lblOsmExecuteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOsmExecuteOrder.Location = new System.Drawing.Point(497, 10);
            this._lblOsmExecuteOrder.Name = "_lblOsmExecuteOrder";
            this._lblOsmExecuteOrder.Size = new System.Drawing.Size(98, 15);
            this._lblOsmExecuteOrder.TabIndex = 7;
            this._lblOsmExecuteOrder.Text = "Execute Order";
            // 
            // _lblOsmProgramSelect
            // 
            this._lblOsmProgramSelect.AutoSize = true;
            this._lblOsmProgramSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOsmProgramSelect.Location = new System.Drawing.Point(265, 11);
            this._lblOsmProgramSelect.Name = "_lblOsmProgramSelect";
            this._lblOsmProgramSelect.Size = new System.Drawing.Size(106, 15);
            this._lblOsmProgramSelect.TabIndex = 6;
            this._lblOsmProgramSelect.Text = "Program Select";
            // 
            // _lblOsmCategories
            // 
            this._lblOsmCategories.AutoSize = true;
            this._lblOsmCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOsmCategories.Location = new System.Drawing.Point(30, 10);
            this._lblOsmCategories.Name = "_lblOsmCategories";
            this._lblOsmCategories.Size = new System.Drawing.Size(135, 15);
            this._lblOsmCategories.TabIndex = 5;
            this._lblOsmCategories.Text = "Program Categories";
            // 
            // _button2
            // 
            this._button2.Location = new System.Drawing.Point(505, 358);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(189, 23);
            this._button2.TabIndex = 4;
            this._button2.Text = "Execute All";
            this._button2.UseVisualStyleBackColor = true;
            // 
            // _button1
            // 
            this._button1.Location = new System.Drawing.Point(273, 358);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(189, 23);
            this._button1.TabIndex = 3;
            this._button1.Text = "Add to Queue";
            this._button1.UseVisualStyleBackColor = true;
            // 
            // _listBox3
            // 
            this._listBox3.FormattingEnabled = true;
            this._listBox3.Location = new System.Drawing.Point(505, 29);
            this._listBox3.Name = "_listBox3";
            this._listBox3.Size = new System.Drawing.Size(189, 316);
            this._listBox3.TabIndex = 2;
            // 
            // _listBox2
            // 
            this._listBox2.FormattingEnabled = true;
            this._listBox2.Location = new System.Drawing.Point(273, 29);
            this._listBox2.Name = "_listBox2";
            this._listBox2.Size = new System.Drawing.Size(189, 316);
            this._listBox2.TabIndex = 1;
            // 
            // _lbOsmCategories
            // 
            this._lbOsmCategories.FormattingEnabled = true;
            this._lbOsmCategories.Items.AddRange(new object[] {
            "Create Restore Point",
            "Reporting/Audit",
            "Hardware Testing",
            "Backup Tasks",
            "Prep For Malware Removal",
            "Temp File Cleanup",
            "De-Bloat",
            "Disinfect",
            "Repair",
            "Patch / Updates / Install",
            "Optimize",
            "Windows Repair",
            "System Tweaks",
            "Apply Branding",
            "Networking",
            "Manual Tools"});
            this._lbOsmCategories.Location = new System.Drawing.Point(38, 29);
            this._lbOsmCategories.Name = "_lbOsmCategories";
            this._lbOsmCategories.Size = new System.Drawing.Size(189, 225);
            this._lbOsmCategories.TabIndex = 0;
            // 
            // _tpTronCli
            // 
            this._tpTronCli.Controls.Add(this._tpTronSettings);
            this._tpTronCli.Location = new System.Drawing.Point(4, 22);
            this._tpTronCli.Name = "_tpTronCli";
            this._tpTronCli.Padding = new System.Windows.Forms.Padding(3);
            this._tpTronCli.Size = new System.Drawing.Size(746, 391);
            this._tpTronCli.TabIndex = 1;
            this._tpTronCli.Text = "TronScript";
            this._tpTronCli.UseVisualStyleBackColor = true;
            // 
            // _tpTronSettings
            // 
            this._tpTronSettings.Controls.Add(this._tpLaunchTron);
            this._tpTronSettings.Controls.Add(this._tpEmailSettings);
            this._tpTronSettings.Controls.Add(this._tpSetFlags);
            this._tpTronSettings.Location = new System.Drawing.Point(0, 0);
            this._tpTronSettings.Name = "_tpTronSettings";
            this._tpTronSettings.SelectedIndex = 0;
            this._tpTronSettings.Size = new System.Drawing.Size(746, 395);
            this._tpTronSettings.TabIndex = 0;
            // 
            // _tpLaunchTron
            // 
            this._tpLaunchTron.Controls.Add(this.button5);
            this._tpLaunchTron.Controls.Add(this.linkLabel2);
            this._tpLaunchTron.Controls.Add(this._btnTronSaveFlags);
            this._tpLaunchTron.Controls.Add(this._cbTronE);
            this._tpLaunchTron.Controls.Add(this._cbTronDev);
            this._tpLaunchTron.Controls.Add(this._btnLocateTron);
            this._tpLaunchTron.Controls.Add(this._btnDeploytofolder);
            this._tpLaunchTron.Controls.Add(this._btnConfigDump);
            this._tpLaunchTron.Controls.Add(this._btnDryRun);
            this._tpLaunchTron.Controls.Add(this._btnRunTron);
            this._tpLaunchTron.Controls.Add(this._cbTronStr);
            this._tpLaunchTron.Controls.Add(this._cbTronSs);
            this._tpLaunchTron.Controls.Add(this._cbTronSrr);
            this._tpLaunchTron.Controls.Add(this._cbTronSfr);
            this._tpLaunchTron.Controls.Add(this._cbTronSm);
            this._tpLaunchTron.Controls.Add(this._cbTronSdc);
            this._tpLaunchTron.Controls.Add(this._cbTronSk);
            this._tpLaunchTron.Controls.Add(this._cbTronSpr);
            this._tpLaunchTron.Controls.Add(this._cbTronSw);
            this._tpLaunchTron.Controls.Add(this._cbTronSe);
            this._tpLaunchTron.Controls.Add(this._cbTronP);
            this._tpLaunchTron.Controls.Add(this._btnClear);
            this._tpLaunchTron.Controls.Add(this._cbTronEr);
            this._tpLaunchTron.Controls.Add(this._cbTronSb);
            this._tpLaunchTron.Controls.Add(this._cbTronM);
            this._tpLaunchTron.Controls.Add(this._cbTronX);
            this._tpLaunchTron.Controls.Add(this._cbTronO);
            this._tpLaunchTron.Controls.Add(this._cbTronV);
            this._tpLaunchTron.Controls.Add(this._cbTronR);
            this._tpLaunchTron.Controls.Add(this._cbTronSp);
            this._tpLaunchTron.Controls.Add(this._cbTronSa);
            this._tpLaunchTron.Controls.Add(this._cbTronSd);
            this._tpLaunchTron.Location = new System.Drawing.Point(4, 22);
            this._tpLaunchTron.Name = "_tpLaunchTron";
            this._tpLaunchTron.Padding = new System.Windows.Forms.Padding(3);
            this._tpLaunchTron.Size = new System.Drawing.Size(738, 369);
            this._tpLaunchTron.TabIndex = 0;
            this._tpLaunchTron.Text = "Launch Tron";
            this._tpLaunchTron.UseVisualStyleBackColor = true;
            // 
            // _btnTronSaveFlags
            // 
            this._btnTronSaveFlags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnTronSaveFlags.Enabled = false;
            this._btnTronSaveFlags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnTronSaveFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnTronSaveFlags.Location = new System.Drawing.Point(578, 196);
            this._btnTronSaveFlags.Name = "_btnTronSaveFlags";
            this._btnTronSaveFlags.Size = new System.Drawing.Size(140, 23);
            this._btnTronSaveFlags.TabIndex = 84;
            this._btnTronSaveFlags.Text = "Save All Flags";
            this._btnTronSaveFlags.UseVisualStyleBackColor = false;
            this._btnTronSaveFlags.Click += new System.EventHandler(this.btn_Tron_SaveFlags_Click);
            // 
            // _cbTronE
            // 
            this._cbTronE.AutoSize = true;
            this._cbTronE.Location = new System.Drawing.Point(279, 41);
            this._cbTronE.Name = "_cbTronE";
            this._cbTronE.Size = new System.Drawing.Size(145, 17);
            this._cbTronE.TabIndex = 83;
            this._cbTronE.Text = "(-e) Always Accept EULA";
            this._cbTronE.UseVisualStyleBackColor = true;
            this._cbTronE.Click += new System.EventHandler(this.cb_tron_e_CheckedChanged);
            // 
            // _cbTronDev
            // 
            this._cbTronDev.AutoSize = true;
            this._cbTronDev.Location = new System.Drawing.Point(279, 177);
            this._cbTronDev.Name = "_cbTronDev";
            this._cbTronDev.Size = new System.Drawing.Size(163, 17);
            this._cbTronDev.TabIndex = 82;
            this._cbTronDev.Text = "(-dev) Override OS Detection";
            this._cbTronDev.UseVisualStyleBackColor = true;
            this._cbTronDev.CheckedChanged += new System.EventHandler(this.cb_tron_dev_CheckedChanged);
            // 
            // _btnLocateTron
            // 
            this._btnLocateTron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._btnLocateTron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnLocateTron.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnLocateTron.ForeColor = System.Drawing.Color.Black;
            this._btnLocateTron.Location = new System.Drawing.Point(579, 18);
            this._btnLocateTron.Name = "_btnLocateTron";
            this._btnLocateTron.Size = new System.Drawing.Size(140, 47);
            this._btnLocateTron.TabIndex = 81;
            this._btnLocateTron.Text = ">> Locate Tron <<";
            this._btnLocateTron.UseVisualStyleBackColor = false;
            this._btnLocateTron.Click += new System.EventHandler(this.btn_LocateTron_Click);
            // 
            // _btnDeploytofolder
            // 
            this._btnDeploytofolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._btnDeploytofolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDeploytofolder.Location = new System.Drawing.Point(579, 71);
            this._btnDeploytofolder.Name = "_btnDeploytofolder";
            this._btnDeploytofolder.Size = new System.Drawing.Size(139, 23);
            this._btnDeploytofolder.TabIndex = 80;
            this._btnDeploytofolder.Text = "Deploy Tron to Folder";
            this._btnDeploytofolder.UseVisualStyleBackColor = false;
            // 
            // _btnConfigDump
            // 
            this._btnConfigDump.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnConfigDump.Enabled = false;
            this._btnConfigDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnConfigDump.Location = new System.Drawing.Point(580, 271);
            this._btnConfigDump.Name = "_btnConfigDump";
            this._btnConfigDump.Size = new System.Drawing.Size(140, 23);
            this._btnConfigDump.TabIndex = 79;
            this._btnConfigDump.Text = "Config Dump";
            this._btnConfigDump.UseVisualStyleBackColor = false;
            this._btnConfigDump.Click += new System.EventHandler(this.btn_ConfigDump_Click);
            // 
            // _btnDryRun
            // 
            this._btnDryRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnDryRun.Enabled = false;
            this._btnDryRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDryRun.Location = new System.Drawing.Point(580, 300);
            this._btnDryRun.Name = "_btnDryRun";
            this._btnDryRun.Size = new System.Drawing.Size(140, 23);
            this._btnDryRun.TabIndex = 78;
            this._btnDryRun.Text = "Dry Run";
            this._btnDryRun.UseVisualStyleBackColor = false;
            this._btnDryRun.Click += new System.EventHandler(this.btn_DryRun_Click);
            // 
            // _btnRunTron
            // 
            this._btnRunTron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._btnRunTron.Enabled = false;
            this._btnRunTron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnRunTron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnRunTron.Location = new System.Drawing.Point(580, 329);
            this._btnRunTron.Name = "_btnRunTron";
            this._btnRunTron.Size = new System.Drawing.Size(140, 23);
            this._btnRunTron.TabIndex = 77;
            this._btnRunTron.Text = "Run Tron";
            this._btnRunTron.UseVisualStyleBackColor = false;
            this._btnRunTron.Click += new System.EventHandler(this.btn_RunTron_Click);
            // 
            // _cbTronStr
            // 
            this._cbTronStr.AutoSize = true;
            this._cbTronStr.Location = new System.Drawing.Point(16, 321);
            this._cbTronStr.Name = "_cbTronStr";
            this._cbTronStr.Size = new System.Drawing.Size(164, 17);
            this._cbTronStr.TabIndex = 76;
            this._cbTronStr.Text = "(-str) Skip Telemetry Removal";
            this._cbTronStr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._cbTronStr.UseVisualStyleBackColor = true;
            this._cbTronStr.CheckedChanged += new System.EventHandler(this.cb_tron_str_CheckedChanged);
            // 
            // _cbTronSs
            // 
            this._cbTronSs.AutoSize = true;
            this._cbTronSs.Location = new System.Drawing.Point(16, 298);
            this._cbTronSs.Name = "_cbTronSs";
            this._cbTronSs.Size = new System.Drawing.Size(155, 17);
            this._cbTronSs.TabIndex = 75;
            this._cbTronSs.Text = "(-ss) Skip Sophos Anti-Virus";
            this._cbTronSs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._cbTronSs.UseVisualStyleBackColor = true;
            this._cbTronSs.CheckedChanged += new System.EventHandler(this.cb_tron_ss_CheckedChanged);
            // 
            // _cbTronSrr
            // 
            this._cbTronSrr.AutoSize = true;
            this._cbTronSrr.Location = new System.Drawing.Point(16, 275);
            this._cbTronSrr.Name = "_cbTronSrr";
            this._cbTronSrr.Size = new System.Drawing.Size(200, 17);
            this._cbTronSrr.TabIndex = 74;
            this._cbTronSrr.Text = "(-srr) Skip Registry Permissions Reset";
            this._cbTronSrr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._cbTronSrr.UseVisualStyleBackColor = true;
            this._cbTronSrr.CheckedChanged += new System.EventHandler(this.cb_tron_srr_CheckedChanged);
            // 
            // _cbTronSfr
            // 
            this._cbTronSfr.AutoSize = true;
            this._cbTronSfr.Location = new System.Drawing.Point(16, 205);
            this._cbTronSfr.Name = "_cbTronSfr";
            this._cbTronSfr.Size = new System.Drawing.Size(201, 17);
            this._cbTronSfr.TabIndex = 73;
            this._cbTronSfr.Text = "(-sfr) Skip filesystem permissions reset";
            this._cbTronSfr.UseVisualStyleBackColor = true;
            this._cbTronSfr.CheckedChanged += new System.EventHandler(this.cb_tron_sfr_CheckedChanged);
            // 
            // _cbTronSm
            // 
            this._cbTronSm.AutoSize = true;
            this._cbTronSm.Location = new System.Drawing.Point(16, 252);
            this._cbTronSm.Name = "_cbTronSm";
            this._cbTronSm.Size = new System.Drawing.Size(137, 17);
            this._cbTronSm.TabIndex = 72;
            this._cbTronSm.Text = "(-sm) Skip MBAM Install";
            this._cbTronSm.UseVisualStyleBackColor = true;
            this._cbTronSm.CheckedChanged += new System.EventHandler(this.cb_tron_sm_CheckedChanged);
            // 
            // _cbTronSdc
            // 
            this._cbTronSdc.AutoSize = true;
            this._cbTronSdc.Location = new System.Drawing.Point(16, 181);
            this._cbTronSdc.Name = "_cbTronSdc";
            this._cbTronSdc.Size = new System.Drawing.Size(260, 17);
            this._cbTronSdc.TabIndex = 70;
            this._cbTronSdc.Text = "(-sdc) Skip DISM component (SxS Store) Cleanup";
            this._cbTronSdc.UseVisualStyleBackColor = true;
            this._cbTronSdc.CheckedChanged += new System.EventHandler(this.cb_tron_sdc_CheckedChanged);
            // 
            // _cbTronSk
            // 
            this._cbTronSk.AutoSize = true;
            this._cbTronSk.Location = new System.Drawing.Point(16, 228);
            this._cbTronSk.Name = "_cbTronSk";
            this._cbTronSk.Size = new System.Drawing.Size(147, 17);
            this._cbTronSk.TabIndex = 71;
            this._cbTronSk.Text = "(-sk) Skip Kaspersky VRT";
            this._cbTronSk.UseVisualStyleBackColor = true;
            this._cbTronSk.CheckedChanged += new System.EventHandler(this.cb_tron_sk_CheckedChanged);
            // 
            // _cbTronSpr
            // 
            this._cbTronSpr.AutoSize = true;
            this._cbTronSpr.Location = new System.Drawing.Point(16, 158);
            this._cbTronSpr.Name = "_cbTronSpr";
            this._cbTronSpr.Size = new System.Drawing.Size(151, 17);
            this._cbTronSpr.TabIndex = 69;
            this._cbTronSpr.Text = "(-spr) Skip Page File Reset";
            this._cbTronSpr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._cbTronSpr.UseVisualStyleBackColor = true;
            this._cbTronSpr.CheckedChanged += new System.EventHandler(this.cb_tron_spr_CheckedChanged);
            // 
            // _cbTronSw
            // 
            this._cbTronSw.AutoSize = true;
            this._cbTronSw.Location = new System.Drawing.Point(16, 135);
            this._cbTronSw.Name = "_cbTronSw";
            this._cbTronSw.Size = new System.Drawing.Size(162, 17);
            this._cbTronSw.TabIndex = 68;
            this._cbTronSw.Text = "(-sw) Skip Windows Updates";
            this._cbTronSw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._cbTronSw.UseVisualStyleBackColor = true;
            this._cbTronSw.CheckedChanged += new System.EventHandler(this.cb_tron_sw_CheckedChanged);
            // 
            // _cbTronSe
            // 
            this._cbTronSe.AutoSize = true;
            this._cbTronSe.Location = new System.Drawing.Point(16, 112);
            this._cbTronSe.Name = "_cbTronSe";
            this._cbTronSe.Size = new System.Drawing.Size(163, 17);
            this._cbTronSe.TabIndex = 67;
            this._cbTronSe.Text = "(-se) Skip Event Log Clearing";
            this._cbTronSe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._cbTronSe.UseVisualStyleBackColor = true;
            this._cbTronSe.CheckedChanged += new System.EventHandler(this.cb_tron_se_CheckedChanged);
            // 
            // _cbTronP
            // 
            this._cbTronP.AutoSize = true;
            this._cbTronP.Location = new System.Drawing.Point(279, 64);
            this._cbTronP.Name = "_cbTronP";
            this._cbTronP.Size = new System.Drawing.Size(158, 17);
            this._cbTronP.TabIndex = 64;
            this._cbTronP.Text = "(-p) Preserve Power Options";
            this._cbTronP.UseVisualStyleBackColor = true;
            this._cbTronP.CheckedChanged += new System.EventHandler(this.cb_tron_p_CheckedChanged);
            // 
            // _btnClear
            // 
            this._btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnClear.Location = new System.Drawing.Point(579, 154);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(140, 23);
            this._btnClear.TabIndex = 63;
            this._btnClear.Text = "Clear All Flags";
            this._btnClear.UseVisualStyleBackColor = false;
            this._btnClear.Click += new System.EventHandler(this._btnClear_Click);
            // 
            // _cbTronEr
            // 
            this._cbTronEr.AutoSize = true;
            this._cbTronEr.Location = new System.Drawing.Point(279, 18);
            this._cbTronEr.Name = "_cbTronEr";
            this._cbTronEr.Size = new System.Drawing.Size(107, 17);
            this._cbTronEr.TabIndex = 53;
            this._cbTronEr.Text = "(-er) Email Report";
            this._cbTronEr.UseVisualStyleBackColor = true;
            this._cbTronEr.Click += new System.EventHandler(this.cb_tron_er_CheckedChanged);
            // 
            // _cbTronSb
            // 
            this._cbTronSb.AutoSize = true;
            this._cbTronSb.Location = new System.Drawing.Point(16, 42);
            this._cbTronSb.Name = "_cbTronSb";
            this._cbTronSb.Size = new System.Drawing.Size(110, 17);
            this._cbTronSb.TabIndex = 62;
            this._cbTronSb.Text = "(-sb) Skip Debloat";
            this._cbTronSb.UseVisualStyleBackColor = true;
            this._cbTronSb.CheckedChanged += new System.EventHandler(this.cb_tron_sb_CheckedChanged);
            // 
            // _cbTronM
            // 
            this._cbTronM.AutoSize = true;
            this._cbTronM.Location = new System.Drawing.Point(279, 200);
            this._cbTronM.Name = "_cbTronM";
            this._cbTronM.Size = new System.Drawing.Size(182, 17);
            this._cbTronM.TabIndex = 54;
            this._cbTronM.Text = "(-m) Preserve Default Metro Apps";
            this._cbTronM.UseVisualStyleBackColor = true;
            this._cbTronM.CheckedChanged += new System.EventHandler(this.cb_tron_m_CheckedChanged);
            // 
            // _cbTronX
            // 
            this._cbTronX.AutoSize = true;
            this._cbTronX.Location = new System.Drawing.Point(279, 154);
            this._cbTronX.Name = "_cbTronX";
            this._cbTronX.Size = new System.Drawing.Size(104, 17);
            this._cbTronX.TabIndex = 61;
            this._cbTronX.Text = "(-x) Self Destruct";
            this._cbTronX.UseVisualStyleBackColor = true;
            this._cbTronX.CheckedChanged += new System.EventHandler(this.cb_tron_x_CheckedChanged);
            // 
            // _cbTronO
            // 
            this._cbTronO.AutoSize = true;
            this._cbTronO.Location = new System.Drawing.Point(279, 86);
            this._cbTronO.Name = "_cbTronO";
            this._cbTronO.Size = new System.Drawing.Size(139, 17);
            this._cbTronO.TabIndex = 55;
            this._cbTronO.Text = "(-o) Power Off After Run";
            this._cbTronO.UseVisualStyleBackColor = true;
            this._cbTronO.CheckedChanged += new System.EventHandler(this.cb_tron_o_CheckedChanged);
            // 
            // _cbTronV
            // 
            this._cbTronV.AutoSize = true;
            this._cbTronV.Location = new System.Drawing.Point(279, 131);
            this._cbTronV.Name = "_cbTronV";
            this._cbTronV.Size = new System.Drawing.Size(83, 17);
            this._cbTronV.TabIndex = 60;
            this._cbTronV.Text = "(-v) Verbose";
            this._cbTronV.UseVisualStyleBackColor = true;
            this._cbTronV.CheckedChanged += new System.EventHandler(this.cb_tron_v_CheckedChanged);
            // 
            // _cbTronR
            // 
            this._cbTronR.AutoSize = true;
            this._cbTronR.Location = new System.Drawing.Point(279, 108);
            this._cbTronR.Name = "_cbTronR";
            this._cbTronR.Size = new System.Drawing.Size(141, 17);
            this._cbTronR.TabIndex = 56;
            this._cbTronR.Text = "(-r) Reboot Automatically";
            this._cbTronR.UseVisualStyleBackColor = true;
            this._cbTronR.CheckedChanged += new System.EventHandler(this.cb_tron_r_CheckedChanged);
            // 
            // _cbTronSp
            // 
            this._cbTronSp.AutoSize = true;
            this._cbTronSp.Location = new System.Drawing.Point(16, 89);
            this._cbTronSp.Name = "_cbTronSp";
            this._cbTronSp.Size = new System.Drawing.Size(112, 17);
            this._cbTronSp.TabIndex = 59;
            this._cbTronSp.Text = "(-sp) Skip Patches";
            this._cbTronSp.UseVisualStyleBackColor = true;
            this._cbTronSp.CheckedChanged += new System.EventHandler(this.cb_tron_sp_CheckedChanged);
            // 
            // _cbTronSa
            // 
            this._cbTronSa.AutoSize = true;
            this._cbTronSa.Location = new System.Drawing.Point(16, 18);
            this._cbTronSa.Name = "_cbTronSa";
            this._cbTronSa.Size = new System.Drawing.Size(117, 17);
            this._cbTronSa.TabIndex = 57;
            this._cbTronSa.Text = "(-sa) Skip Anti-Virus";
            this._cbTronSa.UseVisualStyleBackColor = true;
            this._cbTronSa.CheckedChanged += new System.EventHandler(this.cb_tron_sa_CheckedChanged);
            // 
            // _cbTronSd
            // 
            this._cbTronSd.AutoSize = true;
            this._cbTronSd.Location = new System.Drawing.Point(16, 65);
            this._cbTronSd.Name = "_cbTronSd";
            this._cbTronSd.Size = new System.Drawing.Size(105, 17);
            this._cbTronSd.TabIndex = 58;
            this._cbTronSd.Text = "(-sd) Skip Defrag";
            this._cbTronSd.UseVisualStyleBackColor = true;
            this._cbTronSd.CheckedChanged += new System.EventHandler(this.cb_tron_sd_CheckedChanged);
            // 
            // _tpEmailSettings
            // 
            this._tpEmailSettings.Location = new System.Drawing.Point(4, 22);
            this._tpEmailSettings.Name = "_tpEmailSettings";
            this._tpEmailSettings.Padding = new System.Windows.Forms.Padding(3);
            this._tpEmailSettings.Size = new System.Drawing.Size(738, 369);
            this._tpEmailSettings.TabIndex = 1;
            this._tpEmailSettings.Text = "Email Settings";
            this._tpEmailSettings.UseVisualStyleBackColor = true;
            // 
            // _tpSetFlags
            // 
            this._tpSetFlags.Location = new System.Drawing.Point(4, 22);
            this._tpSetFlags.Name = "_tpSetFlags";
            this._tpSetFlags.Padding = new System.Windows.Forms.Padding(3);
            this._tpSetFlags.Size = new System.Drawing.Size(738, 369);
            this._tpSetFlags.TabIndex = 2;
            this._tpSetFlags.Text = "Set Permanant Flags";
            this._tpSetFlags.UseVisualStyleBackColor = true;
            // 
            // _tpTime
            // 
            this._tpTime.Location = new System.Drawing.Point(4, 22);
            this._tpTime.Name = "_tpTime";
            this._tpTime.Padding = new System.Windows.Forms.Padding(3);
            this._tpTime.Size = new System.Drawing.Size(746, 391);
            this._tpTime.TabIndex = 8;
            this._tpTime.Text = "Technician Time/Reporting";
            this._tpTime.UseVisualStyleBackColor = true;
            // 
            // _tpSystemInfo
            // 
            this._tpSystemInfo.Controls.Add(this.tabControl1);
            this._tpSystemInfo.Location = new System.Drawing.Point(4, 22);
            this._tpSystemInfo.Name = "_tpSystemInfo";
            this._tpSystemInfo.Size = new System.Drawing.Size(746, 391);
            this._tpSystemInfo.TabIndex = 3;
            this._tpSystemInfo.Text = "System Info";
            this._tpSystemInfo.UseVisualStyleBackColor = true;
            // 
            // _tpUninstaller
            // 
            this._tpUninstaller.Location = new System.Drawing.Point(4, 22);
            this._tpUninstaller.Name = "_tpUninstaller";
            this._tpUninstaller.Size = new System.Drawing.Size(746, 391);
            this._tpUninstaller.TabIndex = 5;
            this._tpUninstaller.Text = "Uninstaller";
            this._tpUninstaller.UseVisualStyleBackColor = true;
            // 
            // _tpWmiExplorer
            // 
            this._tpWmiExplorer.Location = new System.Drawing.Point(4, 22);
            this._tpWmiExplorer.Name = "_tpWmiExplorer";
            this._tpWmiExplorer.Size = new System.Drawing.Size(746, 391);
            this._tpWmiExplorer.TabIndex = 6;
            this._tpWmiExplorer.Text = "WMI Explorer";
            this._tpWmiExplorer.UseVisualStyleBackColor = true;
            // 
            // _tpConfigurator
            // 
            this._tpConfigurator.Controls.Add(this._tcConfigurator);
            this._tpConfigurator.Location = new System.Drawing.Point(4, 22);
            this._tpConfigurator.Name = "_tpConfigurator";
            this._tpConfigurator.Size = new System.Drawing.Size(746, 391);
            this._tpConfigurator.TabIndex = 7;
            this._tpConfigurator.Text = "Tweaks";
            this._tpConfigurator.UseVisualStyleBackColor = true;
            // 
            // _tcConfigurator
            // 
            this._tcConfigurator.Controls.Add(this._tpInternetSettings);
            this._tcConfigurator.Controls.Add(this._tpSecurity);
            this._tcConfigurator.Controls.Add(this._tpPerformance);
            this._tcConfigurator.Controls.Add(this._tpWelcomeScreen);
            this._tcConfigurator.Controls.Add(this._tpWindows10);
            this._tcConfigurator.Controls.Add(this._tpExplorer);
            this._tcConfigurator.Controls.Add(this._tpAppearance);
            this._tcConfigurator.Controls.Add(this._tpOem);
            this._tcConfigurator.Location = new System.Drawing.Point(0, 0);
            this._tcConfigurator.Multiline = true;
            this._tcConfigurator.Name = "_tcConfigurator";
            this._tcConfigurator.SelectedIndex = 0;
            this._tcConfigurator.Size = new System.Drawing.Size(750, 395);
            this._tcConfigurator.TabIndex = 0;
            // 
            // _tpInternetSettings
            // 
            this._tpInternetSettings.Location = new System.Drawing.Point(4, 22);
            this._tpInternetSettings.Name = "_tpInternetSettings";
            this._tpInternetSettings.Padding = new System.Windows.Forms.Padding(3);
            this._tpInternetSettings.Size = new System.Drawing.Size(742, 369);
            this._tpInternetSettings.TabIndex = 0;
            this._tpInternetSettings.Text = "Network & Internet";
            this._tpInternetSettings.UseVisualStyleBackColor = true;
            // 
            // _tpSecurity
            // 
            this._tpSecurity.Location = new System.Drawing.Point(4, 22);
            this._tpSecurity.Name = "_tpSecurity";
            this._tpSecurity.Padding = new System.Windows.Forms.Padding(3);
            this._tpSecurity.Size = new System.Drawing.Size(742, 369);
            this._tpSecurity.TabIndex = 1;
            this._tpSecurity.Text = "Security & UAC";
            this._tpSecurity.UseVisualStyleBackColor = true;
            // 
            // _tpPerformance
            // 
            this._tpPerformance.Location = new System.Drawing.Point(4, 22);
            this._tpPerformance.Name = "_tpPerformance";
            this._tpPerformance.Size = new System.Drawing.Size(742, 369);
            this._tpPerformance.TabIndex = 2;
            this._tpPerformance.Text = "Performance";
            this._tpPerformance.UseVisualStyleBackColor = true;
            // 
            // _tpWelcomeScreen
            // 
            this._tpWelcomeScreen.Location = new System.Drawing.Point(4, 22);
            this._tpWelcomeScreen.Name = "_tpWelcomeScreen";
            this._tpWelcomeScreen.Size = new System.Drawing.Size(742, 369);
            this._tpWelcomeScreen.TabIndex = 3;
            this._tpWelcomeScreen.Text = "Welcome Screen";
            this._tpWelcomeScreen.UseVisualStyleBackColor = true;
            // 
            // _tpWindows10
            // 
            this._tpWindows10.Location = new System.Drawing.Point(4, 22);
            this._tpWindows10.Name = "_tpWindows10";
            this._tpWindows10.Size = new System.Drawing.Size(742, 369);
            this._tpWindows10.TabIndex = 4;
            this._tpWindows10.Text = "Windows 10 Upgrade";
            this._tpWindows10.UseVisualStyleBackColor = true;
            // 
            // _tpExplorer
            // 
            this._tpExplorer.Location = new System.Drawing.Point(4, 22);
            this._tpExplorer.Name = "_tpExplorer";
            this._tpExplorer.Size = new System.Drawing.Size(742, 369);
            this._tpExplorer.TabIndex = 5;
            this._tpExplorer.Text = "Explorer";
            this._tpExplorer.UseVisualStyleBackColor = true;
            // 
            // _tpAppearance
            // 
            this._tpAppearance.Location = new System.Drawing.Point(4, 22);
            this._tpAppearance.Name = "_tpAppearance";
            this._tpAppearance.Size = new System.Drawing.Size(742, 369);
            this._tpAppearance.TabIndex = 6;
            this._tpAppearance.Text = "Appearance";
            this._tpAppearance.UseVisualStyleBackColor = true;
            // 
            // _tpOem
            // 
            this._tpOem.Location = new System.Drawing.Point(4, 22);
            this._tpOem.Name = "_tpOem";
            this._tpOem.Size = new System.Drawing.Size(742, 369);
            this._tpOem.TabIndex = 7;
            this._tpOem.Text = "OEM";
            this._tpOem.UseVisualStyleBackColor = true;
            // 
            // _tpSetup
            // 
            this._tpSetup.Controls.Add(this._tabControl2);
            this._tpSetup.Location = new System.Drawing.Point(4, 22);
            this._tpSetup.Name = "_tpSetup";
            this._tpSetup.Padding = new System.Windows.Forms.Padding(3);
            this._tpSetup.Size = new System.Drawing.Size(746, 391);
            this._tpSetup.TabIndex = 9;
            this._tpSetup.Text = "Setup";
            this._tpSetup.UseVisualStyleBackColor = true;
            // 
            // _tabControl2
            // 
            this._tabControl2.Controls.Add(this.tpQuickLaunch);
            this._tabControl2.Controls.Add(this.tpShopSettings);
            this._tabControl2.Controls.Add(this.tpServers);
            this._tabControl2.Controls.Add(this.tpIntegration);
            this._tabControl2.Controls.Add(this.tpLogging);
            this._tabControl2.Location = new System.Drawing.Point(0, 3);
            this._tabControl2.Name = "_tabControl2";
            this._tabControl2.SelectedIndex = 0;
            this._tabControl2.Size = new System.Drawing.Size(746, 392);
            this._tabControl2.TabIndex = 0;
            // 
            // tpQuickLaunch
            // 
            this.tpQuickLaunch.Controls.Add(this.button10);
            this.tpQuickLaunch.Controls.Add(this.button11);
            this.tpQuickLaunch.Controls.Add(this.button9);
            this.tpQuickLaunch.Controls.Add(this.button8);
            this.tpQuickLaunch.Controls.Add(this._btnQlDeleteSelected);
            this.tpQuickLaunch.Controls.Add(this._lbCurrentPrograms);
            this.tpQuickLaunch.Controls.Add(this._lblQlMenuItemName);
            this.tpQuickLaunch.Controls.Add(this._btnQlCreateNew);
            this.tpQuickLaunch.Controls.Add(this._txtQlAppName);
            this.tpQuickLaunch.Controls.Add(this._lblQlFolders);
            this.tpQuickLaunch.Location = new System.Drawing.Point(4, 22);
            this.tpQuickLaunch.Name = "tpQuickLaunch";
            this.tpQuickLaunch.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuickLaunch.Size = new System.Drawing.Size(738, 366);
            this.tpQuickLaunch.TabIndex = 0;
            this.tpQuickLaunch.Text = "Quick Launch";
            this.tpQuickLaunch.UseVisualStyleBackColor = true;
            // 
            // _btnQlDeleteSelected
            // 
            this._btnQlDeleteSelected.Location = new System.Drawing.Point(497, 319);
            this._btnQlDeleteSelected.Name = "_btnQlDeleteSelected";
            this._btnQlDeleteSelected.Size = new System.Drawing.Size(224, 23);
            this._btnQlDeleteSelected.TabIndex = 5;
            this._btnQlDeleteSelected.Text = "Delete Selected";
            this._btnQlDeleteSelected.UseVisualStyleBackColor = true;
            this._btnQlDeleteSelected.Click += new System.EventHandler(this.btn_QL_DeleteSelected_Click);
            // 
            // _lbCurrentPrograms
            // 
            this._lbCurrentPrograms.FormattingEnabled = true;
            this._lbCurrentPrograms.Location = new System.Drawing.Point(309, 46);
            this._lbCurrentPrograms.Name = "_lbCurrentPrograms";
            this._lbCurrentPrograms.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this._lbCurrentPrograms.Size = new System.Drawing.Size(412, 264);
            this._lbCurrentPrograms.TabIndex = 4;
            // 
            // _lblQlMenuItemName
            // 
            this._lblQlMenuItemName.AutoSize = true;
            this._lblQlMenuItemName.Location = new System.Drawing.Point(21, 20);
            this._lblQlMenuItemName.Name = "_lblQlMenuItemName";
            this._lblQlMenuItemName.Size = new System.Drawing.Size(91, 13);
            this._lblQlMenuItemName.TabIndex = 3;
            this._lblQlMenuItemName.Text = "Menu Item Name:";
            // 
            // _btnQlCreateNew
            // 
            this._btnQlCreateNew.Location = new System.Drawing.Point(24, 66);
            this._btnQlCreateNew.Name = "_btnQlCreateNew";
            this._btnQlCreateNew.Size = new System.Drawing.Size(244, 23);
            this._btnQlCreateNew.TabIndex = 2;
            this._btnQlCreateNew.Text = "Create New QL Item";
            this._btnQlCreateNew.UseVisualStyleBackColor = true;
            this._btnQlCreateNew.Click += new System.EventHandler(this.btn_QL_CreateNew_Click);
            // 
            // _txtQlAppName
            // 
            this._txtQlAppName.Location = new System.Drawing.Point(24, 36);
            this._txtQlAppName.Name = "_txtQlAppName";
            this._txtQlAppName.Size = new System.Drawing.Size(244, 20);
            this._txtQlAppName.TabIndex = 1;
            // 
            // _lblQlFolders
            // 
            this._lblQlFolders.AutoSize = true;
            this._lblQlFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblQlFolders.Location = new System.Drawing.Point(8, 8);
            this._lblQlFolders.MaximumSize = new System.Drawing.Size(650, 0);
            this._lblQlFolders.Name = "_lblQlFolders";
            this._lblQlFolders.Size = new System.Drawing.Size(0, 13);
            this._lblQlFolders.TabIndex = 0;
            // 
            // tpShopSettings
            // 
            this.tpShopSettings.Controls.Add(this.pictureBox1);
            this.tpShopSettings.Controls.Add(this._btnShopSetSave);
            this.tpShopSettings.Controls.Add(this._lblShopSetState);
            this.tpShopSettings.Controls.Add(this._tbShopSetState);
            this.tpShopSettings.Controls.Add(this._lblShopSetCity);
            this.tpShopSettings.Controls.Add(this._tbShopSetCity);
            this.tpShopSettings.Controls.Add(this._lblShopSetEmail);
            this.tpShopSettings.Controls.Add(this._tbShopSetEmail);
            this.tpShopSettings.Controls.Add(this._lblShopSetPhone);
            this.tpShopSettings.Controls.Add(this._tbShopSetPhone);
            this.tpShopSettings.Controls.Add(this._tbShopSetAddr2);
            this.tpShopSettings.Controls.Add(this._lblShopSetAddr);
            this.tpShopSettings.Controls.Add(this._tbShopSetAddr1);
            this.tpShopSettings.Controls.Add(this._lblShopSetShopname);
            this.tpShopSettings.Controls.Add(this._tbShopSetName);
            this.tpShopSettings.Location = new System.Drawing.Point(4, 22);
            this.tpShopSettings.Name = "tpShopSettings";
            this.tpShopSettings.Size = new System.Drawing.Size(738, 366);
            this.tpShopSettings.TabIndex = 1;
            this.tpShopSettings.Text = "Shop Settings";
            this.tpShopSettings.UseVisualStyleBackColor = true;
            // 
            // _btnShopSetSave
            // 
            this._btnShopSetSave.Location = new System.Drawing.Point(505, 337);
            this._btnShopSetSave.Name = "_btnShopSetSave";
            this._btnShopSetSave.Size = new System.Drawing.Size(224, 23);
            this._btnShopSetSave.TabIndex = 17;
            this._btnShopSetSave.Text = "Save Shop Info";
            this._btnShopSetSave.UseVisualStyleBackColor = true;
            this._btnShopSetSave.Click += new System.EventHandler(this.btn_ShopSet_Save_Click);
            // 
            // _lblShopSetState
            // 
            this._lblShopSetState.AutoSize = true;
            this._lblShopSetState.Location = new System.Drawing.Point(13, 222);
            this._lblShopSetState.Name = "_lblShopSetState";
            this._lblShopSetState.Size = new System.Drawing.Size(89, 13);
            this._lblShopSetState.TabIndex = 16;
            this._lblShopSetState.Text = "State/Prov + Zip:";
            // 
            // _tbShopSetState
            // 
            this._tbShopSetState.Location = new System.Drawing.Point(16, 238);
            this._tbShopSetState.Name = "_tbShopSetState";
            this._tbShopSetState.Size = new System.Drawing.Size(224, 20);
            this._tbShopSetState.TabIndex = 15;
            // 
            // _lblShopSetCity
            // 
            this._lblShopSetCity.AutoSize = true;
            this._lblShopSetCity.Location = new System.Drawing.Point(13, 174);
            this._lblShopSetCity.Name = "_lblShopSetCity";
            this._lblShopSetCity.Size = new System.Drawing.Size(27, 13);
            this._lblShopSetCity.TabIndex = 14;
            this._lblShopSetCity.Text = "City:";
            // 
            // _tbShopSetCity
            // 
            this._tbShopSetCity.Location = new System.Drawing.Point(16, 190);
            this._tbShopSetCity.Name = "_tbShopSetCity";
            this._tbShopSetCity.Size = new System.Drawing.Size(224, 20);
            this._tbShopSetCity.TabIndex = 13;
            // 
            // _lblShopSetEmail
            // 
            this._lblShopSetEmail.AutoSize = true;
            this._lblShopSetEmail.Location = new System.Drawing.Point(13, 317);
            this._lblShopSetEmail.Name = "_lblShopSetEmail";
            this._lblShopSetEmail.Size = new System.Drawing.Size(35, 13);
            this._lblShopSetEmail.TabIndex = 12;
            this._lblShopSetEmail.Text = "Email:";
            // 
            // _tbShopSetEmail
            // 
            this._tbShopSetEmail.Location = new System.Drawing.Point(16, 333);
            this._tbShopSetEmail.Name = "_tbShopSetEmail";
            this._tbShopSetEmail.Size = new System.Drawing.Size(224, 20);
            this._tbShopSetEmail.TabIndex = 11;
            // 
            // _lblShopSetPhone
            // 
            this._lblShopSetPhone.AutoSize = true;
            this._lblShopSetPhone.Location = new System.Drawing.Point(13, 269);
            this._lblShopSetPhone.Name = "_lblShopSetPhone";
            this._lblShopSetPhone.Size = new System.Drawing.Size(41, 13);
            this._lblShopSetPhone.TabIndex = 10;
            this._lblShopSetPhone.Text = "Phone:";
            // 
            // _tbShopSetPhone
            // 
            this._tbShopSetPhone.Location = new System.Drawing.Point(16, 285);
            this._tbShopSetPhone.Name = "_tbShopSetPhone";
            this._tbShopSetPhone.Size = new System.Drawing.Size(224, 20);
            this._tbShopSetPhone.TabIndex = 9;
            // 
            // _tbShopSetAddr2
            // 
            this._tbShopSetAddr2.Location = new System.Drawing.Point(16, 144);
            this._tbShopSetAddr2.Name = "_tbShopSetAddr2";
            this._tbShopSetAddr2.Size = new System.Drawing.Size(224, 20);
            this._tbShopSetAddr2.TabIndex = 8;
            // 
            // _lblShopSetAddr
            // 
            this._lblShopSetAddr.AutoSize = true;
            this._lblShopSetAddr.Location = new System.Drawing.Point(13, 102);
            this._lblShopSetAddr.Name = "_lblShopSetAddr";
            this._lblShopSetAddr.Size = new System.Drawing.Size(48, 13);
            this._lblShopSetAddr.TabIndex = 7;
            this._lblShopSetAddr.Text = "Address:";
            // 
            // _tbShopSetAddr1
            // 
            this._tbShopSetAddr1.Location = new System.Drawing.Point(16, 118);
            this._tbShopSetAddr1.Name = "_tbShopSetAddr1";
            this._tbShopSetAddr1.Size = new System.Drawing.Size(224, 20);
            this._tbShopSetAddr1.TabIndex = 6;
            // 
            // _lblShopSetShopname
            // 
            this._lblShopSetShopname.AutoSize = true;
            this._lblShopSetShopname.Location = new System.Drawing.Point(13, 12);
            this._lblShopSetShopname.Name = "_lblShopSetShopname";
            this._lblShopSetShopname.Size = new System.Drawing.Size(66, 13);
            this._lblShopSetShopname.TabIndex = 5;
            this._lblShopSetShopname.Text = "Shop Name:";
            // 
            // _tbShopSetName
            // 
            this._tbShopSetName.Location = new System.Drawing.Point(16, 28);
            this._tbShopSetName.Name = "_tbShopSetName";
            this._tbShopSetName.Size = new System.Drawing.Size(224, 20);
            this._tbShopSetName.TabIndex = 4;
            // 
            // _lnkInfoInternalIp
            // 
            this._lnkInfoInternalIp.AutoSize = true;
            this._lnkInfoInternalIp.Location = new System.Drawing.Point(627, 39);
            this._lnkInfoInternalIp.Name = "_lnkInfoInternalIp";
            this._lnkInfoInternalIp.Size = new System.Drawing.Size(95, 13);
            this._lnkInfoInternalIp.TabIndex = 68;
            this._lnkInfoInternalIp.TabStop = true;
            this._lnkInfoInternalIp.Text = "lnk_info_InternalIP";
            // 
            // _lblInfoExternalIp
            // 
            this._lblInfoExternalIp.AutoSize = true;
            this._lblInfoExternalIp.BackColor = System.Drawing.SystemColors.Control;
            this._lblInfoExternalIp.Location = new System.Drawing.Point(386, 73);
            this._lblInfoExternalIp.Name = "_lblInfoExternalIp";
            this._lblInfoExternalIp.Size = new System.Drawing.Size(94, 13);
            this._lblInfoExternalIp.TabIndex = 67;
            this._lblInfoExternalIp.Text = "lbl_info_ExternalIP";
            // 
            // _lnkInfoGateway
            // 
            this._lnkInfoGateway.AutoSize = true;
            this._lnkInfoGateway.Location = new System.Drawing.Point(627, 56);
            this._lnkInfoGateway.Name = "_lnkInfoGateway";
            this._lnkInfoGateway.Size = new System.Drawing.Size(92, 13);
            this._lnkInfoGateway.TabIndex = 66;
            this._lnkInfoGateway.TabStop = true;
            this._lnkInfoGateway.Text = "lnk_info_Gateway";
            // 
            // _lnkInfoPrimDns
            // 
            this._lnkInfoPrimDns.AutoSize = true;
            this._lnkInfoPrimDns.Location = new System.Drawing.Point(627, 73);
            this._lnkInfoPrimDns.Name = "_lnkInfoPrimDns";
            this._lnkInfoPrimDns.Size = new System.Drawing.Size(93, 13);
            this._lnkInfoPrimDns.TabIndex = 64;
            this._lnkInfoPrimDns.TabStop = true;
            this._lnkInfoPrimDns.Text = "lnk_info_PrimDNS";
            // 
            // _lblDns
            // 
            this._lblDns.AutoSize = true;
            this._lblDns.BackColor = System.Drawing.SystemColors.Control;
            this._lblDns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblDns.Location = new System.Drawing.Point(584, 73);
            this._lblDns.Name = "_lblDns";
            this._lblDns.Size = new System.Drawing.Size(37, 13);
            this._lblDns.TabIndex = 63;
            this._lblDns.Text = "DNS:";
            // 
            // _lblGateway
            // 
            this._lblGateway.AutoSize = true;
            this._lblGateway.BackColor = System.Drawing.SystemColors.Control;
            this._lblGateway.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblGateway.Location = new System.Drawing.Point(561, 56);
            this._lblGateway.Name = "_lblGateway";
            this._lblGateway.Size = new System.Drawing.Size(60, 13);
            this._lblGateway.TabIndex = 62;
            this._lblGateway.Text = "Gateway:";
            // 
            // _lblExternalIp
            // 
            this._lblExternalIp.AutoSize = true;
            this._lblExternalIp.BackColor = System.Drawing.SystemColors.Control;
            this._lblExternalIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblExternalIp.Location = new System.Drawing.Point(307, 73);
            this._lblExternalIp.Name = "_lblExternalIp";
            this._lblExternalIp.Size = new System.Drawing.Size(73, 13);
            this._lblExternalIp.TabIndex = 61;
            this._lblExternalIp.Text = "External IP:";
            // 
            // _lblInternalIp
            // 
            this._lblInternalIp.AutoSize = true;
            this._lblInternalIp.BackColor = System.Drawing.SystemColors.Control;
            this._lblInternalIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblInternalIp.Location = new System.Drawing.Point(551, 40);
            this._lblInternalIp.Name = "_lblInternalIp";
            this._lblInternalIp.Size = new System.Drawing.Size(70, 13);
            this._lblInternalIp.TabIndex = 60;
            this._lblInternalIp.Text = "Internal IP:";
            // 
            // _lblFreeC
            // 
            this._lblFreeC.AutoSize = true;
            this._lblFreeC.BackColor = System.Drawing.SystemColors.Control;
            this._lblFreeC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblFreeC.Location = new System.Drawing.Point(6, 75);
            this._lblFreeC.Name = "_lblFreeC";
            this._lblFreeC.Size = new System.Drawing.Size(88, 13);
            this._lblFreeC.TabIndex = 59;
            this._lblFreeC.Text = "Free Space C:";
            // 
            // _lblInfoFreeC
            // 
            this._lblInfoFreeC.AutoSize = true;
            this._lblInfoFreeC.BackColor = System.Drawing.SystemColors.Control;
            this._lblInfoFreeC.Location = new System.Drawing.Point(100, 75);
            this._lblInfoFreeC.Name = "_lblInfoFreeC";
            this._lblInfoFreeC.Size = new System.Drawing.Size(74, 13);
            this._lblInfoFreeC.TabIndex = 58;
            this._lblInfoFreeC.Text = "lbl_info_FreeC";
            // 
            // _lblRam
            // 
            this._lblRam.AutoSize = true;
            this._lblRam.BackColor = System.Drawing.SystemColors.Control;
            this._lblRam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblRam.Location = new System.Drawing.Point(5, 41);
            this._lblRam.Name = "_lblRam";
            this._lblRam.Size = new System.Drawing.Size(38, 13);
            this._lblRam.TabIndex = 57;
            this._lblRam.Text = "RAM:";
            // 
            // _lblInfoRam
            // 
            this._lblInfoRam.AutoSize = true;
            this._lblInfoRam.BackColor = System.Drawing.SystemColors.Control;
            this._lblInfoRam.Location = new System.Drawing.Point(50, 41);
            this._lblInfoRam.Name = "_lblInfoRam";
            this._lblInfoRam.Size = new System.Drawing.Size(70, 13);
            this._lblInfoRam.TabIndex = 56;
            this._lblInfoRam.Text = "lbl_info_RAM";
            // 
            // _lblOs
            // 
            this._lblOs.AutoSize = true;
            this._lblOs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOs.Location = new System.Drawing.Point(6, 24);
            this._lblOs.Name = "_lblOs";
            this._lblOs.Size = new System.Drawing.Size(28, 13);
            this._lblOs.TabIndex = 55;
            this._lblOs.Text = "OS:";
            // 
            // _lblComputerName
            // 
            this._lblComputerName.AutoSize = true;
            this._lblComputerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblComputerName.Location = new System.Drawing.Point(6, 58);
            this._lblComputerName.Name = "_lblComputerName";
            this._lblComputerName.Size = new System.Drawing.Size(100, 13);
            this._lblComputerName.TabIndex = 52;
            this._lblComputerName.Text = "Computer Name:";
            // 
            // _lblInfoOs
            // 
            this._lblInfoOs.AutoSize = true;
            this._lblInfoOs.Location = new System.Drawing.Point(40, 24);
            this._lblInfoOs.Name = "_lblInfoOs";
            this._lblInfoOs.Size = new System.Drawing.Size(61, 13);
            this._lblInfoOs.TabIndex = 54;
            this._lblInfoOs.Text = "lbl_info_OS";
            // 
            // _lblInfoComputerName
            // 
            this._lblInfoComputerName.AutoSize = true;
            this._lblInfoComputerName.Location = new System.Drawing.Point(112, 59);
            this._lblInfoComputerName.Name = "_lblInfoComputerName";
            this._lblInfoComputerName.Size = new System.Drawing.Size(119, 13);
            this._lblInfoComputerName.TabIndex = 53;
            this._lblInfoComputerName.Text = "lbl_info_ComputerName";
            // 
            // _cmsDeleteQl
            // 
            this._cmsDeleteQl.Name = "Delete";
            this._cmsDeleteQl.Size = new System.Drawing.Size(61, 4);
            this._cmsDeleteQl.Text = "DELETE";
            // 
            // _ddlInfoNetworkAdapters
            // 
            this._ddlInfoNetworkAdapters.FormattingEnabled = true;
            this._ddlInfoNetworkAdapters.Location = new System.Drawing.Point(308, 31);
            this._ddlInfoNetworkAdapters.Name = "_ddlInfoNetworkAdapters";
            this._ddlInfoNetworkAdapters.Size = new System.Drawing.Size(185, 21);
            this._ddlInfoNetworkAdapters.TabIndex = 69;
            this._ddlInfoNetworkAdapters.Text = "Select an Adapter";
            this._ddlInfoNetworkAdapters.SelectedIndexChanged += new System.EventHandler(this.ddl_info_NetworkAdapters_SelectedIndexChanged);
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.BackColor = System.Drawing.SystemColors.Control;
            this._label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._label1.Location = new System.Drawing.Point(305, 56);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(75, 13);
            this._label1.TabIndex = 70;
            this._label1.Text = "Description:";
            // 
            // _lblInfoAdapterDesc
            // 
            this._lblInfoAdapterDesc.AutoSize = true;
            this._lblInfoAdapterDesc.BackColor = System.Drawing.SystemColors.Control;
            this._lblInfoAdapterDesc.Location = new System.Drawing.Point(386, 58);
            this._lblInfoAdapterDesc.MaximumSize = new System.Drawing.Size(170, 13);
            this._lblInfoAdapterDesc.Name = "_lblInfoAdapterDesc";
            this._lblInfoAdapterDesc.Size = new System.Drawing.Size(108, 13);
            this._lblInfoAdapterDesc.TabIndex = 71;
            this._lblInfoAdapterDesc.Text = "lbl_info_AdapterDesc";
            // 
            // _ofdTron
            // 
            this._ofdTron.FileName = "Tron.bat";
            // 
            // testBrowserToolStripMenuItem
            // 
            this.testBrowserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneStopInternalToolStripMenuItem,
            this.launchPortableBrowsersetInConfigToolStripMenuItem});
            this.testBrowserToolStripMenuItem.Name = "testBrowserToolStripMenuItem";
            this.testBrowserToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.testBrowserToolStripMenuItem.Text = "Test Browser";
            // 
            // oneStopInternalToolStripMenuItem
            // 
            this.oneStopInternalToolStripMenuItem.Name = "oneStopInternalToolStripMenuItem";
            this.oneStopInternalToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.oneStopInternalToolStripMenuItem.Text = "OneStop Internal";
            // 
            // launchPortableBrowsersetInConfigToolStripMenuItem
            // 
            this.launchPortableBrowsersetInConfigToolStripMenuItem.Name = "launchPortableBrowsersetInConfigToolStripMenuItem";
            this.launchPortableBrowsersetInConfigToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.launchPortableBrowsersetInConfigToolStripMenuItem.Text = "Launch Portable Browser (set in config)";
            // 
            // forceLogoffToolStripMenuItem
            // 
            this.forceLogoffToolStripMenuItem.Name = "forceLogoffToolStripMenuItem";
            this.forceLogoffToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.forceLogoffToolStripMenuItem.Text = "Force Logoff";
            this.forceLogoffToolStripMenuItem.Click += new System.EventHandler(this.forceLogoffToolStripMenuItem_Click);
            // 
            // connectivityToDefaultGatewayToolStripMenuItem
            // 
            this.connectivityToDefaultGatewayToolStripMenuItem.Name = "connectivityToDefaultGatewayToolStripMenuItem";
            this.connectivityToDefaultGatewayToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.connectivityToDefaultGatewayToolStripMenuItem.Text = "Connectivity to Default Gateway";
            // 
            // tpServers
            // 
            this.tpServers.Controls.Add(this.groupBox1);
            this.tpServers.Controls.Add(this.mailGroupBox);
            this.tpServers.Location = new System.Drawing.Point(4, 22);
            this.tpServers.Name = "tpServers";
            this.tpServers.Padding = new System.Windows.Forms.Padding(3);
            this.tpServers.Size = new System.Drawing.Size(738, 366);
            this.tpServers.TabIndex = 2;
            this.tpServers.Text = "Servers (FTP, Email, etc.)";
            this.tpServers.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(234, 317);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Apply";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(234, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 317);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // mailGroupBox
            // 
            this.mailGroupBox.Controls.Add(this.button2);
            this.mailGroupBox.Controls.Add(this.button4);
            this.mailGroupBox.Controls.Add(this.button1);
            this.mailGroupBox.Controls.Add(this.comboBox2);
            this.mailGroupBox.Controls.Add(this.button3);
            this.mailGroupBox.Controls.Add(this.comboBox1);
            this.mailGroupBox.Controls.Add(this.textBox7);
            this.mailGroupBox.Controls.Add(this.textBox6);
            this.mailGroupBox.Controls.Add(this.label9);
            this.mailGroupBox.Controls.Add(this.label8);
            this.mailGroupBox.Controls.Add(this.label7);
            this.mailGroupBox.Controls.Add(this.label6);
            this.mailGroupBox.Controls.Add(this.label5);
            this.mailGroupBox.Controls.Add(this.textBox5);
            this.mailGroupBox.Controls.Add(this.textBox4);
            this.mailGroupBox.Controls.Add(this.label4);
            this.mailGroupBox.Controls.Add(this.textBox3);
            this.mailGroupBox.Controls.Add(this.label3);
            this.mailGroupBox.Controls.Add(this.label2);
            this.mailGroupBox.Controls.Add(this.textBox2);
            this.mailGroupBox.Controls.Add(this.label1);
            this.mailGroupBox.Controls.Add(this.textBox1);
            this.mailGroupBox.Location = new System.Drawing.Point(6, 6);
            this.mailGroupBox.Name = "mailGroupBox";
            this.mailGroupBox.Size = new System.Drawing.Size(315, 354);
            this.mailGroupBox.TabIndex = 5;
            this.mailGroupBox.TabStop = false;
            this.mailGroupBox.Text = "Email Settings";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboBox2.Location = new System.Drawing.Point(229, 171);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(80, 21);
            this.comboBox2.TabIndex = 12;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboBox1.Location = new System.Drawing.Point(42, 171);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(80, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(94, 256);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(215, 20);
            this.textBox7.TabIndex = 10;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(94, 224);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(215, 20);
            this.textBox6.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Subject Line:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Mail-TO:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(130, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Request Reciept?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "SSL:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mail Server Port:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(94, 123);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(215, 20);
            this.textBox5.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(94, 97);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(215, 20);
            this.textBox4.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "SMTP Server:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(94, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(215, 20);
            this.textBox3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "From Address:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(94, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(215, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 20);
            this.textBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(331, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 142);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FTP Settings";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpSystemReport);
            this.tabControl1.Controls.Add(this.tpNetwork);
            this.tabControl1.Location = new System.Drawing.Point(0, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(745, 386);
            this.tabControl1.TabIndex = 0;
            // 
            // tpNetwork
            // 
            this.tpNetwork.Controls.Add(this.netBox);
            this.tpNetwork.Controls.Add(this.clearSslBTN);
            this.tpNetwork.Controls.Add(this.setGoogleDnsBTN);
            this.tpNetwork.Controls.Add(this.winsockRepBTN);
            this.tpNetwork.Controls.Add(this.clearStaticBTN);
            this.tpNetwork.Controls.Add(this.dnsFlushBTN);
            this.tpNetwork.Controls.Add(this.releaseRenewBTN);
            this.tpNetwork.Controls.Add(this.netCombo);
            this.tpNetwork.Controls.Add(this.button7);
            this.tpNetwork.Controls.Add(this.label10);
            this.tpNetwork.Controls.Add(this.groupBox3);
            this.tpNetwork.Location = new System.Drawing.Point(4, 22);
            this.tpNetwork.Name = "tpNetwork";
            this.tpNetwork.Padding = new System.Windows.Forms.Padding(3);
            this.tpNetwork.Size = new System.Drawing.Size(737, 360);
            this.tpNetwork.TabIndex = 0;
            this.tpNetwork.Text = "Network Configuration";
            this.tpNetwork.UseVisualStyleBackColor = true;
            // 
            // tpSystemReport
            // 
            this.tpSystemReport.Location = new System.Drawing.Point(4, 22);
            this.tpSystemReport.Name = "tpSystemReport";
            this.tpSystemReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpSystemReport.Size = new System.Drawing.Size(737, 360);
            this.tpSystemReport.TabIndex = 1;
            this.tpSystemReport.Text = "System Report";
            this.tpSystemReport.UseVisualStyleBackColor = true;
            // 
            // netBox
            // 
            this.netBox.Location = new System.Drawing.Point(9, 134);
            this.netBox.Multiline = true;
            this.netBox.Name = "netBox";
            this.netBox.ReadOnly = true;
            this.netBox.Size = new System.Drawing.Size(300, 220);
            this.netBox.TabIndex = 22;
            // 
            // clearSslBTN
            // 
            this.clearSslBTN.Location = new System.Drawing.Point(159, 103);
            this.clearSslBTN.Name = "clearSslBTN";
            this.clearSslBTN.Size = new System.Drawing.Size(150, 24);
            this.clearSslBTN.TabIndex = 21;
            this.clearSslBTN.Text = "Clear SSL State";
            this.clearSslBTN.UseVisualStyleBackColor = true;
            // 
            // setGoogleDnsBTN
            // 
            this.setGoogleDnsBTN.Location = new System.Drawing.Point(9, 103);
            this.setGoogleDnsBTN.Name = "setGoogleDnsBTN";
            this.setGoogleDnsBTN.Size = new System.Drawing.Size(150, 24);
            this.setGoogleDnsBTN.TabIndex = 20;
            this.setGoogleDnsBTN.Text = "Change to Google DNS";
            this.setGoogleDnsBTN.UseVisualStyleBackColor = true;
            // 
            // winsockRepBTN
            // 
            this.winsockRepBTN.Location = new System.Drawing.Point(159, 73);
            this.winsockRepBTN.Name = "winsockRepBTN";
            this.winsockRepBTN.Size = new System.Drawing.Size(150, 24);
            this.winsockRepBTN.TabIndex = 19;
            this.winsockRepBTN.Text = "WINSOCK Repair";
            this.winsockRepBTN.UseVisualStyleBackColor = true;
            // 
            // clearStaticBTN
            // 
            this.clearStaticBTN.Location = new System.Drawing.Point(9, 73);
            this.clearStaticBTN.Name = "clearStaticBTN";
            this.clearStaticBTN.Size = new System.Drawing.Size(150, 24);
            this.clearStaticBTN.TabIndex = 18;
            this.clearStaticBTN.Text = "Clear STATIC IP Settings";
            this.clearStaticBTN.UseVisualStyleBackColor = true;
            // 
            // dnsFlushBTN
            // 
            this.dnsFlushBTN.Location = new System.Drawing.Point(159, 43);
            this.dnsFlushBTN.Name = "dnsFlushBTN";
            this.dnsFlushBTN.Size = new System.Drawing.Size(150, 24);
            this.dnsFlushBTN.TabIndex = 17;
            this.dnsFlushBTN.Text = "Flush DNS Cache";
            this.dnsFlushBTN.UseVisualStyleBackColor = true;
            // 
            // releaseRenewBTN
            // 
            this.releaseRenewBTN.Location = new System.Drawing.Point(9, 43);
            this.releaseRenewBTN.Name = "releaseRenewBTN";
            this.releaseRenewBTN.Size = new System.Drawing.Size(150, 24);
            this.releaseRenewBTN.TabIndex = 16;
            this.releaseRenewBTN.Text = "Release and Renew DHCP";
            this.releaseRenewBTN.UseVisualStyleBackColor = true;
            // 
            // netCombo
            // 
            this.netCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.netCombo.FormattingEnabled = true;
            this.netCombo.Items.AddRange(new object[] {
            "Refresh to gather..."});
            this.netCombo.Location = new System.Drawing.Point(69, 10);
            this.netCombo.Name = "netCombo";
            this.netCombo.Size = new System.Drawing.Size(162, 21);
            this.netCombo.TabIndex = 15;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(234, 9);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "Refresh";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Interfaces:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(481, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 228);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Network Information";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label11);
            this.flowLayoutPanel3.Controls.Add(this.hostNameTextB);
            this.flowLayoutPanel3.Controls.Add(this.label12);
            this.flowLayoutPanel3.Controls.Add(this.textBox8);
            this.flowLayoutPanel3.Controls.Add(this.label13);
            this.flowLayoutPanel3.Controls.Add(this.textBox9);
            this.flowLayoutPanel3.Controls.Add(this.label14);
            this.flowLayoutPanel3.Controls.Add(this.textBox10);
            this.flowLayoutPanel3.Controls.Add(this.label15);
            this.flowLayoutPanel3.Controls.Add(this.textBox11);
            this.flowLayoutPanel3.Controls.Add(this.label16);
            this.flowLayoutPanel3.Controls.Add(this.textBox12);
            this.flowLayoutPanel3.Controls.Add(this.label17);
            this.flowLayoutPanel3.Controls.Add(this.textBox13);
            this.flowLayoutPanel3.Controls.Add(this.label18);
            this.flowLayoutPanel3.Controls.Add(this.pubIPTextB);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(244, 209);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label11.Size = new System.Drawing.Size(71, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "HOSTNAME:";
            // 
            // hostNameTextB
            // 
            this.hostNameTextB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hostNameTextB.Location = new System.Drawing.Point(80, 3);
            this.hostNameTextB.Name = "hostNameTextB";
            this.hostNameTextB.Size = new System.Drawing.Size(160, 20);
            this.hostNameTextB.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 26);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label12.Size = new System.Drawing.Size(57, 19);
            this.label12.TabIndex = 2;
            this.label12.Text = "LOCAL IP:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(80, 29);
            this.textBox8.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(160, 20);
            this.textBox8.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 52);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label13.Size = new System.Drawing.Size(33, 19);
            this.label13.TabIndex = 4;
            this.label13.Text = "MAC:";
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Location = new System.Drawing.Point(80, 55);
            this.textBox9.Margin = new System.Windows.Forms.Padding(41, 3, 3, 3);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(160, 20);
            this.textBox9.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 78);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label14.Size = new System.Drawing.Size(64, 19);
            this.label14.TabIndex = 6;
            this.label14.Text = "GATEWAY:";
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Location = new System.Drawing.Point(80, 81);
            this.textBox10.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(160, 20);
            this.textBox10.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 104);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label15.Size = new System.Drawing.Size(33, 19);
            this.label15.TabIndex = 8;
            this.label15.Text = "DNS:";
            // 
            // textBox11
            // 
            this.textBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox11.Location = new System.Drawing.Point(80, 107);
            this.textBox11.Margin = new System.Windows.Forms.Padding(41, 3, 3, 3);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(160, 20);
            this.textBox11.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 130);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label16.Size = new System.Drawing.Size(40, 19);
            this.label16.TabIndex = 10;
            this.label16.Text = "DHCP:";
            // 
            // textBox12
            // 
            this.textBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox12.Location = new System.Drawing.Point(80, 133);
            this.textBox12.Margin = new System.Windows.Forms.Padding(34, 3, 3, 3);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(160, 20);
            this.textBox12.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 156);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label17.Size = new System.Drawing.Size(54, 19);
            this.label17.TabIndex = 12;
            this.label17.Text = "SUBNET:";
            // 
            // textBox13
            // 
            this.textBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox13.Location = new System.Drawing.Point(80, 159);
            this.textBox13.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(160, 20);
            this.textBox13.TabIndex = 13;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 182);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label18.Size = new System.Drawing.Size(61, 19);
            this.label18.TabIndex = 14;
            this.label18.Text = "PUBLIC IP:";
            // 
            // pubIPTextB
            // 
            this.pubIPTextB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pubIPTextB.Location = new System.Drawing.Point(80, 185);
            this.pubIPTextB.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.pubIPTextB.Name = "pubIPTextB";
            this.pubIPTextB.Size = new System.Drawing.Size(160, 20);
            this.pubIPTextB.TabIndex = 15;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(278, 225);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(127, 13);
            this.linkLabel2.TabIndex = 85;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "TronScript by /u/vocatus";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button5.Enabled = false;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(579, 125);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 23);
            this.button5.TabIndex = 86;
            this.button5.Text = "Check All Flags";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(8, 356);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 29);
            this.button6.TabIndex = 82;
            this.button6.Text = ">> Locate Tron <<";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(362, 174);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 129);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(24, 111);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(119, 23);
            this.button8.TabIndex = 6;
            this.button8.Text = "Scripts Folder";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(149, 111);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(119, 23);
            this.button9.TabIndex = 7;
            this.button9.Text = "Documents Folder";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(149, 140);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(119, 23);
            this.button10.TabIndex = 9;
            this.button10.Text = "Installers Folder";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(24, 140);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(119, 23);
            this.button11.TabIndex = 8;
            this.button11.Text = "Third Party Apps";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // tpIntegration
            // 
            this.tpIntegration.Controls.Add(this.groupBox11);
            this.tpIntegration.Location = new System.Drawing.Point(4, 22);
            this.tpIntegration.Name = "tpIntegration";
            this.tpIntegration.Size = new System.Drawing.Size(738, 366);
            this.tpIntegration.TabIndex = 3;
            this.tpIntegration.Text = "Ticket/CRM Integration";
            this.tpIntegration.UseVisualStyleBackColor = true;
            // 
            // tpLogging
            // 
            this.tpLogging.Controls.Add(this.groupBox14);
            this.tpLogging.Controls.Add(this.groupBox13);
            this.tpLogging.Controls.Add(this.groupBox12);
            this.tpLogging.Location = new System.Drawing.Point(4, 22);
            this.tpLogging.Name = "tpLogging";
            this.tpLogging.Size = new System.Drawing.Size(738, 366);
            this.tpLogging.TabIndex = 4;
            this.tpLogging.Text = "Logging Control";
            this.tpLogging.UseVisualStyleBackColor = true;
            // 
            // cbCMDLog
            // 
            this.cbCMDLog.AutoSize = true;
            this.cbCMDLog.Location = new System.Drawing.Point(6, 19);
            this.cbCMDLog.Name = "cbCMDLog";
            this.cbCMDLog.Size = new System.Drawing.Size(103, 17);
            this.cbCMDLog.TabIndex = 0;
            this.cbCMDLog.Text = "Send to Log File";
            this.cbCMDLog.UseVisualStyleBackColor = true;
            // 
            // cbCMDConsole
            // 
            this.cbCMDConsole.AutoSize = true;
            this.cbCMDConsole.Location = new System.Drawing.Point(6, 42);
            this.cbCMDConsole.Name = "cbCMDConsole";
            this.cbCMDConsole.Size = new System.Drawing.Size(104, 17);
            this.cbCMDConsole.TabIndex = 1;
            this.cbCMDConsole.Text = "Send to Console";
            this.cbCMDConsole.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCMDLog);
            this.groupBox2.Controls.Add(this.cbCMDConsole);
            this.groupBox2.Location = new System.Drawing.Point(18, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 66);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CMD Commands";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbRegistryLog);
            this.groupBox5.Controls.Add(this.cbRegistryConsole);
            this.groupBox5.Location = new System.Drawing.Point(18, 163);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(124, 66);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Registry Changes";
            // 
            // cbRegistryLog
            // 
            this.cbRegistryLog.AutoSize = true;
            this.cbRegistryLog.Location = new System.Drawing.Point(6, 19);
            this.cbRegistryLog.Name = "cbRegistryLog";
            this.cbRegistryLog.Size = new System.Drawing.Size(103, 17);
            this.cbRegistryLog.TabIndex = 0;
            this.cbRegistryLog.Text = "Send to Log File";
            this.cbRegistryLog.UseVisualStyleBackColor = true;
            // 
            // cbRegistryConsole
            // 
            this.cbRegistryConsole.AutoSize = true;
            this.cbRegistryConsole.Location = new System.Drawing.Point(6, 42);
            this.cbRegistryConsole.Name = "cbRegistryConsole";
            this.cbRegistryConsole.Size = new System.Drawing.Size(104, 17);
            this.cbRegistryConsole.TabIndex = 1;
            this.cbRegistryConsole.Text = "Send to Console";
            this.cbRegistryConsole.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbWebsitesLog);
            this.groupBox6.Controls.Add(this.cbWebsitesConsole);
            this.groupBox6.Location = new System.Drawing.Point(148, 163);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(124, 66);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Visited Websites";
            // 
            // cbWebsitesLog
            // 
            this.cbWebsitesLog.AutoSize = true;
            this.cbWebsitesLog.Location = new System.Drawing.Point(6, 19);
            this.cbWebsitesLog.Name = "cbWebsitesLog";
            this.cbWebsitesLog.Size = new System.Drawing.Size(103, 17);
            this.cbWebsitesLog.TabIndex = 0;
            this.cbWebsitesLog.Text = "Send to Log File";
            this.cbWebsitesLog.UseVisualStyleBackColor = true;
            // 
            // cbWebsitesConsole
            // 
            this.cbWebsitesConsole.AutoSize = true;
            this.cbWebsitesConsole.Location = new System.Drawing.Point(6, 42);
            this.cbWebsitesConsole.Name = "cbWebsitesConsole";
            this.cbWebsitesConsole.Size = new System.Drawing.Size(104, 17);
            this.cbWebsitesConsole.TabIndex = 1;
            this.cbWebsitesConsole.Text = "Send to Console";
            this.cbWebsitesConsole.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbGPLNoticeLog);
            this.groupBox7.Controls.Add(this.cbGPLConsole);
            this.groupBox7.Location = new System.Drawing.Point(148, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(124, 66);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "GPL Notice";
            // 
            // cbGPLNoticeLog
            // 
            this.cbGPLNoticeLog.AutoSize = true;
            this.cbGPLNoticeLog.Location = new System.Drawing.Point(6, 19);
            this.cbGPLNoticeLog.Name = "cbGPLNoticeLog";
            this.cbGPLNoticeLog.Size = new System.Drawing.Size(103, 17);
            this.cbGPLNoticeLog.TabIndex = 0;
            this.cbGPLNoticeLog.Text = "Send to Log File";
            this.cbGPLNoticeLog.UseVisualStyleBackColor = true;
            // 
            // cbGPLConsole
            // 
            this.cbGPLConsole.AutoSize = true;
            this.cbGPLConsole.Location = new System.Drawing.Point(6, 42);
            this.cbGPLConsole.Name = "cbGPLConsole";
            this.cbGPLConsole.Size = new System.Drawing.Size(104, 17);
            this.cbGPLConsole.TabIndex = 1;
            this.cbGPLConsole.Text = "Send to Console";
            this.cbGPLConsole.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbOSStartLog);
            this.groupBox8.Controls.Add(this.cbOSStartConsole);
            this.groupBox8.Location = new System.Drawing.Point(148, 91);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(124, 66);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "OneStop Startup";
            // 
            // cbOSStartLog
            // 
            this.cbOSStartLog.AutoSize = true;
            this.cbOSStartLog.Location = new System.Drawing.Point(6, 19);
            this.cbOSStartLog.Name = "cbOSStartLog";
            this.cbOSStartLog.Size = new System.Drawing.Size(103, 17);
            this.cbOSStartLog.TabIndex = 0;
            this.cbOSStartLog.Text = "Send to Log File";
            this.cbOSStartLog.UseVisualStyleBackColor = true;
            // 
            // cbOSStartConsole
            // 
            this.cbOSStartConsole.AutoSize = true;
            this.cbOSStartConsole.Location = new System.Drawing.Point(6, 42);
            this.cbOSStartConsole.Name = "cbOSStartConsole";
            this.cbOSStartConsole.Size = new System.Drawing.Size(104, 17);
            this.cbOSStartConsole.TabIndex = 1;
            this.cbOSStartConsole.Text = "Send to Console";
            this.cbOSStartConsole.UseVisualStyleBackColor = true;
            // 
            // cbVerboseErrorConsole
            // 
            this.cbVerboseErrorConsole.AutoSize = true;
            this.cbVerboseErrorConsole.Location = new System.Drawing.Point(6, 42);
            this.cbVerboseErrorConsole.Name = "cbVerboseErrorConsole";
            this.cbVerboseErrorConsole.Size = new System.Drawing.Size(104, 17);
            this.cbVerboseErrorConsole.TabIndex = 1;
            this.cbVerboseErrorConsole.Text = "Send to Console";
            this.cbVerboseErrorConsole.UseVisualStyleBackColor = true;
            // 
            // cbVerboseErrorLog
            // 
            this.cbVerboseErrorLog.AutoSize = true;
            this.cbVerboseErrorLog.Location = new System.Drawing.Point(6, 19);
            this.cbVerboseErrorLog.Name = "cbVerboseErrorLog";
            this.cbVerboseErrorLog.Size = new System.Drawing.Size(103, 17);
            this.cbVerboseErrorLog.TabIndex = 0;
            this.cbVerboseErrorLog.Text = "Send to Log File";
            this.cbVerboseErrorLog.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbVerboseErrorLog);
            this.groupBox4.Controls.Add(this.cbVerboseErrorConsole);
            this.groupBox4.Location = new System.Drawing.Point(18, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(124, 66);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Verbose Error Msgs";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cbSysInfoLog);
            this.groupBox9.Controls.Add(this.cbSysinfoConsole);
            this.groupBox9.Location = new System.Drawing.Point(148, 235);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(124, 66);
            this.groupBox9.TabIndex = 9;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Generic System Info";
            // 
            // cbSysInfoLog
            // 
            this.cbSysInfoLog.AutoSize = true;
            this.cbSysInfoLog.Location = new System.Drawing.Point(6, 19);
            this.cbSysInfoLog.Name = "cbSysInfoLog";
            this.cbSysInfoLog.Size = new System.Drawing.Size(103, 17);
            this.cbSysInfoLog.TabIndex = 0;
            this.cbSysInfoLog.Text = "Send to Log File";
            this.cbSysInfoLog.UseVisualStyleBackColor = true;
            // 
            // cbSysinfoConsole
            // 
            this.cbSysinfoConsole.AutoSize = true;
            this.cbSysinfoConsole.Location = new System.Drawing.Point(6, 42);
            this.cbSysinfoConsole.Name = "cbSysinfoConsole";
            this.cbSysinfoConsole.Size = new System.Drawing.Size(104, 17);
            this.cbSysinfoConsole.TabIndex = 1;
            this.cbSysinfoConsole.Text = "Send to Console";
            this.cbSysinfoConsole.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.cbOpenedLog);
            this.groupBox10.Controls.Add(this.cbOpenedConsole);
            this.groupBox10.Location = new System.Drawing.Point(18, 235);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(124, 66);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Opened Programs";
            // 
            // cbOpenedLog
            // 
            this.cbOpenedLog.AutoSize = true;
            this.cbOpenedLog.Location = new System.Drawing.Point(6, 19);
            this.cbOpenedLog.Name = "cbOpenedLog";
            this.cbOpenedLog.Size = new System.Drawing.Size(103, 17);
            this.cbOpenedLog.TabIndex = 0;
            this.cbOpenedLog.Text = "Send to Log File";
            this.cbOpenedLog.UseVisualStyleBackColor = true;
            // 
            // cbOpenedConsole
            // 
            this.cbOpenedConsole.AutoSize = true;
            this.cbOpenedConsole.Location = new System.Drawing.Point(6, 42);
            this.cbOpenedConsole.Name = "cbOpenedConsole";
            this.cbOpenedConsole.Size = new System.Drawing.Size(104, 17);
            this.cbOpenedConsole.TabIndex = 1;
            this.cbOpenedConsole.Text = "Send to Console";
            this.cbOpenedConsole.UseVisualStyleBackColor = true;
            // 
            // btnSaveLoggingStatus
            // 
            this.btnSaveLoggingStatus.Location = new System.Drawing.Point(148, 318);
            this.btnSaveLoggingStatus.Name = "btnSaveLoggingStatus";
            this.btnSaveLoggingStatus.Size = new System.Drawing.Size(124, 23);
            this.btnSaveLoggingStatus.TabIndex = 10;
            this.btnSaveLoggingStatus.Text = "Save";
            this.btnSaveLoggingStatus.UseVisualStyleBackColor = true;
            this.btnSaveLoggingStatus.Click += new System.EventHandler(this.btnSaveLoggingStatus_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.checkBox2);
            this.groupBox11.Controls.Add(this.button12);
            this.groupBox11.Controls.Add(this.checkBox1);
            this.groupBox11.Controls.Add(this.label22);
            this.groupBox11.Controls.Add(this.textBox17);
            this.groupBox11.Controls.Add(this.label23);
            this.groupBox11.Controls.Add(this.textBox18);
            this.groupBox11.Location = new System.Drawing.Point(23, 14);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(349, 166);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "OS Ticket";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 49);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 13);
            this.label22.TabIndex = 7;
            this.label22.Text = "API Key:";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(99, 46);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(237, 20);
            this.textBox17.TabIndex = 10;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 13);
            this.label23.TabIndex = 6;
            this.label23.Text = "Your TLD:";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(99, 20);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(237, 20);
            this.textBox18.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 84);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(134, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Enable Ticket Creation";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(268, 137);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(68, 23);
            this.button12.TabIndex = 12;
            this.button12.Text = "Save";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 108);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(324, 17);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "Ask for ticket name on start? (Default = Date + ComputerName)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.checkBox4);
            this.groupBox12.Controls.Add(this.checkBox3);
            this.groupBox12.Controls.Add(this.label19);
            this.groupBox12.Controls.Add(this.button14);
            this.groupBox12.Controls.Add(this.textBox14);
            this.groupBox12.Controls.Add(this.button13);
            this.groupBox12.Location = new System.Drawing.Point(307, 13);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(317, 127);
            this.groupBox12.TabIndex = 11;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Custom Log Location + Name";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(231, 98);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 0;
            this.button13.Text = "Save";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.groupBox4);
            this.groupBox13.Controls.Add(this.groupBox2);
            this.groupBox13.Controls.Add(this.btnSaveLoggingStatus);
            this.groupBox13.Controls.Add(this.groupBox8);
            this.groupBox13.Controls.Add(this.groupBox9);
            this.groupBox13.Controls.Add(this.groupBox7);
            this.groupBox13.Controls.Add(this.groupBox10);
            this.groupBox13.Controls.Add(this.groupBox5);
            this.groupBox13.Controls.Add(this.groupBox6);
            this.groupBox13.Location = new System.Drawing.Point(16, 13);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(285, 347);
            this.groupBox13.TabIndex = 12;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Set Logging Events";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(18, 20);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(194, 20);
            this.textBox14.TabIndex = 1;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(231, 17);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 2;
            this.button14.Text = "Browse";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(123, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "lbl_Logging_CurrentPath";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(21, 67);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(193, 17);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "Include ComputerName in Filename";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(21, 90);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(143, 17);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "Include Date in Filename";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.checkBox6);
            this.groupBox14.Controls.Add(this.checkBox5);
            this.groupBox14.Location = new System.Drawing.Point(307, 146);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(317, 100);
            this.groupBox14.TabIndex = 13;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Behaviors";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(7, 20);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(210, 17);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Text = "Also export Console to text file with Log";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(7, 44);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 1;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // lblBootStatus
            // 
            this.lblBootStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblBootStatus.Name = "lblBootStatus";
            this.lblBootStatus.Size = new System.Drawing.Size(77, 22);
            this.lblBootStatus.Text = "lblBootStatus";
            // 
            // lblTronStatus
            // 
            this.lblTronStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTronStatus.Name = "lblTronStatus";
            this.lblTronStatus.Size = new System.Drawing.Size(76, 22);
            this.lblTronStatus.Text = "lblTronStatus";
            // 
            // OsMain
            // 
            this.ClientSize = new System.Drawing.Size(754, 531);
            this.Controls.Add(this._lblInfoAdapterDesc);
            this.Controls.Add(this._label1);
            this.Controls.Add(this._ddlInfoNetworkAdapters);
            this.Controls.Add(this._lnkInfoInternalIp);
            this.Controls.Add(this._lblInfoExternalIp);
            this.Controls.Add(this._lnkInfoGateway);
            this.Controls.Add(this._lnkInfoPrimDns);
            this.Controls.Add(this._lblDns);
            this.Controls.Add(this._lblGateway);
            this.Controls.Add(this._lblExternalIp);
            this.Controls.Add(this._lblInternalIp);
            this.Controls.Add(this._lblFreeC);
            this.Controls.Add(this._lblInfoFreeC);
            this.Controls.Add(this._lblRam);
            this.Controls.Add(this._lblInfoRam);
            this.Controls.Add(this._lblOs);
            this.Controls.Add(this._lblComputerName);
            this.Controls.Add(this._lblInfoOs);
            this.Controls.Add(this._lblInfoComputerName);
            this.Controls.Add(this._tcPrimaryTabs);
            this.Controls.Add(this._tsBottomToolbar);
            this.Controls.Add(this._menuPrimary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MainMenuStrip = this._menuPrimary;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OsMain";
            this.Load += new System.EventHandler(this.OS_Main_Load);
            this._tsBottomToolbar.ResumeLayout(false);
            this._tsBottomToolbar.PerformLayout();
            this._menuPrimary.ResumeLayout(false);
            this._menuPrimary.PerformLayout();
            this._tcPrimaryTabs.ResumeLayout(false);
            this._tpWelcome.ResumeLayout(false);
            this._tpWelcome.PerformLayout();
            this._tpOneStopMain.ResumeLayout(false);
            this._tpOneStopMain.PerformLayout();
            this._tpTronCli.ResumeLayout(false);
            this._tpTronSettings.ResumeLayout(false);
            this._tpLaunchTron.ResumeLayout(false);
            this._tpLaunchTron.PerformLayout();
            this._tpSystemInfo.ResumeLayout(false);
            this._tpConfigurator.ResumeLayout(false);
            this._tcConfigurator.ResumeLayout(false);
            this._tpSetup.ResumeLayout(false);
            this._tabControl2.ResumeLayout(false);
            this.tpQuickLaunch.ResumeLayout(false);
            this.tpQuickLaunch.PerformLayout();
            this.tpShopSettings.ResumeLayout(false);
            this.tpShopSettings.PerformLayout();
            this.tpServers.ResumeLayout(false);
            this.mailGroupBox.ResumeLayout(false);
            this.mailGroupBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpNetwork.ResumeLayout(false);
            this.tpNetwork.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tpIntegration.ResumeLayout(false);
            this.tpLogging.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region methods

        public string LoadTitleBar()
        {
            var strVersion = "OneStop 1.0 Beta";
            var strNameofShop = Settings.Default.str_Shop_Name;
            var strComputerName = OsSystem.GetMachineName();
            var strOs = OsSystem.GetOsFriendlyName() + "-" + OsSystem.GetArch();
            var strOutput = strVersion + " - " + strNameofShop + " (" + strComputerName + " - " + strOs + ")";
            return strOutput;
        }


        private void TronEnable(string statusMsg, string path)
        {
            lblAdminStatus.ForeColor = Color.Green;
            _foldersToolStripMenuItem.Enabled = true;
            _btnConfigDump.Enabled = true;
            _btnRunTron.Enabled = true;
            _btnDryRun.Enabled = true;
            _btnTronSaveFlags.Enabled = true;
            _foldersToolStripMenuItem.Enabled = true;

            //Enable CBs
            EnableTronCBs();

            //Code to populate CBs.
            PopulateTronCBs();

            string strAdminStatus = BoolAdminStatus ? "ADMIN" : "NOT ADMIN";
            
            lblAdminStatus.Text = StrTronStatus + strAdminStatus;
        }

        private void EnableTronCBs()
        {
            _cbTronDev.Enabled = true;
            _cbTronE.Enabled = true;
            _cbTronEr.Enabled = true;
            _cbTronM.Enabled = true;
            _cbTronO.Enabled = true;
            _cbTronP.Enabled = true;
            _cbTronR.Enabled = true;
            _cbTronSa.Enabled = true;
            _cbTronSb.Enabled = true;
            _cbTronSd.Enabled = true;
            _cbTronSdc.Enabled = true;
            _cbTronSe.Enabled = true;
            _cbTronSfr.Enabled = true;
            _cbTronSk.Enabled = true;
            _cbTronSm.Enabled = true;
            _cbTronSp.Enabled = true;
            _cbTronSpr.Enabled = true;
            _cbTronSrr.Enabled = true;
            _cbTronSs.Enabled = true;
            _cbTronStr.Enabled = true;
            _cbTronSw.Enabled = true;
            _cbTronV.Enabled = true;
            _cbTronX.Enabled = true;
        }

        private void PopulateTronCBs()
        {
            if (Settings.Default.bool_tron_dev)
            {
                _cbTronDev.Checked = true;
            }
            if (Settings.Default.bool_tron_e)
            {
                _cbTronE.Checked = true;
            }
            if (Settings.Default.bool_tron_er)
            {
                _cbTronEr.Checked = true;
            }
            if (Settings.Default.bool_tron_m)
            {
                _cbTronM.Checked = true;
            }
            if (Settings.Default.bool_tron_o)
            {
                _cbTronO.Checked = true;
            }
            if (Settings.Default.bool_tron_p)
            {
                _cbTronP.Checked = true;
            }
            if (Settings.Default.bool_tron_r)
            {
                _cbTronR.Checked = true;
            }
            if (Settings.Default.bool_tron_sa)
            {
                _cbTronSa.Checked = true;
            }
            if (Settings.Default.bool_tron_sb)
            {
                _cbTronSb.Checked = true;
            }
            if (Settings.Default.bool_tron_sd)
            {
                _cbTronSd.Checked = true;
            }
            if (Settings.Default.bool_tron_sdc)
            {
                _cbTronSdc.Checked = true;
            }
            if (Settings.Default.bool_tron_se)
            {
                _cbTronSe.Checked = true;
            }
            if (Settings.Default.bool_tron_sfr)
            {
                _cbTronSfr.Checked = true;
            }
            if (Settings.Default.bool_tron_sk)
            {
                _cbTronSk.Checked = true;
            }
            if (Settings.Default.bool_tron_sm)
            {
                _cbTronSm.Checked = true;
            }
            if (Settings.Default.bool_tron_sp)
            {
                _cbTronSp.Checked = true;
            }
            if (Settings.Default.bool_tron_spr)
            {
                _cbTronSpr.Checked = true;
            }
            if (Settings.Default.bool_tron_srr)
            {
                _cbTronSrr.Checked = true;
            }
            if (Settings.Default.bool_tron_ss)
            {
                _cbTronSs.Checked = true;
            }
            if (Settings.Default.bool_tron_str)
            {
                _cbTronStr.Checked = true;
            }
            if (Settings.Default.bool_tron_sw)
            {
                _cbTronSw.Checked = true;
            }
            if (Settings.Default.bool_tron_v)
            {
                _cbTronV.Checked = true;
            }
            if (Settings.Default.bool_tron_x)
            {
                _cbTronX.Checked = true;
            }
        }

        private void TronDisable(string statusMsg)
        {
            lblAdminStatus.ForeColor = Color.Red;
            _foldersToolStripMenuItem.Enabled = false;
            _btnTronSaveFlags.Enabled = false;
            _btnConfigDump.Enabled = false;
            _btnRunTron.Enabled = false;
            _btnDryRun.Enabled = false;
            _btnTronSaveFlags.Enabled = false;

            //Empty CBs
            UncheckTronCBs();

            //Code to populate CBs.
            PopulateTronCBs();

            //Disable CBs
            DisableTronCBs();
        }

        private void UncheckTronCBs()
        {
            _cbTronDev.Checked = false;
            _cbTronE.Checked = false;
            _cbTronEr.Checked = false;
            _cbTronM.Checked = false;
            _cbTronO.Checked = false;
            _cbTronP.Checked = false;
            _cbTronR.Checked = false;
            _cbTronSa.Checked = false;
            _cbTronSb.Checked = false;
            _cbTronSd.Checked = false;
            _cbTronSdc.Checked = false;
            _cbTronSe.Checked = false;
            _cbTronSfr.Checked = false;
            _cbTronSk.Checked = false;
            _cbTronSm.Checked = false;
            _cbTronSp.Checked = false;
            _cbTronSpr.Checked = false;
            _cbTronSrr.Checked = false;
            _cbTronSs.Checked = false;
            _cbTronStr.Checked = false;
            _cbTronSw.Checked = false;
            _cbTronV.Checked = false;
            _cbTronX.Checked = false;
        }

        private void DisableTronCBs()
        {
            _cbTronDev.Enabled = false;
            _cbTronE.Enabled = false;
            _cbTronEr.Enabled = false;
            _cbTronM.Enabled = false;
            _cbTronO.Enabled = false;
            _cbTronP.Enabled = false;
            _cbTronR.Enabled = false;
            _cbTronSa.Enabled = false;
            _cbTronSb.Enabled = false;
            _cbTronSd.Enabled = false;
            _cbTronSdc.Enabled = false;
            _cbTronSe.Enabled = false;
            _cbTronSfr.Enabled = false;
            _cbTronSk.Enabled = false;
            _cbTronSm.Enabled = false;
            _cbTronSp.Enabled = false;
            _cbTronSpr.Enabled = false;
            _cbTronSrr.Enabled = false;
            _cbTronSs.Enabled = false;
            _cbTronStr.Enabled = false;
            _cbTronSw.Enabled = false;
            _cbTronV.Enabled = false;
            _cbTronX.Enabled = false;
        }

        private void EnumerateScripts(string strScriptsDirectory)
        {
            try
            {
                string directorytocreate = Directory.GetCurrentDirectory() + "\\Scripts\\";

                var directoryInfo = new FileInfo(directorytocreate).Directory;
                if (directoryInfo != null) directoryInfo.Create();
            }
            catch (Exception e)
            {
                OSConsole("Attempted to Create Scripts directory but failed" + e, intVerboseErrorMode);
            }
            
            try
            {
                if(new DirectoryInfo(strScriptsDirectory).Exists)
                { 
                var s = new DirectoryInfo(strScriptsDirectory);
 
                var files = s.GetFiles("*.*");
                foreach (var file in files)
                {
                    var extension = Path.GetExtension(Convert.ToString(file)).ToUpper();

                    if (extension == ".BAT" || extension == ".COM" || extension == ".EXE" || extension == ".HTA" ||
                        extension == ".CMD" || extension == ".VB" || extension == ".VBS" || extension == ".VBE" ||
                        extension == ".JS" || extension == ".JSE" || extension == ".WS" || extension == ".WSF" ||
                        extension == ".WSC" || extension == ".WSH" || extension == ".PS1" || extension == ".PS1XML" ||
                        extension == ".PS2" || extension == ".PS2XML" || extension == ".PSC1" || extension == ".PSC2" ||
                        extension == ".MSH" || extension == ".MSH1" || extension == ".MSH2" || extension == ".MSHXML" ||
                        extension == ".MXS1XML" || extension == ".MSH2XML")
                    {
                        ToolStripItem subItem = new ToolStripMenuItem();
                        subItem.Click += MenuClickedScripts;
                        subItem.Text = Convert.ToString(file);
                        _scriptsToolStripMenuItem.DropDownItems.Add(subItem);
                    }
                }
                }
                else
                {
                    OSConsole("Scripts Directory Does not Exist", intVerboseErrorMode);
                }
            }
            catch (UnauthorizedAccessException uaEx)
            {
                OSConsole("Exeption Thrown: Enumerating Scripts Directory - " + uaEx.Message, intVerboseErrorMode);
            }
            catch (PathTooLongException pathEx)
            {
                OSConsole("Exeption Thrown: Enumerating Scripts Directory - " + pathEx.Message, intVerboseErrorMode);
            }
            catch
            {
                OSConsole("Exeption Thrown: Enumerating Scripts Directory - Unknown", intVerboseErrorMode);
            }
        }


        public void OSLaunch(string path)
        {
            OSLaunch(path, null);
        }

        public void OSLaunch(string path, string mode)
        {
            OSLaunch(path, mode, null);
        }

        public void OSLaunch(string path, string mode, string args)
        {
            OSLaunch(path, mode, args, false);
        }
        
        private static string GetBrowserPath()
        {
            //Stackoverflow User neminem
            string browser = string.Empty;
            RegistryKey key = null;

            try
            {
                // try location of default browser path in XP
                key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

                // try location of default browser path in Vista
                if (key == null)
                {
                    key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http", false); ;
                }

                if (key != null)
                {
                    //trim off quotes
                    browser = key.GetValue(null).ToString().ToLower().Replace("\"", "");
                    if (!browser.EndsWith("exe"))
                    {
                        //get rid of everything after the ".exe"
                        browser = browser.Substring(0, browser.LastIndexOf(".exe") + 4);
                    }

                    key.Close();
                }
            }
            catch
            {
                return string.Empty;
            }

            return browser;
        }

        public void OSLaunch(string path, string mode, string args, bool wait)
        {
            //Valid modes = prompt, dll, web, folder, standard (or null)
            //prompt_open leaves cmd window open at end prompt_close or prompt closes it.
            //bool wait = if true wait for finish

            if (path == "cmd")
            {
                path = "CMD.exe";
            }
            if (mode == "prompt")
            {
                mode = "prompt_close";
            }

            string output = "";
            string errorcode = "";
            
            if (mode == "web")
            {
                OSConsole("Launched Website: " + path, intWebsiteMode);
                string browserPath = GetBrowserPath();
                if (browserPath == string.Empty)
                    browserPath = "iexplore";
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo(browserPath);
                process.StartInfo.Arguments = "\"" + path + "\"";
                process.Start();
            }
            else if (mode == "tron_folder")
            {
                try
                {
                    Process.Start(@StrTronPath + "\\Resources\\" + path);
                }
                catch (Exception e)
                {
                    OSConsole("Folder Failed to Open: " + e, intVerboseErrorMode);
                }
            }
            else if (mode == "folder")
            {
                
                try
                {
                    Process.Start(path);
                }
                catch (Exception e)
                {
                    OSConsole("Folder Failed to Open: " + e, intVerboseErrorMode);
                }

            }
            else if (mode == "dll")
            {
                OSConsole("Executing DLL Command: " + path, intCMDCommandMode);
                System.Diagnostics.Process.Start("CMD.exe", " /c " + path);
            }
            else if (mode == "prompt_open")
            {
                //k
                OSConsole("Executing System Command: " + args, intCMDCommandMode);

                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.RedirectStandardOutput = true;
                    startInfo.RedirectStandardError = true;
                    startInfo.FileName = path;
                    if (args != null) { startInfo.Arguments = " /k " + args; }
                    startInfo.UseShellExecute = false;

                    Process process = new Process();
                    process.StartInfo = startInfo;
                    process.EnableRaisingEvents = true;

                    process.Start();

                    if (wait) { process.WaitForExit(); }

                    output = process.StandardOutput.ReadToEnd();
                }
                catch (Exception e)
                {
                    OSConsole("Caught Exception: " + e, intVerboseErrorMode);
                }
                OSConsole(output, 1);

            }
            else if (mode == "prompt_close")
            {
                // c
                OSConsole("Executing System Command: " + args, intCMDCommandMode);
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.RedirectStandardOutput = true;
                    startInfo.RedirectStandardError = true;
                    startInfo.FileName = path;
                    if (args != null) {startInfo.Arguments = " /c " + args;}
                    startInfo.UseShellExecute = false;

                    Process process = new Process();
                    process.StartInfo = startInfo;
                    process.EnableRaisingEvents = true;

                    process.Start();

                    if (wait) { process.WaitForExit(); }

                    output = process.StandardOutput.ReadToEnd();

                    if (process.HasExited)
                    {
                        if (process.ExitCode == 0)
                        {
                            OSConsole(output, intCMDCommandMode);
                            OSConsole("Exited successfully", intCMDCommandMode);
                        }
                        else
                        {
                            OSConsole(output, intVerboseErrorMode);
                            OSConsole("Exited with code: " + process.ExitCode, intVerboseErrorMode);
                        }
                    }
                    
                }
                catch (Exception e)
                {
                    OSConsole("Caught Exception: " + e, intVerboseErrorMode);
                }
                
            }
           
            
            else
            { 
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.RedirectStandardOutput = true;
                    startInfo.RedirectStandardError = true;
                    startInfo.FileName = path;
                    if (args != null) startInfo.Arguments = args;
                    startInfo.UseShellExecute = false;

                    Process process = new Process();
                    process.StartInfo = startInfo;
                    process.EnableRaisingEvents = true;

                    process.Start();

                    if(wait){process.WaitForExit();}

                    output = process.StandardOutput.ReadToEnd();
                }
                catch (Exception e)
                {
                    OSConsole("Caught Exception: " + e, intVerboseErrorMode);
                }
                OSConsole(output, intCMDCommandMode);

            }
        }


        private void EnumerateDocs(string strDocsDirectory)
        {
            try
            {
                string directorytocreate = Directory.GetCurrentDirectory() + "\\Documents\\";

                var directoryInfo = new FileInfo(directorytocreate).Directory;
                if (directoryInfo != null) directoryInfo.Create();
            }
            catch (Exception e)
            {
                OSConsole("Attempted to create Documents directory but failed", intVerboseErrorMode);
            }

            try
            {
                if (new DirectoryInfo(strDocsDirectory).Exists)
                {
                    var d = new DirectoryInfo(strDocsDirectory);
                    var filesDocs = d.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                    foreach (var fileDoc in filesDocs)
                    {
                        var extension = Path.GetExtension(Convert.ToString(fileDoc).ToUpper());

                        if (extension == ".602" || extension == ".ABW" || extension == ".ANS" || extension == ".ASC" ||
                            extension == ".CSV" || extension == ".DOC" || extension == ".DOCM" || extension == ".DOCX" ||
                            extension == ".DOT" || extension == ".DOTX" || extension == ".EPUB" || extension == ".GDOC" ||
                            extension == ".HTML" || extension == ".LOG" || extension == ".Mobi" || extension == ".ODM" ||
                            extension == ".ODT" || extension == ".OTT" || extension == ".PDF" || extension == ".RTF" ||
                            extension == ".INFO" || extension == ".TXT" || extension == ".WPS" || extension == ".WPT" ||
                            extension == ".XHTML" || extension == ".XHT" || extension == ".XML" || extension == ".XPS")
                        {
                            ToolStripItem subItem = new ToolStripMenuItem();
                            subItem.Click += MenuClickedDocuments;
                            subItem.Text = Convert.ToString(fileDoc);
                            _documentsToolStripMenuItem.DropDownItems.Add(subItem);
                        }
                    }
                }
                else
                {
                    OSConsole("Scripts Directory Does not Exist", intVerboseErrorMode);
                }
            }
            catch (UnauthorizedAccessException uaEx)
            {
                OSConsole("Exeption Thrown: Enumerating Documents Directory -" + uaEx.Message, intVerboseErrorMode);
            }
            catch (PathTooLongException pathEx)
            {
                OSConsole("Exeption Thrown: Enumerating Documents Directory -" + pathEx.Message, intVerboseErrorMode);
            }
            catch
            {
                OSConsole("Exeption Thrown: Enumerating Documents Directory - Unknown", intVerboseErrorMode);
            }
        }

        public void CreateMenuItem(string strName)
        {
            var result = _ofdMenuItem.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Save Item

                var output = "|" + strName + "," + _ofdMenuItem.FileName;
                var currentSetting = Settings.Default.str_StoredApps;
                Settings.Default.str_StoredApps = currentSetting + output;
                Settings.Default.Save();

                //Create item in current instance
                ToolStripItem subItem = new ToolStripMenuItem();
                subItem.Click += MenuClicked;
                subItem.Text = strName;
                _qlToolStripMenuItem.DropDownItems.Add(subItem);

                //Add to List
                _lbCurrentPrograms.Items.Add(output);
            }
            else
            {
                MessageBox.Show("There was an error trying to add this file.");
            }
        }

        private void LoadMenuatStart()
        {
            var currentSetting = Settings.Default.str_StoredApps;
            var rawPairs = currentSetting.Split('|');
            foreach (var values in rawPairs)
            {
                //Add to Form
                var name = values.Split(',').First();
                ToolStripItem subItem = new ToolStripMenuItem();
                subItem.Click += MenuClicked;
                subItem.Text = name;
                _qlToolStripMenuItem.DropDownItems.Add(subItem);

                //Add to List
                _lbCurrentPrograms.Items.Add(values);
            }
        }

        private void LoadShopSettings()
        {
            _tbShopSetAddr1.Text = Settings.Default.str_Shop_Addr1;
            _tbShopSetAddr2.Text = Settings.Default.str_Shop_Addr2;
            _tbShopSetCity.Text = Settings.Default.str_Shop_City;
            _tbShopSetEmail.Text = Settings.Default.str_Shop_Email;
            _tbShopSetName.Text = Settings.Default.str_Shop_Name;
            _tbShopSetPhone.Text = Settings.Default.str_Shop_Phone;
            _tbShopSetState.Text = Settings.Default.str_Shop_State;
        }

        private void TronSave(string input)
        {
            if (input == "a")
            {
                Settings.Default.bool_tron_a = true;
            }
            if (input == "c")
            {
                Settings.Default.bool_tron_c = true;
            }
            if (input == "d")
            {
                Settings.Default.bool_tron_d = true;
            }
            if (input == "dev")
            {
                Settings.Default.bool_tron_dev = true;
            }
            if (input == "e")
            {
                Settings.Default.bool_tron_e = true;
            }
            if (input == "er")
            {
                Settings.Default.bool_tron_er = true;
            }
            if (input == "m")
            {
                Settings.Default.bool_tron_m = true;
            }
            if (input == "o")
            {
                Settings.Default.bool_tron_o = true;
            }
            if (input == "p")
            {
                Settings.Default.bool_tron_p = true;
            }
            if (input == "r")
            {
                Settings.Default.bool_tron_r = true;
            }
            if (input == "sa")
            {
                Settings.Default.bool_tron_sa = true;
            }
            if (input == "sb")
            {
                Settings.Default.bool_tron_sb = true;
            }
            if (input == "sd")
            {
                Settings.Default.bool_tron_sd = true;
            }
            if (input == "sdc")
            {
                Settings.Default.bool_tron_sdc = true;
            }
            if (input == "se")
            {
                Settings.Default.bool_tron_se = true;
            }
            if (input == "sfr")
            {
                Settings.Default.bool_tron_sfr = true;
            }
            if (input == "sk")
            {
                Settings.Default.bool_tron_sk = true;
            }
            if (input == "sm")
            {
                Settings.Default.bool_tron_sm = true;
            }
            if (input == "sp")
            {
                Settings.Default.bool_tron_sp = true;
            }
            if (input == "spr")
            {
                Settings.Default.bool_tron_spr = true;
            }
            if (input == "srr")
            {
                Settings.Default.bool_tron_srr = true;
            }
            if (input == "ss")
            {
                Settings.Default.bool_tron_ss = true;
            }
            if (input == "str")
            {
                Settings.Default.bool_tron_str = true;
            }
            if (input == "sw")
            {
                Settings.Default.bool_tron_sw = true;
            }
            if (input == "v")
            {
                Settings.Default.bool_tron_v = true;
            }
            if (input == "x")
            {
                Settings.Default.bool_tron_x = true;
            }
            Settings.Default.Save();
        }

        private void TronDel(string input)
        {
            if (input == "a")
            {
                Settings.Default.bool_tron_a = false;
            }
            if (input == "c")
            {
                Settings.Default.bool_tron_c = false;
            }
            if (input == "d")
            {
                Settings.Default.bool_tron_d = false;
            }
            if (input == "dev")
            {
                Settings.Default.bool_tron_dev = false;
            }
            if (input == "e")
            {
                Settings.Default.bool_tron_e = false;
            }
            if (input == "er")
            {
                Settings.Default.bool_tron_er = false;
            }
            if (input == "m")
            {
                Settings.Default.bool_tron_m = false;
            }
            if (input == "o")
            {
                Settings.Default.bool_tron_o = false;
            }
            if (input == "p")
            {
                Settings.Default.bool_tron_p = false;
            }
            if (input == "r")
            {
                Settings.Default.bool_tron_r = false;
            }
            if (input == "sa")
            {
                Settings.Default.bool_tron_sa = false;
            }
            if (input == "sb")
            {
                Settings.Default.bool_tron_sb = false;
            }
            if (input == "sd")
            {
                Settings.Default.bool_tron_sd = false;
            }
            if (input == "sdc")
            {
                Settings.Default.bool_tron_sdc = false;
            }
            if (input == "se")
            {
                Settings.Default.bool_tron_se = false;
            }
            if (input == "sfr")
            {
                Settings.Default.bool_tron_sfr = false;
            }
            if (input == "sk")
            {
                Settings.Default.bool_tron_sk = false;
            }
            if (input == "sm")
            {
                Settings.Default.bool_tron_sm = false;
            }
            if (input == "sp")
            {
                Settings.Default.bool_tron_sp = false;
            }
            if (input == "spr")
            {
                Settings.Default.bool_tron_spr = false;
            }
            if (input == "srr")
            {
                Settings.Default.bool_tron_srr = false;
            }
            if (input == "ss")
            {
                Settings.Default.bool_tron_ss = false;
            }
            if (input == "str")
            {
                Settings.Default.bool_tron_str = false;
            }
            if (input == "sw")
            {
                Settings.Default.bool_tron_sw = false;
            }
            if (input == "v")
            {
                Settings.Default.bool_tron_v = false;
            }
            if (input == "x")
            {
                Settings.Default.bool_tron_x = false;
            }
            Settings.Default.Save();
        }

        #endregion

        private void _btnClear_Click(object sender, EventArgs e)
        {
            //Clear all flags
        }

        private void oneStopToolGetFileInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OS_FileInfo OS_FileInfo = new OS_FileInfo();
            OS_FileInfo.Show();
        }

        private void _forceShutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd","prompt","shutdown /f /s /p");
        }


        private void _forceRestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "shutdown /f /r /p");
        }

        private void forceLogoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "shutdown /f /l");
        }

        private void _enableF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {default} bootmenupolicy legacy");
        }

        private void _disableF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {default} bootmenupolicy standard");
        }

        private void _setSafemodeSwitchOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {current} safeboot");
        }

        private void _setSafemodeSwitchOnNetworkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {default} safeboot network");
        }

        private void _setSafemodeSwitchOnMinimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {default} safeboot minimal");
        }

        private void _setSafemodeSwitchOnAltShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {default} safebootalternateshell yes");
        }

        private void _setSafemodeSwtichOffNormalBootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /deletevalue {default} safeboot");
            OSLaunch("cmd", "prompt", "bcdedit /deletevalue {default} safebootalternateshell");
        }

        private void _enumerateCurrentModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /enum");
        }

        private void _hibernateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "shutdown /h");

        }

        private void _hybridShutdownFastStartUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "shutdown /hybrid /s");
        }

        private void _shutdownWithOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "shutdown /r /o");
        }

        private void _ipconfigalltoolstripmenuitem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "ipconfig /all");
        }

        private void _rOneStopItToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.reddit.com/r/OneStopIT","web");
            
        }

        private void _rTronScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.reddit.com/r/TronScript", "web");
        }

        private void _ninitecomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.ninite.com/", "web");
        }

        private void _bleepingComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://bleepingcomputer.com", "web");
        }

        private void _geGeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.gegeek.com/", "web");
        }

        private void _dSlReportscomSpeedTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.dslreports.com/speedtest", "web");
        }

        private void _speedtestnetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.speedtest.net", "web");
        }

        private void _browserscopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.browserscope.org/", "web");
        }

        private void _qualysBrowsercheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://browsercheck.qualys.com/?scan_type=js", "web");
        }

        private void _firefoxOfficialPluginTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://www.mozilla.org/en-US/plugincheck/", "web");
        }

        private void _silverlightbubblemarkcomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://bubblemark.com/wpfe.htm", "web");
        }

        private void _flashbubblemarkcomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://bubblemark.com/flex.htm", "web");
        }

        private void _javajavatesterorgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://javatester.org/version.html", "web");
        }

        private void _shockwaveadobecomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://www.adobe.com/shockwave/welcome/", "web");
        }

        private void _sSLssllabscomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://www.ssllabs.com/ssltest/viewMyClient.html", "web");
        }

        private void _shieldsUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://www.grc.com/x/ne.dll?bh0bkyd2", "web");
        }

        private void _eSetMasterListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://support.eset.com/kb146/", "web");
        }

        private void _avastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.avast.com/uninstall-utility", "web");
        }

        private void _aVgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.avg.com/us-en/utilities", "web");
        }

        private void _aviraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.avira.com/en/support-for-free-knowledgebase-detail/kbid/88", "web");
        }

        private void _comodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://support.comodo.com/index.php?_m=knowledgebase&_a=viewarticle&kbarticleid=298", "web");
        }

        private void _fSecureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("ftp://ftp.f-secure.com/support/tools/uitool/UninstallationTool.zip", "web");
        }

        private void _kasperskyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://support.kaspersky.com/common/service.aspx?el=1464", "web");
        }

        private void _mcAffeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://download.mcafee.com/products/licensed/cust_support_patches/MCPR.exe", "web");
        }

        private void _nOd32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://support.eset.com/kb2788/", "web");
        }

        private void _nortonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("ftp://ftp.symantec.com/public/english_us_canada/removal_tools/Norton_Removal_Tool.exe", "web");
        }

        private void _nortonSecurityScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("ftp://ftp.symantec.com/public/english_us_canada/removal_tools/NSSRT.exe", "web");
        }

        private void _pandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.pandasecurity.com/resources/sop/UNINSTALLER_08.exe", "web");
        }

        private void _sophosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.sophos.com/support/knowledgebase/article/11019.html", "web");
        }

        private void _windowsSecurityEssentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://support.microsoft.com/kb/2435760", "web");
        }

        private void _prepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_0_prep","tron_folder");
        }

        private void _tempcleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_1_tempclean", "tron_folder");
        }

        private void _dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_2_de-bloat", "tron_folder");
        }

        private void _disinfectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_3_disinfect", "tron_folder");
        }

        private void _repairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_4_repair", "tron_folder");
        }

        private void _patchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_5_patch", "tron_folder");
        }

        private void _optimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_6_optimize", "tron_folder");
        }

        private void _wrapUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_7_wrap-up", "tron_folder");
        }

        private void _manualToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_8_manual_tools", "tron_folder");
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveLoggingStatus_Click(object sender, EventArgs e)
        {
            


            Settings.Default.boolCMDConsole = cbCMDConsole.Checked;
            
            Settings.Default.boolCMDLog = cbCMDLog.Checked;

            Settings.Default.boolGPLNoticeConsole = cbGPLConsole.Checked;

            Settings.Default.boolGPLNoticeLog = cbGPLNoticeLog.Checked;

            Settings.Default.boolProgramOpenedConsole = cbOpenedConsole.Checked;

            Settings.Default.boolProgramOpenedLog = cbOpenedLog.Checked;

            Settings.Default.boolRegistryConsole = cbRegistryConsole.Checked;

            Settings.Default.boolRegistryLog = cbRegistryLog.Checked;

            Settings.Default.boolStartupConsole = cbOSStartConsole.Checked;

            Settings.Default.boolSysInfoConsole = cbSysinfoConsole.Checked;

            Settings.Default.boolStartupLog = cbOSStartLog.Checked;

            Settings.Default.boolSysInfoLog = cbSysInfoLog.Checked;

            Settings.Default.boolVerboseErrorConsole = cbVerboseErrorConsole.Checked;

            Settings.Default.boolVerboseErrorLog = cbVerboseErrorLog.Checked;

            Settings.Default.boolWebsiteConsole = cbWebsitesConsole.Checked;

            Settings.Default.boolWebsiteLog = cbWebsitesLog.Checked;

            string errortext = null;
            try
            {
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                OSConsole("Exception: " + ex, intVerboseErrorMode);
                errortext = Convert.ToString(ex);
            }

            if (String.IsNullOrEmpty(errortext))
            {
                MessageBox.Show("Settings were successfully saved", "Settings Saved");
            }

        }
        
    }
}