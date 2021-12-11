using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day1
{
    public class Solution : ISolution
    {
        public void Calculate()
        {
            List<int> input = new List<int>();
            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day1\TextFile1.txt"))
            {
                input.Add(int.Parse(line));
            }

            PartOne(input);
            PartTwo(input);
        }

        private void PartTwo(List<int> input)
        {
            int counter = 0;

            for (int i = 0; i < input.Count; i++)
            {
                //Console.WriteLine($"i: {i + 4}, Total: {test.Count}");
                if (input.Count < i + 4) break;

                var first = input[i] + input[i + 1] + input[i + 2];
                var second = input[i + 1] + input[i + 2] + input[i + 3];

                if (second > first) counter++;

            }

            Console.WriteLine($"Part 2: {counter}");
        }

        private void PartOne(List<int> input)
        {
            int counter = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (i != 0)
                {
                    if (input[i] > input[i - 1]) counter++;
                }
            }

            Console.WriteLine($"Part 1: {counter}");
        }

    }
}
