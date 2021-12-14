using AdventOfCode2021.Interfaces;
using System;

namespace AdventOfCode2021
{
    class Program
    {
        const bool debugMode = false;
        static void Main(string[] args)
        {
            if(debugMode)
            {
                ISolution currentDay = new Day14.Solution();
                currentDay.Calculate();
            }
            else
            {
                try
                {
                    AocMenu();
                } 
                catch(Exception e)
                {
                    Console.WriteLine($"Something went wrong: {e.Message}");
                }
            }
        }

        private static void ComputeTime(ISolution func)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            func.Calculate();
            watch.Stop();

            Console.WriteLine($"=> Total execution time: {watch.ElapsedMilliseconds} ms");
        }

        private static void StartText()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("== Welcome to Advent of Code 2021 ==");
            Console.WriteLine("====================================\n\n");
            Console.Write("Select day to run (1-25):");
        }

        private static void AocMenu()
        {
            StartText();
            string userInput = Console.ReadLine();
            Console.WriteLine("====================================");
            switch (int.Parse(userInput))
            {
                case 1:
                    ComputeTime(new Day1.Solution());
                    break;
                case 2:
                    ComputeTime(new Day2.Solution());
                    break;
                case 3:
                    ComputeTime(new Day3.Solution());
                    break;
                case 4:
                    ComputeTime(new Day4.Solution());
                    break;
                case 5:
                    ComputeTime(new Day5.Solution());
                    break;
                case 6:
                    ComputeTime(new Day6.Solution());
                    break;
                case 7:
                    ComputeTime(new Day7.Solution());
                    break;
                case 8:
                    ComputeTime(new Day8.Solution());
                    break;
                case 9:
                    ComputeTime(new Day9.Solution());
                    break;
                case 10:
                    ComputeTime(new Day10.Solution());
                    break;
                case 11:
                    ComputeTime(new Day11.Solution());
                    break;
                case 12:
                    ComputeTime(new Day12.Solution());
                    break;
                case 13:
                    ComputeTime(new Day13.Solution());
                    break;
                case 14:
                    ComputeTime(new Day14.Solution());
                    break;
                default:
                    Console.WriteLine("Selected day not found.");
                    break;
            }
        }
    }
}
