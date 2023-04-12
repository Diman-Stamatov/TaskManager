using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;

namespace TaskManager.Commands
{
    public class CreateBoardCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 0;
        //Трябва да решим, колко параметъра ще приема тази команда

        public CreateBoardCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);
            string teamName = CommandParameters[0];
            string boardName = CommandParameters[1];
            return ;
        }
        private string AddBoard(string teamName, string boardName)
        {
            var foundMember = Repository.GetMember(author);

            return $"{author} successfully added a comment to {foundTask.GetType().Name} ID number {id}.";
        }
    }
}
