using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Enums;

namespace TaskManager.Commands
{
    public class CreateFeedbackCommand : BaseCommand
    {
        public const int MinimumNumberOfArguments = 3;

        public CreateFeedbackCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            int numberOfArguments = CommandParameters.Count;
            ValidateArgumentsCount(numberOfArguments, MinimumNumberOfArguments);

            string title = CommandParameters[0];
            CommandParameters.RemoveAt(0);
            int lastIndex = CommandParameters.Count - 1;
            int rating = ParseIntParameter(CommandParameters[lastIndex], "Rating");
            CommandParameters.RemoveAt(lastIndex);
            string description = string.Join(" ", CommandParameters);
           
            return CreateFeedback(title, description, rating);
        }
        public string CreateFeedback(string title, string description, int rating)
        {
            var newFeedback = Repository.CreateFeedback(title, description, rating);
            return $"Feedback with name {title} was successfully created";
        }
    }
}
