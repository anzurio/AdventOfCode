using System;

namespace AdventOfCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem3 = new Day03.NoMatterHowYouSliceIt();
            problem3.ParseInput(SampleInputs.NoMatterHowYouSliceIt);
            problem3.Solve(new ConsoleOutput());

            var problem10 = new Day10.TheStarsAlign();
            problem10.ParseInput(SampleInputs.TheStarsAlign);
            problem10.Solve(new ConsoleOutput());

            var problem18 = new Day18.SettlersOfTheNorthPole();
            problem18.ParseInput(SampleInputs.SettlersOfTheNorthPole);
            problem18.Solve(new ConsoleOutput());

            Console.Read();
        }
    }
}
