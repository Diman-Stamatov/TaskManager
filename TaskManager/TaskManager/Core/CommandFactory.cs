using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;
using TaskManager.Commands.Types;
using static TaskManager.Utilities.UtilityMethods;

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
            ICollection<string> commandParameters = this.ExtractCommandParameters(commandLine);
            ICommand command = null;

            switch (commandType)
            {
                case CommandType.AddTaskComment:
                    throw new NotImplementedException();
                case CommandType.AssignTask:
                    throw new NotImplementedException();
                case CommandType.ChangeBugPriority:
                    throw new NotImplementedException();
                case CommandType.ChangeBugSeverity:
                    throw new NotImplementedException();
                case CommandType.ChangeBugStatus:
                    throw new NotImplementedException();
                case CommandType.ChangeFeedbackRating:
                    throw new NotImplementedException();
                case CommandType.ChangeFeedbackStatus:
                    throw new NotImplementedException();
                case CommandType.ChangeStoryPriority:
                    throw new NotImplementedException();
                case CommandType.ChangeStorySize:
                    throw new NotImplementedException();
                case CommandType.ChangeStoryStatus:
                    throw new NotImplementedException();
                case CommandType.CreateBoard:
                    throw new NotImplementedException();
                case CommandType.CreateBug:
                    throw new NotImplementedException();
                case CommandType.CreateFeedback:
                    throw new NotImplementedException();
                case CommandType.CreateTeam:
                    throw new NotImplementedException();
                case CommandType.ListAssignees:
                    throw new NotImplementedException();
                case CommandType.ListBugs:
                    throw new NotImplementedException();
                case CommandType.ListFeedback:
                    throw new NotImplementedException();
                case CommandType.ListStories:
                    throw new NotImplementedException();
                case CommandType.ListTasks:
                    throw new NotImplementedException();
                case CommandType.ShowAllTeams:
                    throw new NotImplementedException();
                case CommandType.ShowBoardActivityLog:
                    throw new NotImplementedException();
                case CommandType.ShowBoards:
                    throw new NotImplementedException();
                case CommandType.ShowMemberActivityLog:
                    throw new NotImplementedException();
                case CommandType.ShowMembers:
                    throw new NotImplementedException();
                case CommandType.ShowTeamActivityLog:
                    throw new NotImplementedException();
                case CommandType.ShowTeamMembers:
                    throw new NotImplementedException();
                case CommandType.UnassignTask:
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
        private ICollection<string> ExtractCommandParameters(string commandLine)
        {
            IList<string> parameters = commandLine.Split(SplitCommandSymbol).ToList();
            parameters.RemoveAt(0);
            return parameters;
        }
    }
}
