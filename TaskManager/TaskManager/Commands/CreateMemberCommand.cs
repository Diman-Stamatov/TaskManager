using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class CreateMemberCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public CreateMemberCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);
            string memberName = CommandParameters[0];
                
                return CreateMember(memberName);
        }
        private string CreateMember(string memberName)
        {
            var newMember = Repository.CreateMember(memberName);
            return $"Member with name {memberName} was successfully created";
        }
    }
}
