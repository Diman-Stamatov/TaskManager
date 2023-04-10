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

        private static int taskCounter = 0;

        private readonly IList<string> changesHistory;   //??    
        private readonly IList<Comment> comments;
        private string title;
        private string description;
        private readonly int id;
        private DateTime dateTime = DateTime.Now;


        public Task(string name, string description)
        {
            changesHistory = new List<string>();
            comments = new List<Comment>();

            Title = name;
            Description = description;
            id = ++taskCounter;
            //предлагам ви в конструктора на всеки един наследен клас,
            //да се създаде първия ред в changesHistroy съдържащ
            //името на съответния клас и DateTime.Now
            //$"{GetType{}} is created at {TimeNow}." - нещо такова
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
                AddToChangeHistory($"Title set to {title} at {TimeNow}");
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            private set
            {
                ValidateStringPropertyLength(
                 value,
                 GetType().Name,
                 GetMethodName(),
                 DiscriptionNameMinLenght,
                 discriptionNameMaxLenght);
                description = value;
                AddToChangeHistory($"Description set at {TimeNow}");
            }
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
            AddToChangeHistory($"Comment added at {TimeNow}");
        }

        protected void AddToChangeHistory(string newEvent)
        {
            //вариант
            changesHistory.Add($"{newEvent} at {TimeNow()}");
        }
        private string TimeNow()
        {
            //вариант на форматиране
            return $"[{dateTime.ToString("yyyyMMdd|HH:mm:ss.ffff")}]";
        }

        public override string ToString()
        {
            return "не съм сигурен какво се очаква да направя тук";
        }
        protected abstract void PrioritySet();

        public IList<IComment> Comments { get => new List<IComment>(comments); }                
   
        public IList<string> ChangesHistory { get => new List<string>(changesHistory); }

        public static object NextID { get; }
    }
}
