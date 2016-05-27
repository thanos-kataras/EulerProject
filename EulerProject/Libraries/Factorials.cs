using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace EulerProject.Libraries
{
    class Factorials
    {
        private static Dictionary<Int32, BigInteger> cachedIntegers = new Dictionary<int, BigInteger>();
        public static BigInteger GetFactorial(Int32 number)
        {
            if (number == 0) return 1;
            if (cachedIntegers.ContainsKey(number))
                return cachedIntegers[number];

            BigInteger result = number;

            for (int i = 1; i < number; i++)
            {
                result = result * i;
            }
            cachedIntegers[number] = result;
            return result;
        }
    }
}
