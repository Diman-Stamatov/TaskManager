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
    public class ListFeedbackTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private ICommand command;
        List<string> list = new List<string>()
        {
          "FilterDone",
          "FilterScheduled",
          "FilterUnscheduled",
          "FilterNew",
          "SortByRating",
          "SortByTitle",
        };

        [TestInitialize]
        public void InitTest()
        {
            repository = new Repository();
            commandFactory = new CommandFactory(repository);
            command = new ListFeedbackCommand(list, repository);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenArgumentsCountIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ListFeedback");
            command.Execute();
        }

        [TestMethod]
        public void Command_ShouldExecuteWithAllCorectInputs()
        {

            repository.CreateFeedback(ValidTaskTitle, ValidDescription, 5);
            repository.CreateFeedback(ValidTaskTitle, ValidDescription, 4);
            repository.CreateFeedback(ValidTaskTitle, ValidDescription, 10);

            for (int i = 0; i < list.Count; i++)
            {
                ICommand command = this.commandFactory.Create($"ListFeedback {list[i]}");
                string result = command.Execute();
                Assert.IsNotNull(result, $"{list[i]} command is incorect.");
            }
        }

        [TestMethod]
        public void Should_ShowMessage_When_ThereAreNoFeedbackMeetsTheConditions()
        {
            repository.CreateFeedback(ValidTaskTitle, ValidDescription, 5);
            command = commandFactory.Create($"ListFeedback FilterDone");
            var result = new StringWriter();
            Console.SetOut(result);
            command.Execute();
            Assert.IsTrue(!string.IsNullOrEmpty(result.ToString()));
        }

        [TestMethod]
        public void ShouldReturn_FeedbackSortedByRating()
        {
            repository.CreateFeedback(ValidTaskTitle, ValidDescription, 5);
            repository.CreateFeedback(ValidTaskTitle, ValidDescription, 4);
            repository.CreateFeedback(ValidTaskTitle, ValidDescription, 10);

            command = commandFactory.Create($"ListFeedback SortByRating");
            List<string> result = command.Execute().Split(Environment.NewLine).ToList();
            Assert.IsTrue(result[4].Contains("Rating: 10"));
            Assert.IsTrue(result[11].Contains("Rating: 5"));
            Assert.IsTrue(result[18].Contains("Rating: 4"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Command_ShouldThrow_WhenCommandIsInvalid()
        {
            ICommand command = this.commandFactory.Create("ListFeedback ListMe");
            command.Execute();
        }

    }
}
