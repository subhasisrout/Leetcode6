using System;
// Extremely intuitive explaination from #Neetcode https://www.youtube.com/watch?v=fei4bJQdBUQ

namespace Leetcode
{
    public class GameOfLifeLC289
    {
        public void GameOfLife(int[][] board)
        {
            //Original  New     State
            //  0       0       0
            //  1       0       1
            //  0       1       2
            //  1       1       3
            // Note above is similar to truth table, but not exactly truth-table as 10 is not 1 in binary and 01 is not 2 in binary
            // The above is just a way to represent state transitions with a way to go back to the "Original".

            int ROWS = board.Length;
            int COLS = board[0].Length;

            if (ROWS == 0 || COLS == 0)
                return;

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    int nei = GetNeighbours(i, j, board, ROWS, COLS);
                    if (board[i][j] == 1)
                    {
                        if (nei == 2 || nei == 3)
                            board[i][j] = 3; // if 1 stays 1, the state is 3. Check the table above.
                        // else it will die (become 0). if 1 becomes 0, the state is 1. So no code required.
                    }
                    else
                    {
                        if (nei == 3)
                            board[i][j] = 2; // if 0 becomes 1, the state is 2. Check the table above.
                        // else it will remain died (remain 0). if 0 becomes 0, the state is 0. So no code required.
                    }
                }
            }

            // we have the board with the state change captured. Modify it to reflect "new" according to the table above.
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (board[i][j] == 1)
                        board[i][j] = 0;
                    else if (board[i][j] == 2 || board[i][j] == 3)
                        board[i][j] = 1;
                }
            }
        }
        private int GetNeighbours(int i, int j, int[][] board, int ROWS, int COLS)
        {
            int nei = 0;
            for (int u = Math.Max(i - 1, 0); u <= Math.Min(i + 1, ROWS - 1); u++)
            {
                for (int v = Math.Max(j - 1, 0); v <= Math.Min(j + 1, COLS - 1); v++)
                {
                    if (i == u && j == v) continue; //the 2 for loops for neigh will include to cell itself. Need to exclude while calculating neigbours.
                    else if (board[u][v] == 1 || board[u][v] == 3) // original live cells are rep by 1 and 3. Check table.
                        nei++;
                }
            }
            return nei;
        }
    }
}
