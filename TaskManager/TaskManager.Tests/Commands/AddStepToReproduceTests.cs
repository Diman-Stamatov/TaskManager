using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Commands;
using TaskManager.Core.Interfaces;
using TaskManager.Core;
using TaskManager.Exceptions;
using TaskManager.Models.Contracts;
using TaskManager.Commands.Contracts;

namespace TaskManager.Tests.Commands
{
    [TestClass]
    public class AddStepToReproduceTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private IBug bug;
        private IStory story; 

        [TestInitialize]
        public void InitTest()
        {
            this.repository = new Repository();
            this.commandFactory = new CommandFactory(this.repository);
            this.bug = this.repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);
            this.story = this.repository.CreateStory(ValidTaskTitle, ValidDescription, ValidPriority, ValidSize);
        }

        [TestMethod]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("AddStepToReproduce 1");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());

        }

        [TestMethod]
        public void Command_ShouldThrow_WhenTaskIdIsNotValid()
        {
            ICommand command = this.commandFactory.Create("AddStepToReproduce 0 StepToReproduce");
            Assert.ThrowsException<EntryNotFoundException>(() =>
            command.Execute());

        }

        [TestMethod]
        public void Command_ShouldThrow_WhenTaskIsNotABug()
        {
            ICommand command = this.commandFactory.Create("AddStepToReproduce 2 StepToReproduce");
            Assert.ThrowsException<InvalidUserInputException>(() =>
            command.Execute());

        }

        [TestMethod]
        public void Command_Should_AddWhenInputIsValid()
        {
            ICommand command = this.commandFactory.Create("AddStepToReproduce 1 StepToReproduce");
            command.Execute();
            Assert.AreEqual(1, this.bug.StepsToReproduce.Count());
        }
    }
}
