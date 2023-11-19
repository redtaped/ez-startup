using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzStartup.Common;

public interface ILaunchApps
{
    void Launch(string fileName, string arguments, string? workingDirectory = null);
}