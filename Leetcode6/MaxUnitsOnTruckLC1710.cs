using System.Collections.Generic;


// #KeyValuePair list sorting
// Although this will also do - Array.Sort(boxTypes, (left, right) => right[1] - left[1]);
namespace Leetcode
{
    public class MaxUnitsOnTruckLC1710
    {
        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            List<KeyValuePair<int, int>> keyValuePairs = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < boxTypes.Length; i++)
            {
                keyValuePairs.Add(new KeyValuePair<int, int>(boxTypes[i][0], boxTypes[i][1]));
            }
            keyValuePairs.Sort(new MyKeyValueComparer1());
            int result = 0;
            int currentBoxes = 0;
            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                result += (keyValuePairs[i].Value * keyValuePairs[i].Key);
                currentBoxes += keyValuePairs[i].Key;
                if (currentBoxes > truckSize)
                {
                    // remove from result and break;
                    int unitsToBeRemoved = (currentBoxes - truckSize) * keyValuePairs[i].Value;
                    result -= unitsToBeRemoved;
                    break;
                }
            }
            return result;


        }
    }
    //Sorts descending by value. Thats y.CompareTo(x)
    public class MyKeyValueComparer1 : IComparer<KeyValuePair<int, int>>
    {
        public int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
        {
            return y.Value.CompareTo(x.Value);
        }
    }
}
