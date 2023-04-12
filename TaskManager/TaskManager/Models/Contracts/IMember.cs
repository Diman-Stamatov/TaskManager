using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;

namespace TaskManager.Models.Contracts
{
    public interface IMember 
    {
        string Name { get; }
        IList<ITask> Tasks { get; }
        bool IsAssignedToATeam { get; }
    }
}
