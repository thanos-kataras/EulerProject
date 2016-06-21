using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem39 : AbstractProblem, IProblem
    {
        public Problem39() : base(39)
        {
        }

        public void Run()
        {
            int maxsolutions = 0, currsolutions = 0, maxPerimeter = 0;
            for (int i = 1; i <= 1000; i++)
            {
                currsolutions = GetPythSoloutions(i);
                if (currsolutions > maxsolutions)
                {
                    maxsolutions = currsolutions;
                    maxPerimeter = i;
                }
            }

            this.result = maxPerimeter.ToString();
        }

        private int GetPythSoloutions(int i)
        {
            int solutions = 0;
            for(int a=1; a< i; a++)
            {
                for(int b=a; b<i; b++)
                {
                    int c = i - (a + b);
                    if (c < 0)
                        continue;
                    if(((int)Math.Pow(a,2)+(int)Math.Pow(b,2))== (int)Math.Pow(c, 2))
                    {
                        solutions++;
                    }
                }
            }

            return solutions;
        }
    }
}
