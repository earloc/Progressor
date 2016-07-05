using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Progressor.Extensions;

namespace Progressor.Samples.Console {
    class Program {
        static void Main(string[] args) {

            LinearProgress();

            NonLinearProgress();
        }

        private static void NonLinearProgress() {
        }

        private static void LinearProgress() {
            var items = Enumerable.Range(1, 750).AsProgressive();

            items.ProgressChanged += (sender, e) => WriteLine(0, $"Progress: {e.Current}%");

            var rand = new Random();

            foreach (var x in items) {
                WriteLine(1, $"Item: {x.Item} / {items.Count}, Progress: {x.Progress}%, Percent: {x.Percent} %");
                Thread.Sleep(rand.Next(100));
            }

            System.Console.WriteLine("done");
            System.Console.ReadKey();
        }

        private static void WriteLine(int line, string message) {
            System.Console.CursorTop = line;
            System.Console.CursorLeft = 0;
            System.Console.WriteLine(message.PadRight(80));
        }
    }
}
