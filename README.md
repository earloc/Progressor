# Progressor
====================================
Calculate progress - simple, fast, versatile, cross-platform

## how to start?
------------------------------------

grab the [NuGet-Package] (https://nuget.org/earloc/Progressor) or install directly via
> PM> Install-Package Progressor

use it

    foreach (var x in Enumerable.Range(1, 750).AsProgressive())
        WriteLine(1, $"Item: {x.Item} / {items.Count}, Progress: {x.Progress}%, Percent: {x.Percent} %");

and make sure to check out the [Wiki-Page] (https://github.com/earloc/Progressor/wiki)