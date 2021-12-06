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
            List<char> gamma, epsilon;
            SolvePartOne(out gamma, out epsilon);
            outputStream.Write(Convert(gamma.ToArray()) * Convert(epsilon.ToArray()));
            outputStream.WriteNewLine();
            List<char[]> o2RatingValues, co2rating;
            SolvePartTwo(out o2RatingValues, out co2rating);

            outputStream.Write(Convert(o2RatingValues.First().ToArray()) * Convert(co2rating.First().ToArray()));
        }

        
        private void SolvePartOne(out List<char> gamma, out List<char> epsilon)
        {
            gamma = new List<char>();
            epsilon = new List<char>();
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

        private void SolvePartTwo(out List<char[]> o2RatingValues, out List<char[]> co2rating)
        {
            o2RatingValues = values.ToList();
            while (o2RatingValues.Count > 1)
            {
                for (int j = 0; j < o2RatingValues[0].Length; j++)
                {
                    var onesCount = 0;
                    var zerosCount = 0;

                    for (int i = 0; i < o2RatingValues.Count(); i++)
                    {
                        if (o2RatingValues[i][j] == '0')
                        {
                            zerosCount++;
                        }
                        else
                        {
                            onesCount++;
                        }
                    }
                    if (onesCount >= zerosCount)
                    {
                        o2RatingValues = o2RatingValues.Where(x => x[j] == '1').ToList();
                    }
                    else
                    {
                        o2RatingValues = o2RatingValues.Where(x => x[j] == '0').ToList();
                    }
                    if (o2RatingValues.Count == 1) break;
                }


            }

            co2rating = values.ToList();
            while (co2rating.Count > 1)
            {
                for (int j = 0; j < co2rating[0].Length; j++)
                {
                    var onesCount = 0;
                    var zerosCount = 0;

                    for (int i = 0; i < co2rating.Count(); i++)
                    {
                        if (co2rating[i][j] == '0')
                        {
                            zerosCount++;
                        }
                        else
                        {
                            onesCount++;
                        }
                    }
                    if (onesCount >= zerosCount)
                    {
                        co2rating = co2rating.Where(x => x[j] == '0').ToList();
                    }
                    else
                    {
                        co2rating = co2rating.Where(x => x[j] == '1').ToList();
                    }
                    if (co2rating.Count == 1) break;
                }
            }
        }
    }
}
