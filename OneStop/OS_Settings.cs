using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneStop.Properties;

namespace OneStop
{
    class OS_Settings
    {
        internal static int GetCMDConsoleMode()
        {
            int output = 3;

            if (Settings.Default.boolCMDConsole && Settings.Default.boolCMDLog)
            {
                output = 1;
            }
            else if (Settings.Default.boolCMDConsole && !Settings.Default.boolCMDLog)
            {
                output = 0;
            }
            else if (!Settings.Default.boolCMDConsole && Settings.Default.boolCMDLog)
            {
                output = 2;
            }
            else
            {
                output = 3;
            }

            return output;
        }

        internal static int GetGPLMode()
        {
            int output = 3;

            if (Settings.Default.boolGPLNoticeConsole && Settings.Default.boolGPLNoticeLog)
            {
                output = 1;
            }
            else if (Settings.Default.boolGPLNoticeConsole && !Settings.Default.boolGPLNoticeLog)
            {
                output = 0;
            }
            else if (!Settings.Default.boolGPLNoticeConsole && Settings.Default.boolGPLNoticeLog)
            {
                output = 2;
            }
            else
            {
                output = 3;
            }


            return output;
        }

        internal static int GetProgramOpenMode()
        {
            int output = 3;

            if (Settings.Default.boolProgramOpenedConsole && Settings.Default.boolProgramOpenedLog)
            {
                output = 1;
            }
            else if (Settings.Default.boolProgramOpenedConsole && !Settings.Default.boolProgramOpenedLog)
            {
                output = 0;
            }
            else if (!Settings.Default.boolProgramOpenedConsole && Settings.Default.boolProgramOpenedLog)
            {
                output = 2;
            }
            else
            {
                output = 3;
            }


            return output;
        }

        internal static int GetRegistryMode()
        {
            int output = 3;

            if (Settings.Default.boolRegistryConsole && Settings.Default.boolRegistryLog)
            {
                output = 1;
            }
            else if (Settings.Default.boolRegistryConsole && !Settings.Default.boolRegistryLog)
            {
                output = 0;
            }
            else if (!Settings.Default.boolRegistryConsole && Settings.Default.boolRegistryLog)
            {
                output = 2;
            }
            else
            {
                output = 3;
            }

            return output;
        }

        internal static int GetStartupMode()
        {
            int output = 3;

            if (Settings.Default.boolStartupConsole && Settings.Default.boolStartupLog)
            {
                output = 1;
            }
            else if (Settings.Default.boolStartupConsole && !Settings.Default.boolStartupLog)
            {
                output = 0;
            }
            else if (!Settings.Default.boolStartupConsole && Settings.Default.boolStartupLog)
            {
                output = 2;
            }
            else
            {
                output = 3;
            }

            return output;


        }

        internal static int GetSysinfoMode()
        {
            int output = 3;

            if (Settings.Default.boolSysInfoConsole && Settings.Default.boolSysInfoLog)
            {
                output = 1;
            }
            else if (Settings.Default.boolSysInfoConsole && !Settings.Default.boolSysInfoLog)
            {
                output = 0;
            }
            else if (!Settings.Default.boolSysInfoConsole && Settings.Default.boolSysInfoLog)
            {
                output = 2;
            }
            else
            {
                output = 3;
            }

            return output;
        }

        internal static int GetVerboseErrorMode()
        {
            int output = 3;

            if (Settings.Default.boolVerboseErrorConsole && Settings.Default.boolVerboseErrorLog)
            {
                output = 1;
            }
            else if (Settings.Default.boolVerboseErrorConsole && !Settings.Default.boolVerboseErrorLog)
            {
                output = 0;
            }
            else if (!Settings.Default.boolVerboseErrorConsole && Settings.Default.boolVerboseErrorLog)
            {
                output = 2;
            }
            else
            {
                output = 3;
            }

            return output;
        }

        internal static int GetWebsiteMode()
        {
            int output = 3;

            if (Settings.Default.boolWebsiteConsole && Settings.Default.boolWebsiteLog)
            {
                output = 1;
            }
            else if (Settings.Default.boolWebsiteConsole && !Settings.Default.boolWebsiteLog)
            {
                output = 0;
            }
            else if (!Settings.Default.boolWebsiteConsole && Settings.Default.boolWebsiteLog)
            {
                output = 2;
            }
            else
            {
                output = 3;
            }

            return output;
        }
    }
}
