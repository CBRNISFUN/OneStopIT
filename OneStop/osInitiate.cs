using System.ComponentModel;
using System.Windows.Forms;

namespace OneStop
{
    public class osInitiate
    {
        private OsMain _osMain;
        private ToolStrip _tsBottomToolbar;
        private ToolStripProgressBar _pbCurrentProgress;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripLabel _lblCurrentActionStatus;
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
        private Button _btnClear;
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
        private Label _lblDns;
        private Label _lblGateway;
        private Label _lblExternalIp;
        private Label _lblInternalIp;
        private Label _lblFreeC;
        private Label _lblRam;
        private Label _lblOs;
        private Label _lblComputerName;
        private ToolStripSeparator _toolStripSeparator23;
        private TabPage _tpSetup;
        private TabControl _tabControl2;
        private TabPage _tpQuickLaunche;
        private Label _lblQlMenuItemName;
        private Button _btnQlCreateNew;
        private Label _lblQlFolders;
        private ContextMenuStrip _cmsDeleteQl;
        private IContainer components;
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
        private Label _label1;
        private TabPage _tpShopSettings;
        private Button _btnShopSetSave;
        private Label _lblShopSetState;
        private Label _lblShopSetCity;
        private Label _lblShopSetEmail;
        private Label _lblShopSetPhone;
        private Label _lblShopSetAddr;
        private Label _lblShopSetShopname;
        private TabPage _tpOem;

