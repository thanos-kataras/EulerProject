using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem37 : AbstractProblem, IProblem
    {
        public Problem37() : base(37)
        {

        }

        public void Run()
        {
            int found = 0 , sum = 0;
            int currNumber = 11;

            while (found < 11)
            {
                if (IsTruncatablePrime(currNumber))
                {
                    found++;
                    sum += currNumber;
                }
                currNumber++;
            }

            this.result = sum.ToString();
        }

        private bool IsTruncatablePrime(int currNumber)
        {
            string numStr = currNumber.ToString();
            string subSrtRight = "", subSrtLeft = "";
            for (int i = 1; i <= numStr.Length; i++ )
            {
                subSrtRight = numStr.Substring(numStr.Length - i);
                if (!Primes.IsPrime(Int32.Parse(subSrtRight)))
                    return false;
                subSrtLeft = numStr.Substring(0, i);
                if (!Primes.IsPrime(Int32.Parse(subSrtLeft)))
                    return false;
            }

            Console.WriteLine("Both ways truncatable prime:"+ currNumber);
            return true;
        }
    }
}
