using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem32 : AbstractProblem, IProblem
    {
        public Problem32() : base(32)
        {
        }

        public void Run()
        {
            List<byte[]> oneToNineCombis = CombiUtils.IntCombinations(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9);
            HashSet<int> products = new HashSet<int>();
            int product = 0;

            foreach (byte[] pandigital in oneToNineCombis)
            {
                for (int i = 0; i < 8; i++)
                {
                    int firstInt = Int32.Parse(bytesToString(pandigital.Take(i + 1).ToArray()));
                    for (int j = i + 1; j < 8; j++)
                    {
                        int secondInt = Int32.Parse(bytesToString(pandigital.Skip(i + 1).Take(j-i).ToArray()));
                        product = Int32.Parse(bytesToString(pandigital.Skip(j + 1).ToArray()));
                        if (firstInt * secondInt == product && !products.Contains(product))
                            products.Add(product);
                    }
                }
            }

            BigInteger productsSum = products.Sum();

            this.result = productsSum.ToString();
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
