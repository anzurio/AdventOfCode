using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018
{
    public interface ISolver
    {
        void ParseInput(IEnumerable<string> input);
        void Solve(OutputStream outputStream);
    }
}
