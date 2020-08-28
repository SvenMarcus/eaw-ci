using System.IO.Abstractions;
using EawXBuild.Core;

namespace EawXBuild.Tasks {
    public class CleanTask : ITask {
        private readonly IFileSystem fileSystem;

        public CleanTask(IFileSystem fileSystem) {
            this.fileSystem = fileSystem;
        }

        public string Path { get; set; }

        public string Description {
            get {
                var fileType = "file";
                if (fileSystem.Directory.Exists(Path)) fileType = "directory";
                return $"Cleaning {fileType} {Path}";
            }
        }

        public void Run() {
            if (fileSystem.Directory.Exists(Path))
                fileSystem.Directory.Delete(Path);
            else
                fileSystem.File.Delete(Path);
        }
    }
}