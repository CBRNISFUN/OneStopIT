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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using Microsoft.Win32;
using OneStop.Properties;

namespace OneStop
{
    public class OsMain : Form
    {
        #region Declarations
        public bool BoolAdminStatus;
        public bool BoolLocalDir;
        public bool BoolPrevDir;
        public bool BoolRootDir;
        public bool BoolSearchedDir;
        private Button btnSaveLoggingStatus;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private CheckBox cbCMDConsole;
        private CheckBox cbCMDLog;
        private CheckBox cbGPLConsole;
        private CheckBox cbGPLNoticeLog;
        private CheckBox cbOpenedConsole;
        private CheckBox cbOpenedLog;
        private CheckBox cbOSStartConsole;
        private CheckBox cbOSStartLog;
        private CheckBox cbRegistryConsole;
        private CheckBox cbRegistryLog;
        private CheckBox cbSysinfoConsole;
        private CheckBox cbSysInfoLog;
        private CheckBox cbVerboseErrorConsole;
        private CheckBox cbVerboseErrorLog;
        private CheckBox cbWebsitesConsole;
        private CheckBox cbWebsitesLog;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private Button clearSslBTN;
        private Button clearStaticBTN;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ToolStripMenuItem connectivityToDefaultGatewayToolStripMenuItem;
        private Button dnsFlushBTN;
        private FlowLayoutPanel flowLayoutPanel3;
        //private ToolStripMenuItem forceLogoffToolStripMenuItem;
        private GroupBox groupBox1;
        private GroupBox groupBox10;
        private GroupBox groupBox11;
        private GroupBox groupBox12;
        private GroupBox groupBox13;
        private GroupBox groupBox14;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private GroupBox groupBox8;
        private GroupBox groupBox9;

        public string GString = "GodMode.{ED7BA470-8E54-465E-825C-99712043E01C}";
        private TextBox hostNameTextB;
        public int intCMDCommandMode = 3;
        public int intGPLMode = 3;
        public int intProgramOpendMode = 3;
        public int intRegistyMode = 3;
        public int intStartupMode = 3;
        public int intSysinfoMode = 3;
        public int intVerboseErrorMode = 3;
        public int intWebsiteMode = 3;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label22;
        private Label label23;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ToolStripMenuItem launchPortableBrowsersetInConfigToolStripMenuItem;
        private ToolStripLabel lblBootStatus;
        private ToolStripLabel lblTronStatus;
        private LinkLabel linkLabel2;
        private GroupBox mailGroupBox;
        private TextBox netBox;
        private ComboBox netCombo;
        private ToolStripMenuItem oneStopInternalToolStripMenuItem;
        private ToolStripMenuItem oneStopToolGetFileInfoToolStripMenuItem;
        private PictureBox pictureBox1;
        private TextBox pubIPTextB;
        private Button releaseRenewBTN;
        private Button setGoogleDnsBTN;


        public string StrTronPath = "";
        public string StrTronStatus = "";
        private TabControl tabControl1;
        public TextBox tbConsole;
        private ToolStripMenuItem testBrowserToolStripMenuItem;
        private TextBox textBox1;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private ToolStripSeparator toolStripSeparator1;
        private TabPage tpIntegration;
        private TabPage tpLogging;
        private TabPage tpNetwork;
        private TabPage tpServers;
        private TabPage tpSystemReport;
        private ToolStripMenuItem forceLogoffToolStripMenuItem;
        private ToolStripMenuItem oneStopToolInternalBrowserToolStripMenuItem;
        private Label label21;
        private CheckedListBox checkedListBox2;
        private Label label20;
        private CheckedListBox checkedListBox1;
        private Button winsockRepBTN;
#endregion


        private void OS_Main_Load(object sender, EventArgs e)
        {
            #region Startup

            StartProgressMarquee();


            InitLoggingSettings();
            BoolLocalDir = false;
            BoolRootDir = false;
            BoolPrevDir = false;
            BoolSearchedDir = false;

            OSConsole("OS_HR", intStartupMode);
            OSConsole("Begin  ONESTOP STARTUP", intStartupMode);
            OSConsole("OS_HR", intStartupMode);
            OSConsole("OS_BR", intStartupMode);
            OSConsole("OS_GPL", intStartupMode);

            OSConsole("Onestop begain initial startup at: " + DateTime.Now, intStartupMode);


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
                    OSConsole(
                        "ONE STOP IS NOT RUNNING AS ADMINISTRATOR - SOME FUNCTIONALITY, INCLUDING TRON CANNOT RUN",
                        intStartupMode);
                }
            }
            catch (Exception exception)
            {
                OSConsole("Exeption while checking administrator status" + exception, intVerboseErrorMode);
            }


            //Set all labels with current info
            lblAdminStatus.Text = StrTronStatus + strAdminStatus;
            lblInfoFreeC.Text = OsSystem.GetCDriveSpace();
            lblInfoOs.Text = OsSystem.GetOsFriendlyName() + OsSystem.GetArch();
            lblInfoRam.Text = OsSystem.GetInstalledMemory();
            lblInfoComputerName.Text = OsSystem.GetMachineName();
            lblInfoExternalIp.Text = "";
            lnkInfoInternalIp.Text = "";
            lnkInfoGateway.Text = "";
            lnkInfoPrimDns.Text = "";
            lblInfoAdapterDesc.Text = "";
            OSConsole("Getting Current Stystem Status", intSysinfoMode);
            OSConsole("C Drive Space: " + OsSystem.GetCDriveSpace(), intSysinfoMode);
            OSConsole("OS Friendly Name / Arch: " + OsSystem.GetOsFriendlyName() + OsSystem.GetArch(), intSysinfoMode);
            OSConsole("Installed Memory: " + OsSystem.GetInstalledMemory(), intSysinfoMode);
            OSConsole("Machine Name: " + OsSystem.GetMachineName(), intSysinfoMode);
            OSConsole("OS_HR", 0);

