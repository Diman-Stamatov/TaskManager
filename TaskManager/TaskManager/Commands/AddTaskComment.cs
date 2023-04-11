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
    public class AddTaskComment : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;
        

        public AddTaskComment(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

         public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");
            string content = CommandParameters[1];
            string author = CommandParameters[2];           

            return AddComment(taskId, content, author);
        }

        private string AddComment(int id, string content, string author)
        {
            var foundMember = Repository.GetMember(author);
            ITask foundTask = Repository.GetTask(id);
            var newComment = new Comment(foundMember.Name, content);
            foundTask.AddComment(newComment);

            return $"{author} successfully added a comment to {foundTask.GetType().Name} ID number {id}.";
        }

    }
}
