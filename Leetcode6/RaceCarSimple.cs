// Taken from https://leetcode.com/discuss/interview-question/2206756/google-phone-technical-interview-first-round-45-mins-us-2022


namespace Leetcode6
{
    public class RaceCarSimple
    {
        public int Racecar(string actions)
        {
            int pos = 0;
            int speed = 1;
            for (int i = 0; i < actions.Length; i++)
            {
                if (actions[i] == 'A')
                {
                    pos += speed;
                    speed *= 2;
                }
                else
                {
                    speed = -1;
                }

            }
            return pos;
        }

    }
}
