using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Enums;

namespace TaskManager.Commands
{
    internal class ListFeedbackCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public ListFeedbackCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            string fulterByCommand = CommandParameters[0];
            string sortByCommand = CommandParameters[1];
            var task = Repository.Tasks.OfType<Feedback>().ToList();
            StringBuilder stringBuilder = new StringBuilder();

            if (fulterByCommand == "FilterNew")
            {
                List<Feedback> feedbackNew = null;

                switch (sortByCommand)
                {
                    case "SortedTitle":
                        feedbackNew = task.
                        Where(feedback => feedback.Status == FeedbackStatusType.New).
                        OrderBy(story => story.Title).ToList();
                        break;                   
                    case "SortedRating":
                        feedbackNew = task.
                        Where(feedback => feedback.Status == FeedbackStatusType.New).
                        OrderBy(story => story.Rating).
                        ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input sort command is incorrect!");

                }

                if (feedbackNew.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged bugs correspond to your search parameters!");
                }

                foreach (Feedback feedback in feedbackNew)
                {
                    stringBuilder.AppendLine(feedback.ToString());
                    stringBuilder.AppendLine(StringGenerator('*', 15));
                }
            }
            else if (fulterByCommand == "FilterUnscheduled")
            {
                List<Feedback> feedbackUnscheduled = null;

                switch (sortByCommand)
                {
                    case "SortedTitle":
                        feedbackUnscheduled = task.
                        Where(feedback => feedback.Status == FeedbackStatusType.Unscheduled).
                        OrderBy(story => story.Title).ToList();
                        break;
                    case "SortedRating":
                        feedbackUnscheduled = task.
                        Where(feedback => feedback.Status == FeedbackStatusType.Unscheduled).
                        OrderByDescending(story => story.Rating).
                        ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input sort command is incorrect!");

                }

                if (feedbackUnscheduled.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged bugs correspond to your search parameters!");
                }

                foreach (Feedback feedback in feedbackUnscheduled)
                {
                    stringBuilder.AppendLine(feedback.ToString());
                    stringBuilder.AppendLine(StringGenerator('*', 15));
                }

            }
            else if (fulterByCommand == "FilterScheduled")
            {
                List<Feedback> feedbackScheduled = null;

                switch (sortByCommand)
                {
                    case "SortedTitle":
                        feedbackScheduled = task.
                        Where(feedback => feedback.Status == FeedbackStatusType.Scheduled).
                        OrderBy(story => story.Title).ToList();
                        break;
                    case "SortedRating":
                        feedbackScheduled = task.
                        Where(feedback => feedback.Status == FeedbackStatusType.Scheduled).
                        OrderBy(story => story.Rating).
                        ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input sort command is incorrect!");

                }

                if (feedbackScheduled.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged bugs correspond to your search parameters!");
                }

                foreach (Feedback feedback in feedbackScheduled)
                {
                    stringBuilder.AppendLine(feedback.ToString());
                    stringBuilder.AppendLine(StringGenerator('*', 15));
                }

            }
            else if (fulterByCommand == "FilterDone")
            {

                List<Feedback> feedbackDone = null;

                switch (sortByCommand)
                {
                    case "SortedTitle":
                        feedbackDone = task.
                        Where(feedback => feedback.Status == FeedbackStatusType.Done).
                        OrderBy(story => story.Title).ToList();
                        break;
                    case "SortedRating":
                        feedbackDone = task.
                        Where(feedback => feedback.Status == FeedbackStatusType.Done).
                        OrderBy(story => story.Rating).
                        ToList();
                        break;
                    default:
                        throw new InvalidUserInputException("The input sort command is incorrect!");

                }

                if (feedbackDone.Count == 0)
                {
                    throw new InvalidUserInputException("None of the logged bugs correspond to your search parameters!");
                }

                foreach (Feedback feedback in feedbackDone)
                {
                    stringBuilder.AppendLine(feedback.ToString());
                    stringBuilder.AppendLine(StringGenerator('*', 15));
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
