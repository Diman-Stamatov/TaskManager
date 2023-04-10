using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Classes.Interfaces
{
    internal interface ITask
    {
        static int NextID = 0;
        string Title { get; }
        string Description { get; }
        ICollection<string> Comments { get; }
        ICollection<string> ChangeLog { get; }
        

    }
}
