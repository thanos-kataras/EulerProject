using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem36 : AbstractProblem, IProblem
    {
        public Problem36() : base(36)
        {
        }

        public void Run()
        {
            int circPrimes = 0;
            for (int i = 2; i < 1000000; i++)
            {
                bool isFullPrime = true;
                foreach (int num in MathUtils.NumberRotations(i))
                {
                    if (!Primes.IsPrime(num))
                    {
                        isFullPrime = false;
                        break;
                    }
                }
                if (isFullPrime)
                    circPrimes++;
            }
            this.result = circPrimes.ToString();
        }
    }
}
