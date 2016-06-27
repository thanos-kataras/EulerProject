using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem47 : AbstractProblem, IProblem
    {
        static List<long> primes = new List<long>();
        public Problem47() : base(47)
        {
        }

        public void Run()
        {
            long i = 0;
            // Generate primes up to half te current
            for (i = 0; i < 323; i++)
            {
                if (Primes.IsPrime(i))
                    primes.Add(i);
            }
            long currInt = 646;
            int currCount = 0;
            while(true)
            {
                if ((currInt+1) % 2 == 0)
                {
                    if (Primes.IsPrime(++i))
                        primes.Add(i);
                }

                if (IsDivisibleByFourPrimes(++currInt))
                    currCount++;
                else
                    currCount = 0;

                if (currCount==4)
                {
                    this.result = (currInt - 3).ToString();
                    return;
                }
            }
        }

        private bool IsDivisibleByFourPrimes(long v)
        {
            int primesFoundCount = 0;

            foreach (long prime in primes)
            {
                if (v % prime == 0)
                {
                    primesFoundCount++;
                    if (primesFoundCount >= 4)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
