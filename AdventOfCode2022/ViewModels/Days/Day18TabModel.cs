using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ViewModels.Days
{
    internal class Day18TabModel : DayTabModelBase
    {
        public override string Header => "Day 18";

        protected override Models.DayBase Puzzle => Day18Puzzle;
        Models.Days.Day18 Day18Puzzle = new Models.Days.Day18();

        public Day18TabModel()
        {
            Puzzle.SetupFromDefault();
        }
    }
}
