using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Core;
using TaskManager.Exceptions;

namespace TaskManager.Tests.Commands
{
    [TestClass]
    public class ChangeFeedbackRatingTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private IBug bug;
        private IFeedback feedback;

        [TestInitialize]
        public void InitTest()
        {
            this.repository = new Repository();
            this.commandFactory = new CommandFactory(this.repository);
            this.feedback = this.repository.CreateFeedback(ValidTaskTitle, ValidDescription, RatingMinValue);
            this.bug = this.repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ChangeFeedbackRating");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenIDIsInvalid()
        {
            ICommand command = this.commandFactory.Create($"ChangeFeedbackRating 3 {RatingMinValue}");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenTaskIsNotAFeedback()
        {
            ICommand command = this.commandFactory.Create($"ChangeFeedbackRating 2 {RatingMinValue}");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        [DataRow (RatingMinValue - 1)]
        [DataRow (RatingMaxValue + 1)]
        public void Command_ShouldThrow_WhenRatingIsInvalid(int testValue)
        {
            ICommand command = this.commandFactory.Create($"ChangeFeedbackRating 1 {testValue}");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldChange_WhenInputIsValid()
        {
            ICommand command = this.commandFactory.Create($"ChangeFeedbackRating 1 {RatingMaxValue}");           
            command.Execute();
            Assert.AreEqual(RatingMaxValue, this.feedback.Rating);
        }
    }
}
