# Progressor
Calculate progress - simple, fast, versatile, cross-platform

# how does it work?
Simple:
  var items = Enumerable.Range(1, 750).AsProgressive();

items.ProgressChanged += (sender, e) => WriteLine(0, $"Progress: {e.Current}%");

var rand = new Random();

foreach (var x in items) {
    WriteLine(1, $"Item: {x.Item} / {items.Count}, Progress: {x.Progress}%, Percent: {x.Percent} %");
    Thread.Sleep(rand.Next(100));
}

System.Console.WriteLine("done");
System.Console.ReadKey();