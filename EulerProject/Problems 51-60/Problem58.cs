using EulerProject.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems_51_60
{
    class Problem58 : AbstractProblem, IProblem
    {
        public Problem58() : base(58)
        {
        }

        public void Run()
        {
            int step = 2;
            long currentInt = 3;
            long countPrimes = 1;
            long diagonals = 1;
            int sideLength = 1;

            float ratio = 100f;

            Direction current = Direction.Left;

            while(ratio > 10)
            {
                switch(current)
                {
                    case Direction.Up:
                        step = step + 2;
                        break;
                    case Direction.Left:
                    case Direction.Right:
                    case Direction.Down:
                    default:
                        break;

                }

                currentInt += step;
                if (currentInt != 2 && Primes.IsPrime(currentInt))
                    countPrimes++;

                if (current == Direction.Right) { 
                    diagonals += 4;
                    ratio = (float)100 * (float)countPrimes / (float)diagonals;
                    sideLength+=2;
                }


                if (current != Direction.Up)
                    current++;
                else
                    current = Direction.Left;
            }

            this.result = sideLength.ToString();
        }

        enum Direction
        {
            Left,
            Down,
            Right,
            Up
        }
    }
}
