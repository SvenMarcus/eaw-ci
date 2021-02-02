using System;
using EawXBuild.Core;

namespace EawXBuildTest.Core {
    public class TaskDummy : ITask {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual void Run() { }
    }

    public class TaskSpy : TaskDummy {
        public bool WasRun { get; private set; }

        public override void Run() {
            WasRun = true;
        }
    }

    public class ThrowingTaskStub : TaskDummy {
        public override void Run() {
            throw new Exception();
        }
    }
}