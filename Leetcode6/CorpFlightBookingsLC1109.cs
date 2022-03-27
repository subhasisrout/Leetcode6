// Slow in leetcode, but works
// #2d array
// Leetcode solution is O(n). Understood the codeflow but have not understood the intuition.
namespace Leetcode
{
    public class CorpFlightBookingsLC1109
    {
        
        public int[] CorpFlightBookings(int[][] bookings, int n)
        {
            int[] result = new int[n];

            for (int i = 0; i < bookings.Length; i++)
            {
                GetNumOfPersons(bookings[i][0], bookings[i][1], bookings[i][2], result);
            }

            return result;
        }
        private void GetNumOfPersons(int i,int j, int k, int[] result)
        {
            for (int idx = i; idx <= j; idx++)
            {
                result[idx - 1] += k;
            }
        }
    }

}
