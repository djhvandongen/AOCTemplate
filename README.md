# AOCTemplate
A template for Advent of Code in C#

This template can be used by creating classes in the form of ```DayXX.cs```, where XX is in the range of 01 - 25. Observe that Days 1-9 need a 0 as prefix to obtain a two digit suffix to Day. They also need to derive from ``Day.cs`` and implement both ``public override string SolvePartOne()`` and ``public override string SolvePartTwo``. Integrating such a class needs to be done through adding an entry in the ``AddDays()`` method in ``Program.cs``, as has been done with the example class.

Those classes should go in the Code folder.

The input files have the same name convention, but a .txt extension, e.g. ``DayXX.txt``. 

These should go in the Input folder.

# Running the framework

To run the framework, you can simply do ```dotnet build``` and ```dotnet run```. Running it will run all the days which are currently implemented. You can also pass along the days you want to run. You can do this in four ways:
- One single day:        ``dotnet run 1`` runs only Day 1.
- Multiple single days:  ``dotnet run 1 2 4`` runs Days 1, 2 and 4.
- A range of days:       ``dotnet run 4..7`` runs Days 4, 5, 6, and 7.
- Combining these:       ``dotnet run 1 3..5 9`` runs Days 1, 3, 4, 5 and 9.