            //Network Adapters
            OSConsole("Getting Network Adapters", intSysinfoMode);
            var adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var adapter in adapters)
            {
                ddlInfoNetworkAdapters.Items.Add(adapter.Name);
                OSConsole("Adapter Found" + adapter.Name + " - " + adapter.Description, intSysinfoMode);
            }

            //Load Quick Launch Menu

            OSConsole("Loading Quick Launch Menu Settings", intStartupMode);
            LoadMenuatStart();

            var strCurrentDirectory = Directory.GetCurrentDirectory();
            var strScriptsDirectory = strCurrentDirectory + "\\Scripts";
            var strDocsDirectory = strCurrentDirectory + "\\Documents";

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

            OSConsole("Onestop completed initial startup at: " + DateTime.Now, intStartupMode);

            #endregion

            //Load status with current results
            UpdateStatus();

            StopProgressMarquee();
        }

        private void StopProgressMarquee()
        {
            pbCurrentProgress.Style = ProgressBarStyle.Marquee;
            pbCurrentProgress.MarqueeAnimationSpeed = 0;
            pbCurrentProgress.Value = 0;
        }

        private void StartProgressMarquee()
        {
            pbCurrentProgress.Style = ProgressBarStyle.Marquee;
            pbCurrentProgress.MarqueeAnimationSpeed = 30;
        }

        private void avastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.avast.com/uninstall-utility", "web");
        }

        private void aVgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.avg.com/us-en/utilities", "web");
        }

        private void aviraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.avira.com/en/support-for-free-knowledgebase-detail/kbid/88", "web");
        }

        private void bleepingComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://bleepingcomputer.com", "web");
        }

        private void browserscopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.browserscope.org/", "web");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear all flags
        }

        private void comodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://support.comodo.com/index.php?_m=knowledgebase&_a=viewarticle&kbarticleid=298", "web");
        }

        private void disableF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {default} bootmenupolicy standard");
        }

        private void disinfectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_3_disinfect", "tron_folder");
        }

        private void dSlReportscomSpeedTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.dslreports.com/speedtest", "web");
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_2_de-bloat", "tron_folder");
        }

        private void enableF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {default} bootmenupolicy legacy");
        }

        private void enumerateCurrentModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /enum");
        }

        private void eSetMasterListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://support.eset.com/kb146/", "web");
        }

        private void firefoxOfficialPluginTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://www.mozilla.org/en-US/plugincheck/", "web");
        }

        private void flashbubblemarkcomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://bubblemark.com/flex.htm", "web");
        }


        private void forceRestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "shutdown /f /r /p");
        }

        private void forceShutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "shutdown /f /s /p");
        }

        private void fSecureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("ftp://ftp.f-secure.com/support/tools/uitool/UninstallationTool.zip", "web");
        }

        private void geGeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.gegeek.com/", "web");
        }

        private void hibernateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "shutdown /h");
        }

        private void hybridShutdownFastStartUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "shutdown /hybrid /s");
        }

        private void ipconfigalltoolstripmenuitem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "ipconfig /all");
        }

        private void javajavatesterorgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://javatester.org/version.html", "web");
        }

        private void kasperskyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://support.kaspersky.com/common/service.aspx?el=1464", "web");
        }

        private void manualToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_8_manual_tools", "tron_folder");
        }

        private void mcAffeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://download.mcafee.com/products/licensed/cust_support_patches/MCPR.exe", "web");
        }

        private void ninitecomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.ninite.com/", "web");
        }

        private void nOd32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://support.eset.com/kb2788/", "web");
        }

        private void nortonSecurityScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("ftp://ftp.symantec.com/public/english_us_canada/removal_tools/NSSRT.exe", "web");
        }

        private void nortonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("ftp://ftp.symantec.com/public/english_us_canada/removal_tools/Norton_Removal_Tool.exe", "web");
        }

        private void optimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_6_optimize", "tron_folder");
        }

        private void pandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.pandasecurity.com/resources/sop/UNINSTALLER_08.exe", "web");
        }

        private void patchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_5_patch", "tron_folder");
        }

        private void prepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_0_prep", "tron_folder");
        }

        private void qualysBrowsercheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://browsercheck.qualys.com/?scan_type=js", "web");
        }

        private void repairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_4_repair", "tron_folder");
        }

        private void rOneStopItToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.reddit.com/r/OneStopIT", "web");
        }

        private void rTronScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.reddit.com/r/TronScript", "web");
        }

        private void setSafemodeSwitchOnAltShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {default} safebootalternateshell yes");
        }

        private void setSafemodeSwitchOnMinimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {default} safeboot minimal");
        }

        private void setSafemodeSwitchOnNetworkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {default} safeboot network");
        }

        private void setSafemodeSwitchOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /set {current} safeboot");
        }

        private void setSafemodeSwtichOffNormalBootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "bcdedit /deletevalue {default} safeboot");
            OSLaunch("cmd", "prompt", "bcdedit /deletevalue {default} safebootalternateshell");
        }

        private void shieldsUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://www.grc.com/x/ne.dll?bh0bkyd2", "web");
        }

        private void shockwaveadobecomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://www.adobe.com/shockwave/welcome/", "web");
        }

        private void shutdownWithOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "shutdown /r /o");
        }

        private void silverlightbubblemarkcomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://bubblemark.com/wpfe.htm", "web");
        }

        private void sophosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.sophos.com/support/knowledgebase/article/11019.html", "web");
        }

        private void speedtestnetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://www.speedtest.net", "web");
        }

        private void sSLssllabscomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("https://www.ssllabs.com/ssltest/viewMyClient.html", "web");
        }

        private void tempcleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_1_tempclean", "tron_folder");
        }

        private void windowsSecurityEssentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("http://support.microsoft.com/kb/2435760", "web");
        }

        private void wrapUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("stage_7_wrap-up", "tron_folder");
        }

        private void btnConfigDump_Click(object sender, EventArgs e)
        {
            SaveCurrentCBs();
            var strArguments = GetTronArgs();
            LaunchTron(" -c -e");
        }

        private void btnDryRun_Click(object sender, EventArgs e)
        {
            SaveCurrentCBs();
            LaunchTron(" -d -e");
        }

        private void btnLocateTron_Click(object sender, EventArgs e)
        {
            var result = ofdTron.ShowDialog();
            if (result == DialogResult.OK)
            {
                var strFileName = ofdTron.FileName;


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


        private void btnQLCreateNew_Click(object sender, EventArgs e)
        {
            var strObjectName = txtQlAppName.Text;
            var strCleaned = strObjectName.Trim(',', '|');
            CreateMenuItem(strCleaned);
            txtQlAppName.Text = "";
        }

        private void btnQLDeleteSelected_Click(object sender, EventArgs e)
        {
            var strCurrent = Settings.Default.str_StoredApps;
            var strOutput = "";

            foreach (var selecteditem in lbCurrentPrograms.SelectedItems)
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
                        qlToolStripMenuItem.DropDownItems.Remove(qlToolStripMenuItem.DropDownItems[name]);
                    }
                }
            }
            Settings.Default.str_StoredApps = strOutput;
            Settings.Default.Save();

            lbCurrentPrograms.Items.Clear();
            //LoadMenuatStart();
        }

        private void btnRunTronClick(object sender, EventArgs e)
        {
            SaveCurrentCBs();
            LaunchTron("-e");
        }

        private void btnShopSetSave_Click(object sender, EventArgs e)
        {
            Settings.Default.str_Shop_Addr1 = tbShopSetAddr1.Text;
            Settings.Default.str_Shop_Addr2 = tbShopSetAddr2.Text;
            Settings.Default.str_Shop_City = tbShopSetCity.Text;
            Settings.Default.str_Shop_Email = tbShopSetEmail.Text;
            Settings.Default.str_Shop_Name = tbShopSetName.Text;
            Settings.Default.str_Shop_Phone = tbShopSetPhone.Text;
            Settings.Default.str_Shop_State = tbShopSetState.Text;
            Settings.Default.Save();
            LoadTitleBar();
        }

        private void btnTronSaveFlags_Click(object sender, EventArgs e)
        {
            SaveCurrentCBs();
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

            if (string.IsNullOrEmpty(errortext))
            {
                MessageBox.Show("Settings were successfully saved", "Settings Saved");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        public void cbtrondev_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronDev.Checked)
            {
                TronSave("dev");
            }
            else
            {
                TronDel("dev");
            }
        }

        public void cbtronE_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronE.Checked)
            {
                TronSave("e");
            }
            else
            {
                TronDel("e");
            }
        }

        public void cbtronER_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronEr.Checked)
            {
                TronSave("er");
            }
            else
            {
                TronDel("er");
            }
        }

        public void cbtronM_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronM.Checked)
            {
                TronSave("m");
            }
            else
            {
                TronDel("m");
            }
        }

        public void cbtronO_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronO.Checked)
            {
                TronSave("o");
            }
            else
            {
                TronDel("o");
            }
        }

        public void cbtronP_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronP.Checked)
            {
                TronSave("p");
            }
            else
            {
                TronDel("p");
            }
        }

        public void cbtronR_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronR.Checked)
            {
                TronSave("r");
            }
            else
            {
                TronDel("r");
            }
        }

        public void cbtronSA_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSa.Checked)
            {
                TronSave("sa");
            }
            else
            {
                TronDel("sa");
            }
        }

        public void cbtronSB_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSb.Checked)
            {
                TronSave("sb");
            }
            else
            {
                TronDel("sb");
            }
        }

        public void cbtronSD_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSd.Checked)
            {
                TronSave("sd");
            }
            else
            {
                TronDel("sd");
            }
        }

        public void cbtronSDC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSdc.Checked)
            {
                TronSave("sdc");
            }
            else
            {
                TronDel("sdc");
            }
        }

        public void cbtronSE_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSe.Checked)
            {
                TronSave("se");
            }
            else
            {
                TronDel("se");
            }
        }

        public void cbtronSFR_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSfr.Checked)
            {
                TronSave("sfr");
            }
            else
            {
                TronDel("sfr");
            }
        }

        public void cbtronSK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSk.Checked)
            {
                TronSave("sk");
            }
            else
            {
                TronDel("sk");
            }
        }

        public void cbtronSM_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSm.Checked)
            {
                TronSave("sm");
            }
            else
            {
                TronDel("sm");
            }
        }

        public void cbtronSP_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSp.Checked)
            {
                TronSave("sp");
            }
            else
            {
                TronDel("sp");
            }
        }

        public void cbtronSPR_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSpr.Checked)
            {
                TronSave("spr");
            }
            else
            {
                TronDel("spr");
            }
        }

        public void cbtronSRR_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSrr.Checked)
            {
                TronSave("srr");
            }
            else
            {
                TronDel("srr");
            }
        }

        public void cbtronSS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronSs.Checked)
            {
                TronSave("ss");
            }
            else
            {
                TronDel("ss");
            }
        }

        public void cbtronSTR_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronStr.Checked)
            {
                TronSave("str");
            }
            else
            {
                TronDel("str");
            }
        }

        public void cbtronSW_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void cbtronV_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronV.Checked)
            {
                TronSave("v");
            }
            else
            {
                TronDel("v");
            }
        }

        public void cbtronX_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTronX.Checked)
            {
                TronSave("x");
            }
            else
            {
                TronDel("x");
            }
        }


        private void ddlinfoNetworkAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedAdapter = ddlInfoNetworkAdapters.SelectedText;

                var adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (var adapter in adapters)
                {
                    if (adapter.Name == ddlInfoNetworkAdapters.Text)
                    {
                        lblInfoAdapterDesc.Text = adapter.Description;

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
                            lnkInfoPrimDns.Text = strDnsOut;
                        }


                        //Gateway
                        if (adapter.OperationalStatus == OperationalStatus.Up)
                        {
                            var strOutput = "";
                            foreach (var g in adapter.GetIPProperties().GatewayAddresses)
                            {
                                strOutput = strOutput + g.Address + " ";
                                lnkInfoGateway.Text = strOutput;
                            }
                        }
                        else
                        {
                            lnkInfoGateway.Text = "Status is Down";
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
                OSConsole("Exeption Thrown - Network Adapter Selection: " + ex, intVerboseErrorMode);
                throw;
            }
        }

        private void EnableLocalTron()
        {
            var tronFile = ofdTron.FileName;
            var strTronPath = Path.GetDirectoryName(tronFile);
            TronEnable("Tron Located", strTronPath + "\\" + tronFile);
            Settings.Default.str_LastTronDirectory = strTronPath + "\\";
            Settings.Default.Save();
            BoolLocalDir = false;
            BoolPrevDir = false;
        }

        private void forceLogoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSLaunch("cmd", "prompt", "shutdown /f /l");
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
                var tronFile = ofdTron.FileName;
                var tronLaunchString = " /C \"" + tronFile + "\"" + strExtraArg + GetTronArgs();

                Process.Start("cmd.exe", tronLaunchString);
            }
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

        private void oneStopToolGetFileInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OS_FileInfo = new OS_FileInfo();
            OS_FileInfo.Show();
        }

        

        public void OSConsole(string input, int mode)
        {
            //mode = 0 or null -> OSConsole, 1 -> OSConsole plus log, 2-> Log Only, 3->Go nowhere
            var logfile = Directory.GetCurrentDirectory() + "\\Logs\\onestoplog.txt";
            var logfiledir = Directory.GetCurrentDirectory() + "\\Logs\\";

            var directoryInfo = new FileInfo(logfiledir).Directory;
            if (directoryInfo != null) directoryInfo.Create();

            if (input == "OS_GPL")
            {
                if (mode == 1 || mode == 0)
                {
                    tbConsole.AppendText(@"OneStopIT - The Open Source All-In-One tool for technicians." +
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
                tbConsole.AppendText(Environment.NewLine + @"===========================================");
            }
            if (input == "OS_BR" && (mode == 0 || mode == 1))
            {
                tbConsole.AppendText(Environment.NewLine + Environment.NewLine);
            }
            if ((mode == 0 || mode == 1) &&
                (input.Contains("OS_BR") || input.Contains("OS_GPL") || input.Contains("OS_HR")))
            {
            }
            else
            {
                if (mode == 0 || mode == 1)
                {
                    tbConsole.AppendText(Environment.NewLine + input);
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

            if (cbTronDev.Checked)
            {
                Settings.Default.bool_tron_dev = true;
                Settings.Default.Save();
            }
            if (cbTronE.Checked)
            {
                Settings.Default.bool_tron_e = true;
                Settings.Default.Save();
            }
            if (cbTronEr.Checked)
            {
                Settings.Default.bool_tron_er = true;
                Settings.Default.Save();
            }
            if (cbTronM.Checked)
            {
                Settings.Default.bool_tron_m = true;
                Settings.Default.Save();
            }
            if (cbTronO.Checked)
            {
                Settings.Default.bool_tron_o = true;
                Settings.Default.Save();
            }
            if (cbTronP.Checked)
            {
                Settings.Default.bool_tron_p = true;
                Settings.Default.Save();
            }
            if (cbTronR.Checked)
            {
                Settings.Default.bool_tron_r = true;
                Settings.Default.Save();
            }
            if (cbTronSa.Checked)
            {
                Settings.Default.bool_tron_sa = true;
                Settings.Default.Save();
            }
            if (cbTronSb.Checked)
            {
                Settings.Default.bool_tron_sb = true;
                Settings.Default.Save();
            }
            if (cbTronSd.Checked)
            {
                Settings.Default.bool_tron_sd = true;
                Settings.Default.Save();
            }
            if (cbTronSdc.Checked)
            {
                Settings.Default.bool_tron_sdc = true;
                Settings.Default.Save();
            }
            if (cbTronSe.Checked)
            {
                Settings.Default.bool_tron_se = true;
                Settings.Default.Save();
            }
            if (cbTronSfr.Checked)
            {
                Settings.Default.bool_tron_sfr = true;
                Settings.Default.Save();
            }
            if (cbTronSk.Checked)
            {
                Settings.Default.bool_tron_sk = true;
                Settings.Default.Save();
            }
            if (cbTronSm.Checked)
            {
                Settings.Default.bool_tron_sm = true;
                Settings.Default.Save();
            }
            if (cbTronSp.Checked)
            {
                Settings.Default.bool_tron_sp = true;
                Settings.Default.Save();
            }
            if (cbTronSpr.Checked)
            {
                Settings.Default.bool_tron_spr = true;
                Settings.Default.Save();
            }
            if (cbTronSrr.Checked)
            {
                Settings.Default.bool_tron_srr = true;
                Settings.Default.Save();
            }
            if (cbTronSs.Checked)
            {
                Settings.Default.bool_tron_ss = true;
                Settings.Default.Save();
            }
            if (cbTronStr.Checked)
            {
                Settings.Default.bool_tron_str = true;
                Settings.Default.Save();
            }
            if (cbTronSw.Checked)
            {
                Settings.Default.bool_tron_sw = true;
                Settings.Default.Save();
            }
            if (cbTronV.Checked)
            {
                Settings.Default.bool_tron_v = true;
                Settings.Default.Save();
            }
            if (cbTronX.Checked)
            {
                Settings.Default.bool_tron_x = true;
                Settings.Default.Save();
            }
        }

        private void UpdateStatus()
        {
            var bootstatusout = "";
            var tronstatusout = "";
            var adminerrorstatusout = "";

            lblAdminStatus.ForeColor = Color.Green;
            lblBootStatus.ForeColor = Color.Green;
            lblTronStatus.ForeColor = Color.Green;

            var boolBootErrorStatus = false;
            var boolTronErrorStatus = false;
            var boolAdminErrorStatus = false;


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
                tronstatusout = "[Tron: Previous] ";
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


            if (SystemInformation.BootMode == BootMode.FailSafe)
            {
                bootstatusout = "[Boot: Safe]";
            }
            else if (SystemInformation.BootMode == BootMode.FailSafeWithNetwork)
            {
                bootstatusout = "[Boot: Safe+Net]";
            }
            else if (SystemInformation.BootMode == BootMode.Normal)
            {
                bootstatusout = "[Boot: Normal]";
                boolBootErrorStatus = true;
            }

            if (boolAdminErrorStatus)
            {
                lblAdminStatus.ForeColor = Color.Red;
            }
            if (boolBootErrorStatus)
            {
                lblBootStatus.ForeColor = Color.Red;
            }
            if (boolTronErrorStatus)
            {
                lblTronStatus.ForeColor = Color.Red;
            }
            lblAdminStatus.Text = adminerrorstatusout;
            lblBootStatus.Text = bootstatusout;
            lblTronStatus.Text = tronstatusout;
        }

        #region Components

        private ToolStrip tsBottomToolbar;
        private ToolStripProgressBar pbCurrentProgress;
        private ToolStripSeparator toolStripSeparator01;
        private ToolStripLabel lblCurrentActionStatus;
        private ToolStripLabel lblAdminStatus;
        private MenuStrip menuPrimary;
        private ToolStripMenuItem oneStopToolStripMenuItem;
        private ToolStripMenuItem runPromptToolStripMenuItem;
        private ToolStripMenuItem networkToolStripMenuItem;
        private ToolStripMenuItem systemToolStripMenuItem;
        private ToolStripMenuItem techResourcesToolStripMenuItem;
        private ToolStripMenuItem powerToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private TabControl tcPrimaryTabs;
        private TabPage tpTronCli;
        private ToolStripMenuItem startAtRunToolStripMenuItem;
        private ToolStripMenuItem restartAsAdminToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem oneStopSettingsToolStripMenuItem;
        private ToolStripMenuItem tRonToolStripMenuItem;
        private ToolStripMenuItem foldersToolStripMenuItem;
        private ToolStripMenuItem prepToolStripMenuItem;
        private ToolStripMenuItem tempcleanToolStripMenuItem;
        private ToolStripMenuItem dToolStripMenuItem;
        private ToolStripMenuItem disinfectToolStripMenuItem;
        private ToolStripMenuItem repairToolStripMenuItem;
        private ToolStripMenuItem patchToolStripMenuItem;
        private ToolStripMenuItem optimizeToolStripMenuItem;
        private ToolStripMenuItem wrapUpToolStripMenuItem;
        private ToolStripMenuItem manualToolsToolStripMenuItem;
        private ToolStripMenuItem setConfigurationOptionsToolStripMenuItem;
        private ToolStripMenuItem deployTronToNewLocationToolStripMenuItem;
        private ToolStripMenuItem windowsRunCommandToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem openPowershellToolStripMenuItem;
        private ToolStripMenuItem openElevatedCommandPromptToolStripMenuItem;
        private ToolStripMenuItem openElevatedCommandPromptToPathToolStripMenuItem;
        private ToolStripMenuItem openRouterInterfaceToolStripMenuItem;
        private ToolStripMenuItem openAtDefaultGatewayToolStripMenuItem;
        private ToolStripMenuItem openHttprouterpasswordscomToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem openSavedInterface1XxxxxxxxxxxxToolStripMenuItem;
        private ToolStripMenuItem openSavedInterface2XxxxxxxxxxxxToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem dNsSettingsToolStripMenuItem;
        private ToolStripMenuItem resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem firewallToolStripMenuItem;
        private ToolStripMenuItem windowsFirewallAndAdvancedSecurityToolStripMenuItem;
        private ToolStripMenuItem resetFirewallToDefaultnetshFirewallResetToolStripMenuItem;
        private ToolStripMenuItem enableFirewallToolStripMenuItem;
        private ToolStripMenuItem disableFirewallToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem importFirewallSettingsToolStripMenuItem;
        private ToolStripMenuItem exportFirewallSettingsToolStripMenuItem;
        private ToolStripMenuItem enableRemoteManagementToolStripMenuItem;
        private ToolStripMenuItem enableRemoteDesktopToolStripMenuItem;
        private ToolStripMenuItem enableProgramInFirewallToolStripMenuItem;
        private ToolStripMenuItem enablePortToolStripMenuItem;
        private ToolStripMenuItem groupPolicyToolStripMenuItem;
        private ToolStripMenuItem getGroupPolicyReportToolStripMenuItem;
        private ToolStripMenuItem forceRefreshToolStripMenuItem;
        private ToolStripMenuItem openGroupPolicyEditorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem connectivityToHttpwwwgooglecomToolStripMenuItem;
        private ToolStripMenuItem pingIp4ToolStripMenuItem;
        private ToolStripMenuItem pringIp6ToolStripMenuItem;
        private ToolStripMenuItem traceRouteToolStripMenuItem;
        private ToolStripMenuItem pingPathIp4ToolStripMenuItem;
        private ToolStripMenuItem pingPathIp6ToolStripMenuItem;
        private ToolStripMenuItem ipconfigalltoolstripmenuitem;
        private ToolStripMenuItem releaseDhcpToolStripMenuItem;
        private ToolStripMenuItem renewDhcpToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem resetTcpipToolStripMenuItem;
        private ToolStripMenuItem flushDnsCacheToolStripMenuItem;
        private ToolStripMenuItem flushArpCacheToolStripMenuItem;
        private ToolStripMenuItem flushNetbiosCacheToolStripMenuItem;
        private ToolStripMenuItem restIpv4ToolStripMenuItem;
        private ToolStripMenuItem resteIpv6ToolStripMenuItem;
        private ToolStripMenuItem resetWinsockToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem netstatToolStripMenuItem;
        private ToolStripMenuItem pingToolStripMenuItem;
        private ToolStripMenuItem ownIpip4ToolStripMenuItem;
        private ToolStripMenuItem loopbackIp4ToolStripMenuItem;
        private ToolStripMenuItem gatewayIp4ToolStripMenuItem;
        private ToolStripMenuItem otherIp4ToolStripMenuItem;
        private ToolStripMenuItem openNetworkConnectionsToolStripMenuItem;
        private ToolStripMenuItem storedCredentialsToolStripMenuItem;
        private ToolStripMenuItem systemFoldersToolStripMenuItem;
        private ToolStripMenuItem desktopToolStripMenuItem;
        private ToolStripMenuItem userProfilesToolStripMenuItem;
        private ToolStripMenuItem programFilesToolStripMenuItem;
        private ToolStripMenuItem programFilesx86ToolStripMenuItem;
        private ToolStripMenuItem windowsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem controlPanelObjectsToolStripMenuItem;
        private ToolStripMenuItem mainToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem accessibilityToolStripMenuItem;
        private ToolStripMenuItem addNewHardwareToolStripMenuItem;
        private ToolStripMenuItem addRemoveProgramsToolStripMenuItem;
        private ToolStripMenuItem dateTimeToolStripMenuItem;
        private ToolStripMenuItem displayToolStripMenuItem;
        private ToolStripMenuItem findFastToolStripMenuItem;
        private ToolStripMenuItem fontsToolStripMenuItem;
        private ToolStripMenuItem internetPropertiesToolStripMenuItem;
        private ToolStripMenuItem joystickToolStripMenuItem;
        private ToolStripMenuItem keyboardToolStripMenuItem;
        private ToolStripMenuItem exchangeToolStripMenuItem;
        private ToolStripMenuItem microsoftMailPostOfficeToolStripMenuItem;
        private ToolStripMenuItem modemToolStripMenuItem;
        private ToolStripMenuItem mouseToolStripMenuItem;
        private ToolStripMenuItem multimediaToolStripMenuItem;
        private ToolStripMenuItem networkToolStripMenuItem1;
        private ToolStripMenuItem passwordToolStripMenuItem;
        private ToolStripMenuItem pCCardToolStripMenuItem;
        private ToolStripMenuItem powerManagementToolStripMenuItem;
        private ToolStripMenuItem printersToolStripMenuItem;
        private ToolStripMenuItem regionalSettingsToolStripMenuItem;
        private ToolStripMenuItem scannersAndCamerasToolStripMenuItem;
        private ToolStripMenuItem soundToolStripMenuItem;
        private ToolStripMenuItem systemToolStripMenuItem1;
        private ToolStripMenuItem desktopGodmodeFolderToolStripMenuItem;
        private ToolStripMenuItem createLeaveAfterQuitToolStripMenuItem;
        private ToolStripMenuItem createDestroyOnQuitToolStripMenuItem;
        private ToolStripMenuItem diskManagementToolsToolStripMenuItem;
        private ToolStripMenuItem checkDiskToolStripMenuItem;
        private ToolStripMenuItem defragSystemToolStripMenuItem;
        private ToolStripMenuItem defragDefragglerToolStripMenuItem;
        private ToolStripMenuItem diskManagmentToolStripMenuItem;
        private ToolStripMenuItem driveCleanupUtilityToolStripMenuItem;
        private ToolStripMenuItem partitionsToolStripMenuItem;
        private ToolStripMenuItem mSconfigToolStripMenuItem;
        private ToolStripMenuItem systemRestoreToolStripMenuItem;
        private ToolStripMenuItem createRestorePointToolStripMenuItem;
        private ToolStripMenuItem openRestorePointToolStripMenuItem;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem accountsToolStripMenuItem;
        private ToolStripMenuItem advancedAccountsToolStripMenuItem;
        private ToolStripMenuItem autoLogonOptionsToolStripMenuItem;
        private ToolStripMenuItem uAcSettingsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem computerManagementToolStripMenuItem;
        private ToolStripMenuItem componantServicesToolStripMenuItem;
        private ToolStripMenuItem dataSourcesOdbcToolStripMenuItem;
        private ToolStripMenuItem deviceManagerToolStripMenuItem;
        private ToolStripMenuItem directXDiagnosticsToolStripMenuItem;
        private ToolStripMenuItem driverVerifierToolStripMenuItem;
        private ToolStripMenuItem eventViewerToolStripMenuItem;
        private ToolStripMenuItem groupPolicyEditorToolStripMenuItem;
        private ToolStripMenuItem localSecurityPolicyToolStripMenuItem;
        private ToolStripMenuItem performanceMonitorToolStripMenuItem;
        private ToolStripMenuItem printManagementToolStripMenuItem;
        private ToolStripMenuItem registryEditorToolStripMenuItem;
        private ToolStripMenuItem servicesToolStripMenuItem;
        private ToolStripMenuItem sharedFoldersToolStripMenuItem;
        private ToolStripMenuItem taskSchedulerToolStripMenuItem;
        private ToolStripMenuItem windowsMemoryDiagnosticToolStripMenuItem;
        private ToolStripMenuItem wMiTesterToolStripMenuItem;
        private ToolStripMenuItem windowsUpdatesToolStripMenuItem;
        private ToolStripMenuItem windowsVersionToolStripMenuItem;
        private ToolStripMenuItem windowsSecurityCenterToolStripMenuItem;
        private ToolStripMenuItem rOneStopItToolStripMenuItem;
        private ToolStripMenuItem rTronScriptToolStripMenuItem;
        private ToolStripMenuItem ninitecomToolStripMenuItem;
        private ToolStripMenuItem techWebsitesToolStripMenuItem;
        private ToolStripMenuItem bleepingComputerToolStripMenuItem;
        private ToolStripMenuItem geGeekToolStripMenuItem;
        private ToolStripMenuItem browserTestingToolStripMenuItem;
        private ToolStripMenuItem dSlReportscomSpeedTestToolStripMenuItem;
        private ToolStripMenuItem speedtestnetToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem browserscopeToolStripMenuItem;
        private ToolStripMenuItem qualysBrowsercheckToolStripMenuItem;
        private ToolStripMenuItem firefoxOfficialPluginTestToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem silverlightbubblemarkcomToolStripMenuItem;
        private ToolStripMenuItem flashbubblemarkcomToolStripMenuItem;
        private ToolStripMenuItem javajavatesterorgToolStripMenuItem;
        private ToolStripMenuItem shockwaveadobecomToolStripMenuItem;
        private ToolStripMenuItem sSLssllabscomToolStripMenuItem;
        private ToolStripMenuItem shieldsUpToolStripMenuItem;
        private ToolStripMenuItem virusScannerRemovalToolsToolStripMenuItem;
        private ToolStripMenuItem eSetMasterListToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem avastToolStripMenuItem;
        private ToolStripMenuItem aVgToolStripMenuItem;
        private ToolStripMenuItem aviraToolStripMenuItem;
        private ToolStripMenuItem comodoToolStripMenuItem;
        private ToolStripMenuItem fSecureToolStripMenuItem;
        private ToolStripMenuItem kasperskyToolStripMenuItem;
        private ToolStripMenuItem mcAffeToolStripMenuItem;
        private ToolStripMenuItem nOd32ToolStripMenuItem;
        private ToolStripMenuItem nortonToolStripMenuItem;
        private ToolStripMenuItem nortonSecurityScanToolStripMenuItem;
        private ToolStripMenuItem pandaToolStripMenuItem;
        private ToolStripMenuItem sophosToolStripMenuItem;
        private ToolStripMenuItem windowsSecurityEssentialsToolStripMenuItem;
        private ToolStripMenuItem forceShutdownToolStripMenuItem;
        private ToolStripMenuItem forceRestartToolStripMenuItem;
        //private ToolStripMenuItem forceLogoffToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripMenuItem enableF8ToolStripMenuItem;
        private ToolStripMenuItem disableF8ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator22;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripMenuItem setSafemodeSwitchOnToolStripMenuItem;
        private ToolStripMenuItem setSafemodeSwitchOnNetworkingToolStripMenuItem;
        private ToolStripMenuItem setSafemodeSwitchOnMinimalToolStripMenuItem;
        private ToolStripMenuItem setSafemodeSwitchOnAltShellToolStripMenuItem;
        private ToolStripMenuItem setSafemodeSwtichOffNormalBootToolStripMenuItem;
        private ToolStripMenuItem enumerateCurrentModeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripMenuItem hibernateToolStripMenuItem;
        private ToolStripMenuItem hybridShutdownFastStartUpToolStripMenuItem;
        private ToolStripMenuItem shutdownWithOptionsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem disclaimerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator20;
        private ToolStripMenuItem viewOnlineDocumentationToolStripMenuItem;
        private ToolStripMenuItem donateToolStripMenuItem;
        private ToolStripMenuItem bitCoinToolStripMenuItem;
        private ToolStripMenuItem paypalToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator21;
        private ToolStripMenuItem staticToolStripMenuItem;
        private ToolStripMenuItem cBrnisfunToolStripMenuItem;
        private TabPage tpSystemInfo;
        private TabPage tpUninstaller;
        private TabPage tpWmiExplorer;
        private TabPage tpConfigurator;
        private TabPage tpTime;
        private TabControl tpTronSettings;
        private TabPage tpLaunchTron;
        private Button btnLocateTron;
        private Button btnDeploytofolder;
        private Button btnConfigDump;
        private Button btnDryRun;
        private Button btnRunTron;
        private CheckBox cbTronStr;
        private CheckBox cbTronSs;
        private CheckBox cbTronSrr;
        private CheckBox cbTronSfr;
        private CheckBox cbTronSm;
        private CheckBox cbTronSdc;
        private CheckBox cbTronSk;
        private CheckBox cbTronSpr;
        private CheckBox cbTronSw;
        private CheckBox cbTronSe;
        private CheckBox cbTronP;
        private Button btnClear;
        private CheckBox cbTronEr;
        private CheckBox cbTronSb;
        private CheckBox cbTronM;
        private CheckBox cbTronX;
        private CheckBox cbTronO;
        private CheckBox cbTronV;
        private CheckBox cbTronR;
        private CheckBox cbTronSp;
        private CheckBox cbTronSa;
        private CheckBox cbTronSd;
        private TabPage tpEmailSettings;
        private TabPage tpSetFlags;
        private TabControl tcConfigurator;
        private TabPage tpInternetSettings;
        private TabPage tpSecurity;
        private TabPage tpPerformance;
        private TabPage tpWelcomeScreen;
        private TabPage tpWindows10;
        private TabPage tpExplorer;
        private TabPage tpAppearance;
        private LinkLabel lnkInfoInternalIp;
        private Label lblInfoExternalIp;
        private LinkLabel lnkInfoGateway;
        private LinkLabel lnkInfoPrimDns;
        private Label lblDns;
        private Label lblGateway;
        private Label lblExternalIp;
        private Label lblInternalIp;
        private Label lblFreeC;
        private Label lblInfoFreeC;
        private Label lblRam;
        private Label lblInfoRam;
        private Label lblOs;
        private Label lblComputerName;
        private Label lblInfoOs;
        private Label lblInfoComputerName;
        private ToolStripMenuItem qlToolStripMenuItem;
        private ToolStripMenuItem scriptsToolStripMenuItem;
        private ToolStripMenuItem documentsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator23;
        private OpenFileDialog ofdMenuItem;
        private TabPage tpSetup;
        private TabControl tabControl2;
        private TabPage tpQuickLaunch;
        private Label lblQlMenuItemName;
        private Button btnQlCreateNew;
        private TextBox txtQlAppName;
        private Label lblQlFolders;
        private ContextMenuStrip cmsDeleteQl;
        private IContainer components;
        private ListBox lbCurrentPrograms;
        private Button btnQlDeleteSelected;
        private TabPage tpWelcome;
        private TabPage tpOneStopMain;
        private Label lblOsmExecuteOrder;
        private Label lblOsmProgramSelect;
        private Label lblOsmCategories;
        private Button button2;
        private Button button1;
        private ListBox listBox3;
        private ListBox lbProgramSelect;
        private ListBox lbOsmCategories;
        private ComboBox ddlInfoNetworkAdapters;
        private Label lblDescription;
        private Label lblInfoAdapterDesc;
        private TabPage tpShopSettings;
        private Button btnShopSetSave;
        private Label lblShopSetState;
        private TextBox tbShopSetState;
        private Label lblShopSetCity;
        private TextBox tbShopSetCity;
        private Label lblShopSetEmail;
        private TextBox tbShopSetEmail;
        private Label lblShopSetPhone;
        private TextBox tbShopSetPhone;
        private TextBox tbShopSetAddr2;
        private Label lblShopSetAddr;
        private TextBox tbShopSetAddr1;
        private Label lblShopSetShopname;
        private TextBox tbShopSetName;
        private CheckBox cbTronE;
        private CheckBox cbTronDev;
        private OpenFileDialog ofdTron;
        private Button btnTronSaveFlags;
        private TabPage tpOem;

        public OsMain()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tsBottomToolbar = new System.Windows.Forms.ToolStrip();
            this.pbCurrentProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator01 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCurrentActionStatus = new System.Windows.Forms.ToolStripLabel();
            this.lblAdminStatus = new System.Windows.Forms.ToolStripLabel();
            this.lblBootStatus = new System.Windows.Forms.ToolStripLabel();
            this.lblTronStatus = new System.Windows.Forms.ToolStripLabel();
            this.menuPrimary = new System.Windows.Forms.MenuStrip();
            this.qlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.oneStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startAtRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartAsAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.oneStopSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tRonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tempcleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disinfectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wrapUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setConfigurationOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deployTronToNewLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.oneStopToolGetFileInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneStopToolInternalBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runPromptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsRunCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openPowershellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openElevatedCommandPromptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openElevatedCommandPromptToPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneStopInternalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchPortableBrowsersetInConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRouterInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAtDefaultGatewayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHttprouterpasswordscomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.openSavedInterface1XxxxxxxxxxxxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSavedInterface2XxxxxxxxxxxxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.dNsSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.firewallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsFirewallAndAdvancedSecurityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetFirewallToDefaultnetshFirewallResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableFirewallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableFirewallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.importFirewallSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFirewallSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableRemoteManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableRemoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableProgramInFirewallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enablePortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPolicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getGroupPolicyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGroupPolicyEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.connectivityToHttpwwwgooglecomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingIp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pringIp6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traceRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingPathIp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingPathIp6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectivityToDefaultGatewayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ipconfigalltoolstripmenuitem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDhcpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDhcpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.resetTcpipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flushDnsCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flushArpCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flushNetbiosCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restIpv4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resteIpv6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetWinsockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.netstatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ownIpip4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loopbackIp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gatewayIp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherIp4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNetworkConnectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storedCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programFilesx86ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.controlPanelObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.accessibilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewHardwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRemoveProgramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findFastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internetPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joystickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exchangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microsoftMailPostOfficeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multimediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionalSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scannersAndCamerasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.desktopGodmodeFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createLeaveAfterQuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDestroyOnQuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diskManagementToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defragSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defragDefragglerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diskManagmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driveCleanupUtilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSconfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRestorePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRestorePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoLogonOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uAcSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.computerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componantServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSourcesOdbcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directXDiagnosticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driverVerifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPolicyEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localSecurityPolicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.performanceMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registryEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharedFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskSchedulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMemoryDiagnosticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wMiTesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsSecurityCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.techResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOneStopItToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTronScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ninitecomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.techWebsitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bleepingComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geGeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserTestingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSlReportscomSpeedTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedtestnetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.browserscopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qualysBrowsercheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firefoxOfficialPluginTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.silverlightbubblemarkcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flashbubblemarkcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.javajavatesterorgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shockwaveadobecomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSLssllabscomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shieldsUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.virusScannerRemovalToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eSetMasterListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.avastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aVgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aviraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fSecureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasperskyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mcAffeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nOd32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nortonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nortonSecurityScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pandaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sophosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsSecurityEssentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceShutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceLogoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceRestartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.enableF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.setSafemodeSwitchOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSafemodeSwitchOnNetworkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSafemodeSwitchOnMinimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSafemodeSwitchOnAltShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSafemodeSwtichOffNormalBootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enumerateCurrentModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.hibernateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hybridShutdownFastStartUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownWithOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disclaimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.viewOnlineDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitCoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paypalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.staticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cBrnisfunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcPrimaryTabs = new System.Windows.Forms.TabControl();
            this.tpWelcome = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.tpOneStopMain = new System.Windows.Forms.TabPage();
            this.lblOsmExecuteOrder = new System.Windows.Forms.Label();
            this.lblOsmProgramSelect = new System.Windows.Forms.Label();
            this.lblOsmCategories = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.lbProgramSelect = new System.Windows.Forms.ListBox();
            this.lbOsmCategories = new System.Windows.Forms.ListBox();
            this.tpTronCli = new System.Windows.Forms.TabPage();
            this.tpTronSettings = new System.Windows.Forms.TabControl();
            this.tpLaunchTron = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.btnTronSaveFlags = new System.Windows.Forms.Button();
            this.cbTronE = new System.Windows.Forms.CheckBox();
            this.cbTronDev = new System.Windows.Forms.CheckBox();
            this.btnLocateTron = new System.Windows.Forms.Button();
            this.btnDeploytofolder = new System.Windows.Forms.Button();
            this.btnConfigDump = new System.Windows.Forms.Button();
            this.btnDryRun = new System.Windows.Forms.Button();
            this.btnRunTron = new System.Windows.Forms.Button();
            this.cbTronStr = new System.Windows.Forms.CheckBox();
            this.cbTronSs = new System.Windows.Forms.CheckBox();
            this.cbTronSrr = new System.Windows.Forms.CheckBox();
            this.cbTronSfr = new System.Windows.Forms.CheckBox();
            this.cbTronSm = new System.Windows.Forms.CheckBox();
            this.cbTronSdc = new System.Windows.Forms.CheckBox();
            this.cbTronSk = new System.Windows.Forms.CheckBox();
            this.cbTronSpr = new System.Windows.Forms.CheckBox();
            this.cbTronSw = new System.Windows.Forms.CheckBox();
            this.cbTronSe = new System.Windows.Forms.CheckBox();
            this.cbTronP = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbTronEr = new System.Windows.Forms.CheckBox();
            this.cbTronSb = new System.Windows.Forms.CheckBox();
            this.cbTronM = new System.Windows.Forms.CheckBox();
            this.cbTronX = new System.Windows.Forms.CheckBox();
            this.cbTronO = new System.Windows.Forms.CheckBox();
            this.cbTronV = new System.Windows.Forms.CheckBox();
            this.cbTronR = new System.Windows.Forms.CheckBox();
            this.cbTronSp = new System.Windows.Forms.CheckBox();
            this.cbTronSa = new System.Windows.Forms.CheckBox();
            this.cbTronSd = new System.Windows.Forms.CheckBox();
            this.tpEmailSettings = new System.Windows.Forms.TabPage();
            this.tpSetFlags = new System.Windows.Forms.TabPage();
            this.tpTime = new System.Windows.Forms.TabPage();
            this.tpSystemInfo = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSystemReport = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.label20 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tpNetwork = new System.Windows.Forms.TabPage();
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
            this.tpUninstaller = new System.Windows.Forms.TabPage();
            this.tpWmiExplorer = new System.Windows.Forms.TabPage();
            this.tpConfigurator = new System.Windows.Forms.TabPage();
            this.tcConfigurator = new System.Windows.Forms.TabControl();
            this.tpInternetSettings = new System.Windows.Forms.TabPage();
            this.tpSecurity = new System.Windows.Forms.TabPage();
            this.tpPerformance = new System.Windows.Forms.TabPage();
            this.tpWelcomeScreen = new System.Windows.Forms.TabPage();
            this.tpWindows10 = new System.Windows.Forms.TabPage();
            this.tpExplorer = new System.Windows.Forms.TabPage();
            this.tpAppearance = new System.Windows.Forms.TabPage();
            this.tpOem = new System.Windows.Forms.TabPage();
            this.tpSetup = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tpQuickLaunch = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.btnQlDeleteSelected = new System.Windows.Forms.Button();
            this.lbCurrentPrograms = new System.Windows.Forms.ListBox();
            this.lblQlMenuItemName = new System.Windows.Forms.Label();
            this.btnQlCreateNew = new System.Windows.Forms.Button();
            this.txtQlAppName = new System.Windows.Forms.TextBox();
            this.lblQlFolders = new System.Windows.Forms.Label();
            this.tpShopSettings = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnShopSetSave = new System.Windows.Forms.Button();
            this.lblShopSetState = new System.Windows.Forms.Label();
            this.tbShopSetState = new System.Windows.Forms.TextBox();
            this.lblShopSetCity = new System.Windows.Forms.Label();
            this.tbShopSetCity = new System.Windows.Forms.TextBox();
            this.lblShopSetEmail = new System.Windows.Forms.Label();
            this.tbShopSetEmail = new System.Windows.Forms.TextBox();
            this.lblShopSetPhone = new System.Windows.Forms.Label();
            this.tbShopSetPhone = new System.Windows.Forms.TextBox();
            this.tbShopSetAddr2 = new System.Windows.Forms.TextBox();
            this.lblShopSetAddr = new System.Windows.Forms.Label();
            this.tbShopSetAddr1 = new System.Windows.Forms.TextBox();
            this.lblShopSetShopname = new System.Windows.Forms.Label();
            this.tbShopSetName = new System.Windows.Forms.TextBox();
            this.tpServers = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mailGroupBox = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tpIntegration = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button12 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.tpLogging = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbVerboseErrorLog = new System.Windows.Forms.CheckBox();
            this.cbVerboseErrorConsole = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCMDLog = new System.Windows.Forms.CheckBox();
            this.cbCMDConsole = new System.Windows.Forms.CheckBox();
            this.btnSaveLoggingStatus = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cbOSStartLog = new System.Windows.Forms.CheckBox();
            this.cbOSStartConsole = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cbSysInfoLog = new System.Windows.Forms.CheckBox();
            this.cbSysinfoConsole = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbGPLNoticeLog = new System.Windows.Forms.CheckBox();
            this.cbGPLConsole = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cbOpenedLog = new System.Windows.Forms.CheckBox();
            this.cbOpenedConsole = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbRegistryLog = new System.Windows.Forms.CheckBox();
            this.cbRegistryConsole = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbWebsitesLog = new System.Windows.Forms.CheckBox();
            this.cbWebsitesConsole = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lnkInfoInternalIp = new System.Windows.Forms.LinkLabel();
            this.lblInfoExternalIp = new System.Windows.Forms.Label();
            this.lnkInfoGateway = new System.Windows.Forms.LinkLabel();
            this.lnkInfoPrimDns = new System.Windows.Forms.LinkLabel();
            this.lblDns = new System.Windows.Forms.Label();
            this.lblGateway = new System.Windows.Forms.Label();
            this.lblExternalIp = new System.Windows.Forms.Label();
            this.lblInternalIp = new System.Windows.Forms.Label();
            this.lblFreeC = new System.Windows.Forms.Label();
            this.lblInfoFreeC = new System.Windows.Forms.Label();
            this.lblRam = new System.Windows.Forms.Label();
            this.lblInfoRam = new System.Windows.Forms.Label();
            this.lblOs = new System.Windows.Forms.Label();
            this.lblComputerName = new System.Windows.Forms.Label();
            this.lblInfoOs = new System.Windows.Forms.Label();
            this.lblInfoComputerName = new System.Windows.Forms.Label();
            this.ofdMenuItem = new System.Windows.Forms.OpenFileDialog();
            this.cmsDeleteQl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ddlInfoNetworkAdapters = new System.Windows.Forms.ComboBox();
            this.lblInfoAdapterDesc = new System.Windows.Forms.Label();
            this.ofdTron = new System.Windows.Forms.OpenFileDialog();
            this.tsBottomToolbar.SuspendLayout();
            this.menuPrimary.SuspendLayout();
            this.tcPrimaryTabs.SuspendLayout();
            this.tpWelcome.SuspendLayout();
            this.tpOneStopMain.SuspendLayout();
            this.tpTronCli.SuspendLayout();
            this.tpTronSettings.SuspendLayout();
            this.tpLaunchTron.SuspendLayout();
            this.tpSystemInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpSystemReport.SuspendLayout();
            this.tpNetwork.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tpConfigurator.SuspendLayout();
            this.tcConfigurator.SuspendLayout();
            this.tpSetup.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tpQuickLaunch.SuspendLayout();
            this.tpShopSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tpServers.SuspendLayout();
            this.mailGroupBox.SuspendLayout();
            this.tpIntegration.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tpLogging.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsBottomToolbar
            // 
            this.tsBottomToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsBottomToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbCurrentProgress,
            this.toolStripSeparator01,
            this.lblCurrentActionStatus,
            this.lblAdminStatus,
            this.lblBootStatus,
            this.lblTronStatus});
            this.tsBottomToolbar.Location = new System.Drawing.Point(0, 506);
            this.tsBottomToolbar.Name = "tsBottomToolbar";
            this.tsBottomToolbar.Size = new System.Drawing.Size(754, 25);
            this.tsBottomToolbar.TabIndex = 0;
            this.tsBottomToolbar.Text = "tsBottomToolbar";
            // 
            // pbCurrentProgress
            // 
            this.pbCurrentProgress.Name = "pbCurrentProgress";
            this.pbCurrentProgress.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStripSeparator01
            // 
            this.toolStripSeparator01.Name = "toolStripSeparator01";
            this.toolStripSeparator01.Size = new System.Drawing.Size(6, 25);
            // 
            // lblCurrentActionStatus
            // 
            this.lblCurrentActionStatus.Name = "lblCurrentActionStatus";
            this.lblCurrentActionStatus.Size = new System.Drawing.Size(0, 22);
            // 
            // lblAdminStatus
            // 
            this.lblAdminStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblAdminStatus.Name = "lblAdminStatus";
            this.lblAdminStatus.Size = new System.Drawing.Size(88, 22);
            this.lblAdminStatus.Text = "lblAdminStatus";
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
            // menuPrimary
            // 
            this.menuPrimary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qlToolStripMenuItem,
            this.oneStopToolStripMenuItem,
            this.runPromptToolStripMenuItem,
            this.networkToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.techResourcesToolStripMenuItem,
            this.powerToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuPrimary.Location = new System.Drawing.Point(0, 0);
            this.menuPrimary.Name = "menuPrimary";
            this.menuPrimary.Size = new System.Drawing.Size(754, 24);
            this.menuPrimary.TabIndex = 1;
            // 
            // qlToolStripMenuItem
            // 
            this.qlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptsToolStripMenuItem,
            this.documentsToolStripMenuItem,
            this.toolStripSeparator23});
            this.qlToolStripMenuItem.Name = "qlToolStripMenuItem";
            this.qlToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.qlToolStripMenuItem.Text = "QL";
            // 
            // scriptsToolStripMenuItem
            // 
            this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            this.scriptsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.scriptsToolStripMenuItem.Text = "Scripts";
            // 
            // documentsToolStripMenuItem
            // 
            this.documentsToolStripMenuItem.Name = "documentsToolStripMenuItem";
            this.documentsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.documentsToolStripMenuItem.Text = "Documents";
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(132, 6);
            // 
            // oneStopToolStripMenuItem
            // 
            this.oneStopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startAtRunToolStripMenuItem,
            this.restartAsAdminToolStripMenuItem,
            this.toolStripSeparator2,
            this.oneStopSettingsToolStripMenuItem,
            this.tRonToolStripMenuItem,
            this.toolStripSeparator22,
            this.oneStopToolGetFileInfoToolStripMenuItem,
            this.oneStopToolInternalBrowserToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.oneStopToolStripMenuItem.Name = "oneStopToolStripMenuItem";
            this.oneStopToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.oneStopToolStripMenuItem.Text = "OneStop";
            // 
            // startAtRunToolStripMenuItem
            // 
            this.startAtRunToolStripMenuItem.Name = "startAtRunToolStripMenuItem";
            this.startAtRunToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.startAtRunToolStripMenuItem.Text = "Start at Run";
            this.startAtRunToolStripMenuItem.Click += new System.EventHandler(this.setSafemodeSwitchOnMinimalToolStripMenuItem_Click);
            // 
            // restartAsAdminToolStripMenuItem
            // 
            this.restartAsAdminToolStripMenuItem.Name = "restartAsAdminToolStripMenuItem";
            this.restartAsAdminToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.restartAsAdminToolStripMenuItem.Text = "Restart as Admin";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(293, 6);
            // 
            // oneStopSettingsToolStripMenuItem
            // 
            this.oneStopSettingsToolStripMenuItem.Name = "oneStopSettingsToolStripMenuItem";
            this.oneStopSettingsToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.oneStopSettingsToolStripMenuItem.Text = "OneStop Settings";
            // 
            // tRonToolStripMenuItem
            // 
            this.tRonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.foldersToolStripMenuItem,
            this.setConfigurationOptionsToolStripMenuItem,
            this.deployTronToNewLocationToolStripMenuItem});
            this.tRonToolStripMenuItem.Name = "tRonToolStripMenuItem";
            this.tRonToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.tRonToolStripMenuItem.Text = "TRON Settings";
            // 
            // foldersToolStripMenuItem
            // 
            this.foldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prepToolStripMenuItem,
            this.tempcleanToolStripMenuItem,
            this.dToolStripMenuItem,
            this.disinfectToolStripMenuItem,
            this.repairToolStripMenuItem,
            this.patchToolStripMenuItem,
            this.optimizeToolStripMenuItem,
            this.wrapUpToolStripMenuItem,
            this.manualToolsToolStripMenuItem});
            this.foldersToolStripMenuItem.Name = "foldersToolStripMenuItem";
            this.foldersToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.foldersToolStripMenuItem.Text = "Folders";
            // 
            // prepToolStripMenuItem
            // 
            this.prepToolStripMenuItem.Name = "prepToolStripMenuItem";
            this.prepToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.prepToolStripMenuItem.Text = "0 - Prep";
            // 
            // tempcleanToolStripMenuItem
            // 
            this.tempcleanToolStripMenuItem.Name = "tempcleanToolStripMenuItem";
            this.tempcleanToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.tempcleanToolStripMenuItem.Text = "1 - Tempclean";
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.dToolStripMenuItem.Text = "2 - Debloat";
            // 
            // disinfectToolStripMenuItem
            // 
            this.disinfectToolStripMenuItem.Name = "disinfectToolStripMenuItem";
            this.disinfectToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.disinfectToolStripMenuItem.Text = "3 - Disinfect";
            // 
            // repairToolStripMenuItem
            // 
            this.repairToolStripMenuItem.Name = "repairToolStripMenuItem";
            this.repairToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.repairToolStripMenuItem.Text = "4 - Repair";
            // 
            // patchToolStripMenuItem
            // 
            this.patchToolStripMenuItem.Name = "patchToolStripMenuItem";
            this.patchToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.patchToolStripMenuItem.Text = "5 - Patch";
            // 
            // optimizeToolStripMenuItem
            // 
            this.optimizeToolStripMenuItem.Name = "optimizeToolStripMenuItem";
            this.optimizeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.optimizeToolStripMenuItem.Text = "6 - Optimize";
            // 
            // wrapUpToolStripMenuItem
            // 
            this.wrapUpToolStripMenuItem.Name = "wrapUpToolStripMenuItem";
            this.wrapUpToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.wrapUpToolStripMenuItem.Text = "7 - Wrap-Up";
            // 
            // manualToolsToolStripMenuItem
            // 
            this.manualToolsToolStripMenuItem.Name = "manualToolsToolStripMenuItem";
            this.manualToolsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.manualToolsToolStripMenuItem.Text = "8 - Manual Tools";
            // 
            // setConfigurationOptionsToolStripMenuItem
            // 
            this.setConfigurationOptionsToolStripMenuItem.Name = "setConfigurationOptionsToolStripMenuItem";
            this.setConfigurationOptionsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.setConfigurationOptionsToolStripMenuItem.Text = "Set Configuration Options";
            // 
            // deployTronToNewLocationToolStripMenuItem
            // 
            this.deployTronToNewLocationToolStripMenuItem.Name = "deployTronToNewLocationToolStripMenuItem";
            this.deployTronToNewLocationToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.deployTronToNewLocationToolStripMenuItem.Text = "Deploy TRON to new Location";
            this.deployTronToNewLocationToolStripMenuItem.Click += new System.EventHandler(this.disableF8ToolStripMenuItem_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(293, 6);
            // 
            // oneStopToolGetFileInfoToolStripMenuItem
            // 
            this.oneStopToolGetFileInfoToolStripMenuItem.Name = "oneStopToolGetFileInfoToolStripMenuItem";
            this.oneStopToolGetFileInfoToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.oneStopToolGetFileInfoToolStripMenuItem.Text = "OneStop Tool: Get File Info";
            this.oneStopToolGetFileInfoToolStripMenuItem.Click += new System.EventHandler(this.oneStopToolGetFileInfoToolStripMenuItem_Click);
            // 
            // oneStopToolInternalBrowserToolStripMenuItem
            // 
            this.oneStopToolInternalBrowserToolStripMenuItem.Name = "oneStopToolInternalBrowserToolStripMenuItem";
            this.oneStopToolInternalBrowserToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.oneStopToolInternalBrowserToolStripMenuItem.Text = "OneStop Tool: Internal Browser (IE Engine)";
            this.oneStopToolInternalBrowserToolStripMenuItem.Click += new System.EventHandler(this.oneStopToolInternalBrowserToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(293, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // runPromptToolStripMenuItem
            // 
            this.runPromptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsRunCommandToolStripMenuItem,
            this.toolStripSeparator3,
            this.openPowershellToolStripMenuItem,
            this.openElevatedCommandPromptToolStripMenuItem,
            this.openElevatedCommandPromptToPathToolStripMenuItem});
            this.runPromptToolStripMenuItem.Name = "runPromptToolStripMenuItem";
            this.runPromptToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.runPromptToolStripMenuItem.Text = "Run/Prompt";
            // 
            // windowsRunCommandToolStripMenuItem
            // 
            this.windowsRunCommandToolStripMenuItem.Name = "windowsRunCommandToolStripMenuItem";
            this.windowsRunCommandToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.windowsRunCommandToolStripMenuItem.Text = "Windows Run Command";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(291, 6);
            // 
            // openPowershellToolStripMenuItem
            // 
            this.openPowershellToolStripMenuItem.Name = "openPowershellToolStripMenuItem";
            this.openPowershellToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.openPowershellToolStripMenuItem.Text = "Open Powershell";
            // 
            // openElevatedCommandPromptToolStripMenuItem
            // 
            this.openElevatedCommandPromptToolStripMenuItem.Name = "openElevatedCommandPromptToolStripMenuItem";
            this.openElevatedCommandPromptToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.openElevatedCommandPromptToolStripMenuItem.Text = "Open Elevated Command Prompt";
            // 
            // openElevatedCommandPromptToPathToolStripMenuItem
            // 
            this.openElevatedCommandPromptToPathToolStripMenuItem.Name = "openElevatedCommandPromptToPathToolStripMenuItem";
            this.openElevatedCommandPromptToPathToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.openElevatedCommandPromptToPathToolStripMenuItem.Text = "Open Elevated Command Prompt to Path";
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testBrowserToolStripMenuItem,
            this.openRouterInterfaceToolStripMenuItem,
            this.dNsSettingsToolStripMenuItem,
            this.resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem,
            this.toolStripSeparator6,
            this.firewallToolStripMenuItem,
            this.groupPolicyToolStripMenuItem,
            this.toolStripSeparator8,
            this.connectivityToHttpwwwgooglecomToolStripMenuItem,
            this.connectivityToDefaultGatewayToolStripMenuItem,
            this.ipconfigalltoolstripmenuitem,
            this.releaseDhcpToolStripMenuItem,
            this.renewDhcpToolStripMenuItem,
            this.toolStripSeparator9,
            this.resetTcpipToolStripMenuItem,
            this.flushDnsCacheToolStripMenuItem,
            this.flushArpCacheToolStripMenuItem,
            this.flushNetbiosCacheToolStripMenuItem,
            this.restIpv4ToolStripMenuItem,
            this.resteIpv6ToolStripMenuItem,
            this.resetWinsockToolStripMenuItem,
            this.toolStripSeparator10,
            this.netstatToolStripMenuItem,
            this.pingToolStripMenuItem,
            this.openNetworkConnectionsToolStripMenuItem,
            this.storedCredentialsToolStripMenuItem});
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.networkToolStripMenuItem.Text = "Network";
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
            // openRouterInterfaceToolStripMenuItem
            // 
            this.openRouterInterfaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAtDefaultGatewayToolStripMenuItem,
            this.openHttprouterpasswordscomToolStripMenuItem,
            this.toolStripSeparator5,
            this.openSavedInterface1XxxxxxxxxxxxToolStripMenuItem,
            this.openSavedInterface2XxxxxxxxxxxxToolStripMenuItem,
            this.toolStripSeparator4,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12});
            this.openRouterInterfaceToolStripMenuItem.Name = "openRouterInterfaceToolStripMenuItem";
            this.openRouterInterfaceToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.openRouterInterfaceToolStripMenuItem.Text = "Open Router Interface";
            // 
            // openAtDefaultGatewayToolStripMenuItem
            // 
            this.openAtDefaultGatewayToolStripMenuItem.Name = "openAtDefaultGatewayToolStripMenuItem";
            this.openAtDefaultGatewayToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.openAtDefaultGatewayToolStripMenuItem.Text = "Open at Default Gateway";
            // 
            // openHttprouterpasswordscomToolStripMenuItem
            // 
            this.openHttprouterpasswordscomToolStripMenuItem.Name = "openHttprouterpasswordscomToolStripMenuItem";
            this.openHttprouterpasswordscomToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.openHttprouterpasswordscomToolStripMenuItem.Text = "Open http://routerpasswords.com";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(296, 6);
            // 
            // openSavedInterface1XxxxxxxxxxxxToolStripMenuItem
            // 
            this.openSavedInterface1XxxxxxxxxxxxToolStripMenuItem.Name = "openSavedInterface1XxxxxxxxxxxxToolStripMenuItem";
            this.openSavedInterface1XxxxxxxxxxxxToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.openSavedInterface1XxxxxxxxxxxxToolStripMenuItem.Text = "Open Saved Interface 1 (XXX.XXX.XXX.XXX)";
            // 
            // openSavedInterface2XxxxxxxxxxxxToolStripMenuItem
            // 
            this.openSavedInterface2XxxxxxxxxxxxToolStripMenuItem.Name = "openSavedInterface2XxxxxxxxxxxxToolStripMenuItem";
            this.openSavedInterface2XxxxxxxxxxxxToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.openSavedInterface2XxxxxxxxxxxxToolStripMenuItem.Text = "Open Saved Interface 2 (XXX.XXX.XXX.XXX)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(296, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem2.Text = "192.168.1.1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem3.Text = "192.168.0.1";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem4.Text = "192.168.1.254";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem5.Text = "192.168.2.1";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem6.Text = "10.0.0.138";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem7.Text = "10.0.0.2";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem8.Text = "192.168.10.1";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem9.Text = "10.0.0.1";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem10.Text = "192.168.15.1";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem11.Text = "192.168.0.30";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem12.Text = "192.168.100.1";
            // 
            // dNsSettingsToolStripMenuItem
            // 
            this.dNsSettingsToolStripMenuItem.Name = "dNsSettingsToolStripMenuItem";
            this.dNsSettingsToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.dNsSettingsToolStripMenuItem.Text = "DNS Settings";
            // 
            // resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem
            // 
            this.resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem.Name = "resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem";
            this.resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem.Text = "Reset Network Settings to Defaults and Clear All Caches";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(363, 6);
            // 
            // firewallToolStripMenuItem
            // 
            this.firewallToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsFirewallAndAdvancedSecurityToolStripMenuItem,
            this.resetFirewallToDefaultnetshFirewallResetToolStripMenuItem,
            this.enableFirewallToolStripMenuItem,
            this.disableFirewallToolStripMenuItem,
            this.toolStripSeparator7,
            this.importFirewallSettingsToolStripMenuItem,
            this.exportFirewallSettingsToolStripMenuItem,
            this.enableRemoteManagementToolStripMenuItem,
            this.enableRemoteDesktopToolStripMenuItem,
            this.enableProgramInFirewallToolStripMenuItem,
            this.enablePortToolStripMenuItem});
            this.firewallToolStripMenuItem.Name = "firewallToolStripMenuItem";
            this.firewallToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.firewallToolStripMenuItem.Text = "Firewall";
            // 
            // windowsFirewallAndAdvancedSecurityToolStripMenuItem
            // 
            this.windowsFirewallAndAdvancedSecurityToolStripMenuItem.Name = "windowsFirewallAndAdvancedSecurityToolStripMenuItem";
            this.windowsFirewallAndAdvancedSecurityToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.windowsFirewallAndAdvancedSecurityToolStripMenuItem.Text = "Windows Firewall and Advanced Security";
            // 
            // resetFirewallToDefaultnetshFirewallResetToolStripMenuItem
            // 
            this.resetFirewallToDefaultnetshFirewallResetToolStripMenuItem.Name = "resetFirewallToDefaultnetshFirewallResetToolStripMenuItem";
            this.resetFirewallToDefaultnetshFirewallResetToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.resetFirewallToDefaultnetshFirewallResetToolStripMenuItem.Text = "Reset Firewall to Default";
            // 
            // enableFirewallToolStripMenuItem
            // 
            this.enableFirewallToolStripMenuItem.Name = "enableFirewallToolStripMenuItem";
            this.enableFirewallToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.enableFirewallToolStripMenuItem.Text = "Enable Firewall";
            // 
            // disableFirewallToolStripMenuItem
            // 
            this.disableFirewallToolStripMenuItem.Name = "disableFirewallToolStripMenuItem";
            this.disableFirewallToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.disableFirewallToolStripMenuItem.Text = "Disable Firewall";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(287, 6);
            // 
            // importFirewallSettingsToolStripMenuItem
            // 
            this.importFirewallSettingsToolStripMenuItem.Name = "importFirewallSettingsToolStripMenuItem";
            this.importFirewallSettingsToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.importFirewallSettingsToolStripMenuItem.Text = "Import Firewall Settings";
            // 
            // exportFirewallSettingsToolStripMenuItem
            // 
            this.exportFirewallSettingsToolStripMenuItem.Name = "exportFirewallSettingsToolStripMenuItem";
            this.exportFirewallSettingsToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.exportFirewallSettingsToolStripMenuItem.Text = "Export Firewall Settings";
            // 
            // enableRemoteManagementToolStripMenuItem
            // 
            this.enableRemoteManagementToolStripMenuItem.Name = "enableRemoteManagementToolStripMenuItem";
            this.enableRemoteManagementToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.enableRemoteManagementToolStripMenuItem.Text = "Enable Remote Management";
            // 
            // enableRemoteDesktopToolStripMenuItem
            // 
            this.enableRemoteDesktopToolStripMenuItem.Name = "enableRemoteDesktopToolStripMenuItem";
            this.enableRemoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.enableRemoteDesktopToolStripMenuItem.Text = "Enable Remote Desktop";
            // 
            // enableProgramInFirewallToolStripMenuItem
            // 
            this.enableProgramInFirewallToolStripMenuItem.Name = "enableProgramInFirewallToolStripMenuItem";
            this.enableProgramInFirewallToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.enableProgramInFirewallToolStripMenuItem.Text = "Enable a Program";
            // 
            // enablePortToolStripMenuItem
            // 
            this.enablePortToolStripMenuItem.Name = "enablePortToolStripMenuItem";
            this.enablePortToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.enablePortToolStripMenuItem.Text = "Enable a Port";
            // 
            // groupPolicyToolStripMenuItem
            // 
            this.groupPolicyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getGroupPolicyReportToolStripMenuItem,
            this.forceRefreshToolStripMenuItem,
            this.openGroupPolicyEditorToolStripMenuItem});
            this.groupPolicyToolStripMenuItem.Name = "groupPolicyToolStripMenuItem";
            this.groupPolicyToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.groupPolicyToolStripMenuItem.Text = "Group Policy";
            // 
            // getGroupPolicyReportToolStripMenuItem
            // 
            this.getGroupPolicyReportToolStripMenuItem.Name = "getGroupPolicyReportToolStripMenuItem";
            this.getGroupPolicyReportToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.getGroupPolicyReportToolStripMenuItem.Text = "Get Group Policy Report";
            // 
            // forceRefreshToolStripMenuItem
            // 
            this.forceRefreshToolStripMenuItem.Name = "forceRefreshToolStripMenuItem";
            this.forceRefreshToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.forceRefreshToolStripMenuItem.Text = "Force Refresh";
            // 
            // openGroupPolicyEditorToolStripMenuItem
            // 
            this.openGroupPolicyEditorToolStripMenuItem.Name = "openGroupPolicyEditorToolStripMenuItem";
            this.openGroupPolicyEditorToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.openGroupPolicyEditorToolStripMenuItem.Text = "Open Group Policy Editor";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(363, 6);
            // 
            // connectivityToHttpwwwgooglecomToolStripMenuItem
            // 
            this.connectivityToHttpwwwgooglecomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pingIp4ToolStripMenuItem,
            this.pringIp6ToolStripMenuItem,
            this.traceRouteToolStripMenuItem,
            this.pingPathIp4ToolStripMenuItem,
            this.pingPathIp6ToolStripMenuItem});
            this.connectivityToHttpwwwgooglecomToolStripMenuItem.Name = "connectivityToHttpwwwgooglecomToolStripMenuItem";
            this.connectivityToHttpwwwgooglecomToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.connectivityToHttpwwwgooglecomToolStripMenuItem.Text = "Connectivity to http://www.google.com";
            // 
            // pingIp4ToolStripMenuItem
            // 
            this.pingIp4ToolStripMenuItem.Name = "pingIp4ToolStripMenuItem";
            this.pingIp4ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pingIp4ToolStripMenuItem.Text = "Ping (IP4)";
            // 
            // pringIp6ToolStripMenuItem
            // 
            this.pringIp6ToolStripMenuItem.Name = "pringIp6ToolStripMenuItem";
            this.pringIp6ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pringIp6ToolStripMenuItem.Text = "Pring (IP6)";
            // 
            // traceRouteToolStripMenuItem
            // 
            this.traceRouteToolStripMenuItem.Name = "traceRouteToolStripMenuItem";
            this.traceRouteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.traceRouteToolStripMenuItem.Text = "Trace Route";
            // 
            // pingPathIp4ToolStripMenuItem
            // 
            this.pingPathIp4ToolStripMenuItem.Name = "pingPathIp4ToolStripMenuItem";
            this.pingPathIp4ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pingPathIp4ToolStripMenuItem.Text = "Ping Path (IP4)";
            // 
            // pingPathIp6ToolStripMenuItem
            // 
            this.pingPathIp6ToolStripMenuItem.Name = "pingPathIp6ToolStripMenuItem";
            this.pingPathIp6ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pingPathIp6ToolStripMenuItem.Text = "Ping Path (IP 6)";
            // 
            // connectivityToDefaultGatewayToolStripMenuItem
            // 
            this.connectivityToDefaultGatewayToolStripMenuItem.Name = "connectivityToDefaultGatewayToolStripMenuItem";
            this.connectivityToDefaultGatewayToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.connectivityToDefaultGatewayToolStripMenuItem.Text = "Connectivity to Default Gateway";
            // 
            // ipconfigalltoolstripmenuitem
            // 
            this.ipconfigalltoolstripmenuitem.Name = "ipconfigalltoolstripmenuitem";
            this.ipconfigalltoolstripmenuitem.Size = new System.Drawing.Size(366, 22);
            this.ipconfigalltoolstripmenuitem.Text = "Show all IP Info";
            // 
            // releaseDhcpToolStripMenuItem
            // 
            this.releaseDhcpToolStripMenuItem.Name = "releaseDhcpToolStripMenuItem";
            this.releaseDhcpToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.releaseDhcpToolStripMenuItem.Text = "Release DHCP";
            // 
            // renewDhcpToolStripMenuItem
            // 
            this.renewDhcpToolStripMenuItem.Name = "renewDhcpToolStripMenuItem";
            this.renewDhcpToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.renewDhcpToolStripMenuItem.Text = "Renew DHCP";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(363, 6);
            // 
            // resetTcpipToolStripMenuItem
            // 
            this.resetTcpipToolStripMenuItem.Name = "resetTcpipToolStripMenuItem";
            this.resetTcpipToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.resetTcpipToolStripMenuItem.Text = "Reset TCP/IP";
            // 
            // flushDnsCacheToolStripMenuItem
            // 
            this.flushDnsCacheToolStripMenuItem.Name = "flushDnsCacheToolStripMenuItem";
            this.flushDnsCacheToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.flushDnsCacheToolStripMenuItem.Text = "Flush DNS Cache";
            // 
            // flushArpCacheToolStripMenuItem
            // 
            this.flushArpCacheToolStripMenuItem.Name = "flushArpCacheToolStripMenuItem";
            this.flushArpCacheToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.flushArpCacheToolStripMenuItem.Text = "Flush ARP Cache";
            // 
            // flushNetbiosCacheToolStripMenuItem
            // 
            this.flushNetbiosCacheToolStripMenuItem.Name = "flushNetbiosCacheToolStripMenuItem";
            this.flushNetbiosCacheToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.flushNetbiosCacheToolStripMenuItem.Text = "Flush NetBIOS Cache";
            // 
            // restIpv4ToolStripMenuItem
            // 
            this.restIpv4ToolStripMenuItem.Name = "restIpv4ToolStripMenuItem";
            this.restIpv4ToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.restIpv4ToolStripMenuItem.Text = "Reset IPV4";
            // 
            // resteIpv6ToolStripMenuItem
            // 
            this.resteIpv6ToolStripMenuItem.Name = "resteIpv6ToolStripMenuItem";
            this.resteIpv6ToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.resteIpv6ToolStripMenuItem.Text = "Reset IPV6";
            // 
            // resetWinsockToolStripMenuItem
            // 
            this.resetWinsockToolStripMenuItem.Name = "resetWinsockToolStripMenuItem";
            this.resetWinsockToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.resetWinsockToolStripMenuItem.Text = "Reset Winsock";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(363, 6);
            // 
            // netstatToolStripMenuItem
            // 
            this.netstatToolStripMenuItem.Name = "netstatToolStripMenuItem";
            this.netstatToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.netstatToolStripMenuItem.Text = "Netstat";
            // 
            // pingToolStripMenuItem
            // 
            this.pingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ownIpip4ToolStripMenuItem,
            this.loopbackIp4ToolStripMenuItem,
            this.gatewayIp4ToolStripMenuItem,
            this.otherIp4ToolStripMenuItem});
            this.pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            this.pingToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.pingToolStripMenuItem.Text = "Ping";
            // 
            // ownIpip4ToolStripMenuItem
            // 
            this.ownIpip4ToolStripMenuItem.Name = "ownIpip4ToolStripMenuItem";
            this.ownIpip4ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ownIpip4ToolStripMenuItem.Text = "Own IP (IP4)";
            // 
            // loopbackIp4ToolStripMenuItem
            // 
            this.loopbackIp4ToolStripMenuItem.Name = "loopbackIp4ToolStripMenuItem";
            this.loopbackIp4ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.loopbackIp4ToolStripMenuItem.Text = "Loopback (IP4)";
            // 
            // gatewayIp4ToolStripMenuItem
            // 
            this.gatewayIp4ToolStripMenuItem.Name = "gatewayIp4ToolStripMenuItem";
            this.gatewayIp4ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.gatewayIp4ToolStripMenuItem.Text = "Gateway (IP4)";
            // 
            // otherIp4ToolStripMenuItem
            // 
            this.otherIp4ToolStripMenuItem.Name = "otherIp4ToolStripMenuItem";
            this.otherIp4ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.otherIp4ToolStripMenuItem.Text = "Other (IP4)";
            // 
            // openNetworkConnectionsToolStripMenuItem
            // 
            this.openNetworkConnectionsToolStripMenuItem.Name = "openNetworkConnectionsToolStripMenuItem";
            this.openNetworkConnectionsToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.openNetworkConnectionsToolStripMenuItem.Text = "Open Network Connections";
            // 
            // storedCredentialsToolStripMenuItem
            // 
            this.storedCredentialsToolStripMenuItem.Name = "storedCredentialsToolStripMenuItem";
            this.storedCredentialsToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.storedCredentialsToolStripMenuItem.Text = "Stored Credentials";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemFoldersToolStripMenuItem,
            this.toolStripSeparator12,
            this.controlPanelObjectsToolStripMenuItem,
            this.desktopGodmodeFolderToolStripMenuItem,
            this.diskManagementToolsToolStripMenuItem,
            this.mSconfigToolStripMenuItem,
            this.systemRestoreToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.toolStripSeparator11,
            this.computerManagementToolStripMenuItem,
            this.componantServicesToolStripMenuItem,
            this.dataSourcesOdbcToolStripMenuItem,
            this.deviceManagerToolStripMenuItem,
            this.directXDiagnosticsToolStripMenuItem,
            this.driverVerifierToolStripMenuItem,
            this.eventViewerToolStripMenuItem,
            this.groupPolicyEditorToolStripMenuItem,
            this.localSecurityPolicyToolStripMenuItem,
            this.performanceMonitorToolStripMenuItem,
            this.printManagementToolStripMenuItem,
            this.registryEditorToolStripMenuItem,
            this.servicesToolStripMenuItem,
            this.sharedFoldersToolStripMenuItem,
            this.taskSchedulerToolStripMenuItem,
            this.windowsMemoryDiagnosticToolStripMenuItem,
            this.wMiTesterToolStripMenuItem,
            this.windowsUpdatesToolStripMenuItem,
            this.windowsVersionToolStripMenuItem,
            this.windowsSecurityCenterToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // systemFoldersToolStripMenuItem
            // 
            this.systemFoldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desktopToolStripMenuItem,
            this.userProfilesToolStripMenuItem,
            this.programFilesToolStripMenuItem,
            this.programFilesx86ToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.systemFoldersToolStripMenuItem.Name = "systemFoldersToolStripMenuItem";
            this.systemFoldersToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.systemFoldersToolStripMenuItem.Text = "System Folders";
            // 
            // desktopToolStripMenuItem
            // 
            this.desktopToolStripMenuItem.Name = "desktopToolStripMenuItem";
            this.desktopToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.desktopToolStripMenuItem.Text = "Desktop";
            // 
            // userProfilesToolStripMenuItem
            // 
            this.userProfilesToolStripMenuItem.Name = "userProfilesToolStripMenuItem";
            this.userProfilesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.userProfilesToolStripMenuItem.Text = "User Profiles";
            // 
            // programFilesToolStripMenuItem
            // 
            this.programFilesToolStripMenuItem.Name = "programFilesToolStripMenuItem";
            this.programFilesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.programFilesToolStripMenuItem.Text = "Program Files";
            // 
            // programFilesx86ToolStripMenuItem
            // 
            this.programFilesx86ToolStripMenuItem.Name = "programFilesx86ToolStripMenuItem";
            this.programFilesx86ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.programFilesx86ToolStripMenuItem.Text = "Program Files (x86)";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(227, 6);
            // 
            // controlPanelObjectsToolStripMenuItem
            // 
            this.controlPanelObjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.toolStripSeparator13,
            this.accessibilityToolStripMenuItem,
            this.addNewHardwareToolStripMenuItem,
            this.addRemoveProgramsToolStripMenuItem,
            this.dateTimeToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.findFastToolStripMenuItem,
            this.fontsToolStripMenuItem,
            this.internetPropertiesToolStripMenuItem,
            this.joystickToolStripMenuItem,
            this.keyboardToolStripMenuItem,
            this.exchangeToolStripMenuItem,
            this.microsoftMailPostOfficeToolStripMenuItem,
            this.modemToolStripMenuItem,
            this.mouseToolStripMenuItem,
            this.multimediaToolStripMenuItem,
            this.networkToolStripMenuItem1,
            this.passwordToolStripMenuItem,
            this.pCCardToolStripMenuItem,
            this.powerManagementToolStripMenuItem,
            this.printersToolStripMenuItem,
            this.regionalSettingsToolStripMenuItem,
            this.scannersAndCamerasToolStripMenuItem,
            this.soundToolStripMenuItem,
            this.systemToolStripMenuItem1});
            this.controlPanelObjectsToolStripMenuItem.Name = "controlPanelObjectsToolStripMenuItem";
            this.controlPanelObjectsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.controlPanelObjectsToolStripMenuItem.Text = "Control Panel Objects";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(209, 6);
            // 
            // accessibilityToolStripMenuItem
            // 
            this.accessibilityToolStripMenuItem.Name = "accessibilityToolStripMenuItem";
            this.accessibilityToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.accessibilityToolStripMenuItem.Text = "Accessibility";
            // 
            // addNewHardwareToolStripMenuItem
            // 
            this.addNewHardwareToolStripMenuItem.Name = "addNewHardwareToolStripMenuItem";
            this.addNewHardwareToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.addNewHardwareToolStripMenuItem.Text = "Add New Hardware";
            // 
            // addRemoveProgramsToolStripMenuItem
            // 
            this.addRemoveProgramsToolStripMenuItem.Name = "addRemoveProgramsToolStripMenuItem";
            this.addRemoveProgramsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.addRemoveProgramsToolStripMenuItem.Text = "Add/Remove Programs";
            // 
            // dateTimeToolStripMenuItem
            // 
            this.dateTimeToolStripMenuItem.Name = "dateTimeToolStripMenuItem";
            this.dateTimeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.dateTimeToolStripMenuItem.Text = "Date/Time";
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // findFastToolStripMenuItem
            // 
            this.findFastToolStripMenuItem.Name = "findFastToolStripMenuItem";
            this.findFastToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.findFastToolStripMenuItem.Text = "FindFast";
            // 
            // fontsToolStripMenuItem
            // 
            this.fontsToolStripMenuItem.Name = "fontsToolStripMenuItem";
            this.fontsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.fontsToolStripMenuItem.Text = "Fonts";
            // 
            // internetPropertiesToolStripMenuItem
            // 
            this.internetPropertiesToolStripMenuItem.Name = "internetPropertiesToolStripMenuItem";
            this.internetPropertiesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.internetPropertiesToolStripMenuItem.Text = "Internet Properties";
            // 
            // joystickToolStripMenuItem
            // 
            this.joystickToolStripMenuItem.Name = "joystickToolStripMenuItem";
            this.joystickToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.joystickToolStripMenuItem.Text = "Joystick";
            // 
            // keyboardToolStripMenuItem
            // 
            this.keyboardToolStripMenuItem.Name = "keyboardToolStripMenuItem";
            this.keyboardToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.keyboardToolStripMenuItem.Text = "Keyboard";
            // 
            // exchangeToolStripMenuItem
            // 
            this.exchangeToolStripMenuItem.Name = "exchangeToolStripMenuItem";
            this.exchangeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.exchangeToolStripMenuItem.Text = "Exchange";
            // 
            // microsoftMailPostOfficeToolStripMenuItem
            // 
            this.microsoftMailPostOfficeToolStripMenuItem.Name = "microsoftMailPostOfficeToolStripMenuItem";
            this.microsoftMailPostOfficeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.microsoftMailPostOfficeToolStripMenuItem.Text = "Microsoft Mail Post Office";
            // 
            // modemToolStripMenuItem
            // 
            this.modemToolStripMenuItem.Name = "modemToolStripMenuItem";
            this.modemToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.modemToolStripMenuItem.Text = "Modem";
            // 
            // mouseToolStripMenuItem
            // 
            this.mouseToolStripMenuItem.Name = "mouseToolStripMenuItem";
            this.mouseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.mouseToolStripMenuItem.Text = "Mouse";
            // 
            // multimediaToolStripMenuItem
            // 
            this.multimediaToolStripMenuItem.Name = "multimediaToolStripMenuItem";
            this.multimediaToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.multimediaToolStripMenuItem.Text = "Multimedia";
            // 
            // networkToolStripMenuItem1
            // 
            this.networkToolStripMenuItem1.Name = "networkToolStripMenuItem1";
            this.networkToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.networkToolStripMenuItem1.Text = "Network";
            // 
            // passwordToolStripMenuItem
            // 
            this.passwordToolStripMenuItem.Name = "passwordToolStripMenuItem";
            this.passwordToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.passwordToolStripMenuItem.Text = "Password";
            // 
            // pCCardToolStripMenuItem
            // 
            this.pCCardToolStripMenuItem.Name = "pCCardToolStripMenuItem";
            this.pCCardToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.pCCardToolStripMenuItem.Text = "PC Card";
            // 
            // powerManagementToolStripMenuItem
            // 
            this.powerManagementToolStripMenuItem.Name = "powerManagementToolStripMenuItem";
            this.powerManagementToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.powerManagementToolStripMenuItem.Text = "Power Management";
            // 
            // printersToolStripMenuItem
            // 
            this.printersToolStripMenuItem.Name = "printersToolStripMenuItem";
            this.printersToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.printersToolStripMenuItem.Text = "Printers";
            // 
            // regionalSettingsToolStripMenuItem
            // 
            this.regionalSettingsToolStripMenuItem.Name = "regionalSettingsToolStripMenuItem";
            this.regionalSettingsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.regionalSettingsToolStripMenuItem.Text = "Regional Settings";
            // 
            // scannersAndCamerasToolStripMenuItem
            // 
            this.scannersAndCamerasToolStripMenuItem.Name = "scannersAndCamerasToolStripMenuItem";
            this.scannersAndCamerasToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.scannersAndCamerasToolStripMenuItem.Text = "Scanners and Cameras";
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.soundToolStripMenuItem.Text = "Sound";
            // 
            // systemToolStripMenuItem1
            // 
            this.systemToolStripMenuItem1.Name = "systemToolStripMenuItem1";
            this.systemToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.systemToolStripMenuItem1.Text = "System";
            // 
            // desktopGodmodeFolderToolStripMenuItem
            // 
            this.desktopGodmodeFolderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createLeaveAfterQuitToolStripMenuItem,
            this.createDestroyOnQuitToolStripMenuItem});
            this.desktopGodmodeFolderToolStripMenuItem.Name = "desktopGodmodeFolderToolStripMenuItem";
            this.desktopGodmodeFolderToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.desktopGodmodeFolderToolStripMenuItem.Text = "Desktop \"Godmode\" Folder";
            // 
            // createLeaveAfterQuitToolStripMenuItem
            // 
            this.createLeaveAfterQuitToolStripMenuItem.Name = "createLeaveAfterQuitToolStripMenuItem";
            this.createLeaveAfterQuitToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.createLeaveAfterQuitToolStripMenuItem.Text = "Create/Open (Leave on Quit)";
            // 
            // createDestroyOnQuitToolStripMenuItem
            // 
            this.createDestroyOnQuitToolStripMenuItem.Name = "createDestroyOnQuitToolStripMenuItem";
            this.createDestroyOnQuitToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.createDestroyOnQuitToolStripMenuItem.Text = "Create/Open (Destroy on Quit)";
            // 
            // diskManagementToolsToolStripMenuItem
            // 
            this.diskManagementToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkDiskToolStripMenuItem,
            this.defragSystemToolStripMenuItem,
            this.defragDefragglerToolStripMenuItem,
            this.diskManagmentToolStripMenuItem,
            this.driveCleanupUtilityToolStripMenuItem,
            this.partitionsToolStripMenuItem});
            this.diskManagementToolsToolStripMenuItem.Name = "diskManagementToolsToolStripMenuItem";
            this.diskManagementToolsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.diskManagementToolsToolStripMenuItem.Text = "Disk Management Tools";
            // 
            // checkDiskToolStripMenuItem
            // 
            this.checkDiskToolStripMenuItem.Name = "checkDiskToolStripMenuItem";
            this.checkDiskToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.checkDiskToolStripMenuItem.Text = "Check Disk";
            // 
            // defragSystemToolStripMenuItem
            // 
            this.defragSystemToolStripMenuItem.Name = "defragSystemToolStripMenuItem";
            this.defragSystemToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.defragSystemToolStripMenuItem.Text = "Defrag (System)";
            // 
            // defragDefragglerToolStripMenuItem
            // 
            this.defragDefragglerToolStripMenuItem.Name = "defragDefragglerToolStripMenuItem";
            this.defragDefragglerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.defragDefragglerToolStripMenuItem.Text = "Defrag (Defraggler)";
            // 
            // diskManagmentToolStripMenuItem
            // 
            this.diskManagmentToolStripMenuItem.Name = "diskManagmentToolStripMenuItem";
            this.diskManagmentToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.diskManagmentToolStripMenuItem.Text = "Disk Managment";
            // 
            // driveCleanupUtilityToolStripMenuItem
            // 
            this.driveCleanupUtilityToolStripMenuItem.Name = "driveCleanupUtilityToolStripMenuItem";
            this.driveCleanupUtilityToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.driveCleanupUtilityToolStripMenuItem.Text = "Drive Cleanup Utility";
            // 
            // partitionsToolStripMenuItem
            // 
            this.partitionsToolStripMenuItem.Name = "partitionsToolStripMenuItem";
            this.partitionsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.partitionsToolStripMenuItem.Text = "Partitions";
            // 
            // mSconfigToolStripMenuItem
            // 
            this.mSconfigToolStripMenuItem.Name = "mSconfigToolStripMenuItem";
            this.mSconfigToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.mSconfigToolStripMenuItem.Text = "MSCONFIG";
            // 
            // systemRestoreToolStripMenuItem
            // 
            this.systemRestoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createRestorePointToolStripMenuItem,
            this.openRestorePointToolStripMenuItem});
            this.systemRestoreToolStripMenuItem.Name = "systemRestoreToolStripMenuItem";
            this.systemRestoreToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.systemRestoreToolStripMenuItem.Text = "System Restore";
            // 
            // createRestorePointToolStripMenuItem
            // 
            this.createRestorePointToolStripMenuItem.Name = "createRestorePointToolStripMenuItem";
            this.createRestorePointToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.createRestorePointToolStripMenuItem.Text = "Create Restore Point";
            // 
            // openRestorePointToolStripMenuItem
            // 
            this.openRestorePointToolStripMenuItem.Name = "openRestorePointToolStripMenuItem";
            this.openRestorePointToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.openRestorePointToolStripMenuItem.Text = "Open Restore Point";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsToolStripMenuItem,
            this.advancedAccountsToolStripMenuItem,
            this.autoLogonOptionsToolStripMenuItem,
            this.uAcSettingsToolStripMenuItem});
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // advancedAccountsToolStripMenuItem
            // 
            this.advancedAccountsToolStripMenuItem.Name = "advancedAccountsToolStripMenuItem";
            this.advancedAccountsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.advancedAccountsToolStripMenuItem.Text = "Advanced Accounts";
            // 
            // autoLogonOptionsToolStripMenuItem
            // 
            this.autoLogonOptionsToolStripMenuItem.Name = "autoLogonOptionsToolStripMenuItem";
            this.autoLogonOptionsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.autoLogonOptionsToolStripMenuItem.Text = "Auto Logon Options";
            // 
            // uAcSettingsToolStripMenuItem
            // 
            this.uAcSettingsToolStripMenuItem.Name = "uAcSettingsToolStripMenuItem";
            this.uAcSettingsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.uAcSettingsToolStripMenuItem.Text = "UAC Settings";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(227, 6);
            // 
            // computerManagementToolStripMenuItem
            // 
            this.computerManagementToolStripMenuItem.Name = "computerManagementToolStripMenuItem";
            this.computerManagementToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.computerManagementToolStripMenuItem.Text = "Computer Management";
            // 
            // componantServicesToolStripMenuItem
            // 
            this.componantServicesToolStripMenuItem.Name = "componantServicesToolStripMenuItem";
            this.componantServicesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.componantServicesToolStripMenuItem.Text = "Componant Services";
            // 
            // dataSourcesOdbcToolStripMenuItem
            // 
            this.dataSourcesOdbcToolStripMenuItem.Name = "dataSourcesOdbcToolStripMenuItem";
            this.dataSourcesOdbcToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.dataSourcesOdbcToolStripMenuItem.Text = "Data Sources (ODBC)";
            // 
            // deviceManagerToolStripMenuItem
            // 
            this.deviceManagerToolStripMenuItem.Name = "deviceManagerToolStripMenuItem";
            this.deviceManagerToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.deviceManagerToolStripMenuItem.Text = "Device Manager";
            // 
            // directXDiagnosticsToolStripMenuItem
            // 
            this.directXDiagnosticsToolStripMenuItem.Name = "directXDiagnosticsToolStripMenuItem";
            this.directXDiagnosticsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.directXDiagnosticsToolStripMenuItem.Text = "Direct X Diagnostics";
            // 
            // driverVerifierToolStripMenuItem
            // 
            this.driverVerifierToolStripMenuItem.Name = "driverVerifierToolStripMenuItem";
            this.driverVerifierToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.driverVerifierToolStripMenuItem.Text = "Driver Verifier";
            // 
            // eventViewerToolStripMenuItem
            // 
            this.eventViewerToolStripMenuItem.Name = "eventViewerToolStripMenuItem";
            this.eventViewerToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.eventViewerToolStripMenuItem.Text = "Event Viewer";
            // 
            // groupPolicyEditorToolStripMenuItem
            // 
            this.groupPolicyEditorToolStripMenuItem.Name = "groupPolicyEditorToolStripMenuItem";
            this.groupPolicyEditorToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.groupPolicyEditorToolStripMenuItem.Text = "Group Policy Editor";
            // 
            // localSecurityPolicyToolStripMenuItem
            // 
            this.localSecurityPolicyToolStripMenuItem.Name = "localSecurityPolicyToolStripMenuItem";
            this.localSecurityPolicyToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.localSecurityPolicyToolStripMenuItem.Text = "Local Security Policy";
            // 
            // performanceMonitorToolStripMenuItem
            // 
            this.performanceMonitorToolStripMenuItem.Name = "performanceMonitorToolStripMenuItem";
            this.performanceMonitorToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.performanceMonitorToolStripMenuItem.Text = "Performance Monitor";
            // 
            // printManagementToolStripMenuItem
            // 
            this.printManagementToolStripMenuItem.Name = "printManagementToolStripMenuItem";
            this.printManagementToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.printManagementToolStripMenuItem.Text = "Print Management";
            // 
            // registryEditorToolStripMenuItem
            // 
            this.registryEditorToolStripMenuItem.Name = "registryEditorToolStripMenuItem";
            this.registryEditorToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.registryEditorToolStripMenuItem.Text = "Registry Editor";
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.servicesToolStripMenuItem.Text = "Services";
            // 
            // sharedFoldersToolStripMenuItem
            // 
            this.sharedFoldersToolStripMenuItem.Name = "sharedFoldersToolStripMenuItem";
            this.sharedFoldersToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.sharedFoldersToolStripMenuItem.Text = "Shared Folders";
            // 
            // taskSchedulerToolStripMenuItem
            // 
            this.taskSchedulerToolStripMenuItem.Name = "taskSchedulerToolStripMenuItem";
            this.taskSchedulerToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.taskSchedulerToolStripMenuItem.Text = "Task Scheduler";
            // 
            // windowsMemoryDiagnosticToolStripMenuItem
            // 
            this.windowsMemoryDiagnosticToolStripMenuItem.Name = "windowsMemoryDiagnosticToolStripMenuItem";
            this.windowsMemoryDiagnosticToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.windowsMemoryDiagnosticToolStripMenuItem.Text = "Windows Memory Diagnostic";
            // 
            // wMiTesterToolStripMenuItem
            // 
            this.wMiTesterToolStripMenuItem.Name = "wMiTesterToolStripMenuItem";
            this.wMiTesterToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.wMiTesterToolStripMenuItem.Text = "WMI Tester";
            // 
            // windowsUpdatesToolStripMenuItem
            // 
            this.windowsUpdatesToolStripMenuItem.Name = "windowsUpdatesToolStripMenuItem";
            this.windowsUpdatesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.windowsUpdatesToolStripMenuItem.Text = "Windows Updates";
            // 
            // windowsVersionToolStripMenuItem
            // 
            this.windowsVersionToolStripMenuItem.Name = "windowsVersionToolStripMenuItem";
            this.windowsVersionToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.windowsVersionToolStripMenuItem.Text = "Windows Version";
            // 
            // windowsSecurityCenterToolStripMenuItem
            // 
            this.windowsSecurityCenterToolStripMenuItem.Name = "windowsSecurityCenterToolStripMenuItem";
            this.windowsSecurityCenterToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.windowsSecurityCenterToolStripMenuItem.Text = "Windows Security Center";
            // 
            // techResourcesToolStripMenuItem
            // 
            this.techResourcesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rOneStopItToolStripMenuItem,
            this.rTronScriptToolStripMenuItem,
            this.ninitecomToolStripMenuItem,
            this.techWebsitesToolStripMenuItem,
            this.browserTestingToolStripMenuItem,
            this.virusScannerRemovalToolsToolStripMenuItem});
            this.techResourcesToolStripMenuItem.Name = "techResourcesToolStripMenuItem";
            this.techResourcesToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.techResourcesToolStripMenuItem.Text = "Tech Resources";
            // 
            // rOneStopItToolStripMenuItem
            // 
            this.rOneStopItToolStripMenuItem.Name = "rOneStopItToolStripMenuItem";
            this.rOneStopItToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.rOneStopItToolStripMenuItem.Text = "/r/OneStopIT";
            this.rOneStopItToolStripMenuItem.Click += new System.EventHandler(this.rTronScriptToolStripMenuItem_Click);
            // 
            // rTronScriptToolStripMenuItem
            // 
            this.rTronScriptToolStripMenuItem.Name = "rTronScriptToolStripMenuItem";
            this.rTronScriptToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.rTronScriptToolStripMenuItem.Text = "/r/TronScript";
            this.rTronScriptToolStripMenuItem.Click += new System.EventHandler(this.rTronScriptToolStripMenuItem_Click);
            // 
            // ninitecomToolStripMenuItem
            // 
            this.ninitecomToolStripMenuItem.Name = "ninitecomToolStripMenuItem";
            this.ninitecomToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.ninitecomToolStripMenuItem.Text = "Ninite.com";
            this.ninitecomToolStripMenuItem.Click += new System.EventHandler(this.ninitecomToolStripMenuItem_Click);
            // 
            // techWebsitesToolStripMenuItem
            // 
            this.techWebsitesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bleepingComputerToolStripMenuItem,
            this.geGeekToolStripMenuItem});
            this.techWebsitesToolStripMenuItem.Name = "techWebsitesToolStripMenuItem";
            this.techWebsitesToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.techWebsitesToolStripMenuItem.Text = "Tech Websites";
            // 
            // bleepingComputerToolStripMenuItem
            // 
            this.bleepingComputerToolStripMenuItem.Name = "bleepingComputerToolStripMenuItem";
            this.bleepingComputerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.bleepingComputerToolStripMenuItem.Text = "Bleeping Computer";
            this.bleepingComputerToolStripMenuItem.Click += new System.EventHandler(this.bleepingComputerToolStripMenuItem_Click);
            // 
            // geGeekToolStripMenuItem
            // 
            this.geGeekToolStripMenuItem.Name = "geGeekToolStripMenuItem";
            this.geGeekToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.geGeekToolStripMenuItem.Text = "GeGeek";
            this.geGeekToolStripMenuItem.Click += new System.EventHandler(this.geGeekToolStripMenuItem_Click);
            // 
            // browserTestingToolStripMenuItem
            // 
            this.browserTestingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dSlReportscomSpeedTestToolStripMenuItem,
            this.speedtestnetToolStripMenuItem,
            this.toolStripSeparator14,
            this.browserscopeToolStripMenuItem,
            this.qualysBrowsercheckToolStripMenuItem,
            this.firefoxOfficialPluginTestToolStripMenuItem,
            this.toolStripSeparator15,
            this.silverlightbubblemarkcomToolStripMenuItem,
            this.flashbubblemarkcomToolStripMenuItem,
            this.javajavatesterorgToolStripMenuItem,
            this.shockwaveadobecomToolStripMenuItem,
            this.sSLssllabscomToolStripMenuItem,
            this.shieldsUpToolStripMenuItem});
            this.browserTestingToolStripMenuItem.Name = "browserTestingToolStripMenuItem";
            this.browserTestingToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.browserTestingToolStripMenuItem.Text = "Browser Testing";
            // 
            // dSlReportscomSpeedTestToolStripMenuItem
            // 
            this.dSlReportscomSpeedTestToolStripMenuItem.Name = "dSlReportscomSpeedTestToolStripMenuItem";
            this.dSlReportscomSpeedTestToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.dSlReportscomSpeedTestToolStripMenuItem.Text = "DSLReports.com Speed Test";
            this.dSlReportscomSpeedTestToolStripMenuItem.Click += new System.EventHandler(this.dSlReportscomSpeedTestToolStripMenuItem_Click);
            // 
            // speedtestnetToolStripMenuItem
            // 
            this.speedtestnetToolStripMenuItem.Name = "speedtestnetToolStripMenuItem";
            this.speedtestnetToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.speedtestnetToolStripMenuItem.Text = "Speedtest.net";
            this.speedtestnetToolStripMenuItem.Click += new System.EventHandler(this.speedtestnetToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(225, 6);
            // 
            // browserscopeToolStripMenuItem
            // 
            this.browserscopeToolStripMenuItem.Name = "browserscopeToolStripMenuItem";
            this.browserscopeToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.browserscopeToolStripMenuItem.Text = "Browserscope";
            this.browserscopeToolStripMenuItem.Click += new System.EventHandler(this.browserscopeToolStripMenuItem_Click);
            // 
            // qualysBrowsercheckToolStripMenuItem
            // 
            this.qualysBrowsercheckToolStripMenuItem.Name = "qualysBrowsercheckToolStripMenuItem";
            this.qualysBrowsercheckToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.qualysBrowsercheckToolStripMenuItem.Text = "Qualys Browsercheck";
            this.qualysBrowsercheckToolStripMenuItem.Click += new System.EventHandler(this.qualysBrowsercheckToolStripMenuItem_Click);
            // 
            // firefoxOfficialPluginTestToolStripMenuItem
            // 
            this.firefoxOfficialPluginTestToolStripMenuItem.Name = "firefoxOfficialPluginTestToolStripMenuItem";
            this.firefoxOfficialPluginTestToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.firefoxOfficialPluginTestToolStripMenuItem.Text = "Firefox Official Plugin Test";
            this.firefoxOfficialPluginTestToolStripMenuItem.Click += new System.EventHandler(this.firefoxOfficialPluginTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(225, 6);
            // 
            // silverlightbubblemarkcomToolStripMenuItem
            // 
            this.silverlightbubblemarkcomToolStripMenuItem.Name = "silverlightbubblemarkcomToolStripMenuItem";
            this.silverlightbubblemarkcomToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.silverlightbubblemarkcomToolStripMenuItem.Text = "Silverlight (bubblemark.com)";
            this.silverlightbubblemarkcomToolStripMenuItem.Click += new System.EventHandler(this.silverlightbubblemarkcomToolStripMenuItem_Click);
            // 
            // flashbubblemarkcomToolStripMenuItem
            // 
            this.flashbubblemarkcomToolStripMenuItem.Name = "flashbubblemarkcomToolStripMenuItem";
            this.flashbubblemarkcomToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.flashbubblemarkcomToolStripMenuItem.Text = "Flash (bubblemark.com)";
            this.flashbubblemarkcomToolStripMenuItem.Click += new System.EventHandler(this.flashbubblemarkcomToolStripMenuItem_Click);
            // 
            // javajavatesterorgToolStripMenuItem
            // 
            this.javajavatesterorgToolStripMenuItem.Name = "javajavatesterorgToolStripMenuItem";
            this.javajavatesterorgToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.javajavatesterorgToolStripMenuItem.Text = "Java (javatester.org)";
            this.javajavatesterorgToolStripMenuItem.Click += new System.EventHandler(this.javajavatesterorgToolStripMenuItem_Click);
            // 
            // shockwaveadobecomToolStripMenuItem
            // 
            this.shockwaveadobecomToolStripMenuItem.Name = "shockwaveadobecomToolStripMenuItem";
            this.shockwaveadobecomToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.shockwaveadobecomToolStripMenuItem.Text = "Shockwave (adobe.com)";
            this.shockwaveadobecomToolStripMenuItem.Click += new System.EventHandler(this.shockwaveadobecomToolStripMenuItem_Click);
            // 
            // sSLssllabscomToolStripMenuItem
            // 
            this.sSLssllabscomToolStripMenuItem.Name = "sSLssllabscomToolStripMenuItem";
            this.sSLssllabscomToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.sSLssllabscomToolStripMenuItem.Text = "SSL (ssllabs.com)";
            this.sSLssllabscomToolStripMenuItem.Click += new System.EventHandler(this.sSLssllabscomToolStripMenuItem_Click);
            // 
            // shieldsUpToolStripMenuItem
            // 
            this.shieldsUpToolStripMenuItem.Name = "shieldsUpToolStripMenuItem";
            this.shieldsUpToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.shieldsUpToolStripMenuItem.Text = "ShieldsUP!";
            this.shieldsUpToolStripMenuItem.Click += new System.EventHandler(this.shieldsUpToolStripMenuItem_Click);
            // 
            // virusScannerRemovalToolsToolStripMenuItem
            // 
            this.virusScannerRemovalToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eSetMasterListToolStripMenuItem,
            this.toolStripSeparator16,
            this.avastToolStripMenuItem,
            this.aVgToolStripMenuItem,
            this.aviraToolStripMenuItem,
            this.comodoToolStripMenuItem,
            this.fSecureToolStripMenuItem,
            this.kasperskyToolStripMenuItem,
            this.mcAffeToolStripMenuItem,
            this.nOd32ToolStripMenuItem,
            this.nortonToolStripMenuItem,
            this.nortonSecurityScanToolStripMenuItem,
            this.pandaToolStripMenuItem,
            this.sophosToolStripMenuItem,
            this.windowsSecurityEssentialsToolStripMenuItem});
            this.virusScannerRemovalToolsToolStripMenuItem.Name = "virusScannerRemovalToolsToolStripMenuItem";
            this.virusScannerRemovalToolsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.virusScannerRemovalToolsToolStripMenuItem.Text = "Virus Scanner Removal Tools";
            // 
            // eSetMasterListToolStripMenuItem
            // 
            this.eSetMasterListToolStripMenuItem.Name = "eSetMasterListToolStripMenuItem";
            this.eSetMasterListToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.eSetMasterListToolStripMenuItem.Text = "ESET Master List";
            this.eSetMasterListToolStripMenuItem.Click += new System.EventHandler(this.eSetMasterListToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(218, 6);
            // 
            // avastToolStripMenuItem
            // 
            this.avastToolStripMenuItem.Name = "avastToolStripMenuItem";
            this.avastToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.avastToolStripMenuItem.Text = "Avast";
            this.avastToolStripMenuItem.Click += new System.EventHandler(this.avastToolStripMenuItem_Click);
            // 
            // aVgToolStripMenuItem
            // 
            this.aVgToolStripMenuItem.Name = "aVgToolStripMenuItem";
            this.aVgToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.aVgToolStripMenuItem.Text = "AVG";
            this.aVgToolStripMenuItem.Click += new System.EventHandler(this.aVgToolStripMenuItem_Click);
            // 
            // aviraToolStripMenuItem
            // 
            this.aviraToolStripMenuItem.Name = "aviraToolStripMenuItem";
            this.aviraToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.aviraToolStripMenuItem.Text = "Avira";
            this.aviraToolStripMenuItem.Click += new System.EventHandler(this.aviraToolStripMenuItem_Click);
            // 
            // comodoToolStripMenuItem
            // 
            this.comodoToolStripMenuItem.Name = "comodoToolStripMenuItem";
            this.comodoToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.comodoToolStripMenuItem.Text = "Comodo";
            this.comodoToolStripMenuItem.Click += new System.EventHandler(this.comodoToolStripMenuItem_Click);
            // 
            // fSecureToolStripMenuItem
            // 
            this.fSecureToolStripMenuItem.Name = "fSecureToolStripMenuItem";
            this.fSecureToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.fSecureToolStripMenuItem.Text = "F-Secure";
            this.fSecureToolStripMenuItem.Click += new System.EventHandler(this.fSecureToolStripMenuItem_Click);
            // 
            // kasperskyToolStripMenuItem
            // 
            this.kasperskyToolStripMenuItem.Name = "kasperskyToolStripMenuItem";
            this.kasperskyToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.kasperskyToolStripMenuItem.Text = "Kaspersky";
            this.kasperskyToolStripMenuItem.Click += new System.EventHandler(this.kasperskyToolStripMenuItem_Click);
            // 
            // mcAffeToolStripMenuItem
            // 
            this.mcAffeToolStripMenuItem.Name = "mcAffeToolStripMenuItem";
            this.mcAffeToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.mcAffeToolStripMenuItem.Text = "McAffe";
            this.mcAffeToolStripMenuItem.Click += new System.EventHandler(this.mcAffeToolStripMenuItem_Click);
            // 
            // nOd32ToolStripMenuItem
            // 
            this.nOd32ToolStripMenuItem.Name = "nOd32ToolStripMenuItem";
            this.nOd32ToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.nOd32ToolStripMenuItem.Text = "NOD32";
            this.nOd32ToolStripMenuItem.Click += new System.EventHandler(this.nOd32ToolStripMenuItem_Click);
            // 
            // nortonToolStripMenuItem
            // 
            this.nortonToolStripMenuItem.Name = "nortonToolStripMenuItem";
            this.nortonToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.nortonToolStripMenuItem.Text = "Norton";
            this.nortonToolStripMenuItem.Click += new System.EventHandler(this.nortonToolStripMenuItem_Click);
            // 
            // nortonSecurityScanToolStripMenuItem
            // 
            this.nortonSecurityScanToolStripMenuItem.Name = "nortonSecurityScanToolStripMenuItem";
            this.nortonSecurityScanToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.nortonSecurityScanToolStripMenuItem.Text = "Norton Security Scan";
            this.nortonSecurityScanToolStripMenuItem.Click += new System.EventHandler(this.nortonSecurityScanToolStripMenuItem_Click);
            // 
            // pandaToolStripMenuItem
            // 
            this.pandaToolStripMenuItem.Name = "pandaToolStripMenuItem";
            this.pandaToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.pandaToolStripMenuItem.Text = "Panda";
            this.pandaToolStripMenuItem.Click += new System.EventHandler(this.pandaToolStripMenuItem_Click);
            // 
            // sophosToolStripMenuItem
            // 
            this.sophosToolStripMenuItem.Name = "sophosToolStripMenuItem";
            this.sophosToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.sophosToolStripMenuItem.Text = "Sophos";
            this.sophosToolStripMenuItem.Click += new System.EventHandler(this.sophosToolStripMenuItem_Click);
            // 
            // windowsSecurityEssentialsToolStripMenuItem
            // 
            this.windowsSecurityEssentialsToolStripMenuItem.Name = "windowsSecurityEssentialsToolStripMenuItem";
            this.windowsSecurityEssentialsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.windowsSecurityEssentialsToolStripMenuItem.Text = "Windows Security Essentials";
            this.windowsSecurityEssentialsToolStripMenuItem.Click += new System.EventHandler(this.windowsSecurityEssentialsToolStripMenuItem_Click);
            // 
            // powerToolStripMenuItem
            // 
            this.powerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forceShutdownToolStripMenuItem,
            this.forceLogoffToolStripMenuItem,
            this.forceRestartToolStripMenuItem,
            this.toolStripSeparator17,
            this.enableF8ToolStripMenuItem,
            this.disableF8ToolStripMenuItem,
            this.toolStripSeparator18,
            this.setSafemodeSwitchOnToolStripMenuItem,
            this.setSafemodeSwitchOnNetworkingToolStripMenuItem,
            this.setSafemodeSwitchOnMinimalToolStripMenuItem,
            this.setSafemodeSwitchOnAltShellToolStripMenuItem,
            this.setSafemodeSwtichOffNormalBootToolStripMenuItem,
            this.enumerateCurrentModeToolStripMenuItem,
            this.toolStripSeparator19,
            this.hibernateToolStripMenuItem,
            this.hybridShutdownFastStartUpToolStripMenuItem,
            this.shutdownWithOptionsToolStripMenuItem});
            this.powerToolStripMenuItem.Name = "powerToolStripMenuItem";
            this.powerToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.powerToolStripMenuItem.Text = "Power";
            // 
            // forceShutdownToolStripMenuItem
            // 
            this.forceShutdownToolStripMenuItem.Name = "forceShutdownToolStripMenuItem";
            this.forceShutdownToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.forceShutdownToolStripMenuItem.Text = "Force Shutdown";
            this.forceShutdownToolStripMenuItem.Click += new System.EventHandler(this.forceShutdownToolStripMenuItem_Click);
            // 
            // forceLogoffToolStripMenuItem
            // 
            this.forceLogoffToolStripMenuItem.Name = "forceLogoffToolStripMenuItem";
            this.forceLogoffToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.forceLogoffToolStripMenuItem.Text = "Force Logoff";
            this.forceLogoffToolStripMenuItem.Click += new System.EventHandler(this.forceLogoffToolStripMenuItem_Click);
            // 
            // forceRestartToolStripMenuItem
            // 
            this.forceRestartToolStripMenuItem.Name = "forceRestartToolStripMenuItem";
            this.forceRestartToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.forceRestartToolStripMenuItem.Text = "Force Restart";
            this.forceRestartToolStripMenuItem.Click += new System.EventHandler(this.forceRestartToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(291, 6);
            // 
            // enableF8ToolStripMenuItem
            // 
            this.enableF8ToolStripMenuItem.Name = "enableF8ToolStripMenuItem";
            this.enableF8ToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.enableF8ToolStripMenuItem.Text = "Enable F8 Menu";
            this.enableF8ToolStripMenuItem.Click += new System.EventHandler(this.enableF8ToolStripMenuItem_Click);
            // 
            // disableF8ToolStripMenuItem
            // 
            this.disableF8ToolStripMenuItem.Name = "disableF8ToolStripMenuItem";
            this.disableF8ToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.disableF8ToolStripMenuItem.Text = "Disable F8 Menu";
            this.disableF8ToolStripMenuItem.Click += new System.EventHandler(this.disableF8ToolStripMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(291, 6);
            // 
            // setSafemodeSwitchOnToolStripMenuItem
            // 
            this.setSafemodeSwitchOnToolStripMenuItem.Name = "setSafemodeSwitchOnToolStripMenuItem";
            this.setSafemodeSwitchOnToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.setSafemodeSwitchOnToolStripMenuItem.Text = "Set Safemode Switch = On";
            this.setSafemodeSwitchOnToolStripMenuItem.Click += new System.EventHandler(this.setSafemodeSwitchOnToolStripMenuItem_Click);
            // 
            // setSafemodeSwitchOnNetworkingToolStripMenuItem
            // 
            this.setSafemodeSwitchOnNetworkingToolStripMenuItem.Name = "setSafemodeSwitchOnNetworkingToolStripMenuItem";
            this.setSafemodeSwitchOnNetworkingToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.setSafemodeSwitchOnNetworkingToolStripMenuItem.Text = "Set Safemode Switch = On + Networking";
            this.setSafemodeSwitchOnNetworkingToolStripMenuItem.Click += new System.EventHandler(this.setSafemodeSwitchOnNetworkingToolStripMenuItem_Click);
            // 
            // setSafemodeSwitchOnMinimalToolStripMenuItem
            // 
            this.setSafemodeSwitchOnMinimalToolStripMenuItem.Name = "setSafemodeSwitchOnMinimalToolStripMenuItem";
            this.setSafemodeSwitchOnMinimalToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.setSafemodeSwitchOnMinimalToolStripMenuItem.Text = "Set Safemode Switch = On (Minimal)";
            this.setSafemodeSwitchOnMinimalToolStripMenuItem.Click += new System.EventHandler(this.setSafemodeSwitchOnMinimalToolStripMenuItem_Click);
            // 
            // setSafemodeSwitchOnAltShellToolStripMenuItem
            // 
            this.setSafemodeSwitchOnAltShellToolStripMenuItem.Name = "setSafemodeSwitchOnAltShellToolStripMenuItem";
            this.setSafemodeSwitchOnAltShellToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.setSafemodeSwitchOnAltShellToolStripMenuItem.Text = "Set Safemode Switch = On (Alt. Shell)";
            this.setSafemodeSwitchOnAltShellToolStripMenuItem.Click += new System.EventHandler(this.setSafemodeSwitchOnAltShellToolStripMenuItem_Click);
            // 
            // setSafemodeSwtichOffNormalBootToolStripMenuItem
            // 
            this.setSafemodeSwtichOffNormalBootToolStripMenuItem.Name = "setSafemodeSwtichOffNormalBootToolStripMenuItem";
            this.setSafemodeSwtichOffNormalBootToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.setSafemodeSwtichOffNormalBootToolStripMenuItem.Text = "Set Safemode Swtich = Off (Normal Boot)";
            this.setSafemodeSwtichOffNormalBootToolStripMenuItem.Click += new System.EventHandler(this.setSafemodeSwtichOffNormalBootToolStripMenuItem_Click);
            // 
            // enumerateCurrentModeToolStripMenuItem
            // 
            this.enumerateCurrentModeToolStripMenuItem.Name = "enumerateCurrentModeToolStripMenuItem";
            this.enumerateCurrentModeToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.enumerateCurrentModeToolStripMenuItem.Text = "Enumerate Current Mode";
            this.enumerateCurrentModeToolStripMenuItem.Click += new System.EventHandler(this.enumerateCurrentModeToolStripMenuItem_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(291, 6);
            // 
            // hibernateToolStripMenuItem
            // 
            this.hibernateToolStripMenuItem.Name = "hibernateToolStripMenuItem";
            this.hibernateToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.hibernateToolStripMenuItem.Text = "Hibernate";
            this.hibernateToolStripMenuItem.Click += new System.EventHandler(this.hibernateToolStripMenuItem_Click);
            // 
            // hybridShutdownFastStartUpToolStripMenuItem
            // 
            this.hybridShutdownFastStartUpToolStripMenuItem.Name = "hybridShutdownFastStartUpToolStripMenuItem";
            this.hybridShutdownFastStartUpToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.hybridShutdownFastStartUpToolStripMenuItem.Text = "Hybrid (Shutdown + Fast Start Up)";
            this.hybridShutdownFastStartUpToolStripMenuItem.Click += new System.EventHandler(this.hybridShutdownFastStartUpToolStripMenuItem_Click);
            // 
            // shutdownWithOptionsToolStripMenuItem
            // 
            this.shutdownWithOptionsToolStripMenuItem.Name = "shutdownWithOptionsToolStripMenuItem";
            this.shutdownWithOptionsToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.shutdownWithOptionsToolStripMenuItem.Text = "Shutdown With Options";
            this.shutdownWithOptionsToolStripMenuItem.Click += new System.EventHandler(this.shutdownWithOptionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.disclaimerToolStripMenuItem,
            this.toolStripSeparator20,
            this.viewOnlineDocumentationToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.toolStripSeparator21,
            this.staticToolStripMenuItem,
            this.cBrnisfunToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.aboutToolStripMenuItem.Text = "About OneStop";
            // 
            // disclaimerToolStripMenuItem
            // 
            this.disclaimerToolStripMenuItem.Name = "disclaimerToolStripMenuItem";
            this.disclaimerToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.disclaimerToolStripMenuItem.Text = "Disclaimer";
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(220, 6);
            // 
            // viewOnlineDocumentationToolStripMenuItem
            // 
            this.viewOnlineDocumentationToolStripMenuItem.Name = "viewOnlineDocumentationToolStripMenuItem";
            this.viewOnlineDocumentationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.viewOnlineDocumentationToolStripMenuItem.Text = "View Online Documentation";
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitCoinToolStripMenuItem,
            this.paypalToolStripMenuItem});
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.donateToolStripMenuItem.Text = "Donate";
            // 
            // bitCoinToolStripMenuItem
            // 
            this.bitCoinToolStripMenuItem.Name = "bitCoinToolStripMenuItem";
            this.bitCoinToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.bitCoinToolStripMenuItem.Text = "BitCoin";
            // 
            // paypalToolStripMenuItem
            // 
            this.paypalToolStripMenuItem.Name = "paypalToolStripMenuItem";
            this.paypalToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.paypalToolStripMenuItem.Text = "Paypal";
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(220, 6);
            // 
            // staticToolStripMenuItem
            // 
            this.staticToolStripMenuItem.Name = "staticToolStripMenuItem";
            this.staticToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.staticToolStripMenuItem.Text = "StaticExtasy";
            // 
            // cBrnisfunToolStripMenuItem
            // 
            this.cBrnisfunToolStripMenuItem.Name = "cBrnisfunToolStripMenuItem";
            this.cBrnisfunToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.cBrnisfunToolStripMenuItem.Text = "CBRNISFUN";
            // 
            // tcPrimaryTabs
            // 
            this.tcPrimaryTabs.Controls.Add(this.tpWelcome);
            this.tcPrimaryTabs.Controls.Add(this.tpOneStopMain);
            this.tcPrimaryTabs.Controls.Add(this.tpTronCli);
            this.tcPrimaryTabs.Controls.Add(this.tpTime);
            this.tcPrimaryTabs.Controls.Add(this.tpSystemInfo);
            this.tcPrimaryTabs.Controls.Add(this.tpUninstaller);
            this.tcPrimaryTabs.Controls.Add(this.tpWmiExplorer);
            this.tcPrimaryTabs.Controls.Add(this.tpConfigurator);
            this.tcPrimaryTabs.Controls.Add(this.tpSetup);
            this.tcPrimaryTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcPrimaryTabs.HotTrack = true;
            this.tcPrimaryTabs.ItemSize = new System.Drawing.Size(70, 18);
            this.tcPrimaryTabs.Location = new System.Drawing.Point(0, 89);
            this.tcPrimaryTabs.Margin = new System.Windows.Forms.Padding(0);
            this.tcPrimaryTabs.Multiline = true;
            this.tcPrimaryTabs.Name = "tcPrimaryTabs";
            this.tcPrimaryTabs.Padding = new System.Drawing.Point(0, 0);
            this.tcPrimaryTabs.SelectedIndex = 0;
            this.tcPrimaryTabs.Size = new System.Drawing.Size(754, 417);
            this.tcPrimaryTabs.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tcPrimaryTabs.TabIndex = 3;
            // 
            // tpWelcome
            // 
            this.tpWelcome.Controls.Add(this.button6);
            this.tpWelcome.Controls.Add(this.tbConsole);
            this.tpWelcome.Location = new System.Drawing.Point(4, 22);
            this.tpWelcome.Name = "tpWelcome";
            this.tpWelcome.Padding = new System.Windows.Forms.Padding(3);
            this.tpWelcome.Size = new System.Drawing.Size(746, 391);
            this.tpWelcome.TabIndex = 10;
            this.tpWelcome.Text = "Welcome";
            this.tpWelcome.UseVisualStyleBackColor = true;
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
            // tbConsole
            // 
            this.tbConsole.Location = new System.Drawing.Point(353, 6);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConsole.Size = new System.Drawing.Size(385, 379);
            this.tbConsole.TabIndex = 0;
            // 
            // tpOneStopMain
            // 
            this.tpOneStopMain.Controls.Add(this.lblOsmExecuteOrder);
            this.tpOneStopMain.Controls.Add(this.lblOsmProgramSelect);
            this.tpOneStopMain.Controls.Add(this.lblOsmCategories);
            this.tpOneStopMain.Controls.Add(this.listBox3);
            this.tpOneStopMain.Controls.Add(this.lbProgramSelect);
            this.tpOneStopMain.Controls.Add(this.lbOsmCategories);
            this.tpOneStopMain.Location = new System.Drawing.Point(4, 22);
            this.tpOneStopMain.Name = "tpOneStopMain";
            this.tpOneStopMain.Size = new System.Drawing.Size(746, 391);
            this.tpOneStopMain.TabIndex = 11;
            this.tpOneStopMain.Text = "OneStop Auto";
            this.tpOneStopMain.UseVisualStyleBackColor = true;
            // 
            // lblOsmExecuteOrder
            // 
            this.lblOsmExecuteOrder.AutoSize = true;
            this.lblOsmExecuteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOsmExecuteOrder.Location = new System.Drawing.Point(482, 11);
            this.lblOsmExecuteOrder.Name = "lblOsmExecuteOrder";
            this.lblOsmExecuteOrder.Size = new System.Drawing.Size(98, 15);
            this.lblOsmExecuteOrder.TabIndex = 7;
            this.lblOsmExecuteOrder.Text = "Execute Order";
            // 
            // lblOsmProgramSelect
            // 
            this.lblOsmProgramSelect.AutoSize = true;
            this.lblOsmProgramSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOsmProgramSelect.Location = new System.Drawing.Point(216, 10);
            this.lblOsmProgramSelect.Name = "lblOsmProgramSelect";
            this.lblOsmProgramSelect.Size = new System.Drawing.Size(106, 15);
            this.lblOsmProgramSelect.TabIndex = 6;
            this.lblOsmProgramSelect.Text = "Program Select";
            // 
            // lblOsmCategories
            // 
            this.lblOsmCategories.AutoSize = true;
            this.lblOsmCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOsmCategories.Location = new System.Drawing.Point(5, 10);
            this.lblOsmCategories.Name = "lblOsmCategories";
            this.lblOsmCategories.Size = new System.Drawing.Size(135, 15);
            this.lblOsmCategories.TabIndex = 5;
            this.lblOsmCategories.Text = "Program Categories";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(485, 29);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(243, 316);
            this.listBox3.TabIndex = 2;
            // 
            // lbProgramSelect
            // 
            this.lbProgramSelect.FormattingEnabled = true;
            this.lbProgramSelect.Location = new System.Drawing.Point(219, 29);
            this.lbProgramSelect.Name = "lbProgramSelect";
            this.lbProgramSelect.Size = new System.Drawing.Size(243, 342);
            this.lbProgramSelect.TabIndex = 1;
            // 
            // lbOsmCategories
            // 
            this.lbOsmCategories.FormattingEnabled = true;
            this.lbOsmCategories.Items.AddRange(new object[] {
            "Create Restore Point",
            "Reporting/Audit",
            "Hardware Testing",
            "Backup Tasks",
            "Prep For Malware Removal",
            "File Cleanup",
            "Extended File Cleanup",
            "De-Bloat",
            "Disinfect",
            "Repair",
            "Patch / Updates / Install",
            "Optimize",
            "Windows Repair",
            "System Tweaks",
            "Apply Branding",
            "Networking",
            "Manual Tools",
            "Other"});
            this.lbOsmCategories.Location = new System.Drawing.Point(8, 29);
            this.lbOsmCategories.Name = "lbOsmCategories";
            this.lbOsmCategories.Size = new System.Drawing.Size(189, 342);
            this.lbOsmCategories.TabIndex = 0;
            this.lbOsmCategories.SelectedIndexChanged += new System.EventHandler(this.lbOsmCategories_SelectedIndexChanged);
            // 
            // tpTronCli
            // 
            this.tpTronCli.Controls.Add(this.tpTronSettings);
            this.tpTronCli.Location = new System.Drawing.Point(4, 22);
            this.tpTronCli.Name = "tpTronCli";
            this.tpTronCli.Padding = new System.Windows.Forms.Padding(3);
            this.tpTronCli.Size = new System.Drawing.Size(746, 391);
            this.tpTronCli.TabIndex = 1;
            this.tpTronCli.Text = "TronScript";
            this.tpTronCli.UseVisualStyleBackColor = true;
            // 
            // tpTronSettings
            // 
            this.tpTronSettings.Controls.Add(this.tpLaunchTron);
            this.tpTronSettings.Controls.Add(this.tpEmailSettings);
            this.tpTronSettings.Controls.Add(this.tpSetFlags);
            this.tpTronSettings.Location = new System.Drawing.Point(0, 0);
            this.tpTronSettings.Name = "tpTronSettings";
            this.tpTronSettings.SelectedIndex = 0;
            this.tpTronSettings.Size = new System.Drawing.Size(746, 395);
            this.tpTronSettings.TabIndex = 0;
            // 
            // tpLaunchTron
            // 
            this.tpLaunchTron.Controls.Add(this.button5);
            this.tpLaunchTron.Controls.Add(this.linkLabel2);
            this.tpLaunchTron.Controls.Add(this.btnTronSaveFlags);
            this.tpLaunchTron.Controls.Add(this.cbTronE);
            this.tpLaunchTron.Controls.Add(this.cbTronDev);
            this.tpLaunchTron.Controls.Add(this.btnLocateTron);
            this.tpLaunchTron.Controls.Add(this.btnDeploytofolder);
            this.tpLaunchTron.Controls.Add(this.btnConfigDump);
            this.tpLaunchTron.Controls.Add(this.btnDryRun);
            this.tpLaunchTron.Controls.Add(this.btnRunTron);
            this.tpLaunchTron.Controls.Add(this.cbTronStr);
            this.tpLaunchTron.Controls.Add(this.cbTronSs);
            this.tpLaunchTron.Controls.Add(this.cbTronSrr);
            this.tpLaunchTron.Controls.Add(this.cbTronSfr);
            this.tpLaunchTron.Controls.Add(this.cbTronSm);
            this.tpLaunchTron.Controls.Add(this.cbTronSdc);
            this.tpLaunchTron.Controls.Add(this.cbTronSk);
            this.tpLaunchTron.Controls.Add(this.cbTronSpr);
            this.tpLaunchTron.Controls.Add(this.cbTronSw);
            this.tpLaunchTron.Controls.Add(this.cbTronSe);
            this.tpLaunchTron.Controls.Add(this.cbTronP);
            this.tpLaunchTron.Controls.Add(this.btnClear);
            this.tpLaunchTron.Controls.Add(this.cbTronEr);
            this.tpLaunchTron.Controls.Add(this.cbTronSb);
            this.tpLaunchTron.Controls.Add(this.cbTronM);
            this.tpLaunchTron.Controls.Add(this.cbTronX);
            this.tpLaunchTron.Controls.Add(this.cbTronO);
            this.tpLaunchTron.Controls.Add(this.cbTronV);
            this.tpLaunchTron.Controls.Add(this.cbTronR);
            this.tpLaunchTron.Controls.Add(this.cbTronSp);
            this.tpLaunchTron.Controls.Add(this.cbTronSa);
            this.tpLaunchTron.Controls.Add(this.cbTronSd);
            this.tpLaunchTron.Location = new System.Drawing.Point(4, 22);
            this.tpLaunchTron.Name = "tpLaunchTron";
            this.tpLaunchTron.Padding = new System.Windows.Forms.Padding(3);
            this.tpLaunchTron.Size = new System.Drawing.Size(738, 369);
            this.tpLaunchTron.TabIndex = 0;
            this.tpLaunchTron.Text = "Launch Tron";
            this.tpLaunchTron.UseVisualStyleBackColor = true;
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
            this.button5.Click += new System.EventHandler(this.bleepingComputerToolStripMenuItem_Click);
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
            this.linkLabel2.Click += new System.EventHandler(this.rTronScriptToolStripMenuItem_Click);
            // 
            // btnTronSaveFlags
            // 
            this.btnTronSaveFlags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTronSaveFlags.Enabled = false;
            this.btnTronSaveFlags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTronSaveFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTronSaveFlags.Location = new System.Drawing.Point(578, 196);
            this.btnTronSaveFlags.Name = "btnTronSaveFlags";
            this.btnTronSaveFlags.Size = new System.Drawing.Size(140, 23);
            this.btnTronSaveFlags.TabIndex = 84;
            this.btnTronSaveFlags.Text = "Save All Flags";
            this.btnTronSaveFlags.UseVisualStyleBackColor = false;
            this.btnTronSaveFlags.Click += new System.EventHandler(this.btnTronSaveFlags_Click);
            // 
            // cbTronE
            // 
            this.cbTronE.AutoSize = true;
            this.cbTronE.Location = new System.Drawing.Point(279, 41);
            this.cbTronE.Name = "cbTronE";
            this.cbTronE.Size = new System.Drawing.Size(145, 17);
            this.cbTronE.TabIndex = 83;
            this.cbTronE.Text = "(-e) Always Accept EULA";
            this.cbTronE.UseVisualStyleBackColor = true;
            this.cbTronE.CheckedChanged += new System.EventHandler(this.cbtronE_CheckedChanged);
            // 
            // cbTronDev
            // 
            this.cbTronDev.AutoSize = true;
            this.cbTronDev.Location = new System.Drawing.Point(279, 177);
            this.cbTronDev.Name = "cbTronDev";
            this.cbTronDev.Size = new System.Drawing.Size(163, 17);
            this.cbTronDev.TabIndex = 82;
            this.cbTronDev.Text = "(-dev) Override OS Detection";
            this.cbTronDev.UseVisualStyleBackColor = true;
            this.cbTronDev.CheckedChanged += new System.EventHandler(this.cbtrondev_CheckedChanged);
            // 
            // btnLocateTron
            // 
            this.btnLocateTron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLocateTron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocateTron.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocateTron.ForeColor = System.Drawing.Color.Black;
            this.btnLocateTron.Location = new System.Drawing.Point(579, 18);
            this.btnLocateTron.Name = "btnLocateTron";
            this.btnLocateTron.Size = new System.Drawing.Size(140, 47);
            this.btnLocateTron.TabIndex = 81;
            this.btnLocateTron.Text = ">> Locate Tron <<";
            this.btnLocateTron.UseVisualStyleBackColor = false;
            this.btnLocateTron.Click += new System.EventHandler(this.btnLocateTron_Click);
            // 
            // btnDeploytofolder
            // 
            this.btnDeploytofolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDeploytofolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeploytofolder.Location = new System.Drawing.Point(579, 71);
            this.btnDeploytofolder.Name = "btnDeploytofolder";
            this.btnDeploytofolder.Size = new System.Drawing.Size(139, 23);
            this.btnDeploytofolder.TabIndex = 80;
            this.btnDeploytofolder.Text = "Deploy Tron to Folder";
            this.btnDeploytofolder.UseVisualStyleBackColor = false;
            this.btnDeploytofolder.Click += new System.EventHandler(this.browserscopeToolStripMenuItem_Click);
            // 
            // btnConfigDump
            // 
            this.btnConfigDump.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnConfigDump.Enabled = false;
            this.btnConfigDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigDump.Location = new System.Drawing.Point(580, 271);
            this.btnConfigDump.Name = "btnConfigDump";
            this.btnConfigDump.Size = new System.Drawing.Size(140, 23);
            this.btnConfigDump.TabIndex = 79;
            this.btnConfigDump.Text = "Config Dump";
            this.btnConfigDump.UseVisualStyleBackColor = false;
            this.btnConfigDump.Click += new System.EventHandler(this.btnConfigDump_Click);
            // 
            // btnDryRun
            // 
            this.btnDryRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDryRun.Enabled = false;
            this.btnDryRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDryRun.Location = new System.Drawing.Point(580, 300);
            this.btnDryRun.Name = "btnDryRun";
            this.btnDryRun.Size = new System.Drawing.Size(140, 23);
            this.btnDryRun.TabIndex = 78;
            this.btnDryRun.Text = "Dry Run";
            this.btnDryRun.UseVisualStyleBackColor = false;
            this.btnDryRun.Click += new System.EventHandler(this.btnDryRun_Click);
            // 
            // btnRunTron
            // 
            this.btnRunTron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRunTron.Enabled = false;
            this.btnRunTron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunTron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunTron.Location = new System.Drawing.Point(580, 329);
            this.btnRunTron.Name = "btnRunTron";
            this.btnRunTron.Size = new System.Drawing.Size(140, 23);
            this.btnRunTron.TabIndex = 77;
            this.btnRunTron.Text = "Run Tron";
            this.btnRunTron.UseVisualStyleBackColor = false;
            this.btnRunTron.Click += new System.EventHandler(this.btnRunTronClick);
            // 
            // cbTronStr
            // 
            this.cbTronStr.AutoSize = true;
            this.cbTronStr.Location = new System.Drawing.Point(16, 321);
            this.cbTronStr.Name = "cbTronStr";
            this.cbTronStr.Size = new System.Drawing.Size(164, 17);
            this.cbTronStr.TabIndex = 76;
            this.cbTronStr.Text = "(-str) Skip Telemetry Removal";
            this.cbTronStr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cbTronStr.UseVisualStyleBackColor = true;
            this.cbTronStr.CheckedChanged += new System.EventHandler(this.cbtronSTR_CheckedChanged);
            // 
            // cbTronSs
            // 
            this.cbTronSs.AutoSize = true;
            this.cbTronSs.Location = new System.Drawing.Point(16, 298);
            this.cbTronSs.Name = "cbTronSs";
            this.cbTronSs.Size = new System.Drawing.Size(155, 17);
            this.cbTronSs.TabIndex = 75;
            this.cbTronSs.Text = "(-ss) Skip Sophos Anti-Virus";
            this.cbTronSs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cbTronSs.UseVisualStyleBackColor = true;
            this.cbTronSs.CheckedChanged += new System.EventHandler(this.cbtronSS_CheckedChanged);
            // 
            // cbTronSrr
            // 
            this.cbTronSrr.AutoSize = true;
            this.cbTronSrr.Location = new System.Drawing.Point(16, 275);
            this.cbTronSrr.Name = "cbTronSrr";
            this.cbTronSrr.Size = new System.Drawing.Size(200, 17);
            this.cbTronSrr.TabIndex = 74;
            this.cbTronSrr.Text = "(-srr) Skip Registry Permissions Reset";
            this.cbTronSrr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cbTronSrr.UseVisualStyleBackColor = true;
            this.cbTronSrr.CheckedChanged += new System.EventHandler(this.cbtronSRR_CheckedChanged);
            // 
            // cbTronSfr
            // 
            this.cbTronSfr.AutoSize = true;
            this.cbTronSfr.Location = new System.Drawing.Point(16, 205);
            this.cbTronSfr.Name = "cbTronSfr";
            this.cbTronSfr.Size = new System.Drawing.Size(201, 17);
            this.cbTronSfr.TabIndex = 73;
            this.cbTronSfr.Text = "(-sfr) Skip filesystem permissions reset";
            this.cbTronSfr.UseVisualStyleBackColor = true;
            this.cbTronSfr.CheckedChanged += new System.EventHandler(this.cbtronSFR_CheckedChanged);
            // 
            // cbTronSm
            // 
            this.cbTronSm.AutoSize = true;
            this.cbTronSm.Location = new System.Drawing.Point(16, 252);
            this.cbTronSm.Name = "cbTronSm";
            this.cbTronSm.Size = new System.Drawing.Size(137, 17);
            this.cbTronSm.TabIndex = 72;
            this.cbTronSm.Text = "(-sm) Skip MBAM Install";
            this.cbTronSm.UseVisualStyleBackColor = true;
            this.cbTronSm.CheckedChanged += new System.EventHandler(this.cbtronSM_CheckedChanged);
            // 
            // cbTronSdc
            // 
            this.cbTronSdc.AutoSize = true;
            this.cbTronSdc.Location = new System.Drawing.Point(16, 181);
            this.cbTronSdc.Name = "cbTronSdc";
            this.cbTronSdc.Size = new System.Drawing.Size(260, 17);
            this.cbTronSdc.TabIndex = 70;
            this.cbTronSdc.Text = "(-sdc) Skip DISM component (SxS Store) Cleanup";
            this.cbTronSdc.UseVisualStyleBackColor = true;
            this.cbTronSdc.CheckedChanged += new System.EventHandler(this.cbtronSDC_CheckedChanged);
            // 
            // cbTronSk
            // 
            this.cbTronSk.AutoSize = true;
            this.cbTronSk.Location = new System.Drawing.Point(16, 228);
            this.cbTronSk.Name = "cbTronSk";
            this.cbTronSk.Size = new System.Drawing.Size(147, 17);
            this.cbTronSk.TabIndex = 71;
            this.cbTronSk.Text = "(-sk) Skip Kaspersky VRT";
            this.cbTronSk.UseVisualStyleBackColor = true;
            this.cbTronSk.CheckedChanged += new System.EventHandler(this.cbtronSK_CheckedChanged);
            // 
            // cbTronSpr
            // 
            this.cbTronSpr.AutoSize = true;
            this.cbTronSpr.Location = new System.Drawing.Point(16, 158);
            this.cbTronSpr.Name = "cbTronSpr";
            this.cbTronSpr.Size = new System.Drawing.Size(151, 17);
            this.cbTronSpr.TabIndex = 69;
            this.cbTronSpr.Text = "(-spr) Skip Page File Reset";
            this.cbTronSpr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cbTronSpr.UseVisualStyleBackColor = true;
            this.cbTronSpr.CheckedChanged += new System.EventHandler(this.cbtronSPR_CheckedChanged);
            // 
            // cbTronSw
            // 
            this.cbTronSw.AutoSize = true;
            this.cbTronSw.Location = new System.Drawing.Point(16, 135);
            this.cbTronSw.Name = "cbTronSw";
            this.cbTronSw.Size = new System.Drawing.Size(162, 17);
            this.cbTronSw.TabIndex = 68;
            this.cbTronSw.Text = "(-sw) Skip Windows Updates";
            this.cbTronSw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cbTronSw.UseVisualStyleBackColor = true;
            this.cbTronSw.CheckedChanged += new System.EventHandler(this.cbtronSW_CheckedChanged);
            // 
            // cbTronSe
            // 
            this.cbTronSe.AutoSize = true;
            this.cbTronSe.Location = new System.Drawing.Point(16, 112);
            this.cbTronSe.Name = "cbTronSe";
            this.cbTronSe.Size = new System.Drawing.Size(163, 17);
            this.cbTronSe.TabIndex = 67;
            this.cbTronSe.Text = "(-se) Skip Event Log Clearing";
            this.cbTronSe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cbTronSe.UseVisualStyleBackColor = true;
            this.cbTronSe.CheckedChanged += new System.EventHandler(this.cbtronSE_CheckedChanged);
            // 
            // cbTronP
            // 
            this.cbTronP.AutoSize = true;
            this.cbTronP.Location = new System.Drawing.Point(279, 64);
            this.cbTronP.Name = "cbTronP";
            this.cbTronP.Size = new System.Drawing.Size(158, 17);
            this.cbTronP.TabIndex = 64;
            this.cbTronP.Text = "(-p) Preserve Power Options";
            this.cbTronP.UseVisualStyleBackColor = true;
            this.cbTronP.CheckedChanged += new System.EventHandler(this.cbtronP_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(579, 154);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 23);
            this.btnClear.TabIndex = 63;
            this.btnClear.Text = "Clear All Flags";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbTronEr
            // 
            this.cbTronEr.AutoSize = true;
            this.cbTronEr.Location = new System.Drawing.Point(279, 18);
            this.cbTronEr.Name = "cbTronEr";
            this.cbTronEr.Size = new System.Drawing.Size(107, 17);
            this.cbTronEr.TabIndex = 53;
            this.cbTronEr.Text = "(-er) Email Report";
            this.cbTronEr.UseVisualStyleBackColor = true;
            this.cbTronEr.CheckedChanged += new System.EventHandler(this.cbtronER_CheckedChanged);
            // 
            // cbTronSb
            // 
            this.cbTronSb.AutoSize = true;
            this.cbTronSb.Location = new System.Drawing.Point(16, 42);
            this.cbTronSb.Name = "cbTronSb";
            this.cbTronSb.Size = new System.Drawing.Size(110, 17);
            this.cbTronSb.TabIndex = 62;
            this.cbTronSb.Text = "(-sb) Skip Debloat";
            this.cbTronSb.UseVisualStyleBackColor = true;
            this.cbTronSb.CheckedChanged += new System.EventHandler(this.cbtronSB_CheckedChanged);
            // 
            // cbTronM
            // 
            this.cbTronM.AutoSize = true;
            this.cbTronM.Location = new System.Drawing.Point(279, 200);
            this.cbTronM.Name = "cbTronM";
            this.cbTronM.Size = new System.Drawing.Size(182, 17);
            this.cbTronM.TabIndex = 54;
            this.cbTronM.Text = "(-m) Preserve Default Metro Apps";
            this.cbTronM.UseVisualStyleBackColor = true;
            this.cbTronM.CheckedChanged += new System.EventHandler(this.cbtronM_CheckedChanged);
            // 
            // cbTronX
            // 
            this.cbTronX.AutoSize = true;
            this.cbTronX.Location = new System.Drawing.Point(279, 154);
            this.cbTronX.Name = "cbTronX";
            this.cbTronX.Size = new System.Drawing.Size(104, 17);
            this.cbTronX.TabIndex = 61;
            this.cbTronX.Text = "(-x) Self Destruct";
            this.cbTronX.UseVisualStyleBackColor = true;
            this.cbTronX.CheckedChanged += new System.EventHandler(this.cbtronX_CheckedChanged);
            // 
            // cbTronO
            // 
            this.cbTronO.AutoSize = true;
            this.cbTronO.Location = new System.Drawing.Point(279, 86);
            this.cbTronO.Name = "cbTronO";
            this.cbTronO.Size = new System.Drawing.Size(139, 17);
            this.cbTronO.TabIndex = 55;
            this.cbTronO.Text = "(-o) Power Off After Run";
            this.cbTronO.UseVisualStyleBackColor = true;
            this.cbTronO.CheckedChanged += new System.EventHandler(this.cbtronO_CheckedChanged);
            // 
            // cbTronV
            // 
            this.cbTronV.AutoSize = true;
            this.cbTronV.Location = new System.Drawing.Point(279, 131);
            this.cbTronV.Name = "cbTronV";
            this.cbTronV.Size = new System.Drawing.Size(83, 17);
            this.cbTronV.TabIndex = 60;
            this.cbTronV.Text = "(-v) Verbose";
            this.cbTronV.UseVisualStyleBackColor = true;
            this.cbTronV.CheckedChanged += new System.EventHandler(this.cbtronV_CheckedChanged);
            // 
            // cbTronR
            // 
            this.cbTronR.AutoSize = true;
            this.cbTronR.Location = new System.Drawing.Point(279, 108);
            this.cbTronR.Name = "cbTronR";
            this.cbTronR.Size = new System.Drawing.Size(141, 17);
            this.cbTronR.TabIndex = 56;
            this.cbTronR.Text = "(-r) Reboot Automatically";
            this.cbTronR.UseVisualStyleBackColor = true;
            this.cbTronR.CheckedChanged += new System.EventHandler(this.cbtronR_CheckedChanged);
            // 
            // cbTronSp
            // 
            this.cbTronSp.AutoSize = true;
            this.cbTronSp.Location = new System.Drawing.Point(16, 89);
            this.cbTronSp.Name = "cbTronSp";
            this.cbTronSp.Size = new System.Drawing.Size(112, 17);
            this.cbTronSp.TabIndex = 59;
            this.cbTronSp.Text = "(-sp) Skip Patches";
            this.cbTronSp.UseVisualStyleBackColor = true;
            this.cbTronSp.CheckedChanged += new System.EventHandler(this.cbtronSP_CheckedChanged);
            // 
            // cbTronSa
            // 
            this.cbTronSa.AutoSize = true;
            this.cbTronSa.Location = new System.Drawing.Point(16, 18);
            this.cbTronSa.Name = "cbTronSa";
            this.cbTronSa.Size = new System.Drawing.Size(117, 17);
            this.cbTronSa.TabIndex = 57;
            this.cbTronSa.Text = "(-sa) Skip Anti-Virus";
            this.cbTronSa.UseVisualStyleBackColor = true;
            this.cbTronSa.CheckedChanged += new System.EventHandler(this.cbtronSA_CheckedChanged);
            // 
            // cbTronSd
            // 
            this.cbTronSd.AutoSize = true;
            this.cbTronSd.Location = new System.Drawing.Point(16, 65);
            this.cbTronSd.Name = "cbTronSd";
            this.cbTronSd.Size = new System.Drawing.Size(105, 17);
            this.cbTronSd.TabIndex = 58;
            this.cbTronSd.Text = "(-sd) Skip Defrag";
            this.cbTronSd.UseVisualStyleBackColor = true;
            this.cbTronSd.CheckedChanged += new System.EventHandler(this.cbtronSD_CheckedChanged);
            // 
            // tpEmailSettings
            // 
            this.tpEmailSettings.Location = new System.Drawing.Point(4, 22);
            this.tpEmailSettings.Name = "tpEmailSettings";
            this.tpEmailSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmailSettings.Size = new System.Drawing.Size(738, 369);
            this.tpEmailSettings.TabIndex = 1;
            this.tpEmailSettings.Text = "Email Settings";
            this.tpEmailSettings.UseVisualStyleBackColor = true;
            // 
            // tpSetFlags
            // 
            this.tpSetFlags.Location = new System.Drawing.Point(4, 22);
            this.tpSetFlags.Name = "tpSetFlags";
            this.tpSetFlags.Padding = new System.Windows.Forms.Padding(3);
            this.tpSetFlags.Size = new System.Drawing.Size(738, 369);
            this.tpSetFlags.TabIndex = 2;
            this.tpSetFlags.Text = "Set Permanant Flags";
            this.tpSetFlags.UseVisualStyleBackColor = true;
            // 
            // tpTime
            // 
            this.tpTime.Location = new System.Drawing.Point(4, 22);
            this.tpTime.Name = "tpTime";
            this.tpTime.Padding = new System.Windows.Forms.Padding(3);
            this.tpTime.Size = new System.Drawing.Size(746, 391);
            this.tpTime.TabIndex = 8;
            this.tpTime.Text = "Technician Time/Reporting";
            this.tpTime.UseVisualStyleBackColor = true;
            // 
            // tpSystemInfo
            // 
            this.tpSystemInfo.Controls.Add(this.tabControl1);
            this.tpSystemInfo.Location = new System.Drawing.Point(4, 22);
            this.tpSystemInfo.Name = "tpSystemInfo";
            this.tpSystemInfo.Size = new System.Drawing.Size(746, 391);
            this.tpSystemInfo.TabIndex = 3;
            this.tpSystemInfo.Text = "System Info";
            this.tpSystemInfo.UseVisualStyleBackColor = true;
            this.tpSystemInfo.Enter += new System.EventHandler(this.tpSystemInfo_Enter);
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
            // tpSystemReport
            // 
            this.tpSystemReport.Controls.Add(this.label21);
            this.tpSystemReport.Controls.Add(this.checkedListBox2);
            this.tpSystemReport.Controls.Add(this.label20);
            this.tpSystemReport.Controls.Add(this.checkedListBox1);
            this.tpSystemReport.Location = new System.Drawing.Point(4, 22);
            this.tpSystemReport.Name = "tpSystemReport";
            this.tpSystemReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpSystemReport.Size = new System.Drawing.Size(737, 360);
            this.tpSystemReport.TabIndex = 1;
            this.tpSystemReport.Text = "System Report";
            this.tpSystemReport.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(319, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 13);
            this.label21.TabIndex = 3;
            this.label21.Text = "Software";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.ColumnWidth = 150;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "**Software Inventory",
            "Codecs",
            "Date/Time Info",
            "Display",
            "Microsoft Office Data",
            "Operating System",
            "Product Keys",
            "Registry",
            "Restore Points",
            "Scheduled Tasks",
            "Service Packs",
            "Services",
            "Shadow Copy",
            "Startup",
            "Updates"});
            this.checkedListBox2.Location = new System.Drawing.Point(319, 50);
            this.checkedListBox2.MultiColumn = true;
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(141, 304);
            this.checkedListBox2.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 31);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "Hardware";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.ColumnWidth = 150;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "**Hardware Inventory",
            "1394 (Firewire) Controllers",
            "BIOS",
            "Busses",
            "Chassis and Tags",
            "Devices with Failures",
            "Fans/Cooling",
            "Hard Drives",
            "IDE Controller",
            "Infrared Device",
            "Keyboard",
            "Memory",
            "Monitor",
            "Motherboard",
            "Mouse and Pointers",
            "Network Adapters",
            "Other Disks",
            "PCMCIA",
            "Power Supply",
            "Printer",
            "Processor",
            "Serial Port",
            "Sound",
            "Tape Drive",
            "USB",
            "Video Devices"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 50);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(304, 304);
            this.checkedListBox1.TabIndex = 0;
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
            // tpUninstaller
            // 
            this.tpUninstaller.Location = new System.Drawing.Point(4, 22);
            this.tpUninstaller.Name = "tpUninstaller";
            this.tpUninstaller.Size = new System.Drawing.Size(746, 391);
            this.tpUninstaller.TabIndex = 5;
            this.tpUninstaller.Text = "Uninstaller";
            this.tpUninstaller.UseVisualStyleBackColor = true;
            // 
            // tpWmiExplorer
            // 
            this.tpWmiExplorer.Location = new System.Drawing.Point(4, 22);
            this.tpWmiExplorer.Name = "tpWmiExplorer";
            this.tpWmiExplorer.Size = new System.Drawing.Size(746, 391);
            this.tpWmiExplorer.TabIndex = 6;
            this.tpWmiExplorer.Text = "WMI Explorer";
            this.tpWmiExplorer.UseVisualStyleBackColor = true;
            // 
            // tpConfigurator
            // 
            this.tpConfigurator.Controls.Add(this.tcConfigurator);
            this.tpConfigurator.Location = new System.Drawing.Point(4, 22);
            this.tpConfigurator.Name = "tpConfigurator";
            this.tpConfigurator.Size = new System.Drawing.Size(746, 391);
            this.tpConfigurator.TabIndex = 7;
            this.tpConfigurator.Text = "Tweaks";
            this.tpConfigurator.UseVisualStyleBackColor = true;
            // 
            // tcConfigurator
            // 
            this.tcConfigurator.Controls.Add(this.tpInternetSettings);
            this.tcConfigurator.Controls.Add(this.tpSecurity);
            this.tcConfigurator.Controls.Add(this.tpPerformance);
            this.tcConfigurator.Controls.Add(this.tpWelcomeScreen);
            this.tcConfigurator.Controls.Add(this.tpWindows10);
            this.tcConfigurator.Controls.Add(this.tpExplorer);
            this.tcConfigurator.Controls.Add(this.tpAppearance);
            this.tcConfigurator.Controls.Add(this.tpOem);
            this.tcConfigurator.Location = new System.Drawing.Point(0, 0);
            this.tcConfigurator.Multiline = true;
            this.tcConfigurator.Name = "tcConfigurator";
            this.tcConfigurator.SelectedIndex = 0;
            this.tcConfigurator.Size = new System.Drawing.Size(750, 395);
            this.tcConfigurator.TabIndex = 0;
            // 
            // tpInternetSettings
            // 
            this.tpInternetSettings.Location = new System.Drawing.Point(4, 22);
            this.tpInternetSettings.Name = "tpInternetSettings";
            this.tpInternetSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternetSettings.Size = new System.Drawing.Size(742, 369);
            this.tpInternetSettings.TabIndex = 0;
            this.tpInternetSettings.Text = "Network & Internet";
            this.tpInternetSettings.UseVisualStyleBackColor = true;
            // 
            // tpSecurity
            // 
            this.tpSecurity.Location = new System.Drawing.Point(4, 22);
            this.tpSecurity.Name = "tpSecurity";
            this.tpSecurity.Padding = new System.Windows.Forms.Padding(3);
            this.tpSecurity.Size = new System.Drawing.Size(742, 369);
            this.tpSecurity.TabIndex = 1;
            this.tpSecurity.Text = "Security & UAC";
            this.tpSecurity.UseVisualStyleBackColor = true;
            // 
            // tpPerformance
            // 
            this.tpPerformance.Location = new System.Drawing.Point(4, 22);
            this.tpPerformance.Name = "tpPerformance";
            this.tpPerformance.Size = new System.Drawing.Size(742, 369);
            this.tpPerformance.TabIndex = 2;
            this.tpPerformance.Text = "Performance";
            this.tpPerformance.UseVisualStyleBackColor = true;
            // 
            // tpWelcomeScreen
            // 
            this.tpWelcomeScreen.Location = new System.Drawing.Point(4, 22);
            this.tpWelcomeScreen.Name = "tpWelcomeScreen";
            this.tpWelcomeScreen.Size = new System.Drawing.Size(742, 369);
            this.tpWelcomeScreen.TabIndex = 3;
            this.tpWelcomeScreen.Text = "Welcome Screen";
            this.tpWelcomeScreen.UseVisualStyleBackColor = true;
            // 
            // tpWindows10
            // 
            this.tpWindows10.Location = new System.Drawing.Point(4, 22);
            this.tpWindows10.Name = "tpWindows10";
            this.tpWindows10.Size = new System.Drawing.Size(742, 369);
            this.tpWindows10.TabIndex = 4;
            this.tpWindows10.Text = "Windows 10 Upgrade";
            this.tpWindows10.UseVisualStyleBackColor = true;
            // 
            // tpExplorer
            // 
            this.tpExplorer.Location = new System.Drawing.Point(4, 22);
            this.tpExplorer.Name = "tpExplorer";
            this.tpExplorer.Size = new System.Drawing.Size(742, 369);
            this.tpExplorer.TabIndex = 5;
            this.tpExplorer.Text = "Explorer";
            this.tpExplorer.UseVisualStyleBackColor = true;
            // 
            // tpAppearance
            // 
            this.tpAppearance.Location = new System.Drawing.Point(4, 22);
            this.tpAppearance.Name = "tpAppearance";
            this.tpAppearance.Size = new System.Drawing.Size(742, 369);
            this.tpAppearance.TabIndex = 6;
            this.tpAppearance.Text = "Appearance";
            this.tpAppearance.UseVisualStyleBackColor = true;
            // 
            // tpOem
            // 
            this.tpOem.Location = new System.Drawing.Point(4, 22);
            this.tpOem.Name = "tpOem";
            this.tpOem.Size = new System.Drawing.Size(742, 369);
            this.tpOem.TabIndex = 7;
            this.tpOem.Text = "OEM";
            this.tpOem.UseVisualStyleBackColor = true;
            // 
            // tpSetup
            // 
            this.tpSetup.Controls.Add(this.tabControl2);
            this.tpSetup.Location = new System.Drawing.Point(4, 22);
            this.tpSetup.Name = "tpSetup";
            this.tpSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tpSetup.Size = new System.Drawing.Size(746, 391);
            this.tpSetup.TabIndex = 9;
            this.tpSetup.Text = "Setup";
            this.tpSetup.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tpQuickLaunch);
            this.tabControl2.Controls.Add(this.tpShopSettings);
            this.tabControl2.Controls.Add(this.tpServers);
            this.tabControl2.Controls.Add(this.tpIntegration);
            this.tabControl2.Controls.Add(this.tpLogging);
            this.tabControl2.Location = new System.Drawing.Point(0, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(746, 392);
            this.tabControl2.TabIndex = 0;
            // 
            // tpQuickLaunch
            // 
            this.tpQuickLaunch.Controls.Add(this.button10);
            this.tpQuickLaunch.Controls.Add(this.button11);
            this.tpQuickLaunch.Controls.Add(this.button9);
            this.tpQuickLaunch.Controls.Add(this.button8);
            this.tpQuickLaunch.Controls.Add(this.btnQlDeleteSelected);
            this.tpQuickLaunch.Controls.Add(this.lbCurrentPrograms);
            this.tpQuickLaunch.Controls.Add(this.lblQlMenuItemName);
            this.tpQuickLaunch.Controls.Add(this.btnQlCreateNew);
            this.tpQuickLaunch.Controls.Add(this.txtQlAppName);
            this.tpQuickLaunch.Controls.Add(this.lblQlFolders);
            this.tpQuickLaunch.Location = new System.Drawing.Point(4, 22);
            this.tpQuickLaunch.Name = "tpQuickLaunch";
            this.tpQuickLaunch.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuickLaunch.Size = new System.Drawing.Size(738, 366);
            this.tpQuickLaunch.TabIndex = 0;
            this.tpQuickLaunch.Text = "Quick Launch";
            this.tpQuickLaunch.UseVisualStyleBackColor = true;
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
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(149, 111);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(119, 23);
            this.button9.TabIndex = 7;
            this.button9.Text = "Documents Folder";
            this.button9.UseVisualStyleBackColor = true;
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
            // btnQlDeleteSelected
            // 
            this.btnQlDeleteSelected.Location = new System.Drawing.Point(497, 319);
            this.btnQlDeleteSelected.Name = "btnQlDeleteSelected";
            this.btnQlDeleteSelected.Size = new System.Drawing.Size(224, 23);
            this.btnQlDeleteSelected.TabIndex = 5;
            this.btnQlDeleteSelected.Text = "Delete Selected";
            this.btnQlDeleteSelected.UseVisualStyleBackColor = true;
            this.btnQlDeleteSelected.Click += new System.EventHandler(this.btnQLDeleteSelected_Click);
            // 
            // lbCurrentPrograms
            // 
            this.lbCurrentPrograms.FormattingEnabled = true;
            this.lbCurrentPrograms.Location = new System.Drawing.Point(309, 46);
            this.lbCurrentPrograms.Name = "lbCurrentPrograms";
            this.lbCurrentPrograms.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbCurrentPrograms.Size = new System.Drawing.Size(412, 264);
            this.lbCurrentPrograms.TabIndex = 4;
            // 
            // lblQlMenuItemName
            // 
            this.lblQlMenuItemName.AutoSize = true;
            this.lblQlMenuItemName.Location = new System.Drawing.Point(21, 20);
            this.lblQlMenuItemName.Name = "lblQlMenuItemName";
            this.lblQlMenuItemName.Size = new System.Drawing.Size(91, 13);
            this.lblQlMenuItemName.TabIndex = 3;
            this.lblQlMenuItemName.Text = "Menu Item Name:";
            // 
            // btnQlCreateNew
            // 
            this.btnQlCreateNew.Location = new System.Drawing.Point(24, 66);
            this.btnQlCreateNew.Name = "btnQlCreateNew";
            this.btnQlCreateNew.Size = new System.Drawing.Size(244, 23);
            this.btnQlCreateNew.TabIndex = 2;
            this.btnQlCreateNew.Text = "Create New QL Item";
            this.btnQlCreateNew.UseVisualStyleBackColor = true;
            this.btnQlCreateNew.Click += new System.EventHandler(this.btnQLCreateNew_Click);
            // 
            // txtQlAppName
            // 
            this.txtQlAppName.Location = new System.Drawing.Point(24, 36);
            this.txtQlAppName.Name = "txtQlAppName";
            this.txtQlAppName.Size = new System.Drawing.Size(244, 20);
            this.txtQlAppName.TabIndex = 1;
            // 
            // lblQlFolders
            // 
            this.lblQlFolders.AutoSize = true;
            this.lblQlFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQlFolders.Location = new System.Drawing.Point(8, 8);
            this.lblQlFolders.MaximumSize = new System.Drawing.Size(650, 0);
            this.lblQlFolders.Name = "lblQlFolders";
            this.lblQlFolders.Size = new System.Drawing.Size(0, 13);
            this.lblQlFolders.TabIndex = 0;
            // 
            // tpShopSettings
            // 
            this.tpShopSettings.Controls.Add(this.pictureBox1);
            this.tpShopSettings.Controls.Add(this.btnShopSetSave);
            this.tpShopSettings.Controls.Add(this.lblShopSetState);
            this.tpShopSettings.Controls.Add(this.tbShopSetState);
            this.tpShopSettings.Controls.Add(this.lblShopSetCity);
            this.tpShopSettings.Controls.Add(this.tbShopSetCity);
            this.tpShopSettings.Controls.Add(this.lblShopSetEmail);
            this.tpShopSettings.Controls.Add(this.tbShopSetEmail);
            this.tpShopSettings.Controls.Add(this.lblShopSetPhone);
            this.tpShopSettings.Controls.Add(this.tbShopSetPhone);
            this.tpShopSettings.Controls.Add(this.tbShopSetAddr2);
            this.tpShopSettings.Controls.Add(this.lblShopSetAddr);
            this.tpShopSettings.Controls.Add(this.tbShopSetAddr1);
            this.tpShopSettings.Controls.Add(this.lblShopSetShopname);
            this.tpShopSettings.Controls.Add(this.tbShopSetName);
            this.tpShopSettings.Location = new System.Drawing.Point(4, 22);
            this.tpShopSettings.Name = "tpShopSettings";
            this.tpShopSettings.Size = new System.Drawing.Size(738, 366);
            this.tpShopSettings.TabIndex = 1;
            this.tpShopSettings.Text = "Shop Settings";
            this.tpShopSettings.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(362, 174);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 129);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // btnShopSetSave
            // 
            this.btnShopSetSave.Location = new System.Drawing.Point(505, 337);
            this.btnShopSetSave.Name = "btnShopSetSave";
            this.btnShopSetSave.Size = new System.Drawing.Size(224, 23);
            this.btnShopSetSave.TabIndex = 17;
            this.btnShopSetSave.Text = "Save Shop Info";
            this.btnShopSetSave.UseVisualStyleBackColor = true;
            this.btnShopSetSave.Click += new System.EventHandler(this.btnShopSetSave_Click);
            // 
            // lblShopSetState
            // 
            this.lblShopSetState.AutoSize = true;
            this.lblShopSetState.Location = new System.Drawing.Point(13, 222);
            this.lblShopSetState.Name = "lblShopSetState";
            this.lblShopSetState.Size = new System.Drawing.Size(89, 13);
            this.lblShopSetState.TabIndex = 16;
            this.lblShopSetState.Text = "State/Prov + Zip:";
            // 
            // tbShopSetState
            // 
            this.tbShopSetState.Location = new System.Drawing.Point(16, 238);
            this.tbShopSetState.Name = "tbShopSetState";
            this.tbShopSetState.Size = new System.Drawing.Size(224, 20);
            this.tbShopSetState.TabIndex = 15;
            // 
            // lblShopSetCity
            // 
            this.lblShopSetCity.AutoSize = true;
            this.lblShopSetCity.Location = new System.Drawing.Point(13, 174);
            this.lblShopSetCity.Name = "lblShopSetCity";
            this.lblShopSetCity.Size = new System.Drawing.Size(27, 13);
            this.lblShopSetCity.TabIndex = 14;
            this.lblShopSetCity.Text = "City:";
            // 
            // tbShopSetCity
            // 
            this.tbShopSetCity.Location = new System.Drawing.Point(16, 190);
            this.tbShopSetCity.Name = "tbShopSetCity";
            this.tbShopSetCity.Size = new System.Drawing.Size(224, 20);
            this.tbShopSetCity.TabIndex = 13;
            // 
            // lblShopSetEmail
            // 
            this.lblShopSetEmail.AutoSize = true;
            this.lblShopSetEmail.Location = new System.Drawing.Point(13, 317);
            this.lblShopSetEmail.Name = "lblShopSetEmail";
            this.lblShopSetEmail.Size = new System.Drawing.Size(35, 13);
            this.lblShopSetEmail.TabIndex = 12;
            this.lblShopSetEmail.Text = "Email:";
            // 
            // tbShopSetEmail
            // 
            this.tbShopSetEmail.Location = new System.Drawing.Point(16, 333);
            this.tbShopSetEmail.Name = "tbShopSetEmail";
            this.tbShopSetEmail.Size = new System.Drawing.Size(224, 20);
            this.tbShopSetEmail.TabIndex = 11;
            // 
            // lblShopSetPhone
            // 
            this.lblShopSetPhone.AutoSize = true;
            this.lblShopSetPhone.Location = new System.Drawing.Point(13, 269);
            this.lblShopSetPhone.Name = "lblShopSetPhone";
            this.lblShopSetPhone.Size = new System.Drawing.Size(41, 13);
            this.lblShopSetPhone.TabIndex = 10;
            this.lblShopSetPhone.Text = "Phone:";
            // 
            // tbShopSetPhone
            // 
            this.tbShopSetPhone.Location = new System.Drawing.Point(16, 285);
            this.tbShopSetPhone.Name = "tbShopSetPhone";
            this.tbShopSetPhone.Size = new System.Drawing.Size(224, 20);
            this.tbShopSetPhone.TabIndex = 9;
            // 
            // tbShopSetAddr2
            // 
            this.tbShopSetAddr2.Location = new System.Drawing.Point(16, 144);
            this.tbShopSetAddr2.Name = "tbShopSetAddr2";
            this.tbShopSetAddr2.Size = new System.Drawing.Size(224, 20);
            this.tbShopSetAddr2.TabIndex = 8;
            // 
            // lblShopSetAddr
            // 
            this.lblShopSetAddr.AutoSize = true;
            this.lblShopSetAddr.Location = new System.Drawing.Point(13, 102);
            this.lblShopSetAddr.Name = "lblShopSetAddr";
            this.lblShopSetAddr.Size = new System.Drawing.Size(48, 13);
            this.lblShopSetAddr.TabIndex = 7;
            this.lblShopSetAddr.Text = "Address:";
            // 
            // tbShopSetAddr1
            // 
            this.tbShopSetAddr1.Location = new System.Drawing.Point(16, 118);
            this.tbShopSetAddr1.Name = "tbShopSetAddr1";
            this.tbShopSetAddr1.Size = new System.Drawing.Size(224, 20);
            this.tbShopSetAddr1.TabIndex = 6;
            // 
            // lblShopSetShopname
            // 
            this.lblShopSetShopname.AutoSize = true;
            this.lblShopSetShopname.Location = new System.Drawing.Point(13, 12);
            this.lblShopSetShopname.Name = "lblShopSetShopname";
            this.lblShopSetShopname.Size = new System.Drawing.Size(66, 13);
            this.lblShopSetShopname.TabIndex = 5;
            this.lblShopSetShopname.Text = "Shop Name:";
            // 
            // tbShopSetName
            // 
            this.tbShopSetName.Location = new System.Drawing.Point(16, 28);
            this.tbShopSetName.Name = "tbShopSetName";
            this.tbShopSetName.Size = new System.Drawing.Size(224, 20);
            this.tbShopSetName.TabIndex = 4;
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
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(331, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 142);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FTP Settings";
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
            this.mailGroupBox.Controls.Add(this.textBox1);
            this.mailGroupBox.Location = new System.Drawing.Point(6, 6);
            this.mailGroupBox.Name = "mailGroupBox";
            this.mailGroupBox.Size = new System.Drawing.Size(315, 354);
            this.mailGroupBox.TabIndex = 5;
            this.mailGroupBox.TabStop = false;
            this.mailGroupBox.Text = "Email Settings";
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(234, 317);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Apply";
            this.button4.UseVisualStyleBackColor = true;
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(234, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = true;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 20);
            this.textBox1.TabIndex = 1;
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
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(268, 137);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(68, 23);
            this.button12.TabIndex = 12;
            this.button12.Text = "Save";
            this.button12.UseVisualStyleBackColor = true;
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
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(7, 44);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 1;
            this.checkBox6.UseVisualStyleBackColor = true;
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(111, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "lblLoggingCurrentPath";
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
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(18, 20);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(194, 20);
            this.textBox14.TabIndex = 1;
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
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.SystemColors.Control;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(6, 22);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(74, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "From Name:";
            // 
            // lnkInfoInternalIp
            // 
            this.lnkInfoInternalIp.AutoSize = true;
            this.lnkInfoInternalIp.Location = new System.Drawing.Point(627, 39);
            this.lnkInfoInternalIp.Name = "lnkInfoInternalIp";
            this.lnkInfoInternalIp.Size = new System.Drawing.Size(83, 13);
            this.lnkInfoInternalIp.TabIndex = 68;
            this.lnkInfoInternalIp.TabStop = true;
            this.lnkInfoInternalIp.Text = "lnkinfoInternalIP";
            // 
            // lblInfoExternalIp
            // 
            this.lblInfoExternalIp.AutoSize = true;
            this.lblInfoExternalIp.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfoExternalIp.Location = new System.Drawing.Point(386, 73);
            this.lblInfoExternalIp.Name = "lblInfoExternalIp";
            this.lblInfoExternalIp.Size = new System.Drawing.Size(82, 13);
            this.lblInfoExternalIp.TabIndex = 67;
            this.lblInfoExternalIp.Text = "lblinfoExternalIP";
            // 
            // lnkInfoGateway
            // 
            this.lnkInfoGateway.AutoSize = true;
            this.lnkInfoGateway.Location = new System.Drawing.Point(627, 56);
            this.lnkInfoGateway.Name = "lnkInfoGateway";
            this.lnkInfoGateway.Size = new System.Drawing.Size(80, 13);
            this.lnkInfoGateway.TabIndex = 66;
            this.lnkInfoGateway.TabStop = true;
            this.lnkInfoGateway.Text = "lnkinfoGateway";
            // 
            // lnkInfoPrimDns
            // 
            this.lnkInfoPrimDns.AutoSize = true;
            this.lnkInfoPrimDns.Location = new System.Drawing.Point(627, 73);
            this.lnkInfoPrimDns.Name = "lnkInfoPrimDns";
            this.lnkInfoPrimDns.Size = new System.Drawing.Size(81, 13);
            this.lnkInfoPrimDns.TabIndex = 64;
            this.lnkInfoPrimDns.TabStop = true;
            this.lnkInfoPrimDns.Text = "lnkinfoPrimDNS";
            // 
            // lblDns
            // 
            this.lblDns.AutoSize = true;
            this.lblDns.BackColor = System.Drawing.SystemColors.Control;
            this.lblDns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDns.Location = new System.Drawing.Point(584, 73);
            this.lblDns.Name = "lblDns";
            this.lblDns.Size = new System.Drawing.Size(37, 13);
            this.lblDns.TabIndex = 63;
            this.lblDns.Text = "DNS:";
            // 
            // lblGateway
            // 
            this.lblGateway.AutoSize = true;
            this.lblGateway.BackColor = System.Drawing.SystemColors.Control;
            this.lblGateway.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGateway.Location = new System.Drawing.Point(561, 56);
            this.lblGateway.Name = "lblGateway";
            this.lblGateway.Size = new System.Drawing.Size(60, 13);
            this.lblGateway.TabIndex = 62;
            this.lblGateway.Text = "Gateway:";
            // 
            // lblExternalIp
            // 
            this.lblExternalIp.AutoSize = true;
            this.lblExternalIp.BackColor = System.Drawing.SystemColors.Control;
            this.lblExternalIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExternalIp.Location = new System.Drawing.Point(307, 73);
            this.lblExternalIp.Name = "lblExternalIp";
            this.lblExternalIp.Size = new System.Drawing.Size(73, 13);
            this.lblExternalIp.TabIndex = 61;
            this.lblExternalIp.Text = "External IP:";
            // 
            // lblInternalIp
            // 
            this.lblInternalIp.AutoSize = true;
            this.lblInternalIp.BackColor = System.Drawing.SystemColors.Control;
            this.lblInternalIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternalIp.Location = new System.Drawing.Point(551, 40);
            this.lblInternalIp.Name = "lblInternalIp";
            this.lblInternalIp.Size = new System.Drawing.Size(70, 13);
            this.lblInternalIp.TabIndex = 60;
            this.lblInternalIp.Text = "Internal IP:";
            // 
            // lblFreeC
            // 
            this.lblFreeC.AutoSize = true;
            this.lblFreeC.BackColor = System.Drawing.SystemColors.Control;
            this.lblFreeC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreeC.Location = new System.Drawing.Point(6, 75);
            this.lblFreeC.Name = "lblFreeC";
            this.lblFreeC.Size = new System.Drawing.Size(88, 13);
            this.lblFreeC.TabIndex = 59;
            this.lblFreeC.Text = "Free Space C:";
            // 
            // lblInfoFreeC
            // 
            this.lblInfoFreeC.AutoSize = true;
            this.lblInfoFreeC.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfoFreeC.Location = new System.Drawing.Point(100, 75);
            this.lblInfoFreeC.Name = "lblInfoFreeC";
            this.lblInfoFreeC.Size = new System.Drawing.Size(62, 13);
            this.lblInfoFreeC.TabIndex = 58;
            this.lblInfoFreeC.Text = "lblinfoFreeC";
            // 
            // lblRam
            // 
            this.lblRam.AutoSize = true;
            this.lblRam.BackColor = System.Drawing.SystemColors.Control;
            this.lblRam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRam.Location = new System.Drawing.Point(5, 41);
            this.lblRam.Name = "lblRam";
            this.lblRam.Size = new System.Drawing.Size(38, 13);
            this.lblRam.TabIndex = 57;
            this.lblRam.Text = "RAM:";
            // 
            // lblInfoRam
            // 
            this.lblInfoRam.AutoSize = true;
            this.lblInfoRam.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfoRam.Location = new System.Drawing.Point(50, 41);
            this.lblInfoRam.Name = "lblInfoRam";
            this.lblInfoRam.Size = new System.Drawing.Size(58, 13);
            this.lblInfoRam.TabIndex = 56;
            this.lblInfoRam.Text = "lblinfoRAM";
            // 
            // lblOs
            // 
            this.lblOs.AutoSize = true;
            this.lblOs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOs.Location = new System.Drawing.Point(6, 24);
            this.lblOs.Name = "lblOs";
            this.lblOs.Size = new System.Drawing.Size(28, 13);
            this.lblOs.TabIndex = 55;
            this.lblOs.Text = "OS:";
            // 
            // lblComputerName
            // 
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputerName.Location = new System.Drawing.Point(6, 58);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(100, 13);
            this.lblComputerName.TabIndex = 52;
            this.lblComputerName.Text = "Computer Name:";
            // 
            // lblInfoOs
            // 
            this.lblInfoOs.AutoSize = true;
            this.lblInfoOs.Location = new System.Drawing.Point(40, 24);
            this.lblInfoOs.Name = "lblInfoOs";
            this.lblInfoOs.Size = new System.Drawing.Size(49, 13);
            this.lblInfoOs.TabIndex = 54;
            this.lblInfoOs.Text = "lblinfoOS";
            // 
            // lblInfoComputerName
            // 
            this.lblInfoComputerName.AutoSize = true;
            this.lblInfoComputerName.Location = new System.Drawing.Point(112, 59);
            this.lblInfoComputerName.Name = "lblInfoComputerName";
            this.lblInfoComputerName.Size = new System.Drawing.Size(107, 13);
            this.lblInfoComputerName.TabIndex = 53;
            this.lblInfoComputerName.Text = "lblinfoComputerName";
            // 
            // cmsDeleteQl
            // 
            this.cmsDeleteQl.Name = "Delete";
            this.cmsDeleteQl.Size = new System.Drawing.Size(61, 4);
            this.cmsDeleteQl.Text = "DELETE";
            // 
            // ddlInfoNetworkAdapters
            // 
            this.ddlInfoNetworkAdapters.FormattingEnabled = true;
            this.ddlInfoNetworkAdapters.Location = new System.Drawing.Point(308, 31);
            this.ddlInfoNetworkAdapters.Name = "ddlInfoNetworkAdapters";
            this.ddlInfoNetworkAdapters.Size = new System.Drawing.Size(185, 21);
            this.ddlInfoNetworkAdapters.TabIndex = 69;
            this.ddlInfoNetworkAdapters.Text = "Select an Adapter";
            this.ddlInfoNetworkAdapters.Click += new System.EventHandler(this.ddlinfoNetworkAdapters_SelectedIndexChanged);
            // 
            // lblInfoAdapterDesc
            // 
            this.lblInfoAdapterDesc.AutoSize = true;
            this.lblInfoAdapterDesc.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfoAdapterDesc.Location = new System.Drawing.Point(386, 58);
            this.lblInfoAdapterDesc.MaximumSize = new System.Drawing.Size(170, 13);
            this.lblInfoAdapterDesc.Name = "lblInfoAdapterDesc";
            this.lblInfoAdapterDesc.Size = new System.Drawing.Size(96, 13);
            this.lblInfoAdapterDesc.TabIndex = 71;
            this.lblInfoAdapterDesc.Text = "lblinfoAdapterDesc";
            // 
            // ofdTron
            // 
            this.ofdTron.FileName = "Tron.bat";
            // 
            // OsMain
            // 
            this.ClientSize = new System.Drawing.Size(754, 531);
            this.Controls.Add(this.lblInfoAdapterDesc);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.ddlInfoNetworkAdapters);
            this.Controls.Add(this.lnkInfoInternalIp);
            this.Controls.Add(this.lblInfoExternalIp);
            this.Controls.Add(this.lnkInfoGateway);
            this.Controls.Add(this.lnkInfoPrimDns);
            this.Controls.Add(this.lblDns);
            this.Controls.Add(this.lblGateway);
            this.Controls.Add(this.lblExternalIp);
            this.Controls.Add(this.lblInternalIp);
            this.Controls.Add(this.lblFreeC);
            this.Controls.Add(this.lblInfoFreeC);
            this.Controls.Add(this.lblRam);
            this.Controls.Add(this.lblInfoRam);
            this.Controls.Add(this.lblOs);
            this.Controls.Add(this.lblComputerName);
            this.Controls.Add(this.lblInfoOs);
            this.Controls.Add(this.lblInfoComputerName);
            this.Controls.Add(this.tcPrimaryTabs);
            this.Controls.Add(this.tsBottomToolbar);
            this.Controls.Add(this.menuPrimary);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuPrimary;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OsMain";
            this.Load += new System.EventHandler(this.OS_Main_Load);
            this.tsBottomToolbar.ResumeLayout(false);
            this.tsBottomToolbar.PerformLayout();
            this.menuPrimary.ResumeLayout(false);
            this.menuPrimary.PerformLayout();
            this.tcPrimaryTabs.ResumeLayout(false);
            this.tpWelcome.ResumeLayout(false);
            this.tpWelcome.PerformLayout();
            this.tpOneStopMain.ResumeLayout(false);
            this.tpOneStopMain.PerformLayout();
            this.tpTronCli.ResumeLayout(false);
            this.tpTronSettings.ResumeLayout(false);
            this.tpLaunchTron.ResumeLayout(false);
            this.tpLaunchTron.PerformLayout();
            this.tpSystemInfo.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpSystemReport.ResumeLayout(false);
            this.tpSystemReport.PerformLayout();
            this.tpNetwork.ResumeLayout(false);
            this.tpNetwork.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tpConfigurator.ResumeLayout(false);
            this.tcConfigurator.ResumeLayout(false);
            this.tpSetup.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tpQuickLaunch.ResumeLayout(false);
            this.tpQuickLaunch.PerformLayout();
            this.tpShopSettings.ResumeLayout(false);
            this.tpShopSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tpServers.ResumeLayout(false);
            this.mailGroupBox.ResumeLayout(false);
            this.mailGroupBox.PerformLayout();
            this.tpIntegration.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tpLogging.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void tpSystemInfo_Enter(object sender, EventArgs e)
        {
            //StartProgressMarquee();

            //LOAD WMI STUFF HERE


            //StopProgressMarquee();
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
            foldersToolStripMenuItem.Enabled = true;
            btnConfigDump.Enabled = true;
            btnRunTron.Enabled = true;
            btnDryRun.Enabled = true;
            btnTronSaveFlags.Enabled = true;
            foldersToolStripMenuItem.Enabled = true;

            //Enable CBs
            EnableTronCBs();

            //Code to populate CBs.
            PopulateTronCBs();

            var strAdminStatus = BoolAdminStatus ? "ADMIN" : "NOT ADMIN";

            lblAdminStatus.Text = StrTronStatus + strAdminStatus;
        }

        private void EnableTronCBs()
        {
            cbTronDev.Enabled = true;
            cbTronE.Enabled = true;
            cbTronEr.Enabled = true;
            cbTronM.Enabled = true;
            cbTronO.Enabled = true;
            cbTronP.Enabled = true;
            cbTronR.Enabled = true;
            cbTronSa.Enabled = true;
            cbTronSb.Enabled = true;
            cbTronSd.Enabled = true;
            cbTronSdc.Enabled = true;
            cbTronSe.Enabled = true;
            cbTronSfr.Enabled = true;
            cbTronSk.Enabled = true;
            cbTronSm.Enabled = true;
            cbTronSp.Enabled = true;
            cbTronSpr.Enabled = true;
            cbTronSrr.Enabled = true;
            cbTronSs.Enabled = true;
            cbTronStr.Enabled = true;
            cbTronSw.Enabled = true;
            cbTronV.Enabled = true;
            cbTronX.Enabled = true;
        }

        private void PopulateTronCBs()
        {
            if (Settings.Default.bool_tron_dev)
            {
                cbTronDev.Checked = true;
            }
            if (Settings.Default.bool_tron_e)
            {
                cbTronE.Checked = true;
            }
            if (Settings.Default.bool_tron_er)
            {
                cbTronEr.Checked = true;
            }
            if (Settings.Default.bool_tron_m)
            {
                cbTronM.Checked = true;
            }
            if (Settings.Default.bool_tron_o)
            {
                cbTronO.Checked = true;
            }
            if (Settings.Default.bool_tron_p)
            {
                cbTronP.Checked = true;
            }
            if (Settings.Default.bool_tron_r)
            {
                cbTronR.Checked = true;
            }
            if (Settings.Default.bool_tron_sa)
            {
                cbTronSa.Checked = true;
            }
            if (Settings.Default.bool_tron_sb)
            {
                cbTronSb.Checked = true;
            }
            if (Settings.Default.bool_tron_sd)
            {
                cbTronSd.Checked = true;
            }
            if (Settings.Default.bool_tron_sdc)
            {
                cbTronSdc.Checked = true;
            }
            if (Settings.Default.bool_tron_se)
            {
                cbTronSe.Checked = true;
            }
            if (Settings.Default.bool_tron_sfr)
            {
                cbTronSfr.Checked = true;
            }
            if (Settings.Default.bool_tron_sk)
            {
                cbTronSk.Checked = true;
            }
            if (Settings.Default.bool_tron_sm)
            {
                cbTronSm.Checked = true;
            }
            if (Settings.Default.bool_tron_sp)
            {
                cbTronSp.Checked = true;
            }
            if (Settings.Default.bool_tron_spr)
            {
                cbTronSpr.Checked = true;
            }
            if (Settings.Default.bool_tron_srr)
            {
                cbTronSrr.Checked = true;
            }
            if (Settings.Default.bool_tron_ss)
            {
                cbTronSs.Checked = true;
            }
            if (Settings.Default.bool_tron_str)
            {
                cbTronStr.Checked = true;
            }
            if (Settings.Default.bool_tron_sw)
            {
                cbTronSw.Checked = true;
            }
            if (Settings.Default.bool_tron_v)
            {
                cbTronV.Checked = true;
            }
            if (Settings.Default.bool_tron_x)
            {
                cbTronX.Checked = true;
            }
        }

        private void TronDisable(string statusMsg)
        {
            lblAdminStatus.ForeColor = Color.Red;
            foldersToolStripMenuItem.Enabled = false;
            btnTronSaveFlags.Enabled = false;
            btnConfigDump.Enabled = false;
            btnRunTron.Enabled = false;
            btnDryRun.Enabled = false;
            btnTronSaveFlags.Enabled = false;

            //Empty CBs
            UncheckTronCBs();

            //Code to populate CBs.
            PopulateTronCBs();

            //Disable CBs
            DisableTronCBs();
        }

        private void UncheckTronCBs()
        {
            cbTronDev.Checked = false;
            cbTronE.Checked = false;
            cbTronEr.Checked = false;
            cbTronM.Checked = false;
            cbTronO.Checked = false;
            cbTronP.Checked = false;
            cbTronR.Checked = false;
            cbTronSa.Checked = false;
            cbTronSb.Checked = false;
            cbTronSd.Checked = false;
            cbTronSdc.Checked = false;
            cbTronSe.Checked = false;
            cbTronSfr.Checked = false;
            cbTronSk.Checked = false;
            cbTronSm.Checked = false;
            cbTronSp.Checked = false;
            cbTronSpr.Checked = false;
            cbTronSrr.Checked = false;
            cbTronSs.Checked = false;
            cbTronStr.Checked = false;
            cbTronSw.Checked = false;
            cbTronV.Checked = false;
            cbTronX.Checked = false;
        }

        private void DisableTronCBs()
        {
            cbTronDev.Enabled = false;
            cbTronE.Enabled = false;
            cbTronEr.Enabled = false;
            cbTronM.Enabled = false;
            cbTronO.Enabled = false;
            cbTronP.Enabled = false;
            cbTronR.Enabled = false;
            cbTronSa.Enabled = false;
            cbTronSb.Enabled = false;
            cbTronSd.Enabled = false;
            cbTronSdc.Enabled = false;
            cbTronSe.Enabled = false;
            cbTronSfr.Enabled = false;
            cbTronSk.Enabled = false;
            cbTronSm.Enabled = false;
            cbTronSp.Enabled = false;
            cbTronSpr.Enabled = false;
            cbTronSrr.Enabled = false;
            cbTronSs.Enabled = false;
            cbTronStr.Enabled = false;
            cbTronSw.Enabled = false;
            cbTronV.Enabled = false;
            cbTronX.Enabled = false;
        }

        private void EnumerateScripts(string strScriptsDirectory)
        {
            try
            {
                var directorytocreate = Directory.GetCurrentDirectory() + "\\Scripts\\";

                var directoryInfo = new FileInfo(directorytocreate).Directory;
                if (directoryInfo != null) directoryInfo.Create();
            }
            catch (Exception e)
            {
                OSConsole("Attempted to Create Scripts directory but failed" + e, intVerboseErrorMode);
            }

            try
            {
                if (new DirectoryInfo(strScriptsDirectory).Exists)
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
                            extension == ".PS2" || extension == ".PS2XML" || extension == ".PSC1" ||
                            extension == ".PSC2" ||
                            extension == ".MSH" || extension == ".MSH1" || extension == ".MSH2" ||
                            extension == ".MSHXML" ||
                            extension == ".MXS1XML" || extension == ".MSH2XML")
                        {
                            ToolStripItem subItem = new ToolStripMenuItem();
                            subItem.Click += MenuClickedScripts;
                            subItem.Text = Convert.ToString(file);
                            scriptsToolStripMenuItem.DropDownItems.Add(subItem);
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
                MessageBox.Show("Error launching Document");
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
            var browser = string.Empty;
            RegistryKey key = null;

            try
            {
                // try location of default browser path in XP
                key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

                // try location of default browser path in Vista
                if (key == null)
                {
                    key =
                        Registry.CurrentUser.OpenSubKey(
                            @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http", false);
                    ;
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

            var output = "";
            var errorcode = "";

            if (mode == "web")
            {
                OSConsole("Launched Website: " + path, intWebsiteMode);
                var browserPath = GetBrowserPath();
                if (browserPath == string.Empty)
                    browserPath = "iexplore";
                var process = new Process();
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
                Process.Start("CMD.exe", " /c " + path);
            }
            else if (mode == "prompt_open")
            {
                //k
                OSConsole("Executing System Command: " + args, intCMDCommandMode);

                try
                {
                    var startInfo = new ProcessStartInfo();
                    startInfo.RedirectStandardOutput = true;
                    startInfo.RedirectStandardError = true;
                    startInfo.FileName = path;
                    if (args != null)
                    {
                        startInfo.Arguments = " /k " + args;
                    }
                    startInfo.UseShellExecute = false;

                    var process = new Process();
                    process.StartInfo = startInfo;
                    process.EnableRaisingEvents = true;

                    process.Start();

                    if (wait)
                    {
                        process.WaitForExit();
                    }

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
                    var startInfo = new ProcessStartInfo();
                    startInfo.RedirectStandardOutput = true;
                    startInfo.RedirectStandardError = true;
                    startInfo.FileName = path;
                    if (args != null)
                    {
                        startInfo.Arguments = " /c " + args;
                    }
                    startInfo.UseShellExecute = false;

                    var process = new Process();
                    process.StartInfo = startInfo;
                    process.EnableRaisingEvents = true;

                    process.Start();

                    if (wait)
                    {
                        process.WaitForExit();
                    }

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
                    var startInfo = new ProcessStartInfo();
                    startInfo.RedirectStandardOutput = true;
                    startInfo.RedirectStandardError = true;
                    startInfo.FileName = path;
                    if (args != null) startInfo.Arguments = args;
                    startInfo.UseShellExecute = false;

                    var process = new Process();
                    process.StartInfo = startInfo;
                    process.EnableRaisingEvents = true;

                    process.Start();

                    if (wait)
                    {
                        process.WaitForExit();
                    }

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
                var directorytocreate = Directory.GetCurrentDirectory() + "\\Documents\\";

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
                            documentsToolStripMenuItem.DropDownItems.Add(subItem);
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
            var result = ofdMenuItem.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Save Item

                var output = "|" + strName + "," + ofdMenuItem.FileName;
                var currentSetting = Settings.Default.str_StoredApps;
                Settings.Default.str_StoredApps = currentSetting + output;
                Settings.Default.Save();

                //Create item in current instance
                ToolStripItem subItem = new ToolStripMenuItem();
                subItem.Click += MenuClicked;
                subItem.Text = strName;
                qlToolStripMenuItem.DropDownItems.Add(subItem);

                //Add to List
                lbCurrentPrograms.Items.Add(output);
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
                qlToolStripMenuItem.DropDownItems.Add(subItem);

                //Add to List
                lbCurrentPrograms.Items.Add(values);
            }
        }

        private void LoadShopSettings()
        {
            tbShopSetAddr1.Text = Settings.Default.str_Shop_Addr1;
            tbShopSetAddr2.Text = Settings.Default.str_Shop_Addr2;
            tbShopSetCity.Text = Settings.Default.str_Shop_City;
            tbShopSetEmail.Text = Settings.Default.str_Shop_Email;
            tbShopSetName.Text = Settings.Default.str_Shop_Name;
            tbShopSetPhone.Text = Settings.Default.str_Shop_Phone;
            tbShopSetState.Text = Settings.Default.str_Shop_State;
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

        private void oneStopToolInternalBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OS_BrowserIE = new OS_Browser();
            OS_BrowserIE.Show();
        }

        private void lbOsmCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Needs to automatically do the pre-run, run once and set safemode on reboot, normal mode on end. Disable sleep and enable
            //Need to add function to exclude disks from some programs

            if (lbOsmCategories.SelectedItem.ToString() == @"Create Restore Point")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("Restore: Create New Restore Point - OneStop");
                if (Properties.Settings.Default.str_Shop_Name != null)
                    Programlist.Add("Restore: Create New Restore Point" + Properties.Settings.Default.str_Shop_Name);

                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Reporting/Audit")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("Logs/Reports: Email to Default Email");
                Programlist.Add("Logs/Reports: Upload to Ftp");
                Programlist.Add("Logs/Reports: Upload to Dropbox");
                Programlist.Add("Logs/Reports: Zip and Save");
                Programlist.Add("Reporting: Full Report");
                
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Hardware Testing")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("Test: SMART Check");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");

                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Backup Tasks")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("Backup: Registry");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Prep For Malware Removal")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("Prep: RKill");
                Programlist.Add("Prep: ProcessKiller");
                Programlist.Add("Prep: McAffee Stinger");
                Programlist.Add("Prep: TDSS Killer");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"File Cleanup")
            {
            //https://support.microsoft.com/en-us/kb/253597
                List<string> Programlist = new List<string>();
                Programlist.Add("Cleanup: Antivirus: ESET AV Remover");
                Programlist.Add("Cleanup: Browser: Auslogics Browser Care");
                Programlist.Add("Cleanup: Browser: IE: Clean and Reset");
                Programlist.Add("Cleanup: Browser: IE: Delete Browser Helper Objects");
                Programlist.Add("Cleanup: Browser: IE: Delete Toolbar Registry Keys");
                Programlist.Add("Cleanup: Cleanmgr: All");
                Programlist.Add("Cleanup: Cleanmgr: Chkdisk Lost File Fragments");
                Programlist.Add("Cleanup: Cleanmgr: Clear Recycle Bin");
                Programlist.Add("Cleanup: Cleanmgr: Compress Old Files");
                Programlist.Add("Cleanup: Cleanmgr: Content Indexer Catalog Files");
                Programlist.Add("Cleanup: Cleanmgr: Downloaded Program Files (ActiveX / Java)");
                Programlist.Add("Cleanup: Cleanmgr: Offline Files");
                Programlist.Add("Cleanup: Cleanmgr: Temporary Files");
                Programlist.Add("Cleanup: Cleanmgr: Temporary Internet Files");
                Programlist.Add("Cleanup: Cleanmgr: Temporary Offline Files");
                Programlist.Add("Cleanup: Cleanmgr: Temporary Setup Files");
                Programlist.Add("Cleanup: Duplicates: Download Folder");
                Programlist.Add("Cleanup: General: /u/Vocatus TempFileCleanup.bat");
                Programlist.Add("Cleanup: General: BleachBit (all)");
                Programlist.Add("Cleanup: General: BleachBit (manual)");
                Programlist.Add("Cleanup: General: CCleaner (all)");
                Programlist.Add("Cleanup: General: CCleaner (manual)");
                Programlist.Add("Cleanup: Registry: Auslogics Registry Cleaner");
                Programlist.Add("Cleanup: System: Clear Windows Event Logs (w/backup)");
                Programlist.Add("Cleanup: System: Delete $NTUninst");
                Programlist.Add("Cleanup: System: Purge All Restore Points before Today");
                Programlist.Add("Cleanup: System: Purge Volume Shadow Service");
                Programlist.Add("Cleanup: USB: Unused/Not Present");
                Programlist.Add("Cleanup: Bleachbit: Adobe Reader: Cache");
                Programlist.Add("Cleanup: Bleachbit: Adobe Reader: Recent");
                Programlist.Add("Cleanup: Bleachbit: Adobe Reader: Temp");
                Programlist.Add("Cleanup: Bleachbit: Chrome: Cache");
                Programlist.Add("Cleanup: Bleachbit: Chrome: Clean Database Fragmentation");
                Programlist.Add("Cleanup: Bleachbit: Chrome: Cookies");
                Programlist.Add("Cleanup: Bleachbit: Chrome: DOM Storage");
                Programlist.Add("Cleanup: Bleachbit: Chrome: Form History");
                Programlist.Add("Cleanup: Bleachbit: Chrome: History");
                Programlist.Add("Cleanup: Bleachbit: Chrome: Passwords");
                Programlist.Add("Cleanup: Bleachbit: Chrome: Search Engines");
                Programlist.Add("Cleanup: Bleachbit: Chrome: Session");
                Programlist.Add("Cleanup: Bleachbit: Clipboard");
                Programlist.Add("Cleanup: Bleachbit: Deepscan: .DS_Store");
                Programlist.Add("Cleanup: Bleachbit: Deepscan: Backup Files");
                Programlist.Add("Cleanup: Bleachbit: Deepscan: Temp. Files");
                Programlist.Add("Cleanup: Bleachbit: Deepscan: Thumbs.db");
                Programlist.Add("Cleanup: Bleachbit: Filezilla: Recent");
                Programlist.Add("Cleanup: Bleachbit: Firefox: Backup Files");
                Programlist.Add("Cleanup: Bleachbit: Firefox: Cache");
                Programlist.Add("Cleanup: Bleachbit: Firefox: Clean Database Fragmentation");
                Programlist.Add("Cleanup: Bleachbit: Firefox: Cookies");
                Programlist.Add("Cleanup: Bleachbit: Firefox: Crash Reports");
                Programlist.Add("Cleanup: Bleachbit: Firefox: DOM Storage");
                Programlist.Add("Cleanup: Bleachbit: Firefox: Download History");
                Programlist.Add("Cleanup: Bleachbit: Firefox: Form History");
                Programlist.Add("Cleanup: Bleachbit: Firefox: Passwords");
                Programlist.Add("Cleanup: Bleachbit: Firefox: Session Restore");
                Programlist.Add("Cleanup: Bleachbit: Firefox: Site Preferences");
                Programlist.Add("Cleanup: Bleachbit: Firefox: URL History");
                Programlist.Add("Cleanup: Bleachbit: Flash: Cache");
                Programlist.Add("Cleanup: Bleachbit: Flash: Cookies");
                Programlist.Add("Cleanup: Bleachbit: IE: Cookies");
                Programlist.Add("Cleanup: Bleachbit: IE: Form History");
                Programlist.Add("Cleanup: Bleachbit: IE: History");
                Programlist.Add("Cleanup: Bleachbit: IE: Temporary Files");
                Programlist.Add("Cleanup: Bleachbit: Java: Cache");
                Programlist.Add("Cleanup: Bleachbit: LibreOffice: Cache");
                Programlist.Add("Cleanup: Bleachbit: LibreOffice: History");
                Programlist.Add("Cleanup: Bleachbit: Log Files");
                Programlist.Add("Cleanup: Bleachbit: memory.dmp");
                Programlist.Add("Cleanup: Bleachbit: Microsoft Office: Debug Logs");
                Programlist.Add("Cleanup: Bleachbit: Microsoft Office: Recently Used");
                Programlist.Add("Cleanup: Bleachbit: Microsoft Updates Uninstallers");
                Programlist.Add("Cleanup: Bleachbit: MUI Memory");
                Programlist.Add("Cleanup: Bleachbit: OpenOffice: Cache");
                Programlist.Add("Cleanup: Bleachbit: OpenOffice: Recently Used");
                Programlist.Add("Cleanup: Bleachbit: Paint: Recently Used");
                Programlist.Add("Cleanup: Bleachbit: Prefetch Memory");
                Programlist.Add("Cleanup: Bleachbit: Recycle Bin");
                Programlist.Add("Cleanup: Bleachbit: Skype: Chat Logs");
                Programlist.Add("Cleanup: Bleachbit: Skype: Installers");
                Programlist.Add("Cleanup: Bleachbit: System Logs");
                Programlist.Add("Cleanup: Bleachbit: TeamViewer: Logs");
                Programlist.Add("Cleanup: Bleachbit: TeamViewer: Recently Used");
                Programlist.Add("Cleanup: Bleachbit: Temp Files");
                Programlist.Add("Cleanup: Bleachbit: Thunderbird: Cache");
                Programlist.Add("Cleanup: Bleachbit: Thunderbird: Clean Database Fragmentation");
                Programlist.Add("Cleanup: Bleachbit: Thunderbird: Cookies");
                Programlist.Add("Cleanup: Bleachbit: Thunderbird: Index");
                Programlist.Add("Cleanup: Bleachbit: Thunderbird: Password");
                Programlist.Add("Cleanup: Bleachbit: VLC: Recently Used");
                Programlist.Add("Cleanup: Bleachbit: Winamp: Recently Used");
                Programlist.Add("Cleanup: Bleachbit: Windows Explorer: Most Recently Used");
                Programlist.Add("Cleanup: Bleachbit: Windows Explorer: Recent Docs List");
                Programlist.Add("Cleanup: Bleachbit: Windows Explorer: Run");
                Programlist.Add("Cleanup: Bleachbit: Windows Explorer: Search History");
                Programlist.Add("Cleanup: Bleachbit: Windows Explorer: Thumbnails");
                Programlist.Add("Cleanup: Bleachbit: WinRar:  Recently Used");
                Programlist.Add("Cleanup: Bleachbit: WinZip: Recently Used");
                Programlist.Add("Cleanup: Bleachbit: WordPad: Recently Used");


                //IF Bleachbit containes /cleaners/winapp2.ini, iterate through list and append
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"De-Bloat")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Disinfect")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Repair")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("Repair: ");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Patch / Updates / Install")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Optimize")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Windows Repair")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("Repair: Set System Time via NTP");
                Programlist.Add("Repair: Check/Repair WMI");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"System Tweaks")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("Tweak: Reduce System Restore Space");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Apply Branding")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Networking")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Manual Tools")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }
            if (lbOsmCategories.SelectedItem.ToString() == @"Other")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                Programlist.Add("");
                lbProgramSelect.DataSource = Programlist;
            }

            if (lbOsmCategories.SelectedItem.ToString() == @"Extended File Cleanup")
            {
                List<string> Programlist = new List<string>();
                Programlist.Add("**IF WINAPP2.INI is found, options load here**");
                lbProgramSelect.DataSource = Programlist;
            }



        }




    }
}