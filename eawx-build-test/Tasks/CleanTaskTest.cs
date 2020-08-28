using System.IO.Abstractions.TestingHelpers;
using EawXBuild.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EawXBuildTest.Tasks
{
    [TestClass]
    public class CleanTaskTest
    {

        private MockFileSystem _fileSystem;
        private FileSystemAssertions _assertions;
        private CleanTask _sut;

        [TestInitialize]
        public void SetUp()
        {
            _fileSystem = new MockFileSystem();
            _assertions = new FileSystemAssertions(_fileSystem);
            _sut = new CleanTask(_fileSystem);
        }

        [TestMethod]
        [TestCategory(TestUtility.TEST_TYPE_UTILITY)]
        public void GivenPathToFile__WhenCallingRun__ShouldDeleteFile()
        {
            const string dirPath = "Data";
            const string filePath = "Data/MyFile.txt";

            _fileSystem.AddDirectory(dirPath);
            _fileSystem.AddFile(filePath, new MockFileData(string.Empty));

            _sut.Path = filePath;

            _sut.Run();

            _assertions.AssertFileDoesNotExist(filePath);
        }

        [TestMethod]
        [TestCategory(TestUtility.TEST_TYPE_UTILITY)]
        public void GivenPathToDirectory__WhenCallingRun__ShouldDeleteDirectory()
        {
            const string dirPath = "Data";
            _fileSystem.AddDirectory(dirPath);

            _sut.Path = dirPath;

            _sut.Run();

            _assertions.AssertDirectoryDoesNotExist(dirPath);
        }
        
        [TestMethod]
        [TestCategory(TestUtility.TEST_TYPE_UTILITY)]
        public void GivenPathToDirectory__ShouldDescribeTask()
        {
            const string dirPath = "Data";
            _fileSystem.AddDirectory(dirPath);
        
            _sut.Path = dirPath;
        
            Assert.AreEqual($"Cleaning directory {dirPath}", _sut.Description);
        }
        
        [TestMethod]
        [TestCategory(TestUtility.TEST_TYPE_UTILITY)]
        public void GivenPathToFile__ShouldDescribeTask()
        {
            const string filePath = "Data/MyFile.txt";
        
            _sut.Path = filePath;
        
            Assert.AreEqual($"Cleaning file {filePath}", _sut.Description);
        }
        
    }
}
