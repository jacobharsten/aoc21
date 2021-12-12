using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day12
{
    public class Solution : ISolution
    {
        private Dictionary<string, List<string>> _caveMap = new Dictionary<string, List<string>>();
        public void Calculate()
        {
            ReadInput();
            PartOne();
            PartTwo();
        }

        private void PartTwo()
        {
            List<List<string>> possiblePaths = new List<List<string>>();
            FindPaths2(possiblePaths, new List<string> { "start" }, false);
            Console.WriteLine($"Part 2: {possiblePaths.Count()}");
        }

        private void PartOne()
        {
            List<List<string>> possiblePaths = new List<List<string>>();
            FindPaths(possiblePaths, new List<string> { "start" });
            Console.WriteLine($"Part 1: {possiblePaths.Count()}");
        }

        private void FindPaths2(List<List<string>> total, List<string> route, bool secondSmallCave)
        {
            if (route.Last() == "end")
            {
                total.Add(route);
                return;
            }

            foreach (var dirr in _caveMap[route.Last()])
            {
                if (route.Contains(dirr) && dirr != dirr.ToLower())
                {
                    var tempRoute = new List<string>(route) { dirr };
                    FindPaths2(total, tempRoute, secondSmallCave);
                }

                if (!route.Contains(dirr) && dirr != "start")
                {
                    var tempRoute = new List<string>(route) { dirr };
                    FindPaths2(total, tempRoute, secondSmallCave);
                }
                if (route.Contains(dirr) && dirr == dirr.ToLower() && !secondSmallCave && dirr != "start")
                {
                    var tempRoute = new List<string>(route) { dirr };
                    FindPaths2(total, tempRoute, true);
                }


            }
        }

        private void FindPaths(List<List<string>> total, List<string> route)
        {
            if(route.Last() == "end")
            {
                total.Add(route);
            }

            foreach(var dirr in _caveMap[route.Last()])
            {
                if(route.Contains(dirr) && dirr != dirr.ToLower())
                {
                    var tempRoute = new List<string>(route) { dirr };
                    FindPaths(total, tempRoute);
                }
                
                if(!route.Contains(dirr) && dirr != "start")
                {
                    var tempRoute = new List<string>(route) { dirr };
                    FindPaths(total, tempRoute);
                }

            }
        }

        private void ReadInput()
        {
            var input = System.IO.File.ReadAllLines(@"C:\Work\AdventOfCode2021\Day12\input.txt").ToList();

            foreach (var line in input)
            {
                var nodes = line.Split("-");

                if (_caveMap.ContainsKey(nodes[0]))
                {
                    _caveMap[nodes[0]].Add(nodes[1]);
                }
                else
                {
                    _caveMap.Add(nodes[0], new List<string> { nodes[1] });
                }

                if (_caveMap.ContainsKey(nodes[1]))
                {
                    _caveMap[nodes[1]].Add(nodes[0]);
                }
                else
                {
                    _caveMap.Add(nodes[1], new List<string> { nodes[0] });
                }

            }
            
        }
        
    }
}
