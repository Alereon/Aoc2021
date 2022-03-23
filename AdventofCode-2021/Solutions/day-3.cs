using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode_2021.Solutions
{
    internal class day_3
    {
        public void Solution1()
        {
            string[] lines = System.IO.File.ReadAllLines("../../../Input/input-day3.txt");
            int one = 0, zero = 0;
            string gamma = "", epsilon = "";

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j][i] == '0')
                    {
                        zero++;
                    }
                    else if (lines[j][i] == '1')
                    {
                        one++;
                    }

                }

                if (one>zero)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }

                zero = 0;
                one = 0;
            }

            Console.WriteLine("Day 3\nchallenge 1: {0}", Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));
            return;
        }
        public void Solution2()
        {
            string[] lines = System.IO.File.ReadAllLines("../../../Input/input-day3.txt");
            int one = 0, zero = 0;
            List<string> oxygen = new List<string>(lines);
            List<string> scrubber = new List<string>(lines);

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < scrubber.Count; j++)
                {
                    if (scrubber[j][i] == '0')
                    {
                        zero++;
                    }
                    else
                    {
                        one++;
                    }
                }
                if (one >= zero && scrubber.Count > 1)
                {
                    scrubber.RemoveAll(x => x[i] =='1');
                }

                else if (scrubber.Count>1)
                {
                    scrubber.RemoveAll(x => x[i] =='0');
                }

                zero = 0;
                one = 0;
            }

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < oxygen.Count; j++)
                {

                    if (oxygen[j][i]=='0')
                    {

                        zero++;
                    }

                    else
                    {
                        one++;
                    }
                }
                if (one>=zero && oxygen.Count>1)
                {
                    oxygen.RemoveAll(x => x[i] =='0');
                }
                else if (oxygen.Count>1)
                {
                    oxygen.RemoveAll(x => x[i] =='1');
                }

                zero = 0;
                one = 0;
            }

            Console.WriteLine("challenge 2: {0]", Convert.ToInt32(oxygen[0], 2) * Convert.ToInt32(scrubber[0], 2));
            return;
        }
    }
}
