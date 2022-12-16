﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Models
{
    internal abstract class DayBase
    {
        public abstract DayPuzzle DayPuzzle { get; }

        protected abstract void LoadData(List<string> input);

        public abstract long Part1();
        public abstract long Part2();

        public void SetupFromFile(object source = null)
        {

        }

        public void SetupFromDefault()
        {
            LoadData(InputLoader.ReadDefaultInput(DayPuzzle));
        }
    }
}
