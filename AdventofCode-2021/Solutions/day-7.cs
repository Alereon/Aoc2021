using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode_2021.Solutions
{
    public class day_7
    {
        public void Solution1()
        {
            string line = System.IO.File.ReadAllText("../../../Input/input-day7.txt");
            List<int> crabs = Array.ConvertAll(line.Split(','), int.Parse).ToList();
            int fuelNeeded = 0;
            int finalFuel = 1000000000;

            for (int i = 0; i < crabs.Max(); i++)
            {
                fuelNeeded = 0;

                for (int j = 0; j < crabs.Count; j++)
                {
                    fuelNeeded += Math.Abs(i - crabs[j]);
                }

                if (fuelNeeded < finalFuel)
                {
                    finalFuel = fuelNeeded;
                }
            }
            Console.WriteLine("Day 7\n challenge 1: {0]", finalFuel);
        }
        public void Solution2()
        {
            string line = System.IO.File.ReadAllText("../../../Input/input-day7.txt");
            List<int> crabs = Array.ConvertAll(line.Split(','), int.Parse).ToList();
            int fuelNeeded = 0;
            int finalFuel = 1000000000;

            for (int i = 0; i < crabs.Max(); i++)
            {
                fuelNeeded = 0;

                for (int j = 0; j < crabs.Count; j++)
                {
                  for (int k = 1; k <= Math.Abs(i - crabs[j]); k++)
                    {
                        fuelNeeded += k;
                    }
                }

                if (fuelNeeded < finalFuel)
                {
                    finalFuel = fuelNeeded;
                }
            }
            Console.WriteLine("challenge 2: {0]", finalFuel);
        }
    }
}
