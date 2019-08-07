﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018
{
    public abstract class OutputStream : IDisposable
    {
        public abstract OutputStream Open();
        public abstract void Dispose();
        public abstract void Write(string s);
        public abstract void Write(char c);
    }
}
