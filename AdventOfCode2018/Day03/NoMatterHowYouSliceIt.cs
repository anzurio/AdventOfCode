using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2018.Day03
{
    public class NoMatterHowYouSliceIt : ISolver
    {
        private List<Claim> Claims { get; set; } = new List<Claim>();

        public void ParseInput(IEnumerable<string> inputStream)
        {
            var regAutomaton = new Regex(@"#([0-9]+) @ ([0-9]+),([0-9]+): ([0-9]+)x([0-9]+)");

            foreach (var line in inputStream)
            {
                var match = regAutomaton.Match(line);
                Claims.Add(new Claim(
                        int.Parse(match.Groups[1].Value),
                        int.Parse(match.Groups[2].Value),
                        int.Parse(match.Groups[3].Value),
                        int.Parse(match.Groups[4].Value),
                        int.Parse(match.Groups[5].Value)));
            }
        }

        public void Solve(OutputStream os)
        {
            throw new NotImplementedException();
        }
    }
}
