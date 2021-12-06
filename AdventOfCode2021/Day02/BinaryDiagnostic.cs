using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day02
{
    class BinaryDiagnostic : ISolver
    {
        char[][] values;

        public void ParseInput(IEnumerable<string> input)
        {
            List<char[]> lineValues = new List<char[]>();
            foreach (var line in input)
            {
                var chars = line.ToCharArray();
                lineValues.Add(chars);
            }
            values = lineValues.ToArray();
        }

        public void Solve(OutputStream outputStream)
        {
            var gamma = new List<char>();
            var epsilon = new List<char>();
            for (int j = 0; j < values[0].Length; j++)
            {
                var onesCount = 0;
                var zerosCount = 0;
                
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i][j] == '0')
                    {
                        zerosCount++;
                    }
                    else
                    {
                        onesCount++;
                    }
                }
                if (zerosCount > onesCount)
                {
                    gamma.Add('0');
                    epsilon.Add('1');
                }
                else
                {
                    gamma.Add('1');
                    epsilon.Add('0');
                }
            }
            outputStream.Write(Convert(gamma.ToArray()) * Convert(epsilon.ToArray()));

        }

        private int Convert(char[] rate)
        {
            var exp = 0;
            var returnValue = 0;
            for (int i = rate.Length - 1; i >= 0; i--)
            {
                returnValue += (rate[i] == '1') ? (int)Math.Pow(2, exp) : 0;
                exp += 1;
            }

            return returnValue;
        }
    }
}
