using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Exceptions
{
    internal class DuplicateEntryException:ApplicationException
    {
        public DuplicateEntryException(string message) : base(message)
        { }
    }
}
