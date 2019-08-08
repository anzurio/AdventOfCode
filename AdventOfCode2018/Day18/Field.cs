using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Day18
{
    public class Field
    {
        private Dictionary<int, Field> FieldsThroughTime { get; set; } = new Dictionary<int, Field>();
        private Dictionary<string, int> FieldHashesThroughTime { get; set; } = new Dictionary<string, int>();

        private int SideSize { get; set; }
        private char[,] Acres { get; set; }
        internal const char OpenGround = '.';
        internal const char Trees = '|';
        internal const char Lumberyard = '#';

        public Field(int sideSize, char[,] acres)
        {
            Acres = acres;
            SideSize = sideSize;
            FieldsThroughTime[0] = this;
            FieldHashesThroughTime[ToString()] = 0;
        }

        public int ResourceValue
        {
            get
            {
                var trees = 0;
                var lumberyards = 0;
                foreach (var acre in Acres)
                {
                    if (acre == Trees)
                    {
                        trees += 1;
                    }
                    if (acre == Lumberyard)
                    {
                        lumberyards += 1;
                    }
                }
                return trees * lumberyards;
            }
        }

        public char this[int x,int y] => Acres[x, y];
        

        public Field this[int minute]
        {
            get
            {
                Debug.Assert(minute >= 0, "Looking into the past is not supported.");
                Debug.Assert(FieldsThroughTime.ContainsKey(0), "Initial Field should be set in the FieldsThroughTime");
                if (FieldsThroughTime.ContainsKey(minute))
                {
                    return FieldsThroughTime[minute];
                }
                for (int i = 0; i < minute; i++)
                {
                    if (!FieldsThroughTime.ContainsKey(i + 1))
                    {
                        FieldsThroughTime[i + 1] = FieldsThroughTime[i].Step();
                    }
                }
                return FieldsThroughTime[minute];
            }
        }
        
        public Field Step()
        {
            var newField = new char[SideSize, SideSize];

            for (int i = 0; i < SideSize; i++)
            {
                for (int j = 0; j < SideSize; j++)
                {
                    var neighbors = GetNeighbors(i, j);
                    if (Acres[i, j] == OpenGround && 
                        neighbors.Count(n => n == Trees) >= 3)
                    {
                        newField[i, j] = Trees;
                    }
                    else if (Acres[i, j] == Trees && 
                        neighbors.Count(n => n == Lumberyard) >= 3)
                    {
                        newField[i, j] = Lumberyard;
                    }
                    else if (Acres[i, j] == Lumberyard && 
                        neighbors.Any(n => n == Lumberyard) && 
                        neighbors.Any(n => n == Trees))
                    {
                        newField[i, j] = Lumberyard;
                    }
                    else if (Acres[i, j] == Lumberyard)
                    {
                        newField[i, j] = OpenGround;
                    }
                    else
                    {
                        newField[i, j] = Acres[i, j];
                    }
                }
            }

            return new Field(SideSize, newField);
        }

        private List<char> GetNeighbors(int x, int y)
        {
            var neighbors = new List<char>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (!(i == 0 && j == 0))
                    {
                        if (x + i >= 0 && x + i < SideSize &&
                            y + j >= 0 && y + j < SideSize)
                        {
                            neighbors.Add(this[x + i, y + j]);
                        }
                    }
                }
            }

            return neighbors;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in Acres)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
