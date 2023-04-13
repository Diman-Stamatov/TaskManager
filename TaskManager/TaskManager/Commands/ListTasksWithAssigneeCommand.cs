using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
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
                    tasksTypeBug.
                    Where(bug => bug.Status == BugStatusType.Active).
                    OrderBy(bug => bug.Title).
                    ToList();

                    foreach(var bug in tasksTypeBug)
                    {
                        taskDisplay.Append(bug);
                    }
                    break;               
                case "Fixed":
                    tasksTypeBug.
                    Where(bug => bug.Status == BugStatusType.Fixed).
                    OrderBy(bug => bug.Title).
                    ToList();

                    foreach (var bug in tasksTypeBug)
                    {
                        taskDisplay.Append(bug);
                    }
                    break;               
                case "NotDone":
                    tasksTypeStory.
                    Where(story => story.Status == StoryStatusType.NotDone).
                    OrderBy(story => story.Title).
                    ToList();

                    foreach (var story in tasksTypeStory)
                    {
                        taskDisplay.Append(story);
                    }
                    break;                
                case "InProgres":
                    tasksTypeStory.
                    Where(story => story.Status == StoryStatusType.InProgress).
                    OrderBy(story => story.Title).
                    ToList();

                    foreach (var story in tasksTypeStory)
                    {
                        taskDisplay.Append(story);
                    }
                    break;               
                case "Done":
                    tasksTypeStory.
                    Where(story => story.Status == StoryStatusType.Done).
                    OrderBy(story => story.Title).
                    ToList();

                    foreach (var story in tasksTypeStory)
                    {
                        taskDisplay.Append(story);
                    }
                    break;                
                default:
                    tasksTypeBug.
                    Where(bug => bug.Assignee.Name == comand).
                    OrderBy(bug => bug.Title).
                    ToList();

                    tasksTypeStory.
                    Where(story => story.Assignee.Name == comand).
                    OrderBy(story => story.Title).
                    ToList();
                    break;
            }

            return "";
        }
    }
}
