using System.Collections.Generic;
using System.Linq;

// On similar lines, check https://leetcode.com/problems/find-the-celebrity/ (leetcode premium)
// but problem and solution can be found here - https://www.youtube.com/watch?v=LZJBZEnoYLQ

// #Graph
// Below problem will help you learn adj List. Just learn the pattern of creating an adjList.
namespace Leetcode
{
    public class FindTheTownJudgeLC997
    {
        public int FindJudge(int n, int[][] trust)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            // create graph (adj list)
            for (int i = 1; i <= n; i++)
            {
                graph.Add(i, new List<int>());
            }
            for (int i = 0; i < trust.Length; i++)
            {
                var curr = trust[i];
                graph[curr[0]].Add(curr[1]);
            }

            HashSet<int> possibleJudgesSet = new HashSet<int>();
            foreach (var item in graph)
            {
                if (item.Value.Count == 0)
                    possibleJudgesSet.Add(item.Key);
            }

            if (possibleJudgesSet.Count != 1)
                return -1;


            //if you have reached here, there is a SINGLE judge candidate in judgeCandidates set.
            var judge = possibleJudgesSet.First();
            foreach (var item in graph)
            {
                if (item.Key != judge)
                {
                    if (!(item.Value.Contains(judge)))
                        return -1;

                }
            }

            return judge;

        }
    }
}
