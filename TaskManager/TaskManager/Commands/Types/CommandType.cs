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
        ShowMembers,
        ShowMemberActivityLog,
        CreateTeam,
        ShowAllTeams,
        ShowTeamActivityLog,
        ShowTeamMembers,
        CreateBoard,
        ShowBoards,
        ShowBoardActivityLog,
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
        ListTasks,
        ListBugs,
        ListStories,
        ListFeedback,
        ListAssignees
    }
}
