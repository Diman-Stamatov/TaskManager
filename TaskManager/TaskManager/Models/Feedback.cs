using System;
using System.Collections.Generic;
using System.Drawing;
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
        private const FeedbackStatusType InitialStatus = FeedbackStatusType.New;
        public Feedback(int id, string title, string description, int rating)
            : base(id, title, description)
        {
            Rating = rating;
            Status = InitialStatus;
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
            var type = Status.GetType();
            int currentValue = (int)this.Status;
            string propertyName = GetMethodName().TrimAdvance();

            ValidateAdvanceMethod(type, currentValue, propertyName);
            LogChanges(GenerateAdvanceMethodMessage(type, currentValue, propertyName));

            Status++;
        }

        public override void RevertStatus()
        {
            var type = Status.GetType();
            int currentValue = (int)this.Status;
            string propertyName = GetMethodName().TrimRevert();

            ValidateRevertMethod(type, currentValue, propertyName);
            LogChanges(GenerateRevertMethodMessage(type, currentValue, propertyName));
            Status--;
        }

    }
}
