using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Exceptions;

namespace TaskManager.Tests.Models
{
    [TestClass]
    public class TeamTests
    {
        private ITeam mockTeam;
        private IBoard mockBoard;
        private IMember mockMember;

        [TestInitialize] 
        public void Initialize() 
        {
            mockTeam = GetTestTeam();
            mockBoard = GetTestBoard();
            mockMember = GetTestMember();
        }

        [TestMethod]
        public void Team_ShoudImplementITeamInterface()
        {
            var type = typeof(Team);
            var isAssignable = typeof(ITeam).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Board class does not implement IBoard interface!");
        }

        [TestMethod]
        public void TeamConstructor_ValidInput_ShouldCreateTeamObject()
        {
            string title = ValidBoardName;
            Team board = new Team(title);
            Assert.IsNotNull(board);
            Assert.IsInstanceOfType(board, typeof(Team));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        [DataRow(TeamNameMinLength - 1)]
        [DataRow(TeamNameMaxLength + 1)]

        public void WhenAddInvalidTitile_ShouldThrowError(int testSize)
        {
            string title = GetTestString(testSize);
            Team board = new Team(title);
        }

        [TestMethod]
        public void TeamShouldAddBoard_When_BoardIsValid()
        {
            mockTeam.CreateBoard(mockBoard.Name);
            Assert.AreEqual(1, mockTeam.Boards.Count);
            Assert.IsInstanceOfType(mockTeam.Boards[0], typeof(Board));
        }

        [TestMethod]
        public void TeamShouldAddMember_When_MemberIsValid()
        {
            mockTeam.AddTeamMember(mockMember);
            Assert.AreEqual(1, mockTeam.Members.Count);
            Assert.IsInstanceOfType(mockTeam.Members[0], typeof(Member));
        }
    }
}
