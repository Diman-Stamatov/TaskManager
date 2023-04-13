using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Core;

namespace TaskManager.Commands
{
    internal class AssignMemberToTask : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;


        public AssignMemberToTask(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            string content = CommandParameters[1];

            return AddMemberToTeam(taskId, content);
        }

        private string AddMemberToTeam(int taskName, string memberName)
        {
            var foundTeam = Repository.GetTask(taskName);
            IMember foundMember = Repository.GetMember(memberName);
            if (foundMember.IsAssignedToATeam == true)
            {
                string errorMessage = $"{memberName} is already assigned to a team!";
                throw new InvalidUserInputException(errorMessage);
            }
            foundTeam.();

            return $"{memberName} was successfully assigned to Team \"{teamName}\".";
        }
    }
}
