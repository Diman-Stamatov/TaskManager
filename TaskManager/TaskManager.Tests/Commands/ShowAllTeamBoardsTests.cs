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
    public class ShowAllTeamBoardsTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;

        [TestInitialize]
        public void InitTest()
        {
            repository = new Repository();
            var board1 = repository.CreateBoard("BoarsOne");
            var board2 = repository.CreateBoard("BoardTwo");
            Team team1 = (Team)repository.CreateTeam("Team1");
            team1.Boards.Add(board1);
            team1.Boards.Add(board2);
            commandFactory = new CommandFactory(repository);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenCommandIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ShowAllTeamBoard");
            command.Execute();
        }

        [TestMethod]
        public void Command_ShouldReturnValue()
        {
            ICommand command = this.commandFactory.Create("ShowAllTeamBoards");
            Assert.IsNotNull(command.Execute());
        }
    }
}
