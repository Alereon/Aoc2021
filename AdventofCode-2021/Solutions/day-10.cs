using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode_2021.Solutions
{
    internal class day_10
    {
        List<string> lines = System.IO.File.ReadAllLines("../../../Input/input-day10.txt").ToList();
        List<string> corruptedLines = new List<string>();
        public void Solution1()
        {
            int score = 0;
            Dictionary<char, char> charPairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
                { '<', '>' },
            };
            Dictionary<char, int> charPoints = new Dictionary<char, int>
            {
                { ')', 3 },
                { ']', 57 },
                { '}', 1197 },
                { '>', 25137 },
            };

            foreach (var line in lines)
            {
                Stack<char> lineStack = new Stack<char>();

                foreach (var ch in line)
                {
                    if (ch == '<' || ch == '[' || ch == '{' || ch == '(')
                    {
                        lineStack.Push(ch);
                    }
                    else if (charPairs.FirstOrDefault(x => x.Value == ch).Key != lineStack.Pop())
                    {
                        score += charPoints[ch];
                        corruptedLines.Add(line);
                        break;
                    }

                }
            }

            Console.WriteLine(score);
        }
        public void Solution2()
        {
            string newLine = null;

            Dictionary<char, int> charPoints = new Dictionary<char, int>
            {
                { ')', 1 },
                { ']', 2 },
                { '}', 3 },
                { '>', 4 },
            };

            foreach (var line in corruptedLines)
            {
                lines.Remove(line);
            }

            for (int i = 0; i < lines.Count; i++)
            {
                while (true)
                {
                    lines[i] = lines[i].Replace("()", "").Replace("[]", "").Replace("{}", "").Replace("<>", "");

                    if (newLine != lines[i])
                    {
                        newLine = lines[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            List<long> Score = new List<long>(lines.Count);

            for (int i = 0; i < lines.Count; i++)
            {
                long count = 0;

                for (int j = lines[i].Length - 1; j >= 0; j--)
                {
                    char ch = lines[i][j];
                    count *= 5;
                    switch (ch)
                    {
                        case '(':
                            count += 1;
                            break;
                        case '[':
                            count += 2;
                            break;
                        case '{':
                            count += 3;
                            break;
                        case '<':
                            count += 4;
                            break;
                    }
                }
                Score.Add(count);
            }

            var sortedScores = Score.OrderBy(x => x).ToList();
            var middleScore = sortedScores[((Score.Count + 1) / 2) - 1];

            Console.WriteLine(middleScore);
        }
    }
}
