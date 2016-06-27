using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems_51_60
{
    class Problem51 : AbstractProblem, IProblem
    {
        public Problem51() : base(51)
        {
        }

        public void Run()
        {
            Dictionary<int, char> map = new Dictionary<int, char>() {
                { 0, '0' },
                { 1, '1' },
                { 2, '2' },
                { 3, '3' },
                { 4, '4' },
                { 5, '5' },
                { 6, '6' },
                { 7, '7' },
                { 8, '8' },
                { 9, '9' },
            };

            int num = 1001;
            while (true)
            {
                if (!Primes.IsPrime(num))
                {
                    num += 2;
                    continue;
                }

                StringBuilder initStr = new StringBuilder(num.ToString());
                HashSet<StringBuilder> all = new HashSet<StringBuilder>() { initStr };
                for (int i = 1; i < num.ToString().Length - 1; i++)
                {
                    HashSet<StringBuilder> inter = new HashSet<StringBuilder>();
                    foreach (StringBuilder str in all)
                    {
                        for (int j = 0; j < str.Length - 1; j++)
                        {
                            StringBuilder newStr = new StringBuilder(str.ToString());
                            if (newStr[j] != '*')
                            {
                                newStr[j] = '*';
                            }
                            else
                            {
                                continue;
                            }
                            if(!all.Contains(newStr) && !inter.Contains(newStr))
                                inter.Add(newStr);
                        }
                    }
                    all.UnionWith(inter);
                    if (i == 1)
                        all.Remove(initStr);
                }

                foreach (StringBuilder number in all)
                {
                    int primeCount = 0;
                    bool isInFamily = false;
                    for (int k = 0; k < 10; k++)
                    {
                        StringBuilder nNumber = new StringBuilder(number.ToString());
                        if (number[0] == '*' && k == 0)
                            continue;

                        if (nNumber.Equals(new StringBuilder("*2*3*3")))
                            ;
                        nNumber.Replace("*", k.ToString());
                        
                        int testPrime = Int32.Parse(nNumber.ToString());
                        if (initStr.Equals(nNumber))
                            isInFamily = true;
                        if (Primes.IsPrime(testPrime)) { 
                            primeCount++;
                            if (primeCount == 8 && isInFamily)
                            {
                                this.result = num.ToString();
                                return;
                            }
                        }
                    }
                    
                }
                num += 2;
            }
        }
    }
}
