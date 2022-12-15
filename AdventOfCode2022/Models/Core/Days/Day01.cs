using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Models.Days
{
    internal class Day01 : DayBase
    {
        public override DayPuzzle DayPuzzle => DayPuzzle.Day01;
        public List<List<int>> ElvesCalories { get; private set; } = new List<List<int>>();

        public override long Part1()
        {
            return ElvesCalories.Select(elf => elf.Select(calorie => (long)calorie).Sum()).OrderByDescending(calorieSum => calorieSum).First();
        }

        public override long Part2()
        {
            return ElvesCalories.Select(elf => elf.Select(calorie => (long)calorie).Sum()).OrderByDescending(calorieSum => calorieSum).Take(3).Sum();
        }

        protected override void LoadData(List<string> input)
        {
            var test1 = String.Join(" ", input);
            var test2 = test1.Split("  ");
            var test3 = test2.Select(elf => elf.Split(" "));
            ElvesCalories = String.Join(" ", input).Split("  ").Select(elf => elf.Split(" ").Select(calorie => int.Parse(calorie)).ToList()).ToList();
        }
    }
}
