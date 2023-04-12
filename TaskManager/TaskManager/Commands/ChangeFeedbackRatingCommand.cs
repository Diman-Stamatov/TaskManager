using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    internal class ChangeFeedbackRatingCommand :BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;        
        public const string ExpectedTaskTypeName = "Feedback";        
        public ChangeFeedbackRatingCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            int rating = ParseIntParameter(CommandParameters[1], "Rating");            

            return ChangeFeedbackRating(taskId, rating);
        }

        private string ChangeFeedbackRating(int id, int rating)
        {
            var foundTask = Repository.GetTask(id);
            if (foundTask is IFeedback == false)
            {
                string errorMessage = $"The specified task is not a {ExpectedTaskTypeName}!";
                throw new InvalidUserInputException(errorMessage);
            }
            var foundFeedback = (IFeedback)foundTask;
            foundFeedback.Rating = rating;

            return $"Successfully changed the rating of Feedback ID number {id} to {rating}.";
        }
    }
}
