using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Classes.Interfaces;
using TaskManager.Classes.Types;

namespace TaskManager.Classes
{
    internal class Feedback : IFeedback
    {
        public int Rating => throw new NotImplementedException();

        public FeedbackStatusType Status => throw new NotImplementedException();

        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public ICollection<string> Comments => throw new NotImplementedException();

        public ICollection<string> ChangeLog => throw new NotImplementedException();
    }
}
