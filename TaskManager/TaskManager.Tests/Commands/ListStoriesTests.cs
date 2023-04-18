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
    public class ListStoriesTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private ICommand command;
        List<string> list = new List<string>()
        {
          "FilterUnassigned",
          "FilterAssigned",
          "FilterDone",
          "FilterInProgress",
          "FilterNotDone",
          "SortBySize",
          "SortByPriority",
          "SortByTitle"
        };

        [TestInitialize]
        public void InitTest()
        {
            repository = new Repository();
            commandFactory = new CommandFactory(repository);
            command = new ListStoriesCommand(list, repository);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ListStories");
            command.Execute();
        }

        [TestMethod]
        public void Command_ShouldExecuteWithAllCorectInputs()
        {
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.Medium, SizeType.Medium);
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.High, SizeType.Small);
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.Low, SizeType.Large);
            var member3 = repository.CreateMember("Cccccccccc");
            Team team1 = (Team)repository.CreateTeam("Team1");
            team1.AddTeamMember(member3);
            Story story = (Story)repository.Tasks[0];
            story.Assign(member3);
            Story story2 = (Story)repository.Tasks[1];
            story2.Assign(member3);

            for (int i = 0; i < list.Count; i++)
            {
                ICommand command = this.commandFactory.Create($"ListStories {list[i]}");
                string result = command.Execute();
                Assert.IsNotNull(result, $"{list[i]} command is incorect.");
            }
        }

        [TestMethod]
        public void Should_ShowMessage_When_ThereAreNoStoryMeetsTheConditions()
        {
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.Medium, SizeType.Medium);
            command = commandFactory.Create($"ListStories FilterDone");
            var result = new StringWriter();
            Console.SetOut(result);
            command.Execute();
            Assert.IsTrue(!string.IsNullOrEmpty(result.ToString()));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenCommandIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ListStories ListMe");
            command.Execute();
        }

        [TestMethod]
        public void ShouldReturn_StoriesSortedBySize()
        {
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.Medium, SizeType.Medium);
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.High, SizeType.Small);
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.Low, SizeType.Large);
            command = commandFactory.Create($"ListStories SortBySize");
            List<string> result = command.Execute().Split(Environment.NewLine).ToList();
            Console.WriteLine("");
            Assert.IsTrue(result[4].Contains("Size: Large"));
            Assert.IsTrue(result[12].Contains("Size: Medium"));
            Assert.IsTrue(result[20].Contains("Size: Small"));
        }
    }
}
