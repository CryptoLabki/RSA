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
        public static IEnumerable<int> GetFromEratosphen(int max)
        {
            var sieve = Enumerable.Repeat(true, max).ToArray();

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
            if (n.IsEven) return false;

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
            if (n < 2) return false;
            if (n <= 3) return true;
            if (n.IsEven) return false;

            int s = 0;
            var m = n - 1;

            while (m.IsEven)
            {
                m /= 2;
                s++;
            }

            while (r-- > 0)
            {
                // Choose a in [2 .. n - 2]
                var a = RandomGenerator.GetNumber(2, n - 2);

                var x = MathUtils.ModExp(a, new BigInteger(s), n);

                if (x == 1 || x == n - 1) continue;

                for (int i = 0; i < s - 1; i++)
                {
                    x = MathUtils.ModExp(x, 2, n);

                    if (x == 1) return false;
                    if (x == n - 1) break;
                }

                if (x != n - 1) return false;
            }

            return true;
        }


        public static bool FullTest(BigInteger n)
        {
            // simple test
            foreach (var p in GetFromEratosphen((int)BigInteger.Min(150, n)))
            {
                if (n % p == 0) return false;
            }

            if (CheckFermat(n) == false) return false;

            if (CheckRabinMiller(n, 10) == false) return false;

            return true;
        }
    }
}
