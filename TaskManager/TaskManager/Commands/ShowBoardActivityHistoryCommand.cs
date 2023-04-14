using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class ShowBoardActivityHistoryCommand : BaseCommand
    {
        public const int MinimumNumberOfArguments = 2;
        public ShowBoardActivityHistoryCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, MinimumNumberOfArguments);

            string teamName = CommandParameters[0];
            string boardName = CommandParameters[1];

            return ShowBoardActivityHistory(teamName, boardName);
        }

        private string ShowBoardActivityHistory(string teamName, string boardName)
        {
            var foundTeam = Repository.GetTeam(teamName);
            var foundBoard = foundTeam.GetBoard(boardName);
            foundBoard.ShowActivityHistory();

            return $"Successfully displayed the activity history of team \"{teamName}\"'s \"{boardName}\" board.";
        }
    }
}
