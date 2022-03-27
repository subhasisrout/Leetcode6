using System.Collections.Generic;
using System.Linq;

// #This just boils down to remembering "siftDown" or "heapifyDown" :)

namespace Leetcode2
{
	public class MinHeap
	{
		public List<int> heap = new List<int>();
		public MinHeap(List<int> array)
		{
			heap = buildHeap(array);
		}

		public List<int> buildHeap(List<int> array)
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
				siftDown(i, heap.Count - 1, heap);
            }
			return heap;
		}

		public void siftDown(int currentIdx, int endIdx, List<int> heap)
		{
			int leftChildIdx = 2 * currentIdx + 1;
			while (leftChildIdx <= endIdx)
            {
				int rightChildIdx = 2 * currentIdx + 2;
				int smallerChildIdx = leftChildIdx;
				if (rightChildIdx <= endIdx && heap.ElementAt(rightChildIdx) < heap.ElementAt(leftChildIdx))
					smallerChildIdx = rightChildIdx;

				if (heap.ElementAt(currentIdx) > heap.ElementAt(smallerChildIdx))
				{
					SwapNumbersAtIndex(currentIdx, smallerChildIdx);
					currentIdx = smallerChildIdx;
					leftChildIdx = 2 * currentIdx + 1;
				}
				else
					break;

            }
		}

		public void siftUp(int currentIdx, List<int> heap)
		{
			while (currentIdx > 0 && heap.ElementAt((currentIdx - 1)/2) > heap.ElementAt(currentIdx))
            {
				SwapNumbersAtIndex(currentIdx, (currentIdx - 1) / 2);
				currentIdx = (currentIdx - 1) / 2;
			}
		}

		public int Peek()
		{
			return heap.ElementAt(0);
		}

		public int Remove()
		{
			var elementToRemove = heap.ElementAt(0);
			SwapNumbersAtIndex(0, heap.Count - 1);
			heap.RemoveAt(heap.Count - 1);
			siftDown(0, heap.Count - 1, heap);
			return elementToRemove;
		}

		public void Insert(int value)
		{
			heap.Add(value);
			siftUp(heap.Count - 1, heap);
		}

		private void SwapNumbersAtIndex(int i1, int i2)
        {
			int tmp = heap[i1];
			heap[i1] = heap[i2];
			heap[i2] = tmp;
        }
	}

	public class MaxHeap
	{
		public List<int> heap = new List<int>();
		public MaxHeap(List<int> array)
		{
			heap = buildHeap(array);
		}

		public List<int> buildHeap(List<int> array)
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

		public void siftDown(int currentIdx, int endIdx, List<int> heap)
		{
			int leftChildIdx = 2 * currentIdx + 1;
			while (leftChildIdx <= endIdx)
			{
				int rightChildIdx = 2 * currentIdx + 2;
				int biggerChildIdx = leftChildIdx;
				if (rightChildIdx <= endIdx && heap.ElementAt(rightChildIdx) > heap.ElementAt(leftChildIdx))
					biggerChildIdx = rightChildIdx;

				if (heap.ElementAt(currentIdx) > heap.ElementAt(biggerChildIdx))
				{
					SwapNumbersAtIndex(currentIdx, biggerChildIdx, heap);
					currentIdx = biggerChildIdx;
					leftChildIdx = 2 * currentIdx + 1;
				}
				else
					break;

			}
		}

		public void siftUp(int currentIdx, List<int> heap)
		{
			while (currentIdx > 0 && heap.ElementAt((currentIdx - 1) / 2) < heap.ElementAt(currentIdx))
			{
				SwapNumbersAtIndex(currentIdx, (currentIdx - 1) / 2, heap);
				currentIdx = (currentIdx - 1) / 2;
			}
		}

		public int Peek()
		{
			return heap.ElementAt(0);
		}

		public int Size()
		{
			return heap.Count;
		}

		public int Remove()
		{
			var elementToRemove = heap.ElementAt(0);
			SwapNumbersAtIndex(0, heap.Count - 1, heap);
			heap.RemoveAt(heap.Count - 1);
			siftDown(0, heap.Count - 1, heap);
			return elementToRemove;
		}

		public void Insert(int value)
		{
			heap.Add(value);
			siftUp(heap.Count - 1, heap);
		}

		private void SwapNumbersAtIndex(int i1, int i2, List<int> arr)
		{
			int tmp = arr[i1];
			arr[i1] = arr[i2];
			arr[i2] = tmp;
		}
	}

}
