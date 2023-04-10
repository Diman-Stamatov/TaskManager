using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Exceptions
{
    internal class InvalidUserInputException :ApplicationException
    {
        public InvalidUserInputException(string message) : base(message) 
        { }

    }
}
