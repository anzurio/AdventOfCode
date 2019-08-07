using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018
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
