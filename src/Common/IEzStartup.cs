using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzStartup.Common;

public interface IEzStartup
{
    void Launch(string fileName, string arguments);
}