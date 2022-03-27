using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class CanVisitAllRoomsLC841
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            Queue<int> keysQ = new Queue<int>();
            HashSet<int> visitedRooms = new HashSet<int>();
            HashSet<int> usedKeys = new HashSet<int>();

            visitedRooms.Add(0);
            foreach (var item in rooms[0])
            {
                keysQ.Enqueue(item);
            }

            while (keysQ.Count > 0)
            {
                int key = keysQ.Dequeue();
                if (!usedKeys.Contains(key))
                {
                    usedKeys.Add(key);
                    visitedRooms.Add(key);
                    foreach (var item in rooms[key])
                    {
                        keysQ.Enqueue(item);
                    }
                }
            }

            return visitedRooms.Count == rooms.Count;
        }
    }
}
