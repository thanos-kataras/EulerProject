using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem36 : AbstractProblem, IProblem
    {
        public Problem36() : base(36)
        {
        }

        public void Run()
        {
            int sum = 0;
            for (int i=0; i < 1000000; i++)
            {
                String dec = i.ToString();
                String bin = Convert.ToString(i, 2);
                if (StringUtils.IsPalindrome(dec) &&
                    StringUtils.IsPalindrome(bin))
                {
                    sum += i;
                    Console.WriteLine("Decimal: " + dec + "Binary: " + bin);
                }
            }
            this.result = sum.ToString();
        }

        
    }
}
