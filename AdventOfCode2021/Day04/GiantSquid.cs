using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04
{
    public class GiantSquid : ISolver
    {
        private int[] drawings;
        private List<Board> boards = new List<Board>();

        public void ParseInput(IEnumerable<string> input)
        {
            var array = input.ToArray();
            
            drawings = array[0].Split(",").Select(x => int.Parse(x)).ToArray();
            for (int i = 2; i < input.Count(); i += 6)
            {
                var board = new int[5][];
                for (int j = 0; j < 5; j++)
                {
                    board[j] = array[i + j].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                    
                }
                boards.Add(new Board(drawings, board));
            }
        }

        public void Solve(OutputStream outputStream)
        {
            var winningBoard = boards.OrderBy(x => x.WinningTurn).First();
            outputStream.Write(winningBoard.Score);
            outputStream.WriteNewLine();
        }
    }
}
