using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode_2021.Solutions
{
    public class day_1
    {
        public void Solution1()
        {
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("../../../input/input-day1.txt");
            var numbers = lines.Select(Int32.Parse).ToList();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i + 1] > numbers[i])
                {
                    count++;
                }
            }

            Console.WriteLine("Day 1\nchallenge 1: {0}", count);
            return;
        }

        public void Solution2()
        {
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("../../../input/input-day1.txt");
            var numbers = lines.Select(Int32.Parse).ToList();

            for (int i = 1; i < numbers.Count - 2; i++)
            {
                if (numbers[i] + numbers[i + 1] + numbers[i + 2] > numbers[i - 1] +  numbers[i] + numbers[i + 1])
                {
                    count++;
                }
            }

            Console.WriteLine("challenge 2: {0]", count);
            return;
        }
    }
}
