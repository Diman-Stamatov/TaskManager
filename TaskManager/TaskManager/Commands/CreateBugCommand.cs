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
            string title = CommandParameters[0];
            string description = CommandParameters[1];
            PriorityType priority = ParsePriorityTypeParameter(CommandParameters[2], "Priority");
            SeverityType severity = ParseSeverityTypeParameter(CommandParameters[3], "Serverity");

            return CreateBug(title, description, priority, severity);
        }
        public string CreateBug(string  title, string  description, PriorityType priority, SeverityType severity)
        {                           
            var newBug = Repository.CreateBug(title, description, priority, severity);           
            return $"Bug with ID {newBug.Id} was successfully created";
        }
    }
}