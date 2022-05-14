namespace Leetcode6
{
    public class CombinationSumIIILC216
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> result = new List<IList<int>>();
            DFSAndBackTrack(new List<int>(), n, 1);
            return result;


            void DFSAndBackTrack(IList<int> curr, int currSum, int idx)
            {
                if (currSum < 0 || curr.Count > k)
                    return;
                if (currSum == 0 && curr.Count == k)
                {
                    result.Add(new List<int>(curr));
                    return;
                }

                for (int i = idx; i <= 9; i++)
                {
                    curr.Add(i);
                    DFSAndBackTrack(curr, currSum - i, i + 1);
                    curr.RemoveAt(curr.Count - 1);
                }
            }
        }
    }
}
