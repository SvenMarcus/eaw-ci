using System.IO.Abstractions.TestingHelpers;
using EawXBuild.Configuration.Lua.v1;
using EawXBuild.Steam;
using EawXBuildTest.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLua;
using static EawXBuildTest.Configuration.Lua.v1.NLuaUtilities;

namespace EawXBuildTest.Configuration.Lua.v1
{
    [TestClass]
    public class EawCiLuaEnvironmentTest
    {
        private LuaMockFileSystemParser _luaParser;

        [TestInitialize]
        public void SetUp()
        {
            _luaParser = new LuaMockFileSystemParser(new MockFileSystem());
        }

        [TestCleanup]
        public void TearDown()
        {
            _luaParser.Dispose();
        }

        [TestMethod]
        public void WhenCallingCopy__ShouldCallBuildComponentFactoryWithCopyTaskName()
        {
            BuildComponentFactorySpy factorySpy = new BuildComponentFactorySpy();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factorySpy, _luaParser);
            sut.Copy(string.Empty, string.Empty);

            Assert.AreSame("Copy", factorySpy.ActualTaskTypeName);
        }

        [TestMethod]
        public void WhenCallingCopy__ShouldReturnLuaCopyTask()
        {
            BuildComponentFactoryStub factoryStub = new BuildComponentFactoryStub();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factoryStub, _luaParser);
            ILuaTask actual = sut.Copy(string.Empty, string.Empty);

            Assert.IsInstanceOfType(actual, typeof(LuaCopyTask));
        }

        [TestMethod]
        public void WhenCallingLink__ShouldCallBuildComponentFactoryWithSoftCopyTaskName()
        {
            BuildComponentFactorySpy factorySpy = new BuildComponentFactorySpy();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factorySpy, _luaParser);
            sut.Link(string.Empty, string.Empty);

            Assert.AreSame("SoftCopy", factorySpy.ActualTaskTypeName);
        }

        [TestMethod]
        public void WhenCallingLink__ShouldReturnLuaCopyTask()
        {
            BuildComponentFactoryStub factoryStub = new BuildComponentFactoryStub();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factoryStub, _luaParser);
            ILuaTask actual = sut.Link(string.Empty, string.Empty);

            Assert.IsInstanceOfType(actual, typeof(LuaCopyTask));
        }

        [TestMethod]
        public void WhenCallingClean__ShouldCallBuildComponentFactoryWithCleanTaskName()
        {
            BuildComponentFactorySpy factorySpy = new BuildComponentFactorySpy();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factorySpy, _luaParser);
            sut.Clean(string.Empty);

            Assert.AreSame("Clean", factorySpy.ActualTaskTypeName);
        }

        [TestMethod]
        public void WhenCallingClean__ShouldReturnLuaCleanTask()
        {
            BuildComponentFactorySpy factorySpy = new BuildComponentFactorySpy();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factorySpy, _luaParser);
            ILuaTask actual = sut.Clean(string.Empty);

            Assert.IsInstanceOfType(actual, typeof(LuaCleanTask));
        }

        [TestMethod]
        public void WhenCallingRunProcess__ShouldCallBuildComponentFactoryWithRunProgramTaskName()
        {
            BuildComponentFactorySpy factorySpy = new BuildComponentFactorySpy();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factorySpy, _luaParser);
            sut.RunProcess(string.Empty);

            Assert.AreSame("RunProgram", factorySpy.ActualTaskTypeName);
        }

        [TestMethod]
        public void WhenCallingRunProcess__ShouldReturnLuaRunProcessTask()
        {
            BuildComponentFactorySpy factorySpy = new BuildComponentFactorySpy();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factorySpy, _luaParser);
            ILuaTask actual = sut.RunProcess(string.Empty);

            Assert.IsInstanceOfType(actual, typeof(LuaRunProcessTask));
        }

        [TestMethod]
        public void
            WhenCallingCreateSteamWorkshopItem__ShouldCallBuildComponentFactoryWithCreateWorkshopItemTaskName()
        {
            BuildComponentFactorySpy factorySpy = new BuildComponentFactorySpy();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factorySpy, _luaParser);

            LuaTable table = MakeLuaTable(_luaParser.Lua, "the_table");
            sut.CreateSteamWorkshopItem(table);

            Assert.AreSame("CreateSteamWorkshopItem", factorySpy.ActualTaskTypeName);
        }

        [TestMethod]
        public void WhenCallingCreateSteamWorkshopItem__ShouldReturnLuaCreateSteamWorkshopItemTask()
        {
            BuildComponentFactorySpy factorySpy = new BuildComponentFactorySpy();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factorySpy, _luaParser);

            LuaTable table = MakeLuaTable(_luaParser.Lua, "the_table");
            ILuaTask actual = sut.CreateSteamWorkshopItem(table);

            Assert.IsInstanceOfType(actual, typeof(LuaCreateSteamWorkshopItemTask));
        }

        [TestMethod]
        public void
            WhenCallingUpdateSteamWorkshopItem__ShouldCallBuildComponentFactoryWithUpdateWorkshopItemTaskName()
        {
            BuildComponentFactorySpy factorySpy = new BuildComponentFactorySpy();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factorySpy, _luaParser);

            LuaTable table = MakeLuaTable(_luaParser.Lua, "the_table");
            sut.UpdateSteamWorkshopItem(table);

            Assert.AreSame("UpdateSteamWorkshopItem", factorySpy.ActualTaskTypeName);
        }

        [TestMethod]
        public void WhenCallingUpdateSteamWorkshopItem__ShouldReturnLuaUpdateSteamWorkshopItemTask()
        {
            BuildComponentFactorySpy factorySpy = new BuildComponentFactorySpy();
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(factorySpy, _luaParser);

            LuaTable table = MakeLuaTable(_luaParser.Lua, "the_table");
            ILuaTask actual = sut.UpdateSteamWorkshopItem(table);

            Assert.IsInstanceOfType(actual, typeof(LuaUpdateSteamWorkshopItemTask));
        }

        [TestMethod]
        public void GivenNewEawCiLuaEnvironment__OnCreation__ShouldPushVisibilityTableToLuaEnvironment()
        {
            EawCiLuaEnvironment sut = new EawCiLuaEnvironment(new BuildComponentFactoryStub(), _luaParser);

            LuaTable visibilityTable = _luaParser.Lua.GetTable("visibility");
            Assert.AreEqual(visibilityTable["private"], WorkshopItemVisibility.Private);
            Assert.AreEqual(visibilityTable["public"], WorkshopItemVisibility.Public);
        }
    }
}