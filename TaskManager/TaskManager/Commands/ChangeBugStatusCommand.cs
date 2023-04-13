using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class ChangeBugStatusCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;        
        public const string ExpectedAdvanceParameter = "advance";
        public const string ExpectedTaskTypeName = "Bug";
        public const string ManipulatedPropertyName = "Status";
        public ChangeBugStatusCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            string changeDirection = CommandParameters[1].ToLower();
            ValidateEnumChangeInput(changeDirection);

            return ChangeBugStatus(taskId, changeDirection);
        }

        private string ChangeBugStatus(int id, string changeDirection)
        {
            var foundTask = Repository.GetTask(id);
            if (foundTask is IBug == false)
            {
                string errorMessage = $"The specified task is not a {ExpectedTaskTypeName}!";
                throw new InvalidUserInputException(errorMessage);
            }
            var foundBug = (IBug)foundTask;
            string className = ExpectedTaskTypeName;
            if (foundBug.Assignee == null)
            {
                string errorMessage = $"The specified {className} has to be assigned to someone first!";
                throw new InvalidUserInputException(errorMessage);
            }
            var type = foundBug.GetType();
            int currentValue = (int)foundBug.Status;
            string propertyName = ManipulatedPropertyName;
            var taskAssignee = foundBug.Assignee;
            string assigneeName = taskAssignee.Name;

            string commandMessage;
            if (changeDirection == ExpectedAdvanceParameter)
            {
                foundBug.AdvanceStatus();
                commandMessage = GenerateAdvanceMethodMessage(type, currentValue, propertyName, className, id, assigneeName);
            }
            else
            {
                foundBug.RevertStatus();
                commandMessage = GenerateRevertMethodMessage(type, currentValue, propertyName, className, id, assigneeName);
            }
            
            taskAssignee.Log(commandMessage);
            return commandMessage;
        }
    }
}
