// #RememberPattern
// #ingenious way to use list.RemoveAt(idx) in O(1) operation

namespace Leetcode
{
    public class RandomizedSet
    {
        Dictionary<int, int> map = null;
        List<int> list = null;

        public RandomizedSet()
        {
            map = new Dictionary<int, int>();
            list = new List<int>();
        }

        public bool Insert(int val)
        {
            if (map.ContainsKey(val))
                return false;
            map.Add(val, list.Count);
            list.Add(val);
            return true;
        }

        public bool Remove(int val)
        {
            if (!map.ContainsKey(val))
                return false;
            var idx = map[val]; //to be removed
            var lastval = list[list.Count - 1]; //remove and put in above pos.        

            // Below 2 lines update list and map
            list[idx] = lastval;
            map[lastval] = idx;

            // Below 2 lines does actual delete in list and map. NOTE - DO THE DELETE ACTIVITY IN THE END TO AVOID INDEX OUT OF BOUND EXCEPTION.
            map.Remove(val);
            list.RemoveAt(list.Count - 1); // clever way of deleting in list in O(1) time.
            return true;
        }

        public int GetRandom()
        {
            return list[new Random().Next(0, list.Count)];
        }
    }


    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}
