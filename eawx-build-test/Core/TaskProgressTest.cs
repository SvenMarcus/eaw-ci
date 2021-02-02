using System;
using EawXBuild.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EawXBuildTest.Core {
    [TestClass]
    public class TaskProgressTest {
        [TestMethod]
        public void GivenTaskProgress__WhenReporting__ShouldNotifyEventHandler() {
            var wasReported = false;
            var sut = new TaskProgress();
            sut.OnReport += (sender, args) => wasReported = true;

            sut.Report(TaskStatus.Started, new TaskDummy());

            Assert.IsTrue(wasReported);
        }

        [TestMethod]
        public void GivenTaskProgress__WhenReportingTaskStarted__ShouldNotifyEventHandlerWithStatusAndTask() {
            var expectedStatus = TaskStatus.Started;
            var expectedTask = new TaskDummy();

            var sut = new TaskProgress();

            sut.OnReport += AssertReportMatchesStatusAndTask(expectedStatus, expectedTask);

            sut.Report(TaskStatus.Started, expectedTask);
        }

        private static EventHandler<TaskProgressEventArgs> AssertReportMatchesStatusAndTask(TaskStatus expectedStatus, ITask expectedTask) {
            return (sender, args) => {
                Assert.AreEqual(expectedStatus, args.Status);
                Assert.AreEqual(expectedTask, args.Task);
            };
        }
    }
}