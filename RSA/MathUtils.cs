using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RSA
{
    public static class MathUtils
    {
        public static BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b > 0)
            {
                var tmp = b;
                b = a % b;
                a = tmp;
            }

            return a;
        }

        public static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            var m0 = m;
            BigInteger y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                var q = a / m;
                var t = m;

                m = a % m;
                a = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0)
                x += m0;

            return x;
        }

        public static BigInteger ModExp(BigInteger a, BigInteger b, BigInteger n)
        {
            BigInteger res = 1;

            a = a % n;

            if (a == 0)
                return 0;

            while (b > 0)
            {
                if ((b & 1) != 0)
                    res = BigInteger.Multiply(res, a) % n;

                b = b >> 1;
                a = BigInteger.Multiply(a, a) % n;
            }

            return res;
        }
    }
}
