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
        public const int ExpectedNumberOfArguments = 1;

        public ListFeedbackCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            string command = CommandParameters[0];
            var task = Repository.Tasks.OfType<Feedback>().ToList();
            StringBuilder stringBuilder = new StringBuilder();

            if (command == "New")
            {
                List<Feedback> feedbackNew = task.
               Where(feedback => feedback.Status == FeedbackStatusType.New).
               OrderBy(story => story.Title).
               ThenBy(story => story.Rating).
               ToList();

                foreach (Feedback bug in feedbackNew)
                {
                    stringBuilder.Append(bug);
                    StringGenerator('*', 15);
                }
            }
            else if (command == "Unscheduled")
            {
                List<Feedback> feedbackUnscheduled = task.
               Where(feedback => feedback.Status == FeedbackStatusType.Unscheduled).
               OrderBy(story => story.Title).
               ThenBy(story => story.Rating).
               ToList();

                foreach (Feedback bug in feedbackUnscheduled)
                {
                    stringBuilder.Append(bug);
                    StringGenerator('*', 15);
                }

            }
            else if (command == "Scheduled")
            {
                List<Feedback> feedbackScheduled = task.
               Where(feedback => feedback.Status == FeedbackStatusType.Scheduled).
               OrderBy(story => story.Title).
               ThenBy(story => story.Rating).
               ToList();

                foreach (Feedback bug in feedbackScheduled)
                {
                    stringBuilder.Append(bug);
                    StringGenerator('*', 15);
                }
            }
            else if (command == "Done")
            {
                List<Feedback> feedbackDone = task.
               Where(feedback => feedback.Status == FeedbackStatusType.Done).
               OrderBy(story => story.Title).
               ThenBy(story => story.Rating).
               ToList();

                foreach (Feedback bug in feedbackDone)
                {
                    stringBuilder.Append(bug);
                    StringGenerator('*', 15);
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
