using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;
using TaskManager.Models.Contracts;
using static TaskManager.Utilities.UtilityMethods;
using static TaskManager.Utilities.Validation;
using TaskManager.Utilities;

namespace TaskManager.Models
{
    public class Member : IMember
    {
        private const int MinNameLength = 5;
        private const int MaxNameLength = 15;

        private readonly IList<ITask> tasks;
        private readonly List<string> activityLog;

        private string name;
        private string teamAssignedTo;

        public Member(string name)
        {
            Name = name;
            tasks = new List<ITask>();
            activityLog = new List<string>();
            Log(Message(name));
        }

        public string Name
        {
            get => name;
            private set
            {
                ValidateStringPropertyLength(
                 value,
                 GetType().Name,
                 GetMethodName(),
                 MinNameLength,
                 MaxNameLength);
                name = value;
                
            }
        }

        public string TeamAssignedTo
        {
            get => teamAssignedTo;
        }

        public void AddTask(ITask task)
        {
            ValidateDuplicateTask(task, tasks, Name);            
            tasks.Add(task);
            Log(Message(task, Name));
        }

        public void RemoveTask(ITask task)
        {
            ValidateTaskExists(task, Tasks, Name);            
            tasks.Remove(task);
            Log(Message(task, Name));
        }

        public void Log(string newEvent)
        {
            activityLog.Add(AddDate(newEvent));
        }       

        public string PrintTasks()
        {
            StringBuilder taskOutput = new StringBuilder();
            int num = 1;
            taskOutput.AppendLine("Tasks:");
            taskOutput.AppendLine(StringGenerator('-', 10));
            foreach (var task in tasks)
            {
                taskOutput.AppendLine($"{num++}. {task.ToString()}");
                taskOutput.AppendLine(StringGenerator('-', 10));
            }
            return taskOutput.ToString().Trim();
        }

        public string ActivityLog()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Member {Name}");
            sb.AppendLine("Activities");
            foreach (var task in Tasks)
            {
                sb.AppendLine(task.PrintChangesLog());
            }
            return sb.ToString();
        }

        public string FullInfo()
        {
            StringBuilder memberOutput = new StringBuilder();
            memberOutput.AppendLine($"Member: {Name}");
            memberOutput.Append(PrintTasks());
            memberOutput.Append(ActivityLog());
            return memberOutput.ToString().Trim();
        }

        public IComment CreateComment(string content)
        {
            var comment = new Comment(Name, content);
            Log(Message(comment));
            return comment;
        }

        public IList<ITask> Tasks { get => new List<ITask>(tasks); }
                
        public void AssignToTeam(string teamName)
        {
            if (teamAssignedTo != null)
            {
                string errorMessage = $"{Name} is already assigned to a team!";
                throw new InvalidUserInputException(errorMessage);
            }            
            teamAssignedTo = teamName;
        }
      
        private string Message(IComment value)
        {
            return $"Author: {value.Author} added comment: \"{value.Content}\"";
        }
        private string Message(string name)
        {
            return $"Member with name: {name} was created";
        }
        private string Message(ITask task, string name)
        {
            return $"{GetType().Name} with title: {task.Title} Id: {task.Id} was assigned to {Name}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Member {Name} - Tasks {tasks.Count}");
            return sb.ToString();
        }
        
    }
}

