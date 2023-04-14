using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Exceptions;
using TaskManager.Models;
using TaskManager.Models.Contracts;

using static TaskManager.Utilities.Validation;

namespace TaskManager.Commands
{
    public class AddTaskCommentCommand : BaseCommand
    {
        public const int MinimumNumberOfArguments = 3;
        

        public AddTaskCommentCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

         public override string Execute()
        {
            int numberOfArguments = CommandParameters.Count;
            ValidateArgumentsCount(numberOfArguments, MinimumNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            CommandParameters.RemoveAt(0);
            int lastIndex = CommandParameters.Count - 1;
            string author = CommandParameters[lastIndex];
            CommandParameters.RemoveAt(lastIndex);
            string content = string.Join(" ", CommandParameters);
                      

            return AddTaskComment(taskId, content, author);
        }

        private string AddTaskComment(int id, string content, string author)
        {
            var foundMember = Repository.GetMember(author);
            ITask foundTask = Repository.GetTask(id);
            var newComment = new Comment(foundMember.Name, content);
            foundTask.AddComment(newComment);

            return $"{author} successfully added a comment to {foundTask.GetType().Name} ID number {id}.";
        }

    }
}
