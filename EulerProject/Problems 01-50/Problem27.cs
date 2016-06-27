using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem27 : AbstractProblem, IProblem
    {
        static HashSet<long> cachedPrimes = new HashSet<long>();
        public Problem27() : base(27)
        {
        }

        public void Run()
        {
            int a = -999, b = -999;
            long testILongInt = 0;
            long maxConsecutivePrimes = 0, maxACoefficient = 0, maxBCoefficient = 0;
            for (int i = a; i <= 999; i++)
                for (int j = b; j <= 999; j++)
                {
                    int n = 0, consecutivePrimes = 0;
                    while (true)
                    {
                        testILongInt = GetQuadratic(i, j, n++);
                        if (testILongInt > 0 && Primes.IsPrime(testILongInt))
                        {
                            consecutivePrimes++;
                        } else
                        {
                            if (consecutivePrimes > maxConsecutivePrimes)
                            {
                                maxConsecutivePrimes = consecutivePrimes;
                                maxACoefficient = i;
                                maxBCoefficient = j;
                            }
                            break;
                        }
                    }
                }

            this.result = (maxACoefficient * maxBCoefficient).ToString();
        }

        /// <summary>
        /// Calclates n² + an + b
        /// </summary>
        /// <param name="a">The a coefficient</param>
        /// <param name="b">The b coefficient</param>
        /// <param name="n">The n of the quadratic formula</param>
        /// <returns></returns>
        private long GetQuadratic(int a, int b, int n)
        {
            return ((long)Math.Pow(n, 2) + a * n + b);
        }
    }
}
