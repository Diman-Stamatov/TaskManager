using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Contracts;
using TaskManager.Models;
using TaskManager.Exceptions;

namespace TaskManager.Tests.Models
{
    [TestClass]
    public class BugTests
    {
        private IBug bug;
        private IMember mockAssignee;

        [TestInitialize]
        public void Initialize()
        {
            bug = GetTestBug();
            mockAssignee = GetTestMember();
            bug.Assign(mockAssignee);
        }

        [TestMethod]
        public void BugConstructor_ValidInput_ShouldCreateBugObject()
        {
            int id = 1;
            string title = ValidTaskTitle;
            string description = ValidDescription;
            PriorityType priority = PriorityType.Medium;
            SeverityType severity = SeverityType.Minor;

            Bug bug = new Bug(id, title, description, priority, severity);

            Assert.IsNotNull(bug);
            Assert.IsInstanceOfType(bug, typeof(Bug));
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
            SeverityType severity = SeverityType.Minor;
            Bug bug = new Bug(id, title, description, priority, severity);
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
            SeverityType severity = SeverityType.Minor;
            Bug bug = new Bug(id, title, description, priority, severity);
        }

        [TestMethod]
        public void AddStepToReproduce_ShouldAddNewStep()
        {
            string newStep = "New step to reproduce";

            bug.AddStepToReproduce(newStep);

            Assert.AreEqual(1, bug.StepsToReproduce.Count);
            Assert.AreEqual("1. New step to reproduce", bug.StepsToReproduce[0]);
        }

        [TestMethod]
        public void AdvancePriority_ShouldAdvancePriorityByOne()
        {
            var initialPriority = bug.Priority;

            bug.AdvancePriority();

            Assert.AreEqual(initialPriority + 1, bug.Priority);
        }

        [TestMethod]
        public void RevertPriority_ShouldRevertPriorityByOne()
        {

            var initialPriority = bug.Priority;

            bug.RevertPriority();

            Assert.AreEqual(initialPriority - 1, bug.Priority);
        }

        [TestMethod]
        public void AdvanceStatus_ShouldAdvanceStatusByOne()
        {

            var initialStatus = bug.Status;

            bug.AdvanceStatus();

            Assert.AreEqual(initialStatus + 1, bug.Status);
        }

        [TestMethod]
        public void RevertStatus_ShouldRevertStatusByOne()
        {
            bug.AdvanceStatus();
            var initialStatus = bug.Status;

            bug.RevertStatus();

            Assert.AreEqual(initialStatus - 1, bug.Status);
        }

        [TestMethod]
        public void AdvanceSeverity_ShouldAdvanceSeverityByOne()
        {
            var initialSeverity = bug.Severity;

            bug.AdvanceSeverity();

            Assert.AreEqual(initialSeverity + 1, bug.Severity);
        }

        [TestMethod]
        public void RevertSeverity_ShouldRevertSeverityByOne()
        {
            var initialSeverity = bug.Severity;

            bug.RevertSeverity();

            Assert.AreEqual(initialSeverity - 1, bug.Severity);
        }

        [TestMethod]
        public void BugAssign_ValidInput_ShouldAssignBugToMember()
        {
            IBug bug = GetTestBug();
            IMember member = GetTestMember();

            bug.Assign(member);

            Assert.IsNotNull(bug.Assignee);
            Assert.AreEqual(bug.Assignee, member);
        }

        [TestMethod]
        public void BugUnassign_ValidInput_ShouldUnassignBugFromMember()
        {

            IBug bug = GetTestBug();
            IMember member = GetTestMember();
            bug.Assign(member);

            bug.Unassign();

            Assert.IsNull(bug.Assignee);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]

        public void AdvancePriority_ShouldThrowException_WhenOutsideEnum()
        {
            bug.AdvancePriority();
            bug.AdvancePriority();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]

        public void RevertPriority_ShouldThrowException_WhenOutsideEnum()
        {
            bug.RevertPriority();
            bug.RevertPriority();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]

        public void AdvanceSeverity_ShouldThrowException_WhenOutsideEnum()
        {
            bug.AdvanceSeverity();
            bug.AdvanceSeverity();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]

        public void RevertSeverity_ShouldThrowException_WhenOutsideEnum()
        {
            bug.RevertSeverity();
            bug.RevertSeverity();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void RevertStatus_ShouldThrowException_WhenOutsideEnum()
        {
            bug.AdvanceStatus();
            bug.RevertStatus();
            bug.RevertStatus();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void AdvancedStatus_ShouldThrowException_WhenOutsideEnum()
        {
            bug.AdvanceStatus();
            bug.AdvanceStatus();
        }

        [TestMethod]
        public void When_BugIsAssignedToTeam_PropertyShoildNotBeNull()
        {
            ITeam team = GetTestTeam();
            team.CreateBoard("BoardTeam");
            Board board = (Board)team.Boards[0];
            board.AddTask(bug);
            Assert.IsNotNull(bug.TeamAssignedTo);

        }

        [TestMethod]
        public void AddComment_ShoulAddItToTheListOfCommentsBug()
        {
            bug.AddComment(GetTestComment());
            Assert.IsTrue(bug.Comments.Count() != 0);
        }

        [TestMethod]

        public void ActionConserningBug_ShouldBeAddToLog()
        {
            bug.AddComment(GetTestComment());
            Assert.IsTrue(bug.ChangesHistory.Count != 0);
        }

        /* public void LogHistory_SouldPrint()
        {
            Issue issue = TestHelpers.GetValidIssue();
            ConsoleLogger logger = new ConsoleLogger();
            Board.AddItem(issue);
            var result = new StringWriter();
            Console.SetOut(result);
            Board.LogHistory(logger);

            Assert.IsTrue(!string.IsNullOrEmpty(result.ToString()));
        }*/




    }
}
