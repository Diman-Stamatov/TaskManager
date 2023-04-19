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
    public class ShowTeamActivityHistoryTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;

        [TestInitialize]
        public void InitTest()
        {
            repository = new Repository();
            var member2 = repository.CreateMember("MemberOne");
            var member3 = repository.CreateMember("SomeRandom");
            Team team1 = (Team)repository.CreateTeam("Team1");
            Team team2 = (Team)repository.CreateTeam("Team2");
            team1.AddTeamMember(member2);
            team2.AddTeamMember(member3);
            commandFactory = new CommandFactory(repository);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenCommandIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ShowTeamActivityHistory");
            command.Execute();
        }

        [TestMethod]
        public void Command_ShouldReturnValue()
        {
            ICommand command = this.commandFactory.Create("ShowTeamActivityHistory Team1");
            Assert.IsNotNull(command.Execute());
        }
    }
}