        public osInitiate(OsMain osMain)
        {
            InitializeComponent();
            _osMain = osMain;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._tsBottomToolbar = new System.Windows.Forms.ToolStrip();
            this._pbCurrentProgress = new System.Windows.Forms.ToolStripProgressBar();
            this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._lblCurrentActionStatus = new System.Windows.Forms.ToolStripLabel();
            _osMain._lblOneStopStatus = new System.Windows.Forms.ToolStripLabel();
            this._menuPrimary = new System.Windows.Forms.MenuStrip();
            _osMain._qlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _osMain._scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _osMain._documentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this._oneStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._startAtRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._restartAsAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._oneStopSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._tRonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _osMain._foldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            _osMain._btnTronSaveFlags = new System.Windows.Forms.Button();
            _osMain._cbTronE = new System.Windows.Forms.CheckBox();
            _osMain._cbTronDev = new System.Windows.Forms.CheckBox();
            this._btnLocateTron = new System.Windows.Forms.Button();
            this._btnDeploytofolder = new System.Windows.Forms.Button();
            _osMain._btnConfigDump = new System.Windows.Forms.Button();
            _osMain._btnDryRun = new System.Windows.Forms.Button();
            _osMain._btnRunTron = new System.Windows.Forms.Button();
            _osMain._cbTronStr = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSs = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSrr = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSfr = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSm = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSdc = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSk = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSpr = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSw = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSe = new System.Windows.Forms.CheckBox();
            _osMain._cbTronP = new System.Windows.Forms.CheckBox();
            this._btnClear = new System.Windows.Forms.Button();
            _osMain._cbTronEr = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSb = new System.Windows.Forms.CheckBox();
            _osMain._cbTronM = new System.Windows.Forms.CheckBox();
            _osMain._cbTronX = new System.Windows.Forms.CheckBox();
            _osMain._cbTronO = new System.Windows.Forms.CheckBox();
            _osMain._cbTronV = new System.Windows.Forms.CheckBox();
            _osMain._cbTronR = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSp = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSa = new System.Windows.Forms.CheckBox();
            _osMain._cbTronSd = new System.Windows.Forms.CheckBox();
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
            _osMain._lbCurrentPrograms = new System.Windows.Forms.ListBox();
            this._lblQlMenuItemName = new System.Windows.Forms.Label();
            this._btnQlCreateNew = new System.Windows.Forms.Button();
            _osMain._txtQlAppName = new System.Windows.Forms.TextBox();
            this._lblQlFolders = new System.Windows.Forms.Label();
            this._tpShopSettings = new System.Windows.Forms.TabPage();
            this._btnShopSetSave = new System.Windows.Forms.Button();
            this._lblShopSetState = new System.Windows.Forms.Label();
            _osMain._tbShopSetState = new System.Windows.Forms.TextBox();
            this._lblShopSetCity = new System.Windows.Forms.Label();
            _osMain._tbShopSetCity = new System.Windows.Forms.TextBox();
            this._lblShopSetEmail = new System.Windows.Forms.Label();
            _osMain._tbShopSetEmail = new System.Windows.Forms.TextBox();
            this._lblShopSetPhone = new System.Windows.Forms.Label();
            _osMain._tbShopSetPhone = new System.Windows.Forms.TextBox();
            _osMain._tbShopSetAddr2 = new System.Windows.Forms.TextBox();
            this._lblShopSetAddr = new System.Windows.Forms.Label();
            _osMain._tbShopSetAddr1 = new System.Windows.Forms.TextBox();
            this._lblShopSetShopname = new System.Windows.Forms.Label();
            _osMain._tbShopSetName = new System.Windows.Forms.TextBox();
            _osMain._lnkInfoInternalIp = new System.Windows.Forms.LinkLabel();
            _osMain._lblInfoExternalIp = new System.Windows.Forms.Label();
            _osMain._lnkInfoGateway = new System.Windows.Forms.LinkLabel();
            _osMain._lnkInfoPrimDns = new System.Windows.Forms.LinkLabel();
            this._lblDns = new System.Windows.Forms.Label();
            this._lblGateway = new System.Windows.Forms.Label();
            this._lblExternalIp = new System.Windows.Forms.Label();
            this._lblInternalIp = new System.Windows.Forms.Label();
            this._lblFreeC = new System.Windows.Forms.Label();
            _osMain._lblInfoFreeC = new System.Windows.Forms.Label();
            this._lblRam = new System.Windows.Forms.Label();
            _osMain._lblInfoRam = new System.Windows.Forms.Label();
            this._lblOs = new System.Windows.Forms.Label();
            this._lblComputerName = new System.Windows.Forms.Label();
            _osMain._lblInfoOs = new System.Windows.Forms.Label();
            _osMain._lblInfoComputerName = new System.Windows.Forms.Label();
            _osMain._ofdMenuItem = new System.Windows.Forms.OpenFileDialog();
            this._cmsDeleteQl = new System.Windows.Forms.ContextMenuStrip(this.components);
            _osMain._ddlInfoNetworkAdapters = new System.Windows.Forms.ComboBox();
            this._label1 = new System.Windows.Forms.Label();
            _osMain._lblInfoAdapterDesc = new System.Windows.Forms.Label();
            _osMain._ofdTron = new System.Windows.Forms.OpenFileDialog();
            this._tsBottomToolbar.SuspendLayout();
            this._menuPrimary.SuspendLayout();
            this._tcPrimaryTabs.SuspendLayout();
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
            _osMain.SuspendLayout();
            // 
            // _tsBottomToolbar
            // 
            this._tsBottomToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._tsBottomToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this._pbCurrentProgress,
                this._toolStripSeparator1,
                this._lblCurrentActionStatus,
                _osMain._lblOneStopStatus});
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
            _osMain._lblOneStopStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            _osMain._lblOneStopStatus.Name = "_lblOneStopStatus";
            _osMain._lblOneStopStatus.Size = new System.Drawing.Size(103, 22);
            _osMain._lblOneStopStatus.Text = "lbl_OneStopStatus";
            // 
            // _menuPrimary
            // 
            this._menuPrimary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                _osMain._qlToolStripMenuItem,
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
            _osMain._qlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                _osMain._scriptsToolStripMenuItem,
                _osMain._documentsToolStripMenuItem,
                this._toolStripSeparator23});
            _osMain._qlToolStripMenuItem.Name = "_qlToolStripMenuItem";
            _osMain._qlToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            _osMain._qlToolStripMenuItem.Text = "QL";
            // 
            // _scriptsToolStripMenuItem
            // 
            _osMain._scriptsToolStripMenuItem.Name = "_scriptsToolStripMenuItem";
            _osMain._scriptsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            _osMain._scriptsToolStripMenuItem.Text = "Scripts";
            // 
            // _documentsToolStripMenuItem
            // 
            _osMain._documentsToolStripMenuItem.Name = "_documentsToolStripMenuItem";
            _osMain._documentsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            _osMain._documentsToolStripMenuItem.Text = "Documents";
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
                _osMain._foldersToolStripMenuItem,
                this._setConfigurationOptionsToolStripMenuItem,
                this._deployTronToNewLocationToolStripMenuItem});
            this._tRonToolStripMenuItem.Name = "_tRonToolStripMenuItem";
            this._tRonToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this._tRonToolStripMenuItem.Text = "TRON Settings";
            // 
            // _foldersToolStripMenuItem
            // 
            _osMain._foldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this._prepToolStripMenuItem,
                this._tempcleanToolStripMenuItem,
                this._dToolStripMenuItem,
                this._disinfectToolStripMenuItem,
                this._repairToolStripMenuItem,
                this._patchToolStripMenuItem,
                this._optimizeToolStripMenuItem,
                this._wrapUpToolStripMenuItem,
                this._manualToolsToolStripMenuItem});
            _osMain._foldersToolStripMenuItem.Name = "_foldersToolStripMenuItem";
            _osMain._foldersToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            _osMain._foldersToolStripMenuItem.Text = "Folders";
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
            this._tpLaunchTron.Controls.Add(_osMain._btnTronSaveFlags);
            this._tpLaunchTron.Controls.Add(_osMain._cbTronE);
            this._tpLaunchTron.Controls.Add(_osMain._cbTronDev);
            this._tpLaunchTron.Controls.Add(this._btnLocateTron);
            _tpLaunchTron.Controls.Add(_btnDeploytofolder);
            _tpLaunchTron.Controls.Add(_osMain._btnConfigDump);
            _tpLaunchTron.Controls.Add(_osMain._btnDryRun);
            _tpLaunchTron.Controls.Add(_osMain._btnRunTron);
            _tpLaunchTron.Controls.Add(_osMain._cbTronStr);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSs);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSrr);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSfr);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSm);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSdc);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSk);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSpr);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSw);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSe);
            _tpLaunchTron.Controls.Add(_osMain._cbTronP);
            _tpLaunchTron.Controls.Add(_btnClear);
            _tpLaunchTron.Controls.Add(_osMain._cbTronEr);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSb);
            _tpLaunchTron.Controls.Add(_osMain._cbTronM);
            _tpLaunchTron.Controls.Add(_osMain._cbTronX);
            _tpLaunchTron.Controls.Add(_osMain._cbTronO);
            _tpLaunchTron.Controls.Add(_osMain._cbTronV);
            _tpLaunchTron.Controls.Add(_osMain._cbTronR);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSp);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSa);
            _tpLaunchTron.Controls.Add(_osMain._cbTronSd);
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
            _osMain._btnTronSaveFlags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            _osMain._btnTronSaveFlags.Enabled = false;
            _osMain._btnTronSaveFlags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _osMain._btnTronSaveFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _osMain._btnTronSaveFlags.Location = new System.Drawing.Point(579, 300);
            _osMain._btnTronSaveFlags.Name = "_btnTronSaveFlags";
            _osMain._btnTronSaveFlags.Size = new System.Drawing.Size(140, 23);
            _osMain._btnTronSaveFlags.TabIndex = 84;
            _osMain._btnTronSaveFlags.Text = "Save All Flags";
            _osMain._btnTronSaveFlags.UseVisualStyleBackColor = false;
            // 
            // _cbTronE
            // 
            _osMain._cbTronE.AutoSize = true;
            _osMain._cbTronE.Location = new System.Drawing.Point(6, 71);
            _osMain._cbTronE.Name = "_cbTronE";
            _osMain._cbTronE.Size = new System.Drawing.Size(145, 17);
            _osMain._cbTronE.TabIndex = 83;
            _osMain._cbTronE.Text = "(-e) Always Accept EULA";
            _osMain._cbTronE.UseVisualStyleBackColor = true;
            // 
            // _cbTronDev
            // 
            _osMain._cbTronDev.AutoSize = true;
            _osMain._cbTronDev.Location = new System.Drawing.Point(4, 281);
            _osMain._cbTronDev.Name = "_cbTronDev";
            _osMain._cbTronDev.Size = new System.Drawing.Size(163, 17);
            _osMain._cbTronDev.TabIndex = 82;
            _osMain._cbTronDev.Text = "(-dev) Override OS Detection";
            _osMain._cbTronDev.UseVisualStyleBackColor = true;
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
            _osMain._btnConfigDump.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            _osMain._btnConfigDump.Enabled = false;
            _osMain._btnConfigDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _osMain._btnConfigDump.Location = new System.Drawing.Point(579, 117);
            _osMain._btnConfigDump.Name = "_btnConfigDump";
            _osMain._btnConfigDump.Size = new System.Drawing.Size(140, 23);
            _osMain._btnConfigDump.TabIndex = 79;
            _osMain._btnConfigDump.Text = "Config Dump";
            _osMain._btnConfigDump.UseVisualStyleBackColor = false;
            // 
            // _btnDryRun
            // 
            _osMain._btnDryRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            _osMain._btnDryRun.Enabled = false;
            _osMain._btnDryRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _osMain._btnDryRun.Location = new System.Drawing.Point(579, 146);
            _osMain._btnDryRun.Name = "_btnDryRun";
            _osMain._btnDryRun.Size = new System.Drawing.Size(140, 23);
            _osMain._btnDryRun.TabIndex = 78;
            _osMain._btnDryRun.Text = "Dry Run";
            _osMain._btnDryRun.UseVisualStyleBackColor = false;
            // 
            // _btnRunTron
            // 
            _osMain._btnRunTron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            _osMain._btnRunTron.Enabled = false;
            _osMain._btnRunTron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _osMain._btnRunTron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _osMain._btnRunTron.Location = new System.Drawing.Point(579, 175);
            _osMain._btnRunTron.Name = "_btnRunTron";
            _osMain._btnRunTron.Size = new System.Drawing.Size(140, 23);
            _osMain._btnRunTron.TabIndex = 77;
            _osMain._btnRunTron.Text = "Run Tron";
            _osMain._btnRunTron.UseVisualStyleBackColor = false;
            // 
            // _cbTronStr
            // 
            _osMain._cbTronStr.AutoSize = true;
            _osMain._cbTronStr.Location = new System.Drawing.Point(259, 327);
            _osMain._cbTronStr.Name = "_cbTronStr";
            _osMain._cbTronStr.Size = new System.Drawing.Size(164, 17);
            _osMain._cbTronStr.TabIndex = 76;
            _osMain._cbTronStr.Text = "(-str) Skip Telemetry Removal";
            _osMain._cbTronStr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            _osMain._cbTronStr.UseVisualStyleBackColor = true;
            // 
            // _cbTronSs
            // 
            _osMain._cbTronSs.AutoSize = true;
            _osMain._cbTronSs.Location = new System.Drawing.Point(259, 304);
            _osMain._cbTronSs.Name = "_cbTronSs";
            _osMain._cbTronSs.Size = new System.Drawing.Size(155, 17);
            _osMain._cbTronSs.TabIndex = 75;
            _osMain._cbTronSs.Text = "(-ss) Skip Sophos Anti-Virus";
            _osMain._cbTronSs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            _osMain._cbTronSs.UseVisualStyleBackColor = true;
            // 
            // _cbTronSrr
            // 
            _osMain._cbTronSrr.AutoSize = true;
            _osMain._cbTronSrr.Location = new System.Drawing.Point(259, 281);
            _osMain._cbTronSrr.Name = "_cbTronSrr";
            _osMain._cbTronSrr.Size = new System.Drawing.Size(200, 17);
            _osMain._cbTronSrr.TabIndex = 74;
            _osMain._cbTronSrr.Text = "(-srr) Skip Registry Permissions Reset";
            _osMain._cbTronSrr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            _osMain._cbTronSrr.UseVisualStyleBackColor = true;
            // 
            // _cbTronSfr
            // 
            _osMain._cbTronSfr.AutoSize = true;
            _osMain._cbTronSfr.Location = new System.Drawing.Point(259, 211);
            _osMain._cbTronSfr.Name = "_cbTronSfr";
            _osMain._cbTronSfr.Size = new System.Drawing.Size(201, 17);
            _osMain._cbTronSfr.TabIndex = 73;
            _osMain._cbTronSfr.Text = "(-sfr) Skip filesystem permissions reset";
            _osMain._cbTronSfr.UseVisualStyleBackColor = true;
            // 
            // _cbTronSm
            // 
            _osMain._cbTronSm.AutoSize = true;
            _osMain._cbTronSm.Location = new System.Drawing.Point(259, 258);
            _osMain._cbTronSm.Name = "_cbTronSm";
            _osMain._cbTronSm.Size = new System.Drawing.Size(137, 17);
            _osMain._cbTronSm.TabIndex = 72;
            _osMain._cbTronSm.Text = "(-sm) Skip MBAM Install";
            _osMain._cbTronSm.UseVisualStyleBackColor = true;
            // 
            // _cbTronSdc
            // 
            _osMain._cbTronSdc.AutoSize = true;
            _osMain._cbTronSdc.Location = new System.Drawing.Point(259, 187);
            _osMain._cbTronSdc.Name = "_cbTronSdc";
            _osMain._cbTronSdc.Size = new System.Drawing.Size(260, 17);
            _osMain._cbTronSdc.TabIndex = 70;
            _osMain._cbTronSdc.Text = "(-sdc) Skip DISM component (SxS Store) Cleanup";
            _osMain._cbTronSdc.UseVisualStyleBackColor = true;
            // 
            // _cbTronSk
            // 
            _osMain._cbTronSk.AutoSize = true;
            _osMain._cbTronSk.Location = new System.Drawing.Point(259, 234);
            _osMain._cbTronSk.Name = "_cbTronSk";
            _osMain._cbTronSk.Size = new System.Drawing.Size(147, 17);
            _osMain._cbTronSk.TabIndex = 71;
            _osMain._cbTronSk.Text = "(-sk) Skip Kaspersky VRT";
            _osMain._cbTronSk.UseVisualStyleBackColor = true;
            // 
            // _cbTronSpr
            // 
            _osMain._cbTronSpr.AutoSize = true;
            _osMain._cbTronSpr.Location = new System.Drawing.Point(259, 164);
            _osMain._cbTronSpr.Name = "_cbTronSpr";
            _osMain._cbTronSpr.Size = new System.Drawing.Size(151, 17);
            _osMain._cbTronSpr.TabIndex = 69;
            _osMain._cbTronSpr.Text = "(-spr) Skip Page File Reset";
            _osMain._cbTronSpr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            _osMain._cbTronSpr.UseVisualStyleBackColor = true;
            // 
            // _cbTronSw
            // 
            _osMain._cbTronSw.AutoSize = true;
            _osMain._cbTronSw.Location = new System.Drawing.Point(259, 141);
            _osMain._cbTronSw.Name = "_cbTronSw";
            _osMain._cbTronSw.Size = new System.Drawing.Size(162, 17);
            _osMain._cbTronSw.TabIndex = 68;
            _osMain._cbTronSw.Text = "(-sw) Skip Windows Updates";
            _osMain._cbTronSw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            _osMain._cbTronSw.UseVisualStyleBackColor = true;
            // 
            // _cbTronSe
            // 
            _osMain._cbTronSe.AutoSize = true;
            _osMain._cbTronSe.Location = new System.Drawing.Point(259, 118);
            _osMain._cbTronSe.Name = "_cbTronSe";
            _osMain._cbTronSe.Size = new System.Drawing.Size(163, 17);
            _osMain._cbTronSe.TabIndex = 67;
            _osMain._cbTronSe.Text = "(-se) Skip Event Log Clearing";
            _osMain._cbTronSe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            _osMain._cbTronSe.UseVisualStyleBackColor = true;
            // 
            // _cbTronP
            // 
            _osMain._cbTronP.AutoSize = true;
            _osMain._cbTronP.Location = new System.Drawing.Point(6, 119);
            _osMain._cbTronP.Name = "_cbTronP";
            _osMain._cbTronP.Size = new System.Drawing.Size(158, 17);
            _osMain._cbTronP.TabIndex = 64;
            _osMain._cbTronP.Text = "(-p) Preserve Power Options";
            _osMain._cbTronP.UseVisualStyleBackColor = true;
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
            // 
            // _cbTronEr
            // 
            _osMain._cbTronEr.AutoSize = true;
            _osMain._cbTronEr.Location = new System.Drawing.Point(6, 48);
            _osMain._cbTronEr.Name = "_cbTronEr";
            _osMain._cbTronEr.Size = new System.Drawing.Size(107, 17);
            _osMain._cbTronEr.TabIndex = 53;
            _osMain._cbTronEr.Text = "(-er) Email Report";
            _osMain._cbTronEr.UseVisualStyleBackColor = true;
            // 
            // _cbTronSb
            // 
            _osMain._cbTronSb.AutoSize = true;
            _osMain._cbTronSb.Location = new System.Drawing.Point(259, 48);
            _osMain._cbTronSb.Name = "_cbTronSb";
            _osMain._cbTronSb.Size = new System.Drawing.Size(110, 17);
            _osMain._cbTronSb.TabIndex = 62;
            _osMain._cbTronSb.Text = "(-sb) Skip Debloat";
            _osMain._cbTronSb.UseVisualStyleBackColor = true;
            // 
            // _cbTronM
            // 
            _osMain._cbTronM.AutoSize = true;
            _osMain._cbTronM.Location = new System.Drawing.Point(6, 327);
            _osMain._cbTronM.Name = "_cbTronM";
            _osMain._cbTronM.Size = new System.Drawing.Size(182, 17);
            _osMain._cbTronM.TabIndex = 54;
            _osMain._cbTronM.Text = "(-m) Preserve Default Metro Apps";
            _osMain._cbTronM.UseVisualStyleBackColor = true;
            // 
            // _cbTronX
            // 
            _osMain._cbTronX.AutoSize = true;
            _osMain._cbTronX.Location = new System.Drawing.Point(4, 258);
            _osMain._cbTronX.Name = "_cbTronX";
            _osMain._cbTronX.Size = new System.Drawing.Size(104, 17);
            _osMain._cbTronX.TabIndex = 61;
            _osMain._cbTronX.Text = "(-x) Self Destruct";
            _osMain._cbTronX.UseVisualStyleBackColor = true;
            // 
            // _cbTronO
            // 
            _osMain._cbTronO.AutoSize = true;
            _osMain._cbTronO.Location = new System.Drawing.Point(6, 141);
            _osMain._cbTronO.Name = "_cbTronO";
            _osMain._cbTronO.Size = new System.Drawing.Size(139, 17);
            _osMain._cbTronO.TabIndex = 55;
            _osMain._cbTronO.Text = "(-o) Power Off After Run";
            _osMain._cbTronO.UseVisualStyleBackColor = true;
            // 
            // _cbTronV
            // 
            _osMain._cbTronV.AutoSize = true;
            _osMain._cbTronV.Location = new System.Drawing.Point(4, 235);
            _osMain._cbTronV.Name = "_cbTronV";
            _osMain._cbTronV.Size = new System.Drawing.Size(83, 17);
            _osMain._cbTronV.TabIndex = 60;
            _osMain._cbTronV.Text = "(-v) Verbose";
            _osMain._cbTronV.UseVisualStyleBackColor = true;
            // 
            // _cbTronR
            // 
            _osMain._cbTronR.AutoSize = true;
            _osMain._cbTronR.Location = new System.Drawing.Point(6, 163);
            _osMain._cbTronR.Name = "_cbTronR";
            _osMain._cbTronR.Size = new System.Drawing.Size(141, 17);
            _osMain._cbTronR.TabIndex = 56;
            _osMain._cbTronR.Text = "(-r) Reboot Automatically";
            _osMain._cbTronR.UseVisualStyleBackColor = true;
            // 
            // _cbTronSp
            // 
            _osMain._cbTronSp.AutoSize = true;
            _osMain._cbTronSp.Location = new System.Drawing.Point(259, 95);
            _osMain._cbTronSp.Name = "_cbTronSp";
            _osMain._cbTronSp.Size = new System.Drawing.Size(112, 17);
            _osMain._cbTronSp.TabIndex = 59;
            _osMain._cbTronSp.Text = "(-sp) Skip Patches";
            _osMain._cbTronSp.UseVisualStyleBackColor = true;
            // 
            // _cbTronSa
            // 
            _osMain._cbTronSa.AutoSize = true;
            _osMain._cbTronSa.Location = new System.Drawing.Point(259, 24);
            _osMain._cbTronSa.Name = "_cbTronSa";
            _osMain._cbTronSa.Size = new System.Drawing.Size(117, 17);
            _osMain._cbTronSa.TabIndex = 57;
            _osMain._cbTronSa.Text = "(-sa) Skip Anti-Virus";
            _osMain._cbTronSa.UseVisualStyleBackColor = true;
            // 
            // _cbTronSd
            // 
            _osMain._cbTronSd.AutoSize = true;
            _osMain._cbTronSd.Location = new System.Drawing.Point(259, 71);
            _osMain._cbTronSd.Name = "_cbTronSd";
            _osMain._cbTronSd.Size = new System.Drawing.Size(105, 17);
            _osMain._cbTronSd.TabIndex = 58;
            _osMain._cbTronSd.Text = "(-sd) Skip Defrag";
            _osMain._cbTronSd.UseVisualStyleBackColor = true;
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
            this._tpQuickLaunche.Controls.Add(_osMain._lbCurrentPrograms);
            this._tpQuickLaunche.Controls.Add(this._lblQlMenuItemName);
            this._tpQuickLaunche.Controls.Add(this._btnQlCreateNew);
            this._tpQuickLaunche.Controls.Add(_osMain._txtQlAppName);
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
            // 
            // _lbCurrentPrograms
            // 
            _osMain._lbCurrentPrograms.FormattingEnabled = true;
            _osMain._lbCurrentPrograms.Location = new System.Drawing.Point(309, 46);
            _osMain._lbCurrentPrograms.Name = "_lbCurrentPrograms";
            _osMain._lbCurrentPrograms.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            _osMain._lbCurrentPrograms.Size = new System.Drawing.Size(412, 264);
            _osMain._lbCurrentPrograms.TabIndex = 4;
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
            // 
            // _txtQlAppName
            // 
            _osMain._txtQlAppName.Location = new System.Drawing.Point(11, 75);
            _osMain._txtQlAppName.Name = "_txtQlAppName";
            _osMain._txtQlAppName.Size = new System.Drawing.Size(224, 20);
            _osMain._txtQlAppName.TabIndex = 1;
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
            this._tpShopSettings.Controls.Add(_osMain._tbShopSetState);
            this._tpShopSettings.Controls.Add(this._lblShopSetCity);
            this._tpShopSettings.Controls.Add(_osMain._tbShopSetCity);
            this._tpShopSettings.Controls.Add(this._lblShopSetEmail);
            this._tpShopSettings.Controls.Add(_osMain._tbShopSetEmail);
            this._tpShopSettings.Controls.Add(this._lblShopSetPhone);
            this._tpShopSettings.Controls.Add(_osMain._tbShopSetPhone);
            this._tpShopSettings.Controls.Add(_osMain._tbShopSetAddr2);
            this._tpShopSettings.Controls.Add(this._lblShopSetAddr);
            this._tpShopSettings.Controls.Add(_osMain._tbShopSetAddr1);
            this._tpShopSettings.Controls.Add(this._lblShopSetShopname);
            this._tpShopSettings.Controls.Add(_osMain._tbShopSetName);
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
            _osMain._tbShopSetState.Location = new System.Drawing.Point(16, 238);
            _osMain._tbShopSetState.Name = "_tbShopSetState";
            _osMain._tbShopSetState.Size = new System.Drawing.Size(224, 20);
            _osMain._tbShopSetState.TabIndex = 15;
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
            _osMain._tbShopSetCity.Location = new System.Drawing.Point(16, 190);
            _osMain._tbShopSetCity.Name = "_tbShopSetCity";
            _osMain._tbShopSetCity.Size = new System.Drawing.Size(224, 20);
            _osMain._tbShopSetCity.TabIndex = 13;
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
            _osMain._tbShopSetEmail.Location = new System.Drawing.Point(16, 333);
            _osMain._tbShopSetEmail.Name = "_tbShopSetEmail";
            _osMain._tbShopSetEmail.Size = new System.Drawing.Size(224, 20);
            _osMain._tbShopSetEmail.TabIndex = 11;
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
            _osMain._tbShopSetPhone.Location = new System.Drawing.Point(16, 285);
            _osMain._tbShopSetPhone.Name = "_tbShopSetPhone";
            _osMain._tbShopSetPhone.Size = new System.Drawing.Size(224, 20);
            _osMain._tbShopSetPhone.TabIndex = 9;
            // 
            // _tbShopSetAddr2
            // 
            _osMain._tbShopSetAddr2.Location = new System.Drawing.Point(16, 144);
            _osMain._tbShopSetAddr2.Name = "_tbShopSetAddr2";
            _osMain._tbShopSetAddr2.Size = new System.Drawing.Size(224, 20);
            _osMain._tbShopSetAddr2.TabIndex = 8;
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
            _osMain._tbShopSetAddr1.Location = new System.Drawing.Point(16, 118);
            _osMain._tbShopSetAddr1.Name = "_tbShopSetAddr1";
            _osMain._tbShopSetAddr1.Size = new System.Drawing.Size(224, 20);
            _osMain._tbShopSetAddr1.TabIndex = 6;
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
            _osMain._tbShopSetName.Location = new System.Drawing.Point(16, 28);
            _osMain._tbShopSetName.Name = "_tbShopSetName";
            _osMain._tbShopSetName.Size = new System.Drawing.Size(224, 20);
            _osMain._tbShopSetName.TabIndex = 4;
            // 
            // _lnkInfoInternalIp
            // 
            _osMain._lnkInfoInternalIp.AutoSize = true;
            _osMain._lnkInfoInternalIp.Location = new System.Drawing.Point(619, 39);
            _osMain._lnkInfoInternalIp.Name = "_lnkInfoInternalIp";
            _osMain._lnkInfoInternalIp.Size = new System.Drawing.Size(95, 13);
            _osMain._lnkInfoInternalIp.TabIndex = 68;
            _osMain._lnkInfoInternalIp.TabStop = true;
            _osMain._lnkInfoInternalIp.Text = "lnk_info_InternalIP";
            // 
            // _lblInfoExternalIp
            // 
            _osMain._lblInfoExternalIp.AutoSize = true;
            _osMain._lblInfoExternalIp.BackColor = System.Drawing.SystemColors.Control;
            _osMain._lblInfoExternalIp.Location = new System.Drawing.Point(415, 73);
            _osMain._lblInfoExternalIp.Name = "_lblInfoExternalIp";
            _osMain._lblInfoExternalIp.Size = new System.Drawing.Size(94, 13);
            _osMain._lblInfoExternalIp.TabIndex = 67;
            _osMain._lblInfoExternalIp.Text = "lbl_info_ExternalIP";
            // 
            // _lnkInfoGateway
            // 
            _osMain._lnkInfoGateway.AutoSize = true;
            _osMain._lnkInfoGateway.Location = new System.Drawing.Point(619, 56);
            _osMain._lnkInfoGateway.Name = "_lnkInfoGateway";
            _osMain._lnkInfoGateway.Size = new System.Drawing.Size(92, 13);
            _osMain._lnkInfoGateway.TabIndex = 66;
            _osMain._lnkInfoGateway.TabStop = true;
            _osMain._lnkInfoGateway.Text = "lnk_info_Gateway";
            // 
            // _lnkInfoPrimDns
            // 
            _osMain._lnkInfoPrimDns.AutoSize = true;
            _osMain._lnkInfoPrimDns.Location = new System.Drawing.Point(619, 73);
            _osMain._lnkInfoPrimDns.Name = "_lnkInfoPrimDns";
            _osMain._lnkInfoPrimDns.Size = new System.Drawing.Size(93, 13);
            _osMain._lnkInfoPrimDns.TabIndex = 64;
            _osMain._lnkInfoPrimDns.TabStop = true;
            _osMain._lnkInfoPrimDns.Text = "lnk_info_PrimDNS";
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
            _osMain._lblInfoFreeC.AutoSize = true;
            _osMain._lblInfoFreeC.BackColor = System.Drawing.SystemColors.Control;
            _osMain._lblInfoFreeC.Location = new System.Drawing.Point(100, 75);
            _osMain._lblInfoFreeC.Name = "_lblInfoFreeC";
            _osMain._lblInfoFreeC.Size = new System.Drawing.Size(74, 13);
            _osMain._lblInfoFreeC.TabIndex = 58;
            _osMain._lblInfoFreeC.Text = "lbl_info_FreeC";
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
            _osMain._lblInfoRam.AutoSize = true;
            _osMain._lblInfoRam.BackColor = System.Drawing.SystemColors.Control;
            _osMain._lblInfoRam.Location = new System.Drawing.Point(50, 41);
            _osMain._lblInfoRam.Name = "_lblInfoRam";
            _osMain._lblInfoRam.Size = new System.Drawing.Size(70, 13);
            _osMain._lblInfoRam.TabIndex = 56;
            _osMain._lblInfoRam.Text = "lbl_info_RAM";
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
            _osMain._lblInfoOs.AutoSize = true;
            _osMain._lblInfoOs.Location = new System.Drawing.Point(40, 24);
            _osMain._lblInfoOs.Name = "_lblInfoOs";
            _osMain._lblInfoOs.Size = new System.Drawing.Size(61, 13);
            _osMain._lblInfoOs.TabIndex = 54;
            _osMain._lblInfoOs.Text = "lbl_info_OS";
            // 
            // _lblInfoComputerName
            // 
            _osMain._lblInfoComputerName.AutoSize = true;
            _osMain._lblInfoComputerName.Location = new System.Drawing.Point(112, 59);
            _osMain._lblInfoComputerName.Name = "_lblInfoComputerName";
            _osMain._lblInfoComputerName.Size = new System.Drawing.Size(119, 13);
            _osMain._lblInfoComputerName.TabIndex = 53;
            _osMain._lblInfoComputerName.Text = "lbl_info_ComputerName";
            // 
            // _cmsDeleteQl
            // 
            this._cmsDeleteQl.Name = "Delete";
            this._cmsDeleteQl.Size = new System.Drawing.Size(61, 4);
            this._cmsDeleteQl.Text = "DELETE";
            // 
            // _ddlInfoNetworkAdapters
            // 
            _osMain._ddlInfoNetworkAdapters.FormattingEnabled = true;
            _osMain._ddlInfoNetworkAdapters.Location = new System.Drawing.Point(337, 31);
            _osMain._ddlInfoNetworkAdapters.Name = "_ddlInfoNetworkAdapters";
            _osMain._ddlInfoNetworkAdapters.Size = new System.Drawing.Size(185, 21);
            _osMain._ddlInfoNetworkAdapters.TabIndex = 69;
            _osMain._ddlInfoNetworkAdapters.Text = "Select an Adapter";
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
            _osMain._lblInfoAdapterDesc.AutoSize = true;
            _osMain._lblInfoAdapterDesc.BackColor = System.Drawing.SystemColors.Control;
            _osMain._lblInfoAdapterDesc.Location = new System.Drawing.Point(415, 58);
            _osMain._lblInfoAdapterDesc.MaximumSize = new System.Drawing.Size(170, 13);
            _osMain._lblInfoAdapterDesc.Name = "_lblInfoAdapterDesc";
            _osMain._lblInfoAdapterDesc.Size = new System.Drawing.Size(108, 13);
            _osMain._lblInfoAdapterDesc.TabIndex = 71;
            _osMain._lblInfoAdapterDesc.Text = "lbl_info_AdapterDesc";
            // 
            // _ofdTron
            // 
            _osMain._ofdTron.FileName = "Tron.bat";
            // 
            // OsMain
            // 
            _osMain.ClientSize = new System.Drawing.Size(754, 531);
            _osMain.Controls.Add(_osMain._lblInfoAdapterDesc);
            _osMain.Controls.Add(this._label1);
            _osMain.Controls.Add(_osMain._ddlInfoNetworkAdapters);
            _osMain.Controls.Add(_osMain._lnkInfoInternalIp);
            _osMain.Controls.Add(_osMain._lblInfoExternalIp);
            _osMain.Controls.Add(_osMain._lnkInfoGateway);
            _osMain.Controls.Add(_osMain._lnkInfoPrimDns);
            _osMain.Controls.Add(this._lblDns);
            _osMain.Controls.Add(this._lblGateway);
            _osMain.Controls.Add(this._lblExternalIp);
            _osMain.Controls.Add(this._lblInternalIp);
            _osMain.Controls.Add(this._lblFreeC);
            _osMain.Controls.Add(_osMain._lblInfoFreeC);
            _osMain.Controls.Add(this._lblRam);
            _osMain.Controls.Add(_osMain._lblInfoRam);
            _osMain.Controls.Add(this._lblOs);
            _osMain.Controls.Add(this._lblComputerName);
            _osMain.Controls.Add(_osMain._lblInfoOs);
            _osMain.Controls.Add(_osMain._lblInfoComputerName);
            _osMain.Controls.Add(this._tcPrimaryTabs);
            _osMain.Controls.Add(this._tsBottomToolbar);
            _osMain.Controls.Add(this._menuPrimary);
            _osMain.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            _osMain.HelpButton = true;
            _osMain.MainMenuStrip = this._menuPrimary;
            _osMain.MaximizeBox = false;
            _osMain.MinimizeBox = false;
            _osMain.Name = "OsMain";
            this._tsBottomToolbar.ResumeLayout(false);
            this._tsBottomToolbar.PerformLayout();
            this._menuPrimary.ResumeLayout(false);
            this._menuPrimary.PerformLayout();
            this._tcPrimaryTabs.ResumeLayout(false);
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
            _osMain.ResumeLayout(false);
            _osMain.PerformLayout();

        }
    }
}