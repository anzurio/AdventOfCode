using System;

namespace AdventOfCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem10 = new Day10.TheStarsAlign();
            problem10.ParseInput(SampleInputs.TheStarsAlign);
            problem10.Solve(new FileOutput("day10.txt"));

            Console.WriteLine("Hello World!");
            Console.Read();
        }
    }
}
