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
    public class Board : IBoard
    {
        public const int BoardNameMinLength = 5;
        public const int BoardNameMaxLength = 10;

        private string name;
        private IList<ITask> tasks;
        private IList<string> activityHistory;

        public Board(string name)
        {
            Name = name;
            tasks = new List<ITask>();
            activityHistory = new List<string>();
            Log(Message(name));
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                string className = GetType().Name;
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(
                    value, 
                    className, 
                    propertyName, 
                    BoardNameMinLength, 
                    BoardNameMaxLength);
                name = value;
            }
        }

        public IList<string> ActivityHistory
        { 
            get =>new List<string>(activityHistory); 
            
        }

        public IList<ITask> Tasks
        {
            get => new List<ITask>(tasks);
        }
       
        public void AddTask(Task task)
        {
            tasks.Add(task);
            Log(Message(task));
        }
        
        private void Log(string newEvent)
        {
            activityHistory.Add(AddDate(newEvent));
        }
        
        private string Message(string name)
        {
            return $"{name} board was created";
        }
        
        private string Message(Task task)
        {
            return $"{task.GetType} with title {task.Title} and {task.Id} is added at board: {Name}";
        }
        public override string ToString()
        {
            string boardInfo = $"Board name: {Name}" +
                $"\nNumber of tasks on the board: {Tasks.Count}";
            return boardInfo;
        }
        
    }
}
