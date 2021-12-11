using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Day1
{
    public class SolutionOne
    {
        public void CountIncreases()
        {
            int counter = 0;
            List<int> temp = new List<int>();

            /* Refactor this */
            foreach (string line in System.IO.File.ReadLines(@"C:\Work\AdventOfCode2021\Day1\TextFile1.txt"))
            {
                temp.Add(int.Parse(line));
            }


            for(int i=0; i<temp.Count; i++)
            {
                if(i !=0 )
                {
                    if (temp[i] > temp[i - 1]) counter++;
                }
            }
            
            Console.WriteLine(counter);
        }
    }
}
