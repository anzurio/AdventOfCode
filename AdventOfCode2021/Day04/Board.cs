using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day04
{
    class Board
    {
        HashSet<int>[] WinningSets = new HashSet<int>[10];
        HashSet<int> availableValues = new HashSet<int>();

        public int WinningTurn { get; private set; }
        public int Score { get; private set; }

        public Board(int[] drawings, int[][] board)
        {
            WinningTurn = drawings.Length;
            WinningSets[5] = new HashSet<int>();
            WinningSets[6] = new HashSet<int>();
            WinningSets[7] = new HashSet<int>();
            WinningSets[8] = new HashSet<int>();
            WinningSets[9] = new HashSet<int>();
            for (int i = 0; i < board.Length; i++)
            {
                WinningSets[i] = board[i].ToHashSet();
                for (int j = 0; j < board[i].Length; j++)
                {
                    availableValues.Add(board[i][j]);
                    WinningSets[5 + j].Add(board[i][j]);
                }
            }

            for (var turn = 0; turn < drawings.Length; turn++)
            {
                availableValues.Remove(drawings[turn]);
                foreach (var set in WinningSets)
                {
                    set.Remove(drawings[turn]);
                }
                if (WinningSets.Any(x => x.Count == 0))
                {
                    Score = availableValues.Sum() * drawings[turn];
                    WinningTurn = turn;
                    break;
                }
               
            }

        }
    }
}
