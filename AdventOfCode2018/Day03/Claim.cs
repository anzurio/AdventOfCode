using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Day03
{
    public class Claim
    {
        public int Id { get; private set; }
        public int Left { get; private set; }
        public int Top { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Claim(int id, int left, int top, int width, int height)
        {
            Id = id;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }
    }
}
