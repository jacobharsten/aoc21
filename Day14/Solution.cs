using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Day14
{
    public class Solution : ISolution
    {
        private Dictionary<string, string> pairInsertion = new Dictionary<string, string>();
        private Dictionary<string, ulong> pairs = new Dictionary<string, ulong>();
        private Dictionary<string, ulong> tempPairs = new Dictionary<string, ulong>();
        private Dictionary<string, ulong> letterCount = new Dictionary<string, ulong>();
        public void Calculate()
        {
            ReadInput();
            Console.WriteLine($"Part 1: {CalculatePolymer(10)}");
            Console.WriteLine($"Part 2: {CalculatePolymer(40)}");
        }

        private double CalculatePolymer(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                tempPairs = new Dictionary<string, ulong>();

                foreach (var kvp in pairs)
                {
                    var toInsert = pairInsertion[kvp.Key];

                    string first = kvp.Key[0] + toInsert;
                    string second = toInsert + kvp.Key[1];

                    tempPairs.TryGetValue(first, out ulong currentPairCount);
                    tempPairs[first] = currentPairCount + kvp.Value;

                    tempPairs.TryGetValue(second, out currentPairCount);
                    tempPairs[second] = currentPairCount + kvp.Value;

                }
                pairs = new Dictionary<string, ulong>(tempPairs);
            }

            foreach (var kvp in pairs)
            {
                letterCount.TryGetValue(kvp.Key[0].ToString(), out ulong first);
                letterCount[kvp.Key[0].ToString()] = first + kvp.Value;

                letterCount.TryGetValue(kvp.Key[1].ToString(), out ulong second);
                letterCount[kvp.Key[1].ToString()] = second + kvp.Value;
            }

            return GetResultFromDict(letterCount);
        }

        private double GetResultFromDict(Dictionary<string, ulong> kvp)
        {
            var max = Math.Ceiling((double)kvp.Values.Max() / 2.0);
            var min = Math.Ceiling((double)kvp.Values.Min() / 2.0);

            return max - min;
        }

        private void ReadInput()
        {
            var input = System.IO.File.ReadAllLines(@"C:\Work\AdventOfCode2021\Day14\input.txt").ToList();
            var code = input[0];

            for(int i=0; i< code.Length-1; i++)
            {
                var tempPair = code[i].ToString() + code[i + 1].ToString();
                pairs.TryGetValue(tempPair, out ulong currentCount);
                pairs[tempPair] = currentCount + 1;
            }

            input.ForEach(line =>
            {
                if(line.Contains("->"))
                {
                    var charArr = line.Split(" -> ");
                    pairInsertion.Add(charArr[0], charArr[1]);
                }
            });
        }
    }
}
