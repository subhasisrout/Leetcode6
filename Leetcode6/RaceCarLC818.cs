// #Hard #Google #BFS #LevelOrderTraversal
// Note its NOT JUST level order. Since there is also 'reverse'.
// 2 extra thing added to level order - 1) seen set 2) boundary condition of 0 <= pos < 2*target
// #Inspired from youtube videos / multiple places
namespace Leetcode6
{
    public class RaceCarLC818
    {
        public int Racecar(int target)
        {
            Queue<(int, int)> q = new Queue<(int, int)>();
            q.Enqueue((0, 1));
            HashSet<(int, int)> seen = new HashSet<(int, int)>();
            int level = 0;
            while (q.Count > 0)
            {
                int size = q.Count;
                while (size > 0) // for Level-order traversal (BFS)
                {
                    var currItem = q.Dequeue();
                    var currPos = currItem.Item1;
                    var currSpeed = currItem.Item2;

                    if (currPos == target)
                        return level;

                    //A
                    int nextPos = currPos + currSpeed;
                    if (nextPos >= 0 && nextPos < 2 * target && !seen.Contains((nextPos, currSpeed * 2)))
                    {
                        q.Enqueue((nextPos, currSpeed * 2));
                        seen.Add((nextPos, currSpeed * 2));
                    }

                    //R
                    nextPos = currPos;
                    int nextSpeed = currSpeed > 0 ? -1 : 1;
                    if (nextPos >= 0 && nextPos < 2 * target && !seen.Contains((nextPos, nextSpeed)))
                    {
                        q.Enqueue((nextPos, nextSpeed));
                        seen.Add((nextPos, nextSpeed));
                    }

                    size--;
                }
                level++;
            }
            return -1;
        }
    }
}
