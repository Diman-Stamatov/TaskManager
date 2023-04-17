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
    public class AssignTaskTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private IMember member;
        private ITeam team;
        private IBug bug;

        [TestInitialize]
        public void InitTest()
        {
            this.repository = new Repository();
            this.commandFactory = new CommandFactory(this.repository);
            this.member = this.repository.CreateMember(ValidMemberName);
            this.team = this.repository.CreateTeam(ValidTeamName);
            this.team.AddTeamMember(member);
            this.bug = this.repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);

        }

        [TestMethod]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("AssignTask");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenIdIsInvalid()
        {
            ICommand command = this.commandFactory.Create($"AssignTask 2 {ValidMemberName}");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenMemberIsInvalid()
        {
            ICommand command = this.commandFactory.Create($"AssignTask 1 memberName");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldAdd_WhenDataIsValid()
        {
            ICommand command = this.commandFactory.Create($"AssignTask 1 {ValidMemberName}");            
            command.Execute();
            Assert.AreEqual(1, this.member.Tasks.Count);
        }
    }
}
