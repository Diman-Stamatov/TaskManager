using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Contracts;
using static TaskManager.Utilities.UtilityMethods;
using static TaskManager.Utilities.Validation;

namespace TaskManager.Models
{
    public class Comment : IComment
    {
        private string errorMessage = "The content can`t be null or empty!";
        public Comment(string author, string content)
        {
            ValidateStringNotNullOrEmpty(content, errorMessage);
            Author = author;
            Content = content;
        }
        public string Author { get; }
        //Тук ще подаваме Member.Name, за да идва като string
        public string Content { get; }
    }
}
