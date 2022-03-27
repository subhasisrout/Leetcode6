using System;
using System.Collections.Generic;

// #Leetcode 93 #LC93 

namespace Leetcode
{
    public class ValidIPAddressesAE
    {
        public List<string> ValidIPAddresses(string s)
        {
            List<string> result = new List<string>();

            // Loop and inner loops for different position of dots.
            // input "1921680"
            // "1.9.216.80"
            for (int i = 1; i < Math.Min(s.Length, 4); i++)
            {
                string[] currentIPAddress = new string[4];

                currentIPAddress[0] = s.Substring(0, i);
                if (!IsPartValid(currentIPAddress[0]))
                    continue;

                for (int j = i + 1; j < i + Math.Min(s.Length - i, 4); j++)
                {
                    currentIPAddress[1] = s.Substring(i, j - i);
                    if (!IsPartValid(currentIPAddress[1]))
                        continue;

                    for (int k = j + 1; k < j + Math.Min(s.Length - j, 4); k++)
                    {
                        currentIPAddress[2] = s.Substring(j, k - j);
                        currentIPAddress[3] = s.Substring(k);
                        if (IsPartValid(currentIPAddress[2]) && IsPartValid(currentIPAddress[3]))
                        {
                            result.Add(string.Join(".", currentIPAddress));
                        }
                    }
                }
            }
            return result;
        }

        private bool IsPartValid(string strPart)
        {
            if (strPart.Length > 3) return false; // to check overflow exception in the below ToInt32 line
            int part = Convert.ToInt32(strPart);
            if (part > 255) return false;
            return strPart.Length == part.ToString().Length;
        }
    }
}
