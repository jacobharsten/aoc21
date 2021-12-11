using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day5
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
            Dictionary<string, int> temp = new Dictionary<string, int>();

            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day5\input.txt"))
            {
                var coordinates = line.Replace("->", ",").Split(",");

                var x1 = int.Parse(coordinates[0]);
                var y1 = int.Parse(coordinates[1]);
                var x2 = int.Parse(coordinates[2]);
                var y2 = int.Parse(coordinates[3]);


                var dx = x2 - x1;
                var dy = y2 - y1;

                if (dx != 0) dx = dx / Math.Abs(dx);
                if (dy != 0) dy = dy / Math.Abs(dy);

                var x = x1;
                var y = y1;

                while (x != x2 + dx || y != y2 + dy)
                {
                    var key = "(" + x + "," + y + ")";
                    var doesCoordinateExist = temp.TryGetValue(key, out int foundValue);

                    if (doesCoordinateExist)
                    {
                        temp[key] = foundValue + 1;
                    }
                    else
                    {
                        temp[key] = 1;
                    }

                    y += dy;
                    x += dx;
                }

            }
            var counter = 0;
            foreach (KeyValuePair<string, int> kvp in temp)
            {
                if (kvp.Value >= 2)
                {
                    //Console.WriteLine($"Found a point with more then 2 intersects: {kvp.Key}");
                    counter++;
                }
            }
            Console.WriteLine($"Part 2: {counter}");
        }
        
        private void PartOne()
        {
            Console.WriteLine("Part 1: Gone during part 2 solving.");
        }
    }
}
