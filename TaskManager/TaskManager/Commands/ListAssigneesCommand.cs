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
        public const int ExpectedNumberOfArguments = 0;
        //Трябва да решим, колко параметъра ще приема тази команда

        public ListAssigneesCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            var assignees = Repository.Members.
                Where(member => member.IsAssignedToATeam==true).
                OrderBy(member => member.Name).
                ToList();

            if (assignees.Count == 0 )
            {
                return "No Tasks are assigned!";
            }

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var assignee in assignees)
            {
                stringBuilder.AppendLine(assignee.ToString());
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
