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
        public const int MinimumNumberOfArguments = 1;

        public ListBugsCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            int argumentsCount = CommandParameters.Count;
            ValidateArgumentsCount(argumentsCount, MinimumNumberOfArguments);
            

            
            var bugs = Repository.Tasks.OfType<Bug>().ToList();
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < argumentsCount; index++)
            {
                string command = CommandParameters[index];
                switch (command)
                {
                    case "SortByTitle":
                        bugs = bugs.                        
                        OrderBy(bug => bug.Title).ToList();
                        break;
                    case "SortByPriority":
                        bugs = bugs.                        
                        OrderByDescending(bug => bug.Priority)
                        .ToList();
                        break;
                    case "SortBySeverity":
                        bugs = bugs.                    
                    OrderByDescending(bug => bug.Severity).
                    ToList();
                        break;
                    case "FilterActive":
                        bugs = bugs.
                        Where(bug => bug.Status == BugStatusType.Active).ToList();
                        break;
                    case "FilterFixed":
                        bugs = bugs.
                        Where(bug => bug.Status == BugStatusType.Fixed).ToList();
                        break;
                    case "FilterAssigned":
                        bugs = bugs.
                    Where(bug => bug.Assignee != null).ToList();
                        break;
                    case "FilterUnassigned":
                        bugs = bugs.
                    Where(bug => bug.Assignee == null).ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input command was incorrect!");
                }
            }
            if (bugs.Count == 0)
            {
                throw new InvalidUserInputException("None of the logged bugs correspond to your search parameters!");
            }
            foreach (Bug bug in bugs)
            {
                stringBuilder.AppendLine(bug.ToString());
                stringBuilder.AppendLine(GenerateString('*', 15));
            }
            return stringBuilder.ToString().Trim();
        }

    }
}
