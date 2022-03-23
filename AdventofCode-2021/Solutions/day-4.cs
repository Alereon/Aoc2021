using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode_2021.Solutions
{
    public class day_4
    {
        public void Solution1()
        {
            string[] lines = System.IO.File.ReadAllLines("../../../Input/input-day4.txt");
            var boardLines = lines.Skip(1).ToList();
            List<int> numbers = lines[0].Split(',').Select(x => int.Parse(x)).ToList();
            var boards = BingoBoard.ParseBingoBoards(lines[2..]);

            foreach(var number in numbers)
            {
                foreach (BingoBoard board in boards)
                {
                    if (board.MarkNo(number))
                    {
                        Console.WriteLine("Day 4\n challenge 1: {0]", board.WinningValue);
                        return;
                    }
                }
            }
        }
        public void Solution2()
        {
            string[] lines = System.IO.File.ReadAllLines("../../../Input/input-day4.txt");
            List<int> numbers = lines[0].Split(',').Select(x => int.Parse(x)).ToList();
            var boards = BingoBoard.ParseBingoBoards(lines[2..]);

            int lastWinningBoardResult = 0;
            foreach (int number in numbers)
            {
                foreach (BingoBoard board in boards)
                {
                    if (board.MarkNo(number))
                    {
                        lastWinningBoardResult = board.WinningValue;
                    }
                }
                boards.RemoveAll(b => b.IsWin);
            }
            Console.WriteLine("challenge 2: {0]", lastWinningBoardResult);
            return;
        }

        public void Solution3()
        {
            string[] lines = System.IO.File.ReadAllLines("../../../Input/input-day4.txt");
            int[] numbers = lines[0].Split(',').Select(x => int.Parse(x)).ToArray();
        }
    }

    class BingoBoard
    {
        readonly List<List<int>> lines = new();
        readonly List<int> unmarkedNos = new();

        public bool IsWin = false;
        public int WinningValue;

        public BingoBoard(List<int> numbers)
        {
            unmarkedNos = numbers;

            for (int i = 0; i < 5; i++)
            {
                // Rows
                lines.Add(numbers.Skip(i * 5).Take(5).ToList());
                // Columns
                lines.Add(
                    Enumerable.Range(0, 5)
                    .Select(col => numbers.ElementAt((col * 5) + i))
                    .ToList()
                );
            }
        }

        public bool MarkNo(int number)
        {
            unmarkedNos.Remove(number);
            foreach (List<int> line in lines)
            {
                if (line.Remove(number) && line.Count == 0)
                {
                    IsWin = true;
                    WinningValue = number * unmarkedNos.Sum();
                }
            }
            return IsWin;
        }

        public static List<BingoBoard> ParseBingoBoards(string[] input)
        {
            List<BingoBoard> bingoBoards = new();
            for (int i = 0; i < ((input.Length + 1) / 6); i++)
            {
                List<int> numbers = Enumerable
                    .Range(0, 5)
                    .SelectMany(rowNo =>
                        input[(i * 6) + rowNo]
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => int.Parse(x)))
                    .ToList();
                bingoBoards.Add(new BingoBoard(numbers));
            }
            return bingoBoards;
        }
    };
}
