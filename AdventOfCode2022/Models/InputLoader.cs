using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace AdventOfCode2022.Models
{
    internal static class InputLoader
    {
        static string DefaultInput(DayPuzzle day)
        {
            var str = day.ToString();
            switch (day)
            {
                default:
                    return DefaultInput(str);
            }
        }
        static string DefaultInput(string inputName) => AdventOfCode2022.DefaultInputs.ResourceManager.GetString(inputName) ?? "";
        static List<string> ReadResource(string resource)
        {
            return resource?.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)?.ToList() ?? new List<string>();
        }

        public static List<string> ReadDefaultInput(DayPuzzle day) => ReadResource(DefaultInput(day));

    }
}
