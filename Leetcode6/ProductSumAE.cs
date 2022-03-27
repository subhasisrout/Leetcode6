using System;
using System.Collections.Generic;

// #Below one is written by me.
// #AE has a simpler recursive version.

namespace Leetcode
{
    public class ProductSumAE
    {
		public int ProductSum(List<object> array)
		{
			int[] levelAndResult = new int[3]; //level, totalSum, currLevelSum
			levelAndResult[0] = 1;
			DeStructureSum(array, levelAndResult);
			return levelAndResult[1];
		}
		private void DeStructureSum(IList<object> array, int[] levelAndResult)
		{
			int currentLevelSum = 0;
			for (int i = 0; i < array.Count; i++)
			{
				if (array[i] is IList<object>)
				{
					IList<object> objectList = array[i] as IList<object>;
					levelAndResult[0] += 1;
					DeStructureSum(objectList, levelAndResult);
					levelAndResult[0] -= 1;
					currentLevelSum += levelAndResult[2];
				}
				else
				{
					currentLevelSum += Convert.ToInt32(array[i]);
				}
			}
			levelAndResult[2] = currentLevelSum * levelAndResult[0];			
			if (levelAndResult[0] == 1)
				levelAndResult[1] = currentLevelSum;
		}
	}
}
