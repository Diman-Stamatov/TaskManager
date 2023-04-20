using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;

namespace TaskManager.Tests.Commands
{
    [TestClass]
    public class CreateBoardTests
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
            mockTeam = repository.CreateTeam(ValidTeamName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CommandShouldThrow_When_ArgumentsCountIsInvalid()
        {
            ICommand command = commandFactory.Create("CreateBoard");
            command.Execute();
        }

        [TestMethod]
        public void CommandShouldCreate_When_InputIsValid()
        {
            ICommand command = commandFactory.Create($"CreateBoard {ValidTeamName} {ValidBoardName}");
            command.Execute();
            Assert.IsTrue(repository.TeamExists(ValidTeamName));
        }

        [TestMethod]
        [ExpectedException(typeof(EntryNotFoundException))]
        public void CommandShouldThrow_When_TeamIsInvalid()
        {
            ICommand command = commandFactory.Create($"CreateBoard invalidTeamName {ValidBoardName}");
            command.Execute();
        }
    }
}
