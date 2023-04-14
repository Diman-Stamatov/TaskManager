using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TaskManager.Models.Contracts
{
    public interface IBoard
    {
        string Name { get; }
        IList<ITask> Tasks { get; }
        IList<string> ActivityHistory { get; }
        void AddTask(ITask task);
        void Log(string newEvent);
        void ShowActivityHistory();
    }
}
