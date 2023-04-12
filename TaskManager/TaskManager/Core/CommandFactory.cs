using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;
using TaskManager.Commands.Types;
using static TaskManager.Utilities.UtilityMethods;
using TaskManager.Commands.Contracts;
using TaskManager.Commands;
using TaskManager.Commands.Interfaces;

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
            ICommand command = null;

            switch (commandType)
            {
                case CommandType.AddTaskComment:
                    return new AddTaskCommentCommand(commandParameters, repository);
                case CommandType.AssignTask:
                    return new AssignTask(commandParameters, repository);
                case CommandType.ChangeBugPriority:
                    return new ChangeBugPriority(commandParameters, repository);
                case CommandType.ChangeBugSeverity:
                    return new ChangeBugSeverity(commandParameters, repository);
                case CommandType.ChangeBugStatus:
                    return new ChangeBugStatus(commandParameters, repository);
                case CommandType.ChangeFeedbackRating:
                    return new ChangeFeedbackRating(commandParameters, repository);
                case CommandType.ChangeFeedbackStatus:
                    return new ChangeFeedbackStatus(commandParameters, repository);
                case CommandType.ChangeStoryPriority:
                    return new ChangeStoryPriority(commandParameters, repository);
                case CommandType.ChangeStorySize:
                    return new ChangeStorySize(commandParameters, repository);
                case CommandType.ChangeStoryStatus:
                    return new ChangeStoryStatus(commandParameters, repository);
                case CommandType.CreateBoard:
                    return new CreateBoard(commandParameters, repository);
                case CommandType.CreateBug:
                    return new CreateBug(commandParameters, repository);
                case CommandType.CreateStory:
                    return new CreateStory(commandParameters, repository);
                case CommandType.CreateFeedback:
                    return new CreateFeedback(commandParameters, repository);
                case CommandType.CreateMember:
                    return new CreateMember(commandParameters, repository);
                case CommandType.CreateTeam:
                    return new CreateTeam(commandParameters, repository);
                case CommandType.ListAssignees:
                    return new ListAssignees(commandParameters, repository);
                case CommandType.ListBugs:
                    return new ListBugs(commandParameters, repository); ;
                case CommandType.ListFeedback:
                    return new ListFeedback(commandParameters, repository);
                case CommandType.ListStories:
                    return new ListStories(commandParameters, repository);
                case CommandType.ListTasks:
                    return new ListTasks(commandParameters, repository);
                case CommandType.ShowAllTeams:
                    throw new NotImplementedException();
                case CommandType.ShowBoardActivityHistory:
                    throw new NotImplementedException();
                case CommandType.ShowBoards:
                    throw new NotImplementedException();
                case CommandType.ShowMemberActivityHistory:
                    throw new NotImplementedException();
                case CommandType.ShowAllMembers:
                    throw new NotImplementedException();
                case CommandType.ShowTeamActivityHistory:
                    throw new NotImplementedException();
                case CommandType.ShowTeamMembers:
                    throw new NotImplementedException();
                case CommandType.UnassignTask:
                    throw new NotImplementedException();
                case CommandType.ShowAllTeamsBoards:
                    throw new NotImplementedException();
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
            IList<string> parameters = commandLine.Split(SplitCommandSymbol).ToList();
            parameters.RemoveAt(0);
            return parameters;
        }
    }
}
