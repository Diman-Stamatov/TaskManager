using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Commands;
using TaskManager.Core;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;
using TaskManager.Models.Contracts;


namespace TaskManager.Tests.Commands
{
    [TestClass]
    public class ListAssigneesTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;

        [TestInitialize]
        public void Setup()
        {
            repository = GetTestRepository();
            commandFactory = new CommandFactory(repository);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = (ICommand)commandFactory.Create("ListAssignees 1");
        }

    }
}
