using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;

namespace TaskManager.Models
{
    public class Story : IStory
    {
        public PriorityType Priority => throw new NotImplementedException();

        public SizeType Size => throw new NotImplementedException();

        public StoryStatustype Statustype => throw new NotImplementedException();

        public IMember Assignee => throw new NotImplementedException();

        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public IList<string> ChangesHistory => throw new NotImplementedException();

        IList<IComment> ITask.Comments => throw new NotImplementedException();
    }
}
