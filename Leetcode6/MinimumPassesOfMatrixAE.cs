using System;
using System.Collections.Generic;

// #BFS
// #RememberPattern

namespace Leetcode
{
    public class MinimumPassesOfMatrixAE
    {
        public int MinimumPassesOfMatrix(int[][] matrix)
        {
            int numOfPasses = BFS(matrix);
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] < 0)
                        return -1;
                }
            }
            return numOfPasses;
        }

        private int BFS(int[][] matrix)
        {
            int numOfPasses = 0;
            Queue<Tuple<int, int>> q1 = new Queue<Tuple<int, int>>();
            Queue<Tuple<int, int>> q2 = new Queue<Tuple<int, int>>();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] > 0)
                    {
                        q1.Enqueue(new Tuple<int, int>(i, j));
                    }
                }
            }
            while (true)
            {
                if (q1.Count == 0)
                    break;
                while (q1.Count > 0)
                {
                    Tuple<int, int> posNumpos = q1.Dequeue();
                    int i = posNumpos.Item1;
                    int j = posNumpos.Item2;
                    if (!OutOfBounds(i - 1, j, matrix) && matrix[i - 1][j] < 0)
                    {
                        matrix[i - 1][j] = matrix[i - 1][j] * -1;
                        q2.Enqueue(new Tuple<int, int>(i - 1, j));
                    }
                    if (!OutOfBounds(i + 1, j, matrix) && matrix[i + 1][j] < 0)
                    {
                        matrix[i + 1][j] = matrix[i + 1][j] * -1;
                        q2.Enqueue(new Tuple<int, int>(i + 1, j));
                    }
                    if (!OutOfBounds(i, j - 1, matrix) && matrix[i][j - 1] < 0)
                    {
                        matrix[i][j - 1] = matrix[i][j - 1] * -1;
                        q2.Enqueue(new Tuple<int, int>(i, j - 1));
                    }
                    if (!OutOfBounds(i, j + 1, matrix) && matrix[i][j + 1] < 0)
                    {
                        matrix[i][j + 1] = matrix[i][j + 1] * -1;
                        q2.Enqueue(new Tuple<int, int>(i, j + 1));
                    }
                }
                q1 = new Queue<Tuple<int, int>>(q2);
                q2.Clear();
                if (q1.Count > 0)
                    numOfPasses++;
            }

            return numOfPasses;
        }

        private bool OutOfBounds(int i, int j, int[][] matrix)
        {
            if (i < 0 || i >= matrix.Length || j < 0 || j >= matrix[0].Length)
                return true;
            return false;
        }
    }
}
