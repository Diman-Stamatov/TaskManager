using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Exceptions;
using TaskManager.Models;

namespace TaskManager.Tests.Models
{
    [TestClass]
    public class FeedbackTests
    {
        [TestMethod]
        [DataRow(TaskTitleMinLength - 1)]
        [DataRow(TaskTitleMaxLength + 1)]
        public void Feedback_ShouldThrow_WhenTitle_IsInvalidLength(int testSize)
        {
            string testTitle = GetTestString(testSize);

            Assert.ThrowsException<InvalidUserInputException>(() =>
            new Feedback(ValidId, testTitle, ValidDescription, RatingMinValue));
        }

        [TestMethod]
        [DataRow(DescriptionMinLength - 1)]
        [DataRow(DescriptionMaxLength + 1)]
        public void Feedback_ShouldThrow_WhenDescription_IsInvalidLength(int testSize)
        {
            string testDescription = GetTestString(testSize);

            Assert.ThrowsException<InvalidUserInputException>(() =>
            new Feedback(ValidId, ValidTaskTitle, testDescription, RatingMinValue));
        }
        [TestMethod]
        [DataRow(RatingMinValue - 1)]
        [DataRow(RatingMaxValue + 1)]
        public void Feedback_ShouldThrow_WhenRating_IsInvalid(int testValue)
        {           
            Assert.ThrowsException<InvalidUserInputException>(() =>
            new Feedback(ValidId, ValidTaskTitle, ValidDescription, testValue));
        }
        [TestMethod]        
        public void Feedback_ShouldCreate_WhenDataIsValid()
        {
            var feedback = new Feedback(ValidId, ValidTaskTitle, ValidDescription, RatingMinValue);
            Assert.IsNotNull(feedback);
        }
        [TestMethod]
        public void Feedback_AdvanceStatusShould_AdvanceWhenPossible()
        {
            var feedback = new Feedback(ValidId, ValidTaskTitle, ValidDescription, RatingMinValue);
            feedback.AdvanceStatus();
            Assert.AreEqual(FeedbackStatusType.Unscheduled, feedback.Status);
        }
        [TestMethod]
        public void Feedback_AdvanceStatusShouldThrow_WhenAlreadyAdvancedToMax()
        {
            var feedback = new Feedback(ValidId, ValidTaskTitle, ValidDescription, RatingMinValue);
            feedback.AdvanceStatus();
            feedback.AdvanceStatus();
            feedback.AdvanceStatus();
            Assert.ThrowsException<InvalidUserInputException>(()=>
            feedback.AdvanceStatus());
        }
        [TestMethod]
        public void Feedback_RevertStatusShould_RevertWhenPossible()
        {
            var feedback = new Feedback(ValidId, ValidTaskTitle, ValidDescription, RatingMinValue);
            feedback.AdvanceStatus();
            feedback.RevertStatus();
            Assert.AreEqual(FeedbackStatusType.New, feedback.Status);
        }
        [TestMethod]
        public void Feedback_RevertStatusShouldThrow_WhenAlreadyRevertedToMin()
        {
            var feedback = new Feedback(ValidId, ValidTaskTitle, ValidDescription, RatingMinValue);            
            Assert.ThrowsException<InvalidUserInputException>(() =>
            feedback.RevertStatus());
        }

        [TestMethod]
        public void Feedback_ToStringShould_ReturnAString()
        {
            var feedback = new Feedback(ValidId, ValidTaskTitle, ValidDescription, RatingMinValue);
            Assert.IsNotNull(feedback.ToString());
        }
    }
}
