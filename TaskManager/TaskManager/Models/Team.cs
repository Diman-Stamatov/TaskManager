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

        IList<IMember> ITeam.Members => throw new NotImplementedException();

        IList<IBoard> ITeam.Boards => throw new NotImplementedException();
    }
}
