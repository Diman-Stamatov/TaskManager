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
    public class ValidationTests
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private IMember mockMember;
        private IStory mockStory;
        private IBug mockBug;
        private IFeedback mockFeedback;
        private ITeam mockTeam;
        private IBoard mockBoard;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            commandFactory = new CommandFactory(repository);
            mockStory = repository.CreateStory(ValidTaskTitle, ValidDescription, ValidPriority, ValidSize);
            mockFeedback = repository.CreateFeedback(ValidTaskTitle, ValidDescription, ValidId);
            mockMember = repository.CreateMember(ValidMemberName);
            mockStory.Assign(mockMember);
            mockTeam = repository.CreateTeam(ValidTeamName);
            mockBug = repository.CreateBug(ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ValidateStringNotFullOrEmpty_ShoudThrow_When_NullString()
        {
            mockBug = repository.CreateBug(ValidTaskTitle, null, ValidPriority, ValidSeverity);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntryException))]
        public void ValidateDuplicateBoard_ShoudThrow_When_DuplicateBoard()
        {
            mockTeam.CreateBoard(ValidBoardName);
            mockTeam.CreateBoard(ValidBoardName);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ValidateDuplicateTeamMember_ShoudThrow_When_DuplicateTeamMember()
        {
            mockTeam.AddTeamMember(mockMember);
            mockTeam.AddTeamMember(mockMember);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntryException))]
        public void ValidateDuplicateTask_ShoudThrow_When_DuplicateTask()
        {
            mockTeam.CreateBoard("mockBoard");
            var newMockBoard = mockTeam.Boards.First();
            newMockBoard.AddTask(mockBug);
            newMockBoard.AddTask(mockBug);
        }

        [TestMethod]
        public void ValidateAssignMethod_ShoudThrow_When_NameNull()
        {
            mockBug.Assign(mockMember);

        }
    }
}
