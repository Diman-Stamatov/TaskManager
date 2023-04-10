using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;
using TaskManager.Models.Contracts;

namespace TaskManager.Models
{
    public class Team : ITeam
    {
        public string Name => throw new NotImplementedException();

        public IList<IMember> Members => throw new NotImplementedException();

        public IList<IBoard> Boards => throw new NotImplementedException();
    }
}
