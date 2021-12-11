using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day10
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
            List<string> incompleteLines = new List<string>();
            // remove corrupted
            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day10\input.txt"))
            {
                char corruptChar = FindCorruptLines(line);
                if (corruptChar == 'x')
                {
                    incompleteLines.Add(line);
                }
            }

            Dictionary<char, ulong> scoring = new Dictionary<char, ulong>
            {
                {'(', 1 },
                {'[', 2 },
                {'{', 3 },
                {'<', 4 },
            };

            var scoreList = new List<ulong>();

            foreach (var line in incompleteLines)
            {
                var remainders = GetRemainingOpenedTags(line);

                ulong sum = 0;

                while (remainders.Count > 0)
                {
                    sum *= 5;
                    var c = remainders.Pop();
                    sum += scoring[c];
                }

                scoreList.Add(sum);
            }

            var sorted = scoreList.OrderByDescending(c => c).ToList();

            Console.WriteLine($"Part 2: {sorted[(sorted.Count / 2)]}");
        }

        private void PartOne()
        {
            List<char> temp2 = new List<char>();

            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day10\input.txt"))
            {

                char corruptChar = FindCorruptLines(line);
                if (corruptChar != 'x') temp2.Add(corruptChar);

            }

            var sum = temp2.Count(c => c == ')') * 3 + temp2.Count(c => c == ']') * 57 + temp2.Count(c => c == '}') * 1197
                + temp2.Count(c => c == '>') * 25137;

            Console.WriteLine($"Part 1: {sum}");
        }

        private Stack<char> GetRemainingOpenedTags(string line)
        {
            var openeingTags = new List<char>
            {
                '(',
                '[',
                '<',
                '{'
            };

            Stack<char> openTags = new Stack<char>();

            foreach (var ch in line)
            {

                if (openeingTags.Contains(ch))
                {
                    openTags.Push(ch);
                }
                else
                {
                    var closingTag = openTags.Pop();
                    if (GetOpeningTag(ch) != closingTag)
                    {
                        return openTags;
                    }
                }
            }
            return openTags;
        }

        


        private char GetOpeningTag(char c)
        {
            if (c == ')') return '(';
            if (c == ']') return '[';
            if (c == '}') return '{';
            if (c == '>') return '<';
            return 'x';
        }


        private char FindCorruptLines(string line)
        {
            var openeingTags = new List<char>
            {
                '(',
                '[',
                '<',
                '{'
            };
           

            Stack<char> openTags = new Stack<char>();

            foreach (var ch in line)
            {

                if (openeingTags.Contains(ch))
                {
                    openTags.Push(ch);
                }
                else
                {
                    var closingTag = openTags.Pop();
                    if (GetOpeningTag(ch) != closingTag)
                    {
                        return ch;
                    }
                }
            }

            return 'x';
        }
        
    }
}
