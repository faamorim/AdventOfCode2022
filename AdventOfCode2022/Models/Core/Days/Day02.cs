using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Models.Days
{
    internal class Day02 : DayBase
    {
        public override DayPuzzle DayPuzzle => DayPuzzle.Day02;

        enum RockPaperScissor : int
        {
            Rock = 0,
            Paper = 1,
            Scissor = 2,
        }

        enum Result : int
        {
            Loss = -1,
            Draw = 0,
            Win = 1
        }

        List<(RockPaperScissor oponent, RockPaperScissor player)> GamePlan1 = new List<(RockPaperScissor, RockPaperScissor)>();
        List<(RockPaperScissor oponent, Result result)> GamePlan2 = new List<(RockPaperScissor, Result)>();

        Result GetResult(RockPaperScissor player, RockPaperScissor oponent)
        {
            return (Result)((player - oponent + 4) % 3 - 1);
        }

        int ResultScore(Result result)
        {
            return ((int)result + 1) * 3;
        }

        RockPaperScissor GetChoice(RockPaperScissor oponent, Result result)
        {
            return (RockPaperScissor)(((int)oponent + (int)result + 3) % 3);
        }

        int ChoiceScore (RockPaperScissor choice)
        {
            return (int)choice + 1;
        }

        public override long Part1()
        {
            return GamePlan1.Sum(game => ResultScore(GetResult(game.Item2, game.Item1)) + ChoiceScore(game.Item2));
        }

        public override long Part2()
        {
            return GamePlan2.Sum(game => ResultScore(game.Item2) + ChoiceScore(GetChoice(game.Item1, game.Item2)));
        }

        protected override void LoadData(List<string> input)
        {
            RockPaperScissor ParseChoice(char code)
            {
                switch (code)
                {
                    case 'A':
                    case 'X':
                        return RockPaperScissor.Rock;
                    case 'B':
                    case 'Y':
                        return RockPaperScissor.Paper;
                    case 'C':
                    case 'Z':
                        return RockPaperScissor.Scissor;
                    default:
                        throw new FormatException();
                }
            }
            Result ParseResult(char code)
            {
                switch (code)
                {
                    case 'X':
                        return Result.Loss;
                    case 'Y':
                        return Result.Draw;
                    case 'Z':
                        return Result.Win;
                    default:
                        throw new FormatException();

                }
            }
            try
            {
                GamePlan1 = input.Select(game => (ParseChoice(game.First()), ParseChoice(game.Last()))).ToList();
                GamePlan2 = input.Select(game => (ParseChoice(game.First()), ParseResult(game.Last()))).ToList();
            }
            catch (Exception e)
            {

            }
        }
    }
}
