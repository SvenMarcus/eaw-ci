using CommandLine;
using EawXBuild.Configuration;
using EawXBuild.Configuration.CLI;

namespace eawx_build_lua.CLI {
    [Verb("run", true, HelpText = "Run a CI project from an optionally specified configuration file.")]
    public class Options : IOptions {
        public ConfigVersion Version { get; }
        public bool Verbose { get; }

        [Option('c', "config", Required = false, HelpText = "The relative or absolute path to the configuration file.",
            Default = ".eaw-ci.lua")]
        public string ConfigPath { get; set; }
        
        [Option('p', "project", Required = true, HelpText = "Name of the CI project to run.")]
        public string ProjectName { get; set; }

        [Option('j', "job", Required = false, HelpText = "Name of a job specified within a CI project to run.")]
        public string JobName { get; set; }
    }
}