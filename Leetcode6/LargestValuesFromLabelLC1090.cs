using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LargestValuesFromLabelLC1090
    {
        public int LargestValsFromLabels(int[] values, int[] labels, int num_wanted, int use_limit)
        {
            List<ValueLabel> list = new List<ValueLabel>();
            for (int i = 0; i < values.Length; i++)
            {
                list.Add(new ValueLabel() { Val = values[i], Label = labels[i] });
            }
            list.Sort((vl1, vl2) => vl2.Val.CompareTo(vl1.Val));

            Dictionary<int, int> labelCount = new Dictionary<int, int>();

            int result = 0;
            int numAdded = 0;

            for (int i = 0; i < list.Count(); i++)
            {
                if (numAdded >= num_wanted)
                    break;
                int currentVal = list[i].Val;
                int currentLabel = list[i].Label;

                if (labelCount.ContainsKey(currentLabel))
                {
                    if (labelCount[currentLabel] < use_limit)
                    {
                        labelCount[currentLabel] = labelCount[currentLabel] + 1;
                        result += currentVal;
                        numAdded++;
                    }
                }
                else
                {
                    labelCount.Add(currentLabel, 1);
                    result += currentVal;
                    numAdded++;
                }
            }
            return result;
        }
    }

    class ValueLabel
    {
        public int Val { get; set; }
        public int Label { get; set; }
    }
}
