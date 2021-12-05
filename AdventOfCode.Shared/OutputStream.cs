using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Shared
{
    public abstract class OutputStream : IDisposable
    {
        public abstract OutputStream Open();
        public abstract void Dispose();
        public abstract void Write(string s);
        public abstract void Write(char c);
        public abstract void Write(int i);
        public abstract void WriteNewLine();
       
    }
}
