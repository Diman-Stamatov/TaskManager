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
        public const string ExpectedRevertParameter = "revert";
        public const string ExpectedAdvanceParameter = "advance";
        public ChangeBugPriorityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            string changeDirection = CommandParameters[1].ToLower();
            if (changeDirection != "advance" && changeDirection != "revert")
            {
                string errorMessage = $"Please choose either the {ExpectedRevertParameter} " +
                    $"or {ExpectedAdvanceParameter} clarification for this command!";
                throw new InvalidUserInputException(errorMessage);
            }          

            return ChangeBugPriority(taskId, changeDirection);
        }

        private string ChangeBugPriority(int id, string changeDirection)
        {
            var foundTask = (IBug)Repository.GetTask(id);
            if (changeDirection == ExpectedAdvanceParameter)
            {
                foundTask.AdvancePriority();
            }
            else
            {
                foundTask.RevertPriority();
            }            

            return $"successfully added a comment to {foundTask.GetType().Name} ID number {id}.";
        }
    }
}
