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
            var d = getD(P, Q, E);
            var n = P * Q;

            var M = MathUtils.ModExp(c, d, n);
            return M;
        }


        public BigInteger getD(BigInteger P, BigInteger Q, int E)
        {
            return MathUtils.ModInverse(E, (P - 1) * (Q - 1));
        }
    }
}
