using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Classes.Types;

namespace TaskManager.Classes.Interfaces
{
    internal interface IFeedback :ITask
    {
        int Rating { get; }
        FeedbackStatusType Status { get; }

    }
}
