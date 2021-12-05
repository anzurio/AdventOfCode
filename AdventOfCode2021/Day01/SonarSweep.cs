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
        private static int[] Measurements;

        public void ParseInput(IEnumerable<string> input)
        {
            Measurements = input.Select(x => int.Parse(x)).ToArray(); 
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
            outputStream.WriteNewLine();
            count = 0;
            
            for(int i = 0; i < Measurements.Length - 3; i++)
            {
                var previousWindow = Measurements[i] + Measurements[i + 1] + Measurements[i + 2];
                var currentWindow = Measurements[i + 1] + Measurements[i + 2] + Measurements [i + 3];
                if (currentWindow > previousWindow)
                {
                    count++;
                }
            }
            outputStream.Write(count);
        }
    }
}
