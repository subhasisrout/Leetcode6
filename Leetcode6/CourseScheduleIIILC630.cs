// #Greedy. Looks like most greedy problems need a #PriorityQueue .
// Also remember how to use a Custom PriorityComparer
// This approach is shared by almost everyone. However this has good visuals - https://www.youtube.com/watch?v=ey8FxYsFAMU
namespace Leetcode6
{
    public class CourseScheduleIIILC630
    {
        public int ScheduleCourse(int[][] courses)
        {
            // Intuition as you would want to takeup the courses first which ends soon.
            Array.Sort(courses, (a, b) => a[1].CompareTo(b[1]));
            PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(new PriorityComparer());
            int totalTime = 0;
            for (int i = 0; i < courses.Length; i++)
            {
                var course = courses[i];
                var dur = course[0];
                var time = course[1];
                maxHeap.Enqueue(dur, dur);
                totalTime += dur;
                if (totalTime > time)
                {
                    var longestDuration = maxHeap.Dequeue(); //#Greedy
                    totalTime -= longestDuration;
                }
            }
            return maxHeap.Count;
        }

        class PriorityComparer : IComparer<int>
        {
            public int Compare(int p1, int p2)
            {
                return p2.CompareTo(p1);
            }
        }
    }
}
