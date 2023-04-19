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
    public class ShowAllMembersTests
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
            team1.AddTeamMember(member2);
            team1.AddTeamMember(member3);
            commandFactory = new CommandFactory(repository);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenCommandIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ShowAllMember");
            command.Execute();
        }

        [TestMethod]
        public void Command_ShouldReturnValue()
        {
            ICommand command = this.commandFactory.Create("ShowAllMembers");
            Assert.IsNotNull(command.Execute());
        }
    }
}
