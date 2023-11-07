using System.Diagnostics;

ProcessStartInfo startInfo = new ProcessStartInfo
{
    FileName = "explorer.exe",
    Arguments = $"shell:AppsFolder\\WatchtowerBibleandTractSo.45909CDBADF3C_5rz59y55nfz3e!App",
};

Process.Start(startInfo);


