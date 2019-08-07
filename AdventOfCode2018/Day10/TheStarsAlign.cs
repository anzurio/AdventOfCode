using System.Collections.Generic;
using System.Linq;
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
            var minimumNightSky = GetMinimumArea();
            using (var openedStream = os.Open())
            {
                Print(openedStream, minimumNightSky);
            }
        }

        private void Print(OutputStream os, IEnumerable<(int X, int Y)> points)
        {
            var bounds = GetBounds(points);
            for (var j = bounds.MinY; j <= bounds.MaxY; j++)
            {
                var xLookup = points.Where(point => point.Y == j).ToLookup(point => point.X);
                for (var i = bounds.MinX; i <= bounds.MaxX; i++)
                {
                    if (xLookup.Contains(i))
                    {
                        os.Write('*');
                    }
                    else
                    {
                        os.Write(' ');
                    }
                }
                os.WriteNewLine();
            }
        }

        private IEnumerable<(int X, int Y)> GetMinimumArea()
        {
            int dt = 0;
            var currentNightSky = NightSky[dt];
            var currentArea = GetArea(currentNightSky);
            // FIX Potential infinite loop
            while (true)
            {
                var nextNightSky = NightSky[++dt];
                var nextArea = GetArea(nextNightSky);
                // FIX If T+1 instead of decreasing, increases, this will return the first one.
                if (nextArea > currentArea)
                {
                    return currentNightSky;
                }
                else
                {
                    currentNightSky = nextNightSky;
                    currentArea = nextArea;
                }
            }
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
