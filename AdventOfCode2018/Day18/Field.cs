using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Day18
{
    public class Field
    {
        private char[,] keyValuePairs { get; set; } 

        public Field(int sideSize)
        {
            keyValuePairs = new char[sideSize, sideSize];
        }

        public char this[int x,int y]
        {
            get => keyValuePairs[x, y];

            set => keyValuePairs[x, y] = value;
        }
    }
}
