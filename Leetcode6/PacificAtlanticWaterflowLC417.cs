using System.Collections.Generic;

// #Graph #Matrix
// Thought its a DP problem, turned out to be Graph BFS/DFS problem
// Taken the BFS idea from https://leetcode.com/problems/pacific-atlantic-water-flow/discuss/90733/Java-BFS-and-DFS-from-Ocean


namespace Leetcode
{
    public class PacificAtlanticWaterflowLC417
    {
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int N = heights.Length;
            int M = heights[0].Length;
            Queue<int[]> pacificQ = new Queue<int[]>();
            Queue<int[]> atlanticQ = new Queue<int[]>();
            bool[,] pacificCells = new bool[N, M];
            bool[,] atlanticCells = new bool[N, M];

            for (int j = 0; j < M; j++)
            {
                pacificQ.Enqueue(new int[] { 0, j });
                pacificCells[0, j] = true;

                atlanticQ.Enqueue(new int[] { N - 1, j });
                atlanticCells[N - 1, j] = true;
            }

            for (int i = 0; i < N; i++)
            {
                pacificQ.Enqueue(new int[] { i, 0 });
                pacificCells[i, 0] = true;

                atlanticQ.Enqueue(new int[] { i, M - 1 });
                atlanticCells[i, M - 1] = true;
            }

            BFS(heights, pacificQ, pacificCells);
            BFS(heights, atlanticQ, atlanticCells);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (pacificCells[i, j] && atlanticCells[i, j])
                        result.Add(new List<int>() { i, j });
                }
            }
            return result;
        }

        private void BFS(int[][] heights, Queue<int[]> q, bool[,] visited)
        {
            while (q.Count > 0)
            {
                int[] cell = q.Dequeue();
                visited[cell[0], cell[1]] = true;

                List<int[]> cellNeighbours = GetNeighbours(cell);
                foreach (var neighbour in cellNeighbours)
                {
                    if (IsInRange(neighbour, heights) && !visited[neighbour[0], neighbour[1]] && CanWaterFlowFromNeighbourToCell(neighbour, cell, heights))
                    {
                        q.Enqueue(new int[] { neighbour[0], neighbour[1] });
                    }
                }
            }
        }

        private bool CanWaterFlowFromNeighbourToCell(int[] neighbour, int[] cell, int[][] heights)
        {
            return heights[neighbour[0]][neighbour[1]] >= heights[cell[0]][cell[1]];
        }

        private bool IsInRange(int[] neighbour, int[][] heights)
        {
            var invalid = neighbour[0] < 0 || neighbour[0] >= heights.Length
                || neighbour[1] < 0 || neighbour[1] >= heights[0].Length;
            return !invalid;
        }

        private List<int[]> GetNeighbours(int[] cell)
        {
            return new List<int[]>()
            {
                new int[] {cell[0]+1,cell[1]},
                new int[] {cell[0],cell[1]+1},
                new int[] {cell[0]-1,cell[1]},
                new int[] {cell[0],cell[1]-1}
            };
        }
    }
}
