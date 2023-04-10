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
        public int Rating 
        {
            get => rating;
            set 
            {
                ValidateIntRange(value, GetType().Name, GetMethodName(), RatingMinValue, RatingMaxValue);
                rating = value; 
            }
        }

        public FeedbackStatusType Status => throw new NotImplementedException();
        
        public void AdvanceFeedbackStatus()
        {
            //Виж от кой статус стартираш и до къде върти
        } 
        
        public void RevertFeedbackStatus()
        {
            //До кой статус стига
        }

    }
}
