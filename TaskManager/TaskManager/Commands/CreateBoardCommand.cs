using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Core;

namespace TaskManager.Commands
{
    public class CreateBoardCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public CreateBoardCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);
            string teamName = CommandParameters[0];
            string boardName = CommandParameters[1];
            return AddBoard(teamName, boardName);
        }
        private string AddBoard(string teamName, string boardName)
        {
            ITeam foundTeam = Repository.GetTeam(teamName);
            foundTeam.CreateBoard(boardName);
            return $"Board {boardName} successfully created in team {teamName}";
        }
    }
}
