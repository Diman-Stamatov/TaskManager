using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;

namespace TaskManager.Models
{
    public class Bug : IBug
    {
        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public PriorityType Priority => throw new NotImplementedException();

        public SeverityType Severity => throw new NotImplementedException();

        public BugStatusType StatusType => throw new NotImplementedException();

        public IMember Assignee => throw new NotImplementedException();

        public IList<string> StepsToReproduce => throw new NotImplementedException();

        public IList<IComment> Comments => throw new NotImplementedException();

        public IList<string> ChangesHistory => throw new NotImplementedException();
    }
}
