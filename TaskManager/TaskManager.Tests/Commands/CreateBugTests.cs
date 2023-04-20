using TaskManager.Core;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;

namespace TaskManager.Tests.Commands
{
    [TestClass]
    public class CreateBugTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            commandFactory = new CommandFactory(repository);
            mockStory = repository.CreateStory(ValidTaskTitle, ValidDescription, ValidPriority, ValidSize);
            mockBug = repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);
            mockFeedback = repository.CreateFeedback(ValidTaskTitle, ValidDescription, ValidId);
            mockMember = repository.CreateMember(ValidMemberName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CommandShouldThrow_When_ArgumentsCountIsInvalid()
        {
            ICommand command = commandFactory.Create("CreateBug");
            command.Execute();
        }

        [TestMethod]
        public void CommandShouldCreateBug_WhenInputIsValid()
        {
            ICommand command = commandFactory.Create($"CreateBug {ValidTaskTitle} {ValidDescription} {ValidPriority} {ValidSeverity}");
            command.Execute();
            Assert.IsTrue(repository.GetTask(1).Id == 1);
        }
    }
}
