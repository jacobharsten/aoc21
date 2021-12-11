using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day11
{
    class Octopus
    {
        public int EnergyLevel { get; set; }
        public bool IsFlashed { get; set; }
        public Octopus(int n)
        {
            EnergyLevel = n;
            IsFlashed = false;
        }
    }
    public class Solution : ISolution
    {
        public void Calculate()
        {
            PartOne(ReadInput());
            PartTwo(ReadInput());
        }

        private void PartTwo(Octopus[,] input)
        {
            var steps = 0;
            while (true)
            {
                steps++;
                List<Tuple<int, int>> wasFlashed = new List<Tuple<int, int>>();

                for (int i = 0; i < input.GetLength(0); i++)
                {
                    for (int j = 0; j < input.GetLength(1); j++)
                    {
                        wasFlashed.AddRange(CountFlashes(input, i, j));
                    }
                }

                if (wasFlashed.Count == 100)
                {
                    //Console.WriteLine(steps);
                    break;
                }

                foreach (Tuple<int, int> f in wasFlashed)
                {
                    input[f.Item1, f.Item2].IsFlashed = false;
                }
            }
            Console.WriteLine($"Part 2: {steps}");
        }

        private void PartOne(Octopus[,] input)
        {
            var steps = 100;
            var totalFlashes = 0;

            for (int k = 0; k < steps; k++)
            {
                List<Tuple<int, int>> wasFlashed = new List<Tuple<int, int>>();

                for (int i = 0; i < input.GetLength(0); i++)
                {
                    for (int j = 0; j < input.GetLength(1); j++)
                    {
                        wasFlashed.AddRange(CountFlashes(input, i, j));
                    }
                }

                totalFlashes += wasFlashed.Count;

                foreach (Tuple<int, int> f in wasFlashed)
                {
                    input[f.Item1, f.Item2].IsFlashed = false;
                }
            }
            Console.WriteLine($"Part 1: {totalFlashes}");
        }

        private List<Tuple<int,int>> CountFlashes(Octopus[,] arr, int row, int col)
        {
            if (row < 0 || col < 0 || row >= arr.GetLength(0) || col >= arr.GetLength(1) || arr[row,col].IsFlashed)
            {
                return new List<Tuple<int, int>>();
            }

            // increase
            arr[row, col].EnergyLevel++;
            if (arr[row, col].EnergyLevel < 10) return new List<Tuple<int, int>>();

            arr[row, col].IsFlashed = true;
            arr[row, col].EnergyLevel = 0;

            List<Tuple<int, int>> total = new List<Tuple<int, int>>() { new Tuple<int, int>(row, col) };
            total.AddRange(CountFlashes(arr, row, col + 1)); // right
            total.AddRange(CountFlashes(arr, row, col - 1)); // left
            total.AddRange(CountFlashes(arr, row - 1, col)); // top
            total.AddRange(CountFlashes(arr, row + 1, col)); // bottom
            total.AddRange(CountFlashes(arr, row - 1, col + 1)); // right top
            total.AddRange(CountFlashes(arr, row - 1, col - 1)); // left top
            total.AddRange(CountFlashes(arr, row + 1, col + 1)); // right bottom
            total.AddRange(CountFlashes(arr, row + 1, col - 1)); // left bottom

            return total;
        }


        private Octopus[,] ReadInput()
        {
            int rows = 0;
            int columns = 0;
            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day11\input.txt"))
            {

                if (rows == 0)
                {
                    int counter = 0;
                    foreach (var cha in line)
                    {
                        counter++;
                    }
                    rows = counter;
                }

                columns++;
            }

            Octopus[,] arr = new Octopus[rows, columns];
            int currentRow = 0;
            int currentColumn = 0;
            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day11\input.txt"))
            {
                foreach (var value in line)
                {
                    arr[currentRow, currentColumn] = new Octopus(int.Parse(value.ToString()));
                    currentColumn++;
                }
                currentRow++;
                currentColumn = 0;

            }
            return arr;
        }
    }
}
