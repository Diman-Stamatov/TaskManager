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
    public class UnassignTaskTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private IMember mockMember;
        private IStory mockStory;
        private IBug mockBug;
        private IFeedback mockFeedback;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            commandFactory = new CommandFactory(repository);
            mockBug = repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);
            mockStory = repository.CreateStory(ValidTaskTitle, ValidDescription, ValidPriority, ValidSize);
            mockFeedback = repository.CreateFeedback(ValidTaskTitle, ValidDescription, ValidId);
            mockMember = repository.CreateMember(ValidMemberName);
           
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CommandShouldThrow_When_ArgumentsCountIsInvalid()
        {
            ICommand command = commandFactory.Create("UnassignTask");
            command.Execute();
        }

        //ToDo
        //[TestMethod]
        //public void CommandShouldThrow_When_IDIsInvalid()
        //{
        //    mockBug.Assign(mockMember);
        //    ICommand command = commandFactory.Create($"UnassignTask {ValidMemberName}");
        //    command.Execute();
        //    Assert.IsTrue(repository.MemberExists(ValidMemberName));
        //}
    }
}
