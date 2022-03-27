using System.Collections.Generic;
using System.Linq;

namespace Leetcode3
{
    public class MergeKSortedArraysAE
    {
        public static List<int> MergeSortedArrays(List<List<int>> arrays)
        {
			List<int> indices = new List<int>();
            for (int i = 0; i < arrays.Count(); i++)
            {
				indices.Add(0);
            }
			List<int> kSizedBatch = new List<int>();
			List<int> result = new List<int>();
			MinHeap heap = null;

			while (true)
            {
				List<int[]> heapInput = new List<int[]>();
				for (int i = 0; i < arrays.Count; i++)
                {
					List<int> currList = arrays[i];
					int currIdx = indices[i];
					if (currIdx == currList.Count)
						continue;
					else
                    {
						kSizedBatch.Add(currList[currIdx]);
						heapInput.Add(new int[] { currList[currIdx], i });
                    }
                }
				if (heapInput.Count == 0)
					break;

				heap = new MinHeap(heapInput);

				var numAndIdx = heap.Remove();
				result.Add(numAndIdx[0]);
				var idx = numAndIdx[1];
				indices[idx] += 1;
			}
			while (!heap.IsEmpty()) // for the leftover batch (last batch)
				result.Add(heap.Remove()[0]);

			return result;

        }
    }

	public class MinHeap
	{
		public List<int[]> heap = new List<int[]>();
		public MinHeap(List<int[]> array)
		{
			heap = buildHeap(array);
		}

		public List<int[]> buildHeap(List<int[]> array)
		{
			// Below code also works but is inefficient
			/*
            foreach (var item in array)
            {
				this.Insert(item);
            }
			return heap;*/

			int firstParentIndex = (array.Count - 2) / 2;
			for (int i = firstParentIndex; i >= 0; i--)
			{
				siftDown(i, array.Count - 1, array);
			}
			return array;
		}

		public void siftDown(int currentIdx, int endIdx, List<int[]> heap)
		{
			int leftChildIdx = 2 * currentIdx + 1;
			while (leftChildIdx <= endIdx)
			{
				int rightChildIdx = 2 * currentIdx + 2;
				int smallerChildIdx = leftChildIdx;
				if (rightChildIdx <= endIdx && heap.ElementAt(rightChildIdx)[0] < heap.ElementAt(leftChildIdx)[0])
					smallerChildIdx = rightChildIdx;

				if (heap.ElementAt(currentIdx)[0] > heap.ElementAt(smallerChildIdx)[0])
				{
					SwapNumbersAtIndex(currentIdx, smallerChildIdx, heap);
					currentIdx = smallerChildIdx;
					leftChildIdx = 2 * currentIdx + 1;
				}
				else
					break;

			}
		}

		public void siftUp(int currentIdx, List<int[]> heap)
		{
			while (currentIdx > 0 && heap.ElementAt((currentIdx - 1) / 2)[0] > heap.ElementAt(currentIdx)[0])
			{
				SwapNumbersAtIndex(currentIdx, (currentIdx - 1) / 2, heap);
				currentIdx = (currentIdx - 1) / 2;
			}
		}

		public int Peek()
		{
			return heap.ElementAt(0)[0];
		}

		public int[] Remove()
		{
			var elementToRemove = heap.ElementAt(0);
			SwapNumbersAtIndex(0, heap.Count - 1, heap);
			heap.RemoveAt(heap.Count - 1);
			siftDown(0, heap.Count - 1, heap);
			return elementToRemove;
		}

		public bool IsEmpty()
        {
			return heap.Count == 0;
        }

		public void Insert(int[] value)
		{
			heap.Add(value);
			siftUp(heap.Count - 1, heap);
		}

		private void SwapNumbersAtIndex(int i1, int i2, List<int[]> heap)
		{
			int[] tmp = heap[i1];
			heap[i1] = heap[i2];
			heap[i2] = tmp;
		}
	}


}
