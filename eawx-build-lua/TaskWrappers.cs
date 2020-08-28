using System.IO.Abstractions;
using EawXBuild.Core;
using EawXBuild.Native;
using EawXBuild.Services.Process;
using EawXBuild.Tasks;

namespace eawx_build_lua {
    public enum overwrite {
        yes = 1,
        no = 0
    }

    public interface ITaskWrapper {
        internal ITask Task { get; }
    }

    public class CopyTaskWrapper : ITaskWrapper {
        private CopyTask _task;
        ITask ITaskWrapper.Task => _task;

        public CopyTaskWrapper(string source, string target) {
            _task = new CopyTask(new FileSystem(), new CopyPolicy()) {
                Source = source,
                Destination = target,
                AlwaysOverwrite = false
            };
        }

        public CopyTaskWrapper overwrite(bool overwrite) {
            _task.AlwaysOverwrite = overwrite;
            return this;
        }
    }

    public class LinkTaskWrapper : ITaskWrapper {
        private IFileLinkerFactory _factory = new FileLinkerFactory();
        private CopyTask _task;
        ITask ITaskWrapper.Task => _task;

        public LinkTaskWrapper(string source, string target) {
            _task = new CopyTask(new FileSystem(), new LinkCopyPolicy(_factory.MakeFileLinker())) {
                Source = source,
                Destination = target,
                AlwaysOverwrite = true
            };
        }

        public LinkTaskWrapper overwrite(bool overwrite) {
            _task.AlwaysOverwrite = overwrite;
            return this;
        }
    }

    public class CleanTaskWrapper : ITaskWrapper {
        private ITask _task;
        ITask ITaskWrapper.Task => _task;

        public CleanTaskWrapper(string path) {
            _task = new CleanTask(new FileSystem()) {
                Path = path
            };
        }
    }

    public class RunProcessTaskWrapper : ITaskWrapper {
        private RunProcessTask _task;
        ITask ITaskWrapper.Task => _task;

        public RunProcessTaskWrapper(string path, string args) {
            _task = new RunProcessTask(new ProcessRunner(), new FileSystem()) {
                ExecutablePath = path,
                Arguments = args
            };
        }

        public RunProcessTaskWrapper working_directory(string dir) {
            _task.WorkingDirectory = dir;
            return this;
        }
    }
}