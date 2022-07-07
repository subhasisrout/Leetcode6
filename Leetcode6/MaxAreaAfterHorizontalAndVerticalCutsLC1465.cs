// #modulo #long works. #double does not work
// #greedy

namespace Leetcode6
{
    public class MaxAreaAfterHorizontalAndVerticalCutsLC1465
    {
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            List<int> horizontalList = horizontalCuts.ToList();
            horizontalList.Add(0);
            horizontalList.Add(h);
            horizontalList.Sort();

            List<int> verticalList = verticalCuts.ToList();
            verticalList.Add(0);
            verticalList.Add(w);
            verticalList.Sort();

            long maxDiffH = 1;
            for (int i = 1; i < horizontalList.Count; i++)
            {
                maxDiffH = Math.Max(maxDiffH, horizontalList[i] - horizontalList[i - 1]);
            }

            long maxDiffV = 1;
            for (int i = 1; i < verticalList.Count; i++)
            {
                maxDiffV = Math.Max(maxDiffV, verticalList[i] - verticalList[i - 1]);
            }

            long result = maxDiffH * maxDiffV;
            return Convert.ToInt32(result % 1000000007);
        }
    }
}
