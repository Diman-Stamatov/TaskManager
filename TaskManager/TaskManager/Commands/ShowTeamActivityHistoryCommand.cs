using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class ShowTeamActivityHistoryCommand : BaseCommand
    {
        public const int MinimumNumberOfArguments = 1;
        public ShowTeamActivityHistoryCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, MinimumNumberOfArguments);

            string teamName = CommandParameters[0];            

            return ShowTeamActivityHistory(teamName);
        }

        private string ShowTeamActivityHistory(string teamName)
        {
            var foundTeam = Repository.GetTeam(teamName);
            foundTeam.ShowHistoryLog();            

            return $"Successfully displayed team \"{teamName}\"'s activity history.";
            Console.WriteLine();
        }
    }
}
