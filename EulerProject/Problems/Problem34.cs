using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    /// <summary>
    /// Find the sum of all numbers which are equal 
    /// to the sum of the factorial of their digits.
    /// </summary>
    class Problem34 : AbstractProblem, IProblem
    {
        public Problem34() : base(34)
        {

        }

        public void Run()
        {
            BigInteger sum = 0;
            //Ignore 1 and 2 as they are not sums
            for (int i = 3; i <= 1000000; i++)
            {
                if (i % 10000000 ==0) Console.WriteLine(i);

                char[] characters = i.ToString()
                    .ToCharArray();
                BigInteger interimResult = 0;
                foreach (char num in characters)
                {
                    interimResult += Factorials.GetFactorial(Int32.Parse(num.ToString()));
                }

                if (interimResult == i)
                {
                    Console.WriteLine(interimResult);
                    sum += interimResult;
                }
            }

            this.result = "The sum of factorions is:" + sum;
        }
    }
}
