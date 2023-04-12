using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Enums;

namespace TaskManager.Commands
{
    public class CreateBugcommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 5;

        public CreateBugcommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);
            int id = ParseIntParameter(CommandParameters[0], "ID");
            string title = CommandParameters[1];
            string description = CommandParameters[2];
            PriorityType priority = ParsePriorityTypeParameter(CommandParameters[3], "Priority");
            SeverityType severity = ParseSeverityTypeParameter(CommandParameters[4], "Serverity");

            return CreateBug(id, title, description, priority, severity);
        }
        public string CreateBug(int id,string  title, string  description, PriorityType priority, SeverityType severity)
        {
            var newBug = new Bug(id, title, description, priority, severity);
            return $"Bug with name {title} was successfully created";
        }
    }
}