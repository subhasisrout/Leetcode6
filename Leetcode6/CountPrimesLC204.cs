//Sieve of Eratosthenes
//Naive way would O(n^2)

namespace Leetcode
{
    public class CountPrimesLC204
    {
        public int CountPrimes(int n)
        {
            bool[] primes = new bool[n];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }

            for (int i = 2; i * i < primes.Length; i++)
            {
                if (primes[i])
                {
                    for (int j = i; j * i< primes.Length; j++)
                    {
                        primes[i * j] = false;
                    }
                }
            }

            int primeCount = 0;
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i])
                    primeCount++;
            }

            return primeCount;
        }

    }
}
