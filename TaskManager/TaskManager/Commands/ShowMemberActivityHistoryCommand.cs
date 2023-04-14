using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class ShowMemberActivityHistoryCommand : BaseCommand
    {
        public const int MinimumNumberOfArguments = 1;
        public ShowMemberActivityHistoryCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, MinimumNumberOfArguments);

            string memberName = CommandParameters[0];            

            return ShowMemberActivityHistory(memberName);
        }

        private string ShowMemberActivityHistory(string memberName)
        {
            var foundMember = Repository.GetMember(memberName);
            Console.WriteLine(foundMember.ShowActivityLog()); 
            return $"Successfully displayed {memberName}'s activity history.";
        }
    }
}
