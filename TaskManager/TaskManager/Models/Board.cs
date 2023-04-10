using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;
using TaskManager.Models.Contracts;

namespace TaskManager.Models
{
    internal class Board : IBoard
    {
        public string Name => throw new NotImplementedException();

        public ICollection<ITask> Tasks => throw new NotImplementedException();

        public ICollection<string> ActivityLog => throw new NotImplementedException();
    }
}
