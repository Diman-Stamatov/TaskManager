using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class ListAssigneesCommand : BaseCommand
    {
        public ListAssigneesCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            var assignees = Repository.Members.
                Where(member => member.TeamAssignedTo != null).
                OrderBy(member => member.Name).
                ToList();

            if (assignees.Count == 0 )
            {
                return "No Tasks have been assigned yet!";
            }

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var assignee in assignees)
            {
                stringBuilder.Append(assignee);
                stringBuilder.AppendLine(GenerateString('*', 15));
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
