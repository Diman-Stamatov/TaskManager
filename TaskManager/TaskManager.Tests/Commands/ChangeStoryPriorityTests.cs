using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;
using TaskManager.Models;
using TaskManager.Models.Contracts;
using TaskManager.Models.Enums;

namespace TaskManager.Tests.Commands
{
    [TestClass]
    public class ChangeStoryPriorityTests
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
            mockBug = repository.CreateBug(ValidTaskTitle,  ValidDescription, ValidPriority, ValidSeverity);
            mockFeedback = repository.CreateFeedback(ValidTaskTitle, ValidDescription, ValidId);
            mockMember = repository.CreateMember(ValidMemberName);
            mockStory.Assign(mockMember);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CommandShouldThrow_When_ArgumentsCountIsInvalid()
        {
            ICommand command = commandFactory.Create("ChangeStoryPriority");
            command.Execute();
        }
       

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CommandShouldThrow_When_IDIsInvalid()
        {
            ICommand command = commandFactory.Create("ChangeStoryPriority 2 advance");
            command.Execute();
            Assert.AreEqual(PriorityType.High, mockStory.Priority);
        }

        [TestMethod]
        public void Command_ShouldAdvance_WhenInputIsValid()
        {
            ICommand command = commandFactory.Create("ChangeStoryPriority 1 advance");
            command.Execute();
            Assert.AreEqual(PriorityType.High, mockStory.Priority);
        }

        [TestMethod]
        public void Command_ShouldRevert_WhenInputIsValid()
        {
            ICommand command = commandFactory.Create("ChangeStoryPriority 1 revert");
            command.Execute();
            Assert.AreEqual(PriorityType.Low, mockStory.Priority);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenRevertingAtMinimum()
        {
            ICommand command = commandFactory.Create("ChangeStoryPriority 1 revert");
            command.Execute();            
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenAdvanceAtMaximum()
        {
            ICommand command = commandFactory.Create("ChangeStoryPriority 1 advance");
            command.Execute();
            command.Execute();
        }

    }
}
