using AdventOfCode2021.Helpers;
using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Day13
{
    public class Solution : ISolution
    {
        int[,] map;
        List<Tuple<string, int>> folds = new List<Tuple<string, int>>();
        public void Calculate()
        {
            ReadInput();
            PartOne();
            PartTwo();
        }

        private void PartTwo()
        {
            var tempMap = map;

            foreach (var fold in folds)
            {
                if (fold.Item1 == "x")
                {
                    var newMap = FoldX(fold.Item2, tempMap);
                    tempMap = newMap;
                }
                if (fold.Item1 == "y")
                {
                    var newMap = FoldY(fold.Item2, tempMap);
                    tempMap = newMap;
                }
            }

            Console.WriteLine("Part 2: (KJBKEUBG)");
            for (int i = 0; i < tempMap.GetLength(0); i++)
            {
                for (int j = 0; j < tempMap.GetLength(1); j++)
                {
                    if (tempMap[i, j] == 1) Console.Write("#");
                    else Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        private void PartOne()
        {
            if (folds[0].Item1 == "x")
            {
                var newMap = FoldX(folds[0].Item2, map);
                Console.WriteLine($"Part 1: {CountDots(newMap)}");
            }
            if (folds[0].Item1 == "y")
            {
                var newMap = FoldY(folds[0].Item2, map);
                Console.WriteLine($"Part 1: {CountDots(newMap)}");
            }
        }

        private int CountDots(int[,] matrix)
        {
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1) counter++;
                }
            }
            return counter;
        }

        private int[,] FoldX(int col, int[,] currentMap)
        {
            var newMap = new int[currentMap.GetLength(0), currentMap.GetLength(1)/2];
            var foldPart = new int[currentMap.GetLength(0), currentMap.GetLength(1) / 2];

            for (int i = 0; i < currentMap.GetLength(0); i++)
            {
                for (int j = 0; j < currentMap.GetLength(1); j++)
                {
                    if (j < col)
                    {
                        newMap[i, j] = currentMap[i, j];
                    }
                    if (j > col)
                    {
                        foldPart[i, j - (col + 1)] = currentMap[i, j];
                    }
                }
            }

            var transposedFold = MatrixHelper.Transpose(foldPart);
            var folded = MatrixHelper.RotateMatrixClockwise(transposedFold);

            for (int i = 0; i < newMap.GetLength(0); i++)
            {
                for (int j = 0; j < newMap.GetLength(1); j++)
                {
                    if (newMap[i, j] == 0 && folded[i, j] == 1)
                    {
                        newMap[i, j] = 1;
                    }
                }
            }

            return newMap;
        }

        private int[,] FoldY(int row, int[,] currentMap)
        {
            var newMap = new int[currentMap.GetLength(0) / 2, currentMap.GetLength(1)];
            var foldPart = new int[currentMap.GetLength(0) / 2, currentMap.GetLength(1)];

            for (int i = 0; i < currentMap.GetLength(0); i++)
            {
                for (int j = 0; j < currentMap.GetLength(1); j++)
                {
                    if(i < row)
                    {
                        newMap[i, j] = currentMap[i, j];
                    }
                    if(i > row)
                    {
                        foldPart[i - (row + 1), j] = currentMap[i, j];
                    }
                }
            }

            var transposedFold = MatrixHelper.Transpose(foldPart);
            var folded = MatrixHelper.RotateMatrixCounterClockwise(transposedFold);

            for (int i = 0; i < newMap.GetLength(0); i++)
            {
                for (int j = 0; j < newMap.GetLength(1); j++)
                {
                    if (newMap[i, j] == 0 && folded[i, j] == 1)
                    {
                        newMap[i, j] = 1;
                    }
                }
            }

            return newMap;
        }
        private void ReadInput()
        {
            var input = System.IO.File.ReadAllLines(@"C:\Work\AdventOfCode2021\Day13\input.txt").ToList();
            var highestX = 0;
            var highestY = 0;

            input.ForEach(line =>
            {
                if (line.Contains(','))
                {
                    var charArr = line.Split(',');
                    var y = int.Parse(charArr[0]);
                    var x = int.Parse(charArr[1]);

                    if (highestX < x) highestX = x;
                    if (highestY < y) highestY = y;
                }
            });

            map = new int[highestX+1, highestY+1];

            foreach(var line in input)
            {
                if(line.Contains(','))
                {
                    var charArr = line.Split(',');
                    var y = int.Parse(charArr[0]);
                    var x = int.Parse(charArr[1]);

                    if (highestX < x) highestX = x;
                    if (highestY < y) highestY = y;

                    map[x, y] = 1;
                } else
                {
                    // parse folds
                    if(line.Contains('='))
                    {
                        var f = line.Split(" ")[2].Split("=");
                        folds.Add(new Tuple<string, int>(f[0], int.Parse(f[1])));
                    }
                }
            }
        }
    }
}
