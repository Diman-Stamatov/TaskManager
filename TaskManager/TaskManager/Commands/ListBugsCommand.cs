using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Enums;
using TaskManager.Models;

namespace TaskManager.Commands
{
    public class ListBugsCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public ListBugsCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            string filterByCommand = CommandParameters[0];
            string sortByCommand = CommandParameters[1];
            var task = Repository.Tasks.OfType<Bug>().ToList();
            StringBuilder stringBuilder = new StringBuilder();

            if (filterByCommand == "FilterActive")
            {
                List<Bug> bugsActive = task.
               Where(bug => bug.Status == BugStatusType.Active).
               OrderBy(bug => bug.Title).
               ThenBy(bug => bug.Priority == PriorityType.High).
               ThenBy(bug => bug.Priority == PriorityType.Medium).
               ThenBy(bug => bug.Priority == PriorityType.Low).
               ThenBy(bug => bug.Severity == SeverityType.Critical).
               ThenBy(bug => bug.Severity == SeverityType.Major).
               ThenBy(bug => bug.Severity == SeverityType.Minor).
               ToList();
               
                foreach (Bug bug in bugsActive)
                {
                    stringBuilder.Append(bug);
                    StringGenerator('*', 15);
                }
            }
            else if (filterByCommand == "Fixed")
            {
                List<Bug> bugsFixed = task.
               Where(bug => bug.Status == BugStatusType.Fixed).
               OrderBy(bug => bug.Title).
               ThenBy(bug => bug.Priority == PriorityType.High).
               ThenBy(bug => bug.Priority == PriorityType.Medium).
               ThenBy(bug => bug.Priority == PriorityType.Low).
               ThenBy(bug => bug.Severity == SeverityType.Critical).
               ThenBy(bug => bug.Severity == SeverityType.Major).
               ThenBy(bug => bug.Severity == SeverityType.Minor).
               ToList();

                foreach (Bug bug in bugsFixed)
                {
                    stringBuilder.Append(bug);
                    StringGenerator('*', 15);
                }

            }
            else if(filterByCommand == "Assignee")
            {
                List<Bug> bugsAssign = task.
               Where(bug => bug.Assignee.IsAssignedToATeam).
               OrderBy(bug => bug.Title).
               ThenBy(bug => bug.Priority == PriorityType.High).
               ThenBy(bug => bug.Priority == PriorityType.Medium).
               ThenBy(bug => bug.Priority == PriorityType.Low).
               ThenBy(bug => bug.Severity == SeverityType.Critical).
               ThenBy(bug => bug.Severity == SeverityType.Major).
               ThenBy(bug => bug.Severity == SeverityType.Minor).
               ToList();

                foreach (Bug bug in bugsAssign)
                {
                    stringBuilder.Append(bug);
                    StringGenerator('*', 15);
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
