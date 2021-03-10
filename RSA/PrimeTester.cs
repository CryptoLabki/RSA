using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    public class PrimeTester
    {
        public static IEnumerable<int> GetFromEratosphen(int count)
        {
            var sieve = Enumerable.Repeat(true, count).ToArray();

            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i] == true)
                {
                    yield return i;

                    for (int j = i * i; j < sieve.Length; j += i)
                    {
                        sieve[j] = false;
                    }
                }
            }
        }


        public static bool CheckFermat(BigInteger n)
        {
            if (n < 2) return false;
            if (n <= 3) return true;

            for (int i = 2; i < n; i++)
            {
                if (MathUtils.ModExp(new BigInteger(i), n - 1, n) != 1)
                {
                    return false;
                }
            }

            return true;
        }


        public static bool CheckRabinMiller(BigInteger n, int r)
        {
            throw new NotImplementedException();
        }
    }
}
