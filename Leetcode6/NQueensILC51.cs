using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Really we are getting a list of allowed column values [1,3,0,2] and [2,0,3,1] with the index being the row. #LC52
// 3 Helper methods - GetDefaultBoard -> OverlayOutputOnDefaultBoard -> ConvertOutputToStringRepresentation
// Idea from #Neetcode #AE
// With 3 HashSet, the isSafe is very straightforward and efficient

namespace Leetcode
{
    public class NQueensILC51
    {
        HashSet<int> blockedCols = new HashSet<int>();
        HashSet<int> blockedUpDiags = new HashSet<int>();
        HashSet<int> blockedDownDiags = new HashSet<int>();
        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<int>> output = new List<IList<int>>();
            RecurseAndBackTrack(output, 0, n);
            IList<IList<string>> result = ConvertOutputToStringRepresentation(output,n);
            return result;
        }

        private IList<string> GetDefaultBoard(int n)
        {
            IList<string> currBoard = new List<string>();
            StringBuilder row;

            //default board ....,....,...
            for (int i = 0; i < n; i++)
            {
                row = new StringBuilder();
                for (int j = 0; j < n; j++)
                {
                    row.Append(".");
                }
                currBoard.Add(row.ToString());
            }
            return currBoard;
        }

        private IList<IList<string>> ConvertOutputToStringRepresentation(IList<IList<int>> outputs, int n)
        {
            IList<IList<string>> result = new List<IList<string>>();
            foreach (var output in outputs)
            {
                var defaultBoard = GetDefaultBoard(n);
                IList<string> board = OverlayOutputOnDefaultBoard(output, defaultBoard, n);
                result.Add(board);
            }
            return result;
        }

        private IList<string> OverlayOutputOnDefaultBoard(IList<int> output, IList<string> defaultBoard, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int row = i;
                int col = output[row];
                StringBuilder sb = new StringBuilder(defaultBoard[row]);
                sb[col] = 'Q';
                defaultBoard[row] = sb.ToString(); 
            }
            return defaultBoard;
        }

        private void RecurseAndBackTrack(IList<IList<int>> output, int row, int n)
        {
            if (n == row)
                output.Add(new List<int>(blockedCols));

            for (int col = 0; col < n; col++)
            {
                if (IsSafe(row, col))
                {
                    blockedCols.Add(col);
                    blockedUpDiags.Add(row + col);
                    blockedDownDiags.Add(row - col);

                    RecurseAndBackTrack(output, row + 1, n);

                    blockedCols.Remove(col);
                    blockedUpDiags.Remove(row + col);
                    blockedDownDiags.Remove(row - col);
                }
            }
        }

        private bool IsSafe(int row, int col)
        {
            if (blockedCols.Contains(col))
                return false;
            if (blockedUpDiags.Contains(row + col))
                return false;
            if (blockedDownDiags.Contains(row - col))
                return false;

            return true;

        }
    }
}
