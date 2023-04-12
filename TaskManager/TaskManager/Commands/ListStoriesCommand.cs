using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Enums;

namespace TaskManager.Commands
{
    internal class ListStoriesCommand:BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;

        public ListStoriesCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            string command = CommandParameters[0];
            var task = Repository.Tasks.OfType<Story>().ToList();
            StringBuilder stringBuilder = new StringBuilder();

            if (command == "NotDone")
            {
                List<Story> storyActive = task.
               Where(story => story.Status == StoryStatusType.NotDone).
               OrderBy(story => story.Title).
               ThenBy(bug => bug.Priority == PriorityType.High).
               ThenBy(story => story.Priority == PriorityType.Medium).
               ThenBy(story => story.Priority == PriorityType.Low).
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
            else if (command == "Fixed")
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
            else if (command == "Assignee")
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
