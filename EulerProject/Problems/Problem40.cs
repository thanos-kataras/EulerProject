using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem40 : AbstractProblem, IProblem
    {
        public Problem40() : base(40)
        {

        }

        public void Run()
        {
            StringBuilder decPoints = new StringBuilder("");
            int i = 1;
            while (decPoints.Length < 1000000)
            {
                decPoints.Append(i.ToString());
                i++;
            }
            BigInteger multResult = 1;
            multResult *= Int32.Parse(decPoints[1-1].ToString())
                * Int32.Parse(decPoints[10-1].ToString())
                 * Int32.Parse(decPoints[100-1].ToString())
                  * Int32.Parse(decPoints[1000-1].ToString())
                   * Int32.Parse(decPoints[10000-1].ToString())
                    * Int32.Parse(decPoints[100000-1].ToString())
                     * Int32.Parse(decPoints[1000000-1].ToString());
            this.result = multResult.ToString();
        }
    }
}