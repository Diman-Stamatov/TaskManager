using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
   public class ShowTeamMembersCommand : BaseCommand
    {
        public const int MinimumNumberOfArguments = 1;
        public ShowTeamMembersCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, MinimumNumberOfArguments);

            string teamName = CommandParameters[0];

            return ShowTeamMembers(teamName);
        }

        private string ShowTeamMembers(string teamName)
        {
            var foundTeam = Repository.GetTeam(teamName);
            foundTeam.ShowTeamMembers();

            return $"Successfully displayed the activity history of the members assigned to team \"{teamName}\".";
        }
    }
}
