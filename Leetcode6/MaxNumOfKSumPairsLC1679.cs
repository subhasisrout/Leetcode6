namespace Leetcode6
{
    public class MaxNumOfKSumPairsLC1679
    {
        public int MaxOperations(int[] nums, int k)
        {
            // Explaination in 1 line - Add each num OR absorb it its counterPart is found with freq > 0
            int result = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(k - nums[i]) && map[k - nums[i]] > 0)
                { //ABSORB (as counterPart is found with > 0)
                    result++;
                    map[k - nums[i]] = map[k - nums[i]] - 1;
                }
                else
                { //ADD
                    if (!map.ContainsKey(nums[i]))
                        map.Add(nums[i], 1);
                    else
                        map[nums[i]] = map[nums[i]] + 1;
                }
            }
            return result;


            // 2 pointer
            /*Array.Sort(nums);
            int i=0;
            int j=nums.Length - 1;
            int result = 0;
            while (i < j){
                if (nums[i] + nums[j] == k){
                    result ++;
                    i++;
                    j--;
                } else if (nums[i] + nums[j] > k){
                    j--;
                } else {
                    i++;
                }
            }
            return result;*/

        }
    }
}
