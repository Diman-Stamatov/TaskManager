using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;

namespace TaskManager.Models.Contracts
{
    internal interface IMember
    {
        string Name { get; }
        ICollection<ITask> Tasks { get; }
        ICollection<string> ActivityLog { get; }
    }
}
