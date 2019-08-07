using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Day10
{
    internal sealed class NightSky
    {
        private List<Star> Stars { get; set; } = new List<Star>();

        public void Add(Star star)
        {
            Stars.Add(star);
        }

        public IEnumerable<(int X, int Y)> this[int dt] => Stars.Select(star => star[dt]);
        
    }
}
