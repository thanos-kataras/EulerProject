using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject
{
    class AbstractProblem
    {
        private int _ID;
        protected string result = "";

        public int ID
        {
            get { return _ID; }
        }

        public string Result
        {
            get { return result; }
        }

        public AbstractProblem(int ID)
        {
            this._ID = ID;
        }
    }
}
