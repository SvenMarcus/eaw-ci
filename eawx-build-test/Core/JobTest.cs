using System;
using System.Globalization;
using System.IO;
using System.IO.Abstractions.TestingHelpers;
using System.Text;
using EawXBuild.Core;
using EawXBuildTest.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
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
        [TestCategory(TestUtility.TEST_TYPE_HOLY)]
        public void GivenJobWithTasks__ShouldLogTaskDescription() {
            var stringBuilder = new StringBuilder();
            var writer = new StringWriter(stringBuilder);
            Console.SetOut(writer);

            var sut = new Job("job");
            var firstTask = new TaskDummy {Description = "first"};
            var secondTask = new TaskDummy {Description = "second"};
            sut.AddTask(firstTask);
            sut.AddTask(secondTask);

            sut.Run();
            Assert.AreEqual("first" + Environment.NewLine + "second" + Environment.NewLine, stringBuilder.ToString());
        }

        private static void AssertTaskWasRun(TaskSpy firstTask) {
            Assert.IsTrue(firstTask.WasRun, "Task should have been run, but wasn't.");
        }
    }
}