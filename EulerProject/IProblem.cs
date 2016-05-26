using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject
{
    /// <summary>
    /// Describes a problem calls that can be run
    /// </summary>
    interface IProblem
    {
        int ID { get; } 
        string Result { get; }
        void Run();
        
    }
}
