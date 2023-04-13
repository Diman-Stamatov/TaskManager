using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;

namespace TaskManager.Models.Contracts
{
    public interface ITask : IHasId
    {
        string Title { get; }
        string Description { get; }
        IList<IComment> Comments { get; }
        IList<string> ChangesHistory { get; }
        void RevertStatus();
        void AdvanceStatus();
        void AddComment(IComment comment);
        string PrintChangesLog();
        string PrintComments();
        void Log(string newEvent);

    }
}
