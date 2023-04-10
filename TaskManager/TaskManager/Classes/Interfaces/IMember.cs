using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Classes.Interfaces
{
    internal interface IMember
    {
        string Name { get; }
        ICollection<ITask> Tasks { get; }
        ICollection<string> ActivityLog { get; }
    }
}
