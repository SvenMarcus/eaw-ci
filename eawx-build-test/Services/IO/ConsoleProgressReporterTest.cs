using System;
using System.IO;
using System.Text;
using EawXBuild.Core;
using EawXBuild.Services.IO;
using EawXBuildTest.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EawXBuildTest.Services.IO {
    [TestClass]
    public class ConsoleProgressReporterTest {
        private StringBuilder _stringBuilder;
        private TextWriter _out;

        [TestInitialize]
        public void SetUp() {
            _stringBuilder = new StringBuilder();
            _out = Console.Out;
            Console.SetOut(new StringWriter(_stringBuilder));
        }

        [TestMethod]
        public void WhenReportingTaskStart__ShouldPrintTaskStartToConsole() {
            const string expectedTaskId = "taskId";
            const string expectedTaskName = "My Task";

            var progress = new TaskProgress();
            var sut = new ConsoleTaskProgressReporter(progress);

            var task = new TaskDummy {
                Id = expectedTaskId,
                Name = expectedTaskName
            };

            progress.Report(TaskStatus.Started, task);


            var actual = _stringBuilder.ToString().Trim();
            var expected = $"[Start     ] {nameof(TaskDummy)} - Id: {expectedTaskId} - Name: {expectedTaskName}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenReportingTaskFinish__ShouldPrintTaskFinishToConsole() {
            const string expectedTaskId = "taskId";
            const string expectedTaskName = "My Task";

            var progress = new TaskProgress();
            var sut = new ConsoleTaskProgressReporter(progress);

            var task = new TaskDummy {
                Id = expectedTaskId,
                Name = expectedTaskName
            };

            progress.Report(TaskStatus.Finished, task);


            var actual = _stringBuilder.ToString().Trim();
            var expected = $"[       End] {nameof(TaskDummy)} - Id: {expectedTaskId} - Name: {expectedTaskName}";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenReportingTaskStartAndFinish__ShouldPrintTaskStartAndFinishToConsole() {
            const string expectedTaskId = "taskId";
            const string expectedTaskName = "My Task";

            var progress = new TaskProgress();
            var sut = new ConsoleTaskProgressReporter(progress);

            var task = new TaskDummy {
                Id = expectedTaskId,
                Name = expectedTaskName
            };

            progress.Report(TaskStatus.Started, task);
            progress.Report(TaskStatus.Finished, task);


            var actual = _stringBuilder.ToString().Trim();
            var taskDetails = $"{nameof(TaskDummy)} - Id: {expectedTaskId} - Name: {expectedTaskName}";
            var expected = $"[Start     ] {taskDetails}" + Environment.NewLine + $"[       End] {taskDetails}";
            Console.SetOut(_out);
            Console.Write(actual);
            Assert.AreEqual(expected, actual);
        }
    }
}