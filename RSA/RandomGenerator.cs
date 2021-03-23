using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    public class RandomGenerator
    {
        public static BigInteger GetNumber(int lengthInBits)
        {
            BigInteger number = 0;

            using (var rand = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[lengthInBits / 8];

                do
                {
                    rand.GetBytes(bytes);
                    number = new BigInteger(bytes);
                }
                while (number < 0);
            }

            return number;
        }


        public static BigInteger GetNumber(BigInteger min, BigInteger max)
        {
            if (min > max)
            {
                var tmp = min;
                min = max;
                max = tmp;
            }

            BigInteger number = 0;

            do
            {
                number = GetNumber((int)max.ToByteArray().LongLength * 8);
            }
            while (number < min || number > max);

            return number;
        }


        public static BigInteger GetPrimeNumber(int lengthInBits)
        {
            BigInteger number = 0;

            while (true)
            {
                number = GetNumber(lengthInBits);
                if (number.IsEven) number--;
                if (number < 0) continue;

                if (PrimeTester.FullTest(number) == true)
                    return number;
            }
        }


        public static BigInteger GetPrimeNumber(BigInteger min, BigInteger max)
        {
            BigInteger number = 0;

            while (true)
            {
                number = GetNumber(min, max);
                if (number.IsEven) number--;

                if (PrimeTester.FullTest(number) == true)
                    return number;
            }
        }
    }
}
