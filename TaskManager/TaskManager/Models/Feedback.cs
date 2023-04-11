using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;
using static TaskManager.Utilities.UtilityMethods;
using static TaskManager.Utilities.Validation;

namespace TaskManager.Models
{
    public class Feedback : Task, IFeedback
    {
        private const int RatingMinValue = 0;
        private const int RatingMaxValue = 10;
        private int rating;

        public Feedback(string title, string description, int rating)
            : base(title, description)
        {
            Rating = rating;
            Status =  FeedbackStatusType.New;
        }

        public int Rating 
        {
            get => rating;
            set 
            {
                ValidateIntRange(value, GetType().Name, GetMethodName(), RatingMinValue, RatingMaxValue);
                rating = value; 
            }
        }

        public FeedbackStatusType Status { get; private set; }
        
        public override void AdvanceStatus()
        {
            switch (Status)
            {
                case FeedbackStatusType.New:
                    Status = FeedbackStatusType.Unscheduled;
                    LogChanges($"Status changed from {FeedbackStatusType.New} to {FeedbackStatusType.Unscheduled}");
                    break;
                case FeedbackStatusType.Unscheduled:
                    Status = FeedbackStatusType.Scheduled;
                    LogChanges($"Status changed from {FeedbackStatusType.Unscheduled} to {FeedbackStatusType.Scheduled}");
                    break;
                case FeedbackStatusType.Scheduled:
                    Status = FeedbackStatusType.Done;
                    LogChanges($"Status changed from {FeedbackStatusType.Scheduled} to {FeedbackStatusType.Done}");
                    break;
                case FeedbackStatusType.Done:
                    string message = $"Status is already at Done, can't advance any further";
                    LogChanges(message);
                    throw new ArgumentException(message);
                default:
                    throw new ArgumentException($"Feedbag status can only be one of the following: New, Unscheduled, Scheduled, Done");
            }
        }


        public override void RevertStatus()
        {
            switch (Status)
            {
                case FeedbackStatusType.Done:
                    Status = FeedbackStatusType.Scheduled;
                    LogChanges($"Status changed from {FeedbackStatusType.Done} to {FeedbackStatusType.Scheduled}");
                    break;
                case FeedbackStatusType.Scheduled:
                    Status = FeedbackStatusType.Unscheduled;
                    LogChanges($"Status changed from {FeedbackStatusType.Scheduled} to {FeedbackStatusType.Unscheduled}");
                    break;
                case FeedbackStatusType.Unscheduled:
                    Status = FeedbackStatusType.New;
                    LogChanges($"Status changed from {FeedbackStatusType.Unscheduled} to {FeedbackStatusType.New}");
                    break;
                case FeedbackStatusType.New:
                    string message = $"Status is already at New, can't revert any further";
                    LogChanges(message);
                    throw new ArgumentException(message);
                default:
                    throw new ArgumentException($"Feedbag status can only be one of the following: New, Unscheduled, Scheduled, Done");
            }
        }

    }
}
