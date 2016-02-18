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

namespace OneStop
{
    public class OsMain : Form
    {
        public bool BoolLocalDir;
        public bool BoolPrevDir;
        public string GString = "GodMode.{ED7BA470-8E54-465E-825C-99712043E01C}";
        public bool BoolAdminStatus;

        public string StrTronPath = "";
        private TextBox tb_Console;
        public string StrTronStatus = "";

        private void OS_Main_Load(object sender, EventArgs e)
        {
            #region Startup

            Console("OS_HR");
            Console("Begin  ONESTOP STARTUP");
            Console("OS_HR");
            Console("OS_BR");
            Console("OS_GPL");




            Console("OS_HR");
            Console("Loading Settings...");
            Console("OS_BR");
            // Load Settings
            Settings.Default.Reload();

            //Tron not found by default
            TronDisable("Not Initialized - ");

            Console("Searching for Tron.bat");
            //Determine if Tron is located on load.
            var strFileName = "Tron.bat";
            var strCurDir = Directory.GetCurrentDirectory();
            var strFilePaths = Directory.GetFiles(strCurDir);

            if (File.Exists(strCurDir + "\\Tron\\" + strFileName))
            {
                //Tron Was Found in Current Directory, enable all of the disabled functions (ConfigDump Button, 
                TronEnable("Tron Found (Current) - ", strCurDir + "\\" + strFileName);
                BoolLocalDir = true;
                BoolPrevDir = false;
                Console("Tron.bat Found in Local Directory");

            }
            else if (File.Exists(strCurDir + "\\" + strFileName))
            {
                //Tron Was Found in Current Directory, enable all of the disabled functions (ConfigDump Button, 
                TronEnable("Tron Found (Current) - ", strCurDir + "\\" + strFileName);
                BoolLocalDir = true;
                BoolPrevDir = false;
                Console("Tron.bat Found in Local Directory Root");
            }
            else if (Settings.Default.str_LastTronDirectory != null)
            {
                //We didn't find Tron in the Current directory, but we can look in the stored location of where it was last time
                if (File.Exists(Settings.Default.str_LastTronDirectory + "\\" + strFileName))
                {
                    //We've Found Tron in Previous Directory, enable all the disabled functions
                    TronEnable("Tron Found (Previous) - ", Settings.Default.str_LastTronDirectory + "\\" + strFileName);
                    BoolLocalDir = false;
                    BoolPrevDir = true;
                    Console("Tron.bat Found in previously used location");
                }
                else
                {
                    //We didn't find Tron anywhere. 
                    TronDisable("Tron Not Found - ");
                    BoolLocalDir = false;
                    BoolPrevDir = false;
                    Console("Tron.bat not found");

                }
            }
            else
            {
                //We didn't find Tron Anywhere.
                TronDisable("Tron Not Found - ");
                BoolLocalDir = false;
                BoolPrevDir = false;
                Console("Tron.bat not found");
            }

            //Determine if We are Administrators.
            var strAdminStatus = "";
            
            try
            {
                var isElevated = OsSystem.GetElevatedStatus();

                if (isElevated)
                {
                    strAdminStatus = "ADMIN";
                    _lblOneStopStatus.ForeColor = Color.Green;
                    BoolAdminStatus = true;
                    Console("OneStop is running as Administrator");
                }
                if (!isElevated)
                {
                    strAdminStatus = "NOT ADMIN";
                    _lblOneStopStatus.ForeColor = Color.Red;
                    BoolAdminStatus = false;
                    Console("OS_BR");
                    Console("ONE STOP IS NOT RUNNING AS ADMINISTRATOR - SOME FUNCTIONALITY, INCLUDING TRON CANNOT RUN");
                }
            }
            catch (Exception exception)
            {
                Console("Exeption while checking administrator status" + exception);
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
            Console("Getting Current Stystem Status");
            Console("C Drive Space: " + OsSystem.GetCDriveSpace());
            Console("OS Friendly Name / Arch: "  + OsSystem.GetOsFriendlyName() + OsSystem.GetArch());
            Console("Installed Memory: " + OsSystem.GetInstalledMemory());
            Console("Machine Name: " + OsSystem.GetMachineName());
            Console("OS_HR");
            
            //Network Adapters
            Console("Getting Network Adapters");
            var adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var adapter in adapters)
            {
                _ddlInfoNetworkAdapters.Items.Add(adapter.Name);
                Console("Adapter Found" + adapter.Name + " - " + adapter.Description);
            }

            //Load Quick Launch Menu

            Console("Loading Quick Launch Menu Settings");
            LoadMenuatStart();

            string strCurrentDirectory = Directory.GetCurrentDirectory();
            string strScriptsDirectory = strCurrentDirectory + "\\Scripts";
            string strDocsDirectory = strCurrentDirectory + "\\Documents";

            //enumerate scripts Quick Launch
            EnumerateScripts(strScriptsDirectory);

            //Enumerate Docs Quick Launch
            EnumerateDocs(strDocsDirectory);

            Console("Loading Customization Settings");
            //Load Settings Panel
            LoadShopSettings();

            //Load Tron Flags
            Console("Loading Previous Configuration Settings");
            PopulateTronCBs();
            Console("OS_HR");
            Console("END ONESTOP STARTUP");
            Console("OS_HR");
            #endregion
        }

