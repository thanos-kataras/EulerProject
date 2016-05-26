using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace EulerProject
{
    class Program
    {
        // List where we will save the problems
        static List<IProblem> problems = new List<IProblem>();

        static void Main(string[] args)
        {
            //  Get all classes that implement the IProblem interface
            List<Type> types = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes().Where(mytype => mytype.GetInterfaces().
                Contains(typeof(IProblem))).ToList();

            foreach (Type prbType in types)
            {
                // Create a new instance and add the problem to the list
                problems.Add((IProblem)Activator.CreateInstance(prbType));
            }

            while(true)
            {
                PrintOptions();
                Console.Write("Option:");
                var inputString = Console.ReadLine().ToString();
                int n;
                bool isNumeric = int.TryParse(inputString, out n);
                if(!isNumeric) {
                    Console.WriteLine("Wrong input type! Please enter valid number");
                    Console.Clear();
                    continue;
                }
                if (n==1)
                {
                    foreach (IProblem problem in problems)
                        Console.WriteLine("Id:" + problem.ID);
                } else if (n==2)
                {
                    Console.Write("Enter problem number:");
                    inputString = Console.ReadLine().ToString();
                    isNumeric = int.TryParse(inputString, out n);
                    if (!isNumeric)
                    {
                        Console.WriteLine("Wrong input type! Please enter valid number");
                        Console.Clear();
                        continue;
                    }
                    Console.WriteLine("Executing problem:"+ n);
                    IProblem runningProblem = problems.Where(x => x.ID == n).First();
                    runningProblem.Run();
                    Console.WriteLine("Execution done!");
                    Console.WriteLine("Result is:" + runningProblem.Result);

                } else if (n==3)
                {
                    Console.WriteLine("Bye");
                    break;
                }
            }
        }

        static void PrintOptions()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("\t1:List available problems");
            Console.WriteLine("\t2:Enter problem number to run");
            Console.WriteLine("\t3:Exit");
        }
    }
}
