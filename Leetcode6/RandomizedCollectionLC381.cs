// To understand the comment "not the last entry, but the MAX value."
// Dry Run [1,1,2,2,2]. Remove(1) Remove(1). and check state.

namespace Leetcode
{
    public class RandomizedCollectionLC381
    {
        Dictionary<int, SortedSet<int>> map = null;
        List<int> list = null;

        public RandomizedCollectionLC381()
        {
            map = new Dictionary<int, SortedSet<int>>();
            list = new List<int>();
        }

        public bool Insert(int val)
        {
            bool isPresent = map.ContainsKey(val);
            if (!isPresent)
                map.Add(val, new SortedSet<int>());

            map[val].Add(list.Count);
            list.Add(val);
            return !isPresent;
        }

        public bool Remove(int val)
        {
            bool isPresent = map.ContainsKey(val);
            if (!isPresent) return false;

            //set variables
            var valIndicesSet = map[val];
            var collectionLastVal = list[list.Count - 1];
            var valMaxIdx = valIndicesSet.Max; //not the last entry, but the MAX value.
            var collectionLastValIndicesSet = map[collectionLastVal];

            //map updated
            collectionLastValIndicesSet.Remove(collectionLastValIndicesSet.Max); //not the last entry, but the MAX value.
            collectionLastValIndicesSet.Add(valMaxIdx);
            valIndicesSet.Remove(valIndicesSet.Max);
            if (valIndicesSet.Count == 0)
                map.Remove(val);

            //list updated
            list[valMaxIdx] = collectionLastVal;
            list.RemoveAt(list.Count - 1);

            return true;
        }

        public int GetRandom()
        {
            return list[new Random().Next(0, list.Count)];
        }
    }

    /**
     * Your RandomizedCollection object will be instantiated and called as such:
     * RandomizedCollection obj = new RandomizedCollection();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}
