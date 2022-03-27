using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ValidStartingCityAE
    {
		public int ValidStartingCity(int[] distances, int[] fuel, int mpg)
		{
			int resultIdx = 0;
			int currentLeftOverMileage = 0;
			int minimumLeftOverMileage = Int32.MaxValue;
            for (int i = 0; i < distances.Length; i++)
            {
				if (currentLeftOverMileage < minimumLeftOverMileage)
                {
					minimumLeftOverMileage = currentLeftOverMileage;
					resultIdx = i;
                }

				//update currentLeftOverMileage at each stop
				currentLeftOverMileage = currentLeftOverMileage + (mpg * fuel[i]) - distances[i];
            }
			return resultIdx;			
		}
	}
}
