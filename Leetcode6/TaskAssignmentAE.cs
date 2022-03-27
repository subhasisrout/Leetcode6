using System.Collections.Generic;

// My solution is better than AE solution
// Using queue is more elegant than using a List

namespace Leetcode
{
    public class TaskAssignmentAE
    {
		public List<List<int>> TaskAssignment(int k, List<int> tasks)
		{
			List<List<int>> result = new List<List<int>>();
			Dictionary<int, Queue<int>> map = new Dictionary<int, Queue<int>>();
			for (int x = 0; x < tasks.Count; x++)
			{
				if (map.ContainsKey(tasks[x]))
					map[tasks[x]].Enqueue(x);
				else
				{
					Queue<int> q1 = new Queue<int>();
					q1.Enqueue(x);
					map.Add(tasks[x], q1);
				}
			}
			tasks.Sort();
			int i = 0;
			int j = tasks.Count - 1;
			while (i < j)
			{
				int posI = map[tasks[i]].Dequeue();
				int posJ = map[tasks[j]].Dequeue();
				result.Add(new List<int> { posI, posJ });
				i++;
				j--;
			}
			return result;
		}
	}
}
