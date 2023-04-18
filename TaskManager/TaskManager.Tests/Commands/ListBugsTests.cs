using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Commands;
using TaskManager.Core;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;

namespace TaskManager.Tests.Commands
{
    [TestClass]
    public class ListBugsTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private ICommand command;
        List<string> list = new List<string>()
        { 
          "SortByPriority",
          "SortBySeverity",
          "FilterActive",
          "FilterFixed",
          "FilterAssigned",
          "FilterUnassigned",
          "SortByTitle"
        };

        [TestInitialize]
        public void InitTest()
        {
            repository = new Repository();
            commandFactory = new CommandFactory(repository);
            command = new ListBugsCommand(list, repository);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ListBugs");
            command.Execute();
        }

        [TestMethod]
        public void Command_ShouldExecuteWithAllCorectInputs()
        {

            repository.CreateBug(ValidTaskTitle, ValidDescription, PriorityType.Medium, SeverityType.Minor);
            repository.CreateBug(ValidTaskTitle, ValidDescription, PriorityType.High, SeverityType.Major);
            repository.CreateBug(ValidTaskTitle, ValidDescription, PriorityType.Low,SeverityType.Critical);
            var member3 = repository.CreateMember("Cccccccccc");
            Team team1 = (Team)repository.CreateTeam("Team1");
            team1.AddTeamMember(member3);
            Bug bug = (Bug)repository.Tasks[0];
            bug.Assign(member3);
            Bug bug2 = (Bug)repository.Tasks[1];
            bug2.Assign(member3);

            for (int i = 0; i < list.Count; i++)
            {
                ICommand command = this.commandFactory.Create($"ListBugs {list[i]}");
                string  result = command.Execute();
                Assert.IsNotNull(result, $"{list[i]} command is incorect.");
            } 
        }

        [TestMethod]
        public void Should_ShowMessage_When_ThereAreNoBugsMeetsTheConditions()
        {
            repository.CreateBug(ValidTaskTitle, ValidDescription, PriorityType.Low, SeverityType.Critical);
            command = commandFactory.Create($"ListBugs FilterFixed");
            var result = new StringWriter();
            Console.SetOut(result);
            command.Execute();
            Assert.IsTrue(!string.IsNullOrEmpty(result.ToString()));
        }

        [TestMethod]
        public void ShouldReturn_BugsSortedByTitle()
        {
            repository.CreateBug("Abaaaaaaaaaa", ValidDescription, PriorityType.Medium, SeverityType.Minor);
            repository.CreateBug("Avaaaaaaaaaaa", ValidDescription, PriorityType.High, SeverityType.Major);
            repository.CreateBug("Ccccccccccccc", ValidDescription, PriorityType.Low, SeverityType.Critical);
            command = commandFactory.Create($"ListBugs SortByTitle");
            List<string> result = command.Execute().Split(Environment.NewLine).ToList();
            Assert.IsTrue(result[1].Contains("Title: Abaaaaaaaaaa"));
            Assert.IsTrue(result[9].Contains("Title: Avaaaaaaaaaaa"));
            Assert.IsTrue(result[17].Contains("Title: Ccccccccccccc"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenCommandIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ListBugs ListMe");
            command.Execute();
        }
    }
}
