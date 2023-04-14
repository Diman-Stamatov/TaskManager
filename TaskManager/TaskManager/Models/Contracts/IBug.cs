using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Enums;

namespace TaskManager.Models.Contracts
{
    public interface IBug : ITask
    {
        IList<string> StepsToReproduce { get; }
        PriorityType Priority { get; }
        SeverityType Severity { get; }
        BugStatusType Status { get; }
        IMember Assignee { get; }
        string TeamAssignedTo { get; } 
        void AdvancePriority();
        void RevertPriority();
        void AdvanceSeverity();
        void RevertSeverity(); 
        void Assign(IMember member);
        void Unassign();
        void AddStepToReproduce(string stepOfReproduce);
    }
}
