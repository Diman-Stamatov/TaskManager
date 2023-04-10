using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Classes.Types;

namespace TaskManager.Classes.Interfaces
{
    internal interface IStory : ITask
    {
        PriorityType Priority { get; }
        SizeType Size { get; }
        StoryStatustype Statustype { get; }
        IMember Assignee { get; }
    }
}
