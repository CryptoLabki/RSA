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


        public static BigInteger ModExp(BigInteger a, BigInteger b, BigInteger n)
        {
            throw new NotImplementedException();
        }

    }
}
