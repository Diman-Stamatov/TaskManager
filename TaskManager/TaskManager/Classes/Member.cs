using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Classes.Interfaces;

namespace TaskManager.Classes
{
    internal class Member : IMember
    {
        public string Name => throw new NotImplementedException();

        public ICollection<ITask> Tasks => throw new NotImplementedException();

        public ICollection<string> ActivityLog => throw new NotImplementedException();
    }
}
