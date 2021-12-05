using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day03
{
    public class Dive : ISolver
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public int X_Ex { get; private set; }
        public int Y_Ex { get; private set; }
        public int Aim { get; private set; }

        public void ParseInput(IEnumerable<string> input)
        {
            CalculatePartOne(input);
            CalculatePartTwo(input);
        }

        private void CalculatePartOne(IEnumerable<string> input)
        {
            var x = 0;
            var y = 0;
            foreach (var current in input)
            {
                var values = current.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var magnitude = int.Parse(values[1]);
                if (string.Compare("forward", values[0], ignoreCase: true) == 0)
                {
                    x += magnitude;
                }
                else if (string.Compare("down", values[0], ignoreCase: true) == 0)
                {
                    y += magnitude;
                }
                else if (string.Compare("up", values[0], ignoreCase: true) == 0)
                {
                    y -= magnitude;
                }

                this.X = x;
                this.Y = y;
            }
        }

        private void CalculatePartTwo(IEnumerable<string> input)
        {
            var x = 0;
            var y = 0;
            var aim = 0;
            foreach (var current in input)
            {
                var values = current.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var magnitude = int.Parse(values[1]);
                if (string.Compare("forward", values[0], ignoreCase: true) == 0)
                {
                    x += magnitude;
                    y += (aim * magnitude);
                }
                else if (string.Compare("down", values[0], ignoreCase: true) == 0)
                {
                    aim += magnitude;
                }
                else if (string.Compare("up", values[0], ignoreCase: true) == 0)
                {
                    aim -= magnitude;
                }

                this.X_Ex = x;
                this.Y_Ex = y;
            }
        }

        public void Solve(OutputStream outputStream)
        {
            outputStream.Write(X * Y);
            outputStream.WriteNewLine();
            outputStream.Write(X_Ex * Y_Ex);
        }
    }
}
