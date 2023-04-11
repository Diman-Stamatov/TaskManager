using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models.Enums;
using TaskManager.Models.Contracts;
using static TaskManager.Utilities.UtilityMethods;
using static TaskManager.Utilities.Validation;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace TaskManager.Models
{
    public abstract class Task : ITask
    {
        private const int TaskTitleMinLenght = 10;
        private const int TaskTitleMaxLenght = 50;
        private const int DiscriptionNameMinLenght = 10;
        private const int discriptionNameMaxLenght = 500;


        private readonly IList<string> changesLog;      
        private readonly IList<Comment> comments;
        private string title;
        private string description;

        public Task(int id,string title, string description)
        {
            changesLog = new List<string>();
            comments = new List<Comment>();

            Title = title;
            Description = description;
            Id = id;

            LogChanges($"{GetType().Name} with title \"{title}\" was created");
        }

        public string Title
        {
            get => title;

            private set
            {
                ValidateStringPropertyLength(
                 value,
                 GetType().Name,
                 GetMethodName(),
                 TaskTitleMinLenght,
                 TaskTitleMaxLenght);
                title = value;
            }
        }

        public string Description
        {
            get => description;            
            private set
            {
                ValidateStringPropertyLength(
                 value,
                 GetType().Name,
                 GetMethodName(),
                 DiscriptionNameMinLenght,
                 discriptionNameMaxLenght);
                description = value;              
            }
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
            LogChanges($"Comment: \"{comment}\" added");
        }

        protected void LogChanges(string newEvent)
        {
            changesLog.Add($"{newEvent} : [{DateTime.Now.ToString("yyyyMMdd|HH:mm:ss.ffff")}]");
        }
     
        public abstract void AdvanceStatus();
        
        public abstract void RevertStatus();

        public IList<IComment> Comments { get => new List<IComment>(comments); }                
   
        public IList<string> ChangesHistory { get => new List<string>(changesLog); }

        public int Id { get; }

        public string PrintComments()
        {
            StringBuilder sb= new StringBuilder();
            int number = 1;
            sb.AppendLine("Comments:");
            sb.AppendLine(StringGenerator('*', 10));
            foreach (var comment in Comments)
            {
                sb.AppendLine($"{number++}. {comment}");
                sb.AppendLine(StringGenerator('*', 10));
            }
            return sb.ToString().Trim();
        }

        public string PrintChangesLog()
        {
            StringBuilder sb = new StringBuilder();
            int number = 1;
            sb.AppendLine("ChangesLog:");
            sb.AppendLine(StringGenerator('=', 10));
            foreach (var log in changesLog)
            {
                sb.AppendLine($"{number++}. {log}");
                sb.AppendLine(StringGenerator('=', 10));
            }
            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"Task: {GetType().Name}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Description: {Description}");
            return sb.ToString().Trim();        
        }
    }
}
