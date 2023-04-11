using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;
using TaskManager.Models.Contracts;
using static TaskManager.Utilities.UtilityMethods;
using static TaskManager.Utilities.Validation;

namespace TaskManager.Models
{
    public class Member : IMember
    {
        private const int MinNameLength = 5;
        private const int MaxNameLength = 15;
        private readonly IList<string> activityHistory;
        private readonly IList<ITask> tasks;
        private string name;

        public Member(string name)
        {
            Name = name;
            activityHistory = new List<string>();
            tasks = new List<ITask>();
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

        public IList<ITask> Tasks { get => new List<ITask>(tasks); }

        public IList<string> ActivityHistory { get => new List<string>(activityHistory); }
   
        public bool IsAssigned { get; set; }

        public void AddActivityHistory(string logHistory)
        {
            activityHistory.Add(logHistory);
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public string PrintTaska()
        {
            StringBuilder taskOutput = new StringBuilder();
            int num = 1;
            taskOutput.AppendLine("Tcks:");
            taskOutput.AppendLine(StringGenerator('-', 10));
            foreach (var task in tasks)
            {
                taskOutput.AppendLine($"{num++}. {task.ToString()}");
                taskOutput.AppendLine(StringGenerator('-', 10));
            }
            return taskOutput.ToString().Trim();
        }

        public string PtintActivity()
        {
            StringBuilder activityOutput = new StringBuilder();
            activityOutput.AppendLine($"Activity History:");
            int num = 1;
            activityOutput.AppendLine(StringGenerator('-', 10));
            foreach (var activity in activityHistory)
            {
                activityOutput.AppendLine($"{num++}. {activity}");
                activityOutput.AppendLine(StringGenerator('-', 10));
            }

            return activityOutput.ToString().Trim();
        }

        public override string ToString()
        {
           StringBuilder memberOutput = new StringBuilder();
            memberOutput.AppendLine($"Member: {Name}");
            memberOutput.Append(PrintTaska());
            memberOutput.Append(PtintActivity());
            return memberOutput.ToString().Trim();
        }
    }
}

