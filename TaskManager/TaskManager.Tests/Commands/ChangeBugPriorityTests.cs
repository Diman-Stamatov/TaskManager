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
    public class ChangeBugPriorityTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private IMember member;        
        private IBug bug;
        private IStory story;

        [TestInitialize]
        public void InitTest()
        {
            this.repository = new Repository();
            this.commandFactory = new CommandFactory(this.repository);
            this.member = this.repository.CreateMember(ValidMemberName);                  
            this.bug = this.repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);
            this.story = this.repository.CreateStory(ValidTaskTitle, ValidDescription, ValidPriority, ValidSize);
            this.bug.Assign(member);

        }

        [TestMethod]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ChangeBugPriority");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenIDIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ChangeBugPriority 3 Revert");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenTaskIsNotABug()
        {
            ICommand command = this.commandFactory.Create("ChangeBugPriority 2 Revert");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenBugNotAssigned()
        {
            this.bug.Unassign();
            ICommand command = this.commandFactory.Create("ChangeBugPriority 1 Revert");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenCommandNotRevertOrAdvance()
        {
            ICommand command = this.commandFactory.Create("ChangeBugPriority 1 RevertO");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldAdvance_WhenInputIsValid()
        {
            ICommand command = this.commandFactory.Create("ChangeBugPriority 1 Advance");
            command.Execute();
            Assert.AreEqual(PriorityType.High, bug.Priority);
        }

        [TestMethod]
        public void Command_ShouldRevert_WhenInputIsValid()
        {
            ICommand command = this.commandFactory.Create("ChangeBugPriority 1 Revert");
            command.Execute();
            Assert.AreEqual(PriorityType.Low, bug.Priority);
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenRevertingAtMinimum()
        {
            ICommand command = this.commandFactory.Create("ChangeBugPriority 1 Revert");
            command.Execute();
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenAdvancingAtMaximum()
        {
            ICommand command = this.commandFactory.Create("ChangeBugPriority 1 Advance");
            command.Execute();
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }
    }
}
