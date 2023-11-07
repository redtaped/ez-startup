// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using App;

WindowsEzStartup startup = new WindowsEzStartup(new ProcessStartInfo{
    FileName = "explorer.exe",
    Arguments = $"shell:AppsFolder\\WatchtowerBibleandTractSo.45909CDBADF3C_5rz59y55nfz3e!App",
});

startup.Launch();
