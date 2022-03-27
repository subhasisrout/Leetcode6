using System.Collections.Generic;

// Use this (2 graphs - 1 for prereqs and 1 for dependencies (create dependencies)) for mindmap instead of LC210

namespace Leetcode
{
    public class CourseScheduleLC207
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // Graph ADJ LIST pattern START
            Dictionary<int, List<int>> graphPrereq = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> graphDeps = new Dictionary<int, List<int>>();
            for (int i = 0; i < numCourses; i++)
            {
                graphPrereq.Add(i, new List<int>());
                graphDeps.Add(i, new List<int>());
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                var curr = prerequisites[i];
                graphPrereq[curr[0]].Add(curr[1]); //[0,1]-- To complete course 0, you have complete course 1.
                graphDeps[curr[1]].Add(curr[0]);   //[0,1]-- course 1 is like a 'dependency' for course 0.
            }
            // Graph ADJ LIST pattern END

            return TopologicallySortedList(graphPrereq, graphDeps).Count == numCourses;
        }

        private List<int> TopologicallySortedList(Dictionary<int, List<int>> graphPrereq, Dictionary<int, List<int>> graphDeps)
        {
            List<int> topologicallySortedList = new List<int>();
            Queue<int> coursesWithoutDependencies = new Queue<int>();
            foreach (var item in graphPrereq)
            {
                if (item.Value.Count == 0)
                    coursesWithoutDependencies.Enqueue(item.Key);
            }

            while (coursesWithoutDependencies.Count > 0)
            {
                var currCourse = coursesWithoutDependencies.Dequeue();
                topologicallySortedList.Add(currCourse);

                var deps = graphDeps[currCourse];
                foreach (var dep in deps)
                {
                    graphPrereq[dep].Remove(currCourse);
                    if (graphPrereq[dep].Count == 0)
                        coursesWithoutDependencies.Enqueue(dep);
                }

            }
            return topologicallySortedList;
        }
    }
}
