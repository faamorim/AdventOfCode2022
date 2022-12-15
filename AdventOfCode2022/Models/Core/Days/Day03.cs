using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Models.Days
{
    internal class Day03 : DayBase
    {
        public override DayPuzzle DayPuzzle => DayPuzzle.Day03;

        List<string> Rucksacks = new List<string>();

        List<char> SharedTypes ((string, string) rucksack)
        {
            return rucksack.Item1.Distinct().Join(rucksack.Item2.Distinct(), type => type, type => type, (type1, type2) => type1).ToList();
        }

        char GetBadge(List<string> rucksacks)
        {
            if (!rucksacks.Any())
                return ' ';
            var shared = rucksacks[0].ToList(); ;
            for (int i = 1; i < rucksacks.Count; i++)
            {
                shared = shared.Distinct().Join(rucksacks[i].Distinct(), type => type, type => type, (type1, type2) => type1).ToList();
            }
            if (shared.Count == 1)
                return shared.First();
            return ' ';
        }

        int Priority(char item)
        {
            if (char.IsLower(item))
                return item - 'a' + 1;
            if (char.IsUpper(item))
                return item - 'A' + 27;
            return 0;
        }

        public override long Part1()
        {
            var rucksacks = Rucksacks.Select(rucksack => (rucksack.Substring(0, rucksack.Length / 2), rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2))).ToList();
            return rucksacks.Sum(rucksack => SharedTypes(rucksack).Sum(type => (long)Priority(type)));
        }

        public override long Part2()
        {
            var groups = Rucksacks.Select((rucksack, index) => (rucksack, index)).GroupBy(group => group.index / 3).Select(group => group.Select(group => group.rucksack).ToList()).ToList();
            return groups.Sum(group => Priority(GetBadge(group)));
        }

        protected override void LoadData(List<string> input)
        {
            Rucksacks = input;
        }
    }
}
