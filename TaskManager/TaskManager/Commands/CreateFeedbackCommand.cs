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
        public const int ExpectedNumberOfArguments = 3;

        public CreateFeedbackCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);
            string title = CommandParameters[0];
            string description = CommandParameters[1];
            int rating = ParseIntParameter(CommandParameters[2], "Rating");
            return CreateFeedback(title, description, rating);
        }
        public string CreateFeedback(string title, string description, int rating)
        {
            var newFeedback = Repository.CreateFeedback(title, description, rating);
            return $"Feedback with name {title} was successfully created";
        }
    }
}
