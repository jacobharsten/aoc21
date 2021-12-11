using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Day2
{
    public class Solution : ISolution
    {
        public void Calculate()
        {
            var input = System.IO.File.ReadAllLines(@"C:\Work\AdventOfCode2021\Day2\input.txt");
            PartOne(input.ToList());
            PartTwo(input.ToList());
        }

        private void PartTwo(List<string> input)
        {
            int depth = 0;
            int horisontal = 0;
            int aim = 0;

            foreach (string line in input)
            {
                string[] values = line.Split(null);

                if (values[0] == "forward")
                {
                    horisontal += int.Parse(values[1]);
                    depth += aim * int.Parse(values[1]);
                }
                else
                {

                    if (values[0] == "down")
                    {
                        //depth = depth + int.Parse(values[1]);
                        aim += int.Parse(values[1]);
                    }
                    if (values[0] == "up")
                    {
                        //depth = depth - int.Parse(values[1]);
                        aim -= int.Parse(values[1]);
                    }
                }
            }

            //Console.WriteLine(horisontal);
            //Console.WriteLine(depth);
            Console.WriteLine($"Part 2: {depth * horisontal}");
        }
        private void PartOne(List<string> input)
        {
            int depth = 0;
            int horisontal = 0;

            /* Refactor this */
            foreach (string line in input)
            {
                string[] values = line.Split(null);

                if (values[0] == "forward")
                {
                    horisontal += int.Parse(values[1]);
                }
                else
                {

                    if (values[0] == "down")
                    {
                        depth += int.Parse(values[1]);
                    }
                    if (values[0] == "up")
                    {
                        depth -= int.Parse(values[1]);
                    }
                }
            }

            Console.WriteLine($"Part 1: {depth * horisontal}");
        }
    }
}
