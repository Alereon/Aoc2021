using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode_2021.Solutions
{
    public class day_6
    {
        public void Solution1()
        {
            string line = System.IO.File.ReadAllText("../../../Input/input-day6.txt");
            List<int> lanternFish = Array.ConvertAll(line.Split(','), int.Parse).ToList();

            for (var day = 0; day < 256; day++)
            {
                int count = lanternFish.Count;
                for (int i = 0; i < count; i++)
                {
                    if (lanternFish[i] == 0)
                    {
                        lanternFish[i] = 6;
                        lanternFish.Add(8);
                    }
                    else
                    {
                        lanternFish[i]--;
                    }
                }
            }
            Console.WriteLine("Day 6\nchallenge 1: {0}", lanternFish.Count);


        }
        public void Solution2()
        {
            string line = System.IO.File.ReadAllText("../../../Input/input-day6.txt");
            List<ulong> lanternFish = Array.ConvertAll(line.Split(','), ulong.Parse).ToList();
            ulong[] collection = new ulong[9];
            ulong totalFish = 0;

            for (int i = 0; i < lanternFish.Count; i++)
            {
                collection[lanternFish[i]] += 1;
            }

            for (int i = 0; i < 256; i++)
            {
                ulong babies = collection[0];
                for (int j = 0; j < collection.Length - 1; j++)
                {
                    collection[j] = collection[j + 1];
                }
                collection[6] += babies;
                collection[8] = babies;
            }

            for (int i = 0; i < collection.Length; i++)
            {
                totalFish += collection[i];
            }

            Console.WriteLine("challenge 2: {0]", totalFish);
        }
    }
}
