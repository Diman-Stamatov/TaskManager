using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Classes.Interfaces;

namespace TaskManager.Classes
{
    internal class Team : ITeam
    {
        public string Name => throw new NotImplementedException();

        public ICollection<IMember> Members => throw new NotImplementedException();

        public ICollection<IBoard> Boards => throw new NotImplementedException();
    }
}
