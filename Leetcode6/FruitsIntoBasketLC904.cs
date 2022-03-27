using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class FruitsIntoBasketLC904
    {
        public int TotalFruit(int[] tree)
        {
            HashSet<int> distinctTypes = new HashSet<int>();
            for (int i = 0; i < tree.Length; i++)
            {
                distinctTypes.Add(tree[i]);
                if (distinctTypes.Count > 3)
                    break;
            }

            if (distinctTypes.Count <= 2)
                return tree.Count();

            int count = 1;
            for (int i = 0; i <= tree.Length - 2; i++)
            {
                if (i != 0 && tree[i] == tree[i - 1])
                    continue;
                count = Math.Max(count, PickFromIthPosition(tree, i));
            }


            return count;

        }

        private int PickFromIthPosition(int[] tree, int i)
        {
            HashSet<int> fruitTypes = new HashSet<int>();
            int counter = 0;
            bool extraFruitAdded = false;
            while (i < tree.Length)
            {
                fruitTypes.Add(tree[i]);
                counter++;
                if (fruitTypes.Count >= 3)
                {
                    extraFruitAdded = true;
                    break;
                }
                i++;
            }
            if (extraFruitAdded)
                return counter - 1;
            else
                return counter;
        }
    }
}
