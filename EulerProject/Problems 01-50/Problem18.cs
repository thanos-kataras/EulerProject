using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems
{
    class Problem18 : AbstractProblem, IProblem
    {
        private string filename;
        private int[][] routes;
        private int[] routePoints;
        private int[] routeTotals;

        private List<Int32> DeadRoutes = new List<Int32>();

        public Problem18() : base(18)
        {
            this.filename = @"..\..\FileResources\\p018_routes.txt";
        }

        public void Run()
        {
            // Read the routes from the respective problem file (p018_routes.txt)
            PopulateRoutes();

            // Store the current route point
            routePoints = new int[routes[routes.Length - 1].Length];
            // Store the current route totals
            routeTotals = new int[routes[routes.Length - 1].Length];

            for (int i = 0; i < routes[routes.Length - 1].Length; i++)
            {
                routePoints[i] = i;
                routeTotals[i] = routes[routes.Length - 1][i];
            }

            for (int step = routes[routes.Length - 1].Length - 1; step > 0; step--)
            {
                for (int j = 0; j < routes[step-1].Length; j++ )
                {
                    if (j == 0)
                        routes[step - 1][j] += routes[step][0] > routes[step][1] ? routes[step][0] : routes[step][1];
                    else
                        routes[step - 1][j] += routes[step][j] > routes[step][j + 1] ? routes[step][j] : routes[step][j + 1];
                }
            }

            this.result = routes[0][0].ToString();
        }

        /// <summary>
        /// Gets from file and adds to routes array
        /// </summary>
        private void PopulateRoutes()
        {
            string[] lines = System.IO.File.ReadAllLines(this.filename);
            routes = new int[lines.Count()][];

            for (int i = 0; i < lines.Count(); i++)
            {
                routes[i] = new int[i + 1];
                Array.Clear(routes[i], 0, i + 1);
            }

            int line_num = 0;
            foreach (string line in lines)
            {
                int row_num = 0;
                foreach (string entry in line.Split(' '))
                {
                    routes[line_num][row_num] = Int32.Parse(entry);
                    row_num++;
                }
                line_num++;
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }
        }

    }
}
