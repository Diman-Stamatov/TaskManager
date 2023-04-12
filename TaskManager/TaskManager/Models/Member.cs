﻿using System;
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
        private readonly IList<ITask> tasks;
        private readonly List<string> activityLog;
        //ToDo
        private string name;
        private bool isAssignedToATeam;

        public Member(string name)
        {
            Name = name;
            tasks = new List<ITask>();
            //Todo
            activityLog.Add(LogChanges(" "));
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
                 isAssignedToATeam = false;
                
            }
        }

        public IList<ITask> Tasks { get => new List<ITask>(tasks); }

        public bool IsAssignedToATeam
        {
            get => isAssignedToATeam;
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
            //log
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Member {Name} - Tasks {tasks.Count}");
            return sb.ToString();
        }

        public  string FullInfo()
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
            return comment;
        }
        public void AssignToATeam()
        {
            isAssignedToATeam = true;
        }
    }
}

