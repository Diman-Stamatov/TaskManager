using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Core;
using TaskManager.Models;
using TaskManager.Models.Contracts;
using TaskManager.Commands;
using TaskManager.Exceptions;

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
        public static string ValidTaskTitle = GetTestString(TaskTitleMinLength);
        public static string ValidDescription = GetTestString(DescriptionMinLength);
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

      /*  public static IRepository GetTestRepository()
        {
            IRepository repository = new Repository();
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.Medium, SizeType.Medium);
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.High, SizeType.Small);
            repository.CreateStory(ValidTaskTitle, ValidDescription, PriorityType.Low, SizeType.Large);
            repository.CreateBug(ValidTaskTitle, ValidDescription, PriorityType.Medium, SeverityType.Minor);
            repository.CreateBug(ValidTaskTitle, ValidDescription, PriorityType.High, SeverityType.Major);
            repository.CreateBug(ValidTaskTitle, ValidDescription, PriorityType.Low, SeverityType.Critical);
            var member2 = repository.CreateMember("MemberOne");
            var member3 = repository.CreateMember("SomeRandom");
            Team team1 = (Team)repository.CreateTeam("Team1");
            team1.AddTeamMember(member2);
            team1.AddTeamMember(member3);
            Story story = (Story)repository.Tasks[0];
            story.Assign(member2);
            Story story2 = (Story)repository.Tasks[1];
            story2.Assign(member3);
            story2.AdvanceStatus();
            Story story3 = (Story)repository.Tasks[2];
            story3.Assign(member3);
            story3.AdvanceStatus();
            story3.AdvanceStatus();
            Bug bug = (Bug)repository.Tasks[3];
            bug.Assign(member2);
            bug.AdvanceStatus();
            Bug bug2 = (Bug)repository.Tasks[4];
            bug2.Assign(member3);
            Bug bug3 = (Bug)repository.Tasks[5];
            bug3.Assign(member2);

            return new Repository();
        }*/
 
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
