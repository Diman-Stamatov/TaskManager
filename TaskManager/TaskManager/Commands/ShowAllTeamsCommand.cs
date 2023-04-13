using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    internal class ShowAllTeamsCommand : BaseCommand
    {

        public ShowAllTeamsCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            return "";
        }
    }
}
