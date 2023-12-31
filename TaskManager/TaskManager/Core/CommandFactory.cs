﻿using TaskManager.Commands;
using TaskManager.Commands.Contracts;
using TaskManager.Commands.Types;
using TaskManager.Core.Interfaces;


namespace TaskManager.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const char SplitCommandSymbol = ' ';

        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {

            CommandType commandType = ParseCommandType(commandLine);
            IList<string> commandParameters = this.ExtractCommandParameters(commandLine);           

            switch (commandType)
            {
                case CommandType.AddStepToReproduce:
                    return new AddStepToReproduceCommand(commandParameters, repository);
                case CommandType.AddTaskComment:
                    return new AddTaskCommentCommand(commandParameters, repository);
                case CommandType.AddTaskToBoard:
                    return new AddTaskToBoardCommand(commandParameters, repository);
                case CommandType.AssignMemberToTeam:
                    return new AssignMemberToTeamCommand(commandParameters, repository);
                case CommandType.AssignTask:
                    return new AssignTaskCommand(commandParameters, repository);
                case CommandType.ChangeBugPriority:
                    return new ChangeBugPriorityCommand(commandParameters, repository);
                case CommandType.ChangeBugSeverity:
                    return new ChangeBugSeverityCommand(commandParameters, repository);
                case CommandType.ChangeBugStatus:
                    return new ChangeBugStatusCommand(commandParameters, repository);
                case CommandType.ChangeFeedbackRating:
                    return new ChangeFeedbackRatingCommand(commandParameters, repository);
                case CommandType.ChangeFeedbackStatus:
                    return new ChangeFeedbackStatusCommand(commandParameters, repository);
                case CommandType.ChangeStoryPriority:
                    return new ChangeStoryPriorityCommand(commandParameters, repository);
                case CommandType.ChangeStorySize:
                    return new ChangeStorySizeCommand(commandParameters, repository);
                case CommandType.ChangeStoryStatus:
                    return new ChangeStoryStatusCommand(commandParameters, repository);
                case CommandType.CreateBoard:
                    return new CreateBoardCommand(commandParameters, repository);
                case CommandType.CreateBug:
                    return new CreateBugcommand(commandParameters, repository);
                case CommandType.CreateFeedback:
                    return new CreateFeedbackCommand(commandParameters, repository);                
                case CommandType.CreateMember:
                    return new CreateMemberCommand(commandParameters, repository);
                case CommandType.CreateStory:
                    return new CreateStoryCommand(commandParameters, repository);
                case CommandType.CreateTeam:
                    return new CreateTeamCommand(commandParameters, repository);
                case CommandType.ListAssignees:
                    return new ListAssigneesCommand(repository);
                case CommandType.ListBugs:
                    return new ListBugsCommand(commandParameters, repository); 
                case CommandType.ListFeedback:
                    return new ListFeedbackCommand(commandParameters, repository);
                case CommandType.ListStories:
                    return new ListStoriesCommand(commandParameters, repository);
                case CommandType.ListTasks:
                    return new ListTasksCommand(commandParameters, repository);
                case CommandType.ListTasksWithAssignee:
                    return new ListTasksWithAssigneeCommand(commandParameters, repository);
                case CommandType.ShowAllMembers:
                    return new ShowAllMembersCommand(repository);
                case CommandType.ShowAllTeamBoards:
                    return new ShowAllTeamBoardsCommand(repository);
                case CommandType.ShowAllTeams:
                    return new ShowAllTeamsCommand(repository);
                case CommandType.ShowBoardActivityHistory:
                    return new ShowBoardActivityHistoryCommand(commandParameters, repository);                
                case CommandType.ShowMemberActivityHistory:
                    return new ShowMemberActivityHistoryCommand(commandParameters, repository);               
                case CommandType.ShowTeamActivityHistory:
                    return new ShowTeamActivityHistoryCommand(commandParameters, repository);
                case CommandType.ShowTeamMembers:
                    return new ShowTeamMembersCommand(commandParameters, repository);
                case CommandType.UnassignTask:
                    return new UnassignTaskCommand(commandParameters, repository);                
                default:
                    throw new InvalidUserInputException($"Command with name: {commandType} doesn't exist!");
            }
        }

        // Receives a full line and extracts the command to be executed from it.
        // For example, if the input line is "FilterBy Assignee John", the method will return "FilterBy".
        private CommandType ParseCommandType(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandSymbol)[0];
            if (Enum.TryParse(commandName, true, out CommandType result))
            {
                return result;
            }
            
            throw new InvalidUserInputException($"Invalid command. Please use a valid command.");
        }

        // Receives a full line and extracts the parameters that are needed for the command to execute.
        // For example, if the input line is "FilterBy Assignee John",
        // the method will return a list of ["Assignee", "John"].
        private IList<string> ExtractCommandParameters(string commandLine)
        {
            IList<string> parameters = commandLine.Split(SplitCommandSymbol, StringSplitOptions.RemoveEmptyEntries).ToList();
            parameters.RemoveAt(0);
            return parameters;
        }
    }
}
