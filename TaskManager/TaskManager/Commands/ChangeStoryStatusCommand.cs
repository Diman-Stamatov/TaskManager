using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    internal class ChangeStoryStatusCommand:BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public const string ExpectedAdvanceParameter = "advance";
        public const string ExpectedTaskTypeName = "Story";
        public const string ManipulatedPropertyName = "Status";
        public ChangeStoryStatusCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            string changeDirection = CommandParameters[1].ToLower();
            ValidateEnumChangeInput(changeDirection);
            return ChangeStoryStatus(taskId, changeDirection);
        }

        private string ChangeStoryStatus(int id, string changeDirection)
        {
            var foundTask = Repository.GetTask(id);
            if (foundTask is IStory == false)
            {
                string errorMessage = $"The specified task is not a {ExpectedTaskTypeName}!";
                throw new InvalidUserInputException(errorMessage);
            }
            var foundStory = (IStory)foundTask;
            var type = foundStory.GetType();
            int currentValue = (int)foundStory.Status;
            string propertyName = ManipulatedPropertyName;
            string className = ExpectedTaskTypeName;

            string commandMessage;
            if (changeDirection == ExpectedAdvanceParameter)
            {
                foundStory.AdvanceStatus();
                commandMessage = GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, id);
            }
            else
            {
                foundStory.RevertStatus();
                commandMessage = GenerateRevertMethodMessage(type, currentValue, propertyName, className, id);
            }

            return commandMessage;
        }
    }
}
