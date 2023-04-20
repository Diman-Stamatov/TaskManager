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
    public class CreateFeedbackTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private ITeam mockTeam;
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
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CommandShouldThrow_When_ArgumentsCountIsInvalid()
        {
            ICommand command = commandFactory.Create("CreateFeedback");
            command.Execute();
        }

        [TestMethod]
        public void CommandShouldCreateFeedback_WhenInputIsValid()
        {
            ICommand command = commandFactory.Create($"CreateFeedback {ValidTaskTitle} {ValidDescription} {ValidId}");
            command.Execute();
            Assert.IsTrue(repository.GetTask(1).Id == 1);
        }
    }
}
