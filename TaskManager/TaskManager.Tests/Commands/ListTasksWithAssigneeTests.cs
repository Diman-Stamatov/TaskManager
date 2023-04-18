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
    public class ListTasksWithAssigneeTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;

        List<string> list = new List<string>()
        {
          "Active",
          "Fixed",
          "NotDone",
          "InProgres",
          "Done"
        };

        [TestInitialize]
        public void InitTest()
        {
            repository = new Repository();
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.Medium, SizeType.Medium);
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.High, SizeType.Small);
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.Low, SizeType.Large);
            repository.CreateBug(ValidTaskTitle, ValidDescription, PriorityType.Medium, SeverityType.Minor);
            repository.CreateBug(ValidTaskTitle, ValidDescription, PriorityType.High, SeverityType.Major);
            repository.CreateBug(ValidTaskTitle, ValidDescription, PriorityType.Low, SeverityType.Critical);
            var member2 = repository.CreateMember("MemberOne");
            var member3 = repository.CreateMember("SomeRandom");
            Team team1 = (Team)repository.CreateTeam("Team1");
            team1.AddTeamMember(member2);
            team1.AddTeamMember(member3);
            Story story = (Story)repository.Tasks[0];
            story.Assign(member2);
            Story story2 = (Story)repository.Tasks[1];
            story2.Assign(member3);
            story2.AdvanceStatus();
            Story story3 = (Story)repository.Tasks[2];
            story3.Assign(member3);
            story3.AdvanceStatus();
            story3.AdvanceStatus();
            Bug bug = (Bug)repository.Tasks[3];
            bug.Assign(member2);
            bug.AdvanceStatus();
            Bug bug2 = (Bug)repository.Tasks[4];
            bug2.Assign(member3);
            Bug bug3 = (Bug)repository.Tasks[5];
            bug3.Assign(member2);
            commandFactory = new CommandFactory(repository);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ListTasksWithAssignee");
            command.Execute();
        }

        [TestMethod]
        public void Command_ShouldExecuteWithAllCorectInputs()
        {
            for (int i = 0; i < list.Count; i++)
            {
                ICommand command = this.commandFactory.Create($"ListTasksWithAssignee {list[i]}");
                string result = command.Execute();
                Assert.IsNotNull(result, $"{list[i]} command is incorect.");
            }
        }


        [TestMethod]
        public void ShouldReturn_TasksSortedByAssignee()
        {
            ICommand command = commandFactory.Create("ListTasksWithAssignee MemberOne");
            List<string> result = command.Execute().Split(Environment.NewLine).ToList();
            Assert.IsTrue(result[6].Contains("Assigned to: MemberOne"));
            Assert.IsTrue(result[14].Contains("Assigned to: MemberOne"));
        }

        [TestMethod]
        public void Should_ShowMessage_When_ThereAreNoTasksMeetingTheConditions()
        {
            Repository rep = new Repository();
            rep.CreateBug(ValidTaskTitle, ValidDescription, PriorityType.Low, SeverityType.Critical);
            var result = new StringWriter();
            Console.SetOut(result);
            ICommand command = commandFactory.Create("ListTasksWithAssignee Fixed");
            command.Execute();
            Assert.IsTrue(!string.IsNullOrEmpty(result.ToString()));
        }

    }
}
