using System;
using System.Diagnostics;
using System.IO;

public class Day 
{
    protected string DayNumber;
    protected string[] Input;
    protected virtual string SolvePartOne() => "None";
    protected virtual string SolvePartTwo() => "None";
    private ConsoleColor cc = ConsoleColor.White;

    public Day(string dayNumber) 
    {
        DayNumber = dayNumber;
    }

    public void Solve() 
    {
        Reader reader = new Reader();
        Input = reader.Read(DayNumber);
        Stopwatch sw = new Stopwatch();

        sw.Start();
        string partOneAnswer = SolvePartOne();
        sw.Stop();
        string partOneTime = sw.ElapsedMilliseconds.ToString("0.000");
        sw.Reset();

        sw.Start();
        string partTwoAnswer = SolvePartTwo();
        sw.Stop();
        string partTwoTime = sw.ElapsedMilliseconds.ToString("0.000");
        sw.Reset();

        // Console.WriteLine(String.Format("|{0,4} |{1,14} |{2,9} ms |{3,14} |{4,9} ms |", DayNumber, partOneAnswer, partOneTime, partTwoAnswer, partTwoTime));
        Console.Write(String.Format("|{0,4} |{1,14} |", DayNumber, partOneAnswer));

        Console.ForegroundColor = GetColor(partOneTime);
        Console.Write(String.Format("{0,9}", partOneTime));
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" ms |");

        Console.Write(String.Format("{0,14} |", partTwoAnswer));

        Console.ForegroundColor = GetColor(partTwoTime);
        Console.Write(String.Format("{0,9}", partTwoTime));
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" ms |\n");
    }

    private ConsoleColor GetColor(string time) 
    {
        float f_time = float.Parse(time);
        if (f_time <= 0.1f)
            return ConsoleColor.DarkGreen;
        else if (f_time <= 0.5f)
            return ConsoleColor.Green;
        else if (f_time <= 1f)
            return ConsoleColor.Yellow;
        else if (f_time <= 2f)
            return ConsoleColor.DarkYellow;
        else if (f_time <= 5f)
            return ConsoleColor.Red;
        else
            return ConsoleColor.DarkRed;

    }
}