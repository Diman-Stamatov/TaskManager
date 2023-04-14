using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Core;

namespace TaskManager.Commands
{
    internal class AddStepToReproduceCommand:BaseCommand
    {
        public const int MinimumNumberOfArguments = 2;


        public AddStepToReproduceCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            int numberOfArguments = CommandParameters.Count;
            ValidateArgumentsCount(numberOfArguments, MinimumNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            CommandParameters.RemoveAt(0);
            string stepToReproduce = string.Join(" ", CommandParameters);          

            return AddStepToReproduce(taskId, stepToReproduce);
        }

        private string AddStepToReproduce(int id, string stepToReproduce)
        {
            var foundTask = Repository.GetTask(id);
            if (foundTask.GetType() == typeof(IBug))
            {
                var foundBug = (IBug)foundTask;
                foundBug.AddStepToReproduce(stepToReproduce);
            }
            else
            {
                string errorMessage = $"Task ID number {id} is not a Bug!";
                throw new InvalidUserInputException(errorMessage);
            }

            return $"Successfully added a step for reproducing Bug ID number {id}.";
        }
    }
}
