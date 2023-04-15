using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TaskManager.Tests.Utilities
{
    public static class TasksData
    {
        internal const int TaskTitleMinLenght = 10;
        internal const int TaskTitleMaxLenght = 50;
        internal const int DiscriptionMinLenght = 10;
        internal const int DiscriptionMaxLenght = 500;

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

        public static string ValidTaskTitle = GetTestString(TaskTitleMinLenght);
        public static string ValidDescription = GetTestString(DiscriptionMinLenght);

        public static string ValidBoardName = GetTestString(BoardNameMinLength);

        public static string ValidMemberName = GetTestString(MemberNameMinLength);

        public static string ValidTeamName = GetTestString(TeamNameMinLength);
    }
}
