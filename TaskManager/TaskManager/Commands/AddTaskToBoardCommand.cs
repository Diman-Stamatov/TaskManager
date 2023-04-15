using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Core;

namespace TaskManager.Commands
{
    public class AddTaskToBoardCommand :BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;


        public AddTaskToBoardCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            string teamName = CommandParameters[1];
            string boardName = CommandParameters[2];

            return AddTaskToBoard(taskId, teamName, boardName);
        }

        private string AddTaskToBoard(int taskId, string teamName, string boardName)
        {
            var foundTask = Repository.GetTask(taskId);
            var foundTeam = Repository.GetTeam(teamName);
            var teamBoards = foundTeam.Boards;
            string foundTeamName = foundTeam.Name;
            ValidateMissingBoard(boardName, teamBoards, foundTeamName);
            var foundBoard = foundTeam.GetBoard(boardName);
            foundBoard.AddTask(foundTask);
            
            string foundTaskType = foundTask.GetType().Name;
            string successMessage = $"{foundTaskType} ID number {taskId} successfully added to board \"{boardName}\" in team \"{teamName}\".";
            foundTask.Log(successMessage);
            foundBoard.Log(successMessage);
            return successMessage;
        }
    }
}
