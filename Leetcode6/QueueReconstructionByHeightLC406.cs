// Inspired from https://leetcode.com/problems/queue-reconstruction-by-height/discuss/89359/Explanation-of-the-neat-Sort+Insert-solution/94017

// Start by the thought of - all people having equal height [7,0] [7,1] [7,2] [7,3]
// In that case 'k' value is the actual position of the person.

// Now add a person having height 6 in the mix. Where should you add him ? Ans - on his k value.
// To intuitively understand play with different values of k with person having height 6

// #List.Insert #Insert #LinkedListInsert

namespace Leetcode6
{
    public class QueueReconstructionByHeightLC406
    {
        public int[][] ReconstructQueue(int[][] people)
        {
            Array.Sort(people, new CustomComparer());
            List<int[]> result = new List<int[]>();
            for (int i = 0; i < people.Length; i++)
            {
                int k = people[i][1];
                result.Insert(k, people[i]);
            }
            return result.ToArray();
        }

        private class CustomComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                if (x[0] != y[0])
                    return y[0].CompareTo(x[0]); //decreasing height
                else
                    return x[1].CompareTo(y[1]); //incresing k value for same height
            }
        }
    }
}
