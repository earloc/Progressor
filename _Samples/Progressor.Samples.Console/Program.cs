using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

namespace Progressor.Samples.Console {
    class Program {

        private class IntWithRange {
            public IntWithRange(int value) {
                Value = value;
            }

            public int Value { get; }

            public IEnumerable<IntWithRange> Children { get; set; }

        }

        static void Main(string[] args) {
            System.Console.CursorVisible = false;
            LinearProgress();

            ThreeDimensionalLinearProgress().Wait();
        }

        private static async Task ThreeDimensionalLinearProgress() {
            var random = new Random();
            var hierarchy = from i in Enumerable.Range(1, 3)
                            select new IntWithRange(i) {
                            Children = from j in Enumerable.Range(1, random.Next(1, 6))
                                        select new IntWithRange(i * j) {
                                        Children = from k in Enumerable.Range(1, random.Next(1, 12))
                                                   select new IntWithRange(i * j * k) {
                                                       Children = from m in Enumerable.Range(1, random.Next(1, 24))
                                                                  select new IntWithRange(i * j * k * m)
                                                   }
                                     }
                            };
            foreach (var a in hierarchy.AsProgressive().Poll( p => WriteLine(0, $"Overall Progress: {p} %"))) {
                foreach (var b in a.Item.Children.AsProgressive(a)) {
                    foreach (var c in b.Item.Children.AsProgressive(b)) {
                        WriteLine(2, $"1st level Item         {a.Iteration} / {a.Total} ({a.Percent}%)");
                        WriteLine(4, $" 2nd level Item         {b.Iteration} / {b.Total} ({b.Percent}%)");
                        WriteLine(6, $"  3rd level Item         {c.Iteration} / {c.Total} ({c.Percent}%)");
                        await Task.Delay(50);
                    }
                }
            }

            System.Console.ReadKey();
        }

        private static void LinearProgress() {
            var rand = new Random();

            foreach (var x in Enumerable.Range(1, 200).AsProgressive()) {
                WriteLine(1, $"CurrentValue: {x.Item}");
                WriteLine(2, $"Iteration {x.Iteration} / {x.Total} ({x.Percent})");

                //WriteLine(1, $"Item: {x.Item} / {items.Count}, Progress: {x.Progress}%, Percent: {x.Percent} %, Index: {x.Index}");
                Thread.Sleep(rand.Next(100));
            }

            System.Console.WriteLine("done");
            System.Console.ReadKey();
        }

        private static object _ConsoleLock = new object();
        private static void WriteLine(int line, string message) {
            lock (_ConsoleLock) {
                System.Console.CursorTop = line;
                System.Console.CursorLeft = 0;
                System.Console.WriteLine(message.PadRight(80));
            }
        }
    }
}
