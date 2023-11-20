using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EzStartup.Logic;

public interface ILaunchApps
{
    Process Launch(string fileName, string arguments, string? workingDirectory = null);
}