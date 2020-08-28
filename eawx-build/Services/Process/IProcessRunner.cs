using System.Collections.Generic;
using System.Diagnostics;

namespace EawXBuild.Services.Process {
    public interface IProcessRunner {
        void Start(string executablePath);
        void Start(string executablePath, string arguments);

        void Start(ProcessStartInfo processStartInfo);

        void WaitForExit();

        int ExitCode { get; }
    }
}