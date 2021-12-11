using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Day8
{
    public class Solution: ISolution
    {

        public void Calculate()
        {
            PartOne();
            PartTwo();
            
        }

        private void PartTwo()
        {
            Dictionary<int, string> temp = new Dictionary<int, string>
            {
                {1,""}, // a
                {2,""}, // b
                {3,""}, // c
                {4,""}, // d
                {5,""}, // e
                {6,""}, // f
                {7,""}, // g
            };


            var totalValue = 0;

            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day8\input.txt"))
            {
                var initialSplit = line.Split(" | ");
                var charArr = initialSplit[0].Split(" ");

                //var output = charArr[1].Split(" ");
                // 4th mix up 0 and 6;

                foreach (var stuff in charArr)
                {
                    // Determine set up
                    if (stuff.Length == 2) { temp[1] = stuff; } // 1
                    if (stuff.Length == 3) { temp[7] = stuff; } // 7
                    if (stuff.Length == 4) { temp[4] = stuff; } // 4
                    if (stuff.Length == 7) { temp[8] = stuff; } // 8
                }

                foreach (var five in charArr)
                {
                    // can be 2,3 or 5;
                    if (five.Length == 5)
                    {
                        if (CharactersContainsInString(temp[7], five)) temp[3] = five;
                    }

                    // can be 0,6 or 9
                    if (five.Length == 6)
                    {
                        if (CharactersContainsInString(temp[4], five)) temp[9] = five;
                        else
                        {
                            // can only be 0 or 6
                            // take 4 - 1 => remaining exists only in 6
                            var oneCharArr = temp[1];
                            var fourMinusOne = temp[4].Replace(oneCharArr[0].ToString(), "").Replace(oneCharArr[1].ToString(), "");

                            if (CharactersContainsInString(fourMinusOne, five)) temp[6] = five;
                            else temp[0] = five;

                        }

                    }
                }

                foreach (var five in charArr)
                {
                    if (temp[2] != "" && temp[5] != "") break;
                    // 2 or 5
                    if (five.Length == 5 && five != temp[3])
                    {
                        var oneCharArr = temp[1];

                        var nineMinusOne = temp[9].Replace(oneCharArr[0].ToString(), "").Replace(oneCharArr[1].ToString(), "");

                        if (CharactersContainsInString(nineMinusOne, five)) temp[5] = five;
                        else temp[2] = five;

                    }
                }

                // Compute output;
                var test = line.Split("|");
                var output = test[1].Split(" ");

                var codeString = "";

                foreach (var op in output)
                {
                    foreach (KeyValuePair<int, string> keyValuePair in temp)
                    {
                        if (op.Length == keyValuePair.Value.Length && CharactersContainsInString(keyValuePair.Value, op))
                        {
                            codeString = codeString + keyValuePair.Key;
                        }
                    }
                }

                totalValue += int.Parse(codeString);

                temp = new Dictionary<int, string>
                {
                    {1,""}, // a
                    {2,""}, // b
                    {3,""}, // c
                    {4,""}, // d
                    {5,""}, // e
                    {6,""}, // f
                    {7,""}, // g
                };

            }

            Console.WriteLine($"Part 2: {totalValue}");
        }

        private void PartOne()
        {
            int counter = 0;

            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day8\input.txt"))
            {
                var initialSplit = line.Split(" | ");
                var charArr = initialSplit[1].Split(" ");

                foreach (var stuff in charArr)
                {
                    // Determine set up
                    if (stuff.Length == 2) { counter++; } // 1
                    if (stuff.Length == 3) { counter++; } // 7
                    if (stuff.Length == 4) { counter++; } // 4
                    if (stuff.Length == 7) { counter++; } // 8
                }
            }

            Console.WriteLine($"Part 1: {counter}");
        }

        // Checks if the characters in second exists in the first
        // dab <=> fbcad
        private bool CharactersContainsInString(string first, string second)
        {
            var counter = 0;
            foreach (var character in second)
            {
                if (first.Contains(character)) counter++;
            }

            if (counter == first.Length) return true;
            return false;
        }
    }
}
