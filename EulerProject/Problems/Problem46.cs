using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem46 : AbstractProblem, IProblem
    {
        public Problem46() : base(46)
        {
        }

        public void Run()
        {
            SortedSet<long> primes = new SortedSet<long>();
            SortedSet<long> generatedComposites = new SortedSet<long>();
            SortedSet<long> composites = new SortedSet<long>();

            int batchStart = 0, batchLength = 100;
            long topPrime = 0, topComposite = 3;
            while (true)
            {
                for (long i=batchStart; i < batchStart + batchLength; i++)
                {
                    if(Primes.IsPrime(i))
                    {
                        primes.Add(i);
                        topPrime = i;
                    }
                }

                for (long i = topComposite; i < topPrime; i++)
                {
                    if (i%2 != 0 && !primes.Contains(i))
                    {
                        composites.Add(i);
                        topComposite = i;
                    }
                }

                foreach(long prime in primes)
                {
                    long generatedComposite = 0;
                    int baseInt = 1;
                    while (generatedComposite < topPrime)
                    {
                        generatedComposite = GenerateComposite(prime, baseInt++);
                        if (!generatedComposites.Contains(generatedComposite))
                        {
                            generatedComposites.Add(generatedComposite);
                        }
                    }
                }

                foreach(long composite in composites)
                {
                    if (!generatedComposites.Contains(composite))
                    {
                        this.result = composite.ToString();
                        return;
                    }
                }

                composites.Clear();
                batchStart += batchLength;
            }
        }

        private long GenerateComposite(long prime, int v)
        {
            return prime + 2 * (long)Math.Pow(v, 2);
        }
    }
}
