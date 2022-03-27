using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class NQueensIILC52
    {
        HashSet<int> blockedCols = new HashSet<int>();
        HashSet<int> blockedUpDiags = new HashSet<int>();
        HashSet<int> blockedDownDiags = new HashSet<int>();
        public int TotalNQueens(int n)
        {
            IList<IList<int>> output = new List<IList<int>>();
            RecurseAndBackTrack(output, 0, n);
            return output.Count;
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
