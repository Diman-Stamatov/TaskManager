using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Commands.Types
{
    public enum CommandType
    {
        AddStepToReproduce,
        AddTaskComment,
        AddTaskToBoard,
        AssignTask,
        AssignMemberToTeam,
        ChangeBugPriority,
        ChangeBugSeverity,
        ChangeBugStatus,
        ChangeFeedbackRating,
        ChangeFeedbackStatus,
        ChangeStoryPriority,
        ChangeStorySize,
        ChangeStoryStatus,
        CreateBoard,
        CreateBug,
        CreateFeedback,
        CreateMember,
        CreateStory,
        CreateTeam,
        ListAssignees,
        ListBugs,
        ListFeedback,
        ListStories,
        ListTasks,
        ShowAllMembers,
        ShowAllTeamBoards,
        ShowAllTeams,
        ShowBoardActivityHistory,
        ShowMemberActivityHistory,
        ShowTeamActivityHistory,
        ShowTeamMembers,
        UnassignTask,
        ListTasksWithAssignee
    }
}
