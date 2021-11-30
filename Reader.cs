using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Reader 
{
    public string[] Read(string day) 
    {
        // The day parameter has to be in the form of XY, where X is in {0..2} and Y is in {0..9}
        if (!int.TryParse(day, out int dayNr)) throw new ArgumentException("The argument needs to be an integer with two digits.");
        if (dayNr < 1 || dayNr > 25)           throw new ArgumentOutOfRangeException();

        StreamReader sr = new StreamReader($"Input/Day{day}");
        List<string> result = new List<string>();
        string line;

        while((line = sr.ReadLine()) != null) 
        {
            result.Add(line);
        }

        return result.ToArray();
    }
}