// Inspired from votrubac comment - https://leetcode.com/problems/check-if-there-is-a-valid-parentheses-string-path/discuss/2017740/DFS
// #DFS #TopDown #DP #Memoization
// At any time, if balance is -ve, return false
// At any time, if balance is +ve  >= (m+n)/2, return false, as we cannot cancel those braces.

namespace Leetcode6
{
    public class CheckIfThereIsAValidParenthesesStringPathLC2267
    {
        public bool HasValidPath(char[][] grid)
        {
            bool[,,] visited = new bool[100, 100, 101]; //Memo for (i,j,balance) combination
            int m = grid.Length;
            int n = grid[0].Length;
            return DFS(0, 0, 0);

            bool DFS(int i, int j, int bal)
            {
                if (bal < 0 || bal > (m + n) / 2 || visited[i, j, bal] == true)
                    return false;
                visited[i, j, bal] = true;

                bal += (grid[i][j] == '(') ? 1 : -1;


                if (bal == 0 && i == m - 1 && j == n - 1)
                    return true;
                if (i < m - 1 && DFS(i + 1, j, bal))
                    return true;
                if (j < n - 1 && DFS(i, j + 1, bal))
                    return true;

                return false;
            }

        }
    }
}
