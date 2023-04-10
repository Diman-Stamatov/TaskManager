using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Exceptions
{
    public class EntryNotFoundException : ApplicationException
    {
        public EntryNotFoundException(string message):base(message) 
        { }
    }
}
