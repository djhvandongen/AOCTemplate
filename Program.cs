using System;
using System.Collections.Generic;

namespace AOC
{
    class Program
    {
        static Day[] Days = new Day[25];
        static void Main(string[] args)
        {
            AddDays();
            PrintDoubleLine();
            Console.WriteLine("|| Day | Part 1 Answer | Part 1 Time | Part 2 Answer | Part 2 Time ||");
            PrintLine();

            List<int> indexes = GetIndexes(args);
            List<(float, float)> times = new List<(float, float)>();
            foreach(int id in indexes) 
            {
                times.Add(Days[id-1].Solve());
            }

            PrintDoubleLine();

            List<float> firsts = new List<float>(), seconds = new List<float>();
            foreach((float, float) time in times) 
            {
                firsts.Add(time.Item1);
                seconds.Add(time.Item2);
            }
            float firstMean = GetMean(firsts);
            float secondMean = GetMean(seconds);

            string firstMeanStr = firstMean.ToString("0.000");
            string secondMeanStr = secondMean.ToString("0.000");
            Console.WriteLine("||                     | Part 1 Mean |               | Part 2 Mean ||");
            PrintLine();
            Console.WriteLine(String.Format("||                     |{0,10} s |               |{1,10} s ||", firstMeanStr, secondMeanStr));
            PrintDoubleLine();
        }

        // Day N needs to added as Days[N - 1] = new DayN();
        static void AddDays() 
        {
            Days[0] = new Day01();
        }

        static List<int> GetIndexes(string[] args) 
        {
            List<int> result = new List<int>();

            // If there are no arguments supplied, add all days to the output.
            if (args.Length < 1) 
            {
                for (int i = 1; i <= Days.Length; i++) 
                {
                    if (Days[i-1] != null) result.Add(i);
                }
                return result;
            }

            // If not, iterate through all arguments and try to add them.
            foreach(string arg in args) 
            {
                // We firstly want to find out if we're dealing with a single number.
                if (int.TryParse(arg, out int nr)) 
                {
                    if (nr < 1 || nr > 25) throw new ArgumentOutOfRangeException("Argument exceeds bounds of 1 - 25 inclusive");
                    if (Days[nr-1] == null) throw new ArgumentException($"Day {nr} does not yet exist in the repository!");
                    result.Add(nr);
                    continue;
                }
                
                // The current argument is not a single number, so we want to process a range input.
                string[] range = arg.Split("..");
                if (range.Length != 2) throw new ArgumentException("Wrong input syntax. The syntax of X..Y is required, where X and Y are integers");

                // It is necessary to define them here, as max might not get defined when range[0] can't get parsed, due to lazy OR evaluation.
                int min, max = 0;
                if (int.TryParse(range[0], out min) && (int.TryParse(range[1], out max))) 
                {
                    if (min < 1 || max < 1 || min > 25 || max > 25) throw new ArgumentOutOfRangeException("Argument exceeds bounds of 1 - 25 inclusive");
                    if (min > max) throw new ArgumentException("The minimum bound can't be larger than the maximum bound.");

                    for(int i = min; i <= max; i++) {
                        if(result.Contains(i)) throw new ArgumentException($"Day {i} is already present! Please refrain from entering the same number twice or more");
                        if (Days[i-1] == null) throw new ArgumentException($"Day {i} does not yet exist in the repository!");
                        result.Add(i);
                    }
                }
                
                else throw new ArgumentException("Wrong input type. The type of X..Y is required, where X and Y are integers");
            }
            return result;
        }

        static void PrintLine() 
        {
            Console.WriteLine("---------------------------------------------------------------------");     
        }
        static void PrintDoubleLine() 
        {
            Console.WriteLine("=====================================================================");
        }

        static float GetMean(List<float> fs) 
        {
            float result = 0;
            foreach(float f in fs) {
                result += f;
            }
            return result / fs.Count;
        }
    }
}
