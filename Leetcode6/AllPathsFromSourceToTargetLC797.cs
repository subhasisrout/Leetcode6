using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #Graph #BackTrack

namespace Leetcode
{
    public class AllPathsFromSourceToTargetLC797
    {
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            // Creation of dictionary adjList is not needed as its exactly given in that format
            //Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            //for (int i = 0; i < graph.Length; i++)
            //    adjList.Add(i, new List<int>());

            //for (int i = 0; i < graph.Length; i++)
            //{
            //    for (int j = 0; j < graph[i].Length; j++)
            //    {
            //        adjList[i].Add(graph[i][j]);
            //    }

            //}


            IList<IList<int>> result = new List<IList<int>>();
            List<int> currPath = new List<int>();
            currPath.Add(0);
            DFSAndBackTrack(graph, result, currPath, 0);
            return result;

        }

        private void DFSAndBackTrack(int[][] adjList, IList<IList<int>> result, List<int> currPath, int currNode)
        {
            if (currNode == adjList.Length - 1)
            {
                result.Add(new List<int>(currPath));
                return;
            }

            var neighbours = adjList[currNode];
            foreach (var neighbour in neighbours)
            {
                currPath.Add(neighbour);
                DFSAndBackTrack(adjList, result, currPath, neighbour);
                currPath.RemoveAt(currPath.Count - 1);
            }
        }
    }
}
