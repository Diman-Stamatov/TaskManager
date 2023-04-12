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
                List<Story> storyNotDone = task.
               Where(story => story.Status == StoryStatusType.NotDone).
               OrderBy(story => story.Title).
               ThenBy(bug => bug.Priority == PriorityType.High).
               ThenBy(story => story.Priority == PriorityType.Medium).
               ThenBy(story => story.Priority == PriorityType.Low).
               ThenBy(story => story.Size == SizeType.Large).
               ThenBy(story => story.Size == SizeType.Medium).
               ThenBy(story => story.Size == SizeType.Small).
               ToList();

                foreach (Story bug in storyNotDone)
                {
                    stringBuilder.Append(bug);
                    StringGenerator('*', 15);
                }
            }
            else if (command == "InProgress")
            {
                List<Story> storyInProgress = task.
              Where(story => story.Status == StoryStatusType.InProgress).
              OrderBy(story => story.Title).
              ThenBy(story => story.Priority == PriorityType.High).
              ThenBy(story => story.Priority == PriorityType.Medium).
              ThenBy(story => story.Priority == PriorityType.Low).
              ThenBy(story => story.Size == SizeType.Large).
              ThenBy(story => story.Size == SizeType.Medium).
              ThenBy(story => story.Size == SizeType.Small).
              ToList();

                foreach (Story bug in storyInProgress)
                {
                    stringBuilder.Append(bug);
                    StringGenerator('*', 15);
                }

            }
            else if (command == "Done")
            {
                List<Story> storyDone = task.
               Where(story => story.Status == StoryStatusType.Done).
               OrderBy(story => story.Title).
               ThenBy(story => story.Priority == PriorityType.High).
               ThenBy(story => story.Priority == PriorityType.Medium).
               ThenBy(story => story.Priority == PriorityType.Low).
               ThenBy(story => story.Size == SizeType.Large).
               ThenBy(story => story.Size == SizeType.Medium).
               ThenBy(story => story.Size == SizeType.Small).
               ToList();

                foreach (Story bug in storyDone)
                {
                    stringBuilder.Append(bug);
                    StringGenerator('*', 15);
                }
            }
            else if (command == "Assignee")
            {
                List<Story> storyAssignee = task.
               Where(story => story.Assignee.IsAssignedToATeam).
               OrderBy(story => story.Title).
               ThenBy(story => story.Priority == PriorityType.High).
               ThenBy(story => story.Priority == PriorityType.Medium).
               ThenBy(story => story.Priority == PriorityType.Low).
               ThenBy(story => story.Size == SizeType.Large).
               ThenBy(story => story.Size == SizeType.Medium).
               ThenBy(story => story.Size == SizeType.Small).
               ToList();

                foreach (Story bug in storyAssignee)
                {
                    stringBuilder.Append(bug);
                    StringGenerator('*', 15);
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
