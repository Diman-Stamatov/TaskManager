using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Classes.Interfaces;
using TaskManager.Classes.Types;

namespace TaskManager.Classes
{
    internal class Story : IStory
    {
        public PriorityType Priority => throw new NotImplementedException();

        public SizeType Size => throw new NotImplementedException();

        public StoryStatustype Statustype => throw new NotImplementedException();

        public IMember Assignee => throw new NotImplementedException();

        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public ICollection<string> Comments => throw new NotImplementedException();

        public ICollection<string> ChangeLog => throw new NotImplementedException();
    }
}
