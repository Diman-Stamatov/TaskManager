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
        public const int ExpectedNumberOfArguments = 2;

        public ListStoriesCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            string filterByCommand = CommandParameters[0];
            string sortByCommand = CommandParameters[1];
            var task = Repository.Tasks.OfType<Story>().ToList();
            StringBuilder stringBuilder = new StringBuilder();

            if (filterByCommand == "FilterNotDone")
            {
                List<Story> storyNotDone = null;
                switch (sortByCommand)
                {
                    case "SortedTitle":
                        storyNotDone = task.
                        Where(story => story.Status == StoryStatusType.NotDone).
                        OrderBy(story => story.Title).ToList(); ;
                        break;
                    case "SortedPriority":
                        storyNotDone = task.
                        Where(story => story.Status == StoryStatusType.NotDone).
                        OrderBy(story => story.Priority == PriorityType.High).
                        ThenBy(story => story.Priority == PriorityType.Medium).
                        ThenBy(story => story.Priority == PriorityType.Low).ToList();
                        break;
                    case "SortedSize":
                        storyNotDone = task.
                        Where(story => story.Status == StoryStatusType.NotDone).
                        OrderBy(story => story.Size == SizeType.Large).
                        ThenBy(story => story.Size == SizeType.Medium).
                        ThenBy(story => story.Size == SizeType.Small).
                        ToList();
                        break;
                }

                if (storyNotDone == null)
                {
                    throw new InvalidUserInputException("The filtering or sorting commands are incorrect.");
                }

                foreach (Story bug in storyNotDone)
                {
                    stringBuilder.Append(bug);
                    GenerateString('*', 15);
                }
            }
            else if (filterByCommand == "FilterInProgress")
            {
                List<Story> storyInProgress = null;
                switch (sortByCommand)
                {
                    case "SortedTitle":
                        storyInProgress = task.
                        Where(story => story.Status == StoryStatusType.InProgress).
                        OrderBy(story => story.Title).ToList(); ;
                        break;
                    case "SortedPriority":
                        storyInProgress = task.
                        Where(story => story.Status == StoryStatusType.InProgress).
                        OrderBy(story => story.Priority == PriorityType.High).
                        ThenBy(story => story.Priority == PriorityType.Medium).
                        ThenBy(story => story.Priority == PriorityType.Low).ToList();
                        break;
                    case "SortedSize":
                        storyInProgress = task.
                        Where(story => story.Status == StoryStatusType.InProgress).
                        OrderBy(story => story.Size == SizeType.Large).
                        ThenBy(story => story.Size == SizeType.Medium).
                        ThenBy(story => story.Size == SizeType.Small).
                        ToList();
                        break;
                }

                if (storyInProgress == null)
                {
                    throw new InvalidUserInputException("The filtering or sorting commands are incorrect.");
                }

                foreach (Story bug in storyInProgress)
                {
                    stringBuilder.Append(bug);
                    GenerateString('*', 15);
                }

            }
            else if (filterByCommand == "FilterDone")
            {
                List<Story> storyDone = null;
                switch (sortByCommand)
                {
                    case "SortedTitle":
                        storyDone = task.
                        Where(story => story.Status == StoryStatusType.Done).
                        OrderBy(story => story.Title).ToList(); ;
                        break;
                    case "SortedPriority":
                        storyDone = task.
                        Where(story => story.Status == StoryStatusType.Done).
                        OrderBy(story => story.Priority == PriorityType.High).
                        ThenBy(story => story.Priority == PriorityType.Medium).
                        ThenBy(story => story.Priority == PriorityType.Low).ToList();
                        break;
                    case "SortedSize":
                        storyDone = task.
                        Where(story => story.Status == StoryStatusType.Done).
                        OrderBy(story => story.Size == SizeType.Large).
                        ThenBy(story => story.Size == SizeType.Medium).
                        ThenBy(story => story.Size == SizeType.Small).
                        ToList();
                        break;
                }

                if (storyDone == null)
                {
                    throw new InvalidUserInputException("The filtering or sorting commands are incorrect.");
                }

                foreach (Story bug in storyDone)
                {
                    stringBuilder.Append(bug);
                    GenerateString('*', 15);
                }

            }
            else if (filterByCommand == "FilterAssignee")
            {
                List<Story> storyAssignee = null;
                switch (sortByCommand)
                {
                    case "SortedTitle":
                        storyAssignee = task.
                        Where(story => story.Assignee.TeamAssignedTo != null).
                        OrderBy(story => story.Title).ToList(); ;
                        break;
                    case "SortedPriority":
                        storyAssignee = task.
                        Where(story => story.Assignee.TeamAssignedTo != null).
                        OrderBy(story => story.Priority == PriorityType.High).
                        ThenBy(story => story.Priority == PriorityType.Medium).
                        ThenBy(story => story.Priority == PriorityType.Low).ToList();
                        break;
                    case "SortedSize":
                        storyAssignee = task.
                        Where(story => story.Assignee.TeamAssignedTo != null).
                        OrderBy(story => story.Size == SizeType.Large).
                        ThenBy(story => story.Size == SizeType.Medium).
                        ThenBy(story => story.Size == SizeType.Small).
                        ToList();
                        break;
                }

                if (storyAssignee == null)
                {
                    throw new InvalidUserInputException("The filtering or sorting commands are incorrect.");
                }

                foreach (Story bug in storyAssignee)
                {
                    stringBuilder.Append(bug);
                    GenerateString('*', 15);
                }

            }

            return stringBuilder.ToString().Trim();
        }
    }
}
