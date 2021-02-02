using System.Collections.Generic;
using EawXBuild.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EawXBuildTest.Core {
    [TestClass]
    public class JobTest {
        [TestMethod]
        [TestCategory(TestUtility.TEST_TYPE_HOLY)]
        public void GivenJobWithTwoTasks__WhenRunningJob__ShouldExecuteAllTasks() {
            var sut = new Job("job");
            var firstTask = new TaskSpy();
            var secondTask = new TaskSpy();
            sut.AddTask(firstTask);
            sut.AddTask(secondTask);

            sut.Run();

            AssertTaskWasRun(firstTask);
            AssertTaskWasRun(secondTask);
        }

        [TestMethod]
        public void GivenJobWithTask__WhenRunning__ShouldReportTaskStartAndFinish() {
            var taskStatuses = new List<TaskStatus>();
            var progress = new TaskProgress();
            progress.OnReport += (sender, args) => taskStatuses.Add(args.Status); 
                
            var sut = new Job("job");
            sut.AddTask(new TaskDummy());

            sut.Run(progress);

            var expected = new []{TaskStatus.Started, TaskStatus.Finished};
            CollectionAssert.AreEquivalent(expected, taskStatuses);
        }

        [TestMethod]
        public void GivenJobWithThrowingTask__WhenRunning__ShouldReportTaskStartAndFail() {
            var taskStatuses = new List<TaskStatus>();
            var progress = new TaskProgress();
            progress.OnReport += (sender, args) => taskStatuses.Add(args.Status); 
                
            var sut = new Job("job");
            sut.AddTask(new ThrowingTaskStub());

            sut.Run(progress);

            var expected = new []{TaskStatus.Started, TaskStatus.Failed};
            CollectionAssert.AreEquivalent(expected, taskStatuses);
        }

        [TestMethod]
        public void GivenJobWithThrowingAndSecondTask__WhenRunning__ShouldNotRunSecondTask() {
            var taskSpy = new TaskSpy();
            
            var sut = new Job("job");
            sut.AddTask(new ThrowingTaskStub());
            sut.AddTask(taskSpy);

            sut.Run();
            
            Assert.IsFalse(taskSpy.WasRun);
        }

        [TestMethod]
        public void GivenJobWithTask__WhenRunning__ShouldReportBeforeAndAfterTaskRun() {
            var progress = new TaskProgress();
            var taskMock = new CheckReportBeforeAndAfterRunTaskMock(progress);

            var sut = new Job("job");
            sut.AddTask(taskMock);

            sut.Run(progress);

            taskMock.Verify();
        }
        
        private static void AssertTaskWasRun(TaskSpy firstTask) {
            Assert.IsTrue(firstTask.WasRun, "Task should have been run, but wasn't.");
        }
    }
}