using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class WindowsEzStartup : IEzStartup
    {
        private ProcessStartInfo startInfo;

        public WindowsEzStartup(ProcessStartInfo startInfo){
            this.startInfo = startInfo;
        }

        public void Launch()
        {
            try{
                Process.Start(this.startInfo);
            }
            catch{
                Console.WriteLine("Failed to Launch Application");
            }
        }
    }
}