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

            int row = 0, column = 1000;
            Direction currentDirection = Direction.Left;
            int leftLimit = 0, downLimit = 1000, rightLimit = 1000, upLimit = 1;
            long diagSum = 0;
            bool leftStart = true;
            for (int i = (int)Math.Pow(1001,2); i > 0; i--)
            {
                if (currentDirection == Direction.Left && column >= leftLimit)
                {
                    // At the start of the square add number as
                    // it is the first of the diagonal
                    if (leftStart)
                    {
                        diagSum += i;
                    }
                    diagonalArray[row][column] = i;
                    
                    if (column == leftLimit && !leftStart)
                    {
                        leftLimit++;
                        currentDirection = map[currentDirection];
                        diagSum += i;
                        row++;
                    } else
                    column--;

                    leftStart = false;

                } else if (currentDirection == Direction.Down && row <= downLimit)
                {
                    diagonalArray[row][column] = i;
                    
                    if (row == downLimit)
                    {
                        downLimit--;
                        currentDirection = map[currentDirection];
                        diagSum += i;
                        column++;
                    } else
                    row++;
                } else if (currentDirection == Direction.Right && column <= rightLimit)
                {
                    diagonalArray[row][column] = i;
                    
                    if (column == rightLimit)
                    {
                        rightLimit--;
                        currentDirection = map[currentDirection];
                        diagSum += i;
                        row--;
                    } else
                        column++;
                }
                else if (currentDirection == Direction.Up && row >= upLimit)
                {
                    diagonalArray[row][column] = i;
                    
                    if (row == upLimit)
                    {
                        upLimit++;
                        currentDirection = map[currentDirection];
                        column--;
                        leftStart = true;
                    } else
                        row--;
                }
            }
            this.result = diagSum.ToString();
        }

        private Dictionary<Direction,Direction> map = new Dictionary<Direction,Direction> {
            {Direction.Left,Direction.Down},
            {Direction.Down,Direction.Right},
            {Direction.Right,Direction.Up},
            {Direction.Up,Direction.Left}
            };

        private enum Direction
        {
            Up = 0,
            Down = 1,
            Right = 2,
            Left = 3
        }
    }
}
