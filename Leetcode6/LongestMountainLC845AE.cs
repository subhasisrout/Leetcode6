using System;

// #AE
// #SelfWritten #Intuitive

namespace Leetcode
{
    public class LongestMountainLC845AE
    {
		public int LongestMountain(int[] arr)
		{
			if (arr == null || arr.Length <= 2)
				return 0;

			int i = 1;
			int result = 0;
			int currentMax = 0;

			while (i < arr.Length - 1)
			{
				int originalI = i;
				bool leftMove = false;
				bool rightMove = false;
				while (i > 0 && arr[i - 1] < arr[i])
				{
					i--;
					leftMove = true;
				}
				int l = i;

				i = originalI;
				while (i < arr.Length - 1 && arr[i + 1] < arr[i])
				{
					i++;
					rightMove = true;
				}
				int r = i;

				if (leftMove && rightMove)
					currentMax = r - l + 1;
				else
					currentMax = 0;
				result = Math.Max(result, currentMax);
				i = r + 1;
			}
			return result;

		}
	}
}
