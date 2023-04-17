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
        private IStory story;
        private IFeedback feedback;

        [TestInitialize]
        public void InitTest()
        {
            this.repository = new Repository();
            this.commandFactory = new CommandFactory(this.repository);
            this.member = this.repository.CreateMember(ValidMemberName);
            this.team = this.repository.CreateTeam(ValidTeamName);            
            this.bug = this.repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);
            this.story = this.repository.CreateStory(ValidTaskTitle, ValidDescription, ValidPriority, ValidSize);
            this.feedback = this.repository.CreateFeedback(ValidTaskTitle, ValidDescription, RatingMinValue);
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
            this.team.AddTeamMember(member);
            ICommand command = this.commandFactory.Create($"AssignTask 4 {ValidMemberName}");
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
        public void Command_ShouldThrow_WhenAssigneeNotOnATeam()
        {
            
            ICommand command = this.commandFactory.Create($"AssignTask 1 {ValidMemberName}");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenTaskIsFeedback()
        {
            this.team.AddTeamMember(member);
            ICommand command = this.commandFactory.Create($"AssignTask 3 {ValidMemberName}");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void Command_ShouldAdd_WhenDataIsValid(int testValue)
        {
            this.team.AddTeamMember(member);
            ICommand command = this.commandFactory.Create($"AssignTask {testValue} {ValidMemberName}");            
            command.Execute();
            Assert.AreEqual(1, this.member.Tasks.Count);
        }
    }
}
