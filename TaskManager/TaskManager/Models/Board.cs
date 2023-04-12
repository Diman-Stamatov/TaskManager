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
            this.Name = name;
            this.tasks = new List<ITask>();
            this.activityHistory = new List<string>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, className, propertyName, BoardNameMinLength, BoardNameMaxLength);
                this.name = value;
            }
        }

        public IList<string> ActivityHistory
        { 
            get 
            { 
                return new List<string>(this.activityHistory); 
            }
        }

        public IList<ITask> Tasks
        {
            get
            {
                return new List<ITask>(this.tasks);
            }
        }
        public override string ToString()
        {
            string boardInfo = $"Board name: {Name}" +
                $"\nNumber of tasks on the board: {Tasks.Count}";
            return boardInfo;
        }
        
    }
}
