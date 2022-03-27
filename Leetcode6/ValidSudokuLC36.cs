using System.Collections.Generic;

// #TopInterviewQues

namespace Leetcode
{
    public class ValidSudokuLC36
    {
        public bool IsValidSudoku(char[][] board)
        {
            HashSet<string> seen = new HashSet<string>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char curr = board[i][j];
                    if (curr != '.')
                    {
                        if (!(seen.Add(curr + " in row " + i))
                            || !(seen.Add(curr + " in col " + j))
                            || !(seen.Add(curr + " in row,col " + i / 3 + j / 3)))
                            return false;
                    }
                }
            }
            return true;

        }
    }
}
// for the second example in leetcode: 2/3 = 0, 2/3 = 0 
// 8 in row,col 00
// 8 in row,col 00 