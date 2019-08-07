using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2018.Day10
{
    public class TheStarsAlign : ISolver
    {
        private NightSky NightSky { get; set; } = new NightSky();

        public void ParseInput(IEnumerable<string> inputStream)
        {
            var regAutomaton = new Regex(@"position=<([0-9\- ]+), ([0-9\- ]+)> velocity=<([0-9\- ]+), ([0-9\- ]+)>");

            foreach (var line in inputStream)
            {
                var match = regAutomaton.Match(line);
                NightSky.Add(new Star(
                        int.Parse(match.Groups[1].Value),
                        int.Parse(match.Groups[2].Value),
                        int.Parse(match.Groups[3].Value),
                        int.Parse(match.Groups[4].Value)));
            }
        }

        public void Solve(OutputStream os)
        {
            var minimumNightSky = GetDtMinimumArea();
            Print(os, minimumNightSky);
        }

        private void Print(OutputStream os, IEnumerable<(int X, int Y)> enumerable)
        {
            var bounds = GetBounds(enumerable);
            throw new NotImplementedException();
        }

        private IEnumerable<(int X, int Y)> GetDtMinimumArea()
        {
            // FIX Potential infinite loop
            /*while (true)
            {
                var nextNightSky = NightSky[dt + 1];
                var nextArea = GetArea(nextNightSky);
                if (nextArea > currentArea)
                {
                    return minimumNightSky;
                }
                else
                {
                    dt++;
                }
            }*/
        }

        private int GetArea(IEnumerable<(int X, int Y)> points)
        {
            var (minX, minY, maxX, maxY) = GetBounds(points);

            return (minX - maxX + 1) * (minY - maxY + 1);
        }

        private (int MinX, int MinY, int MaxX, int MaxY) GetBounds(IEnumerable<(int X, int Y)> points)
        {
            var minX = int.MaxValue;
            var minY = int.MaxValue;
            var maxX = int.MinValue;
            var maxY = int.MinValue;
            foreach (var point in points)
            {
                if (minX > point.X)
                {
                    minX = point.X;
                }
                if (minY > point.Y)
                {
                    minY = point.Y;
                }
                if (maxX < point.X)
                {
                    maxX = point.X;
                }
                if (maxY < point.Y)
                {
                    maxY = point.Y;
                }
            }

            return (minX, minY, maxX, maxY);
        }
    }
}
