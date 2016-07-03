using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems_51_60
{
    class Problem55 : AbstractProblem, IProblem
    {
        public Problem55() : base(55)
        {
        }

        public void Run()
        {
            int lynchel = 0;
            for (int i=1; i<10000;i++)
            {
                int tries = 0;
                BigInteger initial = i;
                bool isLynchel = true;
                while (tries < 50)
                {
                    BigInteger reverse = BigInteger.Parse(StringUtils.Reverse(initial.ToString()));
                    initial += reverse;
                    if (StringUtils.IsPalindrome(initial.ToString()))
                        isLynchel = false;

                    tries++;
                }
                if (isLynchel)
                    lynchel++;
            }

            this.result = lynchel.ToString();
        }
    }
}
