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
    public class AssignMemberToTeamTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;        
        private IMember member;
        private ITeam team;

        [TestInitialize]
        public void InitTest()
        {
            this.repository = new Repository();
            this.commandFactory = new CommandFactory(this.repository);           
            this.member = this.repository.CreateMember(ValidMemberName);
            this.team = this.repository.CreateTeam(ValidTeamName);
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("AssignMemberToTeam");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenTeamNameIsInvalid()
        {
            ICommand command = this.commandFactory.Create($"AssignMemberToTeam teamName {ValidMemberName}");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenMemberNameIsInvalid()
        {
            ICommand command = this.commandFactory.Create($"AssignMemberToTeam {ValidTeamName} memberName");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldAssign_WhenDataIsValid()
        {
            ICommand command = this.commandFactory.Create($"AssignMemberToTeam {ValidTeamName} {ValidMemberName}");
            command.Execute();
            Assert.AreEqual(1, this.team.Members.Count);
        }
    }
}
