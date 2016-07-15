# Progressor
====================================
Calculate progress - simple, fast, versatile, cross-platform

Progressor makes calculation of progress as simple as enumerating a collection:

    foreach (var x in Enumerable.Range(1, 200).AsProgressive()) {
        Console.WriteLine($"CurrentValue: {x.Item}");
        Console.WriteLine($"Iteration {x.Iteration} / {x.Total} ({x.Percent})");
    }

>CurrentValue: 42  
>Iteration 42 / 200 (20,5%)

You can "descent" into deeper iterations, maintaining gloabl and local progress:

    foreach (var x in Enumerable.Range(1, 200).AsProgressive()) {
        foreach (var y in Enumerable.Range(1, 100).AsProgressive(x)) {
            foreach (var z in Enumerable.Range(1, 50).AsProgressive(z)) {
                Console.WriteLine($"Iteration y {z.Iteration} / {z.Total} ({z.Percent})");
                Console.WriteLine($"Iteration y {y.Iteration} / {y.Total} ({y.Percent})");
                Console.WriteLine($"Iteration x {x.Iteration} / {x.Total} ({x.Percent})");
            }
        }
    }

>Iteration z 10 / 50 (20%)  
>Iteration y 25 / 100 (25.20%)  
>Iteration x 100 / 200 (50.2520%)

If you ever found yourself figuring out this nasty percent-calculation formular in excel for the 1000´s time, this lib is for you!

It even comes with two handy extension methods
for calculating values
    Console.WriteLine(42.PercentOf(200));
>84
or percentage
    Console.WriteLine(84.AsPercentOf(200));
>42

## how to start?
------------------------------------

grab the [NuGet-Package] (https://nuget.org/earloc/Progressor) or install directly via
> PM> Install-Package Progressor

and make sure to check out the [Wiki-Page] (https://github.com/earloc/Progressor/wiki)