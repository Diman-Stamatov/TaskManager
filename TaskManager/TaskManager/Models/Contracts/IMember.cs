using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;

namespace TaskManager.Models.Contracts
{
    public interface IMember : IAssigneble
    {
        string Name { get; }
        IList<ITask> Tasks { get; }
        IList<string> ActivityHistory { get; }
    }
}
