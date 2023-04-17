using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Models.Contracts;

namespace TaskManager.Tests.Utilities
{
    public static class TasksData
    {
        internal const int TaskTitleMinLength = 10;
        internal const int TaskTitleMaxLength = 50;
        internal const int DescriptionMinLength = 10;
        internal const int DescriptionMaxLength = 500;

        internal const BugStatusType InitialBugStatus = BugStatusType.Active;

        internal const int RatingMinValue = 0;
        internal const int RatingMaxValue = 10;
        internal const FeedbackStatusType InitialFeedbackStatus = FeedbackStatusType.New;

        internal const StoryStatusType InitialStoryStatus = StoryStatusType.NotDone;        
    }
    internal static class BoardData
    {
        internal const int BoardNameMinLength = 5;
        internal const int BoardNameMaxLength = 10;
    }
    internal static class MemberData
    {
        internal const int MemberNameMinLength = 5;
        internal const int MemberNameMaxLength = 15;
    }
    internal static class TeamData
    {
        internal const int TeamNameMinLength = 5;
        internal const int TeamNameMaxLength = 15;
    }
    public static class HelperValues
    {
        public static string GetTestString(int size)
        {
            return new string('x', size);
        }

        public static int ValidId = 1;
        public static string ValidTaskTitle = GetTestString(TaskTitleMinLenght);
        public static string ValidDescription = GetTestString(DiscriptionMinLenght);
        public static PriorityType ValidPriority = PriorityType.Medium;
        public static SeverityType ValidSeverity = SeverityType.Major;
        public static SizeType ValidSize = SizeType.Medium;

        public static string ValidBoardName = GetTestString(BoardNameMinLength);

        public static string ValidMemberName = GetTestString(MemberNameMinLength);

        public static string ValidTeamName = GetTestString(TeamNameMinLength);
        public static IMember GetTestMember()
        {
            return new Member(ValidMemberName);
        }
        public static IBug GetTestBug()
        {
            return new Bug(ValidId, ValidTaskTitle, ValidDescription, ValidPriority, ValidSeverity);
        }
        public static IFeedback GetTestFeedback()
        {
            return new Feedback(ValidId, ValidTaskTitle, ValidDescription, RatingMinValue);
        }
        public static IStory GetTestStory()
        {
            return new Story(ValidId, ValidTaskTitle, ValidDescription, ValidPriority, ValidSize);
        }

        public static IBoard GetTestBoard()
        {
            return new Board(ValidBoardName);
        }
        public static ITeam GetTestTeam()
        {
            return new Team(ValidTeamName);
        }
        public static IComment GetTestComment()
        {
            return new Comment(ValidMemberName, ValidDescription);
        }
    }
    /*[TestMethod]
    [DataRow(AssigneeMaxLength + 1)]
    [DataRow(AssigneeMaxLength + 2)]
    [DataRow(AssigneeMinLength - 1)]
    [DataRow(AssigneeMinLength - 2)]
    public void Task_ShouldThrow_WhenAssigneeIsInvalidLength(int testSize)
    {
        string validTitle = GetTestString(TitleMaxLength);
        string testAssignee = GetTestString(testSize);

        Assert.ThrowsException<ArgumentException>(() =>
        new Task(validTitle, testAssignee, ValidDate));
    }*/
}
