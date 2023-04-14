using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class CreateTeamCommand : BaseCommand
    {                           
        public const int ExpectedNumberOfArguments = 1;

        public CreateTeamCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);
            string teamName = CommandParameters[0];
            return CreateTeam(teamName);
        }
        public string CreateTeam(string teamName)
        {
            return $"Team with name {teamName} was successfully created";
        }
    }
}
