using System.Collections.Generic;
using NLua;

namespace eawx_build_lua {
    public class ProjectBuilder {
        [LuaHide]
        public List<ProjectWrapper> Projects { get; } = new List<ProjectWrapper>();
        
        [LuaGlobal(Name = "project")]
        public ProjectWrapper Project(string name) {
            var project = new ProjectWrapper(name);
            Projects.Add(project);
            return project;
        }
        
        [LuaGlobal(Name = "copy")]
        public CopyTaskWrapper Copy(string source, string target) {
            return new CopyTaskWrapper(source, target);
        }

        [LuaGlobal(Name = "link")]
        public LinkTaskWrapper Link(string source, string target) {
            return new LinkTaskWrapper(source, target);
        }
        
        [LuaGlobal(Name = "clean")]
        public CleanTaskWrapper Clean(string path) {
            return new CleanTaskWrapper(path);
        }

        [LuaGlobal(Name = "run_process")]
        public RunProcessTaskWrapper RunProcess(string path, string args) {
            return new RunProcessTaskWrapper(path, args);
        }
    }
}