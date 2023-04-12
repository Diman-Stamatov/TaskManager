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
        public const string ExpectedRevertParameter = "revert";
        public const string ExpectedAdvanceParameter = "advance";
        public ChangeBugSeverityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            string changeDirection = CommandParameters[1].ToLower();
            if (changeDirection != ExpectedAdvanceParameter && changeDirection != ExpectedRevertParameter)
            {
                string errorMessage = $"Please choose either the {ExpectedRevertParameter} " +
                    $"or {ExpectedAdvanceParameter} clarification for this command!";
                throw new InvalidUserInputException(errorMessage);
            }

            return ChangeBugSeverity(taskId, changeDirection);
        }

        private string ChangeBugSeverity(int id, string changeDirection)
        {
            var foundTask = (IBug)Repository.GetTask(id);
            var type = foundTask.GetType();
            int currentValue = (int)foundTask.Severity;
            string propertyName = "Severity";
            string className = foundTask.GetType().Name;

            string commandMessage;
            if (changeDirection == ExpectedAdvanceParameter)
            {
                foundTask.AdvanceSeverity();
                commandMessage = GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, id);
            }
            else
            {
                foundTask.RevertSeverity();
                commandMessage = GenerateRevertMethodMessage(type, currentValue, propertyName, className, id);
            }

            return commandMessage;
        }
    }
}
