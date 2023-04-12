using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces;
using TaskManager.Models.Contracts;
using TaskManager.Models;

namespace TaskManager.Commands
{
    public class AssignTaskCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;        

        public AssignTaskCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentsCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(CommandParameters[0], "ID");           
            string assigneeName = CommandParameters[1];

            return AssignTask(taskId, assigneeName);
        }

        private string AssignTask(int taskId, string assigneeName)
        {
            var foundMember = Repository.GetMember(assigneeName);
            if (foundMember.IsAssignedToATeam == false)
            {
                throw new InvalidUserInputException($"{assigneeName} should be assigned to a team before being assigned a task!");
            }
            ITask foundTask = Repository.GetTask(taskId);
            string successMessage = "{0} ID number {1} was assigned to {2}.";
            string taskTypeName = foundTask.GetType().Name;

            if (foundTask.GetType() == typeof(Feedback))
            {
                string errorMessage = "Cannot assign a Feedback to an employee!";
                throw new InvalidUserInputException(errorMessage);
            }
            else if (foundTask.GetType() == typeof(Bug))
            {
                IBug foundBug = (IBug)foundTask;
                foundBug.Assignee = foundMember;
                foundMember.AssignToATeam();
                return string.Format(successMessage, taskTypeName, taskId, assigneeName);
            }
            else
            {
                IStory foundStory = (IStory)foundTask;
                foundStory.Assignee = foundMember;
                return string.Format(successMessage, taskTypeName, taskId, assigneeName);
            }
        }
    }
}
