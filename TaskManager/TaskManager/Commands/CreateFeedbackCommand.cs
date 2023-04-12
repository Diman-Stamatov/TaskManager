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
        public const int ExpectedNumberOfArguments = 0;
        //Трябва да решим, колко параметъра ще приема тази команда

        public CreateFeedbackCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);
            int id = ParseIntParameter(CommandParameters[0], "ID");
            string title = CommandParameters[1];
            string description = CommandParameters[2];
            int rating = ParseIntParameter(CommandParameters[3], "Rating");
            return CreateFeedback(id, title, description, rating);
        }
        public string CreateFeedback(int id, string title, string description, int rating)
        {
            var newFeedback = new Feedback(id, title, description, rating);
            return $"Feedback with name {title} was successfully created";
        }
    }
}
