using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem41 : AbstractProblem, IProblem
    {
        public Problem41() : base(41)
        {

        }

        public void Run()
        {
            for (int i=999999999; i>0; i--)
            {
                if ( i%2 != 0 && i % 10 != 0 && i % 3 != 0
                    && i % 5 != 0 && i % 7 != 0
                    && MathUtils.IsPandigital(i) 
                    && Primes.IsPrime(i))
                {
                    this.result = i.ToString();
                    break;
                }
            }
        }
    }
}
