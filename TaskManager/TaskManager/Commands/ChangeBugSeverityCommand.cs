using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class ChangeBugSeverityCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;        
        public const string ExpectedAdvanceParameter = "advance";
        public const string ExpectedTaskTypeName = "Bug";
        public const string ManipulatedPropertyName = "Severity";
        public ChangeBugSeverityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            string changeDirection = CommandParameters[1].ToLower();
            ValidateEnumChangeInput(changeDirection);
            return ChangeBugSeverity(taskId, changeDirection);
        }

        private string ChangeBugSeverity(int id, string changeDirection)
        {
            var foundTask = Repository.GetTask(id);
            if (foundTask is IBug == false)
            {
                string errorMessage = $"The specified task is not a {ExpectedTaskTypeName}!";
                throw new InvalidUserInputException(errorMessage);
            }
            var foundBug = (IBug)foundTask;
            var type = foundBug.GetType();
            int currentValue = (int)foundBug.Severity;
            string propertyName = ManipulatedPropertyName;
            string className = ExpectedTaskTypeName;

            string commandMessage;
            if (changeDirection == ExpectedAdvanceParameter)
            {
                foundBug.AdvanceSeverity();
                commandMessage = GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, id);
            }
            else
            {
                foundBug.RevertSeverity();
                commandMessage = GenerateRevertMethodMessage(type, currentValue, propertyName, className, id);
            }

            return commandMessage;
        }
    }
}
