using CommandLine;
using eawx_build_lua.CLI;
using NLua;

namespace eawx_build_lua {
    class Program {
        static void Main(string[] args) {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Exec);
        }

        static void Exec(Options options) {
            EawXBuildApplication app = new EawXBuildApplication(options);
            var exitCode = app.Run();
            System.Environment.ExitCode = (int) exitCode;
        }
    }
}