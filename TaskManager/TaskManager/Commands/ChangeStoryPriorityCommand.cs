using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    internal class ChangeStoryPriorityCommand:BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;        
        public const string ExpectedAdvanceParameter = "advance";
        public const string ExpectedTaskTypeName = "Story";
        public const string ManipulatedPropertyName = "Priority";
        public ChangeStoryPriorityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            string changeDirection = CommandParameters[1].ToLower();
            ValidateEnumChangeInput(changeDirection);
            return ChangeStoryPriority(taskId, changeDirection);
        }

        private string ChangeStoryPriority(int id, string changeDirection)
        {
            var foundTask = Repository.GetTask(id);
            if (foundTask is IStory == false)
            {
                string errorMessage = $"The specified task is not a {ExpectedTaskTypeName}!";
                throw new InvalidUserInputException(errorMessage);
            }
            var foundStory = (IStory)foundTask;
            string className = ExpectedTaskTypeName;
            if (foundStory.Assignee == null)
            {
                string errorMessage = $"The specified {className} has to be assigned to someone first!";
                throw new InvalidUserInputException(errorMessage);
            }
            var type = foundStory.GetType();
            int currentValue = (int)foundStory.Priority;
            string propertyName = ManipulatedPropertyName;
            var taskAssignee = foundStory.Assignee;
            string assigneeName = taskAssignee.Name;
            string commandMessage;
            if (changeDirection == ExpectedAdvanceParameter)
            {
                foundStory.AdvancePriority();
                commandMessage = GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, id, assigneeName);
            }
            else
            {
                foundStory.RevertPriority();
                commandMessage = GenerateRevertMethodMessage(type, currentValue, propertyName, className, id, assigneeName);
            }

            taskAssignee.Log(commandMessage);
            return commandMessage;
        }
    }
}
