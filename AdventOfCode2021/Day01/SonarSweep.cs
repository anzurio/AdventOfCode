using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day01
{
    public class SonarSweep : ISolver
    {
        private static List<int> Measurements = new List<int>();

        public void ParseInput(IEnumerable<string> input)
        {
            Measurements = input.Select(x => int.Parse(x)).ToList(); 
        }

        public void Solve(OutputStream outputStream)
        {
            var previous = -1;
            var count = 0;
            foreach (var measurement in Measurements)
            {
                if (previous < measurement)
                {
                    count++;
                }
                previous = measurement;
            }


            outputStream.Write(count - 1);
        }
    }
}
