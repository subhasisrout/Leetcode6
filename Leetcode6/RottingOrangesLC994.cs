using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //difference between jagged array and 2d array.
    // jagged array in .NET is int[][]. Array of array. Each array (inside the "master array") can be of differnet length
    //2d array (rectangular) in .NET is int[,]

    //#MultiSourceBFS - You capture the length of queue and (remove everything + add neighbours) in ONE cycle.
    public class RottingOrangesLC994
    {
        public int OrangesRotting(int[][] grid)
        {
            HashSet<string> rottenOranges = new HashSet<string>();
            HashSet<string> freshOranges = new HashSet<string>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2)
                        rottenOranges.Add(i + "," + j);
                    if (grid[i][j] == 1)
                        freshOranges.Add(i + "," + j);
                }

            }

            int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

            HashSet<string> infectedOranges = null;
            int minutes = 0;
            while (freshOranges.Count > 0)
            {
                infectedOranges = new HashSet<string>();
                foreach (var rottenOrange in rottenOranges)
                {
                    int i = Convert.ToInt32(rottenOrange.Split(new string[] { "," },StringSplitOptions.RemoveEmptyEntries)[0]);
                    int j = Convert.ToInt32(rottenOrange.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1]);

                    for (int u = 0; u <= directions.GetUpperBound(0); u++)
                    {
                        int newI = i + directions[u, 0];
                        int newJ = j + directions[u, 1];

                        if (freshOranges.Contains(newI + "," + newJ))
                        {
                            infectedOranges.Add(newI + "," + newJ);
                            freshOranges.Remove(newI + "," + newJ);
                        }
                    }                    
                }

                if (infectedOranges.Count == 0)
                    return -1;

                minutes++;
                rottenOranges = infectedOranges;
            }
            return minutes;
        }

        // From NeetCode
        // MultiSource #BFS #Intuitive
        public int OrangesRotting2(int[][] grid)
        {
            int freshOrangeCount = 0;
            Queue<int[]> rottenOrangeQueue = new Queue<int[]>(); //row,col
            int minutes = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        rottenOrangeQueue.Enqueue(new int[] { i, j });
                    }
                    else if (grid[i][j] == 1)
                    {
                        freshOrangeCount++;
                    }
                }
            }
            while (rottenOrangeQueue.Count > 0 && freshOrangeCount > 0)
            {
                //Do multi source BFS
                int len = rottenOrangeQueue.Count; //for each minute, pop all the rotten oranges
                for (int i = 0; i < len; i++)
                {
                    var poppedOrangeLoc = rottenOrangeQueue.Dequeue();
                    var neighborOrangesLoc = new int[][]{
                        new int[] {poppedOrangeLoc[0]-1, poppedOrangeLoc[1]},
                        new int[] {poppedOrangeLoc[0]+1, poppedOrangeLoc[1]},
                        new int[] {poppedOrangeLoc[0], poppedOrangeLoc[1]-1},
                        new int[] {poppedOrangeLoc[0], poppedOrangeLoc[1]+1},
                        };
                    for (int k = 0; k < neighborOrangesLoc.Length; k++)
                    {
                        var neighbourLoc = neighborOrangesLoc[k];
                        if (!IsOutOfBound(neighbourLoc, grid) && grid[neighbourLoc[0]][neighbourLoc[1]] == 1)
                        {
                            grid[neighbourLoc[0]][neighbourLoc[1]] = 2;
                            rottenOrangeQueue.Enqueue(neighbourLoc);
                            freshOrangeCount--;
                        }
                    }
                }
                minutes++;
            }

            if (freshOrangeCount == 0)
                return minutes;
            else
                return -1;
        }
        private bool IsOutOfBound(int[] loc, int[][] grid)
        {
            int row = loc[0];
            int col = loc[1];
            if (row < 0 || row >= grid.Length || col < 0 || col >= grid[row].Length)
                return true;
            return false;
        }
    }
}
