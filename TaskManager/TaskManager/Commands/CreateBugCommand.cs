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
        public const int MinimumNumberOfArguments = 5;

        public CreateBugcommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            int numberOfArguments = CommandParameters.Count;
            ValidateArgumentsCount(numberOfArguments, MinimumNumberOfArguments);

            string title = CommandParameters[0];
            CommandParameters.RemoveAt(0);
            int lastIndex = CommandParameters.Count-1;
            SeverityType severity = ParseSeverityTypeParameter(CommandParameters[lastIndex], "Serverity");
            CommandParameters.RemoveAt(lastIndex);
            lastIndex = CommandParameters.Count - 1;
            PriorityType priority = ParsePriorityTypeParameter(CommandParameters[lastIndex], "Priority");
            string description = string.Join(" ", CommandParameters);

            return CreateBug(title, description, priority, severity);
        }
        public string CreateBug(string  title, string  description, PriorityType priority, SeverityType severity)
        {                           
            var newBug = Repository.CreateBug(title, description, priority, severity);           
            return $"Bug with ID {newBug.Id} was successfully created";
        }
    }
}