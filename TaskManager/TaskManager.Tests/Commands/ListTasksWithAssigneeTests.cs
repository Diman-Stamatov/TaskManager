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
            repository = GetTestRepository();
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

    }
}
