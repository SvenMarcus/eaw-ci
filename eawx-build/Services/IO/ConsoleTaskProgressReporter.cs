using System;
using EawXBuild.Core;

namespace EawXBuild.Services.IO {
    public class ConsoleTaskProgressReporter {

        public ConsoleTaskProgressReporter(TaskProgress progress) {
            progress.OnReport += (sender, args) => {
                switch (args.Status) {
                    case TaskStatus.Started:
                        OnStartedReport(args);
                        break;
                    case TaskStatus.Finished:
                        OnFinishedReport(args);
                        break;
                    case TaskStatus.Failed:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                };
            };
        }

        private static void OnStartedReport(TaskProgressEventArgs args) {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Start");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"     ] {args.Task.GetType().Name} - Id: {args.Task.Id} - Name: {args.Task.Name}" + System.Environment.NewLine);
        }

        private static void OnFinishedReport(TaskProgressEventArgs args) {
            Console.Write("[       ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("End");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"] {args.Task.GetType().Name} - Id: {args.Task.Id} - Name: {args.Task.Name}" + System.Environment.NewLine);
        }
    }
}