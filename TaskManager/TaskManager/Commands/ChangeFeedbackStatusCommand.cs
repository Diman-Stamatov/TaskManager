using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Enums;

namespace TaskManager.Commands
{
    public class ChangeFeedbackStatusCommand :BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;        
        public const string ExpectedAdvanceParameter = "advance";
        public const string ExpectedTaskTypeName = "Feedback";
        public const string ManipulatedPropertyName = "Status";
        public ChangeFeedbackStatusCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            string changeDirection = CommandParameters[1].ToLower();
            ValidateEnumChangeInput(changeDirection);
            return ChangeFeedbackStatus(taskId, changeDirection);
        }

        private string ChangeFeedbackStatus(int id, string changeDirection)
        {
            var foundTask = Repository.GetTask(id);
            if (foundTask is IFeedback == false)
            {
                string errorMessage = $"The specified task is not a {ExpectedTaskTypeName}!";
                throw new InvalidUserInputException(errorMessage);
            }
            var foundFeedback = (IFeedback)foundTask;
            var type = typeof(FeedbackStatusType);
            int currentValue = (int)foundFeedback.Status;
            string propertyName = ManipulatedPropertyName;
            string className = ExpectedTaskTypeName;

            string commandMessage;
            if (changeDirection == ExpectedAdvanceParameter)
            {
                foundFeedback.AdvanceStatus();
                commandMessage = GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, id);
            }
            else
            {
                foundFeedback.RevertStatus();
                commandMessage = GenerateRevertMethodMessage(type, currentValue, propertyName, className, id);
            }

            return commandMessage;
        }
    }
}
