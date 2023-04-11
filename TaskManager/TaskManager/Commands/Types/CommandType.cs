using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Commands.Types
{
    public enum CommandType
    {
        CreateMember,
        ShowAllMembers,
        ShowMemberActivityHistory,
        CreateTeam,
        ShowAllTeams,
        ShowTeamActivityHistory,
        ShowTeamMembers,
        CreateBoard,
        ShowBoards,
        ShowAllTeamsBoards,
        ShowBoardActivityHistory,
        CreateBug,
        CreateStory,
        CreateFeedback,
        ChangeBugPriority,
        ChangeBugSeverity,
        ChangeBugStatus,
        ChangeStoryPriority,
        ChangeStorySize,
        ChangeStoryStatus,
        ChangeFeedbackRating,
        ChangeFeedbackStatus,
        AssignTask,
        UnassignTask,
        AddTaskComment,
        //Listing
        ListTasks,
        ListBugs,
        ListStories,
        ListFeedback,
        ListAssignees,

    }
}
