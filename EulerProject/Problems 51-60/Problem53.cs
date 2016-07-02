using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems_51_60
{
    class Problem53 : AbstractProblem, IProblem
    {
        public Problem53() : base(53)
        {
        }

        public void Run()
        {
            int n = 1, r = 0;
            int moreThanAMill = 0;
            while (n<=100)
            {
                r = 0;
                while (n > r)
                {
                    BigInteger combis = CombiUtils.SelectRfromN(n, r);
                    if (combis >= 1000000)
                    {
                        moreThanAMill++;
                    }
                    r++;
                }
                n++;
            }
            this.result = moreThanAMill.ToString();
        }
    }
}
