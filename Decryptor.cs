using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class Decryptor
    {
        public BigInteger Decrypt(BigInteger P, BigInteger Q, int E, BigInteger c)
        {
            var d = MathUtils.ModInverse(E, (P - 1) * (Q - 1));
            var n = P * Q;

            var M = MathUtils.ModExp(c, d, n);
            return M;
        }
    }
}
