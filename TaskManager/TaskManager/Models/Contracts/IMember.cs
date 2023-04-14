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
 
        string TeamAssignedTo { get; }

        void AssignToTeam(string teamName);
        void Log(string newEvent);
        void AddTask(ITask task);
        void RemoveTask(ITask task);
        string FullInfo();
        string ShowActivityLog();
        string PrintTasks();
    }
}
