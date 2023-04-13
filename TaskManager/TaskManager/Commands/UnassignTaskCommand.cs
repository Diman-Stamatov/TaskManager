using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    internal class UnassignTaskCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;

        public UnassignTaskCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");          

            return UnassignTask(taskId);
        }

        private string UnassignTask(int taskId)
        {
            
            
            ITask foundTask = Repository.GetTask(taskId);
            string successMessage = "{0} ID number {1} was unassigned from {2}.";
            string taskTypeName;
            string assigneeName;            
            if (foundTask.GetType() == typeof(Feedback))
            {
                string errorMessage = "A Feedback cannot have an assignee!";
                throw new InvalidUserInputException(errorMessage);
            }
            else if (foundTask.GetType() == typeof(Bug))
            {
                IBug foundBug = (IBug)foundTask;
                int id = foundBug.Id;
                taskTypeName = foundBug.GetType().Name;
                assigneeName = foundBug.Assignee.Name;
                successMessage = string.Format(successMessage, taskTypeName, id, assigneeName);
                foundBug.Unassign();                            
            }
            else
            {
                IStory foundStory = (IStory)foundTask;
                int id = foundStory.Id;
                taskTypeName = foundStory.GetType().Name;
                assigneeName = foundStory.Assignee.Name;
                successMessage = string.Format(successMessage, taskTypeName, id, assigneeName);
                foundStory.Unassign();
            }

            return successMessage;

        }
    }
}
