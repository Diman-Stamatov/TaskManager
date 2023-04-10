using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;
using TaskManager.Models.Contracts;

namespace TaskManager.Models
{
    public abstract class Task : ITask
    {
        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public IList<string> ChangesHistory => throw new NotImplementedException();

        IList<IComment> ITask.Comments => throw new NotImplementedException();
    }
}
