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
    public class ChangeStoryStatusTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private IMember mockMember;
        private IStory mockStory;
        private IBug mockBug;
        private IFeedback mockFeedback;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            commandFactory = new CommandFactory(repository);
            mockStory = repository.CreateStory(ValidTaskTitle, ValidDescription, ValidPriority, ValidSize);
            mockBug = repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);
            mockFeedback = repository.CreateFeedback(ValidTaskTitle, ValidDescription, ValidId);
            mockMember = repository.CreateMember(ValidMemberName);
            mockStory.Assign(mockMember);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CommandShouldThrow_When_ArgumentsCountIsInvalid()
        {
            ICommand command = commandFactory.Create("ChangeStoryStatus");
            command.Execute();
        }

        [TestMethod]
        public void Command_ShouldAdvance_WhenInputIsValid()
        {
            ICommand command = commandFactory.Create("ChangeStoryStatus 1 advance");
            command.Execute();
            Assert.AreEqual(StoryStatusType.InProgress, mockStory.Status);
        }

        [TestMethod]
        public void Command_ShouldRevert_WhenInputIsValid()
        {
            Command_ShouldAdvance_WhenInputIsValid();
            ICommand command = commandFactory.Create("ChangeStoryStatus 1 revert");
            command.Execute();
            Assert.AreEqual(StoryStatusType.NotDone, mockStory.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenRevertingAtMinimum()
        {
            ICommand command = commandFactory.Create("ChangeStoryStatus 1 revert");
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenAdvanceAtMaximum()
        {
            ICommand command = commandFactory.Create("ChangeStoryStatus 1 advance");
            command.Execute();
            command.Execute();
            command.Execute();
        }
    }
}
