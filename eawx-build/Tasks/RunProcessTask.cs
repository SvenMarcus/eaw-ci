using System.IO;
using System.IO.Abstractions;
using EawXBuild.Core;
using EawXBuild.Exceptions;
using EawXBuild.Services.Process;

namespace EawXBuild.Tasks {
    public class RunProcessTask : ITask {
        private readonly IProcessRunner _runner;
        private readonly IFileSystem _filesystem;

        public RunProcessTask(IProcessRunner runner, IFileSystem filesystem = null) {
            _runner = runner;
            _filesystem = filesystem ?? new FileSystem();
        }

        public void Run() {
            if (_filesystem.Path.IsPathRooted(ExecutablePath)) throw new NoRelativePathException(ExecutablePath);
            _runner.Start(ExecutablePath, Arguments);
            _runner.WaitForExit();
            if(_runner.ExitCode != 0) throw new ProcessFailedException();
        }

        public string ExecutablePath { get; set; }
        public string Arguments { get; set; }
    }
}