﻿using System;
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
        private const int DiscriptionMinLenght = 10;
        private const int DiscriptionMaxLenght = 500;

        private readonly IList<string> changesLog;      
        private readonly IList<IComment> comments;

        protected string title;
        private string description;

        public Task(int id,string title, string description)
        {
            changesLog = new List<string>();
            comments = new List<IComment>();

            Title = title;
            Description = description;
            Id = id;
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
                 DiscriptionMinLenght,
                 DiscriptionMaxLenght);
                description = value;              
            }
        }

        public void AddComment(IComment comment)
        {
            comments.Add(comment);
            Log(Message(comment));
        }

        public void Log(string newEvent)
        {
            changesLog.Add(AddDate(newEvent));
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
            sb.AppendLine(GenerateString('*', 10));
            foreach (var comment in Comments)
            {
                sb.AppendLine($"{number++}. {comment}");
                sb.AppendLine(GenerateString('*', 10));
            }
            return sb.ToString().Trim();
        }

        public string PrintChangesLog()
        {
            StringBuilder sb = new StringBuilder();
            int number = 1;
            sb.AppendLine("ChangesLog:");
            sb.AppendLine(GenerateString('=', 10));
            foreach (var log in changesLog)
            {
                sb.AppendLine($"{number++}. {log}");
                sb.AppendLine(GenerateString('=', 10));
            }
            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"Task: {GetType().Name}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Description: {Description}");
            return sb.ToString();        
        }
    }
}
