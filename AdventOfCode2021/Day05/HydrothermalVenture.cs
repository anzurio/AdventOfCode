using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day05
{
    public class HydrothermalVenture : ISolver
    {
        private OceanFloor OceanFloor = new OceanFloor();
        public void ParseInput(IEnumerable<string> input)
        {
            var regAutomaton = new Regex(@"([0-9]+),([0-9]+) -> ([0-9]+),([0-9]+)");
            foreach (var line in input)
            {
                var match = regAutomaton.Match(line);
                if (match.Success)
                {
                    OceanFloor.Add(new Lines(
                        int.Parse(match.Groups[1].Value),
                        int.Parse(match.Groups[2].Value),
                        int.Parse(match.Groups[3].Value),
                        int.Parse(match.Groups[4].Value)
                     ));
                }
            }

        }

        public void Solve(OutputStream outputStream)
        {
            outputStream.Write(OceanFloor.OverlappingLines());
            outputStream.WriteNewLine();
            outputStream.Write(OceanFloor.OverlappingLinesIncludingDiagonals());
        }
    }
}
