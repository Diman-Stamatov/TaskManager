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
    public class AddTaskToBoardTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private IBug bug;
        private ITeam team;

        [TestInitialize]
        public void InitTest()
        {
            this.repository = new Repository();
            this.commandFactory = new CommandFactory(this.repository);
            this.bug = this.repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);
            this.team = this.repository.CreateTeam(ValidTeamName);
            this.team.CreateBoard(ValidBoardName);
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("AddTaskToBoard");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenIdIsIncorrect()
        {
            ICommand command = this.commandFactory.Create($"AddTaskToBoard 2 {ValidTeamName} {ValidBoardName}");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenTeamIsIncorrect()
        {
            ICommand command = this.commandFactory.Create($"AddTaskToBoard 1 teamName {ValidBoardName}");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenBoardIsIncorrect()
        {
            ICommand command = this.commandFactory.Create($"AddTaskToBoard 1 {ValidTeamName} boardName");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());
        }
        [TestMethod]
        public void Command_ShouldAdd_WhenDataIsValid()
        {
            ICommand command = this.commandFactory.Create($"AddTaskToBoard 1 {ValidTeamName} {ValidBoardName}");            
            command.Execute();
            Assert.AreEqual(1, this.team.Boards[0].Tasks.Count);
        }
    }
}
