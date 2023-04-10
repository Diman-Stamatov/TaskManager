using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Classes.Types;

namespace TaskManager.Classes.Interfaces
{
    internal interface IBug :ITask
    {
        ICollection<string> StepsToReproduce { get; }
        PriorityType Priority { get; }
        SeverityType Severity { get; }
        BugStatusType StatusType { get; }
        IMember Assignee { get; }




    }
}
