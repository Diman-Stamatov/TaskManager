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
        public const int ExpectedNumberOfArguments = 3;

        public CreateStoryCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);
            string title = CommandParameters[0];
            string description = CommandParameters[1];
            PriorityType priority = ParsePriorityTypeParameter(CommandParameters[2], "Priority");
            SizeType size = ParseSizeTypeParameter(CommandParameters[3], "SizeType");

            return CreateStory(title, description, priority, size);
        }
        public string CreateStory(string title, string description, PriorityType priority, SizeType size)
        {
            var newStory = Repository.CreateStory(title, description, priority, size);
            return $"Story with ID {newStory.Id} was successfully created";
        }
    }
}
