using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;

namespace TaskManager.Commands
{
    public class ListTasksWithAssigneeCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;

        public ListTasksWithAssigneeCommand(IList<string> commandParameters, IRepository repository)
             : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            string comand = CommandParameters[0];
            StringBuilder taskDisplay = new StringBuilder();
            var tasksTypeBug = Repository.Tasks.OfType<Bug>().ToList();
            var tasksTypeStory = Repository.Tasks.OfType<Story>().ToList();
            switch (comand)
            {
                case "Active":
                    tasksTypeBug = tasksTypeBug.
                    Where(bug => bug.Status == BugStatusType.Active && bug.Assignee.TeamAssignedTo != null).
                    OrderBy(bug => bug.Title).
                    ToList();

                    foreach(var bug in tasksTypeBug)
                    {
                        taskDisplay.Append(bug);
                    }
                    break;               
                case "Fixed":
                    tasksTypeBug = tasksTypeBug.
                    Where(bug => bug.Status == BugStatusType.Fixed && bug.Assignee.TeamAssignedTo != null).
                    OrderBy(bug => bug.Title).
                    ToList();

                    foreach (var bug in tasksTypeBug)
                    {
                        taskDisplay.Append(bug);
                    }
                    break;               
                case "NotDone":
                    tasksTypeStory = tasksTypeStory.
                    Where(story => story.Status == StoryStatusType.NotDone && story.Assignee.TeamAssignedTo != null).
                    OrderBy(story => story.Title).
                    ToList();

                    foreach (var story in tasksTypeStory)
                    {
                        taskDisplay.Append(story);
                    }
                    break;                
                case "InProgres":
                    tasksTypeStory = tasksTypeStory.
                    Where(story => story.Status == StoryStatusType.InProgress && story.Assignee.TeamAssignedTo != null).
                    OrderBy(story => story.Title).
                    ToList();

                    foreach (var story in tasksTypeStory)
                    {
                        taskDisplay.Append(story);
                    }
                    break;               
                case "Done":
                    tasksTypeStory = tasksTypeStory.
                    Where(story => story.Status == StoryStatusType.Done && story.Assignee.TeamAssignedTo != null).
                    OrderBy(story => story.Title).
                    ToList();

                    foreach (var story in tasksTypeStory)
                    {
                        taskDisplay.Append(story);
                    }
                    break;                
                default:
                    tasksTypeBug = tasksTypeBug.
                    Where(bug => bug.Assignee.Name == comand && bug.Assignee.TeamAssignedTo != null).
                    OrderBy(bug => bug.Title).
                    ToList();

                    tasksTypeStory = tasksTypeStory.
                    Where(story => story.Assignee.Name == comand && story.Assignee.TeamAssignedTo != null).
                    OrderBy(story => story.Title).
                    ToList();

                    foreach(var story in tasksTypeStory)
                    {
                        taskDisplay.Append(story);
                    }

                    foreach(var bug in tasksTypeBug)
                    {
                        taskDisplay.Append(bug);
                    }

                    break;
            }

            if (taskDisplay.Length == 0)
            {
                throw new InvalidUserInputException("There is no information that meets the conditions!");
            }

            return taskDisplay.ToString().Trim();
        }
    }
}
