using EawXBuild.Core;
using NLua;

namespace eawx_build_lua {
    public class ProjectWrapper {
        public ProjectWrapper(string name) {
            Project = new Project {Name = name};
        }

        public JobWrapper add_job(string name) {
            var jobWrapper = new JobWrapper(name);
            Project.AddJob(jobWrapper.Job);
            return jobWrapper;
        }
        
        internal Project Project { get; private set; }
    }

    public class JobWrapper {
        public JobWrapper(string name) {
            Job = new Job(name);
        }

        public void add_task(ITaskWrapper task) {
            Job.AddTask(task.Task);
        }

        internal Job Job { get; private set; }
    }
}