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

            return unassignTask(taskId);
        }

        private string unassignTask(int taskId)
        {
            
            string assigneeName;
            ITask foundTask = Repository.GetTask(taskId);
            string taskTypeName = foundTask.GetType().Name;
            string noAssigneeError = "The specified {0} hasn't been assigned yet!";
            if (foundTask.GetType() == typeof(Feedback))
            {
                string errorMessage = "A Feedback cannot have an assignee!";
                throw new InvalidUserInputException(errorMessage);
            }
            else if (foundTask.GetType() == typeof(Bug))
            {
                IBug foundBug = (IBug)foundTask;
                if (foundBug.Assignee == null)
                {
                    string errorMessage = string.Format(noAssigneeError, taskTypeName);
                    throw new InvalidUserInputException(errorMessage);
                }
                foundBug.Assignee.RemoveTask(foundBug);
              // foundBug.RemoveTask();                
            }
            else
            {
                IStory foundStory = (IStory)foundTask;
                assigneeName = foundStory.Assignee.Name;
                foundStory.Assignee = null;                
            }

            return "";

        }
    }
}
