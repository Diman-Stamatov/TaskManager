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
        private string InvalidContentMessage = "Please specify the comment's contents!";
        private string InvalidAuthorMessage = "Please specify the comment's author!";
        public Comment(string author, string content)
        {
            ValidateStringNotNullOrEmpty(content, InvalidContentMessage);
            ValidateStringNotNullOrEmpty(author, InvalidAuthorMessage);
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
