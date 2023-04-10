using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Enums;

namespace TaskManager.Models.Contracts
{
    internal interface IFeedback :ITask
    {
        int Rating { get; }
        FeedbackStatusType Status { get; }

    }
}
