using System;

namespace EawXBuild.Core {
    public enum TaskStatus {
        Started,
        Finished,
        Failed
    }

    public class TaskProgressEventArgs {
        public TaskProgressEventArgs(TaskStatus status, ITask task) {
            Status = status;
            Task = task;
        }

        public TaskStatus Status { get; }

        public ITask Task { get; }
    }

    public class TaskProgress {
        public event EventHandler<TaskProgressEventArgs> OnReport;

        public void Report(TaskStatus taskStatus, ITask type) {
            OnReport?.Invoke(this, new TaskProgressEventArgs(taskStatus, type));
        }
    }
}