using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    internal class ShowAllMembersCommand:BaseCommand
    {
       
        public ShowAllMembersCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            var members = Repository.Members.ToList();
            StringBuilder memberDisplay = new StringBuilder();
            foreach (var member in members)
            {
                memberDisplay.Append(member.FullInfo());
            }

        }
    }
}
