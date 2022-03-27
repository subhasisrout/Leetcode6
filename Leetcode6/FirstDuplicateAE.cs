namespace Leetcode
{
    public class FirstDuplicateAE
    {
        public int FirstDuplicateValue(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                    continue;
                else
                {
                    if (array[array[i]] < 0)
                        return array[i];
                    else
                        array[array[i]] = array[array[i]] * -1;
                }
            }
            return -1;
        }
    }
}
