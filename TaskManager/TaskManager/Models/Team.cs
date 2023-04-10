using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;
using TaskManager.Models.Contracts;

namespace TaskManager.Models
{
    internal class Team : ITeam
    {
        public string Name => throw new NotImplementedException();

        public ICollection<IMember> Members => throw new NotImplementedException();

        public ICollection<IBoard> Boards => throw new NotImplementedException();
    }
}
