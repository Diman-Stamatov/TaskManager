using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Commands;
using TaskManager.Core.Interfaces;
using TaskManager.Core;
using TaskManager.Exceptions;

namespace TaskManager.Tests.Commands
{
    [TestClass]
    public class ListTasksTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;

        [TestInitialize]
        public void InitTest()
        {
            repository = new Repository();
            commandFactory = new CommandFactory(repository);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ListTasks");
            command.Execute();
        }


        [TestMethod]

        public void ShouldReturn_BugsSortedByTitle()
        {
            repository.CreateBug("Abaaaaaaaaaa", ValidDescription, PriorityType.Medium, SeverityType.Minor);
            repository.CreateBug("Bvaaaaaaaaaaa", ValidDescription, PriorityType.High, SeverityType.Major);
            repository.CreateBug("Ccccccccccccc", ValidDescription, PriorityType.Low, SeverityType.Critical);
            ICommand command = commandFactory.Create($"ListTasks Sorted");
            List<string> result = command.Execute().Split(Environment.NewLine).ToList();
            Assert.IsTrue(result[1].Contains("Title: Abaaaaaaaaaa"));
            Assert.IsTrue(result[9].Contains("Title: Bvaaaaaaaaaaa"));
            Assert.IsTrue(result[17].Contains("Title: Ccccccccccccc"));
        }

        [TestMethod]

        public void ShouldReturn_BugsSortedByGivenTitle()
        {
            repository.CreateBug("Bbaaaaaaaaaa", ValidDescription, PriorityType.Medium, SeverityType.Minor);
            repository.CreateBug("Bbaaaaaaaaaa", ValidDescription, PriorityType.High, SeverityType.Minor);
            repository.CreateBug("Bbaaaaaaaaaa", ValidDescription, PriorityType.Medium, SeverityType.Major);
            repository.CreateBug("Aaaaaaaaaaaa", ValidDescription, PriorityType.Low, SeverityType.Critical);
            ICommand command = commandFactory.Create($"ListTasks Bbaaaaaaaaaa");
            List<string> result = command.Execute().Split(Environment.NewLine).ToList();
            Assert.AreEqual(result[1].Contains("Title: Bbaaaaaaaaaa"), result[9].Contains("Title: Bbaaaaaaaaaa"));
            Assert.AreEqual(result[9].Contains("Title: Bbaaaaaaaaaa"), result[17].Contains("Title: Bbaaaaaaaaaa"));
        }
    }
}
