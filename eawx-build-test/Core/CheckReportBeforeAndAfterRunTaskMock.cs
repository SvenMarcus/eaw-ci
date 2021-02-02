using System;
using EawXBuild.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EawXBuildTest.Core {
    public class CheckReportBeforeAndAfterRunTaskMock : TaskSpy {
        private string _callOrder = string.Empty;

        public CheckReportBeforeAndAfterRunTaskMock(TaskProgress progress) {
            progress.OnReport += (_, args) => {
                _callOrder += args.Status switch {
                    TaskStatus.Started => "s",
                    TaskStatus.Finished => "f",
                    _ => throw new ArgumentOutOfRangeException()
                };
            };
        }

        public override void Run() {
            base.Run();
            _callOrder += "r";
        }

        public void Verify() {
            Assert.AreEqual("srf", _callOrder);
        }
    }
}