using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Contracts;
using TaskManager.Models;
using TaskManager.Exceptions;
using Task = TaskManager.Models.Task;

namespace TaskManager.Tests.Models
{
    [TestClass]
    public class StoryTests
    {
        private IStory story;
        private IMember mockAssignee;

        [TestInitialize]
        public void Initialize()
        {
            story = GetTestStory();
            mockAssignee = GetTestMember();
            story.Assign(mockAssignee);
        }

        [TestMethod]
        public void Story_Should_ImplementIStoryInterface()
        {
            var type = typeof(Story);
            var isAssignable = typeof(IStory).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Story class does not implement IBug interface!");
        }

        [TestMethod]
        public void Story_Should_DeriveFromTask()
        {
            var type = typeof(Story);
            var isAssignable = typeof(Task).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Story class does not derive from Task base class!");
        }

        [TestMethod]
        public void StoryConstructor_ValidInput_ShouldCreateStoryObject()
        {
            int id = 1;
            string title = ValidTaskTitle;
            string description = ValidDescription;
            PriorityType priority = PriorityType.Medium;
            SizeType size = SizeType.Medium;

            Story story = new Story(id, title, description, priority, size);

            Assert.IsNotNull(story);
            Assert.IsInstanceOfType(story, typeof(Story));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        [DataRow(TaskTitleMinLength - 1)]
        [DataRow(TaskTitleMaxLength + 1)]

        public void WhenAddInvalidTitile_ShouldThrowError(int testSize)
        {
            int id = 1;
            string title = GetTestString(testSize);
            string description = ValidDescription;
            PriorityType priority = PriorityType.Medium;
            SizeType size = SizeType.Medium;

            Story story = new Story(id, title, description, priority, size);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        [DataRow(DescriptionMinLength - 1)]
        [DataRow(DescriptionMaxLength + 1)]

        public void WhenAddInvalidDescription_ShouldThrowError(int testSize)
        {
            int id = 1;
            string title = ValidTaskTitle;
            string description = GetTestString(testSize);
            PriorityType priority = PriorityType.Medium;
            SizeType size = SizeType.Medium;

            Story story = new Story(id, title, description, priority, size);
        }

        [TestMethod]
        public void AdvancePriority_ShouldAdvancePriorityByOne()
        {
            var initialPriority = story.Priority;

            story.AdvancePriority();

            Assert.AreEqual(initialPriority + 1, story.Priority);
        }

        [TestMethod]
        public void RevertPriority_ShouldRevertPriorityByOne()
        {

            var initialPriority = story.Priority;

            story.RevertPriority();

            Assert.AreEqual(initialPriority - 1, story.Priority);
        }

        [TestMethod]
        public void AdvanceStatus_ShouldAdvanceStatusByOne()
        {

            var initialStatus = story.Status;

            story.AdvanceStatus();

            Assert.AreEqual(initialStatus + 1, story.Status);
        }

        [TestMethod]
        public void RevertStatus_ShouldRevertStatusByOne()
        {
            story.AdvanceStatus();
            var initialStatus = story.Status;

            story.RevertStatus();

            Assert.AreEqual(initialStatus - 1, story.Status);
        }

        [TestMethod]
        public void AdvanceSize_ShouldAdvanceSizeByOne()
        {

            var initialStatus = story.Size;

            story.AdvanceSize();

            Assert.AreEqual(initialStatus + 1, story.Size);
        }

        [TestMethod]
        public void RevertSize_ShouldRevertSizeByOne()
        {
            story.AdvanceSize();
            var initialStatus = story.Size;

            story.RevertSize();

            Assert.AreEqual(initialStatus - 1, story.Size);
        }

        [TestMethod]
        public void StoryAssign_ValidInput_ShouldAssignStoryToMember()
        {
            IStory story = GetTestStory();
            IMember member = GetTestMember();

            story.Assign(member);

            Assert.IsNotNull(story.Assignee);
            Assert.AreEqual(story.Assignee, member);
        }

        [TestMethod]
        public void StoryUnassign_ValidInput_ShouldUnassignStoryFromMember()
        {

            IStory story = GetTestStory();
            IMember member = GetTestMember();

            story.Assign(member);
            story.Unassign();

            Assert.IsNull(story.Assignee);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]

        public void AdvancePriority_ShouldThrowException_WhenOutsideEnum()
        {
            story.AdvancePriority();
            story.AdvancePriority();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]

        public void RevertPriority_ShouldThrowException_WhenOutsideEnum()
        {
            story.RevertPriority();
            story.RevertPriority();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void RevertStatus_ShouldThrowException_WhenOutsideEnum()
        {
            story.AdvanceStatus();
            story.RevertStatus();
            story.RevertStatus();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void AdvancedStatus_ShouldThrowException_WhenOutsideEnum()
        {
            story.AdvanceStatus();
            story.AdvanceStatus();
            story.AdvanceStatus();
        }

        [TestMethod]
        public void When_StoryIsAssignedToTeam_PropertyShoildNotBeNull()
        {
            ITeam team = GetTestTeam();
            team.CreateBoard("BoardTeam");
            Board board = (Board)team.Boards[0];
            board.AddTask(story);
            Assert.IsNotNull(story.TeamAssignedTo);
        }

        [TestMethod]
        public void AddComment_ShoulAddItToTheListOfCommentsStory()
        {
            story.AddComment(GetTestComment());
            Assert.IsTrue(story.Comments.Count() != 0);
        }

        [TestMethod]
        public void ActionConserningStory_ShouldBeAddToLog()
        {
            story.AddComment(GetTestComment());
            Assert.IsTrue(story.ChangesHistory.Count != 0);
        }

        [TestMethod]
        public void ToString_Should_Return_String()
        {
            string output = story.ToString();
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void WhenStoryIsNotAssigne_OutputShouldContaune()
        {
            IStory unassigneStory = GetTestStory();
            string output = unassigneStory.ToString();
            Assert.IsTrue(output.Contains("Assigned to: Nobody yet."));
        }

    }
}
