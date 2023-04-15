using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Enums;

namespace TaskManager.Commands
{
    public class ListStoriesCommand:BaseCommand
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
                        OrderByDescending(story => story.Priority).
                        ToList();
                        break;
                    case "SortedSize":
                        storyNotDone = task.
                        Where(story => story.Status == StoryStatusType.NotDone).
                        OrderByDescending(story => story.Size).
                        ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input sort command is incorrect!");
                }

                if (storyNotDone.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged stories correspond to your search parameters!");
                }

                foreach (Story story in storyNotDone)
                {
                    stringBuilder.AppendLine(story.ToString());
                    stringBuilder.AppendLine(StringGenerator('*', 15));
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
                        OrderByDescending(story => story.Priority).ToList();
                        break;
                    case "SortedSize":
                        storyInProgress = task.
                        Where(story => story.Status == StoryStatusType.InProgress).
                        OrderByDescending(story => story.Size).
                        ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input sort command is incorrect!");
                }

                if (storyInProgress.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged stories correspond to your search parameters!");
                }

                foreach (Story story in storyInProgress)
                {
                    stringBuilder.AppendLine(story.ToString());
                    stringBuilder.AppendLine(StringGenerator('*', 15));
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
                        OrderByDescending(story => story.Priority).ToList();
                        break;
                    case "SortedSize":
                        storyDone = task.
                        Where(story => story.Status == StoryStatusType.Done).
                        OrderByDescending(story => story.Size).
                        ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input sort command is incorrect!");
                }

                if (storyDone.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged stories correspond to your search parameters!");
                }

                foreach (Story story in storyDone)
                {
                    stringBuilder.AppendLine(story.ToString());
                    stringBuilder.AppendLine(StringGenerator('*', 15));
                }

            }
            else if (filterByCommand == "FilterAssignee")
            {
                List<Story> storyAssignee = null;
                switch (sortByCommand)
                {
                    case "SortedTitle":
                        storyAssignee = task.
                        Where(story => story.Assignee != null).
                        OrderBy(story => story.Title).ToList(); ;
                        break;
                    case "SortedPriority":
                        storyAssignee = task.
                        Where(story => story.Assignee != null).
                        OrderByDescending(story => story.Priority).
                        ToList();
                        break;
                    case "SortedSize":
                        storyAssignee = task.
                        Where(story => story.Assignee != null).
                        OrderByDescending(story => story.Size).
                        ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input sort command is incorrect!");
                }

                if (storyAssignee.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged stories correspond to your search parameters!");
                }

                foreach (Story story in storyAssignee)
                {
                    stringBuilder.AppendLine(story.ToString());
                    stringBuilder.AppendLine( StringGenerator('*', 15));
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
