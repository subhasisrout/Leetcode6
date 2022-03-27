// #Not Found in Leetcode
// Read through my code.



namespace Leetcode
{
    public class SortKSortedArrayAE
    {
        public int[] SortKSortedArray(int[] array, int k)
        {
            if (k == 0) return array;
            int i = 0;
            int j = k;
            int pos = 0;
            MinHeap minHeap = new MinHeap(k);

            //First time only
            for (int idx = 0; idx < j; idx++)
            {
                if (idx == array.Length)
                    break;
                minHeap.Insert(array[idx]);
            }

            while (j < array.Length)
            {
                minHeap.Insert(array[j]);
                int minNum = minHeap.Remove();
                int minNumIdx = -1;
                for (int idx = i; idx <= j; idx++)
                {
                    if (array[idx] == minNum)
                    {
                        minNumIdx = idx;
                        break;
                    }
                }
                if (minNumIdx != pos)
                    Swap(array, minNumIdx, pos);
                pos++;
                i++;
                j++;
            }

            // j (second pointer is out-to-bounds. Just need to arrange the left-over elements in the heap)
            while (minHeap.Size != 0)
            {
                int minNum = minHeap.Remove();
                int minNumIdx = -1;
                for (int idx = i; idx < array.Length; idx++)
                {
                    if (array[idx] == minNum)
                    {
                        minNumIdx = idx;
                        break;
                    }
                }
                if (minNumIdx != pos)
                    Swap(array, minNumIdx, pos);
                i++;
                pos++;
            }
            return array;
        }

        private void Swap(int[] arr, int index1, int index2)
        {
            int tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }
    }
}
