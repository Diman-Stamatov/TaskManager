using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Enums;
using TaskManager.Models;
using TaskManager.Models.Contracts;
using TaskManager.Exceptions;

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
                List<Bug> bugsActive = null;
                switch (sortByCommand)
                {
                    case "SortedTitle":
                    bugsActive = task.
                    Where(bug => bug.Status == BugStatusType.Active).
                    OrderBy(bug => bug.Title).ToList();;
                        break;
                    case "SortedPriority":
                    bugsActive = task.
                    Where(bug => bug.Status == BugStatusType.Active).
                    OrderBy(bug => bug.Priority == PriorityType.High).
                    ThenBy(bug => bug.Priority == PriorityType.Medium)
                    .ToList();
                        break;
                    case "SortedSeverity":
                        bugsActive = task.
                    Where(bug => bug.Status == BugStatusType.Active).
                    OrderBy(bug => bug.Severity == SeverityType.Critical).
                    ThenBy(bug => bug.Severity == SeverityType.Major).
                    ToList();
                        break;
                    default:
                    throw new InvalidUserInputException("The input sort command is incorrect!");
                }

                if (bugsActive.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged bugs correspond to your search parameters!");
                }

                foreach (Bug bug in bugsActive)
                {
                    stringBuilder.AppendLine(bug.ToString());
                    stringBuilder.AppendLine(StringGenerator('*', 15));
                }
            }
            else if (filterByCommand == "FilterFixed")
            {
                List<Bug> bugsFixed = null;
                switch (sortByCommand)
                {
                    case "SortedTitle":
                        bugsFixed = task.
                        Where(bug => bug.Status == BugStatusType.Fixed).
                        OrderBy(bug => bug.Title).ToList(); ;
                        break;
                    case "SortedPriority":
                        bugsFixed = task.
                        Where(bug => bug.Status == BugStatusType.Fixed).
                        OrderBy(bug => bug.Priority == PriorityType.High).
                        ThenBy(bug => bug.Priority == PriorityType.Medium).
                        ThenBy(bug => bug.Priority == PriorityType.Low).ToList();
                        break;
                    case "SortedSeverity":
                        bugsFixed = task.
                        Where(bug => bug.Status == BugStatusType.Fixed).
                        OrderBy(bug => bug.Severity == SeverityType.Critical).
                        ThenBy(bug => bug.Severity == SeverityType.Major).
                        ThenBy(bug => bug.Severity == SeverityType.Minor).
                        ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input sort command is incorrect!");
                }

                if (bugsFixed.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged bugs correspond to your search parameters!");
                }

                foreach (Bug bug in bugsFixed)
                {
                    stringBuilder.AppendLine(bug.ToString());
                    stringBuilder.AppendLine(StringGenerator('*', 15));
                }


            }
            else if(filterByCommand == "FilterAssignee")
            {
                List<Bug> bugsAssignee = null;
                switch (sortByCommand)
                {
                    case "SortedTitle":
                        bugsAssignee = task.
                        Where(bug => bug.Assignee != null).
                        OrderBy(bug => bug.Title).ToList(); ;
                        break;
                    case "SortedPriority":
                        bugsAssignee = task.
                        Where(bug => bug.Assignee != null).
                        OrderBy(bug => bug.Priority == PriorityType.High).
                        ThenBy(bug => bug.Priority == PriorityType.Medium).
                        ToList();
                        break;
                    case "SortedSeverity":
                        bugsAssignee = task.
                        Where(bug => bug.Assignee != null).
                        OrderBy(bug => bug.Severity == SeverityType.Critical).
                        ThenBy(bug => bug.Severity == SeverityType.Major).
                        ToList();
                        break;
                    default:                    
                        throw new InvalidUserInputException("The input sort command is incorrect!");
                }

                if (bugsAssignee.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged bugs correspond to your search parameters!");
                }

                foreach (Bug bug in bugsAssignee)
                {
                    stringBuilder.AppendLine(bug.ToString());
                    stringBuilder.AppendLine(StringGenerator('*', 15));
                }
            }
            else
            {
                throw new InvalidUserInputException("The input filter command is incorrect!");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
