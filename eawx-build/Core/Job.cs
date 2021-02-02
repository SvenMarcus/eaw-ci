using System;
using System.Collections.Generic;

namespace EawXBuild.Core {
    public class Job : IJob {
        private readonly List<ITask> _tasks = new List<ITask>();

        public Job(string name) {
            Name = name;
        }

        public string Name { get; }

        public void AddTask(ITask task) {
            _tasks.Add(task);
        }

        public void Run(TaskProgress progress = null) {
            foreach (var task in _tasks) {
                var success = ReportAndTryRunTask(progress, task);
                if (!success) return;
            }
        }

        private static bool ReportAndTryRunTask(TaskProgress progress, ITask task) {
            progress?.Report(TaskStatus.Started, task);
            var success = TryRunTask(task);
            
            var status = success ? TaskStatus.Finished : TaskStatus.Failed;
            progress?.Report(status, task);
            return success;
        }

        private static bool TryRunTask(ITask task) {
            try {
                task.Run();
            }
            catch (Exception) {
                return false;
            }

            return true;
        }
    }
}