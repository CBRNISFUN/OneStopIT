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

namespace OneStop
{
    public class OsMain : Form
    {
        public bool BoolLocalDir;
        public bool BoolPrevDir;
        public string GString = "GodMode.{ED7BA470-8E54-465E-825C-99712043E01C}";

        public string StrTronPath = "";
        public string StrTronStatus = "";
        const string StrFileName = "Tron.bat";

        public osInitiate OsInitiate
        {
            get { return _osInitiate; }
        }

        private void OS_Main_Load(object sender, EventArgs e)
        {
            #region Startup

            // Load Settings
            Settings.Default.Reload();

            //Tron not found by default
            TronDisable("Not Initialized - ");


            //Determine if Tron is located on load.
            string strFileName;
            string strCurDir;
            string[] strFilePaths;
            GetTronLocation(out strCurDir, out strFilePaths);

            //Determine if We are Administrators.
            var strAdminStatus = "";
            var isElevated = OsSystem.GetElevatedStatus();

            if (isElevated)
            {
                strAdminStatus = "ADMIN";
                _lblOneStopStatus.ForeColor = Color.Green;
            }
            if (!isElevated)
            {
                strAdminStatus = "NOT ADMIN";
                _lblOneStopStatus.ForeColor = Color.Red;
            }


            //Set all labels with current info
            _lblOneStopStatus.Text = StrTronStatus + strAdminStatus;
            _lblInfoFreeC.Text = OsSystem.GetCDriveSpace();
            _lblInfoOs.Text = OsSystem.GetOsFriendlyName() + OsSystem.GetArch();
            _lblInfoRam.Text = OsSystem.GetInstalledMemory();
            _lblInfoComputerName.Text = OsSystem.GetMachineName();
            _lblInfoExternalIp.Text = "";
            _lnkInfoInternalIp.Text = "";
            _lnkInfoGateway.Text = "";
            _lnkInfoPrimDns.Text = "";
            _lblInfoAdapterDesc.Text = "";


            //Network Adapters

            var adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var adapter in adapters)
            {
                _ddlInfoNetworkAdapters.Items.Add(adapter.Name);
            }

            //Load Quick Launch Menu
            LoadMenuatStart();

            string strCurrentDirectory = Directory.GetCurrentDirectory();
            string strScriptsDirectory = strCurrentDirectory + "\\Scripts";
            string strDocsDirectory = strCurrentDirectory + "\\Documents";

            //enumerate scripts Quick Launch
            EnumerateScripts(strScriptsDirectory);

            //Enumerate Docs Quick Launch
            EnumerateDocs(strDocsDirectory);

            //Load Settings Panel
            LoadShopSettings();

            //Load Tron Flags
            PopulateTronCBs();

            #endregion
        }

        private void GetTronLocation(out string strCurDir, out string[] strFilePaths)
        {
            
            strCurDir = Directory.GetCurrentDirectory();
            strFilePaths = Directory.GetFiles(strCurDir);

            if (File.Exists(strCurDir + "\\" + StrFileName))
            {
                //Tron Was Found in Current Directory, enable all of the disabled functions (ConfigDump Button, 
                TronEnable("Tron Found (Current) - ", strCurDir + "\\" + StrFileName);
                BoolLocalDir = true;
                BoolPrevDir = false;
            }
            else if (Settings.Default.str_LastTronDirectory != null)
            {
                //We didn't find Tron in the Current directory, but we can look in the stored location of where it was last time
                if (File.Exists(Settings.Default.str_LastTronDirectory + "\\" + StrFileName))
                {
                    //We've Found Tron in Previous Directory, enable all the disabled functions
                    TronEnable("Tron Found (Previous) - ", Settings.Default.str_LastTronDirectory + "\\" + StrFileName);
                    BoolLocalDir = false;
                    BoolPrevDir = true;
                }
                else
                {
                    //We didn't find Tron anywhere. 
                    TronDisable("Tron Not Found - ");
                    BoolLocalDir = false;
                    BoolPrevDir = false;
                }
            }
            else
            {
                //We didn't find Tron Anywhere.
                TronDisable("Tron Not Found - ");
                BoolLocalDir = false;
                BoolPrevDir = false;
            }
        }


