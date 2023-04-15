using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models;
using TaskManager.Models.Enums;

namespace TaskManager.Commands
{
    public class ListStoriesCommand : BaseCommand
    {
        public const int MinimumNumberOfArguments = 1;

        public ListStoriesCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            int argumentsCount = CommandParameters.Count;
            ValidateArgumentsCount(argumentsCount, MinimumNumberOfArguments);

            var stories = Repository.Tasks.OfType<Story>().ToList();
            StringBuilder stringBuilder = new StringBuilder();

            for (int index = 0; index < argumentsCount; index++)
            {
                string command = CommandParameters[index];
                switch (command)
                {
                    case "SortByTitle":
                        stories = stories.
                        OrderBy(story => story.Title).ToList(); ;
                        break;
                    case "SortByPriority":
                        stories = stories.
                        OrderByDescending(story => story.Priority).
                        ToList();
                        break;
                    case "SortBySize":
                        stories = stories.
                        OrderByDescending(story => story.Size).
                        ToList();
                        break;
                    case "FilterNotDone":
                        stories = stories.
                         Where(story => story.Status == StoryStatusType.NotDone).
                        ToList();
                        break;
                    case "FilterInProgress":
                        stories = stories.
                         Where(story => story.Status == StoryStatusType.InProgress).
                        ToList();
                        break;
                    case "FilterDone":
                        stories = stories.
                         Where(story => story.Status == StoryStatusType.Done).
                        ToList();
                        break;
                    case "FilterAssigned":
                        stories = stories.
                    Where(story => story.Assignee != null).ToList();
                        break;
                    case "FilterUnassigned":
                        stories = stories.
                    Where(story => story.Assignee == null).ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input sort command is incorrect!");
                }

                if (stories.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged stories correspond to your search parameters!");
                }

                foreach (Story story in stories)
                {
                    stringBuilder.AppendLine(story.ToString());
                    stringBuilder.AppendLine(GenerateString('*', 15));
                }
            }
            return stringBuilder.ToString().Trim();
        }
    }
}

