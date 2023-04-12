using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Core;

namespace TaskManager.Commands
{
    internal class AssignMemberToTeamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;


        public AssignMemberToTeamCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);
            
            string teamName = CommandParameters[0];
            string memberName = CommandParameters[1];

            return AddMemberToTeam(teamName, memberName);
        }

        private string AddMemberToTeam(string teamName, string memberName)
        {
            var foundTeam = Repository.GetTeam(teamName);            
            var foundMember = Repository.GetMember(memberName);
            if (foundMember.IsAssignedToATeam == true)
            {
                string errorMessage = $"{memberName} is already assigned to a team!";
                throw new InvalidUserInputException(errorMessage);
            }
            foundTeam.AddTeamMember(foundMember);
            
            return $"{memberName} was successfully assigned to Team \"{teamName}\".";
        }
    }
}
