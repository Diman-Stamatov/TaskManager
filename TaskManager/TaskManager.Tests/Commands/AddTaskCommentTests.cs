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
    public class AddTaskCommentTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private IBug bug;
        private IStory story;
        private IMember member;

        [TestInitialize]
        public void InitTest()
        {
            this.repository = new Repository();
            this.commandFactory = new CommandFactory(this.repository);
            this.bug = this.repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);
            this.story = this.repository.CreateStory(ValidTaskTitle, ValidDescription, ValidPriority, ValidSize);
            this.member = this.repository.CreateMember(ValidMemberName);
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("AddTaskComment");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());

        }

        [TestMethod]
        public void Command_ShouldThrow_WhenIDIsInvalid()
        {
            ICommand command = this.commandFactory.Create($"AddTaskComment 3 Comment {ValidMemberName}");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());

        }

        [TestMethod]
        public void Command_ShouldThrow_WhenAuthorIsNotARegisteredEmployee()
        {
            ICommand command = this.commandFactory.Create($"AddTaskComment 2 Comment Author");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());

        }

        [TestMethod]
        public void Command_Should_CreateWhenInputIsValid()
        {
            ICommand command = this.commandFactory.Create($"AddTaskComment 2 Comment {ValidMemberName}");
            command.Execute();
            Assert.AreEqual(1, this.story.Comments.Count);

        }
    }
}
