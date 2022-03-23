using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode_2021.Solutions
{
    public class day_2
    {
        public void Solution1()
        {
            string[] lines = System.IO.File.ReadAllLines("input-day2.txt");
            int horizontal = 0, depth = 0;
            var moves = from line in lines
                        let words = line.Split(' ')
                        select new
                        {
                            cmd = words[0],
                            amount = words[1]
                        };

            foreach (var move in moves)
            {
                if (String.Equals(move.cmd, "forward"))
                {
                    horizontal += Int32.Parse(move.amount);
                }
                else if (String.Equals(move.cmd, "down"))
                {
                    depth += Int32.Parse(move.amount);
                }
                else if (String.Equals(move.cmd, "up"))
                {
                    depth -= Int32.Parse(move.amount);
                }
            }

            Console.WriteLine("Day1\nchallenge 1: {0}", horizontal * depth);
            return;
        }
        public void Solution2()
        {
            string[] lines = System.IO.File.ReadAllLines("input-day2.txt");
            int horizontal = 0, depth = 0, aim = 0;
            var moves = from line in lines
                        let words = line.Split(' ')
                        select new
                        {
                            cmd = words[0],
                            amount = words[1]
                        };

            foreach (var move in moves)
            {
                if (String.Equals(move.cmd, "forward"))
                {
                    horizontal += Int32.Parse(move.amount);

                    if (aim > 0)
                    {
                        depth += aim * Int32.Parse(move.amount);
                    }
                }
                else if (String.Equals(move.cmd, "down"))
                {
                    aim += Int32.Parse(move.amount);
                }
                else if (String.Equals(move.cmd, "up"))
                {
                    aim -= Int32.Parse(move.amount);
                }
            }

            Console.WriteLine("challenge 2: {0]", horizontal * depth);
            return;
        }
    }
}
