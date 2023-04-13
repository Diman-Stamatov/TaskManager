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
        private string errorContentMessage = "The content can`t be null or empty!";
        private string errorAuthorMessage = "The author can`t be null or empty!";
        public Comment(string author, string content)
        {
            ValidateStringNotNullOrEmpty(content, errorContentMessage);
            ValidateStringNotNullOrEmpty(author, errorAuthorMessage);
            Author = author;
            Content = content;
        }
        public string Author { get; }

        public string Content { get; }

        public override string ToString()
        {
            StringBuilder comment = new StringBuilder();
            comment.Append($"{Author}: {Content}");
            return comment.ToString();
        }
    }
}
