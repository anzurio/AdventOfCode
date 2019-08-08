using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2018.Day18
{
    public class Field
    {
        private int SideSize { get; set; }
        private char[,] Acres { get; set; }
        internal const char OpenGround = '.';
        internal const char Trees = '|';
        internal const char Lumberyard = '#';

        public Field(int sideSize)
        {
            Acres = new char[sideSize, sideSize];
            SideSize = sideSize;
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

        public char this[int x,int y]
        {
            get => Acres[x, y];

            set => Acres[x, y] = value;
        }

        public Field this[int minute]
        {
            get
            {
                Debug.Assert(minute >= 0, "Looking into the past is not supported.");
                var field = this;
                for (int i = 1; i <= minute; i++)
                {
                    field = field.Step();
                }
                return field;
            }
        }
        
        public Field Step()
        {
            var newField = new Field(SideSize);

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

            return newField;
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
                        try
                        {
                            neighbors.Add(Acres[x + i, y + j]);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            
                        }
                    }
                }
            }

            return neighbors;
        }
    }
}
