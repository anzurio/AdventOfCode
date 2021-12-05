using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Shared
{
    public class ConsoleOutput : OutputStream
    {
        public override void Dispose()
        {
            WriteNewLine();
        }

        public override OutputStream Open()
        {
            return this;
        }

        public override void Write(string s)
        {
            Console.Write(s);
        }

        public override void Write(char c)
        {
            Console.Write(c);
        }

        public override void Write(int i)
        {
            Console.Write(i);
        }

        public override void WriteNewLine()
        {
            Console.WriteLine();
        }
    }
}
