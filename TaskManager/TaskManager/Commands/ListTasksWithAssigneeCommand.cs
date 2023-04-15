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
                    Where(bug => bug.Status == BugStatusType.Active && bug.Assignee != null).
                    OrderBy(bug => bug.Title).
                    ToList();

                    foreach(var bug in tasksTypeBug)
                    {
                        taskDisplay.AppendLine(bug.ToString());
                        taskDisplay.AppendLine(GenerateString('*', 15));
                    }
                    break;               
                case "Fixed":
                    tasksTypeBug = tasksTypeBug.
                    Where(bug => bug.Status == BugStatusType.Fixed && bug.Assignee != null).
                    OrderBy(bug => bug.Title).
                    ToList();

                    foreach (var bug in tasksTypeBug)
                    {
                        taskDisplay.AppendLine(bug.ToString());
                        taskDisplay.AppendLine(GenerateString('*', 15));
                    }
                    break;               
                case "NotDone":
                    tasksTypeStory = tasksTypeStory.
                    Where(story => story.Status == StoryStatusType.NotDone && story.Assignee != null).
                    OrderBy(story => story.Title).
                    ToList();

                    foreach (var story in tasksTypeStory)
                    {
                        taskDisplay.AppendLine(story.ToString());
                        taskDisplay.AppendLine(GenerateString('*', 15));
                    }
                    break;                
                case "InProgres":
                    tasksTypeStory = tasksTypeStory.
                    Where(story => story.Status == StoryStatusType.InProgress && story.Assignee != null).
                    OrderBy(story => story.Title).
                    ToList();

                    foreach (var story in tasksTypeStory)
                    {
                        taskDisplay.AppendLine(story.ToString());
                        taskDisplay.AppendLine(GenerateString('*', 15));
                    }
                    break;               
                case "Done":
                    tasksTypeStory = tasksTypeStory.
                    Where(story => story.Status == StoryStatusType.Done && story.Assignee != null).
                    OrderBy(story => story.Title).
                    ToList();

                    foreach (var story in tasksTypeStory)
                    {
                        taskDisplay.AppendLine(story.ToString());
                        taskDisplay.AppendLine(GenerateString('*', 15));
                    }
                    break;                
                default:
                    tasksTypeBug = tasksTypeBug.
                    Where(bug => bug.Assignee != null && bug.Assignee.Name == comand).
                    OrderBy(bug => bug.Title).
                    ToList();

                    tasksTypeStory = tasksTypeStory.
                    Where(story => story.Assignee != null && story.Assignee.Name == comand).
                    OrderBy(story => story.Title).
                    ToList();

                    foreach(var story in tasksTypeStory)
                    {
                        taskDisplay.AppendLine(story.ToString());
                        taskDisplay.AppendLine(GenerateString('*', 15));
                    }

                    foreach(var bug in tasksTypeBug)
                    {
                        taskDisplay.AppendLine(bug.ToString());
                        taskDisplay.AppendLine(GenerateString('*', 15));
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
