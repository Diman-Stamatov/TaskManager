using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class ShowAllMembersCommand : BaseCommand
    {

        public ShowAllMembersCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            var members = Repository.Members;
            StringBuilder memberDisplay = new StringBuilder();

            for (int i = 0; i < members.Count; i++)
            {
                memberDisplay.AppendLine($"{i + 1}. Member name: {members[i].Name}.");
            }
            memberDisplay.AppendLine(StringGenerator('*', 15));

            return memberDisplay.ToString().Trim();
        }
    }
}
