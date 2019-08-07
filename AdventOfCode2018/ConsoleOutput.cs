﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018
{
    public class ConsoleOutput : OutputStream
    {
        public override void Dispose()
        {
            // No op
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

        public override void WriteNewLine()
        {
            Console.WriteLine();
        }
    }
}