        private void ddl_info_NetworkAdapters_SelectedIndexChanged(object sender, EventArgs e)
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
            var strArguments = OsTron.GetTronArgs();
            LaunchTron(" -c -e");
        }

        private void LaunchTron(string strExtraArg)
        {
            if (BoolLocalDir)
            {
                var strCurrentDir = Directory.GetCurrentDirectory();
                var tronLaunchString = " /C \"" + strCurrentDir + "\\Tron.bat\"" + strExtraArg + OsTron.GetTronArgs();
                Process.Start("cmd.exe", tronLaunchString);
            }
            else if (BoolPrevDir)
            {
                var strCurrentDir = Settings.Default.str_LastTronDirectory;
                var tronLaunchString = " /C \"" + strCurrentDir + "Tron.bat\"" + strExtraArg + OsTron.GetTronArgs();
                Process.Start("cmd.exe", tronLaunchString);
            }
            else
            {
                var tronFile = _ofdTron.FileName;
                var tronLaunchString = " /C \"" + tronFile + "\"" + strExtraArg + OsTron.GetTronArgs();

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

        #region Components

        private ToolStripLabel _lblOneStopStatus;
        private ToolStripMenuItem _foldersToolStripMenuItem;
        internal Button _btnConfigDump;
        public Button _btnDryRun;
        public Button _btnRunTron;
        public CheckBox _cbTronStr;
        public CheckBox _cbTronSs;
        public CheckBox _cbTronSrr;
        public CheckBox _cbTronSfr;
        public CheckBox _cbTronSm;
        public CheckBox _cbTronSdc;
        public CheckBox _cbTronSk;
        public CheckBox _cbTronSpr;
        public CheckBox _cbTronSw;
        public CheckBox _cbTronSe;
        public CheckBox _cbTronP;
        public CheckBox _cbTronEr;
        public CheckBox _cbTronSb;
        public CheckBox _cbTronM;
        public CheckBox _cbTronX;
        public CheckBox _cbTronO;
        public CheckBox _cbTronV;
        public CheckBox _cbTronR;
        public CheckBox _cbTronSp;
        public CheckBox _cbTronSa;
        public CheckBox _cbTronSd;
        private LinkLabel _lnkInfoInternalIp;
        private Label _lblInfoExternalIp;
        private LinkLabel _lnkInfoGateway;
        private LinkLabel _lnkInfoPrimDns;
        private Label _lblInfoFreeC;
        private Label _lblInfoRam;
        private Label _lblInfoOs;
        private Label _lblInfoComputerName;
        private ToolStripMenuItem _qlToolStripMenuItem;
        private ToolStripMenuItem _scriptsToolStripMenuItem;
        private ToolStripMenuItem _documentsToolStripMenuItem;
        private OpenFileDialog _ofdMenuItem;
        private TextBox _txtQlAppName;
        private ListBox _lbCurrentPrograms;
        private ComboBox _ddlInfoNetworkAdapters;
        private Label _lblInfoAdapterDesc;
        private TextBox _tbShopSetState;
        private TextBox _tbShopSetCity;
        private TextBox _tbShopSetEmail;
        private TextBox _tbShopSetPhone;
        private TextBox _tbShopSetAddr2;
        private TextBox _tbShopSetAddr1;
        private TextBox _tbShopSetName;
        public CheckBox _cbTronE;
        internal CheckBox _cbTronDev;
        private OpenFileDialog _ofdTron;
        public Button _btnTronSaveFlags;
        private readonly osInitiate _osInitiate;

        public OsMain()
        {
            _osInitiate = new osInitiate(this);
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
            _lblOneStopStatus.ForeColor = Color.Green;
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
            _lblOneStopStatus.ForeColor = Color.Red;
            _foldersToolStripMenuItem.Enabled = false;
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
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show(uaEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                MessageBox.Show(pathEx.Message);
            }
        }

        private void EnumerateDocs(string strDocsDirectory)
        {
            try
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
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show(uaEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                MessageBox.Show(pathEx.Message);
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
    }
}