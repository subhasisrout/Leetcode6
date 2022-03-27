// #Graph algorithm, #Graph implemented using class structure (OOPS)
// Refer TopologicalSortAE.jpg for a picture. The PreReqCount of 1 and 4 would be 0.
// "1" and "4" nodes .Deps property will have nodes "2" and "3" because 
// "1" and "4" have created a dependency on "2" and "3".


// #Leetcode #LC210 (except the dependency order is opposite) and LC207

// DO NOT USE FOR MINDMAP.
// Instead use CourseScheduleLC207 (2 graphs - 1 for prereqs and 1 for dependencies (create dependencies))


using System.Collections.Generic;

namespace Leetcode2
{
    public class CourseScheduleLC210
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            JobGraph jobGraph = CreateJobGraphWithDependencies(numCourses, prerequisites);
            return TopologicallySortedList(jobGraph);
        }

        private static int[] TopologicallySortedList(JobGraph jobGraph)
        {
            List<int> topologicallySortedList = new List<int>();
            Queue<JobNode> nodesWithNoPreReqs = new Queue<JobNode>();
            foreach (var node in jobGraph.Nodes)
            {
                if (node.PreReqCount == 0)
                    nodesWithNoPreReqs.Enqueue(node);
            }

            while (nodesWithNoPreReqs.Count != 0)
            {
                var node = nodesWithNoPreReqs.Dequeue();
                topologicallySortedList.Add(node.Job);
                
                //Start Below Block updates .Deps property and updates PreReqCount of each dep
                var deps = node.Deps;
                foreach (var dep in deps)
                {
                    dep.PreReqCount--;
                    if (dep.PreReqCount == 0)
                        nodesWithNoPreReqs.Enqueue(dep);
                }
                node.Deps = new List<JobNode>();
                //End
            }

            if (topologicallySortedList.Count != jobGraph.Nodes.Count)
                return new int[] { };
            return topologicallySortedList.ToArray();
        }

        private static JobGraph CreateJobGraphWithDependencies(int numCourses, int[][] deps)
        {
            JobGraph jobGraph = new JobGraph(numCourses);
            foreach (var dep in deps)
            {
                jobGraph.AddDep(dep[1], dep[0]);

            }
            return jobGraph;
        }
    }

    public class JobGraph
    {
        // Below 2 properties will be needed for the Graph. Just remember it.
        public List<JobNode> Nodes { get; set; }
        public Dictionary<int, JobNode> Graph { get; set; }

        public JobGraph(int numCourses)
        {
            this.Nodes = new List<JobNode>();
            this.Graph = new Dictionary<int, JobNode>();

            for (int i = 0; i < numCourses; i++)
            {
                this.AddNode(i);
            }
        }

        //[0,2]... 2 is dependent on 0.
        // 0 must run first then 2 can run.
        // 0 has created a dependency on other jobs, one of them being 2.
        public void AddDep(int preReqJobId, int dependentJobId)
        {
            var preReqJob = this.Graph[preReqJobId];
            var dependentJob = this.Graph[dependentJobId];
            dependentJob.PreReqCount += 1;
            preReqJob.Deps.Add(dependentJob);

        }

        private void AddNode(int job)
        {
            this.Graph.Add(job, new JobNode(job));
            this.Nodes.Add(this.Graph[job]);            
        }

    }

    public class JobNode
    {
        public int Job { get; set; }
        public int PreReqCount { get; set; }

        // Dependencies that this node has created on others
        // Kind of opposite of prerequisites
        public List<JobNode> Deps { get; set; }

        public JobNode(int job)
        {
            this.Job = job;
            this.PreReqCount = 0;
            this.Deps = new List<JobNode>();
        }

    }
}
