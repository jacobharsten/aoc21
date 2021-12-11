using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Day7
{
    public class Solution : ISolution
    {
        public void Calculate()
        {
            List<int> crabs = new List<int>();
            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day7\input.txt"))
            {
                var charArr = line.Split(",");

                foreach (var stuff in charArr)
                {
                    crabs.Add(int.Parse(stuff));
                }
            }

            PartOne(crabs);
            PartTwo(crabs);
        }

        private void PartTwo(List<int> crabs)
        {
            var sum = -1;
            var maxCrab = crabs.Max();
            var minCrab = crabs.Min();

            for (int i = minCrab; i < maxCrab + 1; i++)
            {
                var tempSum = 0;

                foreach (var crab in crabs)
                {
                    tempSum += ComputeFuel(crab, i);
                }

                if (sum == -1) sum = tempSum;
                if (tempSum < sum) sum = tempSum;
            }

            Console.WriteLine($"Part 2: {sum}");
        }
        private void PartOne(List<int> crabs)
        {
            crabs.Sort();

            var median = crabs[crabs.Count / 2];

            var totalCount = 0;
            crabs.ForEach(crab => totalCount += crab);

            var fuelSum = 0;

            crabs.ForEach(crab => fuelSum += ComputeFuelCostForOneCrap(crab, median));

            Console.WriteLine($"Part 1: {fuelSum}");

        }

        private int ComputeFuel(int position, int target)
        {
            var iterations = Math.Abs(position - target);
            var fuelSpent = 0;

            for(int i=1; i<iterations+1; i++)
            {
                fuelSpent += i;
            }
            return fuelSpent;
        }

        private int ComputeFuelCostForOneCrap(int position, int target)
        {
            return Math.Abs(position - target);
        }
    }
}
