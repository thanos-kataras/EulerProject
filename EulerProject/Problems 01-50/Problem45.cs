using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem45 : AbstractProblem, IProblem
    {
        public Problem45() : base(45)
        {
        }

        public void Run()
        {
            BigInteger currentTri = MathUtils.GenerateTriangleNumber(2);
            BigInteger currentPen = MathUtils.GeneratePentagonalNumber(2);
            BigInteger currentHex = MathUtils.GeneratePentagonalNumber(2);

            int triIndex = 1, penIndex = 1, hexIndex = 1;
            bool foundEqual = false;
            while (true)
            {
                if (currentTri == currentPen)
                    foundEqual = true;

                if (currentTri > currentPen)
                {
                    currentPen = MathUtils.GeneratePentagonalNumber(++penIndex);
                }
                else if (currentTri < currentPen)
                {
                    currentTri = MathUtils.GenerateTriangleNumber(++triIndex);
                    continue;
                }

                if (foundEqual)
                {
                    while (currentHex < currentPen)
                        currentHex = MathUtils.GenerateHexagonalNumber(++hexIndex);

                    if (currentHex == currentPen && currentTri > 40755)
                    {
                        this.result = currentTri.ToString();
                        return;
                    }
                    foundEqual = false;
                    currentTri = MathUtils.GenerateTriangleNumber(++triIndex);
                }
            }
        }
    }
}
