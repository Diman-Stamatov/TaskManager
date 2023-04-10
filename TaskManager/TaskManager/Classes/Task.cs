using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Classes.Interfaces;

namespace TaskManager.Classes
{
    internal abstract class Task : ITask
    {
        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public ICollection<string> Comments => throw new NotImplementedException();

        public ICollection<string> ChangeLog => throw new NotImplementedException();
    }
}
