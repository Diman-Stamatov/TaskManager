using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Contracts;
using TaskManager.Models;
using TaskManager.Exceptions;
using Task = TaskManager.Models.Task;
using System.Drawing;
using System.Xml.Linq;

namespace TaskManager.Tests.Models
{
    [TestClass]
    public class BoardTests
    {
        private IBoard mockBoard;
        private IBug mockBug;
        private IStory mockStory;
        private IFeedback mockFeedback;

        [TestInitialize]
        public void Initialize()
        {
            mockBoard = GetTestBoard();
            mockBug = GetTestBug();
            mockStory = GetTestStory();
            mockFeedback = GetTestFeedback();
        }

        [TestMethod]
        public void Board_ShoudImplementIBoardInterface()
        {
            var type = typeof(Board);
            var isAssignable = typeof(IBoard).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Board class does not implement IBoard interface!");
        }

        [TestMethod]
        public void BoardConstructor_ValidInput_ShouldCreateBoardObject()
        {
            string title = ValidBoardName;
            Board board = new Board(title);
            Assert.IsNotNull(board);
            Assert.IsInstanceOfType(board, typeof(Board));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        [DataRow(BoardNameMinLength - 1)]
        [DataRow(BoardNameMaxLength + 1)]

        public void WhenAddInvalidTitile_ShouldThrowError(int testSize)
        {
            string title = GetTestString(testSize);
            Board board = new Board(title);

        }

        [TestMethod]
        public void TaskShouldAddBug_When_BugIsValid()
        {
            mockBoard.AddTask(mockBug);
            Assert.AreEqual(1, mockBoard.Tasks.Count);
            Assert.IsInstanceOfType(mockBoard.Tasks[0], typeof(Bug));
        }

        [TestMethod]
        public void TaskShoudAddStory_When_StoryIsValid()
        {
            mockBoard.AddTask(mockStory);
            Assert.AreEqual(1, mockBoard.Tasks.Count());
            Assert.IsInstanceOfType(mockBoard.Tasks[0], typeof(Story));
        }

        [TestMethod]
        public void TaskShoudAddFeedback_When_FeedbackIsValid()
        {
            mockBoard.AddTask(mockFeedback);
            Assert.AreEqual(1, mockBoard.Tasks.Count());
            Assert.IsInstanceOfType(mockBoard.Tasks[0], typeof(Feedback));
        }

        [TestMethod]
        public void ToString_Should_Return_String_Value()
        {
            string output = mockBoard.ToString();
            Assert.IsNotNull(output);
            Assert.IsInstanceOfType(output, typeof(string));
        }
    }
}
