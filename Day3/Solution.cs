using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Day3
{
    public class Solution : ISolution
    {
        public void Calculate()
        {
            List<string> input = new List<string>();

            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day3\input.txt"))
            {
                input.Add(line);
            }

            PartOne(input);
            PartTwo(input);
        }

        private void PartTwo(List<string> input)
        {
            var ogygenRating = GetOxygenRating(input, 0);
            var co2ScrubberRating = GetCO2ScrubberRating(input, 0);

            //Console.WriteLine($"Oxygen rating: {Convert.ToInt32(ogygenRating[0], 2)}");
            //Console.WriteLine($"Oxygen rating: {Convert.ToInt32(co2ScrubberRating[0], 2)}");
            Console.WriteLine($"Part 2: {Convert.ToInt32(co2ScrubberRating[0], 2) * Convert.ToInt32(ogygenRating[0], 2)}");
        }

        private void PartOne(List<string> input)
        {
            List<int> gammaRate = new List<int>(new int[12]);

            foreach (var bin in input)
            {
                var charArray = bin.ToCharArray();

                for (int i = 0; i < charArray.Length; i++)
                {
                    gammaRate[i] += int.Parse(charArray[i].ToString());
                }

            }

            var threshold = input.Count / 2;

            for (int i = 0; i < gammaRate.Count; i++)
            {
                if (gammaRate[i] > threshold)
                {
                    gammaRate[i] = 1;
                }
                else
                {
                    gammaRate[i] = 0;
                }
            }

            List<int> epsilonRate = new List<int>();

            gammaRate.ForEach(gr =>
            {
                var inverted = (gr ^= 1);
                epsilonRate.Add(inverted);
            });

            var gammaRateString = "";
            var epsilonString = "";

            gammaRate.ForEach(gr => gammaRateString += gr);
            epsilonRate.ForEach(gr => epsilonString += gr);

            Console.WriteLine($"Part 1: {Convert.ToInt32(gammaRateString, 2) * Convert.ToInt32(epsilonString, 2)}");
        }

        private int FindNumberOfOnes(List<string> list, int position)
        {
            var foundOnes = 0;
            list.ForEach(binStr =>
            {
                foundOnes += int.Parse(binStr[position].ToString());
            });

            return foundOnes;
        }

        private List<string> GetCO2ScrubberRating(List<string> temp, int position)
        {
            var foundOnes = 0;
            temp.ForEach(binStr =>
            {
                var charArray = binStr.ToCharArray();
                foundOnes += int.Parse(charArray[position].ToString());
            });

            //Console.WriteLine($"FOund ones old: {foundOnes}");
            //Console.WriteLine($"FOund ones new: {FindNumberOfOnes(temp, position)}");

            var threshold = Math.Ceiling((double)temp.Count / 2);
            var arrayToKeep = new List<string>();

            if (foundOnes >= threshold)
            {
                arrayToKeep = temp.Where(binStr => binStr.ToCharArray()[position] == '0').ToList();
            }
            else
            {
                arrayToKeep = temp.Where(binStr => binStr.ToCharArray()[position] == '1').ToList();
            }

            //Console.WriteLine($"Keeping {arrayToKeep.Count} values on iteration {position}");


            if (arrayToKeep.Count > 1)
            {
                return GetCO2ScrubberRating(arrayToKeep, position + 1);
            }

            return arrayToKeep;
        }

        private List<string> GetOxygenRating(List<string> temp, int position)
        {
            var foundOnes = 0;
            temp.ForEach(binStr =>
            {
                var charArray = binStr.ToCharArray();
                foundOnes += int.Parse(charArray[position].ToString());
            });

            var threshold = Math.Ceiling((double)temp.Count / 2);
            var arrayToKeep = new List<string>();

            if (foundOnes >= threshold)
            {
                arrayToKeep = temp.Where(binStr => binStr.ToCharArray()[position] == '1').ToList();
            }
            else
            {
                arrayToKeep = temp.Where(binStr => binStr.ToCharArray()[position] == '0').ToList();
            }

            //Console.WriteLine($"Keeping {arrayToKeep.Count} values on iteration {position}");


            if (arrayToKeep.Count > 1)
            {
                return GetOxygenRating(arrayToKeep, position + 1);
            }

            return arrayToKeep;
        }
    }
}
