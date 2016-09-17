using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems_51_60
{
    class Problem57 : AbstractProblem, IProblem
    {
        public Problem57() : base(57)
        {
        }

        public void Run()
        {
            int count = 0;
            BigInteger[] fraction1 = new BigInteger[2] {1,1};
            BigInteger[] fraction2 = new BigInteger[2] {1,2};



            BigInteger[] latestPartial = new BigInteger[2] { 2 , 1 };

            for (int i=1; i<1000; i++)
            {

                latestPartial = CalcLatestPartial(latestPartial);

                fraction2[0] = latestPartial[1];
                fraction2[1] = latestPartial[0];

                BigInteger[] result = MathUtils.AddFractions(fraction1, fraction2);

                // If the nominator is more digits than the denominator
                // increment the count.
                if (result[0].ToString().Length > result[1].ToString().Length)
                    count++;
            }

            Console.WriteLine("Count = {0}", count);
        }

        private BigInteger[] CalcLatestPartial(BigInteger[] latestPartial)
        {
            BigInteger[] fraction1 = new BigInteger[2] { 2, 1 };
            BigInteger[] fraction2 = new BigInteger[2] { latestPartial[1], latestPartial[0] };
            return MathUtils.AddFractions(fraction1, fraction2);

        }
    }
}
