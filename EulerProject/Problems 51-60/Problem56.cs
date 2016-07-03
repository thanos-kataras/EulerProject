using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems_51_60
{
    class Problem56 : AbstractProblem, IProblem
    {
        public Problem56() : base(56)
        {
        }

        public void Run()
        {
            long maxSum = 0;
            for (int i = 100; i >0; i--)
            {
                for (int j = 100; j >= 0; j--)
                {
                    BigInteger result = BigInteger.Pow(i, j);
                    long nextSum = MathUtils.IntToList(result).Sum();
                    if (nextSum> maxSum)
                    {
                        maxSum = nextSum;
                    }
                }
            }

            this.result = maxSum.ToString();
        }
    }
}
