using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
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
            long[] fraction1 = new long[2] { 2,21};
            long[] fraction2 = new long[2] { 1,6}; 



            long[] result = MathUtils.AddFractions(fraction1,fraction2);

            Console.WriteLine("Fraction: {0} / {1}", result[0] , result[1]);
        }
    }
}
