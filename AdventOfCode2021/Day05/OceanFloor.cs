using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day05
{
    public class OceanFloor
    {
        private List<Lines>[,] vents = new List<Lines>[1000, 1000];
        private List<Lines>[,] ventsIncludingDiagonal = new List<Lines>[1000, 1000];

        internal void Add(Lines vent)
        {
            if (vent.X1 == vent.X2)
            {
                var minVentY = Math.Min(vent.Y1, vent.Y2);
                var maxVentY = Math.Max(vent.Y1, vent.Y2);
                for (int i = minVentY; i <= maxVentY; i++)
                {
                    if (vents[vent.X1, i] == null)
                    {
                        vents[vent.X1, i] = new List<Lines>();
                    }
                    if (ventsIncludingDiagonal[vent.X1, i] == null)
                    {
                        ventsIncludingDiagonal[vent.X1, i] = new List<Lines>();
                    }
                    vents[vent.X1, i].Add(vent);
                    ventsIncludingDiagonal[vent.X1, i].Add(vent);
                }
            } 
            else if (vent.Y1 == vent.Y2)
            {
                var minVentX = Math.Min(vent.X1, vent.X2);
                var maxVentX = Math.Max(vent.X1, vent.X2);
                for (int i = minVentX; i <= maxVentX; i++)
                {
                    if (vents[i, vent.Y1] == null)
                    {
                        vents[i, vent.Y1] = new List<Lines>();
                    }
                    if (ventsIncludingDiagonal[i, vent.Y1] == null)
                    {
                        ventsIncludingDiagonal[i, vent.Y1] = new List<Lines>();
                    }
                    vents[i, vent.Y1].Add(vent);
                    ventsIncludingDiagonal[i, vent.Y1].Add(vent);
                }
            }
            else
            {
                var deltaX = vent.X1 < vent.X2 ? 1 : -1;
                var deltaY = vent.Y1 < vent.Y2 ? 1 : -1;
                var stepsX = Math.Abs(vent.X1 - vent.X2);
                var stepsY = Math.Abs(vent.Y1 - vent.Y2);
                var i = vent.X1;
                var j = vent.Y1;
                while (stepsX > 0 && stepsY > 0)
                {
                    if (ventsIncludingDiagonal[i, j] == null)
                    {
                        ventsIncludingDiagonal[i, j] = new List<Lines>();
                    }
                    ventsIncludingDiagonal[i, j].Add(vent);

                    i += deltaX;
                    j += deltaY;
                    stepsX--;
                    stepsY--;
                }
                i = vent.X2;
                j = vent.Y2;
                if (ventsIncludingDiagonal[i, j] == null)
                {
                    ventsIncludingDiagonal[i, j] = new List<Lines>();
                }
                ventsIncludingDiagonal[i, j].Add(vent);


            }
        }

        public int OverlappingLines()
        {
            var count = 0;
            foreach (var vent in vents)
            {
                if (vent != null && vent.Count > 1)
                {
                    count++;
                }
            }

            return count;
        }

        public int OverlappingLinesIncludingDiagonals()
        {
            var count = 0;
            foreach (var vent in ventsIncludingDiagonal)
            {
                if (vent != null && vent.Count > 1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
