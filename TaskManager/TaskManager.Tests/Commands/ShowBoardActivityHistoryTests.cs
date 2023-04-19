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
    public class ShowBoardActivityHistoryTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;

        [TestInitialize]
        public void InitTest()
        {
            repository = new Repository();
            Team team1 = (Team)repository.CreateTeam("Team1");
            team1.CreateBoard("BoarsOne");
            team1.CreateBoard("BoardTwo");
            commandFactory = new CommandFactory(repository);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenCommandIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ShowBoardActivityHistory");
            command.Execute();
        }

        [TestMethod]
        public void Command_ShouldReturnValue()
        {
            ICommand command = this.commandFactory.Create("ShowBoardActivityHistory Team1 BoarsOne");
            Assert.IsNotNull(command.Execute());
        }
    }
}
