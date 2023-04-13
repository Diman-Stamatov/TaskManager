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
        void AssignToATeam();
        void Log(string newEvent);
        void AddTask(ITask task);
        void RemoveTask(ITask task);
        string FullInfo();
        string ActivityLog();
        string PrintTasks();
    }
}
