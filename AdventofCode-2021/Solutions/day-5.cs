using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventofCode_2021.Solutions
{
    public class day_5
    {
        public void Solution1()
        {
            int[,] grid = new int[1000, 1000];
            int x1, x2, y1, y2;
            int xDiff, yDiff;
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("../../../Input/input-day5.txt");
            var trimmed = lines.Select(x => x.Split(" -> ")).ToArray();

            Array.Clear(grid, 0, grid.Length);

            foreach (var line in trimmed)
            {
                var coords = line.Select(x => x.Split(',')).ToList();
                x1 = int.Parse(coords[0][0]);
                x2 = int.Parse(coords[1][0]);
                y1 = int.Parse(coords[0][1]);
                y2 =int.Parse(coords[1][1]);

                xDiff = x2 - x1;
                yDiff = y2 - y1;

                if (x1 == x2)
                {
                    //horizontal
                    int minY = Math.Min(y1, y2);
                    int maxY = Math.Max(y1, y2);

                    for (int y = minY; y<=maxY; y++)
                    {
                        grid[x1, y]++;
                    }
                }
                else if (y1==y2)
                {
                    //vertical
                    int minX = Math.Min(x1, x2);
                    int maxX = Math.Max(x1, x2);

                    for (int x = minX; x<=maxX; x++)
                    {
                        grid[x, y1]++;
                    }
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (grid[i, j] >= 2)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("Day 5\nchallenge 1: {0]", count);
        }

        public void Solution2()
        {
            int[,] grid = new int[1000, 1000];
            int x1, x2, y1, y2;
            int minY, maxY, minX, maxX;
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("../../../Input/DataDay5.txt");
            var trimmed = lines.Select(x => x.Split(" -> ")).ToArray();

            Array.Clear(grid, 0, grid.Length);

            foreach (var line in trimmed)
            {
                var coords = line.Select(x => x.Split(',')).ToList();
                x1 = int.Parse(coords[0][0]);
                x2 = int.Parse(coords[1][0]);
                y1 = int.Parse(coords[0][1]);
                y2 =int.Parse(coords[1][1]);

                if (x1 == x2)
                {
                    //horizontal
                    minY = Math.Min(y1, y2);
                    maxY = Math.Max(y1, y2);

                    for (int y = minY; y<=maxY; y++)
                    {
                        grid[x1, y]++;
                    }
                }
                else if (y1==y2)
                {
                    //vertical
                    minX = Math.Min(x1, x2);
                    maxX = Math.Max(x1, x2);

                    for (int x = minX; x<=maxX; x++)
                    {
                        grid[x, y1]++;
                    }
                }
                else if (x1 != x2 && y1 != y2)
                {
                    //diagonal
                    if (x2 > x1 && y1 > y2)
                    {
                        // x up, y down
                        int y = y1;
                        for (int x = x1; x<=x2; x++)
                        {
                            grid[x, y]++;
                            y--;
                        }
                    }
                    else if (x1 > x2 && y2 > y1)
                    {
                        // x down, y up
                        int y = y1;
                        for (int x = x1; x>=x2; x--)
                        {
                            grid[x, y]++;
                            y++;
                        }
                    }
                    else if (x2 > x1 && y2 > y1)
                    {
                        // x up, y up
                        int y = y1;
                        for (int x = x1; x<=x2; x++)
                        {
                            grid[x, y]++;
                            y++;
                        }
                    }
                    else if (x1 > x2 && y1 > y2)
                    {
                        // x down, y down
                        int y = y1;
                        for (int x = x1; x>=x2; x--)
                        {
                            grid[x, y]++;
                            y--;
                        }
                    }
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (grid[i, j] >= 2)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("challenge 2: {0}", count);
        }
    }
}
