using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode_2021.Solutions
{
    public class day_8
    {

        public void Solution1()
        {
            int count = 0;
            string[] lines = System.IO.File.ReadAllLines("../../../Input/input-day8.txt");
            var output = lines.Select(x => x.Split(" | ").Last()).ToArray();
            var segments = output.Select(x => x.Split(' ')).ToArray();

            foreach (var segment in segments)
            {
               foreach(var segmentSplit in segment)
                {
                    if (segmentSplit.Length == 2 || segmentSplit.Length == 3 || segmentSplit.Length == 4 || segmentSplit.Length == 7)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("Day 8\nchallenge 1: {0}", count);
        }

        public void Solution2()
        {
            string[] lines = System.IO.File.ReadAllLines("../../../Input/input-day8.txt");
            long result = 0;

            foreach (var line in lines)
            {
                List<string> inputs = line.Substring(0, line.IndexOf("|") - 1).Split(" ").Select(p => String.Join("", p.OrderBy(c => c))).ToList();
                List<string> outputs = line.Substring(line.IndexOf("|") + 2).Split(" ").Select(p => String.Join("", p.OrderBy(c => c))).ToList();

                List<string> digitPatterns = DetermineDigitPatterns(inputs);

                result += Convert.ToInt32(String.Join("", outputs.Select(o => digitPatterns.IndexOf(o).ToString())));
            }

            Console.WriteLine(result);
        }

        public List<string> DetermineDigitPatterns(List<string> inputs)
        {
            string[] patterns = new string[10];

            patterns[1] = inputs.First(i => i.Length == 2);
            patterns[4] = inputs.First(i => i.Length == 4);

            char tr = patterns[1][0];
            char br = patterns[1][1];
            char tl = patterns[4].First(c => !patterns[1].Contains(c));
            char m = patterns[4].Last(c => !patterns[1].Contains(c));

            patterns[0] = inputs.First(i => i.Length == 6 && (i.Contains(tr) && i.Contains(br)) && !(i.Contains(tl) && i.Contains(m)));
            patterns[2] = inputs.First(i => i.Length == 5 && !(i.Contains(tr) && i.Contains(br)) && !(i.Contains(tl) && i.Contains(m)));
            patterns[3] = inputs.First(i => i.Length == 5 && (i.Contains(tr) && i.Contains(br)) && !(i.Contains(tl) && i.Contains(m)));
            patterns[5] = inputs.First(i => i.Length == 5 && !(i.Contains(tr) && i.Contains(br)) && (i.Contains(tl) && i.Contains(m)));
            patterns[6] = inputs.First(i => i.Length == 6 && !(i.Contains(tr) && i.Contains(br)) && (i.Contains(tl) && i.Contains(m)));
            patterns[7] = inputs.First(i => i.Length == 3);
            patterns[8] = inputs.First(i => i.Length == 7);
            patterns[9] = inputs.First(i => i.Length == 6 && (i.Contains(tr) && i.Contains(br)) && (i.Contains(tl) && i.Contains(m)));

            return patterns.ToList();
        }
    }
}
