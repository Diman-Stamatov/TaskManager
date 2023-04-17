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
    public class ChangeFeedbackStatusTests
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
            ICommand command = this.commandFactory.Create("ChangeFeedbackStatus");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenIDIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ChangeFeedbackStatus 3 Revert");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenTaskIsNotAFeedback()
        {
            ICommand command = this.commandFactory.Create("ChangeFeedbackStatus 2 Revert");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }                

        [TestMethod]
        public void Command_ShouldThrow_WhenCommandNotRevertOrAdvance()
        {
            ICommand command = this.commandFactory.Create("ChangeFeedbackStatus 1 RevertO");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldAdvance_WhenInputIsValid()
        {
            ICommand command = this.commandFactory.Create("ChangeFeedbackStatus 1 Advance");
            command.Execute();
            Assert.AreEqual(FeedbackStatusType.Unscheduled, feedback.Status);
        }

        [TestMethod]
        public void Command_ShouldRevert_WhenInputIsValid()
        {
            ICommand command = this.commandFactory.Create("ChangeFeedbackStatus 1 Revert");
            this.feedback.AdvanceStatus();
            command.Execute();
            Assert.AreEqual(FeedbackStatusType.New, feedback.Status);
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenRevertingAtMinimum()
        {
            ICommand command = this.commandFactory.Create("ChangeFeedbackStatus 1 Revert");            
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenAdvancingAtMaximum()
        {
            ICommand command = this.commandFactory.Create("ChangeFeedbackStatus 1 Advance");
            command.Execute();
            command.Execute();
            command.Execute();
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }
    }
}
