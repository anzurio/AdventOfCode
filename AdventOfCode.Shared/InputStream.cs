using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Shared
{
    public abstract class InputStream : IEnumerable<string>
    {
        public abstract IEnumerator<string> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
