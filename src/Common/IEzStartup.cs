using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;

namespace EzStartup.Common;

public interface IEzStartup
{
    void Launch(WindowsStartupApp arguments);
    void LaunchMany(List<WindowsStartupApp> startupApps);
}