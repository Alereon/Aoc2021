using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode_2021.Solutions
{
    internal class day_14
    {
        public void Solution1()
        {
            string[] lines = System.IO.File.ReadAllLines("../../../input/input-day14.txt");
            StringBuilder template = new StringBuilder(lines[0]);
            Dictionary<string, char> pairs = new Dictionary<string, char>();
            Dictionary<char, long> keyCount = new Dictionary<char, long>();

            for (int i = 2; i < lines.Length; i++)
            {
                var tokens = lines[i].Split(" -> ");
                pairs.Add(tokens[0], char.Parse(tokens[1]));
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < template.Length - 1; j++)
                {
                    var pair = template[j].ToString() + template[j + 1].ToString();

                    if (pairs.ContainsKey(pair))
                    {
                        template.Insert(j + 1, pairs[pair]);
                        j++;
                    }
                }
            }

            for (int i = 0; i < template.Length; i++)
            {
                if (keyCount.ContainsKey(template[i]))
                {
                    keyCount[template[i]]++;
                }
                else
                {
                    keyCount.Add(template[i], 1);
                }
            }

            Console.WriteLine(keyCount.Values.Max() - keyCount.Values.Min());
        }
        public void Solution2()
        {
            var inputs = System.IO.File.ReadAllLines("../../../input/input-day14.txt");

            //  var stopwatch = Stopwatch.StartNew();
            var template = inputs[0];
            var rules = inputs
                .Skip(2)
                .Select(line => new PolymerPair
                {
                    Key = line.Substring(0, 2),
                    Result = line.Last(),
                    Children = new List<PolymerPair>(),
                })
                .ToList();

            foreach (var rule in rules)
            {
                rule.Children.Add(rules.First(r => r.Key == $"{rule.First}{rule.Result}"));
                rule.Children.Add(rules.First(r => r.Key == $"{rule.Result}{rule.Second}"));
            }

            var counts = rules.ToDictionary(rule => rule.Key, _ => 0L);
            var letterCounts = Enumerable.Range(0, 26).ToDictionary(i => Convert.ToChar('A' + i), _ => 0L);

            for (var i = 0; i < template.Length; i++)
            {
                if (i < template.Length - 1)
                    counts[template.Substring(i, 2)]++;

                letterCounts[template[i]]++;
            }

            for (var i = 0; i < 40; i++)
            {
                var countsCopy = counts.ToDictionary(count => count.Key, count => count.Value);
                foreach (var rule in rules)
                {
                    foreach (var child in rule.Children)
                    {
                        countsCopy[child.Key] += counts[rule.Key];
                    }

                    letterCounts[rule.Result] += counts[rule.Key];
                    countsCopy[rule.Key] -= counts[rule.Key];
                }
                counts = countsCopy;
            }

            var count = letterCounts.Max(x => x.Value) - letterCounts.Where(x => x.Value > 0).Min(x => x.Value);

            Console.WriteLine(count);
        }

        private class PolymerPair
        {
            public string Key { get; set; }

            public char First => Key[0];

            public char Second => Key[1];

            public char Result { get; set; }

            public List<PolymerPair> Children { get; set; }
        }
    }
}
