using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;

namespace TaskManager.Models.Contracts
{
    public interface ITask
    {
        static int NextID = 0;
        string Title { get; }
        string Description { get; }
        IList<IComment> Comments { get; }
        IList<string> ChangesHistory { get; }
        

    }
}
