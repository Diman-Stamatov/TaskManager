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
    public class CreateMemberTests
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
            mockTeam = repository.CreateTeam(ValidTeamName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CommandShouldThrow_When_ArgumentsCountIsInvalid()
        {
            ICommand command = commandFactory.Create("CreateMember");
            command.Execute();
        }

        [TestMethod]
        public void CommandShouldCreateMember_WhenInputIsValid()
        {
            ICommand command = commandFactory.Create($"CreateMember {ValidMemberName}");
            command.Execute();
            Assert.AreEqual(1, repository.Members.Count);
            Assert.IsTrue(repository.MemberExists(ValidMemberName));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CommandShouldThrow_When_MemberAlreadyExists()
        {
            ICommand command = commandFactory.Create($"CreateMember {ValidMemberName}");
            command.Execute();
            command.Execute();
        }
    }
}