        public void Console(string input)
        {
            if (input == "OS_GPL")
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
            else if (input == "OS_HR")
            {
                tb_Console.AppendText(Environment.NewLine + @"===========================================");
            }
            else if (input == "OS_BR")
            {
                tb_Console.AppendText(Environment.NewLine + Environment.NewLine);
            }
            else
            {
                tb_Console.AppendText(Environment.NewLine + input);
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
            catch (Exception)
            {
                Console("Exeption Thrown - Network Adapter Selection");
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
        private ToolStripLabel _lblOneStopStatus;
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
        private ToolStripMenuItem _connectivityToDefaultGatewayToolStripMenuItem;
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
        private TabPage _tpTestBrowser;
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
        private TabPage _tpQuickLaunche;
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
        private TabPage _tpShopSettings;
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
            this._lblOneStopStatus = new System.Windows.Forms.ToolStripLabel();
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
            this._connectivityToDefaultGatewayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this._tpTestBrowser = new System.Windows.Forms.TabPage();
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
            this._tpQuickLaunche = new System.Windows.Forms.TabPage();
            this._btnQlDeleteSelected = new System.Windows.Forms.Button();
            this._lbCurrentPrograms = new System.Windows.Forms.ListBox();
            this._lblQlMenuItemName = new System.Windows.Forms.Label();
            this._btnQlCreateNew = new System.Windows.Forms.Button();
            this._txtQlAppName = new System.Windows.Forms.TextBox();
            this._lblQlFolders = new System.Windows.Forms.Label();
            this._tpShopSettings = new System.Windows.Forms.TabPage();
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
            this.tb_Console = new System.Windows.Forms.TextBox();
            this._tsBottomToolbar.SuspendLayout();
            this._menuPrimary.SuspendLayout();
            this._tcPrimaryTabs.SuspendLayout();
            this._tpWelcome.SuspendLayout();
            this._tpOneStopMain.SuspendLayout();
            this._tpTronCli.SuspendLayout();
            this._tpTronSettings.SuspendLayout();
            this._tpLaunchTron.SuspendLayout();
            this._tpConfigurator.SuspendLayout();
            this._tcConfigurator.SuspendLayout();
            this._tpSetup.SuspendLayout();
            this._tabControl2.SuspendLayout();
            this._tpQuickLaunche.SuspendLayout();
            this._tpShopSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tsBottomToolbar
            // 
            this._tsBottomToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._tsBottomToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._pbCurrentProgress,
            this._toolStripSeparator1,
            this._lblCurrentActionStatus,
            this._lblOneStopStatus});
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
            this._lblCurrentActionStatus.Size = new System.Drawing.Size(132, 22);
            this._lblCurrentActionStatus.Text = "lbl_CurrentActionStatus";
            // 
            // _lblOneStopStatus
            // 
            this._lblOneStopStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._lblOneStopStatus.Name = "_lblOneStopStatus";
            this._lblOneStopStatus.Size = new System.Drawing.Size(103, 22);
            this._lblOneStopStatus.Text = "lbl_OneStopStatus";
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
            this._scriptsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this._scriptsToolStripMenuItem.Text = "Scripts";
            // 
            // _documentsToolStripMenuItem
            // 
            this._documentsToolStripMenuItem.Name = "_documentsToolStripMenuItem";
            this._documentsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this._documentsToolStripMenuItem.Text = "Documents";
            // 
            // _toolStripSeparator23
            // 
            this._toolStripSeparator23.Name = "_toolStripSeparator23";
            this._toolStripSeparator23.Size = new System.Drawing.Size(132, 6);
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
            this._quitToolStripMenuItem});
            this._oneStopToolStripMenuItem.Name = "_oneStopToolStripMenuItem";
            this._oneStopToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this._oneStopToolStripMenuItem.Text = "OneStop";
            // 
            // _startAtRunToolStripMenuItem
            // 
            this._startAtRunToolStripMenuItem.Name = "_startAtRunToolStripMenuItem";
            this._startAtRunToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this._startAtRunToolStripMenuItem.Text = "Start at Run";
            // 
            // _restartAsAdminToolStripMenuItem
            // 
            this._restartAsAdminToolStripMenuItem.Name = "_restartAsAdminToolStripMenuItem";
            this._restartAsAdminToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this._restartAsAdminToolStripMenuItem.Text = "Restart as Admin";
            // 
            // _toolStripSeparator2
            // 
            this._toolStripSeparator2.Name = "_toolStripSeparator2";
            this._toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // _oneStopSettingsToolStripMenuItem
            // 
            this._oneStopSettingsToolStripMenuItem.Name = "_oneStopSettingsToolStripMenuItem";
            this._oneStopSettingsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this._oneStopSettingsToolStripMenuItem.Text = "OneStop Settings";
            // 
            // _tRonToolStripMenuItem
            // 
            this._tRonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._foldersToolStripMenuItem,
            this._setConfigurationOptionsToolStripMenuItem,
            this._deployTronToNewLocationToolStripMenuItem});
            this._tRonToolStripMenuItem.Name = "_tRonToolStripMenuItem";
            this._tRonToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
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
            // 
            // _tempcleanToolStripMenuItem
            // 
            this._tempcleanToolStripMenuItem.Name = "_tempcleanToolStripMenuItem";
            this._tempcleanToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._tempcleanToolStripMenuItem.Text = "1 - Tempclean";
            // 
            // _dToolStripMenuItem
            // 
            this._dToolStripMenuItem.Name = "_dToolStripMenuItem";
            this._dToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._dToolStripMenuItem.Text = "2 - Debloat";
            // 
            // _disinfectToolStripMenuItem
            // 
            this._disinfectToolStripMenuItem.Name = "_disinfectToolStripMenuItem";
            this._disinfectToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._disinfectToolStripMenuItem.Text = "3 - Disinfect";
            // 
            // _repairToolStripMenuItem
            // 
            this._repairToolStripMenuItem.Name = "_repairToolStripMenuItem";
            this._repairToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._repairToolStripMenuItem.Text = "4 - Repair";
            // 
            // _patchToolStripMenuItem
            // 
            this._patchToolStripMenuItem.Name = "_patchToolStripMenuItem";
            this._patchToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._patchToolStripMenuItem.Text = "5 - Patch";
            // 
            // _optimizeToolStripMenuItem
            // 
            this._optimizeToolStripMenuItem.Name = "_optimizeToolStripMenuItem";
            this._optimizeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._optimizeToolStripMenuItem.Text = "6 - Optimize";
            // 
            // _wrapUpToolStripMenuItem
            // 
            this._wrapUpToolStripMenuItem.Name = "_wrapUpToolStripMenuItem";
            this._wrapUpToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._wrapUpToolStripMenuItem.Text = "7 - Wrap-Up";
            // 
            // _manualToolsToolStripMenuItem
            // 
            this._manualToolsToolStripMenuItem.Name = "_manualToolsToolStripMenuItem";
            this._manualToolsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this._manualToolsToolStripMenuItem.Text = "8 - Manual Tools";
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
            this._toolStripSeparator22.Size = new System.Drawing.Size(162, 6);
            // 
            // _quitToolStripMenuItem
            // 
            this._quitToolStripMenuItem.Name = "_quitToolStripMenuItem";
            this._quitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
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
            this._openRouterInterfaceToolStripMenuItem,
            this._dNsSettingsToolStripMenuItem,
            this._resetNetworkSettingsToDefaultsAndClearAllCachesToolStripMenuItem,
            this._toolStripSeparator6,
            this._firewallToolStripMenuItem,
            this._groupPolicyToolStripMenuItem,
            this._toolStripSeparator8,
            this._connectivityToHttpwwwgooglecomToolStripMenuItem,
            this._connectivityToDefaultGatewayToolStripMenuItem,
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
            // _connectivityToDefaultGatewayToolStripMenuItem
            // 
            this._connectivityToDefaultGatewayToolStripMenuItem.Name = "_connectivityToDefaultGatewayToolStripMenuItem";
            this._connectivityToDefaultGatewayToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this._connectivityToDefaultGatewayToolStripMenuItem.Text = "Show all IP Info";
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
            // 
            // _rTronScriptToolStripMenuItem
            // 
            this._rTronScriptToolStripMenuItem.Name = "_rTronScriptToolStripMenuItem";
            this._rTronScriptToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this._rTronScriptToolStripMenuItem.Text = "/r/TronScript";
            // 
            // _ninitecomToolStripMenuItem
            // 
            this._ninitecomToolStripMenuItem.Name = "_ninitecomToolStripMenuItem";
            this._ninitecomToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this._ninitecomToolStripMenuItem.Text = "Ninite.com";
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
            // 
            // _geGeekToolStripMenuItem
            // 
            this._geGeekToolStripMenuItem.Name = "_geGeekToolStripMenuItem";
            this._geGeekToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this._geGeekToolStripMenuItem.Text = "GeGeek";
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
            // 
            // _speedtestnetToolStripMenuItem
            // 
            this._speedtestnetToolStripMenuItem.Name = "_speedtestnetToolStripMenuItem";
            this._speedtestnetToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._speedtestnetToolStripMenuItem.Text = "Speedtest.net";
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
            // 
            // _qualysBrowsercheckToolStripMenuItem
            // 
            this._qualysBrowsercheckToolStripMenuItem.Name = "_qualysBrowsercheckToolStripMenuItem";
            this._qualysBrowsercheckToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._qualysBrowsercheckToolStripMenuItem.Text = "Qualys Browsercheck";
            // 
            // _firefoxOfficialPluginTestToolStripMenuItem
            // 
            this._firefoxOfficialPluginTestToolStripMenuItem.Name = "_firefoxOfficialPluginTestToolStripMenuItem";
            this._firefoxOfficialPluginTestToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._firefoxOfficialPluginTestToolStripMenuItem.Text = "Firefox Official Plugin Test";
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
            // 
            // _flashbubblemarkcomToolStripMenuItem
            // 
            this._flashbubblemarkcomToolStripMenuItem.Name = "_flashbubblemarkcomToolStripMenuItem";
            this._flashbubblemarkcomToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._flashbubblemarkcomToolStripMenuItem.Text = "Flash (bubblemark.com)";
            // 
            // _javajavatesterorgToolStripMenuItem
            // 
            this._javajavatesterorgToolStripMenuItem.Name = "_javajavatesterorgToolStripMenuItem";
            this._javajavatesterorgToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._javajavatesterorgToolStripMenuItem.Text = "Java (javatester.org)";
            // 
            // _shockwaveadobecomToolStripMenuItem
            // 
            this._shockwaveadobecomToolStripMenuItem.Name = "_shockwaveadobecomToolStripMenuItem";
            this._shockwaveadobecomToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._shockwaveadobecomToolStripMenuItem.Text = "Shockwave (adobe.com)";
            // 
            // _sSLssllabscomToolStripMenuItem
            // 
            this._sSLssllabscomToolStripMenuItem.Name = "_sSLssllabscomToolStripMenuItem";
            this._sSLssllabscomToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._sSLssllabscomToolStripMenuItem.Text = "SSL (ssllabs.com)";
            // 
            // _shieldsUpToolStripMenuItem
            // 
            this._shieldsUpToolStripMenuItem.Name = "_shieldsUpToolStripMenuItem";
            this._shieldsUpToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this._shieldsUpToolStripMenuItem.Text = "ShieldsUP!";
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
            // 
            // _aVgToolStripMenuItem
            // 
            this._aVgToolStripMenuItem.Name = "_aVgToolStripMenuItem";
            this._aVgToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._aVgToolStripMenuItem.Text = "AVG";
            // 
            // _aviraToolStripMenuItem
            // 
            this._aviraToolStripMenuItem.Name = "_aviraToolStripMenuItem";
            this._aviraToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._aviraToolStripMenuItem.Text = "Avira";
            // 
            // _comodoToolStripMenuItem
            // 
            this._comodoToolStripMenuItem.Name = "_comodoToolStripMenuItem";
            this._comodoToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._comodoToolStripMenuItem.Text = "Comodo";
            // 
            // _fSecureToolStripMenuItem
            // 
            this._fSecureToolStripMenuItem.Name = "_fSecureToolStripMenuItem";
            this._fSecureToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._fSecureToolStripMenuItem.Text = "F-Secure";
            // 
            // _kasperskyToolStripMenuItem
            // 
            this._kasperskyToolStripMenuItem.Name = "_kasperskyToolStripMenuItem";
            this._kasperskyToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._kasperskyToolStripMenuItem.Text = "Kaspersky";
            // 
            // _mcAffeToolStripMenuItem
            // 
            this._mcAffeToolStripMenuItem.Name = "_mcAffeToolStripMenuItem";
            this._mcAffeToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._mcAffeToolStripMenuItem.Text = "McAffe";
            // 
            // _nOd32ToolStripMenuItem
            // 
            this._nOd32ToolStripMenuItem.Name = "_nOd32ToolStripMenuItem";
            this._nOd32ToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._nOd32ToolStripMenuItem.Text = "NOD32";
            // 
            // _nortonToolStripMenuItem
            // 
            this._nortonToolStripMenuItem.Name = "_nortonToolStripMenuItem";
            this._nortonToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._nortonToolStripMenuItem.Text = "Norton";
            // 
            // _nortonSecurityScanToolStripMenuItem
            // 
            this._nortonSecurityScanToolStripMenuItem.Name = "_nortonSecurityScanToolStripMenuItem";
            this._nortonSecurityScanToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._nortonSecurityScanToolStripMenuItem.Text = "Norton Security Scan";
            // 
            // _pandaToolStripMenuItem
            // 
            this._pandaToolStripMenuItem.Name = "_pandaToolStripMenuItem";
            this._pandaToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._pandaToolStripMenuItem.Text = "Panda";
            // 
            // _sophosToolStripMenuItem
            // 
            this._sophosToolStripMenuItem.Name = "_sophosToolStripMenuItem";
            this._sophosToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._sophosToolStripMenuItem.Text = "Sophos";
            // 
            // _windowsSecurityEssentialsToolStripMenuItem
            // 
            this._windowsSecurityEssentialsToolStripMenuItem.Name = "_windowsSecurityEssentialsToolStripMenuItem";
            this._windowsSecurityEssentialsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this._windowsSecurityEssentialsToolStripMenuItem.Text = "Windows Security Essentials";
            // 
            // _powerToolStripMenuItem
            // 
            this._powerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._forceShutdownToolStripMenuItem,
            this._forceRestartToolStripMenuItem,
            this._forceLogoffToolStripMenuItem,
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
            // 
            // _forceRestartToolStripMenuItem
            // 
            this._forceRestartToolStripMenuItem.Name = "_forceRestartToolStripMenuItem";
            this._forceRestartToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._forceRestartToolStripMenuItem.Text = "Force Restart";
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
            // 
            // _disableF8ToolStripMenuItem
            // 
            this._disableF8ToolStripMenuItem.Name = "_disableF8ToolStripMenuItem";
            this._disableF8ToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._disableF8ToolStripMenuItem.Text = "Disable F8 Menu";
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
            // 
            // _setSafemodeSwitchOnNetworkingToolStripMenuItem
            // 
            this._setSafemodeSwitchOnNetworkingToolStripMenuItem.Name = "_setSafemodeSwitchOnNetworkingToolStripMenuItem";
            this._setSafemodeSwitchOnNetworkingToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._setSafemodeSwitchOnNetworkingToolStripMenuItem.Text = "Set Safemode Switch = On + Networking";
            // 
            // _setSafemodeSwitchOnMinimalToolStripMenuItem
            // 
            this._setSafemodeSwitchOnMinimalToolStripMenuItem.Name = "_setSafemodeSwitchOnMinimalToolStripMenuItem";
            this._setSafemodeSwitchOnMinimalToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._setSafemodeSwitchOnMinimalToolStripMenuItem.Text = "Set Safemode Switch = On (Minimal)";
            // 
            // _setSafemodeSwitchOnAltShellToolStripMenuItem
            // 
            this._setSafemodeSwitchOnAltShellToolStripMenuItem.Name = "_setSafemodeSwitchOnAltShellToolStripMenuItem";
            this._setSafemodeSwitchOnAltShellToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._setSafemodeSwitchOnAltShellToolStripMenuItem.Text = "Set Safemode Switch = On (Alt. Shell)";
            // 
            // _setSafemodeSwtichOffNormalBootToolStripMenuItem
            // 
            this._setSafemodeSwtichOffNormalBootToolStripMenuItem.Name = "_setSafemodeSwtichOffNormalBootToolStripMenuItem";
            this._setSafemodeSwtichOffNormalBootToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._setSafemodeSwtichOffNormalBootToolStripMenuItem.Text = "Set Safemode Swtich = Off (Normal Boot)";
            // 
            // _enumerateCurrentModeToolStripMenuItem
            // 
            this._enumerateCurrentModeToolStripMenuItem.Name = "_enumerateCurrentModeToolStripMenuItem";
            this._enumerateCurrentModeToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._enumerateCurrentModeToolStripMenuItem.Text = "Enumerate Current Mode";
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
            // 
            // _hybridShutdownFastStartUpToolStripMenuItem
            // 
            this._hybridShutdownFastStartUpToolStripMenuItem.Name = "_hybridShutdownFastStartUpToolStripMenuItem";
            this._hybridShutdownFastStartUpToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._hybridShutdownFastStartUpToolStripMenuItem.Text = "Hybrid (Shutdown + Fast Start Up)";
            // 
            // _shutdownWithOptionsToolStripMenuItem
            // 
            this._shutdownWithOptionsToolStripMenuItem.Name = "_shutdownWithOptionsToolStripMenuItem";
            this._shutdownWithOptionsToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this._shutdownWithOptionsToolStripMenuItem.Text = "Shutdown With Options";
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
            this._tcPrimaryTabs.Controls.Add(this._tpTestBrowser);
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
            this._tpWelcome.Controls.Add(this.tb_Console);
            this._tpWelcome.Location = new System.Drawing.Point(4, 22);
            this._tpWelcome.Name = "_tpWelcome";
            this._tpWelcome.Padding = new System.Windows.Forms.Padding(3);
            this._tpWelcome.Size = new System.Drawing.Size(746, 391);
            this._tpWelcome.TabIndex = 10;
            this._tpWelcome.Text = "Welcome";
            this._tpWelcome.UseVisualStyleBackColor = true;
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
            this._lblOsmExecuteOrder.Location = new System.Drawing.Point(471, 10);
            this._lblOsmExecuteOrder.Name = "_lblOsmExecuteOrder";
            this._lblOsmExecuteOrder.Size = new System.Drawing.Size(98, 15);
            this._lblOsmExecuteOrder.TabIndex = 7;
            this._lblOsmExecuteOrder.Text = "Execute Order";
            // 
            // _lblOsmProgramSelect
            // 
            this._lblOsmProgramSelect.AutoSize = true;
            this._lblOsmProgramSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOsmProgramSelect.Location = new System.Drawing.Point(239, 11);
            this._lblOsmProgramSelect.Name = "_lblOsmProgramSelect";
            this._lblOsmProgramSelect.Size = new System.Drawing.Size(106, 15);
            this._lblOsmProgramSelect.TabIndex = 6;
            this._lblOsmProgramSelect.Text = "Program Select";
            // 
            // _lblOsmCategories
            // 
            this._lblOsmCategories.AutoSize = true;
            this._lblOsmCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOsmCategories.Location = new System.Drawing.Point(4, 10);
            this._lblOsmCategories.Name = "_lblOsmCategories";
            this._lblOsmCategories.Size = new System.Drawing.Size(135, 15);
            this._lblOsmCategories.TabIndex = 5;
            this._lblOsmCategories.Text = "Program Categories";
            // 
            // _button2
            // 
            this._button2.Location = new System.Drawing.Point(479, 273);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(189, 23);
            this._button2.TabIndex = 4;
            this._button2.Text = "Execute All";
            this._button2.UseVisualStyleBackColor = true;
            // 
            // _button1
            // 
            this._button1.Location = new System.Drawing.Point(247, 274);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(189, 23);
            this._button1.TabIndex = 3;
            this._button1.Text = "Add to Queue";
            this._button1.UseVisualStyleBackColor = true;
            // 
            // _listBox3
            // 
            this._listBox3.FormattingEnabled = true;
            this._listBox3.Location = new System.Drawing.Point(479, 29);
            this._listBox3.Name = "_listBox3";
            this._listBox3.Size = new System.Drawing.Size(189, 238);
            this._listBox3.TabIndex = 2;
            // 
            // _listBox2
            // 
            this._listBox2.FormattingEnabled = true;
            this._listBox2.Location = new System.Drawing.Point(247, 29);
            this._listBox2.Name = "_listBox2";
            this._listBox2.Size = new System.Drawing.Size(189, 238);
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
            this._lbOsmCategories.Location = new System.Drawing.Point(12, 29);
            this._lbOsmCategories.Name = "_lbOsmCategories";
            this._lbOsmCategories.Size = new System.Drawing.Size(189, 277);
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
            this._btnTronSaveFlags.Location = new System.Drawing.Point(579, 300);
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
            this._cbTronE.Location = new System.Drawing.Point(6, 71);
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
            this._cbTronDev.Location = new System.Drawing.Point(4, 281);
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
            this._btnConfigDump.Location = new System.Drawing.Point(579, 117);
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
            this._btnDryRun.Location = new System.Drawing.Point(579, 146);
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
            this._btnRunTron.Location = new System.Drawing.Point(579, 175);
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
            this._cbTronStr.Location = new System.Drawing.Point(259, 327);
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
            this._cbTronSs.Location = new System.Drawing.Point(259, 304);
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
            this._cbTronSrr.Location = new System.Drawing.Point(259, 281);
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
            this._cbTronSfr.Location = new System.Drawing.Point(259, 211);
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
            this._cbTronSm.Location = new System.Drawing.Point(259, 258);
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
            this._cbTronSdc.Location = new System.Drawing.Point(259, 187);
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
            this._cbTronSk.Location = new System.Drawing.Point(259, 234);
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
            this._cbTronSpr.Location = new System.Drawing.Point(259, 164);
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
            this._cbTronSw.Location = new System.Drawing.Point(259, 141);
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
            this._cbTronSe.Location = new System.Drawing.Point(259, 118);
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
            this._cbTronP.Location = new System.Drawing.Point(6, 119);
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
            this._btnClear.Location = new System.Drawing.Point(579, 330);
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
            this._cbTronEr.Location = new System.Drawing.Point(6, 48);
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
            this._cbTronSb.Location = new System.Drawing.Point(259, 48);
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
            this._cbTronM.Location = new System.Drawing.Point(6, 327);
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
            this._cbTronX.Location = new System.Drawing.Point(4, 258);
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
            this._cbTronO.Location = new System.Drawing.Point(6, 141);
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
            this._cbTronV.Location = new System.Drawing.Point(4, 235);
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
            this._cbTronR.Location = new System.Drawing.Point(6, 163);
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
            this._cbTronSp.Location = new System.Drawing.Point(259, 95);
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
            this._cbTronSa.Location = new System.Drawing.Point(259, 24);
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
            this._cbTronSd.Location = new System.Drawing.Point(259, 71);
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
            this._tpSystemInfo.Location = new System.Drawing.Point(4, 22);
            this._tpSystemInfo.Name = "_tpSystemInfo";
            this._tpSystemInfo.Size = new System.Drawing.Size(746, 391);
            this._tpSystemInfo.TabIndex = 3;
            this._tpSystemInfo.Text = "System Info";
            this._tpSystemInfo.UseVisualStyleBackColor = true;
            // 
            // _tpTestBrowser
            // 
            this._tpTestBrowser.Location = new System.Drawing.Point(4, 22);
            this._tpTestBrowser.Name = "_tpTestBrowser";
            this._tpTestBrowser.Size = new System.Drawing.Size(746, 391);
            this._tpTestBrowser.TabIndex = 4;
            this._tpTestBrowser.Text = "Test Browser";
            this._tpTestBrowser.UseVisualStyleBackColor = true;
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
            this._tpConfigurator.Text = "Configurator";
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
            this._tabControl2.Controls.Add(this._tpQuickLaunche);
            this._tabControl2.Controls.Add(this._tpShopSettings);
            this._tabControl2.Location = new System.Drawing.Point(0, 3);
            this._tabControl2.Name = "_tabControl2";
            this._tabControl2.SelectedIndex = 0;
            this._tabControl2.Size = new System.Drawing.Size(746, 392);
            this._tabControl2.TabIndex = 0;
            // 
            // _tpQuickLaunche
            // 
            this._tpQuickLaunche.Controls.Add(this._btnQlDeleteSelected);
            this._tpQuickLaunche.Controls.Add(this._lbCurrentPrograms);
            this._tpQuickLaunche.Controls.Add(this._lblQlMenuItemName);
            this._tpQuickLaunche.Controls.Add(this._btnQlCreateNew);
            this._tpQuickLaunche.Controls.Add(this._txtQlAppName);
            this._tpQuickLaunche.Controls.Add(this._lblQlFolders);
            this._tpQuickLaunche.Location = new System.Drawing.Point(4, 22);
            this._tpQuickLaunche.Name = "_tpQuickLaunche";
            this._tpQuickLaunche.Padding = new System.Windows.Forms.Padding(3);
            this._tpQuickLaunche.Size = new System.Drawing.Size(738, 366);
            this._tpQuickLaunche.TabIndex = 0;
            this._tpQuickLaunche.Text = "Quick Launch";
            this._tpQuickLaunche.UseVisualStyleBackColor = true;
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
            this._lblQlMenuItemName.Location = new System.Drawing.Point(8, 59);
            this._lblQlMenuItemName.Name = "_lblQlMenuItemName";
            this._lblQlMenuItemName.Size = new System.Drawing.Size(91, 13);
            this._lblQlMenuItemName.TabIndex = 3;
            this._lblQlMenuItemName.Text = "Menu Item Name:";
            // 
            // _btnQlCreateNew
            // 
            this._btnQlCreateNew.Location = new System.Drawing.Point(11, 105);
            this._btnQlCreateNew.Name = "_btnQlCreateNew";
            this._btnQlCreateNew.Size = new System.Drawing.Size(224, 23);
            this._btnQlCreateNew.TabIndex = 2;
            this._btnQlCreateNew.Text = "Create New QL Item";
            this._btnQlCreateNew.UseVisualStyleBackColor = true;
            this._btnQlCreateNew.Click += new System.EventHandler(this.btn_QL_CreateNew_Click);
            // 
            // _txtQlAppName
            // 
            this._txtQlAppName.Location = new System.Drawing.Point(11, 75);
            this._txtQlAppName.Name = "_txtQlAppName";
            this._txtQlAppName.Size = new System.Drawing.Size(224, 20);
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
            // _tpShopSettings
            // 
            this._tpShopSettings.Controls.Add(this._btnShopSetSave);
            this._tpShopSettings.Controls.Add(this._lblShopSetState);
            this._tpShopSettings.Controls.Add(this._tbShopSetState);
            this._tpShopSettings.Controls.Add(this._lblShopSetCity);
            this._tpShopSettings.Controls.Add(this._tbShopSetCity);
            this._tpShopSettings.Controls.Add(this._lblShopSetEmail);
            this._tpShopSettings.Controls.Add(this._tbShopSetEmail);
            this._tpShopSettings.Controls.Add(this._lblShopSetPhone);
            this._tpShopSettings.Controls.Add(this._tbShopSetPhone);
            this._tpShopSettings.Controls.Add(this._tbShopSetAddr2);
            this._tpShopSettings.Controls.Add(this._lblShopSetAddr);
            this._tpShopSettings.Controls.Add(this._tbShopSetAddr1);
            this._tpShopSettings.Controls.Add(this._lblShopSetShopname);
            this._tpShopSettings.Controls.Add(this._tbShopSetName);
            this._tpShopSettings.Location = new System.Drawing.Point(4, 22);
            this._tpShopSettings.Name = "_tpShopSettings";
            this._tpShopSettings.Size = new System.Drawing.Size(738, 366);
            this._tpShopSettings.TabIndex = 1;
            this._tpShopSettings.Text = "Shop Settings";
            this._tpShopSettings.UseVisualStyleBackColor = true;
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
            this._lnkInfoInternalIp.Location = new System.Drawing.Point(619, 39);
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
            this._lblInfoExternalIp.Location = new System.Drawing.Point(415, 73);
            this._lblInfoExternalIp.Name = "_lblInfoExternalIp";
            this._lblInfoExternalIp.Size = new System.Drawing.Size(94, 13);
            this._lblInfoExternalIp.TabIndex = 67;
            this._lblInfoExternalIp.Text = "lbl_info_ExternalIP";
            // 
            // _lnkInfoGateway
            // 
            this._lnkInfoGateway.AutoSize = true;
            this._lnkInfoGateway.Location = new System.Drawing.Point(619, 56);
            this._lnkInfoGateway.Name = "_lnkInfoGateway";
            this._lnkInfoGateway.Size = new System.Drawing.Size(92, 13);
            this._lnkInfoGateway.TabIndex = 66;
            this._lnkInfoGateway.TabStop = true;
            this._lnkInfoGateway.Text = "lnk_info_Gateway";
            // 
            // _lnkInfoPrimDns
            // 
            this._lnkInfoPrimDns.AutoSize = true;
            this._lnkInfoPrimDns.Location = new System.Drawing.Point(619, 73);
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
            this._lblDns.Location = new System.Drawing.Point(576, 73);
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
            this._lblGateway.Location = new System.Drawing.Point(553, 56);
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
            this._lblExternalIp.Location = new System.Drawing.Point(336, 73);
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
            this._lblInternalIp.Location = new System.Drawing.Point(543, 40);
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
            this._ddlInfoNetworkAdapters.Location = new System.Drawing.Point(337, 31);
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
            this._label1.Location = new System.Drawing.Point(334, 56);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(75, 13);
            this._label1.TabIndex = 70;
            this._label1.Text = "Description:";
            // 
            // _lblInfoAdapterDesc
            // 
            this._lblInfoAdapterDesc.AutoSize = true;
            this._lblInfoAdapterDesc.BackColor = System.Drawing.SystemColors.Control;
            this._lblInfoAdapterDesc.Location = new System.Drawing.Point(415, 58);
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
            // tb_Console
            // 
            this.tb_Console.Location = new System.Drawing.Point(353, 6);
            this.tb_Console.Multiline = true;
            this.tb_Console.Name = "tb_Console";
            this.tb_Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Console.Size = new System.Drawing.Size(385, 379);
            this.tb_Console.TabIndex = 0;
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
            this._tpConfigurator.ResumeLayout(false);
            this._tcConfigurator.ResumeLayout(false);
            this._tpSetup.ResumeLayout(false);
            this._tabControl2.ResumeLayout(false);
            this._tpQuickLaunche.ResumeLayout(false);
            this._tpQuickLaunche.PerformLayout();
            this._tpShopSettings.ResumeLayout(false);
            this._tpShopSettings.PerformLayout();
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

            string strAdminStatus = BoolAdminStatus ? "ADMIN" : "NOT ADMIN";
            
            _lblOneStopStatus.Text = StrTronStatus + strAdminStatus;
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
                    Console("Scripts Directory Does not Exist");
                }
            }
            catch (UnauthorizedAccessException uaEx)
            {
                Console("Exeption Thrown: Enumerating Scripts Directory - " + uaEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                Console("Exeption Thrown: Enumerating Scripts Directory - " + pathEx.Message);
            }
            catch
            {
                Console("Exeption Thrown: Enumerating Scripts Directory - Unknown");
            }
        }

        private void EnumerateDocs(string strDocsDirectory)
        {
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
                    Console("Scripts Directory Does not Exist");
                }
            }
            catch (UnauthorizedAccessException uaEx)
            {
                Console("Exeption Thrown: Enumerating Documents Directory -" + uaEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                Console("Exeption Thrown: Enumerating Documents Directory -" + pathEx.Message);
            }
            catch
            {
                Console("Exeption Thrown: Enumerating Documents Directory - Unknown");
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
    }
}