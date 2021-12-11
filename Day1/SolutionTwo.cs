using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day1
{
    public class SolutionTwo
    {
        public void CountSlidingWindow()
        {
            int counter = 0;
            List<int> temp = new List<int>();

            /* Refactor this */
            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day1\TextFile1.txt"))
            {
                temp.Add(int.Parse(line));
            }

            for (int i = 0; i < temp.Count; i++)
            {
                //Console.WriteLine($"i: {i + 4}, Total: {test.Count}");
                if (temp.Count < i + 4) break;

                var first = temp[i] + temp[i + 1] + temp[i + 2];
                var second = temp[i + 1] + temp[i + 2] + temp[i + 3];

                if (second > first) counter++;
                
            }

            Console.WriteLine(counter);
        }
        
}
}
