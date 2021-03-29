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


        public static bool CheckRabinMiller(BigInteger n, int r)
        {
            var b = n - 1;
            int k = -1;
            var beta = new List<int>();

            do
            {
                k++;
                beta.Add((int)(b % 2));
                b /= 2;
            }
            while (b > 0);

            for (int j = 0; j < r; j++)
            {
                var a = RandomGenerator.GetNumber(2, n - 2);

                if (MathUtils.GCD(a, n) > 1)
                    return false;

                BigInteger d = 1;
                for (int i = k; i >= 0; i--)
                {
                    var x = d;
                    d = MathUtils.ModExp(d, 2, n);

                    if (d == 1 && x != 1 && x != n - 1)
                        return false;

                    if (beta[i] == 1)
                        d = (d * a) % n;
                }

                if (d != 1)
                    return false;
            }

            return true;
        }


        public static bool FullTest(BigInteger n)
        {
            if (n < 2) return false;
            if (n <= 3) return true;
            if (n.IsEven) return false;

            // simple test
            foreach (var p in GetFromEratosphen((int)BigInteger.Min(150, n)))
            {
                if (n % p == 0)
                    return false;
            }

            if (CheckRabinMiller(n, 10) == false)
                return false;

            return true;
        }
    }
}
