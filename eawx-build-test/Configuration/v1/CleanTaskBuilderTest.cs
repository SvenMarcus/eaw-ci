using System;
using EawXBuild.Configuration.v1;
using EawXBuild.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EawXBuildTest.Configuration.v1 {
    [TestClass]
    public class CleanTaskBuilderTest {
        [TestMethod]
        public void WhenBuildingCleanTaskWithDirectoryPath__ShouldReturnConfiguredCleanTask() {
            const string pathToDirectory = "Path/To/Directory";
            var sut = new CleanTaskBuilder();

            CleanTask task = (CleanTask) sut.With("Path", pathToDirectory).Build();

            Assert.AreEqual(pathToDirectory, task.Path);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WhenBuildingCleanTaskWithUnknownConfigOption__ShouldThrowInvalidOperationException() {
            var sut = new CleanTaskBuilder();

            sut.With("Unknown", "").Build();
        }
    }
}