using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Logic
{
    public class WindowsPositioner : IWindowsPositioner
    {
        private readonly ILogger<WindowsPositioner> _logger;
        public WindowsPositioner(ILogger<WindowsPositioner> logger){
            _logger = logger;
        }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        public void Position(Process process, int positionX, int positionY, int sizeX, int sizeY)
        {
            _logger.LogInformation("Positioning {ProcessName} at X:{PositionX} Y:{PositionY} W:{SizeX} H:{SizeY}",process.ProcessName,positionX,positionY,sizeX,sizeY);
            
            IntPtr handle = process.Handle;
            var didwork = MoveWindow(handle,positionX,positionY,sizeX,sizeY,true);
            
            _logger.LogInformation(didwork? "Process was positioned." : "Process failed to be positoned");
        }
        
    }
}