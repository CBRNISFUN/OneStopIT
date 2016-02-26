using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmiLight;

namespace OneStop
{
    class OS_WMI
    {
        public static List<string> GetRunningProcesses()
        {
            List<string> output = new List<string>();
            using (WmiConnection localcon = new WmiConnection())
            {
                output.AddRange(localcon.CreateQuery("SELECT * FROM Win32_Process").Select(queryobject => queryobject.ToString()));
            }
            return output;
        }

    }
}
