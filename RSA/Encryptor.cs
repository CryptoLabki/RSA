using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    public class Encryptor
    {
        public readonly int E;

        public BigInteger P { get; private set; }
        public BigInteger Q { get; private set; }

        public BigInteger N => P * Q;
        public BigInteger Phi => (P - 1) * (Q - 1);


        public Encryptor(int e, int lengthInBits)
        {
            E = e;

            if (E % 2 == 0)
                throw new ArgumentException("E must be odd");

            do
            {
                P = RandomGenerator.GetPrimeNumber(lengthInBits);
                Q = RandomGenerator.GetPrimeNumber(lengthInBits);
            }
            while (MathUtils.GCD(E, Phi) != 1);
        }


        public BigInteger Encrypt(BigInteger m)
        {
            var c = MathUtils.ModExp(m, E, N);

            return c;
        }
    }
}
