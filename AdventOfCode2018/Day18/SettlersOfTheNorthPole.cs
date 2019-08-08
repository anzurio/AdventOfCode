using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2018.Day18
{
    public class SettlersOfTheNorthPole : ISolver
    {
        private Field Field { get; set; }

        public void ParseInput(IEnumerable<string> inputStream)
        {
            var y = 0;
            var width = 0;
            char[,] acres = null;
            foreach (var line in inputStream)
            {
                var chars = line.ToArray();
                var count = chars.Count(c => c == Field.Lumberyard || c == Field.OpenGround || c == Field.Trees);
                if (count > 0)
                {
                    if (acres == null)
                    {
                        width = count;
                        acres = new char[width, width];
                    }
                    for (int i = 0; i < width; i++)
                    {
                       acres[i, y] = chars[i];
                    }
                    y++;
                }
            }
            Field = new Field(width, acres);
            Debug.Assert(width == y, "The input should represent a square.");
        }

        public void Solve(OutputStream os)
        {
            using (var openedStream = os.Open())
            {
                os.Write(Field[10].ResourceValue);
                os.WriteNewLine();
                os.Write(Field[1000000000].ResourceValue);
            }
        }
    }
}
