using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Enums;

namespace TaskManager.Commands
{
    public class ListFeedbackCommand : BaseCommand
    {
        public const int MinimumNumberOfArguments = 1;

        public ListFeedbackCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            int argumentsCount = CommandParameters.Count;
            ValidateArgumentsCount(argumentsCount, MinimumNumberOfArguments);
            
            var feedbacks = Repository.Tasks.OfType<Feedback>().ToList();
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < argumentsCount; index++)
            {
                string command = CommandParameters[index];
                switch (command)
                {
                    case "SortByTitle":
                        feedbacks = feedbacks.
                        OrderBy(feedback => feedback.Title).ToList();
                        break;
                    case "SortByRating":
                        feedbacks = feedbacks.                        
                        OrderByDescending(feedback => feedback.Rating).
                        ToList();
                        break;
                    case "FilterNew":
                        feedbacks = feedbacks.
                        Where(feedback => feedback.Status == FeedbackStatusType.New).
                        ToList();
                        break;
                    case "FilterUnscheduled":
                        feedbacks = feedbacks.
                        Where(feedback => feedback.Status == FeedbackStatusType.Unscheduled).
                        ToList();
                        break;
                    case "FilterScheduled":
                        feedbacks = feedbacks.
                        Where(feedback => feedback.Status == FeedbackStatusType.Scheduled).
                        ToList();
                        break;
                    case "FilterDone":
                        feedbacks = feedbacks.
                        Where(feedback => feedback.Status == FeedbackStatusType.Done).
                        ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input command was incorrect!");
                }

            }

            if (feedbacks.Count == 0)
            {
                throw new InvalidUserInputException("None of the logged feedback correspond to your search parameters!");
            }

            foreach (Feedback feedback in feedbacks)
            {
                stringBuilder.AppendLine(feedback.ToString());
                stringBuilder.AppendLine(GenerateString('*', 15));
            }

            return stringBuilder.ToString().Trim();
        }
            
    }
}
