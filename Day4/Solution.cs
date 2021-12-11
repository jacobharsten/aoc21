using AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day4
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
            var s = IterateBoards();
            Console.WriteLine($"Part 1: {s.Item1 * s.Item2}");
        }

        private void PartOne()
        {
            var s = IterateBoards(true);
            Console.WriteLine($"Part 1: {s.Item1 * s.Item2}");
        }

        private Tuple<int,int> IterateBoards(bool isPartOne = false)
        {
            var inputQueue = ReadBingoInput();
            List<int> drawnNumbers = new List<int>();
            List<int[,]> bingoBoards = ReadBoardFromTxt();

            List<int[,]> remainingBoards = new List<int[,]>();
            Tuple<int, int> lastBoard = new Tuple<int, int> (1,1);

            while(inputQueue.Count > 0)
            {
                var nextNumber = inputQueue.Dequeue();
                drawnNumbers.Add(nextNumber);

                //Console.WriteLine($"Bingoboard length: {bingoBoards.Count}");
                //Console.WriteLine(nextNumber);

                foreach (var board in bingoBoards)
                {
                    if (IsItBingo(board, drawnNumbers))
                    {
                        if(isPartOne)
                        {
                            return new Tuple<int, int> ( FindAllUnmarked(board, drawnNumbers), nextNumber);
                        }
                        //Console.WriteLine("BINGO BOARD FOUND!");
                        //Console.WriteLine($"LAST DRAWN NUMBER: {nextNumber}");

                        // find all unmarked numbers
                        //FindAllUnmarked(board, drawnNumbers);
                        //return; Uncomnment this for solution 1
                        lastBoard = new Tuple<int, int>(FindAllUnmarked(board, drawnNumbers), nextNumber);
                    } else
                    {
                        remainingBoards.Add(board);
                    }
                }

                bingoBoards = remainingBoards;
                remainingBoards = new List<int[,]>();
            }
            return lastBoard;
        }

        private int FindAllUnmarked(int[,] board, List<int> drawnNumbers)
        {
            var sum = 0;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    if (!drawnNumbers.Contains(board[j, i]))
                    {
                        sum += board[j, i];
                    }
                }
            }

            return sum;
        }

        private Queue<int> ReadBingoInput()
        {
            Queue<int> test = new Queue<int>();

            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day4\bingoInput.txt"))
            {
                var rowNumbers = line.Split(",");
                foreach(var val in rowNumbers)
                {
                    test.Enqueue(int.Parse(val));
                }
            }
            return test;
        }

        private List<int[,]> ReadBoardFromTxt()
        {
            List<int[,]> allBoards = new List<int[,]>();
            int[,] array = new int[5, 5];
            int counter = 0;

            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day4\boards.txt"))
            {
                if(line.Length < 2)
                {
                    allBoards.Add(array);
                    array = new int[5, 5];
                    counter = 0;
                    continue;
                }

                var trimDoubleSpace = line.Replace("  ", " ").Trim();
                var rowNumbers = trimDoubleSpace.Split(" ");

                for (int i = 0; i < array.GetLength(1); i++)
                {
                    array[counter, i] = int.Parse(rowNumbers[i]);
                }

                counter++;
            }
            return allBoards;
        }


        private bool IsItBingo(int[,] board, List<int> drawnNumbers)
        {
            // Bingo on Column?
            for (int j = 0; j < 5; j++)
            {
                int counter = 0;
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if(drawnNumbers.Contains(board[i, j]))
                    {
                        counter++;
                    }
                }

                if (counter == 5) {
                    //Console.WriteLine("Bingo on column for board: ");
                    //Print2DArray(board);
                    return true;
                }
                
            }

            //Bingo on Row?
            for (int j=0; j<5; j++)
            {
                int counter = 0;
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    if (drawnNumbers.Contains(board[j, i]))
                    {
                        counter++;
                    }
                }
                if (counter == 5)
                {
                    //Console.WriteLine("Bingo on row for board: ");
                    //Print2DArray(board);
                    return true;
                }
            }
            
            return false;
        }

        private void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
