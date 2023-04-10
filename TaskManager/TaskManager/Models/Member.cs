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
        //ActivityHistory ще връща копие на листа, за да не може да се правят неволни промени в него
        public bool IsAssigned { get; set; }

        //Добавяме през метод, за да защитим списъка
        public void AddActivityHistory(string logHistory)
        {
            activityHistory.Add(logHistory);
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public override string ToString()
        {
           StringBuilder memberOutput = new StringBuilder();
            memberOutput.AppendLine($"Member: {Name}");
            memberOutput.AppendLine("Tcks:");
            int num = 1;
            foreach (var task in tasks)
            {
                memberOutput.AppendLine($"{num++}. {task.ToString()}");
                memberOutput.AppendLine(StringGenerator('-', 10));
            } 
            memberOutput.AppendLine(StringGenerator('-',10));
            memberOutput.AppendLine($"Activity History:");
            num = 1;
            foreach (var activity in activityHistory)
            {
                memberOutput.AppendLine($"{num++}. {activity}");
                memberOutput.AppendLine(StringGenerator('-', 10));
            }
            
            return memberOutput.ToString();
        }
    }
}

