using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AdventOfCode2021.Interfaces;

namespace AdventOfCode2021.Day9
{
    public class Solution : ISolution
    {

        public void Calculate()
        {
            int[,] array = ReadInput();

            PartOne(array);
            PartTwo(array);
        }        

        private void PartTwo(int[,] array)
        {
            int counter = 0;
            List<int> basins = new List<int>();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    // [i,j]
                    if (array[i, j] == 9) continue;

                    counter = CountBasins(array, i, j);

                    basins.Add(counter);

                    //Console.WriteLine($"Basin found with count: {counter}, starting on: ({i},{j})");
                    counter = 0;
                }
            }

            basins = basins.OrderByDescending(i => i).ToList();

            Console.WriteLine($"Part 2: {basins[0] * basins[1] * basins[2]}");
        }

        private void PartOne(int[,] array)
        {
            List<int> lowerPoints = new List<int>();
            var counter = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    // [i,j]
                    counter++;
                    var adjacentValues = GetAdjacentElements(array, i, j);
                    if (IsLowerPoint(array[i, j], adjacentValues))
                    {
                        lowerPoints.Add(array[i, j]);
                    }
                }
            }

            int totalValue = 0;

            foreach (var value in lowerPoints)
            {
                totalValue += (value + 1);
            }

            Console.WriteLine($"Part 1: {totalValue}");
        }

        // inital point => list of adjacents
        private int CountBasins(int[,] arr, int x, int y)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);

            if (x < 0 || y < 0 || x >= rows || y >= columns)
            {
                return 0;
            }

            if (arr[x, y] == 9) return 0;

            arr[x, y] = 9;

            return 1 + CountBasins(arr, x - 1, y) + CountBasins(arr, x + 1, y) + CountBasins(arr, x, y + 1) + CountBasins(arr, x, y - 1);

        }

        private int[,] ReadInput()
        {
            int rows = 0;
            int columns = 0;
            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day9\input.txt"))
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

            int[,] arr = new int[rows, columns];
            int currentRow = 0;
            int currentColumn = 0;
            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day9\input.txt"))
            {
                foreach (var value in line)
                {
                    arr[currentRow, currentColumn] = int.Parse(value.ToString());
                    currentColumn++;
                }
                currentRow++;
                currentColumn = 0;

            }

            return arr;
        }


        private bool IsLowerPoint(int initial, List<int>adjacents)
        {
            foreach(var value in adjacents)
            {
                if(value <= initial)
                {
                    return false;
                }
            }
            return true;
        }

        private List<int> GetAdjacentElements (int [,] arr, int row, int column)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);
            List<int> adjacentValues = new List<int>();

            int hy = row + 1;
            int dy = row - 1;
            int hx = column + 1;
            int dx = column - 1;

            // Up value
            if(row - 1 >= 0)
            {
                adjacentValues.Add((int)arr.GetValue(row - 1, column));
            }
            // down value
            if(row + 1 < rows)
            {
                adjacentValues.Add((int)arr.GetValue(row + 1, column));
            }
            // right
            if(column + 1 < columns)
            {
                adjacentValues.Add((int)arr.GetValue(row, column + 1));
            }
            // left
            if(column - 1 >= 0)
            {
                adjacentValues.Add((int)arr.GetValue(row, column - 1));
            }

            return adjacentValues;

        }
    }
}
