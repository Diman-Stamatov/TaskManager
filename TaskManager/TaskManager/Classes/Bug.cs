using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Classes.Interfaces;
using TaskManager.Classes.Types;

namespace TaskManager.Classes
{
    internal class Bug : IBug
    {
        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();
        public ICollection<string> StepsToReproduce => throw new NotImplementedException();

        public PriorityType Priority => throw new NotImplementedException();

        public SeverityType Severity => throw new NotImplementedException();

        public BugStatusType StatusType => throw new NotImplementedException();

        public IMember Assignee => throw new NotImplementedException();
        

        public ICollection<string> Comments => throw new NotImplementedException();

        public ICollection<string> ChangeLog => throw new NotImplementedException();
    }
}
