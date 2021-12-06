using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day06
{
    public class Lanternfish : ISolver
    {
        List<int> initialState;
        List<int> initialState2;

        public void ParseInput(IEnumerable<string> input)
        {
            initialState = input.First().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            initialState2 = input.First().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

        }

        public void Solve(OutputStream outputStream)
        {
            for (int i = 0; i < 80; i++)
            {
                var length = initialState.Count;
                for (int j = 0; j < length; j++)
                {
                    if (initialState[j] == 0)
                    {
                        initialState.Add(8);
                        initialState[j] = 6;
                    }
                    else
                    {
                        initialState[j]--;
                    }

                }
            }
            outputStream.Write(initialState.Count);


            ulong[] lastState = new ulong[9];
            foreach (var state in initialState2)
            {
                if (state != 0)
                {
                    lastState[state]++;
                }
            }


            for (int i = 1; i < 257; i++)
            {
                ulong[] currentState = new ulong[]
                {
                    lastState[1], //0
                    lastState[2], //1
                    lastState[3], //2
                    lastState[4], //3
                    lastState[5], //4
                    lastState[6], //5
                    lastState[7] + lastState[0], //6
                    lastState[8], //7
                    lastState[0] //8
                };
                lastState = currentState;
            }

            ulong sum = 0;
            foreach (var x in lastState )
            {
                sum += x;
            }

            outputStream.WriteNewLine();

            outputStream.Write(sum.ToString());
        }
    }
}
