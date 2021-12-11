using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Day6
{
    public class Solution : ISolution
    {
        public void Calculate()
        {
            PartOne();
            PartTwo();
        }

        private void PartTwo()
        {
            Console.WriteLine($"Part 1: {ComputeLanthernExpansion(256)}");
        }
        private void PartOne()
        {
            Console.WriteLine($"Part 1: {ComputeLanthernExpansion(80)}");
        }

        private ulong ComputeLanthernExpansion(int days)
        {
            Dictionary<int, ulong> fishes = GetFreshFishDict();
            Dictionary<int, ulong> fishesNew = GetFreshFishDict();

            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day6\input.txt"))
            {
                var charArr = line.Split(",");

                foreach (var stuff in charArr)
                {
                    fishes[int.Parse(stuff)] += 1;
                }

            }


            for (int i = 0; i < days; i++)
            {
                foreach (var fishday in fishes)
                {
                    // Respawn
                    if (fishday.Key == 0)
                    {
                        fishesNew[6] += fishes[fishday.Key];
                        fishesNew[8] += fishes[fishday.Key];
                    }
                    else
                    {
                        fishesNew[fishday.Key - 1] += fishes[fishday.Key];
                    }
                }

                // reset
                fishes = fishesNew;
                fishesNew = GetFreshFishDict();

            }

            ulong fishCount = 0;
            foreach (var fish in fishes)
            {
                fishCount += fishes[fish.Key];
            }

            return fishCount;
        }

        private Dictionary<int, ulong> GetFreshFishDict()
        {
            return new Dictionary<int, ulong>()
                {
                    {0, 0 },
                    {1, 0 },
                    {2, 0 },
                    {3, 0 },
                    {4, 0 },
                    {5, 0 },
                    {6, 0 },
                    {7, 0 },
                    {8, 0 },
                };
        }

    }
}
