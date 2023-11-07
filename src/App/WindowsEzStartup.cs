using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App
{
    public class WindowsEzStartup : IEzStartup
    {
        private ProcessStartInfo startInfo;

        public WindowsEzStartup(ProcessStartInfo startInfo){
            this.startInfo = startInfo;
        }

        public void Launch()
        {
           Process.Start(this.startInfo);
        }
    }
}