using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Enums;

namespace TaskManager.Commands
{
    public class CreateStoryCommand : BaseCommand
    {
        public const int MinimumNumberOfArguments = 4;

        public CreateStoryCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            int numberOfArguments = CommandParameters.Count;
            ValidateArgumentsCount(numberOfArguments, MinimumNumberOfArguments);

            string title = CommandParameters[0];
            CommandParameters.RemoveAt(0);
            int lastIndex = CommandParameters.Count - 1;
            SizeType size = ParseSizeTypeParameter(CommandParameters[lastIndex], "SizeType");
            CommandParameters.RemoveAt(lastIndex);
            lastIndex = CommandParameters.Count - 1;
            PriorityType priority = ParsePriorityTypeParameter(CommandParameters[lastIndex], "Priority");
            CommandParameters.RemoveAt(lastIndex);
            string description = string.Join(" ", CommandParameters);    

            return CreateStory(title, description, priority, size);
        }
        public string CreateStory(string title, string description, PriorityType priority, SizeType size)
        {
            var newStory = Repository.CreateStory(title, description, priority, size);
            return $"A story titled {title} with ID {newStory.Id} was successfully created";
        }
    }
}
