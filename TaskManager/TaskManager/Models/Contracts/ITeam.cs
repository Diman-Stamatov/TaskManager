using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;

namespace TaskManager.Models.Contracts
{
    public interface ITeam
    {
        string Name { get; }
        ICollection<IMember> Members { get; }
        ICollection<IBoard> Boards { get; }

    }
}
