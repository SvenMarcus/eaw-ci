using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using eawx_build_lua.CLI;
using EawXBuild.Core;
using EawXBuild.Environment;
using EawXBuild.Exceptions;
using NLua;

namespace eawx_build_lua {
    public class EawXBuildApplication {
        private readonly Options _options;

        public EawXBuildApplication(Options options) {
            _options = options;
        }

        public ExitCode Run() {
            ProjectBuilder builder = new ProjectBuilder();
            using Lua lua = SetUpLuaEnvironment(builder);
            lua.DoFile(_options.ConfigPath);

            var project = GetProject(builder, _options);
            if (project == null) {
                Console.WriteLine($"No project found for name \"{_options.ProjectName}\".");
                return ExitCode.ExConfig;
            }

            try {
                RunJob(project, _options.JobName);
            } catch (JobNotFoundException exception) {
                Console.WriteLine($"No job found for name \"{_options.JobName}\"");
                return ExitCode.ExConfig;
            } catch (Exception exception) {
                Console.WriteLine($"An error occurred during the execution of the Job \"{_options.JobName}\"");
                Console.WriteLine(exception.InnerException?.Message);
                return ExitCode.ExConfig;
            }

            return ExitCode.Success;
        }

        private static Lua SetUpLuaEnvironment(ProjectBuilder builder) {
            Lua lua = new Lua();
            lua.State.Encoding = Encoding.UTF8;
            lua.DoString("function import() end");
            LuaRegistrationHelper.TaggedInstanceMethods(lua, builder);
            LoadBuildUtilityFunctions(lua);
            return lua;
        }

        private static Project GetProject(ProjectBuilder builder, Options options) {
            var projectWrapper = builder.Projects.Find(wrapper => wrapper.Project.Name.Equals(options.ProjectName));
            var project = projectWrapper?.Project;
            return project;
        }

        private static void RunJob(IProject project, string jobName) {
            var jobAsync = project.RunJobAsync(jobName);
            Task.WaitAll(jobAsync);
            if (jobAsync.Exception != null)
                throw jobAsync.Exception;
        }

        private static void LoadBuildUtilityFunctions(Lua lua) {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("eawx_build_lua.build_utilities.lua");
            var build_utilities = new StreamReader(stream).ReadToEnd();
            lua.DoString(build_utilities);
        }
    }
}