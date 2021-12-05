using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Shared
{
    public interface ISolver
    {
        void ParseInput(IEnumerable<string> input);
        void Solve(OutputStream outputStream);
    }
}
