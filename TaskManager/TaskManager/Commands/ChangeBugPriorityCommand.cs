using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    internal class ChangeBugPriorityCommand :BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public const string ExpectedAdvanceParameter = "advance";
        public const string ExpectedTaskTypeName = "Bug";
        public const string ManipulatedPropertyName = "Priority";
        public ChangeBugPriorityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            string changeDirection = CommandParameters[1].ToLower();
            ValidateEnumChangeInput(changeDirection);
            return ChangeBugPriority(taskId, changeDirection);
        }

        private string ChangeBugPriority(int id, string changeDirection)
        {
            var foundTask = Repository.GetTask(id);
            if (foundTask is IBug == false)
            {
                string errorMessage = $"The specified task is not a {ExpectedTaskTypeName}!";
                throw new InvalidUserInputException(errorMessage);
            }
            var foundBug = (IBug)foundTask;
            var type = foundBug.GetType();
            int currentValue = (int)foundBug.Priority;
            string propertyName = ManipulatedPropertyName;
            string className = ExpectedTaskTypeName;            

            string commandMessage;
            if (changeDirection == ExpectedAdvanceParameter)
            {
                foundBug.AdvancePriority();
                commandMessage = GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, id);
            }
            else
            {
                foundBug.RevertPriority();
                commandMessage = GenerateRevertMethodMessage(type, currentValue, propertyName, className, id);
            }            
            
            return commandMessage;
        }
    }
}
