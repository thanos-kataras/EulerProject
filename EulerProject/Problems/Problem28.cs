using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem28 : AbstractProblem, IProblem
    {
        public Problem28() : base(28)
        {
        }

        public void Run()
        {
            int[][] diagonalArray = new int[1001][];
            for (int i = 0; i<1001; i++ )
            {
                diagonalArray[i] = new int[1001];
            }
        }
    }
}
