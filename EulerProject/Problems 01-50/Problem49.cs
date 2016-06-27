using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem49 : AbstractProblem, IProblem
    {
        public Problem49() : base(49)
        {
        }

        public void Run()
        {
            for (int i = 1000; i<10000; i++)
            {
                if (Primes.IsPrime(i))
                {
                    byte[] bytes = {
                        Byte.Parse(i.ToString()[0].ToString()),
                        Byte.Parse(i.ToString()[1].ToString()),
                        Byte.Parse(i.ToString()[2].ToString()),
                        Byte.Parse(i.ToString()[3].ToString()),
                    };
                    List<byte[]> permutations = CombiUtils.IntCombinations(bytes, 4);
                    List<int> primes = new List<int>();
                    List<int> solutionPrimes = new List<int>();
                    foreach (byte[] perm in permutations)
                    {
                        int prime = Int32.Parse(bytesToString(perm));
                        if(Primes.IsPrime(prime))
                        {
                            primes.Add(prime);
                        }
                    }
                    primes.Sort();
                    primes = primes.Where(x => x.ToString().Length==4).ToList();
                    for (int firstIndex = 0; firstIndex < primes.Count(); firstIndex++)
                    {
                        bool found = false;
                        int secondIndex = 1;
                        while (secondIndex < primes.Count())
                        {
                            int diff = primes[secondIndex] - primes[firstIndex];
                            for (int l = primes.Count - 1; l > secondIndex; l--)
                            {
                                if (diff == primes[l] - primes[secondIndex] && diff!=0)
                                {
                                    solutionPrimes.Add(primes[firstIndex]);
                                    solutionPrimes.Add(primes[secondIndex]);
                                    solutionPrimes.Add(primes[l]);
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                                break;
                            secondIndex++;
                        }
                        if (found)
                            break;
                    }

                    if(solutionPrimes.Count == 3)
                    {
                        
                        if (solutionPrimes[1] - solutionPrimes[0] == solutionPrimes[2] - solutionPrimes[1])
                            Console.WriteLine("Prime 1: {0} Prime 2: {1} Prime 3: {2} - Diff value: {3}",
                                solutionPrimes[0],
                                solutionPrimes[1], 
                                solutionPrimes[2], 
                                solutionPrimes[2]- primes[1]
                                );

                        if (solutionPrimes[0] != 1487)
                        {
                            this.result = solutionPrimes[0] + "" + solutionPrimes[1] + "" + solutionPrimes[2];
                            return;
                        }
                    }

                    
                }
            }
        }

        private String bytesToString(byte[] bytes)
        {
            string tmp = "";
            foreach (byte b in bytes)
            {
                tmp += b;
            }
            return tmp;
        }
    }
}
