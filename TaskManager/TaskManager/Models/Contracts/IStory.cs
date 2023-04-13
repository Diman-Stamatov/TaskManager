using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Enums;

namespace TaskManager.Models.Contracts
{
    public interface IStory : ITask
    {
        PriorityType Priority { get; }
        SizeType Size { get; }
        StoryStatusType Status { get; }
        IMember Assignee { get;}
        string TeamAssignedTo { get; }
        void AdvancePriority();
        void RevertPriority();
        void AdvanceSize();
        void RevertSize();
        void Assign(IMember member);
        void Unassign();
    }
}
